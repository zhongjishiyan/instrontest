using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using ClsStaticStation;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using AppleLabApplication;
using Microsoft.Win32;

namespace TabHeaderDemo
{

    public partial class FormMainLab : Form
    {

        public int l = 0;


        public MacroRecord myMacroRecord = new MacroRecord();
        int lastTimeRecorded = 0;

        MouseHook mouseHook = new MouseHook();
        KeyboardHook keyboardHook = new KeyboardHook();

        KeyboardHook keyboardReplayHook = new KeyboardHook();



        private Color topbackcolor = new Color();

        private  ClsStaticStation.ClsBaseControl myarm;

        private ClsStaticStation.CArm marm;
        private ClsStaticStation.CDOLI mdoli;
        private ClsStaticStation.CDsp mdsp;
        private User围压 User围压1;
        private UserControl操作面板 UserControl操作面板1;

        private UserControl扭转 UserControl扭转1;
        private UserControl轴向 UserControl轴向1;
        private List<JMeter> mlistmeter;
        private List<Button> mlistkey;

        public UserControlMain umain;

        private MainForm fdata;

        private int msel = 0;
        [STAThread]
        static void Main()
        {


            if (IsWindowsVistaOrNewer)
            {



                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Process instance = RunningInstance();
                if (instance == null)
                {
                    //1.1 没有实例在运行
                    //try
                    {
                        Application.Run(new FormMainLab());
                    }

                    // catch (Exception ex)
                    {
                        //throw;
                    }

                }
                else
                {
                    //1.2 已经有一个实例在运行
                    HandleRunningInstance(instance);
                }

            }
            else
            {
                MessageBox.Show("请在windows7以上版本运行");
            }

        }


