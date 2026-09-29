using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SoundCore.Modelos;
using SoundCore.Audio;
using SoundCore.EstructurasPropias;

namespace SoundCore.UI
{
    public partial class MainForm : Form
    {
        private AudioPlayer _audioPlayer = new AudioPlayer();
        private int _contadorId = 1;
        private Random _rand = new Random();
        private readonly ListaSimpleEnlazada<Pista> _colaPropia = new();
        private readonly LinkedList<Pista> _colaLinkedList = new();
        private readonly List<Pista> _colaList = new();

        public MainForm()
        {
            InitializeComponent();
            ConfigurarDgvCola();

            // Filtro en tiempo real con los campos existentes
            txtTitulo.TextChanged  += (s, e) => RefrescarVista();
            txtArtista.TextChanged += (s, e) => RefrescarVista();

            RefrescarVista();
        }

        private void ConfigurarDgvCola()
        {
            dgvCola.AutoGenerateColumns = false;
            dgvCola.Columns.Clear();
            dgvCola.Columns.Add(new DataGridViewTextBoxColumn { Name = "Pos", HeaderText = "Pos", Width = 40 });
            dgvCola.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", Width = 40 });
            dgvCola.Columns.Add(new DataGridViewTextBoxColumn { Name = "TituloArtista", HeaderText = "Título / Artista", Width = 200 });
            dgvCola.Columns.Add(new DataGridViewTextBoxColumn { Name = "Bpm", HeaderText = "BPM", Width = 60 });
            dgvCola.Columns.Add(new DataGridViewTextBoxColumn { Name = "Duracion", HeaderText = "Duración (s)", Width = 80 });
            dgvCola.SelectionChanged += DgvCola_SelectionChanged;
        }

