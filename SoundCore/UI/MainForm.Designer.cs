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
            this.components = new System.ComponentModel.Container();
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelMetadata = new System.Windows.Forms.Label();
            this.rbPropia = new System.Windows.Forms.RadioButton();
            this.rbLinkedList = new System.Windows.Forms.RadioButton();
            this.rbList = new System.Windows.Forms.RadioButton();
            this.btnCargarArchivos = new System.Windows.Forms.Button();
            
            // Metadata inputs
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.lblArtista = new System.Windows.Forms.Label();
            this.txtArtista = new System.Windows.Forms.TextBox();
            this.lblBpm = new System.Windows.Forms.Label();
            this.txtBpm = new System.Windows.Forms.TextBox();
            this.lblDuracion = new System.Windows.Forms.Label();
            this.txtDuracion = new System.Windows.Forms.TextBox();
            
            this.dgvCola = new System.Windows.Forms.DataGridView();
            this.pictureBoxAlbum = new System.Windows.Forms.PictureBox();
            
            // Transport and Volume
            this.trackBarPosition = new System.Windows.Forms.TrackBar();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.lblVolumen = new System.Windows.Forms.Label();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.timerProgress = new System.Windows.Forms.Timer(this.components);

            this.btnPlay = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            
            // Actions
            this.btnEncolarFinal = new System.Windows.Forms.Button();
            this.btnUpNext = new System.Windows.Forms.Button();
            this.btnAvanzar = new System.Windows.Forms.Button();
            this.btnInvertir = new System.Windows.Forms.Button();
            this.btnOrdenarBPM = new System.Windows.Forms.Button();
            this.btnPurgar = new System.Windows.Forms.Button();
            this.btnBenchmark = new System.Windows.Forms.Button();

            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCola)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            this.SuspendLayout();

            // panelTop
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Controls.Add(this.txtTitulo);
            this.panelTop.Controls.Add(this.lblArtista);
            this.panelTop.Controls.Add(this.txtArtista);
            this.panelTop.Controls.Add(this.lblBpm);
            this.panelTop.Controls.Add(this.txtBpm);
            this.panelTop.Controls.Add(this.lblDuracion);
            this.panelTop.Controls.Add(this.txtDuracion);
            this.panelTop.Controls.Add(this.rbPropia);
            this.panelTop.Controls.Add(this.rbLinkedList);
            this.panelTop.Controls.Add(this.rbList);
            this.panelTop.Controls.Add(this.labelMetadata);
            this.panelTop.Controls.Add(this.btnCargarArchivos);
            this.panelTop.Location = new System.Drawing.Point(12, 12);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(860, 75);
            this.panelTop.TabIndex = 0;

            // Structure Selector
            this.labelMetadata.AutoSize = true;
            this.labelMetadata.Location = new System.Drawing.Point(10, 18);
            this.labelMetadata.Name = "labelMetadata";
            this.labelMetadata.Size = new System.Drawing.Size(62, 15);
            this.labelMetadata.Text = "Estructura:";

            this.rbPropia.AutoSize = true;
            this.rbPropia.Location = new System.Drawing.Point(85, 14);
            this.rbPropia.Name = "rbPropia";
            this.rbPropia.Size = new System.Drawing.Size(125, 19);
            this.rbPropia.TabIndex = 1;
            this.rbPropia.TabStop = true;
            this.rbPropia.Text = "Lista Simple Propia";
            this.rbPropia.UseVisualStyleBackColor = true;
            this.rbPropia.Checked = true;
            this.rbPropia.CheckedChanged += new System.EventHandler(this.Estructura_CheckedChanged);

            this.rbLinkedList.AutoSize = true;
            this.rbLinkedList.Location = new System.Drawing.Point(210, 14);
            this.rbLinkedList.Name = "rbLinkedList";
            this.rbLinkedList.Size = new System.Drawing.Size(125, 19);
            this.rbLinkedList.TabIndex = 2;
            this.rbLinkedList.TabStop = true;
            this.rbLinkedList.Text = ".NET LinkedList<T>";
            this.rbLinkedList.UseVisualStyleBackColor = true;
            this.rbLinkedList.CheckedChanged += new System.EventHandler(this.Estructura_CheckedChanged);

            this.rbList.AutoSize = true;
            this.rbList.Location = new System.Drawing.Point(340, 14);
            this.rbList.Name = "rbList";
            this.rbList.Size = new System.Drawing.Size(85, 19);
            this.rbList.TabIndex = 3;
            this.rbList.TabStop = true;
            this.rbList.Text = ".NET List<T>";
            this.rbList.UseVisualStyleBackColor = true;
            this.rbList.CheckedChanged += new System.EventHandler(this.Estructura_CheckedChanged);
            
            // Metadata inputs
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(10, 45);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "Título:";

            this.txtTitulo.Location = new System.Drawing.Point(50, 42);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(100, 23);

            this.lblArtista.AutoSize = true;
            this.lblArtista.Location = new System.Drawing.Point(160, 45);
            this.lblArtista.Name = "lblArtista";
            this.lblArtista.Text = "Artista:";

            this.txtArtista.Location = new System.Drawing.Point(205, 42);
            this.txtArtista.Name = "txtArtista";
            this.txtArtista.Size = new System.Drawing.Size(100, 23);

            this.lblBpm.AutoSize = true;
            this.lblBpm.Location = new System.Drawing.Point(315, 45);
            this.lblBpm.Name = "lblBpm";
            this.lblBpm.Text = "BPM:";

            this.txtBpm.Location = new System.Drawing.Point(350, 42);
            this.txtBpm.Name = "txtBpm";
            this.txtBpm.Size = new System.Drawing.Size(45, 23);

            this.lblDuracion.AutoSize = true;
            this.lblDuracion.Location = new System.Drawing.Point(405, 45);
            this.lblDuracion.Name = "lblDuracion";
            this.lblDuracion.Text = "Dur(s):";

            this.txtDuracion.Location = new System.Drawing.Point(448, 42);
            this.txtDuracion.Name = "txtDuracion";
            this.txtDuracion.Size = new System.Drawing.Size(45, 23);

            // btnCargarArchivos
            this.btnCargarArchivos.Location = new System.Drawing.Point(510, 41);
            this.btnCargarArchivos.Name = "btnCargarArchivos";
            this.btnCargarArchivos.Size = new System.Drawing.Size(155, 25);
            this.btnCargarArchivos.TabIndex = 2;
            this.btnCargarArchivos.Text = "📁 Cargar Archivos";
            this.btnCargarArchivos.UseVisualStyleBackColor = true;
            this.btnCargarArchivos.Click += new System.EventHandler(this.btnCargarArchivos_Click);

            // dgvCola
            this.dgvCola.AllowUserToAddRows = false;
            this.dgvCola.AllowUserToDeleteRows = false;
            this.dgvCola.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCola.Location = new System.Drawing.Point(12, 95);
            this.dgvCola.Name = "dgvCola";
            this.dgvCola.ReadOnly = true;
            this.dgvCola.RowHeadersVisible = false;
            this.dgvCola.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCola.Size = new System.Drawing.Size(580, 200);
            this.dgvCola.TabIndex = 1;

            // pictureBoxAlbum
            this.pictureBoxAlbum.BackColor = System.Drawing.Color.DimGray;
            this.pictureBoxAlbum.Location = new System.Drawing.Point(610, 95);
            this.pictureBoxAlbum.Name = "pictureBoxAlbum";
            this.pictureBoxAlbum.Size = new System.Drawing.Size(260, 200);
            this.pictureBoxAlbum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAlbum.TabIndex = 2;
            this.pictureBoxAlbum.TabStop = false;

            // trackBarPosition
            this.trackBarPosition.Location = new System.Drawing.Point(12, 305);
            this.trackBarPosition.Name = "trackBarPosition";
            this.trackBarPosition.Size = new System.Drawing.Size(450, 45);
            this.trackBarPosition.TabIndex = 12;
            this.trackBarPosition.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarPosition.Scroll += new System.EventHandler(this.trackBarPosition_Scroll);

            // lblTiempo
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Location = new System.Drawing.Point(468, 310);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(79, 15);
            this.lblTiempo.Text = "00:00 / 00:00";

            // lblVolumen
            this.lblVolumen.AutoSize = true;
            this.lblVolumen.Location = new System.Drawing.Point(610, 310);
            this.lblVolumen.Name = "lblVolumen";
            this.lblVolumen.Text = "Vol:";

            // trackBarVolume
            this.trackBarVolume.Location = new System.Drawing.Point(640, 305);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(230, 45);
            this.trackBarVolume.TabIndex = 13;
            this.trackBarVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarVolume.Value = 100;
            this.trackBarVolume.Scroll += new System.EventHandler(this.trackBarVolume_Scroll);

            // timerProgress
            this.timerProgress.Interval = 500;
            this.timerProgress.Tick += new System.EventHandler(this.timerProgress_Tick);

            // btnPlay
            this.btnPlay.Location = new System.Drawing.Point(610, 350);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(80, 30);
            this.btnPlay.TabIndex = 3;
            this.btnPlay.Text = "▶ Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);

            // btnPause
            this.btnPause.Location = new System.Drawing.Point(700, 350);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(80, 30);
            this.btnPause.TabIndex = 4;
            this.btnPause.Text = "⏸ Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);

            // btnStop
            this.btnStop.Location = new System.Drawing.Point(790, 350);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(80, 30);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "⏹ Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);

            // btnEncolarFinal
            this.btnEncolarFinal.Location = new System.Drawing.Point(12, 350);
            this.btnEncolarFinal.Name = "btnEncolarFinal";
            this.btnEncolarFinal.Size = new System.Drawing.Size(100, 30);
            this.btnEncolarFinal.TabIndex = 6;
            this.btnEncolarFinal.Text = "+ Encolar Final";
            this.btnEncolarFinal.UseVisualStyleBackColor = true;
            this.btnEncolarFinal.Click += new System.EventHandler(this.btnEncolarFinal_Click);

            // btnUpNext
            this.btnUpNext.Location = new System.Drawing.Point(118, 350);
            this.btnUpNext.Name = "btnUpNext";
            this.btnUpNext.Size = new System.Drawing.Size(85, 30);
            this.btnUpNext.TabIndex = 7;
            this.btnUpNext.Text = "⏭ Up Next";
            this.btnUpNext.UseVisualStyleBackColor = true;
            this.btnUpNext.Click += new System.EventHandler(this.btnUpNext_Click);

            // btnAvanzar
            this.btnAvanzar.Location = new System.Drawing.Point(209, 350);
            this.btnAvanzar.Name = "btnAvanzar";
            this.btnAvanzar.Size = new System.Drawing.Size(85, 30);
            this.btnAvanzar.TabIndex = 8;
            this.btnAvanzar.Text = "⏩ Avanzar";
            this.btnAvanzar.UseVisualStyleBackColor = true;
            this.btnAvanzar.Click += new System.EventHandler(this.btnAvanzar_Click);

            // btnInvertir
            this.btnInvertir.Location = new System.Drawing.Point(300, 350);
            this.btnInvertir.Name = "btnInvertir";
            this.btnInvertir.Size = new System.Drawing.Size(85, 30);
            this.btnInvertir.TabIndex = 9;
            this.btnInvertir.Text = "⇅ Invertir";
            this.btnInvertir.UseVisualStyleBackColor = true;
            this.btnInvertir.Click += new System.EventHandler(this.btnInvertir_Click);

            // btnOrdenarBPM
            this.btnOrdenarBPM.Location = new System.Drawing.Point(391, 350);
            this.btnOrdenarBPM.Name = "btnOrdenarBPM";
            this.btnOrdenarBPM.Size = new System.Drawing.Size(105, 30);
            this.btnOrdenarBPM.TabIndex = 10;
            this.btnOrdenarBPM.Text = "⚡ Ordenar BPM";
            this.btnOrdenarBPM.UseVisualStyleBackColor = true;
            this.btnOrdenarBPM.Click += new System.EventHandler(this.btnOrdenarBPM_Click);

            // btnPurgar
            this.btnPurgar.Location = new System.Drawing.Point(502, 350);
            this.btnPurgar.Name = "btnPurgar";
            this.btnPurgar.Size = new System.Drawing.Size(90, 30);
            this.btnPurgar.TabIndex = 11;
            this.btnPurgar.Text = "🧹 Purgar";
            this.btnPurgar.UseVisualStyleBackColor = true;
            this.btnPurgar.Click += new System.EventHandler(this.btnPurgar_Click);

            // btnBenchmark
            this.btnBenchmark.Location = new System.Drawing.Point(12, 395);
            this.btnBenchmark.Name = "btnBenchmark";
            this.btnBenchmark.Size = new System.Drawing.Size(200, 30);
            this.btnBenchmark.TabIndex = 14;
            this.btnBenchmark.Text = "⏱️ Benchmark (25k Pistas)";
            this.btnBenchmark.UseVisualStyleBackColor = true;
            this.btnBenchmark.Click += new System.EventHandler(this.btnBenchmark_Click);

            // MainForm
            this.ClientSize = new System.Drawing.Size(884, 440);
            this.Controls.Add(this.btnBenchmark);
            this.Controls.Add(this.trackBarVolume);
            this.Controls.Add(this.lblVolumen);
            this.Controls.Add(this.lblTiempo);
            this.Controls.Add(this.trackBarPosition);
            this.Controls.Add(this.btnPurgar);
            this.Controls.Add(this.btnOrdenarBPM);
            this.Controls.Add(this.btnInvertir);
            this.Controls.Add(this.btnAvanzar);
            this.Controls.Add(this.btnUpNext);
            this.Controls.Add(this.btnEncolarFinal);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.pictureBoxAlbum);
            this.Controls.Add(this.dgvCola);
            this.Controls.Add(this.panelTop);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SoundCore Engine GUI";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCola)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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
    }
}
