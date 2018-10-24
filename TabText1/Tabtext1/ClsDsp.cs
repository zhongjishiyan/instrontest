#define DSP_ONDATABLOCK
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
using PipesServerTest;

namespace ClsStaticStation
{
    

    public class CDsp : ClsBaseControl
    {
        drivertest1.ClassCW341 w341;

         [DllImport("kernel32.dll")]
        public static extern UIntPtr SetThreadAffinityMask(IntPtr hThread,
       UIntPtr dwThreadAffinityMask);

        //得到当前线程的handler  
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetCurrentThread();

        //获取cpu的id号  
        public static ulong SetCpuID(int id)
        {
            ulong cpuid = 0;
            if (id < 0 || id >= System.Environment.ProcessorCount)
            {
                id = 0;
            }
            cpuid |= 1UL << id;

            return cpuid;
        }

        Mutex mt = new Mutex();//创建一个同步基元

        private double mstarttickcount;
        private int mspenum = 0;
        private RawDataDataGroup[] r = new RawDataDataGroup[1];
        private float[] rr;
        private System.Windows.Forms.Timer mtimer;
        public XLNet.XLDOPE.Data GGMsg;
        private RawDataStruct b;
        public short DeviceNum = 1;

        private int m_runstate;

        private PipeServer _pipeServer;


        private XLDOPE.MDataIno ma;

        private bool mdemotesting = false;
        private int mdemotestingp = 0;

        private double pos;
        private double load;
        private double ext;

        private double cmd;

        private double time;
        private double count;
        private double pos1;//围压位移
        private double load1;//围压负荷

        public List<CComLibrary.CmdSeg> mrunlist;


        private double mstarttime;
        private double moritime;

        public double mrunstarttime = 0;

        private double sensor4;
        private double sensor5;
        private double sensor6;
        private double sensor7;
        private double sensor8;


        private Queue<XLDOPE.MDataIno> mdatalist;


        public long oncount = 0;

        private Boolean mrun = false;//函数执行后置位

        private double m_keeptime;//保持时间

        private double m_keepstarttime;//开始保持时时间

        private bool m_keepstart = false;//开始保持

        private int m_returnstep;//返回步骤
        private int m_returncount;//返回次数
        private List<demodata> mdemodata = new List<demodata>();

        public override void findzero(double speed)
        {

            short tan = 0;
            myedc.Move.OrgMove(XLDOPE.MOVE.UP, XLDOPE.CTRL.POS, speed, ref tan);
        }

        public override void Exit()
        {
            base.Exit();
            w341.Stop();
            mtimer.Stop();
          
            _pipeServer.PipeMessage -= new DelegateMessage(PipesMessageHandler);
            _pipeServer = null;
            

        }

        public override void DriveOn()
        {

            myedc.Move.On();
        }
        public override void DriveOff()
        {
            myedc.Move.Off();
        }

        public override void CrossDown(int ctrlmode, double speed)
        {
            short tan = 0;

            double m = speed;

            if (m_Global.mycls.chsignals[ctrlmode].EdcChannleSel == 0)
            {
                myedc.Move.FMove(XLNet.XLDOPE.MOVE.DOWN, (XLNet.XLDOPE.CTRL)ctrlmode + Convert.ToInt16(0 * 256), m / 60, ref tan);
            }
            else
            {
                myedc.Move.FMove(XLNet.XLDOPE.MOVE.DOWN, (XLNet.XLDOPE.CTRL)ctrlmode + Convert.ToInt16(1 * 256), m / 60, ref tan);
            }

        }

        public override void btnzeroall()
        {
            for (int i = 0; i < m_Global.mycls.chsignals.Count; i++)
            {


                XLDOPE.Data Sample = default(XLDOPE.Data);
                myedc.Data.CurrentData(ref Sample);


                myedc.Tare.SetTare((XLDOPE.SENSOR)i, Sample.Sensor[i]);

            }

        }

        public override void btnrestoreall()
        {

            for (int i = 0; i < m_Global.mycls.chsignals.Count; i++)
            {




                myedc.Tare.SetTare((XLDOPE.SENSOR)i, 0);

            }
        }

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

                if (m_Global.mycls.ChannelSampling[2] == 0)
                {
                    ext = r.NextDouble();
                }

                if (m_Global.mycls.ChannelSampling[2]==1 )
                {
                    ext = _pipeServer._TransferData.Channel1;
                }
                time = (System.Environment.TickCount - mstarttickcount) / 1000.0;

                count = 0;
                load1 = r.NextDouble();
                pos1 = r.NextDouble();

            }
            else
            {
                r = new Random(System.Environment.TickCount);
                load = r.NextDouble();
                pos = r.NextDouble();
                if (m_Global.mycls.ChannelSampling[2] == 0)
                {
                    ext = r.NextDouble();
                }
                if (m_Global.mycls.ChannelSampling[2] == 1)
                {
                    ext = _pipeServer._TransferData.Channel1;
                }
                time = (System.Environment.TickCount - mstarttickcount) / 1000.0;

                count = 0;
                load1 = r.NextDouble();
                pos1 = r.NextDouble();

                if (mdemotestingp < mdemodata.Count - 1)
                {
                    load = mdemodata[mdemotestingp].load * (50 + mspenum - 1) / 50;
                    pos = mdemodata[mdemotestingp].pos * (50 + mspenum - 1) / 50;
                    ext = mdemodata[mdemotestingp].ext * (50 + mspenum - 1) / 50;
                    time = mdemodata[mdemotestingp].time;
                    mdemotestingp = mdemotestingp + 1;
                }
                else
                {

                    mdemotesting = false;
                }

            }


            if  (mtestrun == true)
            {
                if (CComLibrary.GlobeVal.filesave.Extensometer_DataFrozenFlag==true)
                {
                    ext = 0;
                }
            }


            //自定义通道赋值
            ClsStaticStation.m_Global.mload = load;

            ClsStaticStation.m_Global.mpos = pos;

            ClsStaticStation.m_Global.mext = ext;

            ClsStaticStation.m_Global.mload1 = load1;
            ClsStaticStation.m_Global.mpos1 = pos1;

            ClsStaticStation.m_Global.msensor4 = r.NextDouble() + 1;

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

                    b.data[m_Global.mycls.datalist[j].EdcId] = cmd;


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

      



            
         

