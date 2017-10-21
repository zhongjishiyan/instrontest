//#define DSP_ONDATABLOCK
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using Microsoft.VisualBasic.Compatibility;
using System.Windows.Forms;
using DoPE_HANDLE = System.Int32;
using XLNet;

namespace ClsStaticStation
{
    public class CDsp : ClsBaseControl
    {

        private float[] rr;
        private System.Windows.Forms.Timer mtimer;
        public XLNet.XLDOPE.Data  GGMsg;
        private RawDataStruct b;
        public short DeviceNum = 1;

        private int m_runstate;
        private int m_runlaststate;//

        private XLDOPE.MDataIno ma;
     
        private bool mdemotesting = false;
        private int mdemotestingp = 0;

        private double pos;
        private double load;
        private double ext;
        private double poscmd;
        private double loadcmd;
        private double extcmd;
        private double time;
        private double count;
        private double pos1;//围压位移
        private double load1;//围压负荷

        public List<CComLibrary.CmdSeg> mrunlist;

        private double mstarttime;
        private double moritime;

        public double mrunstarttime = 0;



        private List<XLDOPE.MDataIno> mdatalist;


        public long oncount = 0;

        private Boolean mrun = false;//函数执行后置位

        private double m_keeptime;//保持时间

        private double m_keepstarttime;//开始保持时时间

        private bool m_keepstart = false;//开始保持

        private int m_returnstep;//返回步骤
        private int m_returncount;//返回次数
        private List<demodata> mdemodata = new List<demodata>();

