namespace TabHeaderDemo
{
    partial class FormMainLab
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainLab));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tlpsel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbochannel = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsluser = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblmachine = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslbldevice = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblkind = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblsample = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblmethod = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblreport = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolstatustest = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblEmergencyStop = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslbllimit = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblstate = new System.Windows.Forms.ToolStripStatusLabel();
            this.paneltop = new System.Windows.Forms.Panel();
            this.tlprecord = new System.Windows.Forms.TableLayoutPanel();
            this.recordStopButton = new System.Windows.Forms.Button();
            this.playBackMacroButton = new System.Windows.Forms.Button();
            this.recordStartButton = new System.Windows.Forms.Button();
            this.btnread = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnkey3 = new System.Windows.Forms.Button();
            this.btnkey2 = new System.Windows.Forms.Button();
            this.btnkey1 = new System.Windows.Forms.Button();
            this.btnkey4 = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnhand = new System.Windows.Forms.Button();
            this.btnext1 = new System.Windows.Forms.Button();
            this.btnpos = new System.Windows.Forms.Button();
            this.btnload = new System.Windows.Forms.Button();
            this.btnext2 = new System.Windows.Forms.Button();
            this.tlbmeterback = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tlbmeter = new System.Windows.Forms.TableLayoutPanel();
            this.jMeter1 = new TabHeaderDemo.JMeter();
            this.jMeter2 = new TabHeaderDemo.JMeter();
            this.jMeter3 = new TabHeaderDemo.JMeter();
            this.jMeter4 = new TabHeaderDemo.JMeter();
            this.btnmethod = new System.Windows.Forms.Button();
            this.btnon = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnkeyimageList = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timermain = new System.Windows.Forms.Timer(this.components);
            this.timerRecord = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.imageListState = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tlpsel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.paneltop.SuspendLayout();
            this.tlprecord.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tlbmeterback.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tlbmeter.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.toolTip1.SetToolTip(this.splitContainer1.Panel1, resources.GetString("splitContainer1.Panel1.ToolTip"));
            // 
            // splitContainer1.Panel2
            // 
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.toolTip1.SetToolTip(this.splitContainer1.Panel2, resources.GetString("splitContainer1.Panel2.ToolTip"));
            this.toolTip1.SetToolTip(this.splitContainer1, resources.GetString("splitContainer1.ToolTip"));
            this.splitContainer1.SplitterMoving += new System.Windows.Forms.SplitterCancelEventHandler(this.splitContainer1_SplitterMoving);
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            this.splitContainer1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.splitContainer1_MouseDown);
            this.splitContainer1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.splitContainer1_MouseUp);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Name = "panel1";
            this.toolTip1.SetToolTip(this.panel1, resources.GetString("panel1.ToolTip"));
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.toolTip1.SetToolTip(this.tableLayoutPanel1, resources.GetString("tableLayoutPanel1.ToolTip"));
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            this.toolTip1.SetToolTip(this.panel2, resources.GetString("panel2.ToolTip"));
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Controls.Add(this.tlpsel);
            this.panel3.Name = "panel3";
            this.toolTip1.SetToolTip(this.panel3, resources.GetString("panel3.ToolTip"));
            // 
            // tlpsel
            // 
            resources.ApplyResources(this.tlpsel, "tlpsel");
            this.tlpsel.Controls.Add(this.label1, 0, 0);
            this.tlpsel.Controls.Add(this.cbochannel, 1, 0);
            this.tlpsel.Name = "tlpsel";
            this.toolTip1.SetToolTip(this.tlpsel, resources.GetString("tlpsel.ToolTip"));
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.toolTip1.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // cbochannel
            // 
            resources.ApplyResources(this.cbochannel, "cbochannel");
            this.cbochannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbochannel.FormattingEnabled = true;
            this.cbochannel.Name = "cbochannel";
            this.toolTip1.SetToolTip(this.cbochannel, resources.GetString("cbochannel.ToolTip"));
            this.cbochannel.SelectedIndexChanged += new System.EventHandler(this.cbochannel_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsluser,
            this.tslblmachine,
            this.tslbldevice,
            this.tslblkind,
            this.tslblsample,
            this.tslblmethod,
            this.tslblreport,
            this.toolstatustest,
            this.tslblEmergencyStop,
            this.tslbllimit,
            this.tslblstate});
            this.statusStrip1.Name = "statusStrip1";
            this.toolTip1.SetToolTip(this.statusStrip1, resources.GetString("statusStrip1.ToolTip"));
            // 
            // tsluser
            // 
            resources.ApplyResources(this.tsluser, "tsluser");
            this.tsluser.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsluser.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tsluser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsluser.Name = "tsluser";
            // 
            // tslblmachine
            // 
            resources.ApplyResources(this.tslblmachine, "tslblmachine");
            this.tslblmachine.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tslblmachine.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tslblmachine.Name = "tslblmachine";
            // 
            // tslbldevice
            // 
            resources.ApplyResources(this.tslbldevice, "tslbldevice");
            this.tslbldevice.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tslbldevice.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tslbldevice.Name = "tslbldevice";
            // 
            // tslblkind
            // 
            resources.ApplyResources(this.tslblkind, "tslblkind");
            this.tslblkind.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tslblkind.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tslblkind.Name = "tslblkind";
            // 
            // tslblsample
            // 
            resources.ApplyResources(this.tslblsample, "tslblsample");
            this.tslblsample.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tslblsample.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tslblsample.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tslblsample.Name = "tslblsample";
            // 
            // tslblmethod
            // 
            resources.ApplyResources(this.tslblmethod, "tslblmethod");
            this.tslblmethod.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tslblmethod.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tslblmethod.Name = "tslblmethod";
            // 
            // tslblreport
            // 
            resources.ApplyResources(this.tslblreport, "tslblreport");
            this.tslblreport.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tslblreport.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tslblreport.Name = "tslblreport";
            // 
            // toolstatustest
            // 
            resources.ApplyResources(this.toolstatustest, "toolstatustest");
            this.toolstatustest.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolstatustest.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.toolstatustest.Name = "toolstatustest";
            // 
            // tslblEmergencyStop
            // 
            resources.ApplyResources(this.tslblEmergencyStop, "tslblEmergencyStop");
            this.tslblEmergencyStop.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tslblEmergencyStop.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tslblEmergencyStop.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.tslblEmergencyStop.Name = "tslblEmergencyStop";
            // 
            // tslbllimit
            // 
            resources.ApplyResources(this.tslbllimit, "tslbllimit");
            this.tslbllimit.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tslbllimit.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tslbllimit.Name = "tslbllimit";
            // 
            // tslblstate
            // 
            resources.ApplyResources(this.tslblstate, "tslblstate");
            this.tslblstate.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tslblstate.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tslblstate.Name = "tslblstate";
            // 
            // paneltop
            // 
            resources.ApplyResources(this.paneltop, "paneltop");
            this.paneltop.BackColor = System.Drawing.Color.Transparent;
            this.paneltop.Controls.Add(this.tlprecord);
            this.paneltop.Controls.Add(this.tableLayoutPanel4);
            this.paneltop.Controls.Add(this.tableLayoutPanel3);
            this.paneltop.Controls.Add(this.tlbmeterback);
            this.paneltop.Controls.Add(this.btnmethod);
            this.paneltop.Controls.Add(this.btnon);
            this.paneltop.Name = "paneltop";
            this.toolTip1.SetToolTip(this.paneltop, resources.GetString("paneltop.ToolTip"));
            this.paneltop.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // tlprecord
            // 
            resources.ApplyResources(this.tlprecord, "tlprecord");
            this.tlprecord.Controls.Add(this.recordStopButton, 0, 0);
            this.tlprecord.Controls.Add(this.playBackMacroButton, 0, 0);
            this.tlprecord.Controls.Add(this.recordStartButton, 0, 0);
            this.tlprecord.Controls.Add(this.btnread, 3, 0);
            this.tlprecord.Name = "tlprecord";
            this.toolTip1.SetToolTip(this.tlprecord, resources.GetString("tlprecord.ToolTip"));
            // 
            // recordStopButton
            // 
            resources.ApplyResources(this.recordStopButton, "recordStopButton");
            this.recordStopButton.BackColor = System.Drawing.Color.Transparent;
            this.recordStopButton.FlatAppearance.BorderSize = 0;
            this.recordStopButton.Name = "recordStopButton";
            this.toolTip1.SetToolTip(this.recordStopButton, resources.GetString("recordStopButton.ToolTip"));
            this.recordStopButton.UseVisualStyleBackColor = false;
            this.recordStopButton.Click += new System.EventHandler(this.recordStopButton_Click);
            this.recordStopButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.recordStopButton_MouseDown);
            this.recordStopButton.MouseEnter += new System.EventHandler(this.recordStopButton_MouseEnter);
            this.recordStopButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.recordStopButton_MouseUp);
            // 
            // playBackMacroButton
            // 
            resources.ApplyResources(this.playBackMacroButton, "playBackMacroButton");
            this.playBackMacroButton.BackColor = System.Drawing.Color.Transparent;
            this.playBackMacroButton.FlatAppearance.BorderSize = 0;
            this.playBackMacroButton.Name = "playBackMacroButton";
            this.toolTip1.SetToolTip(this.playBackMacroButton, resources.GetString("playBackMacroButton.ToolTip"));
            this.playBackMacroButton.UseVisualStyleBackColor = false;
            this.playBackMacroButton.Click += new System.EventHandler(this.playBackMacroButton_Click);
            this.playBackMacroButton.MouseEnter += new System.EventHandler(this.playBackMacroButton_MouseEnter);
            // 
            // recordStartButton
            // 
            resources.ApplyResources(this.recordStartButton, "recordStartButton");
            this.recordStartButton.BackColor = System.Drawing.Color.Transparent;
            this.recordStartButton.FlatAppearance.BorderSize = 0;
            this.recordStartButton.Name = "recordStartButton";
            this.toolTip1.SetToolTip(this.recordStartButton, resources.GetString("recordStartButton.ToolTip"));
            this.recordStartButton.UseVisualStyleBackColor = false;
            this.recordStartButton.Click += new System.EventHandler(this.recordStartButton_Click);
            this.recordStartButton.MouseEnter += new System.EventHandler(this.recordStartButton_MouseEnter);
            // 
            // btnread
            // 
            resources.ApplyResources(this.btnread, "btnread");
            this.btnread.Name = "btnread";
            this.toolTip1.SetToolTip(this.btnread, resources.GetString("btnread.ToolTip"));
            this.btnread.UseVisualStyleBackColor = true;
            this.btnread.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel4
            // 
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Controls.Add(this.btnkey3, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnkey2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnkey1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnkey4, 3, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.toolTip1.SetToolTip(this.tableLayoutPanel4, resources.GetString("tableLayoutPanel4.ToolTip"));
            this.tableLayoutPanel4.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel4_Paint);
            // 
            // btnkey3
            // 
            resources.ApplyResources(this.btnkey3, "btnkey3");
            this.btnkey3.BackColor = System.Drawing.Color.Transparent;
            this.btnkey3.FlatAppearance.BorderSize = 0;
            this.btnkey3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnkey3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnkey3.Name = "btnkey3";
            this.toolTip1.SetToolTip(this.btnkey3, resources.GetString("btnkey3.ToolTip"));
            this.btnkey3.UseVisualStyleBackColor = false;
            this.btnkey3.Click += new System.EventHandler(this.btnkey3_Click);
            this.btnkey3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnkey3_MouseDown);
            this.btnkey3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnkey3_MouseUp);
            // 
            // btnkey2
            // 
            resources.ApplyResources(this.btnkey2, "btnkey2");
            this.btnkey2.BackColor = System.Drawing.Color.Transparent;
            this.btnkey2.FlatAppearance.BorderSize = 0;
            this.btnkey2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnkey2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnkey2.Name = "btnkey2";
            this.toolTip1.SetToolTip(this.btnkey2, resources.GetString("btnkey2.ToolTip"));
            this.btnkey2.UseVisualStyleBackColor = false;
            this.btnkey2.Click += new System.EventHandler(this.btnkey2_Click_1);
            this.btnkey2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnkey2_MouseDown);
            this.btnkey2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnkey2_MouseUp);
            // 
            // btnkey1
            // 
            resources.ApplyResources(this.btnkey1, "btnkey1");
            this.btnkey1.BackColor = System.Drawing.Color.Transparent;
            this.btnkey1.FlatAppearance.BorderSize = 0;
            this.btnkey1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnkey1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnkey1.Name = "btnkey1";
            this.toolTip1.SetToolTip(this.btnkey1, resources.GetString("btnkey1.ToolTip"));
            this.btnkey1.UseVisualStyleBackColor = false;
            this.btnkey1.Click += new System.EventHandler(this.btnkey1_Click);
            this.btnkey1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnkey1_MouseDown);
            this.btnkey1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnkey1_MouseUp);
            // 
            // btnkey4
            // 
            resources.ApplyResources(this.btnkey4, "btnkey4");
            this.btnkey4.BackColor = System.Drawing.Color.Transparent;
            this.btnkey4.FlatAppearance.BorderSize = 0;
            this.btnkey4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnkey4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnkey4.Name = "btnkey4";
            this.toolTip1.SetToolTip(this.btnkey4, resources.GetString("btnkey4.ToolTip"));
            this.btnkey4.UseVisualStyleBackColor = false;
            this.btnkey4.Click += new System.EventHandler(this.btnkey4_Click);
            this.btnkey4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnkey4_MouseDown);
            this.btnkey4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnkey4_MouseUp);
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.btnhand, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnext1, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnpos, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnload, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnext2, 3, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.toolTip1.SetToolTip(this.tableLayoutPanel3, resources.GetString("tableLayoutPanel3.ToolTip"));
            // 
            // btnhand
            // 
            resources.ApplyResources(this.btnhand, "btnhand");
            this.btnhand.BackColor = System.Drawing.Color.Transparent;
            this.btnhand.FlatAppearance.BorderSize = 0;
            this.btnhand.Name = "btnhand";
            this.toolTip1.SetToolTip(this.btnhand, resources.GetString("btnhand.ToolTip"));
            this.btnhand.UseVisualStyleBackColor = false;
            this.btnhand.Click += new System.EventHandler(this.btnhand_Click);
            // 
            // btnext1
            // 
            resources.ApplyResources(this.btnext1, "btnext1");
            this.btnext1.BackColor = System.Drawing.Color.Transparent;
            this.btnext1.FlatAppearance.BorderSize = 0;
            this.btnext1.Name = "btnext1";
            this.toolTip1.SetToolTip(this.btnext1, resources.GetString("btnext1.ToolTip"));
            this.btnext1.UseVisualStyleBackColor = false;
            this.btnext1.Click += new System.EventHandler(this.btnext1_Click);
            // 
            // btnpos
            // 
            resources.ApplyResources(this.btnpos, "btnpos");
            this.btnpos.BackColor = System.Drawing.Color.Transparent;
            this.btnpos.FlatAppearance.BorderSize = 0;
            this.btnpos.Name = "btnpos";
            this.toolTip1.SetToolTip(this.btnpos, resources.GetString("btnpos.ToolTip"));
            this.btnpos.UseVisualStyleBackColor = false;
            this.btnpos.Click += new System.EventHandler(this.btnpos_Click);
            // 
            // btnload
            // 
            resources.ApplyResources(this.btnload, "btnload");
            this.btnload.BackColor = System.Drawing.Color.Transparent;
            this.btnload.FlatAppearance.BorderSize = 0;
            this.btnload.Name = "btnload";
            this.toolTip1.SetToolTip(this.btnload, resources.GetString("btnload.ToolTip"));
            this.btnload.UseVisualStyleBackColor = false;
            this.btnload.Click += new System.EventHandler(this.btnload_Click);
            // 
            // btnext2
            // 
            resources.ApplyResources(this.btnext2, "btnext2");
            this.btnext2.BackColor = System.Drawing.Color.Transparent;
            this.btnext2.FlatAppearance.BorderSize = 0;
            this.btnext2.Name = "btnext2";
            this.toolTip1.SetToolTip(this.btnext2, resources.GetString("btnext2.ToolTip"));
            this.btnext2.UseVisualStyleBackColor = false;
            this.btnext2.Click += new System.EventHandler(this.btnext2_Click);
            // 
            // tlbmeterback
            // 
            resources.ApplyResources(this.tlbmeterback, "tlbmeterback");
            this.tlbmeterback.BackColor = System.Drawing.Color.Transparent;
            this.tlbmeterback.Controls.Add(this.pictureBox2, 0, 0);
            this.tlbmeterback.Controls.Add(this.tlbmeter, 0, 0);
            this.tlbmeterback.Name = "tlbmeterback";
            this.toolTip1.SetToolTip(this.tlbmeterback, resources.GetString("tlbmeterback.ToolTip"));
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox2, resources.GetString("pictureBox2.ToolTip"));
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // tlbmeter
            // 
            resources.ApplyResources(this.tlbmeter, "tlbmeter");
            this.tlbmeter.BackColor = System.Drawing.Color.Transparent;
            this.tlbmeter.Controls.Add(this.jMeter1, 0, 0);
            this.tlbmeter.Controls.Add(this.jMeter2, 1, 0);
            this.tlbmeter.Controls.Add(this.jMeter3, 2, 0);
            this.tlbmeter.Controls.Add(this.jMeter4, 3, 0);
            this.tlbmeter.Name = "tlbmeter";
            this.toolTip1.SetToolTip(this.tlbmeter, resources.GetString("tlbmeter.ToolTip"));
            // 
            // jMeter1
            // 
            resources.ApplyResources(this.jMeter1, "jMeter1");
            this.jMeter1.BackColor = System.Drawing.Color.Transparent;
            this.jMeter1.Name = "jMeter1";
            this.toolTip1.SetToolTip(this.jMeter1, resources.GetString("jMeter1.ToolTip"));
            // 
            // jMeter2
            // 
            resources.ApplyResources(this.jMeter2, "jMeter2");
            this.jMeter2.BackColor = System.Drawing.Color.Transparent;
            this.jMeter2.Name = "jMeter2";
            this.toolTip1.SetToolTip(this.jMeter2, resources.GetString("jMeter2.ToolTip"));
            // 
            // jMeter3
            // 
            resources.ApplyResources(this.jMeter3, "jMeter3");
            this.jMeter3.BackColor = System.Drawing.Color.Transparent;
            this.jMeter3.Name = "jMeter3";
            this.toolTip1.SetToolTip(this.jMeter3, resources.GetString("jMeter3.ToolTip"));
            // 
            // jMeter4
            // 
            resources.ApplyResources(this.jMeter4, "jMeter4");
            this.jMeter4.BackColor = System.Drawing.Color.Transparent;
            this.jMeter4.Name = "jMeter4";
            this.toolTip1.SetToolTip(this.jMeter4, resources.GetString("jMeter4.ToolTip"));
            // 
            // btnmethod
            // 
            resources.ApplyResources(this.btnmethod, "btnmethod");
            this.btnmethod.BackColor = System.Drawing.Color.Transparent;
            this.btnmethod.FlatAppearance.BorderSize = 0;
            this.btnmethod.ForeColor = System.Drawing.Color.White;
            this.btnmethod.Name = "btnmethod";
            this.toolTip1.SetToolTip(this.btnmethod, resources.GetString("btnmethod.ToolTip"));
            this.btnmethod.UseVisualStyleBackColor = false;
            this.btnmethod.Click += new System.EventHandler(this.btnmethod_Click);
            // 
            // btnon
            // 
            resources.ApplyResources(this.btnon, "btnon");
            this.btnon.BackColor = System.Drawing.Color.Transparent;
            this.btnon.FlatAppearance.BorderSize = 0;
            this.btnon.Name = "btnon";
            this.btnon.Tag = "0";
            this.toolTip1.SetToolTip(this.btnon, resources.GetString("btnon.ToolTip"));
            this.btnon.UseVisualStyleBackColor = false;
            this.btnon.Click += new System.EventHandler(this.btnon_Click);
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.toolTip1.SetToolTip(this.tabControl1, resources.GetString("tabControl1.ToolTip"));
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.panel5);
            this.tabPage1.Name = "tabPage1";
            this.toolTip1.SetToolTip(this.tabPage1, resources.GetString("tabPage1.ToolTip"));
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Name = "panel5";
            this.toolTip1.SetToolTip(this.panel5, resources.GetString("panel5.ToolTip"));
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Name = "tabPage2";
            this.toolTip1.SetToolTip(this.tabPage2, resources.GetString("tabPage2.ToolTip"));
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1.bmp");
            this.imageList1.Images.SetKeyName(1, "b.ico");
            // 
            // btnkeyimageList
            // 
            this.btnkeyimageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("btnkeyimageList.ImageStream")));
            this.btnkeyimageList.TransparentColor = System.Drawing.Color.Transparent;
            this.btnkeyimageList.Images.SetKeyName(0, "29.ico");
            this.btnkeyimageList.Images.SetKeyName(1, "29press.ico");
            this.btnkeyimageList.Images.SetKeyName(2, "27.ico");
            this.btnkeyimageList.Images.SetKeyName(3, "27press.ico");
            this.btnkeyimageList.Images.SetKeyName(4, "3key.ico");
            this.btnkeyimageList.Images.SetKeyName(5, "3key_press.ico");
            this.btnkeyimageList.Images.SetKeyName(6, "4key.ico");
            this.btnkeyimageList.Images.SetKeyName(7, "4key_press.ico");
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timermain
            // 
            this.timermain.Tick += new System.EventHandler(this.timermain_Tick);
            // 
            // timerRecord
            // 
            this.timerRecord.Tick += new System.EventHandler(this.timerRecord_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // saveFileDialog1
            // 
            resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "24.bmp");
            this.imageList2.Images.SetKeyName(1, "24红.bmp");
            // 
            // imageListState
            // 
            this.imageListState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListState.ImageStream")));
            this.imageListState.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListState.Images.SetKeyName(0, "1.bmp");
            this.imageListState.Images.SetKeyName(1, "3.bmp");
            // 
            // FormMainLab
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.paneltop);
            this.Controls.Add(this.statusStrip1);
            this.MaximizeBox = false;
            this.Name = "FormMainLab";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMainLab_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMainLab_FormClosed);
            this.Load += new System.EventHandler(this.FormMainLab_Load);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tlpsel.ResumeLayout(false);
            this.tlpsel.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.paneltop.ResumeLayout(false);
            this.tlprecord.ResumeLayout(false);
            this.tlprecord.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tlbmeterback.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tlbmeter.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsluser;
        private System.Windows.Forms.Panel paneltop;
        private System.Windows.Forms.Button btnmethod;
        private System.Windows.Forms.Button btnon;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tlbmeterback;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TableLayoutPanel tlbmeter;
        private JMeter jMeter1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripStatusLabel tslbldevice;
        private System.Windows.Forms.ToolStripStatusLabel tslblkind;
        private System.Windows.Forms.ToolStripStatusLabel tslblsample;
        private System.Windows.Forms.ToolStripStatusLabel tslblmethod;
        private System.Windows.Forms.ToolStripStatusLabel tslblreport;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnpos;
        private System.Windows.Forms.Button btnhand;
        private System.Windows.Forms.Button btnload;
        private System.Windows.Forms.Button btnext2;
        private System.Windows.Forms.Button btnext1;
        private System.Windows.Forms.ImageList btnkeyimageList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private JMeter jMeter2;
        private JMeter jMeter3;
        private JMeter jMeter4;
        public System.Windows.Forms.Button btnkey1;
        public System.Windows.Forms.Button btnkey2;
        public System.Windows.Forms.Button btnkey3;
        public System.Windows.Forms.Button btnkey4;
        private System.Windows.Forms.ToolStripStatusLabel tslblEmergencyStop;
        private System.Windows.Forms.ToolStripStatusLabel tslbllimit;
        private System.Windows.Forms.ToolStripStatusLabel toolstatustest;
        private System.Windows.Forms.Timer timermain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tlpsel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbochannel;
        public System.Windows.Forms.ToolStripStatusLabel tslblmachine;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tlprecord;
        private System.Windows.Forms.Timer timerRecord;
        private System.Windows.Forms.Button recordStopButton;
        private System.Windows.Forms.Button playBackMacroButton;
        private System.Windows.Forms.Button recordStartButton;
        private System.Windows.Forms.Button btnread;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripStatusLabel tslblstate;
        public System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ImageList imageList2;
        public System.Windows.Forms.ImageList imageListState;
    }
}