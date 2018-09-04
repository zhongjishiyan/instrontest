using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace TabHeaderDemo
{

    public partial class UserControlBlock : UserControl
    {
        public delegate void BtnLeftAddEventHandler(object sender, int index);
        public event BtnLeftAddEventHandler btnleftevent;

        public delegate void BtnRightAddEventHandler(object sender, int index);
        public event BtnRightAddEventHandler btnrightevent;

        public delegate void BtnCopyEventHandler(object sender, int index);
        public event BtnCopyEventHandler btncopyevent;

        public delegate void BtnCutEventHandler(object sender, int index);
        public event BtnCutEventHandler btncutevent;

        public delegate void SelectEventHandler(object sender, int index);
        public event SelectEventHandler btnselectevent;

        public System.Drawing.Bitmap backimage = new Bitmap(50, 50);

        public Color backcolor;

        public int Id = 0;

        private int mkind = 0;


        public CComLibrary.Sequence msequence;

        public int Kind
        {
            get
            {
                return mkind;
            }
            set
            {
                mkind = value;
                setkind();

            }
        }


        private bool mselected = false;

        public bool selected
        {
            get
            {
                return mselected;
            }
            set
            {
                mselected = value;
                setkind();
            }
        }


      

        public void setcaption()
        {
            if (GlobeVal.mysys.language == 0)
            {
                lblcaption.Text = "步骤" + (Id + 1).ToString() + " " + msequence.stepname;
            }
            else
            {
                lblcaption.Text = "Step " + (Id + 1).ToString() + " " + msequence.stepname;
            }

        }

        public void setkind()
        {

            if (mkind == 0)
            {
               
                if (mselected)
                {
                    lblcaption.ForeColor = Color.White;
                 
                    
                    tlpbottom.Visible = true;

                }
                else
                {
                    lblcaption.ForeColor = Color.White;
                 
                    tlpbottom.Visible = false;
                }
            }

            if (mkind == 1)
            {
              
                if (mselected)
                {
                    lblcaption.ForeColor = Color.White;
                 
                    tlpbottom.Visible = true;
                }
                else
                {
                    lblcaption.ForeColor = Color.White;
                 
                    tlpbottom.Visible = false;
                }
            }

            if (mkind == 2)
            {
              
                if (mselected)
                {
                    lblcaption.ForeColor = Color.White;
                
                    tlpbottom.Visible = true;
                }
                else
                {
                    lblcaption.ForeColor = Color.White;
               
                    tlpbottom.Visible = false;
                }
            }

            if (mkind == 3)
            {
              
                if (mselected)
                {
                    tlpbottom.Visible = true;
                    lblcaption.ForeColor = Color.White;
                 
                }
                else
                {
                    lblcaption.ForeColor = Color.White;
                 
                    tlpbottom.Visible = false;
                }
            }

            if (mkind == 4)
            {

                if (mselected)
                {
                    tlpbottom.Visible = true;
                    lblcaption.ForeColor = Color.White;
                  
                }
                else
                {
                    lblcaption.ForeColor = Color.White;
               
                    tlpbottom.Visible = false;
                }
            }

            if (mkind == 5)
            {

                if (mselected)
                {
                    tlpbottom.Visible = true;
                    lblcaption.ForeColor = Color.White;
                   
                }
                else
                {
                    lblcaption.ForeColor = Color.White ;
                  
                    tlpbottom.Visible = false;
                }
            }

            this.Refresh();

        }

        private void drawFigure(PaintEventArgs e, PointF[] points, Color mycolor)
        {
            GraphicsPath path = new GraphicsPath();


            Corners r = new Corners(points, 5);
            r.Execute(path);
            path.CloseFigure();
            Matrix matrix = new Matrix();
            matrix.Translate(0, 0);
            path.Transform(matrix);


            //Bitmap map = new Bitmap(backimage);
            Color c = mycolor;



            drawPath(e, path, c);

            path.Reset();
            r = new Corners(points, 5);
            r.Execute(path);
            path.CloseFigure();
            matrix = new Matrix();
            matrix.Translate(0, 0);
            path.Transform(matrix);

            drawPath(e, path, c);

            path.Dispose();
        }

        private static void drawPath(PaintEventArgs e, GraphicsPath path, Color color)
        {

            LinearGradientBrush brush = new LinearGradientBrush(path.GetBounds(),
                Color.FromArgb(100, color), Color.FromArgb(100, color), LinearGradientMode.Vertical);
            e.Graphics.FillPath(Brushes.SeaGreen, path);
            Pen pen = new Pen(Color.FromArgb(100, color), 1);

            e.Graphics.DrawPath(Pens.SeaGreen, path);

            brush.Dispose();
            pen.Dispose();
        }
        public UserControlBlock()
        {
            InitializeComponent();

            msequence = new CComLibrary.Sequence();

            
          

           // waveformGraph1.PlotAreaColor = Color.SeaGreen;
        }

        private void UserControlStep_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
            return;
          
          

        }

     

        private void UserControlStep_Enter(object sender, EventArgs e)
        {

        }

        private void UserControlStep_Leave(object sender, EventArgs e)
        {

        }

        private void UserControlStep_DoubleClick(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void picback_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            

           if (  btnselectevent!=null)
            {

                btnselectevent(this, 0);
            }
            
        }

        private void btnrightadd_Click(object sender, EventArgs e)
        {
            if (this.btnrightevent!=null)
            {
                btnrightevent(this, 0);
            }
        }

        private void btnleftadd_Click(object sender, EventArgs e)
        {
            if (btnleftevent != null)
            {
                btnleftevent(this, 0);
            }
        }

        private void btncopy_Click(object sender, EventArgs e)
        {
            if (this.btncopyevent != null)
            {
                btncopyevent(this, 0);
            }
        }

        private void btncut_Click(object sender, EventArgs e)
        {
            if (this.btncutevent != null)
            {
                btncutevent(this, 0);
            }
        }

        private void waveformGraph1_PlotDataChanged(object sender, NationalInstruments.UI.XYPlotDataChangedEventArgs e)
        {

        }

        private void scatterGraph1_PlotDataChanged(object sender, NationalInstruments.UI.XYPlotDataChangedEventArgs e)
        {

        }

        private void scatterGraph1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (btnselectevent != null)
            {

                btnselectevent(this, 0);
            }
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            scatterGraph1.Left = -scatterGraph1.PlotAreaBounds.Left;
            scatterGraph1.Top = -scatterGraph1.PlotAreaBounds.Top;
            scatterGraph1.Width =  Convert.ToInt16(panel1.Width+scatterGraph1.PlotAreaBounds.Left *2);
            scatterGraph1.Height  = Convert.ToInt16(panel1.Height+scatterGraph1.PlotAreaBounds.Top *2 );
        }

      
    }
}
