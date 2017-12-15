using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClsStaticStation;
using System.IO;
namespace TabHeaderDemo
{
    public partial class UserControlGraph : UserControl
    {

        public long count = 0;
        private CComLibrary.PlotSettings myplotsettings;
        private int mplot1;
        private RawDataDataGroup[] r = new RawDataDataGroup[1];
        private RawDataStruct b;
        public Queue<RawDataStruct> myarraydata;
        string mspefiledat;

        public double tstart;

        public double maxload;

        private double mstarttime;

        public void RefreshCaption()
        {
            string s;
            if (mplot1 == 1)
            {
                s = myplotsettings.curvekind1_curvecaption;
                s = s.Replace("%n", (CComLibrary.GlobeVal.filesave.currentspenumber + 1).ToString());
                s = s.Replace("%m", CComLibrary.GlobeVal.filesave.mspecount.ToString());

                scatterGraph.Caption = s;
            }

            if (mplot1 == 2)
            {
                s = myplotsettings.curvekind2_curvecaption;
                s = s.Replace("%n", (CComLibrary.GlobeVal.filesave.currentspenumber + 1).ToString());
                s = s.Replace("%m", CComLibrary.GlobeVal.filesave.mspecount.ToString());

                scatterGraph.Caption = s;

            }
        }
        public void startrun()
        {
            RawDataDataGroup d;
            string s;
            count = 0;
            int mk;
            tstart = 0;
            maxload = 0;
            mstarttime = 0;


            
            
            

            if (myplotsettings.curvekind == 1)
            {
                scatterGraph.ClearData();
            }
            else
            {
                mk = (CComLibrary.GlobeVal.filesave.currentspenumber+1) % myplotsettings.curvecount;
                if (mk == 0)
                {
                    mk = myplotsettings.curvecount;
                }
                if (mk == 1)
                {
                    scatterGraph.ClearData(); 
                }
                scatterGraph.Plots[mk - 1].ClearData();
            }
            
            myarraydata.Clear();

            if (mplot1 == 1)
            {
                mspefiledat = GlobeVal.mysys.SamplePath +"\\"+GlobeVal.mysys.SampleFile+"-"+
                    (CComLibrary.GlobeVal.filesave.currentspenumber+1).ToString().Trim()+".txt";
               

                if (File.Exists(mspefiledat) == true)
                {
                    File.Delete(mspefiledat);

                }

                FileStream fs = new FileStream(mspefiledat, FileMode.CreateNew);
               
                using (StreamWriter w = new StreamWriter(fs,System.Text.Encoding.Default)) 
                {

                    s = "";

                    for (int i = 0; i < CComLibrary.GlobeVal.filesave.mrawdata.Count; i++)
                    {
                        s = s + CComLibrary.GlobeVal.filesave.mrawdata[i].cName+" ";
                    }

                    w.WriteLine(s);
                       
                    s = "";
                    for (int i = 0; i < CComLibrary.GlobeVal.filesave.mrawdata.Count; i++)
                    {
                        s = s + CComLibrary.GlobeVal.filesave.mrawdata[i].cUnits[CComLibrary.GlobeVal.filesave.mrawdata[i].cUnitsel] + " ";
                    }
                    w.WriteLine(s);
                       

                }
                fs.Close();
            }
            timer1.Enabled = true;
        }

        public void endrun()
        {
            timer1.Enabled = false;

        }
        public void Init曲线(int plot)
        {
           
            if (plot == 1)
            {
                myplotsettings = CComLibrary.GlobeVal.filesave.mplotpara1;
                lblcaption.Text = "曲线图1";
                lblcaption.Tag = true;


            }

            if (plot == 2)
            {
                myplotsettings = CComLibrary.GlobeVal.filesave.mplotpara2;
                lblcaption.Text = "曲线图2";
                lblcaption.Tag = "";
            }
           

            scatterGraph.Plots.Clear();
            legend.Items.Clear();
            NationalInstruments.UI.ScatterPlot mplot;
            NationalInstruments.UI.LegendItem mlegitem;

            if ((myplotsettings.ychannel>=0) && (myplotsettings.ychannel<ClsStaticStation.m_Global.mycls.allsignals.Count))
            {

            }
            else
            {
                myplotsettings.ychannel = 0;
            }

            if ((myplotsettings.xchannel >= 0) && (myplotsettings.xchannel < ClsStaticStation.m_Global.mycls.allsignals.Count))
            {

            }
            else
            {
                myplotsettings.xchannel = 0;
            }


            if ((myplotsettings.ychannelunit >= 0) && (myplotsettings.ychannelunit < ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.ychannel].cUnitCount))
            {
            }
            else
            {
                myplotsettings.ychannelunit = 0;
            }


