namespace TabHeaderDemo
{
    partial class UserControlCamera1
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlCamera1));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
            this.camera1FpsLabel = new System.Windows.Forms.Label();
            this.comboBox_camera = new System.Windows.Forms.ComboBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnStartVideo = new System.Windows.Forms.Button();
            this.labelTime = new System.Windows.Forms.Label();
            this.btnStopVideo = new System.Windows.Forms.Button();
            this.btnTakePic = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnplay = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.videoSourcePlayer1);
            this.groupBox1.Controls.Add(this.camera1FpsLabel);
            this.groupBox1.Controls.Add(this.comboBox_camera);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // videoSourcePlayer1
            // 
            resources.ApplyResources(this.videoSourcePlayer1, "videoSourcePlayer1");
            this.videoSourcePlayer1.BackColor = System.Drawing.Color.White;
            this.videoSourcePlayer1.ForeColor = System.Drawing.Color.White;
            this.videoSourcePlayer1.Name = "videoSourcePlayer1";
            this.videoSourcePlayer1.VideoSource = null;
            // 
            // camera1FpsLabel
            // 
            resources.ApplyResources(this.camera1FpsLabel, "camera1FpsLabel");
            this.camera1FpsLabel.Name = "camera1FpsLabel";
            // 
            // comboBox_camera
            // 
            resources.ApplyResources(this.comboBox_camera, "comboBox_camera");
            this.comboBox_camera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_camera.FormattingEnabled = true;
            this.comboBox_camera.Name = "comboBox_camera";
            // 
            // stopButton
            // 
            resources.ApplyResources(this.stopButton, "stopButton");
            this.stopButton.Name = "stopButton";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // startButton
            // 
            resources.ApplyResources(this.startButton, "startButton");
            this.startButton.Name = "startButton";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btnStartVideo
            // 
            resources.ApplyResources(this.btnStartVideo, "btnStartVideo");
            this.btnStartVideo.Name = "btnStartVideo";
            this.btnStartVideo.UseVisualStyleBackColor = true;
            this.btnStartVideo.Click += new System.EventHandler(this.btnStartVideo_Click);
            // 
            // labelTime
            // 
            resources.ApplyResources(this.labelTime, "labelTime");
            this.labelTime.Name = "labelTime";
            // 
            // btnStopVideo
            // 
            resources.ApplyResources(this.btnStopVideo, "btnStopVideo");
            this.btnStopVideo.Name = "btnStopVideo";
            this.btnStopVideo.UseVisualStyleBackColor = true;
            this.btnStopVideo.Click += new System.EventHandler(this.btnStopVideo_Click);
            // 
            // btnTakePic
            // 
            resources.ApplyResources(this.btnTakePic, "btnTakePic");
            this.btnTakePic.Name = "btnTakePic";
            this.btnTakePic.UseVisualStyleBackColor = true;
            this.btnTakePic.Click += new System.EventHandler(this.btnTakePic_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.btnplay);
            this.groupBox2.Controls.Add(this.btnTakePic);
            this.groupBox2.Controls.Add(this.stopButton);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.startButton);
            this.groupBox2.Controls.Add(this.btnStopVideo);
            this.groupBox2.Controls.Add(this.labelTime);
            this.groupBox2.Controls.Add(this.btnStartVideo);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // btnplay
            // 
            resources.ApplyResources(this.btnplay, "btnplay");
            this.btnplay.Name = "btnplay";
            this.btnplay.UseVisualStyleBackColor = true;
            this.btnplay.Click += new System.EventHandler(this.btnplay_Click);
            // 
            // openFileDialog
            // 
            resources.ApplyResources(this.openFileDialog, "openFileDialog");
            // 
            // UserControlCamera1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "UserControlCamera1";
            this.Load += new System.EventHandler(this.UserControlCamera_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label camera1FpsLabel;
        private System.Windows.Forms.ComboBox comboBox_camera;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnStartVideo;
        private System.Windows.Forms.Button btnStopVideo;
        private System.Windows.Forms.Button btnTakePic;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label labelTime;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnplay;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}
