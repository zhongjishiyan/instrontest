using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using CustomControls.OS;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.IO;
namespace TabHeaderDemo
{
    public partial class UserControl东光 : UserControl
    {
        private binfile mybinfile;
        private bool mrun = false;
        [Serializable]
        private class binfile
        {

           
            public double dg_freq = 0;
            public double dg_range = 0;
            public double dg_count = 0;
            public double dg_totalcount = 0;
            public double dg_ave = 0;
            public double dg_minute = 0;

            public binfile ()
            {
            }

            public void SerializeNow(string filename)
            {

                FileStream fileStream =
                new FileStream(filename, FileMode.Create);
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(fileStream, this);

                fileStream.Close();
            }

            public binfile DeSerializeNow(string filename)
            {
                binfile  c = new binfile();
                try
                {


                    using (FileStream fileStream =
                     new FileStream(filename,
                     FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        BinaryFormatter b = new BinaryFormatter();

                        c = b.Deserialize(fileStream) as binfile ;

                       
                        fileStream.Close();



                    }
                }
                catch (Exception e1)
                {
                    c = new binfile ();

                    MessageBox.Show(e1.Message, "读取文件");
                }
                finally
                {

                }
                return (c);
            }
        }
        private void drawFigure(PaintEventArgs e, PointF[] points)
        {
            GraphicsPath path = new GraphicsPath();


            Corners r = new Corners(points, 5);
            r.Execute(path);
            path.CloseFigure();
            Matrix matrix = new Matrix();
            matrix.Translate(3, 3);
            path.Transform(matrix);





            Color c = (this.imageList3.Images[0] as Bitmap).GetPixel((this.imageList3.Images[0] as Bitmap).Width - 5, (this.imageList3.Images[0] as Bitmap).Height / 2);



            drawPath(e, path, c);

            path.Reset();
            r = new Corners(points, 5);
            r.Execute(path);
            path.CloseFigure();
            matrix = new Matrix();
            matrix.Translate(0, 0);
            path.Transform(matrix);

            c = (this.imageList3.Images[0] as Bitmap).GetPixel(this.imageList3.Images[0].Width / 2, this.imageList3.Images[0].Height / 2);

            

            panel3.BackColor = c;
            drawPath(e, path, c);

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

       
        public UserControl东光()
        {
            mybinfile = new TabHeaderDemo.UserControl东光.binfile();
            InitializeComponent();
            cboctrl.Items.Clear();
            cboctrl.Items.Add("位移");
            cboctrl.Items.Add("负荷");
            cboctrl.SelectedIndex = 0;

            cbowave.Items.Clear();
            cbowave.Items.Add("正弦波");
            cbowave.Items.Add("三角波");
            cbowave.SelectedIndex = 0;
            //Application.StartupPath

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲



            this.tableLayoutPanel1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel1, true, null);
            this.tableLayoutPanel2.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel2, true, null);
            this.tableLayoutPanel8.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel8, true, null);

            this.tableLayoutPanel11.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel11, true, null);

