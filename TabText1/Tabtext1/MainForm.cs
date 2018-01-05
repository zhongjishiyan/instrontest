using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using NationalInstruments.UI;
using System.Drawing.Printing;
using System.Data.OleDb; 
using System.Collections;
using NationalInstruments.Analysis;
using NationalInstruments.Analysis.Conversion;
using NationalInstruments.Analysis.Dsp;
using NationalInstruments.Analysis.Dsp.Filters;
using NationalInstruments.Analysis.Math;
using NationalInstruments.Analysis.Monitoring;
using NationalInstruments.Analysis.SignalGeneration;
using NationalInstruments;
using System.Drawing.Imaging;
using Word = Microsoft.Office.Interop.Word;

using System.Runtime.InteropServices;
using System.Threading;

namespace AppleLabApplication
{
   
    public partial class MainForm : Form
    {
        public Boolean formloaded = false;
        //一个试验过程对应多个计算过程
        public List<string> g_namelist;//样本通道名称
        public List<string> g_signnamelist;//样本通道符号名称
        public string g_datafilepath;//数据文件路径
        public string gmptpath = "";//工程文件保存路径
        public string gmptprocedurepath = "";//试验过程保存路径
        public string gmethodname = "";//要计算的方法名称
        public int gtestkind = 0;//要计算的方法类型
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);

        SheetView _SheetView;
        SheetView _SheetView1;
        Panel  outputwindow1;
        UResultControl  _UResultControl;
        RichTextBox outputwindow2;





       
        private Point mP7;
        private Point mP8;
        private PointF mP7F;
        private PointF mP8F;

        private Boolean mtsbtext_bool = false;
        private Boolean mtsbtext_begin = false;

        ZBobb.AlphaBlendTextBox mabtext;



        private Point mP1;
        private Point mP2;
        private PointF mP1F;
        private PointF mP2F;

        private Boolean mtsbarrow_bool=false ;
        private Boolean mtsbarrow_begin = false;



        private Point mP3;
        private Point mP4;
        private PointF mP3F;
        private PointF mP4F;

        private Boolean mtsbline_bool = false;
        private Boolean mtsbline_begin = false;



        private Point mP5;
        private Point mP6;
        private PointF mP5F;
        private PointF mP6F;

        private Boolean mtsbrect_bool = false;
        private Boolean mtsbrect_begin = false;

        Rectangle lastRect = Rectangle.Empty;

        private Point mP9;
        private Point mP10;
        private PointF mP9F;
        private PointF mP10F;

        private Boolean mtsbpoint_bool = false;
        private Boolean mtsbpoint_begin = false;


        private Point mP11;
        private Point mP12;
        private PointF mP11F;
        private PointF mP12F;

