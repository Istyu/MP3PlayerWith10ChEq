namespace MusicPlayer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.openAudio = new System.Windows.Forms.Button();
            this.Play = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.volumeBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.band1Bar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.band2Bar = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.band3Bar = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.band4Bar = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.band5Bar = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.band6Bar = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
            this.band7Bar = new System.Windows.Forms.TrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.band8Bar = new System.Windows.Forms.TrackBar();
            this.label12 = new System.Windows.Forms.Label();
            this.band9Bar = new System.Windows.Forms.TrackBar();
            this.label13 = new System.Windows.Forms.Label();
            this.band10Bar = new System.Windows.Forms.TrackBar();
            this.label14 = new System.Windows.Forms.Label();
            this.Stop = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.positionBar = new System.Windows.Forms.TrackBar();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.coverBox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.visibleEqList = new System.Windows.Forms.Button();
            this.musicList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.band1Bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.band2Bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.band3Bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.band4Bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.band5Bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.band6Bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.band7Bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.band8Bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.band9Bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.band10Bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coverBox)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(15, 15);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(415, 23);
            this.comboBox1.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 509);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(417, 109);
            this.progressBar1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(15, 486);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Master Peak";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // openAudio
            // 
            this.openAudio.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.openAudio.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.openAudio.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.openAudio.Location = new System.Drawing.Point(15, 147);
            this.openAudio.Margin = new System.Windows.Forms.Padding(4);
            this.openAudio.Name = "openAudio";
            this.openAudio.Size = new System.Drawing.Size(417, 29);
            this.openAudio.TabIndex = 3;
            this.openAudio.Text = "Open MP3 file";
            this.openAudio.UseVisualStyleBackColor = false;
            this.openAudio.Click += new System.EventHandler(this.openAudio_Click);
            // 
            // Play
            // 
            this.Play.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Play.Enabled = false;
            this.Play.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Play.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Play.Location = new System.Drawing.Point(15, 184);
            this.Play.Margin = new System.Windows.Forms.Padding(4);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(417, 29);
            this.Play.TabIndex = 4;
            this.Play.Text = "Play";
            this.Play.UseVisualStyleBackColor = false;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pauseButton.Enabled = false;
            this.pauseButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pauseButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pauseButton.Location = new System.Drawing.Point(15, 221);
            this.pauseButton.Margin = new System.Windows.Forms.Padding(4);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(417, 29);
            this.pauseButton.TabIndex = 5;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = false;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.SystemColors.ControlDark;
            this.exit.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.exit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.exit.Location = new System.Drawing.Point(15, 293);
            this.exit.Margin = new System.Windows.Forms.Padding(4);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(417, 29);
            this.exit.TabIndex = 6;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // volumeBar
            // 
            this.volumeBar.BackColor = System.Drawing.SystemColors.Desktop;
            this.volumeBar.Location = new System.Drawing.Point(15, 437);
            this.volumeBar.Margin = new System.Windows.Forms.Padding(4);
            this.volumeBar.Name = "volumeBar";
            this.volumeBar.Size = new System.Drawing.Size(417, 45);
            this.volumeBar.TabIndex = 7;
            this.volumeBar.Value = 10;
            this.volumeBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(15, 414);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Volume:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(485, 378);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "Music name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(80, 414);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "10";
            // 
            // band1Bar
            // 
            this.band1Bar.BackColor = System.Drawing.SystemColors.Desktop;
            this.band1Bar.Location = new System.Drawing.Point(485, 15);
            this.band1Bar.Margin = new System.Windows.Forms.Padding(4);
            this.band1Bar.Name = "band1Bar";
            this.band1Bar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.band1Bar.Size = new System.Drawing.Size(45, 307);
            this.band1Bar.TabIndex = 11;
            this.band1Bar.Visible = false;
            this.band1Bar.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(485, 336);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 19);
            this.label2.TabIndex = 12;
            this.label2.Text = "31";
            this.label2.Visible = false;
            // 
            // band2Bar
            // 
            this.band2Bar.BackColor = System.Drawing.SystemColors.Desktop;
            this.band2Bar.Location = new System.Drawing.Point(550, 15);
            this.band2Bar.Margin = new System.Windows.Forms.Padding(4);
            this.band2Bar.Name = "band2Bar";
            this.band2Bar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.band2Bar.Size = new System.Drawing.Size(45, 307);
            this.band2Bar.TabIndex = 13;
            this.band2Bar.Visible = false;
            this.band2Bar.Scroll += new System.EventHandler(this.band2Bar_Scroll);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(550, 336);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 19);
            this.label6.TabIndex = 14;
            this.label6.Text = "62";
            this.label6.Visible = false;
            // 
            // band3Bar
            // 
            this.band3Bar.BackColor = System.Drawing.SystemColors.Desktop;
            this.band3Bar.Location = new System.Drawing.Point(616, 15);
            this.band3Bar.Margin = new System.Windows.Forms.Padding(4);
            this.band3Bar.Name = "band3Bar";
            this.band3Bar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.band3Bar.Size = new System.Drawing.Size(45, 307);
            this.band3Bar.TabIndex = 15;
            this.band3Bar.Visible = false;
            this.band3Bar.Scroll += new System.EventHandler(this.band3Bar_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(616, 336);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 19);
            this.label7.TabIndex = 16;
            this.label7.Text = "125";
            this.label7.Visible = false;
            // 
            // band4Bar
            // 
            this.band4Bar.BackColor = System.Drawing.SystemColors.Desktop;
            this.band4Bar.Location = new System.Drawing.Point(681, 15);
            this.band4Bar.Margin = new System.Windows.Forms.Padding(4);
            this.band4Bar.Name = "band4Bar";
            this.band4Bar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.band4Bar.Size = new System.Drawing.Size(45, 307);
            this.band4Bar.TabIndex = 17;
            this.band4Bar.Visible = false;
            this.band4Bar.Scroll += new System.EventHandler(this.band4Bar_Scroll);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(681, 336);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 19);
            this.label8.TabIndex = 18;
            this.label8.Text = "250";
            this.label8.Visible = false;
            // 
            // band5Bar
            // 
            this.band5Bar.BackColor = System.Drawing.SystemColors.Desktop;
            this.band5Bar.Location = new System.Drawing.Point(747, 15);
            this.band5Bar.Margin = new System.Windows.Forms.Padding(4);
            this.band5Bar.Name = "band5Bar";
            this.band5Bar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.band5Bar.Size = new System.Drawing.Size(45, 307);
            this.band5Bar.TabIndex = 19;
            this.band5Bar.Visible = false;
            this.band5Bar.Scroll += new System.EventHandler(this.band5Bar_Scroll);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(747, 336);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 19);
            this.label9.TabIndex = 20;
            this.label9.Text = "500";
            this.label9.Visible = false;
            // 
            // band6Bar
            // 
            this.band6Bar.BackColor = System.Drawing.SystemColors.Desktop;
            this.band6Bar.Location = new System.Drawing.Point(813, 15);
            this.band6Bar.Margin = new System.Windows.Forms.Padding(4);
            this.band6Bar.Name = "band6Bar";
            this.band6Bar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.band6Bar.Size = new System.Drawing.Size(45, 307);
            this.band6Bar.TabIndex = 21;
            this.band6Bar.Visible = false;
            this.band6Bar.Scroll += new System.EventHandler(this.band6Bar_Scroll);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(813, 336);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 19);
            this.label10.TabIndex = 22;
            this.label10.Text = "1K";
            this.label10.Visible = false;
            // 
            // band7Bar
            // 
            this.band7Bar.BackColor = System.Drawing.SystemColors.Desktop;
            this.band7Bar.Location = new System.Drawing.Point(878, 15);
            this.band7Bar.Margin = new System.Windows.Forms.Padding(4);
            this.band7Bar.Name = "band7Bar";
            this.band7Bar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.band7Bar.Size = new System.Drawing.Size(45, 307);
            this.band7Bar.TabIndex = 23;
            this.band7Bar.Visible = false;
            this.band7Bar.Scroll += new System.EventHandler(this.band7Bar_Scroll);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.Location = new System.Drawing.Point(878, 336);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 19);
            this.label11.TabIndex = 24;
            this.label11.Text = "2K";
            this.label11.Visible = false;
            // 
            // band8Bar
            // 
            this.band8Bar.BackColor = System.Drawing.SystemColors.Desktop;
            this.band8Bar.Location = new System.Drawing.Point(944, 15);
            this.band8Bar.Margin = new System.Windows.Forms.Padding(4);
            this.band8Bar.Name = "band8Bar";
            this.band8Bar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.band8Bar.Size = new System.Drawing.Size(45, 307);
            this.band8Bar.TabIndex = 25;
            this.band8Bar.Visible = false;
            this.band8Bar.Scroll += new System.EventHandler(this.band8Bar_Scroll);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label12.Location = new System.Drawing.Point(944, 336);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 19);
            this.label12.TabIndex = 26;
            this.label12.Text = "4K";
            this.label12.Visible = false;
            // 
            // band9Bar
            // 
            this.band9Bar.BackColor = System.Drawing.SystemColors.Desktop;
            this.band9Bar.Location = new System.Drawing.Point(1009, 15);
            this.band9Bar.Margin = new System.Windows.Forms.Padding(4);
            this.band9Bar.Name = "band9Bar";
            this.band9Bar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.band9Bar.Size = new System.Drawing.Size(45, 307);
            this.band9Bar.TabIndex = 27;
            this.band9Bar.Visible = false;
            this.band9Bar.Scroll += new System.EventHandler(this.band9Bar_Scroll);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Location = new System.Drawing.Point(1009, 336);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 19);
            this.label13.TabIndex = 28;
            this.label13.Text = "8K";
            this.label13.Visible = false;
            // 
            // band10Bar
            // 
            this.band10Bar.BackColor = System.Drawing.SystemColors.Desktop;
            this.band10Bar.Location = new System.Drawing.Point(1075, 15);
            this.band10Bar.Margin = new System.Windows.Forms.Padding(4);
            this.band10Bar.Name = "band10Bar";
            this.band10Bar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.band10Bar.Size = new System.Drawing.Size(45, 307);
            this.band10Bar.TabIndex = 29;
            this.band10Bar.Visible = false;
            this.band10Bar.Scroll += new System.EventHandler(this.band10Bar_Scroll);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label14.Location = new System.Drawing.Point(1075, 336);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 19);
            this.label14.TabIndex = 30;
            this.label14.Text = "16K";
            this.label14.Visible = false;
            // 
            // Stop
            // 
            this.Stop.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Stop.Enabled = false;
            this.Stop.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Stop.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Stop.Location = new System.Drawing.Point(15, 258);
            this.Stop.Margin = new System.Windows.Forms.Padding(4);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(417, 29);
            this.Stop.TabIndex = 31;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = false;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label15.Location = new System.Drawing.Point(485, 521);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 19);
            this.label15.TabIndex = 32;
            this.label15.Text = "Duration:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label16.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label16.Location = new System.Drawing.Point(557, 521);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 19);
            this.label16.TabIndex = 33;
            this.label16.Text = "dur";
            // 
            // positionBar
            // 
            this.positionBar.BackColor = System.Drawing.SystemColors.Desktop;
            this.positionBar.Location = new System.Drawing.Point(15, 365);
            this.positionBar.Margin = new System.Windows.Forms.Padding(4);
            this.positionBar.Name = "positionBar";
            this.positionBar.Size = new System.Drawing.Size(417, 45);
            this.positionBar.TabIndex = 34;
            this.positionBar.Scroll += new System.EventHandler(this.positionBar_Scroll);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label17.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label17.Location = new System.Drawing.Point(15, 336);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 19);
            this.label17.TabIndex = 35;
            this.label17.Text = "time";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label18.Location = new System.Drawing.Point(485, 413);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(30, 19);
            this.label18.TabIndex = 36;
            this.label18.Text = "title";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label19.Location = new System.Drawing.Point(485, 448);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(38, 19);
            this.label19.TabIndex = 37;
            this.label19.Text = "artist";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label20.Location = new System.Drawing.Point(485, 486);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 19);
            this.label20.TabIndex = 38;
            this.label20.Text = "bitrate";
            // 
            // coverBox
            // 
            this.coverBox.BackColor = System.Drawing.Color.Transparent;
            this.coverBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("coverBox.InitialImage")));
            this.coverBox.Location = new System.Drawing.Point(922, 458);
            this.coverBox.Name = "coverBox";
            this.coverBox.Size = new System.Drawing.Size(250, 160);
            this.coverBox.TabIndex = 39;
            this.coverBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(15, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(417, 29);
            this.button1.TabIndex = 40;
            this.button1.Text = "Save EQ settings";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // visibleEqList
            // 
            this.visibleEqList.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.visibleEqList.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.visibleEqList.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.visibleEqList.Location = new System.Drawing.Point(15, 106);
            this.visibleEqList.Name = "visibleEqList";
            this.visibleEqList.Size = new System.Drawing.Size(417, 29);
            this.visibleEqList.TabIndex = 41;
            this.visibleEqList.Text = "Visible EQ/Music List";
            this.visibleEqList.UseVisualStyleBackColor = false;
            this.visibleEqList.Click += new System.EventHandler(this.visibleEqList_Click);
            // 
            // musicList
            // 
            this.musicList.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.musicList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.musicList.Location = new System.Drawing.Point(454, 15);
            this.musicList.MultiSelect = false;
            this.musicList.Name = "musicList";
            this.musicList.Size = new System.Drawing.Size(718, 340);
            this.musicList.TabIndex = 42;
            this.musicList.UseCompatibleStateImageBehavior = false;
            this.musicList.View = System.Windows.Forms.View.Details;
            this.musicList.SelectedIndexChanged += new System.EventHandler(this.musicList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 520;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Artist";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Duration";
            this.columnHeader3.Width = 80;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1184, 641);
            this.Controls.Add(this.musicList);
            this.Controls.Add(this.visibleEqList);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.coverBox);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.positionBar);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.band10Bar);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.band9Bar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.band8Bar);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.band7Bar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.band6Bar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.band5Bar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.band4Bar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.band3Bar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.band2Bar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.band1Bar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.volumeBar);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.Play);
            this.Controls.Add(this.openAudio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.progressBar1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1200, 720);
            this.MinimumSize = new System.Drawing.Size(1200, 680);
            this.Name = "Form1";
            this.Text = "MP3 Player";
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.band1Bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.band2Bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.band3Bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.band4Bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.band5Bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.band6Bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.band7Bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.band8Bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.band9Bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.band10Bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coverBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProgressBar progressBar1;
        private ComboBox comboBox1;
        private Label label1;
        private ComboBox comboBox2;
        private ProgressBar progressBar2;
        private Label label2;
        private System.Windows.Forms.Timer timer1;
        private Button openAudio;
        private Button Play;
        private Button pauseButton;
        private Button exit;
        private TrackBar volumeBar;
        private Label label3;
        private Label label4;
        private Label label5;
        private TrackBar band1Bar;
        private TrackBar band2Bar;
        private Label label6;
        private TrackBar band3Bar;
        private Label label7;
        private TrackBar band4Bar;
        private Label label8;
        private TrackBar band5Bar;
        private Label label9;
        private TrackBar band6Bar;
        private Label label10;
        private TrackBar band7Bar;
        private Label label11;
        private TrackBar band8Bar;
        private Label label12;
        private TrackBar band9Bar;
        private Label label13;
        private TrackBar band10Bar;
        private Label label14;
        private Button Stop;
        private Label label15;
        private Label label16;
        private TrackBar positionBar;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private PictureBox coverBox;
        private Button button1;
        private Button visibleEqList;
        private ListView musicList;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        //private TrackBar Band1;
    }
}