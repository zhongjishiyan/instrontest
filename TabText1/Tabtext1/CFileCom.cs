﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;
using AppleLabApplication;
//using NationalInstruments.Analysis.Math;

using ClsStaticStation;
using System.Data;
using System.Web.UI;
using System.Data.SqlClient;


namespace CComLibrary
{

    [Serializable]
    public class Student
    {
        public Student(string name, string sex, int age)
        {
            this.Name = name;
            this.Sex = sex;
            this.Age = age;
        }
        public string Name { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
    }
    public class BoTree<T>
    {
        public BoTree()
        {
            nodes = new List<BoTree<T>>();
        }

        public BoTree(T data)
        {
            this.Data = data;
            nodes = new List<BoTree<T>>();
        }

        private BoTree<T> parent;
        /// <summary>
        /// 父结点
        /// </summary>
        public BoTree<T> Parent
        {
            get { return parent; }
        }
        /// <summary>
        /// 结点数据
        /// </summary>
        public T Data { get; set; }

        private List<BoTree<T>> nodes;
        /// <summary>
        /// 子结点
        /// </summary>
        public List<BoTree<T>> Nodes
        {
            get { return nodes; }
        }
        /// <summary>
        /// 添加结点
        /// </summary>
        /// <param name="node">结点</param>
        public void AddNode(BoTree<T> node)
        {
            if (!nodes.Contains(node))
            {
                node.parent = this;
                nodes.Add(node);
            }
        }
        /// <summary>
        /// 添加结点
        /// </summary>
        /// <param name="nodes">结点集合</param>
        public void AddNode(List<BoTree<T>> nodes)
        {
            foreach (var node in nodes)
            {
                if (!nodes.Contains(node))
                {
                    node.parent = this;
                    nodes.Add(node);
                }
            }
        }
        /// <summary>
        /// 移除结点
        /// </summary>
        /// <param name="node"></param>
        public void Remove(BoTree<T> node)
        {
            if (nodes.Contains(node))
                nodes.Remove(node);
        }
        /// <summary>
        /// 清空结点集合
        /// </summary>
        public void RemoveAll()
        {
            nodes.Clear();
        }
    }



    [ComVisible(true)]
    [Guid("EBAD8A83-BC05-412D-A059-6648C524148F")]
    public interface IMyClass
    {
        void Initialize();
        void Dispose();
        int Add(int x, int y);
        void calc();
        double expstr(string s, int i, out Boolean r);
        void initarray(string s, int count);
        void refreshglobe(string s);
        void refreshresult(string s);
        void gethwnd(long h);
        void setarrayvalue(double[,] t, int l);
        void setarrayvalueold(double[,] t, int l);

    }

    [ComVisible(true)]
    [Guid("722FA461-6288-4071-A105-9705281B19A1")]
    [ProgId("K8robot.reply")]
    public class K8robot

    {

        [DllImport("user32.dll")]
        private static extern int SetParent(IntPtr hWndChild, IntPtr hWndParent);

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        private static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter,
        int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern uint SetWindowLong(IntPtr hwnd, int nIndex, uint newLong);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern uint GetWindowLong(IntPtr hwnd, int nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool ShowWindow(IntPtr hWnd, short State);


        private const int HWND_TOP = 0x0;
        private const int WM_COMMAND = 0x0112;
        private const int WM_QT_PAINT = 0xC2DC;
        private const int WM_PAINT = 0x000F;
        private const int WM_SIZE = 0x0005;
        private const int SWP_FRAMECHANGED = 0x0020;

        MathExpressionParser mp;



        public void savecode()
        {
            string _temp = "";
            if (CComLibrary.GlobeVal.languageselect ==0)
            {
                _temp = "代码.txt";
            }
            else
            {
                _temp = "code.txt";
            }
            using (StreamWriter sw = new StreamWriter(_temp ))
            {
                // Add some text to the file.

                sw.Write(mp.text.Text);


            }

        }
        /*
        public void gethwnd(long h)
        {
            SetParent(GlobeVal.m_mainform.Handle, (IntPtr)h);


            GlobeVal.m_mainform.Show();
            GlobeVal.m_mainform.Left = 0;
            GlobeVal.m_mainform.Top = 0;
            SetWindowPos(GlobeVal.m_mainform.Handle, -1, 0, 0, 0, 0, 1);


        }*/

        public void Initialize_Channel()
        {

            mp = new MathExpressionParser();
            mp.Init_Func();
            mp.InitBegin();
            GlobeVal.m_channeldata = new double[20];


            //nothing todo
        }


        public void Initialize()
        {

            mp = new MathExpressionParser();
            mp.Init_Func();
            mp.InitBegin();
            GlobeVal.m_data = new double[30][];
            GlobeVal.m_calcdata = new double[30][];


            //nothing todo
        }
        public void Dispose()
        {
            mp = null;
            //nothing todo
        }
        public int Add(int x, int y)
        {
            return x + y;
        }

        public void setarrayvalueold(System.Array t, int l, int m)
        {
            int i;
            int j;
            int k = 0;
            GlobeVal.m_len = l;

            if (l - 1 > 0)
            {

                for (i = 0; i < 30; i++)
                {
                    GlobeVal.m_data[i] = new double[l - 1];
                    GlobeVal.m_calcdata[i] = new double[l - 1];
                }

                for (i = 0; i < l - 1; i++)
                {


                    for (j = 0; j < m; j++)
                    {


                        GlobeVal.m_data[j][i] = 0;


                    }


                }
            }
        }


        public void setarrayvalue(System.Array t, int l, int m)
        {
            int i;
            int j;
            int k = 0;
            int mi = 0;
            int mj = 0;
            GlobeVal.m_len = l;

            if (l - 1 > 0)
            {

                for (i = 0; i < 30; i++)
                {
                    GlobeVal.m_data[i] = new double[l - 1];
                    GlobeVal.m_calcdata[i] = new double[l - 1];
                }

                for (i = 0; i < l - 1; i++)
                {
                    for (k = 0; k < GlobeVal.filesave.m_namelist.Count; k++)
                    {

                        for (j = 0; j < m; j++)
                        {
                            if (GlobeVal.filesave.m_namelist[k] == CComLibrary.GlobeVal.g_datatitle[j])
                            {
                                for (int ii = 0; ii < ClsStaticStation.m_Global.mycls.signalskindlist.Count; ii++)
                                {
                                    for (int jj = 0; jj < ClsStaticStation.m_Global.mycls.signalskindlist[ii].cUnitCount; jj++)
                                    {
                                        if (CComLibrary.GlobeVal.g_dataunit[j].Trim() == ClsStaticStation.m_Global.mycls.signalskindlist[ii].cUnits[jj])
                                        {
                                            mi = ii;
                                            mj = jj;
                                            ClsStaticStation.m_Global.mycls.signalskindlist[ii].originprecise = 3;
                                            ClsStaticStation.m_Global.mycls.signalskindlist[ii].cUnitsel = jj;
                                            break;
                                        }
                                    }
                                }
                                GlobeVal.m_data[k][i] = Convert.ToDouble(ClsStaticStation.m_Global.mycls.signalskindlist[mi].GetOriValue(Convert.ToDouble(t.GetValue(i + 1, j))));

                            }
                        }
                    }

                }
            }
        }

        public void initarray(string s, int count)
        {
            if (GlobeVal.m_len - 1 > 0)
            {
                mp.InitArray(s, count);
            }
        }

        public void InitChannel(string s, int i)
        {
            mp.msource = s;
            mp.InitChannel(s, i);
        }


        public void Initexpr通道(string s, int i)
        {

            mp.msource = s;


            mp.InitExpr通道(s, i);

        }

        public void Initexpr(string s, int i)
        {

            mp.msource = s;


            mp.InitExpr(s, i);

        }

        public void calc通道()
        {

            mp.InitCalcedChannelExpressiton通道();
            mp.calc();

            return;
        }

        public Boolean calc()
        {
            Boolean b;

            b = mp.InitCalcedChannelExpressiton();
            mp.calc();

            return b;
        }

        public double getresult通道(int i)
        {
            double v = 0;
            v = mp.eval_hardchannel(i);
            return v;

        }


        public double getresult(int i)
        {
            double v = 0;

            if (mp == null)
            {
                v = 0;
            }
            else
            {
                v = mp.eval_calcedchannel(i);
            }
            return v;

        }

        public double expchannel(string s, int i, out Boolean r)
        {
            double v = 0;
            mp.msource = s;
            //mp.InitChannel(s, i);
            mp.InitHardChannel(s, i);
            r = mp.InitCalcedChannelExpressiton();
            v = mp.eval_hardchannel(i);

            return v;
        }
        public double expstr(string s, int i, out Boolean r)
        {
            double v = 0;

            mp.msource = s;



            mp.InitExpr(s, i);

            r = mp.InitCalcedChannelExpressiton();

            v = mp.eval_calcedchannel(i);


            return v;

        }

        public void refreshhardglobe(string s)
        {
            mp.RefreshHardGlobe(s);
        }
        public void refreshglobe(string s)
        {
            mp.RefreshGlobe(s);
        }
        public void refreshresulthard(string s)
        {
            mp.RefreshResultHard(s);
        }
        public void refreshresult(string s)
        {
            mp.RefreshResult(s);
        }
    }
    public class CFileCom
    {
    }


}

namespace CComLibrary
{
    [Serializable]
    public class LineStruct
    {
        public PointF pf;
        public int kind;  //0 point  1 line 2 paraline
        public double xstart;
        public double ystart;
        public double xend;
        public double yend;
        public int indexstart;
        public int indexend;
        public double value;

    }

    [Serializable]
    public class cboitem
    {

        public string Name;
        public int value;
        public List<string> mlist;
        public cboitem()
        {
            mlist = new List<string>();
        }

    }

    [Serializable]
    public class PlotSettings
    {

        public double xmax;
        public double xmin;
        public double ymax;
        public double ymin;
        public double y1max;
        public double y1min;

        public int curvekind = 0;//曲线类型  //
        public string curvekind1_curvecaption = "试样 %n，共 %m 个";
        public int curvecount = 4;//每个曲线图的曲线数量
        public int curveoffset = 0;//曲线偏移类型
        public bool showinvalidspe = false;//是否排除无效试样
        public bool showdatapointer = false;//是否启用数据点选择器
        public string curvekind2_curvecaption = "试样 %n";

        public int xchannel = 0;
        public int xchannelunit = 0;
        public bool xchannelzoom = false;


        public int[] ychannel;
        public int[] ychannelunit;

        public bool ychannelzoom = false;

        public int y1channel = 0;
        public int y1channelunit = 0;
        public bool y1channelzoom = false;

        public bool dynamicdraw = false;

        public int dynamicpointcount = 1000;



        //以下为曲线高级设置
        private Color m_backcolor;
        public Color backcolor
        {
            get
            {
                return m_backcolor;
            }
            set
            {
                m_backcolor = value;
            }
        }



        private Color m_axiscolor;

        public Color axiscolor
        {
            get
            {
                return m_axiscolor;
            }
            set
            {
                m_axiscolor = value;
            }

        }

        private Font m_CurveCaptionfont;

        public Font CurveCaptionfont
        {
            get
            {
                return m_CurveCaptionfont;
            }
            set
            {
                m_CurveCaptionfont = value;
            }

        }

        private Font m_AxisCaptionFont;

        public Font AxisCaptionFont
        {
            get
            {
                return m_AxisCaptionFont;
            }
            set
            {
                m_AxisCaptionFont = value;
            }


        }

        private Font m_AxisFont;

        public Font AxisFont
        {
            get
            {
                return m_AxisFont;
            }
            set
            {
                m_AxisFont = value;
            }
        }

        private Boolean m_ShowGrid;

        public Boolean ShowGrid
        {

            get
            {
                return m_ShowGrid;
            }
            set
            {
                m_ShowGrid = value;
            }
        }

        public String GridLineStyleName;
        [NonSerialized]

        private NationalInstruments.UI.LineStyle m_GridLineStyle;
        [System.Xml.Serialization.XmlIgnore]

        public NationalInstruments.UI.LineStyle GridLineStyle
        {
            get
            {
                return m_GridLineStyle;
            }
            set
            {
                m_GridLineStyle = value;
            }
        }


        private Color m_GridLineColor;

        public Color GridLineColor
        {
            get
            {
                return m_GridLineColor;
            }
            set
            {
                m_GridLineColor = value;
            }
        }

        private bool m_XCaption = false;

        public bool XCaption
        {
            get
            {
                return m_XCaption;
            }
            set
            {
                m_XCaption = value;
            }
        }

        private Boolean m_Xlog;//对数坐标

        public Boolean Xlog//对数坐标
        {
            get
            {
                return m_Xlog;
            }
            set
            {
                m_Xlog = value;
            }
        }


        private Boolean m_Xrevert;

        public Boolean Xrevert//坐标反转
        {
            get
            {
                return m_Xrevert;
            }
            set
            {
                m_Xrevert = value;
            }
        }



        private bool m_YCaption = false;

        public bool YCaption
        {
            get
            {
                return m_YCaption;
            }
            set
            {
                m_YCaption = value;
            }
        }

        private Boolean m_Ylog;

        public Boolean Ylog//对数坐标
        {
            get
            {
                return m_Ylog;

            }
            set
            {
                m_Ylog = value;
            }

        }

        private Boolean m_Yrevert;

        public Boolean Yrevert//坐标反转
        {
            get
            {
                return m_Yrevert;
            }
            set
            {
                m_Yrevert = value;
            }
        }

        private Boolean m_showLegend;


        public Boolean showLegend
        {
            get
            {
                return m_showLegend;
            }
            set
            {
                m_showLegend = value;
            }
        }


        public int LegendKind;//未用  对于多试样曲线图类型为试样编号或试样标识，对于其他曲线图类型为数据通道）


        public int LegendCaption;//未用
        public int LegendPos;//未用
        public int LegendDir;//未用


        private Boolean m_showlegendborder;
        public Boolean showlegendborder
        {
            get
            {
                return m_showlegendborder;
            }
            set
            {
                m_showlegendborder = value;
            }

        }

        private Color m_LegendBackColor;

        public Color LegendBackColor
        {
            get
            {
                return m_LegendBackColor;
            }
            set
            {
                m_LegendBackColor = value;
            }
        }

        private Font m_LegendFont;

        public Font LegendFont
        {
            get
            {
                return m_LegendFont;
            }
            set
            {
                m_LegendFont = value;
            }
        }



        public String SignPointStylName;
        [NonSerialized]

        private NationalInstruments.UI.ShapeStyle m_SignPointStyle;
        [System.Xml.Serialization.XmlIgnore]
        public NationalInstruments.UI.ShapeStyle SignPointStyle
        {
            get
            {
                return m_SignPointStyle;
            }
            set
            {
                m_SignPointStyle = value;
            }

        }

        private int m_SignPointSize;
        public int SignPointSize
        {
            get
            {
                return m_SignPointSize;
            }
            set
            {
                m_SignPointSize = value;
            }
        }

        private Color m_SignPointColor;

        public Color SignPointColor
        {
            get
            {
                return m_SignPointColor;
            }
            set
            {
                m_SignPointColor = value;
            }
        }


        public String SignLineStyleName;

        [NonSerialized]
        private NationalInstruments.UI.LineStyle m_SignLineStyle;

        [System.Xml.Serialization.XmlIgnore]
        public NationalInstruments.UI.LineStyle SignLineStyle
        {
            get
            {
                return m_SignLineStyle;
            }
            set
            {
                m_SignLineStyle = value;
            }

        }

        private Color m_SignLineColor;


        public Color SignLineColor
        {
            get
            {
                return m_SignLineColor;
            }
            set
            {
                m_SignLineColor = value;
            }
        }




        public String[] PlotLineStyleName;
        [NonSerialized]

        private NationalInstruments.UI.LineStyle[] m_PlotLineStyle;
        [System.Xml.Serialization.XmlIgnore]
        public NationalInstruments.UI.LineStyle[] PlotLineStyle
        {
            get
            {
                return m_PlotLineStyle;
            }
            set
            {
                m_PlotLineStyle = value;
            }
        }

        private Color[] m_PlotLineColor;
        public Color[] PlotLineColor
        {
            get
            {
                return m_PlotLineColor;
            }
            set
            {
                m_PlotLineColor = value;
            }
        }



        public String[] PlotLinePointStyleName;
        [NonSerialized]
        private NationalInstruments.UI.PointStyle[] m_PlotLinePointStyle;
        [System.Xml.Serialization.XmlIgnore]
        public NationalInstruments.UI.PointStyle[] PlotLinePointStyle
        {
            get
            {
                return m_PlotLinePointStyle;
            }
            set
            {
                m_PlotLinePointStyle = value;
            }

        }


        private int[] m_PlotLinePointSize;

        public int[] PlotLinePointSize
        {
            get
            {
                return m_PlotLinePointSize;
            }
            set
            {
                m_PlotLinePointSize = value;
            }
        }
        private int[] m_PlotLineSize;

        public int[] PlotLineSize
        {
            get
            {
                return m_PlotLineSize;
            }
            set
            {
                m_PlotLineSize = value;
            }
        }

        private Color[] m_PlotLinePointColor;
        public Color[] PlotLinePointColor
        {
            get
            {
                return m_PlotLinePointColor;
            }
            set
            {
                m_PlotLinePointColor = value;
            }


        }

        public void SetPlotLineStyle(ref NationalInstruments.UI.LineStyle mr, int index)
        {
            int w = 0;
            List<NationalInstruments.UI.LineStyle> mlist;
            mlist = new List<NationalInstruments.UI.LineStyle>();

            mlist.Add(NationalInstruments.UI.LineStyle.Dash);

            mlist.Add(NationalInstruments.UI.LineStyle.DashDot);

            mlist.Add(NationalInstruments.UI.LineStyle.DashDotDot);

            mlist.Add(NationalInstruments.UI.LineStyle.Dot);
            mlist.Add(NationalInstruments.UI.LineStyle.None);
            mlist.Add(NationalInstruments.UI.LineStyle.Solid);

            mr = NationalInstruments.UI.LineStyle.None;

            for (int i = 0; i < mlist.Count; i++)
            {
                if (mlist[i].Name == this.PlotLineStyleName[index])
                {
                    mr = mlist[i];

                }
            }

            mlist.Clear();
            mlist = null;



        }

        public void SetSignLineStyle(ref NationalInstruments.UI.LineStyle mr)
        {
            int w = 0;
            List<NationalInstruments.UI.LineStyle> mlist;
            mlist = new List<NationalInstruments.UI.LineStyle>();

            mlist.Add(NationalInstruments.UI.LineStyle.Dash);

            mlist.Add(NationalInstruments.UI.LineStyle.DashDot);

            mlist.Add(NationalInstruments.UI.LineStyle.DashDotDot);

            mlist.Add(NationalInstruments.UI.LineStyle.Dot);
            mlist.Add(NationalInstruments.UI.LineStyle.None);
            mlist.Add(NationalInstruments.UI.LineStyle.Solid);

            mr = NationalInstruments.UI.LineStyle.None;

            for (int i = 0; i < mlist.Count; i++)
            {
                if (mlist[i].Name == this.SignLineStyleName)
                {
                    mr = mlist[i];

                }
            }

            mlist.Clear();
            mlist = null;



        }

        public void SetPlotLinePointStyle(ref NationalInstruments.UI.PointStyle mr, int index)
        {
            int w = 0;
            List<NationalInstruments.UI.PointStyle> mlist;
            mlist = new List<NationalInstruments.UI.PointStyle>();

            mlist.Add(NationalInstruments.UI.PointStyle.Cross);

            mlist.Add(NationalInstruments.UI.PointStyle.EmptyCircle);

            mlist.Add(NationalInstruments.UI.PointStyle.EmptyDiamond);

            mlist.Add(NationalInstruments.UI.PointStyle.EmptySquare);
            mlist.Add(NationalInstruments.UI.PointStyle.EmptyTriangleDown);

            mlist.Add(NationalInstruments.UI.PointStyle.EmptyTriangleLeft);
            mlist.Add(NationalInstruments.UI.PointStyle.EmptyTriangleRight);
            mlist.Add(NationalInstruments.UI.PointStyle.EmptyTriangleUp);

            mlist.Add(NationalInstruments.UI.PointStyle.None);

            mlist.Add(NationalInstruments.UI.PointStyle.Plus);
            mlist.Add(NationalInstruments.UI.PointStyle.SolidCircle);

            mlist.Add(NationalInstruments.UI.PointStyle.SolidDiamond);

            mlist.Add(NationalInstruments.UI.PointStyle.SolidSquare);

            mlist.Add(NationalInstruments.UI.PointStyle.SolidTriangleDown);

            mlist.Add(NationalInstruments.UI.PointStyle.SolidTriangleLeft);

            mlist.Add(NationalInstruments.UI.PointStyle.SolidTriangleRight);

            mlist.Add(NationalInstruments.UI.PointStyle.SolidTriangleUp);

            mr = NationalInstruments.UI.PointStyle.Cross;

            for (int i = 0; i < mlist.Count; i++)
            {
                if (mlist[i].Name == this.PlotLinePointStyleName[index])
                {
                    mr = mlist[i];

                }
            }



            mlist.Clear();
            mlist = null;



        }
        public void SetSignPointStyle(ref NationalInstruments.UI.ShapeStyle mr)
        {
            int w = 0;
            List<NationalInstruments.UI.ShapeStyle> mlist;
            mlist = new List<NationalInstruments.UI.ShapeStyle>();

            mlist.Add(NationalInstruments.UI.ShapeStyle.Asterisk);

            mlist.Add(NationalInstruments.UI.ShapeStyle.Diamond);

            mlist.Add(NationalInstruments.UI.ShapeStyle.None);

            mlist.Add(NationalInstruments.UI.ShapeStyle.Oval);
            mlist.Add(NationalInstruments.UI.ShapeStyle.Rectangle);

            mr = NationalInstruments.UI.ShapeStyle.Diamond;

            for (int i = 0; i < mlist.Count; i++)
            {
                if (mlist[i].Name == this.SignPointStylName)
                {
                    mr = mlist[i];

                }
            }



            mlist.Clear();
            mlist = null;



        }
        public void SetGridLineStyle(ref NationalInstruments.UI.LineStyle mr)
        {
            int w = 0;
            List<NationalInstruments.UI.LineStyle> mlist;
            mlist = new List<NationalInstruments.UI.LineStyle>();

            mlist.Add(NationalInstruments.UI.LineStyle.Dash);

            mlist.Add(NationalInstruments.UI.LineStyle.DashDot);

            mlist.Add(NationalInstruments.UI.LineStyle.DashDotDot);

            mlist.Add(NationalInstruments.UI.LineStyle.Dot);
            mlist.Add(NationalInstruments.UI.LineStyle.None);
            mlist.Add(NationalInstruments.UI.LineStyle.Solid);

            mr = NationalInstruments.UI.LineStyle.None;
            for (int i = 0; i < mlist.Count; i++)
            {
                if (mlist[i].Name == GridLineStyleName)
                {
                    mr = mlist[i];

                }
            }

            mlist.Clear();
            mlist = null;



        }

        public PlotSettings()
        {
            backcolor = Color.White;
            axiscolor = Color.Black;
            CurveCaptionfont = new Font("宋体", 10);
            AxisCaptionFont = new Font("宋体", 10);
            AxisFont = new Font("宋体", 10);

            ShowGrid = false;



            GridLineStyleName = NationalInstruments.UI.LineStyle.DashDot.Name;
            SetGridLineStyle(ref this.m_GridLineStyle);


            m_GridLineColor = Color.Black;

            XCaption = true;
            Xlog = false;
            Xrevert = false;

            YCaption = true;
            Ylog = false;
            Yrevert = false;

            showLegend = true;
            LegendKind = 0;
            LegendCaption = 0;
            LegendPos = 0;
            LegendDir = 0;


            showlegendborder = true;
            LegendBackColor = Color.White;
            LegendFont = new Font("宋体", 10);

            SignPointStyle = NationalInstruments.UI.ShapeStyle.Diamond;
            SignPointSize = 5;
            SignPointColor = Color.Red;

            SignLineStyle = NationalInstruments.UI.LineStyle.Solid;
            SignLineColor = Color.DarkGreen;

            PlotLineStyleName = new String[16];
            m_PlotLineStyle = new NationalInstruments.UI.LineStyle[16];
            PlotLineColor = new Color[16];
            m_PlotLinePointStyle = new NationalInstruments.UI.PointStyle[16];
            PlotLinePointStyleName = new String[16];
            PlotLinePointSize = new int[16];
            PlotLineSize = new int[16];
            PlotLinePointColor = new Color[16];

            ychannel = new int[16];
            ychannelunit = new int[16];

            for (int i = 0; i < 16; i++)
            {

                m_PlotLineStyle[i] = NationalInstruments.UI.LineStyle.Solid;
                PlotLineStyleName[i] = m_PlotLineStyle[i].Name;
                PlotLineColor[i] = Color.Red;

                m_PlotLinePointStyle[i] = NationalInstruments.UI.PointStyle.None;
                PlotLinePointStyleName[i] = m_PlotLinePointStyle[i].Name;
                PlotLinePointSize[i] = 3;
                PlotLineSize[i] = 1;
                PlotLinePointColor[i] = Color.Black;
            }


        }

    }

    [Serializable]
    public class inputtextitem
    {
        public string intername = "";
        public string name = " ";
        public string value = " ";

    }

    [Serializable]
    public class inputitem
    {
        public string name;
        public double value;
        public string unit;
        public int dimsel = 0;//量纲选择
        public ItemSignal myitemsignal;
        public bool zerocheck = false;

    }
    [Serializable]
    public class outputitem
    {
        public string formulaname;
        public string formulavalue;
        public string formulaunit;
        public bool check = false;
        public bool selected = false;
        public int dimsel = 0;//量纲选择
        public string formulaexplain = "";
        public bool show;
        public ItemSignal myitemsignal;
        public double limitup = 10000; //合格范围上限
        public double limitdown = 0;//合格范围下限
        public bool apply = false;//表格标题显示方式,false 显示公式名称 true 显示公式说明



        public Object Clone()
        {
            return this.MemberwiseClone();

        }

    }

    [Serializable]
    public class userchannelitem
    {
        public string channelname;
        public string channelvalue;
        public string channelunit;
        public int channel_dimensionkind;

        public ItemSignal myitemsignal;


    }

    [Serializable]
    public class tablelaycoutstruct
    {
        int colcount;
        int rowcount;
        int[] colwidth;
        int[] rowheight;


    }

    [Serializable]
    public class FileLayoutStruct
    {
        public string name = "";
        public string datapath = "";

        public int rowcount;
        public int colcount;
        public int[] rowheight;
        public int[] colWidth;
        public string[] ItemName;
        public int[] ItemCol;
        public int[] ItemRow;
        public int[] ItemColSpan;
        public int[] ItemRowSpan;
        public bool[] Show;

        public int height;
        public int width;

        public FileLayoutStruct()
        {
            ItemName = new string[20];
            ItemCol = new int[20];
            ItemRow = new int[20];
            ItemColSpan = new int[20];
            ItemRowSpan = new int[20];
            Show = new bool[20];
            rowheight = new int[20];
            colWidth = new int[20];

        }

        public void SerializeNow(string filename)
        {

            FileStream fileStream =
            new FileStream(filename, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(fileStream, this);
            fileStream.Close();
        }
        public FileLayoutStruct DeSerializeNow(string filename)
        {
            FileLayoutStruct c = new FileLayoutStruct();
            try
            {


                using (FileStream fileStream =
                 new FileStream(filename,
                 FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    BinaryFormatter b = new BinaryFormatter();

                    c = b.Deserialize(fileStream) as FileLayoutStruct;


                    fileStream.Close();

                }
            }
            catch (Exception e1)
            {
                c = new FileLayoutStruct();
                if (CComLibrary.GlobeVal.languageselect == 0)
                {
                    MessageBox.Show(e1.Message, "读取文件");
                }
                else
                {
                    MessageBox.Show(e1.Message, "Read file");
                }
            }
            finally
            {

            }
            return (c);
        }
    }



    [Serializable]
    public class TableHeaderPara
    {
        public Font HeaderFont;
        public ContentAlignment HeaderAlignment;
        public Color HeaderBackColor;
        public Color HeaderForeColor;

        public TableHeaderPara()
        {
            HeaderFont = new Font("宋体", 12);
            HeaderAlignment = ContentAlignment.MiddleCenter;
            HeaderBackColor = SystemColors.ButtonFace;
            HeaderForeColor = Color.Black;

        }

    }
    [Serializable]
    public class TableColPara
    {
        public Font ColFont;
        public ContentAlignment ColAlignment;
        public Color ColBackColor;
        public Color ColForeColor;

        public TableColPara()
        {
            ColFont = new Font("宋体", 12);
            ColAlignment = ContentAlignment.MiddleRight;
            ColBackColor = SystemColors.ButtonFace;
            ColForeColor = Color.Black;
        }
    }

    [Serializable]
    public class TableGridPara
    {
        public Font GridFont;
        public ContentAlignment GridAlignment;
        public Color GridBackColor;
        public Color GridForeColor;

        public TableGridPara()
        {
            GridFont = new Font("宋体", 12);
            GridAlignment = ContentAlignment.MiddleCenter;
            GridBackColor = Color.White;
            GridForeColor = Color.Black;
        }
    }


    [Serializable]
    public class TablePara
    {
        public TableHeaderPara mTableHeaderPara;
        public TableColPara mTableColPara;
        public TableGridPara mTableGridPara;
        public Boolean showvalidspe = true;

        public int statisticssel = 0;

        public TablePara()
        {
            mTableHeaderPara = new TableHeaderPara();
            mTableColPara = new TableColPara();
            mTableGridPara = new TableGridPara();
        }


    }

    [Serializable]
    public class PromptsItem
    {
        public string itemname;
        public string[] Litemname;

        public int itemkind;

        public string parentstring;

        public string[] Lparentstring;



        public event EventHandler PropertyChanged;
        private object mitemvalue = null;

        public bool group = false;

        public bool used = false;

        public int level = 0;

        public cboitem mcboitem;

        public string itemunit;


        public void checkzero()  //判断输入值是否为0

        {
            double v = 0;
            for (int i = 0; i <
       CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem.Length; i++)
            {

                if (itemname == CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[i].cName)
                {

                    v = Convert.ToDouble( CComLibrary.GlobeVal.filesave.dt.Rows[CComLibrary.GlobeVal.filesave.currentspenumber][itemname]);

                    if (CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[i].checkzero ==true)
                    {
                        if (CComLibrary.GlobeVal.languageselect == 0)
                        {
                            MessageBox.Show(itemname + "不能为0,请重新输入");
                        }
                        else
                        {
                            MessageBox.Show(itemname + " can't be 0. Please re-enter.");
                        }

                    }

                }

            }

        }
        public void getvalue()
        {
            mitemvalue = " ";
            string temp = "";
            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                temp = "样品注释1";
            }
            else
            {
                temp = "Sample note 1";
            }


            if (itemname == temp)
            {


                mitemvalue = CComLibrary.GlobeVal.filesave.samplememo1;


                itemkind = 0;
            }

            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                temp = "样品注释2";
            }
            else
            {
                temp = "Sample note 2";
            }



            if (itemname == temp)
            {
                mitemvalue = CComLibrary.GlobeVal.filesave.samplememo2;

                itemkind = 0;

            }

            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                temp = "样品注释3";
            }
            else
            {
                temp = "Sample note 3";
            }


