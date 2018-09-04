using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Diagnostics;
using AForge.Video.FFMPEG;
using System.IO;
using System.Drawing.Imaging;
namespace TabHeaderDemo
{
    public partial class UserControlCamera1 : UserControl
    {
        FilterInfoCollection videoDevices;
        // stop watch for measuring fps
        private Stopwatch stopWatch = null;
       


        
        public VideoFileWriter videoWriter = null;//写入到视频
        public Bitmap bm1 = null;
        Boolean is_record_video = false;
        Boolean ifCam1 = false;


        int hour = 0;
        int tick_num = 0;
       
        int fps = 30;        //正常速率，fps越大速率越快，相当于快进

        System.Timers.Timer timer_count;

        public void play()
        {
            FileVideoSource fileSource = new FileVideoSource(System.Windows.Forms.Application.StartupPath + "\\MyVideo\\"+
                CComLibrary.GlobeVal.filesave.play_avi_file);

            // open it
            OpenVideoSource(fileSource);
        }

        public void stop()
        {
            // stop current video source
            CloseCurrentVideoSource();

          
            this.videoSourcePlayer1.Stop();
            
        }

        public void Init()
        {
            return;
        }
        public UserControlCamera1()
        {
            InitializeComponent();
            camera1FpsLabel.Text = string.Empty;
           

            // show device list
            try
            {
                // enumerate video devices
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count == 0)
                {
                    throw new Exception();
                }

                for (int i = 1, n = videoDevices.Count; i <= n; i++)
                {
                    string cameraName = i + " : " + videoDevices[i - 1].Name;

                    comboBox_camera.Items.Add(cameraName);
                   
                }

                // check cameras count
                if (videoDevices.Count == 1)
                {
                    
                }
                else
                {
                  
                }
                comboBox_camera.SelectedIndex = 0;
            }
            catch
            {
                startButton.Enabled = false;

                comboBox_camera.Items.Add("No cameras found");
              

                comboBox_camera.SelectedIndex = 0;
              
                comboBox_camera.Enabled = false;
            
            }
        }
        private void StartCameras()
        {
            // create first video source
            VideoCaptureDevice videoSource1 = new VideoCaptureDevice(videoDevices[comboBox_camera.SelectedIndex].MonikerString);
            videoSource1.DesiredFrameRate = fps;

            videoSourcePlayer1.VideoSource = videoSource1;
            videoSourcePlayer1.Start();

            // create second video source
            

            // reset stop watch
            stopWatch = null;
            // start timer
            timer1.Enabled = true;
        }

        // Stop cameras
        private void StopCameras()
        {
            timer1.Enabled = false;

            videoSourcePlayer1.SignalToStop();
         

            videoSourcePlayer1.WaitForStop();
            
        }

        private void UserControlCamera_Load(object sender, EventArgs e)
        {

          
            btnStopVideo.Enabled = false;
            btnTakePic.Enabled = false;

         
           
        }
        public void tick_count(object source, System.Timers.ElapsedEventArgs e)
        {
          
           
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            IVideoSource videoSource1 = videoSourcePlayer1.VideoSource;
           
           
            int framesReceived1 = 0;
            int framesReceived2 = 0;

            // get number of frames for the last second
            if (videoSource1 != null)
            {
                framesReceived1 = videoSource1.FramesReceived;
            }

           

            if (stopWatch == null)
            {
                stopWatch = new Stopwatch();
                stopWatch.Start();
            }
            else
            {
                stopWatch.Stop();

                float fps1 = 1000.0f * framesReceived1 / stopWatch.ElapsedMilliseconds;
                float fps2 = 1000.0f * framesReceived2 / stopWatch.ElapsedMilliseconds;

                camera1FpsLabel.Text = fps1.ToString("F2") + " fps";
              

                stopWatch.Reset();
                stopWatch.Start();
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (GlobeVal.cam1 == null)
            {

                GlobeVal.cam1 = new VideoCaptureDevice(videoDevices[comboBox_camera.SelectedIndex].MonikerString);
            }
            else
            {
                GlobeVal.cam1.Stop();
                GlobeVal.cam1.NewFrame -= Cam_NewFrame1;
            }  


            GlobeVal.cam1.DesiredFrameRate = fps;


            videoSourcePlayer1.VideoSource = GlobeVal.cam1;
            videoSourcePlayer1.Start();

            //MessageBox.Show( cam1.VideoCapabilities[0].FrameSize.Width.ToString());

            //cam1.DesiredFrameSize = new System.Drawing.Size(width, height);
            //cam1.DesiredFrameRate = fps;
             GlobeVal.cam1.NewFrame += new NewFrameEventHandler(Cam_NewFrame1);
             GlobeVal.cam1.Start();
            btnStartVideo.Enabled = true;


            startButton.Enabled = false;
            stopButton.Enabled = true;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {

            startButton.Enabled = true;
            stopButton.Enabled = false;

            camera1FpsLabel.Text = string.Empty;
            videoSourcePlayer1.SignalToStop();
            btnStartVideo.Enabled = false;

            videoSourcePlayer1.WaitForStop();
           GlobeVal.cam1.SignalToStop();
            GlobeVal.cam1.WaitForStop();

        }
        //获取Video相对路径？
        private String GetVideoPath()
        {
            String personImgPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)
                         + Path.DirectorySeparatorChar.ToString() + "MyVideo";
            if (!Directory.Exists(personImgPath))
            {
                Directory.CreateDirectory(personImgPath);
            }

            return personImgPath;
        }
        //获取Img相对路径？
        private String GetImagePath()
        {
            String personImgPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)
                         + Path.DirectorySeparatorChar.ToString() + "MyImages";
            if (!Directory.Exists(personImgPath))
            {
                Directory.CreateDirectory(personImgPath);
            }

            return personImgPath;
        }