            this.tableLayoutPanel9.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel9, true, null);
            
           
            
        }
        public void Init()
        {
            
            numfreq1.Value = mybinfile.dg_freq;
            numrange.Value = mybinfile.dg_range;
            numcount.Value = mybinfile.dg_count;
            numave.Value = mybinfile.dg_ave;
            numtotalcount.Value = mybinfile.dg_totalcount;
            numsaveinterval.Value =mybinfile.dg_minute;
        }
        private void switch1_ValueChanged(object sender, EventArgs e)
        {
            if (switchDriver.Value == true)
            {
                GlobeVal.myarm.DriveOn();
            }

            else
            {

                GlobeVal.myarm.DriveOff();
            }

        }

        private void switch1_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {

        }
        public void DelayS(double t)
        {
            double m = Environment.TickCount;

            while ((Environment.TickCount - m) / 1000 <= t)
            {
                Application.DoEvents();
            }


        }

        

        private void cboweiya_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboctrl.SelectedIndex == 0)
            {
                lblunit.Text = "mm/min";
                lblmunit.Text = "mm";

                numericEdit1.Range = new NationalInstruments.UI.Range(0, 10);
                numericEdit2.Range = new NationalInstruments.UI.Range(-25, 25);
                numave.Range = new NationalInstruments.UI.Range(-25, 25);

            }
            else
            {
                lblunit.Text = "kN/min";
                lblmunit.Text = "kN";

                numericEdit1.Range = new NationalInstruments.UI.Range(0, 10);
                numericEdit2.Range = new NationalInstruments.UI.Range(-1, 1);
                numave.Range = new NationalInstruments.UI.Range(-1, 1);
            }
        }

        private void btnup_Click(object sender, EventArgs e)
        {
            GlobeVal.myarm.CrossUp(cboctrl.SelectedIndex, numericEdit1.Value);
        }

        private void btndown_Click(object sender, EventArgs e)
        {
            GlobeVal.myarm.CrossDown(cboctrl.SelectedIndex, numericEdit1.Value);
        }

        private void btnstop_Click(object sender, EventArgs e)
        {
            GlobeVal.myarm.CrossStop(cboctrl.SelectedIndex);
         }


        
        private void btnstart_Click(object sender, EventArgs e)
        {

            GlobeVal.myarm.DestStart(cboctrl.SelectedIndex, numericEdit2.Value, numericEdit1.Value);
        }

        private void btnend_Click(object sender, EventArgs e)
        {

            GlobeVal.myarm.DestStop(cboctrl.SelectedIndex);
        }

        private void switch2_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {

        }

        private void switch1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UserControl轴向_Paint(object sender, PaintEventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }


            GraphicsContainer containerState = e.Graphics.BeginContainer();
            tableLayoutPanel1.BackColor = Color.Transparent;

            e.Graphics.PageUnit = System.Drawing.GraphicsUnit.Pixel;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.Clear(Color.White);



            PointF[] roundedRectangle = new PointF[5];
            roundedRectangle[0].X = 1;
            roundedRectangle[0].Y = 0;
            roundedRectangle[1].X = this.Width - 2 - 3;
            roundedRectangle[1].Y = 0;
            roundedRectangle[2].X = this.Width - 2 - 3;
            roundedRectangle[2].Y = this.Height - 2 - 3;
            roundedRectangle[3].X = 1;
            roundedRectangle[3].Y = this.Height - 2 - 3;
            roundedRectangle[4].X = 1;
            roundedRectangle[4].Y = 0;
            drawFigure(e, roundedRectangle);



            e.Graphics.EndContainer(containerState);
        }

        private void switch2_ValueChanged_1(object sender, EventArgs e)
        {
            if (this.switchLink.Value==true)
            {
                   if (CComLibrary.GlobeVal.filesave == null)
                  {
                       MessageBox.Show("请先设置试验方法");
                          return;
                    }
                  else
                  {
                
                    }

                   GlobeVal.myarm.mdemo = GlobeVal.mysys.demo;

           
                 GlobeVal.myarm.Init((int)this.Handle);
                
                
      
            GlobeVal.FormmainLab.timer1.Enabled =true;
            if (GlobeVal.myarm.mdemo == true)
            {
                GlobeVal.myarm.readdemo(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\demo\\拉伸1演示.txt");

            }

            GlobeVal.FormmainLab.InitMeter();
            GlobeVal.FormmainLab.InitKey();

            GlobeVal.myarm.connected = true;

                mybinfile = mybinfile.DeSerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\sys\\东光.参数");
                Init();
                timer1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (GlobeVal.myarm.dianyabaohu ==false)
            {
                lbLed3.LedColor = Color.LightGreen;

            }
            else
            {
                
                lbLed3.LedColor = Color.Red;

                if (mrun ==true)
                {
                    btntestend_Click(null, null);
                }
            }
        }

        private void btnteststart_Click(object sender, EventArgs e)
        {
            
          
            GlobeVal.myarm.fatigtest(cbowave.SelectedIndex,Convert.ToSingle( numfreq1.Value),Convert.ToSingle(numave.Value), Convert.ToSingle( numrange.Value), numcount.Value);
            GlobeVal.myarm.SetBaseCount(Convert.ToInt32( mybinfile.dg_totalcount));

            mrun = true;
        }

        private void btntestend_Click(object sender, EventArgs e)
        {
            if (GlobeVal.myarm.count > numtotalcount.Value)
            {
                numtotalcount.Value = GlobeVal.myarm.count;

                mybinfile.SerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\sys\\东光.参数");
            }
            GlobeVal.myarm.DestStop(0);

            mrun = false;

            GlobeVal.myarm.SetBaseCount(Convert.ToInt32(0));

          
        }

        private void numrange_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            mybinfile.dg_range = numrange.Value;
           
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UserControl东光_Load(object sender, EventArgs e)
        {
          
        }

        private void numfreq_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
           mybinfile.dg_freq = numfreq1.Value;
            


        }

        private void numcount_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            mybinfile.dg_count = numcount.Value;
        }

        private void numave_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            mybinfile.dg_ave = numave.Value;
        
        }

        private void numtotalcount_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            mybinfile.dg_totalcount = numtotalcount.Value;
       
        }

        private void numsaveinterval_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            mybinfile.dg_minute = numsaveinterval.Value;

           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
          
            Init();

        }

        private void numcount_ValueChanged(object sender, EventArgs e)
        {
            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            mybinfile = mybinfile.DeSerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\sys\\东光.参数");
            Init();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mybinfile.SerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\sys\\东光.参数");
        }
    }
}