            if (itemname == temp)
            {
                mitemvalue = CComLibrary.GlobeVal.filesave.samplememo3;

                itemkind = 0;

            }
            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                temp = "样品说明";
            }
            else
            {
                temp = "Sample description";
            }



            if (itemname ==temp)
            {
                mitemvalue = CComLibrary.GlobeVal.filesave.samplememo;

                itemkind = 0;

            }

            for (int i = 0; i <
         CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem.Length; i++)
            {

                if (itemname == CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[i].cName)
                {

                    mitemvalue = CComLibrary.GlobeVal.filesave.dt.Rows[CComLibrary.GlobeVal.filesave.currentspenumber][itemname];

                    if (mitemvalue.ToString() == "")
                    {

                        mitemvalue = CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[i].cvalue.ToString();
                        CComLibrary.GlobeVal.filesave.dt.Rows[CComLibrary.GlobeVal.filesave.currentspenumber][itemname] = mitemvalue;


                    }

                    itemunit = CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[i].cUnits[
                        CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[i].cUnitsel];
                    itemkind = 1;
                }

            }

            for (int i = 0; i <
             CComLibrary.GlobeVal.filesave.minputtext.Count; i++)
            {
                if (itemname == CComLibrary.GlobeVal.filesave.minputtext[i].name)
                {
                    mitemvalue = CComLibrary.GlobeVal.filesave.dt.Rows[CComLibrary.GlobeVal.filesave.currentspenumber][itemname];

                    if (mitemvalue.ToString() == "")
                    {

                        mitemvalue = CComLibrary.GlobeVal.filesave.minputtext[i].value;
                        CComLibrary.GlobeVal.filesave.dt.Rows[CComLibrary.GlobeVal.filesave.currentspenumber][itemname] = mitemvalue;

                    }
                    itemkind = 0;
                }
            }

            for (int i = 0; i <
                   CComLibrary.GlobeVal.filesave.minput.Count; i++)
            {

                if (itemname == CComLibrary.GlobeVal.filesave.minput[i].name)
                {
                    mitemvalue = CComLibrary.GlobeVal.filesave.dt.Rows[CComLibrary.GlobeVal.filesave.currentspenumber][itemname];
                    if (mitemvalue.ToString() == "")
                    {
                        mitemvalue = CComLibrary.GlobeVal.filesave.minput[i].value.ToString();
                        CComLibrary.GlobeVal.filesave.dt.Rows[CComLibrary.GlobeVal.filesave.currentspenumber][itemname] = mitemvalue;
                    }
                    itemunit = CComLibrary.GlobeVal.filesave.minput[i].myitemsignal.cUnits[CComLibrary.GlobeVal.filesave.minput[i].myitemsignal.cUnitsel];
                    itemkind = 1;
                }
            }

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mcbo.Count; i++)
            {

                if (itemname == CComLibrary.GlobeVal.filesave.mcbo[i].Name)
                {
                    mitemvalue = CComLibrary.GlobeVal.filesave.dt.Rows[CComLibrary.GlobeVal.filesave.currentspenumber][itemname];

                    if (mitemvalue.ToString() == "")
                    {
                        mitemvalue = CComLibrary.GlobeVal.filesave.mcbo[i].value.ToString();
                        CComLibrary.GlobeVal.filesave.dt.Rows[CComLibrary.GlobeVal.filesave.currentspenumber][itemname] = mitemvalue;
                    }
                    mcboitem = CComLibrary.GlobeVal.filesave.mcbo[i];

                    itemkind = 2;
                }
            }

            if (mitemvalue == null)
            {
                mitemvalue = " ";
            }

        }

        public void setvalue()
        {
            string temp = "";
            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                temp = "样品注释1";
            }
            else
            {
                temp = "Sample note 1";
            }

