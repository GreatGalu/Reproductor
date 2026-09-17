using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Reproductor
{
    internal class AudioPlayer
    {
        private IWavePlayer _outputDevice;
        private AudioFileReader _audioFile;

        public void Load(string filePath)
        {
            Stop();
            _outputDevice = new WaveOutEvent();
            _audioFile = new AudioFileReader(filePath);
            _outputDevice.Init(_audioFile);
        }
        public void Stop() => _outputDevice?.Stop();
        public void Pause() => _outputDevice?.Pause();
        public void Play()
        {
            _audioFile?.Dispose();
            _outputDevice.Pause();
            _outputDevice?.Play();
        }
    }
}