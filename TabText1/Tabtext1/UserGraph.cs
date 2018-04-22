using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using NationalInstruments.UI.WindowsForms;
using NationalInstruments.UI;
using NationalInstruments.Analysis.Math;
using NationalInstruments.Analysis.Monitoring;
using System.Drawing.Printing;
namespace AppleLabApplication
{
    public partial class UserGraph : UserControl  
    {

        public string datapath = "";

        public bool firstread = false;
        private int curvescount = 0;

        public int xfirstsel = 0;
        public int yfirstsel = 0;

        private Point mP7;
        private Point mP8;
        private PointF mP7F;
        private PointF mP8F;

        private System.Boolean mtsbtext_bool = false;
        private System.Boolean mtsbtext_begin = false;

        ZBobb.AlphaBlendTextBox mabtext;



        private Point mP1;
        private Point mP2;
        private PointF mP1F;
        private PointF mP2F;

        private System.Boolean mtsbarrow_bool = false;
        private System.Boolean mtsbarrow_begin = false;



        private Point mP3;
        private Point mP4;
        private PointF mP3F;
        private PointF mP4F;

        private System.Boolean mtsbline_bool = false;
        private System.Boolean mtsbline_begin = false;



        private Point mP5;
        private Point mP6;
        private PointF mP5F;
        private PointF mP6F;

        private System.Boolean mtsbrect_bool = false;
        private System.Boolean mtsbrect_begin = false;

        Rectangle lastRect = Rectangle.Empty;

        private Point mP9;
        private Point mP10;
        private PointF mP9F;
        private PointF mP10F;

        private System.Boolean mtsbpoint_bool = false;
        private System.Boolean mtsbpoint_begin = false;


        private Point mP11;
        private Point mP12;
        private PointF mP11F;
        private PointF mP12F;

        private System.Boolean mtsbcontrol_bool = false;
        private System.Boolean mtsbcontrol_begin = false;
        public UserGraph()
        {
            InitializeComponent();

           
        }

        private void PrintPageEntireGraph(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            
            Rectangle bounds = e.MarginBounds;

            scatterGraph1.Draw(new ComponentDrawArgs(g,bounds));
        }
        public void Init()
        {
            tsbdefault.Checked = true;
            ToolStripItemClickedEventArgs e = new ToolStripItemClickedEventArgs(tsbdefault);
           
            toolStrip2_ItemClicked(null,e);

            for (int i = 0; i < legend.Items.Count; i++)
            {
                legend.Items[i].Visible = false; 
            }
        }
       
        private void drawmline(double x1, double y1, double x2, double y2, CComLibrary.LineStruct l)
        {

            XYPointAnnotation u = new XYPointAnnotation(scatterPlot1.XAxis, scatterPlot1.YAxis);
            u.ArrowColor = Color.Green;

            u.Visible = true;


            u.XPosition = x1;
            u.YPosition = y1;
            u.ShapeVisible = false;
            u.ShapeSize = new Size(1, 1);
            u.ArrowHeadStyle = ArrowStyle.None;
            u.InteractionMode = AnnotationInteractionMode.None;
            u.ArrowLineWidth = 2;
            u.ArrowLineStyle = LineStyle.DashDotDot;
            u.ArrowColor = Color.Green;
            u.Caption = u.YPosition.ToString("G4");
            u.CaptionVisible = true;
            u.CaptionForeColor = u.ArrowColor;


            PointF pf = new PointF();
            pf.X = Convert.ToSingle(x2);
            pf.Y = Convert.ToSingle(y2);
            l.pf = pf;
            u.Tag = l;

            scatterGraph1.Annotations.Add(u);
            u.SetPosition(x1, y1);
            u.SetCaptionPosition(x2, y2);

            scatterGraph1.Cursor = Cursors.Default;


        }

        public void drawline(double x1, double y1, double x2, double y2, CComLibrary.LineStruct l)
        {

           if (double.IsNaN(x1)==true)
            {
                x1 = 0;
                return;
            }
           if  (double.IsInfinity( x1)==true)
            {
                x1 = 0;
                return;
            }

           if (double.IsNaN(y1) ==true)
            {
                y1 = 0;
                return;
            }
            if (double.IsInfinity(y1) == true)
            {
                y1 = 0;
                return;
            }
            if (double.IsNaN(x2)==true)
            {
                x2 = 0;
                return;
            }


            if (double.IsInfinity(x2) == true)
            {
                x2 = 0;
                return;
            }
            if (double .IsNaN(y2)==true)
            {
                y2 = 0;
                return;
            }
            if (double.IsInfinity(y2) == true)
            {
                y2 = 0;
                return;
            }


            XYPointAnnotation u = new XYPointAnnotation(scatterGraph1.Plots[0].XAxis, scatterGraph1.Plots[0].YAxis);
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

            scatterGraph1.Annotations.Add(u);
            u.SetPosition(x1, y1);
            u.SetCaptionPosition(x2, y2);

            u.Caption = l.value.ToString("F3");
            u.CaptionForeColor = Color.Green;
            u.CaptionVisible = false;

            base.Cursor = System.Windows.Forms.Cursors.Default;


        }
        public void drawsign(double x, double y, CComLibrary.LineStruct l)
        {

            if (double.IsInfinity(x) == true)
            {
                x = 0;
                return;
            }

            if (double.IsInfinity(y) == true)
            {
                y = 0;
                return;
            }

            XYPointAnnotation u = new XYPointAnnotation(scatterGraph1.Plots[0].XAxis, scatterGraph1.Plots[0].YAxis);
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

            scatterGraph1.Annotations.Add(u);
            u.SetPosition(x, y);
            u.SetCaptionPosition(x, y);
        }

        private void tsbdefault_CheckedChanged(object sender, EventArgs e)
        {
            scatterGraph1.Cursor = Cursors.Default;
            scatterGraph1.InteractionModeDefault = NationalInstruments.UI.GraphDefaultInteractionMode.None;

        }

        private void tsbzoomin_Click(object sender, EventArgs e)
        {
            scatterGraph1.InteractionModeDefault = NationalInstruments.UI.GraphDefaultInteractionMode.ZoomXY;
            tsbzoomout.Enabled = true;

        }

        private void tsbzoomout_Click(object sender, EventArgs e)
        {
            scatterGraph1.UndoZoomPan();
            scatterGraph1.InteractionModeDefault = NationalInstruments.UI.GraphDefaultInteractionMode.None;
        }

        private void tsbscreenreader_Click(object sender, EventArgs e)
        {
           


        }

        private void tsbreader_Click(object sender, EventArgs e)
        {
          

        }

        private void tsbselector_CheckedChanged(object sender, EventArgs e)
        {
            int l;
            scatterGraph1.InteractionModeDefault = NationalInstruments.UI.GraphDefaultInteractionMode.None;

            if (tsbselector.Checked == true)
            {
                scatterGraph1.Plots[0].GetXData();
                l = scatterGraph1.Plots[0].HistoryCount;
                CComLibrary.GlobeVal.g_datadraw = new double[2][];

                CComLibrary.GlobeVal.g_datadraw[0] = new double[l];
                CComLibrary.GlobeVal.g_datadraw[1] = new double[l];
                CComLibrary.GlobeVal.g_datadraw[0] = scatterGraph1.Plots[0].GetXData();
                CComLibrary.GlobeVal.g_datadraw[1] = scatterGraph1.Plots[0].GetYData();

                xyCursorstart.Visible = true;
                xyCursorend.Visible = true;

                if (scatterGraph1.Plots[0].HistoryCount > 0)
                {
                    xyCursorstart.MoveCursor(0);

                    xyCursorend.MoveCursor(scatterGraph1.Plots[0].HistoryCount - 1);
                }

                toolStripbar.Enabled = true;
            }
            else
            {
                xyCursorstart.Visible = false;
                xyCursorend.Visible = false;
                toolStripbar.Enabled = false;
            }
        }

