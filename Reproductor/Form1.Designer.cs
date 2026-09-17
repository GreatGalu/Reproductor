namespace Reproductor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            listBoxPlaylist = new ListBox();
            buttonAdd = new Button();
            buttonRemove = new Button();
            buttonPlay = new Button();
            buttonPause = new Button();
            buttonStop = new Button();
            pictureBoxAlbum = new PictureBox();
            labelTitle = new Label();
            labelArtist = new Label();
            trackBarVolume = new TrackBar();
            labelVolume = new Label();
            trackBarPosition = new TrackBar();
            labelPosition = new Label();
            timerProgress = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBoxAlbum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarVolume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarPosition).BeginInit();
            SuspendLayout();
            // 
            // listBoxPlaylist
            // 
            listBoxPlaylist.BackColor = Color.FromArgb(45, 45, 48);
            listBoxPlaylist.BorderStyle = BorderStyle.FixedSingle;
            listBoxPlaylist.ForeColor = Color.WhiteSmoke;
            listBoxPlaylist.FormattingEnabled = true;
            listBoxPlaylist.ItemHeight = 17;
            listBoxPlaylist.Location = new Point(20, 20);
            listBoxPlaylist.Name = "listBoxPlaylist";
            listBoxPlaylist.Size = new Size(420, 461);
            listBoxPlaylist.TabIndex = 0;
            listBoxPlaylist.SelectedIndexChanged += ListBoxPlaylist_SelectedIndexChanged;
            // 
            // buttonAdd
            // 
            buttonAdd.BackColor = Color.FromArgb(60, 60, 64);
            buttonAdd.FlatStyle = FlatStyle.Flat;
            buttonAdd.ForeColor = Color.WhiteSmoke;
            buttonAdd.Location = new Point(20, 505);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(100, 30);
            buttonAdd.TabIndex = 1;
            buttonAdd.Text = "Añadir";
            buttonAdd.UseVisualStyleBackColor = false;
            buttonAdd.Click += ButtonAdd_Click;
            // 
            // buttonRemove
            // 
            buttonRemove.BackColor = Color.FromArgb(60, 60, 64);
            buttonRemove.FlatStyle = FlatStyle.Flat;
            buttonRemove.ForeColor = Color.WhiteSmoke;
            buttonRemove.Location = new Point(130, 505);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(100, 30);
            buttonRemove.TabIndex = 2;
            buttonRemove.Text = "Eliminar";
            buttonRemove.UseVisualStyleBackColor = false;
            buttonRemove.Click += ButtonRemove_Click;
            // 
            // buttonPlay
            // 
            buttonPlay.BackColor = Color.FromArgb(0, 122, 204);
            buttonPlay.FlatStyle = FlatStyle.Flat;
            buttonPlay.ForeColor = Color.WhiteSmoke;
            buttonPlay.Location = new Point(460, 430);
            buttonPlay.Name = "buttonPlay";
            buttonPlay.Size = new Size(80, 30);
            buttonPlay.TabIndex = 3;
            buttonPlay.Text = "Play";
            buttonPlay.UseVisualStyleBackColor = false;
            buttonPlay.Click += ButtonPlay_Click;
            // 
            // buttonPause
            // 
            buttonPause.BackColor = Color.FromArgb(60, 60, 64);
            buttonPause.FlatStyle = FlatStyle.Flat;
            buttonPause.ForeColor = Color.WhiteSmoke;
            buttonPause.Location = new Point(550, 430);
            buttonPause.Name = "buttonPause";
            buttonPause.Size = new Size(80, 30);
            buttonPause.TabIndex = 4;
            buttonPause.Text = "Pause";
            buttonPause.UseVisualStyleBackColor = false;
            buttonPause.Click += ButtonPause_Click;
            // 
            // buttonStop
            // 
            buttonStop.BackColor = Color.FromArgb(60, 60, 64);
            buttonStop.FlatStyle = FlatStyle.Flat;
            buttonStop.ForeColor = Color.WhiteSmoke;
            buttonStop.Location = new Point(640, 430);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(80, 30);
            buttonStop.TabIndex = 5;
            buttonStop.Text = "Stop";
            buttonStop.UseVisualStyleBackColor = false;
            buttonStop.Click += ButtonStop_Click;
            // 
            // pictureBoxAlbum
            // 
            pictureBoxAlbum.BackColor = Color.FromArgb(40, 40, 40);
            pictureBoxAlbum.Location = new Point(460, 20);
            pictureBoxAlbum.Name = "pictureBoxAlbum";
            pictureBoxAlbum.Size = new Size(260, 260);
            pictureBoxAlbum.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxAlbum.TabIndex = 6;
            pictureBoxAlbum.TabStop = false;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Arial", 11F, FontStyle.Bold);
            labelTitle.ForeColor = Color.WhiteSmoke;
            labelTitle.Location = new Point(740, 30);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(50, 22);
            labelTitle.TabIndex = 7;
            labelTitle.Text = "Title";
            // 
            // labelArtist
            // 
            labelArtist.AutoSize = true;
            labelArtist.Font = new Font("Arial", 10F);
            labelArtist.ForeColor = Color.WhiteSmoke;
            labelArtist.Location = new Point(740, 60);
            labelArtist.Name = "labelArtist";
            labelArtist.Size = new Size(46, 19);
            labelArtist.TabIndex = 8;
            labelArtist.Text = "Artist";
            // 
            // trackBarVolume
            // 
            trackBarVolume.BackColor = Color.FromArgb(30, 30, 30);
            trackBarVolume.Location = new Point(740, 430);
            trackBarVolume.Maximum = 100;
            trackBarVolume.Name = "trackBarVolume";
            trackBarVolume.Size = new Size(300, 56);
            trackBarVolume.TabIndex = 9;
            trackBarVolume.Value = 80;
            // 
            // labelVolume
            // 
            labelVolume.AutoSize = true;
            labelVolume.ForeColor = Color.WhiteSmoke;
            labelVolume.Location = new Point(740, 410);
            labelVolume.Name = "labelVolume";
            labelVolume.Size = new Size(64, 17);
            labelVolume.TabIndex = 10;
            labelVolume.Text = "Volumen";
            // 
            // trackBarPosition
            // 
            trackBarPosition.BackColor = Color.FromArgb(30, 30, 30);
            trackBarPosition.Location = new Point(460, 360);
            trackBarPosition.Maximum = 100;
            trackBarPosition.Name = "trackBarPosition";
            trackBarPosition.Size = new Size(580, 56);
            trackBarPosition.TabIndex = 11;
            // 
            // labelPosition
            // 
            labelPosition.AutoSize = true;
            labelPosition.ForeColor = Color.WhiteSmoke;
            labelPosition.Location = new Point(460, 340);
            labelPosition.Name = "labelPosition";
            labelPosition.Size = new Size(44, 17);
            labelPosition.TabIndex = 12;
            labelPosition.Text = "00:00";
            // 
            // timerProgress
            // 
            timerProgress.Interval = 1000;
            timerProgress.Tick += TimerProgress_Tick;
            // 
            // Form1
            // 
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(1199, 573);
            Controls.Add(listBoxPlaylist);
            Controls.Add(buttonAdd);
            Controls.Add(buttonRemove);
            Controls.Add(buttonPlay);
            Controls.Add(buttonPause);
            Controls.Add(buttonStop);
            Controls.Add(pictureBoxAlbum);
            Controls.Add(labelTitle);
            Controls.Add(labelArtist);
            Controls.Add(trackBarVolume);
            Controls.Add(labelVolume);
            Controls.Add(trackBarPosition);
            Controls.Add(labelPosition);
            Font = new Font("Arial", 9F);
            ForeColor = Color.WhiteSmoke;
            Name = "Form1";
            Text = "Reproductor";
            ((System.ComponentModel.ISupportInitialize)pictureBoxAlbum).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarVolume).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarPosition).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonAdd;
        private Button buttonRemove;
        private Button buttonPlay;
        private Button buttonPause;
        private Button buttonStop;
        private ListBox listBoxPlaylist;
        private PictureBox pictureBoxAlbum;
        private Label labelTitle;
        private Label labelArtist;
        private TrackBar trackBarVolume;
        private Label labelVolume;
        private TrackBar trackBarPosition;
        private Label labelPosition;
        private System.Windows.Forms.Timer timerProgress;
    }
}