            if (itemname == temp)
            {
                CComLibrary.GlobeVal.filesave.samplememo1 = Convert.ToString(mitemvalue);
            }
            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                temp = "样品注释2";
            }
            else
            {
                temp = "Sample note 2";
            }
            if (itemname == temp)
            {
                CComLibrary.GlobeVal.filesave.samplememo2 = Convert.ToString(mitemvalue);
            }
            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                temp = "样品注释3";
            }
            else
            {
                temp = "Sample note 3";
            }
            if (itemname == temp)
            {
                CComLibrary.GlobeVal.filesave.samplememo3 = Convert.ToString(mitemvalue);
            }

            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                temp = "样品说明";
            }
            else
            {
                temp = "Sample description";
            }


            if (itemname ==temp)
            {
                CComLibrary.GlobeVal.filesave.samplememo = Convert.ToString(mitemvalue);
            }

            for (int i = 0; i <
                 CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem.Length; i++)
            {

                if (itemname == CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[i].cName)
                {


                    CComLibrary.GlobeVal.filesave.dt.Rows[CComLibrary.GlobeVal.filesave.currentspenumber][itemname] = Convert.ToDouble(mitemvalue);
                    CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[i].cvalue = Convert.ToDouble(mitemvalue);

                }

            }

            for (int i = 0; i <
             CComLibrary.GlobeVal.filesave.minputtext.Count; i++)
            {
                if (itemname == CComLibrary.GlobeVal.filesave.minputtext[i].name)
                {
                    CComLibrary.GlobeVal.filesave.dt.Rows[CComLibrary.GlobeVal.filesave.currentspenumber][itemname] = Convert.ToString(mitemvalue);
                    CComLibrary.GlobeVal.filesave.minputtext[i].value = Convert.ToString(mitemvalue);
                }
            }

            for (int i = 0; i <
                  CComLibrary.GlobeVal.filesave.minput.Count; i++)
            {

                if (itemname == CComLibrary.GlobeVal.filesave.minput[i].name)
                {
                    CComLibrary.GlobeVal.filesave.dt.Rows[CComLibrary.GlobeVal.filesave.currentspenumber][itemname] = Convert.ToDouble(mitemvalue);
                    CComLibrary.GlobeVal.filesave.minput[i].value = Convert.ToDouble(mitemvalue);

                }
            }


            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mcbo.Count; i++)
            {

                if (itemname == CComLibrary.GlobeVal.filesave.mcbo[i].Name)
                {
                    CComLibrary.GlobeVal.filesave.dt.Rows[CComLibrary.GlobeVal.filesave.currentspenumber][itemname] = Convert.ToInt32(mitemvalue);
                    CComLibrary.GlobeVal.filesave.mcbo[i].value = Convert.ToInt32(mitemvalue);


                }
            }

        }

        public object itemvalue
        {
            get
            {
                getvalue();



                return mitemvalue;
            }
            set
            {
                mitemvalue = value;

                setvalue();

                this.OnPropertyChanged(new EventArgs());
                //每次改变Name值调用方法;            
            }
        }

        private void OnPropertyChanged(EventArgs eventArgs)
        {
            if (this.PropertyChanged != null)
            //判断事件是否有处理函数 
            {

                this.PropertyChanged(this, eventArgs);
            }
        }
        public PromptsItem()
        {
            Litemname = new string[10];
            Lparentstring = new string[10];
        }





    }

    [Serializable]

    public class Sequence
    {
        public int wavekind;
        public string stepname;
        public int controlmode;
        public ItemSignal rate;
        public ItemSignal dest;
        public double keeptime;
        public long cycles;
        public int direction;
        public int maxmeasure;
        public ItemSignal maxvalue;
        public int minmeasure;
        public ItemSignal minvalue;

        public bool loop = false;
        public int returnstep = 0;
        public int loopcount = 0;
        public int finishedloopcount = 0;

        public ItemSignal[] sign = new ItemSignal[20];

        public double mrate;
        public double mdest;

        public int mrateunit = 0;
        public int mdestunit = 0;

        public int destcontrolmode = 0;

        public int destmode = 0;

        public double mtrirate;
        public int mtrirateunit = 0;

        public double mtriratedown;
        public int mtriratedownunit = 0;

        public long mcount;

        public long mfinishedcount = 0;

        public long mcurrentcount = 0;//用作变量使用



        public int mtriinitdir;

        public int mtricbomax;

        public double mtrimax;
        public double mtrimin;

        public ItemSignal trirate;

        public ItemSignal triratedown;

        public ItemSignal sinrate;
        public double msinrate;
        public int msinrateunit = 0;

        public int msininitdir;
        public double msinmax;
        public double msinmin;
        public double msinfreq;




        public bool runfinished = false;


        public ItemSignal rectrate;
        public double mrectrate;
        public int mrectrateunit = 0;
        public int mrectcount = 0;
        public int mrectinitdir = 0;
        public double mrectuprate;
        public double mrectdownrate;
        public double mrectupdest;
        public double mrectdowndest;
        public double mrectupkeeptime;
        public double mrectdownkeeptime;



        public int samplingmode = 0;//采样方式

        public Boolean[] chkchannel = new Boolean[20];
        public double[] sampleinterval = new double[20];
        public double[] sampleintervaltemp = new double[20];


        public bool msavetracking = false;
        public bool msavepeaktrend = false;
        public int[] msavetrackingrow1;
        public int[] msavetrackingrow2;
        public int[] msavetrackingrow3;

        public int[] msavepeaktrendrow1;
        public int[] msavepeaktrendrow2;
        public int[] msavepeaktrendrow3;


        public int msavemode_forflow = 0;//跟踪数据保存模式
        public int msavemode_forappend = 0;//追加数据保存模式


        public int chkchannelcount = 0;
        public Sequence()
        {
            wavekind = 0;
            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                stepname = "斜波";
            }
            else
            {
                stepname = "Ramp ";
            }
            controlmode = 0;
            rate = new ClsStaticStation.ItemSignal();
            dest = new ClsStaticStation.ItemSignal();
            keeptime = 0;
            cycles = 0;
            direction = 0;
            destmode = 0;

            msavetrackingrow1 = new int[20];
            msavetrackingrow2 = new int[20];
            msavetrackingrow3 = new int[20];

            msavepeaktrendrow1 = new int[20];
            msavepeaktrendrow2 = new int[20];
            msavepeaktrendrow3 = new int[20];


        }

    }

    [Serializable]
    public class SequenceFile
    {



        public List<Sequence> mSequencelist;

        public void clear()
        {
            mSequencelist.Clear();
        }


        public void Insert(int index)
        {
            Sequence r = new Sequence();
            mSequencelist.Insert(index, r);
        }
        public void add()
        {
            Sequence r = new Sequence();

            mSequencelist.Add(r);

        }

        public void add(Sequence r)
        {

            mSequencelist.Add(r);

        }
        public SequenceFile()
        {



            mSequencelist = new List<Sequence>();

            mSequencelist.Clear();


        }

        public void SerializeNow(string filename)
        {

            FileStream fileStream =
            new FileStream(filename, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(fileStream, this);
            fileStream.Close();
        }
        public SequenceFile DeSerializeNow(string filename)
        {
            SequenceFile c = new SequenceFile();
            try
            {


                using (FileStream fileStream =
                 new FileStream(filename,
                 FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    BinaryFormatter b = new BinaryFormatter();

                    c = b.Deserialize(fileStream) as SequenceFile;

                    for (int i = 0; i < c.mSequencelist.Count; i++)
                    {
                        if (c.mSequencelist[i].chkchannel == null)
                        {
                            c.mSequencelist[i].chkchannel = new Boolean[20];
                        }
                        if (c.mSequencelist[i].sampleinterval == null)
                        {
                            c.mSequencelist[i].sampleinterval = new double[20];
                        }
                        if (c.mSequencelist[i].sampleintervaltemp == null)
                        {
                            c.mSequencelist[i].sampleintervaltemp = new double[20];
                        }

                        if (c.mSequencelist[i].msavetrackingrow1 == null)
                        {
                            c.mSequencelist[i].msavetrackingrow1 = new int[20];

                        }

                        if (c.mSequencelist[i].msavetrackingrow2 == null)
                        {
                            c.mSequencelist[i].msavetrackingrow2 = new int[20];

                        }
                        if (c.mSequencelist[i].msavetrackingrow3 == null)
                        {
                            c.mSequencelist[i].msavetrackingrow3 = new int[20];

                        }

                        if (c.mSequencelist[i].msavepeaktrendrow1 == null)
                        {
                            c.mSequencelist[i].msavepeaktrendrow1 = new int[20];

                        }

                        if (c.mSequencelist[i].msavepeaktrendrow2 == null)
                        {
                            c.mSequencelist[i].msavepeaktrendrow2 = new int[20];

                        }
                        if (c.mSequencelist[i].msavepeaktrendrow3 == null)
                        {
                            c.mSequencelist[i].msavepeaktrendrow3 = new int[20];

                        }

                    }

                    fileStream.Close();



                }
            }
            catch (Exception e1)
            {
                c = new SequenceFile();


                if (CComLibrary.GlobeVal.languageselect == 0)

                {

                    MessageBox.Show(e1.Message, "读取文件");
                }
                else
                {
                    MessageBox.Show(e1.Message, "Read file");
                }
            }
            finally
            {

            }
            return (c);
        }
    }
    [Serializable]
    public class SegTest
    {
        public int cmd;//控制模式

        public int dir;//方向  0 上升，1 下降
        public int controlmode;//控制方式
        public double speed;//速度
        public int destcontrolmode;//目标控制方式
        public double dest;//目标值
        public int action;// 动作

        public bool cyclicrun;//循环执行
        public int returnstep; //返回到步骤
        public int cycliccount;//循环次数
        public int havedcount;//已经循环次数
        public string explain;//说明

        public double keeptime;//保持时间


        public double mstartload;
        public double mendload;
        public double mstartstrain;
        public double mendstrain;
        public double mstrainspeed;


        public int destmod = 0;//目标控制模式

        public string cyclicconvert()
        {
            string s = "";

            if (cyclicrun == true)
            {
                if (returnstep > 0)
                {
                    if (cycliccount > 0)
                    {
                        if (CComLibrary.GlobeVal.languageselect == 0)
                        {
                            s = "返回" + cycliccount.ToString() + "次," + "返回到步骤" + returnstep.ToString();
                        }
                        else
                        {
                            s = "Return to" + cycliccount.ToString() + "times," + "Return to step" + returnstep.ToString();
                        }
                    }
                }
            }
            return s;
        }
        public string speedconvert()
        {
            string s = "";



            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals.Count; i++)
            {
                if (controlmode == i)
                {
                    if (CComLibrary.GlobeVal.languageselect == 0)
                    {
                        s = "速度:" + speed.ToString("F4") + ClsStaticStation.m_Global.mycls.hardsignals[i].speedSignal.cUnits[0];
                    }
                    else
                    {
                        s = "The rate is " + speed.ToString("F4") + ClsStaticStation.m_Global.mycls.hardsignals[i].speedSignal.cUnits[0];
                    }


                }



            }

            return s;
        }

        public string destconvert()
        {

            string s = "";



            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals.Count; i++)
            {
                if (destcontrolmode == i)
                {
                    if (CComLibrary.GlobeVal.languageselect == 0)
                    {
                        s = "当" + ClsStaticStation.m_Global.mycls.hardsignals[i].cName + "到达" +

                            dest.ToString("F4") + ClsStaticStation.m_Global.mycls.hardsignals[i].cUnits[0] + "时";
                    }
                    else
                    {
                        s = "When the" + ClsStaticStation.m_Global.mycls.hardsignals[i].cName + "reaches" +

                           dest.ToString("F4") + ClsStaticStation.m_Global.mycls.hardsignals[i].cUnits[0] ;

                      

                    }


                }



            }

            if (keeptime == 0)
            {

            }
            else
            {
                if (CComLibrary.GlobeVal.languageselect == 0)
                {
                    s = s + ",保持" + keeptime.ToString() + "s";
                }
                else
                {
                    s = s + ",Keep" + keeptime.ToString() + "s";
                }
            }

            if (destmod == 0)
            {
                if (CComLibrary.GlobeVal.languageselect == 0)
                {
                    s = s + ",切换";
                }
                else
                {
                    s = s + ", Switch"; 
                }

            }
            else if (destmod == 1)
            {
                if (CComLibrary.GlobeVal.languageselect == 0)
                {
                    s = s + ",不切换";
                }
                else
                {
                    s = s + ", No switch";
                }
            }
            else if (destmod == 2)
            {
                if (CComLibrary.GlobeVal.languageselect == 0)
                {
                    s = s + ",跟随";
                }
                else
                {
                    s = s + ",Follow";
                }
            }

            return s;
        }

        public string dirconvert()
        {
            return "";

        }

        public SegTest()
        {

            cmd = 0;
            dir = 1;//上升
            controlmode = 0;
            speed = 0.1;
            destcontrolmode = 0;
            dest = 0;
            action = 0;
            returnstep = 0;
            cycliccount = 0;
            explain = "";
            keeptime = 0;
        }
    }


    [Serializable]
    public class SegFile
    {
        public int cmdstingcount;
        public string[] cmdstring;
        public string[] actionstring;

        public List<SegTest> mseglist;

        public void clear()
        {
            mseglist.Clear();
        }

        public void add()
        {
            SegTest r = new SegTest();

            mseglist.Add(r);

        }

        public SegFile()
        {

            cmdstring = new string[16];

            for (int i = 0; i < m_Global.mycls.hardsignals.Count; i++)
            {
                if (m_Global.mycls.machinekind == 6)
                {
                    if (CComLibrary.GlobeVal.languageselect == 0)
                    {
                        cmdstring[i] = "通道" + (m_Global.mycls.hardsignals[i].EdcChannleSel + 1).ToString() + "-" + m_Global.mycls.hardsignals[i].cName;
                    }
                    else
                    {
                        cmdstring[i] = "Channel" + (m_Global.mycls.hardsignals[i].EdcChannleSel + 1).ToString() + "-" + m_Global.mycls.hardsignals[i].cName;
                    }
                }
                else
                {
                    cmdstring[i] = m_Global.mycls.hardsignals[i].cName;
                }
            }
            cmdstingcount = m_Global.mycls.hardsignals.Count;

            actionstring = new string[2];
            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                actionstring[0] = "顺序执行";
                actionstring[1] = "同步执行";
            }
            else
            {
                actionstring[0] = "Sequential execution";
                actionstring[1] = "Synchronous execution";
            }

            mseglist = new List<SegTest>();

            mseglist.Clear();



        }

        public void Initcmdstring(int count, params string[] m)
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
        public SegFile DeSerializeNow(string filename)
        {
            SegFile c = new SegFile();
            try
            {


                using (FileStream fileStream =
                 new FileStream(filename,
                 FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    BinaryFormatter b = new BinaryFormatter();

                    c = b.Deserialize(fileStream) as SegFile;

                    c.actionstring = new string[2];
                    if (CComLibrary.GlobeVal.languageselect == 0)
                    {
                        c.actionstring[0] = "顺序执行";
                        c.actionstring[1] = "同步执行";
                    }
                    else
                    {
                        c.actionstring[0] = "Sequential execution";
                        c.actionstring[1] = "Synchronous execution";
                    }

                    c.cmdstring = new string[m_Global.mycls.hardsignals.Count];

                    for (int i = 0; i < m_Global.mycls.hardsignals.Count; i++)
                    {
                        if (m_Global.mycls.machinekind == 6)
                        {
                            if (CComLibrary.GlobeVal.languageselect == 0)
                            {

                                c.cmdstring[i] = "通道" + (m_Global.mycls.hardsignals[i].EdcChannleSel + 1).ToString() + "-" + m_Global.mycls.hardsignals[i].cName;
                            }
                            else
                            {
                                c.cmdstring[i] = "Channel " + (m_Global.mycls.hardsignals[i].EdcChannleSel + 1).ToString() + "-" + m_Global.mycls.hardsignals[i].cName;
                            }
                        }
                        else
                        {
                            c.cmdstring[i] = m_Global.mycls.hardsignals[i].cName;
                        }
                    }
                    c.cmdstingcount = m_Global.mycls.hardsignals.Count;

                    fileStream.Close();



                }
            }
            catch (Exception e1)
            {
                c = new SegFile();

                if (CComLibrary.GlobeVal.languageselect == 0)
                {
                    MessageBox.Show(e1.Message, "读取文件");
                }
                else
                {
                    MessageBox.Show(e1.Message, "Read file");
                }
            }
            finally
            {

            }
            return (c);
        }
    }

    [Serializable]
    public class CTestStep
    {

        public int Id = -1;

        public bool havedloop = false;

        public int nextstep = -1;

        public string mtooltip = "";

        public List<PromptsItem> mstepPromptsItem = new List<PromptsItem>();


    }

    public enum TestStatus
    {
        Untested = 0,
        tested = 1,
        novalid = 2,
        RemoveExt = 3

    };

    [Serializable]
    public class CmdSeg
    {

        public bool check;
        public int controlmode;
        public double speed;
        public int destcontrolmode;
        public double dest;
        public double keeptime;
        public int returncount;
        public int returnstep;
        public int cmd;
        public int action;
        public int explainkind = 0;// 命令解释类型
        public Sequence mseq;

        public int speedunit = 0;
        public int destunit = 0;
        public int currentcount = 1;
        public int destmode = 0;//控制模式





        public double speedorigin()
        {
            double t = 0;
            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals.Count; i++)
            {
                if (controlmode == i)
                {

                    t = Convert.ToDouble(ClsStaticStation.m_Global.mycls.hardsignals[i].speedSignal.GetOriValue(speed, speedunit));
                }
            }
            return t;
        }
        public double destorigin()

        {
            double t = 0;
            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals.Count; i++)
            {
                if (destcontrolmode == i)
                {
                    t = Convert.ToDouble(ClsStaticStation.m_Global.mycls.hardsignals[i].GetOriValue(dest, destunit));
                }
            }

            return t;
        }


        public CmdSeg()
        {
            check = false;
            controlmode = 0;
            speed = 0.1;
            destcontrolmode = 0;
            dest = 0;
            keeptime = 0;
            returncount = 0;
            returnstep = 0;
            speedunit = 0;
            destunit = 0;
            cmd = 0;

            mseq = new Sequence();


        }

        public string speedconvert()
        {
            string s = "";



            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals.Count; i++)
            {
                if (controlmode == i)
                {
                    if (CComLibrary.GlobeVal.languageselect == 0)
                    {
                        s = "速度:" + speed.ToString("F4") + ClsStaticStation.m_Global.mycls.hardsignals[i].speedSignal.cUnits[speedunit];
                    }
                    else
                    {
                        s = "rate:" + speed.ToString("F4") + ClsStaticStation.m_Global.mycls.hardsignals[i].speedSignal.cUnits[speedunit];
                    }
                    if (controlmode == 1)
                    {
                        s = s + "[" + CComLibrary.GlobeVal.filesave.LoadToStrain(speedorigin()).ToString("F4") + "MPa/s]";

                    }

                    //  s = s + "原始速度:" + speedorigin().ToString("F4") + " ";
                }



            }

            return s;
        }



        public string destconvert()
        {

            string s = "";



            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals.Count; i++)
            {
                if (destcontrolmode == i)
                {

                    if (CComLibrary.GlobeVal.languageselect == 0)
                    {
                        s = "当" + ClsStaticStation.m_Global.mycls.hardsignals[i].cName + "到达" +

                            dest.ToString("F4") + ClsStaticStation.m_Global.mycls.hardsignals[i].cUnits[destunit] + "时";

                    }
                    else
                    {
                        s = "When the " + ClsStaticStation.m_Global.mycls.hardsignals[i].cName + " reaches" +

                           dest.ToString("F4") + ClsStaticStation.m_Global.mycls.hardsignals[i].cUnits[destunit] ;
                    }

                    if (destcontrolmode == 1)
                    {
                        s = s + "[" + CComLibrary.GlobeVal.filesave.LoadToStrain(destorigin()).ToString("F4") + "MPa]";

                    }

                }



            }

            if (keeptime == 0)
            {

            }
            else
            {
                if (CComLibrary.GlobeVal.languageselect == 0)
                {
                    s = s + ",保持" + keeptime.ToString() + "s";
                }
                else
                {
                    s = s + ",hold" + keeptime.ToString() + "s";
                }
            }

            if (destmode == 0)
            {
                if (CComLibrary.GlobeVal.languageselect == 0)
                {
                    s = s + ",切换";
                }
                else
                {
                    s = s + ",switch";
                }
            }
            else if (destmode == 1)
            {
                if (CComLibrary.GlobeVal.languageselect == 0)
                {
                    s = s + ",不切换";
                }
                else
                {
                    s = s + ",no switch";
                }
            }
            else if (destmode == 2)
            {
                if (CComLibrary.GlobeVal.languageselect == 0)
                {
                    s = s + ",跟随";
                }
                else
                {
                    s = s + ",follow";
                }
            }

            return s;
        }

        public string seqwavekindconvert()
        {
            string s = "";
            s = s + mseq.stepname + " ";


            return s;
        }

        public string seqcontrolmodeconvert()
        {
            string s = "";
            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals.Count; i++)
            {
                if (mseq.controlmode == i)
                {
                    if (CComLibrary.GlobeVal.languageselect == 0)
                    {
                        s = "控制方式：";
                    }
                    else
                    {
                        s = "Control mode";
                    }
                    s = s + ClsStaticStation.m_Global.mycls.hardsignals[i].cName;
                }
            }
            s = s + " ";
            return s;
        }

        public string seqcmd()
        {
            string s = "";

            if (mseq.wavekind == 0)
            {
                for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals.Count; i++)
                {
                    if (mseq.controlmode == i)
                    {
                        if (CComLibrary.GlobeVal.languageselect == 0)
                        {
                            s = s + "速度:" + mseq.mrate.ToString("F4") + ClsStaticStation.m_Global.mycls.hardsignals[i].speedSignal.cUnits[mseq.mrateunit];
                        }
                        else
                        {
                            s = s + "rate:" + mseq.mrate.ToString("F4") + ClsStaticStation.m_Global.mycls.hardsignals[i].speedSignal.cUnits[mseq.mrateunit];
                        }
                    }
                }

                for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals.Count; i++)
                {
                    if (mseq.destcontrolmode == i)
                    {
                        if (CComLibrary.GlobeVal.languageselect == 0)
                        {
                            s = s + "目标:" + mseq.mdest.ToString("F4") + ClsStaticStation.m_Global.mycls.hardsignals[i].cUnits[mseq.mdestunit];
                        }
                        else
                        {
                            s = s + "Dest:" + mseq.mdest.ToString("F4") + ClsStaticStation.m_Global.mycls.hardsignals[i].cUnits[mseq.mdestunit];
                        }
                    }
                }

            }

            if (mseq.wavekind == 1)
            {
                if (CComLibrary.GlobeVal.languageselect == 0)
                {
                    s = s + "保持：" + mseq.keeptime.ToString() + "S";
                }
                else
                {
                    s = s + "hold:" + mseq.keeptime.ToString() + "S";
                }
            }

            if (mseq.wavekind == 2)
            {
                for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals.Count; i++)
                {
                    if (mseq.controlmode == i)
                    {
                        if (CComLibrary.GlobeVal.languageselect == 0)
                        {
                            s = s + "速度:" + mseq.mtrirate.ToString("F4") + ClsStaticStation.m_Global.mycls.hardsignals[i].speedSignal.cUnits[mseq.mtrirateunit];
                        }
                        else
                        {
                            s = s + "rate:" + mseq.mtrirate.ToString("F4") + ClsStaticStation.m_Global.mycls.hardsignals[i].speedSignal.cUnits[mseq.mtrirateunit];
                        }
                    }
                }

                if (CComLibrary.GlobeVal.languageselect == 0)
                {
                    s = s + " 次数：" + mseq.mcount.ToString();
                }
                else
                {
                    s = s + " Count:" + mseq.mcount.ToString();
                }
                if (mseq.mtriinitdir == 0)
                {
                    if (CComLibrary.GlobeVal.languageselect == 0)
                    {
                        s = s + " 初始方向：向上";
                    }
                    else
                    {
                        s = s + " Initial direction: upward";
                    }

                }
                else
                {
                    if (CComLibrary.GlobeVal.languageselect == 0)
                    {
                        s = s + " 初始方向：向下";
                    }
                    else
                    {
                        s = s + " Initial direction: down";
                    }
                }
                if (CComLibrary.GlobeVal.languageselect == 0)
                {
                    s = s + " 最大值：" + mseq.mtrimax.ToString("F4");
                    s = s + " 最小值：" + mseq.mtrimin.ToString("F4");
                }
                else
                {
                    s = s + " Maximum value:" + mseq.mtrimax.ToString("F4");
                    s = s + " Minimum value:" + mseq.mtrimin.ToString("F4");
                }

            }

            if (mseq.wavekind == 3)
            {
                for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals.Count; i++)
                {
                    if (mseq.controlmode == i)
                    {
                        if (CComLibrary.GlobeVal.languageselect == 0)
                        {
                            s = s + "速度:" + mseq.msinrate.ToString("F4") + ClsStaticStation.m_Global.mycls.hardsignals[i].speedSignal.cUnits[mseq.msinrateunit];
                        }
                        else
                        {
                            s = s + "rate:" + mseq.msinrate.ToString("F4") + ClsStaticStation.m_Global.mycls.hardsignals[i].speedSignal.cUnits[mseq.msinrateunit];
                        }
                    }
                }

                if (CComLibrary.GlobeVal.languageselect == 0)
                {
                    s = s + " 次数：" + mseq.mcount.ToString();
                }
                else
                {
                    s = s + " Count:" + mseq.mcount.ToString();
                }
                if (mseq.msininitdir == 0)
                {
                    if (CComLibrary.GlobeVal.languageselect == 0)
                    {
                        s = s + " 初始方向：向上";
                    }
                    else
                    {
                        s = s + " Initial direction: upward";
                    }

                }
                else
                {
                    if (CComLibrary.GlobeVal.languageselect == 0)
                    {
                        s = s + " 初始方向：向下";
                    }
                    else
                    {
                        s = s + " Initial direction: down";
                    }
                }

                if (CComLibrary.GlobeVal.languageselect == 0)
                {
                    s = s + " 频率：" + mseq.msinfreq.ToString("F4");

                    s = s + " 最大值：" + mseq.msinmax.ToString("F4");
                    s = s + " 最小值：" + mseq.msinmin.ToString("F4");
                }
                else
                {
                    s = s + " Freq:" + mseq.msinfreq.ToString("F4");

                    s = s + " Maximum value:" + mseq.msinmax.ToString("F4");
                    s = s + " Minimum value:" + mseq.msinmin.ToString("F4");
                }
            }

            if (mseq.wavekind == 4)
            {
                for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals.Count; i++)
                {
                    if (mseq.controlmode == i)
                    {
                        if (CComLibrary.GlobeVal.languageselect == 0)
                        {
                            s = s + "速度：" + mseq.mrectrate.ToString("F4") + ClsStaticStation.m_Global.mycls.hardsignals[i].speedSignal.cUnits[mseq.mrectrateunit];
                        }
                        else
                        {
                            s = s + "rate:" + mseq.mrectrate.ToString("F4") + ClsStaticStation.m_Global.mycls.hardsignals[i].speedSignal.cUnits[mseq.mrectrateunit];

                        }
                    }
                }

                if (CComLibrary.GlobeVal.languageselect == 0)
                {

                    s = s + " 次数：" + mseq.mrectcount.ToString();
                }
                else
                {
                    s = s + " Count:" + mseq.mrectcount.ToString();
                }

                if (mseq.mrectinitdir == 0)
                {
                    if (CComLibrary.GlobeVal.languageselect == 0)
                    {
                        s = s + " 初始方向：向上";
                    }
                    else
                    {
                        s = s + " Initial direction: upward";
                    }

                }
                else
                {
                    if (CComLibrary.GlobeVal.languageselect == 0)
                    {
                        s = s + " 初始方向：向下";
                    }
                    else
                    {
                        s = s + " Initial direction: down";
                    }
                }

                for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals.Count; i++)
                {
                    if (mseq.controlmode == i)
                    {
                        if (CComLibrary.GlobeVal.languageselect == 0)
                        {
                            s = s + "上升速度:" + mseq.mrectuprate.ToString("F4") + ClsStaticStation.m_Global.mycls.hardsignals[i].speedSignal.cUnits[mseq.mrectrateunit];
                        }
                        else
                        {
                            s = s + "Rising rate:" + mseq.mrectuprate.ToString("F4") + ClsStaticStation.m_Global.mycls.hardsignals[i].speedSignal.cUnits[mseq.mrectrateunit];
                            
                        }
                    }

                    if (mseq.controlmode == i)
                    {
                        if (CComLibrary.GlobeVal.languageselect == 0)
                        {
                            s = s + "上升目标:" + mseq.mrectupdest.ToString("F4");

                            s = s + "上升保持时间：" + mseq.mrectupkeeptime.ToString("F2") + "S";
                        }
                        else
                        {
                            s = s + "Rising dest:" + mseq.mrectupdest.ToString("F4");

                            s = s + "Rising keep time：" + mseq.mrectupkeeptime.ToString("F2") + "S";
                        }
                    }




                    if (mseq.controlmode == i)
                    {
                        if (CComLibrary.GlobeVal.languageselect == 0)
                        {
                            s = s + "下降速度:" + mseq.mrectdownrate.ToString("F4") + ClsStaticStation.m_Global.mycls.hardsignals[i].speedSignal.cUnits[mseq.mrectrateunit];
                        }
                        else
                        {
                            s = s + "Descending rate:" + mseq.mrectdownrate.ToString("F4") + ClsStaticStation.m_Global.mycls.hardsignals[i].speedSignal.cUnits[mseq.mrectrateunit];
                        }
                    }

                    if (mseq.controlmode == i)
                    {
                        if (CComLibrary.GlobeVal.languageselect == 0)
                        {
                            s = s + "下降目标:" + mseq.mrectdownrate.ToString("F4");
                            s = s + "下降保持时间：" + mseq.mrectdownkeeptime.ToString("F2") + "S";
                        }
                        else
                        {
                            s = s + "Descending dest:" + mseq.mrectdownrate.ToString("F4");
                            s = s + "Descending keep time：" + mseq.mrectdownkeeptime.ToString("F2") + "S";
                        }
                    }



                }
            }

            s = s + " ";
            return s;
        }


        public string explain(int machinekind)
        {


            string s = "";

            if (explainkind == 0) //是分段命令按分段命令解释
            {
                if (CComLibrary.GlobeVal.languageselect == 0)
                {
                    s = s + "斜波";
                }
                else
                {
                    s = s + "Ramp ";
                }
                s = s + speedconvert();

                s = s + " " + destconvert();



                if ((returncount > 0) && (returnstep > 0))
                {
                    if (CComLibrary.GlobeVal.languageselect == 0)
                    {
                        s = s + "返回" + returncount.ToString() + "次," + "返回到步骤" + returnstep.ToString();
                    }
                    else
                    {
                        s = s + "Return to " + returncount.ToString() + " times," + "Return to step" + returnstep.ToString();
                    }
                }





                if (action == 0)
                {
                    if (CComLibrary.GlobeVal.languageselect == 0)
                    {
                        s = s + " 顺序执行";
                    }
                    else
                    {
                        s = s + " Sequential execution";
                    }
                }
                else
                {
                    if (CComLibrary.GlobeVal.languageselect == 0)
                    {
                        s = s + " 同步执行";
                    }
                    else
                    {
                        s = s + " Synchronous execution";
                    }
                }
            }
            else if (explainkind == 1) //是序列命令按序列解释
            {
                s = s + seqwavekindconvert() + seqcontrolmodeconvert() + seqcmd();

            }
            return s;

        }

    }

    [Serializable]

    public class DatabaseItem : ICloneable, IDisposable

    {

        public string KindName;
        public string Name;

        public string[] LName;

        public int Ntype;

        public string Value;


        private bool disposed = false;


        public DatabaseItem()
        {
            LName = new string[10];
        }

        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.



                }

                // Call the appropriate methods to clean up
                // unmanaged resources here.
                // If disposing is false,
                // only the following code is executed.


                // Note disposing has been done.
                disposed = true;

            }
        }



        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        public virtual Object Clone()
        {
            return this.MemberwiseClone();

        }



    }
    [Serializable]
    public class FileStruct : IEquatable<FileStruct>
    {
        public string SerializeObject(object obj)
        {
            if (null == obj)
                return string.Empty;
            Type type = obj.GetType();
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            StringBuilder objString = new StringBuilder();
            foreach (FieldInfo field in fields)
            {
                object value = field.GetValue(obj);     //取得字段的值
                objString.Append(field.Name + ":" + value + ";");
            }

            return objString.ToString();
        }


        private bool FileCompare(string file1, string file2)

        {

            //  判断相同的文件是否被参考两次。

            if (file1 == file2)

            {

                return true;

            }


            int file1byte = 0;

            int file2byte = 0;


            using (FileStream fs1 = new FileStream(file1, FileMode.Open),

            fs2 = new FileStream(file2, FileMode.Open))

            {

                //  检查文件大小。如果两个文件的大小并不相同，则视为不相同。

                if (fs1.Length != fs2.Length)

                {

                    // 关闭文件。

                    fs1.Close();

                    fs2.Close();


                    return false;

                }


                //  逐一比较两个文件的每一个字节，直到发现不相符或已到达文件尾端为止。

                do

                {

                    // 从每一个文件读取一个字节。

                    file1byte = fs1.ReadByte();

                    file2byte = fs2.ReadByte();

                }

                while ((file1byte == file2byte) && (file1byte != -1));


                // 关闭文件。

                fs1.Close();

                fs2.Close();

            }


            //  返回比较的结果。在这个时候，只有当两个文件的内容完全相同时，  "file1byte" 才会等于 "file2byte"。

            return ((file1byte - file2byte) == 0);

        }
        // implements IEquatable<Staff>
        public bool Equals(FileStruct other)
        {

            bool b = false;

            if (null == this || null == other)
                return false;
            if (this.GetType() != other.GetType())
                return false;

            string f1 = System.IO.Path.GetTempPath();

            this.SerializeNow(f1 + "a.zzz");
            other.SerializeNow(f1 + "b.zzz");



            // return SerializeObject(this).Equals(SerializeObject(other));

            b = FileCompare(f1 + "a.zzz", f1 + "b.zzz");

            System.IO.File.Delete(f1 + "a.zzz");
            System.IO.File.Delete(f1 + "b.zzz");

            return b;

        }

        // override Equals
        public override bool Equals(object obj)
        {


            if (obj == null)
                return this == null;

            if (!(obj is FileStruct))
                return false;

            FileStruct s = obj as FileStruct;

            return this.methodname == s.methodname;
        }

        // override GetHashCode
        public override int GetHashCode()
        {
            return this.methodname.GetHashCode();
        }
        public string methodname = ""; //方法名称
        public string datapath = "";


        public CheckState _flow测试前 = CheckState.Unchecked;
        public CheckState _flow测试结束 = CheckState.Unchecked;
        public CheckState _flow数据采集 = CheckState.Unchecked;
        public CheckState _flow应变 = CheckState.Unchecked;
        public CheckState _flow试验选项 = CheckState.Unchecked;
        public CheckState _flow测试 = CheckState.Unchecked;




        public List<string> m_namelist;

        public List<string> m_signnamelist;

        public List<inputitem> minput;

        public List<outputitem> moutput;

        public List<outputitem> mseloutput;

        public CalcPanel mcalcpanel;

        public List<userchannelitem> muserchannel;

        public string fileextname = "*.*";

        public int minterval = 1;

        public int xsel;
        public int ysel;

        public int[] ysels;
        public int[] yselpostion;

        public int yselcount = 0;
        public int filekind = 0;

        public List<string> lprocedurename;

        public int shapeselect = 0;

        public string methodauthor = "";//方法作者
        public string methodmemo = "";//方法说明
        public int methodkind = 0; //方法类型
        public List<shapeitem> mshapelist;

        public string samplememo1;//样品注释1
        public string samplememo2;//样品注释2
        public string samplememo3;//样品注释3
        public string samplememo; //样品说明

        public string samplename;//样品名称

        public string layfilename;//布局文件名称

        public DataTable dt;



        public DataTable dtstatic;



        public ClsStaticStation.ItemSignalStation mstation;
        public List<inputtextitem> minputtext;

        public List<cboitem> mcbo;

        public List<ItemSignal> mmeter;

        public List<ItemSignal> mkey;

        public int mworkspace = 0;

        public List<ItemSignal> mextrameter;

        public List<ItemSignal> mrawdata;

        public List<ItemSignal> mlongdata;

        public List<CTestStep> mstep;

        public List<int> mtestlist;

        public bool mwizard = false; //试验向导是否有效

        public int mspecount = 1;//试样数量

        public int mcontrolprocess = 0;//控制过程类型 0 普通，1 高级 2 简单控制

        public List<ItemSignal> mautozero; //自动清零列表

        public List<outputitem> mtablecol1;//表格1列
        public List<outputitem> mtablecol2;//表格2列

        public List<outputitem> mtable1statistics;//表格1统计值

        public List<outputitem> mtable2statistics;//表格2统计值

        public TablePara mtable1para;//表格1格式参数
        public TablePara mtable2para;//表格2格式参数

        public PlotSettings mplotpara1;//曲线1设置参数
        public PlotSettings mplotpara2;//曲线2设置参数

        public List<ItemSignal> mrawlist;//原始数据列表

        public int mdatacaptureselect = 0;//数据采集选择

        public bool[] chkcriteria;//  数据采集准则
        public int[] cbomeasurement;//数据采集通道
        public double[] numinterval;//数据采集间隔
        public double[] numintervallast;//作为变量使用
        public double[] numintervallast1;//作为变量使用



        public bool endoftest1 = false;// 试验结束1
        public int endoftest1criteria = 0;//试验结束1准则
        public double endoftest1value = 0;//试验结束1变量值

        public int endoftest1usechannel;//试验结束时所使用的判断通道
        public bool endoftest1tempbool = false;//作为变量使用

        public double endoftest1tempmax = 0;//作为变量使用

        public bool endoftest2 = false;// 试验结束2
        public int endoftest2criteria = 0;//试验结束2准则
        public double endoftest2value = 0;//试验结束2变量值
        public int endoftest2usechannel;//试验结束时所使用的判断通道

        public bool endoftest2tempbool = false;//作为变量使用
        public double endoftest2tempmax = 0;//作为变量使用

        public int testaction = 0;//试验结束动作


        public List<CTestStep> teststep;


        public List<PromptsItem> mpromptslist;

        public List<outputitem> moutputexternal;//结果表格额外

        public int currentspenumber = 0;

        public int cbosamplestart = 0;
        public List<double> mcbosamplestart;
        public int cbosampleinterval = 0;
        public List<double> mcbosampleinterval;


        //public bool crackcheck = false;//断裂检测
        //public double crackvalue = 10;//断裂阀值





        public List<ItemSignal> mchsignals; //信号限位

        public List<PromptsItem> mFreeFormPromptsItem;
        public string SamplePath;
        public string SampleDefaultName = "TestSample";

        public CmdSeg pretest_cmd;

        public CmdSeg[] testcmdstep;

        public string SegName = "default.seg";

        public string SequenceName = "default.seg";

        public List<CmdSeg> mseglist; //seg文件

        public List<CComLibrary.CmdSeg> mexplainlist;//试验段列表

        public string ReportTemplate;//报告模板

        public int ReportFormat;//报告格式

        public Boolean ReportSave;//是否保存报告

        public Boolean ReportPrint;//是否打印报告


        public int Samplingmode;// 数据采集模式 是动态还是静态


        public string lasttestdatatime;//最后试验日期

        public CmdSeg simple_cmd; //简单试验

        public double Extensometer_gauge;//引伸计标距
        public double Extensometer1_gauge;//引伸计1标距

        public bool chkextremove;//试验过程中是否摘除引伸计
        public int Extensometer_removal;//引伸计去除准则
        public int Extensometer_DataChannel;//引伸计通道选择
        public double Extensometer_DataValue;//引伸计去除值;
        public int Extensometer_DataValueUnit;//引伸计去除值单位;
        public int Extensometer_Action;//引伸计去除时动作
        public bool Extensometer_DataFrozen;//引伸计摘除时数据冻结

        public bool Extensometer_DataFrozenFlag;//引伸计摘除时数据冻结判断标志 运行时使用

        public Boolean UseDatabase;//数据库是否有效
        public List<DatabaseItem> mdatabaseitemlist;
        public List<DatabaseItem> mdatabaseitemselect;

        public int testedcount = 0;

        public bool mplay = false;//是否播放录像
        public string play_avi_file = "";
        public bool mautorecord = false;//是否自动记录
        public bool mautoplay = false;//是否自动播放
        public bool mplayfile = false;//播放录像时是否播放
        public string play_avi_datafile = "";

        public int ReportMode = 0;//报告模式
        public string UserReportTemplate = "";//自定义报告模板名称


        public double StrainToLoad(double l)
        {
            double t = 0;


            if (mshapelist[shapeselect].shapename == mshapelist[mshapelist[0].Rect_Shape].shapename)
            {
                t = mshapelist[shapeselect].sizeitem[0].cvalue * mshapelist[shapeselect].sizeitem[1].cvalue;

            }

            if (mshapelist[shapeselect].shapename == mshapelist[mshapelist[0].Round_Shape].shapename)
            {
                t = mshapelist[shapeselect].sizeitem[0].cvalue * mshapelist[shapeselect].sizeitem[0].cvalue / 4 * 3.1415926;

            }


            return l / 1000 * t;

        }

        public double LoadToStrain(double l)
        {
            double t = 0;

            if (mshapelist[shapeselect].shapename == ClsStaticStation.m_Global.mycls.shapelist[ClsStaticStation.m_Global.mycls.shapelist[0].Rect_Shape].shapename)
            {
                t = mshapelist[shapeselect].sizeitem[0].cvalue * mshapelist[shapeselect].sizeitem[1].cvalue;

            }

            if (mshapelist[shapeselect].shapename == ClsStaticStation.m_Global.mycls.shapelist[ClsStaticStation.m_Global.mycls.shapelist[0].Round_Shape].shapename)
            {
                t = mshapelist[shapeselect].sizeitem[0].cvalue * mshapelist[shapeselect].sizeitem[0].cvalue / 4 * 3.1415926;

            }




            return l / t * 1000;

        }

        public double GetArea()
        {
            double t = 0;


            if (mshapelist[shapeselect].shapename == mshapelist[mshapelist[0].Rect_Shape].shapename)
            {
                t = mshapelist[shapeselect].sizeitem[0].cvalue * mshapelist[shapeselect].sizeitem[1].cvalue;

            }

            if (mshapelist[shapeselect].shapename == mshapelist[mshapelist[0].Round_Shape].shapename)
            {
                t = mshapelist[shapeselect].sizeitem[0].cvalue * mshapelist[shapeselect].sizeitem[0].cvalue / 4 * 3.1415926;

            }


            return t;

        }

        public void InitExplainList()
        {

            if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 2) //简单试验
            {




                mexplainlist = new List<CmdSeg>();
                mexplainlist.Clear();


                mexplainlist.Add(CComLibrary.GlobeVal.filesave.simple_cmd);






            }

            if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 0) //一般试验
            {




                mexplainlist = new List<CmdSeg>();
                mexplainlist.Clear();

                if (CComLibrary.GlobeVal.filesave.pretest_cmd.check == true)
                {
                    mexplainlist.Add(CComLibrary.GlobeVal.filesave.pretest_cmd);


                }

                for (int i = 0; i < 4; i++)
                {
                    if (CComLibrary.GlobeVal.filesave.testcmdstep[i].check == true)
                    {
                        mexplainlist.Add(CComLibrary.GlobeVal.filesave.testcmdstep[i]);
                    }
                    else
                    {
                        break;
                    }

                }



            }
            else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 1)//中级试验
            {


                CComLibrary.GlobeVal.filesave.mseglist = new List<CComLibrary.CmdSeg>();


                CComLibrary.SegFile sf = new CComLibrary.SegFile();

                sf = sf.DeSerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ\\seg\\"
                    + CComLibrary.GlobeVal.filesave.SegName);

                int i = 0;



                int m = sf.mseglist.Count;

                for (i = 0; i < m; i++)
                {
                    CComLibrary.CmdSeg n = new CComLibrary.CmdSeg();
                    n.check = true;
                    n.controlmode = sf.mseglist[i].controlmode;
                    n.speed = sf.mseglist[i].speed;
                    n.destcontrolmode = sf.mseglist[i].destcontrolmode;
                    n.dest = sf.mseglist[i].dest;
                    n.keeptime = sf.mseglist[i].keeptime;
                    n.cmd = sf.mseglist[i].cmd;
                    n.action = sf.mseglist[i].action;
                    n.explainkind = 0;

                    if (sf.mseglist[i].cyclicrun == true)
                    {

                        n.returncount = sf.mseglist[i].cycliccount;
                        n.returnstep = sf.mseglist[i].returnstep;
                    }
                    else
                    {
                        n.returncount = 0;
                        n.returnstep = 0;
                    }
                    CComLibrary.GlobeVal.filesave.mseglist.Add(n);
                }


                mexplainlist = new List<CComLibrary.CmdSeg>();
                mexplainlist.Clear();

                if (CComLibrary.GlobeVal.filesave.pretest_cmd.check == true)
                {
                    mexplainlist.Add(CComLibrary.GlobeVal.filesave.pretest_cmd);
                    mexplainlist[0].keeptime = 0;

                }

                for (i = 0; i < CComLibrary.GlobeVal.filesave.mseglist.Count; i++)
                {
                    if (CComLibrary.GlobeVal.filesave.mseglist[i].check == true)
                    {
                        mexplainlist.Add(CComLibrary.GlobeVal.filesave.mseglist[i]);
                    }
                    else
                    {
                        break;
                    }

                }

            }

            else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 3)//高级试验
            {
                CComLibrary.GlobeVal.filesave.mseglist = new List<CComLibrary.CmdSeg>();

                CComLibrary.SequenceFile sqf = new CComLibrary.SequenceFile();
                sqf = sqf.DeSerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ\\sequence\\" + CComLibrary.GlobeVal.filesave.SequenceName);


                for (int i = 0; i < sqf.mSequencelist.Count; i++)
                {

                    CComLibrary.CmdSeg n = new CComLibrary.CmdSeg();
                    n.check = true;
                    n.explainkind = 1;
                    n.mseq = sqf.mSequencelist[i];




                    CComLibrary.GlobeVal.filesave.mseglist.Add(n);
                }


                mexplainlist = new List<CComLibrary.CmdSeg>();
                mexplainlist.Clear();



                for (int i = 0; i < CComLibrary.GlobeVal.filesave.mseglist.Count; i++)
                {

                    mexplainlist.Add(CComLibrary.GlobeVal.filesave.mseglist[i]);


                }
            }

        }

        private void Init_SystemPara()
        {

            CComLibrary.SystemPara b;
            string s;
            int i;
            int j;
            CComLibrary.GlobeVal.msyspara.Clear();

            s = "";

            for (j = 0; j < CComLibrary.GlobeVal.filesave.mshapelist.Count; j++)
            {
                for (i = 0; i < CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem.Length; i++)
                {
                    if (CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem[i].cName != "None")
                    {
                        b = new CComLibrary.SystemPara();

                        string r = CComLibrary.GlobeVal.filesave.mshapelist[j].shapename + "_" +
                            CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem[i].cName;
                        r = r.Replace(" ", "_");
                        b.Name = r;
                        b.replaceName = b.Name;
                        s = s + "public double " + b.replaceName + "=" +
                            CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem[i].cvalue.ToString() + ";" + "\r\n";
                        CComLibrary.GlobeVal.msyspara.Add(b);
                    }


                }
            }

            for (i = 0; i < CComLibrary.GlobeVal.filesave.mcbo.Count; i++)
            {
                b = new CComLibrary.SystemPara();
                b.Name = CComLibrary.GlobeVal.filesave.mcbo[i].Name;
                b.replaceName = b.Name;
                s = s + "public  int " + b.replaceName + "=" + CComLibrary.GlobeVal.filesave.mcbo[i].value.ToString() + ";" + "\r\n";
                CComLibrary.GlobeVal.msyspara.Add(b);
            }

            for (i = 0; i < CComLibrary.GlobeVal.filesave.minput.Count; i++)
            {
                b = new CComLibrary.SystemPara();
                b.Name = CComLibrary.GlobeVal.filesave.minput[i].name;
                b.replaceName = b.Name;
                s = s + "public  double " + b.replaceName + "=" + CComLibrary.GlobeVal.filesave.minput[i].value.ToString() + ";" + "\r\n";
                CComLibrary.GlobeVal.msyspara.Add(b);
            }


            CComLibrary.GlobeVal.gcalc.refreshglobe(s);





        }

        public int readfilelen(string fileName, out int L)
        {
            string line;
            char[] sp;
            char[] sp1;
            string[] ww;
            int i = -1;
            sp = new char[2];

            L = 0;
            using (StreamReader sr = new StreamReader(fileName, Encoding.Default))
            {

                while ((line = sr.ReadLine()) != null)
                {
                    sp[0] = Convert.ToChar(" ");

                    ww = line.Split(sp);
                    L = ww.Length;

                    i = i + 1;

                }

            }



            return i - 1;
        }

        public int readdemo(string fileName, int len, int L)
        {
            int i = -1;
            int j = 0;
            Type l_Type;


            char[] sp;
            char[] sp1;
            string[] ww;

            string line;


            CComLibrary.GlobeVal.g_datatitle = new string[30];
            CComLibrary.GlobeVal.g_dataunit = new string[30];

            sp = new char[2];
            sp1 = new char[2];

            l_Type = typeof(string);

            CComLibrary.GlobeVal.l_Array = Array.CreateInstance(l_Type, len, L);



            using (StreamReader sr = new StreamReader(fileName, Encoding.Default))
            {

                while ((line = sr.ReadLine()) != null)
                {
                    i = i + 1;
                    if (i == 0)
                    {

                        sp[0] = Convert.ToChar(" ");

                        ww = line.Split(sp);



                        for (j = 0; j < ww.Length; j++)
                        {


                            CComLibrary.GlobeVal.g_datatitle[j] = ww[j];


                        }

                    }

                    else if (i == 1)
                    {

                        sp[0] = Convert.ToChar(" ");

                        ww = line.Split(sp);





                        for (j = 0; j < ww.Length; j++)
                        {


                            CComLibrary.GlobeVal.g_dataunit[j] = ww[j];


                        }
                    }
                    else
                    {

                        sp[0] = Convert.ToChar(" ");

                        ww = line.Split(sp);




                        for (int k = 0; k < L; k++)
                        {

                            if (i <= len)
                            {
                                CComLibrary.GlobeVal.l_Array.SetValue(ww[k], i - 1, k);
                            }
                        }



                    }
                }

            }









            CComLibrary.GlobeVal.g_datalen = i - 1;

            return i - 1;


        }


        public void calc(string filename)
        {
            int i;
            int j;
            int k;


            int L = 0;



            if (File.Exists(filename) == false)
            {
                return;
            }
            i = readfilelen(filename, out L);


            if (i > 10)
            {

            }
            else
            {
                MessageBox.Show("没有生成试验数据，不能进行计算");
            }

            readdemo(filename, i, L);

            Boolean bcalc = false;

            CComLibrary.SystemPara b;
            string s;






            s = "";

            CComLibrary.GlobeVal.m_test = false;



            for (i = 0; i < CComLibrary.GlobeVal.filesave.m_namelist.Count; i++)
            {

                string r = CComLibrary.GlobeVal.filesave.m_namelist[i];
                r = r.Replace(" ", "_");
                s = s + r + " ";

            }

            for (i = 0; i < 100; i++)
            {
                ClsStaticStation.m_Global.mresult[i] = 0;
            }

            s = s.Trim();
            CComLibrary.GlobeVal.gcalc.Initialize();

            CComLibrary.GlobeVal.gcalc.setarrayvalue(CComLibrary.GlobeVal.l_Array, CComLibrary.GlobeVal.g_datalen, L - 1);

            CComLibrary.GlobeVal.gcalc.initarray(s, CComLibrary.GlobeVal.g_datalen);


            Init_SystemPara();
            bool mhavecalcitem = false;

            for (j = 0; j < CComLibrary.GlobeVal.filesave.moutput.Count; j++)
            {
                if (CComLibrary.GlobeVal.filesave.moutput[j].check == true)
                {
                    mhavecalcitem = true;

                    CComLibrary.GlobeVal.gcalc.Initexpr(CComLibrary.GlobeVal.filesave.moutput[j].formulavalue, j + 1);
                    s = "";
                    for (i = 0; i < CComLibrary.GlobeVal.filesave.moutput.Count; i++)
                    {
                        b = new CComLibrary.SystemPara();
                        b.Name = CComLibrary.GlobeVal.filesave.moutput[i].formulaname;
                        b.replaceName = "@result" + (i + 1).ToString().Trim();
                        //  s = s + "double " + b.replaceName + "=" + "CalcedChannelResult["+(i + 1).ToString().Trim() + "];" + "\r\n";
                        s = s + "double " + b.replaceName + "=" + "m_Global.mresult[" + (i + 1).ToString().Trim() + "];\r\n";
                        CComLibrary.GlobeVal.msyspara.Add(b);



                    }

                }
            }

            if (mhavecalcitem == false)
            {
                MessageBox.Show("没有设置计算项目");
            }
            else
            {
                CComLibrary.GlobeVal.gcalc.refreshresult(s);
                bcalc = CComLibrary.GlobeVal.gcalc.calc();


                double[] rr;
                Boolean[] rvalid;
                rr = new double[100];
                rvalid = new Boolean[100];
                for (j = 0; j < CComLibrary.GlobeVal.filesave.moutput.Count; j++)
                {
                    rr[j] = 0;
                    rvalid[j] = false;
                }



                for (j = 0; j < CComLibrary.GlobeVal.filesave.moutput.Count; j++)
                {



                    if (ClsStaticStation.m_Global.mvalid == true)
                    {
                        rvalid[j + 1] = true;
                    }
                    else
                    {
                        rvalid[j + 1] = false;
                    }

                    // CComLibrary.GlobeVal.gcalc.getresult(j + 1).ToString();


                }



            }



        }


        public void checkchange()
        {

            InitTable();
            this.mtablecol1.Clear();
            this.mtablecol2.Clear();

        }


        public void InitTable()
        {
            string s = "";
            dt = new DataTable();


            DataColumn dc = null;
            if (GlobeVal.languageselect == 0)
            {
                dc = dt.Columns.Add("序号", Type.GetType("System.Int32"));
            }
            else
            {
                dc = dt.Columns.Add("Order", Type.GetType("System.Int32"));
            }
            dc.AutoIncrement = true;//自动增加
            dc.AutoIncrementSeed = 1;//起始为1
            dc.AutoIncrementStep = 1;//步长为1
            dc.AllowDBNull = true;//

            dc = dt.Columns.Add("SpeStatus",typeof(CComLibrary.TestStatus));
            /*
            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mpromptslist.Count; i++)
            {

                dc = dt.Columns.Add(CComLibrary.GlobeVal.filesave.mpromptslist[i].itemname, System.Type.GetType("System.String"));


            }
            */

            for (int i = 0; i <
        this.mshapelist[this.shapeselect].sizeitem.Length; i++)
            {
                if (this.mshapelist[this.shapeselect].sizeitem[i].cName != "None")
                {

                    s = this.mshapelist[this.shapeselect].sizeitem[i].cName;
                    dc = dt.Columns.Add(s, typeof(double));
                }
            }


            for (int i = 0; i <
              this.minputtext.Count; i++)
            {

                s = this.minputtext[i].name;
                dc = dt.Columns.Add(s, typeof(string));

            }

            for (int i = 0; i <
             this.minput.Count; i++)
            {

                s = this.minput[i].name;
                dc = dt.Columns.Add(s, typeof(double));
            }



            for (int i = 0; i < this.mcbo.Count; i++)
            {



                s = this.mcbo[i].Name;
                dc = dt.Columns.Add(s, typeof(double));

            }


            for (int i = 0; i < this.moutput.Count; i++)
            {

                dc = dt.Columns.Add(this.moutput[i].formulaname, typeof(double));

            }



            //for (int i = 0; i < CComLibrary.GlobeVal.filesave.mspecount; i++)

            for (int i = 0; i < 100; i++)

            {
                DataRow newRow;
                newRow = dt.NewRow();


                dt.Rows.Add(newRow);

            }

            dtstatic = new DataTable();
            dc = null;

            dc = dtstatic.Columns.Add("Statistics", Type.GetType("System.String"));

            dc.AllowDBNull = true;//

            dc = dtstatic.Columns.Add("SpeStatus", typeof(CComLibrary.TestStatus));

            for (int i = 0; i < this.mpromptslist.Count; i++)
            {

                dc = dtstatic.Columns.Add(this.mpromptslist[i].itemname, System.Type.GetType("System.String"));

            }


            for (int i = 0; i < this.moutput.Count; i++)
            {

                dc = dtstatic.Columns.Add(this.moutput[i].formulaname, typeof(double));

            }


            for (int i = 0; i < 6; i++)
            {
                DataRow newRow;
                newRow = dtstatic.NewRow();


                dtstatic.Rows.Add(newRow);

            }

            if (GlobeVal.languageselect == 0)
            {

                dtstatic.Rows[0][0] = "最大值";
                dtstatic.Rows[1][0] = "最小值";
                dtstatic.Rows[2][0] = "平均值";
                dtstatic.Rows[3][0] = "标准偏差";
                dtstatic.Rows[4][0] = "方差";

            }
            else
            {
                dtstatic.Rows[0][0] = "Max";
                dtstatic.Rows[1][0] = "Min";
                dtstatic.Rows[2][0] = "Aaverage";
                dtstatic.Rows[3][0] = "Standard deviation";
                dtstatic.Rows[4][0] = "Variance";
            }

        }
        public void InitOutputExternal()
        {
            outputitem p;
            moutputexternal.Clear();

            for (int i = 0; i <
        CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem.Length; i++)
            {
                p = new outputitem();
                p.formulaname = CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[i].cName;
                p.myitemsignal = CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[i];

                p.formulavalue = "";
                moutputexternal.Add(p);

            }

            for (int i = 0; i <
             CComLibrary.GlobeVal.filesave.minputtext.Count; i++)
            {
                p = new outputitem();
                p.formulaname = CComLibrary.GlobeVal.filesave.minputtext[i].name;
                p.myitemsignal = new ItemSignal();
                p.myitemsignal.cUnitKind = 19;
                p.myitemsignal.cUnitsel = 0;
                p.myitemsignal.InitUnit();
                p.formulavalue = "";
                moutputexternal.Add(p);

            }

            for (int i = 0; i <
                  CComLibrary.GlobeVal.filesave.minput.Count; i++)
            {
                p = new outputitem();
                p.formulaname = CComLibrary.GlobeVal.filesave.minput[i].name;
                p.myitemsignal = CComLibrary.GlobeVal.filesave.minput[i].myitemsignal;
                p.formulavalue = "";
                moutputexternal.Add(p);
            }

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mcbo.Count; i++)
            {
                p = new outputitem();
                p.formulaname = CComLibrary.GlobeVal.filesave.mcbo[i].Name;
                p.myitemsignal = new ItemSignal();
                p.myitemsignal.cUnitKind = 19;
                p.myitemsignal.cUnitsel = 0;
                p.myitemsignal.InitUnit();
                p.formulavalue = "";
                moutputexternal.Add(p);

            }

        }

        public void init_mtable2statistics(FileStruct f)
        {


            f.mtable2statistics = new List<outputitem>();
            outputitem a = new outputitem();
            if (GlobeVal.languageselect == 0)
            {
                a.formulaname = "最大值";
            }
            else
            {
                a.formulaname = "Max";
            }
            f.mtable2statistics.Add(a);

            a = new outputitem();
            if (GlobeVal.languageselect == 0)
            {
                a.formulaname = "最小值";
            }
            else
            {
                a.formulaname = "Min";
            }
            f.mtable2statistics.Add(a);

            a = new outputitem();
            if (GlobeVal.languageselect == 0)
            {
                a.formulaname = "平均值";
            }
            else
            {
                a.formulaname = "Average";
            }
            f.mtable2statistics.Add(a);
        }
        public void init_mtable1statistics(FileStruct f)
        {


            f.mtable1statistics = new List<outputitem>();
            outputitem a = new outputitem();
            if (GlobeVal.languageselect == 0)
            {
                a.formulaname = "最大值";
            }
            else
            {
                a.formulaname = "Max";
            }
            f.mtable1statistics.Add(a);
            a = new outputitem();
            if (GlobeVal.languageselect == 0)
            {
                a.formulaname = "最小值";
            }
            else
            {
                a.formulaname = "Min";
            }
            f.mtable1statistics.Add(a);

            a = new outputitem();
            if (GlobeVal.languageselect == 0)
            {
                a.formulaname = "平均值";
            }
            else
            {
                a.formulaname = "Average";
            }
            f.mtable1statistics.Add(a);


        }

        public void InitPrompts()
        {
            mpromptslist.Clear();
            PromptsItem p = new PromptsItem();
            p.itemname = "样品注释1";
            p.Litemname[0]= "样品注释1";
            p.Litemname[1] = "Sample note 1";


            p.parentstring = "样品";
            p.Lparentstring[0] = "样品";
            p.Lparentstring[1] = "Sample";

            mpromptslist.Add(p);

            p = new PromptsItem();
            p.itemname = "样品注释2";
            p.Litemname[0] = "样品注释2";
            p.Litemname[1] = "Sample note 2";
            p.parentstring = "样品";
            p.Lparentstring[0] = "样品";
            p.Lparentstring[1] = "Sample";

            mpromptslist.Add(p);

            p = new PromptsItem();
            p.itemname = "样品注释3";
            p.Litemname[0] = "样品注释3";
            p.Litemname[1] = "Sample note 3";

            p.parentstring = "样品";
            p.Lparentstring[0] = "样品";
            p.Lparentstring[1] = "Sample";


            mpromptslist.Add(p);

            p = new PromptsItem();
            p.itemname = "样品说明";
            p.Litemname[0] = "样品说明";
            p.Litemname[1] = "Sample description";


            p.parentstring = "样品";
            p.Lparentstring[0] = "样品";
            p.Lparentstring[1] = "Sample";


            mpromptslist.Add(p);


           for (int i=0;i<mpromptslist.Count;i++)

            {
                if (CComLibrary.GlobeVal.languageselect ==0)
                {
                    mpromptslist[i].itemname = mpromptslist[i].Litemname[0];
                    mpromptslist[i].parentstring = mpromptslist[i].Lparentstring[0];
                }
                else
                {
                    mpromptslist[i].itemname = mpromptslist[i].Litemname[1];
                    mpromptslist[i].parentstring = mpromptslist[i].Lparentstring[1];
                }
            }


            for (int i = 0; i <
           CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem.Length; i++)
            {
                if (CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[i].cName != "None")
                {
                    p = new PromptsItem();
                    p.itemname = CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[i].cName;
                    if (CComLibrary.GlobeVal.languageselect == 0)
                    {
                        p.parentstring = "试样尺寸输入";
                    }
                    else
                    {
                        p.parentstring = "Sample size input";
                    }

                    mpromptslist.Add(p);
                }
            }


            for (int i = 0; i <
              CComLibrary.GlobeVal.filesave.minputtext.Count; i++)
            {
                p = new PromptsItem();
                p.itemname = CComLibrary.GlobeVal.filesave.minputtext[i].name;
                if (CComLibrary.GlobeVal.languageselect == 0)
                {
                    p.parentstring = "试样文本输入";
                }
                else
                {
                    p.parentstring = "Sample text input";
                }
                mpromptslist.Add(p);
            }

            for (int i = 0; i <
             CComLibrary.GlobeVal.filesave.minput.Count; i++)
            {
                p = new PromptsItem();
                p.itemname = CComLibrary.GlobeVal.filesave.minput[i].name;
                if (CComLibrary.GlobeVal.languageselect == 0)
                {
                    p.parentstring = "试样数字输入";
                }
                else
                {
                    p.parentstring = "Sample digital input";
                }
                mpromptslist.Add(p);
            }



            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mcbo.Count; i++)
            {
                p = new PromptsItem();
                if (CComLibrary.GlobeVal.languageselect == 0)
                {
                    p.parentstring = "试样选项输入";
                }
                else
                {
                    p.parentstring = "Sample option input";
                }
                p.itemname = CComLibrary.GlobeVal.filesave.mcbo[i].Name;
                mpromptslist.Add(p);

            }


        }

        public FileStruct()
        {


            m_namelist = new List<string>();
            minput = new List<inputitem>();
            moutput = new List<outputitem>();
            mseloutput = new List<outputitem>();
            mcalcpanel = new CalcPanel();
            muserchannel = new List<userchannelitem>();
            ysels = new int[10];
            yselpostion = new int[10];
            lprocedurename = new List<string>();

            mshapelist = new List<shapeitem>();
            minputtext = new List<inputtextitem>();
            mcbo = new List<cboitem>();
            mmeter = new List<ItemSignal>();
            mkey = new List<ItemSignal>();
            mextrameter = new List<ItemSignal>();
            mrawdata = new List<ItemSignal>();
            mstep = new List<CTestStep>();
            mtestlist = new List<int>();
            mautozero = new List<ItemSignal>();
            mtablecol1 = new List<outputitem>();
            mtablecol2 = new List<outputitem>();
            mtable1para = new TablePara();
            mtable2para = new TablePara();
            mplotpara1 = new PlotSettings();
            mplotpara2 = new PlotSettings();

            mlongdata = new List<ClsStaticStation.ItemSignal>();

            init_mtable1statistics(this);
            init_mtable2statistics(this);
            mrawdata = new List<ItemSignal>();

            chkcriteria = new bool[3];
            cbomeasurement = new int[3];
            numinterval = new double[3];
            numintervallast = new double[3];
            numintervallast1 = new double[3];

            teststep = new List<CTestStep>();
            for (int i = 0; i < 9; i++)
            {
                CTestStep ct = new CTestStep();
                ct.Id = i;

                teststep.Add(ct);
            }

            teststep[0].havedloop = false;
            teststep[1].havedloop = true;
            teststep[2].havedloop = true;
            teststep[3].havedloop = true;
            teststep[4].havedloop = true;
            teststep[5].havedloop = true;
            teststep[6].havedloop = true;

            teststep[7].havedloop = false;
            teststep[8].havedloop = false;

            mpromptslist = new List<PromptsItem>();

            moutputexternal = new List<outputitem>();

            mcbosamplestart = new List<double>();
            mcbosamplestart.Add(0);
            mcbosamplestart.Add(10.0);
            mcbosamplestart.Add(20.0);
            mcbosamplestart.Add(30.0);
            mcbosamplestart.Add(60.0);

            mcbosampleinterval = new List<double>();
            mcbosampleinterval.Add(0.1);
            mcbosampleinterval.Add(1);
            mcbosampleinterval.Add(10);
            mcbosampleinterval.Add(20);
            mcbosampleinterval.Add(30);
            mcbosampleinterval.Add(60);
            mcbosampleinterval.Add(600);
            mcbosampleinterval.Add(1200);
            mcbosampleinterval.Add(1800);
            mcbosampleinterval.Add(3600);

            mchsignals = new List<ItemSignal>();
            for (int i = 0; i < ClsStaticStation.m_Global.mycls.chsignals.Count; i++)
            {
                mchsignals.Add(ClsStaticStation.m_Global.mycls.chsignals[i]);
            }
            mFreeFormPromptsItem = new List<PromptsItem>();

            pretest_cmd = new CmdSeg();

            testcmdstep = new CmdSeg[4];

            for (int i = 0; i < 4; i++)
            {
                testcmdstep[i] = new CmdSeg();
            }

            mseglist = new List<CmdSeg>();

            mdatabaseitemlist = new List<DatabaseItem>();
            mdatabaseitemselect = new List<DatabaseItem>();
            Init_databaselist(false, this.currentspenumber);


        }

        public void Init_databaselist(bool calced, int inum)
        {
            mdatabaseitemlist.Clear();
            DatabaseItem m = new CComLibrary.DatabaseItem();

            m.Name = "";
            m.LName[0] = "方法名称";

            m.LName[1] = "Method name";

            m.Ntype = 0;
            m.Value = this.methodname;

            mdatabaseitemlist.Add(m);

            m = new DatabaseItem();

            m.Name = "";
            m.LName[0] = "方法作者";
            m.LName[1] = "Method author";


            m.Ntype = 0;
            m.Value = this.methodauthor;
            mdatabaseitemlist.Add(m);
            m = new DatabaseItem();
            m.Name = "";

            m.LName[0] = "方法说明";

            m.LName[1] = "Method description";

            m.Ntype = 0;
            m.Value = this.methodauthor;
            mdatabaseitemlist.Add(m);


            m = new DatabaseItem();
            m.Name = "";
            m.LName[0] = "样品名称";
            m.LName[1] = "Sample name";

            m.Ntype = 0;
            m.Value = this.samplename;
            mdatabaseitemlist.Add(m);

            m = new DatabaseItem();
            m.Name = "";
            m.LName[0] = "样品注释1";

            m.LName[1] = "Sample note 1";
            m.Ntype = 0;
            m.Value = this.samplememo1;
            mdatabaseitemlist.Add(m);

            m = new DatabaseItem();
            m.Name = "";
            m.LName[0] = "样品注释2";
            m.LName[1] = "Sample note 2";


            m.Ntype = 0;
            m.Value = this.samplememo2;
            mdatabaseitemlist.Add(m);

            m = new DatabaseItem();
            m.Name = "";
            m.LName[0] = "样品注释3";
            m.LName[1] = "Sample note 2";
            m.Ntype = 0;
            m.Value = this.samplememo3;
            mdatabaseitemlist.Add(m);

            m = new DatabaseItem();
            m.Name = "";
            m.LName[0] = "样品说明";

            m.LName[1] = "Sample description";

            m.Ntype = 0;
            m.Value = this.samplememo;
            mdatabaseitemlist.Add(m);


            m = new DatabaseItem();
            m.Name = "";
            m.LName[0] = "试样数量";
            m.LName[1] = "Number of specimens"; 
            m.Ntype = 0;
            m.Value = this.mspecount.ToString();
            mdatabaseitemlist.Add(m);

            m = new DatabaseItem();
            m.Name = "";
            m.LName[0] = "试样号";
            m.LName[1] = "Serial number";
            m.Ntype = 0;
            m.Value = (inum + 1).ToString();
            mdatabaseitemlist.Add(m);

            m = new DatabaseItem();
            m.Name = "";
            m.LName[0] = "试验日期";
            m.LName[1] = "Test date";
            m.Ntype = 0;
            m.Value = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
            mdatabaseitemlist.Add(m);



            m = new DatabaseItem();
            m.Name = "";
            m.LName[0] = "试样形状";
            m.LName[1] = "Specimen shape";
            m.Ntype = 0;

            if (this.mshapelist.Count > 0)
            {
                m.Value = this.mshapelist[this.shapeselect].shapename;
            }
            mdatabaseitemlist.Add(m);


            for(int j=0;j<mdatabaseitemlist.Count;j++)
            {
                if (CComLibrary.GlobeVal.languageselect == 0)
                {
                    mdatabaseitemlist[j].Name = mdatabaseitemlist[j].LName[0];
                }
                else
                {
                    mdatabaseitemlist[j].Name = mdatabaseitemlist[j].LName[1];
                }
            }

            for (int j = 0; j < this.mshapelist.Count; j++)
            {


                for (int i = 0; i <
                   this.mshapelist[this.shapeselect].sizeitem.Length; i++)
                {
                    if (this.mshapelist[j].sizeitem[i].cName != "None")
                    {
                        m = new DatabaseItem();
                        m.Name = this.mshapelist[j].shapename + "_" + this.mshapelist[j].sizeitem[i].cName;
                        m.Ntype = 0;

                        bool mb = false;
                        for (int k = 0; k < CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem.Count; k++)
                        {
                            if (this.mshapelist[j].sizeitem[i].cName == CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem[k].itemname)
                            {

                                mb = true;
                                m.Value = CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem[k].itemvalue.ToString();
                                mdatabaseitemlist.Add(m);

                            }
                        }
                        if (mb == false)
                        {
                            m.Value = this.mshapelist[j].sizeitem[i].cvalue.ToString();
                            mdatabaseitemlist.Add(m);
                        }
                    }

                }
            }



            for (int i = 0; i <
              this.minput.Count; i++)
            {
                m = new DatabaseItem();
                m.Name = this.minput[i].name;
                m.Ntype = 0;
                m.Value = this.minput[i].value.ToString();
                mdatabaseitemlist.Add(m);

            }




            for (int i = 0; i <
              this.minputtext.Count; i++)
            {
                m = new DatabaseItem();
                m.Name = this.minputtext[i].name;
                
                m.Ntype = 0;
                m.Value = this.minputtext[i].value;
                mdatabaseitemlist.Add(m);
            }




            for (int i = 0; i < this.mcbo.Count; i++)
            {
                m = new DatabaseItem();
                if (CComLibrary.GlobeVal.languageselect == 0)
                {
                    m.KindName = "试样选项输入";
                }
                else
                {
                    m.KindName = "Sample option input";
                }
                m.Name = this.mcbo[i].Name;
                m.Ntype = 0;
                m.Value = this.mcbo[i].mlist[this.mcbo[i].value];
                mdatabaseitemlist.Add(m);


            }



            for (int i = 0; i < this.moutput.Count; i++)
            {

                m = new DatabaseItem();
                if (CComLibrary.GlobeVal.languageselect  == 0)
                {
                    m.KindName = "计算项目";
                }
                else
                {
                    m.KindName = "Calculated items";
                }
                m.Name = this.moutput[i].formulaname;
                m.Ntype = 0;
                m.Value = "0";
                if (CComLibrary.GlobeVal.gcalc == null)
                {
                    m.Value = "0";
                }
                else
                {

                    if (calced == false)
                    {
                        // m.Value = ClsStaticStation.m_Global.mresult[i + 1].ToString();
                    }
                    else

                    {
                        m.Value = CComLibrary.GlobeVal.gcalc.getresult(i + 1).ToString();
                    }

                }


                mdatabaseitemlist.Add(m);


            }

            for (int i = 0; i < mdatabaseitemlist.Count; i++)
            {
                for (int j = 0; j < mdatabaseitemselect.Count; j++)
                {
                    if (mdatabaseitemselect[j].Name == mdatabaseitemlist[i].Name)
                    {
                        mdatabaseitemselect[j] = mdatabaseitemlist[i];
                    }
                }
            }

        }

        public void SerializeNow(string filename)
        {

            FileStream fileStream =
            new FileStream(filename, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(fileStream, this);
            fileStream.Close();
        }
        public FileStruct DeSerializeNow(string filename)
        {
            FileStruct c = new FileStruct();
            try
            {


                using (FileStream fileStream =
                 new FileStream(filename,
                 FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    BinaryFormatter b = new BinaryFormatter();

                    c = b.Deserialize(fileStream) as FileStruct;
                    if (c.minput == null)
                    {
                        c.minput = new List<CComLibrary.inputitem>();
                    }
                    if (c.moutput == null)
                    {
                        c.moutput = new List<CComLibrary.outputitem>();
                    }

                    if (c.mseloutput == null)
                    {
                        c.mseloutput = new List<CComLibrary.outputitem>();

                    }
                    if (c.mcalcpanel == null)
                    {
                        c.mcalcpanel = new CalcPanel();
                    }

                    if (c.muserchannel == null)
                    {
                        c.muserchannel = new List<CComLibrary.userchannelitem>();
                    }


                    if (c.mshapelist == null)
                    {
                        c.mshapelist = new List<shapeitem>();



                    }


                    for (int i = 0; i < c.mshapelist.Count; i++)
                    {
                        for (int j = 0; j < m_Global.mycls.shapelist.Count; j++)
                        {
                            if (c.mshapelist[i].shapename == m_Global.mycls.shapelist[j].shapename)
                            {
                                c.mshapelist[i] = m_Global.mycls.shapelist[j];
                            }
                        }
                    }

                    bool mt = true;
                    for (int i = 0; i < c.mchsignals.Count; i++)
                    {
                        if(mchsignals[i].cName != ClsStaticStation.m_Global.mycls.chsignals[i].cName)
                        {
                            mt = false;
                        }
                       
                    }

                    if (mt == false)
                    {
                        c.mchsignals.Clear();
                        for (int i = 0; i < ClsStaticStation.m_Global.mycls.chsignals.Count; i++)
                        {

                            c.mchsignals.Add(ClsStaticStation.m_Global.mycls.chsignals[i]);
                        }
                    }


                    if (c.minputtext == null)
                    {
                        c.minputtext = new List<inputtextitem>();


                    }
                    if (c.mcbo == null)
                    {
                        c.mcbo = new List<cboitem>();
                    }

                    if (c.mmeter == null)
                    {
                        c.mmeter = new List<ItemSignal>();
                    }
                    if (c.mkey == null)
                    {
                        c.mkey = new List<ItemSignal>();
                    }

                    if (c.mextrameter == null)
                    {
                        c.mextrameter = new List<ItemSignal>();
                    }
                    if (c.mrawdata == null)
                    {
                        c.mrawdata = new List<ItemSignal>();
                    }
                    if (c.mstep == null)
                    {
                        c.mstep = new List<CTestStep>();
                    }

                    if (c.mtestlist == null)
                    {
                        c.mtestlist = new List<int>();
                    }

                    if (c.mautozero == null)
                    {
                        c.mautozero = new List<ItemSignal>();
                    }


                    if (c.mtablecol1 == null)
                    {
                        c.mtablecol1 = new List<outputitem>();
                    }

                    if (c.mtablecol2 == null)
                    {
                        c.mtablecol2 = new List<outputitem>();
                    }

                   

                    if (c.mtable1statistics == null)
                    {
                        init_mtable1statistics(c);

                    }

                    if (c.layfilename == null)
                    {
                        c.layfilename = " ";
                    }

                    if (c.mtable2statistics == null)
                    {
                        init_mtable2statistics(c);

                    }

                   // c.init_mtable1statistics(c);
                   // c.init_mtable2statistics(c);

                    if (c.mtable1para == null)
                    {
                        c.mtable1para = new TablePara();
                    }

                    if (c.mtable2para == null)
                    {
                        c.mtable2para = new TablePara();
                    }

                    if (c.mplotpara1 == null)
                    {
                        c.mplotpara1 = new PlotSettings();
                    }
                    if (c.mplotpara2 == null)
                    {
                        c.mplotpara2 = new PlotSettings();
                    }

                    if (c.mplotpara1.PlotLineColor == null)
                    {
                        c.mplotpara1.PlotLineColor = new Color[16];
                        for (int i = 0; i < 16; i++)
                        {
                            c.mplotpara1.PlotLineColor[i] = Color.Black;
                        }

                    }

                    if (c.mplotpara1.PlotLinePointColor == null)
                    {
                        c.mplotpara1.PlotLinePointColor = new Color[16];
                        for (int i = 0; i < 16; i++)
                        {
                            c.mplotpara1.PlotLinePointColor[i] = Color.Red;
                        }
                    }

                    if (c.mplotpara1.PlotLinePointStyle == null)
                    {
                        c.mplotpara1.PlotLinePointStyle = new NationalInstruments.UI.PointStyle[16];
                        for (int i = 0; i < 16; i++)
                        {
                            c.mplotpara1.PlotLinePointStyle[i] = NationalInstruments.UI.PointStyle.Cross;
                        }
                    }

                    if (c.mplotpara1.PlotLineSize == null)
                    {
                        c.mplotpara1.PlotLineSize = new int[16];
                        for (int i = 0; i < 16; i++)
                        {
                            c.mplotpara1.PlotLineSize[i] = 1;
                        }


                    }

                    if (c.mplotpara1.PlotLineStyle == null)
                    {
                        c.mplotpara1.PlotLineStyle = new NationalInstruments.UI.LineStyle[16];
                        for (int i = 0; i < 16; i++)
                        {
                            c.mplotpara1.PlotLineStyle[i] = NationalInstruments.UI.LineStyle.Solid;
                        }
                    }

                    if (c.mplotpara1.PlotLinePointSize == null)
                    {
                        c.mplotpara1.PlotLinePointSize = new int[16];
                        for (int i = 0; i < 16; i++)
                        {
                            c.mplotpara1.PlotLinePointSize[i] = 1;
                        }
                    }



                    if (c.mplotpara2.PlotLineColor == null)
                    {
                        c.mplotpara2.PlotLineColor = new Color[16];
                        for (int i = 0; i < 16; i++)
                        {
                            c.mplotpara2.PlotLineColor[i] = Color.Black;
                        }

                    }

                    if (c.mplotpara2.PlotLinePointColor == null)
                    {
                        c.mplotpara2.PlotLinePointColor = new Color[16];
                        for (int i = 0; i < 16; i++)
                        {
                            c.mplotpara2.PlotLinePointColor[i] = Color.Red;
                        }
                    }


                    if (c.mplotpara2.PlotLinePointStyle == null)
                    {
                        c.mplotpara2.PlotLinePointStyle = new NationalInstruments.UI.PointStyle[16];
                        for (int i = 0; i < 16; i++)
                        {
                            c.mplotpara2.PlotLinePointStyle[i] = NationalInstruments.UI.PointStyle.Cross;
                        }
                    }

                    if (c.mplotpara2.PlotLinePointSize == null)
                    {
                        c.mplotpara2.PlotLinePointSize = new int[16];
                        for (int i = 0; i < 16; i++)
                        {
                            c.mplotpara2.PlotLinePointSize[i] = 1;
                        }
                    }


                    if (c.mplotpara2.PlotLineSize == null)
                    {
                        c.mplotpara2.PlotLineSize = new int[16];
                        for (int i = 0; i < 16; i++)
                        {
                            c.mplotpara2.PlotLineSize[i] = 1;
                        }


                    }

                    if (c.mplotpara2.PlotLineStyle == null)
                    {
                        c.mplotpara2.PlotLineStyle = new NationalInstruments.UI.LineStyle[16];
                        for (int i = 0; i < 16; i++)
                        {
                            c.mplotpara2.PlotLineStyle[i] = NationalInstruments.UI.LineStyle.Solid;
                        }
                    }

                    if (c.mrawdata == null)
                    {
                        c.mrawdata = new List<ItemSignal>();
                    }

                    if (c.numinterval == null)
                    {
                        c.numinterval = new double[3];
                        for (int i = 0; i < 3; i++)
                        {
                            c.numinterval[i] = 0;
                        }
                    }

                    if (c.numintervallast == null)
                    {
                        c.numintervallast = new double[3];
                        for (int i = 0; i < 3; i++)
                        {
                            c.numintervallast[i] = 0;
                        }
                    }

                    if (c.numintervallast1 == null)
                    {
                        c.numintervallast1 = new double[3];
                        for (int i = 0; i < 3; i++)
                        {
                            c.numintervallast1[i] = 0;
                        }
                    }

                    if (c.cbomeasurement == null)
                    {
                        c.cbomeasurement = new int[3];
                        for (int i = 0; i < 3; i++)
                        {
                            c.cbomeasurement[i] = 0;
                        }
                    }
                    if (c.chkcriteria == null)
                    {
                        c.chkcriteria = new bool[3];
                        for (int i = 0; i < 3; i++)
                        {
                            c.chkcriteria[i] = false;
                        }
                    }

                    if (c.teststep == null)
                    {
                        c.teststep = new List<CTestStep>();
                        for (int i = 0; i < 9; i++)
                        {
                            CTestStep ct = new CTestStep();

                            if (ct.mstepPromptsItem == null)
                            {
                                ct.mstepPromptsItem = new List<PromptsItem>();
                            }
                            ct.Id = i;

                            c.teststep.Add(ct);
                        }

                        c.teststep[0].havedloop = false;
                        c.teststep[1].havedloop = true;
                        c.teststep[2].havedloop = true;
                        c.teststep[3].havedloop = true;
                        c.teststep[4].havedloop = true;
                        c.teststep[5].havedloop = true;
                        c.teststep[6].havedloop = true;

                        c.teststep[7].havedloop = false;
                        c.teststep[8].havedloop = false;
                    }

                    if (c.samplememo == null)
                    {
                        c.samplememo = " ";
                    }
                    if (c.samplememo1 == null)
                    {
                        c.samplememo1 = " ";
                    }
                    if (c.samplememo2 == null)
                    {
                        c.samplememo2 = " ";
                    }
                    if (c.samplename == null)
                    {
                        c.samplename = " ";
                    }
                    if (c.samplememo3 == null)
                    {
                        c.samplememo3 = " ";
                    }
                    if (c.mpromptslist == null)
                    {
                        c.mpromptslist = new List<PromptsItem>();
                    }
                    if (c.moutputexternal == null)
                    {
                        c.moutputexternal = new List<outputitem>();
                    }

                    if (c.mcbosamplestart == null)
                    {
                        c.mcbosamplestart = new List<double>();
                        c.mcbosamplestart.Add(0);
                        c.mcbosamplestart.Add(10.0);
                        c.mcbosamplestart.Add(20.0);
                        c.mcbosamplestart.Add(30.0);
                        c.mcbosamplestart.Add(60.0);
                    }

                    if (c.mcbosampleinterval == null)
                    {
                        c.mcbosampleinterval = new List<double>();
                        c.mcbosampleinterval.Add(0.1);
                        c.mcbosampleinterval.Add(1);
                        c.mcbosampleinterval.Add(10);
                        c.mcbosampleinterval.Add(20);
                        c.mcbosampleinterval.Add(30);
                        c.mcbosampleinterval.Add(60);
                        c.mcbosampleinterval.Add(600);
                        c.mcbosampleinterval.Add(1200);
                        c.mcbosampleinterval.Add(1800);
                        c.mcbosampleinterval.Add(3600);

                    }


                    if (c.mchsignals == null)
                    {
                        c.mchsignals = new List<ItemSignal>();
                        for (int i = 0; i < ClsStaticStation.m_Global.mycls.chsignals.Count; i++)
                        {
                            c.mchsignals.Add(ClsStaticStation.m_Global.mycls.chsignals[i]);
                        }

                    }

                    if (c.mFreeFormPromptsItem == null)
                    {
                        c.mFreeFormPromptsItem = new List<PromptsItem>();
                    }

                    //InitOutputExternal(ref c);

                    if (c.pretest_cmd == null)
                    {
                        c.pretest_cmd = new CmdSeg();

                    }

                    if (c.testcmdstep == null)
                    {
                        c.testcmdstep = new CmdSeg[4];

                        for (int i = 0; i < 4; i++)
                        {
                            c.testcmdstep[i] = new CmdSeg();
                        }
                    }


                    if (c.mseglist == null)
                    {
                        c.mseglist = new List<CmdSeg>();

                        if (mcontrolprocess == 1)
                        {
                            SegFile sf = new SegFile();

                            sf = sf.DeSerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ\\seg\\"
                                + SegName);

                            int i = 0;



                            int m = sf.mseglist.Count;

                            for (i = 0; i < m; i++)
                            {
                                CmdSeg n = new CmdSeg();
                                n.check = true;
                                n.controlmode = sf.mseglist[i].controlmode;
                                n.speed = sf.mseglist[i].speed;
                                n.destcontrolmode = sf.mseglist[i].destcontrolmode;
                                n.dest = sf.mseglist[i].dest;
                                c.mseglist.Add(n);
                            }
                        }


                    }

                    if (c.ReportTemplate == null)
                    {
                        c.ReportTemplate = "default.it";
                    }

                    if (c.simple_cmd == null)
                    {
                        c.simple_cmd = new CmdSeg();
                    }

                    if (c.mdatabaseitemlist == null)
                    {
                        c.mdatabaseitemlist = new List<DatabaseItem>();

                    }
                    c.Init_databaselist(false, c.currentspenumber);

                    if (c.mdatabaseitemselect == null)
                    {
                        c.mdatabaseitemselect = new List<DatabaseItem>();
                    }

                    if (c.mlongdata == null)
                    {
                        c.mlongdata = new List<ClsStaticStation.ItemSignal>();
                    }

                    fileStream.Close();




                }
            }
            catch (Exception e1)
            {
                c = new FileStruct();

                MessageBox.Show(e1.Message, "读取文件");
            }
            finally
            {

            }
            return (c);
        }
    }





    public class MyClassBase
    {



        public double q = 10;
        public double w1 = 0;
        public double[] v;
        public string[] vname;
        public double result = 0;
        public double[] CalcedChannelResult;





        public MyClassBase()
        {
            v = new double[100];
            vname = new string[100];
            CalcedChannelResult = new double[100];


        }

        public virtual double[] eval_hardchannel(int count)
        {
            return CalcedChannelResult;

        }
        public virtual void calcchannel(double[] v, string s)
        {

        }
        public virtual void doit()
        {

        }
        public virtual double eval(double x, double y)
        {

            return 0;
        }

        public virtual double[] eval_calcedchannel(int count)
        {

            return CalcedChannelResult;
        }



    }
}
namespace CComLibrary
{
    public class MathExpressionParser
    {
        public string msource;
        private string calcstring;

