using System;
using System.Collections.Generic;
using NAudio.Wave;

namespace SoundCore.Audio
{

    public static class BpmDetector
    {
        private const int EnvFps = 200;           
        private const int MinBpm = 70;             
        private const int MaxBpm = 180;
        private const double SegundosAnalisis = 45; 
        private const int BpmMinimoValido = 60;    
        private const int BpmMaximoValido = 220;

        public static int Detectar(string filePath)
        {
            var env = ConstruirEnvolvente(filePath);

            if (env.Count < EnvFps * 5)
            {
                return 120;
            }

            int n = env.Count;
            var onset = new double[n];
            double media = 0;
            for (int i = 1; i < n; i++)
            {
                onset[i] = Math.Max(0, env[i] - env[i - 1]);
                media += onset[i];
            }
            media /= n;
            for (int i = 0; i < n; i++) onset[i] -= media;

            int lagMin = (int)(60.0 * EnvFps / MaxBpm);
            int lagMax = (int)(60.0 * EnvFps / MinBpm);
            var acf = new double[lagMax + 2];
            int mejorLag = lagMin;
            double mejor = double.MinValue;

            for (int lag = lagMin; lag <= lagMax + 1; lag++)
            {
                double suma = 0;
                for (int i = lag; i < n; i++) suma += onset[i] * onset[i - lag];
                acf[lag] = suma / (n - lag);

                if (lag <= lagMax && acf[lag] > mejor)
                {
                    mejor = acf[lag];
                    mejorLag = lag;
                }
            }

            double lagFino = mejorLag;
            if (mejorLag > lagMin && mejorLag <= lagMax)
            {
                double y0 = acf[mejorLag - 1], y1 = acf[mejorLag], y2 = acf[mejorLag + 1];
                double den = y0 - 2 * y1 + y2;
                if (Math.Abs(den) > 1e-12) lagFino = mejorLag + 0.5 * (y0 - y2) / den;
            }

            int bpm = (int)Math.Round(60.0 * EnvFps / lagFino);
            return Math.Clamp(bpm, BpmMinimoValido, BpmMaximoValido);
        }

        private static List<double> ConstruirEnvolvente(string filePath)
        {
            var env = new List<double>();

            try
            {
                using var reader = new AudioFileReader(filePath);
                var sampleProvider = reader.ToSampleProvider();

                int sr = reader.WaveFormat.SampleRate;
                int canales = Math.Max(1, reader.WaveFormat.Channels);
                int hop = Math.Max(1, sr / EnvFps);

                if (reader.TotalTime.TotalSeconds > SegundosAnalisis + 20)
                    reader.CurrentTime = TimeSpan.FromSeconds(20);

                int maxEnv = (int)(SegundosAnalisis * EnvFps);
                var buffer = new float[hop * canales * 50];
                double acumulado = 0;
                int contados = 0;
                int leidos;

                while (env.Count < maxEnv && (leidos = sampleProvider.Read(buffer.AsSpan(0, buffer.Length))) > 0)
                {
                    for (int i = 0; i + canales <= leidos && env.Count < maxEnv; i += canales)
                    {
                        float mono = 0;
                        for (int c = 0; c < canales; c++) mono += buffer[i + c];
                        mono /= canales;

                        acumulado += mono * mono;
                        if (++contados == hop)
                        {
                            env.Add(Math.Sqrt(acumulado / hop));
                            acumulado = 0;
                            contados = 0;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return new List<double>();
            }

            return env;
        }
    }
}