        private void tsbtext_Click(object sender, EventArgs e)
        {

        }

        private void tsbtext_CheckedChanged(object sender, EventArgs e)
        {
            scatterGraph1.InteractionModeDefault = NationalInstruments.UI.GraphDefaultInteractionMode.None;

            mtsbtext_bool = tsbtext.Checked;
            scatterGraph1.Cursor = Cursors.IBeam;
        }

        private void tsbarrow_CheckedChanged(object sender, EventArgs e)
        {
            scatterGraph1.InteractionModeDefault = NationalInstruments.UI.GraphDefaultInteractionMode.None;
            mtsbarrow_bool = tsbarrow.Checked;
            scatterGraph1.Cursor = Cursors.Cross;
        }

        private void tsbline_CheckedChanged(object sender, EventArgs e)
        {
            scatterGraph1.InteractionModeDefault = NationalInstruments.UI.GraphDefaultInteractionMode.None;
            mtsbline_bool = tsbline.Checked;
            scatterGraph1.Cursor = Cursors.Cross;
        }

        private void tsbrect_CheckedChanged(object sender, EventArgs e)
        {
            scatterGraph1.InteractionModeDefault = NationalInstruments.UI.GraphDefaultInteractionMode.None;
            mtsbrect_bool = tsbrect.Checked;
            scatterGraph1.Cursor = Cursors.Cross;
        }