        public long stringlength = 0;

        public TextBox text;

        private ListBox list;

        private Microsoft.CSharp.CSharpCodeProvider cp;
        private System.CodeDom.Compiler.ICodeCompiler ic;
        private System.CodeDom.Compiler.CompilerParameters cpar;
        private System.CodeDom.Compiler.CompilerResults cr;
        public MyClassBase myobj = null;

        public ArrayList errorMessages;

        public DirectoryInfo info;

        void ReleaseDLL1()
        {

            string temp = System.Environment.GetEnvironmentVariable("TEMP");
            info = new DirectoryInfo(temp);

            //  byte[] byDll =global::AppleLabApplication.Properties.Resources.AppleLabApplication;//获取嵌入dll文件的字节数组  



            string strPath = info.FullName + @"\AppleLabApplication.dll";//设置释放路径  
                                                                         //创建dll文件（覆盖模式）  
            using (FileStream fs = new FileStream(strPath, FileMode.Create))
            {
                // fs.Write(byDll, 0, byDll.Length);
            }
            /*

            byte[] byDll1 = global::AppleLabApplication.Properties.Resources.nianlys;
             strPath = info.FullName + @"\nianlys.dll";//设置释放路径  
                                                                         //创建dll文件（覆盖模式）  
            using (FileStream fs = new FileStream(strPath, FileMode.Create))
            {
                fs.Write(byDll1, 0, byDll1.Length);
            }
            */
        }