        private void demo()
        {

            int j;
            int i;
            int jj;
            int ii;
            Random r;
            b = new RawDataStruct();
            b.data = new double[24];
            if (mdemotesting == false)
            {
               r = new Random(System.Environment.TickCount);
                load = r.NextDouble();
                pos = r.NextDouble();
                ext = r.NextDouble();
                time = System.Environment.TickCount / 1000;
                poscmd = 0;
                loadcmd = 0;
                extcmd = 0;
                count = 0;
                load1 = r.NextDouble();
                pos1 = r.NextDouble();

            }
            else
            {
                r = new Random(System.Environment.TickCount);
                load = r.NextDouble();
                pos = r.NextDouble();
                ext = r.NextDouble();
                time = System.Environment.TickCount / 1000;
                poscmd = 0;
                loadcmd = 0;
                extcmd = 0;
                count = 0;
                load1 = r.NextDouble();
                pos1 = r.NextDouble();

                if (mdemotestingp < mdemodata.Count - 1)
                {
                    load = mdemodata[mdemotestingp].load;
                    pos = mdemodata[mdemotestingp].pos;
                    time = mdemodata[mdemotestingp].time;
                    mdemotestingp = mdemotestingp + 1;
                }
                else
                {
                    mdemotesting = false;
                }

            }


            //自定义通道赋值
            ClsStaticStation.m_Global.mload = load;

            ClsStaticStation.m_Global.mpos = pos;

            ClsStaticStation.m_Global.mload1 = load1;
            ClsStaticStation.m_Global.mpos1 = pos1;

            ClsStaticStation.m_Global.msensor4 = r.NextDouble()+1;

            ClsStaticStation.m_Global.msensor5 = r.NextDouble() + 2;

            ClsStaticStation.m_Global.msensor6 = r.NextDouble() + 3;


            ClsStaticStation.m_Global.msensor7 = r.NextDouble() + 4;

            ClsStaticStation.m_Global.msensor8 = r.NextDouble() + 5;

            double[] rr;

            rr = new double[100];

            for (j = 0; j < 100; j++)
            {
                rr[j] = 0;
            }

            if (CComLibrary.GlobeVal.filesave == null)
            {
            }
            else
            {

                for (j = 0; j < CComLibrary.GlobeVal.filesave.muserchannel.Count; j++)
                {
                    rr[j] = 0;
                }

                for (j = 0; j < CComLibrary.GlobeVal.filesave.muserchannel.Count; j++)

                {



                    rr[j + 1] = CComLibrary.GlobeVal.gcalc.getresult通道(j + 1);

                }
            }



            for (j = 0; j < m_Global.mycls.datalist.Count; j++)
            {

                for (int m = 0; m < 100; m++)
                {
                    if (m_Global.mycls.datalist[j].SignName == "Ch User" + m.ToString().Trim())
                    {
                        b.data[m_Global.mycls.datalist[j].EdcId] = rr[m + 1];

                    }

                }

                if (m_Global.mycls.datalist[j].SignName == "Ch Time")
                {

                    b.data[m_Global.mycls.datalist[j].EdcId] = time;


                    if (time > m_Global.mycls.datalist[j].bvaluemax)
                    {
                        m_Global.mycls.datalist[j].bvaluemax = time;
                    }
                    if (time < m_Global.mycls.datalist[j].bvaluemin)
                    {
                        m_Global.mycls.datalist[j].bvaluemin = time;
                    }


                    m_Global.mycls.datalist[j].rvaluemax = time;


                    m_Global.mycls.datalist[j].rvaluemin = 0;



                }
                if (m_Global.mycls.datalist[j].SignName == "ambient pressure Ch Disp")
                {

                    b.data[m_Global.mycls.datalist[j].EdcId] = pos1;


                    if (pos > m_Global.mycls.datalist[j].bvaluemax)
                    {
                        m_Global.mycls.datalist[j].bvaluemax = pos1;
                    }
                    if (pos < m_Global.mycls.datalist[j].bvaluemin)
                    {
                        m_Global.mycls.datalist[j].bvaluemin = pos1;
                    }
                    if (pos > m_Global.mycls.datalist[j].rvaluemax)
                    {
                        m_Global.mycls.datalist[j].rvaluemax = pos1;
                    }
                    if (pos < m_Global.mycls.datalist[j].rvaluemin)
                    {
                        m_Global.mycls.datalist[j].rvaluemin = pos1;
                    }


                }
                if (m_Global.mycls.datalist[j].SignName == "Ch Disp")
                {

                    b.data[m_Global.mycls.datalist[j].EdcId] = pos;


                    if (pos > m_Global.mycls.datalist[j].bvaluemax)
                    {
                        m_Global.mycls.datalist[j].bvaluemax = pos;
                    }
                    if (pos < m_Global.mycls.datalist[j].bvaluemin)
                    {
                        m_Global.mycls.datalist[j].bvaluemin = pos;
                    }
                    if (pos > m_Global.mycls.datalist[j].rvaluemax)
                    {
                        m_Global.mycls.datalist[j].rvaluemax = pos;
                    }
                    if (pos < m_Global.mycls.datalist[j].rvaluemin)
                    {
                        m_Global.mycls.datalist[j].rvaluemin = pos;
                    }


                }


                if (m_Global.mycls.datalist[j].SignName == "Ch Sensor4")
                {

                    b.data[m_Global.mycls.datalist[j].EdcId] = ClsStaticStation.m_Global.msensor4;


                    if (ClsStaticStation.m_Global.msensor4 > m_Global.mycls.datalist[j].bvaluemax)
                    {
                        m_Global.mycls.datalist[j].bvaluemax = ClsStaticStation.m_Global.msensor4;
                    }
                    if (ClsStaticStation.m_Global.msensor4 < m_Global.mycls.datalist[j].bvaluemin)
                    {
                        m_Global.mycls.datalist[j].bvaluemin = ClsStaticStation.m_Global.msensor4;
                    }
                    if (ClsStaticStation.m_Global.msensor4 > m_Global.mycls.datalist[j].rvaluemax)
                    {
                        m_Global.mycls.datalist[j].rvaluemax = ClsStaticStation.m_Global.msensor4;
                    }
                    if (ClsStaticStation.m_Global.msensor4 < m_Global.mycls.datalist[j].rvaluemin)
                    {
                        m_Global.mycls.datalist[j].rvaluemin = ClsStaticStation.m_Global.msensor4;
                    }


                }

                if (m_Global.mycls.datalist[j].SignName == "Ch Sensor5")
                {

                    b.data[m_Global.mycls.datalist[j].EdcId] = ClsStaticStation.m_Global.msensor5;


                    if (ClsStaticStation.m_Global.msensor5 > m_Global.mycls.datalist[j].bvaluemax)
                    {
                        m_Global.mycls.datalist[j].bvaluemax = ClsStaticStation.m_Global.msensor5;
                    }
                    if (ClsStaticStation.m_Global.msensor5 < m_Global.mycls.datalist[j].bvaluemin)
                    {
                        m_Global.mycls.datalist[j].bvaluemin = ClsStaticStation.m_Global.msensor5;
                    }
                    if (ClsStaticStation.m_Global.msensor5 > m_Global.mycls.datalist[j].rvaluemax)
                    {
                        m_Global.mycls.datalist[j].rvaluemax = ClsStaticStation.m_Global.msensor5;
                    }
                    if (ClsStaticStation.m_Global.msensor5 < m_Global.mycls.datalist[j].rvaluemin)
                    {
                        m_Global.mycls.datalist[j].rvaluemin = ClsStaticStation.m_Global.msensor5;
                    }


                }


                if (m_Global.mycls.datalist[j].SignName == "Ch Sensor6")
                {

                    b.data[m_Global.mycls.datalist[j].EdcId] = ClsStaticStation.m_Global.msensor6;


                    if (ClsStaticStation.m_Global.msensor6 > m_Global.mycls.datalist[j].bvaluemax)
                    {
                        m_Global.mycls.datalist[j].bvaluemax = ClsStaticStation.m_Global.msensor6;
                    }
                    if (ClsStaticStation.m_Global.msensor6 < m_Global.mycls.datalist[j].bvaluemin)
                    {
                        m_Global.mycls.datalist[j].bvaluemin = ClsStaticStation.m_Global.msensor6;
                    }
                    if (ClsStaticStation.m_Global.msensor6 > m_Global.mycls.datalist[j].rvaluemax)
                    {
                        m_Global.mycls.datalist[j].rvaluemax = ClsStaticStation.m_Global.msensor6;
                    }
                    if (ClsStaticStation.m_Global.msensor6 < m_Global.mycls.datalist[j].rvaluemin)
                    {
                        m_Global.mycls.datalist[j].rvaluemin = ClsStaticStation.m_Global.msensor6;
                    }


                }

                if (m_Global.mycls.datalist[j].SignName == "Ch Sensor7")
                {

                    b.data[m_Global.mycls.datalist[j].EdcId] = ClsStaticStation.m_Global.msensor7;


                    if (ClsStaticStation.m_Global.msensor7 > m_Global.mycls.datalist[j].bvaluemax)
                    {
                        m_Global.mycls.datalist[j].bvaluemax = ClsStaticStation.m_Global.msensor7;
                    }
                    if (ClsStaticStation.m_Global.msensor7 < m_Global.mycls.datalist[j].bvaluemin)
                    {
                        m_Global.mycls.datalist[j].bvaluemin = ClsStaticStation.m_Global.msensor7;
                    }
                    if (ClsStaticStation.m_Global.msensor7 > m_Global.mycls.datalist[j].rvaluemax)
                    {
                        m_Global.mycls.datalist[j].rvaluemax = ClsStaticStation.m_Global.msensor7;
                    }
                    if (ClsStaticStation.m_Global.msensor7 < m_Global.mycls.datalist[j].rvaluemin)
                    {
                        m_Global.mycls.datalist[j].rvaluemin = ClsStaticStation.m_Global.msensor7;
                    }


                }

                if (m_Global.mycls.datalist[j].SignName == "Ch Sensor8")
                {

                    b.data[m_Global.mycls.datalist[j].EdcId] = ClsStaticStation.m_Global.msensor8;


                    if (ClsStaticStation.m_Global.msensor8 > m_Global.mycls.datalist[j].bvaluemax)
                    {
                        m_Global.mycls.datalist[j].bvaluemax = ClsStaticStation.m_Global.msensor8;
                    }
                    if (ClsStaticStation.m_Global.msensor8 < m_Global.mycls.datalist[j].bvaluemin)
                    {
                        m_Global.mycls.datalist[j].bvaluemin = ClsStaticStation.m_Global.msensor8;
                    }
                    if (ClsStaticStation.m_Global.msensor8 > m_Global.mycls.datalist[j].rvaluemax)
                    {
                        m_Global.mycls.datalist[j].rvaluemax = ClsStaticStation.m_Global.msensor8;
                    }
                    if (ClsStaticStation.m_Global.msensor8 < m_Global.mycls.datalist[j].rvaluemin)
                    {
                        m_Global.mycls.datalist[j].rvaluemin = ClsStaticStation.m_Global.msensor8;
                    }


                }

                if (m_Global.mycls.datalist[j].SignName == "ambient pressure Ch Load")
                {

                    b.data[m_Global.mycls.datalist[j].EdcId] = load1;


                    if (load > m_Global.mycls.datalist[j].bvaluemax)
                    {

                        m_Global.mycls.datalist[j].bvaluemax = load1;
                    }
                    if (load < m_Global.mycls.datalist[j].bvaluemin)
                    {
                        m_Global.mycls.datalist[j].bvaluemin = load1;
                    }

                    if (load > m_Global.mycls.datalist[j].rvaluemax)
                    {

                        m_Global.mycls.datalist[j].rvaluemax = load1;
                    }
                    if (load < m_Global.mycls.datalist[j].rvaluemin)
                    {
                        m_Global.mycls.datalist[j].rvaluemin = load1;
                    }

                }

                if (m_Global.mycls.datalist[j].SignName == "Ch Load")
                {

                    b.data[m_Global.mycls.datalist[j].EdcId] = load;


                    if (load > m_Global.mycls.datalist[j].bvaluemax)
                    {

                        m_Global.mycls.datalist[j].bvaluemax = load;
                    }
                    if (load < m_Global.mycls.datalist[j].bvaluemin)
                    {
                        m_Global.mycls.datalist[j].bvaluemin = load;
                    }

                    if (load > m_Global.mycls.datalist[j].rvaluemax)
                    {

                        m_Global.mycls.datalist[j].rvaluemax = load;
                    }
                    if (load < m_Global.mycls.datalist[j].rvaluemin)
                    {
                        m_Global.mycls.datalist[j].rvaluemin = load;
                    }

                }

                if (m_Global.mycls.datalist[j].SignName == "Ch Ext")
                {

                    b.data[m_Global.mycls.datalist[j].EdcId] = ext;


                    if (ext > m_Global.mycls.datalist[j].bvaluemax)
                    {

                        m_Global.mycls.datalist[j].bvaluemax = ext;
                    }
                    if (ext < m_Global.mycls.datalist[j].bvaluemin)
                    {
                        m_Global.mycls.datalist[j].bvaluemin = ext;
                    }

                    if (ext > m_Global.mycls.datalist[j].rvaluemax)
                    {

                        m_Global.mycls.datalist[j].rvaluemax = ext;
                    }
                    if (ext < m_Global.mycls.datalist[j].rvaluemin)
                    {
                        m_Global.mycls.datalist[j].rvaluemin = ext;
                    }

                }

                if (m_Global.mycls.datalist[j].SignName == "Ch Command")
                {

                    b.data[m_Global.mycls.datalist[j].EdcId] = poscmd;


                }

                if (m_Global.mycls.datalist[j].SignName == "Ch Disp Command")
                {


                    b.data[m_Global.mycls.datalist[j].EdcId] = poscmd;



                }

                if (m_Global.mycls.datalist[j].SignName == "Ch Load Command")
                {


                    b.data[m_Global.mycls.datalist[j].EdcId] = loadcmd;




                }


                if (m_Global.mycls.datalist[j].SignName == "Ch Count")
                {

                    b.data[m_Global.mycls.datalist[j].EdcId] = count;


                }


                if (m_Global.mycls.datalist[j].SignName == "Ch Feed")
                {

                    b.data[m_Global.mycls.datalist[j].EdcId] = 0;
                }

                if (m_Global.mycls.datalist[j].SignName == "Ch Out")
                {

                    b.data[m_Global.mycls.datalist[j].EdcId] = 0;
                }


                if (m_Global.mycls.datalist[j].SignName == "Ch Dynamic Stiffness")
                {


                }


              


            }

            RawDataDataGroup d;
            RawDataDataGroup c = new RawDataDataGroup();
            c.ID = 0;
            m_Global.mycls.structcopy_RawDataData(ref c.rdata, b);
            for (j = 0; j < 4; j++)
            {

                if (ClsStatic.arraydatacount[j] >= ClsStatic.arraydata[j].NodeCount - 1)
                {

                    ClsStatic.arraydata[j].Read<RawDataDataGroup>(out d, 10);
                    ClsStatic.arraydatacount[j] = ClsStatic.arraydatacount[j] - 1;
                }

                ClsStatic.arraydatacount[j] = ClsStatic.arraydatacount[j] + 1;
                ClsStatic.arraydata[j].Write<RawDataDataGroup>(ref c, 10);
            }

            if (ClsStatic.savedatacount >= ClsStatic.savedata.NodeCount - 1)
            {
                ClsStatic.savedata.Read<RawDataDataGroup>(out d, 10);
                ClsStatic.savedatacount = ClsStatic.savedatacount - 1;
            }
            ClsStatic.savedatacount = ClsStatic.savedatacount + 1;
            ClsStatic.savedata.Write<RawDataDataGroup>(ref c, 10);

            for (j = 0; j < m_Global.mycls.allsignals.Count; j++)
            {
                if (m_Global.mycls.allsignals[j].SignName == "Ch Command")
                {

                    m_Global.mycls.allsignals[j].cvalue = poscmd;

                }

                if (m_Global.mycls.allsignals[j].SignName == "Ch Disp Command")
                {

                    m_Global.mycls.allsignals[j].cvalue = poscmd;

                }

                if (m_Global.mycls.allsignals[j].SignName == "Ch Load Command")
                {

                    m_Global.mycls.allsignals[j].cvalue = loadcmd;

                }


            }
            for (j = 0; j < m_Global.mycls.allsignals.Count; j++)
            {


               

              

                if (m_Global.mycls.allsignals[j].SignName == "Ch Time")
                {
                    m_Global.mycls.allsignals[j].cvalue = time;
                }

                if (m_Global.mycls.allsignals[j].SignName == "ambient pressure Ch Disp")
                {
                    m_Global.mycls.allsignals[j].cvalue = pos1;

                }

                if (m_Global.mycls.allsignals[j].SignName == "Ch Disp")
                {
                    m_Global.mycls.allsignals[j].cvalue = pos;




                }

                if (m_Global.mycls.allsignals[j].SignName == "ambient pressure Ch Load")
                {
                    m_Global.mycls.allsignals[j].cvalue = load1;

                }

                if (m_Global.mycls.allsignals[j].SignName == "Ch Load")
                {
                    m_Global.mycls.allsignals[j].cvalue = load;

                }

                if (m_Global.mycls.allsignals[j].SignName == "Ch Sensor4")
                {
                    m_Global.mycls.allsignals[j].cvalue = ClsStaticStation.m_Global.msensor4;
                }

                if (m_Global.mycls.allsignals[j].SignName == "Ch Sensor5")
                {
                    m_Global.mycls.allsignals[j].cvalue = ClsStaticStation.m_Global.msensor5;
                }


                if (m_Global.mycls.allsignals[j].SignName == "Ch Sensor6")
                {
                    m_Global.mycls.allsignals[j].cvalue = ClsStaticStation.m_Global.msensor6;
                }

                if (m_Global.mycls.allsignals[j].SignName == "Ch Sensor7")
                {
                    m_Global.mycls.allsignals[j].cvalue = ClsStaticStation.m_Global.msensor7;
                }

                if (m_Global.mycls.allsignals[j].SignName == "Ch Sensor8")
                {
                    m_Global.mycls.allsignals[j].cvalue = ClsStaticStation.m_Global.msensor8;
                }

                if (m_Global.mycls.allsignals[j].SignName == "Ch Ext")
                {
                    m_Global.mycls.allsignals[j].cvalue = ext;


                }

                for (int m = 0; m < 100; m++)
                {
                    if (m_Global.mycls.allsignals[j].SignName == "Ch User" + m.ToString().Trim())
                    {
                        m_Global.mycls.allsignals[j].cvalue = rr[m + 1];

                    }

                }

            }



        }
        public override void starttest()
        {
            short k = 0;




            myedc.Data.SetTime(XLDOPE.SETTIME_MODE.IMMEDIATE, 0);

           

            mtestrun = true;

            if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 2)//简单试验
            {
                startcontrol();
            }
            else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 0) //一般试验
            {




                mrunlist = new List<CComLibrary.CmdSeg>();
                mrunlist.Clear();

                if (CComLibrary.GlobeVal.filesave.pretest_cmd.check == true)
                {
                    mrunlist.Add(CComLibrary.GlobeVal.filesave.pretest_cmd);


                }

                for (int i = 0; i < 4; i++)
                {
                    if (CComLibrary.GlobeVal.filesave.testcmdstep[i].check == true)
                    {
                        mrunlist.Add(CComLibrary.GlobeVal.filesave.testcmdstep[i]);
                    }
                    else
                    {
                        break;
                    }

                }

                if (mrunlist.Count > 0)
                {
                }
                else
                {

                    MessageBox.Show("错误，您没有设置一般测试过程");
                    mtestrun = false;
                    return;
                }

                mcurseg = 0;

                if (mrunlist[mcurseg].controlmode ==
                    mrunlist[mcurseg].destcontrolmode)
                {
                    k = 1;
                }
                else
                {
                    k = 0;
                }


                segstep(mrunlist[mcurseg].cmd, mrunlist[mcurseg].dest,
                    Convert.ToInt16(mrunlist[mcurseg].controlmode),
                     Convert.ToInt16(mrunlist[mcurseg].destcontrolmode),
                    k, Convert.ToSingle(mrunlist[mcurseg].speed), 0, 0, 0, 0);






            }
            else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 1) //高级试验
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


                mrunlist = new List<CComLibrary.CmdSeg>();
                mrunlist.Clear();

                if (CComLibrary.GlobeVal.filesave.pretest_cmd.check == true)
                {
                    mrunlist.Add(CComLibrary.GlobeVal.filesave.pretest_cmd);
                    mrunlist[0].keeptime = 0;

                    mrunlist[0].action = 0;

                }

                for (i = 0; i < CComLibrary.GlobeVal.filesave.mseglist.Count; i++)
                {
                    if (CComLibrary.GlobeVal.filesave.mseglist[i].check == true)
                    {
                        mrunlist.Add(CComLibrary.GlobeVal.filesave.mseglist[i]);
                    }
                    else
                    {
                        break;
                    }

                }

                if (mrunlist.Count > 0)
                {
                }
                else
                {

                    MessageBox.Show("错误，您没有设置高级测试过程");
                    mtestrun = false;
                    return;
                }


                mcurseg = 0;



                for (int ii = mcurseg; ii < mrunlist.Count; ii++)
                {
                    if (mrunlist[ii].controlmode ==
                   mrunlist[ii].destcontrolmode)
                    {
                        k = 1;
                    }
                    else
                    {
                        k = 0;
                    }
                    if (mrunlist[ii].action == 1)
                    {
                        segstep(mrunlist[ii].cmd, mrunlist[ii].dest,
                           Convert.ToInt16(mrunlist[ii].controlmode),
                             Convert.ToInt16(mrunlist[ii].destcontrolmode),
                            k, Convert.ToSingle(mrunlist[ii].speed),
                          mrunlist[ii].keeptime, mrunlist[ii].returnstep, mrunlist[ii].returncount, mrunlist[ii].action);

                        mcurseg = ii;
                    }
                    else
                    {

                        if (ii == mcurseg)
                        {
                            segstep(mrunlist[ii].cmd, mrunlist[ii].dest,
                       Convert.ToInt16(mrunlist[ii].controlmode),
                        Convert.ToInt16(mrunlist[ii].destcontrolmode),
                       k, Convert.ToSingle(mrunlist[ii].speed),
                       mrunlist[ii].keeptime, mrunlist[ii].returnstep, mrunlist[ii].returncount, mrunlist[ii].action);

                            mcurseg = ii;
                        }
                        break;


                    }


                }


                total_returncount = 0;

                current_returncount = 1;


            }

            m_runlaststate = m_runstate;

            mrunstarttime = System.Environment.TickCount / 1000;
        }
        public override void DestStart(int ctrlmode, double dest, double speed)
        {
            XLDOPE.CTRL control;

            short tan = 0;
            double destination;
            double mspeed;


            mspeed = speed / 60;
             

            control = (XLDOPE.CTRL)ConvertCtrlMode(ctrlmode);

            destination = dest;
            myedc.Move.Pos(control, mspeed, dest, ref tan );
           
        }

        public override void DestStop(int ctrlmode)
        {
            short tan = 0;
         
            myedc.Move.Halt(XLDOPE.CTRL.POS, ref tan );
          
        }

        public override void CrossUp(int ctrlmode, double speed)
        {
            short tan = 0;
            myedc.Move.FMove(XLNet.XLDOPE.MOVE.UP, XLNet.XLDOPE.CTRL.OPEN, speed/60 , ref tan);

        }
        public override void CrossDown(int ctrlmode, double speed)
        {
            short tan = 0;
            myedc.Move.FMove(XLNet.XLDOPE.MOVE.DOWN, XLNet.XLDOPE.CTRL.OPEN, speed/60 , ref tan);
        }

        public override void CrossStop(int ctrlmode)
        {
            short tan = 0;

            XLNet.XLDOPE.ERR p;
            p = myedc.Move.SHalt(ref tan);
        }
        public override void endtest()
        {
            mstarttime = 0;

            endcontrol();

            if (mdemo == true)
            {
            }
            else
            {
                CrossStop(0);

            }
            mtestrun = false;

            CComLibrary.GlobeVal.InitUserCalcChannel();//初始化用户自定义通道
        }
        public override void readdemo(string fileName)
        {
            int i = -1;
            int j = 0;


            char[] sp;
            char[] sp1;
            string[] ww;

            string line;



            sp = new char[2];
            sp1 = new char[2];
            mdemodata.Clear();

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


                            //CComLibrary.GlobeVal.g_datatitle[j] = ww[j];


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

                        int L = ww.Length;

                        demodata m = new demodata();

                        m.time = Convert.ToDouble(ww[0]);
                        m.load = Convert.ToDouble(ww[1]);
                        m.pos = Convert.ToDouble(ww[2]);
                        m.ext = Convert.ToDouble(ww[3]);

                        mdemodata.Add(m);

                    }
                }

            }




        }

        public override void demotest(bool testing)
        {
            mdemotesting = testing;
            mdemotestingp = 0;


        }
      
        public override int ConvertCtrlMode(int ctrl)
        {
            XLDOPE.CTRL t = default(XLDOPE.CTRL);
            if (ctrl == 0) //位移
            {

                // t = XLDOPE.CTRL.POS;
                t = XLDOPE.CTRL.OPEN;
            }
            if (ctrl == 1)  //负荷
            {
                t = XLDOPE.CTRL.LOAD;
            }

            if (ctrl == 2) //变形
            {
                t = XLDOPE.CTRL.EXTENSION;
            }

            return Convert.ToInt16(t);


           
        }
        public override bool getlimit(int ch)
        {
            return false;
        }

        public override bool getEmergencyStop()
        {
            return false;
        }
        public void btnkey(Button b)
        {

        }

        void btnzero(Button b)
        {
        }
        void restorezero(Button b)
        {

        }

        public override void setrunstate(int m)
        {

        }

        public override void segstep(int cmd, double dest, short firstctl, short destctl, short destkeepstyle, float speed, double keeptime, int reurnstep, int returncount, int action)
        {

            bool b = false;
            m_keeptime = keeptime;
            m_keepstart = false;
            keepingstate = false;

            m_returncount = returncount;
            m_returnstep = reurnstep;
            if (m_returncount > 0)
            {
                total_returncount = m_returncount;
            }

            if (mdemo == true)
            {
                m_runstate = 1;
            }
            else
            {
                if (cmd == 2)
                {
                   

                }
                else
                {

                    short tan=0;
                   

                    myedc.Move.PosExt((XLDOPE.CTRL)ConvertCtrlMode(firstctl), Convert.ToSingle(speed), XLDOPE.LIMITMODE.NOT_ACTIVE, 5, (XLDOPE.CTRL)ConvertCtrlMode(destctl)
                        , Convert.ToSingle(dest), XLDOPE.DESTMODE.DEST_POSITION, ref tan);


                  

                        mrun = true;
                    

                }

            }




        }

        public CDsp()
        {
            rr = new float[10];
            GGMsg = new XLDOPE.Data();
            mdatalist = new List<XLDOPE.MDataIno>();
          
            mtimer = new System.Windows.Forms.Timer();
            mtimer.Tick += new EventHandler(mtimer_Tick);
            mtimer.Interval = 50;


            try
            {
                myedc = new XLDOPE.Edc();

            }
            catch (System.BadImageFormatException)
            {


            }

#if DSP_ONDATABLOCK

            myedc.Eh.SetOnDataBlockSize(100);
#else
             myedc.Eh.SetOnDataBlockSize(0);
#endif

            myedc.Eh.OnHandlerFuncHdlr += new XLDOPE.OnHandlerFuncHdlr(Eh_OnHandlerFuncHdlr);

#if DSP_ONDATABLOCK
            myedc.Eh.OnDataBlockHdlr += new XLDOPE.OnDataBlockHdlr(Eh_OnDataBlockHdlr);
#else
            myedc.Eh.OnDataHdlr += new XLDOPE.OnDataHdlr(Eh_OnDataHdlr);
#endif


            myedc.Eh.OnPosMsgHdlr +=new XLDOPE.OnPosMsgHdlr( Eh_OnPosMsgHdlr);

        }

        private int Eh_OnPosMsgHdlr(ref XLDOPE.OnPosMsg OnPosMsg, object Parameter)
        {

            return 0;
        }
