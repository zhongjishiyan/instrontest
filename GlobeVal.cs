using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using ADOX;

using AForge.Video;
using AForge.Video.DirectShow;
using System.Diagnostics;
using AForge.Video.FFMPEG;

namespace TabHeaderDemo
{
    public sealed  class   GlobeVal
    {

        [DllImport("kernel32.dll")]
        public  static extern UIntPtr SetThreadAffinityMask(IntPtr hThread,
        UIntPtr dwThreadAffinityMask);

        //得到当前线程的handler  
        [DllImport("kernel32.dll")]
        public  static extern IntPtr GetCurrentThread();

        //获取cpu的id号  
        public  static ulong SetCpuID(int id)
        {
            ulong cpuid = 0;
            if (id < 0 || id >= System.Environment.ProcessorCount)
            {
                id = 0;
            }
            cpuid |= 1UL << id;

            return cpuid;
        }

        private readonly int MOUSEEVENTF_LEFTDOWN = 0x2;
        private readonly int MOUSEEVENTF_LEFTUP = 0x4;
        [DllImport("user32")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        public GlobeVal()
        {
          
        }
        public static   string mmethodfilename;

        public static CComLibrary.FileStruct filesavecmp;

        public static int lastindex = -1;

        public static Panel dopanel;

        public static  Panel backpanel;
        public static  UserControlTest  userControltest1;
        public static UserControlMain UserControlMain1;
        public static UserControlPretest userControlpretest1;
        public static UserControlMethod userControlmethod1;

        public static Button mbtntest;
        public static  UserControlDynSet dynset;
        public static  UserControlWizard wizard;

        public static UserControlProcess UserControlProcess1;
        public static bool resizing = false;
        public static ClassSys mysys;


        public static UserControlResult UserControlResult1;
        public static UserControlResult UserControlResult2;
        public static UserControlSpe UserControlSpe1;
        public static UserControlGraph UserControlGraph1;
        public static UserControlGraph UserControlGraph2;
        public static UserControlCamera1 UserControlCamera;

        public static UserControlRawdata UserControlRawdata1;
        public static UserControlLongRecord UserControlLongRecord1;

        public static bool suc = false;

        public static bool ShowCameraForm = false;

        public static  VideoCaptureDevice cam1;     //视频的来源选择

        public static ClsStaticStation.ClsBaseControl myarm;


        public static UserReport muserreport;


        public static string username = "";
        public static string userpassword = "";
        public static int userkind = 0;

        public static string spefilename = "";

        public static StatusStrip MainStatusStrip;

        public static FormMainLab FormmainLab;


        public static string str_General_test;
        public static string str_Intermediate_Test;
        public static string str_Simple_test;
        public static string str_Advanced_test;


        public static void Init_Global_String_resource()
        {
            if (GlobeVal.mysys.language ==0)
            {
                str_General_test = "一般测控";
                str_Intermediate_Test = "中级测控";
                str_Simple_test = "简单控制";
                str_Advanced_test = "高级测控";
            }
            else
            {
                str_General_test = "General test";
                str_Intermediate_Test = "Intermediate test";
                str_Simple_test = "Simple test";
                str_Advanced_test = "Advanced test";
            }
        }

        public static void putlistboxitem(ListBox listBox1)
        {
            listBox1.Items.Clear();
            if (GlobeVal.mysys.language == 0)
            {
                listBox1.Items.Add("试验方法类型：" + ClsStaticStation.m_Global.mycls.TestkindList[CComLibrary.GlobeVal.filesave.methodkind]);
                listBox1.Items.Add("试验方法描述：" + CComLibrary.GlobeVal.filesave.methodmemo);
                listBox1.Items.Add("试验方法作者：" + CComLibrary.GlobeVal.filesave.methodauthor);
            }
            else
            {
                listBox1.Items.Add("Type of test method：" + ClsStaticStation.m_Global.mycls.TestkindList[CComLibrary.GlobeVal.filesave.methodkind]);
                listBox1.Items.Add("Description of test method：" + CComLibrary.GlobeVal.filesave.methodmemo);
                listBox1.Items.Add("Author of test method：" + CComLibrary.GlobeVal.filesave.methodauthor);
                

            }

            string ms = "";

            if (CComLibrary.GlobeVal.filesave.UseDatabase == true)
            {
                if (GlobeVal.mysys.language == 0)
                {

                    ms = "是";
                }
                else
                {
                    ms = "Yes";
                }
            }
            else
            {
                if (GlobeVal.mysys.language == 0)
                {
                    ms = "否";
                }
                else
                {
                    ms = "No";
                }
            }

            if (GlobeVal.mysys.language == 0)
            {
                listBox1.Items.Add("试验结果是否保存到数据库：" + ms);
            }
            else
            {
                listBox1.Items.Add("The test results are saved to the database：" + ms);
            }
            if (CComLibrary.GlobeVal.filesave.mwizard == true)
            {
                if (GlobeVal.mysys.language == 0)
                {
                    ms = "是";
                }
                else
                {
                    ms = "Yes";
                }
            }
            else
            {
                if (GlobeVal.mysys.language == 0)
                {
                    ms = "否";
                }
                else
                {
                    ms = "No";
                }
            }

            if (GlobeVal.mysys.language == 0)
            {
                listBox1.Items.Add("试验过程带提示：" + ms);
            }
            else
            {
                listBox1.Items.Add("Test process with hints：" + ms);
                
            }


            if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 0)
            {
                string _temp = "";

                if (GlobeVal.mysys.language ==0)
                {
                    _temp = "控制过程:" + "一般测控";
                }
                else
                {
                    _temp = "Control flow:" + "General test";
                }

                listBox1.Items.Add(_temp);
              
            }
            else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 1)
            {
                string _temp = "";

                if (GlobeVal.mysys.language == 0)
                {
                    _temp = "控制过程: " + "中级测控";
                }
                else
                {
                    _temp = "Control flow:" + "Intermediate test";
                }
                listBox1.Items.Add(_temp);
            }
            else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 2)
            {
                string _temp = "";

                if (GlobeVal.mysys.language ==0)
                {
                    _temp = "控制过程:" + "简单控制";
                }
                else
                {
                    _temp = "Control flow:" + "Simple test";
                }
                listBox1.Items.Add(_temp);
            }
            else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 3)
            {

                string _temp = "";
                if (GlobeVal.mysys.language ==0)

                {
                    _temp = "控制过程:" + "高级测控";
                }
                else
                {
                    _temp = "Control flow:" + "Advanced test";
                }

                listBox1.Items.Add(_temp);
            }


            CComLibrary.GlobeVal.filesave.InitExplainList();

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mexplainlist.Count; i++)
            {
                string s;
                if (GlobeVal.mysys.language == 0)
                {
                    s = "   " + "步骤" + (i + 1).ToString() + " " + CComLibrary.GlobeVal.filesave.mexplainlist[i].explain(GlobeVal.mysys.machinekind);
                }
                else
                {
                    s = "   " + "Step " + (i + 1).ToString() + " " + CComLibrary.GlobeVal.filesave.mexplainlist[i].explain(GlobeVal.mysys.machinekind);
                }
                listBox1.Items.Add(s);
            }

            if (CComLibrary.GlobeVal.filesave.Samplingmode == 0)
            {
                if (GlobeVal.mysys.language == 0)
                {
                    ms = "静态采集";
                }
                else
                {
                    ms = "Static acquisition";
                }

            }
            else
            {
                if (GlobeVal.mysys.language == 0)
                {
                    ms = "动态采集";
                }
                else
                {
                    ms = "Dynamic acquisition";
                }
            }


            if (GlobeVal.mysys.language == 0)
            {
                listBox1.Items.Add("数据采集方式：" + ms);
            }
            else
            {
                listBox1.Items.Add("Data Capture mode：" + ms);
            }

            if (CComLibrary.GlobeVal.filesave.Samplingmode == 0)
            {
                ms = "";
                if ( CComLibrary.GlobeVal.filesave.chkcriteria[0] == true)
                {
                    if (GlobeVal.mysys.language == 0)
                    {
                        ms = ms + "准则1";
                    }
                    else
                    {
                        ms = ms + "Criteria 1";
                    }
                }
                if (CComLibrary.GlobeVal.filesave.chkcriteria[1] == true)
                {
                    if (GlobeVal.mysys.language == 0)
                    {
                        ms = ms + "准则2";
                    }
                    else
                    {
                        ms = ms + "Criteria 2";
                    }
                }

                if (CComLibrary.GlobeVal.filesave.chkcriteria[2] == true)
                {
                    if (GlobeVal.mysys.language == 0)
                    {
                        ms = ms + "准则3";
                    }
                    else
                    {
                        ms = ms + "Criteria 3";
                    }
                }

                if (ms=="")
                {
                    if (GlobeVal.mysys.language == 0)
                    {
                        ms = "无";
                    }
                    else
                    {
                        ms = "None";
                    }
                }

                if (GlobeVal.mysys.language == 0)
                {
                    listBox1.Items.Add("数据采集准则：" + ms);
                }
                else
                {
                    listBox1.Items.Add("Data acquisition criteria：" + ms);
                }
            }

            if (CComLibrary.GlobeVal.filesave.mplotpara1.dynamicdraw == true)
            {
                if (mysys.language == 0)
                {
                    ms = "动态绘制方式";
                }
                else
                {
                    ms = "Dynamic drawing data curve";
                }
                if (mysys.language == 0)
                {
                    listBox1.Items.Add("曲线1：" + ms);
                }
                else
                {
                    listBox1.Items.Add("Graph 1：" + ms);
                }
            }

            if (mysys.language == 0)
            {
                listBox1.Items.Add("结果表格1：");
            }
            else
            {
                listBox1.Items.Add("Result 1：");
            }
            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mtablecol1.Count; i++)
            {
                string s;
                if (mysys.language == 0)
                {
                    s = "   列" + (i + 1).ToString() + "：" + CComLibrary.GlobeVal.filesave.mtablecol1[i].formulaname;
                }
                else
                {
                    s = "   Column" + (i + 1).ToString() + "：" + CComLibrary.GlobeVal.filesave.mtablecol1[i].formulaname;
                }
                listBox1.Items.Add(s);
            }

            if (CComLibrary.GlobeVal.filesave.mrawdata.Count > 0)
            {
                if (mysys.language == 0)
                {
                    listBox1.Items.Add("原始数据输出：");
                }
                else
                {
                    listBox1.Items.Add("Raw data output:");
                }
                for (int i = 0; i < CComLibrary.GlobeVal.filesave.mrawdata.Count; i++)
                {
                    string s = "";
                    if (mysys.language == 0)
                    {
                        s = "   列" + (i + 1).ToString() + "：" + CComLibrary.GlobeVal.filesave.mrawdata[i].cName;
                    }
                    else
                    {
                        s = "   Column" + (i + 1).ToString() + "：" + CComLibrary.GlobeVal.filesave.mrawdata[i].cName;
                    }
                    listBox1.Items.Add(s);
                }
            }
            if (CComLibrary.GlobeVal.filesave.mlongdata.Count > 0)
            {
                if (mysys.language == 0)
                {
                    listBox1.Items.Add("峰值趋势数据输出：");
                }
                else
                {
                    listBox1.Items.Add("Trend of peak and valley value：");
                }
                for (int i = 0; i < CComLibrary.GlobeVal.filesave.mlongdata.Count; i++)
                {
                    string s = "";

                    if (mysys.language == 0)
                    {
                        s = "   列" + (i + 1).ToString() + "：" + CComLibrary.GlobeVal.filesave.mlongdata[i].cName;
                    }
                    else
                    {
                        s = "   Column" + (i + 1).ToString() + "：" + CComLibrary.GlobeVal.filesave.mlongdata[i].cName;
                    }
                    listBox1.Items.Add(s);
                }
            }
        }
        public static  void NewDatabase()
        {
            //CComLibrary.GlobeVal.filesave.SampleDefaultName

            if (System.IO.Directory.Exists(Application.StartupPath + "\\mdb") == true)
            {
                System.IO.Directory.CreateDirectory(Application.StartupPath + "\\mdb");
            }


            if (File.Exists(Application.StartupPath + "\\mdb\\" + CComLibrary.GlobeVal.filesave.methodname + ".mdb") == true)
            {
                File.Delete(Application.StartupPath + "\\mdb\\" + CComLibrary.GlobeVal.filesave.methodname + ".mdb");
            }

            ADOX.Catalog catalog = new Catalog();
            catalog.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\mdb\\" + CComLibrary.GlobeVal.filesave.methodname + ".mdb;" + "Jet OLEDB:Engine Type=5");

            ADODB.Connection cn = new ADODB.Connection();

            cn.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\mdb\\" + CComLibrary.GlobeVal.filesave.methodname + ".mdb", null, null, -1);



            catalog.ActiveConnection = cn;

            ADOX.Table table = new ADOX.Table();
            table.Name = "FirstTable";

            ADOX.Column column = new ADOX.Column();
            column.ParentCatalog = catalog;
            column.Name = "RecordId";
            column.Type = DataTypeEnum.adInteger;
            column.DefinedSize = 9;
            column.Properties["AutoIncrement"].Value = true;
            table.Columns.Append(column, DataTypeEnum.adInteger, 9);
            table.Keys.Append("FirstTablePrimaryKey", KeyTypeEnum.adKeyPrimary, column, null, null);

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mdatabaseitemselect.Count; i++)
            {
                column = new ADOX.Column();

                column.Name = CComLibrary.GlobeVal.filesave.mdatabaseitemselect[i].Name;
                column.Attributes = ColumnAttributesEnum.adColNullable;
                table.Columns.Append(column, DataTypeEnum.adVarWChar, 80);

               
            }


            // table.Columns.Append("CustomerName", DataTypeEnum.adVarWChar, 50);
            // table.Columns.Append("Age", DataTypeEnum.adInteger, 9);
            // table.Columns.Append("生日", DataTypeEnum.adVarWChar, 80);

            catalog.Tables.Append(table);
            cn.Close();

        }
        public static  void SaveDatabase()
        {
            ADODB.Connection cn = new ADODB.Connection();

            cn.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\mdb\\" + CComLibrary.GlobeVal.filesave.methodname + ".mdb", null, null, -1);
            ADODB.Recordset rs;

            rs = new ADODB.Recordset();

            rs.LockType = ADODB.LockTypeEnum.adLockPessimistic;
            rs.CursorType = ADODB.CursorTypeEnum.adOpenDynamic;

            string sql = "select * from FirstTable";
            rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, (int)ADODB.CommandTypeEnum.adCmdText);

            if ((rs.RecordCount > 0))
            {
                rs.MoveFirst();
            }
            string mshiyanghao = "";
            string myangpinmingcheng = "";
            int nshiyanhao = 0;
            int nyangpinmingcheng = 0;
            int nRecordId = 0;
            for (int j = 0; j < CComLibrary.GlobeVal.filesave.mdatabaseitemselect.Count; j++)
            {


                if (CComLibrary.GlobeVal.filesave.mdatabaseitemselect[j].Name == "试样号")
                {
                    mshiyanghao = CComLibrary.GlobeVal.filesave.mdatabaseitemselect[j].Value;
                    nshiyanhao = j;
                }
                if (CComLibrary.GlobeVal.filesave.mdatabaseitemselect[j].Name == "样品名称")
                {
                    myangpinmingcheng = CComLibrary.GlobeVal.filesave.mdatabaseitemselect[j].Value;
                    nyangpinmingcheng = j;
                }
            }


            bool mb = false;
            string wshiyanghao = "";
            string wyangpinmingcheng = "";
            for (int i = 0; i < rs.RecordCount; i++)
            {
                wshiyanghao = Convert.ToString(rs.Fields[nshiyanhao + 1].Value);
                wyangpinmingcheng = Convert.ToString(rs.Fields[nyangpinmingcheng + 1].Value);
                if ((wshiyanghao == mshiyanghao) && (wyangpinmingcheng == myangpinmingcheng))
                {
                    mb = true;

                    nRecordId = Convert.ToInt32(rs.Fields[0].Value);
                    break;
                }
                else
                {
                    rs.MoveNext();
                }

            }

            for (int i = 0; i < 1; i++)
            {


                object missing = System.Reflection.Missing.Value;
                if (mb == false)
                {

                    rs.AddNew(missing, missing);
                    rs.Fields["RecordId"].Value = rs.RecordCount;
                }
                else
                {
                    rs.Delete(ADODB.AffectEnum.adAffectCurrent);
                    rs.AddNew(missing, missing);
                    rs.Fields["RecordId"].Value = nRecordId;
                }



                for (int j = 0; j < CComLibrary.GlobeVal.filesave.mdatabaseitemselect.Count; j++)
                {
                    if (CComLibrary.GlobeVal.filesave.mdatabaseitemselect[j].Value == null)
                    {
                        rs.Fields[j + 1].Value = "";
                    }
                    else
                    {
                        rs.Fields[j + 1].Value = CComLibrary.GlobeVal.filesave.mdatabaseitemselect[j].Value;
                    }

                }


                rs.Update();
            }


            rs.Close();
            cn.Close();


        }

    }
}