            for (j = 0; j < m_Global.mycls.allsignals.Count; j++)
            {
                if (m_Global.mycls.allsignals[j].SignName == "Ch Command")
                {

                    m_Global.mycls.allsignals[j].cvalue = cmd;

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

                /*

                for (int m = 0; m < 100; m++)
                {
                    if (m_Global.mycls.allsignals[j].SignName == "Ch User" + m.ToString().Trim())
                    {
                        m_Global.mycls.allsignals[j].cvalue = rr[m + 1];

                    }

                }
                */
            }



        }


        public override void cleartime()
        {
            base.cleartime();
            myedc.Data.SetTime(XLDOPE.SETTIME_MODE.IMMEDIATE, 0);





            if (mdemo == false)
            {
                bool b = false;
                while (b == true)
                {
                    Application.DoEvents();
                    if (time < 1)
                    {
                        b = false;
                    }
                }

            }



            if (CComLibrary.GlobeVal.filesave.Samplingmode == 0)
            {
                mt.WaitOne();

                mdatalist.Clear();

                mt.ReleaseMutex();

                
            }
        }

        public override void starttest(int spenum)
        {
            short k = 0;
            RawDataDataGroup d;

            oldcount = 0;
            mspenum = spenum;

            CComLibrary.GlobeVal.filesave.Extensometer_DataFrozenFlag = false;


            duanliebaohu = false;

            m_runstate = 0;

            mtestrun = true;

            if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 2)//简单试验
            {
                mrunlist = new List<CComLibrary.CmdSeg>();
                mrunlist.Clear();

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

                    MessageBox.Show("错误，您没有设置一般测控过程");
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


                segstep(mrunlist[mcurseg].cmd, mrunlist[mcurseg].destorigin(),
                    Convert.ToInt16(mrunlist[mcurseg].controlmode),
                     Convert.ToInt16(mrunlist[mcurseg].destcontrolmode),
                    k, Convert.ToSingle(mrunlist[mcurseg].speedorigin()), 0, 0, 0, 0, mrunlist[mcurseg].destmode);






            }
            else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 3) //高级试验
            {

                CComLibrary.SequenceFile sqf = new CComLibrary.SequenceFile();
                sqf = sqf.DeSerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ\\sequence\\" + CComLibrary.GlobeVal.filesave.SequenceName);


                CComLibrary.GlobeVal.filesave.mseglist = new List<CComLibrary.CmdSeg>();


                for (int i = 0; i < sqf.mSequencelist.Count; i++)
                {
                    CComLibrary.CmdSeg n = new CComLibrary.CmdSeg();
                    n.check = true;
                    if (sqf.mSequencelist[i].wavekind == 0) //斜波
                    {
                        n.controlmode = sqf.mSequencelist[i].controlmode;

                        n.cmd = 0;

                        n.speed = Convert.ToDouble(ClsStaticStation.m_Global.mycls.hardsignals[n.controlmode].speedSignal.GetOriValue(sqf.mSequencelist[i].mrate, sqf.mSequencelist[i].mrateunit));
                        n.destcontrolmode = sqf.mSequencelist[i].destcontrolmode;
                        n.dest = Convert.ToDouble(ClsStaticStation.m_Global.mycls.hardsignals[n.controlmode].GetOriValue(sqf.mSequencelist[i].mdest, sqf.mSequencelist[i].mdestunit));
                        n.keeptime = 0;

                        n.mseq = sqf.mSequencelist[i];
                        n.mseq.wavekind = sqf.mSequencelist[i].wavekind;
                        n.mseq.stepname = sqf.mSequencelist[i].stepname;

                        n.destmode = sqf.mSequencelist[i].destmode;

                        n.action = 0; //始终保持异步控制
                        if (sqf.mSequencelist[i].loop == true)
                        {

                            n.returncount = sqf.mSequencelist[i].loopcount;
                            n.returnstep = sqf.mSequencelist[i].returnstep;
                        }
                        else
                        {
                            n.returncount = 0;
                            n.returnstep = 0;
                        }

                    }

                    if (sqf.mSequencelist[i].wavekind == 1) //保持波
                    {
                        n.keeptime = sqf.mSequencelist[i].keeptime;
                        n.mseq = sqf.mSequencelist[i];
                        n.mseq.wavekind = sqf.mSequencelist[i].wavekind;
                        n.mseq.stepname = sqf.mSequencelist[i].stepname;

                        n.cmd = 0;

                        n.action = 0; //始终保持异步控制
                        if (sqf.mSequencelist[i].loop == true)
                        {


                            n.returncount = sqf.mSequencelist[i].loopcount;
                            n.returnstep = sqf.mSequencelist[i].returnstep;
                        }
                        else
                        {
                            n.returncount = 0;
                            n.returnstep = 0;
                        }

                    }

                    if (sqf.mSequencelist[i].wavekind == 2) //循环波
                    {
                        n.keeptime = sqf.mSequencelist[i].keeptime;

                        n.mseq = sqf.mSequencelist[i];
                        n.mseq.stepname = sqf.mSequencelist[i].stepname;
                        n.mseq.wavekind = sqf.mSequencelist[i].wavekind;
                        n.cmd = 0;

                        n.action = 0; //始终保持异步控制
                        if (sqf.mSequencelist[i].loop == true)
                        {
                            n.returncount = sqf.mSequencelist[i].loopcount;
                            n.returnstep = sqf.mSequencelist[i].returnstep;
                        }
                        else
                        {
                            n.returncount = 0;
                            n.returnstep = 0;
                        }

                    }

                    if (sqf.mSequencelist[i].wavekind == 3) //正弦波
                    {
                        n.keeptime = sqf.mSequencelist[i].keeptime;

                        n.mseq = sqf.mSequencelist[i];
                        n.mseq.stepname = sqf.mSequencelist[i].stepname;
                        n.mseq.wavekind = sqf.mSequencelist[i].wavekind;
                        n.cmd = 0;

                        n.action = 0; //始终保持异步控制
                        if (sqf.mSequencelist[i].loop == true)
                        {
                            n.returncount = sqf.mSequencelist[i].loopcount;
                            n.returnstep = sqf.mSequencelist[i].returnstep;
                        }
                        else
                        {
                            n.returncount = 0;
                            n.returnstep = 0;
                        }

                    }



                    CComLibrary.GlobeVal.filesave.mseglist.Add(n);
                }



                mrunlist = new List<CComLibrary.CmdSeg>();
                mrunlist.Clear();

                if (CComLibrary.GlobeVal.filesave.pretest_cmd.check == true)
                {
                    mrunlist.Add(CComLibrary.GlobeVal.filesave.pretest_cmd);
                    mrunlist[0].keeptime = 0;
                    mrunlist[0].mseq.wavekind = -1;
                    mrunlist[0].action = 0;

                }

                for (int i = 0; i < CComLibrary.GlobeVal.filesave.mseglist.Count; i++)
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

                    MessageBox.Show("错误，您没有设置高级测控过程");
                    mtestrun = false;
                    return;
                }


                bool mfindcurseg = false;

                for (int ii = 0; ii < CComLibrary.GlobeVal.filesave.mseglist.Count; ii++)
                {
                    if (CComLibrary.GlobeVal.filesave.mseglist[ii].mseq.runfinished == false)
                    {
                        mcurseg = ii;
                        mfindcurseg = true;
                        break;
                    }
                }

                if (mfindcurseg == false)
                {
                    MessageBox.Show("错误，试验过程已经执行完成，请再次重新初始化试验过程");
                    mtestrun = false;
                    return;

                }




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


                    if (ii == mcurseg)
                    {
                        segstep(mrunlist[ii].cmd, mrunlist[ii].destorigin(),
                   Convert.ToInt16(mrunlist[ii].controlmode),
                    Convert.ToInt16(mrunlist[ii].destcontrolmode),
                   k, Convert.ToSingle(mrunlist[ii].speedorigin()),
                   mrunlist[ii].keeptime, mrunlist[ii].returnstep, mrunlist[ii].returncount, mrunlist[ii].action, mrunlist[ii].destmode);

                        mcurseg = ii;
                    }
                    break;




                }


                total_returncount = 0;


                for (int ii = mcurseg; ii < mrunlist.Count; ii++)
                {
                    if (mrunlist[ii].mseq.loopcount > 0)
                    {
                        current_returncount = mrunlist[ii].mseq.finishedloopcount;
                        break;
                    }
                }







            }
            else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 1) //中级试验
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

                    MessageBox.Show("错误，您没有设置中级测试过程");
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
                        segstep(mrunlist[ii].cmd, mrunlist[ii].destorigin(),
                           Convert.ToInt16(mrunlist[ii].controlmode),
                             Convert.ToInt16(mrunlist[ii].destcontrolmode),
                            k, Convert.ToSingle(mrunlist[ii].speedorigin()),
                          mrunlist[ii].keeptime, mrunlist[ii].returnstep, mrunlist[ii].returncount, mrunlist[ii].action, mrunlist[ii].destmode);

                        mcurseg = ii;
                    }
                    else
                    {

                        if (ii == mcurseg)
                        {
                            segstep(mrunlist[ii].cmd, mrunlist[ii].destorigin(),
                       Convert.ToInt16(mrunlist[ii].controlmode),
                        Convert.ToInt16(mrunlist[ii].destcontrolmode),
                       k, Convert.ToSingle(mrunlist[ii].speedorigin()),
                       mrunlist[ii].keeptime, mrunlist[ii].returnstep, mrunlist[ii].returncount, mrunlist[ii].action, mrunlist[ii].destmode);

                            mcurseg = ii;
                        }
                        break;


                    }


                }


                total_returncount = 0;

                current_returncount = 0;


            }



            mrunstarttime = System.Environment.TickCount / 1000;

           

        }
        public override void DestStart(int ctrlmode, double dest, double speed)
        {
            XLDOPE.CTRL control;

            short tan = 0;
            double destination;
            double mspeed;


            mspeed = speed / 60;


            control = (XLDOPE.CTRL)ConvertCtrlMode(ctrlmode)+ Convert.ToInt16(m_Global.mycls.chsignals[ctrlmode].EdcChannleSel*256);

            destination = dest;

            try
            {
                myedc.Move.Pos(control, mspeed, dest, ref tan);
            }
            catch (NullReferenceException)
            {

            }


        }

        public override void DestStop(int ctrlmode)
        {
            short tan = 0;


            try
            {
                myedc.Move.Halt((XLDOPE.CTRL)ctrlmode+ Convert.ToInt16(m_Global.mycls.chsignals[ctrlmode].EdcChannleSel * 256), ref tan);
            }
            catch (NullReferenceException)
            {

            }


        }

        public override void CrossUp(int ctrlmode, double speed)
        {
            short tan = 0;
            double m = speed;


            try
            {
                if (m_Global.mycls.chsignals[ctrlmode].EdcChannleSel == 0)
                {
                    myedc.Move.FMove(XLNet.XLDOPE.MOVE.UP, (XLNet.XLDOPE.CTRL)ctrlmode + Convert.ToInt16(0 * 256), m / 60, ref tan);
                }
                else
                {
                    myedc.Move.FMove(XLNet.XLDOPE.MOVE.UP, (XLNet.XLDOPE.CTRL)ctrlmode + Convert.ToInt16(1 * 256), m / 60, ref tan);
                }
            }
            catch (NullReferenceException)
            {


            }


        }


        public override void CrossStop(int ctrlmode)
        {
            short tan = 0;

            try
            {
                if (m_Global.mycls.chsignals[ctrlmode].EdcChannleSel == 0)
                {
                    myedc.Move.Halt((XLDOPE.CTRL)ctrlmode + Convert.ToInt16(0 * 256), ref tan);
                }
                else
                {
                    myedc.Move.Halt((XLDOPE.CTRL)ctrlmode + Convert.ToInt16(1 * 256), ref tan);
                }
            }
            catch (NullReferenceException)
            {

            }
        }
        public override void endtest()
        {
            mstarttime = 0;

            endcontrol();

            mtestrun = false;
            mrun = false;



            CComLibrary.GlobeVal.filesave.Extensometer_DataFrozenFlag = false;


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
                t = XLDOPE.CTRL.POS;

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
        public override void btnkey(Button b)
        {
            if (Convert.ToBoolean(b.Tag) == false)
            {
                b.ForeColor = System.Drawing.Color.Red;
                b.Tag = true;
                btnzero(b);

            }
            else
            {
                b.ForeColor = System.Drawing.Color.Black;

                b.Tag = false;
                restorezero(b);
            }


        }

        public override void btnzero(Button b)
        {

            for (int i = 0; i < m_Global.mycls.chsignals.Count; i++)
            {

                if (b.Text == m_Global.mycls.chsignals[i].cName)
                {
                    //if (m_Global.mycls.hardsignals[i].SignName == "Ch Disp")
                    if (i == 0)
                    {
                        XLDOPE.Data Sample = default(XLDOPE.Data);
                        myedc.Data.CurrentData(ref Sample);


                        myedc.Tare.SetTare(XLDOPE.SENSOR.SENSOR_S, Sample.Sensor[Convert.ToInt16(XLDOPE.SENSOR.SENSOR_S)]);
                    }
                    if (i == 1)
                    // if (m_Global.mycls.hardsignals[i].SignName == "Ch Load")
                    {
                        XLDOPE.Data Sample = default(XLDOPE.Data);
                        myedc.Data.CurrentData(ref Sample);
                        myedc.Tare.SetTare(XLDOPE.SENSOR.SENSOR_F, Sample.Sensor[Convert.ToInt16(XLDOPE.SENSOR.SENSOR_F)]);
                    }

                    if (i == 2)
                    //if (m_Global.mycls.hardsignals[i].SignName == "Ch Ext")
                    {
                        XLDOPE.Data Sample = default(XLDOPE.Data);
                        myedc.Data.CurrentData(ref Sample);
                        myedc.Tare.SetTare(XLDOPE.SENSOR.SENSOR_E, Sample.Sensor[Convert.ToInt16(XLDOPE.SENSOR.SENSOR_E)]);
                    }
                    if (i == 3)
                    //if (m_Global.mycls.hardsignals[i].SignName == "Ch Sensor3")
                    {
                        XLDOPE.Data Sample = default(XLDOPE.Data);
                        myedc.Data.CurrentData(ref Sample);
                        myedc.Tare.SetTare(XLDOPE.SENSOR.SENSOR_3, Sample.Sensor[Convert.ToInt16(XLDOPE.SENSOR.SENSOR_3)]);
                    }
                    if (i == 4)
                    //if (m_Global.mycls.hardsignals[i].SignName == "Ch Sensor4")
                    {
                        XLDOPE.Data Sample = default(XLDOPE.Data);
                        myedc.Data.CurrentData(ref Sample);
                        myedc.Tare.SetTare(XLDOPE.SENSOR.SENSOR_4, Sample.Sensor[Convert.ToInt16(XLDOPE.SENSOR.SENSOR_4)]);
                    }

                    if (i == 5)
                    //if (m_Global.mycls.hardsignals[i].SignName == "Ch Sensor5")
                    {
                        XLDOPE.Data Sample = default(XLDOPE.Data);
                        myedc.Data.CurrentData(ref Sample);
                        myedc.Tare.SetTare(XLDOPE.SENSOR.SENSOR_5, Sample.Sensor[Convert.ToInt16(XLDOPE.SENSOR.SENSOR_5)]);
                    }
                    if (i == 6)
                    // if (m_Global.mycls.hardsignals[i].SignName == "Ch Sensor6")
                    {
                        XLDOPE.Data Sample = default(XLDOPE.Data);
                        myedc.Data.CurrentData(ref Sample);
                        myedc.Tare.SetTare(XLDOPE.SENSOR.SENSOR_6, Sample.Sensor[Convert.ToInt16(XLDOPE.SENSOR.SENSOR_6)]);
                    }
                    if (i == 7)

                    //if (m_Global.mycls.hardsignals[i].SignName == "Ch Sensor7")
                    {
                        XLDOPE.Data Sample = default(XLDOPE.Data);
                        myedc.Data.CurrentData(ref Sample);
                        myedc.Tare.SetTare(XLDOPE.SENSOR.SENSOR_7, Sample.Sensor[Convert.ToInt16(XLDOPE.SENSOR.SENSOR_7)]);
                    }



                }
            }


        }
        void restorezero(Button b)
        {
            for (int i = 0; i < m_Global.mycls.chsignals.Count; i++)
            {
                if (b.Text == m_Global.mycls.chsignals[i].cName)
                {
                    if (i == 0)

                    //if (m_Global.mycls.hardsignals[i].SignName == "Ch Disp")
                    {

                        myedc.Tare.SetTare(XLDOPE.SENSOR.SENSOR_S, 0);
                    }
                    if (i == 1)

                    // if (m_Global.mycls.hardsignals[i].SignName == "Ch Load")
                    {

                        myedc.Tare.SetTare(XLDOPE.SENSOR.SENSOR_F, 0);
                    }
                    if (i == 2)
                    //if (m_Global.mycls.hardsignals[i].SignName == "Ch Ext")
                    {

                        myedc.Tare.SetTare(XLDOPE.SENSOR.SENSOR_E, 0);
                    }
                    if (i == 3)
                    //if (m_Global.mycls.hardsignals[i].SignName == "Ch Sensor3")
                    {

                        myedc.Tare.SetTare(XLDOPE.SENSOR.SENSOR_3, 0);
                    }
                    if (i == 4)
                    //if (m_Global.mycls.hardsignals[i].SignName == "Ch Sensor4")
                    {

                        myedc.Tare.SetTare(XLDOPE.SENSOR.SENSOR_4, 0);
                    }
                    if (i == 5)

                    //if (m_Global.mycls.hardsignals[i].SignName == "Ch Sensor5")
                    {

                        myedc.Tare.SetTare(XLDOPE.SENSOR.SENSOR_5, 0);
                    }
                    if (i == 6)
                    //if (m_Global.mycls.hardsignals[i].SignName == "Ch Sensor6")
                    {

                        myedc.Tare.SetTare(XLDOPE.SENSOR.SENSOR_6, 0);
                    }
                    if (i == 7)
                    //if (m_Global.mycls.hardsignals[i].SignName == "Ch Sensor7")
                    {

                        myedc.Tare.SetTare(XLDOPE.SENSOR.SENSOR_7, 0);
                    }


                }

            }
        }

        public override void setrunstate(int m)
        {

        }


        public override void segstep(int cmd, double dest, short firstctl, short destctl, short destkeepstyle, float speed, double keeptime, int reurnstep, int returncount, int action, int destmode)
        {

            bool b = false;
            short tan = 0;



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
                m_runstate = 0;
            }
            else
            {

                if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 3)
                {
                    if (mrunlist[mcurseg].mseq.wavekind <= 0)
                    {
                        m_runstate = 1;

                        myedc.Move.PosExt((XLDOPE.CTRL)ConvertCtrlMode(firstctl)+ Convert.ToInt16(m_Global.mycls.chsignals[firstctl].EdcChannleSel * 256), Convert.ToSingle(speed), XLDOPE.LIMITMODE.NOT_ACTIVE, 5, (XLDOPE.CTRL)ConvertCtrlMode(destctl)
                            , Convert.ToSingle(dest), (XLDOPE.DESTMODE)destmode, ref tan);

                    }

                    if (mrunlist[mcurseg].mseq.wavekind == 1)
                    {
                        m_runstate = 0;

                    }

                    if (mrunlist[mcurseg].mseq.wavekind == 2)

                    {
                        if ((mrunlist[mcurseg].mseq.mcount - mrunlist[mcurseg].mseq.mfinishedcount) <= 0)
                        {
                            m_runstate = 0;
                        }
                        else
                        {
                            m_runstate = 1;
                            double m_speed1 = Convert.ToDouble(m_Global.mycls.hardsignals[mrunlist[mcurseg].controlmode].speedSignal.GetOriValue(mrunlist[mcurseg].mseq.mtrirate, mrunlist[mcurseg].mseq.mtrirateunit));

                            double m_speed2= Convert.ToDouble(m_Global.mycls.hardsignals[mrunlist[mcurseg].controlmode].speedSignal.GetOriValue(mrunlist[mcurseg].mseq.mtriratedown, mrunlist[mcurseg].mseq.mtriratedownunit));
                            double m_dest1 = mrunlist[mcurseg].mseq.mtrimax;
                            double m_dest2 = mrunlist[mcurseg].mseq.mtrimin;


                            myedc.Move.Cycle((XLDOPE.CTRL)mrunlist[mcurseg].mseq.controlmode + 
                                Convert.ToInt16(m_Global.mycls.chsignals[mrunlist[mcurseg].mseq.controlmode].EdcChannleSel * 256),
                                m_speed1, m_dest1, 0, m_speed2, m_dest2, 0, (DoPE_HANDLE)(mrunlist[mcurseg].mseq.mcount - mrunlist[mcurseg].mseq.mfinishedcount), m_speed1, m_dest2, ref tan);
                        }

                    }


                    if (mrunlist[mcurseg].mseq.wavekind == 3)

                    {
                        if (mrunlist[mcurseg].mseq.mcount - mrunlist[mcurseg].mseq.mfinishedcount <= 0)
                        {
                            m_runstate = 0;
                        }
                        else
                        {
                            m_runstate = 1;
                            double m_speed = Convert.ToDouble(m_Global.mycls.hardsignals[mrunlist[mcurseg].controlmode].speedSignal.GetOriValue(mrunlist[mcurseg].mseq.msinrate, mrunlist[mcurseg].mseq.msinrateunit));
                            double m_dest1 = mrunlist[mcurseg].mseq.msinmax;
                            double m_dest2 = mrunlist[mcurseg].mseq.msinmin;

                            double m_offset = 0;
                            double m_amp = 0;

                            if (m_dest1 < m_dest2)
                            {
                                m_offset = m_dest1 + (m_dest2 - m_dest1) / 2;
                                m_amp = (m_dest2 - m_dest1) / 2;
                            }
                            else
                            {
                                m_offset = m_dest2 + (m_dest1 - m_dest2) / 2;
                                m_amp = (m_dest1 - m_dest2) / 2;
                            }


                            myedc.Move.DynCyclesSimple(XLDOPE.DYN_WAVEFORM.COSINE, (XLDOPE.DYN_PEAKCTRL)0, (XLDOPE.CTRL)mrunlist[mcurseg].mseq.controlmode
                                + Convert.ToInt16(m_Global.mycls.chsignals[mrunlist[mcurseg].mseq.controlmode].EdcChannleSel * 256), false, m_speed, m_offset, m_amp,
                                mrunlist[mcurseg].mseq.msinfreq, (DoPE_HANDLE)(mrunlist[mcurseg].mseq.mcount - mrunlist[mcurseg].mseq.mfinishedcount), m_speed, m_offset, ref tan);
                        }
                    }


                    mrun = true;

                }
                else
                {

                    if (cmd == 2)
                    {


                    }
                    else
                    {




                        m_runstate = 1;
                        myedc.Move.PosExt((XLDOPE.CTRL)ConvertCtrlMode(firstctl) + Convert.ToInt16(m_Global.mycls.chsignals[firstctl].EdcChannleSel * 256), Convert.ToSingle(speed), XLDOPE.LIMITMODE.NOT_ACTIVE, 5, (XLDOPE.CTRL)ConvertCtrlMode(destctl)
                            , Convert.ToSingle(dest), (XLDOPE.DESTMODE)destmode, ref tan);

                        mrun = true;


                    }
                }

            }




        }


       
        public CDsp()
        {


             w341 = new drivertest1.ClassCW341();
           
            
            rr = new float[10];
            GGMsg = new XLDOPE.Data();
            mdatalist = new Queue<XLDOPE.MDataIno>();

            
            mtimer = new System.Windows.Forms.Timer();
            mtimer.Tick += new EventHandler(mtimer_Tick);
            mtimer.Interval = 40;

            mstarttickcount = Environment.TickCount;

            _pipeServer = new PipeServer();
            _pipeServer.PipeMessage += new DelegateMessage(PipesMessageHandler);

            try
            {
                _pipeServer.Listen("TestPipe");

            }
            catch (Exception)
            {

            }


            //SetThreadAffinityMask(GetCurrentThread(), new UIntPtr(SetCpuID(0)));



        }

        private void PipesMessageHandler(byte[] message)
        {
            _pipeServer._TransferData = ByteToTransferData<TransferData>(message);

            return;

        }

        public byte[] StructTOBytes(object obj)
        {
            int size = Marshal.SizeOf(obj);
            //创建byte数组
            byte[] bytes = new byte[size];
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将结构体拷贝到分配好的内存空间
            Marshal.StructureToPtr(obj, structPtr, false);
            //从内存空间拷贝到byte数组
            Marshal.Copy(structPtr, bytes, 0, size);


            //释放内存空间
            Marshal.FreeHGlobal(structPtr);


            return bytes;
        }
        public TransferData ByteToTransferData<TransferData>(byte[] dataBuffer)
        {
            object structure = null;
            int size = Marshal.SizeOf(typeof(TransferData));
            IntPtr allocIntPtr = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.Copy(dataBuffer, 0, allocIntPtr, size);
                structure = Marshal.PtrToStructure(allocIntPtr, typeof(TransferData));
            }
            finally
            {
                Marshal.FreeHGlobal(allocIntPtr);
            }
            return (TransferData)structure;

        }



        ~CDsp()
        {
            w341.Stop();
            mtimer.Stop();
           


        }



        private int Eh_OnPosMsgHdlr(ref XLDOPE.OnPosMsg OnPosMsg, object Parameter)
        {
            // OnPosMsg.Reached
            m_runstate = 0;

            return 0;
        }