        void ReleaseDLL()
        {


            // byte[] byDll = global::AppleLabApplication.Properties.Resources.AppleLabApplication;//获取嵌入dll文件的字节数组  
            string strPath = Application.CommonAppDataPath + @"\AppleLabApplication.dll";//设置释放路径  
                                                                                         //创建dll文件（覆盖模式）  
            using (FileStream fs = new FileStream(strPath, FileMode.Create))
            {
                ////  fs.Write(byDll, 0, byDll.Length);
            }



        }

        public MathExpressionParser()
        {


            //  ReleaseDLL();
            errorMessages = new ArrayList();


            cp = new Microsoft.CSharp.CSharpCodeProvider();
            ic = cp.CreateCompiler();
            cpar = new System.CodeDom.Compiler.CompilerParameters();
            cpar.GenerateInMemory = true;
            cpar.GenerateExecutable = false;
            cpar.ReferencedAssemblies.Add(Application.StartupPath + "\\system.dll");
            cpar.ReferencedAssemblies.Add(Application.StartupPath + "\\System.Windows.Forms.dll");

            /*
            if (File.Exists(info.FullName + @"\AppleLabApplication.dll"))
            {
                cpar.ReferencedAssemblies.Add(info.FullName + @"\AppleLabApplication.dll");//添加可执行文件名
            }
            
            */

            //if (File.Exists(Application.CommonAppDataPath + @"\AppleLabApplication.dll"))
            {
                cpar.ReferencedAssemblies.Add(Application.StartupPath + "\\AppleLabApplication.dll");//添加可执行文件名
            }


            calcstring = "";
            list = new ListBox();
            text = new TextBox();
            text.Multiline = true;
            //cpar.ReferencedAssemblies.Add(AppDomain.CurrentDomain.FriendlyName);


        }




        public void InitArray(string s, int count)
        {
            int istart;
            int iend;
            int i, j;
            string mys;
            string[] s1;
            mys = s;

            for (i = 1; i <= GlobeVal.filesave.muserchannel.Count; i++)
            {
                mys = mys + " " + GlobeVal.filesave.muserchannel[i - 1].channelname;

            }



            char[] a;
            a = new char[1];
            a[0] = Convert.ToChar(" ");
            s1 = mys.Split(a);

            istart = list.FindString("//var array begin" + "\r\n");
            iend = list.FindString("//var array end" + "\r\n");



            mys = "";



            for (i = 0; i < s1.Length; i++)
            {
                mys = mys + "public double[] " + s1[i] + ";" + "\r\n";


            }

            for (i = istart + 1; i <= iend - 1; i++)
            {
                list.Items.RemoveAt(istart + 1);

            }
            i = istart + 1;
            list.Items.Insert(i, mys);


            istart = list.FindString("//array new begin" + "\r\n");
            iend = list.FindString("//array new end" + "\r\n");

            //mys = "";

            //for (i = 0; i < s1.Length; i++)
            {
                // mys = mys +   s1[i] +" = new double"+"["+count.ToString().Trim()+"]" +";"+ "\r\n";


            }
            //istart = istart + 1;
            //list.Items.Insert(istart, mys);

            mys = "";

            for (i = 0; i < s1.Length; i++)
            {

                mys = mys + s1[i] + " = GlobeVal.m_data[" + i.ToString().Trim() + "];" + "\r\n";
            }
            istart = istart + 1;
            list.Items.Insert(istart, mys);

            mys = "";


            // for (i = 0; i < GlobeVal.filesave.muserchannel.Count; i++)
            for (i = 0; i < 0; i++)
            {


                mys = mys + " for (int j = 0; j < GlobeVal.m_len - 1; j++)\r\n";
                mys = mys + "{\r\n";


                mys = mys + "索引=j;\r\n";

                //mys = mys + GlobeVal.filesave.muserchannel[i].channelvalue+"\r\n";

                istart = istart + 1;
                list.Items.Insert(istart, mys);

                mys = "";

                mys = mys + "//calcchannel begin" + (i + 1).ToString().Trim() + "\r\n";
                istart = istart + 1;
                list.Items.Insert(istart, mys);

                mys = "";
                mys = mys + "//calcchannel end" + (i + 1).ToString().Trim() + "\r\n";

                istart = istart + 1;
                list.Items.Insert(istart, mys);

                mys = "";

                if (CComLibrary.GlobeVal.languageselect == 0)
                {
                    mys = mys + "GlobeVal.m_calcdata[" + i.ToString().Trim() + "][j] =_结果;";
                }
                else
                {
                    mys = mys + "GlobeVal.m_calcdata[" + i.ToString().Trim() + "][j] =_Result;";
                }
                mys = mys + "\r\n}\r\n";

            }







            //for (i = s1.Length - GlobeVal.filesave.muserchannel.Count; i < s1.Length; i++)
            {
                // mys = mys + s1[i] + " = GlobeVal.m_calcdata[" + (i-(s1.Length - GlobeVal.filesave.muserchannel.Count)).ToString().Trim() + "];" + "\r\n";
            }


            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                mys = mys + "_数组长度=" + (GlobeVal.m_len).ToString() + ";" + "\r\n";
            }
            else
            {
                mys = mys + "_Length_of_array=" + (GlobeVal.m_len).ToString() + ";" + "\r\n";

            }

            for (i = istart + 1; i <= iend - 1; i++)
            {
                list.Items.RemoveAt(istart + 1);

            }
            istart = istart + 1;
            list.Items.Insert(istart, mys);





        }

