using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TabHeaderDemo
{
    public partial class UserControl曲线 : UserControl
    {
        public UserControlMethod musercontrolmethod;

        private CComLibrary.PlotSettings myplotsettings;
        public int curvetab = 0;



        private int mcurveselect = 0;

        public void Init曲线类型()
        {



            if (myplotsettings.curvekind == 0)
            {
                radioButton1.Checked = true;
            }
            if (myplotsettings.curvekind == 1)
            {
                radioButton2.Checked = true;
            }
            if (myplotsettings.curvekind == 2)
            {
                radioButton3.Checked = true;
            }

            txtcurveaption_kind1.Text = myplotsettings.curvekind1_curvecaption;
            if (myplotsettings.curvecount <= 0)
            {
                myplotsettings.curvecount = 1;
            }
            numcount.Value = myplotsettings.curvecount;

            cbooffset.Items.Clear();
            cbooffset.Items.Add("无");
            cbooffset.Items.Add("X轴");
            cbooffset.Items.Add("Y轴");
            cbooffset.Items.Add("XY轴");
            cbooffset.SelectedIndex = myplotsettings.curveoffset;

            chkshowinvalidspe.Checked = myplotsettings.showinvalidspe;

            chkdatapoint.Checked = myplotsettings.showdatapointer;

            chkdynamic.Checked = myplotsettings.dynamicdraw;
            numdynamic.Value = myplotsettings.dynamicpointcount;

        }

        public void InitX轴数据()
        {


            cboxchannel.Items.Clear();
            for (int i = 0; i < ClsStaticStation.m_Global.mycls.allsignals.Count; i++)
            {

                cboxchannel.Items.Add(ClsStaticStation.m_Global.mycls.allsignals[i].cName);

            }

            if ((myplotsettings.xchannel >= 0) && (myplotsettings.xchannel < cboxchannel.Items.Count))
            {
                cboxchannel.SelectedIndex = myplotsettings.xchannel;
            }
            else
            {
                myplotsettings.xchannel = 0;
                cboxchannel.SelectedIndex = myplotsettings.xchannel;
            }
            cboxchannelunit.Items.Clear();
            for (int i = 0; i < ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.xchannel].cUnitCount; i++)
            {
                cboxchannelunit.Items.Add(ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.xchannel].cUnits[i]);
            }

            if ((myplotsettings.xchannelunit >= 0) && (myplotsettings.xchannelunit < cboxchannelunit.Items.Count))
            {
                cboxchannelunit.SelectedIndex = myplotsettings.xchannelunit;
            }

            this.scatterGraph1.XAxes[0].Caption = ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.xchannel].cName + "[" +
                ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.xchannel].cUnits[myplotsettings.xchannelunit] + "]";




            if (myplotsettings.xchannelzoom == true)
            {
                rdbxautozoom.Checked = true;
            }
            else
            {
                rdbxhandzoom.Checked = true;
            }

            numxmax.Value = myplotsettings.xmax;
            numxmin.Value = myplotsettings.xmin;
           

        }

        public void InitY轴数据()
        {
            if (myplotsettings.curvekind == 0)
            {
                cbocurve.Items.Clear();


                cbocurve.Items.Add(1.ToString().Trim());


                cbocurve.SelectedIndex = 0;
                grpydefine.Text = "Y轴定义";
                this.grpyscale.Text = "Y轴缩放比例";

                grpy1define.Visible = false;
                grpy1scale.Visible = false;

                lblY轴.Visible = false;
                cbocurve.Visible = false;
            }
            else if (myplotsettings.curvekind == 1)
            {

                cbocurve.Items.Clear();


                cbocurve.Items.Add(1.ToString().Trim());


                cbocurve.SelectedIndex = 0;


                grpydefine.Text = "左侧Y轴定义";
                this.grpyscale.Text = "左侧Y轴缩放比例";
                grpy1define.Text = "右侧Y轴定义";
                grpy1scale.Text = "右侧Y轴缩放比例";

                grpy1define.Visible = true;
                grpy1scale.Visible = true;

                lblY轴.Visible = false;
                cbocurve.Visible = false;

                cboy1channel.Items.Clear();
                for (int i = 0; i < ClsStaticStation.m_Global.mycls.allsignals.Count; i++)
                {

                    cboy1channel.Items.Add(ClsStaticStation.m_Global.mycls.allsignals[i].cName);

                }

                if ((myplotsettings.y1channel >= 0) && (myplotsettings.y1channel < cboy1channel.Items.Count))
                {
                    cboy1channel.SelectedIndex = myplotsettings.y1channel;
                }

                cboy1channelunit.Items.Clear();
                for (int i = 0; i < ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.y1channel].cUnitCount; i++)
                {
                    cboy1channelunit.Items.Add(ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.y1channel].cUnits[i]);
                }

                if ((myplotsettings.y1channelunit >= 0) && (myplotsettings.y1channelunit < cboy1channelunit.Items.Count))
                {
                    cboy1channelunit.SelectedIndex = myplotsettings.y1channelunit;
                }




                this.scatterGraph1.YAxes[1].Caption = ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.y1channel].cName + "[" +
                  ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.y1channel].cUnits[myplotsettings.y1channelunit] + "]";



                if (myplotsettings.y1channelzoom == true)
                {
                    rdby1autozoom.Checked = true;
                }
                else
                {
                    rdby1handzoom.Checked = true;
                }
            }
            else
            {
                grpydefine.Text = "Y轴定义";
                this.grpyscale.Text = "Y轴缩放比例";


                grpy1define.Visible = false;
                grpy1scale.Visible = false;

                lblY轴.Visible = true;
                cbocurve.Visible = true;

                cbocurve.Items.Clear();

                for (int i = 0; i < myplotsettings.curvecount; i++)
                {
                    cbocurve.Items.Add((i+1).ToString().Trim());
                }

                cbocurve.SelectedIndex = 0;


                cboy1channel.Items.Clear();
                for (int i = 0; i < ClsStaticStation.m_Global.mycls.allsignals.Count; i++)
                {

                    cboy1channel.Items.Add(ClsStaticStation.m_Global.mycls.allsignals[i].cName);

                }

                if ((myplotsettings.y1channel >= 0) && (myplotsettings.y1channel < cboy1channel.Items.Count))
                {
                    cboy1channel.SelectedIndex = myplotsettings.y1channel;
                }

                cboy1channelunit.Items.Clear();
                for (int i = 0; i < ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.y1channel].cUnitCount; i++)
                {
                    cboy1channelunit.Items.Add(ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.y1channel].cUnits[i]);
                }

                if ((myplotsettings.y1channelunit >= 0) && (myplotsettings.y1channelunit < cboy1channelunit.Items.Count))
                {
                    cboy1channelunit.SelectedIndex = myplotsettings.y1channelunit;
                }




                this.scatterGraph1.YAxes[1].Caption = ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.y1channel].cName + "[" +
                  ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.y1channel].cUnits[myplotsettings.y1channelunit] + "]";



                if (myplotsettings.y1channelzoom == true)
                {
                    rdby1autozoom.Checked = true;
                }
                else
                {
                    rdby1handzoom.Checked = true;
                }

            }

            cboychannel.Items.Clear();
            for (int i = 0; i < ClsStaticStation.m_Global.mycls.allsignals.Count; i++)
            {

                cboychannel.Items.Add(ClsStaticStation.m_Global.mycls.allsignals[i].cName);

            }

            if ((myplotsettings.ychannel[cbocurve.SelectedIndex] >= 0) && (myplotsettings.ychannel[cbocurve.SelectedIndex] < cboychannel.Items.Count))
            {
                cboychannel.SelectedIndex = myplotsettings.ychannel[cbocurve.SelectedIndex];
            }
            else
            {
                myplotsettings.ychannel[cboy1channel.SelectedIndex] = 0;
                cboychannel.SelectedIndex = myplotsettings.ychannel[cbocurve.SelectedIndex];
            }



            cboychannelunit.Items.Clear();
            for (int i = 0; i < ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.ychannel[cbocurve.SelectedIndex]].cUnitCount; i++)
            {
                cboychannelunit.Items.Add(ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.ychannel[cbocurve.SelectedIndex]].cUnits[i]);
            }

            if ((myplotsettings.ychannelunit[cbocurve.SelectedIndex] >= 0) && (myplotsettings.ychannelunit[cbocurve.SelectedIndex] < cboychannelunit.Items.Count))
            {
                cboychannelunit.SelectedIndex = myplotsettings.ychannelunit[cbocurve.SelectedIndex];
            }

            this.scatterGraph1.YAxes[0].Caption = ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.ychannel[cbocurve.SelectedIndex]].cName + "[" +
            ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.ychannel[cbocurve.SelectedIndex]].cUnits[myplotsettings.ychannelunit[cbocurve.SelectedIndex]] + "]";


            if (myplotsettings.ychannelzoom == true)
            {
                rdbyautozoom.Checked = true;
            }
            else
            {
                rdbyhandzoom.Checked = true;
            }

            numymax.Value = myplotsettings.ymax;
            numymin.Value = myplotsettings.ymin;
            numy1max.Value = myplotsettings.y1max;
            numy1min.Value = myplotsettings.y1min;
        }


        public void Init高级()
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("曲线图外观");
            listBox1.Items.Add("网格线");
            listBox1.Items.Add("X 轴");
            listBox1.Items.Add("Y 轴");
            listBox1.Items.Add("图例设置");
            listBox1.Items.Add("图例外观");
            listBox1.Items.Add("标记类型");
            listBox1.Items.Add("构造线类型");
            //listBox1.Items.Add("PIP 线");

            scatterGraph1.Plots.Clear();
            legend3.Items.Clear();
            NationalInstruments.UI.ScatterPlot mplot;
            NationalInstruments.UI.LegendItem mlegitem;
            if (myplotsettings.curvekind == 0)
            {
                scatterGraph1.YAxes[0].Visible = true;
                scatterGraph1.YAxes[1].Visible = false;

                for (int i = 0; i < myplotsettings.curvecount; i++)
                {
                    listBox1.Items.Add("曲线 " + (i + 1).ToString().Trim());
                    mplot = new NationalInstruments.UI.ScatterPlot();
                    mplot.LineColor = myplotsettings.PlotLineColor[i];
                    mplot.LineStyle = myplotsettings.PlotLineStyle[i];
                    mplot.PointStyle = myplotsettings.PlotLinePointStyle[i];
                    mplot.PointSize = new Size(myplotsettings.PlotLineSize[i], myplotsettings.PlotLineSize[i]);
                    mplot.PointColor = myplotsettings.PlotLinePointColor[i];
                    mplot.LineWidth = myplotsettings.PlotLinePointSize[i];
                    scatterGraph1.Plots.Add(mplot);

                    mplot.ClearData();
                    mplot.PlotXYAppend(0 + i * 0.2, 0);
                    mplot.PlotXYAppend(2 + i * 0.2, 4);
                    mplot.PlotXYAppend(8 + i * 0.2, 9);
                    mlegitem = new NationalInstruments.UI.LegendItem();
                    mlegitem.Source = mplot;
                    mlegitem.Text = (i + 1).ToString().Trim();
                    legend3.Items.Add(mlegitem);


                }

                if (myplotsettings.curvecount >= 2)
                {
                    scatterGraph1.Plots[1].YAxis = yAxis1;

                }
            }


            if (myplotsettings.curvekind == 1)
            {
                int i;

                scatterGraph1.YAxes[0].Visible = true;
                scatterGraph1.YAxes[1].Visible = true;

                i = 0;
                listBox1.Items.Add("左轴曲线 ");
                mplot = new NationalInstruments.UI.ScatterPlot();
                mplot.LineColor = myplotsettings.PlotLineColor[i];
                mplot.LineStyle = myplotsettings.PlotLineStyle[i];
                mplot.PointStyle = myplotsettings.PlotLinePointStyle[i];
                mplot.PointSize = new Size(myplotsettings.PlotLineSize[i], myplotsettings.PlotLineSize[i]);
                mplot.PointColor = myplotsettings.PlotLinePointColor[i];
                mplot.LineWidth = myplotsettings.PlotLinePointSize[i];
                scatterGraph1.Plots.Add(mplot);

                mplot.ClearData();
                mplot.PlotXYAppend(0 + i * 0.2, 0);
                mplot.PlotXYAppend(2 + i * 0.2, 4);
                mplot.PlotXYAppend(8 + i * 0.2, 9);
                mlegitem = new NationalInstruments.UI.LegendItem();
                mlegitem.Source = mplot;
                mlegitem.Text = (i + 1).ToString().Trim();
                legend3.Items.Add(mlegitem);

                i = 1;
                listBox1.Items.Add("右轴曲线 ");
                mplot = new NationalInstruments.UI.ScatterPlot();
                mplot.LineColor = myplotsettings.PlotLineColor[i];
                mplot.LineStyle = myplotsettings.PlotLineStyle[i];
                mplot.PointStyle = myplotsettings.PlotLinePointStyle[i];
                mplot.PointSize = new Size(myplotsettings.PlotLineSize[i], myplotsettings.PlotLineSize[i]);
                mplot.PointColor = myplotsettings.PlotLinePointColor[i];
                mplot.LineWidth = myplotsettings.PlotLinePointSize[i];
                scatterGraph1.Plots.Add(mplot);

                mplot.ClearData();
                mplot.PlotXYAppend(0 + i * 0.2, 0);
                mplot.PlotXYAppend(2 + i * 0.2, 4);
                mplot.PlotXYAppend(8 + i * 0.2, 9);
                mlegitem = new NationalInstruments.UI.LegendItem();
                mlegitem.Source = mplot;
                mlegitem.Text = (i + 1).ToString().Trim();
                legend3.Items.Add(mlegitem);

                mplot.YAxis = yAxis2;


            }

            if (myplotsettings.curvekind == 2)
            {
                scatterGraph1.YAxes[0].Visible = true;
                scatterGraph1.YAxes[1].Visible = false;

                for (int i = 0; i < myplotsettings.curvecount; i++)
                {
                    listBox1.Items.Add("曲线 " + (i + 1).ToString().Trim());
                    mplot = new NationalInstruments.UI.ScatterPlot();
                    mplot.LineColor = myplotsettings.PlotLineColor[i];
                    mplot.LineStyle = myplotsettings.PlotLineStyle[i];
                    mplot.PointStyle = myplotsettings.PlotLinePointStyle[i];
                    mplot.PointSize = new Size(myplotsettings.PlotLineSize[i], myplotsettings.PlotLineSize[i]);
                    mplot.PointColor = myplotsettings.PlotLinePointColor[i];
                    mplot.LineWidth = myplotsettings.PlotLinePointSize[i];
                    scatterGraph1.Plots.Add(mplot);

                    mplot.ClearData();
                    mplot.PlotXYAppend(0 + i * 0.2, 0);
                    mplot.PlotXYAppend(2 + i * 0.2, 4);
                    mplot.PlotXYAppend(8 + i * 0.2, 9);
                    mlegitem = new NationalInstruments.UI.LegendItem();
                    mlegitem.Source = mplot;
                    mlegitem.Text = (i + 1).ToString().Trim();
                    legend3.Items.Add(mlegitem);


                }

                if (myplotsettings.curvecount >= 2)
                {
                    scatterGraph1.Plots[1].YAxis = yAxis1;

                }
            }


            listBox1.SelectedIndex = 0;


            Apply高级();
        }
        public void Init(int sel)
        {

            tabControl1.SelectedIndex = sel;

            if (GlobeVal.UserControlMain1.btnmtest.Visible == true)
            {
                tabControl1.Enabled = false;
            }
            else
            {
                tabControl1.Enabled = true;
            }

            myplotsettings = new CComLibrary.PlotSettings();

            if (curvetab == 0)
            {
                myplotsettings = CComLibrary.GlobeVal.filesave.mplotpara1;



            }

            if (curvetab == 1)
            {
                myplotsettings = CComLibrary.GlobeVal.filesave.mplotpara2;

            }



            if (curvetab == 0)
            {
                lbltitle0.Text = "设置曲线1类型";
                lbltitle1.Text = "设置曲线1-X轴数据";
                lbltitle2.Text = "设置曲线1-Y轴数据";
                lbltitle3.Text = "设置曲线1-高级项目";

            }


            if (curvetab == 1)
            {
                lbltitle0.Text = "设置曲线2类型";
                lbltitle1.Text = "设置曲线2-X轴数据";
                lbltitle2.Text = "设置曲线2-Y轴数据";
                lbltitle3.Text = "设置曲线2-高级项目";

            }

            if (sel == 0)

            {
                Init曲线类型();
            }

            if (sel == 1)
            {
                InitX轴数据();
            }

            if (sel == 2)
            {
                InitY轴数据();
            }

            if (sel == 3)
            {
                Init高级();
            }


        }
        public UserControl曲线()
        {
            InitializeComponent();
            tabControl1.ItemSize = new Size(1, 1);
            tabControl2.ItemSize = new Size(1, 1);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                tlpkind1.Visible = true;
                tlpkind2.Visible = false;

                myplotsettings.curvekind = 0;

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                tlpkind1.Visible = false;
                tlpkind2.Visible = true;

                myplotsettings.curvekind = 1;
            }
        }

        private void tableLayoutPanel11_SizeChanged(object sender, EventArgs e)
        {


        }

        private void panel8_SizeChanged(object sender, EventArgs e)
        {

        }

        private void panel7_SizeChanged(object sender, EventArgs e)
        {
            tabControl2.Top = -5;
            tabControl2.Left = 0;
            tabControl2.Width = panel7.ClientSize.Width;
            tabControl2.Height = panel7.ClientSize.Height + 5;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                lblcaption.Text = listBox1.Items[listBox1.SelectedIndex].ToString();
                if ((listBox1.SelectedIndex >= 0) && (listBox1.SelectedIndex <= 7))
                {
                    tabControl2.SelectedIndex = listBox1.SelectedIndex;
                }
                else
                {
                    mcurveselect = listBox1.SelectedIndex - 8;
                    tabControl2.SelectedIndex = 9;
                }
            }
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void Apply高级()
        {
            scatterGraph1.BackColor = this.myplotsettings.backcolor;
            tableLayoutPanelCurve.BackColor = this.myplotsettings.backcolor;
            scatterGraph1.PlotAreaColor = this.myplotsettings.backcolor;
            scatterGraph1.CaptionBackColor = this.myplotsettings.backcolor;

            scatterGraph1.XAxes[0].BaseLineColor = this.myplotsettings.axiscolor;
            scatterGraph1.XAxes[0].OriginLineColor = this.myplotsettings.axiscolor;
            scatterGraph1.XAxes[0].MajorDivisions.LabelForeColor = this.myplotsettings.axiscolor;
            scatterGraph1.XAxes[0].MajorDivisions.TickColor = this.myplotsettings.axiscolor;
            scatterGraph1.XAxes[0].BaseLineVisible = true;

            if (myplotsettings.curvekind == 0)
            {
                yAxis2.BaseLineColor = this.myplotsettings.axiscolor;
                yAxis2.BaseLineVisible = true;
                yAxis2.MajorDivisions.LabelVisible = false;
                yAxis2.MajorDivisions.TickVisible = false;
                yAxis2.CaptionVisible = false;

            }
            else
            {

                yAxis2.BaseLineColor = this.myplotsettings.axiscolor;
                yAxis2.BaseLineVisible = true;
                yAxis2.OriginLineColor = this.myplotsettings.axiscolor;
                yAxis2.MajorDivisions.LabelForeColor = this.myplotsettings.axiscolor;
                yAxis2.MajorDivisions.TickColor = this.myplotsettings.axiscolor;
                yAxis2.MajorDivisions.LabelVisible = true;
                yAxis2.MajorDivisions.TickVisible = true;
                yAxis2.CaptionVisible = true;

            }

            xAxis2.BaseLineColor = this.myplotsettings.axiscolor;
            xAxis2.BaseLineVisible = true;

            scatterGraph1.YAxes[0].BaseLineColor = this.myplotsettings.axiscolor;
            scatterGraph1.YAxes[0].BaseLineVisible = true;
            scatterGraph1.YAxes[0].MajorDivisions.TickColor = this.myplotsettings.axiscolor;
            scatterGraph1.YAxes[0].OriginLineColor = this.myplotsettings.axiscolor;
            scatterGraph1.YAxes[0].MajorDivisions.LabelForeColor = this.myplotsettings.axiscolor;
            if (this.myplotsettings.CurveCaptionfont != null)
            {
                scatterGraph1.CaptionFont = new Font(this.myplotsettings.CurveCaptionfont.FontFamily, this.myplotsettings.CurveCaptionfont.Size);
            }

            if (this.myplotsettings.AxisCaptionFont != null)
            {
                scatterGraph1.XAxes[0].CaptionFont = new Font(this.myplotsettings.AxisCaptionFont.FontFamily, this.myplotsettings.AxisCaptionFont.Size);

                scatterGraph1.YAxes[0].CaptionFont = new Font(this.myplotsettings.AxisCaptionFont.FontFamily, this.myplotsettings.AxisCaptionFont.Size);
            }

            if (this.myplotsettings.AxisFont != null)
            {
                scatterGraph1.XAxes[0].MajorDivisions.LabelFont = new Font(this.myplotsettings.AxisFont.FontFamily, this.myplotsettings.AxisFont.Size);
                scatterGraph1.YAxes[0].MajorDivisions.LabelFont = new Font(this.myplotsettings.AxisFont.FontFamily, this.myplotsettings.AxisFont.Size);

            }


            scatterGraph1.XAxes[0].MajorDivisions.GridVisible = this.myplotsettings.ShowGrid;
            scatterGraph1.YAxes[0].MajorDivisions.GridVisible = this.myplotsettings.ShowGrid;

            NationalInstruments.UI.LineStyle p = default(NationalInstruments.UI.LineStyle);
            ;
            this.myplotsettings.SetGridLineStyle(ref p);

            scatterGraph1.XAxes[0].MajorDivisions.GridLineStyle = p;

            scatterGraph1.YAxes[0].MajorDivisions.GridLineStyle = p;



            scatterGraph1.XAxes[0].MajorDivisions.GridColor = this.myplotsettings.GridLineColor;
            scatterGraph1.YAxes[0].MajorDivisions.GridColor = this.myplotsettings.GridLineColor;
            if (this.myplotsettings.XCaption == true)
            {
                scatterGraph1.XAxes[0].CaptionVisible = true;
            }
            else
            {
                scatterGraph1.XAxes[0].CaptionVisible = false;
            }

            if (this.myplotsettings.Xlog == false)
            {
                scatterGraph1.XAxes[0].ScaleType = NationalInstruments.UI.ScaleType.Linear;

            }
            else
            {
                scatterGraph1.XAxes[0].ScaleType = NationalInstruments.UI.ScaleType.Logarithmic;

            }

            scatterGraph1.XAxes[0].Inverted = this.myplotsettings.Xrevert;

            if (this.myplotsettings.YCaption == true)
            {
                scatterGraph1.YAxes[0].CaptionVisible = true;
                scatterGraph1.YAxes[1].CaptionVisible = true;
            }
            else
            {
                scatterGraph1.YAxes[0].CaptionVisible = false;
                scatterGraph1.YAxes[1].CaptionVisible = false;
            }



            if (this.myplotsettings.Ylog == false)
            {

                scatterGraph1.YAxes[0].ScaleType = NationalInstruments.UI.ScaleType.Linear;
            }
            else
            {

                scatterGraph1.YAxes[0].ScaleType = NationalInstruments.UI.ScaleType.Logarithmic;
            }


            scatterGraph1.YAxes[0].Inverted = this.myplotsettings.Yrevert;


            if (this.myplotsettings.showLegend == true)
            {
                tableLayoutPanelCurve.ColumnStyles[1].Width = 90;
            }
            else
            {
                tableLayoutPanelCurve.ColumnStyles[1].Width = 0;
            }

            if (this.myplotsettings.showlegendborder == true)
            {
                this.legend3.Border = NationalInstruments.UI.Border.Solid;
            }
            else
            {
                this.legend3.Border = NationalInstruments.UI.Border.None;
            }

            this.legend3.BackColor = this.myplotsettings.LegendBackColor;

            this.legend3.Font = this.myplotsettings.LegendFont;

            NationalInstruments.UI.ShapeStyle p1 = default(NationalInstruments.UI.ShapeStyle);

            this.myplotsettings.SetSignPointStyle(ref p1);

            this.xyPointAnnotation1.ShapeStyle = p1;

            if (this.myplotsettings.SignPointSize <= 0)
            {
                this.myplotsettings.SignPointSize = 1;
            }

            this.xyPointAnnotation1.ShapeSize = new Size(this.myplotsettings.SignPointSize, this.myplotsettings.SignPointSize);

            this.xyPointAnnotation1.ShapeFillColor = this.myplotsettings.SignPointColor;

            NationalInstruments.UI.LineStyle p2 = default(NationalInstruments.UI.LineStyle);
            this.myplotsettings.SetSignLineStyle(ref p2);

            this.xyPointAnnotation2.ArrowLineStyle = p2;

            this.xyPointAnnotation2.ArrowColor = this.myplotsettings.SignLineColor;

            if (myplotsettings.PlotLineStyleName == null)
            {
                myplotsettings.PlotLineStyleName = new string[16];

                for (int i = 0; i < 16; i++)
                {
                    myplotsettings.PlotLineStyleName[i] = "";
                }
            }

            if (myplotsettings.PlotLinePointStyleName == null)
            {
                myplotsettings.PlotLinePointStyleName = new string[16];




            }

            if (myplotsettings.PlotLinePointSize == null)
            {
                myplotsettings.PlotLinePointSize = new int[16];
            }

            NationalInstruments.UI.PointStyle p3 = default(NationalInstruments.UI.PointStyle);

            if (myplotsettings.curvekind == 0)
            {
                for (int i = 0; i < myplotsettings.curvecount; i++)
                {
                    this.myplotsettings.SetPlotLineStyle(ref p2, i);
                    this.scatterGraph1.Plots[i].LineStyle = p2;


                    this.scatterGraph1.Plots[i].LineColor = myplotsettings.PlotLineColor[i];


                    this.myplotsettings.SetPlotLinePointStyle(ref p3, i);
                    this.scatterGraph1.Plots[i].PointStyle = p3;

                    if (myplotsettings.PlotLineSize[i] <= 0)
                    {
                        myplotsettings.PlotLineSize[i] = 4;
                    }

                    if (myplotsettings.PlotLinePointSize[i] <= 0)
                    {
                        myplotsettings.PlotLinePointSize[i] = 1;
                    }
                    this.scatterGraph1.Plots[i].PointSize = new Size(myplotsettings.PlotLineSize[i], myplotsettings.PlotLineSize[i]);

                }
            }
            if (myplotsettings.curvekind == 1)
            {
                for (int i = 0; i < 2; i++)
                {
                    this.myplotsettings.SetPlotLineStyle(ref p2, i);
                    this.scatterGraph1.Plots[i].LineStyle = p2;


                    this.scatterGraph1.Plots[i].LineColor = myplotsettings.PlotLineColor[i];


                    this.myplotsettings.SetPlotLinePointStyle(ref p3, i);
                    this.scatterGraph1.Plots[i].PointStyle = p3;

                    if (myplotsettings.PlotLineSize[i] <= 0)
                    {
                        myplotsettings.PlotLineSize[i] = 4;
                    }

                    if (myplotsettings.PlotLinePointSize[i] <= 0)
                    {
                        myplotsettings.PlotLinePointSize[i] = 1;
                    }
                    this.scatterGraph1.Plots[i].PointSize = new Size(myplotsettings.PlotLineSize[i], myplotsettings.PlotLineSize[i]);

                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormPlotSet f = new FormPlotSet();
            f.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(this.myplotsettings, "backcolor");

            f.ShowDialog();

            this.myplotsettings.backcolor = (Color)f.propertyEditor1.Source.Value;


            Apply高级();
            f.Dispose();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormPlotSet f = new FormPlotSet();

            NationalInstruments.UI.LineStyle p = default(NationalInstruments.UI.LineStyle);
            this.myplotsettings.SetGridLineStyle(ref p);
            this.myplotsettings.GridLineStyle = p;

            f.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(this.myplotsettings, "GridLineStyle");

            f.ShowDialog();

            this.myplotsettings.GridLineStyleName = ((NationalInstruments.UI.LineStyle)f.propertyEditor1.Source.Value).Name;


            Apply高级();

            f.Dispose();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormPlotSet f = new FormPlotSet();
            f.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(this.myplotsettings, "axiscolor");

            f.ShowDialog();

            this.myplotsettings.axiscolor = (Color)f.propertyEditor1.Source.Value;


            Apply高级();
            f.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormPlotSet f = new FormPlotSet();
            f.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(this.myplotsettings, "CurveCaptionfont");

            f.ShowDialog();

            this.myplotsettings.CurveCaptionfont = (Font)f.propertyEditor1.Source.Value;


            Apply高级();
            f.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormPlotSet f = new FormPlotSet();
            f.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(this.myplotsettings, "AxisCaptionFont");

            f.ShowDialog();

            this.myplotsettings.AxisCaptionFont = (Font)f.propertyEditor1.Source.Value;


            Apply高级();
            f.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormPlotSet f = new FormPlotSet();
            f.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(this.myplotsettings, "AxisFont");

            f.ShowDialog();

            this.myplotsettings.AxisFont = (Font)f.propertyEditor1.Source.Value;


            Apply高级();
            f.Dispose();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormPlotSet f = new FormPlotSet();
            f.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(this.myplotsettings, "ShowGrid");

            f.ShowDialog();

            this.myplotsettings.ShowGrid = (Boolean)f.propertyEditor1.Source.Value;


            Apply高级();
            f.Dispose();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormPlotSet f = new FormPlotSet();
            f.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(this.myplotsettings, "GridLineColor");

            f.ShowDialog();

            this.myplotsettings.GridLineColor = (Color)f.propertyEditor1.Source.Value;


            Apply高级();
            f.Dispose();
        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            FormPlotSet f = new FormPlotSet();
            f.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(this.myplotsettings, "XCaption");

            f.ShowDialog();

            this.myplotsettings.XCaption = (bool)f.propertyEditor1.Source.Value;


            Apply高级();
            f.Dispose();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FormPlotSet f = new FormPlotSet();
            f.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(this.myplotsettings, "Xlog");

            f.ShowDialog();

            this.myplotsettings.Xlog = (bool)f.propertyEditor1.Source.Value;


            Apply高级();
            f.Dispose();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            FormPlotSet f = new FormPlotSet();
            f.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(this.myplotsettings.Xrevert, "Xrevert");

            f.ShowDialog();

            this.myplotsettings.Xrevert = (bool)f.propertyEditor1.Source.Value;


            Apply高级();
            f.Dispose();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            FormPlotSet f = new FormPlotSet();
            f.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(this.myplotsettings, "YCaption");

            f.ShowDialog();

            this.myplotsettings.YCaption = (bool)f.propertyEditor1.Source.Value;


            Apply高级();
            f.Dispose();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            FormPlotSet f = new FormPlotSet();
            f.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(this.myplotsettings, "Ylog");

            f.ShowDialog();

            this.myplotsettings.Ylog = (bool)f.propertyEditor1.Source.Value;


            Apply高级();
            f.Dispose();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            FormPlotSet f = new FormPlotSet();
            f.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(this.myplotsettings, "Yrevert");

            f.ShowDialog();

            this.myplotsettings.Yrevert = (bool)f.propertyEditor1.Source.Value;


            Apply高级();
            f.Dispose();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            FormPlotSet f = new FormPlotSet();
            f.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(this.myplotsettings, "showLegend");

            f.ShowDialog();

            this.myplotsettings.showLegend = (bool)f.propertyEditor1.Source.Value;


            Apply高级();
            f.Dispose();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            FormPlotSet f = new FormPlotSet();
            f.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(this.myplotsettings, "showlegendborder");

            f.ShowDialog();

            this.myplotsettings.showlegendborder = (bool)f.propertyEditor1.Source.Value;


            Apply高级();
            f.Dispose();
        }



        private void button22_Click(object sender, EventArgs e)
        {
            FormPlotSet f = new FormPlotSet();
            f.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(this.myplotsettings, "LegendBackColor");

            f.ShowDialog();

            this.myplotsettings.LegendBackColor = (Color)f.propertyEditor1.Source.Value;


            Apply高级();
            f.Dispose();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            FormPlotSet f = new FormPlotSet();
            f.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(this.myplotsettings, "LegendFont");

            f.ShowDialog();

            this.myplotsettings.LegendFont = (Font)f.propertyEditor1.Source.Value;


            Apply高级();
            f.Dispose();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                 tlpkind1.Visible = true;
                 tlpkind2.Visible = false;

                myplotsettings.curvekind = 2;
            }
        }

        private void txtcurveaption_kind1_TextChanged(object sender, EventArgs e)
        {
            myplotsettings.curvekind1_curvecaption = txtcurveaption_kind1.Text;
        }

        private void numcount_ValueChanged(object sender, EventArgs e)
        {
            myplotsettings.curvecount = Convert.ToInt32(numcount.Value);
        }

        private void cbooffset_SelectedIndexChanged(object sender, EventArgs e)
        {
            myplotsettings.curveoffset = cbooffset.SelectedIndex;
        }

        private void chkshowinvalidspe_CheckedChanged(object sender, EventArgs e)
        {
            myplotsettings.showinvalidspe = chkshowinvalidspe.Checked;
        }

        private void chkdatapoint_CheckedChanged(object sender, EventArgs e)
        {
            myplotsettings.showdatapointer = chkdatapoint.Checked;
        }

        private void cboxchannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            myplotsettings.xchannel = cboxchannel.SelectedIndex;

            cboxchannelunit.Items.Clear();
            for (int i = 0; i < ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.xchannel].cUnitCount; i++)
            {
                cboxchannelunit.Items.Add(ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.xchannel].cUnits[i]);
            }


            if ((myplotsettings.xchannelunit >= 0) && (myplotsettings.xchannelunit < cboxchannelunit.Items.Count))
            {
                cboxchannelunit.SelectedIndex = myplotsettings.xchannelunit;
            }
            else
            {
                myplotsettings.xchannelunit = 0;
                cboxchannelunit.SelectedIndex = 0;
            }
            this.scatterGraph1.XAxes[0].Caption = ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.xchannel].cName + "[" +
                ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.xchannel].cUnits[myplotsettings.xchannelunit] + "]";


        }

        private void cboxchannelunit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rdbxautozoom_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbxautozoom.Checked == true)
            {
                myplotsettings.xchannelzoom = true;
            }
        }

        private void rdbxhandzoom_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdbxhandzoom.Checked == true)
            {
                myplotsettings.xchannelzoom = false;
            }
        }

        private void cboychannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            myplotsettings.ychannel[cbocurve.SelectedIndex] = cboychannel.SelectedIndex;
            cboychannelunit.Items.Clear();
            for (int i = 0; i < ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.ychannel[cbocurve.SelectedIndex]].cUnitCount; i++)
            {
                cboychannelunit.Items.Add(ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.ychannel[cbocurve.SelectedIndex]].cUnits[i]);
            }

            if ((myplotsettings.ychannelunit[cbocurve.SelectedIndex] >= 0) && (myplotsettings.ychannelunit[cbocurve.SelectedIndex] < cboychannelunit.Items.Count))
            {
                cboychannelunit.SelectedIndex = myplotsettings.ychannelunit[cbocurve.SelectedIndex];
            }
            else
            {
                myplotsettings.ychannelunit[cbocurve.SelectedIndex] = 0;
                cboychannelunit.SelectedIndex = 0;
            }
            this.scatterGraph1.YAxes[0].Caption = ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.ychannel[cbocurve.SelectedIndex]].cName + "[" +
           ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.ychannel[cbocurve.SelectedIndex]].cUnits[myplotsettings.ychannelunit[cbocurve.SelectedIndex]] + "]";



        }

        private void cboychannelunit_SelectedIndexChanged(object sender, EventArgs e)
        {




        }

        private void rdbyautozoom_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbyautozoom.Checked == true)
            {
                myplotsettings.ychannelzoom = true;
            }
        }

        private void rdbyhandzoom_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbyhandzoom.Checked == true)
            {
                myplotsettings.ychannelzoom = false;
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            FormPlotSet f = new FormPlotSet();

            NationalInstruments.UI.ShapeStyle p = default(NationalInstruments.UI.ShapeStyle);
            this.myplotsettings.SetSignPointStyle(ref p);
            xyPointAnnotation1.ShapeStyle = p;



            f.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(xyPointAnnotation1, "ShapeStyle");

            f.ShowDialog();

            this.myplotsettings.SignPointStylName = ((NationalInstruments.UI.ShapeStyle)f.propertyEditor1.Source.Value).Name;


            Apply高级();
            f.Dispose();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            FormPlotSet f = new FormPlotSet();
            f.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(this.myplotsettings, "SignPointSize");

            f.ShowDialog();

            this.myplotsettings.SignPointSize = (int)f.propertyEditor1.Source.Value;


            Apply高级();
            f.Dispose();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            FormPlotSet f = new FormPlotSet();
            f.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(this.myplotsettings, "SignPointColor");

            f.ShowDialog();

            this.myplotsettings.SignPointColor = (Color)f.propertyEditor1.Source.Value;


            Apply高级();
            f.Dispose();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            FormPlotSet f = new FormPlotSet();

            NationalInstruments.UI.LineStyle p = default(NationalInstruments.UI.LineStyle);
            this.myplotsettings.SetSignLineStyle(ref p);
            this.myplotsettings.SignLineStyle = p;



            f.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(myplotsettings, "SignLineStyle");

            f.ShowDialog();

            this.myplotsettings.SignLineStyleName = ((NationalInstruments.UI.LineStyle)f.propertyEditor1.Source.Value).Name;


            Apply高级();
            f.Dispose();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            FormPlotSet f = new FormPlotSet();
            f.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(this.myplotsettings, "SignLineColor");

            f.ShowDialog();

            this.myplotsettings.SignLineColor = (Color)f.propertyEditor1.Source.Value;


            Apply高级();
            f.Dispose();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            FormPlotSet f = new FormPlotSet();

            NationalInstruments.UI.LineStyle p = default(NationalInstruments.UI.LineStyle);
            this.myplotsettings.SetPlotLineStyle(ref p, mcurveselect);
            this.scatterGraph1.Plots[mcurveselect].LineStyle = p;



            f.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(this.scatterGraph1.Plots[mcurveselect], "LineStyle");

            f.ShowDialog();

            this.myplotsettings.PlotLineStyleName[mcurveselect] = ((NationalInstruments.UI.LineStyle)f.propertyEditor1.Source.Value).Name;


            Apply高级();
            f.Dispose();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            FormPlotSet f = new FormPlotSet();
            this.scatterGraph1.Plots[mcurveselect].LineColor = this.myplotsettings.PlotLineColor[mcurveselect];
            f.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(this.scatterGraph1.Plots[mcurveselect], "LineColor");

            f.ShowDialog();

            this.myplotsettings.PlotLineColor[mcurveselect] = (Color)f.propertyEditor1.Source.Value;


            Apply高级();
            f.Dispose();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            FormPlotSet f = new FormPlotSet();

            NationalInstruments.UI.PointStyle p = default(NationalInstruments.UI.PointStyle);
            this.myplotsettings.SetPlotLinePointStyle(ref p, mcurveselect);
            this.scatterGraph1.Plots[mcurveselect].PointStyle = p;



            f.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(this.scatterGraph1.Plots[mcurveselect], "PointStyle");

            f.ShowDialog();

            this.myplotsettings.PlotLinePointStyleName[mcurveselect] = ((NationalInstruments.UI.PointStyle)f.propertyEditor1.Source.Value).Name;


            Apply高级();
            f.Dispose();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            FormPlotSet f = new FormPlotSet();
            this.scatterGraph1.Plots[mcurveselect].PointSize = new Size(this.myplotsettings.PlotLineSize[mcurveselect], this.myplotsettings.PlotLineSize[mcurveselect]);
            f.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(this.scatterGraph1.Plots[mcurveselect].PointSize, "Width");

            f.ShowDialog();



            this.myplotsettings.PlotLineSize[mcurveselect] = ((int)f.propertyEditor1.Source.Value);



            Apply高级();
            f.Dispose();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            FormPlotSet f = new FormPlotSet();
            this.scatterGraph1.Plots[mcurveselect].PointColor = this.myplotsettings.PlotLinePointColor[mcurveselect];
            f.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(this.scatterGraph1.Plots[mcurveselect], "PointColor");

            f.ShowDialog();



            this.myplotsettings.PlotLinePointColor[mcurveselect] = ((Color)f.propertyEditor1.Source.Value);



            Apply高级();
            f.Dispose();
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            FormPlotSet f = new FormPlotSet();
            this.scatterGraph1.Plots[mcurveselect].LineWidth = this.myplotsettings.PlotLinePointSize[mcurveselect];
            f.propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(this.scatterGraph1.Plots[mcurveselect], "LineWidth");

            f.ShowDialog();



            this.myplotsettings.PlotLinePointSize[mcurveselect] = Convert.ToInt32(((float)f.propertyEditor1.Source.Value));



            Apply高级();
            f.Dispose();
        }

        private void cboy1channel_SelectedIndexChanged(object sender, EventArgs e)
        {
            myplotsettings.y1channel = cboy1channel.SelectedIndex;
            cboy1channelunit.Items.Clear();
            for (int i = 0; i < ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.y1channel].cUnitCount; i++)
            {
                cboy1channelunit.Items.Add(ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.y1channel].cUnits[i]);
            }
            myplotsettings.y1channelunit = 0;
            if ((myplotsettings.y1channelunit >= 0) && (myplotsettings.y1channelunit < cboy1channelunit.Items.Count))
            {
                cboy1channelunit.SelectedIndex = myplotsettings.y1channelunit;
            }
            this.scatterGraph1.YAxes[1].Caption = ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.y1channel].cName + "[" +
             ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.y1channel].cUnits[myplotsettings.y1channelunit] + "]";



        }

        private void cboy1channelunit_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.myplotsettings.y1channelunit = cboy1channelunit.SelectedIndex;
            this.scatterGraph1.YAxes[1].Caption = ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.y1channel].cName + "[" +
           ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.y1channel].cUnits[myplotsettings.y1channelunit] + "]";


        }

        private void cboychannelunit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            myplotsettings.ychannelunit[cbocurve.SelectedIndex] = this.cboychannelunit.SelectedIndex;
            this.scatterGraph1.YAxes[0].Caption = ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.ychannel[cbocurve.SelectedIndex]].cName + "[" +
            ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.ychannel[cbocurve.SelectedIndex]].cUnits[myplotsettings.ychannelunit[cbocurve.SelectedIndex]] + "]";
        }

        private void cboxchannelunit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            myplotsettings.xchannelunit = cboxchannelunit.SelectedIndex;
            this.scatterGraph1.XAxes[0].Caption = ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.xchannel].cName + "[" +
                ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.xchannel].cUnits[myplotsettings.xchannelunit] + "]";
        }

        private void chkdynamic_CheckedChanged(object sender, EventArgs e)
        {
            myplotsettings.dynamicdraw = chkdynamic.Checked;
        }

        private void numdynamic_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            myplotsettings.dynamicpointcount = Convert.ToInt32(numdynamic.Value);
        }

        private void cbo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbocurve_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((myplotsettings.ychannel[cbocurve.SelectedIndex] >= 0) && (myplotsettings.ychannel[cbocurve.SelectedIndex] < cboychannel.Items.Count))
            {
                cboychannel.SelectedIndex = myplotsettings.ychannel[cbocurve.SelectedIndex];
            }
            else
            {
                myplotsettings.ychannel[cboy1channel.SelectedIndex] = 0;
                cboychannel.SelectedIndex = myplotsettings.ychannel[cbocurve.SelectedIndex];
            }

            if ((myplotsettings.ychannelunit[cbocurve.SelectedIndex] >= 0) && (myplotsettings.ychannelunit[cbocurve.SelectedIndex] < cboychannelunit.Items.Count))
            {
                cboychannelunit.SelectedIndex = myplotsettings.ychannelunit[cbocurve.SelectedIndex];
            }


        }

        private void numxmax_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            myplotsettings.xmax = numxmax.Value;
        }

        private void numxmin_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            myplotsettings.xmin = numxmin.Value;
        }

        private void numymax_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            myplotsettings.ymax = numymax.Value;


        }

        private void numymin_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            myplotsettings.ymin = numymin.Value;
        }

        private void numy1max_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            myplotsettings.y1max = numy1max.Value;

        }

        private void numy1min_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            myplotsettings.y1min = numy1min.Value;
        }

        private void tlpkind2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rdby1autozoom_CheckedChanged(object sender, EventArgs e)
        {
            
            if (rdby1autozoom.Checked == true)
            {
                myplotsettings.y1channelzoom  = true;
            }
        }

        private void rdby1handzoom_CheckedChanged(object sender, EventArgs e)
        {
            if (rdby1handzoom.Checked == true)
            {
                myplotsettings.y1channelzoom = false;
            }
        }
    }
}
