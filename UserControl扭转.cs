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

namespace TabHeaderDemo
{
    public partial class UserControl扭转 : UserControl
    {

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
        public UserControl扭转()
        {
            InitializeComponent();
            cboctrl.Items.Clear();
            cboctrl.Items.Add("扭角");
            cboctrl.Items.Add("扭矩");
            cboctrl.SelectedIndex = 0;
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

        private void switch1_ValueChanged(object sender, EventArgs e)
        {
            if (switchDriver.Value == true)
            {
                GlobeVal.myarm.DriveOn();

                timer1.Enabled = true; 
            }

            else
            {
                timer1.Enabled = false;
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
                lblunit.Text = "°/min";
                lblmunit.Text = "°";

            }
            else
            {
                lblunit.Text = "N.M/min";
                lblmunit.Text = "N.M";
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


                if (GlobeVal.myarm.connected == false)
                {
                    this.switchLink.Value = false;
                }
        
            }

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            GlobeVal.myarm.startcontrol();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GlobeVal.myarm.endcontrol();
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (GlobeVal.myarm.getlimit(0) == true)
            {
                pictureBox1.BackgroundImage = imageList1.Images[1]; 
            }
            else
            {
                pictureBox1.BackgroundImage = imageList1.Images[0];
            }
            if (GlobeVal.myarm.getlimit(1) == true)
            {
                pictureBox2.BackgroundImage = imageList1.Images[1];
            }
            else
            {
                pictureBox2.BackgroundImage = imageList1.Images[0];
            }

            label3.Text = GlobeVal.myarm.debug.ToString("X"); 
        }

		private void numericEdit1_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
		{
			CComLibrary.GlobeVal.filesave.simple_cmd.speed = numericEdit1.Value / 60;  
			


		}

		private void numericEdit2_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
		{
			CComLibrary.GlobeVal.filesave.simple_cmd.dest = numericEdit2.Value;  
		}

        private void btnzero_Click(object sender, EventArgs e)
        {
            GlobeVal.myarm.ReturnZero(0, numericEdit1.Value);
        }
    }
}
