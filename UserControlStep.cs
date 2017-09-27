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

    public partial class UserControlStep : UserControl
    {
        public System.Drawing.Bitmap backimage = new Bitmap(50, 50);

        public Color backcolor;

        private int mkind = 0;

        public int Kind
        {
            get
            {
                return mkind;
            }
            set
            {
                mkind  = value;
                setkind();
           
            }
        }
    

        private  bool mselected = false;

        public bool selected
        {
            get
            {
                return mselected;
            }
            set
            {
                 mselected=value;
                setkind();
            }
        }


        

        public void setkind()
        {
            
            if (mkind==0)
            {
                lblcaption.Text = "斜波";
                if (mselected)
                {
                    lblcaption.ForeColor = Color.White; 
                    picback.BackgroundImage = imageList1.Images[1];
                    tlpbottom.Visible = true;

                }
                else
                {
                    lblcaption.ForeColor = Color.SeaGreen; 
                    picback.BackgroundImage = imageList1.Images[0];
                    tlpbottom.Visible = false;
                }
            }

            if (mkind ==1)
            {
                lblcaption.Text = "保持";
                if (mselected)
                {
                    lblcaption.ForeColor = Color.White;
                    picback.BackgroundImage = imageList1.Images[5];
                    tlpbottom.Visible = true;
                }
                else
                {
                    lblcaption.ForeColor = Color.SeaGreen;
                    picback.BackgroundImage = imageList1.Images[4];
                    tlpbottom.Visible = false;
                }
            }

            if (mkind == 2)
            {
                lblcaption.Text = "循环波";
                if (mselected)
                {
                    lblcaption.ForeColor = Color.White;
                    picback.BackgroundImage = imageList1.Images[3];
                    tlpbottom.Visible = true;
                }
                else
                {
                    lblcaption.ForeColor = Color.SeaGreen;
                    picback.BackgroundImage = imageList1.Images[2];
                    tlpbottom.Visible = false;
                }
            }

            if (mkind == 3)
            {
                lblcaption.Text = "结束";
                if (mselected)
                {
                    tlpbottom.Visible = true;
                    lblcaption.ForeColor = Color.White;
                    picback.BackgroundImage = imageList1.Images[7];
                }
                else
                {
                    lblcaption.ForeColor = Color.SeaGreen;
                    picback.BackgroundImage = imageList1.Images[6];
                    tlpbottom.Visible = false ;
                }
            }
            
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
                Color.FromArgb(5, color), Color.FromArgb(10,color) , LinearGradientMode.Vertical);
            e.Graphics.FillPath(brush, path);
            Pen pen = new Pen(Color.FromArgb(5, color), 1);

            e.Graphics.DrawPath(pen, path);

            brush.Dispose();
            pen.Dispose();
        }
        public UserControlStep()
        {
            InitializeComponent();
        }

        private void UserControlStep_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
            GraphicsContainer containerState = e.Graphics.BeginContainer();
            tableLayoutPanel1.BackColor = Color.Transparent;



            e.Graphics.PageUnit = System.Drawing.GraphicsUnit.Pixel;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.Clear(Color.White);


            PointF[] roundedRectangle;



            roundedRectangle = new PointF[5];
            roundedRectangle[0].X = 2;
            roundedRectangle[0].Y = 2;
            roundedRectangle[1].X = tableLayoutPanel2.Width - 2 - 5;
            roundedRectangle[1].Y = 2;
            roundedRectangle[2].X = tableLayoutPanel2.Width - 2 - 5;
            roundedRectangle[2].Y = tableLayoutPanel2.Height - 2 - 5;
            roundedRectangle[3].X = 2;
            roundedRectangle[3].Y = tableLayoutPanel2.Height - 2 - 5;
            roundedRectangle[4].X = 2;
            roundedRectangle[4].Y = 2;
            drawFigure(e, roundedRectangle, Color.FromArgb(2, Color.YellowGreen));

            roundedRectangle = new PointF[5];
            roundedRectangle[0].X = 5;
            roundedRectangle[0].Y = 5;
            roundedRectangle[1].X = tableLayoutPanel2.Width - 5 - 5;
            roundedRectangle[1].Y = 5;
            roundedRectangle[2].X = tableLayoutPanel2.Width - 5 - 5;
            roundedRectangle[2].Y = tableLayoutPanel2.Height - 5 - 5;
            roundedRectangle[3].X = 5;
            roundedRectangle[3].Y = tableLayoutPanel2.Height - 5 - 5;
            roundedRectangle[4].X = 5;
            roundedRectangle[4].Y = 5;





            drawFigure(e, roundedRectangle, Color.Black);

            Pen p = new Pen(Color.SeaGreen);
            p.Width = 3;
            e.Graphics.DrawRectangle(p, roundedRectangle[0].X + 10, roundedRectangle[0].Y + 10, tableLayoutPanel2.Width - 15 - 20, tableLayoutPanel2.Height - 15 - 20);
            if (mselected == false )
            {
                e.Graphics.FillRectangle(Brushes.White , roundedRectangle[0].X + 10, roundedRectangle[0].Y + 10, tableLayoutPanel2.Width - 15 - 20, tableLayoutPanel2.Height - 15 - 20);
            }
            else
            { 
            e.Graphics.FillRectangle(Brushes.SeaGreen, roundedRectangle[0].X + 10, roundedRectangle[0].Y + 10, tableLayoutPanel2.Width - 15 - 20, tableLayoutPanel2.Height - 15 - 20);
            }
           
            e.Graphics.EndContainer(containerState);

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