            if ((myplotsettings.xchannelunit >= 0) && (myplotsettings.xchannelunit < ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.xchannel].cUnitCount))
            {
            }
            else
            {
                myplotsettings.xchannelunit = 0;
            }
            if ( myplotsettings.curvekind == 0)
            {
                scatterGraph.YAxes[0].Visible = true;
                scatterGraph.YAxes[1].Visible = false;

                

                scatterGraph.YAxes[0].Caption = ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.ychannel].cName + "[" +
                ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.ychannel].cUnits[myplotsettings.ychannelunit] + "]";

                scatterGraph.XAxes[0].Caption = ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.xchannel].cName + "[" +
                ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.xchannel].cUnits[myplotsettings.xchannelunit] + "]";

         
                //scatterGraph.YAxes[0].Caption =myplotsettings.
                for (int i = 0; i < myplotsettings.curvecount; i++)
                {
                   
                    mplot = new NationalInstruments.UI.ScatterPlot();
                    mplot.LineColor = myplotsettings.PlotLineColor[i];
                    mplot.LineStyle = myplotsettings.PlotLineStyle[i];
                    mplot.PointStyle = myplotsettings.PlotLinePointStyle[i];
                    mplot.PointSize = new Size(myplotsettings.PlotLineSize[i], myplotsettings.PlotLineSize[i]);
                    mplot.PointColor = myplotsettings.PlotLinePointColor[i];
                    mplot.LineWidth = myplotsettings.PlotLinePointSize[i];
                    mplot.HistoryCapacity = 300000;
                    scatterGraph.Plots.Add(mplot);
                    
                       



                    mplot.ClearData();
                   
                    mlegitem = new NationalInstruments.UI.LegendItem();
                    mlegitem.Source = mplot;
                    mlegitem.Text = (i + 1).ToString().Trim();
                    legend.Items.Add(mlegitem);


                }

                if (myplotsettings.curvecount >= 2)
                {
                    scatterGraph.Plots[1].YAxis = yAxis1;

                }
            }


            if (myplotsettings.curvekind == 1)
            {
                int i;

                i = 0;
                scatterGraph.YAxes[0].Visible = true;
                scatterGraph.YAxes[1].Visible = true;

                scatterGraph.YAxes[0].Caption = ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.ychannel].cName + "[" +
               ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.ychannel].cUnits[myplotsettings.ychannelunit] + "]";

                scatterGraph.XAxes[0].Caption = ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.xchannel].cName + "[" +
                ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.xchannel].cUnits[myplotsettings.xchannelunit] + "]";

                scatterGraph.YAxes[1].Caption = ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.y1channel].cName + "[" +
                ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.y1channel].cUnits[myplotsettings.y1channelunit] + "]";



                mplot = new NationalInstruments.UI.ScatterPlot();
                mplot.LineColor = myplotsettings.PlotLineColor[i];
                mplot.LineStyle = myplotsettings.PlotLineStyle[i];
                mplot.PointStyle = myplotsettings.PlotLinePointStyle[i];
                mplot.PointSize = new Size(myplotsettings.PlotLineSize[i], myplotsettings.PlotLineSize[i]);
                mplot.PointColor = myplotsettings.PlotLinePointColor[i];
                mplot.LineWidth = myplotsettings.PlotLinePointSize[i];
                mplot.HistoryCapacity = 300000;
                scatterGraph.Plots.Add(mplot);

                mplot.ClearData();
               
                mlegitem = new NationalInstruments.UI.LegendItem();
                mlegitem.Source = mplot;
                mlegitem.Text = (i + 1).ToString().Trim();
                legend.Items.Add(mlegitem);

                i = 1;
               
                mplot = new NationalInstruments.UI.ScatterPlot();
                mplot.LineColor = myplotsettings.PlotLineColor[i];
                mplot.LineStyle = myplotsettings.PlotLineStyle[i];
                mplot.PointStyle = myplotsettings.PlotLinePointStyle[i];
                mplot.PointSize = new Size(myplotsettings.PlotLineSize[i], myplotsettings.PlotLineSize[i]);
                mplot.PointColor = myplotsettings.PlotLinePointColor[i];
                mplot.LineWidth = myplotsettings.PlotLinePointSize[i];
                scatterGraph.Plots.Add(mplot);

                mplot.ClearData();
               
                mlegitem = new NationalInstruments.UI.LegendItem();
                mlegitem.Source = mplot;
                mlegitem.Text = (i + 1).ToString().Trim();
                legend.Items.Add(mlegitem);

                mplot.YAxis = yAxis2;

               
            }

            xyCursor1.Plot = scatterGraph.Plots[0];

            if (myplotsettings.showdatapointer == true)
            {
                toolStrip2.Visible = true;
               
            }
            else
            {
                toolStrip2.Visible  = false;
            }
            mplot1 = plot;


        }

        public UserControlGraph()
        {

            InitializeComponent();
            myarraydata = new Queue<RawDataStruct>();
            mplot1 = 0;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲


            this.tableLayoutPanel1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel1, true, null);
            tabControl1.ItemSize = new Size(1, 1);

        }

        private void panelback_SizeChanged(object sender, EventArgs e)
        {
           
        }

        private void panelback_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanelCurve_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int mk=0;
            int j = 0;
            int k=0;
            double  xi=0;
            double  yi=0;
            double y1i = 0;
            double mtime = 0;

            double v=0;

            double mload = 0;
            string s;

            timer1.Enabled = false;
            int ll = 0;

            ll = ClsStatic.arraydata[mplot1 - 1].Read<RawDataDataGroup>(r, 0, 10);

            if (ll == 0)
            {
            }
            else
            {
               ClsStatic.arraydatacount[mplot1 - 1] = ClsStatic.arraydatacount[mplot1 - 1] - 1;
            }

           

            while (ll != 0)
            {
                b = new RawDataStruct();
                b.data = new double[24];


                    m_Global.mycls.structcopy_RawDataStruct(r[0].rdata, ref b);
                

                    myarraydata.Enqueue(b);
              

                ll = ClsStatic.arraydata[mplot1 -1].Read<RawDataDataGroup>(r, 0, 10);

                if (ll == 0)
                {
                    break;
                }
                else
                {
                    ClsStatic.arraydatacount[mplot1 - 1] = ClsStatic.arraydatacount[mplot1 -1] - 1;
                }
            }

            while (myarraydata.Count > 0)
            {

                b = myarraydata.Dequeue();

                

                count = count + 1;

                for (int i=0;i<m_Global.mycls.datalist.Count;i++)
                {
                    
                    if (m_Global.mycls.datalist[i].SignName == m_Global.mycls.allsignals[myplotsettings.xchannel].SignName)
                    {

                        xi = Convert.ToDouble(m_Global.mycls.allsignals[myplotsettings.xchannel].GetValueFromUnit(b.data[m_Global.mycls.datalist[i].EdcId], 
                            myplotsettings.xchannelunit));

                    }

                    if (m_Global.mycls.datalist[i].SignName == ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.ychannel].SignName)

                    {

                        yi = Convert.ToDouble(m_Global.mycls.allsignals[myplotsettings.ychannel].GetValueFromUnit(b.data[m_Global.mycls.datalist[i].EdcId],
                           myplotsettings.ychannelunit ));

                     
                     }

                    if (m_Global.mycls.datalist[i].SignName == ClsStaticStation.m_Global.mycls.allsignals[myplotsettings.y1channel].SignName)
                    {

                        y1i = Convert.ToDouble(m_Global.mycls.allsignals[myplotsettings.y1channel].GetValueFromUnit(b.data[m_Global.mycls.datalist[i].EdcId],
                           myplotsettings.y1channelunit));


                    }

                    if (m_Global.mycls.datalist[i].SignName == "Ch Time")
                    {
                        mtime = b.data[m_Global.mycls.datalist[i].EdcId];
                    }

                    if (m_Global.mycls.datalist[i].SignName == "Ch Load")
                    {
                        mload = b.data[m_Global.mycls.datalist[i].EdcId];
                    }
                    
                    
                 }

                if ( Math.Abs(mtime - mstarttime) >= 0.02)
                {
                    mstarttime = mtime;
                    if (myplotsettings.curvekind == 0)
                    {
                        mk = (CComLibrary.GlobeVal.filesave.currentspenumber + 1) % myplotsettings.curvecount;
                        if (mk == 0)
                        {
                            mk = myplotsettings.curvecount;
                        }

                        if (myplotsettings.curveoffset == 0)
                        {

                            scatterGraph.Plots[mk - 1].PlotXYAppend(xi, yi);
                        }

                        if (myplotsettings.curveoffset == 1)
                        {

                            scatterGraph.Plots[mk - 1].PlotXYAppend(xi + 0.1 * (mk - 1), yi);
                        }

                        if (myplotsettings.curveoffset == 2)
                        {

                            scatterGraph.Plots[mk - 1].PlotXYAppend(xi, yi + 0.1 * (mk - 1));
                        }

                        if (myplotsettings.curveoffset == 3)
                        {

                            scatterGraph.Plots[mk - 1].PlotXYAppend(xi + 0.1 * (mk - 1), yi + 0.1 * (mk - 1));
                        }


                    }
                    if (myplotsettings.curvekind == 1)
                    {

                        scatterGraph.Plots[0].PlotXYAppend(xi, yi);
                        scatterGraph.Plots[1].PlotXYAppend(xi, y1i);
                    }
                }
                if (mplot1 == 1)
                {
                    if (CComLibrary.GlobeVal.filesave.SampleInterval == 0)
                    {
                        CComLibrary.GlobeVal.filesave.SampleInterval = 10;
                    }

                    

                    if ((mtime - tstart) >= 1/CComLibrary.GlobeVal.filesave.SampleInterval)
                    {
                        tstart = mtime;
                        using (StreamWriter w = File.AppendText(mspefiledat))
                        {

                            s = "";

                            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mrawdata.Count; i++)
                            {

                                for (j = 0; j < ClsStaticStation.m_Global.mycls.datalist.Count; j++)
                                {
                                    if (ClsStaticStation.m_Global.mycls.datalist[j].SignName == CComLibrary.GlobeVal.filesave.mrawdata[i].SignName)
                                    {
                                        k = ClsStaticStation.m_Global.mycls.datalist[j].EdcId;


                                       double.TryParse(CComLibrary.GlobeVal.filesave.mrawdata[i].GetValueFromUnit(b.data[k],
                                           CComLibrary.GlobeVal.filesave.mrawdata[i].cUnitsel),out v);
                                        s = s + v.ToString("F"+CComLibrary.GlobeVal.filesave.mrawdata[i].precise.ToString()) + " ";
                                    }
                                }



                            }

                            w.WriteLine(s);




                        }
                    }
                }

               
            }
            /*
            if(count >5000)
            {
                scatterGraph.ClearData();
                count = 0;
            }

            lblcaption.Text = count.ToString();
            */
            timer1.Enabled = true;

        }

        private void scatterGraph_PlotDataChanged(object sender, NationalInstruments.UI.XYPlotDataChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void tsbscreenreader_Click(object sender, EventArgs e)
        {
            if (xyCursor1.Visible == true)
            {
                xyCursor1.Visible = false;
            }
            else
            {
                xyCursor1.Visible = true;
            }
        }

        private void tsbzoomin_Click(object sender, EventArgs e)
        {
            scatterGraph.InteractionModeDefault = NationalInstruments.UI.GraphDefaultInteractionMode.ZoomXY;
        }

        private void tsbzoomout_Click(object sender, EventArgs e)
        {
            scatterGraph.UndoZoomPan();
            scatterGraph.InteractionModeDefault = NationalInstruments.UI.GraphDefaultInteractionMode.None;
        
        }

        private void lblcaption_Click(object sender, EventArgs e)
        {
            if (mplot1 == 1)
            {
                if ( Convert.ToBoolean( lblcaption.Tag) ==false)
                {
                    lblcaption.Tag = true;
                    lblcaption.Text = "分析图1";
                    tabControl1.SelectedIndex = 1;
                }
                else
                {
                    lblcaption.Text = "曲线图1";
                    lblcaption.Tag = false;
                    tabControl1.SelectedIndex = 0;
                }
            }
        }
    }
}