        private void btnStartVideo_Click(object sender, EventArgs e)
        {
            //创建一个视频文件
            

            

           
            String picName =@GetVideoPath() + "\\" + DateTime.Now.ToString("yyyyMMdd HH-mm-ss");

           picName = picName + ".avi";
           
           

          
            
            is_record_video = true;
            videoWriter = new VideoFileWriter();

            if (GlobeVal.cam1.IsRunning)
            {
                
                videoWriter.Open(picName, GlobeVal.cam1.VideoCapabilities[0].FrameSize.Width, GlobeVal.cam1.VideoCapabilities[0].FrameSize.Height, fps, VideoCodec.MPEG4);
                
            }
            else
            {
                if (GlobeVal.mysys.language == 0)
                {
                    MessageBox.Show("没有视频源输入，无法录制视频。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Video can not be recorded without video source input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }

            tick_num = 0;
            timer1.Enabled = true;

            ifCam1 = true;
            btnStartVideo.Enabled = false;

           

            btnStopVideo.Enabled = true ;
            btnTakePic.Enabled = true;
        }

        private void comboBox_videoecode_SelectedIndexChanged(object sender, EventArgs e)
        {
           
          
        }

        private void Cam_NewFrame1(object obj, NewFrameEventArgs eventArgs)
        {
           // pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
           bm1 = (Bitmap)eventArgs.Frame.Clone();
         
            
            if (is_record_video)
            {
                videoWriter.WriteVideoFrame(bm1);
            }

        }

        private void btnStopVideo_Click(object sender, EventArgs e)
        {
            
            this.is_record_video = false;
            this.videoWriter.Close();
            timer1.Enabled = false;

          
            btnStartVideo.Enabled = true;

          

            btnStopVideo.Enabled = false;
            btnTakePic.Enabled = false ;

           
        }

        private void btnPauseVideo_Click(object sender, EventArgs e)
        {
          
        }

        private void btnTakePic_Click(object sender, EventArgs e)
        {
            if (ifCam1)
            {

                String filepath = GetImagePath() + "\\" + DateTime.Now.ToString("yyyyMMdd HH-mm-ss") + ".bmp";
                bm1.Save(filepath);
                
            }
            else
                MessageBox.Show("摄像头没有运行", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int width = 320;
            int height = 240;

            // create instance of video writer 
            VideoFileWriter writer = new VideoFileWriter();
            // create new video file 
            writer.Open(@"d:\test.avi", width, height, 25, VideoCodec.MPEG4);
            // create a bitmap to save into the video file 
            Bitmap image = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            // write 1000 video frames 
            for (int i = 0; i < 1000; i++)
            {
                image.SetPixel(i % width, i % height, Color.Red);
                writer.WriteVideoFrame(image);
            }
            writer.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tick_num++;
            int temp = tick_num;

            int sec = temp % 60;

            int min = temp / 60;
            if (min % 60 == 0)
            {
                hour = min / 60;
                min = 0;
            }
            else
            {
                min = min - hour * 60;
            }



            String tick = hour.ToString() + "：" + min.ToString() + "：" + sec.ToString();

            {
                this.labelTime.Text = tick;
            };
        }

        private void OpenVideoSource(IVideoSource source)
        {
            // set busy cursor
            this.Cursor = Cursors.WaitCursor;

            // stop current video source
            CloseCurrentVideoSource();

            // start new video source
            this.videoSourcePlayer1.VideoSource = source;
            this.videoSourcePlayer1.Start();

            // reset stop watch
            stopWatch = null;

            // start timer
            timer.Start();

            this.Cursor = Cursors.Default;
        }

        private void CloseCurrentVideoSource()
        {
            if (this.videoSourcePlayer1.VideoSource != null)
            {
                this.videoSourcePlayer1.SignalToStop();

                // wait ~ 3 seconds
                for (int i = 0; i < 30; i++)
                {
                    if (!this.videoSourcePlayer1.IsRunning)
                        break;
                    System.Threading.Thread.Sleep(100);
                }

                if (this.videoSourcePlayer1.IsRunning)
                {
                    this.videoSourcePlayer1.Stop();
                }

                this.videoSourcePlayer1.VideoSource = null;
            }
        }

        private void btnplay_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // create video source
                FileVideoSource fileSource = new FileVideoSource(openFileDialog.FileName);

                // open it
                OpenVideoSource(fileSource);
            }
        }
    }
}