        private void tsbpoint_CheckedChanged(object sender, EventArgs e)
        {
            scatterGraph1.InteractionModeDefault = NationalInstruments.UI.GraphDefaultInteractionMode.None;
            mtsbpoint_bool = tsbpoint.Checked;
            scatterGraph1.Cursor = Cursors.Cross;
        }
        void t_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                scatterGraph1.Focus();
                return;

            }
        }

        void t_LostFocus(object sender, EventArgs e)
        {
            double x, y;
            double x1, y1;

            (sender as ZBobb.AlphaBlendTextBox).Visible = false;

            XYPointAnnotation u = new XYPointAnnotation(scatterPlot1.XAxis, scatterPlot1.YAxis);
            u.ArrowColor = Color.White;
            u.ArrowVisible = false;
            u.Visible = true;
            scatterPlot1.InverseMapDataPoint(scatterPlot1.GetBounds(), mP8F, out x, out y);
            u.XPosition = x;
            u.YPosition = y;
            u.ShapeVisible = false;
            u.ShapeSize = new Size(1, 1);
            u.CaptionVisible = true;
            u.CaptionForeColor = scatterGraph1.ForeColor;
            u.InteractionMode = AnnotationInteractionMode.DragCaption;

            scatterPlot1.InverseMapDataPoint(scatterPlot1.GetBounds(), mP8F, out x1, out y1);


            PointF pf = new PointF();
            pf.X = Convert.ToSingle(x1);
            pf.Y = Convert.ToSingle(y1);

            CComLibrary.LineStruct l = new CComLibrary.LineStruct();
            l.kind = 3;
            l.pf = pf;
            u.Tag = l;

            u.Caption = (sender as ZBobb.AlphaBlendTextBox).Text;
            scatterGraph1.Annotations.Add(u);
            u.SetPosition(x, y);
            u.SetCaptionPosition(x1, y1);


            scatterGraph1.Cursor = Cursors.Default;

            timertxt.Enabled = true;


        }
        private void scatterGraph1_MouseUp(object sender, MouseEventArgs e)
        {
            double x, y;
            double x1, y1;

            PointF f = new PointF();


            if (sender is Panel)
            {

                (sender as Panel).SendToBack();

                f.X = (sender as Panel).Left;
                f.Y = (sender as Panel).Top;

                scatterPlot1.InverseMapDataPoint(scatterPlot1.GetBounds(), f, out x, out y);


                xyselectstart.XPosition = x;
                xyselectstart.YPosition = y;
                xyselectstart.Visible = true;
                xyselectstart.Tag = sender;


                f.X = (sender as Panel).Width + (sender as Panel).Left;
                f.Y = (sender as Panel).Top + (sender as Panel).Height;


                scatterPlot1.InverseMapDataPoint(scatterPlot1.GetBounds(), f, out x1, out y1);


                xyselectend.XPosition = x1;
                xyselectend.YPosition = y1;
                xyselectend.Tag = sender;
                xyselectend.Visible = true;






            }




            if ((mtsbtext_bool == true) && (e.Button == MouseButtons.Left))
            {
                mP8F.X = e.X;
                mP8F.Y = e.Y;

                mabtext = new ZBobb.AlphaBlendTextBox();

                mabtext.BackAlpha = 0;
                mabtext.ForeColor = scatterGraph1.ForeColor;
                mabtext.BackColor = scatterGraph1.BackColor;
                mabtext.BorderStyle = BorderStyle.FixedSingle;

                scatterGraph1.Controls.Add(mabtext);

                mabtext.Left = e.X;
                mabtext.Top = e.Y;
                mabtext.Parent = scatterGraph1;
                mabtext.KeyPress += new KeyPressEventHandler(t_KeyPress);
                mabtext.LostFocus += new EventHandler(t_LostFocus);

                mtsbtext_bool = false;
                scatterGraph1.Cursor = Cursors.Default;
                tsbtext.Checked = false;
                mabtext.Focus();


            }

            if ((mtsbcontrol_begin == true) && (e.Button == MouseButtons.Left))
            {
                mP12F.X = e.X;
                mP12F.Y = e.Y;

                Panel u = new Panel();
                u.Visible = true;
                u.BackColor = Color.White;



                u.Left = Convert.ToInt16(mP11F.X);
                u.Top = Convert.ToInt16(mP11F.Y);
                u.Width = Convert.ToInt16(Math.Abs(mP12F.X - mP11F.X));
                u.Height = Convert.ToInt16(Math.Abs(mP12F.Y - mP11F.Y));

                u.MouseDown += new MouseEventHandler(scatterGraph1_MouseDown);
                u.MouseUp += new MouseEventHandler(scatterGraph1_MouseUp);
                u.Parent = scatterGraph1;
                scatterGraph1.Controls.Add(u);

                scatterGraph1.Cursor = Cursors.Default;

                tsbcontrol.Checked = false;
                mtsbcontrol_bool = false;
                mtsbcontrol_begin = false;




            }
            if ((mtsbrect_bool == true) && (e.Button == MouseButtons.Left))
            {
                mP6F.X = e.X;
                mP6F.Y = e.Y;


                XYRangeAnnotation u = new XYRangeAnnotation(scatterPlot1.XAxis, scatterPlot1.YAxis);
                u.ArrowColor = Color.White;
                u.ArrowVisible = false;
                u.Visible = true;
                u.CaptionVisible = false;
                u.Caption = "";
                u.RangeFillStyle = FillStyle.DiagonalBrick;
                u.CaptionForeColor = scatterGraph1.ForeColor;
                scatterPlot1.InverseMapDataPoint(scatterPlot1.GetBounds(), mP6F, out x, out y);

                u.InteractionMode = AnnotationInteractionMode.None;
                u.ArrowHeadStyle = ArrowStyle.None;

                scatterPlot1.InverseMapDataPoint(scatterPlot1.GetBounds(), mP5F, out x1, out y1);

                scatterGraph1.Annotations.Add(u);
                if (x1 < x)
                {
                    u.XRange = new Range(x1, x);
                }
                else
                {
                    u.XRange = new Range(x, x1);
                }
                if (y1 < y)
                {
                    u.YRange = new Range(y1, y);
                }
                else
                {
                    u.YRange = new Range(y, y1);
                }


                scatterGraph1.Cursor = Cursors.Default;

                tsbrect.Checked = false;
                mtsbrect_bool = false;
                mtsbrect_begin = false;

            }

            if ((mtsbpoint_bool == true) && (e.Button == MouseButtons.Left))
            {
                mP10F.X = e.X;
                mP10F.Y = e.Y;

                XYPointAnnotation u = new XYPointAnnotation(scatterPlot1.XAxis, scatterPlot1.YAxis);
                u.ArrowColor = scatterGraph1.ForeColor;

                u.Visible = true;
                scatterPlot1.InverseMapDataPoint(scatterPlot1.GetBounds(), mP10F, out x, out y);
                u.ShapeVisible = true;
                u.ShapeSize = new Size(10, 10);

                u.CaptionForeColor = scatterGraph1.ForeColor;
                u.XPosition = x;
                u.YPosition = y;

                u.ArrowHeadStyle = ArrowStyle.None;
                u.ArrowVisible = false;
                u.InteractionMode = AnnotationInteractionMode.None;
                //scatterPlot1.InverseMapDataPoint(scatterPlot1.GetBounds(), mP9F, out x1, out y1);


                PointF pf = new PointF();
                pf.X = Convert.ToSingle(x);
                pf.Y = Convert.ToSingle(y);

                CComLibrary.LineStruct l = new CComLibrary.LineStruct();
                l.kind = 0;
                l.pf = pf;
                u.Tag = l;

                scatterGraph1.Annotations.Add(u);
                u.SetPosition(x, y);
                u.SetCaptionPosition(x, y);

                scatterGraph1.Cursor = Cursors.Default;

                tsbpoint.Checked = false;
                mtsbpoint_bool = false;
                mtsbpoint_begin = false;

            }

            if ((mtsbline_bool == true) && (e.Button == MouseButtons.Left))
            {
                mP4F.X = e.X;
                mP4F.Y = e.Y;



                XYPointAnnotation u = new XYPointAnnotation(scatterPlot1.XAxis, scatterPlot1.YAxis);
                u.ArrowColor = scatterGraph1.ForeColor;

                u.Visible = true;
                scatterPlot1.InverseMapDataPoint(scatterPlot1.GetBounds(), mP4F, out x, out y);
                u.XPosition = x;
                u.YPosition = y;
                u.ShapeVisible = false;
                u.ShapeSize = new Size(1, 1);
                u.ArrowHeadStyle = ArrowStyle.None;
                u.InteractionMode = AnnotationInteractionMode.None;
                scatterPlot1.InverseMapDataPoint(scatterPlot1.GetBounds(), mP3F, out x1, out y1);
                u.CaptionForeColor = scatterGraph1.ForeColor;

                PointF pf = new PointF();
                pf.X = Convert.ToSingle(x1);
                pf.Y = Convert.ToSingle(y1);
                CComLibrary.LineStruct l = new CComLibrary.LineStruct();
                l.kind = 1;
                l.pf = pf;
                u.Tag = l;

                scatterGraph1.Annotations.Add(u);
                u.SetPosition(x, y);
                u.SetCaptionPosition(x1, y1);

                scatterGraph1.Cursor = Cursors.Default;

                tsbline.Checked = false;
                mtsbline_bool = false;
                mtsbline_begin = false;

            }
            if ((mtsbarrow_bool == true) && (e.Button == MouseButtons.Left))
            {
                mP2F.X = e.X;
                mP2F.Y = e.Y;




                XYPointAnnotation u = new XYPointAnnotation(scatterPlot1.XAxis, scatterPlot1.YAxis);

                u.ArrowColor = scatterGraph1.ForeColor;
                u.Visible = true;
                scatterPlot1.InverseMapDataPoint(scatterPlot1.GetBounds(), mP2F, out x, out y);
                u.XPosition = x;
                u.YPosition = y;
                u.ShapeVisible = false;
                u.InteractionMode = AnnotationInteractionMode.None;
                u.ShapeSize = new Size(1, 1);
                u.CaptionForeColor = scatterGraph1.ForeColor;

                scatterPlot1.InverseMapDataPoint(scatterPlot1.GetBounds(), mP1F, out x1, out y1);

                scatterGraph1.Annotations.Add(u);
                u.SetPosition(x, y);

                u.SetCaptionPosition(x1, y1);

                PointF pf = new PointF();
                pf.X = Convert.ToSingle(x1);
                pf.Y = Convert.ToSingle(y1);

                CComLibrary.LineStruct l = new CComLibrary.LineStruct();
                l.kind = 3;
                l.pf = pf;
                u.Tag = l;

                scatterGraph1.Cursor = Cursors.Default;

                tsbarrow.Checked = false;
                mtsbarrow_bool = false;
                mtsbarrow_begin = false;


            }

            scatterGraph1.Cursor = Cursors.Default;
        }

        private void scatterGraph1_MouseDown(object sender, MouseEventArgs e)
        {
            if (mtsbpoint_bool == true)
            {
                mtsbpoint_begin = true;
                mP9.X = e.X;
                mP9.Y = e.Y;
                mP9 = scatterGraph1.PointToClient(e.Location);
                mP10 = mP9;

            }
            if (mtsbrect_bool == true)
            {
                mtsbrect_begin = true;
                mP5F.X = e.X;
                mP5F.Y = e.Y;
                mP5 = scatterGraph1.PointToScreen(e.Location);
                mP6 = mP5;


            }
            if (mtsbline_bool == true)
            {
                mtsbline_begin = true;
                mP3F.X = e.X;
                mP3F.Y = e.Y;
                mP3 = scatterGraph1.PointToScreen(e.Location);
                mP4 = mP3;

            }
            if (mtsbarrow_bool == true)
            {
                mtsbarrow_begin = true;

                mP1F.X = e.X;
                mP1F.Y = e.Y;

                mP1 = scatterGraph1.PointToScreen(e.Location);
                mP2 = mP1;



            }
            if (mtsbcontrol_bool == true)
            {
                mtsbcontrol_begin = true;
                mP11F.X = e.X;
                mP11F.Y = e.Y;
                mP11 = scatterGraph1.PointToScreen(e.Location);
                mP12 = mP11;


            }

        }

        private void timertxt_Tick(object sender, EventArgs e)
        {
            scatterGraph1.Controls.Remove(mabtext);
            timertxt.Enabled = false;
        }

        private void scatterGraph1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            XAxis xx;

            xx = scatterGraph1.GetXAxisAt(e.X, e.Y);

            if (xx != null)
            {



                FormAxis  f = FormAxis.InstanceObject();   //实例化窗体
                f.myplot = scatterGraph1;
                f.Tag = xx;
                f.Focus();   //让窗体获得焦点
                f.ShowDialog();    //显示窗体


               
               
              
             

            }

            YAxis yy;
            yy = scatterGraph1.GetYAxisAt(e.X, e.Y);

            if (yy != null)
            {

                FormAxis f = FormAxis.InstanceObject();   //实例化窗体
                f.myplot = scatterGraph1;
                f.Tag = yy;
                f.Focus();   //让窗体获得焦点
                f.ShowDialog();    //显示窗体


            }

        }

        private void scatterGraph1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((mtsbpoint_bool == true) && (mtsbpoint_begin == true))
            {


            }

            if ((mtsbarrow_bool == true) && (mtsbarrow_begin == true))
            {


                ControlPaint.DrawReversibleLine(mP1, mP2, Color.Red);
                mP2 = scatterGraph1.PointToScreen(e.Location);

                ControlPaint.DrawReversibleLine(mP1, mP2, Color.Red);



            }

            if ((mtsbline_bool == true) && (mtsbline_begin == true))
            {
                ControlPaint.DrawReversibleLine(mP3, mP4, Color.Red);
                mP4 = scatterGraph1.PointToScreen(e.Location);

                ControlPaint.DrawReversibleLine(mP3, mP4, Color.Red);

            }

            if ((mtsbrect_bool == true) && (mtsbrect_begin == true))
            {
                if (this.mP5.X >= 0)
                {
                    Point current = scatterGraph1.PointToScreen(e.Location);
                    Size size = new Size(current.X - mP5.X, current.Y - mP5.Y);

                    ControlPaint.DrawReversibleFrame(lastRect, Color.Red, FrameStyle.Dashed);  //擦旧
                    lastRect = new Rectangle(mP5, size);
                    ControlPaint.DrawReversibleFrame(lastRect, Color.Red, FrameStyle.Dashed);  //画新
                }


            }


            if ((mtsbcontrol_bool == true) && (mtsbcontrol_begin == true))
            {
                if (this.mP11.X >= 0)
                {
                    Point current = scatterGraph1.PointToScreen(e.Location);
                    Size size = new Size(current.X - mP11.X, current.Y - mP11.Y);

                    ControlPaint.DrawReversibleFrame(lastRect, Color.Red, FrameStyle.Dashed);  //擦旧
                    lastRect = new Rectangle(mP11, size);
                    ControlPaint.DrawReversibleFrame(lastRect, Color.Red, FrameStyle.Dashed);  //画新
                }


            }
        }

        private void scatterGraph1_PlotAreaMouseMove(object sender, MouseEventArgs e)
        {
            XYAnnotation b;


            b = scatterGraph1.GetAnnotationAt(e.Location.X, e.Location.Y);


            if (b != null)
            {
                scatterGraph1.Cursor = Cursors.Hand;


            }
            else
            {
                scatterGraph1.Cursor = Cursors.Default;
            }
        }

        private void scatterGraph1_PlotAreaMouseUp(object sender, MouseEventArgs e)
        {



            XYAnnotation b;



            b = scatterGraph1.GetAnnotationAt(e.Location.X, e.Location.Y);


            if (b != null)
            {
                if (b is XYPointAnnotation)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        if (xyselectend.Visible == false)
                        {
                            xyselectstart.XPosition = (b as XYPointAnnotation).XPosition;
                            xyselectstart.YPosition = (b as XYPointAnnotation).YPosition;
                            if ((b as XYPointAnnotation).Tag == null)
                            {
                            }
                            else
                            {
                                CComLibrary.LineStruct f = (CComLibrary.LineStruct)((b as XYPointAnnotation).Tag);


                                xyselectend.XPosition = f.pf.X;
                                xyselectend.YPosition = f.pf.Y;

                                if (b.ArrowVisible == true)
                                {
                                    xyselectstart.Visible = true;
                                    xyselectstart.Tag = b;
                                    xyselectend.Visible = true;
                                    xyselectend.Tag = b;
                                }
                                else
                                {
                                    xyselectstart.Visible = true;
                                    xyselectstart.Tag = b;
                                    xyselectend.Visible = false;
                                    xyselectend.Tag = b;
                                }
                            }

                        }
                    }
                    else
                    {
                        Point t = new Point();
                        t.X = e.X;
                        t.Y = e.Y;
                        t = scatterGraph1.PointToScreen(t);
                        ctmnu.Tag = b;
                        ctmnu.Show(t.X, t.Y);

                    }

                }

                if (b is XYRangeAnnotation)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        if (xyselectend.Visible == false)
                        {
                            xyselectstart.XPosition = (b as XYRangeAnnotation).XRange.Minimum;
                            xyselectstart.YPosition = (b as XYRangeAnnotation).YRange.Maximum;

                            xyselectend.XPosition = (b as XYRangeAnnotation).XRange.Maximum;
                            xyselectend.YPosition = (b as XYRangeAnnotation).YRange.Minimum;
                            xyselectstart.Visible = true;

                            xyselectend.Visible = true;
                            xyselectstart.Tag = b;
                            xyselectend.Tag = b;



                        }
                    }
                    else
                    {
                        Point t = new Point();
                        t.X = e.X;
                        t.Y = e.Y;
                        t = scatterGraph1.PointToScreen(t);
                        ctmnu.Tag = b;
                        ctmnu.Show(t.X, t.Y);

                    }

                }

            }
            else
            {
                xyselectstart.Visible = false;
                xyselectstart.Tag = null;
                xyselectend.Visible = false;
                xyselectend.Tag = null;

                if (e.Button == MouseButtons.Right)
                {
                    Point t = new Point();
                    t.X = e.X;
                    t.Y = e.Y;
                    t = scatterGraph1.PointToScreen(t);

                    ctmnuplot.Show(t.X, t.Y);


                }

            }
        }

        private void scatterGraph1_Resize(object sender, EventArgs e)
        {
            
            int i = 0;
            if (CComLibrary.GlobeVal.m_test == false)
            {
                scatterGraph1.Annotations.Clear();
                for (i = 0; i < CComLibrary.GlobeVal.m_listline.Count; i++)
                {
                    if (CComLibrary.GlobeVal.m_listline[i].kind == 0)
                    {

                        drawsign(CComLibrary.GlobeVal.m_listline[i].xstart, CComLibrary.GlobeVal.m_listline[i].ystart, CComLibrary.GlobeVal.m_listline[i]);



                    }
                    else if (CComLibrary.GlobeVal.m_listline[i].kind == 1)
                    {
                        drawline(CComLibrary.GlobeVal.m_listline[i].xstart, CComLibrary.GlobeVal.m_listline[i].ystart,
                             CComLibrary.GlobeVal.m_listline[i].xend, CComLibrary.GlobeVal.m_listline[i].yend, CComLibrary.GlobeVal.m_listline[i]);


                    }

                }

            }
        }

        private void ctmnu编辑_Click(object sender, EventArgs e)
        {
            FormPopupMenu f = new FormPopupMenu();
            f.Tag = ctmnu.Tag;
            f.ShowDialog();
        }

        private void ctmnu删除_Click(object sender, EventArgs e)
        {
            if (ctmnu.Tag is XYPointAnnotation)
            {
                XYPointAnnotation b = (XYPointAnnotation)(ctmnu.Tag);
                scatterGraph1.Annotations.Remove(b);
                xyselectstart.Visible = false;
                xyselectend.Visible = false;

            }
            if (ctmnu.Tag is XYRangeAnnotation)
            {
                XYRangeAnnotation c = (XYRangeAnnotation)(ctmnu.Tag);
                scatterGraph1.Annotations.Remove(c);
                xyselectstart.Visible = false;
                xyselectend.Visible = false;
            }

        }

        private void tsbscreenreader_CheckedChanged(object sender, EventArgs e)
        {
            scatterGraph1.InteractionModeDefault = NationalInstruments.UI.GraphDefaultInteractionMode.None;

            if (tsbscreenreader.Checked == true)
            {
                xyCursorScreen.Visible = true;
                double xValue = (xAxis1.Range.Maximum + xAxis1.Range.Minimum) / 2;
                double yValue = (yAxis1.Range.Maximum + yAxis1.Range.Minimum) / 2;

                xyCursorScreen.MoveCursor(xValue, yValue);

                xyCursorScreen.LabelVisible = true;


            }
            else
            {
                xyCursorScreen.Visible = false;
            }
        }

        private void UserGraph_Load(object sender, EventArgs e)
        {
            toolStrip2.RenderMode = ToolStripRenderMode.System;
        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem != this.tsbdefault)
            {
                tsbdefault.CheckState = CheckState.Unchecked;
            }

            if (e.ClickedItem != this.tsbselector)
            {
                tsbselector.CheckState = CheckState.Unchecked;
            }
            if (e.ClickedItem != tsbarrow)
            {
                tsbarrow.CheckState = CheckState.Unchecked;
            }
            if (e.ClickedItem != this.tsbreader)
            {
                tsbreader.CheckState = CheckState.Unchecked;
            }

            if (e.ClickedItem != this.tsbscreenreader)
            {
                tsbscreenreader.CheckState = CheckState.Unchecked;
            }

            if (e.ClickedItem != this.tsbrect)
            {
                tsbrect.CheckState = CheckState.Unchecked;
            }
            if (e.ClickedItem != this.tsbline)
            {
                tsbline.CheckState = CheckState.Unchecked;
            }
            if (e.ClickedItem != this.tsbtext)
            {
                tsbtext.CheckState = CheckState.Unchecked;
            }

            if (e.ClickedItem != this.tsbzoomout)
            {
                tsbzoomout.CheckState = CheckState.Unchecked;
            }

            if (e.ClickedItem != this.tsbzoomin)
            {
                tsbzoomin.CheckState = CheckState.Unchecked;
            }


        }

        private void xyCursorstart_AfterDraw(object sender, AfterDrawXYCursorEventArgs e)
        {
            PointF f;
            PointF f1;
            double k;
            double x1, y1;

            if (xyCursorstart.Visible == true)
            {

                Graphics g = e.Graphics;


                Rectangle bounds = new Rectangle(e.Bounds.Left, e.Bounds.Top, e.Bounds.Width, e.Bounds.Height);

                using (Brush brush = new SolidBrush(Color.FromArgb(128, xyCursorstart.Color)))
                {



                    k = 20;
                    y1 = 0;


                    x1 = (y1 - xyCursorstart.YPosition) / k + xyCursorstart.XPosition;


                    f = scatterPlot1.MapDataPoint(e.Bounds, xyCursorstart.XPosition, xyCursorstart.YPosition);
                    f1 = scatterPlot1.MapDataPoint(e.Bounds, x1, y1);

                    Pen pf = new Pen(xyCursorstart.Color);

                    //g.DrawLine(pf, f1.X, f1.Y, f.X, f.Y);

                    PointF point1 = new PointF(f.X, f.Y);
                    PointF point2 = new PointF(f.X - 5, f.Y + 5);
                    PointF point3 = new PointF(f.X + 5, f.Y + 5);
                    PointF point4 = new PointF(f.X, f.Y);
                    PointF[] pntArr = { point1, point2, point3, point4 };

                    g.DrawLines(pf, pntArr);
                    g.FillPolygon(brush, pntArr);


                    point1 = new PointF(f.X, f.Y);
                    point2 = new PointF(f.X - 5, f.Y - 5);
                    point3 = new PointF(f.X + 5, f.Y - 5);
                    point4 = new PointF(f.X, f.Y);
                    PointF[] pntArr1 = { point1, point2, point3, point4 };

                    g.DrawLines(pf, pntArr1);
                    g.FillPolygon(brush, pntArr1);
                    pf.Dispose();

                }

            }

        }

        private void xyCursorstart_AfterMove(object sender, AfterMoveXYCursorEventArgs e)
        {
            toollabelshow.Text = "起始光标:" + "X:" + e.XPosition.ToString("G4") + "Y:" + e.YPosition.ToString("G4");
        }

        private void xyCursorend_AfterDraw(object sender, AfterDrawXYCursorEventArgs e)
        {
            PointF f;
            PointF f1;
            double k;
            double x1, y1;

            if (xyCursorend.Visible == true)
            {

                Graphics g = e.Graphics;


                Rectangle bounds = new Rectangle(e.Bounds.Left, e.Bounds.Top, e.Bounds.Width, e.Bounds.Height);


                using (Brush brush = new SolidBrush(Color.FromArgb(128, xyCursorend.Color)))
                {

                    Pen pf = new Pen(xyCursorend.Color);

                    k = 20;
                    y1 = 0;


                    x1 = (y1 - xyCursorend.YPosition) / k + xyCursorend.XPosition;


                    f = scatterPlot1.MapDataPoint(e.Bounds, xyCursorend.XPosition, xyCursorend.YPosition);
                    f1 = scatterPlot1.MapDataPoint(e.Bounds, x1, y1);



                    //g.DrawLine(Pens.Red, f1.X, f1.Y, f.X, f.Y);

                    PointF point1 = new PointF(f.X, f.Y);
                    PointF point2 = new PointF(f.X - 5, f.Y + 5);
                    PointF point3 = new PointF(f.X + 5, f.Y + 5);
                    PointF point4 = new PointF(f.X, f.Y);
                    PointF[] pntArr = { point1, point2, point3, point4 };

                    g.DrawLines(pf, pntArr);
                    g.FillPolygon(brush, pntArr);


                    point1 = new PointF(f.X, f.Y);
                    point2 = new PointF(f.X - 5, f.Y - 5);
                    point3 = new PointF(f.X + 5, f.Y - 5);
                    point4 = new PointF(f.X, f.Y);
                    PointF[] pntArr1 = { point1, point2, point3, point4 };

                    g.DrawLines(pf, pntArr1);
                    g.FillPolygon(brush, pntArr1);

                    pf.Dispose();


                }
            }

        }

        private void xyCursorend_AfterMove(object sender, AfterMoveXYCursorEventArgs e)
        {
            toollabelshow.Text = "结束光标:" + "X:" + e.XPosition.ToString("G4") + "Y:" + e.YPosition.ToString("G4");
        }

        private void xyselectstart_AfterMove(object sender, AfterMoveXYCursorEventArgs e)
        {
            PointF f = new PointF();

            int x; int y;

            if (xyselectstart.Tag is XYPointAnnotation)
            {
                XYPointAnnotation xy = (XYPointAnnotation)(xyselectstart.Tag);
                xy.SetPosition(xyselectstart.XPosition, xyselectstart.YPosition);
                CComLibrary.LineStruct l = xy.Tag as CComLibrary.LineStruct;
                if (l.kind == 0)
                {
                    xy.SetCaptionPosition(xyselectstart.XPosition, xyselectstart.YPosition);
                }
                else
                {
                    xy.SetCaptionPosition(xyselectend.XPosition, xyselectend.YPosition);
                }
            }
            else if (xyselectstart.Tag is XYRangeAnnotation)
            {
                XYRangeAnnotation xy = (XYRangeAnnotation)(xyselectstart.Tag);

                if (xyselectstart.XPosition < xyselectend.XPosition)
                {
                    xy.XRange = new Range(xyselectstart.XPosition, xyselectend.XPosition);
                }
                else
                {
                    xy.XRange = new Range(xyselectend.XPosition, xyselectstart.XPosition);
                }

                if (xyselectstart.YPosition < xyselectend.YPosition)
                {
                    xy.YRange = new Range(xyselectstart.YPosition, xyselectend.YPosition);
                }
                else
                {
                    xy.YRange = new Range(xyselectend.YPosition, xyselectstart.YPosition);
                }


            }
            else if (xyselectstart.Tag is Panel)
            {
                f = scatterPlot1.MapDataPoint(scatterPlot1.GetBounds(), xyselectstart.XPosition, xyselectstart.YPosition);
                (xyselectstart.Tag as Panel).Left = Convert.ToInt16(f.X);
                (xyselectstart.Tag as Panel).Top = Convert.ToInt16(f.Y);
                f = scatterPlot1.MapDataPoint(scatterPlot1.GetBounds(), xyselectend.XPosition, xyselectend.YPosition);
                (xyselectstart.Tag as Panel).Width = Convert.ToInt16(f.X) - (xyselectstart.Tag as Panel).Left;
                (xyselectstart.Tag as Panel).Height = Convert.ToInt16(f.Y) - (xyselectstart.Tag as Panel).Top;


            }
        }

        private void xyselectend_AfterMove(object sender, AfterMoveXYCursorEventArgs e)
        {
            PointF f;
            if (xyselectend.Tag is XYPointAnnotation)
            {
                XYPointAnnotation xy = (XYPointAnnotation)(xyselectend.Tag);
                xy.SetPosition(xyselectstart.XPosition, xyselectstart.YPosition);
                xy.SetCaptionPosition(xyselectend.XPosition, xyselectend.YPosition);

                PointF pf = new PointF();
                pf.X = Convert.ToSingle(xyselectend.XPosition);
                pf.Y = Convert.ToSingle(xyselectend.YPosition);
                CComLibrary.LineStruct l = (CComLibrary.LineStruct)xy.Tag;

                l.pf = pf;
            }
            else if (xyselectend.Tag is XYRangeAnnotation)
            {
                XYRangeAnnotation xy = (XYRangeAnnotation)(xyselectstart.Tag);

                if (xyselectstart.XPosition < xyselectend.XPosition)
                {
                    xy.XRange = new Range(xyselectstart.XPosition, xyselectend.XPosition);
                }
                else
                {
                    xy.XRange = new Range(xyselectend.XPosition, xyselectstart.XPosition);
                }

                if (xyselectstart.YPosition < xyselectend.YPosition)
                {
                    xy.YRange = new Range(xyselectstart.YPosition, xyselectend.YPosition);
                }
                else
                {
                    xy.YRange = new Range(xyselectend.YPosition, xyselectstart.YPosition);
                }


            }
            else if (xyselectstart.Tag is Panel)
            {
                f = scatterPlot1.MapDataPoint(scatterPlot1.GetBounds(), xyselectstart.XPosition, xyselectstart.YPosition);
                (xyselectstart.Tag as Panel).Left = Convert.ToInt16(f.X);
                (xyselectstart.Tag as Panel).Top = Convert.ToInt16(f.Y);
                f = scatterPlot1.MapDataPoint(scatterPlot1.GetBounds(), xyselectend.XPosition, xyselectend.YPosition);
                (xyselectstart.Tag as Panel).Width = Convert.ToInt16(f.X) - (xyselectstart.Tag as Panel).Left;
                (xyselectstart.Tag as Panel).Height = Convert.ToInt16(f.Y) - (xyselectstart.Tag as Panel).Top;


            }

        }

        private void 最大峰值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[] t;
            int starti;
            int endi;
            int i;
            double mmax;
            double mmin;
            int mmaxindex;
            int mminindex;
            if (xyCursorstart.GetCurrentIndex() <= xyCursorend.GetCurrentIndex())
            {
                starti = xyCursorstart.GetCurrentIndex();
                endi = xyCursorend.GetCurrentIndex();
            }
            else
            {
                endi = xyCursorstart.GetCurrentIndex();
                starti = xyCursorend.GetCurrentIndex();
            }
            t = new double[endi - starti + 1];

            for (i = starti; i <= endi; i++)
            {
                t[i - starti] = CComLibrary.GlobeVal.g_datadraw[1][i];
            }
            NationalInstruments.Analysis.Math.ArrayOperation.MaxMin1D(t, out mmax, out mmaxindex, out mmin, out mminindex);
            CComLibrary.LineStruct l = new CComLibrary.LineStruct();
            l.kind = 0;
            l.indexstart = starti + mmaxindex;
            l.xstart = CComLibrary.GlobeVal.g_datadraw[0][l.indexstart];
            l.ystart = CComLibrary.GlobeVal.g_datadraw[1][l.indexstart];
            CComLibrary.GlobeVal.m_listline.Add(l);

            drawsign(l.xstart, l.ystart, l);

            richTextBox1.Text =richTextBox1.Text +("最大峰值=" + l.ystart.ToString()+"\r\n");


            scatterGraph1.Refresh();
        }

        private void 全部峰值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[] amplitudesPeak;
            double[] locationsPeak;
            double[] secondDerivativesPeak;

            double[] t;
            int starti;
            int endi;
            int i;

            int j;
            double threshold;
            starti = xyCursorstart.GetCurrentIndex();
            endi = xyCursorend.GetCurrentIndex();
            t = new double[endi - starti + 1];

            for (i = starti; i <= endi; i++)
            {
                t[i - starti] = CComLibrary.GlobeVal.g_datadraw[1][i];
            }

            PeakPolarity peakPolarity = PeakPolarity.Peaks;

            threshold = ArrayOperation.GetMin(CComLibrary.GlobeVal.g_datadraw[1]);

            NationalInstruments.Analysis.Monitoring.PeakDetector peakDetect
                = new NationalInstruments.Analysis.Monitoring.PeakDetector(threshold, (int)3, peakPolarity);

            peakDetect.Detect(t, true, out amplitudesPeak, out locationsPeak, out secondDerivativesPeak);

            richTextBox1.Text = richTextBox1.Text  + "峰值数量：" + amplitudesPeak.Length.ToString() + "\r\n";

            for (i = 0; i < locationsPeak.Length; i++)
            {
                richTextBox1.Text = richTextBox1.Text  + "峰值位置：" + locationsPeak[i].ToString() + "\r\n";
            }
            for (i = 0; i < locationsPeak.Length; i++)
            {
                j = Convert.ToInt16(locationsPeak[i]);

                CComLibrary.LineStruct l = new CComLibrary.LineStruct();
                l.kind = 0;
                l.indexstart = starti + j;
                l.xstart = CComLibrary.GlobeVal.g_datadraw[0][starti + j];
                l.ystart = CComLibrary.GlobeVal.g_datadraw[1][starti + j];


                CComLibrary.GlobeVal.m_listline.Add(l);

                drawsign(l.xstart, l.ystart, l);

                richTextBox1.Text  = richTextBox1.Text  + "峰值：" + amplitudesPeak[i].ToString() + "\r\n";
            }
            scatterGraph1.Refresh();
        }

        private void 最小谷值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[] t;
            int starti;
            int endi;
            int i;
            double mmax;
            double mmin;
            int mmaxindex;
            int mminindex;

            if (xyCursorstart.GetCurrentIndex() <= xyCursorend.GetCurrentIndex())
            {
                starti = xyCursorstart.GetCurrentIndex();
                endi = xyCursorend.GetCurrentIndex();
            }
            else
            {
                endi = xyCursorstart.GetCurrentIndex();
                starti = xyCursorend.GetCurrentIndex();
            }


            t = new double[endi - starti + 1];

            for (i = starti; i <= endi; i++)
            {
                t[i - starti] = CComLibrary.GlobeVal.g_datadraw[1][i];
            }
            NationalInstruments.Analysis.Math.ArrayOperation.MaxMin1D(t, out mmax, out mmaxindex, out mmin, out mminindex);

            CComLibrary.LineStruct l = new CComLibrary.LineStruct();
            l.kind = 0;
            l.indexstart = starti + mminindex;
            l.xstart = CComLibrary.GlobeVal.g_datadraw[0][starti + mminindex];
            l.ystart = CComLibrary.GlobeVal.g_datadraw[1][starti + mminindex];
            drawsign(l.xstart, l.ystart, l);
            CComLibrary.GlobeVal.m_listline.Add(l);

            richTextBox1.Text =
                 richTextBox1.Text + "最小谷值=" + l.ystart.ToString() + "\r\n";

            scatterGraph1.Refresh();
        }

        private void tsbcontrol_Click(object sender, EventArgs e)
        {
            
        }

        private void 全部谷值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[] amplitudesPeak;
            double[] locationsPeak;
            double[] secondDerivativesPeak;

            double[] t;
            int starti;
            int endi;
            int i;

            int j;
            starti = xyCursorstart.GetCurrentIndex();
            endi = xyCursorend.GetCurrentIndex();
            t = new double[endi - starti + 1];

            double threshold = 0;


            for (i = starti; i <= endi; i++)
            {
                t[i - starti] = CComLibrary.GlobeVal.g_datadraw[1][i];
            }

            PeakPolarity peakPolarity = PeakPolarity.Valleys;

            threshold = ArrayOperation.GetMax(CComLibrary.GlobeVal.g_datadraw[1]);

            NationalInstruments.Analysis.Monitoring.PeakDetector peakDetect
                = new NationalInstruments.Analysis.Monitoring.PeakDetector(threshold, (int)3, peakPolarity);



            peakDetect.Detect(t, true, out amplitudesPeak, out locationsPeak, out secondDerivativesPeak);

            richTextBox1.Text = richTextBox1.Text + "谷值数量：" + amplitudesPeak.Length.ToString() + "\r\n";

            for (i = 0; i < locationsPeak.Length; i++)
            {
                richTextBox1.Text = richTextBox1.Text + "谷值位置：" + locationsPeak[i].ToString() + "\r\n";
            }
            for (i = 0; i < locationsPeak.Length; i++)
            {
                j = Convert.ToInt16(locationsPeak[i]);

                CComLibrary.LineStruct l = new CComLibrary.LineStruct();
                l.kind = 0;
                l.indexstart = starti + j;
                l.xstart = CComLibrary.GlobeVal.g_datadraw[0][starti + j];
                l.ystart = CComLibrary.GlobeVal.g_datadraw[1][starti + j];

                drawsign(l.xstart, l.ystart, l);

                CComLibrary.GlobeVal.m_listline.Add(l);

                richTextBox1.Text = richTextBox1.Text + "谷值：" + amplitudesPeak[i].ToString() + "\r\n";
            }
            scatterGraph1.Refresh();

        }

        private void 平均值所有峰值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[] t;
            int starti;
            int endi;
            int i;
            double mean;
            double stddev;

            if (xyCursorstart.GetCurrentIndex() <= xyCursorend.GetCurrentIndex())
            {
                starti = xyCursorstart.GetCurrentIndex();
                endi = xyCursorend.GetCurrentIndex();
            }
            else
            {
                endi = xyCursorstart.GetCurrentIndex();
                starti = xyCursorend.GetCurrentIndex();
            }


            t = new double[endi - starti + 1];

            for (i = starti; i <= endi; i++)
            {
                t[i - starti] = CComLibrary.GlobeVal.g_datadraw[1][i];
            }
            NationalInstruments.Analysis.Math.ArrayOperation.Normalize1D(t, out mean, out stddev);

            CComLibrary.LineStruct l1 = new CComLibrary.LineStruct();
            l1.kind = 1;

            l1.xstart = CComLibrary.GlobeVal.g_datadraw[0][starti];
            l1.ystart = mean;

            l1.xend = CComLibrary.GlobeVal.g_datadraw[0][endi];
            l1.yend = mean;
            l1.value = mean;

            richTextBox1.Text =
            richTextBox1.Text + "平均值=" + l1.value.ToString() + "\r\n";


            CComLibrary.GlobeVal.m_listline.Add(l1);




            drawmline(l1.xstart, l1.ystart,
                        l1.xend, l1.yend, l1);


            scatterGraph1.Refresh();
        }

        private void tsbtnlineslope_Click(object sender, EventArgs e)
        {
            int starti;
            int endi;
            int i;

            if (xyCursorstart.GetCurrentIndex() <= xyCursorend.GetCurrentIndex())
            {
                starti = xyCursorstart.GetCurrentIndex();
                endi = xyCursorend.GetCurrentIndex();
            }
            else
            {
                endi = xyCursorstart.GetCurrentIndex();
                starti = xyCursorend.GetCurrentIndex();
            }

            CComLibrary.LineStruct l1 = new CComLibrary.LineStruct();
            l1.kind = 1;
            l1.indexstart = starti;
            l1.indexend = endi;



            CComLibrary.GlobeVal.m_listline.Add(l1);



            l1.xstart = CComLibrary.GlobeVal.g_datadraw[0][l1.indexstart];
            l1.ystart = CComLibrary.GlobeVal.g_datadraw[1][l1.indexstart];

            l1.xend = CComLibrary.GlobeVal.g_datadraw[0][l1.indexend];
            l1.yend = CComLibrary.GlobeVal.g_datadraw[1][l1.indexend];

            if (l1.xstart - l1.xend == 0)
            {
                l1.value = 0;
            }
            else
            {
                l1.value = (l1.ystart - l1.yend) / (l1.xstart - l1.xend);
            }


            drawline(l1.xstart, l1.ystart,
                        l1.xend, l1.yend, l1);

            richTextBox1.Text =
                  richTextBox1.Text + "直线斜率=" + l1.value.ToString() + "\r\n";

            scatterGraph1.Refresh();
        }

        private void 水平差值计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int starti;
            int endi;
            int i;

            if (xyCursorstart.GetCurrentIndex() <= xyCursorend.GetCurrentIndex())
            {
                starti = xyCursorstart.GetCurrentIndex();
                endi = xyCursorend.GetCurrentIndex();
            }
            else
            {
                endi = xyCursorstart.GetCurrentIndex();
                starti = xyCursorend.GetCurrentIndex();
            }

            CComLibrary.LineStruct l1 = new CComLibrary.LineStruct();
            l1.kind = 1;
            l1.indexstart = starti;
            l1.indexend = endi;



            CComLibrary.GlobeVal.m_listline.Add(l1);



            l1.xstart = CComLibrary.GlobeVal.g_datadraw[0][l1.indexstart];
            l1.ystart = CComLibrary.GlobeVal.g_datadraw[1][l1.indexstart];

            l1.xend = CComLibrary.GlobeVal.g_datadraw[0][l1.indexend];
            l1.yend = CComLibrary.GlobeVal.g_datadraw[1][l1.indexend];

            l1.value = Math.Abs(l1.xstart - l1.xend);
            richTextBox1.Text =
                  richTextBox1.Text + "水平差值计算=" + l1.value.ToString() + "\r\n";

        }

        private void 垂直差值计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int starti;
            int endi;
            int i;

            if (xyCursorstart.GetCurrentIndex() <= xyCursorend.GetCurrentIndex())
            {
                starti = xyCursorstart.GetCurrentIndex();
                endi = xyCursorend.GetCurrentIndex();
            }
            else
            {
                endi = xyCursorstart.GetCurrentIndex();
                starti = xyCursorend.GetCurrentIndex();
            }

            CComLibrary.LineStruct l1 = new CComLibrary.LineStruct();
            l1.kind = 1;
            l1.indexstart = starti;
            l1.indexend = endi;



            CComLibrary.GlobeVal.m_listline.Add(l1);



            l1.xstart = CComLibrary.GlobeVal.g_datadraw[0][l1.indexstart];
            l1.ystart = CComLibrary.GlobeVal.g_datadraw[1][l1.indexstart];

            l1.xend = CComLibrary.GlobeVal.g_datadraw[0][l1.indexend];
            l1.yend = CComLibrary.GlobeVal.g_datadraw[1][l1.indexend];

            l1.value = Math.Abs(l1.ystart - l1.yend);
            richTextBox1.Text =
                  richTextBox1.Text + "垂直差值计算=" + l1.value.ToString() + "\r\n";
        }

        private void tsbtnclearall_Click(object sender, EventArgs e)
        {

            CComLibrary.GlobeVal.m_listline.Clear();
            scatterGraph1.Annotations.Clear();
            scatterGraph1.Refresh();
        }

        private void scatterGraph1_SizeChanged(object sender, EventArgs e)
        {
           
        }

        private void tsbreader_CheckedChanged(object sender, EventArgs e)
        {
            scatterGraph1.InteractionModeDefault = NationalInstruments.UI.GraphDefaultInteractionMode.None;
            if (tsbreader.Checked == true)
            {
                xyCursor.Visible = true;
                double xValue = (xAxis1.Range.Maximum + xAxis1.Range.Minimum) / 2;
                double yValue = (yAxis1.Range.Maximum + yAxis1.Range.Minimum) / 2;

                xyCursor.MoveCursor(xValue, yValue);

                xyCursor.LabelVisible = true;
            }
            else
            {
                xyCursor.Visible = false;
            }
        }

        private void tsbdefault_Click(object sender, EventArgs e)
        {

        }

        private void 清除内容ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void 曲线设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.mscattergraph = scatterGraph1; 
            FormPlot fp = new FormPlot();
            

            fp.ShowDialog();
        }

        private void tsbarrow_Click(object sender, EventArgs e)
        {

        }

        private void tsbcontrol_CheckedChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Visible)
            {
                richTextBox1.Visible = false;
                scatterGraph1.Visible = true;
            }
            else
            {
                richTextBox1.Visible = true;
                scatterGraph1.Visible = false;
            }
        }
        private PrintPageEventHandler GetPrintPageEventHandler()
        {
            PrintPageEventHandler handler = new PrintPageEventHandler(PrintPageEntireGraph);


            handler = new PrintPageEventHandler(PrintPageEntireGraph);

            return handler;
        }
        private void tsbprint_CheckStateChanged(object sender, EventArgs e)
        {
         
        }

        private void tsbprint_Click(object sender, EventArgs e)
        {
            using (PrintDocument document = new PrintDocument())
            {
                if (document.PrinterSettings.IsValid)
                {
                    document.PrintPage += GetPrintPageEventHandler();
                    document.DefaultPageSettings.Landscape = true;
                    graphPrintPreviewDialog.Document = document;

                    graphPrintPreviewDialog.ShowDialog(this);


                }
                else
                {
                    MessageBox.Show(this, new InvalidPrinterException(document.PrinterSettings).Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbmultiline_Click(object sender, EventArgs e)
        {

            richTextBox1.Visible = false;
            scatterGraph1.Visible = true;

            if (legend.Visible)
            {
                legend.Visible = false ;
                legend.BringToFront();
                scatterGraph1.BringToFront();

               
                scatterGraph1.ClearData();
                CComLibrary.GlobeVal.m_listline.Clear();
                scatterGraph1.Annotations.Clear();

                tsbreadcurve.Visible = false ;

                curvescount = 0;

                for(int i=0;i<legend.Items.Count;i++)
                {
                    legend.Items[i].Visible = false;
                }

                tsbselector.Visible = true ;
                tsbscreenreader.Visible = true;
                tsbcontrol.Visible = true;
                toolStripbar.Visible = true ;

                firstread = false ;

            }
            else
            {
                legend.Visible = true;
                legend.BringToFront();
                scatterGraph1.BringToFront();

               
                scatterGraph1.ClearData();
                CComLibrary.GlobeVal.m_listline.Clear();
                scatterGraph1.Annotations.Clear();
                tsbreadcurve.Visible = true ;
                curvescount = 0;

                for (int i = 0; i < legend.Items.Count; i++)
                {
                    legend.Items[i].Visible = false;
                }

                toolStripbar.Visible =false;

                tsbselector.Visible = false ;
                tsbscreenreader.Visible = false ;
                tsbcontrol.Visible = false;

                firstread = false;

            }
        }

        private void tsbmultiline_CheckedChanged(object sender, EventArgs e)
        {
           
           

        }

        private void tsbreadcurve_Click(object sender, EventArgs e)
        {

            if (curvescount >=8)
            {
                MessageBox.Show("最多只能叠加8条曲线");
                return;
            }

            CustomControls.TxtOpenFileDialog openFileDialog1 = new CustomControls.TxtOpenFileDialog();

            curvescount = curvescount + 1;

            openFileDialog1.OpenDialog.InitialDirectory = this.datapath;



            openFileDialog1.firstread = firstread;

            if (firstread==true)
            {
                openFileDialog1.xchsel = xfirstsel;
                openFileDialog1.ychsel = yfirstsel;
                openFileDialog1.cbox.Enabled = false ;
                openFileDialog1.cboy.Enabled = false ;
            }
            else
            {
                openFileDialog1.cbox.Enabled = true  ;
                openFileDialog1.cboy.Enabled = true  ;
            }

            openFileDialog1.OpenDialog.FileName = "";
            openFileDialog1.OpenDialog.Filter = "文本文件(*.txt)|*.txt";
            //openFileDialog1.Filter = "所有文件(*.*)|*.*|文本文件(*.txt)|*.txt|log文件(*.log)|*.log";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.OpenDialog.FileName == null)
            {

                return;
            }
            else
            {
                string fileName = openFileDialog1.OpenDialog.FileName;



                if (openFileDialog1.good ==true)
                {
                    if (fileName =="")
                    {

                    }
                    else

                    {

                       
                    

                      
                        string firstline = "";
                        string secondline = "";
                        int i = 0;
                        bool r = true;
                        char[] sp;
                        char[] sp1;
                        string[] ww;
                        string[] ww1;
                        int xchsel = 0;
                        int ychsel = 0;

                        double x=0;
                        double y=0;

                        sp = new char[2];
                        sp1 = new char[2];

                        sp[0] = Convert.ToChar(" ");
                        xchsel = openFileDialog1.xchsel;
                        ychsel = openFileDialog1.ychsel;
                        if (firstread == false)
                        {
                            xfirstsel = xchsel;
                            yfirstsel = ychsel;

                        }

                       
                        scatterGraph1.Plots[curvescount - 1].ClearData();
                        StreamReader m_streamReader = new StreamReader(fileName, System.Text.Encoding.Default);
                        try
                        {
                            //使用StreamReader类来读取文件
                            m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                            // 从数据流中读取每一行，直到文件的最后一行，并在richTextBox1中显示出内容
                           
                            string strLine = m_streamReader.ReadLine();
                            firstline = strLine;
                            strLine = m_streamReader.ReadLine();
                            secondline = strLine;
                            strLine = m_streamReader.ReadLine();


                            ww = firstline.Split(sp);
                            ww1 = secondline.Split(sp);
                            scatterGraph1.XAxes[0].Caption = ww[xchsel]+"["+ww1[xchsel]+"]";
                            scatterGraph1.YAxes[0].Caption = ww[ychsel]+"["+ww1[ychsel]+"]";


                            while (r == true)
                            {

                                
                                ww = strLine.Split(sp);

                                x = Convert.ToDouble(ww[xchsel]);
                                y = Convert.ToDouble(ww[ychsel]);

                                scatterGraph1.Plots[curvescount - 1].PlotXYAppend(x, y);

                                strLine = m_streamReader.ReadLine();

                                if (strLine == null)
                                {
                                    r = false;

                                }

                                i = i + 1;
                                
                            }
                            //关闭此StreamReader对象
                            m_streamReader.Close();

                            legend.Items[curvescount - 1].Visible = true;
                           // legend.Items[curvescount - 1].Text = fileName;
                           

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        firstread = true;
                        // MessageBox.Show(fileName);
                    }
                }
                else
                {


                    MessageBox.Show("数据格式不兼容");

                }
            }
        }
    }
}
