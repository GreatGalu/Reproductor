using System;
using System.Collections.Generic;
using System.IO;

namespace SoundCore.Audio
{
    /// <summary>
    /// Calcula el BPM UNA sola vez por archivo y lo persiste:
    ///  - primero en la etiqueta del propio archivo (ID3 TBPM),
    ///  - si el formato no lo permite (p. ej. algunos .wav) o el archivo está bloqueado,
    ///    en un caché local (bpm_cache.txt junto al ejecutable).
    /// En las cargas siguientes el BPM ya viene en la etiqueta o en el caché y no se recalcula.
    /// </summary>
    public static class BpmService
    {
        private static readonly object _lock = new();
        private static string RutaCache => Path.Combine(AppContext.BaseDirectory, "bpm_cache.txt");

        /// <returns>BPM y dónde quedó guardado / de dónde salió.</returns>
        public static (int bpm, string origen) ResolverBpm(string filePath)
        {
            string clave = Path.GetFullPath(filePath);

            // 1) Ya calculado antes y guardado en caché -> no se recalcula.
            if (TryLeerCache(clave, out int enCache))
                return (enCache, "leído del caché");

            // 2) Calcular y guardar.
            int bpm = BpmDetector.Detectar(filePath);

            if (GuardarEnEtiqueta(filePath, bpm))
                return (bpm, "calculado y guardado en la etiqueta del archivo");

            GuardarEnCache(clave, bpm);
            return (bpm, "calculado y guardado en caché (el archivo no admite/permitió la etiqueta)");
        }

        private static bool GuardarEnEtiqueta(string filePath, int bpm)
        {
            try
            {
                using (var f = TagLib.File.Create(filePath))
                {
                    f.Tag.BeatsPerMinute = (uint)bpm;
                    f.Save();
                }
                // Verificación: se relee para confirmar que realmente quedó persistido.
                using (var f2 = TagLib.File.Create(filePath))
                {
                    return f2.Tag.BeatsPerMinute == (uint)bpm;
                }
            }
            catch
            {
                return false; // solo lectura, bloqueado por el reproductor, formato sin soporte, etc.
            }
        }

        private static bool TryLeerCache(string clave, out int bpm)
        {
            bpm = 0;
            lock (_lock)
            {
                try
                {
                    if (!File.Exists(RutaCache)) return false;
                    foreach (var linea in File.ReadLines(RutaCache))
                    {
                        int sep = linea.LastIndexOf('\t');
                        if (sep <= 0) continue;
                        if (string.Equals(linea.Substring(0, sep), clave, StringComparison.OrdinalIgnoreCase)
                            && int.TryParse(linea.Substring(sep + 1), out bpm))
                            return true;
                    }
                }
                catch { }
            }
            return false;
        }

        private static void GuardarEnCache(string clave, int bpm)
        {
            lock (_lock)
            {
                try { File.AppendAllText(RutaCache, $"{clave}\t{bpm}{Environment.NewLine}"); }
                catch { }
            }
        }
    }
}