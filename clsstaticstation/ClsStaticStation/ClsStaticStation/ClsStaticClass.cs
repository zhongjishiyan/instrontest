using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using log4net;
using System.IO;

namespace ClsStaticStation
{
    class ClsStaticClass
    {
    }

    [Serializable]
    public struct RawDataStruct
    {
        public double[] data;

        public int hardlimitlow;
        public int hardlimitup;
        public int softlimitlow;
        public int softlimitup;
        public int ctrlstate1;
        public int ctrlstate2;
        public UInt16 ctrl_state_s;
        public UInt16 ctrl_state_f;
        public UInt16 ctrl_state_e;
        public UInt16 ctrl_halt;
        public UInt16 ctrl_down;
        public UInt16 ctrl_up;
        public UInt16 ctrl_move;
        public UInt16 ctrl_ready;
        public UInt16 ctrl_soft_set;
        public UInt16 ctrl_lower_sft_s;
        public UInt16 ctrl_lower_sft_f;
        public UInt16 ctrl_lower_sft_e;
        public UInt16 ctrl_upper_sft_s;
        public UInt16 ctrl_upper_sft_f;
        public UInt16 ctrl_upper_sft_e;


    }

    public struct RawDataDataGroup
    {
        public int ID;
        public RawDataData rdata;

    }

    public struct RawDataData
    {
        public double data0;
        public double data1;
        public double data2;
        public double data3;
        public double data4;
        public double data5;
        public double data6;
        public double data7;
        public double data8;
        public double data9;
        public double data10;
        public double data11;
        public double data12;
        public double data13;
        public double data14;
        public double data15;
        public double data16;
        public double data17;
        public double data18;
        public double data19;
        public double data20;
        public double data21;
        public double data22;
        public double data23;
        public int hardlimitlow;
        public int hardlimitup;
        public int softlimitlow;
        public int softlimitup;
        public int ctrlstate1;
        public int ctrlstate2;
        public UInt16 ctrl_state_s;
        public UInt16 ctrl_state_f;
        public UInt16 ctrl_state_e;
        public UInt16 ctrl_halt;
        public UInt16 ctrl_down;
        public UInt16 ctrl_up;
        public UInt16 ctrl_move;
        public UInt16 ctrl_ready;
        public UInt16 ctrl_soft_set;
        public UInt16 ctrl_lower_sft_s;
        public UInt16 ctrl_lower_sft_f;
        public UInt16 ctrl_lower_sft_e;
        public UInt16 ctrl_upper_sft_s;
        public UInt16 ctrl_upper_sft_f;
        public UInt16 ctrl_upper_sft_e;


    }
    /*
    public class LogHelper
    {
      // public static log4net.Layout.PatternLayout layout;
       // public static log4net.Appender.FileAppender appender;
       // public static ILog log;

        private static ListBox mli;

        private static bool mIsInfoEnabled;
        private static bool mIsWarnEnabled;
        private static bool mIsDebugEnabled;
        private static bool mIsErrorEnabled;


        private static string mfilename;
        public LogHelper()
        {



        }
        public static void SetConfig(Boolean IsInfoEnabled, bool IsWarnEnabled, bool IsDebugEnabled, bool IsErrorEnabled)
        {
            mIsInfoEnabled = IsInfoEnabled;
            mIsWarnEnabled = IsWarnEnabled;
            mIsDebugEnabled = IsDebugEnabled;
            mIsErrorEnabled = IsErrorEnabled;


        }

        public static void Close()
        {
            LogManager.Shutdown();
        }

        public static void SetMessageControl(ListBox li)
        {
            mli = li;
        }

        public static void SetFileName(string filename)
        {
            layout = new log4net.Layout.PatternLayout("%d %p %m %n");
            appender = new log4net.Appender.FileAppender(layout, filename, true);

            log4net.Config.BasicConfigurator.Configure(appender);
            log = LogManager.GetLogger("loginfo");
            mfilename = filename;

        }

        private static string readlastinfo()
        {
            string s = "";
            using (FileStream fs = new FileStream(mfilename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        s = sr.ReadLine();
                    }
                }
            }
            return s;
        }
       
        public static void WriteLogInfo(string info)
        {
            string s;

            if (log.IsInfoEnabled)
            {
                if (mIsInfoEnabled)
                {
                    log.Info(info);

                    if (mli.Items.Count > 1000)
                        mli.Items.RemoveAt(0);


                    //mli.Items.Add(readlastinfo());

                    s = DateTime.Now.ToString() + " 信息 " + info;
                    mli.Items.Add(s);

                    mli.SelectedIndex = mli.Items.Count - 1;
                    mli.SelectedIndex = -1;
                }
            }
        }
        
        public static void WriteLogError(string info, Exception se)
        {
            string s;
            if (log.IsErrorEnabled)
            {
                if (mIsErrorEnabled)
                {
                    log.Error(info, se);
                    if (mli.Items.Count > 1000)
                        mli.Items.RemoveAt(0);

                    s = DateTime.Now.ToString() + " 错误 " + info;
                    mli.Items.Add(s);
                    mli.SelectedIndex = mli.Items.Count - 1;
                    mli.SelectedIndex = -1;
                }
            }
        }

        public static void WriteLogWarn(string info, Exception se)
        {
            string s;
            if (log.IsWarnEnabled)
            {
                if (mIsWarnEnabled)
                {
                    log.Warn(info, se);
                    if (mli.Items.Count > 1000)
                        mli.Items.RemoveAt(0);
                    s = DateTime.Now.ToString() + " 警告 " + info;
                    mli.Items.Add(s);
                    mli.SelectedIndex = mli.Items.Count - 1;
                    mli.SelectedIndex = -1;
                }
            }
        }

        public static void WriteLogDebug(string info, Exception se)
        {
            string s;
            if (log.IsDebugEnabled)
            {
                if (mIsDebugEnabled)
                {
                    log.Debug(info, se);
                    if (mli.Items.Count > 1000)
                        mli.Items.RemoveAt(0);
                    s = DateTime.Now.ToString() + " 调试 " + info;
                    mli.Items.Add(s);
                    mli.SelectedIndex = mli.Items.Count - 1;
                    mli.SelectedIndex = -1;
                }
            }
        }

    }  */
    [Serializable]


    public class TreeViewHard : TreeView
    {
        private TreeNodeHard m_lastnode;
        public TreeViewHard()
        {

        }

        public void InsertLine(int pos, int level, ItemSignal cc)
        {

            TreeNodeHard aa = new TreeNodeHard();
            aa.SelectedImageIndex = cc.imageindex;
            aa.ImageIndex = cc.imageindex;
            aa.isl = cc;

            if (level == -1)
            {
                aa.Text = cc.cName;
                base.Nodes.Add(aa);

            }
            else
            {

                aa.Text = cc.cName;

                if (m_lastnode.Level == cc.level)
                {
                    m_lastnode.Parent.Nodes.Add(aa);
                }
                else if (m_lastnode.Level > cc.level)
                {
                    while (m_lastnode.Level > cc.level)
                    {
                        m_lastnode = (TreeNodeHard)m_lastnode.Parent;
                    }

                    m_lastnode.Parent.Nodes.Add(aa);

                }
                else
                {
                    m_lastnode.Nodes.Add(aa);
                }

            }

            m_lastnode = aa;
            base.ExpandAll();

        }


    }



    public class TreeNodeHard : TreeNode
    {
        public TreeNodeHard()
        {

        }

        public ItemBaseSignal isl;
        public int ChannelId = -1;
        public bool Channel_Amend = false;//通道可以修正


    }

    

}