#if DSP_ONDATABLOCK
        private int Eh_OnDataBlockHdlr(ref XLDOPE.OnDataBlock OnDataBlock, object Parameter)
        {
            

            for (int i = 0; i <OnDataBlock.nData; i=i+1)
            {
                XLDOPE.Data m1 = new XLDOPE.Data();
                m1 = OnDataBlock.Data[i].Data;

                ma = new XLDOPE.MDataIno();
                ma.Id = 0;
                ma.mydatainfo = m1;
                mdatalist.Add(ma);
                oncount = oncount + 1;
            }
            return 0;
        }
#else
        private void  Eh_OnDataHdlr(ref XLDOPE.OnData m)
        {
            XLDOPE.Data Sample = new XLDOPE.Data();

            b.hardlimitlow = Sample.LowerLimits;
            b.hardlimitup = Sample.UpperLimits;
            b.softlimitlow = Sample.LowerSft;
            b.softlimitup = Sample.UpperSft;
            b.ctrlstate1 = Sample.CtrlState1;
            b.ctrlstate2 = Sample.CtrlState2;

            b.ctrl_state_s = (ushort)((Sample.CtrlState1) & 1);
            b.ctrl_state_f = (ushort)((Sample.CtrlState1 >> 1) & 1);
            b.ctrl_state_e = (ushort)((Sample.CtrlState1 >> 2) & 1);

            b.ctrl_halt = (ushort)((Sample.CtrlState1 >> 4) & 1);
            b.ctrl_down = (ushort)((Sample.CtrlState1 >> 5) & 1);
            b.ctrl_up = (ushort)((Sample.CtrlState1 >> 6) & 1);

            b.ctrl_move = (ushort)((Sample.CtrlState1 >> 7) & 1);
            b.ctrl_ready = (ushort)((Sample.CtrlState1 >> 8) & 1);
            b.ctrl_soft_set = (ushort)((Sample.CtrlState1 >> 11) & 1);

            b.ctrl_lower_sft_s = (ushort)((Sample.CtrlState2 >> 0) & 1);
            b.ctrl_lower_sft_f = (ushort)((Sample.CtrlState2 >> 1) & 1);
            b.ctrl_lower_sft_e = (ushort)((Sample.CtrlState2 >> 2) & 1);

            b.ctrl_upper_sft_s = (ushort)((Sample.CtrlState2 >> 4) & 1);
            b.ctrl_upper_sft_f = (ushort)((Sample.CtrlState2 >> 5) & 1);
            b.ctrl_upper_sft_e = (ushort)((Sample.CtrlState2 >> 6) & 1);


            if (b.ctrl_halt  == 1)
            {
                m_runstate = 0;
            }
            else
            {
                m_runstate = 1;
            }



            Sample  = m.Data ;
            moritime = m.Data.Time;
            ma = new XLDOPE.MDataIno();
            ma.Id = 0;
            ma.mydatainfo = Sample;
            mdatalist.Add(ma);
            oncount = oncount + 1;

            return ;
        }