        /// <summary>
        /// Gets a value indicating if the operating system is a Windows 2000 or a newer one.
        /// </summary>
        /// 
        private static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            //遍历与当前进程名称相同的进程列表 
            foreach (Process process in processes)
            {
                //如果实例已经存在则忽略当前进程 
                if (process.Id != current.Id)
                {
                    //保证要打开的进程同已经存在的进程来自同一文件路径
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        //返回已经存在的进程
                        return process;
                    }
                }
            }
            return null;
        }
        //3.已经有了就把它激活，并将其窗口放置最前端
        private static void HandleRunningInstance(Process instance)
        {
            ShowWindowAsync(instance.MainWindowHandle, 1); //调用api函数，正常显示窗口
            SetForegroundWindow(instance.MainWindowHandle); //将窗口放置最前端
        }
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(System.IntPtr hWnd, int cmdShow);
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(System.IntPtr hWnd);

        public static bool IsWindows2000OrNewer
        {
            get { return (Environment.OSVersion.Platform == PlatformID.Win32NT) && (Environment.OSVersion.Version.Major >= 5); }
        }

        /// <summary>
        /// Gets a value indicating if the operating system is a Windows XP or a newer one.
        /// </summary>
        public static bool IsWindowsXpOrNewer
        {
            get
            {
                return
                    (Environment.OSVersion.Platform == PlatformID.Win32NT) &&
                    (
                        (Environment.OSVersion.Version.Major >= 6) ||
                        (
                            (Environment.OSVersion.Version.Major == 5) &&
                            (Environment.OSVersion.Version.Minor >= 1)
                        )
                    );
            }
        }

        /// <summary>
        /// Gets a value indicating if the operating system is a Windows Vista or a newer one.
        /// </summary>
        public static bool IsWindowsVistaOrNewer
        {
            get { return (Environment.OSVersion.Platform == PlatformID.Win32NT) && (Environment.OSVersion.Version.Major >= 6); }
        }

        public FormMainLab()
        {
            InitializeComponent();

            GlobeVal.mysys = new ClassSys();

            //MessageBox.Show(System.Windows.Forms.Application.StartupPath.ToString());


            if (Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ") == false)
            {
                Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ");
            }
            if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\sys\\setup.ini") == true)
            {

                GlobeVal.mysys = GlobeVal.mysys.DeSerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\sys\\setup.ini");

            }


            m_Global.mycls = new ItemSignalStation(Convert.ToInt32(GlobeVal.mysys.machinekind));



            if (GlobeVal.mysys.controllerkind == 0)
            {
                marm = new CArm();
                myarm = marm;

            }

            if (GlobeVal.mysys.controllerkind == 1)
            {
                mdoli = new CDOLI();
                myarm = mdoli;
            }

            if (GlobeVal.mysys.controllerkind == 2)
            {

                mdsp = new CDsp();
                myarm = mdsp;
            }
            if (GlobeVal.mysys.controllerkind == 3)
            {
                myarm = new C电机();
            }



            fdata = new MainForm();

            topbackcolor = Color.WhiteSmoke;

            if (GlobeVal.mysys.demo == true)
            {
                tlprecord.Visible = true;
            }
            else
            {
                tlprecord.Visible = false;
            }

            mouseHook.MouseMove += new MouseEventHandler(mouseHook_MouseMove);
            mouseHook.MouseDown += new MouseEventHandler(mouseHook_MouseDown);
            mouseHook.MouseUp += new MouseEventHandler(mouseHook_MouseUp);

            keyboardHook.KeyDown += new KeyEventHandler(keyboardHook_KeyDown);
            keyboardHook.KeyUp += new KeyEventHandler(keyboardHook_KeyUp);
            keyboardReplayHook.KeyDown += new KeyEventHandler(KeyboardReplayHook_KeyDown);
            keyboardReplayHook.KeyUp += new KeyEventHandler(KeyboardReplayHook_KeyUp);

        }

        private void KeyboardReplayHook_KeyUp(object sender, KeyEventArgs e)
        {
            return;
        }

        private void KeyboardReplayHook_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Escape)
            {


                this.timerRecord.Enabled = false;
                playBackMacroButton.Enabled = true;
                this.keyboardReplayHook.Stop();
                this.Cursor = Cursors.Default;
                return;
            }
            return;
        }


        void mouseHook_MouseMove(object sender, MouseEventArgs e)
        {

            myMacroRecord.events.Add(
                new MacroEvent(
                    MacroEventType.MouseMove,
                    e,
                    Environment.TickCount - lastTimeRecorded, this.Width, this.Height
                ));


            lastTimeRecorded = Environment.TickCount;

        }

        void mouseHook_MouseDown(object sender, MouseEventArgs e)
        {

            myMacroRecord.events.Add(
                new MacroEvent(
                    MacroEventType.MouseDown,
                    e,
                    Environment.TickCount - lastTimeRecorded, this.Width, this.Height
                ));

            lastTimeRecorded = Environment.TickCount;

        }

        void mouseHook_MouseUp(object sender, MouseEventArgs e)
        {

            myMacroRecord.events.Add(
                new MacroEvent(
                    MacroEventType.MouseUp,
                    e,
                    Environment.TickCount - lastTimeRecorded, this.Width, this.Height
                ));

            lastTimeRecorded = Environment.TickCount;

        }

        void keyboardHook_KeyDown(object sender, KeyEventArgs e)
        {

            myMacroRecord.events.Add(
                new MacroEvent(
                    MacroEventType.KeyDown,
                    e,
                    Environment.TickCount - lastTimeRecorded, this.Width, this.Height
                ));

            lastTimeRecorded = Environment.TickCount;

        }

        void keyboardHook_KeyUp(object sender, KeyEventArgs e)
        {



            myMacroRecord.events.Add(
                new MacroEvent(
                    MacroEventType.KeyUp,
                    e,

                    Environment.TickCount - lastTimeRecorded, this.Width, this.Height
                ));

            lastTimeRecorded = Environment.TickCount;

        }

        public void delay(double m)
        {
            double t;
            t = Environment.TickCount;

            while (Environment.TickCount - t < m)
            {
                Application.DoEvents();
            }
        }

        public void DoMacro()
        {
            MacroEvent macroEvent = myMacroRecord.events[l] as MacroEvent;

            if (macroEvent.MacroEventType == MacroEventType.MouseMove)
            {
                this.timerRecord.Interval = macroEvent.TimeSinceLastEvent+1;
            }
            else

            {
                this.timerRecord.Interval = macroEvent.TimeSinceLastEvent + 1;
            }

            {


                switch (macroEvent.MacroEventType)
                {
                    case MacroEventType.MouseMove:
                        {

                            MouseEventArgs mouseArgs = (MouseEventArgs)macroEvent.EventArgs;

                            MouseSimulator.X = Convert.ToInt32(mouseArgs.X * this.Width / macroEvent.width);
                            MouseSimulator.Y = Convert.ToInt32(mouseArgs.Y * (this.Height) / (macroEvent.height));

                        }
                        break;
                    case MacroEventType.MouseDown:
                        {


                            MouseEventArgs mouseArgs = (MouseEventArgs)macroEvent.EventArgs;

                            MouseSimulator.MouseDown(mouseArgs.Button);

                            // shiwei 2017.10.20  演示时改变鼠标状态
                            this.Cursor = Cursors.AppStarting;

                        }
                        break;
                    case MacroEventType.MouseUp:
                        {

                            MouseEventArgs mouseArgs = (MouseEventArgs)macroEvent.EventArgs;

                            MouseSimulator.MouseUp(mouseArgs.Button);
                            // shiwei 2017.10.20  演示时改变鼠标状态
                            this.Cursor = Cursors.Hand;

                        }
                        break;
                    case MacroEventType.KeyDown:
                        {

                            KeyEventArgs keyArgs = (KeyEventArgs)macroEvent.EventArgs;

                            KeyboardSimulator.KeyDown(keyArgs.KeyCode);

                        }
                        break;
                    case MacroEventType.KeyUp:
                        {

                            KeyEventArgs keyArgs = (KeyEventArgs)macroEvent.EventArgs;

                            KeyboardSimulator.KeyUp(keyArgs.KeyCode);

                        }
                        break;
                    default:
                        break;
                }

            }
        }

        public System.Drawing.Bitmap backimage = new Bitmap(50, 50);

        private void drawFigure(PaintEventArgs e, PointF[] points)
        {
            GraphicsPath path = new GraphicsPath();


            Corners r = new Corners(points, 5);
            r.Execute(path);
            path.CloseFigure();
            Matrix matrix = new Matrix();
            matrix.Translate(3, 3);
            path.Transform(matrix);


            Bitmap map = new Bitmap(backimage);

            // Color c = (this.imageList1.Images[1] as Bitmap).GetPixel(this.imageList1.Images[1].Width - 5, this.imageList1.Images[1].Height / 2);


            // Color c = map.GetPixel(map.Width - 5, map.Height / 2);


            map.Dispose();
            drawPath(e, path, topbackcolor);

            path.Reset();
            r = new Corners(points, 5);
            r.Execute(path);
            path.CloseFigure();
            matrix = new Matrix();
            matrix.Translate(0, 0);
            path.Transform(matrix);
            map = new Bitmap(backimage);
            // c = map.GetPixel(map.Width / 2, map.Height / 2);



            map.Dispose();

            drawPath(e, path, topbackcolor);

            path.Dispose();
        }

        private static void drawPath(PaintEventArgs e, GraphicsPath path, Color color)
        {
            LinearGradientBrush brush = new LinearGradientBrush(path.GetBounds(),
                color, color, LinearGradientMode.Horizontal);
            e.Graphics.FillPath(brush, path);
            Pen pen = new Pen(color, 1);
            e.Graphics.DrawPath(pen, path);

            brush.Dispose();
            pen.Dispose();
        }
        //判断键值是否存在
        private bool IsRegeditKeyExit()
        {
            string[] subkeyNames;
            RegistryKey hkml = Registry.LocalMachine;
            RegistryKey software = hkml.OpenSubKey("SOFTWARE\\test");
            //RegistryKey software = hkml.OpenSubKey("SOFTWARE\\test", true);
            subkeyNames = software.GetValueNames();
            //取得该项下所有键值的名称的序列，并传递给预定的数组中
            foreach (string keyName in subkeyNames)
            {
                if (keyName == "test") //判断键值的名称
                {
                    hkml.Close();
                    return true;
                }
            }
            hkml.Close();
            return false;
        }
        //判断注册表是否存在
        private bool IsRegeditExit(string name)
        {

            bool _exit = false;

            try
            {

                string[] subkeyNames;

                RegistryKey hkml = Registry.LocalMachine;

                RegistryKey software = hkml.OpenSubKey("software", true);
                RegistryKey aimdir = software.OpenSubKey("AppleLabJ", true);               /////由此可判断Weather路径是否存在


                subkeyNames = aimdir.GetValueNames();

                foreach (string keyName in subkeyNames)
                {

                    if (keyName == name)
                    {

                        _exit = true;

                        return _exit;

                    }

                }

            }

            catch

            { }

            return _exit;

        }
        public void reg()
        {
            return;
            RegistryKey key = Registry.LocalMachine;
            RegistryKey software = key.CreateSubKey("software\\AppleLabJ");
            //在HKEY_LOCAL_MACHINE\SOFTWARE下新建名为test的注册表项。如果已经存在则不影响！

            software = key.OpenSubKey("software\\AppleLabJ", true);
            software.SetValue("AppleLabJ", "AppleLab 微机控制岩石试验机", RegistryValueKind.String);
            software.SetValue("InstallData", DateTime.Today.ToShortDateString(), RegistryValueKind.String);
            //software.SetValue("test", "0", RegistryValueKind.DWord);
            key.Close();
        }

        private void FormMainLab_Load(object sender, EventArgs e)
        {
            GlobeVal.MainStatusStrip = this.statusStrip1;

            GlobeVal.FormmainLab = this;

            this.Left = 0;
            this.Top = 0;

            jMeter1.BackColor = topbackcolor;
            jMeter2.BackColor = topbackcolor;
            jMeter3.BackColor = topbackcolor;
            jMeter4.BackColor = topbackcolor;


            mlistmeter = new List<JMeter>();
            mlistmeter.Add(jMeter1);

            mlistmeter.Add(jMeter2);
            mlistmeter.Add(jMeter3);
            mlistmeter.Add(jMeter4);
            mlistkey = new List<Button>();
            mlistkey.Add(btnkey1);
            mlistkey.Add(btnkey2);
            mlistkey.Add(btnkey3);
            mlistkey.Add(btnkey4);

            umain = new UserControlMain();
            umain.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(umain);

            backimage = new Bitmap(this.imageList1.Images[0], this.imageList1.Images[0].Size);

            this.Width = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width);
            this.Height = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height);

          //   this.Width = 1600;
            // this.Height = 900;
            tabControl1.ItemSize = new Size(1, 1);





            GlobeVal.myarm = myarm;


            if (GlobeVal.mysys.machinekind == 2)
            {
                User围压1 = new User围压();
                User围压1.Dock = DockStyle.Fill;
                UserControl操作面板1 = new UserControl操作面板();
                UserControl轴向1 = new UserControl轴向();
                UserControl操作面板1.Controls.Add(UserControl轴向1);
                UserControl轴向1.Dock = DockStyle.Fill;
                UserControl操作面板1.Dock = DockStyle.Fill;

                panel2.Controls.Add(UserControl操作面板1);
                tlpsel.Visible = true;
                cbochannel.Items.Clear();
                cbochannel.Items.Add("轴向");
                cbochannel.Items.Add("围压");
                cbochannel.SelectedIndex = 0;


            }

            if (GlobeVal.mysys.machinekind == 0)
            {
                tlpsel.Visible = false;
                UserControl操作面板1 = new UserControl操作面板();
                UserControl轴向1 = new UserControl轴向();
                UserControl操作面板1.Controls.Add(UserControl轴向1);
                UserControl轴向1.Dock = DockStyle.Fill;
                UserControl操作面板1.Dock = DockStyle.Fill;
                panel2.Controls.Add(UserControl操作面板1);
            }

            if (GlobeVal.mysys.machinekind == 1)
            {

                tlpsel.Visible = false;
                UserControl操作面板1 = new UserControl操作面板();
                UserControl扭转1 = new UserControl扭转();
                UserControl操作面板1.Controls.Add(UserControl扭转1);
                UserControl扭转1.Dock = DockStyle.Fill;
                UserControl操作面板1.Dock = DockStyle.Fill;
                panel2.Controls.Add(UserControl操作面板1);
            }
            if (GlobeVal.mysys.machinekind == 3)
            {

                tlpsel.Visible = false;
                UserControl操作面板1 = new UserControl操作面板();
                UserControl轴向1 = new UserControl轴向();
                UserControl操作面板1.Controls.Add(UserControl轴向1);
                UserControl轴向1.Dock = DockStyle.Fill;
                UserControl操作面板1.Dock = DockStyle.Fill;
                panel2.Controls.Add(UserControl操作面板1);
            }

            if (GlobeVal.mysys.demo == true)
            {
                GlobeVal.MainStatusStrip.Items["tslbldevice"].Text = "演示";
            }
            else
            {
                GlobeVal.MainStatusStrip.Items["tslbldevice"].Text = GlobeVal.mysys.ControllerName[GlobeVal.mysys.controllerkind];
            }

            /*
          
            if (IsRegeditExit("AppleLabJ") == true)
            {
                
            }
            else
            {
                reg();
            }

            string info = "";
            RegistryKey Key;
            Key = Registry.LocalMachine;
            RegistryKey software = Key.OpenSubKey("software\\AppleLabJ");
            // myreg = Key.OpenSubKey("software\\test",true);
            info = software.GetValue("AppleLabJ").ToString();

            GlobeVal.mysys.softwareconfig = info;

            info = software.GetValue("InstallData").ToString();

            GlobeVal.mysys.softwareinstalldate = info;



            software.Close();

    */
            if (GlobeVal.mysys.showshorttitle == false)
            {
                UTop.wordArt1.Caption = "AppleLab";

            }
            else
            {
                UTop.wordArt1.Caption = GlobeVal.mysys.shorttitle;
            }

            if (GlobeVal.mysys.showlogo == true)
            {
                if (System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\bmp\\" + GlobeVal.mysys.bmplogo))
                {
                    UTop.paneldefine.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\bmp\\" + GlobeVal.mysys.bmplogo);
                    UTop.panel6.Visible = false;
                    UTop.paneldefine.Visible = true;
                }
                else
                {
                    UTop.panel6.Visible = true;
                    UTop.paneldefine.Visible = false;

                }
            }
            else
            {
                UTop.panel6.Visible = true;
                UTop.paneldefine.Visible = false;

            }

            UTop.Refresh();

            timermain.Enabled = true;

            Frm.Form登录 f = new TabHeaderDemo.Frm.Form登录();
            f.result = false;

            f.ShowDialog();

            if (f.result == true)
            {

            }
            else
            {
                Close();
            }
            f.Close();

        }

        void m_toolbox_Load(object sender, EventArgs e)
        {

        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {


            GraphicsContainer containerState = e.Graphics.BeginContainer();



            e.Graphics.PageUnit = System.Drawing.GraphicsUnit.Pixel;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.Clear(Color.White);



            PointF[] roundedRectangle = new PointF[5];
            roundedRectangle[0].X = 6;
            roundedRectangle[0].Y = 0;
            roundedRectangle[1].X = panel4.Width - 2 - 3;
            roundedRectangle[1].Y = 0;
            roundedRectangle[2].X = panel4.Width - 2 - 3;
            roundedRectangle[2].Y = panel4.Height - 2 - 3;
            roundedRectangle[3].X = 1;
            roundedRectangle[3].Y = panel4.Height - 2 - 3;
            roundedRectangle[4].X = 1;
            roundedRectangle[4].Y = 6;
            drawFigure(e, roundedRectangle);



            e.Graphics.EndContainer(containerState);
        }

        private void btnkey2_MouseDown(object sender, MouseEventArgs e)
        {
            btnkey2.BackgroundImage = btnkeyimageList.Images[1];
        }

        private void btnkey2_Click(object sender, EventArgs e)
        {

        }

        private void btnkey2_MouseUp(object sender, MouseEventArgs e)
        {
            btnkey2.BackgroundImage = btnkeyimageList.Images[0];
        }

        private void btnkey1_MouseDown(object sender, MouseEventArgs e)
        {
            btnkey1.BackgroundImage = btnkeyimageList.Images[3];

        }

        private void btnkey1_MouseUp(object sender, MouseEventArgs e)
        {
            btnkey1.BackgroundImage = btnkeyimageList.Images[2];
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnkey3_MouseDown(object sender, MouseEventArgs e)
        {
            btnkey3.BackgroundImage = btnkeyimageList.Images[5];
        }

        private void btnkey3_MouseUp(object sender, MouseEventArgs e)
        {
            btnkey3.BackgroundImage = btnkeyimageList.Images[4];
        }

        private void btnkey4_MouseDown(object sender, MouseEventArgs e)
        {
            btnkey4.BackgroundImage = btnkeyimageList.Images[7];
        }

        private void btnkey4_MouseUp(object sender, MouseEventArgs e)
        {
            btnkey4.BackgroundImage = btnkeyimageList.Images[6];
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (GlobeVal.myarm.getrunstate() == 1)
            {
                GlobeVal.MainStatusStrip.Items["tslblstate"].Text = "状态：运行";

            }
            else
            {
                GlobeVal.MainStatusStrip.Items["tslblstate"].Text = "状态：停止";
            }


            if ((GlobeVal.myarm.getlimit(0) == true) || (GlobeVal.myarm.getlimit(0) == true))
            {
                GlobeVal.MainStatusStrip.Items["tslbllimit"].Text = "限位：保护";
                GlobeVal.MainStatusStrip.Items["tslbllimit"].BackColor = Color.Red;

            }
            else
            {
                GlobeVal.MainStatusStrip.Items["tslbllimit"].Text = "限位：正常";

                GlobeVal.MainStatusStrip.Items["tslbllimit"].BackColor = SystemColors.Control;
            }

            if (GlobeVal.myarm.getEmergencyStop() == true)
            {
                GlobeVal.MainStatusStrip.Items["tslblEmergencyStop"].Text = "急停：保护";
                GlobeVal.MainStatusStrip.Items["tslblEmergencyStop"].BackColor = Color.Red;
            }

            else
            {
                GlobeVal.MainStatusStrip.Items["tslblEmergencyStop"].Text = "急停：正常";
                GlobeVal.MainStatusStrip.Items["tslblEmergencyStop"].BackColor = SystemColors.Control;
            }
            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mmeter.Count; i++)
            {
                for (int j = 0; j < m_Global.mycls.allsignals.Count; j++)
                {
                    if (CComLibrary.GlobeVal.filesave.mmeter[i].cName == m_Global.mycls.allsignals[j].cName)
                    {
                        mlistmeter[i].lblvalue.Text = m_Global.mycls.allsignals[j].GetValueFromUnit(m_Global.mycls.allsignals[j].cvalue,
                            CComLibrary.GlobeVal.filesave.mmeter[i].cUnitsel);



                    }
                }
            }

        }
        public void InitKey()
        {
            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mkey.Count; i++)
            {
                mlistkey[i].Text = CComLibrary.GlobeVal.filesave.mkey[i].cName;

                mlistkey[i].Tag = false;
                mlistkey[i].Visible = true;
            }
            for (int i = CComLibrary.GlobeVal.filesave.mkey.Count; i < 4; i++)
            {
                mlistkey[i].Visible = false;
            }
        }
        public void InitMeter()
        {
            tlbmeter.ColumnCount = CComLibrary.GlobeVal.filesave.mmeter.Count;


            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mmeter.Count; i++)
            {

                mlistmeter[i].lblcaption.Text = CComLibrary.GlobeVal.filesave.mmeter[i].cName;
                mlistmeter[i].lblunit.Text = CComLibrary.GlobeVal.filesave.mmeter[i].cUnits[CComLibrary.GlobeVal.filesave.mmeter[i].cUnitsel];
                mlistmeter[i].Visible = true;
                mlistmeter[i].lblvalue.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(
                    CComLibrary.GlobeVal.filesave.mmeter[i].precise);
            }

            for (int i = CComLibrary.GlobeVal.filesave.mmeter.Count; i < 4; i++)
            {
                mlistmeter[i].Visible = false;
            }

            tlbmeter.Refresh();
        }

        private void splitContainer1_SplitterMoving(object sender, SplitterCancelEventArgs e)
        {
            if (msel == 1)
            {
                //e.Cancel = true;
            }
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {


        }

        private void splitContainer1_MouseDown(object sender, MouseEventArgs e)
        {
            msel = 1;
        }

        private void splitContainer1_MouseUp(object sender, MouseEventArgs e)
        {
            msel = 0;
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void FormMainLab_FormClosed(object sender, FormClosedEventArgs e)
        {
            myarm.Exit();
            myarm.CloseConnection();
            GlobeVal.mysys.SerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\sys\\setup.ini");
        }

        private void btntool_Click(object sender, EventArgs e)
        {
            int i;

           if (CComLibrary.GlobeVal.filesave==null)
            {
                CComLibrary.GlobeVal.filesave = new CComLibrary.FileStruct();
            }

            CComLibrary.FileStruct f = CComLibrary.GlobeVal.filesave;
            string temp = System.Environment.GetEnvironmentVariable("TEMP");
            DirectoryInfo info = new DirectoryInfo(temp);

            if (CComLibrary.GlobeVal.filesave == null)
            {

            }
            else
            {
                CComLibrary.GlobeVal.filesave.SerializeNow(info.FullName + "\\temp.tmp");

            }
            try
            {


                fdata.g_namelist.Clear();

                for (int j = 0; j < m_Global.mycls.originsignals.Count; j++)
                {
                    fdata.g_namelist.Add(m_Global.mycls.originsignals[j].cName);
                }
                fdata.g_datafilepath = System.Windows.Forms.Application.StartupPath + "\\AppleLabJ";

                fdata.gmptpath = System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + @"\method\";
                fdata.gmptprocedurepath = System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + @"\method\";
                fdata.tsbeditproject.Visible = false;
                fdata.gtestkind = CComLibrary.GlobeVal.filesave.methodkind;
                fdata.gmethodname = CComLibrary.GlobeVal.filesave.methodname;


                fdata.Text = "AppleLab-试验数据分析软件";
                fdata.Show();

                fdata.InitKind();
                fdata.WindowState = FormWindowState.Normal;
                fdata.ShowDialog();
                fdata.reset();

                CComLibrary.GlobeVal.InitUserCalcChannel();

            }
            catch (Exception ex)
            {

            }

            temp = System.Environment.GetEnvironmentVariable("TEMP");
            info = new DirectoryInfo(temp);
            if (f == null)
            { }
            else
            {
                CComLibrary.GlobeVal.filesave = f.DeSerializeNow(info.FullName + "\\temp.tmp");
            }

        }

        private void btnon_Click(object sender, EventArgs e)
        {





        }

        private void btnhand_Click(object sender, EventArgs e)
        {
            return;
            Frm.FormTest f = new Frm.FormTest();
            f.Show();
        }



        private void btnkey1_Click(object sender, EventArgs e)
        {


            GlobeVal.myarm.btnkey(sender as Button);

        }

        private void btnkey2_Click_1(object sender, EventArgs e)
        {
            GlobeVal.myarm.btnkey(sender as Button);
        }

        private void btnkey3_Click(object sender, EventArgs e)
        {
            GlobeVal.myarm.btnkey(sender as Button);
        }

        private void btnkey4_Click(object sender, EventArgs e)
        {
            GlobeVal.myarm.btnkey(sender as Button);
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void timermain_Tick(object sender, EventArgs e)
        {
            if ((GlobeVal.mysys.CurentUserIndex >= 0) && (GlobeVal.mysys.CurentUserIndex < GlobeVal.mysys.UserCount))
            {
            }
            else
            {
                GlobeVal.mysys.CurentUserIndex = 0;
            }


            tsluser.Text = "用户名:" + GlobeVal.mysys.UserName[GlobeVal.mysys.CurentUserIndex];

            if (GlobeVal.mysys.showapptitle == false)
            {
                tslblmachine.Text = GlobeVal.mysys.MachineName[GlobeVal.mysys.machinekind];
                this.Text = "AppleLab-" + GlobeVal.mysys.MachineName[GlobeVal.mysys.machinekind];
            }
            else
            {
                tslblmachine.Text = GlobeVal.mysys.apptitle;
                this.Text = GlobeVal.mysys.apptitle;
            }

            if (GlobeVal.mysys.showshorttitle == false)
            {
                UTop.wordArt1.Caption = "AppleLab";

            }
            else
            {
                UTop.wordArt1.Caption = GlobeVal.mysys.shorttitle;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void cbochannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbochannel.SelectedIndex == 0)
            {
                panel2.Controls.Clear();
                panel2.Controls.Add(UserControl操作面板1);
            }
            else
            {
                panel2.Controls.Clear();
                panel2.Controls.Add(User围压1);
            }
        }

        private void btnmethod_Click(object sender, EventArgs e)
        {
            int i;
            bool b = false;
            CComLibrary.FileStruct f = new CComLibrary.FileStruct();
            if (GlobeVal.mysys.AppUserLevel < 1)
            {
                MessageBox.Show("您的当前权限不够，请使用试验经理或管理员权限登录");
                return;
            }
            if (tabControl1.SelectedIndex == 0)
            {
                if (CComLibrary.GlobeVal.filesave == null)
                {
                    b = true;
                }
                else
                {
                    f = CComLibrary.GlobeVal.filesave;

                    string temp = System.Environment.GetEnvironmentVariable("TEMP");
                    DirectoryInfo info = new DirectoryInfo(temp);
                    CComLibrary.GlobeVal.filesave.SerializeNow(info.FullName + "\\temp.tmp");

                }
                try
                {


                    fdata.g_namelist.Clear();

                    for (int j = 0; j < m_Global.mycls.originsignals.Count; j++)
                    {
                        fdata.g_namelist.Add(m_Global.mycls.originsignals[j].cName);
                    }
                    fdata.g_datafilepath = System.Windows.Forms.Application.StartupPath + "\\AppleLabJ\\";

                    fdata.gmptpath = System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + @"\method\";
                    fdata.gmptprocedurepath = System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + @"\method\";
                    fdata.tsbeditproject.Visible = true;
                    fdata.Text = "AppleLab-试验标准编辑器";
                    fdata.ShowDialog();
                    fdata.reset();

                    CComLibrary.GlobeVal.InitUserCalcChannel();

                }
                catch (Exception ex)
                {

                }
                if (b == true)
                {
                    string temp = System.Environment.GetEnvironmentVariable("TEMP");
                    DirectoryInfo info = new DirectoryInfo(temp);
                    CComLibrary.GlobeVal.filesave = f.DeSerializeNow(info.FullName + "\\temp.tmp");
                }
            }
            else
            {
                MessageBox.Show("只能在主窗体中编辑");
            }
        }

        private void recordStartButton_Click(object sender, EventArgs e)
        {
            recordStartButton.Enabled = false;
            myMacroRecord.events.Clear();
            lastTimeRecorded = Environment.TickCount;

            keyboardHook.Start();
            mouseHook.Start();


        }

        private void recordStopButton_Click(object sender, EventArgs e)
        {

        }

        private void playBackMacroButton_Click(object sender, EventArgs e)
        {

            if (myMacroRecord.events.Count > 0)
            {

            }
            else
            {
                MessageBox.Show("请重新录制或读取过程");
                return;
            }
            playBackMacroButton.Enabled = false;
            l = 0;
            this.timerRecord.Enabled = true;
            this.keyboardReplayHook.Start();
            this.Cursor = Cursors.Hand;
        }

        private void timerRecord_Tick(object sender, EventArgs e)
        {
            DoMacro();
            l = l + 1;

            if (l > myMacroRecord.events.Count - 1)
            {
                this.timerRecord.Enabled = false;
                playBackMacroButton.Enabled = true;
                this.keyboardReplayHook.Stop();
                this.Cursor = Cursors.Default;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + @"\record\";
            string s1 = this.Width.ToString() + "_" + this.Height.ToString();


            openFileDialog1.InitialDirectory = s + s1;
            openFileDialog1.Filter = "(*.rec" + ")|*.rec";
            openFileDialog1.ShowDialog();

            myMacroRecord = myMacroRecord.DeSerializeNow(openFileDialog1.FileName);
        }

        private void recordStartButton_MouseEnter(object sender, EventArgs e)
        {

            this.toolTip1.ShowAlways = true;
            this.toolTip1.SetToolTip(sender as Button, (sender as Button).Tag as string);
        }

        private void playBackMacroButton_MouseEnter(object sender, EventArgs e)
        {
            this.toolTip1.ShowAlways = true;
            this.toolTip1.SetToolTip(sender as Button, (sender as Button).Tag as string);
        }

        private void recordStopButton_MouseEnter(object sender, EventArgs e)
        {
            this.toolTip1.ShowAlways = true;
            this.toolTip1.SetToolTip(sender as Button, (sender as Button).Tag as string);
        }

        private void recordStopButton_MouseDown(object sender, MouseEventArgs e)
        {


        }

        private void recordStopButton_MouseUp(object sender, MouseEventArgs e)
        {
            recordStartButton.Enabled = true;
            keyboardHook.Stop();
            mouseHook.Stop();
            myMacroRecord.events.RemoveAt(myMacroRecord.events.Count - 1);
            myMacroRecord.events.RemoveAt(myMacroRecord.events.Count - 1);
            string s = System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + @"\record\";

            string s1 = this.Width.ToString() + "_" + this.Height.ToString();

            if (System.IO.Directory.Exists(s + s1))
            {

            }
            else
            {
                System.IO.Directory.CreateDirectory(s + s1);
            }
            saveFileDialog1.InitialDirectory = s + s1;
            saveFileDialog1.Filter = "(*.rec" + ")|*.rec";
            saveFileDialog1.ShowDialog();


            myMacroRecord.SerializeNow(saveFileDialog1.FileName);
        }

        private void btnpos_Click(object sender, EventArgs e)
        {

            if (GlobeVal.mysys.machinekind == Convert.ToInt32(ClassSys._MachineName.Torsion))
            {
                Frm.FormTorsionTransducer f = new Frm.FormTorsionTransducer();
                f.ShowDialog();
            }

            if (GlobeVal.mysys.machinekind == Convert.ToInt32(ClassSys._MachineName.standard1))
            {

                Frm.FrmPosTransducer f = new Frm.FrmPosTransducer();
                f.ShowDialog();
            }


        }

        private void btnload_Click(object sender, EventArgs e)
        {
            if (GlobeVal.mysys.machinekind == Convert.ToInt32(ClassSys._MachineName.Torsion))
            {
                Frm.FormLoadTransducer f = new Frm.FormLoadTransducer();
                f.ShowDialog();
            }

            if (GlobeVal.mysys.machinekind == Convert.ToInt32(ClassSys._MachineName.standard1))
            {
                Frm.FormLoadTransducer f = new Frm.FormLoadTransducer();
                f.ShowDialog();
            }
        }

        private void btnext1_Click(object sender, EventArgs e)
        {
            if (GlobeVal.mysys.machinekind == Convert.ToInt32(ClassSys._MachineName.standard1))
            {
                Frm.FrmExtTransducer f = new Frm.FrmExtTransducer();
                f.ShowDialog();
            }
        }

        private void btnext2_Click(object sender, EventArgs e)
        {

        }
    }
}