        private void DgvCola_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvCola.CurrentRow != null && dgvCola.CurrentRow.Index >= 0)
            {
                int id = Convert.ToInt32(dgvCola.CurrentRow.Cells[1].Value);
                var coleccion = ObtenerColeccionActiva();
                var pista = coleccion.FirstOrDefault(p => p.Id == id);
                if (pista != null)
                {
                    var image = pista.GetAlbumArt();
                    pictureBoxAlbum.Image = image;
                }
            }
        }

        private List<Pista> ObtenerColeccionActiva()
        {
            if (rbPropia.Checked) return _colaPropia.ToList();
            if (rbLinkedList.Checked) return _colaLinkedList.ToList();
            return _colaList;
        }

        private void Estructura_CheckedChanged(object? sender, EventArgs e)
        {
            RadioButton? rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                RefrescarVista();
            }
        }

        private void btnCargarArchivos_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos de Audio|*.mp3;*.wav";
                ofd.Multiselect = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in ofd.FileNames)
                    {
                        string title = System.IO.Path.GetFileNameWithoutExtension(file);
                        string artist = "Desconocido";
                        int bpm = 0;
                        int duration = 0;

                        try
                        {
                            using (var tagFile = TagLib.File.Create(file))
                            {
                                if (!string.IsNullOrEmpty(tagFile.Tag.Title)) title = tagFile.Tag.Title;
                                if (tagFile.Tag.Performers != null && tagFile.Tag.Performers.Length > 0) artist = string.Join(", ", tagFile.Tag.Performers);
                                bpm = (int)tagFile.Tag.BeatsPerMinute;
                                if (tagFile.Properties != null) duration = (int)tagFile.Properties.Duration.TotalSeconds;
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Error leyendo metadatos: {ex.Message}");
                        }

                        if (bpm == 0) bpm = _rand.Next(100, 141);

                        var pista = new Pista(_contadorId++, title, artist, bpm, duration, file);
                        InsertarAlFinal(pista);
                    }
                    RefrescarVista();
                }
            }
        }

        private void InsertarAlFinal(Pista pista)
        {
            if (rbPropia.Checked) _colaPropia.AgregarAlFinal(pista);
            else if (rbLinkedList.Checked) _colaLinkedList.AddLast(pista);
            else _colaList.Add(pista);
        }

        private void btnPlay_Click(object? sender, EventArgs e)
        {
            if (dgvCola.CurrentRow != null && dgvCola.CurrentRow.Index >= 0)
            {
                int id = Convert.ToInt32(dgvCola.CurrentRow.Cells[1].Value);
                var coleccion = ObtenerColeccionActiva();
                var pista = coleccion.FirstOrDefault(p => p.Id == id);

                if (pista != null)
                {
                    if (string.IsNullOrWhiteSpace(pista.FilePath) || !System.IO.File.Exists(pista.FilePath))
                    {
                        MessageBox.Show($"El archivo para '{pista.Titulo}' no existe o es una pista manual sin audio.\nNo se puede reproducir.", "Error de Audio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        _audioPlayer.Load(pista.FilePath);
                        _audioPlayer.Play();
                        timerProgress.Start();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"No se pudo reproducir el archivo:\n{ex.Message}", "Error de Reproducción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnPause_Click(object? sender, EventArgs e)
        {
            _audioPlayer.Pause();
        }

        private void btnStop_Click(object? sender, EventArgs e)
        {
            _audioPlayer.Stop();
            timerProgress.Stop();
            trackBarPosition.Value = 0;
            lblTiempo.Text = "00:00 / 00:00";
        }

        private void timerProgress_Tick(object? sender, EventArgs e)
        {
            var totalSeconds = (int)_audioPlayer.TotalTime.TotalSeconds;
            var currentSeconds = (int)_audioPlayer.CurrentTime.TotalSeconds;

            if (totalSeconds > 0)
            {
                trackBarPosition.Maximum = totalSeconds;
                trackBarPosition.Value = Math.Min(currentSeconds, totalSeconds);
            }
            lblTiempo.Text = $"{_audioPlayer.CurrentTime:mm\\:ss} / {_audioPlayer.TotalTime:mm\\:ss}";
        }

        private void trackBarPosition_Scroll(object? sender, EventArgs e)
        {
            _audioPlayer.Seek(trackBarPosition.Value);
        }

        private void trackBarVolume_Scroll(object? sender, EventArgs e)
        {
            _audioPlayer.Volume = trackBarVolume.Value / 100.0f;
        }

        private Pista LeerPistaDesdeInputs()
        {
            string titulo = string.IsNullOrWhiteSpace(txtTitulo.Text) ? $"Pista {_contadorId}" : txtTitulo.Text.Trim();
            string artista = string.IsNullOrWhiteSpace(txtArtista.Text) ? "Artista Desconocido" : txtArtista.Text.Trim();
            if (!int.TryParse(txtBpm.Text, out int bpm) || bpm <= 0) bpm = _rand.Next(100, 141);
            if (!int.TryParse(txtDuracion.Text, out int duracion) || duracion <= 0) duracion = 180;

            return new Pista(_contadorId++, titulo, artista, bpm, duracion, "");
        }

        private void btnEncolarFinal_Click(object? sender, EventArgs e)
        {
            var pista = LeerPistaDesdeInputs();
            InsertarAlFinal(pista);
            RefrescarVista();
        }

        private void btnUpNext_Click(object? sender, EventArgs e)
        {
            var pista = LeerPistaDesdeInputs();

            if (rbPropia.Checked)
            {
                _colaPropia.ReproducirSiguiente(pista);
            }
            else if (rbLinkedList.Checked)
            {
                if (_colaLinkedList.First == null) _colaLinkedList.AddFirst(pista);
                else _colaLinkedList.AddAfter(_colaLinkedList.First, pista);
            }
            else
            {
                if (_colaList.Count <= 1) _colaList.Add(pista);
                else _colaList.Insert(1, pista);
            }

            RefrescarVista();
        }

        private void btnAvanzar_Click(object? sender, EventArgs e)
        {
            try
            {
                Pista? pistaSonando = null;
                if (rbPropia.Checked)
                {
                    pistaSonando = _colaPropia.AvanzarPista();
                }
                else if (rbLinkedList.Checked)
                {
                    if (_colaLinkedList.First == null) throw new InvalidOperationException();
                    pistaSonando = _colaLinkedList.First.Value;
                    _colaLinkedList.RemoveFirst();
                }
                else
                {
                    if (_colaList.Count == 0) throw new InvalidOperationException();
                    pistaSonando = _colaList[0];
                    _colaList.RemoveAt(0);
                }

                RefrescarVista();

                if (dgvCola.Rows.Count > 0)
                {
                    dgvCola.Rows[0].Selected = true;
                    btnPlay_Click(sender, e);
                }
                else
                {
                    btnStop_Click(sender, e);
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("No hay pistas pendientes en la cola.", "Fin del Setlist", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnInvertir_Click(object? sender, EventArgs e)
        {
            if (rbPropia.Checked)
            {
                _colaPropia.Invertir();
            }
            else if (rbLinkedList.Checked)
            {
                var listaTemporal = new List<Pista>(_colaLinkedList);
                listaTemporal.Reverse();
                _colaLinkedList.Clear();
                foreach (var item in listaTemporal) _colaLinkedList.AddLast(item);
            }
            else
            {
                _colaList.Reverse();
            }

            RefrescarVista();
        }

        private void btnOrdenarBPM_Click(object? sender, EventArgs e)
        {
            if (rbPropia.Checked)
            {
                var temporal = new ListaSimpleEnlazada<Pista>();
                foreach (var pista in _colaPropia)
                {
                    temporal.InsertarOrdenado(pista, (a, b) => a.Bpm.CompareTo(b.Bpm));
                }
                _colaPropia.Limpiar();
                foreach (var p in temporal) _colaPropia.AgregarAlFinal(p);
            }
            else if (rbLinkedList.Checked)
            {
                var ordenadas = _colaLinkedList.OrderBy(p => p.Bpm).ToList();
                _colaLinkedList.Clear();
                foreach (var p in ordenadas) _colaLinkedList.AddLast(p);
            }
            else
            {
                _colaList.Sort((a, b) => a.Bpm.CompareTo(b.Bpm));
            }

            RefrescarVista();
        }

        private void btnPurgar_Click(object? sender, EventArgs e)
        {
            if (rbPropia.Checked)
            {
                _colaPropia.DepurarDuplicados((a, b) => a.Titulo.Equals(b.Titulo, StringComparison.OrdinalIgnoreCase));
            }
            else if (rbLinkedList.Checked)
            {
                var unicos = _colaLinkedList.GroupBy(p => p.Titulo.Trim().ToLower()).Select(g => g.First()).ToList();
                _colaLinkedList.Clear();
                foreach (var p in unicos) _colaLinkedList.AddLast(p);
            }
            else
            {
                var unicos = _colaList.GroupBy(p => p.Titulo.Trim().ToLower()).Select(g => g.First()).ToList();
                _colaList.Clear();
                _colaList.AddRange(unicos);
            }

            RefrescarVista();
        }

        private void RefrescarVista()
        {
            dgvCola.Rows.Clear();
            IEnumerable<Pista> coleccion = rbPropia.Checked ? _colaPropia :
                                           rbLinkedList.Checked ? _colaLinkedList : _colaList;

            // Filtrar por Título
            string filtroTitulo = txtTitulo.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(filtroTitulo))
                coleccion = coleccion.Where(p => p.Titulo.ToLower().Contains(filtroTitulo));

            // Filtrar por Artista
            string filtroArtista = txtArtista.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(filtroArtista))
                coleccion = coleccion.Where(p => p.Artista.ToLower().Contains(filtroArtista));

            int index = 1;
            foreach (var p in coleccion)
            {
                dgvCola.Rows.Add(index++, p.Id, $"{p.Titulo} - {p.Artista}", p.Bpm, p.DuracionSegundos);
            }
        }

        private void btnBenchmark_Click(object? sender, EventArgs e)
        {
            int n = 20000;
            var sw = new Stopwatch();
            var testPropia = new ListaSimpleEnlazada<Pista>();
            testPropia.AgregarAlFinal(new Pista(0, "Head", "DJ", 120, 200, ""));
            sw.Start();
            for (int i = 0; i < n; i++)
            {
                testPropia.ReproducirSiguiente(new Pista(i, $"Pista {i}", "DJ", _rand.Next(100, 150), 180, ""));
            }
            sw.Stop();
            long tiempoPropia = sw.ElapsedMilliseconds;

            var testLinkedList = new LinkedList<Pista>();
            testLinkedList.AddLast(new Pista(0, "Head", "DJ", 120, 200, ""));
            sw.Restart();
            for (int i = 0; i < n; i++)
            {
                testLinkedList.AddAfter(testLinkedList.First!, new Pista(i, $"Pista {i}", "DJ", _rand.Next(100, 150), 180, ""));
            }
            sw.Stop();
            long tiempoLinkedList = sw.ElapsedMilliseconds;

            var testList = new List<Pista> { new Pista(0, "Head", "DJ", 120, 200, "") };
            sw.Restart();
            for (int i = 0; i < n; i++)
            {
                testList.Insert(1, new Pista(i, $"Pista {i}", "DJ", _rand.Next(100, 150), 180, ""));
            }
            sw.Stop();
            long tiempoList = sw.ElapsedMilliseconds;

            MessageBox.Show(
                $"=== RESULTADOS DE ESTRÉS ({n:N0} INSERCIONES INTERMEDIAS) ===\n\n" +
                $"• Lista Enlazada Propia (Nodos):   {tiempoPropia} ms  [Operación O(1) por reconexión]\n" +
                $"• .NET LinkedList<T>:             {tiempoLinkedList} ms  [Operación O(1)]\n" +
                $"• .NET List<T> (Array Dinámico):   {tiempoList} ms  [Operación O(n) por desplazamiento de memoria]\n\n" +
                $"Conclusión Técnica: En inserciones intermedias frecuentes, las Listas Enlazadas superan a List<T> " +
                $"porque no ejecutan Array.Copy ni redimensionamiento de búfer.",
                "Prueba de Estrés (Benchmark)", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
