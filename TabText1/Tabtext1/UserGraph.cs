using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.UI.WindowsForms;
using NationalInstruments.UI;

namespace AppleLabApplication
{
    public partial class UserGraph : NationalInstruments.UI.WindowsForms.ScatterGraph 
    {
        private ScatterPlot scatterPlot1;
        public UserGraph()
        {
            InitializeComponent();

           
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public void drawline(double x1, double y1, double x2, double y2, CComLibrary.LineStruct l)
        {

            XYPointAnnotation u = new XYPointAnnotation(base.Plots[0].XAxis, base.Plots[0].YAxis);
            u.ArrowColor = Color.Green;

            u.Visible = true;

            u.XPosition = x1;
            u.YPosition = y1;
            u.ShapeVisible = false;
            u.ShapeSize = new Size(1, 1);
            u.ArrowHeadStyle = ArrowStyle.None;
            u.InteractionMode = AnnotationInteractionMode.None;
            u.ArrowLineWidth = 2;
            u.ArrowLineStyle = LineStyle.Solid;
            u.ArrowColor = Color.Green;


            PointF pf = new PointF();
            pf.X = Convert.ToSingle(x2);
            pf.Y = Convert.ToSingle(y2);
            l.pf = pf;
            u.Tag = l;

            base.Annotations.Add(u);
            u.SetPosition(x1, y1);
            u.SetCaptionPosition(x2, y2);

            u.Caption = l.value.ToString("F3");
            u.CaptionForeColor = Color.Green;
            u.CaptionVisible = false;

            base.Cursor = System.Windows.Forms.Cursors.Default;


        }
        public void drawsign(double x, double y, CComLibrary.LineStruct l)
        {

            XYPointAnnotation u = new XYPointAnnotation(base.Plots[0].XAxis, base.Plots[0].YAxis);
            u.ArrowColor = Color.Green;

            u.Visible = true;

            u.ShapeVisible = true;
            u.ShapeSize = new Size(10, 10);

            u.XPosition = x;
            u.YPosition = y;

            u.ArrowHeadStyle = ArrowStyle.None;
            u.ArrowVisible = false;
            u.InteractionMode = AnnotationInteractionMode.None;



            PointF pf = new PointF();
            pf.X = Convert.ToSingle(x);
            pf.Y = Convert.ToSingle(y);
            l.pf = pf;
            u.Tag = l;

            base.Annotations.Add(u);
            u.SetPosition(x, y);
            u.SetCaptionPosition(x, y);
        }

    }
}
