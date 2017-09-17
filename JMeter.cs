﻿using System;
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
    public partial class JMeter : UserControl
    {
        public System.Drawing.Bitmap backimage = new Bitmap(50, 50);

        public Color backcolor;
        public JMeter()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void drawFigure(PaintEventArgs e, PointF[] points,Color mycolor)
        {
            GraphicsPath path = new GraphicsPath();


            Corners r = new Corners(points, 5);
            r.Execute(path);
            path.CloseFigure();
            Matrix matrix = new Matrix();
            matrix.Translate(3, 3);
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
                color, color, LinearGradientMode.Horizontal);
            e.Graphics.FillPath(brush, path);
            Pen pen = new Pen(color, 1);
            e.Graphics.DrawPath(pen, path);

            brush.Dispose();
            pen.Dispose();
        }
        private void JMeter_Paint(object sender, PaintEventArgs e)
        {
            GraphicsContainer containerState = e.Graphics.BeginContainer();
            tableLayoutPanel1.BackColor = Color.Transparent;



            e.Graphics.PageUnit = System.Drawing.GraphicsUnit.Pixel;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.Clear(this.BackColor);


            PointF[] roundedRectangle;
            


            roundedRectangle = new PointF[5];
            roundedRectangle[0].X = 1;
            roundedRectangle[0].Y = 0;
            roundedRectangle[1].X = this.Width - 2 - 4;
            roundedRectangle[1].Y = 0;
            roundedRectangle[2].X = this.Width - 2 - 4;
            roundedRectangle[2].Y = this.Height - 2 - 4;
            roundedRectangle[3].X = 1;
            roundedRectangle[3].Y = this.Height - 2 - 4;
            roundedRectangle[4].X = 1;
            roundedRectangle[4].Y = 0;
            drawFigure(e, roundedRectangle,Color.Gray);

            roundedRectangle = new PointF[5];
            roundedRectangle[0].X = 2;
            roundedRectangle[0].Y = 2;
            roundedRectangle[1].X = this.Width - 2 - 5;
            roundedRectangle[1].Y =2;
            roundedRectangle[2].X = this.Width - 2 - 5;
            roundedRectangle[2].Y = this.Height - 2 - 5;
            roundedRectangle[3].X = 2;
            roundedRectangle[3].Y = this.Height - 2 - 5;
            roundedRectangle[4].X = 2;
            roundedRectangle[4].Y =2;
            drawFigure(e, roundedRectangle, lblvalue.BackColor);
            e.Graphics.EndContainer(containerState);
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Resize(object sender, EventArgs e)
        {

        }
    }
}
