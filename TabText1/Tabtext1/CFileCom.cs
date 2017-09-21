 using System;
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
using NationalInstruments.Analysis.Math;
using NationalInstruments.Analysis;
using NationalInstruments.Analysis.Conversion;
using NationalInstruments.Analysis.Dsp;
using NationalInstruments.Analysis.Dsp.Filters;
using NationalInstruments.Analysis.Monitoring;
using NationalInstruments.Analysis.SignalGeneration;
using NationalInstruments;
using ClsStaticStation;
using System.Data;
using System.Web.UI;
namespace CComLibrary
{

      
   

      [ComVisible(true)]
        [Guid("EBAD8A83-BC05-412D-A059-6648C524148F")]
        public interface IMyClass
        {
            void Initialize();
            void Dispose();
            int Add(int x, int y);
            void calc();
             double expstr(string s, int i,out Boolean r);
             void initarray(string s, int count);
             void refreshglobe(string s);
             void refreshresult(string s);
             void gethwnd(long  h);
             void setarrayvalue(double[,] t, int l);
             void setarrayvalueold(double[,] t, int l);

        }

        [ComVisible(true)]
        [Guid("722FA461-6288-4071-A105-9705281B19A1")]
        [ProgId("K8robot.reply")]
        public class K8robot 

        {

            [DllImport("user32.dll")]
             private static extern int SetParent(IntPtr hWndChild,IntPtr hWndParent);

            [DllImport("user32.dll")]
             private static extern bool ShowWindowAsync(IntPtr hWnd,int nCmdShow);

            [DllImport("user32.dll", SetLastError = true)]
             private static extern bool PostMessage(IntPtr hWnd,uint Msg,int wParam,int lParam);

