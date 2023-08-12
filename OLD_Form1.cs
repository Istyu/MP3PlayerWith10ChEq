using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NAudio;
using NAudio.CoreAudioApi;
using NAudio.Dsp;
using NAudio.Mixer;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using TagLib;

namespace MusicPlayer
{
    public partial class Form1 : Form
    {
        private NAudio.Extras.Equalizer equalizer;
        private NAudio.Extras.EqualizerBand[] bands;

        private NAudio.Wave.BlockAlignReductionStream stream = null;
        //private NAudio.Wave.DirectSoundOut output = null;
        private NAudio.Wave.WaveOutEvent output = null; // With this possible the sound volume controlling
        private List<string> songPaths = new List<string>();

        public float[] eqValues;
        public int[] eqScrollValues;

        // Thread definitions
        Thread thread;
        public bool threadStarted;
        Thread timeScrollThread;
        public bool scrollThreadStarted;

        public bool decrementVol;
        public bool incrementVol;
        public bool stopped;
        public float currentVol;
        public string volText;
        public bool visibleEqAndList;
        //public bool audioFileLoaded;

        public float Band1
        {
            get
            {
                return bands[0].Gain;
            }
            set
            {
                if (bands[0].Gain != value)
                {
                    bands[0].Gain = value;
                    //OnPropertyChanged("Band1");
                }
            }
        }
        public float Band2
        {
            get
            {
                return bands[1].Gain;
            }
            set
            {
                if (bands[1].Gain != value)
                {
                    bands[1].Gain = value;
                    //OnPropertyChanged("Band2");
                }
            }
        }
        public float Band3
        {
            get
            {
                return bands[2].Gain;
            }
            set
            {
                if (bands[2].Gain != value)
                {
                    bands[2].Gain = value;
                    //OnPropertyChanged("Band3");
                }
            }
        }
        public float Band4
        {
            get
            {
                return bands[3].Gain;
            }
            set
            {
                if (bands[3].Gain != value)
                {
                    bands[3].Gain = value;
                    //OnPropertyChanged("Band4");
                }
            }
        }
        public float Band5
        {
            get
            {
                return bands[4].Gain;
            }
            set
            {
                if (bands[4].Gain != value)
                {
                    bands[4].Gain = value;
                    //OnPropertyChanged("Band5");
                }
            }
        }
        public float Band6
        {
            get
            {
                return bands[5].Gain;
            }
            set
            {
                if (bands[5].Gain != value)
                {
                    bands[5].Gain = value;
                    //OnPropertyChanged("Band6");
                }
            }
        }
        public float Band7
        {
            get
            {
                return bands[6].Gain;
            }
            set
            {
                if (bands[6].Gain != value)
                {
                    bands[6].Gain = value;
                    //OnPropertyChanged("Band7");
                }
            }
        }
        public float Band8
        {
            get
            {
                return bands[7].Gain;
            }
            set
            {
                if (bands[7].Gain != value)
                {
                    bands[7].Gain = value;
                    //OnPropertyChanged("Band7");
                }
            }
        }
        public float Band9
        {
            get
            {
                return bands[8].Gain;
            }
            set
            {
                if (bands[8].Gain != value)
                {
                    bands[8].Gain = value;
                    //OnPropertyChanged("Band7");
                }
            }
        }
        public float Band10
        {
            get
            {
                return bands[9].Gain;
            }
            set
            {
                if (bands[9].Gain != value)
                {
                    bands[9].Gain = value;
                    //OnPropertyChanged("Band7");
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            //InitializeListView();

            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            var devices = enumerator.EnumerateAudioEndPoints( DataFlow.All, DeviceState.Active );
            comboBox1.Text = "Choose the audio source...";
            comboBox1.Items.AddRange( devices.ToArray() );

            eqValues = new float[10];
            eqScrollValues = new int[10];

            thread = new Thread(ThreadFunc);
            thread.IsBackground = true;
            threadStarted = false;

            timeScrollThread = new Thread(timeScrollFunc);
            timeScrollThread.IsBackground = true;
            scrollThreadStarted = false;

            decrementVol = false;
            incrementVol = false;
            //audioFileLoaded = false;
            stopped = false;
            currentVol = 1.0f;
            volText = "";
            visibleEqAndList = false;

            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string fileName = "eqsettings.txt";
            string filePath = Path.Combine(executablePath, fileName);

            if( !System.IO.File.Exists( filePath ) )
                eqSettingsFirstTime();
        }

        /*private void InitializeListView()
        {
            musicList.View = View.Details;
            musicList.Columns.Add("Name");
            musicList.Columns.Add("Duration");
        }*/

        private void timer1_Tick(object sender, EventArgs e)
        {
            if( comboBox1.SelectedItem != null )
            {
                var device = (MMDevice) comboBox1.SelectedItem;
                progressBar1.Value = (int)( Math.Round( device.AudioMeterInformation.MasterPeakValue * 100 ) );
            }
        }

        private Image ResizeImage(Image image, int width, int height)
        {
            // Create new image the specified sizes
            Bitmap resizedImage = new Bitmap(width, height);
        
            // Drawing to the new image with the sized image
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.DrawImage(image, 0, 0, width, height);
            }
        
            return resizedImage;
        }

        private string GetDuration(string filePath)
        {
            try
            {
                using (var file = TagLib.File.Create(filePath))
                {
                    TimeSpan duration = file.Properties.Duration;
                    return duration.ToString(@"mm\:ss"); // Formázott időtartam (perc:másodperc)
                }
            }
            catch (Exception)
            {
                return "N/A"; // Hiba esetén vagy ha nincs időtartam információ
            }
        }

        private NAudio.Wave.WaveStream pcm = null;
        private void openAudio_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = true;
            open.Title = "Select mp3 file"; // Selection window title
            open.Filter = "MP3 file (*.mp3)|*.mp3;";
            if( open.ShowDialog() != DialogResult.OK )
                return;

            foreach(string fileName in open.FileNames)
            {
                string songTitle = System.IO.Path.GetFileNameWithoutExtension(fileName);
                //string artist = "Ismeretlen"; // Ide valós előadó adatokat olvashatsz be
                string songDuration = GetDuration(fileName);
                ListViewItem item = new ListViewItem(new string[] { songTitle, songDuration });
                musicList.Items.Add(item);
            }
        }

