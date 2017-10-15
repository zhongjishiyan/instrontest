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
    public partial class User围压 : UserControl
    {
        public User围压()
        {
            InitializeComponent();



            this.tableLayoutPanel1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel1, true, null);
            this.tableLayoutPanel2.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel2, true, null);

            return;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲

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
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void User围压_Load(object sender, EventArgs e)
        {

            Color  c = (this.imageList3.Images[0] as Bitmap).GetPixel(this.imageList3.Images[0].Width / 2, this.imageList3.Images[0].Height / 2);

            jMeter1.BackColor = c;
            jMeter2.BackColor = c;
            jMeter1.Refresh();
            jMeter2.Refresh();
            
            jMeter1.lblcaption.Text  = "围压压力";
            jMeter1.lblunit.Text  = "MPa";
            jMeter2.lblcaption.Text = "围压位移";
            jMeter2.lblunit.Text = "mm";
           
           
            timer1.Enabled = true;

            cboweiya.Items.Clear();
            cboweiya.Items.Add("围压位移");
            cboweiya.Items.Add("围压压力");
            cboweiya.SelectedIndex = 0;
           
          

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            

            double t;
            for (int j = 0; j < ClsStaticStation.m_Global.mycls.allsignals.Count; j++)
            {
                if (jMeter1.lblcaption.Text  == ClsStaticStation.m_Global.mycls.allsignals[j].cName)
                {
                    jMeter1.lblvalue.Value  = Convert.ToDouble( ClsStaticStation.m_Global.mycls.allsignals[j].GetValueFromUnit(
                        ClsStaticStation.m_Global.mycls.allsignals[j].cvalue,
                       0));



                }
                if (jMeter2.lblcaption.Text == ClsStaticStation.m_Global.mycls.allsignals[j].cName)
                {
                    jMeter2.lblvalue.Value = Convert.ToDouble( ClsStaticStation.m_Global.mycls.allsignals[j].GetValueFromUnit(
                        ClsStaticStation.m_Global.mycls.allsignals[j].cvalue,
                       0));



                }

                
            }
        }

        private void btnenable_Click(object sender, EventArgs e)
        {
          
        }

        private void btnfa_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void btnup_Click(object sender, EventArgs e)
        {
            


            ClsStaticStation.a9500.SIMPLELINE s1;
            s1 = new ClsStaticStation.a9500.SIMPLELINE();


            if (cboweiya.SelectedIndex == 1)
            {

                s1.ctl = ClsStaticStation.a9500.mCTRL_LOAD;

            }
            else
            {
                s1.ctl = ClsStaticStation.a9500.mCTRL_POS;
            }
            
            s1.dest = 900000;
            s1.speed = Convert.ToSingle(numericEdit1.Value)/60;
            s1.num = 0;

            ClsStaticStation.a9500.ARM_DEC_SendMove(0, 0, ref s1);

        }

        private void btndown_Click(object sender, EventArgs e)
        {




            ClsStaticStation.a9500.SIMPLELINE s1;
            s1 = new ClsStaticStation.a9500.SIMPLELINE();


            if (cboweiya.SelectedIndex == 1)
            {

                s1.ctl =ClsStaticStation.a9500.mCTRL_LOAD;

            }
            else
            {
                s1.ctl = ClsStaticStation.a9500.mCTRL_POS;
            }
            s1.dest = -900000;
            s1.speed = Convert.ToSingle(numericEdit1.Value)/60;
            s1.num = 0;

            ClsStaticStation.a9500.ARM_DEC_SendMove(0, 0, ref s1);

        }

        private void btnoil_ValueChanged(object sender, EventArgs e)
        {

            if (btnoil.Caption == "开始注油")
            {
                btnoil.Caption = "停止注油";
                ClsStaticStation.a9500.ARM_DEC_SendOUTSignal(0, 0, 32);
            }
            else
            {
                btnoil.Caption = "开始注油";
                ClsStaticStation.a9500.ARM_DEC_SendOUTSignal(0, 0, 33);
            }


        }

        private void btnenable_ValueChanged(object sender, EventArgs e)
        {

            if (btnenable.Caption == "蓄能器使能")
            {
                btnenable.Caption  = "蓄能器禁止";
                ClsStaticStation.a9500.ARM_DEC_SendOUTSignal(0, 0, 48);
            }
            else
            {
                btnenable.Caption = "蓄能器使能";
                ClsStaticStation.a9500.ARM_DEC_SendOUTSignal(0, 0, 49);
            }

        }

        private void btnfa_ValueChanged(object sender, EventArgs e)
        {

            if (btnfa.Caption == "开泄油阀")
            {
                btnfa.Caption  = "关泄油阀";
                ClsStaticStation.a9500.ARM_DEC_SendOUTSignal(0, 0, 32);


            }
            else
            {
                btnfa.Caption = "开泄油阀";
                ClsStaticStation.a9500.ARM_DEC_SendOUTSignal(0, 0, 33);

            }

        }

        private void btnstop_Click(object sender, EventArgs e)
        {

            ClsStaticStation.a9500.ARM_DEC_MoveStop(0, 0, Convert.ToInt16( GlobeVal.myarm.ConvertCtrlMode(cboweiya.SelectedIndex)));



        }

        private void cboweiya_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cboweiya.SelectedIndex == 0)
            {
                lblunit.Text = "mm/min";
                lblmunit.Text = "mm";
            }
            else
            {
                lblunit.Text = "MPa/min";
                lblmunit.Text = "MPa";
            }
        }

        private void btnstart_Click(object sender, EventArgs e)
        {

            ClsStaticStation.a9500.COMPLEXMOVEST move = new ClsStaticStation.a9500.COMPLEXMOVEST();

            move.dest = Convert.ToSingle(numericEdit2.Value);
            move.firstctl = Convert.ToInt16(GlobeVal.myarm.ConvertCtrlMode(cboweiya.SelectedIndex));
            move.destctl = Convert.ToInt16(GlobeVal.myarm.ConvertCtrlMode(cboweiya.SelectedIndex));
            move.destkeepstyle = 1;
            move.speed = Convert.ToSingle(numericEdit1.Value / 60);
            move.num = 0;
            move.runmsg = 0;
            move.holdtime = 0;

            ClsStaticStation.a9500.ARM_DEC_SendComplexMove(0, 0, 0, 1, 0, ref  move);
            DelayS(0.1);
            ClsStaticStation.a9500.ARM_DEC_Test_Start(0, 0);


        }

        private void btnend_Click(object sender, EventArgs e)
        {


            ClsStaticStation.a9500.ARM_DEC_Test_Stop(0, 0);

            DelayS(0.1);

          
         
        }

      

        private void User围压_Paint(object sender, PaintEventArgs e)
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

        private void switch2_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {

        }

        private void switchDrive_ValueChanged(object sender, EventArgs e)
        {
            if (switchDrive.Value == true)
            {
                ClsStaticStation.a9500.ARM_DEC_System_OFF(0);
                DelayS(0.1);
                ClsStaticStation.a9500.ARM_DEC_System_OFF(0);
                DelayS(0.1);
                ClsStaticStation.a9500.ARM_DEC_System_ON(0);

            }
            else
            {
                ClsStaticStation.a9500.ARM_DEC_System_OFF(0);
            }
        }

        private void switchLink_ValueChanged(object sender, EventArgs e)
        {
            if (switchLink.Value == true)
            {
                short reval;

                reval = System.Convert.ToInt16(ClsStaticStation.a9500.ARM_DEC_Connect((short)0));

                ClsStaticStation.a9500.ARM_DEC_SetCtlerStyle(0, (short)1);  //电拉方式 2017.05.02


                double t = System.Environment.TickCount;

                while ((System.Environment.TickCount - t) < 1000)
                {

                }

            }

        }
    }
}