#endif
        private void Eh_OnHandlerFuncHdlr(int NamelessParameter1, int NamelessParameter2, int NamelessParameter3)
        {
           // oncount = oncount + 1;
            return;
        }
        public override int getrunstate() // 1运行 0 停止
        {
            if (mdemo == true)
            {
            }

            else
            {
               
            }

            return m_runstate;
        }
        void mtimer_Tick(object sender, EventArgs e)
        {
            short k;

            Timer();

            if (mtestrun == false)
            {
                return;
            }

            if (mrun == true)
            {

                if ((this.getrunstate() == 0))
                {


                    if (m_keeptime > 0)
                    {
                        keepingstate = true;

                        if (m_keepstart == false)
                        {
                            m_keepstart = true;

                            m_keepstarttime = System.Environment.TickCount / 1000.0;


                        }
                        else
                        {

                            keepingtime = System.Environment.TickCount / 1000.0 - m_keepstarttime;

                            if (keepingtime >= m_keeptime)
                            {
                                m_keeptime = -1;
                            }

                        }

                    }
                    else
                    {
                        mrun = false;
                        keepingstate = false;

                        if (m_returncount > 0)
                        {
                            current_returncount = current_returncount + 1;

                            if (current_returncount > m_returncount)
                            {
                                mcurseg = mcurseg + 1;

                            }
                            else
                            {
                                mcurseg = m_returnstep - 1;

                            }
                        }
                        else
                        {

                            mcurseg = mcurseg + 1;
                        }

                        if (mcurseg < mrunlist.Count)
                        {

                            for (int ii = mcurseg; ii < mrunlist.Count; ii++)
                            {
                                if (mrunlist[ii].controlmode ==
                               mrunlist[ii].destcontrolmode)
                                {
                                    k = 1;
                                }
                                else
                                {
                                    k = 0;
                                }
                                if (mrunlist[ii].action == 1)
                                {
                                    segstep(mrunlist[ii].cmd, mrunlist[ii].dest,
                                       Convert.ToInt16(mrunlist[ii].controlmode),
                                         Convert.ToInt16(mrunlist[ii].destcontrolmode),
                                        k, Convert.ToSingle(mrunlist[ii].speed),
                                      mrunlist[ii].keeptime, mrunlist[ii].returnstep, mrunlist[ii].returncount, mrunlist[ii].action);
                                }
                                else
                                {
                                    if (ii == mcurseg)
                                    {
                                        segstep(mrunlist[ii].cmd, mrunlist[ii].dest,
                                   Convert.ToInt16(mrunlist[ii].controlmode),
                                    Convert.ToInt16(mrunlist[ii].destcontrolmode),
                                   k, Convert.ToSingle(mrunlist[ii].speed),
                                   mrunlist[ii].keeptime, mrunlist[ii].returnstep, mrunlist[ii].returncount, mrunlist[ii].action);

                                        mcurseg = ii;
                                    }
                                    break;
                                }
                            }



                        }
                        else
                        {
                            mtestrun = false;
                        }
                    }


                }


            }



            return;
           
        }

        void Timer()
        {
            int j;
            int i;
            int jj;
            int ii;

            if (mdemo == true)
            {
                demo();
            }
            else
            {

                ii = mdatalist.Count;

                for (jj = 0; jj < ii; jj++)
                {



                    GGMsg = mdatalist[jj].mydatainfo;

                    b = new RawDataStruct();
                    b.data = new double[24];



                    pos = GGMsg.Sensor[0] ;
                    load =GGMsg.Sensor[1] ;
                    ext = GGMsg.Sensor[2];
                    poscmd = 0;
                    loadcmd = 0;
                    extcmd = 0;
                    //time = AccurateTimer.GetTimeTick();
                    time = GGMsg.Time;
                    count = 0;



                    ClsStaticStation.m_Global.msensor4 = GGMsg.Sensor[3];

                    ClsStaticStation.m_Global.msensor5 = GGMsg.Sensor[4];

                    ClsStaticStation.m_Global.msensor6 = GGMsg.Sensor[5];


                    ClsStaticStation.m_Global.msensor7 = GGMsg.Sensor[6];

                    ClsStaticStation.m_Global.msensor8 = GGMsg.Sensor[7];


                    //自定义通道赋值
                    ClsStaticStation.m_Global.mload = load;

                    ClsStaticStation.m_Global.mpos = pos;

                    ClsStaticStation.m_Global.mload1 = load1;
                    ClsStaticStation.m_Global.mpos1 = pos1;

                    double[] rr;

                    rr = new double[100];

                    for (j = 0; j < 100; j++)
                    {
                        rr[j] = 0;
                    }

                    if (CComLibrary.GlobeVal.filesave == null)
                    {
                    }
                    else
                    {

                        for (j = 0; j < CComLibrary.GlobeVal.filesave.muserchannel.Count; j++)
                        {
                            rr[j] = 0;
                        }

                        for (j = 0; j < CComLibrary.GlobeVal.filesave.muserchannel.Count; j++)
                        {



                            rr[j + 1] = CComLibrary.GlobeVal.gcalc.getresult通道(j + 1);

                        }
                    }



                    for (j = 0; j < m_Global.mycls.datalist.Count; j++)
                    {

                        for (int m = 0; m < 100; m++)
                        {
                            if (m_Global.mycls.datalist[j].SignName == "Ch User" + m.ToString().Trim())
                            {
                                b.data[m_Global.mycls.datalist[j].EdcId] = rr[m + 1];

                            }

                        }

                        if (m_Global.mycls.datalist[j].SignName == "Ch Time")
                        {

                            b.data[m_Global.mycls.datalist[j].EdcId] = time;


                            if (time > m_Global.mycls.datalist[j].bvaluemax)
                            {
                                m_Global.mycls.datalist[j].bvaluemax = time;
                            }
                            if (time < m_Global.mycls.datalist[j].bvaluemin)
                            {
                                m_Global.mycls.datalist[j].bvaluemin = time;
                            }


                            m_Global.mycls.datalist[j].rvaluemax = time;


                            m_Global.mycls.datalist[j].rvaluemin = 0;



                        }

                        if (m_Global.mycls.datalist[j].SignName == "Ch Sensor4")
                        {

                            b.data[m_Global.mycls.datalist[j].EdcId] = ClsStaticStation.m_Global.msensor4;


                            if (ClsStaticStation.m_Global.msensor4 > m_Global.mycls.datalist[j].bvaluemax)
                            {
                                m_Global.mycls.datalist[j].bvaluemax = ClsStaticStation.m_Global.msensor4;
                            }
                            if (ClsStaticStation.m_Global.msensor4 < m_Global.mycls.datalist[j].bvaluemin)
                            {
                                m_Global.mycls.datalist[j].bvaluemin = ClsStaticStation.m_Global.msensor4;
                            }
                            if (ClsStaticStation.m_Global.msensor4 > m_Global.mycls.datalist[j].rvaluemax)
                            {
                                m_Global.mycls.datalist[j].rvaluemax = ClsStaticStation.m_Global.msensor4;
                            }
                            if (ClsStaticStation.m_Global.msensor4 < m_Global.mycls.datalist[j].rvaluemin)
                            {
                                m_Global.mycls.datalist[j].rvaluemin = ClsStaticStation.m_Global.msensor4;
                            }


                        }

                        if (m_Global.mycls.datalist[j].SignName == "Ch Sensor5")
                        {

                            b.data[m_Global.mycls.datalist[j].EdcId] = ClsStaticStation.m_Global.msensor5;


                            if (ClsStaticStation.m_Global.msensor5 > m_Global.mycls.datalist[j].bvaluemax)
                            {
                                m_Global.mycls.datalist[j].bvaluemax = ClsStaticStation.m_Global.msensor5;
                            }
                            if (ClsStaticStation.m_Global.msensor5 < m_Global.mycls.datalist[j].bvaluemin)
                            {
                                m_Global.mycls.datalist[j].bvaluemin = ClsStaticStation.m_Global.msensor5;
                            }
                            if (ClsStaticStation.m_Global.msensor5 > m_Global.mycls.datalist[j].rvaluemax)
                            {
                                m_Global.mycls.datalist[j].rvaluemax = ClsStaticStation.m_Global.msensor5;
                            }
                            if (ClsStaticStation.m_Global.msensor5 < m_Global.mycls.datalist[j].rvaluemin)
                            {
                                m_Global.mycls.datalist[j].rvaluemin = ClsStaticStation.m_Global.msensor5;
                            }


                        }


                        if (m_Global.mycls.datalist[j].SignName == "Ch Sensor6")
                        {

                            b.data[m_Global.mycls.datalist[j].EdcId] = ClsStaticStation.m_Global.msensor6;


                            if (ClsStaticStation.m_Global.msensor6 > m_Global.mycls.datalist[j].bvaluemax)
                            {
                                m_Global.mycls.datalist[j].bvaluemax = ClsStaticStation.m_Global.msensor6;
                            }
                            if (ClsStaticStation.m_Global.msensor6 < m_Global.mycls.datalist[j].bvaluemin)
                            {
                                m_Global.mycls.datalist[j].bvaluemin = ClsStaticStation.m_Global.msensor6;
                            }
                            if (ClsStaticStation.m_Global.msensor6 > m_Global.mycls.datalist[j].rvaluemax)
                            {
                                m_Global.mycls.datalist[j].rvaluemax = ClsStaticStation.m_Global.msensor6;
                            }
                            if (ClsStaticStation.m_Global.msensor6 < m_Global.mycls.datalist[j].rvaluemin)
                            {
                                m_Global.mycls.datalist[j].rvaluemin = ClsStaticStation.m_Global.msensor6;
                            }


                        }

                        if (m_Global.mycls.datalist[j].SignName == "Ch Sensor7")
                        {

                            b.data[m_Global.mycls.datalist[j].EdcId] = ClsStaticStation.m_Global.msensor7;


                            if (ClsStaticStation.m_Global.msensor7 > m_Global.mycls.datalist[j].bvaluemax)
                            {
                                m_Global.mycls.datalist[j].bvaluemax = ClsStaticStation.m_Global.msensor7;
                            }
                            if (ClsStaticStation.m_Global.msensor7 < m_Global.mycls.datalist[j].bvaluemin)
                            {
                                m_Global.mycls.datalist[j].bvaluemin = ClsStaticStation.m_Global.msensor7;
                            }
                            if (ClsStaticStation.m_Global.msensor7 > m_Global.mycls.datalist[j].rvaluemax)
                            {
                                m_Global.mycls.datalist[j].rvaluemax = ClsStaticStation.m_Global.msensor7;
                            }
                            if (ClsStaticStation.m_Global.msensor7 < m_Global.mycls.datalist[j].rvaluemin)
                            {
                                m_Global.mycls.datalist[j].rvaluemin = ClsStaticStation.m_Global.msensor7;
                            }


                        }

                        if (m_Global.mycls.datalist[j].SignName == "Ch Sensor8")
                        {

                            b.data[m_Global.mycls.datalist[j].EdcId] = ClsStaticStation.m_Global.msensor8;


                            if (ClsStaticStation.m_Global.msensor8 > m_Global.mycls.datalist[j].bvaluemax)
                            {
                                m_Global.mycls.datalist[j].bvaluemax = ClsStaticStation.m_Global.msensor8;
                            }
                            if (ClsStaticStation.m_Global.msensor8 < m_Global.mycls.datalist[j].bvaluemin)
                            {
                                m_Global.mycls.datalist[j].bvaluemin = ClsStaticStation.m_Global.msensor8;
                            }
                            if (ClsStaticStation.m_Global.msensor8 > m_Global.mycls.datalist[j].rvaluemax)
                            {
                                m_Global.mycls.datalist[j].rvaluemax = ClsStaticStation.m_Global.msensor8;
                            }
                            if (ClsStaticStation.m_Global.msensor8 < m_Global.mycls.datalist[j].rvaluemin)
                            {
                                m_Global.mycls.datalist[j].rvaluemin = ClsStaticStation.m_Global.msensor8;
                            }


                        }


                        if (m_Global.mycls.datalist[j].SignName == "Ch Disp")
                        {

                            b.data[m_Global.mycls.datalist[j].EdcId] = pos;


                            if (pos > m_Global.mycls.datalist[j].bvaluemax)
                            {
                                m_Global.mycls.datalist[j].bvaluemax = pos;
                            }
                            if (pos < m_Global.mycls.datalist[j].bvaluemin)
                            {
                                m_Global.mycls.datalist[j].bvaluemin = pos;
                            }
                            if (pos > m_Global.mycls.datalist[j].rvaluemax)
                            {
                                m_Global.mycls.datalist[j].rvaluemax = pos;
                            }
                            if (pos < m_Global.mycls.datalist[j].rvaluemin)
                            {
                                m_Global.mycls.datalist[j].rvaluemin = pos;
                            }


                        }

                        if (m_Global.mycls.datalist[j].SignName == "ambient pressure Ch Disp")
                        {

                            b.data[m_Global.mycls.datalist[j].EdcId] = pos1;


                            if (pos > m_Global.mycls.datalist[j].bvaluemax)
                            {
                                m_Global.mycls.datalist[j].bvaluemax = pos1;
                            }
                            if (pos < m_Global.mycls.datalist[j].bvaluemin)
                            {
                                m_Global.mycls.datalist[j].bvaluemin = pos1;
                            }
                            if (pos > m_Global.mycls.datalist[j].rvaluemax)
                            {
                                m_Global.mycls.datalist[j].rvaluemax = pos1;
                            }
                            if (pos < m_Global.mycls.datalist[j].rvaluemin)
                            {
                                m_Global.mycls.datalist[j].rvaluemin = pos1;
                            }


                        }



                        if (m_Global.mycls.datalist[j].SignName == "ambient pressure Ch Load")
                        {

                            b.data[m_Global.mycls.datalist[j].EdcId] = load1;


                            if (load > m_Global.mycls.datalist[j].bvaluemax)
                            {

                                m_Global.mycls.datalist[j].bvaluemax = load1;
                            }
                            if (load < m_Global.mycls.datalist[j].bvaluemin)
                            {
                                m_Global.mycls.datalist[j].bvaluemin = load1;
                            }

                            if (load > m_Global.mycls.datalist[j].rvaluemax)
                            {

                                m_Global.mycls.datalist[j].rvaluemax = load1;
                            }
                            if (load < m_Global.mycls.datalist[j].rvaluemin)
                            {
                                m_Global.mycls.datalist[j].rvaluemin = load1;
                            }

                        }

                        if (m_Global.mycls.datalist[j].SignName == "Ch Load")
                        {

                            b.data[m_Global.mycls.datalist[j].EdcId] = load;


                            if (load > m_Global.mycls.datalist[j].bvaluemax)
                            {

                                m_Global.mycls.datalist[j].bvaluemax = load;
                            }
                            if (load < m_Global.mycls.datalist[j].bvaluemin)
                            {
                                m_Global.mycls.datalist[j].bvaluemin = load;
                            }

                            if (load > m_Global.mycls.datalist[j].rvaluemax)
                            {

                                m_Global.mycls.datalist[j].rvaluemax = load;
                            }
                            if (load < m_Global.mycls.datalist[j].rvaluemin)
                            {
                                m_Global.mycls.datalist[j].rvaluemin = load;
                            }

                        }

                        if (m_Global.mycls.datalist[j].SignName == "Ch Ext")
                        {

                            b.data[m_Global.mycls.datalist[j].EdcId] = ext;


                            if (ext > m_Global.mycls.datalist[j].bvaluemax)
                            {

                                m_Global.mycls.datalist[j].bvaluemax = ext;
                            }
                            if (ext < m_Global.mycls.datalist[j].bvaluemin)
                            {
                                m_Global.mycls.datalist[j].bvaluemin = ext;
                            }

                            if (ext > m_Global.mycls.datalist[j].rvaluemax)
                            {

                                m_Global.mycls.datalist[j].rvaluemax = ext;
                            }
                            if (ext < m_Global.mycls.datalist[j].rvaluemin)
                            {
                                m_Global.mycls.datalist[j].rvaluemin = ext;
                            }

                        }

                        if (m_Global.mycls.datalist[j].SignName == "Ch Command")
                        {

                            b.data[m_Global.mycls.datalist[j].EdcId] = poscmd;


                        }

                        if (m_Global.mycls.datalist[j].SignName == "Ch Disp Command")
                        {


                            b.data[m_Global.mycls.datalist[j].EdcId] = poscmd;



                        }

                        if (m_Global.mycls.datalist[j].SignName == "Ch Load Command")
                        {


                            b.data[m_Global.mycls.datalist[j].EdcId] = loadcmd;




                        }


                        if (m_Global.mycls.datalist[j].SignName == "Ch Count")
                        {

                            b.data[m_Global.mycls.datalist[j].EdcId] = count;


                        }


                        if (m_Global.mycls.datalist[j].SignName == "Ch Feed")
                        {

                            b.data[m_Global.mycls.datalist[j].EdcId] = 0;
                        }

                        if (m_Global.mycls.datalist[j].SignName == "Ch Out")
                        {

                            b.data[m_Global.mycls.datalist[j].EdcId] = 0;
                        }


                        if (m_Global.mycls.datalist[j].SignName == "Ch Dynamic Stiffness")
                        {


                        }




                    }

                    RawDataDataGroup d;
                    RawDataDataGroup c = new RawDataDataGroup();
                    c.ID = 0;
                    m_Global.mycls.structcopy_RawDataData(ref c.rdata, b);
                    for (j = 0; j < 4; j++)
                    {

                        if (ClsStatic.arraydatacount[j] >= ClsStatic.savedata.NodeCount - 1)
                        {

                            ClsStatic.arraydata[j].Read<RawDataDataGroup>(out d, 10);
                            ClsStatic.arraydatacount[j] = ClsStatic.arraydatacount[j] - 1;
                        }

                        ClsStatic.arraydatacount[j] = ClsStatic.arraydatacount[j] + 1;
                        ClsStatic.arraydata[j].Write<RawDataDataGroup>(ref c, 10);
                    }

                    if (ClsStatic.savedatacount >= ClsStatic.savedata.NodeCount - 1)
                    {
                        ClsStatic.savedata.Read<RawDataDataGroup>(out d, 10);
                        ClsStatic.savedatacount = ClsStatic.savedatacount - 1;
                    }
                    ClsStatic.savedatacount = ClsStatic.savedatacount + 1;
                    ClsStatic.savedata.Write<RawDataDataGroup>(ref c, 10);

                    for (j = 0; j < m_Global.mycls.allsignals.Count; j++)
                    {
                        if (m_Global.mycls.allsignals[j].SignName == "Ch Command")
                        {

                            m_Global.mycls.allsignals[j].cvalue = poscmd;

                        }

                        if (m_Global.mycls.allsignals[j].SignName == "Ch Disp Command")
                        {

                            m_Global.mycls.allsignals[j].cvalue = poscmd;

                        }

                        if (m_Global.mycls.allsignals[j].SignName == "Ch Load Command")
                        {

                            m_Global.mycls.allsignals[j].cvalue = loadcmd;

                        }


                    }
                    for (j = 0; j < m_Global.mycls.allsignals.Count; j++)
                    {

                        if (m_Global.mycls.allsignals[j].SignName == "Ch Time")
                        {
                            m_Global.mycls.allsignals[j].cvalue = time;
                        }
                        if (m_Global.mycls.allsignals[j].SignName == "ambient pressure Ch Disp")
                        {
                            m_Global.mycls.allsignals[j].cvalue = pos1;

                        }
                        if (m_Global.mycls.allsignals[j].SignName == "Ch Sensor4")
                        {
                            m_Global.mycls.allsignals[j].cvalue = ClsStaticStation.m_Global.msensor4;
                        }

                        if (m_Global.mycls.allsignals[j].SignName == "Ch Sensor5")
                        {
                            m_Global.mycls.allsignals[j].cvalue = ClsStaticStation.m_Global.msensor5;
                        }


                        if (m_Global.mycls.allsignals[j].SignName == "Ch Sensor6")
                        {
                            m_Global.mycls.allsignals[j].cvalue = ClsStaticStation.m_Global.msensor6;
                        }

                        if (m_Global.mycls.allsignals[j].SignName == "Ch Sensor7")
                        {
                            m_Global.mycls.allsignals[j].cvalue = ClsStaticStation.m_Global.msensor7;
                        }

                        if (m_Global.mycls.allsignals[j].SignName == "Ch Sensor8")
                        {
                            m_Global.mycls.allsignals[j].cvalue = ClsStaticStation.m_Global.msensor8;
                        }
                        if (m_Global.mycls.allsignals[j].SignName == "Ch Disp")
                        {
                            m_Global.mycls.allsignals[j].cvalue = pos;




                        }
                        if (m_Global.mycls.allsignals[j].SignName == "ambient pressure Ch Load")
                        {

                            m_Global.mycls.allsignals[j].cvalue = load1;
                        }
                        if (m_Global.mycls.allsignals[j].SignName == "Ch Load")
                        {
                            m_Global.mycls.allsignals[j].cvalue = load;

                        }

                        if (m_Global.mycls.allsignals[j].SignName == "Ch Ext")
                        {
                            m_Global.mycls.allsignals[j].cvalue = ext;


                        }

                        for (int m = 0; m < 100; m++)
                        {
                            if (m_Global.mycls.allsignals[j].SignName == "Ch User" + m.ToString().Trim())
                            {
                                m_Global.mycls.allsignals[j].cvalue = rr[m + 1];

                            }

                        }

                    }

                }


                mdatalist.Clear();

            }
        }

        public override void Init(int handle)
        {

            OpenConnection();


        }

        int OpenConnection()
        {
            XLDOPE.XL_init();

           int r= XLDOPE.XL_start(1);
           
            if (r>=0)
            {

            }
            else
            {

                MessageBox.Show("网卡设置错误");
            }


            mtimer.Start();


            return 0;
        }

        public override int CloseConnection()
        {
            mtimer.Stop();
            try
            {
                XLDOPE.XL_stop();
                XLDOPE.XL_free();
            }
            catch(System.BadImageFormatException)
            {
                

            }

            return 0;
        }
    }
}