        private void musicList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (musicList.SelectedItems.Count > 0)
            {
                int selectedIndex = musicList.SelectedItems[0].Index;
                PlaySong(selectedIndex);
            }
        }

        private void PlaySong(int index)
        {
            if (index >= 0 && index < songPaths.Count)
            {
                //player.SoundLocation = songPaths[index];
                //player.Play();

                string selectedFilePath = songPaths[index].FileName;
                var file = TagLib.File.Create(selectedFilePath);
                string title = file.Tag.Title; // Title
                string artist = file.Tag.FirstPerformer; // Artist
                int bitrate = (int)file.Properties.AudioBitrate; // Bitrate
                string bitrateStr = bitrate.ToString();
                IPicture[] pictures = file.Tag.Pictures; // Cover
                label18.Text = title;
                label19.Text = artist;
                label20.Text = bitrateStr + "kb/s";
                if (pictures.Length > 0)
                {
                    IPicture picture = pictures[0];
                    using (MemoryStream memoryStream = new MemoryStream(picture.Data.Data))
                    {
                        Image albumArtImage = Image.FromStream(memoryStream);
                        // Scaling the albumArtImage to the size of coverBox
                        albumArtImage = ResizeImage(albumArtImage, coverBox.Width, coverBox.Height);
                        coverBox.Image = albumArtImage;
                    }
                }
                else
                    coverBox.Image = coverBox.InitialImage;

                //audioFileLoaded = true;

                DisposeWave();
                resetBandBars();
                string selectedFileName = songPaths[index].SafeFileName;
                label4.Text = selectedFileName;
                stopped = false;

                if(!threadStarted)
                    thread.Start();

                if(!scrollThreadStarted)
                    timeScrollThread.Start();

                StreamReader Read = null;
                Read = new StreamReader( "eqsettings.txt" );
                while( Read.Peek() > -1 )
                    StringRead(Read.ReadLine());
                Read.Close();

                eqScroll();

                bands = new NAudio.Extras.EqualizerBand[10]
                {
                    new NAudio.Extras.EqualizerBand
                    {
                        Bandwidth = 0.8f,
                        Frequency = 31,
                        Gain = eqValues[0]
                    },
                    new NAudio.Extras.EqualizerBand
                    {
                        Bandwidth = 0.8f,
                        Frequency = 62,
                        Gain = eqValues[1]
                    },
                    new NAudio.Extras.EqualizerBand
                    {
                        Bandwidth = 0.8f,
                        Frequency = 125,
                        Gain = eqValues[2]
                    },
                    new NAudio.Extras.EqualizerBand
                    {
                        Bandwidth = 0.8f,
                        Frequency = 250,
                        Gain = eqValues[3]
                    },
                    new NAudio.Extras.EqualizerBand
                    {
                        Bandwidth = 0.8f,
                        Frequency = 500,
                        Gain = eqValues[4]
                    },
                    new NAudio.Extras.EqualizerBand
                    {
                        Bandwidth = 0.8f,
                        Frequency = 1000,
                        Gain = eqValues[5]
                    },
                    new NAudio.Extras.EqualizerBand
                    {
                        Bandwidth = 0.8f,
                        Frequency = 2000,
                        Gain = eqValues[6]
                    },
                    new NAudio.Extras.EqualizerBand
                    {
                        Bandwidth = 0.8f,
                        Frequency = 4000,
                        Gain = eqValues[7]
                    },
                    new NAudio.Extras.EqualizerBand
                    {
                        Bandwidth = 0.8f,
                        Frequency = 8000,
                        Gain = eqValues[8]
                    },
                    new NAudio.Extras.EqualizerBand
                    {
                        Bandwidth = 0.8f,
                        Frequency = 16000,
                        Gain = eqValues[9]
                    }
                };

                this.pcm = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream( new NAudio.Wave.Mp3FileReader(songPaths[index].FileName) );
                WaveChannel32 waveChannel = new WaveChannel32(pcm);
                ISampleProvider sampleChannel = new SampleChannel(waveChannel);
                equalizer = new NAudio.Extras.Equalizer(sampleChannel, bands);
                TimeSpan duration = pcm.TotalTime;
                string durationString = duration.ToString();
                label16.Text = durationString;
                //output = new NAudio.Wave.DirectSoundOut();
                output = new NAudio.Wave.WaveOutEvent(); // With this possible the sound volume controlling
                output.Volume = 1.0f; // Controlling the sound volume | 1.0 = 100%, 0.5 = 50%, 0.0 = 0% |
                //output.Init( stream );
                output.Init(new SampleToWaveProvider(equalizer));

                positionBar.Minimum = 0;
                positionBar.Maximum = (int)pcm.TotalTime.TotalSeconds;

                Play.Enabled = true;
                pauseButton.Enabled = true;
                Stop.Enabled = true;
            }
        }