            [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
            private static extern bool SetWindowPos(IntPtr hWnd,int hWndInsertAfter,
            int X,int Y,int cx,int cy,uint uFlags);

            [DllImport("user32.dll")]
            private static extern int SendMessage(IntPtr hWnd,uint Msg,int wParam,int lParam);

            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            private static extern uint SetWindowLong(IntPtr hwnd, int nIndex, uint newLong);

            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
             private static extern uint GetWindowLong(IntPtr hwnd, int nIndex);

            [DllImport("user32.dll", CharSet = CharSet.Auto)]
             private static  extern bool ShowWindow(IntPtr hWnd, short State);


             private const int HWND_TOP = 0x0;
             private const int WM_COMMAND = 0x0112;
             private const int WM_QT_PAINT = 0xC2DC;
             private const int WM_PAINT = 0x000F;
             private const int WM_SIZE = 0x0005;
             private const int SWP_FRAMECHANGED = 0x0020;

             MathExpressionParser mp;

             public void savecode()
             {
                 using (StreamWriter sw = new StreamWriter("代码.txt"))
                 {
                     // Add some text to the file.
                    
                     sw.Write(mp.text.Text);
                     
                     
                 }

             }

             public void gethwnd(long  h)
             {
                 SetParent(GlobeVal.m_mainform.Handle, (IntPtr)h);


                 GlobeVal.m_mainform.Show();
                 GlobeVal.m_mainform.Left = 0;
                 GlobeVal.m_mainform.Top = 0;
                 SetWindowPos(GlobeVal.m_mainform.Handle, -1, 0, 0, 0, 0, 1); 


             }

             public void Initialize通道()
             {

                 mp = new MathExpressionParser();

                 mp.InitBegin();
                 GlobeVal.m_channeldata = new double[20];  


                 //nothing todo
             }

         
            public void Initialize()
            {
                
                mp = new MathExpressionParser();
               
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


            public void setarrayvalue(System.Array  t, int l,int m)
            {
                int i;
                int j;
                int k=0;
                int mi=0;
                int mj=0;
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
                                    for (int ii=0;ii<ClsStaticStation.m_Global.mycls.signalskindlist.Count;ii++)
                                    {
                                        for (int jj=0;jj<ClsStaticStation.m_Global.mycls.signalskindlist[ii].cUnitCount ;jj++)
                                        {
                                            if (CComLibrary.GlobeVal.g_dataunit[j].Trim() == ClsStaticStation.m_Global.mycls.signalskindlist[ii].cUnits[jj])
                                            {
                                                mi =ii;
                                                mj = jj;
                                                ClsStaticStation.m_Global.mycls.signalskindlist[ii].originprecise  = 3;
                                                ClsStaticStation.m_Global.mycls.signalskindlist[ii].cUnitsel = jj;
                                                break;
                                            }
                                        }
                                     }
                                        GlobeVal.m_data[k][i] =  Convert.ToDouble( ClsStaticStation.m_Global.mycls.signalskindlist[mi].GetOriValue(Convert.ToDouble(t.GetValue(i+1,j))));
                                    
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

            public void InitChannel(string s,int i)
            {
                mp.msource = s;
                mp.InitChannel(s,i);
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

            public Boolean     calc()
            {
                Boolean b;
                
                b=mp.InitCalcedChannelExpressiton();
                mp.calc(); 

                return b ;
            }

            public double getresult通道(int i)
            {
                double v = 0;
                v = mp.eval_hardchannel(i);
                return v;

            }


            public double  getresult(int i)
            {
                double v = 0;
                v = mp.eval_calcedchannel(i);
                return v;

            }

            public double  expchannel(string s, int i, out Boolean r)
            {
                double v = 0;
                mp.msource = s;
                //mp.InitChannel(s, i);
                mp.InitHardChannel(s, i);
                r=mp.InitCalcedChannelExpressiton();
                v = mp.eval_hardchannel(i);
              
                return v;
            }
            public double expstr(string s, int i,out Boolean   r)
            {
                double v=0;
               
                mp.msource = s;

               
 
                mp.InitExpr(s, i);

                r=mp.InitCalcedChannelExpressiton();

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
    public class  LineStruct
    {
        public PointF pf;
        public  int     kind;  //0 point  1 line 2 paraline
        public  double  xstart;
        public  double  ystart;
        public  double  xend;
        public  double  yend;
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

        public int ychannel = 0;
        public int ychannelunit = 0;
        public bool ychannelzoom = false;

        public int y1channel = 0;
        public int y1channelunit = 0;
        public bool y1channelzoom = false;
      

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

        private  Boolean m_ShowGrid;

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
   
        public  NationalInstruments.UI.LineStyle GridLineStyle
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

        private  bool   m_XCaption=false ;

        public bool  XCaption
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
                m_Xlog=value;
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



        private bool  m_YCaption=false ;

        public bool  YCaption
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

        private  Boolean m_showLegend;


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


        private  Boolean m_showlegendborder;
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
        private  int[] m_PlotLineSize;

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

        public void SetPlotLineStyle(ref  NationalInstruments.UI.LineStyle mr,int index)
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

        public void SetSignLineStyle(ref  NationalInstruments.UI.LineStyle mr)
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

        public void SetPlotLinePointStyle(ref  NationalInstruments.UI.PointStyle mr,int index)
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
        public void SetSignPointStyle(ref  NationalInstruments.UI.ShapeStyle  mr)
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
        public void SetGridLineStyle(ref  NationalInstruments.UI.LineStyle mr)
        {
            int w=0;
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
            SetGridLineStyle( ref this.m_GridLineStyle); 
            
            
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
        public string name=" ";
        public string  value=" ";
    }
   
    [Serializable]
      public class  inputitem
        {
          public   string name;
          public   double  value;
          public   string unit;
          public int dimsel=0;//量纲选择
          public ItemSignal myitemsignal;
         
        }
    [Serializable]
      public class outputitem
      {
         public  string formulaname;
         public  string formulavalue;
         public  string formulaunit;
         public bool check=false;
         public bool selected = false;
         public int dimsel = 0;//量纲选择
         public string formulaexplain="";
         public bool show;
         public ItemSignal myitemsignal;
         public double limitup = 10000; //合格范围上限
         public double limitdown = 0;//合格范围下限
         public bool apply = false;//合格范围判断统计值

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
            ItemName = new string[10];
            ItemCol = new int[10];
            ItemRow = new int[10];
            ItemColSpan = new int[10];
            ItemRowSpan = new int[10];
            Show = new bool[10];
            rowheight = new int[10];
            colWidth = new int[10]; 
 
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

                MessageBox.Show(e1.Message, "读取文件");
            }
            finally
            {

            }
            return (c);
        }
    }



    [Serializable]
    public class  TableHeaderPara
    {
        public Font HeaderFont;
        public ContentAlignment  HeaderAlignment;
        public Color HeaderBackColor;
        public Color HeaderForeColor;

        public TableHeaderPara()
        {
          HeaderFont=new Font("宋体", 12);
          HeaderAlignment = ContentAlignment.MiddleCenter;
          HeaderBackColor = SystemColors.ButtonFace;
          HeaderForeColor = Color.Black;

        }

    }
    [Serializable]
    public class  TableColPara
    {
        public Font ColFont;
        public ContentAlignment  ColAlignment;
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
    public class  TableGridPara
    {
        public Font GridFont;
        public ContentAlignment  GridAlignment;
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
        public  TableHeaderPara  mTableHeaderPara ;
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
       public int itemkind;

       public string parentstring;

        

        public event EventHandler PropertyChanged; 
        private object  mitemvalue =null;

        public bool group = false;

        public bool used = false;

        public int level = 0;

        public cboitem mcboitem;

        public string itemunit;

        public void getvalue()
        {
            mitemvalue = " ";

            if (itemname == "样品注释1")
            {

                
                mitemvalue =  CComLibrary.GlobeVal.filesave.samplememo1;

               
                itemkind = 0;
            }

            if (itemname == "样品注释2")
            {
                mitemvalue = CComLibrary.GlobeVal.filesave.samplememo2;
             
                itemkind = 0;

            }

            if (itemname == "样品注释3")
            {
                mitemvalue = CComLibrary.GlobeVal.filesave.samplememo3;
               
                itemkind = 0;

            }

            if (itemname == "样品说明")
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

                    if (mitemvalue.ToString()=="")
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

                        mitemvalue = CComLibrary.GlobeVal.filesave.minputtext[i].value ;
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
            if (itemname  == "样品注释1")
            {
                CComLibrary.GlobeVal.filesave.samplememo1 = Convert.ToString( mitemvalue);
            }

            if (itemname == "样品注释2")
            {
                CComLibrary.GlobeVal.filesave.samplememo2 = Convert.ToString(mitemvalue);
            }

            if (itemname == "样品注释3")
            {
                CComLibrary.GlobeVal.filesave.samplememo3 = Convert.ToString(mitemvalue);
            }

            if (itemname == "样品说明")
            {
                CComLibrary.GlobeVal.filesave.samplememo =Convert.ToString( mitemvalue);
            }

            for (int i = 0; i <
        CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem.Length; i++)
            {

                if (itemname == CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[i].cName)
                {
                    CComLibrary.GlobeVal.filesave.dt.Rows[CComLibrary.GlobeVal.filesave.currentspenumber][itemname] = Convert.ToDouble(mitemvalue);
                     //CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[i].cvalue= Convert.ToDouble(mitemvalue);
                    
                }

            }

            for (int i = 0; i <
             CComLibrary.GlobeVal.filesave.minputtext.Count; i++)
            {
                if (itemname ==CComLibrary.GlobeVal.filesave.minputtext[i].name)
                {
                    CComLibrary.GlobeVal.filesave.dt.Rows[CComLibrary.GlobeVal.filesave.currentspenumber][itemname] = Convert.ToString(mitemvalue);
                    // CComLibrary.GlobeVal.filesave.minputtext[i].value=Convert.ToString( mitemvalue);
                }
            }

            for (int i = 0; i <
                  CComLibrary.GlobeVal.filesave.minput.Count; i++)
            {

                if (itemname == CComLibrary.GlobeVal.filesave.minput[i].name)
                {
                    CComLibrary.GlobeVal.filesave.dt.Rows[CComLibrary.GlobeVal.filesave.currentspenumber][itemname] = Convert.ToDouble(mitemvalue);
                   //CComLibrary.GlobeVal.filesave.minput[i].value=Convert.ToDouble( mitemvalue) ;
                   
                }
            }


            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mcbo.Count; i++)
            {

                if (itemname == CComLibrary.GlobeVal.filesave.mcbo[i].Name)
                {
                    CComLibrary.GlobeVal.filesave.dt.Rows[CComLibrary.GlobeVal.filesave.currentspenumber][itemname] = Convert.ToInt32(mitemvalue);
                   // CComLibrary.GlobeVal.filesave.mcbo[i].value = Convert.ToInt32(mitemvalue);
                    
                    
                }
            }

        }

        public object itemvalue
        {
            get {
                getvalue();

                

                return mitemvalue ; }
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
        public string explain;//说明

        public double keeptime;//保持时间


        public double mstartload;
        public double mendload;
        public double mstartstrain;
        public double mendstrain;
        public double mstrainspeed;

        public string cyclicconvert()
        {
            string s = "";

            if (cyclicrun == true)
            {
                if (returnstep > 0)
                {
                    if (cycliccount > 0)
                    {
                        s = "返回" + cycliccount.ToString() + "次," + "返回到步骤" + returnstep.ToString();
                    }
                }
            }
            return s;
        }
        public string speedconvert()
        {
            string s = "";

            if (cmd == 2)
            {
                s = "速度:" + speed.ToString()+"MPa/s";

            }
            else
            {

                for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals.Count; i++)
                {
                    if (controlmode == i)
                    {
                        s = "速度:" + speed.ToString("F4") + ClsStaticStation.m_Global.mycls.hardsignals[i].speedSignal.cUnits[0];


                    }
                    if (controlmode == 1)
                    {
                        s = s + "[" + CComLibrary.GlobeVal.filesave.LoadToStrain(speed).ToString("F4") + "MPa/s]";

                    }


                }
            }
            return s;
        }

        public string destconvert()
        {

            string s = "";

            if (cmd == 2)
            {
                s = "当围压压力到达" + dest.ToString() + "MPa时";
            }

            else
            {

                for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals.Count; i++)
                {
                    if (destcontrolmode == i)
                    {
                        s = "当" + ClsStaticStation.m_Global.mycls.hardsignals[i].cName + "到达" +

                            dest.ToString("F4") + ClsStaticStation.m_Global.mycls.hardsignals[i].cUnits[0] + "时";

                    }

                    if (destcontrolmode == 1)
                    {
                        s = s + "["+CComLibrary.GlobeVal.filesave.LoadToStrain(dest).ToString("F4")+"MPa]" ;
                            
                    }

                }

                if (keeptime == 0)
                {

                }
                else
                {
                    s = s + ",保持" + keeptime.ToString() + "s";
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
            cmdstring = new string[3];


            
            cmdstring[0] = "等速位移";
            cmdstring[1] = "等速力";
            cmdstring[2] = "等速围压压力";
          

            actionstring = new string[2];

            actionstring[0] = "异步控制";
            actionstring[1] = "同步控制";
          

            mseglist = new List<SegTest>();

            mseglist.Clear();


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



                    fileStream.Close();



                }
            }
            catch (Exception e1)
            {
                c = new SegFile();

                MessageBox.Show(e1.Message, "读取文件");
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

        public List<PromptsItem> mstepPromptsItem=new List<PromptsItem>();

       
    }

   public  enum TestStatus
    {
        Untested = 0,
        tested = 1,
        novalid = 2

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
            cmd = 0;
          
        }

        public  string explain(int machinekind)
        {
            string s="";
            SegFile f=new SegFile();

            s = s + f.cmdstring[cmd] + " ";

            
            if (cmd == 2)
            {
                s = s + "速度 " + speed.ToString("F4") + " ";

                s = s + "MPa/s";

                s = s + "目标[MPa]：";
                s = s + dest.ToString();
            }

            else
            {



                s = s + "速度 " + speed.ToString("F4") + " ";

                if ((machinekind == 0)||(machinekind ==2))

                {
                    if (controlmode == 0)
                    {
                        s = s + "mm/s  ";
                    }
                    else
                    {
                        s = s + "kN/s ";

                        s = s + "[" + CComLibrary.GlobeVal.filesave.LoadToStrain(speed).ToString("F4") + "MPa/s]";

                    }


                    if (destcontrolmode == 0)
                    {
                        s = s + "目标[mm]：";
                    }
                    else
                    {
                        s = s + "目标[kN]：";


                    }
                }
                else if (machinekind == 1)
                {

                    if (controlmode == 0)
                    {
                        s = s + "°/s  ";
                    }
                    else
                    {
                        s = s + "N.M/s ";

                       

                    }


                    if (destcontrolmode == 0)
                    {
                        s = s + "目标[°]：";
                    }
                    else
                    {
                        s = s + "目标[N.M]：";


                    }
                }
                s = s + dest.ToString("F4");


                if (destcontrolmode == 0)
                {
                }
                else
                {
                    s = s + "[" + CComLibrary.GlobeVal.filesave.LoadToStrain(dest).ToString("F4") + "MPa]";

                }

                if (keeptime > 0)
                {
                    s = s + "保持" + keeptime.ToString("F4") + "s";
                }

                if ((returncount > 0) && (returnstep > 0))
                {

                    s = s + "返回" + returncount.ToString() + "次," + "返回到步骤" + returnstep.ToString();
                }

                


            }

            if (action == 0)
            {
                s = s + " 顺序执行";
            }
            else
            {
                s = s + " 同步执行";
            }
            return s;
        }
    }

    [Serializable]
    public class FileStruct
    {
      

        public string methodname=""; //方法名称
        public string datapath = "";

        public List<string> m_namelist;

        public List<inputitem>  minput;
        
        public List<outputitem>  moutput;


        public CalcPanel mcalcpanel;

        public List<userchannelitem> muserchannel;

        public string fileextname = "*.*";

        public int minterval = 1;

        public  int xsel;
        public  int ysel;

        public  int[] ysels;
        public  int[] yselpostion;

        public  int yselcount = 0;
        public int filekind = 0;

        public List<string> lprocedurename;

        public int shapeselect = 0;

        public string methodauthor="";//方法作者
        public string methodmemo = "";//方法说明
        public int methodkind = 0; //方法类型
        public List<shapeitem> mshapelist;

        public string samplememo1;//样品注释1
        public string samplememo2;//样品注释2
        public string samplememo3;//样品注释3
        public string samplememo; //样品说明

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

        public List<CTestStep> mstep;

        public List<int> mtestlist;

        public bool mwizard = false; //试验向导是否有效

        public int mspecount = 0;//试样数量

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


        public bool endoftest1=false;// 试验结束1
        public int endoftest1criteria=0;//试验结束1准则
        public double  endoftest1value=0;//试验结束1变量值

        



        public bool endoftest2=false;// 试验结束2
        public int endoftest2criteria=0;//试验结束2准则
        public double  endoftest2value=0;//试验结束2变量值
       

        public int testaction=0;//试验结束动作


        public List<CTestStep> teststep;


        public List<PromptsItem> mpromptslist;

        public List<outputitem> moutputexternal;//结果表格额外

        public int currentspenumber = 0;

        public int cbosamplestart=0;
        public List<double> mcbosamplestart;
        public int cbosampleinterval = 0;
        public List<double> mcbosampleinterval;

        public double SampleInterval = 50; //采样频率
        public bool crackcheck = false;//断裂检测
        public double crackvalue = 10;//断裂阀值

        public List<ItemSignal> mchsignals; //信号限位

        public List<PromptsItem> mFreeFormPromptsItem ;
        public string SamplePath;
        public string SampleDefaultName="TestSample";

        public CmdSeg pretest_cmd;

        public CmdSeg[] testcmdstep;

        public string SegName = "default.seg";

        public List<CmdSeg> mseglist; //seg文件

        public List<CComLibrary.CmdSeg> mexplainlist;//试验段列表

        public string ReportTemplate;//报告模板

        public int ReportFormat;//报告格式

        public Boolean ReportSave;//是否保存报告

        public Boolean ReportPrint;//是否打印报告

        public string  lasttestdatatime;//最后试验日期

		public CmdSeg simple_cmd; //简单试验

        public double StrainToLoad(double l)
        {
            double t = 0;

            if (mshapelist[shapeselect].shapename == "矩形")
            {
                t = mshapelist[shapeselect].sizeitem[0].cvalue * mshapelist[shapeselect].sizeitem[1].cvalue;

            }

            if (mshapelist[shapeselect].shapename == "圆形")
            {
                t = mshapelist[shapeselect].sizeitem[0].cvalue * mshapelist[shapeselect].sizeitem[0].cvalue / 4 * 3.1415926;

            }

            return  l / 1000 * t; 

        }

        public double LoadToStrain(double l)
        {
            double t = 0;

            if (mshapelist[shapeselect].shapename == "矩形")
            {
                t = mshapelist[shapeselect].sizeitem[0].cvalue * mshapelist[shapeselect].sizeitem[1].cvalue;

            }

            if (mshapelist[shapeselect].shapename == "圆形")
            {
                t = mshapelist[shapeselect].sizeitem[0].cvalue * mshapelist[shapeselect].sizeitem[0].cvalue / 4 * 3.1415926;

            }


            return l/t*1000;

        }

        public double GetArea()
        {
            double t=0;

            if (mshapelist[shapeselect].shapename == "矩形")
           {
               t = mshapelist[shapeselect].sizeitem[0].cvalue * mshapelist[shapeselect].sizeitem[1].cvalue;

           }

            if (mshapelist[shapeselect].shapename == "圆形")
            {
                t = mshapelist[shapeselect].sizeitem[0].cvalue * mshapelist[shapeselect].sizeitem[0].cvalue/4*3.1415926;

            }


           return t;
           
        }

        public void InitExplainList()
        {

			if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 2) //简单试验
				{




					mexplainlist = new List<CmdSeg>();
					mexplainlist.Clear();

					
				    mexplainlist.Add(CComLibrary.GlobeVal.filesave.simple_cmd );


					

					

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
            else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 1)//高级试验
            {


                CComLibrary.GlobeVal.filesave.mseglist = new List<CComLibrary.CmdSeg>();


                CComLibrary.SegFile sf = new CComLibrary.SegFile();

                sf = sf.DeSerializeNow(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AppleLabJ\\seg\\"
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
                    if (CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem[i].cName != "无")
                    {
                        b = new CComLibrary.SystemPara();
                        b.Name = CComLibrary.GlobeVal.filesave.mshapelist[j].shapename + "_" +
                            CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem[i].cName;
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




            i = readfilelen(filename, out L);

            readdemo(filename, i, L);

            Boolean bcalc = false;

            CComLibrary.SystemPara b;
            string s;






            s = "";

            CComLibrary.GlobeVal.m_test = false;

            for (i = 0; i < CComLibrary.GlobeVal.filesave.m_namelist.Count; i++)
            {
                s = s + CComLibrary.GlobeVal.filesave.m_namelist[i] + " ";

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

            for (j = 0; j < CComLibrary.GlobeVal.filesave.moutput.Count; j++)
            {
                if (CComLibrary.GlobeVal.filesave.moutput[j].check == true)
                {
                    CComLibrary.GlobeVal.gcalc.Initexpr(CComLibrary.GlobeVal.filesave.moutput[j].formulavalue, j + 1);
                    s = "";
                    for (i = 0; i < CComLibrary.GlobeVal.filesave.moutput.Count; i++)
                    {
                        b = new CComLibrary.SystemPara();
                        b.Name = CComLibrary.GlobeVal.filesave.moutput[i].formulaname;
                        b.replaceName = b.Name;
                        //  s = s + "double " + b.replaceName + "=" + "CalcedChannelResult["+(i + 1).ToString().Trim() + "];" + "\r\n";
                        s = s + "double " + b.replaceName + "=" + "m_Global.mresult[" + (i + 1).ToString().Trim() + "];\r\n";
                        CComLibrary.GlobeVal.msyspara.Add(b);



                    }

                }
            }

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





               CComLibrary.GlobeVal.gcalc.getresult(j + 1).ToString();


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
            dt = new DataTable();
           

            DataColumn dc = null;
            dc = dt.Columns.Add("序号", Type.GetType("System.Int32"));
            dc.AutoIncrement = true;//自动增加
            dc.AutoIncrementSeed = 1;//起始为1
            dc.AutoIncrementStep = 1;//步长为1
            dc.AllowDBNull = true;//

            dc = dt.Columns.Add("试样状态", typeof(CComLibrary.TestStatus)); 

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mpromptslist.Count; i++)
            {
               
                dc = dt.Columns.Add(CComLibrary.GlobeVal.filesave.mpromptslist[i].itemname, System.Type.GetType("System.String"));
               
               
            }


            for (int i = 0; i < CComLibrary.GlobeVal.filesave.moutput.Count; i++)
            {

                dc = dt.Columns.Add(CComLibrary.GlobeVal.filesave.moutput[i].formulaname,typeof(double));
               
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

            dc = dtstatic.Columns.Add("统计", Type.GetType("System.String"));
           
            dc.AllowDBNull = true;//

            dc = dtstatic.Columns.Add("试样状态", typeof(CComLibrary.TestStatus));

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mpromptslist.Count; i++)
            {

                dc = dtstatic.Columns.Add(CComLibrary.GlobeVal.filesave.mpromptslist[i].itemname, System.Type.GetType("System.String"));

            }


            for (int i = 0; i < CComLibrary.GlobeVal.filesave.moutput.Count; i++)
            {

                dc = dtstatic.Columns.Add(CComLibrary.GlobeVal.filesave.moutput[i].formulaname, typeof(double));

            }


            for (int i = 0; i < 6; i++)
            {
                DataRow newRow;
                newRow = dtstatic.NewRow();

               
                dtstatic.Rows.Add(newRow);

            }

            dtstatic.Rows[0][0] = "最大值";
            dtstatic.Rows[1][0] = "最小值";
            dtstatic.Rows[2][0] = "平均值";
            dtstatic.Rows[3][0] = "标准偏差";
            dtstatic.Rows[4][0] = "方差";
            

            
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
            a.formulaname = "最大值";

            f.mtable2statistics.Add(a);

            a = new outputitem();
            a.formulaname = "最小值";
            f.mtable2statistics.Add(a);

            a = new outputitem();
            a.formulaname = "平均值";
            f.mtable2statistics.Add(a);
        }
        public void init_mtable1statistics(FileStruct f)
        {


            f.mtable1statistics = new List<outputitem>();
            outputitem a = new outputitem();
            a.formulaname = "最大值";

            f.mtable1statistics.Add(a);
            a = new outputitem();
            a.formulaname = "最小值";
            f.mtable1statistics.Add(a);

            a = new outputitem();
            a.formulaname = "平均值";
            f.mtable1statistics.Add(a);

           
        }

        public void InitPrompts()
        {
            mpromptslist.Clear();
           PromptsItem p = new PromptsItem();
           p.itemname = "样品注释1";
           p.parentstring = "样品";
          
           mpromptslist.Add(p);

           p = new PromptsItem();
           p.itemname = "样品注释2";
           p.parentstring = "样品";
          
           mpromptslist.Add(p);

           p = new PromptsItem();
           p.itemname = "样品注释3";
           p.parentstring = "样品";
           mpromptslist.Add(p);

           p = new PromptsItem();
           p.itemname = "样品说明";
           p.parentstring = "样品";
           mpromptslist.Add(p);


          

           for (int i = 0; i <
          CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem.Length; i++)
           {
               if (CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[i].cName != "无")
               {
                   p = new PromptsItem();
                   p.itemname = CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[i].cName;
                   p.parentstring = "试样尺寸输入";
                   mpromptslist.Add(p);
               }
           }


           for (int i = 0; i <
             CComLibrary.GlobeVal.filesave.minputtext.Count; i++)
           {
               p = new PromptsItem();
               p.itemname =CComLibrary.GlobeVal.filesave.minputtext[i].name;
               p.parentstring = "试样文本输入";
               mpromptslist.Add(p);
           }

           for (int i = 0; i <
            CComLibrary.GlobeVal.filesave.minput.Count; i++)
           {
                p = new PromptsItem();
                p.itemname =CComLibrary.GlobeVal.filesave.minput[i].name;
                p.parentstring = "试样数字输入";
                mpromptslist.Add(p);
           }



           for (int i = 0; i < CComLibrary.GlobeVal.filesave.mcbo.Count; i++)
           {
               p = new PromptsItem();
               
               p.parentstring = "试样选项输入";
               p.itemname=CComLibrary.GlobeVal.filesave.mcbo[i].Name;
               mpromptslist.Add(p);

           }


        }

        public FileStruct()
       {
           m_namelist = new List<string>();
           minput = new List<inputitem>();
           moutput = new List<outputitem>();
           mcalcpanel = new CalcPanel();
           muserchannel = new List<userchannelitem>(); 
           ysels=new int[10]; 
           yselpostion=new int[10] ;
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

           init_mtable1statistics(this);
           init_mtable2statistics(this);
           mrawdata = new List<ItemSignal>();

           chkcriteria = new bool[3];
           cbomeasurement = new int[3];
           numinterval = new double[3];

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
           

       }

        public void SerializeNow(string filename)
        {
            
            FileStream fileStream =
            new FileStream(filename, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(fileStream, this);
            fileStream.Close();
        }
        public  FileStruct   DeSerializeNow(string filename)
        {
            FileStruct c = new FileStruct();
            try
            {
                

                using (FileStream fileStream =
                 new FileStream(filename ,
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
                        c.moutput =new List<CComLibrary.outputitem>();
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

                    if (c.mtable2statistics == null)
                    {
                        init_mtable2statistics(c);

                    }

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
                        c.numinterval =new double[3];
                        for (int i = 0; i < 3; i++)
                        {
                            c.numinterval[i] = 0;
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

                    if (c.pretest_cmd ==null)
                    {
                        c.pretest_cmd = new CmdSeg();

                    }

                    if (c.testcmdstep == null)
                    {
                       c.testcmdstep= new CmdSeg[4];

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

                            sf = sf.DeSerializeNow(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AppleLabJ\\seg\\"
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

                       

                    fileStream.Close();

                  
                    
                    
                }
            }
            catch (Exception e1)
            {
                c = new FileStruct();

                MessageBox.Show(e1.Message,"读取文件");  
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
        public  string msource;
        private string calcstring;

        public long stringlength = 0;

        public  TextBox text;

        private ListBox list;

        private Microsoft.CSharp.CSharpCodeProvider cp;
        private System.CodeDom.Compiler.ICodeCompiler ic;
        private System.CodeDom.Compiler.CompilerParameters cpar;
        private System.CodeDom.Compiler.CompilerResults cr;
        public MyClassBase myobj = null;

        public ArrayList errorMessages;


        public MathExpressionParser()
        {
            errorMessages = new ArrayList();
            
            cp = new Microsoft.CSharp.CSharpCodeProvider();
            ic = cp.CreateCompiler();
            cpar = new System.CodeDom.Compiler.CompilerParameters();
            cpar.GenerateInMemory = true;
            cpar.GenerateExecutable = false;
            cpar.ReferencedAssemblies.Add(Application.StartupPath + "\\system.dll");
            cpar.ReferencedAssemblies.Add(Application.StartupPath + "\\System.Windows.Forms.dll");
            //cpar.ReferencedAssemblies.Add("NationalInstruments.Analysis.Enterprise.dll");
            cpar.ReferencedAssemblies.Add(Application.StartupPath +"\\AppleLabApplication.dll");//添加可执行文件名
            cpar.ReferencedAssemblies.Add(Application.StartupPath + "\\ClsStaticStation.dll");//添加可执行文件名

            
            calcstring = "";
            list = new ListBox();
            text = new TextBox();
            text.Multiline = true;
            //cpar.ReferencedAssemblies.Add(AppDomain.CurrentDomain.FriendlyName);


        }


       

        public void InitArray(string s,int count)
        {
            int istart;
            int iend;
            int i,j;
            string mys;
            string[] s1;
            mys = s;

            for (i = 1; i <= GlobeVal.filesave.muserchannel.Count; i++)
            {
                mys  = mys  + " " + GlobeVal.filesave.muserchannel[i - 1].channelname;

            }


           
            char[] a;
            a=new char[1];
            a[0] = Convert.ToChar(" ");
            s1 = mys.Split(a);

            istart = list.FindString("//var array begin" + "\r\n");
            iend = list.FindString("//var array end" + "\r\n");
           
           

            mys = "";

            

            for (i = 0; i < s1.Length; i++)
            {
                mys = mys + "public double[] " + s1[i] +";"+ "\r\n";


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

                    mys = mys + "//calcchannel begin"+ (i+1).ToString().Trim()+"\r\n";
                    istart = istart + 1;
                    list.Items.Insert(istart, mys);

                    mys = "";
                    mys = mys +"//calcchannel end" + (i+1).ToString().Trim() + "\r\n";

                    istart = istart + 1;
                    list.Items.Insert(istart, mys);

                    mys = "";

                    mys = mys + "GlobeVal.m_calcdata["+ i.ToString().Trim()+"][j] =结果;";
                    mys = mys + "\r\n}\r\n";

            }

           
            

          

           
            //for (i = s1.Length - GlobeVal.filesave.muserchannel.Count; i < s1.Length; i++)
            {
               // mys = mys + s1[i] + " = GlobeVal.m_calcdata[" + (i-(s1.Length - GlobeVal.filesave.muserchannel.Count)).ToString().Trim() + "];" + "\r\n";
            }
           


            mys = mys + "数组长度=" + (GlobeVal.m_len).ToString() +";"+"\r\n";


            for (i = istart + 1; i <= iend - 1; i++)
            {
                list.Items.RemoveAt(istart + 1);

            }
            istart = istart + 1;
            list.Items.Insert(istart, mys);

            
            


        }


     
        public void InitBegin()
        {
            int i;

            

            list.Items.Clear();
            list.Items.Add("using System;" + "\r\n");
            list.Items.Add("using CComLibrary;\r\n");
            list.Items.Add("using System.Windows.Forms;\r\n");
            list.Items.Add("using ClsStaticStation;\r\n");

            list.Items.Add("class myclass:CComLibrary.MyClassBase" + "\r\n");
            list.Items.Add("{" + "\r\n");
            list.Items.Add("public Boolean  有效=false;\r\n "); 
            list.Items.Add("public const int 单坐标=0;\r\n");
            list.Items.Add("public const int 双坐标=1;\r\n");
            list.Items.Add("public const int 曲线1=1;\r\n");
            list.Items.Add("public const int 曲线2=2;\r\n");
            list.Items.Add("public const int 曲线3=3;\r\n");
            list.Items.Add("public const int 曲线4=4;\r\n");
            list.Items.Add("public const int 曲线5=5;\r\n");
            list.Items.Add("public const int 曲线6=6;\r\n");
            list.Items.Add("public const int 曲线7=7;\r\n");
            list.Items.Add("public const int 曲线8=8;\r\n");
            list.Items.Add("public const int 左轴=0;\r\n");
            list.Items.Add("public const int 右轴=1;\r\n");
            list.Items.Add("public const int 底轴=2;\r\n");

            list.Items.Add("public const bool 不画特征点=false;\r\n");
            list.Items.Add("public const bool 画特征点=true;\r\n");





            list.Items.Add("public double abs(double v)" + "\r\n");
            list.Items.Add("{ return Math.Abs(v);}" + "\r\n");
            list.Items.Add("public double sin(double v) {return Math.Sin(v);}" + "\r\n");
            list.Items.Add("public double cos(double v) {return Math.Cos(v);}" + "\r\n");
            list.Items.Add("public double ceiling(double v) {return Math.Ceiling(v);}" + "\r\n");
            list.Items.Add("public double exp(double v) {return Math.Exp(v);}" + "\r\n");
            list.Items.Add("public double power(double x,double y) {return  Math.Pow(x,y);}" + "\r\n");
            list.Items.Add("public double sqrt(double v) {return  Math.Sqrt(v);}" + "\r\n");
            list.Items.Add("public int 取整(double v) {return Convert.ToInt32(v);}"+"\r\n");
            list.Items.Add("public double 修约(double v,int l){return Math.Round(v,l);}" + "\r\n"); 
            list.Items.Add("public double maxpeak(int starti,int endi,double[] v)" + "\r\n" + "{ return  GlobeVal._funmax(starti,endi,v); }" + "\r\n");
            list.Items.Add("public double 屈服(double[] x,double[] y,bool mdraw)" + "\r\n" + " {  double v;  int i;\r\n  GlobeVal._yield(x,y, mdraw, out v,out i);\r\n return v; \r\n}\r\n");
            list.Items.Add("public double 弹模(double[] x,double[] y,bool mdraw) \r\n {double mslope; double a;double b; \r\n GlobeVal._automodule(x,y,mdraw, out mslope, out a, out b); return mslope;\r\n}\r\n");
            list.Items.Add("public double 杨氏弹模(double[] x,double[] y,bool mdraw)\r\n{ double mslope;int starti;int endi;\r\n GlobeVal._autoYoungModulus(x,y,mdraw,out mslope, out starti, out endi); return mslope;\r\n}\r\n");

            list.Items.Add("public double 曲线拟合(double[] x,double[] y) \r\n {double mslope; \r\n GlobeVal._fit(x,y,out mslope); return mslope;\r\n}\r\n");

            list.Items.Add("public double 弦向弹模(double[] x,double[] y,double startx,double endx)\r\n{ double mslope;int starti;int endi;\r\n GlobeVal._chordmodulus(x,y,startx,endx,out mslope, out starti, out endi); return mslope;\r\n}\r\n");

            list.Items.Add("public double 预设点(double[] setx,double[] calcy,double setvalue,bool mdraw)\r\n{ double t; GlobeVal._presetcalc(setx,calcy,setvalue,out t,mdraw); return t;}\r\n");

            list.Items.Add("public void 坐标轴设置(int 参数) \r\n");

            list.Items.Add("{ GlobeVal.m_mainform.设置坐标(参数);}\r\n");

            list.Items.Add("public void 消息框(string 参数) \r\n");
            list.Items.Add("{ GlobeVal._消息框(参数);}\r\n");

            list.Items.Add("public void 调试输出(string 参数) \r\n");
            list.Items.Add("{ GlobeVal._调试输出(参数);}\r\n");

            list.Items.Add("public void 清除曲线(int 曲线号) \r\n");
            list.Items.Add("{ GlobeVal._清除曲线(曲线号);}\r\n");

            list.Items.Add("public void 设置曲线Y坐标轴(int 曲线号,int Y轴) \r\n");
            list.Items.Add("{ GlobeVal._设置曲线Y坐标轴(曲线号,Y轴);}\r\n");

            list.Items.Add("public void 闭合曲线(int 曲线号) \r\n");


            list.Items.Add("{ GlobeVal._闭合曲线(曲线号) ;}" + "\r\n");

            list.Items.Add("public void 坐标轴标题(int 坐标轴,string 标题) \r\n");
            list.Items.Add("{ GlobeVal._坐标轴标题(坐标轴,标题);}"+ "\r\n");
            list.Items.Add("public void 曲线标题(string 标题) \r\n");
            list.Items.Add("{GlobeVal._曲线标题(标题);}"+"\r\n");



  
            list.Items.Add("public void 画XY曲线(double[] x,double[] y ,int 曲线号) \r\n");


            list.Items.Add("{ GlobeVal.m_mainform.plotxy(x,y,曲线号) ;}" + "\r\n");

            list.Items.Add("public void 画XY点(double x,double y,int 曲线号) \r\n");

            list.Items.Add("{ GlobeVal.m_mainform.plotxypoint(x,y,曲线号) ;}" + "\r\n");

            list.Items.Add("public void 清除所有曲线()\r\n");
            list.Items.Add("{ GlobeVal.m_mainform.clearxy();}\r\n");

            list.Items.Add("public double 结果=0;" + "\r\n");
            list.Items.Add("public int 数组长度=0;" + "\r\n");
            list.Items.Add("public int 索引=0;" + "\r\n");


            list.Items.Add("public int debug1=-1;" + "\r\n");


            list.Items.Add("//var array begin" + "\r\n");


            list.Items.Add("//var array end" + "\r\n");


             list.Items.Add("//ResultHard begin"+"\r\n");
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


            list.Items.Add("//hardvar begin"+"\r\n");
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
            i = istart+1;
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
            this.RefreshDebug通道("debug1=" + "count" + ";\r\n");

            this.msource = expr;
            s1 = "if (debug1==" + count.ToString().Trim()  + ")\r\n" + "{\r\n" + expr + "\r\n" +
               "if (System.Double.IsNaN(结果)==true){结果=0;}\r\n" +
                "CalcedChannelResult[" + count.ToString().Trim() + "]=结果;" + "\r\n}";


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
            string  s1;

            

            int istart;
            int iend;
            int i;
            this.RefreshDebug("debug1=" + "count"+";\r\n");

            this.msource = expr;
            s1 = "if (debug1==" + count.ToString().Trim() + ")\r\n" + "{\r\n" + expr + "\r\n" +
               "if (System.Double.IsNaN(结果)==true){结果=0; 有效=false; }\r\n"+
                 "else { 有效=true;  }\r\n"+
                "  CalcedChannelResult[" + count.ToString().Trim() + "]=结果;" +"m_Global.mvalid=有效;" + "\r\n}";
                 

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
            int j=0;

            string[] m ;

            sp=new char[3];
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

             //   GlobeVal.m_richtextbox.SaveFile("d:\\a.rtf");
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
            
            if (cr.Errors.Count >0) 

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

                        GlobeVal.errorline=j;

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
        public void    calc()
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

        public static int formulakind =0;
        public static bool m_test = false;
        public static  MainForm m_mainform;
        public static RichTextBox m_outputwindow;
        public static Compenkie.RichTextBoxExtend m_richtextbox;
        public static RichTextBox m_calc_outputwindow;

        public static double[][] m_data;
        public static double[][] m_calcdata;

        public static double[] m_channeldata;
        public static int m_i=0;

        public static string  mptprocedurepath;

        public static string _试验方法;
        public static string _文件类型;
        public static int m_len;
        public static string _programname;
        public static string  _programstring; 

        public static  CComLibrary.FileStruct filesave;
        public static string currentfilesavename;
        public static  List<CComLibrary.Rule> mrule = new List< CComLibrary.Rule >();
        public static  List<CComLibrary.SystemPara> msyspara=new List<SystemPara>();
        public static List<CComLibrary.Rule> mfunc = new List<Rule>();
        public static List<CComLibrary.Rule> mconst = new List<Rule>();

        //public static CComLibrary.MathExpressionParser gparser = new CComLibrary.MathExpressionParser();

        public static string[]  g_datatitle;
        public static string[]  g_dataunit;
        //public   System.Array   g_data;
        public static  System.Array l_Array;
        public static int g_datalen=0;
        public static int g_colcount = 0;
        public static double[][] g_datadraw;

        public static int  xsel;
        public static int  ysel;

        public static int[] ysels;
        public static int[] yselpostion;

        public static int yselcount = 0;

        public static  SampleProject.Extensions.GridArray[] outgrid;

        private static  void Init_SystemPara通道()
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
                b.Name = CComLibrary.GlobeVal.filesave.m_namelist[j] + "通道";

                b.replaceName = b.Name;
                if (CComLibrary.GlobeVal.filesave.m_namelist[j] == "负荷")
                {
                    s = s + "public double " + b.replaceName + "=" + "ClsStaticStation.m_Global.mload" + ";" + "\r\n";
                }

                else if (CComLibrary.GlobeVal.filesave.m_namelist[j] == "位移")
                {
                    s = s + "public double " + b.replaceName + "=" + "ClsStaticStation.m_Global.mpos" + ";" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_namelist[j] == "变形")
                {
                    s = s + "public double " + b.replaceName + "=" + "ClsStaticStation.m_Global.mext" + ";" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_namelist[j] == "时间")
                {
                    s = s + "public double " + b.replaceName + "=0;" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_namelist[j] == "围压压力")
                {
                    s = s + "public double " + b.replaceName + "=" + "ClsStaticStation.m_Global.mload1" + ";" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_namelist[j] == "围压位移")
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
                    if (CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem[i].cName != "无")
                    {
                        b = new CComLibrary.SystemPara();
                        b.Name = CComLibrary.GlobeVal.filesave.mshapelist[j].shapename + "_" +
                            CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem[i].cName;
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
                b.Name = CComLibrary.GlobeVal.filesave.m_namelist[j] + "通道";

                b.replaceName = b.Name;
                if (CComLibrary.GlobeVal.filesave.m_namelist[j] == "负荷")
                {
                    s = s + b.replaceName + "=" + "ClsStaticStation.m_Global.mload" + ";" + "\r\n";
                }

                else if (CComLibrary.GlobeVal.filesave.m_namelist[j] == "位移")
                {
                    s = s + b.replaceName + "=" + "ClsStaticStation.m_Global.mpos" + ";" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_namelist[j] == "变形")
                {
                    s = s + b.replaceName + "=" + "ClsStaticStation.m_Global.mext" + ";" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_namelist[j] == "时间")
                {
                    s = s + b.replaceName + "=0;" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_namelist[j] == "围压压力")
                {
                    s = s  + b.replaceName + "=" + "ClsStaticStation.m_Global.mload1" + ";" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_namelist[j] == "围压位移")
                {
                    s = s  + b.replaceName + "=" + "ClsStaticStation.m_Global.mpos1" + ";" + "\r\n";
                }



            }

            CComLibrary.GlobeVal.gcalc.refreshhardglobe(s);

            s = "";
            for (i = 0; i < CComLibrary.GlobeVal.filesave.moutput.Count; i++)
            {
                b = new CComLibrary.SystemPara();
                b.Name = CComLibrary.GlobeVal.filesave.moutput[i].formulaname;
                b.replaceName = b.Name;
                s = s + "public  double " + b.replaceName + "= 0" + ";" + "\r\n";
                CComLibrary.GlobeVal.msyspara.Add(b);
            }


            CComLibrary.GlobeVal.gcalc.refreshresulthard(s);


        }
        public static void InitUserCalcChannel() //初始化用户自定义通道
        {
            int j;
            CComLibrary.GlobeVal.gcalc.Initialize通道();
            
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
            double m=0;

            return m;
        }


        public static int errorline=-1;
       
        

        public static List<LineStruct> m_listline = new List<LineStruct>();

        /// <summary>
        /// 对一组点通过最小二乘法进行线性回归
        /// </summary>
        /// <param name="parray"></param>
        public static void LinearRegression(Point[] parray,out double  slope)
        {
            //点数不能小于2
            if (parray.Length < 2)
            {
                //Console.WriteLine("点的数量小于2，无法进行线性回归");
                //return;
                if ((parray[1].X - parray[0].X) == 0)
                {
                    slope = 0;
                }
                else
                {
                    slope = (parray[1].Y - parray[0].Y) / (parray[1].X - parray[0].X);
                }
            }
            else
            {

                //求出横纵坐标的平均值
                double averagex = 0, averagey = 0;
                foreach (Point p in parray)
                {
                    averagex += p.X;
                    averagey += p.Y;
                }
                averagex /= parray.Length;
                averagey /= parray.Length;
                //经验回归系数的分子与分母
                double numerator = 0;
                double denominator = 0;
                foreach (Point p in parray)
                {
                    numerator += (p.X - averagex) * (p.Y - averagey);
                    denominator += (p.X - averagex) * (p.X - averagex);
                }
                //回归系数b（Regression Coefficient）
                double RCB = numerator / denominator;
                //回归系数a
                double RCA = averagey - RCB * averagex;
                slope = RCB;

                // Console.WriteLine("回归系数A： " + RCA.ToString("0.0000"));
                // Console.WriteLine("回归系数B： " + RCB.ToString("0.0000"));
                // Console.WriteLine(string.Format("方程为： y = {0} + {1} * x",
                //  RCA.ToString("0.0000"), RCB.ToString("0.0000")));
                //剩余平方和与回归平方和
                double residualSS = 0;  //（Residual Sum of Squares）
                double regressionSS = 0; //（Regression Sum of Squares）
                foreach (Point p in parray)
                {
                    residualSS +=
                      (p.Y - RCA - RCB * p.X) *
                      (p.Y - RCA - RCB * p.X);
                    regressionSS +=
                      (RCA + RCB * p.X - averagey) *
                      (RCA + RCB * p.X - averagey);
                }
            }
            //Console.WriteLine("剩余平方和： " + residualSS.ToString("0.0000"));
            //Console.WriteLine("回归平方和： " + regressionSS.ToString("0.0000"));
        }
        //拟合求斜率
        public static double _fit(double[] x, double[] y,out double slope)
    {
        double t=0;
        double t1;
        int l = y.Length;

        
        //LinearRegression(array,out t);
        if (x.Length > 2)
        {
            CurveFit.LinearFit(x, y, FitMethod.LeastSquare, out t, out t1, out t1);
        }
        slope = t;

        return 0;
    }

        public static void _曲线标题(string s)
        {
            CComLibrary.GlobeVal.m_mainform.scatterGraph1.Caption =s;
        }
        //
        public static void _坐标轴标题(int c, string s)
        {
            if (c == 0)
            {
                CComLibrary.GlobeVal.m_mainform.scatterGraph1.YAxes[0].Caption = s;  
            }
            if (c == 1)
            {
                CComLibrary.GlobeVal.m_mainform.scatterGraph1.YAxes[1].Caption = s;  
            }
            if (c == 2)
            {
                CComLibrary.GlobeVal.m_mainform.scatterGraph1.XAxes[0].Caption  = s;  
            }
        }

        public static void  _消息框(string s)
        {
            MessageBox.Show(s); 
        }

        public static void _调试输出(string s)
        {
            if (CComLibrary.GlobeVal.m_test == true)
            {
                CComLibrary.GlobeVal.m_calc_outputwindow.Text =
                    CComLibrary.GlobeVal.m_calc_outputwindow.Text + s+"\r\n";
            }
            else
            {
                CComLibrary.GlobeVal.m_outputwindow.Text =
                    CComLibrary.GlobeVal.m_outputwindow.Text + s+"\r\n";
            }

        }

        public static void _闭合曲线(int c)
        {
            double x;
            double y;
            CComLibrary.GlobeVal.m_mainform.scatterGraph1.Plots[c - 1].GetDataPoint(0, out x, out y);
            CComLibrary.GlobeVal.m_mainform.scatterGraph1.Plots[c - 1].PlotXYAppend(x, y); 
        }
        public static void _清除曲线(int c)
        {
            CComLibrary.GlobeVal.m_mainform.scatterGraph1.Plots[c - 1].ClearData();
         

        }

        public static void _设置曲线Y坐标轴(int c,int t)
        {
            if (t == 0)
            {
                CComLibrary.GlobeVal.m_mainform.scatterGraph1.Plots[c - 1].YAxis =

                    CComLibrary.GlobeVal.m_mainform.scatterGraph1.YAxes[0];
            }
            else
            {
                CComLibrary.GlobeVal.m_mainform.scatterGraph1.Plots[c - 1].YAxis =

                    CComLibrary.GlobeVal.m_mainform.scatterGraph1.YAxes[1];
            }


        }

        //插值函数
        public static double _Interpolant(double x1, double y1, double x2, double y2,double x)
        {

            double[] xData = new double[2];
            double[] yData = new double[2];
            double[] secondDerivatives;
            double initialBoundary, finalBoundary, xValue, interpValue=0;


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
                secondDerivatives = CurveFit.SplineInterpolant(xData, yData, initialBoundary, finalBoundary);


                // Calculate spline interpolated value  
                interpValue = CurveFit.SplineInterpolation(xData, yData, secondDerivatives, xValue);
            }

            return interpValue;
        }
        public static bool _presetcalc(double[] setx, double[] calcy, double setvalue, out double calcvalue,bool draw)
        {
            int i;
            int mindex;
            bool b;
            double x1=0, x2=0, y1=0, y2=0;

            b = false;
            calcvalue = 0;
            for (i = 1; i < m_len-2; i++)
            {
                if (setx[i] >= setvalue)
                {
                    mindex = i;
                    calcvalue = calcy[i];
                    x1=setx[i-1];
                    x2=setx[i+1];
                    y1 = calcy[i - 1];
                    y2 = calcy[i + 1];
                    calcvalue=_Interpolant(x1, y1, x2, y2, setvalue);

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

        public static bool _chordmodulus(double[] x, double[] y,  double startx,double endx, out double value, out int starti, out int endi)
        {
            int i;
            double starty=0;
            double endy=0;

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
                if (x[i] >= endx )
                {
                    endy = y[i];
                    mendi = i;
                    break;
                }
            }

            starti = mstarti;
            endi = mendi;
            value = (starty -endy)/(startx-endx);
            return false;
        }
        public static bool _autoYoungModulus(double[] x, double[] y, bool mdraw, out double value, out int starti, out int endi)
        {
            double yieldvalue;
            int yieldindex;
            bool b;
            double xa=0;
            double xb=0;
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
 
            b = _yield(x, y, false, out yieldvalue, out yieldindex);

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

                CurveFit.LinearFit(inputx, inputy, FitMethod.LeastSquare, out mslope, out mintercept, out mresidue);
                mslopev[i - 1] = mslope;
                minterceptv[i - 1] = mintercept; 

                CComLibrary.GlobeVal.m_outputwindow.Text = CComLibrary.GlobeVal.m_outputwindow.Text +"Young Modules " + mslope.ToString() + " " + mintercept.ToString() + "\r\n";

            }

          
            value = Statistics.Mean(mslopev);
           
            starti = 0;
            endi = 0;

            xa = Statistics.Mean(mslopev);
            xb = Statistics.Mean(minterceptv);

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
        public static bool _automodule(double[] x, double[] y, bool mdraw, out double value,out double  a , out double b )
        {
            double yieldvalue;
            int yieldindex;
            
           
            int i;
            int k;

            double[] inputx;
            double[] inputy;

            double[] mx;
            int[] mxi;

            double mslope=0;
            double  mintercept=0;
            double   mresidue=0;

            double[] mslopev;

            double[] minterceptv;

            mx=new double[8]; 
            mxi =new int[8]; 
            mslopev =new double[7];
            minterceptv = new double[7]; 
           _yield(x, y, false, out yieldvalue,  out yieldindex);
           
                mxi[0] = 0;
                for (i = 1; i <= 7; i++)
                {
                    mx[i] = x[0];
                    for (k = 0; k <= yieldindex; k++)
                    {
                        if (x[k] >= x[yieldindex] / 7.0 * i)
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

                        CurveFit.LinearFit(inputx, inputy, FitMethod.LeastSquare, out mslope, out mintercept, out mresidue);
                    }
                    mslopev[i-1]=mslope;
                    minterceptv[i-1]=mintercept;  

                    CComLibrary.GlobeVal.m_outputwindow.Text = CComLibrary.GlobeVal.m_outputwindow.Text + mslope.ToString() + " "+ mintercept.ToString()+   "\r\n";

                }
                  


                value = Statistics.Mean(mslopev);

                a = Statistics.Mean(mslopev) ;
                b = Statistics.Mean(minterceptv) ;

                if (mdraw == true)
                {
                    LineStruct l = new LineStruct();
                    l.kind = 1;
                    l.xstart = x[yieldindex] *0.1;
                    l.ystart = a*l.xstart +b;

                    l.xend   =x[yieldindex] * 0.9;
                    l.yend = a * l.xend + b;
               
                    m_listline.Add(l);

                }
               
            return false;
        }

        public static bool   _yield(double[] x, double[] y, bool mdraw,  out double value,out int  index)
        {
        
            int i;
            int k;
            int maxindex=0;
            double max;
            double[] mk;
            int [] mkstart;
            int[] mkend;
            int segcount = 0;
            int j=0;
            int  a=0;
            bool b=false ;
            int bi = 0;
            double mvalue=0;
            int mindex=0;
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

            segcount =100;
            mk = new double[segcount];
            mkstart = new  int[segcount];
            mkend = new int[segcount]; 
            j=0;
            a=0;
            k=0;
            for (i = 0; i <segcount; i++)
            {
                
                while  (x[a + k] - x[a] <= xx)
                {
                    k=k+1;
                    if (a+k >= m_len - 2)
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

            b = false;
            for (i = 0; i < segcount; i++)
            {
                if (mk[i] < 0)
                {
                    bi = i-1;
                    

                    b = true;
                    break;
                }
            }

            if (b == false)
            {
                value =max;
                index = maxindex;
                return b;
            }



            mvalue = y[mkstart[bi]];
            for (i = mkstart[bi]; i <  mkend[bi+1]; i++)
            {
                if (y[i] >= mvalue)
                {
                    mvalue = y[i];
                    mindex =i;
                    
                }
            }


            value=mvalue;
            index = mindex;

            

            if (mdraw == true)
            {
                LineStruct l = new LineStruct();
                l.kind = 0;
                l.indexstart = index;
                m_listline.Add(l);
            }

            return b;
            
            
           
        }
        public static  double _funmax(int starti, int endi, double[] value)
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
        }

        public string OperaWordsName;
        public string replaceName;
        public string kind; //类型
        public string explain;//说明
        public int count;//参数数量
        public string[] paraname;//参数名称
        public string[] parakind;//参数类型



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
            int  i;
            textgrid = new string[rowcount][];

            for (i = 0; i <rowcount ; i++)
            {
                textgrid[i] = new string[colcount]; 
            }

        }


        public int colcount = 0;
        public int rowcount=0;

        public int[] namecol;
        public int[] namerow;
        public int[] valuecol;
        public int[] valuerow;

        public string[][] textgrid;
       


    }

    public class xyaa :  NationalInstruments.UI.XYRangeAnnotation
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