        private Boolean mtsbcontrol_bool = false;
        private Boolean mtsbcontrol_begin = false;


        
        /// <summary>      
        /// 释放内存      
        /// </summary>      
        public static void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }  

        public MainForm()
        {
            InitializeComponent();

            g_namelist = new List<string>();
            g_signnamelist = new List<string>();
            Application.DoEvents();

            
        }

     
      


        public  void HighlightDataPoint(AfterDrawXYPlotEventArgs e, double x, double y)
        {
            Graphics g = e.Graphics;
            PointF mappedPoint = e.Plot.MapDataPoint(e.Bounds, x, y);
            Rectangle bounds = new Rectangle((int)(mappedPoint.X - 8), (int)(mappedPoint.Y - 8), 16, 16);

            using (Brush brush = new SolidBrush(Color.FromArgb(128, Color.Red)))
            {
                g.FillEllipse(brush, bounds);
            }

            g.DrawEllipse(Pens.Yellow, bounds);
        }

        private void 新建NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openprojectfile(); 
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void RefreshUResultControl()
        {
            ColumnHeader c;
            ListViewItem b;
            int i = 0;
            int j = 0;
            int k = 0;
          
           
          

            SampleProject.Extensions.GridBarChart gridBarChart1;


            gridBarChart1 = new SampleProject.Extensions.GridBarChart();
            CComLibrary.inputitem aa = new CComLibrary.inputitem();

            for (i = 0; i < CComLibrary.GlobeVal.filesave.minput.Count; i++)
            {


                aa = CComLibrary.GlobeVal.filesave.minput[i];
                gridBarChart1.Bars.Add(new SampleProject.Extensions.ChartBar(aa.name, aa.value, aa.unit,aa.dimsel, Color.Red, Color.White));
            }



            _UResultControl.listEditor1.List = new ArrayList(gridBarChart1.Bars);
            _UResultControl.listEditor1.ItemType = typeof(SampleProject.Extensions.ChartBar);
            _UResultControl.listEditor1.LoadList();



          
           

            /*
            for (i = 0; i < CComLibrary.GlobeVal.filesave.mcalcpanel.colcount; i++)
            {
               
                if (i < CComLibrary.GlobeVal.filesave.mcalcpanel.colcount -1)
                {
                    _UResultControl.listView1.Columns.Add("", 220, HorizontalAlignment.Left);
                }
                else
                {
                    _UResultControl.listView1.Columns.Add("", -2, HorizontalAlignment.Left);
                }
                
            }


            for (i = 0; i < CComLibrary.GlobeVal.filesave.mcalcpanel.rowcount; i++)
            {
                b = new ListViewItem();

                b.Text = "";

                b.BackColor = Color.White;

                for (j = 0; j < CComLibrary.GlobeVal.filesave.mcalcpanel.colcount; j++)
                {
                    b.SubItems.Add("");
                }

                for (j = 0; j < CComLibrary.GlobeVal.filesave.mcalcpanel.colcount; j++)
                {

                    b.SubItems[j].Text = CComLibrary.GlobeVal.filesave.mcalcpanel.textgrid[i][j];

                    for (k = 0; k < CComLibrary.GlobeVal.filesave.moutput.Count; k++)
                    {
                        if ("[" + CComLibrary.GlobeVal.filesave.moutput[k].formulaname + "]" == CComLibrary.GlobeVal.filesave.mcalcpanel.textgrid[i][j])
                        {

                            b.SubItems[j].Text = CComLibrary.GlobeVal.filesave.moutput[k].formulaname + "[" + CComLibrary.GlobeVal.filesave.moutput[k].formulaunit + "]";
 
                                


                        }

                        if ("{" + CComLibrary.GlobeVal.filesave.moutput[k].formulaname + "结果}" == CComLibrary.GlobeVal.filesave.mcalcpanel.textgrid[i][j])
                        {

                            b.SubItems[j].Text = "";


                        }



                    }

                }
                _UResultControl.listView1.Items.Add(b);
            }


            */
        }

        public void openprojectfile_(string filename)
        {
            int i = 0;
            string[] ss;

            FormMethod f = new FormMethod();
            f.loadfile(filename);
            f.mmptpath = this.gmptpath;


            f.filesave.m_namelist = this.g_namelist;
            f.filesave.m_signnamelist = this.g_signnamelist;
            f.filesave.datapath = this.g_datafilepath;

            f.ShowDialog();

            toolStripCboKind.SelectedIndex = f.filesave.methodkind;

            tcboproject.Items.Clear();

            ss = Directory.GetFiles(this.gmptpath+ClsStaticStation.m_Global.mycls.TestkindList[toolStripCboKind.SelectedIndex]);


            for (i = 0; i < ss.Length; i++)
            {
                tcboproject.Items.Add(Path.GetFileNameWithoutExtension(ss[i]));


            }

            for (i = 0; i < ss.Length; i++)
            {
                if (CComLibrary.GlobeVal.filesave.methodname == Path.GetFileNameWithoutExtension(ss[i]))
                {
                    tcboproject.SelectedIndex = i;
                }
            }


            RefreshUResultControl();

        }
        public void openprojectfile()
        {

            int i = 0;
            string[] ss;

           
            

            FormMethod f = new FormMethod();
            

            f.mmptpath = this.gmptpath;

            
            f.filesave.m_namelist = this.g_namelist;
            f.filesave.m_signnamelist = this.g_signnamelist;
            f.filesave.datapath = this.g_datafilepath;
 

            f.ShowDialog();





            tcboproject.Items.Clear();

            ss = Directory.GetFiles(this.gmptpath + "\\" + ClsStaticStation.m_Global.mycls.TestkindList[toolStripCboKind.SelectedIndex] + "\\");


            for (i = 0; i < ss.Length; i++)
            {
                tcboproject.Items.Add(Path.GetFileNameWithoutExtension(ss[i]));


            }

            for (i = 0; i < ss.Length; i++)
            {
                if (CComLibrary.GlobeVal.filesave.methodname == Path.GetFileNameWithoutExtension(ss[i]))
                {
                    tcboproject.SelectedIndex = i;
                }
            }


            RefreshUResultControl();


        }

        private void tsbnewproject_Click(object sender, EventArgs e)
        {
            openprojectfile(); 
 
        }

        public void reset()
        {
            int i;
            for (i = 0; i < scatterGraph1.Plots.Count; i++)
            {
                scatterGraph1.Plots[i].ClearData() ;
            }

            try
            {
                Type l_Type;
                l_Type = typeof(string);

                System.Array l_Array = Array.CreateInstance(l_Type, 100 + 3, 2);

                //  l_Array.SetValue("abc", 0, 0); 



                CComLibrary.GlobeVal.outgrid[0].LoadDataSource(l_Array);








            }
            catch (Exception err)
            {
                SourceLibrary.Windows.Forms.ErrorDialog.Show(this, err, "Error");
            }
              
        }
        public void InitKind()
        {
            int i;

            
                toolStripCboKind.SelectedIndex = this.gtestkind;
           
           
                for (i = 0; i < tcboproject.Items.Count ; i++)
                {
                    if (this.gmethodname == Convert.ToString(  tcboproject.Items[i]))
                    {
                        tcboproject.SelectedIndex = i;
                    }
                }
            
            
        }
        public void Form2_Load(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.mscattergraph = scatterGraph1;

           scatterGraph1.Annotations.Clear();
            if  (formloaded ==false)
            {
                formloaded = true;
            }
           else
            {
                return;
            }

           

            int i;

            string[] ss;

            int c = ClsStaticStation.m_Global.mycls.TestkindList.Count;
            toolStripCboKind.Items.Clear();
            for (i = 0; i < c; i++)
            {
                toolStripCboKind.Items.Add(ClsStaticStation.m_Global.mycls.TestkindList[i]);
                if (Directory.Exists(CComLibrary.GlobeVal.mptprocedurepath + "\\" + ClsStaticStation.m_Global.mycls.TestkindList[i]) == true)
                {
                    Directory.CreateDirectory(CComLibrary.GlobeVal.mptprocedurepath + "\\" + ClsStaticStation.m_Global.mycls.TestkindList[i]);

                }
            }
            if (tsbeditproject.Enabled == false)
            {
                toolStripCboKind.SelectedIndex = this.gtestkind;
            }
            else
            {
                toolStripCboKind.SelectedIndex = 0;
            }

            toolStrip2.RenderMode = ToolStripRenderMode.System;


            CComLibrary.GlobeVal.g_datatitle = new string[30];
            CComLibrary.GlobeVal.g_dataunit = new string[30];

       
            CComLibrary.GlobeVal.m_richtextbox = new Compenkie.RichTextBoxExtend();
            CComLibrary.GlobeVal.ysels = new int[10];
            CComLibrary.GlobeVal.yselpostion = new int[10];

            CComLibrary.GlobeVal.filesave = new CComLibrary.FileStruct();
            CComLibrary.GlobeVal.filesave.ysels = new int[10];
            CComLibrary.GlobeVal.filesave.yselpostion = new int[10];

            for (i = 0; i < scatterGraph1.Plots.Count; i++)
            {
                scatterGraph1.Plots[i].HistoryCapacity = 1000000;

            }

            CComLibrary.GlobeVal.outgrid = new SampleProject.Extensions.GridArray[10];

            for (i = 0; i < 10; i++)
            {
                CComLibrary.GlobeVal.outgrid[i] = new SampleProject.Extensions.GridArray();
                CComLibrary.GlobeVal.outgrid[i].Visible = false;
                CComLibrary.GlobeVal.outgrid[i].BorderStyle = BorderStyle.None;
                CComLibrary.GlobeVal.outgrid[i].Dock = DockStyle.Fill;
            }



            tcboproject.Items.Clear();

            ss = Directory.GetFiles(this.gmptpath + "\\" + ClsStaticStation.m_Global.mycls.TestkindList[toolStripCboKind.SelectedIndex]);


            for (i = 0; i < ss.Length; i++)
            {
                tcboproject.Items.Add(Path.GetFileNameWithoutExtension(ss[i]));
            }

            if (tsbeditproject.Enabled == false)
            {
                for (i = 0; i < ss.Length; i++)
                {
                    if (this.gmethodname == Path.GetFileNameWithoutExtension(ss[i]))
                    {
                        tcboproject.SelectedIndex = i;
                    }
                }
            }
            else
            {
                if (tcboproject.Items.Count > 0)
                {
                    tcboproject.SelectedIndex = 0;
                }
            }

            _SheetView = new SheetView();
            _SheetView.Dock = DockStyle.Bottom;
            _SheetView.Height = 18;
            _SheetView.Font = new Font("verdana", 8, GraphicsUnit.Point);
            _SheetView.Sheets.Clear();
            _SheetView.Sheets.Add(new Sheet("数据 1"));
            _SheetView.SelectionChanged += new EventHandler(_SheetView_SelectionChanged);
            _SheetView.SelectedIndex = 0;
            panel5.Controls.Clear();
            panel5.Controls.Add(_SheetView);
            panel6.Controls.Add(CComLibrary.GlobeVal.outgrid[0]);



            try
            {
                Type l_Type;
                l_Type = typeof(string);

                System.Array l_Array = Array.CreateInstance(l_Type, 100 + 3, 2);





                CComLibrary.GlobeVal.outgrid[0].LoadDataSource(l_Array);

            }
            catch (Exception err)
            {
                SourceLibrary.Windows.Forms.ErrorDialog.Show(this, err, "Error");
            }

            outputwindow1 = new Panel();
            outputwindow1.BackColor = Color.DarkGray;
            outputwindow1.Dock = DockStyle.Fill;
            outputwindow1.Visible = true;
            outputwindow1.BorderStyle = BorderStyle.None;

            outputwindow2 = new RichTextBox();
            outputwindow2.BackColor = Color.White;
            outputwindow2.Visible = true;
            outputwindow2.Dock = DockStyle.Fill;
            outputwindow2.BorderStyle = BorderStyle.None;


            _SheetView1 = new SheetView();
            _SheetView1.Dock = DockStyle.Bottom;
            _SheetView1.Height = 18;
            _SheetView1.Font = new Font("verdana", 8, GraphicsUnit.Point);
            _SheetView1.Sheets.Clear();
            _SheetView1.Sheets.Add(new Sheet("面板"));
            _SheetView1.Sheets.Add(new Sheet("输出"));
            _SheetView1.SelectionChanged += new EventHandler(_SheetView1_SelectionChanged);
            _SheetView1.SelectedIndex = 0;
            panel3.Controls.Clear();
            panel3.Controls.Add(_SheetView1);

            panel3.Controls.Add(outputwindow1);
            panel3.Controls.Add(outputwindow2);

            CComLibrary.GlobeVal.m_outputwindow = outputwindow2;


            _UResultControl = new UResultControl();
            _UResultControl.listView1.View = View.Details;
            _UResultControl.listView1.GridLines = true;
            _UResultControl.listView1.FullRowSelect = true;
            _UResultControl.BackColor = SystemColors.Control;

            outputwindow1.Controls.Add(_UResultControl);
            _UResultControl.Dock = DockStyle.Fill;



            formloaded = true;

            if (tcboproject.SelectedIndex >= 0)
            {
                tcboproject_SelectedIndexChanged(null, null);
            }

            CComLibrary.GlobeVal.mptprocedurepath = this.gmptprocedurepath;



        }

        void _SheetView1_SelectionChanged(object sender, EventArgs e)
        {
            outputwindow1.Visible = false;
            outputwindow2.Visible = false;
            if (_SheetView1.SelectedIndex == 0)
            {
                outputwindow1.Visible = true;
            }
            else
            {
                outputwindow2.Visible = true;
            }
 
            return;
        }

        void _SheetView_SelectionChanged(object sender, EventArgs e)
        {
            int i;
            for (i=0;i<10;i++)
            {
                CComLibrary.GlobeVal.outgrid[i].Visible = false;
            }

            CComLibrary.GlobeVal.outgrid[_SheetView.SelectedIndex].Visible = true;

            return;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
          
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void 读取试验数据toolStripButton_Click(object sender, EventArgs e)
        {
            string exstring;
            int i = -1;
            int j = 0;
            int k=0;
            int w = 0;
            string[] ww;
            string[] www;
            string line;
            string lastline="";
            string last2line="";

            int ii = 0;
           
            char[] sp;
            char[] sp1;
            int mpos=0;

            Type l_Type;
            l_Type = typeof(string);

            ClearMemory();

            System.Array g_data;

          

            g_data = System.Array.CreateInstance(typeof(string), 30, 1000000);

          
             
           
            int L = 0;

            List<string> mlistx=new List<string>();



            sp = new char[2];
            sp1 = new char[2];

            openFileDialog1.InitialDirectory = this.g_datafilepath  ;

            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "(*" + CComLibrary.GlobeVal.filesave.fileextname + ")|*"+
               CComLibrary.GlobeVal.filesave.fileextname;
            //openFileDialog1.Filter = "所有文件(*.*)|*.*|文本文件(*.txt)|*.txt|log文件(*.log)|*.log";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == null)
            {
                
                return;
            }
            else
            {
                string fileName = openFileDialog1.FileName;

                if (fileName == "")
                {
                    return;
                }
                else
                {


                    toolStripStatusLabel_filename.Text = "试验数据文件名称;" + fileName;

                    exstring = Path.GetExtension(fileName);



                    CComLibrary.GlobeVal.outgrid[0].Tag = Path.GetFileNameWithoutExtension(fileName);

                    if (exstring == ".lab")
                    {
                        try
                        {
                            // Create an instance of StreamReader to read from a file.
                            // The using statement also closes the StreamReader.
                            using (StreamReader sr = new StreamReader(fileName, Encoding.Default))
                            {


                                while ((line = sr.ReadLine()) != null)
                                {
                                    i = i + 1;
                                   
                                    if (line.Contains("负荷") == true)
                                    {

                                        w = i;
                                        line = line.Replace("，", ",");

                                        sp[0] = Convert.ToChar(",");

                                        ww = line.Split(sp);

                                        L = ww.Length;
                                        mlistx.Clear();

                                        k = 0;
                                        for (j = 0; j < ww.Length; j++)
                                        {
                                            if (ww[j] == "")
                                            {
                                                L = ww.Length - 1;
                                            }
                                            else
                                            {
                                                mlistx.Add(ww[j]);
                                                
                                                CComLibrary.GlobeVal.g_datatitle[k] = ww[j];
                                                CComLibrary.GlobeVal.g_dataunit[k] = "";
                                                k = k + 1;
                                            }


                                        }

                                       

                                        break;
                                    }


                                }
                            }
                        }
                        catch (Exception e1)
                        {
                            MessageBox.Show(e1.Message);
                        }

                        i = -1;
                        try
                        {
                            // Create an instance of StreamReader to read from a file.
                            // The using statement also closes the StreamReader.


                            using (StreamReader sr = new StreamReader(fileName, Encoding.Default))
                            {
                                while ((line = sr.ReadLine()) != null)
                                {
                                    i = i + 1;


                                    if (i >= w)
                                    {

                                        sp[0] = Convert.ToChar(",");

                                        www = line.Split(sp);



                                        for (j = 0; j < www.Length; j++)
                                        {

                                            if (www[j].Contains(":") == true)
                                            {
                                                g_data.SetValue(www[j], j, i - w);

                                            }
                                            else
                                            {
                                                g_data.SetValue(www[j], j, i - w);
                                            }

                                        }
                                    }

                                }

                                i = i - w;

                                
                            }
                        }
                        catch (Exception e1)
                        {
                            MessageBox.Show(e1.Message);
                        }

                    }
                    if (exstring == ".dat")
                    {

                        try
                        {
                            // Create an instance of StreamReader to read from a file.
                            // The using statement also closes the StreamReader.
                            

                            using (StreamReader sr = new StreamReader(fileName, Encoding.UTF8))
                            {


                                while ((line = sr.ReadLine()) != null)
                                {
                                    i = i + 1;
                                    if (line.Contains("\"")==false)
                                    {

                                        w = i-1;
                                        sp[0] = Convert.ToChar(",");
                                        sp1[0] = Convert.ToChar("\"");
                                        ww = last2line.Split(sp);

                                        L = ww.Length;
                                        mlistx.Clear();

                                        for (j = 0; j < ww.Length; j++)
                                        {
                                            if (ww[j] == "")
                                            {
                                                L = ww.Length - 1;
                                            }
                                            else
                                            {
                                                ww[j] = ww[j].Trim(sp1);
                                                mlistx.Add(ww[j]);
                                                CComLibrary.GlobeVal.g_datatitle[j] = ww[j];
                                                
                                            }


                                        }

                                        ww = lastline.Split(sp);



                                        for (j = 0; j < ww.Length; j++)
                                        {
                                            if (ww[j] == "")
                                            {

                                            }
                                            else
                                            {
                                                CComLibrary.GlobeVal.g_dataunit[j] = ww[j];

                                            }


                                        }


                                        

                                        break;
                                    }
                                    last2line = lastline;
                                    lastline = line;
                                    
                                }

                                if (i == -1)
                                {
                                    MessageBox.Show("错误,文件为空"); 
                                    return;
                                }
                               
                            }
                        }
                        catch (Exception e1)
                        {
                            MessageBox.Show(e1.Message);
                        }

                        i = -1;
                        try
                        {
                            // Create an instance of StreamReader to read from a file.
                            // The using statement also closes the StreamReader.
                            using (StreamReader sr = new StreamReader(fileName, Encoding.UTF8))
                            {


                                
                                line = sr.ReadLine();

                                 
                                sp[0] = Convert.ToChar(",");

                               

                                ww = line.Split(sp);
                                sp1[0] = Convert.ToChar("\"");

                                CComLibrary.GlobeVal._试验方法 = ww[1].Trim(sp1);
                                CComLibrary.GlobeVal._文件类型 = ww[0].Trim(sp1);

                                if (ww.Length > 30)
                                {
                                    MessageBox.Show("文件列数不能超过30");
                                    return;
                                }


                            }
                        }
                        catch (Exception e1)
                        {
                            MessageBox.Show(e1.Message);
                        }

                        try
                        {
                            // Create an instance of StreamReader to read from a file.
                            // The using statement also closes the StreamReader.


                            using (StreamReader sr = new StreamReader(fileName, Encoding.UTF8))
                            {
                                while ((line = sr.ReadLine()) != null)
                                {
                                    if (line.Contains("\"") == false)
                                    {
                                        i = i + 1;


                                        if (i >= w)
                                        {

                                            www = line.Split(sp);



                                            for (j = 0; j < www.Length; j++)
                                            {

                                                if (www[j].Contains(":") == true)
                                                {
                                                    g_data.SetValue(www[j], j, i - w);

                                                }
                                                else
                                                {
                                                    g_data.SetValue(www[j], j, i - w);
                                                }

                                            }
                                        }
                                    }
                                    
                                }

                                i = i - w;
                            }
                        }
                        catch (Exception e1)
                        {
                            MessageBox.Show(e1.Message);
                        }
                    }

                    if (exstring == ".xls")
                    {
                        DataSet ds;
                        ds = ExcelToDS(fileName);

                        mlistx.Clear();

                        for (j = 0; j < ds.Tables[0].Columns.Count; j++)
                        {
                            line = ds.Tables[0].Columns[j].ToString();
                            if (line.Contains("(") == true)
                            {
                                mpos = line.IndexOf("(");
                                CComLibrary.GlobeVal.g_dataunit[j] = line.Substring(mpos, line.Length - mpos);

                                line = line.Substring(0, mpos);
                            }
                            else
                            {
                                CComLibrary.GlobeVal.g_dataunit[j] = " ";

                            }

                            mlistx.Add(line);
                            CComLibrary.GlobeVal.g_datatitle[j] = line;


                        }
                    }

                    if (exstring ==".mdb")
                    {
                        
                        OleDbConnection conn = null;
                        OleDbDataReader reader = null;
                        
                        conn = new OleDbConnection(
                        "Provider=Microsoft.Jet.OLEDB.4.0; " +
                        "Data Source=" + (fileName));
                        conn.Open();
                        OleDbCommand cmd =
                         new OleDbCommand("Select * FROM 实验数据", conn);
                        reader = cmd.ExecuteReader();



                        L = reader.FieldCount;

                         for (j = 0; j < reader.FieldCount; j++)
                         {

                              CComLibrary.GlobeVal.g_datatitle[j] =reader.GetName(j);
                              CComLibrary.GlobeVal.g_dataunit[j] = "";

                         }

                         i=0;

                         ii = 0;
                         while (reader.Read())
                         {
                             
                             ii = ii + 1;

                             if (ii >= CComLibrary.GlobeVal.filesave.minterval)
                             {
                                 for (j = 0; j < reader.FieldCount; j++)
                                 {
                                     g_data.SetValue(reader[reader.GetName(j)].ToString(), j, i);
                                 }

                                 ii = 0;
                                 i = i + 1;

                             }
                             

                             if (i > 1000000 - 1)
                             {
                                 break;
                             }

                         }

                         i = i - 1;
                        
                    }

                    if ((exstring == ".log") || (exstring ==".txt"))
                    {

                        try
                        {
                            // Create an instance of StreamReader to read from a file.
                            // The using statement also closes the StreamReader.
                            using (StreamReader sr = new StreamReader(fileName, Encoding.Default))
                            {

                               

                                line = sr.ReadLine();
                                sp[0] = Convert.ToChar(" ");

                                ww = line.Split(sp);

                                if (ww.Length > 30)
                                {
                                    MessageBox.Show("文件列数不能超过30");
                                    return;
                                }


                            }
                        }
                        catch (Exception e1)
                        {
                            MessageBox.Show(e1.Message);
                        }



                        try
                        {
                            // Create an instance of StreamReader to read from a file.
                            // The using statement also closes the StreamReader.
                            using (StreamReader sr = new StreamReader(fileName, Encoding.Default))
                            {

                               


                                if (exstring == ".txt")
                                {

                                    while ((line = sr.ReadLine()) != null)
                                    {
                                        line = line.Trim();
                                        i = i + 1;
                                        if (i == 0)
                                        {

                                            sp[0] = Convert.ToChar(" ");

                                            ww = line.Split(sp);

                                          

                                            mlistx.Clear();

                                            for (j = 0; j < ww.Length; j++)
                                            {

                                                mlistx.Add(ww[j]);
                                                CComLibrary.GlobeVal.g_datatitle[j] = ww[j];

                                               
                                            }

                                        }
                                        
                                      else if (i == 1)
                                        {

                                           sp[0] = Convert.ToChar(" ");

                                            ww = line.Split(sp);



                                            mlistx.Clear();

                                            for (j = 0; j < ww.Length; j++)
                                            {
                                                mlistx.Add(ww[j]);
                                               CComLibrary.GlobeVal.g_dataunit[j] = ww[j];


                                            }
                                       }
                                        else
                                        {

                                            sp[0] = Convert.ToChar(" ");

                                            ww = line.Split(sp);

                                            L = ww.Length;

                                            for (j = 0; j < ww.Length; j++)
                                            {

                                                if (ww[j].Contains(":") == true)
                                                {
                                                   g_data.SetValue(Convert.ToDateTime(ww[j]).TimeOfDay.TotalHours.ToString(),j,i);

                                                }
                                                else
                                                {
                                                    g_data.SetValue(ww[j],j,i);
                                                }

                                            }

                                        }
                                    }
                                }

                                if (exstring == ".log")
                                {

                                    while ((line = sr.ReadLine()) != null)
                                    {
                                        i = i + 1;
                                        if (i == 0)
                                        {
                                            line = line.Replace(".", "_");
                                            sp[0] = Convert.ToChar(" ");

                                            ww = line.Split(sp);

                                            L = ww.Length;

                                            for (j = 0; j < ww.Length; j++)
                                            {
                                                if (ww[j] == "")
                                                {
                                                    L = ww.Length - 1;

                                                }
                                            }

                                            CComLibrary.GlobeVal.g_colcount = L;


                                            mlistx.Clear();

                                            for (j = 0; j < L; j++)
                                            {
                                                if (ww[j].Contains("(") == true)
                                                {
                                                    mpos = ww[j].IndexOf("(");
                                                    CComLibrary.GlobeVal.g_dataunit[j] = ww[j].Substring(mpos, ww[j].Length - mpos);

                                                    ww[j] = ww[j].Substring(0, mpos);
                                                }
                                                else
                                                {
                                                    CComLibrary.GlobeVal.g_dataunit[j] = " ";

                                                }

                                                mlistx.Add(ww[j]);
                                                CComLibrary.GlobeVal.g_datatitle[j] = ww[j];


                                            }

                                        }

                                        else
                                        {

                                            www = line.Split(sp);



                                            for (j = 0; j < L; j++)
                                            {

                                                if (www[j].Contains(":") == true)
                                                {
                                                    g_data.SetValue(Convert.ToDateTime(www[j]).TimeOfDay.TotalHours.ToString(), j, i);

                                                }
                                                else
                                                {
                                                    g_data.SetValue(www[j],j,i);
                                                }

                                            }

                                        }
                                    }
                                }

                            }
                        }
                        catch (Exception e1)
                        {
                            MessageBox.Show(e1.Message);
                        }
                    }
                }

                try
                {
                    
                    l_Type = typeof(string);


                    i = i - 1;
                    CComLibrary.GlobeVal.l_Array = Array.CreateInstance(l_Type, i, L);

                    for (k=0;k<L;k++)
                    {
                      for (j=2;j<=i;j++)
                      {

                        
                              //k,j
                          CComLibrary.GlobeVal.l_Array.SetValue(g_data.GetValue(k, j), j - 2, k);
                        
                      }
                    }

                    CComLibrary.GlobeVal.g_datalen = i - 1;



                    CComLibrary.GlobeVal.outgrid[0].LoadDataSource(CComLibrary.GlobeVal.l_Array);

                  

                    for (k = 0; k < L; k++)
                    {
                        for (j = 0; j < 2; j++)
                        {

                            if (j == 0)
                            {
                                CComLibrary.GlobeVal.outgrid[0].m_ColHeaderCell.SetValue(new SourceGrid2.Position(j + 1,k+1), CComLibrary.GlobeVal.g_datatitle[k].ToString());
                           
                            }
                            else if (j == 1)
                            {
                                CComLibrary.GlobeVal.outgrid[0].m_ColHeaderCell.SetValue(new SourceGrid2.Position(j + 1,k+1), CComLibrary.GlobeVal.g_dataunit[k].ToString());
                           
                            }
                           
                        }
                    }

                }
                catch (Exception err)
                {
                    SourceLibrary.Windows.Forms.ErrorDialog.Show(this, err, "Error");
                }

            }

       
            

        }


       
        public void Init_SystemPara()
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
                        s = s + "public double " + b.replaceName + "="+
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
                s = s + "public  double " + b.replaceName + "="+ CComLibrary.GlobeVal.filesave.minput[i].value.ToString()+";" + "\r\n";
                CComLibrary.GlobeVal.msyspara.Add(b);
            }


            CComLibrary.GlobeVal.gcalc.refreshglobe(s);



           

        }

        private void 计算toolStripButton_Click(object sender, EventArgs e)
        {
            int i;
            int j;
            int k;
            Boolean a;


            try
            {

                Boolean bcalc = false;

                CComLibrary.SystemPara b;
                string s;
                s = "";
                CComLibrary.GlobeVal.mscattergraph = scatterGraph1;
                CComLibrary.GlobeVal.m_test = false;

                CComLibrary.GlobeVal.m_listline.Clear();

                scatterGraph1.Annotations.Clear();



                CComLibrary.GlobeVal.filesave.minput.Clear();
                for (i = 0; i < _UResultControl.listEditor1.List.Count; i++)
                {
                    CComLibrary.inputitem minput = new CComLibrary.inputitem();

                    minput.name = (_UResultControl.listEditor1.List[i] as SampleProject.Extensions.ChartBar).名称;
                    minput.value = (_UResultControl.listEditor1.List[i] as SampleProject.Extensions.ChartBar).值;
                    minput.unit = (_UResultControl.listEditor1.List[i] as SampleProject.Extensions.ChartBar).单位;

                    CComLibrary.GlobeVal.filesave.minput.Add(minput);


                }


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

                CComLibrary.GlobeVal.gcalc.setarrayvalue(CComLibrary.GlobeVal.l_Array, CComLibrary.GlobeVal.g_datalen, CComLibrary.GlobeVal.outgrid[0].ColumnsCount - 1);

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
                            b.replaceName = b.Name;
                            //  s = s + "double " + b.replaceName + "=" + "CalcedChannelResult["+(i + 1).ToString().Trim() + "];" + "\r\n";
                            s = s + "double " + b.replaceName + "=" + "m_Global.mresult[" + (i + 1).ToString().Trim() + "];\r\n";
                            CComLibrary.GlobeVal.msyspara.Add(b);



                        }

                    }
                }

                if (mhavecalcitem ==false )
                {
                    MessageBox.Show("没有设置计算项目");
                }
                if (mhavecalcitem == true)
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


                        //if (bcalc == false)
                        {
                            //  CComLibrary.GlobeVal.m_outputwindow.Text =
                            //     CComLibrary.GlobeVal.m_outputwindow.Text
                            //    + "---"+CComLibrary.GlobeVal.filesave.moutput[j].formulaname+ 
                            //   " 计算出现错误，请检查公式定义\r\n";
                            //}
                            if (ClsStaticStation.m_Global.mvalid == true)
                            {
                                rvalid[j + 1] = true;
                            }
                            else
                            {
                                rvalid[j + 1] = false;
                            }

                            CComLibrary.GlobeVal.gcalc.getresult(j + 1);

                            //rr[j + 1] = CComLibrary.GlobeVal.gcalc.getresult(j + 1);
                            //ClsStaticStation.m_Global.mresult[j + 1] = rr[j + 1];

                        }
                    }

                    for (k = 0; k < CComLibrary.GlobeVal.filesave.moutput.Count; k++)
                    {

                    }
                    _UResultControl.listView1.Clear();
                    _UResultControl.listView1.Columns.Add("计算项目", 220, HorizontalAlignment.Left);
                    _UResultControl.listView1.Columns.Add("结果", 220, HorizontalAlignment.Left);


                    for (i = 0; i < CComLibrary.GlobeVal.filesave.moutput.Count; i++)
                    {
                        ListViewItem b1;
                        b1 = new ListViewItem();
                        b1.SubItems.Add("");
                        b1.SubItems.Add("");
                        b1.Text = CComLibrary.GlobeVal.filesave.moutput[i].formulaname;

                        b1.BackColor = Color.White;

                        b1.SubItems[1].Text = CComLibrary.GlobeVal.gcalc.getresult(i + 1).ToString();
                        _UResultControl.listView1.Items.Add(b1);



                    }

                    /*
                   for (k = 0; k < CComLibrary.GlobeVal.filesave.moutput.Count; k++)
                   {

                           for (i = 0; i < CComLibrary.GlobeVal.filesave.mcalcpanel.rowcount; i++)
                           {
                               for (j = 0; j < CComLibrary.GlobeVal.filesave.mcalcpanel.colcount; j++)
                               {

                                   if ("{" + CComLibrary.GlobeVal.filesave.moutput[k].formulaname + "结果}" == CComLibrary.GlobeVal.filesave.mcalcpanel.textgrid[i][j])
                                   {
                                       //if (rvalid[k+ 1] == true)
                                       {
                                           _UResultControl.listView1.Items[i].SubItems[j].Text =ClsStaticStation.m_Global.mresult[k+1].ToString() ;
                                       }
                                       //else
                                       {
                                          // _UResultControl.listView1.Items[i].SubItems[j].Text = "------";
                                       }


                                   }
                               }
                           }

                   }
                     * */


                    if (CComLibrary.GlobeVal.m_test == false)
                    {

                        for (i = 0; i < CComLibrary.GlobeVal.m_listline.Count; i++)
                        {
                            if (CComLibrary.GlobeVal.m_listline[i].kind == 0)
                            {
                               // CComLibrary.GlobeVal.m_listline[i].xstart = CComLibrary.GlobeVal.g_datadraw[0][CComLibrary.GlobeVal.m_listline[i].indexstart];
                               // CComLibrary.GlobeVal.m_listline[i].ystart = CComLibrary.GlobeVal.g_datadraw[1][CComLibrary.GlobeVal.m_listline[i].indexstart];


                               // MessageBox.Show(CComLibrary.GlobeVal.m_listline[i].xstart.ToString());
                               // MessageBox.Show(CComLibrary.GlobeVal.m_listline[i].ystart.ToString());

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

                CComLibrary.GlobeVal.InitUserCalcChannel();
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

        }

        private void tsbplotline_Click(object sender, EventArgs e)
        {
            int i;
            int ii;
            int j;
            int k;
            double x=0;
            double  y=0;
            string s;


            xyselectstart.MoveCursor(0);
            xyselectend.MoveCursor(0);

            xyCursorstart.Visible = false;
            xyCursorend.Visible = false;
            toolStripbar.Enabled = false;
            CComLibrary.GlobeVal.m_listline.Clear();

            scatterGraph1.Annotations.Clear();


            FormLineSet f1 = new FormLineSet();
            f1.ShowDialog();

            

            for (k = 0; k < this.scatterGraph1.YAxes.Count; k++)
            {
                this.scatterGraph1.YAxes[k].Visible = false;
            }
            this.scatterGraph1.YAxes[0].Position = YAxisPosition.Left;
            this.scatterGraph1.YAxes[0].Visible = true;
            
            scatterGraph1.ClearData();
            

            this.scatterPlot1.LineStyle = LineStyle.Solid;
            
            this.scatterPlot1.PointStyle = PointStyle.None;
            this.scatterPlot1.PointColor = Color.Blue;
            this.scatterPlot1.PointSize = new Size(3, 3);

           

            j = 0;

            for (i = 4; i < CComLibrary.GlobeVal.outgrid[0].RowsCount; i++)
            {
                if (CComLibrary.GlobeVal.outgrid[0].m_DataCell.GetValue(new SourceGrid2.Position(i, 1)) == null)
                {
                    break;
                }
                else
                {
                    if (CComLibrary.GlobeVal.outgrid[0].m_DataCell.GetValue(new SourceGrid2.Position(i, 1)).ToString().Trim() == "")
                    {
                        break;
                    }
                    else
                    {
                        j = j + 1;
                    }
                }

            }

            

           


            ii = 0;
            for (i = 4; i < j; i++)
            {
                if (CComLibrary.GlobeVal.outgrid[0].m_DataCell.GetValue(new SourceGrid2.Position(i, 1)) ==null)
                {
                    break;
                }
                else
                {
                    if (CComLibrary.GlobeVal.outgrid[0].m_DataCell.GetValue(new SourceGrid2.Position(i, 1)).ToString().Trim() =="")
                    {
                        break;
                    }
                    else
                    {
                        s=CComLibrary.GlobeVal.outgrid[0].m_DataCell.GetValue(new SourceGrid2.Position(i, 1)).ToString();

                        if (s.Contains("\"")==true)
                        {
                        }
                        else
                        {

                            x = Convert.ToDouble(CComLibrary.GlobeVal.outgrid[0].m_DataCell.GetValue(new SourceGrid2.Position(i, CComLibrary.GlobeVal.xsel)));

                            y = Convert.ToDouble(CComLibrary.GlobeVal.outgrid[0].m_DataCell.GetValue(new SourceGrid2.Position(i, CComLibrary.GlobeVal.ysel)));

                            scatterGraph1.PlotXYAppend(x, y); 
                            ii = ii + 1;
                        }
                    }
                }

            }

            if ((CComLibrary.GlobeVal.xsel - 1 >= 0) && (CComLibrary.GlobeVal.ysel - 1 >= 0))
            {

                this.scatterPlot1.XAxis.Caption = CComLibrary.GlobeVal.g_datatitle[CComLibrary.GlobeVal.xsel - 1] + "[" + CComLibrary.GlobeVal.g_dataunit[CComLibrary.GlobeVal.xsel - 1] + "]";
                this.scatterPlot1.YAxis.Caption = CComLibrary.GlobeVal.g_datatitle[CComLibrary.GlobeVal.ysel - 1] + "[" + CComLibrary.GlobeVal.g_dataunit[CComLibrary.GlobeVal.ysel - 1] + "]";
            }



            //scatterGraph1.PlotXY(CComLibrary.GlobeVal.g_datadraw[0], CComLibrary.GlobeVal.g_datadraw[1]); 

                
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            
            
             
        }

        private void scatterGraph1_Zoom(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            //scatterGraph1.InteractionModeDefault = NationalInstruments.UI.GraphDefaultInteractionMode.None;

        }

        private void drawmline(double x1, double y1, double x2, double y2,CComLibrary.LineStruct l)
        {

            XYPointAnnotation u = new XYPointAnnotation(scatterPlot1.XAxis, scatterPlot1.YAxis);
            u.ArrowColor = Color.Green ;

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
        
        private void drawline(double x1, double y1, double x2, double y2,CComLibrary.LineStruct l)
        {
           
            XYPointAnnotation u = new XYPointAnnotation(scatterPlot1.XAxis, scatterPlot1.YAxis);
            u.ArrowColor = Color.Green ;

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
            u.CaptionVisible = false ;

            scatterGraph1.Cursor = Cursors.Default;

            
        }
        private void drawsign(double x,double y,CComLibrary.LineStruct l)
        {
            
            XYPointAnnotation u = new XYPointAnnotation(scatterPlot1.XAxis, scatterPlot1.YAxis);
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

        private void scatterGraph1_AfterDrawPlot(object sender, NationalInstruments.UI.AfterDrawXYPlotEventArgs e)
        {

         
        }

        private void scatterGraph1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((mtsbpoint_bool == true) && (mtsbpoint_begin == true))
            {


            }

            if ((mtsbarrow_bool == true) && (mtsbarrow_begin ==true))
            {


                ControlPaint.DrawReversibleLine(mP1, mP2, Color.Red );
                mP2 = scatterGraph1.PointToScreen(e.Location);

                ControlPaint.DrawReversibleLine(mP1, mP2, Color.Red );



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
                    lastRect = new Rectangle(mP5,size);
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

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
                Graphics f = scatterGraph1.CreateGraphics();
            
                double x1 = 1, x2 = 10,x3=5, y1 = 5, y2 = 1,y3=10;

                PointF point1 = this.scatterPlot1.MapDataPoint(scatterPlot1.GetBounds() , x1, y1);
                PointF point2 = this.scatterPlot1.MapDataPoint(scatterPlot1.GetBounds(), x2, y2);
                PointF point3 = this.scatterPlot1.MapDataPoint(scatterPlot1.GetBounds(), x3, y3);

                Pen pen = null;
                if (y2 > y1)
                    pen = Pens.LimeGreen;
                else if (y2 == y1)
                    pen = Pens.Yellow;
                else
                    pen = Pens.Red;

                
                f.DrawLines(pen, new PointF[] { point1, point2, point3 });
                f.Dispose();


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
                mP1F.Y  = e.Y;  

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
        private void tsbarrow_Click(object sender, EventArgs e)
        {
            scatterGraph1.InteractionModeDefault = NationalInstruments.UI.GraphDefaultInteractionMode.None;
            mtsbarrow_bool = tsbarrow.Checked;
            scatterGraph1.Cursor = Cursors.Cross; 
        }

        private void scatterGraph1_MouseUp(object sender, MouseEventArgs e)
        {
            double x, y;
            double x1, y1;

            PointF f=new PointF();


            if (sender is Panel)
            {
                
                    (sender as Panel).SendToBack();

                    f.X = (sender as Panel).Left ;
                    f.Y = (sender as Panel).Top;

                    scatterPlot1.InverseMapDataPoint(scatterPlot1.GetBounds(), f, out x, out y);


                    xyselectstart.XPosition = x;
                    xyselectstart.YPosition = y;
                    xyselectstart.Visible = true;
                    xyselectstart.Tag = sender; 
                        
                        
                   f.X = (sender as Panel).Width +(sender as Panel).Left;
                    f.Y = (sender as Panel).Top+(sender as Panel).Height;


                    scatterPlot1.InverseMapDataPoint(scatterPlot1.GetBounds(), f, out x1, out y1);


                    xyselectend.XPosition = x1 ;
                    xyselectend.YPosition = y1;
                    xyselectend.Tag = sender; 
                    xyselectend.Visible = true;


                    

                
                
            }

            

            
            if ((mtsbtext_bool == true) && (e.Button ==MouseButtons.Left))
            {
                mP8F.X = e.X;
                mP8F.Y = e.Y;

                mabtext = new ZBobb.AlphaBlendTextBox();

                mabtext.BackAlpha = 0;
                mabtext.ForeColor = scatterGraph1.ForeColor ;
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
                u.Width = Convert.ToInt16(Math.Abs(mP12F.X  - mP11F.X ));
                u.Height = Convert.ToInt16(Math.Abs(mP12F.Y  - mP11F.Y ));

                u.MouseDown += new MouseEventHandler(scatterGraph1_MouseDown );
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
               
                u.XPosition = x;
                u.YPosition = y;
               
                u.ArrowHeadStyle = ArrowStyle.None;
                u.ArrowVisible = false;
                u.InteractionMode = AnnotationInteractionMode.None;
                //scatterPlot1.InverseMapDataPoint(scatterPlot1.GetBounds(), mP9F, out x1, out y1);


                PointF pf = new PointF();
                pf.X = Convert.ToSingle(x);
                pf.Y = Convert.ToSingle(y);
                
                CComLibrary.LineStruct l =new CComLibrary.LineStruct();
                l.kind = 0;
                l.pf = pf;
                u.Tag =l;
                
                scatterGraph1.Annotations.Add(u);
                u.SetPosition(x, y);
                u.SetCaptionPosition(x, y);

                scatterGraph1.Cursor = Cursors.Default;

                tsbpoint.Checked = false;
                mtsbpoint_bool = false;
                mtsbpoint_begin = false; 

            }

            if ((mtsbline_bool == true) && (e.Button ==MouseButtons.Left))
            {
                mP4F.X = e.X;
                mP4F.Y = e.Y;


               
                XYPointAnnotation u = new XYPointAnnotation(scatterPlot1.XAxis, scatterPlot1.YAxis);
                u.ArrowColor =scatterGraph1.ForeColor;
                 
                u.Visible = true;
                scatterPlot1.InverseMapDataPoint(scatterPlot1.GetBounds(), mP4F, out x, out y);
                u.XPosition = x;
                u.YPosition = y;
                u.ShapeVisible = false;
                u.ShapeSize = new Size(1, 1);
                u.ArrowHeadStyle = ArrowStyle.None;
                u.InteractionMode = AnnotationInteractionMode.None; 
                scatterPlot1.InverseMapDataPoint(scatterPlot1.GetBounds(), mP3F, out x1, out y1);


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
            if ((mtsbarrow_bool == true) && (e.Button ==MouseButtons.Left))
            {
                mP2F.X = e.X;
                mP2F.Y = e.Y;

            
                
                
                XYPointAnnotation  u = new XYPointAnnotation(scatterPlot1.XAxis,scatterPlot1.YAxis)  ;
               
                u.ArrowColor = scatterGraph1.ForeColor;
                u.Visible = true;
                scatterPlot1.InverseMapDataPoint(scatterPlot1.GetBounds(), mP2F, out x, out y);
                u.XPosition = x;
                u.YPosition = y;
                u.ShapeVisible = false;
                u.InteractionMode = AnnotationInteractionMode.None;
                u.ShapeSize = new Size(1, 1);
                
                scatterPlot1.InverseMapDataPoint(scatterPlot1.GetBounds(), mP1F, out x1, out y1);
                 
                scatterGraph1.Annotations.Add(u);
                u.SetPosition(x, y);
                
                u.SetCaptionPosition(x1, y1);

                PointF pf =new PointF();
                pf.X = Convert.ToSingle( x1);
                pf.Y = Convert.ToSingle( y1);

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

            u.Caption = (sender as ZBobb.AlphaBlendTextBox).Text  ; 
            scatterGraph1.Annotations.Add(u);
            u.SetPosition(x, y);
            u.SetCaptionPosition(x1, y1);


            scatterGraph1.Cursor = Cursors.Default;

            timertxt.Enabled = true;    


        }

        void t_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                scatterGraph1.Focus();
                return;
                
            }
        }

        private void scatterGraph1_CaptionPositionChanged(object sender, EventArgs e)
        {
            
        }

        private void scatterGraph1_AnnotationsChanged(object sender, CollectionChangeEventArgs e)
        {
              
        }

        private void scatterGraph1_AfterDragAnnotationCaption(object sender, AfterDragXYAnnotationCaptionEventArgs e)
        {
            
           // MessageBox.Show(e.XOffset.ToString());
        }

        private void tsbtext_Click(object sender, EventArgs e)
        {
            scatterGraph1.InteractionModeDefault = NationalInstruments.UI.GraphDefaultInteractionMode.None;

            mtsbtext_bool = tsbtext.Checked;
            scatterGraph1.Cursor = Cursors.IBeam ;

            
        }

        private void timertxt_Tick(object sender, EventArgs e)
        {
            scatterGraph1.Controls.Remove(mabtext);
            timertxt.Enabled = false; 
        }

        private void tsbline_Click(object sender, EventArgs e)
        {
            scatterGraph1.InteractionModeDefault = NationalInstruments.UI.GraphDefaultInteractionMode.None;
            mtsbline_bool= tsbline.Checked ;
            scatterGraph1.Cursor = Cursors.Cross; 
        }

        private void tsbrect_Click(object sender, EventArgs e)
        {
            scatterGraph1.InteractionModeDefault = NationalInstruments.UI.GraphDefaultInteractionMode.None;
            mtsbrect_bool = tsbrect.Checked;
            scatterGraph1.Cursor = Cursors.Cross; 
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            if (formloaded == false)
            {
                //Thread.Sleep(3000);
                
                formloaded = true;
            }
        }

        private void tsbzoomin_Click(object sender, EventArgs e)
        {
            
            scatterGraph1.InteractionModeDefault = NationalInstruments.UI.GraphDefaultInteractionMode.ZoomXY;
            tsbzoomout.Enabled = true;
            

        }

        private void tsbreader_Click(object sender, EventArgs e)
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

        private void tsbscreenreader_Click(object sender, EventArgs e)
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

        private void tsbzoomout_Click(object sender, EventArgs e)
        {
            scatterGraph1.UndoZoomPan();
            scatterGraph1.InteractionModeDefault = NationalInstruments.UI.GraphDefaultInteractionMode.None;
        }

        private void tsbplotdot_Click(object sender, EventArgs e)
        {
            int i;
            int ii;
            int j;
            string s;
            int k;
          
            FormLineSet f1 = new FormLineSet();
            f1.ShowDialog();
            this.scatterGraph1.YAxes[0].Position = YAxisPosition.Left;  
            this.scatterGraph1.YAxes[0].Visible = true;
            for (k = 0; k < this.scatterGraph1.YAxes.Count; k++)
            {
                this.scatterGraph1.YAxes[k].Visible = false;
            }

            scatterGraph1.ClearData();
            

            this.scatterPlot1.LineStyle = LineStyle.None ;

            this.scatterPlot1.PointStyle = PointStyle.Cross ;
            this.scatterPlot1.PointColor = Color.Blue;
            this.scatterPlot1.PointSize = new Size(3, 3);



            j = 0;

            for (i = 4; i < CComLibrary.GlobeVal.outgrid[0].RowsCount; i++)
            {
                if (CComLibrary.GlobeVal.outgrid[0].m_DataCell.GetValue(new SourceGrid2.Position(i, 1)) == null)
                {
                    break;
                }
                else
                {
                    if (CComLibrary.GlobeVal.outgrid[0].m_DataCell.GetValue(new SourceGrid2.Position(i, 1)).ToString().Trim() == "")
                    {
                        break;
                    }
                    else
                    {
                        j = j + 1;
                    }
                }

            }


          


            ii = 0;
            for (i = 4; i < j; i++)
            {
                if (CComLibrary.GlobeVal.outgrid[0].m_DataCell.GetValue(new SourceGrid2.Position(i, 1)) == null)
                {
                    break;
                }
                else
                {
                    if (CComLibrary.GlobeVal.outgrid[0].m_DataCell.GetValue(new SourceGrid2.Position(i, 1)).ToString().Trim() == "")
                    {
                        break;
                    }
                    else
                    {
                        s = CComLibrary.GlobeVal.outgrid[0].m_DataCell.GetValue(new SourceGrid2.Position(i, 1)).ToString();

                        if (s.Contains("\"") == true)
                        {
                        }
                        else
                        {
                           
                            ii = ii + 1;
                        }
                    }
                }

            }

            if ((CComLibrary.GlobeVal.xsel - 1 >= 0) && (CComLibrary.GlobeVal.ysel - 1 >= 0))
            {

                this.scatterPlot1.XAxis.Caption = CComLibrary.GlobeVal.g_datatitle[CComLibrary.GlobeVal.xsel - 1] + "[" + CComLibrary.GlobeVal.g_dataunit[CComLibrary.GlobeVal.xsel - 1] + "]";
                this.scatterPlot1.YAxis.Caption = CComLibrary.GlobeVal.g_datatitle[CComLibrary.GlobeVal.ysel - 1] + "[" + CComLibrary.GlobeVal.g_dataunit[CComLibrary.GlobeVal.ysel - 1] + "]";
            }



            scatterGraph1.PlotXY(CComLibrary.GlobeVal.g_datadraw[0], CComLibrary.GlobeVal.g_datadraw[1]); 

            
        }
        private void PrintPageEntireGraph(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            
            
            Rectangle bounds = e.MarginBounds;

            scatterGraph1.Draw(new ComponentDrawArgs(g, bounds));
        }
    
        private PrintPageEventHandler GetPrintPageEventHandler()
        {
            PrintPageEventHandler handler = new PrintPageEventHandler(PrintPageEntireGraph);
            
            
                handler = new PrintPageEventHandler(PrintPageEntireGraph);
            
            return handler;
        }


        private void toolStripButton9_Click_1(object sender, EventArgs e)
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

      

        private void tsbdefault_Click(object sender, EventArgs e)
        {
            scatterGraph1.Cursor = Cursors.Default;
            scatterGraph1.InteractionModeDefault = NationalInstruments.UI.GraphDefaultInteractionMode.None; 


        }

       
        private void tsbeditproject_Click(object sender, EventArgs e)
        {
            openprojectfile_(this.gmptpath+"\\"+ClsStaticStation.m_Global.mycls.TestkindList[toolStripCboKind.SelectedIndex]+"\\"+tcboproject.Text+".dat"); 
        }

       
        private void tcboproject_SelectedIndexChanged(object sender, EventArgs e)
        
        {
           
           
            string[] ss;

            if (formloaded == false)
            {
                return;
            }
            CComLibrary.GlobeVal.filesave = new CComLibrary.FileStruct();

            string s;
            s = this.gmptpath +"\\"+ClsStaticStation.m_Global.mycls.TestkindList[toolStripCboKind.SelectedIndex]+"\\"  + tcboproject.Text + ".dat";
            CComLibrary.GlobeVal.filesave = CComLibrary.GlobeVal.filesave.DeSerializeNow(s);

            if (_UResultControl == null)
            {
                return;
            }


            RefreshUResultControl();

            

        }

        private void 关于AToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AboutBox dlg = new AboutBox();
            dlg.ShowDialog();
            return; 
            string s;
            double b;
            DateTime m; 
            s = "09:56:56";

              

            m=Convert.ToDateTime(s);
            b = Convert.ToDouble(m.TimeOfDay.TotalDays); 

        }

        private void tcboproject_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int i;
            int j;
            int k;

            if ((CComLibrary.GlobeVal.filesave.m_namelist.Count+1) == CComLibrary.GlobeVal.outgrid[0].ColumnsCount)
            {
                CComLibrary.GlobeVal.xsel = CComLibrary.GlobeVal.filesave.xsel;
                CComLibrary.GlobeVal.yselcount = CComLibrary.GlobeVal.filesave.yselcount; 
                for (i = 0; i < CComLibrary.GlobeVal.filesave.yselcount; i++)
                {
                    CComLibrary.GlobeVal.ysels[i] = CComLibrary.GlobeVal.filesave.ysels[i];
                    CComLibrary.GlobeVal.yselpostion[i] = CComLibrary.GlobeVal.filesave.yselpostion[i];  
                }
 

            }
            else
            {
               
            }

            FormMultiAxisSet f = new FormMultiAxisSet();
            f.ShowDialog();
           
            CComLibrary.GlobeVal.g_datadraw = new double[2][];

            


            j = 0;

            for (i = 4; i < CComLibrary.GlobeVal.outgrid[0].RowsCount; i++)
            {
                if (CComLibrary.GlobeVal.outgrid[0].m_DataCell.GetValue(new SourceGrid2.Position(i, CComLibrary.GlobeVal.xsel)) == null)
                {
                    break;
                }
                else
                {
                    if (CComLibrary.GlobeVal.outgrid[0].m_DataCell.GetValue(new SourceGrid2.Position(i, CComLibrary.GlobeVal.xsel)).ToString().Trim() == "")
                    {
                        break;
                    }
                    else
                    {
                        j = j + 1;
                    }
                }

            }


            CComLibrary.GlobeVal.g_datadraw[0] = new double[j];
            CComLibrary.GlobeVal.g_datadraw[1] = new double[j];

            this.scatterGraph1.ClearData();

            for (k = 0; k < this.scatterGraph1.YAxes.Count; k++)
            {
                this.scatterGraph1.YAxes[k].Visible = false;
            }


           

            for (k = 0; k < CComLibrary.GlobeVal.yselcount; k++)
            {
                
                this.scatterGraph1.Plots[k].LineStyle = LineStyle.Solid;

        
                for (i = 4; i < CComLibrary.GlobeVal.outgrid[0].RowsCount; i++)
                {
                    if (CComLibrary.GlobeVal.outgrid[0].m_DataCell.GetValue(new SourceGrid2.Position(i, CComLibrary.GlobeVal.xsel)) == null)
                    {
                        break;
                    }
                    else
                    {
                        if (CComLibrary.GlobeVal.outgrid[0].m_DataCell.GetValue(new SourceGrid2.Position(i, CComLibrary.GlobeVal.xsel)).ToString().Trim() == "")
                        {
                            break;
                        }
                        else
                        {
                            CComLibrary.GlobeVal.g_datadraw[0][i - 4] = Convert.ToDouble(CComLibrary.GlobeVal.outgrid[0].m_DataCell.GetValue(new SourceGrid2.Position(i, CComLibrary.GlobeVal.xsel)));
                            CComLibrary.GlobeVal.g_datadraw[1][i - 4] = Convert.ToDouble(CComLibrary.GlobeVal.outgrid[0].m_DataCell.GetValue(new SourceGrid2.Position(i, CComLibrary.GlobeVal.ysels[k])));
                        }
                    }

                }


                if (CComLibrary.GlobeVal.yselpostion[k] == 0)
                {
                    this.scatterGraph1.YAxes[k].Position = YAxisPosition.Left;
                    this.scatterGraph1.YAxes[k].LeftCaptionOrientation = VerticalCaptionOrientation.TopToBottom;
                    this.scatterGraph1.YAxes[k].CaptionPosition = YAxisPosition.Left; 
                    this.scatterGraph1.YAxes[k].CaptionVisible = true;
                }
                else
                {
                    this.scatterGraph1.YAxes[k].Position = YAxisPosition.Right;
                    this.scatterGraph1.YAxes[k].CaptionPosition = YAxisPosition.Right;   
                    this.scatterGraph1.YAxes[k].LeftCaptionOrientation = VerticalCaptionOrientation.BottomToTop;
                    this.scatterGraph1.YAxes[k].CaptionVisible = true;

                }


                this.scatterGraph1.YAxes[k].Visible = true;
                this.scatterGraph1.Plots[k].YAxis = this.scatterGraph1.YAxes[k];

                if ((CComLibrary.GlobeVal.xsel - 1 >= 0) && (CComLibrary.GlobeVal.ysels[k] - 1 >= 0))
                {
                    

                    this.scatterGraph1.Plots[k].XAxis.Caption = CComLibrary.GlobeVal.g_datatitle[CComLibrary.GlobeVal.xsel - 1] + "[" + CComLibrary.GlobeVal.g_dataunit[CComLibrary.GlobeVal.xsel - 1] + "]";

                    

                    this.scatterGraph1.Plots[k].YAxis.CaptionForeColor  = scatterGraph1.Plots[k].LineColor;
                    this.scatterGraph1.Plots[k].YAxis.BaseLineColor = scatterGraph1.Plots[k].LineColor;
                    this.scatterGraph1.Plots[k].YAxis.MajorDivisions.LabelForeColor = scatterGraph1.Plots[k].LineColor;
                    this.scatterGraph1.Plots[k].YAxis.MajorDivisions.TickColor = scatterGraph1.Plots[k].LineColor; 


                    this.scatterGraph1.Plots[k].YAxis.Caption = CComLibrary.GlobeVal.g_datatitle[CComLibrary.GlobeVal.ysels[k] - 1] + "[" + CComLibrary.GlobeVal.g_dataunit[CComLibrary.GlobeVal.ysels[k] - 1] + "]";
                }



                this.scatterGraph1.Plots[k].PlotXY(CComLibrary.GlobeVal.g_datadraw[0], CComLibrary.GlobeVal.g_datadraw[1]);

            }

            this.scatterGraph1.Plots[0].YAxis.Visible = true;


        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {

        }

        private void xyCursorparallel_AfterDraw(object sender, AfterDrawXYCursorEventArgs e)
        {


            //ControlPaint.DrawReversibleLine(mP1, mP2, Color.Red);
            //mP2 = scatterGraph1.PointToScreen(e.Location);
            PointF f;
            PointF f1;
            double k;
            double x1, y1;
            double x2, y2;

            Graphics g = e.Graphics;


            Rectangle bounds = new Rectangle(e.Bounds.Left, e.Bounds.Top, e.Bounds.Width, e.Bounds.Height); 

            using (Brush brush = new SolidBrush(Color.FromArgb(128, xyCursorParallel.Color )))
            {
                //g.FillEllipse(brush, bounds);
            }

            //g.DrawEllipse(Pens.Yellow, bounds);

            k = 20;
           y1 = 0   ;
            

            x1=(y1 - xyCursorParallel.YPosition)/k+xyCursorParallel.XPosition; 


            f=scatterPlot1.MapDataPoint(e.Bounds, xyCursorParallel.XPosition, xyCursorParallel.YPosition);
            f1 = scatterPlot1.MapDataPoint(e.Bounds, x1, y1);

            g.DrawLine(Pens.Red,f1.X ,f1.Y  ,f.X,f.Y );


         
             using (Brush brush = new SolidBrush(Color.FromArgb(128, Color.Red)))
            {
                g.DrawString(x1.ToString()  , scatterGraph1.Font, brush, f1.X, f1.Y-scatterGraph1.Font.Height  );
            }

            

            


            
        }

     

       

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           
            if (e.ClickedItem != this.tsbdefault)
            {
                tsbdefault.CheckState  = CheckState.Unchecked;
            }
            
            if (e.ClickedItem != this.tsbselector)
            {
                tsbselector.CheckState = CheckState.Unchecked; 
            }
            if (e.ClickedItem!=tsbarrow )  
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

            if (e.ClickedItem != this.tsbrect )
            {
                tsbrect.CheckState = CheckState.Unchecked;
            }
            if (e.ClickedItem != this.tsbline )
            {
                tsbline.CheckState = CheckState.Unchecked;
            }
            if (e.ClickedItem != this.tsbtext )
            {
                tsbtext.CheckState = CheckState.Unchecked;
            }

            if (e.ClickedItem != this.tsbzoomout )
            {
                tsbzoomout.CheckState = CheckState.Unchecked;
            }

            if (e.ClickedItem != this.tsbzoomin)
            {
                tsbzoomin.CheckState = CheckState.Unchecked;
            }

         

        }

        private void toolStrip2_ItemRemoved(object sender, ToolStripItemEventArgs e)
        {

        }
        public DataSet ExcelToDS(string Path)
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string strExcel = "";
            OleDbDataAdapter myCommand = null;
            DataSet ds = null;


            DataTable schemaTable = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
            string tableName = schemaTable.Rows[0][2].ToString().Trim();
            

            strExcel = "select * from ["+tableName +"]";
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            ds = new DataSet();
            myCommand.Fill(ds, "table1");
            return ds;
        } 
        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            int k;  

            string exstring;
            int i = -1;
            int j = 0;

            int ii = 0;
            

            double[] y;
            double x1, y1;
            char[] sp;
           
           
            int L = 0;


            FormMultiAxisNoGrid f = new FormMultiAxisNoGrid();
            f.ShowDialog();

            this.scatterGraph1.ClearData();
             

            for (k = 0; k < this.scatterGraph1.YAxes.Count; k++)
            {
                this.scatterGraph1.YAxes[k].Visible = false;
            }

            for (k = 0; k < CComLibrary.GlobeVal.yselcount; k++)
            {

                this.scatterGraph1.Plots[k].LineStyle = LineStyle.Solid;

                if (CComLibrary.GlobeVal.yselpostion[k] == 0)
                {
                    this.scatterGraph1.YAxes[k].Position = YAxisPosition.Left;
                    this.scatterGraph1.YAxes[k].LeftCaptionOrientation = VerticalCaptionOrientation.TopToBottom;
                    this.scatterGraph1.YAxes[k].CaptionPosition = YAxisPosition.Left;
                    this.scatterGraph1.YAxes[k].CaptionVisible = true;
                }
                else
                {
                    this.scatterGraph1.YAxes[k].Position = YAxisPosition.Right;
                    this.scatterGraph1.YAxes[k].CaptionPosition = YAxisPosition.Right;
                    this.scatterGraph1.YAxes[k].LeftCaptionOrientation = VerticalCaptionOrientation.BottomToTop;
                    this.scatterGraph1.YAxes[k].CaptionVisible = true;

                }


                this.scatterGraph1.YAxes[k].Visible = true;
                this.scatterGraph1.Plots[k].YAxis = this.scatterGraph1.YAxes[k];

                if ((CComLibrary.GlobeVal.xsel - 1 >= 0) && (CComLibrary.GlobeVal.ysels[k] - 1 >= 0))
                {


                    this.scatterGraph1.Plots[k].XAxis.Caption = CComLibrary.GlobeVal.g_datatitle[CComLibrary.GlobeVal.xsel - 1] + "[" + CComLibrary.GlobeVal.g_dataunit[CComLibrary.GlobeVal.xsel - 1] + "]";



                    this.scatterGraph1.Plots[k].YAxis.CaptionForeColor = scatterGraph1.Plots[k].LineColor;



                    this.scatterGraph1.Plots[k].YAxis.Caption = CComLibrary.GlobeVal.g_datatitle[CComLibrary.GlobeVal.ysels[k] - 1] + "[" + CComLibrary.GlobeVal.g_dataunit[CComLibrary.GlobeVal.ysels[k] - 1] + "]";
                }

            }

            this.scatterGraph1.Plots[0].YAxis.Visible = true;

            List<string> mlistx=new List<string>();



            sp = new char[2];
            openFileDialog1.InitialDirectory = CComLibrary.GlobeVal.filesave.datapath ;
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "(*" + CComLibrary.GlobeVal.filesave.fileextname + ")|*"+
               CComLibrary.GlobeVal.filesave.fileextname;
            //openFileDialog1.Filter = "所有文件(*.*)|*.*|文本文件(*.txt)|*.txt|log文件(*.log)|*.log";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == null)
            {

            }
            else
            {
                string fileName = openFileDialog1.FileName;

                if (fileName == "")
                {

                }
                else
                {


                    toolStripStatusLabel_filename.Text = "试验数据文件名称;" + fileName;

                    exstring = Path.GetExtension(fileName);

                    if (exstring == ".mdb")
                    {

                        OleDbConnection conn = null;
                        OleDbDataReader reader = null;

                        conn = new OleDbConnection(
                        "Provider=Microsoft.Jet.OLEDB.4.0; " +
                        "Data Source=" + (fileName));
                        conn.Open();
                        OleDbCommand cmd =
                         new OleDbCommand("Select * FROM 实验数据", conn);
                        reader = cmd.ExecuteReader();



                        L = reader.FieldCount;
                        y = new double[L]; 
                        for (j = 0; j < reader.FieldCount; j++)
                        {

                            CComLibrary.GlobeVal.g_datatitle[j] = reader.GetName(j);
                            CComLibrary.GlobeVal.g_dataunit[j] = "";

                        }

                        i = 0;
                        ii = 0;

                        while (reader.Read())
                        {
                            i = i + 1;

                            ii = ii + 1;
                            if (ii>100)
                            {
                                for (j = 0; j < reader.FieldCount; j++)
                                {
                                    y[j] = Convert.ToDouble(reader[reader.GetName(j)]);
                                }

                                ii = 0;
                                for (k = 0; k < CComLibrary.GlobeVal.yselcount; k++)
                                {
                                    x1 = y[CComLibrary.GlobeVal.xsel];
                                    y1 = y[CComLibrary.GlobeVal.ysels[k]];
                                    this.scatterGraph1.Plots[k].PlotXYAppend(x1, y1);

                                }
                            }

                            

                        }

                    }
                }
            }

           
            
            
        }

        private void toolStrip2_Paint(object sender, PaintEventArgs e)
        {
            if ((sender as ToolStrip).RenderMode == ToolStripRenderMode.System)
            {
               // Rectangle rect = new Rectangle(0, 0, this.toolStrip2.Width - 8, this.toolStrip2.Height - 8);
               // e.Graphics.SetClip(rect);
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

        private void tsbselector_Click(object sender, EventArgs e)
        {

        }

        private void tsbselector_CheckedChanged(object sender, EventArgs e)
        {
            int l;
            scatterGraph1.InteractionModeDefault = NationalInstruments.UI.GraphDefaultInteractionMode.None;

            if (tsbselector.Checked == true)
            {
                scatterGraph1.Plots[0].GetXData();
                l=scatterGraph1.Plots[0].HistoryCount; 
                CComLibrary.GlobeVal.g_datadraw = new double[2][];

                CComLibrary.GlobeVal.g_datadraw[0] = new double[l];
                CComLibrary.GlobeVal.g_datadraw[1] = new double[l];
                CComLibrary.GlobeVal.g_datadraw[0] = scatterGraph1.Plots[0].GetXData();
                CComLibrary.GlobeVal.g_datadraw[1] = scatterGraph1.Plots[0].GetYData() ;

                xyCursorstart.Visible = true;
                xyCursorend.Visible = true;

                if (scatterPlot1.HistoryCount > 0)
                {
                    xyCursorstart.MoveCursor(0);

                    xyCursorend.MoveCursor(scatterPlot1.HistoryCount - 1);
                }
               
                toolStripbar.Enabled = true; 
            }
            else
            {
                xyCursorstart.Visible = false ;
                xyCursorend.Visible = false ;
                toolStripbar.Enabled = false; 
            }
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

        private void xyCursorstart_AfterMove(object sender, AfterMoveXYCursorEventArgs e)
        {
            toollabelshow.Text = "起始光标:" +"X:"+ e.XPosition.ToString("G4")+ "Y:" + e.YPosition.ToString("G4") ; 
        }

        private void xyCursorend_AfterMove(object sender, AfterMoveXYCursorEventArgs e)
        {
            toollabelshow.Text = "结束光标:" + "X:" + e.XPosition.ToString("G4") + "Y:" + e.YPosition.ToString("G4"); 
        }

        private void 最大峰值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[] t;
            int starti;
            int endi;
            int i;
            double mmax;
            double mmin;
            int  mmaxindex;
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
            t=new double[endi-starti+1];

            for (i=starti;i<=endi;i++)
            {
                t[i-starti]=CComLibrary.GlobeVal.g_datadraw[1][i];
            }
            NationalInstruments.Analysis.Math.ArrayOperation.MaxMin1D(t, out mmax, out mmaxindex,  out mmin, out mminindex);
            CComLibrary.LineStruct l=new CComLibrary.LineStruct();
            l.kind = 0;
            l.indexstart = starti + mmaxindex; 
            l.xstart =CComLibrary.GlobeVal.g_datadraw[0][l.indexstart];
            l.ystart =CComLibrary.GlobeVal.g_datadraw[1][l.indexstart]; 
            CComLibrary.GlobeVal.m_listline.Add(l);

            drawsign(l.xstart, l.ystart,l);

            this.outputwindow2.Text =
                 this.outputwindow2.Text + "最大峰值=" + l.ystart.ToString()+"\r\n";


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

            CComLibrary.GlobeVal.m_outputwindow.Text = CComLibrary.GlobeVal.m_outputwindow.Text + "峰值数量：" + amplitudesPeak.Length.ToString()+"\r\n";

            for (i = 0; i < locationsPeak.Length; i++)
            {
                CComLibrary.GlobeVal.m_outputwindow.Text = CComLibrary.GlobeVal.m_outputwindow.Text + "峰值位置：" + locationsPeak[i].ToString() + "\r\n";
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

                drawsign(l.xstart, l.ystart,l);

                CComLibrary.GlobeVal.m_outputwindow.Text = CComLibrary.GlobeVal.m_outputwindow.Text + "峰值：" + amplitudesPeak[i].ToString() + "\r\n";
            }
            scatterGraph1.Refresh(); 

        }

        private void tsbtnclear_Click(object sender, EventArgs e)
        {
            
        }

        private void tsbtnrecent_Click(object sender, EventArgs e)
        {
           
        }

        private void tsbtnclearall_Click(object sender, EventArgs e)
        {
            
            CComLibrary.GlobeVal.m_listline.Clear();
            scatterGraph1.Annotations.Clear(); 
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
            drawsign(l.xstart, l.ystart,l);
            CComLibrary.GlobeVal.m_listline.Add(l);

            this.outputwindow2.Text =
                 this.outputwindow2.Text + "最小谷值=" + l.ystart.ToString()+"\r\n";

            scatterGraph1.Refresh(); 
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
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

            double threshold=0;


            for (i = starti; i <= endi; i++)
            {
                t[i - starti] = CComLibrary.GlobeVal.g_datadraw[1][i];
            }

            PeakPolarity peakPolarity = PeakPolarity.Valleys;

            threshold = ArrayOperation.GetMax(CComLibrary.GlobeVal.g_datadraw[1]);
   
            NationalInstruments.Analysis.Monitoring.PeakDetector peakDetect
                = new NationalInstruments.Analysis.Monitoring.PeakDetector(threshold, (int)3, peakPolarity);

            

            peakDetect.Detect(t, true, out amplitudesPeak, out locationsPeak, out secondDerivativesPeak);

            CComLibrary.GlobeVal.m_outputwindow.Text = CComLibrary.GlobeVal.m_outputwindow.Text + "谷值数量：" + amplitudesPeak.Length.ToString() + "\r\n";

            for (i = 0; i < locationsPeak.Length; i++)
            {
                CComLibrary.GlobeVal.m_outputwindow.Text = CComLibrary.GlobeVal.m_outputwindow.Text + "谷值位置：" + locationsPeak[i].ToString() + "\r\n";
            }
            for (i = 0; i < locationsPeak.Length; i++)
            {
                j = Convert.ToInt16(locationsPeak[i]);

                CComLibrary.LineStruct l = new CComLibrary.LineStruct();
                l.kind = 0;
                l.indexstart = starti + j;
                l.xstart = CComLibrary.GlobeVal.g_datadraw[0][starti + j];
                l.ystart = CComLibrary.GlobeVal.g_datadraw[1][starti + j];

                drawsign(l.xstart, l.ystart,l); 

                CComLibrary.GlobeVal.m_listline.Add(l);

                CComLibrary.GlobeVal.m_outputwindow.Text = CComLibrary.GlobeVal.m_outputwindow.Text + "谷值：" + amplitudesPeak[i].ToString() + "\r\n";
            }
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

            CComLibrary.LineStruct  l1=new CComLibrary.LineStruct();
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
                        l1.xend, l1.yend,l1);
            
            this.outputwindow2.Text =
                  this.outputwindow2.Text + "直线斜率="+l1.value.ToString()+"\r\n";

            scatterGraph1.Refresh();


        }

        private void tsbtnslopeparallel_Click(object sender, EventArgs e)
        {
            xyCursorParallel.Visible = true; 
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {

        }

        private void scatterGraph1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void scatterGraph1_PlotAreaMouseDown(object sender, MouseEventArgs e)
        {
            
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
                scatterGraph1.Cursor = Cursors.Default ;
            }
        }

        private void scatterGraph1_PlotAreaMouseUp(object sender, MouseEventArgs e)
        {


           

            XYAnnotation  b;


            
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
                                    xyselectend.Visible = false ;
                                    xyselectend.Tag = b;
                                }
                            }

                        }
                    }
                    else
                    {
                        Point t=new Point();
                        t.X =e.X;
                        t.Y =e.Y ;
                        t = scatterGraph1.PointToScreen(t);
                        ctmnu.Tag = b;
                        ctmnu.Show(t.X , t.Y );

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

        private void xyselectstart_AfterMove(object sender, AfterMoveXYCursorEventArgs e)
        {
            PointF f=new PointF();

            int x;int y;

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
                 f= scatterPlot1.MapDataPoint(scatterPlot1.GetBounds(),xyselectstart.XPosition,xyselectstart.YPosition);
                 (xyselectstart.Tag as Panel).Left = Convert.ToInt16( f.X) ;
                 (xyselectstart.Tag as Panel).Top = Convert.ToInt16(f.Y); 
                 f= scatterPlot1.MapDataPoint(scatterPlot1.GetBounds(),xyselectend.XPosition,xyselectend.YPosition);
                 (xyselectstart.Tag as Panel).Width = Convert.ToInt16(f.X) - (xyselectstart.Tag as Panel).Left;
                 (xyselectstart.Tag as Panel).Height = Convert.ToInt16(f.Y)-(xyselectstart.Tag as Panel).Top; 
                 

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

        private void ctmnu编辑_Click(object sender, EventArgs e)
        {
            FormPopupMenu f = new FormPopupMenu();
            f.Tag = ctmnu.Tag;
            f.ShowDialog(); 

        }

        private void ctmnu_Opening(object sender, CancelEventArgs e)
        {

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

        private void scatterGraph1_PlotDataChanged(object sender, XYPlotDataChangedEventArgs e)
        {

        }



       

        private void tsbpoint_CheckedChanged(object sender, EventArgs e)
        {
            scatterGraph1.InteractionModeDefault = NationalInstruments.UI.GraphDefaultInteractionMode.None;
            mtsbpoint_bool = tsbpoint.Checked;
            scatterGraph1.Cursor = Cursors.Cross; 
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

            l1.xstart = CComLibrary.GlobeVal.g_datadraw[0][starti] ;
            l1.ystart = mean;

            l1.xend = CComLibrary.GlobeVal.g_datadraw[0][endi];
            l1.yend = mean;
            l1.value = mean;

            this.outputwindow2.Text =
            this.outputwindow2.Text + "平均值=" + l1.value.ToString()+"\r\n";


            CComLibrary.GlobeVal.m_listline.Add(l1);



            
            drawmline(l1.xstart, l1.ystart,
                        l1.xend, l1.yend,l1);

            
            scatterGraph1.Refresh(); 
        }

        private void scatterGraph1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            XAxis xx;

            xx = scatterGraph1.GetXAxisAt(e.X, e.Y);

            if (xx != null)
            {
                FormAxis f = new FormAxis();
                f.myplot = scatterGraph1;
                f.Tag = xx;
                f.Show();

            }

            YAxis yy;
            yy = scatterGraph1.GetYAxisAt(e.X, e.Y);

            if (yy != null)
            {

                FormAxis f = new FormAxis();
                f.myplot = scatterGraph1; 
                f.Tag = yy;
                f.Show();
            }



           
        }

        private void 曲线设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPlot fp = new FormPlot();
            
            
            fp.Show();
        }

        public static void KillExcelProcess()
        {
            System.Diagnostics.Process[] myPs;
            myPs = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process p in myPs)
            {
                if (p.Id != 0)
                {
                    string myS = "excel.EXE" + p.ProcessName + "  ID:" + p.Id.ToString();
                    try
                    {
                        if (p.Modules != null)
                            if (p.Modules.Count > 0)
                            {
                                System.Diagnostics.ProcessModule pm = p.Modules[0];
                                myS += "\n Modules[0].FileName:" + pm.FileName;
                                myS += "\n Modules[0].ModuleName:" + pm.ModuleName;
                                myS += "\n Modules[0].FileVersionInfo:\n" + pm.FileVersionInfo.ToString();
                                if (pm.ModuleName.ToLower() == "excel.exe")
                                    p.Kill();
                            }
                    }
                    catch
                    { }
                    finally
                    {
                        ;
                    }
                }
            }
        }

        public static void KillWordProcess()
        {
            System.Diagnostics.Process[] myPs;
            myPs = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process p in myPs)
            {
                if (p.Id != 0)
                {
                    string myS = "WINWORD.EXE" + p.ProcessName + "  ID:" + p.Id.ToString();
                    try
                    {
                        if (p.Modules != null)
                            if (p.Modules.Count > 0)
                            {
                                System.Diagnostics.ProcessModule pm = p.Modules[0];
                                myS += "\n Modules[0].FileName:" + pm.FileName;
                                myS += "\n Modules[0].ModuleName:" + pm.ModuleName;
                                myS += "\n Modules[0].FileVersionInfo:\n" + pm.FileVersionInfo.ToString();
                                if (pm.ModuleName.ToLower() == "winword.exe")
                                    p.Kill();
                            }
                    }
                    catch
                    { }
                    finally
                    {
                        ;
                    }
                }
            }
        }
        private void tsbprintreport_Click(object sender, EventArgs e)
        {
            
        }

        private void tsbcontrol_Click(object sender, EventArgs e)
        {
            mtsbcontrol_bool = tsbcontrol.Checked;
            scatterGraph1.Cursor = Cursors.Cross; 
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            FormWord f = new FormWord();
            f.Show();
        }

        private void tsbzoomout_Click_1(object sender, EventArgs e)
        {

        }

        private void tsbrect_Click_1(object sender, EventArgs e)
        {

        }


        public void savetemp()
        {
            FileStream fs = new FileStream("c:\\t.temp", FileMode.Open);
            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            sw.Write(tcboproject.SelectedIndex.ToString());
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close(); 
        }

        public void loadtemp()
        {
            if (File.Exists("c:\\t.temp")==true)
            {
            StreamReader sr = new StreamReader("c:\\t.temp", Encoding.Default);
            String line;

            line = sr.ReadLine();

            sr.Close();
 
            if  ((Convert.ToInt16(line)>=0) && (Convert.ToInt16(line)<=tcboproject.Items.Count-1))
            {
                tcboproject.SelectedIndex = Convert.ToInt16(line);
            }
            }
 
        }

        private void 内容CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 保存bmp文件_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            //scatterGraph1  
            scatterGraph1.ToFile("c:\\曲线.bmp",ImageType.Bmp);  
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            object oMissing = System.Reflection.Missing.Value;

            Bitmap b = new Bitmap(scatterGraph1.Width, scatterGraph1.Height);
            Graphics f = scatterGraph1.CreateGraphics();

            scatterGraph1.DrawToBitmap(b, new Rectangle(0, 0, b.Width, b.Height));

            b.Save("d:\\1.jpg", ImageFormat.Jpeg);

            Word._Application objApp = default(Word._Application);
            Word._Document objDoc;
            try
            {
                object objMiss = System.Reflection.Missing.Value;
                object objEndOfDocFlag = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

                //Start Word and create a new document.
                objApp = new Word.Application();
                objApp.Visible = true;
                objDoc = objApp.Documents.Add(ref objMiss, ref objMiss,
                    ref objMiss, ref objMiss);

                //Insert a paragraph at the end of the document.
                Word.Paragraph objPara2; //define paragraph object
                object oRng = objDoc.Bookmarks.get_Item(ref objEndOfDocFlag).Range; //go to end of the page
                objPara2 = objDoc.Content.Paragraphs.Add(ref oRng); //add paragraph at end of document
                objPara2.Range.Text = tcboproject.Text  ; //add some text in paragraph
                objPara2.Range.Font.Bold = 1;
                objPara2.Range.Font.Size = 32;
                objPara2.Range.ParagraphFormat.Alignment =
                    Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                objPara2.Format.SpaceAfter = 10; //defind some style
                objPara2.Range.InsertParagraphAfter(); //insert paragraph
                objPara2.Range.Font.Bold = 0;
                objPara2.Range.Font.Size = 12;
                objPara2.Range.ParagraphFormat.Alignment =
                   Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                //Insert a 2 x 2 table, (table with 2 row and 2 column)
                Word.Table objTab1; //create table object
                Word.Range objWordRng = objDoc.Bookmarks.get_Item(ref objEndOfDocFlag).Range; //go to end of document

                objTab1 = objDoc.Tables.Add(objWordRng, _UResultControl.listEditor1.List.Count, 3, ref objMiss, ref objMiss); //add table object in word document
                object  c="网格型";
                objTab1.set_Style(ref c);
                objTab1.Range.ParagraphFormat.SpaceAfter = 6;
                int iRow, iCols;
                string strText;


                for (iRow = 1; iRow <= _UResultControl.listEditor1.List.Count; iRow++)
                 
                    {
                   
                        objTab1.Cell(iRow, 1).Range.Text = (_UResultControl.listEditor1.List[iRow-1] as SampleProject.Extensions.ChartBar).名称;
                       objTab1.Cell(iRow, 2).Range.Text = (_UResultControl.listEditor1.List[iRow-1] as SampleProject.Extensions.ChartBar).值.ToString();
                        objTab1.Cell(iRow, 3).Range.Text = (_UResultControl.listEditor1.List[iRow-1] as SampleProject.Extensions.ChartBar).单位;


                    }
                //objTab1.Rows[1].Range.Font.Bold = 1; //make first row of table BOLD
                //objTab1.Columns[1].Width = objApp.InchesToPoints(3); //increase first column width



                //Add some text after table
                objWordRng = objDoc.Bookmarks.get_Item(ref objEndOfDocFlag).Range;
                objWordRng.InsertParagraphAfter(); //put enter in document
                objWordRng.InsertAfter("计算结果:");
                objWordRng.InsertParagraphAfter(); 

               
                objWordRng = objDoc.Bookmarks.get_Item(ref objEndOfDocFlag).Range;
                objWordRng.InsertParagraphAfter(); //put enter in document

                 objWordRng = objDoc.Bookmarks.get_Item(ref objEndOfDocFlag).Range; //go to end of document

                objTab1 = objDoc.Tables.Add(objWordRng, _UResultControl.listView1.Items.Count,
                    _UResultControl.listView1.Columns.Count 
                    , ref objMiss, ref objMiss); //add table object in word document
                c = "网格型";
                objTab1.set_Style(ref c);
                objTab1.Range.ParagraphFormat.SpaceAfter = 6;

                
                
                for (iRow = 1; iRow <= _UResultControl.listView1.Items.Count ; iRow++)
                {
                    for (int j = 0; j < _UResultControl.listView1.Columns.Count  ; j++)
                    {
                        
                        {
                            //objTab1.Cell(iRow, j).Range.Text = _UResultControl.listView1.Items[iRow].SubItems[j].Text;
                            //objTab1.Cell(iRow, 1).Range.Text = _UResultControl.listView1.Items[iRow - 1].Text;
                            objTab1.Cell(iRow, j+1).Range.Text = _UResultControl.listView1.Items[iRow-1].SubItems[j].Text;

                        }
                        

                    }

                }
                //objTab1.Rows[0].Range.Font.Bold = 1; //make first row of table BOLD

                objWordRng = objDoc.Bookmarks.get_Item(ref objEndOfDocFlag).Range;
                objWordRng.InsertParagraphAfter(); //put enter in document
                objWordRng.InsertAfter("试验曲线:");
                objWordRng.InsertParagraphAfter();
                objWordRng = objDoc.Bookmarks.get_Item(ref objEndOfDocFlag).Range;

                objWordRng.InlineShapes.AddPicture("d:\\1.jpg", ref oMissing, ref oMissing, ref oMissing);

                object szPath = "test.docx"; //your file gets saved with name 'test.docx'
                objDoc.SaveAs(ref szPath, ref oMissing, ref oMissing, ref oMissing,
  ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
  ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
  ref oMissing, ref oMissing);

                //objDoc.Close(ref oMissing, ref oMissing, ref oMissing);
                //关闭word  
                //objApp.Quit(ref oMissing, ref oMissing, ref oMissing);  


                //KillWordProcess();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error occurred while executing code : " + ex.Message);
            }
            finally
            {
                //you can dispose object here
            }

        }

        private void tsbarrow_Click_1(object sender, EventArgs e)
        {

        }

        private void tsbtnleastslope_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {

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
            this.outputwindow2.Text =
                  this.outputwindow2.Text + "水平差值计算=" + l1.value.ToString() + "\r\n";

          


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

            l1.value = Math.Abs(l1.ystart- l1.yend);
            this.outputwindow2.Text =
                  this.outputwindow2.Text + "垂直差值计算=" + l1.value.ToString() + "\r\n";

        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            //CComLibrary.GlobeVal.gcalc.Initialize通道();

            //FormChannel f = new FormChannel();

            //f.Show();

            
        }

        private void toolStripLabel8_Click(object sender, EventArgs e)
        {

        }

        private void toolStripCboKind_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (System.IO.Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\method\\" + toolStripCboKind.Text))
            {

            }
            else
            {
                System.IO.Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\method\\" + toolStripCboKind.Text);
            
            }
            

            tcboproject.Items.Clear();

            string[] subfolders = Directory.GetFiles(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\method\\" + toolStripCboKind.Text);
            foreach (string s in subfolders)
            {
               
                tcboproject.Items.Add(Path.GetFileNameWithoutExtension(s));
                tcboproject.SelectedIndex = 0;
            }

            //CComLibrary.GlobeVal.filesave.methodkind = toolStripCboKind.SelectedIndex;

           // Application.StartupPath + "\\method\\" + toolStripCboKind.Text);

        }


        public int readfilelen(string fileName,out int L)
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

        public int  readdemo(string fileName,int len,int L)
        {
            int i = -1;
            int j = 0;
            Type l_Type;
            

            char[] sp;
            char[] sp1;
            string[] ww;

            string line;



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




                        }
                    }
                    else
                    {

                        sp[0] = Convert.ToChar(" ");

                        ww = line.Split(sp);

                        


                        for (int k=0;k<L;k++)
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

        private void toolStripButton17_Click(object sender, EventArgs e)
        {
           
           
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            
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
    }
}
