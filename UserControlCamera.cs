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
namespace TabHeaderDemo
{
    public partial class UserControlCamera : UserControl
    {
        FilterInfoCollection videoDevices;
        // stop watch for measuring fps
        private Stopwatch stopWatch = null;
       


       

        public void Init()
        {
            return;
        }
        public UserControlCamera()
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
            videoSource1.DesiredFrameRate = 10;

            videoSourcePlayer1.VideoSource = videoSource1;
            videoSourcePlayer1.Start();

            // create second video source
            

            // reset stop watch
            stopWatch = null;
            // start timer
            timer.Start();
        }

        // Stop cameras
        private void StopCameras()
        {
            timer.Stop();

            videoSourcePlayer1.SignalToStop();
         

            videoSourcePlayer1.WaitForStop();
            
        }

        private void UserControlCamera_Load(object sender, EventArgs e)
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
            StartCameras();

            startButton.Enabled = false;
            stopButton.Enabled = true;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            StopCameras();

            startButton.Enabled = true;
            stopButton.Enabled = false;

            camera1FpsLabel.Text = string.Empty;
            
        }
        //获取Video相对路径？
       


        private void btnStartVideo_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox_videoecode_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void Cam_NewFrame1(object obj, NewFrameEventArgs eventArgs)
        {
          

        }

        private void btnStopVideo_Click(object sender, EventArgs e)
        {
            
          
           
        }

        private void btnPauseVideo_Click(object sender, EventArgs e)
        {
            
        }

        private void btnTakePic_Click(object sender, EventArgs e)
        {
           
        }
    
    }
}