        public void Init_Func()
        {
            CComLibrary.GlobeVal.mfunc.Clear();

            CComLibrary.Rule a = new CComLibrary.Rule();

            a.OperaWordsName = "_坐标轴设置";

            a.LOperaWordsName[0] = "_坐标轴设置";
            a.LOperaWordsName[1] = "_AxisSetting";

            a.ListString = "";
            a.LListString[0] = "public void " + a.LOperaWordsName[0] + "(int para) \r\n { CComLibrary.GlobeVal._SetCoordinates(para);}\r\n";
            a.LListString[1] = "public void " + a.LOperaWordsName[1] + "(int para) \r\n { CComLibrary.GlobeVal._SetCoordinates(para);}\r\n";


            a.replaceName = a.OperaWordsName;
            a.count = 1;
            a.explain = "选择坐标轴是单坐标轴还是左右双坐标轴";
            a.LExplain[0] = "选择坐标轴是单坐标轴还是左右双坐标轴,kind 0-单坐标轴 ,1-双坐标轴";
            a.LExplain[1] = "Select whether the coordinate axis is a single coordinate axis or a left-right double coordinate axis.kind is  0- single axis, 1- double axes.";



            a.paraname[0] = "kind";
            a.parakind[0] = "integer";

            CComLibrary.GlobeVal.mfunc.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_消息框";
            a.LOperaWordsName[0] = "_消息框";
            a.LOperaWordsName[1] = "_MsgBox";

            a.ListString = "";
            a.LListString[0] = "public void " + a.LOperaWordsName[0] + "(string para) \r\n  { CComLibrary.GlobeVal._MessageBox(para);}\r\n";
            a.LListString[1] = "public void " + a.LOperaWordsName[1] + "(string para) \r\n  { CComLibrary.GlobeVal._MessageBox(para);}\r\n";


            a.replaceName = a.OperaWordsName;
            a.count = 1;
            a.explain = "显示消息框";
            a.LExplain[0] = "显示消息框";
            a.LExplain[1] = "Display message box";

            a.paraname[0] = "text";
            a.parakind[0] = "string";

            CComLibrary.GlobeVal.mfunc.Add(a);


            a = new CComLibrary.Rule();
            a.OperaWordsName = "_调试输出";
            a.LOperaWordsName[0] = "_调试输出";
            a.LOperaWordsName[1] = "_DebugOutput";



            a.ListString = "";
            a.LListString[0] = "public void " + a.LOperaWordsName[0] + "(string para) \r\n { CComLibrary.GlobeVal._DebugOut(para);}\r\n";
            a.LListString[1] = "public void " + a.LOperaWordsName[1] + "(string para) \r\n { CComLibrary.GlobeVal._DebugOut(para);}\r\n";



            a.replaceName = a.OperaWordsName;
            a.count = 1;
            a.explain = "在调试界面中输出";
            a.LExplain[0] = "在调试界面中输出";
            a.LExplain[1] = "Output in debug interface";
            a.paraname[0] = "text";
            a.parakind[0] = "string";

            CComLibrary.GlobeVal.mfunc.Add(a);


            a = new CComLibrary.Rule();
            a.OperaWordsName = "_清除曲线";
            a.LOperaWordsName[0] = "_清除曲线";
            a.LOperaWordsName[1] = "_ClearCurveData";

            a.ListString = "";
            a.LListString[0] = "public void " + a.LOperaWordsName[0] + "(int para) \r\n { CComLibrary.GlobeVal._ClearLine(para);}\r\n";
            a.LListString[1] = "public void " + a.LOperaWordsName[1] + "(int para) \r\n { CComLibrary.GlobeVal._ClearLine(para);}\r\n";


            a.replaceName = a.OperaWordsName;
            a.count = 1;
            a.explain = "清除指定曲线数据";
            a.LExplain[0] = "清除指定曲线数据";
            a.LExplain[1] = "Clears the specified curve data";
            a.paraname[0] = "curve number";
            a.parakind[0] = "int";

            CComLibrary.GlobeVal.mfunc.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_设置曲线对应坐标轴";
            a.LOperaWordsName[0] = "_设置曲线对应坐标轴";
            a.LOperaWordsName[1] = "_SetCurveAxis";

            a.ListString = "";
            a.LListString[0] = "public void " + a.LOperaWordsName[0] + "(int c,int n) \r\n { CComLibrary.GlobeVal._SetYAxis(c,n);}\r\n";
            a.LListString[1] = "public void " + a.LOperaWordsName[1] + "(int c,int n) \r\n { CComLibrary.GlobeVal._SetYAxis(c,n);}\r\n";


            a.replaceName = a.OperaWordsName;
            a.count = 2;
            a.explain = "指定曲线使用左坐标轴还是右坐标轴,Curve number 1-8， Axis 0 左轴 1 右轴";
            a.LExplain[0] = "指定曲线使用左坐标轴还是右坐标轴";
            a.LExplain[1] = "Specifies whether the curve uses the left axis or the right axis. Curve number:1-8.  Axis 0 leftaxis, 1 rightaxis";

            a.paraname[0] = "Curve number";
            a.parakind[0] = "int";
            a.paraname[1] = "Axis";
            a.parakind[1] = "int";
            CComLibrary.GlobeVal.mfunc.Add(a);




            a = new CComLibrary.Rule();
            a.OperaWordsName = "_清除所有曲线";
            a.LOperaWordsName[0] = "_清除所有曲线";
            a.LOperaWordsName[1] = "_ClearAllCurve";

            a.ListString = "";

            a.LListString[0] = "public void " + a.LOperaWordsName[0] + "()\r\n { CComLibrary.GlobeVal._clearxy();}\r\n";
            a.LListString[1] = "public void " + a.LOperaWordsName[1] + "()\r\n { CComLibrary.GlobeVal._clearxy();}\r\n";

            a.replaceName = a.OperaWordsName;
            a.count = 0;
            a.explain = "清除所有曲线数据";
            a.LExplain[0] = "清除所有曲线数据";
            a.LExplain[1] = "Clear all curve data";

            a.paraname[0] = "";
            a.parakind[0] = "";

            CComLibrary.GlobeVal.mfunc.Add(a);


            a = new CComLibrary.Rule();
            a.OperaWordsName = "_闭合曲线";
            a.LOperaWordsName[0] = "_闭合曲线";
            a.LOperaWordsName[1] = "_CloseCurve";

            a.ListString = "";
            a.LListString[0] = "public void " + a.LOperaWordsName[0] + "(int n) \r\n { CComLibrary.GlobeVal._CloseCurve(n) ;} \r\n";
            a.LListString[1] = "public void " + a.LOperaWordsName[1] + "(int n) \r\n { CComLibrary.GlobeVal._CloseCurve(n) ;} \r\n";

            a.replaceName = a.OperaWordsName;
            a.count = 1;
            a.explain = "从头到尾连接曲线,使曲线闭合";
            a.LExplain[0] = "从头到尾连接曲线,使曲线闭合";
            a.LExplain[1] = "Connect the curve from beginning to end so that the curve closes.";

            a.paraname[0] = "Curve number";
            a.parakind[0] = "integer";

            CComLibrary.GlobeVal.mfunc.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_画XY曲线";
            a.LOperaWordsName[0] = "_画XY曲线";
            a.LOperaWordsName[1] = "_PlotXY";

            a.ListString = "";
            a.LListString[0] = "public void " + a.LOperaWordsName[0] + "(double[] x,double[] y ,int n) \r\n { CComLibrary.GlobeVal._plotxy(x,y,n) ;} \r\n";
            a.LListString[1] = "public void " + a.LOperaWordsName[1] + "(double[] x,double[] y ,int n) \r\n { CComLibrary.GlobeVal._plotxy(x,y,n) ;} \r\n";


            a.replaceName = a.OperaWordsName;
            a.count = 3;
            a.explain = "使用一个二维数组绘制曲线";
            a.LExplain[0] = "使用一个二维数组绘制曲线";
            a.LExplain[1] = "Draw curves using a two-dimensional array";

            a.paraname[0] = "X";
            a.parakind[0] = "double []";
            a.paraname[1] = "Y";
            a.parakind[1] = "double []";
            a.paraname[2] = "Curve number";
            a.parakind[2] = "integer";

            CComLibrary.GlobeVal.mfunc.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_画XY点";
            a.LOperaWordsName[0] = "_画XY点";
            a.LOperaWordsName[1] = "_PlotPoint";

            a.ListString = "";
            a.LListString[0] = "public void " + a.LOperaWordsName[0] + "(double x,double y,int n) \r\n { CComLibrary.GlobeVal._plotxypoint(x,y,n) ;} \r\n";
            a.LListString[1] = "public void " + a.LOperaWordsName[1] + "(double x,double y,int n) \r\n { CComLibrary.GlobeVal._plotxypoint(x,y,n) ;} \r\n";


            a.replaceName = a.OperaWordsName;
            a.count = 3;
            a.explain = "把一个XY坐标点绘制到曲线上";
            a.LExplain[0] = "把一个XY坐标点绘制到曲线上";
            a.LExplain[1] = "Draw a coordinate point onto the curve";

            a.paraname[0] = "X";
            a.parakind[0] = "double";
            a.paraname[1] = "Y";
            a.parakind[1] = "double";
            a.paraname[2] = "Curve number";
            a.parakind[2] = "integer";

            CComLibrary.GlobeVal.mfunc.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_拐点";
            a.LOperaWordsName[0] = "_拐点";
            a.LOperaWordsName[1] = "_InflectionPoint";
            a.ListString = "";
            a.LListString[0] = "public double " + a.LOperaWordsName[0] + "(double[] x,double[] y, double offset, bool mdraw)" + "\r\n" + " {  double v;  int i;\r\n  CComLibrary.GlobeVal._yield(x,y, offset, mdraw, out v,out i);\r\n return v; \r\n}\r\n";

            a.LListString[1] = "public double " + a.LOperaWordsName[1] + "(double[] x,double[] y, double offset, bool mdraw)" + "\r\n" + " {  double v;  int i;\r\n  CComLibrary.GlobeVal._yield(x,y, offset, mdraw, out v,out i);\r\n return v; \r\n}\r\n";


            a.replaceName = a.OperaWordsName;
            a.count = 4;
            a.explain = "指定偏移值求拐点,可指定是否显示在曲线上";
            a.LExplain[0] = "指定偏移值求拐点,可指定是否显示在曲线上";
            a.LExplain[1] = "Specify the offset value to find the inflection point, which can specify whether it is displayed on the curve or not.";


            a.paraname[0] = "X";
            a.parakind[0] = "double []";

            a.paraname[1] = "Y";
            a.parakind[1] = "double []";

            a.paraname[2] = "offset value";
            a.parakind[2] = "double";

            a.paraname[3] = "Show";
            a.parakind[3] = "bool";

            CComLibrary.GlobeVal.mfunc.Add(a);





            a = new CComLibrary.Rule();
            a.OperaWordsName = "_斜率";
            a.LOperaWordsName[0] = "_斜率";
            a.LOperaWordsName[1] = "_Slope";

            a.replaceName = a.OperaWordsName;
            a.count = 3;
            a.explain = "计算斜率，并指示是否在曲线上显示";
            a.LExplain[0] = "计算斜率，并指示是否在曲线上显示";
            a.LExplain[1] = "Calculate the slope and indicate whether it is displayed on the curve.";

            a.ListString = "";
            a.LListString[0] = "public double " + a.LOperaWordsName[0] + "(double[] x,double[] y,bool mdraw) \r\n {double mslope; double a;double b; \r\n CComLibrary.GlobeVal._automodule(x,y,mdraw, out mslope, out a, out b); return mslope;\r\n}\r\n";
            a.LListString[1] = "public double " + a.LOperaWordsName[1] + "(double[] x,double[] y,bool mdraw) \r\n {double mslope; double a;double b; \r\n CComLibrary.GlobeVal._automodule(x,y,mdraw, out mslope, out a, out b); return mslope;\r\n}\r\n";

            a.paraname[0] = "X";
            a.parakind[0] = "double []";

            a.paraname[1] = "Y";
            a.parakind[1] = "double []";

            a.paraname[2] = "Draw";
            a.parakind[2] = "Bool";

            CComLibrary.GlobeVal.mfunc.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_材料屈服点索引";
            a.LOperaWordsName[0] = "_材料屈服点索引";
            a.LOperaWordsName[1] = "_YieldIndex";

            a.replaceName = a.OperaWordsName;
            a.count = 3;
            a.explain = "计算材料屈服点，并返回在数组中的索引";
            a.LExplain[0] = "计算材料屈服点，并返回在数组中的索引";
            a.LExplain[1] = "Calculates the yield point of the material and returns the index in the array.";

            a.ListString = "";
            a.LListString[0] = "public int " + a.OperaWordsName[0] + "(double[] x, double[] y, bool mdraw) \r\n {int v;\r\n CComLibrary.GlobeVal._normalyield(x, y, mdraw, out v);return v;\r\n}\r\n";
            a.LListString[1] = "public int " + a.OperaWordsName[1] + "(double[] x, double[] y, bool mdraw) \r\n {int v;\r\n CComLibrary.GlobeVal._normalyield(x, y, mdraw, out v);return v;\r\n}\r\n";
            a.paraname[0] = "X";
            a.parakind[0] = "double []";

            a.paraname[1] = "Y";
            a.parakind[1] = "double []";

            a.paraname[2] = "Draw";
            a.parakind[2] = "Bool";
            CComLibrary.GlobeVal.mfunc.Add(a);


            a = new CComLibrary.Rule();
            a.OperaWordsName = "_材料上屈服点索引";
            a.LOperaWordsName[0] = "_材料上屈服点索引";
            a.LOperaWordsName[1] = "_UpperYieldIndex";

            a.replaceName = a.OperaWordsName;
            a.count = 3;
            a.explain = "计算材料上屈服点,并返回在数组中的索引";
            a.LExplain[0] = "计算材料上屈服点,并返回在数组中的索引";
            a.LExplain[1] = "Calculates the upper yield point and returns the index in the array.";

            a.ListString = "";
            a.LListString[0] = "public int " + a.LOperaWordsName[0] + "(double[] x,double[] y,bool mdraw) \r\n {int v;\r\n CComLibrary.GlobeVal._upperyield(x,y,mdraw,out v);return v;\r\n}\r\n";
            a.LListString[1] = "public int " + a.LOperaWordsName[1] + "(double[] x,double[] y,bool mdraw) \r\n {int v;\r\n CComLibrary.GlobeVal._upperyield(x,y,mdraw,out v);return v;\r\n}\r\n";

            a.paraname[0] = "X";
            a.parakind[0] = "double []";

            a.paraname[1] = "Y";
            a.parakind[1] = "double []";

            a.paraname[2] = "Draw";
            a.parakind[2] = "Bool";
            CComLibrary.GlobeVal.mfunc.Add(a);


            a = new CComLibrary.Rule();
            a.OperaWordsName = "_材料下屈服点索引";
            a.LOperaWordsName[0] = "_材料下屈服点索引";
            a.LOperaWordsName[1] = "_LowerYieldIndex";
            a.ListString = "";
            a.LListString[0] = "public int " + a.LOperaWordsName[0] + "(double[] x,double[] y,bool mdraw) \r\n {int v;\r\n CComLibrary.GlobeVal._loweryield(x,y,mdraw,out v);return v;\r\n}\r\n";
            a.LListString[1] = "public int " + a.LOperaWordsName[1] + "(double[] x,double[] y,bool mdraw) \r\n {int v;\r\n CComLibrary.GlobeVal._loweryield(x,y,mdraw,out v);return v;\r\n}\r\n";



            a.replaceName = a.OperaWordsName;
            a.count = 3;
            a.explain = "计算材料下屈服点索引";
            a.paraname[0] = "X";
            a.parakind[0] = "double []";

            a.paraname[1] = "Y";
            a.parakind[1] = "double []";

            a.paraname[2] = "Draw";
            a.parakind[2] = "Bool";
            CComLibrary.GlobeVal.mfunc.Add(a);



            a = new CComLibrary.Rule();
            a.OperaWordsName = "_斜率1";
            a.LOperaWordsName[0] = "_斜率1";
            a.LOperaWordsName[1] = "_Slope1";

            a.ListString = "";
            a.LListString[0] = "public double " + a.LOperaWordsName[0] + "(double[] x,double[] y, double yminpercent,double ymaxpercent, bool mdraw) \r\n {double mslope; int a;int b; \r\n CComLibrary.GlobeVal._module(x,y,yminpercent,ymaxpercent, mdraw, out mslope, out a, out b); return mslope;\r\n}\r\n";
            a.LListString[1] = "public double " + a.LOperaWordsName[1] + "(double[] x,double[] y, double yminpercent,double ymaxpercent, bool mdraw) \r\n {double mslope; int a;int b; \r\n CComLibrary.GlobeVal._module(x,y,yminpercent,ymaxpercent, mdraw, out mslope, out a, out b); return mslope;\r\n}\r\n";


            a.replaceName = a.OperaWordsName;
            a.count = 5;
            a.explain = "计算斜率";
            a.LExplain[0] = "计算斜率";
            a.LExplain[1] = "Calculation slope";

            a.paraname[0] = "X";
            a.parakind[0] = "double []";

            a.paraname[1] = "Y";
            a.parakind[1] = "double []";

            a.paraname[2] = "YMin%";
            a.parakind[2] = "double";

            a.paraname[3] = "YMax%";
            a.parakind[3] = "double";

            a.paraname[4] = "Draw";
            a.parakind[4] = "Bool";
            CComLibrary.GlobeVal.mfunc.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_偏置斜率交点";
            a.LOperaWordsName[0] = "_偏置斜率交点";
            a.LOperaWordsName[1] = "_OffsetSlopeIntersectionPoint";

            a.ListString = "";
            a.LListString[0] = "public double " + a.LOperaWordsName[0] + "(double[] x, double[] y,  double yminpercent,double ymaxpercent,double oa, bool mdraw)\r\n{ double value;\r\n GlobeVal._offsetslopepoint(x,y,yminpercent,ymaxpercent,oa, out value,mdraw); return value;\r\n}\r\n";
            a.LListString[1] = "public double " + a.LOperaWordsName[1] + "(double[] x, double[] y,  double yminpercent,double ymaxpercent,double oa, bool mdraw)\r\n{ double value;\r\n GlobeVal._offsetslopepoint(x,y,yminpercent,ymaxpercent,oa, out value,mdraw); return value;\r\n}\r\n";



            a.replaceName = a.OperaWordsName;
            a.count = 6;
            a.explain = "在X轴偏置点做一条与指定斜率平行的直接，求该直线和曲线相交点";
            a.LExplain[0] = "在X轴偏置点做一条与指定斜率平行的直接，求该直线和曲线相交点";
            a.LExplain[1] = "At the offset point of the X axis, make a direct parallel to the specified slope, and find the intersection point between the line and the curve.";

            a.paraname[0] = "X";
            a.parakind[0] = "double []";

            a.paraname[1] = "Y";
            a.parakind[1] = "double []";

            a.paraname[2] = "YMin%";
            a.parakind[2] = "double";

            a.paraname[3] = "YMax%";
            a.parakind[3] = "double";

            a.paraname[4] = "Offset";
            a.parakind[4] = "double";



            a.paraname[5] = "Draw";
            a.parakind[5] = "Bool";
            CComLibrary.GlobeVal.mfunc.Add(a);



            a = new CComLibrary.Rule();
            a.OperaWordsName = "_数组Y最大值";
            a.LOperaWordsName[0] = "_数组Y最大值";
            a.LOperaWordsName[1] = "_MaxYInArray";

            a.ListString = "";
            a.LListString[0] = "public double " + a.LOperaWordsName[0] + "(double[] x, double[] y, bool mdraw)\r\n{ double value; int index; \r\n GlobeVal._maxyvalue(x,y,out value, out index, mdraw); return value;\r\n}\r\n";
            a.LListString[1] = "public double " + a.LOperaWordsName[1] + "(double[] x, double[] y, bool mdraw)\r\n{ double value; int index; \r\n GlobeVal._maxyvalue(x,y,out value, out index, mdraw); return value;\r\n}\r\n";


            a.replaceName = a.OperaWordsName;
            a.count = 3;
            a.explain = "计算数组Y最大值";
            a.LExplain[0] = "计算数组Y最大值";
            a.LExplain[1] = "Calculate the maximum value of array Y";


            a.paraname[0] = "X";
            a.parakind[0] = "double []";
            a.paraname[1] = "Y";
            a.parakind[1] = "double []";

            a.paraname[2] = "Draw";
            a.parakind[2] = "Bool";
            CComLibrary.GlobeVal.mfunc.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_引伸计1标距";
            a.LOperaWordsName[0] = "_引伸计1标距";
            a.LOperaWordsName[1] = "_ExtensometerGaugeForOne";

            a.ListString = "";
            a.LListString[0] = "public double " + a.LOperaWordsName[0] + "()\r\n{ double value;\r\n CComLibrary.GlobeVal._gauge(out value); return value;\r\n} \r\n";
            a.LListString[1] = "public double " + a.LOperaWordsName[1] + "()\r\n{ double value;\r\n CComLibrary.GlobeVal._gauge(out value); return value;\r\n} \r\n";


            a.replaceName = a.OperaWordsName;
            a.count = 0;
            a.explain = "取得1号引伸计标距值";
            a.LExplain[0] = "取得1号引伸计标距值";
            a.LExplain[1] = "Get the No. 1 extensometer gauge value.";

            CComLibrary.GlobeVal.mfunc.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_引伸计2标距";
            a.LOperaWordsName[0] = "_引伸计2标距";
            a.LOperaWordsName[1] = "_ExtensometerGaugeForTow";

            a.ListString = "";
            a.LListString[0] = "public double " + a.LOperaWordsName[0] + "()\r\n{ double value;\r\n CComLibrary.GlobeVal._gauge1(out value); return value;\r\n} \r\n";
            a.LListString[1] = "public double " + a.LOperaWordsName[1] + "()\r\n{ double value;\r\n CComLibrary.GlobeVal._gauge1(out value); return value;\r\n} \r\n";


            a.replaceName = a.OperaWordsName;
            a.count = 0;
            a.explain = "取得2号引伸计标距值";
            a.LExplain[0] = "取得2号引伸计标距值";
            a.LExplain[1] = "Get the No. 2 extensometer gauge value.";

            CComLibrary.GlobeVal.mfunc.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_断后伸长率";
            a.LOperaWordsName[0] = "_断后伸长率";
            a.LOperaWordsName[1] = "_ElongationAtBreak";

            a.ListString = "";
            a.LListString[0] = "public double " + a.LOperaWordsName[0] + "()\r\n{ double value;\r\n CComLibrary.GlobeVal._ElongationAfterBreak(out value); return value;\r\n}\r\n";
            a.LListString[1] = "public double " + a.LOperaWordsName[1] + "()\r\n{ double value;\r\n CComLibrary.GlobeVal._ElongationAfterBreak(out value); return value;\r\n}\r\n";



            a.replaceName = a.OperaWordsName;
            a.count = 0;
            a.explain = "求断后伸长率";
            a.LExplain[0] = "求断后伸长率";
            a.LExplain[1] = "Calculating elongation after breaking";
            CComLibrary.GlobeVal.mfunc.Add(a);


            a = new CComLibrary.Rule();
            a.OperaWordsName = "_面积";
            a.LOperaWordsName[0] = "_面积";
            a.LOperaWordsName[1] = "_Area";

            a.ListString = "";
            a.LListString[0] = "public double " + a.LOperaWordsName[0] + "()\r\n{ double value;\r\n CComLibrary.GlobeVal._area(out value); return value;\r\n}\r\n";
            a.LListString[1] = "public double " + a.LOperaWordsName[1] + "()\r\n{ double value;\r\n CComLibrary.GlobeVal._area(out value); return value;\r\n}\r\n";


            a.replaceName = a.OperaWordsName;
            a.count = 0;
            a.explain = "计算面积";
            a.LExplain[0] = "计算试样初始横截面积";
            a.LExplain[1] = "Calculate the initial cross-sectional area of specimens";

            CComLibrary.GlobeVal.mfunc.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_断后面积";
            a.LOperaWordsName[0] = "_断后面积";
            a.LOperaWordsName[1] = "_FractureArea";

            a.ListString = "";
            a.LListString[0] = "public double " + a.LOperaWordsName[0] + "()\r\n{ double value;\r\n CComLibrary.GlobeVal._BreakArea(out value); return value;\r\n}\r\n";
            a.LListString[1] = "public double " + a.LOperaWordsName[1] + "()\r\n{ double value;\r\n CComLibrary.GlobeVal._BreakArea(out value); return value;\r\n}\r\n";


            a.replaceName = a.OperaWordsName;
            a.count = 0;
            a.explain = "输入断后尺寸并计算断后试样面积";
            a.LExplain[0] = "输入断后尺寸并计算断后试样面积";
            a.LExplain[1] = "After fracture, the size of the specimen is input, and the area of the broken sample is calculated.";

            CComLibrary.GlobeVal.mfunc.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_预设点";
            a.LOperaWordsName[0] = "_预设点";
            a.LOperaWordsName[1] = "_YFromX";

            a.ListString = "";
            a.LListString[0] = "public double " + a.LOperaWordsName[0] + "(double[] setx,double[] calcy,double setvalue,bool mdraw)\r\n{ double t; CComLibrary.GlobeVal._presetcalc(setx,calcy,setvalue,out t,mdraw); return t;}\r\n";
            a.LListString[1] = "public double " + a.LOperaWordsName[1] + "(double[] setx,double[] calcy,double setvalue,bool mdraw)\r\n{ double t; CComLibrary.GlobeVal._presetcalc(setx,calcy,setvalue,out t,mdraw); return t;}\r\n";



            a.replaceName = a.OperaWordsName;
            a.count = 4;
            a.explain = "在二维数组中，指定X列中的某个值并求对应的Y列中的值";
            a.LExplain[0] = "在二维数组中，指定X列中的某个值并求对应的Y列中的值";
            a.LExplain[1] = "In a two-dimensional array, specify a value in the X column and find the value in the corresponding Y column.";



            a.paraname[0] = "SetChannel";
            a.parakind[0] = "double []";

            a.paraname[1] = "CalcedChannel";
            a.parakind[1] = "double []";

            a.paraname[2] = "SetValue";
            a.parakind[2] = "double";

            a.paraname[3] = "Draw";
            a.parakind[3] = "Bool";


            CComLibrary.GlobeVal.mfunc.Add(a);
            /*
            a = new CComLibrary.Rule();
            a.OperaWordsName = "_弦向弹模";
            a.LOperaWordsName[0] = "_弦向弹模";
            a.LOperaWordsName[1]= "_ChordModulus";

            a.ListString = "";
            a.LListString[0] = "";


            a.replaceName = a.OperaWordsName;
            a.count = 2;
            a.explain = "计算弦向弹模";
            a.LExplain[0] = "计算弦向弹模";
            a.LExplain[1] = "Calculating chord elastic modulus";

            a.paraname[0] = "X";
            a.parakind[0] = "double []";

            a.paraname[1] = "Y";
            a.parakind[1] = "double []";
            //CComLibrary.GlobeVal.mfunc.Add(a);

            

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_曲线拟合";
            a.LOperaWordsName[0] = "_曲线拟合";
            a.LOperaWordsName[1] = "_CurveFitting";

            a.replaceName = a.OperaWordsName;
            a.count = 2;
            a.explain = "对二维数组进行曲线拟合，并计算其斜率";
            a.LExplain[0] = "对二维数组进行曲线拟合，并计算其斜率";
            a.LExplain[1] = "Curve fitting for a set of two-dimensional arrays and calculate its slope.";

            a.paraname[0] = "X";
            a.parakind[0] = "double []";
            a.explain = "Y";
            a.paraname[1] = "Y";
            a.parakind[1] = "double []";
            CComLibrary.GlobeVal.mfunc.Add(a);
            
            a = new CComLibrary.Rule();
            a.OperaWordsName = "_坐标轴标题";
            a.LOperaWordsName[0] = "_坐标轴标题";
            a.LOperaWordsName[1] = "_坐标轴标题";

            a.replaceName = a.OperaWordsName;
            a.count = 2;
            a.explain = "设置坐标轴标题";


            a.paraname[0] = "";
            a.parakind[0] = "Integer";
           
            a.paraname[1] = "text";
            a.parakind[1] = "String";

            CComLibrary.GlobeVal.mfunc.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_曲线标题";
            a.replaceName = a.OperaWordsName;
            a.count = 1;
            a.explain = "设置曲线标题类容";
            a.paraname[0] = "标题内容";
            a.parakind[0] = "String";
            CComLibrary.GlobeVal.mfunc.Add(a);
           */

            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                for (int i = 0; i < CComLibrary.GlobeVal.mfunc.Count; i++)
                {
                    CComLibrary.GlobeVal.mfunc[i].OperaWordsName = CComLibrary.GlobeVal.mfunc[i].LOperaWordsName[0];
                    CComLibrary.GlobeVal.mfunc[i].explain = CComLibrary.GlobeVal.mfunc[i].LExplain[0];
                    CComLibrary.GlobeVal.mfunc[i].ListString = CComLibrary.GlobeVal.mfunc[i].LListString[0];

                }
            }
            else
            {
                for (int i = 0; i < CComLibrary.GlobeVal.mfunc.Count; i++)
                {
                    CComLibrary.GlobeVal.mfunc[i].OperaWordsName = CComLibrary.GlobeVal.mfunc[i].LOperaWordsName[1];
                    CComLibrary.GlobeVal.mfunc[i].explain = CComLibrary.GlobeVal.mfunc[i].LExplain[1];
                    CComLibrary.GlobeVal.mfunc[i].ListString = CComLibrary.GlobeVal.mfunc[i].LListString[1];

                }
            }

        }

        public void InitBegin()
        {
            int i;



            list.Items.Clear();
            list.Items.Add("using System;" + "\r\n");
            list.Items.Add("using CComLibrary;\r\n");
            list.Items.Add("using System.Windows.Forms;\r\n");
            //  list.Items.Add("using NationalInstruments.Analysis;\r\n");

            //list.Items.Add("using NationalInstruments.Analysis;\r\n");
            //list.Items.Add("using NationalInstruments.Analysis.Conversion;\r\n");
            //list.Items.Add("using NationalInstruments.Analysis.Dsp;\r\n");
            //list.Items.Add("using NationalInstruments.Analysis.Dsp.Filters;\r\n");
            //list.Items.Add("using NationalInstruments.Analysis.Monitoring;\r\n");
            //list.Items.Add("using NationalInstruments.Analysis.SignalGeneration;\r\n");
            //list.Items.Add("using NationalInstruments;\r\n");

            //list.Items.Add("using NationalInstruments.Analysis.Math;\r\n");
            list.Items.Add("using ClsStaticStation;\r\n");

            list.Items.Add("class myclass:CComLibrary.MyClassBase" + "\r\n");
            list.Items.Add("{" + "\r\n");
            list.Items.Add("public Boolean  _有效=false;\r\n ");
            list.Items.Add("public const int _单坐标=0;\r\n");
            list.Items.Add("public const int _双坐标=1;\r\n");
            list.Items.Add("public const int _曲线1=1;\r\n");
            list.Items.Add("public const int _曲线2=2;\r\n");
            list.Items.Add("public const int _曲线3=3;\r\n");
            list.Items.Add("public const int _曲线4=4;\r\n");
            list.Items.Add("public const int _曲线5=5;\r\n");
            list.Items.Add("public const int _曲线6=6;\r\n");
            list.Items.Add("public const int _曲线7=7;\r\n");
            list.Items.Add("public const int _曲线8=8;\r\n");
            list.Items.Add("public const int _左轴=0;\r\n");
            list.Items.Add("public const int _右轴=1;\r\n");
            list.Items.Add("public const int _底轴=2;\r\n");

            list.Items.Add("public const bool _不画特征点=false;\r\n");
            list.Items.Add("public const bool _画特征点=true;\r\n");





            list.Items.Add("public double abs(double v)" + "\r\n");
            list.Items.Add("{ return Math.Abs(v);}" + "\r\n");
            list.Items.Add("public double sin(double v) {return Math.Sin(v);}" + "\r\n");
            list.Items.Add("public double cos(double v) {return Math.Cos(v);}" + "\r\n");
            list.Items.Add("public double ceiling(double v) {return Math.Ceiling(v);}" + "\r\n");
            list.Items.Add("public double exp(double v) {return Math.Exp(v);}" + "\r\n");
            list.Items.Add("public double power(double x,double y) {return  Math.Pow(x,y);}" + "\r\n");
            list.Items.Add("public double sqrt(double v) {return  Math.Sqrt(v);}" + "\r\n");
            list.Items.Add("public int round(double v) {return Convert.ToInt32(v);}" + "\r\n");


            list.Items.Add("public double revision(double v,int l){return Math.Round(v,l);}" + "\r\n");



            list.Items.Add("public double _maxpeak(int starti,int endi,double[] v)" + "\r\n" + "{ return  CComLibrary.GlobeVal._funmax(starti,endi,v); }" + "\r\n");

            for (int j = 0; j < CComLibrary.GlobeVal.mfunc.Count; j++)
            {
                list.Items.Add(CComLibrary.GlobeVal.mfunc[j].ListString);
            }

            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                list.Items.Add("public double _结果=0;" + "\r\n");
            }
            else
            {
                list.Items.Add("public double _Result=0;" + "\r\n");
            }
            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                list.Items.Add("public int _数组长度=0;" + "\r\n");
            }
            else
            {
                list.Items.Add("public int _Length_of_array=0;" + "\r\n");
            }

            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                list.Items.Add("public int _索引=0;" + "\r\n");
            }
            else
            {
                list.Items.Add("public int _Index=0;" + "\r\n");
            }

            list.Items.Add("public int _debug1=-1;" + "\r\n");


            list.Items.Add("//var array begin" + "\r\n");


            list.Items.Add("//var array end" + "\r\n");


            list.Items.Add("//ResultHard begin" + "\r\n");
            list.Items.Add("//ResultHard end" + "\r\n");

            list.Items.Add("// userdefined array begin" + "\r\n");
            list.Items.Add("// userdefined array end" + "\r\n");


            list.Items.Add("//var begin" + "\r\n");

            list.Items.Add("//var end" + "\r\n");



            list.Items.Add("public myclass()" + "\r\n");
            list.Items.Add("{" + "\r\n");
            list.Items.Add("//array new begin" + "\r\n");
            list.Items.Add("//array new end" + "\r\n");
            list.Items.Add("//userdefined new begin" + "\r\n");
            list.Items.Add("//userdefined new end" + "\r\n");

            list.Items.Add("}" + "\r\n");

            list.Items.Add("public override double[] eval_hardchannel(int count)\r\n");
            list.Items.Add("{\r\n");


            list.Items.Add("//hardvar begin" + "\r\n");
            list.Items.Add("//hardvar end" + "\r\n");



            list.Items.Add("//harddebug begin" + "\r\n");
            list.Items.Add("//harddebug end" + "\r\n");

            list.Items.Add("try {\r\n");

            for (i = 1; i <= 100; i++)
            {
                list.Items.Add("//hardcalc begin" + i.ToString().Trim() + "\r\n");
                list.Items.Add("//hardcalc end" + i.ToString().Trim() + "\r\n");
            }


            list.Items.Add("}" + "\r\n");
            list.Items.Add("catch (Exception e) {if (e is IndexOutOfRangeException) { MessageBox.Show(e.Message); }if (e is DivideByZeroException){MessageBox.Show(e.Message); }}\r\n");

            list.Items.Add("return  CalcedChannelResult ;" + "\r\n");


            list.Items.Add("}\r\n");

            list.Items.Add("public override void calcchannel(double[] v, string s)\r\n");
            list.Items.Add("{\r\n");

            list.Items.Add("}\r\n");

            list.Items.Add("public override void doit()" + "\r\n");
            list.Items.Add("{\r\n");
            list.Items.Add("//doit begin" + "\r\n");





            list.Items.Add("//doit end" + "\r\n");
            list.Items.Add("}\r\n");




            list.Items.Add("public override double[] eval_calcedchannel(int count)" + "\r\n");

            list.Items.Add("{" + "\r\n");

            list.Items.Add("//result begin" + "\r\n");
            list.Items.Add("//result end" + "\r\n");


            list.Items.Add("//debug begin" + "\r\n");
            list.Items.Add("//debug end" + "\r\n");


            list.Items.Add("//globe begin" + "\r\n");
            list.Items.Add("//globe end" + "\r\n");




            list.Items.Add("try {\r\n");

            for (i = 1; i <= 100; i++)
            {
                list.Items.Add("//calc begin" + i.ToString().Trim() + "\r\n");
                list.Items.Add("//calc end" + i.ToString().Trim() + "\r\n");
            }


            list.Items.Add("}" + "\r\n");
            list.Items.Add("catch (Exception e) {if (e is IndexOutOfRangeException) { MessageBox.Show(e.Message); }if (e is DivideByZeroException){MessageBox.Show(e.Message); }}\r\n");

            list.Items.Add("return  CalcedChannelResult ;" + "\r\n");

            list.Items.Add("}\r\n");

            list.Items.Add("}" + "\r\n");




        }

        public void RefreshDebug通道(string s)
        {
            int istart;
            int iend;
            int i;

            istart = list.FindString("//harddebug begin" + "\r\n");
            iend = list.FindString("//harddebug end" + "\r\n");


            for (i = istart + 1; i <= iend - 1; i++)
            {
                list.Items.RemoveAt(istart + 1);

            }
            i = istart + 1;
            list.Items.Insert(i, s + "\r\n");

        }


        public void RefreshDebug(string s)
        {
            int istart;
            int iend;
            int i;

            istart = list.FindString("//debug begin" + "\r\n");
            iend = list.FindString("//debug end" + "\r\n");


            for (i = istart + 1; i <= iend - 1; i++)
            {
                list.Items.RemoveAt(istart + 1);

            }
            i = istart + 1;
            list.Items.Insert(i, s + "\r\n");

        }

        public void RefreshResultHard(string s)
        {
            int istart;
            int iend;
            int i;

            istart = list.FindString("//ResultHard begin" + "\r\n");
            iend = list.FindString("//ResultHard end" + "\r\n");


            for (i = istart + 1; i <= iend - 1; i++)
            {
                list.Items.RemoveAt(istart + 1);

            }
            i = istart + 1;
            list.Items.Insert(i, s + "\r\n");
        }
        public void RefreshResult(string s)
        {
            int istart;
            int iend;
            int i;

            istart = list.FindString("//result begin" + "\r\n");
            iend = list.FindString("//result end" + "\r\n");


            for (i = istart + 1; i <= iend - 1; i++)
            {
                list.Items.RemoveAt(istart + 1);

            }
            i = istart + 1;
            list.Items.Insert(i, s + "\r\n");
        }

        public void RefreshHardGlobe(string s)
        {
            int istart;
            int iend;
            int i;

            istart = list.FindString("//hardvar begin" + "\r\n");
            iend = list.FindString("//hardvar end" + "\r\n");


            for (i = istart + 1; i <= iend - 1; i++)
            {
                list.Items.RemoveAt(istart + 1);

            }
            i = istart + 1;
            list.Items.Insert(i, s + "\r\n");


        }
        public void RefreshGlobe(string s)
        {
            int istart;
            int iend;
            int i;

            istart = list.FindString("//var begin" + "\r\n");
            iend = list.FindString("//var end" + "\r\n");


            for (i = istart + 1; i <= iend - 1; i++)
            {
                list.Items.RemoveAt(istart + 1);

            }
            i = istart + 1;
            list.Items.Insert(i, s + "\r\n");


        }



        public void RefreshVar(string var)
        {
            int istart;
            int iend;
            int i;

            istart = list.FindString("//var begin" + "\r\n");
            iend = list.FindString("//var end" + "\r\n");



            for (i = istart + 1; i <= iend - 1; i++)
            {
                list.Items.RemoveAt(istart + 1);

            }
            i = istart + 1;
            list.Items.Insert(i, var + "\r\n");

        }

        public void InitHardChannel(string expr, int count)
        {
            string s1;



            int istart;
            int iend;
            int i;



            this.msource = expr;
            s1 = expr;



            istart = list.FindString("//hardcalc begin" + count.ToString().Trim() + "\r\n");
            iend = list.FindString("//hardcalc end" + count.ToString().Trim() + "\r\n");

            for (i = istart + 1; i <= iend - 1; i++)
            {
                list.Items.RemoveAt(istart + 1);
            }
            i = istart + 1;
            list.Items.Insert(i, s1 + "\r\n");
        }

        public void InitChannel(string expr, int count)
        {
            string s1;



            int istart;
            int iend;
            int i;



            this.msource = expr;
            s1 = expr;



            istart = list.FindString("//calcchannel begin" + count.ToString().Trim() + "\r\n");
            iend = list.FindString("//calcchannel end" + count.ToString().Trim() + "\r\n");

            for (i = istart + 1; i <= iend - 1; i++)
            {
                list.Items.RemoveAt(istart + 1);
            }
            i = istart + 1;
            list.Items.Insert(i, s1 + "\r\n");
        }

        public void InitExpr通道(string expr, int count)
        {
            string s1;



            int istart;
            int iend;
            int i;
            this.RefreshDebug通道("_debug1=" + "count" + ";\r\n");

            this.msource = expr;

            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                s1 = "if (_debug1==" + count.ToString().Trim() + ")\r\n" + "{\r\n" + expr + "\r\n" +
                   "if (System.Double.IsNaN(_结果)==true){_结果=0;}\r\n" +
                    "CalcedChannelResult[" + count.ToString().Trim() + "]=_结果;" + "\r\n}";
            }
            else
            {
                s1 = "if (_debug1==" + count.ToString().Trim() + ")\r\n" + "{\r\n" + expr + "\r\n" +
                   "if (System.Double.IsNaN(_Result)==true){_Result=0;}\r\n" +
                    "CalcedChannelResult[" + count.ToString().Trim() + "]=_Result;" + "\r\n}";
            }

            istart = list.FindString("//hardcalc begin" + count.ToString().Trim() + "\r\n");
            iend = list.FindString("//hardcalc end" + count.ToString().Trim() + "\r\n");

            for (i = istart + 1; i <= iend - 1; i++)
            {
                list.Items.RemoveAt(istart + 1);
            }
            i = istart + 1;
            list.Items.Insert(i, s1 + "\r\n");

        }

        public void InitExpr(string expr, int count)
        {
            string s1;



            int istart;
            int iend;
            int i;
            this.RefreshDebug("_debug1=" + "count" + ";\r\n");

            this.msource = expr;

            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                s1 = "if (_debug1==" + count.ToString().Trim() + ")\r\n" + "{\r\n" + expr + "\r\n" +
                   "if (System.Double.IsNaN(_结果)==true){_结果=0; _有效=false; }\r\n" +
                     "else { _有效=true;  }\r\n" +
                    "  CalcedChannelResult[" + count.ToString().Trim() + "]=_结果;" + "m_Global.mvalid=_有效;" + "\r\n}";

            }
            else
            {
                s1 = "if (_debug1==" + count.ToString().Trim() + ")\r\n" + "{\r\n" + expr + "\r\n" +
                   "if (System.Double.IsNaN(_Result)==true){_Result=0; _有效=false; }\r\n" +
                     "else { _有效=true;  }\r\n" +
                    "  CalcedChannelResult[" + count.ToString().Trim() + "]=_Result;" + "m_Global.mvalid=_有效;" + "\r\n}";

            }
            istart = list.FindString("//calc begin" + count.ToString().Trim() + "\r\n");
            iend = list.FindString("//calc end" + count.ToString().Trim() + "\r\n");

            for (i = istart + 1; i <= iend - 1; i++)
            {
                list.Items.RemoveAt(istart + 1);
            }
            i = istart + 1;
            list.Items.Insert(i, s1 + "\r\n");

        }

        public bool InitCalcedChannelExpressiton通道()
        {
            char[] sp;

            string src;
            int i;
            int j = 0;

            string[] m;

            sp = new char[3];
            src = "";
            for (i = 0; i < list.Items.Count; i++)
            {
                src = src + list.Items[i];


            }

            stringlength = src.Length;


            sp[0] = Convert.ToChar("\r");
            sp[1] = Convert.ToChar("\n");


            /*

            if (GlobeVal.m_richtextbox == null)
            {
                GlobeVal.m_richtextbox = new Compenkie.RichTextBoxExtend();
            }
           
                GlobeVal.m_richtextbox.Text = src;

                  GlobeVal.m_richtextbox.SaveFile("m:\\a.rtf");
            
            */

            cr = ic.CompileAssemblyFromSource(cpar, src);
            GlobeVal.errorline = 0;


            if (cr.Errors.Count > 0)


            {

                MessageBox.Show(cr.Errors[0].ToString());


            }

            if (cr.Errors.Count == 0 && cr.CompiledAssembly != null)
            {
                Type ObjType = cr.CompiledAssembly.GetType("myclass");
                try
                {
                    if (ObjType != null)
                    {
                        myobj = (MyClassBase)Activator.CreateInstance(ObjType);
                    }
                }
                catch (Exception ex)
                {

                }
                return true;
            }
            else
                return false;

        }
        public bool InitCalcedChannelExpressiton()
        {



            char[] sp;

            string src;
            int i;
            int j = 0;

            string[] m;

            sp = new char[3];
            src = "";
            for (i = 0; i < list.Items.Count; i++)
            {
                src = src + list.Items[i];
            }

            stringlength = src.Length;


            sp[0] = Convert.ToChar("\r");
            sp[1] = Convert.ToChar("\n");


            m = msource.Split(sp);


            text.Text = src;

            if (GlobeVal.m_richtextbox == null)
            {
            }
            else
            {
                GlobeVal.m_richtextbox.Text = src;
                //记住删除

              //  GlobeVal.m_richtextbox.SaveFile("d:\\a.rtf");
            }

            //return false;

            cr = ic.CompileAssemblyFromSource(cpar, src);
            GlobeVal.errorline = 0;


            if (CComLibrary.GlobeVal.m_test == false)
            {
                if (CComLibrary.GlobeVal.m_outputwindow == null)
                {
                }
                else
                {
                    CComLibrary.GlobeVal.m_outputwindow.Clear();
                }
            }
            else
            {
                if (CComLibrary.GlobeVal.m_calc_outputwindow == null)
                {
                }
                else
                {
                    CComLibrary.GlobeVal.m_calc_outputwindow.Clear();
                }
            }

            if (cr.Errors.Count > 0)

            //foreach (System.CodeDom.Compiler.CompilerError ce in cr.Errors)
            {
                //errorMessages.Add(ce.ErrorText);


                System.CodeDom.Compiler.CompilerError ce = cr.Errors[0];
                if (ce.Line >= 1)
                {


                    if (msource.Contains(text.Lines[ce.Line - 1]) == true)
                    {
                        for (i = 0; i < m.Length; i++)
                        {
                            if (m[i] == text.Lines[ce.Line - 1])
                            {
                                j = i;
                            }
                        }

                        GlobeVal.errorline = j;

                        if (CComLibrary.GlobeVal.m_test == false)
                        {
                            if (CComLibrary.GlobeVal.m_outputwindow == null)
                            {
                            }
                            else
                            {
                                CComLibrary.GlobeVal.m_outputwindow.Text = CComLibrary.GlobeVal.m_outputwindow.Text +
                                 "第" + j.ToString() + "行," + "第" + ce.Column.ToString() + "列," + text.Lines[ce.Line - 1] + ce.ErrorText + "\r\n";
                            }
                        }
                        else
                        {
                            if (CComLibrary.GlobeVal.m_calc_outputwindow == null)
                            {
                            }
                            else
                            {
                                CComLibrary.GlobeVal.m_calc_outputwindow.Text = CComLibrary.GlobeVal.m_calc_outputwindow.Text +
                                    "第" + j.ToString() + "行," + "第" + ce.Column.ToString() + "列," + text.Lines[ce.Line - 1] + ce.ErrorText + "\r\n";
                            }
                        }
                    }
                    else
                    {
                        if (CComLibrary.GlobeVal.m_test == false)
                        {
                            if (CComLibrary.GlobeVal.m_outputwindow == null)
                            {
                            }
                            else
                            {

                                CComLibrary.GlobeVal.m_outputwindow.Text = CComLibrary.GlobeVal.m_outputwindow.Text +
                             "内部函数错误:" + "第" + j.ToString() + "行," + "第" + ce.Column.ToString() + "列," + text.Lines[ce.Line - 1] + ce.ErrorText + "\r\n";
                            }


                        }
                        else
                        {
                            if (CComLibrary.GlobeVal.m_calc_outputwindow == null)
                            {
                            }
                            else
                            {
                                CComLibrary.GlobeVal.m_calc_outputwindow.Text = CComLibrary.GlobeVal.m_calc_outputwindow.Text +
                                "内部函数错误:" + "第" + j.ToString() + "行," + "第" + ce.Column.ToString() + "列," + text.Lines[ce.Line - 1] + ce.ErrorText + "\r\n";
                            }
                        }
                    }


                    // MessageBox.Show(ce.ErrorNumber.ToString()); 
                }
                else
                {
                    if (CComLibrary.GlobeVal.m_test == false)
                    {
                        if (CComLibrary.GlobeVal.m_outputwindow == null)
                        {
                        }
                        else
                        {

                            CComLibrary.GlobeVal.m_outputwindow.Text = CComLibrary.GlobeVal.m_outputwindow.Text +

                             ce.ErrorNumber.ToString() + "\r\n";
                        }
                    }
                    else
                    {
                        if (CComLibrary.GlobeVal.m_calc_outputwindow == null)
                        {
                        }
                        else
                        {
                            CComLibrary.GlobeVal.m_calc_outputwindow.Text = CComLibrary.GlobeVal.m_calc_outputwindow.Text +

                            ce.ErrorNumber.ToString() + "\r\n";
                        }
                    }
                }


            }

            if (cr.Errors.Count == 0 && cr.CompiledAssembly != null)
            {
                Type ObjType = cr.CompiledAssembly.GetType("myclass");
                try
                {
                    if (ObjType != null)
                    {
                        myobj = (MyClassBase)Activator.CreateInstance(ObjType);
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
                return true;
            }
            else
                return false;
        }

        public double eval(double x, double y)
        {
            double val = 0.0;
            if (myobj != null)
            {
                val = myobj.eval(x, y);
            }
            return val;
        }
        public void doit()
        {
            if (myobj != null)
            {
                myobj.doit();
            }
        }
        public void calc()
        {

            try
            {
                myobj.eval_calcedchannel(0);
            }
            catch (Exception ex)
            {

            }
        }

        public double eval_hardchannel(int count)
        {
            double val;

            val = 0;
            if (myobj != null)
            {


                myobj.CalcedChannelResult = myobj.eval_hardchannel(count);
                val = myobj.CalcedChannelResult[count];
            }
            return val;
        }
        public double eval_calcedchannel(int count)
        {
            double val;

            val = 0;
            if (myobj != null)
            {
                myobj.CalcedChannelResult = myobj.eval_calcedchannel(count);

                val = myobj.CalcedChannelResult[count];
                for (int i = 0; i < 100; i++)
                {
                    ClsStaticStation.m_Global.mresult[i] = myobj.CalcedChannelResult[i];
                }
            }
            return val;
        }
    }




    public class GlobeVal
    {
        public static ManageLanguage mylanguage = new ManageLanguage();
        private static int mlanguageselect = 0;
        public static int languageselect
        {
            get
            {
                return mlanguageselect;
            }
            set
            {
                mlanguageselect = value;



            }
        }
        public struct Point
        {
            public double X;
            public double Y;
            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }
        }

        public static int formulakind = 0;
        public static bool m_test = false;

        public static RichTextBox m_outputwindow;
        public static Compenkie.RichTextBoxExtend m_richtextbox;
        public static RichTextBox m_calc_outputwindow;

        public static double[][] m_data;
        public static double[][] m_calcdata;

        public static double[] m_channeldata;
        public static int m_i = 0;

        public static string mptprocedurepath;

        public static string _试验方法;
        public static string _文件类型;
        public static int m_len;
        public static string _programname;
        public static string _programstring;
        public static bool continuetest = false;
        public static CComLibrary.FileStruct filesave;
        public static string currentfilesavename;
        public static List<CComLibrary.Rule> mrule = new List<CComLibrary.Rule>();
        public static List<CComLibrary.SystemPara> msyspara = new List<SystemPara>();
        public static List<CComLibrary.Rule> mfunc = new List<Rule>();
        public static List<CComLibrary.Rule> mconst = new List<Rule>();

        //public static CComLibrary.MathExpressionParser gparser = new CComLibrary.MathExpressionParser();

        public static string[] g_datatitle;
        public static string[] g_dataunit;
        //public   System.Array   g_data;
        public static System.Array l_Array;
        public static int g_datalen = 0;
        public static int g_colcount = 0;
        public static double[][] g_datadraw;

        public static int xsel;
        public static int ysel;

        public static int[] ysels;
        public static int[] yselpostion;

        public static int yselcount = 0;

        public static SampleProject.Extensions.GridArray[] outgrid;



        private static void Init_SystemPara通道()
        {

            CComLibrary.SystemPara b;
            string s;
            int i;
            int j;
            CComLibrary.GlobeVal.msyspara.Clear();

            s = "";


            s = s + "\r\n";


            for (j = 0; j < CComLibrary.GlobeVal.filesave.m_namelist.Count; j++)
            {
                b = new CComLibrary.SystemPara();

                string r = CComLibrary.GlobeVal.filesave.m_namelist[j];
                r = r.Replace(" ", "_");

                b.Name = r + "通道";

                b.replaceName = b.Name;
                if (CComLibrary.GlobeVal.filesave.m_signnamelist[j] == "Ch Load")
                {
                    s = s + "public double " + b.replaceName + "=" + "ClsStaticStation.m_Global.mload" + ";" + "\r\n";
                }


                else if (CComLibrary.GlobeVal.filesave.m_signnamelist[j] == "Ch Disp")
                {
                    s = s + "public double " + b.replaceName + "=" + "ClsStaticStation.m_Global.mpos" + ";" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_signnamelist[j] == "Ch Ext")
                {
                    s = s + "public double " + b.replaceName + "=" + "ClsStaticStation.m_Global.mext" + ";" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_signnamelist[j] == "Ch Sensor4")
                {
                    s = s + "public double " + b.replaceName + "=" + "ClsStaticStation.m_Global.msensor4" + ";" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_signnamelist[j] == "Ch Sensor5")
                {
                    s = s + "public double " + b.replaceName + "=" + "ClsStaticStation.m_Global.msensor5" + ";" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_signnamelist[j] == "Ch Sensor6")
                {
                    s = s + "public double " + b.replaceName + "=" + "ClsStaticStation.m_Global.msensor6" + ";" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_signnamelist[j] == "Ch Sensor7")
                {
                    s = s + "public double " + b.replaceName + "=" + "ClsStaticStation.m_Global.msensor7" + ";" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_signnamelist[j] == "Ch Sensor8")
                {
                    s = s + "public double " + b.replaceName + "=" + "ClsStaticStation.m_Global.msensor8" + ";" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_signnamelist[j] == "Ch Time")
                {
                    s = s + "public double " + b.replaceName + "=0;" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_signnamelist[j] == "ambient pressure Ch Load")
                {
                    s = s + "public double " + b.replaceName + "=" + "ClsStaticStation.m_Global.mload1" + ";" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_signnamelist[j] == "ambient pressure Ch Disp")
                {
                    s = s + "public double " + b.replaceName + "=" + "ClsStaticStation.m_Global.mpos1" + ";" + "\r\n";
                }

                CComLibrary.GlobeVal.msyspara.Add(b);

            }
            for (j = 0; j < CComLibrary.GlobeVal.filesave.muserchannel.Count; j++)
            {
                b = new CComLibrary.SystemPara();
                b.Name = CComLibrary.GlobeVal.filesave.muserchannel[j].channelname + "通道";

                b.replaceName = b.Name;
                s = s + "public double " + b.replaceName + "=0;" + "\r\n";
                CComLibrary.GlobeVal.msyspara.Add(b);
            }


            for (j = 0; j < CComLibrary.GlobeVal.filesave.mshapelist.Count; j++)
            {
                for (i = 0; i < CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem.Length; i++)
                {
                    if (CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem[i].cName != "None")
                    {
                        b = new CComLibrary.SystemPara();
                        string r = CComLibrary.GlobeVal.filesave.mshapelist[j].shapename + "_" +
                            CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem[i].cName;
                        r = r.Replace(" ", "_");
                        b.Name = r;
                        b.replaceName = b.Name;
                        s = s + "public double " + b.replaceName + "=" +
                            CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem[i].cvalue.ToString() + ";" + "\r\n";
                        CComLibrary.GlobeVal.msyspara.Add(b);
                    }


                }
            }

            for (i = 0; i < CComLibrary.GlobeVal.filesave.minput.Count; i++)
            {
                b = new CComLibrary.SystemPara();
                b.Name = CComLibrary.GlobeVal.filesave.minput[i].name;
                b.replaceName = b.Name;
                s = s + "public  double " + b.replaceName + "=" + CComLibrary.GlobeVal.filesave.minput[i].value.ToString() + ";" + "\r\n";
                CComLibrary.GlobeVal.msyspara.Add(b);
            }


            CComLibrary.GlobeVal.gcalc.refreshglobe(s);


            s = "";
            for (j = 0; j < CComLibrary.GlobeVal.filesave.m_namelist.Count; j++)
            {
                b = new CComLibrary.SystemPara();

                string r = CComLibrary.GlobeVal.filesave.m_namelist[j];

                r = r.Replace(" ", "_");
                b.Name = r + "通道";

                b.replaceName = b.Name;
                if (CComLibrary.GlobeVal.filesave.m_signnamelist[j] == "Ch Load")
                {
                    s = s + b.replaceName + "=" + "ClsStaticStation.m_Global.mload" + ";" + "\r\n";
                }

                else if (CComLibrary.GlobeVal.filesave.m_signnamelist[j] == "Ch Disp")
                {
                    s = s + b.replaceName + "=" + "ClsStaticStation.m_Global.mpos" + ";" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_signnamelist[j] == "Ch Ext")
                {
                    s = s + b.replaceName + "=" + "ClsStaticStation.m_Global.mext" + ";" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_signnamelist[j] == "Ch Sensor4")
                {
                    s = s + b.replaceName + "=" + "ClsStaticStation.m_Global.msensor4" + ";" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_signnamelist[j] == "Ch Sensor5")
                {
                    s = s + b.replaceName + "=" + "ClsStaticStation.m_Global.msensor5" + ";" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_signnamelist[j] == "Ch Sensor6")
                {
                    s = s + b.replaceName + "=" + "ClsStaticStation.m_Global.msensor6" + ";" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_signnamelist[j] == "Ch Sensor7")
                {
                    s = s + b.replaceName + "=" + "ClsStaticStation.m_Global.msensor7" + ";" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_signnamelist[j] == "Ch Sensor8")
                {
                    s = s + b.replaceName + "=" + "ClsStaticStation.m_Global.msensor8" + ";" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_signnamelist[j] == "Ch Time")
                {
                    s = s + b.replaceName + "=0;" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_signnamelist[j] == "ambient pressure Ch Load")
                {
                    s = s + b.replaceName + "=" + "ClsStaticStation.m_Global.mload1" + ";" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_signnamelist[j] == "ambient pressure Ch Pos")
                {
                    s = s + b.replaceName + "=" + "ClsStaticStation.m_Global.mpos1" + ";" + "\r\n";
                }



            }

            CComLibrary.GlobeVal.gcalc.refreshhardglobe(s);

            s = "";
            for (i = 0; i < CComLibrary.GlobeVal.filesave.moutput.Count; i++)
            {
                b = new CComLibrary.SystemPara();
                b.Name = CComLibrary.GlobeVal.filesave.moutput[i].formulaname;
                b.replaceName = "@result" + (i + 1).ToString().Trim();
                s = s + "public  double " + b.replaceName + "= 0" + ";" + "\r\n";
                CComLibrary.GlobeVal.msyspara.Add(b);
            }


            CComLibrary.GlobeVal.gcalc.refreshresulthard(s);


        }
        public static void InitUserCalcChannel() //初始化用户自定义通道
        {
            int j;



            CComLibrary.GlobeVal.gcalc.Initialize_Channel();



            Init_SystemPara通道();


            for (j = 0; j < CComLibrary.GlobeVal.filesave.muserchannel.Count; j++)
            {

                CComLibrary.GlobeVal.gcalc.Initexpr通道(CComLibrary.GlobeVal.filesave.muserchannel[j].channelvalue, j + 1);

            }

            CComLibrary.GlobeVal.gcalc.calc通道();
        }

        public static K8robot gcalc = new K8robot();
        public static double _inputvar(long count)
        {
            double m = 0;

            return m;
        }


        public static int errorline = -1;



        public static void LinearRegression(double[] x, double[] y, out double a, out double b)
        {
            int ii = 0;
            double sum_x = 0;
            double sum_y = 0;
            double sum_xy = 0;
            double sum_x2 = 0;
            a = 0;
            b = 0;

            int dataCnt = x.Length;

            if (dataCnt == 1)
            {
                a = 0;
                b = y[0];
                return;
            }
            /*
            if (dataCnt ==2)
            {
                if (x[0]-x[1]==0)
                        {
                            a = 0;
                            b = y[0];
                        }
                else
                        {
                            a = (y[0] - y[1]) / (x[0] - x[1]);
                            b = 0;
                        }
            }
            */

            for (ii = 0; ii <= dataCnt - 1; ii++)
            {
                //X和
                sum_x += x[ii];
                //Y和
                sum_y += y[ii];
                //X*Y和
                sum_xy += x[ii] * y[ii];
                //X2和
                sum_x2 += x[ii] * x[ii];
            }

            //nΣx2-(Σx)2
            double divisor = dataCnt * sum_x2 - sum_x * sum_x;
            if (Math.Abs(divisor) > 1E-06)
            {
                // a=(nΣxy - ΣxΣy)/[nΣx2-(Σx)2]
                a = (dataCnt * sum_xy - sum_x * sum_y) / divisor;

                // b=(Σx2Σy - ΣxyΣx)/[nΣx2-(Σx)2]
                b = (sum_x2 * sum_y - sum_xy * sum_x) / divisor;

            }

        }
        public static List<LineStruct> m_listline = new List<LineStruct>();

        /// <summary>
        /// 对一组点通过最小二乘法进行线性回归
        /// </summary>
        /// <param name="parray"></param>
        /// 



        public static int _normalyield(double[] x, double[] y, bool mdraw, out int v)
        {

            //为计算屈服点和上下屈服点做准备
            //只在此时,给TempYieldIndex赋值
            double tempk = 0;
            double zdl;
            double zf;
            int Num = 0;
            int Zi;
            double XiShu = 0.5;
            double mslope = 0;
            int mstartindex = 0;
            int mendindex = 0;
            double temp = 0;
            int TempYieldIndex = 0;
            bool Findit = false;

            _module(x, y, 10, 30, false, out mslope, out mstartindex, out mendindex);


            for (Zi = mendindex; Zi < m_len - 3; Zi++)
            {

                zf = y[Zi + 2] - y[Zi];


                zdl = x[Zi + 2] - x[Zi];


                if (zdl != 0)
                {
                    tempk = zf / zdl;
                }




                if (tempk < mslope * XiShu)
                {

                    TempYieldIndex = Zi;
                    Num = Num + 1;

                    if (Num >= 3)
                    {

                        if (zf < 0)
                        {
                            temp = -9999999;
                            for (int i = mendindex; i < Zi; i++)
                            {
                                if (temp < y[i])
                                {
                                    temp = y[i];
                                    TempYieldIndex = i;
                                }
                            }
                            Findit = true;

                            v = TempYieldIndex;



                            break;

                        }
                        else
                        {
                            TempYieldIndex = Zi + 2;
                            Findit = false;

                        }

                        break;


                    }
                }
                else
                {
                    Num = 0;

                }

            }


            v = TempYieldIndex;

            if (mdraw == true)
            {
                LineStruct l = new LineStruct();
                l.kind = 0;
                l.indexstart = TempYieldIndex;
                l.xstart = x[TempYieldIndex];
                l.ystart = y[TempYieldIndex];
                m_listline.Add(l);
            }
            return 0;
        }

        public static int _upperyield(double[] x, double[] y, bool mdraw, out int v)
        {
            //为计算屈服点和上下屈服点做准备
            //只在此时,给TempYieldIndex赋值
            double tempk = 0;
            double zdl;
            double zf;
            int Num = 0;
            int Zi;
            double XiShu = 0.5;
            double mslope = 0;
            int mstartindex = 0;
            int mendindex = 0;
            double temp = 0;
            int TempYieldIndex = 0;
            bool Findit = false;
            int mv = 0;

            _module(x, y, 10, 30, false, out mslope, out mstartindex, out mendindex);


            for (Zi = mendindex; Zi < m_len - 3; Zi++)
            {

                zf = y[Zi + 2] - y[Zi];


                zdl = x[Zi + 2] - x[Zi];


                if (zdl != 0)
                {
                    tempk = zf / zdl;
                }




                if (tempk < mslope * XiShu)
                {

                    TempYieldIndex = Zi;
                    Num = Num + 1;

                    if (Num >= 3)
                    {

                        if (zf < 0)
                        {
                            temp = -9999999;
                            for (int i = mendindex; i < Zi; i++)
                            {
                                if (temp < y[i])
                                {
                                    temp = y[i];
                                    TempYieldIndex = i;
                                }
                            }
                            Findit = true;

                            v = TempYieldIndex;



                            break;

                        }
                        else
                        {
                            TempYieldIndex = Zi + 2;
                            Findit = false;

                        }

                        break;


                    }
                }
                else
                {
                    Num = 0;

                }

            }

            if (Findit == true)
            {
                mv = TempYieldIndex;
            }

            else

            {
                int peak = 0;
                bool peakb = false;
                int[] peakv = new int[1000];

                for (int i = TempYieldIndex; i < m_len - 3; i++)
                {
                    if (((y[i + 2] - y[i]) < 0) && (peakb == false))
                    {
                        peakv[peak] = i;
                        peakb = true;
                        peak = peak + 1;

                    }

                    if ((y[i + 2] - y[i] > 0))
                    {
                        peakb = false;
                    }

                }

                if (peak <= 1)
                {
                    mv = -1;
                }
                if (peak == 2)
                {
                    mv = peakv[0];
                }

                if (peak > 2)
                {
                    mv = peakv[1];
                }
            }

            v = mv;
            if ((mdraw == true) && (mv >= 0))
            {
                LineStruct l = new LineStruct();
                l.kind = 0;
                l.indexstart = mv;
                l.xstart = x[mv];
                l.ystart = y[mv];
                m_listline.Add(l);
            }
            return 0;
        }


        public static int _loweryield(double[] x, double[] y, bool mdraw, out int v)
        {
            //为计算屈服点和上下屈服点做准备
            //只在此时,给TempYieldIndex赋值
            double tempk = 0;
            double zdl;
            double zf;
            int Num = 0;
            int Zi;
            double XiShu = 0.5;
            double mslope = 0;
            int mstartindex = 0;
            int mendindex = 0;
            double temp = 0;
            int TempYieldIndex = 0;
            bool Findit = false;
            int mv = 0;

            _module(x, y, 10, 30, false, out mslope, out mstartindex, out mendindex);


            for (Zi = mendindex; Zi < m_len - 3; Zi++)
            {

                zf = y[Zi + 2] - y[Zi];


                zdl = x[Zi + 2] - x[Zi];


                if (zdl != 0)
                {
                    tempk = zf / zdl;
                }




                if (tempk < mslope * XiShu)
                {

                    TempYieldIndex = Zi;
                    Num = Num + 1;

                    if (Num >= 3)
                    {

                        if (zf < 0)
                        {
                            temp = -9999999;
                            for (int i = mendindex; i < Zi; i++)
                            {
                                if (temp < y[i])
                                {
                                    temp = y[i];
                                    TempYieldIndex = i;
                                }
                            }
                            Findit = true;

                            v = TempYieldIndex;



                            break;

                        }
                        else
                        {
                            TempYieldIndex = Zi + 2;
                            Findit = false;

                        }

                        break;


                    }
                }
                else
                {
                    Num = 0;

                }

            }


            int peak = 0;
            bool peakb = false;
            int[] peakv = new int[1000];

            for (int i = TempYieldIndex; i < m_len - 3; i++)
            {
                if (((y[i + 2] - y[i]) < 0) && (peakb == false))
                {
                    peakv[peak] = i;
                    peakb = true;
                    peak = peak + 1;

                }

                if ((y[i + 2] - y[i] > 0))
                {
                    peakb = false;
                }

            }

            if (peak <= 1)
            {
                mv = -1;
            }
            if (peak == 2)
            {
                double mt = y[peakv[0]];
                for (int i = peakv[0]; i < peakv[1]; i++)
                {
                    if (mt > y[i])
                    {
                        mt = y[i];
                        mv = i;
                    }
                }
            }

            if (peak > 2)
            {
                double mt = y[peakv[1]];
                for (int i = peakv[1]; i < peakv[peak - 1]; i++)
                {
                    if (mt > y[i])
                    {
                        mt = y[i];
                        mv = i;
                    }
                }
            }


            v = mv;
            if ((mdraw == true) && (mv >= 0))
            {
                LineStruct l = new LineStruct();
                l.kind = 0;
                l.indexstart = mv;
                l.xstart = x[mv];
                l.ystart = y[mv];
                m_listline.Add(l);
            }
            return 0;
        }

        //拟合求斜率
        public static double _fit(double[] x, double[] y, out double slope)
        {
            double t = 0;
            double t1 = 0;
            int l = y.Length;


            //LinearRegression(array,out t);
            if (x.Length > 2)
            {
                // CurveFit.LinearFit(x, y, FitMethod.LeastSquare, out t, out t1, out t1);
                LinearRegression(x, y, out t, out t1);
            }
            slope = t;

            return 0;
        }

        public static void _曲线标题(string s)
        {
            CComLibrary.GlobeVal.mscattergraph.Caption = s;
        }
        //
        public static void _坐标轴标题(int c, string s)
        {
            if (c == 0)
            {
                CComLibrary.GlobeVal.mscattergraph.YAxes[0].Caption = s;
            }
            if (c == 1)
            {
                CComLibrary.GlobeVal.mscattergraph.YAxes[1].Caption = s;
            }
            if (c == 2)
            {
                CComLibrary.GlobeVal.mscattergraph.XAxes[0].Caption = s;
            }
        }

        public static void _MessageBox(string s)
        {
            MessageBox.Show(s);
        }

        public static void _DebugOut(string s)
        {
            if (CComLibrary.GlobeVal.m_test == true)
            {
                CComLibrary.GlobeVal.m_calc_outputwindow.Text =
                    CComLibrary.GlobeVal.m_calc_outputwindow.Text + s + "\r\n";
            }
            else
            {
                CComLibrary.GlobeVal.m_outputwindow.Text =
                    CComLibrary.GlobeVal.m_outputwindow.Text + s + "\r\n";
            }

        }

        public static void _CloseCurve(int c)
        {
            double x;
            double y;
            CComLibrary.GlobeVal.mscattergraph.Plots[c - 1].GetDataPoint(0, out x, out y);
            CComLibrary.GlobeVal.mscattergraph.Plots[c - 1].PlotXYAppend(x, y);
        }
        public static void _ClearLine(int c)
        {
            CComLibrary.GlobeVal.mscattergraph.Plots[c - 1].ClearData();


        }

        public static void _SetYAxis(int c, int t)
        {
            if (t == 0)
            {
                CComLibrary.GlobeVal.mscattergraph.Plots[c - 1].YAxis =

                    CComLibrary.GlobeVal.mscattergraph.YAxes[0];
            }
            else
            {
                CComLibrary.GlobeVal.mscattergraph.Plots[c - 1].YAxis =

                    CComLibrary.GlobeVal.mscattergraph.YAxes[1];
            }


        }

        //插值函数

        static double Lagrange(double[] x, double[] y, int n, double t)
        {
            double z = 0.0;
            int k, m, i;
            if (n < 1) return z;
            if (n == 1) return z = y[0];
            //线性插值
            if (n == 2)
            {
                z = y[0] * (t - x[1]) / (x[0] - x[1]) + y[1] * (t - x[0]) / (x[1] - x[0]);
                return z;
            }
            if (t <= x[1] && t > x[0]) { k = 0; m = 2; }        //取最前的三个节点
            else if (t < x[n - 1] && t >= x[n - 2]) { k = n - 3; m = n - 1; }   //取最后的三个节点
            else               //寻找重点三个节点
            {
                k = 0; m = n - 1;
                while (m - k != 1)
                {
                    i = (k + m) / 2;
                    if (t < x[i]) m = i;
                    else
                        k = i;

                }
                Console.WriteLine("k={0},m={1}", k, m);
                k = k - 1; m = m + 1;
                if (Math.Abs(t - x[k]) < Math.Abs(t - x[m])) m = m - 1;
                else k = k + 1;
                Console.WriteLine("k={0},m={1}", k, m);
            }
            //进行三点二次插值
            for (int p = k; p <= m; p++)
            {
                double s = 1.0;
                for (int j = k; j <= m; j++)
                    if (j != p) s *= (t - x[j]) / (x[p] - x[j]);
                z += s * y[p];
            }
            return z;

        }
        public static double _Interpolant(double x1, double y1, double x2, double y2, double x)
        {

            double[] xData = new double[2];
            double[] yData = new double[2];
            double[] secondDerivatives;
            double initialBoundary, finalBoundary, xValue, interpValue = 0;


            xData[0] = x1;
            xData[1] = x2;
            yData[0] = y1;
            yData[1] = y2;



            initialBoundary = 1.00E+30;


            finalBoundary = 1.00E+30;

            xValue = x;

            // Calculate secondDerivatives

            if (xData.Length > 2)
            {
                // secondDerivatives = CurveFit.SplineInterpolant(xData, yData, initialBoundary, finalBoundary);


                // Calculate spline interpolated value  
                // interpValue = CurveFit.SplineInterpolation(xData, yData, secondDerivatives, xValue);
            }

            interpValue = Lagrange(xData, yData, 2, x);

            return interpValue;
        }
        public static bool _presetcalc(double[] setx, double[] calcy, double setvalue, out double calcvalue, bool draw)
        {
            int i;
            int mindex;
            bool b;
            double x1 = 0, x2 = 0, y1 = 0, y2 = 0;

            b = false;
            calcvalue = 0;
            for (i = 1; i < m_len - 2; i++)
            {
                if (setx[i] >= setvalue)
                {
                    mindex = i;
                    calcvalue = calcy[i];
                    x1 = setx[i - 1];
                    x2 = setx[i + 1];
                    y1 = calcy[i - 1];
                    y2 = calcy[i + 1];
                    calcvalue = _Interpolant(x1, y1, x2, y2, setvalue);

                    b = true;

                    if (draw == true)
                    {
                        LineStruct l = new LineStruct();
                        l.kind = 0;
                        l.indexstart = mindex;
                        m_listline.Add(l);
                    }

                    break;




                }
            }




            return b;
        }

        public static bool _chordmodulus(double[] x, double[] y, double startx, double endx, out double value, out int starti, out int endi)
        {
            int i;
            double starty = 0;
            double endy = 0;

            int mstarti = 0;
            int mendi = 0;

            for (i = 0; i < m_len; i++)
            {
                if (x[i] >= startx)
                {
                    starty = y[i];
                    mstarti = i;
                    break;
                }
            }
            for (i = 0; i < m_len; i++)
            {
                if (x[i] >= endx)
                {
                    endy = y[i];
                    mendi = i;
                    break;
                }
            }

            starti = mstarti;
            endi = mendi;
            value = (starty - endy) / (startx - endx);
            return false;
        }


        public static bool _sizeinput(out double item1, out double item2, out double item3)
        {
            item1 = 0;
            item2 = 0;
            item3 = 0;

            if (GlobeVal.filesave.mshapelist.Count > 0)
            {

                for (int i = 0; i <
                      GlobeVal.filesave.mshapelist[GlobeVal.filesave.shapeselect].sizeitem.Length; i++)
                {
                    if (GlobeVal.filesave.mshapelist[GlobeVal.filesave.shapeselect].sizeitem[i].cName != "None")
                    {
                        FormSpeInput f = new AppleLabApplication.FormSpeInput();
                        f.lblcaption.Text = GlobeVal.filesave.mshapelist[GlobeVal.filesave.shapeselect].sizeitem[i].cName;
                        f.ShowDialog();

                        if (i == 0)
                        {
                            item1 = f.txtvalue.Value;
                        }
                        if (i == 1)
                        {
                            item2 = f.txtvalue.Value;
                        }
                        if (i == 2)
                        {
                            item3 = f.txtvalue.Value;
                        }

                    }

                }
            }

            return false;
        }

        public static bool _autoYoungModulus(double[] x, double[] y, bool mdraw, out double value, out int starti, out int endi)
        {
            double yieldvalue;
            int yieldindex;
            bool b;
            double xa = 0;
            double xb = 0;
            int i;
            int k;

            double[] inputx;
            double[] inputy;

            double[] mx;
            int[] mxi;

            double mslope;
            double mintercept;
            double mresidue;

            double[] mslopev;
            double[] minterceptv;

            mx = new double[8];
            mxi = new int[8];
            mslopev = new double[7];
            minterceptv = new double[7];

            b = _yield(x, y, 0.1, false, out yieldvalue, out yieldindex);

            mxi[0] = 0;
            for (i = 1; i <= 7; i++)
            {
                mx[i] = y[0];
                for (k = 0; k <= yieldindex; k++)
                {
                    if (y[k] >= y[yieldindex] / 7.0 * i)
                    {
                        mxi[i] = k;
                        break;
                    }
                }
            }
            mxi[7] = yieldindex;
            for (i = 1; i <= 7; i++)
            {
                inputx = new double[mxi[i] - mxi[i - 1]];
                inputy = new double[mxi[i] - mxi[i - 1]];

                for (k = mxi[i - 1]; k < mxi[i]; k++)
                {

                    inputx[k - mxi[i - 1]] = x[k];
                    inputy[k - mxi[i - 1]] = y[k];





                }

                // CurveFit.LinearFit(inputx, inputy, FitMethod.LeastSquare, out mslope, out mintercept, out mresidue);
                LinearRegression(inputx, inputy, out mslope, out mintercept);

                mslopev[i - 1] = mslope;
                minterceptv[i - 1] = mintercept;

                CComLibrary.GlobeVal.m_outputwindow.Text = CComLibrary.GlobeVal.m_outputwindow.Text + "Young Modules " + mslope.ToString() + " " + mintercept.ToString() + "\r\n";

            }


            value = mslopev.Average();

            starti = 0;
            endi = 0;

            xa = mslopev.Average();
            xb = minterceptv.Average();

            if (mdraw == true)
            {
                //  LineStruct l = new LineStruct();
                // l.kind = 1;
                // l.ystart = y[yieldindex] * 0.1;
                // l.xstart = (l.ystart - xb) / xa;

                // l.yend = y[yieldindex] * 0.9;
                // l.ystart = (l.yend - xb) / xa;

                // m_listline.Add(l);

                LineStruct l = new LineStruct();
                l.kind = 1;
                l.xstart = x[yieldindex] * 0.1;
                l.ystart = xa * l.xstart + xb;

                l.xend = x[yieldindex] * 0.9;
                l.yend = xa * l.xend + xb;

                m_listline.Add(l);


            }
            return b;

        }

        public static double[] LinearResult(double[] arrayX, double[] arrayY)
        {
            double[] result = { 0, 0 };

            if (arrayX.Length == arrayY.Length)
            {
                double averX = arrayX.Average();
                double averY = arrayY.Average();
                result[0] = Scale(averX, averY, arrayX, arrayY);
                result[1] = Offset(result[0], averX, averY);
            }

            return result;
        }

        private static double Scale(double averX, double averY, double[] arrayX, double[] arrayY)
        {
            double scale = 0;
            if (arrayX.Length == arrayY.Length)
            {
                double Molecular = 0;
                double Denominator = 0;
                for (int i = 0; i < arrayX.Length; i++)
                {
                    Molecular += (arrayX[i] - averX) * (arrayY[i] - averY);
                    Denominator += Math.Pow((arrayX[i] - averX), 2);
                }
                scale = Molecular / Denominator;
            }

            return scale;
        }

        public static void _clearxy()
        {
            int i;
            for (i = 0; i < GlobeVal.mscattergraph.Plots.Count; i++)
            {
                GlobeVal.mscattergraph.Plots[i].ClearData();
            }

            return;
        }


        public static void _plotxypoint(double x, double y, int c)
        {
            if (CComLibrary.GlobeVal.m_test == false)
            {
                if ((c >= 1) && (c <= GlobeVal.mscattergraph.Plots.Count))
                {

                }
                else
                {
                    MessageBox.Show("曲线号错误");
                }



                GlobeVal.mscattergraph.Plots[c - 1].PlotXYAppend(x, y);

            }
        }

        public static void _plotxy(double[] x, double[] y, int c)
        {

            if (CComLibrary.GlobeVal.m_test == false)
            {
                if ((c >= 1) && (c <= GlobeVal.mscattergraph.Plots.Count))
                {

                }
                else
                {
                    MessageBox.Show("曲线号错误");
                }



                GlobeVal.mscattergraph.Plots[c - 1].ClearData();

                GlobeVal.mscattergraph.Plots[c - 1].PlotXY(x, y);
            }
        }


        public static NationalInstruments.UI.WindowsForms.ScatterGraph mscattergraph;
        public static void _SetCoordinates(int a)
        {
            if (a == 0)
            {
                GlobeVal.mscattergraph.Plots[0].YAxis = GlobeVal.mscattergraph.YAxes[0];
                GlobeVal.mscattergraph.Plots[1].YAxis = GlobeVal.mscattergraph.YAxes[1];
                GlobeVal.mscattergraph.Plots[0].YAxis.Visible = true;

                GlobeVal.mscattergraph.Plots[0].YAxis.Position = NationalInstruments.UI.YAxisPosition.Left;

                GlobeVal.mscattergraph.Plots[1].YAxis.Visible = false;



            }
            else
            {

                GlobeVal.mscattergraph.Plots[0].YAxis = GlobeVal.mscattergraph.YAxes[0];
                GlobeVal.mscattergraph.Plots[1].YAxis = GlobeVal.mscattergraph.YAxes[1];
                GlobeVal.mscattergraph.Plots[0].YAxis.Visible = true;
                GlobeVal.mscattergraph.Plots[0].YAxis.Position = NationalInstruments.UI.YAxisPosition.Left;
                GlobeVal.mscattergraph.Plots[1].YAxis.Visible = true;
                GlobeVal.mscattergraph.Plots[1].YAxis.Position = NationalInstruments.UI.YAxisPosition.Right;

            }



            return;
        }

        public static bool _gauge(out double value)
        {
            value = CComLibrary.GlobeVal.filesave.Extensometer_gauge;
            return false;
        }

        public static bool _gauge1(out double value)
        {
            value = CComLibrary.GlobeVal.filesave.Extensometer1_gauge;
            return false;
        }

        //断后标距
        public static bool _ElongationAfterBreak(out double value)
        {
            double t = 0;
            FormSpeInput f = new FormSpeInput();
            f.lblcaption.Text = "断后标距";
            f.ShowDialog();

            t = f.txtvalue.Value;

            if (CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[2].cvalue == 0)
            {
                value = 0;
            }
            else
            {
                value = t / CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[2].cvalue * 100;
            }
            CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[5].cvalue = t;
            f.Dispose();

            return false;
        }

        //断后面积
        public static bool _BreakArea(out double value)
        {


            double t = 0;

            double m1;
            double m2;


            if (CComLibrary.GlobeVal.filesave.mshapelist.Count > 0)
            {

            }
            else
            {
                value = 0;
                return false;
            }


            if (CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].shapename == CComLibrary.GlobeVal
                .filesave.mshapelist[CComLibrary.GlobeVal.filesave.mshapelist[0].Rect_Shape].shapename)
            {
                FormSpeInput f = new FormSpeInput();
                f.lblcaption.Text = "断后" + CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[0].cName;
                f.ShowDialog();
                m1 = f.txtvalue.Value;

                CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[3].cvalue = m1;
                f.Dispose();

                f = new FormSpeInput();
                f.lblcaption.Text = "断后" + CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[1].cName;
                f.ShowDialog();

                m2 = f.txtvalue.Value;
                CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[4].cvalue = m2;
                f.Dispose();
                t = m1 * m2;

            }

            if (CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].shapename == CComLibrary.GlobeVal
                .filesave.mshapelist[CComLibrary.GlobeVal.filesave.mshapelist[0].Round_Shape].shapename)
            {
                FormSpeInput f = new FormSpeInput();
                f.lblcaption.Text = "断后" + CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[0].cName;
                f.ShowDialog();
                m1 = f.txtvalue.Value;

                CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[3].cvalue = m1;
                f.Dispose();
                t = m1
                 * m1 / 4 * 3.1415926;
            }

            if (CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].shapename == CComLibrary.GlobeVal
                .filesave.mshapelist[CComLibrary.GlobeVal.filesave.mshapelist[0].Tube_Shape].shapename)
            {
                FormSpeInput f = new FormSpeInput();
                f.lblcaption.Text = "断后" + CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[0].cName;
                f.ShowDialog();
                m1 = f.txtvalue.Value;

                CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[3].cvalue = m1;

                f.Dispose();
                f = new FormSpeInput();
                f.lblcaption.Text = "断后" + CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[1].cName;
                f.ShowDialog();
                m2 = f.txtvalue.Value;
                CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[4].cvalue = m2;
                f.Dispose();





                t = 3.1415926 * (Math.Pow(m1 / 2, 2)
                    - Math.Pow((m1 - m2 * 2) / 2, 2));

            }

            if (CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].shapename == CComLibrary.GlobeVal
                .filesave.mshapelist[CComLibrary.GlobeVal.filesave.mshapelist[0].Irregular_Shape].shapename)
            {
                FormSpeInput f = new FormSpeInput();
                f.lblcaption.Text = "断后" + CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[0].cName;
                f.ShowDialog();
                m1 = f.txtvalue.Value;

                CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[3].cvalue = m1;

                f.Dispose();
                t = m1;


            }


            value = t;

            return false;
        }

        public static bool _area(out double value)
        {
            double t = 0;

            double m1;
            double m2;


            if (CComLibrary.GlobeVal.filesave.mshapelist.Count > 0)
            {

            }
            else
            {
                value = 0;
                return false;
            }
            if (CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].shapename == CComLibrary.GlobeVal
            .filesave.mshapelist[CComLibrary.GlobeVal.filesave.mshapelist[0].Rect_Shape].shapename)
            {
                t = CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[0].cvalue
                 * CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[1].cvalue;
            }

            if (CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].shapename == CComLibrary.GlobeVal
                .filesave.mshapelist[CComLibrary.GlobeVal.filesave.mshapelist[0].Round_Shape].shapename)
            {
                t = CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[0].cvalue
                 * CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[0].cvalue / 4 * 3.1415926;
            }

            if (CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].shapename == CComLibrary.GlobeVal
                .filesave.mshapelist[CComLibrary.GlobeVal.filesave.mshapelist[0].Tube_Shape].shapename)
            {

                m1 = CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[0].cvalue;
                m2 = CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[1].cvalue;





                t = 3.1415926 * (Math.Pow(m1 / 2, 2)
                    - Math.Pow((m1 - m2 * 2) / 2, 2));

            }

            if (CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].shapename == CComLibrary.GlobeVal
                .filesave.mshapelist[CComLibrary.GlobeVal.filesave.mshapelist[0].Irregular_Shape].shapename)
            {

                t = CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[0].cvalue;


            }


            value = t;



            return false;
        }

        private static double Offset(double scale, double averX, double averY)
        {
            double offset = 0;
            offset = averY - scale * averX;
            return offset;
        }

        public static bool _maxyvalue(double[] x, double[] y, out double value, out int mindex, bool mdraw)
        {
            double t = 0;
            int index = 0;
            t = y.Max();

            double max = y[0];

            for (int i = 1; i < y.Length; i++)
            {
                if (y[i] > max)
                {
                    max = y[i];
                    index = i;//把较大值的索引赋值非index
                }
            }



            value = t;
            mindex = index;

            if (mdraw == true)
            {
                LineStruct l = new LineStruct();
                l.kind = 0;
                l.indexstart = index;
                l.xstart = x[index];
                l.ystart = y[index];
                m_listline.Add(l);

            }
            return false;
        }

        public static bool _offsetslopepoint(double[] x, double[] y, double yminpercent, double ymaxpercent, double oa, out double value, bool mdraw)
        {
            try
            {
                double yieldvalue;
                int yieldindex;
                int i;
                int k;

                double[] inputx;
                double[] inputy;

                double[] inputxx;
                double[] inputyy;
                double[] mx;
                int[] mxi;

                double mslope = 0;
                double mintercept = 0;
                double mresidue = 0;

                double[] mslopev;

                double[] minterceptv;

                mx = new double[8];
                mxi = new int[8];
                mslopev = new double[7];
                minterceptv = new double[7];

                int mendi = 0;
                int mstarti = 0;


                _maxyvalue(x, y, out yieldvalue, out yieldindex, false);





                for (i = 0; i < yieldindex; i++)
                {

                    if (y[i] >= yieldvalue * yminpercent / 100.0)
                    {
                        mstarti = i;
                        break;
                    }
                }
                for (i = 0; i < yieldindex; i++)
                {

                    if (y[i] >= yieldvalue * ymaxpercent / 100.0)
                    {
                        mendi = i;
                        break;
                    }
                }




                int m1 = mstarti;
                int m2 = mendi;

                inputxx = new double[m2 - m1 + 1];
                inputyy = new double[m2 - m1 + 1];






                if (m2 - m1 > 2)
                {



                    for (int j = m1; j <= m2; j++)
                    {
                        inputxx[j - m1] = x[j];
                        inputyy[j - m1] = y[j];
                    }

                    //CurveFit.LinearFit(inputxx, inputyy, NationalInstruments.Analysis.Math.FitMethod.LeastSquare, out mslope, out mintercept, out mresidue);

                    LinearRegression(inputxx, inputyy, out mslope, out mintercept);
                }


                double tx = 0;
                double ty = 0;
                double mk = 0;
                double mks = 0;
                int msel = 0;



                tx = (ty - y[m1]) / mslope + x[m1];

                tx = tx + oa;

                mks = 10000000;
                for (i = 0; i < y.Length; i++)
                {
                    mk = (y[i] - ty) / (x[i] - tx);


                    if (mks > Math.Abs(mk - mslope))
                    {
                        mks = Math.Abs(mk - mslope);
                        msel = i;
                    }


                }
                value = y[msel];


                if (mdraw == true)
                {
                    LineStruct l = new LineStruct();
                    l.kind = 1;
                    l.xstart = tx;
                    l.ystart = ty;

                    l.xend = x[msel];
                    l.yend = y[msel];

                    m_listline.Add(l);

                }


            }
            catch (Exception e1)
            {

                value = 0;



                MessageBox.Show(e1.Source);
            }
            return false;

        }

        public static bool _module(double[] x, double[] y, double yminpercent, double ymaxpercent, bool mdraw, out double value, out int a, out int b)
        {

            try
            {
                double yieldvalue;
                int yieldindex;



                int i;
                int k;

                double[] inputx;
                double[] inputy;

                double[] inputxx;
                double[] inputyy;
                double[] mx;
                int[] mxi;

                double mslope = 0;
                double mintercept = 0;
                double mresidue = 0;

                double[] mslopev;

                double[] minterceptv;

                mx = new double[8];
                mxi = new int[8];
                mslopev = new double[7];
                minterceptv = new double[7];

                int mendi = 0;
                int mstarti = 0;


                _maxyvalue(x, y, out yieldvalue, out yieldindex, false);





                for (i = 0; i < yieldindex; i++)
                {

                    if (y[i] >= yieldvalue * yminpercent / 100.0)
                    {
                        mstarti = i;
                        break;
                    }
                }
                for (i = 0; i < yieldindex; i++)
                {

                    if (y[i] >= yieldvalue * ymaxpercent / 100.0)
                    {
                        mendi = i;
                        break;
                    }
                }




                int m1 = mstarti;
                int m2 = mendi;

                inputxx = new double[m2 - m1 + 1];
                inputyy = new double[m2 - m1 + 1];






                if (m2 - m1 > 2)
                {
                    //value =NationalInstruments.Analysis.Math.ArrayOperation.GetMax(mslopev);


                    for (int j = m1; j <= m2; j++)
                    {
                        inputxx[j - m1] = x[j];
                        inputyy[j - m1] = y[j];
                    }

                    // CurveFit.LinearFit(inputxx, inputyy, NationalInstruments.Analysis.Math.FitMethod.LeastSquare, out mslope, out mintercept, out mresidue);
                    LinearRegression(inputxx, inputyy, out mslope, out mintercept);
                }


                value = mslope;
                a = mstarti;
                b = mendi;

                // CComLibrary.GlobeVal.m_outputwindow.Text = CComLibrary.GlobeVal.m_outputwindow.Text + value.ToString() + "\r\n";


                if (mdraw == true)
                {
                    LineStruct l = new LineStruct();
                    l.kind = 1;
                    l.xstart = x[m1];
                    l.ystart = y[m1];

                    l.xend = x[m2];
                    l.yend = y[m2];

                    m_listline.Add(l);

                }


            }
            catch (Exception e1)
            {

                value = 0;

                a = 0;
                b = 0;

                MessageBox.Show(e1.Source);
            }
            return false;

        }
        public static bool _automodule(double[] x, double[] y, bool mdraw, out double value, out double a, out double b)
        {

            try
            {
                double yieldvalue;
                int yieldindex;



                int i;
                int k;

                double[] inputx;
                double[] inputy;

                double[] inputxx;
                double[] inputyy;
                double[] mx;
                int[] mxi;

                double mslope = 0;
                double mintercept = 0;
                double mresidue = 0;

                double[] mslopev;

                double[] minterceptv;

                mx = new double[8];
                mxi = new int[8];
                mslopev = new double[7];
                minterceptv = new double[7];
                _yield(x, y, 0.1, false, out yieldvalue, out yieldindex);

                mxi[0] = 0;
                for (i = 1; i <= 7; i++)
                {
                    mx[i] = x[0];
                    for (k = 0; k <= yieldindex; k++)
                    {
                        if (x[k] >= x[yieldindex] / 7 * i)
                        {
                            mxi[i] = k;
                            break;
                        }
                    }
                }
                mxi[7] = yieldindex;
                for (i = 1; i <= 7; i++)
                {
                    inputx = new double[mxi[i] - mxi[i - 1]];
                    inputy = new double[mxi[i] - mxi[i - 1]];

                    for (k = mxi[i - 1]; k < mxi[i]; k++)
                    {

                        inputx[k - mxi[i - 1]] = x[k];
                        inputy[k - mxi[i - 1]] = y[k];
                    }
                    if (inputx.Length >= 2)
                    {

                        // CurveFit.LinearFit(inputx, inputy, NationalInstruments.Analysis.Math.FitMethod.LeastSquare, out mslope, out mintercept, out mresidue);
                        LinearRegression(inputx, inputy, out mslope, out mintercept);
                    }
                    mslopev[i - 1] = mslope;
                    minterceptv[i - 1] = mintercept;

                    // CComLibrary.GlobeVal.m_outputwindow.Text = CComLibrary.GlobeVal.m_outputwindow.Text + mslope.ToString() + " " + mintercept.ToString() + "\r\n";

                }

                int m1 = Convert.ToInt32(yieldindex * 0.2);
                int m2 = Convert.ToInt32(yieldindex * 0.7);

                inputxx = new double[m2 - m1 + 1];
                inputyy = new double[m2 - m1 + 1];



                //value =NationalInstruments.Analysis.Math.ArrayOperation.GetMax(mslopev);


                for (int j = m1; j <= m2; j++)
                {
                    inputxx[j - m1] = x[j];
                    inputyy[j - m1] = y[j];
                }

                //CurveFit.LinearFit(inputxx, inputyy, NationalInstruments.Analysis.Math.FitMethod.LeastSquare, out mslope, out mintercept, out mresidue);

                LinearRegression(inputxx, inputyy, out mslope, out mintercept);

                value = mslope;
                a = mslope;
                b = mintercept;

                // CComLibrary.GlobeVal.m_outputwindow.Text = CComLibrary.GlobeVal.m_outputwindow.Text + value.ToString() + "\r\n";


                if (mdraw == true)
                {
                    LineStruct l = new LineStruct();
                    l.kind = 1;
                    l.xstart = x[Convert.ToInt32(yieldindex * 0.2)];
                    l.ystart = y[Convert.ToInt32(yieldindex * 0.2)];

                    l.xend = x[Convert.ToInt32(yieldindex * 0.7)];
                    l.yend = y[Convert.ToInt32(yieldindex * 0.7)];

                    m_listline.Add(l);

                }
            }
            catch (Exception e1)
            {

                value = 0;

                a = 0;
                b = 0;

                MessageBox.Show(e1.Source);
            }
            return false;
        }

        public static bool _yield(double[] x, double[] y, double offset, bool mdraw, out double value, out int index)
        {

            int i;
            int k;
            int maxindex = 0;
            double max;
            double[] mk;
            int[] mkstart;
            int[] mkend;
            int segcount = 0;
            int j = 0;
            int a = 0;
            bool b = false;
            int bi = 0;
            double mvalue = 0;
            int mindex = 0;
            double xx;
            double maxx;
            int maxxindex = 0;

            maxx = x[0];
            for (i = 0; i < m_len - 1; i++)
            {
                if (x[i] >= maxx)
                {
                    maxx = x[i];
                    maxxindex = i;

                }
            }

            max = y[0];


            for (i = 0; i < maxxindex; i++)
            {
                if (y[i] >= max)
                {
                    max = y[i];
                    maxindex = i;
                }

            }

            xx = x[maxindex] * 0.01;

            segcount = m_len / 10;
            mk = new double[segcount];
            mkstart = new int[segcount];
            mkend = new int[segcount];
            j = 0;
            a = 0;
            k = 0;
            for (i = 0; i < segcount; i++)
            {

                while (x[a + k] - x[a] <= xx)
                {
                    k = k + 1;
                    if (a + k >= m_len - 2)
                    {
                        k = k - 1;
                        break;
                    }
                }
                if ((x[a] - x[a + k]) != 0)
                {
                    mk[j] = (y[a] - y[a + k]) / (x[a] - x[a + k]);
                }
                else
                {
                    mk[j] = 0;
                }
                mkstart[j] = a;
                mkend[j] = a + k;
                j = j + 1;
                a = a + k;


                // CComLibrary.GlobeVal.m_outputwindow.Text = CComLibrary.GlobeVal.m_outputwindow.Text + "屈服段=" +(j-1).ToString() + " "+  mk[j-1].ToString() + "\r\n";     

                k = 0;

            }


            double mt = mk.Max();


            b = false;
            for (i = 0; i < segcount; i++)
            {
                if (mk[i] <= mt * 0.8)
                {
                    bi = i;


                    b = true;
                    break;
                }
            }

            if (b == false)
            {
                value = max;
                index = maxindex;
                return b;
            }



            mvalue = y[mkstart[bi]];
            for (i = mkstart[bi]; i < mkend[bi + 1]; i++)
            {
                if (y[i] >= mvalue)
                {
                    mvalue = y[i];
                    mindex = i;

                }
            }


            value = mvalue;
            index = mindex;



            if (mdraw == true)
            {
                LineStruct l = new LineStruct();
                l.kind = 0;
                l.indexstart = index;
                l.xstart = x[index];
                l.ystart = y[index];
                m_listline.Add(l);

            }

            return b;



        }
        public static double _funmax(int starti, int endi, double[] value)
        {
            int i;
            double m;

            m = value[starti];

            for (i = starti; i < endi; i++)
            {
                if (value[i] <= m)
                {
                    m = value[i];
                }
            }

            return m;
        }
        public GlobeVal()
        {


        }
    }


    [Serializable]

    public class Rule
    {


        public Rule()
        {
            paraname = new string[10];
            parakind = new string[10];
            LOperaWordsName = new string[10];
            LExplain = new string[10];
            LListString = new string[10];
            for (int i = 0; i < 10; i++)
            {
                paraname[i] = "";
                parakind[i] = "";
                LOperaWordsName[i] = "";
                LExplain[i] = "";
                LListString[i] = "";
            }
        }

        public string OperaWordsName;
        public string replaceName;
        public string kind; //类型
        public string explain;//说明
        public int count;//参数数量
        public string[] paraname;//参数名称
        public string[] parakind;//参数类型

        public string[] LOperaWordsName;

        public string[] LExplain;

        public string ListString;

        public string[] LListString;



    }

    [Serializable]

    public class SystemPara
    {


        public SystemPara()
        {

        }

        public string Name;
        public string replaceName;
        public string kind; //类型
        public string explain;//说明




    }





    [Serializable]

    public class CalcPanel
    {
        public CalcPanel()
        {
            namecol = new int[100];
            namerow = new int[100];
            valuecol = new int[100];
            valuerow = new int[100];


        }

        public void init_textgrid()
        {
            int i;
            textgrid = new string[rowcount][];

            for (i = 0; i < rowcount; i++)
            {
                textgrid[i] = new string[colcount];
            }

        }


        public int colcount = 0;
        public int rowcount = 0;

        public int[] namecol;
        public int[] namerow;
        public int[] valuecol;
        public int[] valuerow;

        public string[][] textgrid;



    }

    public class xyaa : NationalInstruments.UI.XYRangeAnnotation
    {

        public xyaa()
        {



        }
    }



    /// <summary>
    /// Class to store one CSV row
    /// </summary>
    public class CsvRow : List<string>
    {
        public string LineText { get; set; }
    }

    /// <summary>
    /// Class to write data to a CSV file
    /// </summary>
    public class CsvFileWriter : StreamWriter
    {
        public CsvFileWriter(Stream stream)
            : base(stream)
        {
        }

        public CsvFileWriter(string filename)
            : base(filename)
        {
        }

        /// <summary>
        /// Writes a single row to a CSV file.
        /// </summary>
        /// <param name="row">The row to be written</param>
        public void WriteRow(CsvRow row)
        {
            StringBuilder builder = new StringBuilder();
            bool firstColumn = true;
            foreach (string value in row)
            {
                // Add separator if this isn't the first value
                if (!firstColumn)
                    builder.Append(',');
                // Implement special handling for values that contain comma or quote
                // Enclose in quotes and double up any double quotes
                if (value.IndexOfAny(new char[] { '"', ',' }) != -1)
                    builder.AppendFormat("\"{0}\"", value.Replace("\"", "\"\""));
                else
                    builder.Append(value);
                firstColumn = false;
            }
            row.LineText = builder.ToString();
            WriteLine(row.LineText);
        }
    }

    /// <summary>
    /// Class to read data from a CSV file
    /// </summary>
    public class CsvFileReader : StreamReader
    {
        public CsvFileReader(Stream stream)
            : base(stream)
        {
        }

        public CsvFileReader(string filename)
            : base(filename)
        {
        }

        /// <summary>
        /// Reads a row of data from a CSV file
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public bool ReadRow(CsvRow row)
        {
            row.LineText = ReadLine();
            if (String.IsNullOrEmpty(row.LineText))
                return false;

            int pos = 0;
            int rows = 0;

            while (pos < row.LineText.Length)
            {
                string value;

                // Special handling for quoted field
                if (row.LineText[pos] == '"')
                {
                    // Skip initial quote
                    pos++;

                    // Parse quoted value
                    int start = pos;
                    while (pos < row.LineText.Length)
                    {
                        // Test for quote character
                        if (row.LineText[pos] == '"')
                        {
                            // Found one
                            pos++;

                            // If two quotes together, keep one
                            // Otherwise, indicates end of value
                            if (pos >= row.LineText.Length || row.LineText[pos] != '"')
                            {
                                pos--;
                                break;
                            }
                        }
                        pos++;
                    }
                    value = row.LineText.Substring(start, pos - start);
                    value = value.Replace("\"\"", "\"");
                }
                else
                {
                    // Parse unquoted value
                    int start = pos;
                    while (pos < row.LineText.Length && row.LineText[pos] != ',')
                        pos++;
                    value = row.LineText.Substring(start, pos - start);
                }

                // Add field to list
                if (rows < row.Count)
                    row[rows] = value;
                else
                    row.Add(value);
                rows++;

                // Eat up to and including next comma
                while (pos < row.LineText.Length && row.LineText[pos] != ',')
                    pos++;
                if (pos < row.LineText.Length)
                    pos++;
            }
            // Delete any unused items
            while (row.Count > rows)
                row.RemoveAt(rows);

            // Return true if any columns read
            return (row.Count > 0);
        }
    }


}


