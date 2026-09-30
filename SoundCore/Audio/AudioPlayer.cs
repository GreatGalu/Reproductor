using System;
using NAudio.Wave;

namespace SoundCore.Audio
{
    public class AudioPlayer
    {
        private IWavePlayer? _outputDevice;
        private AudioFileReader? _audioFile;

        public TimeSpan CurrentTime
        {
            get => _audioFile?.CurrentTime ?? TimeSpan.Zero;
            set
            {
                if (_audioFile != null)
                {
                    _audioFile.CurrentTime = value;
                }
            }
        }

        public TimeSpan TotalTime => _audioFile?.TotalTime ?? TimeSpan.Zero;

        public float Volume
        {
            get => _audioFile?.Volume ?? (_outputDevice?.Volume ?? 1.0f);
            set
            {
                if (_audioFile != null)
                {
                    _audioFile.Volume = value;
                }
                if (_outputDevice != null)
                {
                    _outputDevice.Volume = value;
                }
            }
        }
        public string CurrentFilePath { get; private set; } = string.Empty;

        public void Load(string filePath)
        {
            if (CurrentFilePath == filePath && _outputDevice != null) return;

            Stop();
            CurrentFilePath = filePath;
            _outputDevice = new WaveOut();
            _audioFile = new AudioFileReader(filePath);
            _outputDevice.Init(_audioFile);
        }

        public void Seek(double totalSeconds)
        {
            if (_audioFile != null)
            {
                if (totalSeconds < 0) totalSeconds = 0;
                if (totalSeconds > _audioFile.TotalTime.TotalSeconds) totalSeconds = _audioFile.TotalTime.TotalSeconds;
                _audioFile.CurrentTime = TimeSpan.FromSeconds(totalSeconds);
            }
        }

        public void Play()
        {
            _outputDevice?.Play();
        }

        public void Pause()
        {
            _outputDevice?.Pause();
        }

        public void Stop()
        {
            if (_outputDevice != null)
            {
                _outputDevice.Stop();
            }
            if (_audioFile != null)
            {
                _audioFile.CurrentTime = TimeSpan.Zero;
            }
        }
    }
}
