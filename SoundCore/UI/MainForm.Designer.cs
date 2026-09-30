namespace SoundCore.UI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panelTop = new Panel();
            lblTitulo = new Label();
            txtTitulo = new TextBox();
            lblArtista = new Label();
            txtArtista = new TextBox();
            lblBpm = new Label();
            txtBpm = new TextBox();
            lblDuracion = new Label();
            txtDuracion = new TextBox();
            rbPropia = new RadioButton();
            rbLinkedList = new RadioButton();
            rbList = new RadioButton();
            labelMetadata = new Label();
            btnCargarArchivos = new Button();
            dgvCola = new DataGridView();
            pictureBoxAlbum = new PictureBox();
            trackBarPosition = new TrackBar();
            lblTiempo = new Label();
            lblVolumen = new Label();
            trackBarVolume = new TrackBar();
            timerProgress = new System.Windows.Forms.Timer(components);
            btnPlay = new Button();
            btnPause = new Button();
            btnStop = new Button();
            btnEncolarFinal = new Button();
            btnUpNext = new Button();
            btnAvanzar = new Button();
            btnInvertir = new Button();
            btnOrdenarBPM = new Button();
            btnPurgar = new Button();
            btnBenchmark = new Button();
            btnCargar25k = new Button();
            grpBenchmark = new GroupBox();
            txtResultadosBenchmark = new TextBox();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCola).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAlbum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarPosition).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarVolume).BeginInit();
            grpBenchmark.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(lblTitulo);
            panelTop.Controls.Add(txtTitulo);
            panelTop.Controls.Add(lblArtista);
            panelTop.Controls.Add(txtArtista);
            panelTop.Controls.Add(lblBpm);
            panelTop.Controls.Add(txtBpm);
            panelTop.Controls.Add(lblDuracion);
            panelTop.Controls.Add(txtDuracion);
            panelTop.Controls.Add(rbPropia);
            panelTop.Controls.Add(rbLinkedList);
            panelTop.Controls.Add(rbList);
            panelTop.Controls.Add(labelMetadata);
            panelTop.Controls.Add(btnCargarArchivos);
            panelTop.Location = new Point(12, 12);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(860, 75);
            panelTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(10, 45);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(50, 20);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Título:";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(50, 42);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(100, 27);
            txtTitulo.TabIndex = 1;
            // 
            // lblArtista
            // 
            lblArtista.AutoSize = true;
            lblArtista.Location = new Point(160, 45);
            lblArtista.Name = "lblArtista";
            lblArtista.Size = new Size(55, 20);
            lblArtista.TabIndex = 2;
            lblArtista.Text = "Artista:";
            // 
            // txtArtista
            // 
            txtArtista.Location = new Point(205, 42);
            txtArtista.Name = "txtArtista";
            txtArtista.Size = new Size(100, 27);
            txtArtista.TabIndex = 3;
            // 
            // lblBpm
            // 
            lblBpm.AutoSize = true;
            lblBpm.Location = new Point(315, 45);
            lblBpm.Name = "lblBpm";
            lblBpm.Size = new Size(42, 20);
            lblBpm.TabIndex = 4;
            lblBpm.Text = "BPM:";
            // 
            // txtBpm
            // 
            txtBpm.Location = new Point(350, 42);
            txtBpm.Name = "txtBpm";
            txtBpm.Size = new Size(45, 27);
            txtBpm.TabIndex = 5;
            // 
            // lblDuracion
            // 
            lblDuracion.AutoSize = true;
            lblDuracion.Location = new Point(405, 45);
            lblDuracion.Name = "lblDuracion";
            lblDuracion.Size = new Size(52, 20);
            lblDuracion.TabIndex = 6;
            lblDuracion.Text = "Dur(s):";
            // 
            // txtDuracion
            // 
            txtDuracion.Location = new Point(448, 42);
            txtDuracion.Name = "txtDuracion";
            txtDuracion.Size = new Size(45, 27);
            txtDuracion.TabIndex = 7;
            // 
            // rbPropia
            // 
            rbPropia.AutoSize = true;
            rbPropia.Checked = true;
            rbPropia.Location = new Point(85, 14);
            rbPropia.Name = "rbPropia";
            rbPropia.Size = new Size(157, 24);
            rbPropia.TabIndex = 1;
            rbPropia.TabStop = true;
            rbPropia.Text = "Lista Simple Propia";
            rbPropia.UseVisualStyleBackColor = true;
            rbPropia.CheckedChanged += Estructura_CheckedChanged;
            // 
            // rbLinkedList
            // 
            rbLinkedList.AutoSize = true;
            rbLinkedList.Location = new Point(248, 16);
            rbLinkedList.Name = "rbLinkedList";
            rbLinkedList.Size = new Size(157, 24);
            rbLinkedList.TabIndex = 2;
            rbLinkedList.TabStop = true;
            rbLinkedList.Text = ".NET LinkedList<T>";
            rbLinkedList.UseVisualStyleBackColor = true;
            rbLinkedList.CheckedChanged += Estructura_CheckedChanged;
            // 
            // rbList
            // 
            rbList.AutoSize = true;
            rbList.Location = new Point(411, 18);
            rbList.Name = "rbList";
            rbList.Size = new Size(114, 24);
            rbList.TabIndex = 3;
            rbList.TabStop = true;
            rbList.Text = ".NET List<T>";
            rbList.UseVisualStyleBackColor = true;
            rbList.CheckedChanged += Estructura_CheckedChanged;
            // 
            // labelMetadata
            // 
            labelMetadata.AutoSize = true;
            labelMetadata.Location = new Point(10, 18);
            labelMetadata.Name = "labelMetadata";
            labelMetadata.Size = new Size(77, 20);
            labelMetadata.TabIndex = 8;
            labelMetadata.Text = "Estructura:";
            // 
            // btnCargarArchivos
            // 
            btnCargarArchivos.Location = new Point(510, 41);
            btnCargarArchivos.Name = "btnCargarArchivos";
            btnCargarArchivos.Size = new Size(155, 25);
            btnCargarArchivos.TabIndex = 2;
            btnCargarArchivos.Text = "📁 Cargar Archivos";
            btnCargarArchivos.UseVisualStyleBackColor = true;
            btnCargarArchivos.Click += btnCargarArchivos_Click;
            // 
            // dgvCola
            // 
            dgvCola.AllowUserToAddRows = false;
            dgvCola.AllowUserToDeleteRows = false;
            dgvCola.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCola.Location = new Point(12, 95);
            dgvCola.Name = "dgvCola";
            dgvCola.ReadOnly = true;
            dgvCola.RowHeadersVisible = false;
            dgvCola.RowHeadersWidth = 51;
            dgvCola.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCola.Size = new Size(580, 200);
            dgvCola.TabIndex = 1;
            // 
            // pictureBoxAlbum
            // 
            pictureBoxAlbum.BackColor = Color.DimGray;
            pictureBoxAlbum.Location = new Point(610, 95);
            pictureBoxAlbum.Name = "pictureBoxAlbum";
            pictureBoxAlbum.Size = new Size(260, 200);
            pictureBoxAlbum.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxAlbum.TabIndex = 2;
            pictureBoxAlbum.TabStop = false;
            // 
            // trackBarPosition
            // 
            trackBarPosition.Location = new Point(12, 305);
            trackBarPosition.Name = "trackBarPosition";
            trackBarPosition.Size = new Size(450, 56);
            trackBarPosition.TabIndex = 12;
            trackBarPosition.TickStyle = TickStyle.None;
            trackBarPosition.Scroll += trackBarPosition_Scroll;
            // 
            // lblTiempo
            // 
            lblTiempo.AutoSize = true;
            lblTiempo.Location = new Point(468, 310);
            lblTiempo.Name = "lblTiempo";
            lblTiempo.Size = new Size(93, 20);
            lblTiempo.TabIndex = 18;
            lblTiempo.Text = "00:00 / 00:00";
            // 
            // lblVolumen
            // 
            lblVolumen.AutoSize = true;
            lblVolumen.Location = new Point(610, 310);
            lblVolumen.Name = "lblVolumen";
            lblVolumen.Size = new Size(33, 20);
            lblVolumen.TabIndex = 17;
            lblVolumen.Text = "Vol:";
            // 
            // trackBarVolume
            // 
            trackBarVolume.Location = new Point(640, 305);
            trackBarVolume.Maximum = 100;
            trackBarVolume.Name = "trackBarVolume";
            trackBarVolume.Size = new Size(230, 56);
            trackBarVolume.TabIndex = 13;
            trackBarVolume.TickStyle = TickStyle.None;
            trackBarVolume.Value = 100;
            trackBarVolume.Scroll += trackBarVolume_Scroll;
            // 
            // timerProgress
            // 
            timerProgress.Interval = 500;
            timerProgress.Tick += timerProgress_Tick;
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(610, 359);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(80, 30);
            btnPlay.TabIndex = 3;
            btnPlay.Text = "▶ Play";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // btnPause
            // 
            btnPause.Location = new Point(696, 359);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(80, 30);
            btnPause.TabIndex = 4;
            btnPause.Text = "⏸ Pause";
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Click += btnPause_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(789, 359);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(80, 30);
            btnStop.TabIndex = 5;
            btnStop.Text = "⏹ Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnEncolarFinal
            // 
            btnEncolarFinal.Location = new Point(12, 359);
            btnEncolarFinal.Name = "btnEncolarFinal";
            btnEncolarFinal.Size = new Size(100, 30);
            btnEncolarFinal.TabIndex = 6;
            btnEncolarFinal.Text = "+ Encolar Final";
            btnEncolarFinal.UseVisualStyleBackColor = true;
            btnEncolarFinal.Click += btnEncolarFinal_Click;
            // 
            // btnUpNext
            // 
            btnUpNext.Location = new Point(118, 359);
            btnUpNext.Name = "btnUpNext";
            btnUpNext.Size = new Size(85, 30);
            btnUpNext.TabIndex = 7;
            btnUpNext.Text = "⏭ Up Next";
            btnUpNext.UseVisualStyleBackColor = true;
            btnUpNext.Click += btnUpNext_Click;
            // 
            // btnAvanzar
            // 
            btnAvanzar.Location = new Point(209, 359);
            btnAvanzar.Name = "btnAvanzar";
            btnAvanzar.Size = new Size(85, 30);
            btnAvanzar.TabIndex = 8;
            btnAvanzar.Text = "⏩ Avanzar";
            btnAvanzar.UseVisualStyleBackColor = true;
            btnAvanzar.Click += btnAvanzar_Click;
            // 
            // btnInvertir
            // 
            btnInvertir.Location = new Point(300, 359);
            btnInvertir.Name = "btnInvertir";
            btnInvertir.Size = new Size(85, 30);
            btnInvertir.TabIndex = 9;
            btnInvertir.Text = "⇅ Invertir";
            btnInvertir.UseVisualStyleBackColor = true;
            btnInvertir.Click += btnInvertir_Click;
            // 
            // btnOrdenarBPM
            // 
            btnOrdenarBPM.Location = new Point(391, 359);
            btnOrdenarBPM.Name = "btnOrdenarBPM";
            btnOrdenarBPM.Size = new Size(105, 30);
            btnOrdenarBPM.TabIndex = 10;
            btnOrdenarBPM.Text = "⚡ Ordenar BPM";
            btnOrdenarBPM.UseVisualStyleBackColor = true;
            btnOrdenarBPM.Click += btnOrdenarBPM_Click;
            // 
            // btnPurgar
            // 
            btnPurgar.Location = new Point(502, 359);
            btnPurgar.Name = "btnPurgar";
            btnPurgar.Size = new Size(90, 30);
            btnPurgar.TabIndex = 11;
            btnPurgar.Text = "\U0001f9f9 Purgar";
            btnPurgar.UseVisualStyleBackColor = true;
            btnPurgar.Click += btnPurgar_Click;
            // 
            // btnBenchmark
            // 
            btnBenchmark.Location = new Point(12, 395);
            btnBenchmark.Name = "btnBenchmark";
            btnBenchmark.Size = new Size(200, 30);
            btnBenchmark.TabIndex = 14;
            btnBenchmark.Text = "⏱️ Benchmark (25k Pistas)";
            btnBenchmark.UseVisualStyleBackColor = true;
            btnBenchmark.Click += btnBenchmark_Click;
            // 
            // btnCargar25k
            // 
            btnCargar25k.Location = new Point(12, 435);
            btnCargar25k.Name = "btnCargar25k";
            btnCargar25k.Size = new Size(200, 30);
            btnCargar25k.TabIndex = 16;
            btnCargar25k.Text = "🎵 Cargar 25k Pistas";
            btnCargar25k.UseVisualStyleBackColor = true;
            btnCargar25k.Click += btnCargar25k_Click;
            // 
            // grpBenchmark
            // 
            grpBenchmark.Controls.Add(txtResultadosBenchmark);
            grpBenchmark.Location = new Point(225, 388);
            grpBenchmark.Name = "grpBenchmark";
            grpBenchmark.Size = new Size(647, 150);
            grpBenchmark.TabIndex = 15;
            grpBenchmark.TabStop = false;
            grpBenchmark.Text = "Panel de Benchmark y Telemetría";
            // 
            // txtResultadosBenchmark
            // 
            txtResultadosBenchmark.BackColor = Color.FromArgb(30, 30, 30);
            txtResultadosBenchmark.Dock = DockStyle.Fill;
            txtResultadosBenchmark.Font = new Font("Consolas", 9F);
            txtResultadosBenchmark.ForeColor = Color.Gainsboro;
            txtResultadosBenchmark.Location = new Point(3, 23);
            txtResultadosBenchmark.Multiline = true;
            txtResultadosBenchmark.Name = "txtResultadosBenchmark";
            txtResultadosBenchmark.ReadOnly = true;
            txtResultadosBenchmark.ScrollBars = ScrollBars.Vertical;
            txtResultadosBenchmark.Size = new Size(641, 124);
            txtResultadosBenchmark.TabIndex = 0;
            txtResultadosBenchmark.Text = "Presiona \"Benchmark\" para ejecutar la prueba de estrés.";
            txtResultadosBenchmark.TextChanged += txtResultadosBenchmark_TextChanged;
            // 
            // MainForm
            // 
            ClientSize = new Size(884, 568);
            Controls.Add(grpBenchmark);
            Controls.Add(btnBenchmark);
            Controls.Add(btnCargar25k);
            Controls.Add(trackBarVolume);
            Controls.Add(lblVolumen);
            Controls.Add(lblTiempo);
            Controls.Add(trackBarPosition);
            Controls.Add(btnPurgar);
            Controls.Add(btnOrdenarBPM);
            Controls.Add(btnInvertir);
            Controls.Add(btnAvanzar);
            Controls.Add(btnUpNext);
            Controls.Add(btnEncolarFinal);
            Controls.Add(btnStop);
            Controls.Add(btnPause);
            Controls.Add(btnPlay);
            Controls.Add(pictureBoxAlbum);
            Controls.Add(dgvCola);
            Controls.Add(panelTop);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SoundCore Engine GUI";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCola).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAlbum).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarPosition).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarVolume).EndInit();
            grpBenchmark.ResumeLayout(false);
            grpBenchmark.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelMetadata;
        private System.Windows.Forms.RadioButton rbPropia;
        private System.Windows.Forms.RadioButton rbLinkedList;
        private System.Windows.Forms.RadioButton rbList;

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label lblArtista;
        private System.Windows.Forms.TextBox txtArtista;
        private System.Windows.Forms.Label lblBpm;
        private System.Windows.Forms.TextBox txtBpm;
        private System.Windows.Forms.Label lblDuracion;
        private System.Windows.Forms.TextBox txtDuracion;

        private System.Windows.Forms.Button btnCargarArchivos;
        private System.Windows.Forms.DataGridView dgvCola;
        private System.Windows.Forms.PictureBox pictureBoxAlbum;

        private System.Windows.Forms.TrackBar trackBarPosition;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.Label lblVolumen;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.Timer timerProgress;

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnEncolarFinal;
        private System.Windows.Forms.Button btnUpNext;
        private System.Windows.Forms.Button btnAvanzar;
        private System.Windows.Forms.Button btnInvertir;
        private System.Windows.Forms.Button btnOrdenarBPM;
        private System.Windows.Forms.Button btnPurgar;
        private System.Windows.Forms.Button btnBenchmark;
        private System.Windows.Forms.Button btnCargar25k;
        private System.Windows.Forms.GroupBox grpBenchmark;
        private System.Windows.Forms.TextBox txtResultadosBenchmark;
    }
}