        void timeScrollFunc()
        {
            scrollThreadStarted = true;
            while( scrollThreadStarted )
            {
                Thread.Sleep(50);
                if( !stopped )
                {
                    string currTime = this.pcm.CurrentTime.ToString();
                    label17.Text = currTime;
                    double totalSeconds = this.pcm.CurrentTime.TotalSeconds;
                    int seconds = (int)totalSeconds;
                    positionBar.Value = seconds;
                }
            }
        }

        private void Play_Click(object sender, EventArgs e)
        {
            //if( output != null )
            //{
                //if( output.PlaybackState == NAudio.Wave.PlaybackState.Paused )
                    incrementVol = true;
                    stopped = false;
            //}
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if( output != null )
            {
                if( output.PlaybackState == NAudio.Wave.PlaybackState.Playing )
                    decrementVol = true;
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            if( output != null )
            {
                stopped = true;
                label17.Text = "0";
                positionBar.Value = 0;
                this.pcm.CurrentTime = new TimeSpan(0);
                output.Stop();
            }
        }

        private void button1_Click(object sender, EventArgs e) // Save EQ settings
        {
            StreamWriter Write = null;

            Write = new StreamWriter( "eqsettings.txt" );
            Write.WriteLine( "eq1Value=" + eqValues[0].ToString() );
            Write.WriteLine( "eq1Scroll=" + eqScrollValues[0].ToString() );
            Write.WriteLine( "eq2Value=" + eqValues[1].ToString() );
            Write.WriteLine( "eq2Scroll=" + eqScrollValues[1].ToString() );
            Write.WriteLine( "eq3Value=" + eqValues[2].ToString() );
            Write.WriteLine( "eq3Scroll=" + eqScrollValues[2].ToString() );
            Write.WriteLine( "eq4Value=" + eqValues[3].ToString() );
            Write.WriteLine( "eq4Scroll=" + eqScrollValues[3].ToString() );
            Write.WriteLine( "eq5Value=" + eqValues[4].ToString() );
            Write.WriteLine( "eq5Scroll=" + eqScrollValues[4].ToString() );
            Write.WriteLine( "eq6Value=" + eqValues[5].ToString() );
            Write.WriteLine( "eq6Scroll=" + eqScrollValues[5].ToString() );
            Write.WriteLine( "eq7Value=" + eqValues[6].ToString() );
            Write.WriteLine( "eq7Scroll=" + eqScrollValues[6].ToString() );
            Write.WriteLine( "eq8Value=" + eqValues[7].ToString() );
            Write.WriteLine( "eq8Scroll=" + eqScrollValues[7].ToString() );
            Write.WriteLine( "eq9Value=" + eqValues[8].ToString() );
            Write.WriteLine( "eq9Scroll=" + eqScrollValues[8].ToString() );
            Write.WriteLine( "eq10Value=" + eqValues[9].ToString() );
            Write.WriteLine( "eq10Scroll=" + eqScrollValues[9].ToString() );
            Write.Close();
        }

        private void visibleEqList_Click(object sender, EventArgs e)
        {
            if( visibleEqAndList )
            {
                label2.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                band1Bar.Visible = false;
                band2Bar.Visible = false;
                band3Bar.Visible = false;
                band4Bar.Visible = false;
                band5Bar.Visible = false;
                band6Bar.Visible = false;
                band7Bar.Visible = false;
                band8Bar.Visible = false;
                band9Bar.Visible = false;
                band10Bar.Visible = false;
                visibleEqAndList = false;
            }
            else if( !visibleEqAndList )
            {
                label2.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
                label14.Visible = true;
                band1Bar.Visible = true;
                band2Bar.Visible = true;
                band3Bar.Visible = true;
                band4Bar.Visible = true;
                band5Bar.Visible = true;
                band6Bar.Visible = true;
                band7Bar.Visible = true;
                band8Bar.Visible = true;
                band9Bar.Visible = true;
                band10Bar.Visible = true;
                visibleEqAndList = true;
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            DisposeWave();
            this.Close();
        }

        private void positionBar_Scroll(object sender, EventArgs e)
        {
            if( output != null )
            {
                if( output.PlaybackState == NAudio.Wave.PlaybackState.Playing )
                {
                    output.Pause();
                    this.pcm.CurrentTime = TimeSpan.FromSeconds(positionBar.Value);
                    output.Play();
                }
                else
                    this.pcm.CurrentTime = TimeSpan.FromSeconds(positionBar.Value);
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (equalizer == null)
                return;
            /*if( band1Bar.Value == 0 )
                bands[0].Gain = 0.0f;
            if( band1Bar.Value == 1 )
                bands[0].Gain = 1.0f;
            if( band1Bar.Value == 2 )
                bands[0].Gain = 2.0f;
            if( band1Bar.Value == 3 )
                bands[0].Gain = 3.0f;
            if( band1Bar.Value == 4 )
                bands[0].Gain = 4.0f;
            if( band1Bar.Value == 5 )
                bands[0].Gain = 5.0f;
            if( band1Bar.Value == 6 )
                bands[0].Gain = 6.0f;
            if( band1Bar.Value == 7 )
                bands[0].Gain = 7.0f;
            if( band1Bar.Value == 8 )
                bands[0].Gain = 8.0f;
            if( band1Bar.Value == 9 )
                bands[0].Gain = 9.0f;
            if( band1Bar.Value == 10 )
                bands[0].Gain = 10.0f;*/

            int selectedValue = band1Bar.Value;
            float newGain = Math.Min(selectedValue, 10.0f);
            bands[0].Gain = newGain;

            eqValues[0] = newGain;
            eqScrollValues[0] = selectedValue;

            equalizer.Update();
        }

        private void band2Bar_Scroll(object sender, EventArgs e)
        {
            if (equalizer == null)
                return;

            int selectedValue = band2Bar.Value;
            float newGain = Math.Min(selectedValue, 10.0f);
            bands[1].Gain = newGain;

            eqValues[1] = newGain;
            eqScrollValues[1] = selectedValue;

            equalizer.Update();
        }

        private void band3Bar_Scroll(object sender, EventArgs e)
        {
            if (equalizer == null)
                return;

            int selectedValue = band3Bar.Value;
            float newGain = Math.Min(selectedValue, 10.0f);
            bands[2].Gain = newGain;

            eqValues[2] = newGain;
            eqScrollValues[2] = selectedValue;

            equalizer.Update();
        }

        private void band4Bar_Scroll(object sender, EventArgs e)
        {
            if (equalizer == null)
                return;

            int selectedValue = band4Bar.Value;
            float newGain = Math.Min(selectedValue, 10.0f);
            bands[3].Gain = newGain;

            eqValues[3] = newGain;
            eqScrollValues[3] = selectedValue;

            equalizer.Update();
        }

        private void band5Bar_Scroll(object sender, EventArgs e)
        {
            if (equalizer == null)
                return;

            int selectedValue = band5Bar.Value;
            float newGain = Math.Min(selectedValue, 10.0f);
            bands[4].Gain = newGain;

            eqValues[4] = newGain;
            eqScrollValues[4] = selectedValue;

            equalizer.Update();
        }

        private void band6Bar_Scroll(object sender, EventArgs e)
        {
            if (equalizer == null)
                return;

            int selectedValue = band6Bar.Value;
            float newGain = Math.Min(selectedValue, 10.0f);
            bands[5].Gain = newGain;

            eqValues[5] = newGain;
            eqScrollValues[5] = selectedValue;

            equalizer.Update();
        }

        private void band7Bar_Scroll(object sender, EventArgs e)
        {
            if (equalizer == null)
                return;

            int selectedValue = band7Bar.Value;
            float newGain = Math.Min(selectedValue, 10.0f);
            bands[6].Gain = newGain;

            eqValues[6] = newGain;
            eqScrollValues[6] = selectedValue;

            equalizer.Update();
        }

        private void band8Bar_Scroll(object sender, EventArgs e)
        {
            if (equalizer == null)
                return;

            int selectedValue = band8Bar.Value;
            float newGain = Math.Min(selectedValue, 10.0f);
            bands[7].Gain = newGain;

            eqValues[7] = newGain;
            eqScrollValues[7] = selectedValue;

            equalizer.Update();
        }

        private void band9Bar_Scroll(object sender, EventArgs e)
        {
            if (equalizer == null)
                return;

            int selectedValue = band9Bar.Value;
            float newGain = Math.Min(selectedValue, 10.0f);
            bands[8].Gain = newGain;

            eqValues[8] = newGain;
            eqScrollValues[8] = selectedValue;

            equalizer.Update();
        }

        private void band10Bar_Scroll(object sender, EventArgs e)
        {
            if (equalizer == null)
                return;

            int selectedValue = band10Bar.Value;
            float newGain = Math.Min(selectedValue, 10.0f);
            bands[9].Gain = newGain;

            eqValues[9] = newGain;
            eqScrollValues[9] = selectedValue;

            equalizer.Update();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //if( !audioFileLoaded )
            //    return;
            if( output == null )
                return;
            if( volumeBar.Value == 0 )
                output.Volume = 0.0f;
            if( volumeBar.Value == 1 )
                output.Volume = 0.1f;
            if( volumeBar.Value == 2 )
                output.Volume = 0.2f;
            if( volumeBar.Value == 3 )
                output.Volume = 0.3f;
            if( volumeBar.Value == 4 )
                output.Volume = 0.4f;
            if( volumeBar.Value == 5 )
                output.Volume = 0.5f;
            if( volumeBar.Value == 6 )
                output.Volume = 0.6f;
            if( volumeBar.Value == 7 )
                output.Volume = 0.7f;
            if( volumeBar.Value == 8 )
                output.Volume = 0.8f;
            if( volumeBar.Value == 9 )
                output.Volume = 0.9f;
            if( volumeBar.Value == 10 )
                output.Volume = 1.0f;

            currentVol = output.Volume;
            volText = volumeBar.Value.ToString();
            label5.Text = volText;
        }

        private void eqSettingsFirstTime()
        {
            StreamWriter Write = null;

            Write = new StreamWriter( "eqsettings.txt" );
            Write.WriteLine( "eq1Value=0");
            Write.WriteLine( "eq1Scroll=0");
            Write.WriteLine( "eq2Value=0");
            Write.WriteLine( "eq2Scroll=0");
            Write.WriteLine( "eq3Value=0");
            Write.WriteLine( "eq3Scroll=0");
            Write.WriteLine( "eq4Value=0");
            Write.WriteLine( "eq4Scroll=0");
            Write.WriteLine( "eq5Value=0");
            Write.WriteLine( "eq5Scroll=0");
            Write.WriteLine( "eq6Value=0");
            Write.WriteLine( "eq6Scroll=0");
            Write.WriteLine( "eq7Value=0");
            Write.WriteLine( "eq7Scroll=0");
            Write.WriteLine( "eq8Value=0");
            Write.WriteLine( "eq8Scroll=0");
            Write.WriteLine( "eq9Value=0");
            Write.WriteLine( "eq9Scroll=0");
            Write.WriteLine( "eq10Value=0");
            Write.WriteLine( "eq10Scroll=0");
            Write.Close();
        }

        private void StringRead( string buffer )
        {
            if( buffer.StartsWith("eq1Value=") )
            {
                float eqVal = float.Parse(buffer.Substring(9));
                eqValues[0] = eqVal;
            }
            if( buffer.StartsWith("eq1Scroll=") )
            {
                int eqScroll = int.Parse(buffer.Substring(10));
                eqScrollValues[0] = eqScroll;
            }
            if( buffer.StartsWith("eq2Value=") )
            {
                float eq2Val = float.Parse(buffer.Substring(9));
                eqValues[1] = eq2Val;
            }
            if( buffer.StartsWith("eq2Scroll=") )
            {
                int eq2Scroll = int.Parse(buffer.Substring(10));
                eqScrollValues[1] = eq2Scroll;
            }
            if( buffer.StartsWith("eq3Value=") )
            {
                float eq3Val = float.Parse(buffer.Substring(9));
                eqValues[2] = eq3Val;
            }
            if( buffer.StartsWith("eq3Scroll=") )
            {
                int eq3Scroll = int.Parse(buffer.Substring(10));
                eqScrollValues[2] = eq3Scroll;
            }
            if( buffer.StartsWith("eq4Value=") )
            {
                float eq4Val = float.Parse(buffer.Substring(9));
                eqValues[3] = eq4Val;
            }
            if( buffer.StartsWith("eq4Scroll=") )
            {
                int eq4Scroll = int.Parse(buffer.Substring(10));
                eqScrollValues[3] = eq4Scroll;
            }
            if( buffer.StartsWith("eq5Value=") )
            {
                float eq5Val = float.Parse(buffer.Substring(9));
                eqValues[4] = eq5Val;
            }
            if( buffer.StartsWith("eq5Scroll=") )
            {
                int eq5Scroll = int.Parse(buffer.Substring(10));
                eqScrollValues[4] = eq5Scroll;
            }
            if( buffer.StartsWith("eq6Value=") )
            {
                float eq6Val = float.Parse(buffer.Substring(9));
                eqValues[5] = eq6Val;
            }
            if( buffer.StartsWith("eq6Scroll=") )
            {
                int eq6Scroll = int.Parse(buffer.Substring(10));
                eqScrollValues[5] = eq6Scroll;
            }
            if( buffer.StartsWith("eq7Value=") )
            {
                float eq7Val = float.Parse(buffer.Substring(9));
                eqValues[6] = eq7Val;
            }
            if( buffer.StartsWith("eq7Scroll=") )
            {
                int eq7Scroll = int.Parse(buffer.Substring(10));
                eqScrollValues[6] = eq7Scroll;
            }
            if( buffer.StartsWith("eq8Value=") )
            {
                float eq8Val = float.Parse(buffer.Substring(9));
                eqValues[7] = eq8Val;
            }
            if( buffer.StartsWith("eq8Scroll=") )
            {
                int eq8Scroll = int.Parse(buffer.Substring(10));
                eqScrollValues[7] = eq8Scroll;
            }
            if( buffer.StartsWith("eq9Value=") )
            {
                float eq9Val = float.Parse(buffer.Substring(9));
                eqValues[8] = eq9Val;
            }
            if( buffer.StartsWith("eq9Scroll=") )
            {
                int eq9Scroll = int.Parse(buffer.Substring(10));
                eqScrollValues[8] = eq9Scroll;
            }
            if( buffer.StartsWith("eq10Value=") )
            {
                float eq10Val = float.Parse(buffer.Substring(10));
                eqValues[9] = eq10Val;
            }
            if( buffer.StartsWith("eq10Scroll=") )
            {
                int eq10Scroll = int.Parse(buffer.Substring(11));
                eqScrollValues[9] = eq10Scroll;
            }
        }

        private void eqScroll()
        {
            if( eqScrollValues[0] != null )
            {
                band1Bar.Value = eqScrollValues[0];
            }
            if( eqScrollValues[1] != null )
            {
                band2Bar.Value = eqScrollValues[1];
            }
            if( eqScrollValues[2] != null )
            {
                band3Bar.Value = eqScrollValues[2];
            }
            if( eqScrollValues[3] != null )
            {
                band4Bar.Value = eqScrollValues[3];
            }
            if( eqScrollValues[4] != null )
            {
                band5Bar.Value = eqScrollValues[4];
            }
            if( eqScrollValues[5] != null )
            {
                band6Bar.Value = eqScrollValues[5];
            }
            if( eqScrollValues[6] != null )
            {
                band7Bar.Value = eqScrollValues[6];
            }
            if( eqScrollValues[7] != null )
            {
                band8Bar.Value = eqScrollValues[7];
            }
            if( eqScrollValues[8] != null )
            {
                band9Bar.Value = eqScrollValues[8];
            }
            if( eqScrollValues[9] != null )
            {
                band10Bar.Value = eqScrollValues[9];
            }
        }

        void resetBandBars()
        {
            band1Bar.Value = 0;
            band2Bar.Value = 0;
            band3Bar.Value = 0;
            band4Bar.Value = 0;
            band5Bar.Value = 0;
            band6Bar.Value = 0;
            band7Bar.Value = 0;
            band8Bar.Value = 0;
            band9Bar.Value = 0;
            band10Bar.Value = 0;
        }

        private void DisposeWave()
        {
            if( output != null )
            {
                if( output.PlaybackState == NAudio.Wave.PlaybackState.Playing )
                    output.Stop();
                output.Dispose();
                output = null;
            }
            if( pcm != null )
            {
                pcm.Dispose();
                pcm = null;
            }
            if( stream != null )
            {
                stream.Dispose();
                stream = null;
            }
        }

        void ThreadFunc()
        {
            threadStarted = true;
            while( threadStarted )
            {
                if( decrementVol )
                {
                    for( float i = currentVol; i > 0.0f; i-= 0.1f )
                    {
                        output.Volume = i;
                        Thread.Sleep(50);
                    }
                    output.Pause();
                    decrementVol = false;
                }
                if( incrementVol )
                {
                    output.Play();
                    output.Volume = 0.0f;
                    for( float i = 0.0f; i <= currentVol; i+= 0.1f )
                    {
                        output.Volume = i;
                        Thread.Sleep(50);
                    }
                    incrementVol = false;
                }
            }
        }
    }
}

namespace NAudio.Extras
{
    /// <summary>
    /// Basic example of a multi-band eq
    /// uses the same settings for both channels in stereo audio
    /// Call Update after you've updated the bands
    /// Potentially to be added to NAudio in a future version
    /// </summary>
    public class Equalizer : ISampleProvider
    {
        private readonly ISampleProvider sourceProvider;
        private readonly EqualizerBand[] bands;
        private readonly BiQuadFilter[,] filters;
        private readonly int channels;
        private readonly int bandCount;
        private bool updated;

        public Equalizer(ISampleProvider sourceProvider, EqualizerBand[] bands)
        {
            this.sourceProvider = sourceProvider;
            this.bands = bands;
            channels = sourceProvider.WaveFormat.Channels;
            bandCount = bands.Length;
            filters = new BiQuadFilter[channels,bands.Length];
            CreateFilters();
        }

        private void CreateFilters()
        {
            for (int bandIndex = 0; bandIndex < bandCount; bandIndex++)
            {
                var band = bands[bandIndex];
                for (int n = 0; n < channels; n++)
                {
                    if (filters[n, bandIndex] == null)
                        filters[n, bandIndex] = BiQuadFilter.PeakingEQ(sourceProvider.WaveFormat.SampleRate, band.Frequency, band.Bandwidth, band.Gain);
                    else
                        filters[n, bandIndex].SetPeakingEq(sourceProvider.WaveFormat.SampleRate, band.Frequency, band.Bandwidth, band.Gain);
                }
            }
        }

        public void Update()
        {
            updated = true;
            CreateFilters();
        }

        public WaveFormat WaveFormat => sourceProvider.WaveFormat;

        public int Read(float[] buffer, int offset, int count)
        {
            int samplesRead = sourceProvider.Read(buffer, offset, count);

            if (updated)
            {
                CreateFilters();
                updated = false;
            }

            for (int n = 0; n < samplesRead; n++)
            {
                int ch = n % channels; 
                
                for (int band = 0; band < bandCount; band++)
                {
                    buffer[offset + n] = filters[ch, band].Transform(buffer[offset + n]);
                }
            }
            return samplesRead;
        }
    }

    public class EqualizerBand
    {
        public float Frequency { get; set; }
        public float Gain { get; set; }
        public float Bandwidth { get; set; }
    }

    public class SampleToWaveProvider : IWaveProvider
    {
        private readonly ISampleProvider source;
    
        public WaveFormat WaveFormat => source.WaveFormat;
    
        public SampleToWaveProvider(ISampleProvider source)
        {
            if (source.WaveFormat.Encoding != WaveFormatEncoding.IeeeFloat)
            {
                throw new ArgumentException("Must be already floating point");
            }
            this.source = source;
        }
    
        public int Read(byte[] buffer, int offset, int count)
        {
            int count2 = count / 4;
            WaveBuffer waveBuffer = new WaveBuffer(buffer);
            return source.Read(waveBuffer.FloatBuffer, offset / 4, count2) * 4;
        }
    }
}