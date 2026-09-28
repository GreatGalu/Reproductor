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
        private TextBox txtBuscar;

        // Estructuras paralelas
        private readonly ListaSimpleEnlazada<Pista> _colaPropia = new();
        private readonly LinkedList<Pista> _colaLinkedList = new();
        private readonly List<Pista> _colaList = new();

        public MainForm()
        {
            InitializeComponent();
            ConfigurarDgvCola();
            AplicarTemaOscuro();
            RefrescarVista();
        }

        private void AplicarTemaOscuro()
        {
            Color fondoOscuro = Color.FromArgb(25, 25, 30);
            Color moradoOscuro = Color.FromArgb(52, 21, 57); // #341539
            Color textoClaro = Color.White;
            Color cianAcento = Color.FromArgb(0, 229, 255);
            
            this.BackColor = fondoOscuro;
            this.ForeColor = textoClaro;
            
            panelTop.BackColor = moradoOscuro;
            
            // Configurar DGV
            dgvCola.BackgroundColor = fondoOscuro;
            dgvCola.DefaultCellStyle.BackColor = Color.FromArgb(35, 35, 40);
            dgvCola.DefaultCellStyle.ForeColor = textoClaro;
            dgvCola.DefaultCellStyle.SelectionBackColor = cianAcento;
            dgvCola.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvCola.ColumnHeadersDefaultCellStyle.BackColor = moradoOscuro;
            dgvCola.ColumnHeadersDefaultCellStyle.ForeColor = textoClaro;
            dgvCola.ColumnHeadersDefaultCellStyle.SelectionBackColor = moradoOscuro;
            dgvCola.EnableHeadersVisualStyles = false;
            dgvCola.RowHeadersVisible = false;
            dgvCola.GridColor = Color.FromArgb(50, 50, 50);
            
            // Estilizar Botones
            foreach (Control c in this.Controls) {
                if (c is Button btn) {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = cianAcento;
                    btn.BackColor = moradoOscuro;
                    btn.ForeColor = textoClaro;
                }
            }
            foreach (Control c in panelTop.Controls) {
                if (c is Button btn) {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = cianAcento;
                    btn.BackColor = Color.FromArgb(40, 10, 45);
                    btn.ForeColor = textoClaro;
                }
            }

            // Crear barra de búsqueda dinámica
            Label lblBuscar = new Label() { Text = "🔍 Buscar:", AutoSize = true, Location = new Point(10, 80), ForeColor = cianAcento, Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            txtBuscar = new TextBox();
            txtBuscar.Location = new Point(90, 78);
            txtBuscar.Size = new Size(300, 25);
            txtBuscar.BackColor = Color.FromArgb(40, 40, 45);
            txtBuscar.ForeColor = textoClaro;
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.TextChanged += (s, e) => RefrescarVista();
            
            this.Controls.Add(lblBuscar);
            this.Controls.Add(txtBuscar);
            
            // Mover DGV abajo
            dgvCola.Location = new Point(12, 115);
            dgvCola.Size = new Size(580, 180);
            pictureBoxAlbum.Location = new Point(610, 115);
            pictureBoxAlbum.Size = new Size(260, 180);
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
            AgregarArchivos(false, false);
        }

        private void AgregarArchivos(bool upNext, bool limpiarPrimero)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos de Audio|*.mp3;*.wav";
                ofd.Multiselect = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (limpiarPrimero) 
                    {
                        if (rbPropia.Checked) _colaPropia.Limpiar();
                        else if (rbLinkedList.Checked) _colaLinkedList.Clear();
                        else _colaList.Clear();
                    }

                    // Si es upNext, invertimos el orden para que se inserten correctamente uno tras otro en la cima
                    var archivos = upNext ? ofd.FileNames.Reverse().ToArray() : ofd.FileNames;

                    foreach (string file in archivos)
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
                        
                        if (upNext)
                        {
                            if (rbPropia.Checked) _colaPropia.ReproducirSiguiente(pista);
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
                        }
                        else
                        {
                            InsertarAlFinal(pista);
                        }
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
                    catch(Exception ex)
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
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                AgregarArchivos(false, false);
            }
            else
            {
                var pista = LeerPistaDesdeInputs();
                InsertarAlFinal(pista);
                RefrescarVista();
            }
        }

        private void btnUpNext_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                AgregarArchivos(true, false);
            }
            else
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

            string filtro = txtBuscar != null ? txtBuscar.Text.Trim().ToLower() : "";
            if (!string.IsNullOrEmpty(filtro))
            {
                coleccion = coleccion.Where(p => 
                    p.Titulo.ToLower().Contains(filtro) || 
                    p.Artista.ToLower().Contains(filtro));
            }

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

            // 1. Test Inserción Intermedia: Lista Propia
            var testPropia = new ListaSimpleEnlazada<Pista>();
            testPropia.AgregarAlFinal(new Pista(0, "Head", "DJ", 120, 200, ""));
            sw.Start();
            for (int i = 0; i < n; i++)
            {
                testPropia.ReproducirSiguiente(new Pista(i, $"Pista {i}", "DJ", _rand.Next(100, 150), 180, ""));
            }
            sw.Stop();
            long tiempoPropia = sw.ElapsedMilliseconds;

            // 2. Test Inserción Intermedia: LinkedList<T>
            var testLinkedList = new LinkedList<Pista>();
            testLinkedList.AddLast(new Pista(0, "Head", "DJ", 120, 200, ""));
            sw.Restart();
            for (int i = 0; i < n; i++)
            {
                testLinkedList.AddAfter(testLinkedList.First!, new Pista(i, $"Pista {i}", "DJ", _rand.Next(100, 150), 180, ""));
            }
            sw.Stop();
            long tiempoLinkedList = sw.ElapsedMilliseconds;

            // 3. Test Inserción Intermedia: List<T> (Array Copy)
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
