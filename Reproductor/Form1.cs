using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using TagLib;

namespace Reproductor
{
    public partial class Form1 : Form
    {
        private readonly AudioPlayer _player = new AudioPlayer();
        private readonly List<Track> _tracks = new List<Track>();

        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Audio files|*.mp3;*.wav;*.flac;*.m4a;*.ogg|All files|*.*"
            };

            if (ofd.ShowDialog() != DialogResult.OK) return;

            foreach (var file in ofd.FileNames)
            {
                try
                {
                    var tagFile = TagLib.File.Create(file);
                    var t = new Track
                    {
                        Title = string.IsNullOrWhiteSpace(tagFile.Tag.Title) ? Path.GetFileNameWithoutExtension(file) : tagFile.Tag.Title,
                        Artist = tagFile.Tag.FirstPerformer ?? "Unknown",
                        Album = tagFile.Tag.Album ?? "",
                        Duration = tagFile.Properties.Duration,
                        FilePath = file
                    };

                    _tracks.Add(t);
                    listBoxPlaylist.Items.Add(t);
                }
                catch (Exception)
                {
                    // If TagLib fails, add minimal info
                    var t = new Track
                    {
                        Title = Path.GetFileNameWithoutExtension(file),
                        Artist = "Unknown",
                        Album = "",
                        Duration = TimeSpan.Zero,
                        FilePath = file
                    };
                    _tracks.Add(t);
                    listBoxPlaylist.Items.Add(t);
                }
            }

            if (listBoxPlaylist.Items.Count > 0 && listBoxPlaylist.SelectedIndex < 0)
            {
                listBoxPlaylist.SelectedIndex = 0;
            }
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            var idx = listBoxPlaylist.SelectedIndex;
            if (idx < 0) return;

            _tracks.RemoveAt(idx);
            listBoxPlaylist.Items.RemoveAt(idx);

            if (listBoxPlaylist.Items.Count > 0)
            {
                listBoxPlaylist.SelectedIndex = Math.Max(0, idx - 1);
            }
            else
            {
                ClearTrackDisplay();
            }
        }

        private void ButtonPlay_Click(object sender, EventArgs e)
        {
            var idx = listBoxPlaylist.SelectedIndex;
            if (idx < 0) return;

            var track = _tracks[idx];
            try
            {
                _player.Load(track.FilePath);
                _player.Play();
                UpdateTrackDisplay(track);
                timerProgress.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al reproducir: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonPause_Click(object sender, EventArgs e)
        {
            _player.Pause();
            timerProgress.Stop();
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            _player.Stop();
            timerProgress.Stop();
            trackBarPosition.Value = 0;
            labelPosition.Text = "00:00";
        }

        private void ListBoxPlaylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idx = listBoxPlaylist.SelectedIndex;
            if (idx < 0)
            {
                ClearTrackDisplay();
                return;
            }

            var track = _tracks[idx];
            UpdateTrackDisplay(track);
        }

        private void UpdateTrackDisplay(Track track)
        {
            labelTitle.Text = track.Title ?? "Unknown";
            labelArtist.Text = track.Artist ?? "Unknown";

            try
            {
                var art = track.GetAlbumArt(track.FilePath);
                if (art != null)
                {
                    pictureBoxAlbum.Image = art;
                }
                else
                {
                    pictureBoxAlbum.Image = null;
                }
            }
            catch
            {
                pictureBoxAlbum.Image = null;
            }

            // Position display initial
            labelPosition.Text = track.Duration.ToString(@"mm\:ss");
            trackBarPosition.Value = 0;
        }

        private void ClearTrackDisplay()
        {
            labelTitle.Text = "Title";
            labelArtist.Text = "Artist";
            pictureBoxAlbum.Image = null;
            labelPosition.Text = "00:00";
            trackBarPosition.Value = 0;
        }

        private void TimerProgress_Tick(object sender, EventArgs e)
        {
            // AudioPlayer actualmente no expone posición/d duración. Aquí dejamos una actualización visual mínima.
            // Para que esto muestre la posición real habría que exponer AudioFileReader.Position/TotalTime desde AudioPlayer.
        }
    }
}