#if DSP_ONDATABLOCK
        private int Eh_OnDataBlockHdlr(ref XLDOPE.OnDataBlock OnDataBlock, object Parameter)
        {
            if (CComLibrary.GlobeVal.filesave == null)
            {
                return 0;
            }
            if (CComLibrary.GlobeVal.filesave.Samplingmode == 0)
            {
                for (int i = 0; i < OnDataBlock.nData; i = i + 4)
                {

                    XLDOPE.Data m1 = new XLDOPE.Data();
                    m1 = OnDataBlock.Data[i].Data;

                    ma = new XLDOPE.MDataIno();
                    ma.Id = 0;
                    ma.mydatainfo = m1;

                    if (m1.Sensor == null)
                    {
                    }
                    else
                    {
                        mt.WaitOne();
                        if (mdatalist.Count > 1000)
                        {
                            mdatalist.Dequeue();
                        }

                        mdatalist.Enqueue(ma);
                        mt.ReleaseMutex();
                    }
                    //   oncount = oncount + 1;
                }
            }
            else
            {
                for (int i = 0; i < OnDataBlock.nData; i = i + 1)
                {

                    XLDOPE.Data m1 = new XLDOPE.Data();
                    m1 = OnDataBlock.Data[i].Data;

                    ma = new XLDOPE.MDataIno();
                    ma.Id = 0;
                    ma.mydatainfo = m1;

                    if (m1.Sensor == null)
                    {
                    }
                    else
                    {
                        mt.WaitOne();
                        if (mdatalist.Count > 2000)
                        {
                            mdatalist.Dequeue();
                        }

                        mdatalist.Enqueue(ma);
                        mt.ReleaseMutex();
                    }
                    //   oncount = oncount + 1;
                }
            }
            return 0;
        }
#else
        private void Eh_OnDataHdlr(ref XLDOPE.OnData m)
        {
            XLDOPE.Data Sample = new XLDOPE.Data();
            Sample = m.Data;




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

            moritime = m.Data.Time;
            ma = new XLDOPE.MDataIno();
            ma.Id = 0;
            ma.mydatainfo = Sample;


            mt.WaitOne();
            if (mdatalist.Count > 1000)
            {
                mdatalist.Dequeue();
            }

            mdatalist.Enqueue(ma);
            mt.ReleaseMutex();

          //  mdatalist.Enqueue(ma);

        
            //  oncount = oncount + 1;

            return;
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


                            mrunlist[mcurseg].mseq.finishedloopcount = current_returncount;


                            CComLibrary.GlobeVal.filesave.mseglist[mcurseg].mseq.finishedloopcount = current_returncount;


                            if (current_returncount >= m_returncount)
                            {
                                CComLibrary.GlobeVal.filesave.mseglist[mcurseg].mseq.runfinished = true;
                                CComLibrary.GlobeVal.filesave.mseglist[mcurseg].mseq.mfinishedcount = CComLibrary.GlobeVal.filesave.mseglist[mcurseg].mseq.mcurrentcount;


                                mcurseg = mcurseg + 1;
                                total_returncount = 0;
                                current_returncount = 0;

                                CComLibrary.SequenceFile sqf = new CComLibrary.SequenceFile();

                                for (int i = 0; i < mrunlist.Count; i++)
                                {
                                    sqf.add(mrunlist[i].mseq);
                                }
                                sqf.SerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ\\sequence\\" + CComLibrary.GlobeVal.filesave.SequenceName);

                                //  CComLibrary.GlobeVal.filesave.SerializeNow(CComLibrary.GlobeVal.filesave.methodname);



                            }
                            else
                            {
                                int bcur = mcurseg;
                                mcurseg = m_returnstep - 1;

                                for (int i = mcurseg; i < bcur; i++)
                                {
                                    CComLibrary.GlobeVal.filesave.mseglist[i].mseq.mfinishedcount = 0;
                                    CComLibrary.GlobeVal.filesave.mseglist[i].mseq.runfinished = false;
                                }

                            }


                        }
                        else
                        {

                            CComLibrary.GlobeVal.filesave.mseglist[mcurseg].mseq.runfinished = true;
                            CComLibrary.GlobeVal.filesave.mseglist[mcurseg].mseq.mfinishedcount = CComLibrary.GlobeVal.filesave.mseglist[mcurseg].mseq.mcurrentcount;


                            mcurseg = mcurseg + 1;
                        }

                        if ((mcurseg < mrunlist.Count))
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
                                      mrunlist[ii].keeptime, mrunlist[ii].returnstep, mrunlist[ii].returncount, mrunlist[ii].action, mrunlist[ii].destmode);
                                }
                                else
                                {
                                    if (ii == mcurseg)
                                    {
                                        segstep(mrunlist[ii].cmd, mrunlist[ii].dest,
                                   Convert.ToInt16(mrunlist[ii].controlmode),
                                    Convert.ToInt16(mrunlist[ii].destcontrolmode),
                                   k, Convert.ToSingle(mrunlist[ii].speed),
                                   mrunlist[ii].keeptime, mrunlist[ii].returnstep, mrunlist[ii].returncount, mrunlist[ii].action, mrunlist[ii].destmode);

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



                    mt.WaitOne();
                    XLDOPE.MDataIno md = mdatalist.Dequeue();


                    if (md.mydatainfo.Sensor == null)
                    {

                    }
                    else
                    {
                        GGMsg = md.mydatainfo;
                    }

                    mt.ReleaseMutex();

                    b = new RawDataStruct();
                    b.data = new double[24];



                    pos = GGMsg.Sensor[0];
                    load = GGMsg.Sensor[1];

                    if (m_Global.mycls.ChannelSampling[2] == 0)
                    {


                        ext = GGMsg.Sensor[2];
                    }


                    //time = AccurateTimer.GetTimeTick();

                    cmd = GGMsg.Test1;

                    time = GGMsg.Time;

                    count = 0;

                    base.count = 0;

                    if (mtestrun == true)
                    {
                        if (CComLibrary.GlobeVal.filesave.Extensometer_DataFrozenFlag  == true)
                        {
                            ext = 0;
                        }
                    }


                    if (CComLibrary.GlobeVal.filesave != null)
                    {
                        if ((CComLibrary.GlobeVal.filesave.mseglist.Count > 0))
                        {
                            if ((mcurseg >= 0) && (mcurseg < CComLibrary.GlobeVal.filesave.mseglist.Count) && (CComLibrary.GlobeVal.filesave.mseglist[mcurseg].mseq.wavekind > 1))
                            {
                                if (mtestrun == true)
                                {


                                    count = CComLibrary.GlobeVal.filesave.mseglist[mcurseg].mseq.mfinishedcount + GGMsg.Cycles;
                                }
                                else
                                {

                                    count = CComLibrary.GlobeVal.filesave.mseglist[mcurseg].mseq.mfinishedcount;
                                }

                                base.count = Convert.ToInt32(count);
                            }

                        }




                        if (CComLibrary.GlobeVal.filesave.mseglist.Count > 0)
                        {
                            if ((mcurseg >= 0) && (mcurseg < CComLibrary.GlobeVal.filesave.mseglist.Count))
                            {

                                if ((CComLibrary.GlobeVal.filesave.mseglist[mcurseg].mseq.wavekind == 2) || (CComLibrary.GlobeVal.filesave.mseglist[mcurseg].mseq.wavekind == 3))
                                {
                                    CComLibrary.GlobeVal.filesave.mseglist[mcurseg].mseq.mcurrentcount = Convert.ToInt32(count);
                                }
                                else
                                {
                                    CComLibrary.GlobeVal.filesave.mseglist[mcurseg].mseq.mcurrentcount = 0;
                                }
                            }

                        }

                    }

                    ClsStaticStation.m_Global.msensor4 = GGMsg.Sensor[3];

                    ClsStaticStation.m_Global.msensor5 = GGMsg.Sensor[4];

                    ClsStaticStation.m_Global.msensor6 = GGMsg.Sensor[5];


                    ClsStaticStation.m_Global.msensor7 = GGMsg.Sensor[6];

                    ClsStaticStation.m_Global.msensor8 = GGMsg.Sensor[7];


                    //自定义通道赋值
                    ClsStaticStation.m_Global.mload = load;

                    ClsStaticStation.m_Global.mpos = pos;



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

                            b.data[m_Global.mycls.datalist[j].EdcId] = cmd;


                        }




                        if (m_Global.mycls.datalist[j].SignName == "Ch Count")
                        {

                            b.data[m_Global.mycls.datalist[j].EdcId] = count;





                        }
                        if (m_Global.mycls.datalist[j].SignName == "Ch Disp Max")
                        {
                            for (int m = 0; m < m_Global.mycls.chsignals.Count; m++)
                            {
                                if (m_Global.mycls.chsignals[m].SignName == "Ch Disp")
                                {
                                    b.data[m_Global.mycls.datalist[j].EdcId] = m_Global.mycls.chsignals[m].cvaluemax;
                                }
                            }
                        }

                        if (m_Global.mycls.datalist[j].SignName == "Ch Disp Min")
                        {
                            for (int m = 0; m < m_Global.mycls.chsignals.Count; m++)
                            {
                                if (m_Global.mycls.chsignals[m].SignName == "Ch Disp")
                                {
                                    b.data[m_Global.mycls.datalist[j].EdcId] = m_Global.mycls.chsignals[m].cvaluemin;
                                }
                            }
                        }


                        if (m_Global.mycls.datalist[j].SignName == "Ch Load Max")
                        {
                            for (int m = 0; m < m_Global.mycls.chsignals.Count; m++)
                            {
                                if (m_Global.mycls.chsignals[m].SignName == "Ch Load")
                                {
                                    b.data[m_Global.mycls.datalist[j].EdcId] = m_Global.mycls.chsignals[m].cvaluemax;
                                }
                            }
                        }

                        if (m_Global.mycls.datalist[j].SignName == "Ch Load Min")
                        {
                            for (int m = 0; m < m_Global.mycls.chsignals.Count; m++)
                            {
                                if (m_Global.mycls.chsignals[m].SignName == "Ch Load")
                                {
                                    b.data[m_Global.mycls.datalist[j].EdcId] = m_Global.mycls.chsignals[m].cvaluemin;
                                }
                            }
                        }


                        if (m_Global.mycls.datalist[j].SignName == "Ch Ext Max")
                        {
                            for (int m = 0; m < m_Global.mycls.chsignals.Count; m++)
                            {
                                if (m_Global.mycls.chsignals[m].SignName == "Ch Ext")
                                {
                                    b.data[m_Global.mycls.datalist[j].EdcId] = m_Global.mycls.chsignals[m].cvaluemax;
                                }
                            }
                        }

                        if (m_Global.mycls.datalist[j].SignName == "Ch Ext Min")
                        {
                            for (int m = 0; m < m_Global.mycls.chsignals.Count; m++)
                            {
                                if (m_Global.mycls.chsignals[m].SignName == "Ch Ext")
                                {
                                    b.data[m_Global.mycls.datalist[j].EdcId] = m_Global.mycls.chsignals[m].cvaluemin;
                                }
                            }
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


                   
                    /*
                    if (ClsStatic.savedatacount >= ClsStatic.savedata.NodeCount - 1)
                    {
                        ClsStatic.savedata.Read<RawDataDataGroup>(out d, 10);
                        ClsStatic.savedatacount = ClsStatic.savedatacount - 1;
                    }
                    ClsStatic.savedatacount = ClsStatic.savedatacount + 1;
                    ClsStatic.savedata.Write<RawDataDataGroup>(ref c, 10);
                    */

                    for (j = 0; j < m_Global.mycls.allsignals.Count; j++)
                    {
                        if (m_Global.mycls.allsignals[j].SignName == "Ch Command")
                        {

                            m_Global.mycls.allsignals[j].cvalue = cmd;

                        }




                    }
                    for (j = 0; j < m_Global.mycls.allsignals.Count; j++)
                    {

                        if (m_Global.mycls.allsignals[j].SignName == "Ch Time")
                        {
                            m_Global.mycls.allsignals[j].cvalue = time;
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
                            if (pos > m_Global.mycls.allsignals[j].bvaluemax)
                            {
                                m_Global.mycls.allsignals[j].bvaluemax = pos;
                            }
                            if (pos < m_Global.mycls.allsignals[j].bvaluemin)
                            {
                                m_Global.mycls.allsignals[j].bvaluemin = pos;
                            }
                            if (pos > m_Global.mycls.allsignals[j].rvaluemax)
                            {
                                m_Global.mycls.allsignals[j].rvaluemax = pos;
                            }
                            if (pos < m_Global.mycls.allsignals[j].rvaluemin)
                            {
                                m_Global.mycls.allsignals[j].rvaluemin = pos;
                            }

                        }

                        if (m_Global.mycls.allsignals[j].SignName == "Ch Load")
                        {
                            m_Global.mycls.allsignals[j].cvalue = load;

                            if (load > m_Global.mycls.allsignals[j].bvaluemax)
                            {
                                m_Global.mycls.allsignals[j].bvaluemax = load;
                            }
                            if (load < m_Global.mycls.allsignals[j].bvaluemin)
                            {
                                m_Global.mycls.allsignals[j].bvaluemin = load;
                            }
                            if (load > m_Global.mycls.allsignals[j].rvaluemax)
                            {
                                m_Global.mycls.allsignals[j].rvaluemax = load;
                            }
                            if (load < m_Global.mycls.allsignals[j].rvaluemin)
                            {
                                m_Global.mycls.allsignals[j].rvaluemin = load;
                            }


                        }

                        if (m_Global.mycls.allsignals[j].SignName == "Ch Ext")
                        {
                            m_Global.mycls.allsignals[j].cvalue = ext;

                            if (ext > m_Global.mycls.allsignals[j].bvaluemax)
                            {
                                m_Global.mycls.allsignals[j].bvaluemax = ext;
                            }
                            if (ext < m_Global.mycls.allsignals[j].bvaluemin)
                            {
                                m_Global.mycls.allsignals[j].bvaluemin = ext;
                            }
                            if (ext > m_Global.mycls.allsignals[j].rvaluemax)
                            {
                                m_Global.mycls.allsignals[j].rvaluemax = ext;
                            }
                            if (ext < m_Global.mycls.allsignals[j].rvaluemin)
                            {
                                m_Global.mycls.allsignals[j].rvaluemin = ext;
                            }



                        }

                        if (m_Global.mycls.allsignals[j].SignName == "Ch Count")
                        {
                            m_Global.mycls.allsignals[j].cvalue = count;

                            if (Math.Abs(Convert.ToInt32(count) - oldcount) >= 2)
                            {
                                for (int m = 0; m < m_Global.mycls.chsignals.Count; m++)
                                {
                                    m_Global.mycls.chsignals[m].cvaluemax = m_Global.mycls.chsignals[m].bvaluemax;
                                    m_Global.mycls.chsignals[m].cvaluemin = m_Global.mycls.chsignals[m].bvaluemin;
                                    m_Global.mycls.chsignals[m].bvaluemax = m_Global.mycls.chsignals[m].fullminbase;
                                    m_Global.mycls.chsignals[m].bvaluemin = m_Global.mycls.chsignals[m].fullmaxbase;

                                }

                                oldcount = Convert.ToInt32(count);
                            }


                        }

                       


                        /*
                        for (int m = 0; m < 100; m++)
                        {
                            if (m_Global.mycls.allsignals[j].SignName == "Ch User" + m.ToString().Trim())
                            {
                                m_Global.mycls.allsignals[j].cvalue = rr[m + 1];

                            }

                        }
                        */

                    }

                }




            }
        }

        public override void Init(int handle)
        {

            OpenConnection();


        }

        int OpenConnection()
        {
            short tan = 0;

            try
            {
                myedc = new XLDOPE.Edc(XLDOPE.OpenBy.DeviceId, 0, 0, 0, 0, 0, 0);
                //myedc = new XLDOPE.Edc(XLDOPE.OpenBy.DeviceId, 0);

                connected = myedc.IsConnected();

            }
            catch (System.BadImageFormatException)
            {
                connected = false;

            }

#if DSP_ONDATABLOCK

            myedc.Eh.SetOnDataBlockSize(190);
#else
                myedc.Eh.SetOnDataBlockSize(0);
#endif

            myedc.Eh.OnHandlerFuncHdlr += new XLDOPE.OnHandlerFuncHdlr(Eh_OnHandlerFuncHdlr);

#if DSP_ONDATABLOCK
            myedc.Eh.OnDataBlockHdlr += new XLDOPE.OnDataBlockHdlr(Eh_OnDataBlockHdlr);
#else
                myedc.Eh.OnDataHdlr += new XLDOPE.OnDataHdlr(Eh_OnDataHdlr);
#endif


            myedc.Eh.OnPosMsgHdlr += new XLDOPE.OnPosMsgHdlr(Eh_OnPosMsgHdlr);

            // Set UserScale
            XLDOPE.UserScale userScale = new XLDOPE.UserScale();
            // set position and extension scale to mm

            for (int i = 0; i < ClsStaticStation.m_Global.mycls.chsignals.Count; i++)
            {
                if (ClsStaticStation.m_Global.mycls.chsignals[i].cUnitKind == 1)
                {
                    userScale[(XLDOPE.SENSOR)i] = 0.001;
                }
            }



            // Select machine setup and initialize
            myedc.Setup.SelSetup(XLDOPE.SETUP_NUMBER.SETUP_1, userScale, ref tan, ref tan);

            DataTransmissionRate = 0.001;
          //  myedc.Data.SetDataTransmissionRate(base.DataTransmissionRate);


            mtimer.Start();



            return 0;
        }

        public override int CloseConnection()
        {
            mtimer.Stop();




            return 0;
        }
    }
}

