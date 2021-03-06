﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using Microsoft.VisualBasic.Compatibility;
using System.Windows.Forms;

using PipesServerTest;
namespace ClsStaticStation
{

    struct demodata
    {
        public double pos;
        public double load;
        public double ext;
        public double poscmd;
        public double loadcmd;
        public double extcmd;
        public double time;
        public double count;
        public double pos1;//围压位移
        public double load1;//围压负荷
    }

    public class CArm : ClsBaseControl
    {
        a9500.MDataIno m_MDataIno = new a9500.MDataIno();
        
       

        static double m_samplestarttime;//采样信号开始时间

      
        long basecount = 0;


        public long oldcount = 0;



        private RawDataDataGroup[] r = new RawDataDataGroup[1];
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public a9500.DataInfo GGMsg;
        private a9500.OnGetDataDel GetDataIns;
        public short DeviceNum = 0;
        private float mLoadCapacity; //力满量程值
        private RawDataStruct b;



      




        private double mstarttime;

        private List<a9500.MDataIno> mdatalist;

        private System.Windows.Forms.Timer mtimer;


        private bool mdemotesting = false;
        private int mdemotestingp = 0;

        private double pos;
        private double load;
        private double ext;
        private double poscmd;
        private double loadcmd;
        private double extcmd;
        private double time;

        private double posmax;
        private double posmin;
        private double loadmax;
        private double loadmin;
        private double extmax;
        private double extmin;

        private double time2;

        private double moritime;
        private double count;
        private double pos1;//围压位移
        private double load1;//围压负荷

        private double mspeed_load0;
        private double mspeed_load1;
        private double mspeed_pos0;
        private double mspeed_pos1;
        private double mspeed_time0;

        private double sensor4;
        private double sensor5;
        private double sensor6;
        private double sensor7;
        private double sensor8;





        public double maxload;

        private Boolean mrun = false;//函数执行后置位

        private Boolean mbeingtest = false;

        public List<CComLibrary.CmdSeg> mrunlist;



        public double mrunstarttime = 0;

        private Boolean m_limit = false;//硬限位

        private short oldsystemState = 0;
        private Boolean m_EmergencyStop = false;//急停

        private int m_runstate1;//函数运行状态 围压
        private int m_runstate0;//函数运行状态 轴压

        private int m_runstate;//函数运行状态

        private int m_runlaststate;//

        private double m_keeptime;//保持时间

        private double m_keepstarttime;//开始保持时时间

        private bool m_keepstart = false;//开始保持




        private bool fConnected = false;
        public override bool Connected()//
        {
            return fConnected;


        }




        private int m_returnstep;//返回步骤
        private int m_returncount;//返回次数



        public int rrr = 0;
        public int www = 0;
        public override void setrunstate(int m)
        {
            m_runstate = m;
        }

        private List<demodata> mdemodata = new List<demodata>();

        public override void btnzeroall()
        {

        }

        public override void btnrestoreall()
        {

        }
        public override void startcontrol()
        {

        }
        public override void endcontrol()
        {


        }

        public override void Exit()
        {

        }
        public override bool getlimit(int ch)
        {
            return m_limit;
        }

        public override bool getEmergencyStop()
        {
            return m_EmergencyStop;
        }

        public override int getrunstate() // 1运行 0 停止
        {
            if (mdemo == true)
            {
            }

            else
            {

                if ((m_runstate0 == 0) && (m_runstate1 == 0))
                {
                    m_runstate = 0;
                }
                else
                {
                    m_runstate = 1;
                }
            }

            return m_runstate;
        }



        public override int ConvertCtrlMode(int ctrl)
        {
            int t = 0;
            if (ctrl == 0) //位移
            {

                t = a9500.mCTRL_POS;
            }
            if (ctrl == 1)  //负荷
            {
                t = a9500.mCTRL_LOAD;
            }

            if (ctrl == 2) //变形
            {
                t = a9500.mCTRL_EXTENSION;
            }

            return t;
        }












        public CArm()
        {
           
           
            GGMsg = new a9500.DataInfo();
            mdatalist = new List<a9500.MDataIno>();
            mtimer = new System.Windows.Forms.Timer();
            mtimer.Tick += new EventHandler(mtimer_Tick);
            mtimer.Interval = 50;
            mtimer.Enabled = true;
            mtimer.Start();

           



        }

        

        ~CArm()
        {
            mtimer.Stop();
            
           

        }

        private void MSerialPort3_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

        }

        private void MSerialPort2_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {


        }

        private void MSerialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {



        }

        private void gatherdatafromSerialPort()
        {



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

        public override void DriveOn()
        {

            a9500.ARM_DEC_System_OFF(DeviceNum);
            DelayS(0.1);
            a9500.ARM_DEC_System_OFF(DeviceNum);
            DelayS(0.1);
            a9500.ARM_DEC_System_ON(DeviceNum);

            a9500.ARM_DEC_SendOUTSignal(0, DeviceNum, 16);
        }

        public override void DriveOff()
        {

            a9500.ARM_DEC_System_OFF(DeviceNum);

            a9500.ARM_DEC_SendOUTSignal(0, DeviceNum, 17);
        }

        public override void CrossUp(int ctrlmode, double speed)
        {
            a9500.SIMPLELINE s1;
            s1 = new a9500.SIMPLELINE();


            if (ctrlmode == 1)
            {

                s1.ctl = a9500.mCTRL_LOAD;

            }
            else
            {
                s1.ctl = a9500.mCTRL_POS;
            }

            s1.dest = 900000;
            s1.speed = Convert.ToSingle(speed) / 60;
            s1.num = 0;

            a9500.ARM_DEC_SendMove(0, DeviceNum, ref s1);
        }

        public override void SetBaseCount(int count)
        {
            basecount = count;
        }
        public override void CrossDown(int ctrlmode, double speed)
        {
            a9500.SIMPLELINE s1;
            s1 = new a9500.SIMPLELINE();


            if (ctrlmode == 1)
            {

                s1.ctl = ClsStaticStation.a9500.mCTRL_LOAD;

            }
            else
            {
                s1.ctl = ClsStaticStation.a9500.mCTRL_POS;
            }
            s1.dest = -900000;
            s1.speed = Convert.ToSingle(speed) / 60;
            s1.num = 0;

            a9500.ARM_DEC_SendMove(0, DeviceNum, ref s1);
        }

        public override void CrossStop(int ctrlmode)
        {
            a9500.ARM_DEC_MoveStop(0, DeviceNum, Convert.ToInt16(ConvertCtrlMode(ctrlmode)));

        }

        public override  void fatigstop()
        {
           
        }
        public override void fatigtest(int wavekind, float freq, float ave, float range, double count)
        {
            a9500.CSinWave SinS = new a9500.CSinWave();
            a9500.CTriWave TriangleS = new a9500.CTriWave();
            if (wavekind == 0)
            {

                SinS.ctlMode = a9500.mCTRL_LOAD;
                SinS.fspeed = Convert.ToSingle(10.0 / 60);
                SinS.fdestination = ave;
                SinS.mdestination = range;

                SinS.lspeed = Convert.ToSingle(10.0 / 60);
                SinS.ldestination = 0;

                SinS.frq = freq;
                SinS.mphase = 0;
                SinS.cycles = Convert.ToInt32(count);
                a9500.ARM_DEC_SendSineWave(0, DeviceNum, 0, 1, 0, ref SinS);
                a9500.ARM_DEC_Test_Start(DeviceNum, 0);
            }

            else if (wavekind == 1)
            {
                TriangleS.ctlMode = a9500.mCTRL_LOAD;
                TriangleS.fspeed = Convert.ToSingle(10.0 / 60);
                TriangleS.fdestination = ave;
                TriangleS.mdestination = range;

                TriangleS.lspeed = Convert.ToSingle(10.0 / 60);
                TriangleS.ldestination = 0;

                TriangleS.frq = freq;

                TriangleS.mphase = 0;
                TriangleS.cycles = Convert.ToInt32(count);


                a9500.ARM_DEC_SendTriWave(0, DeviceNum, 0, 1, 0, ref TriangleS);
                a9500.ARM_DEC_Test_Start(DeviceNum, 0);

            }

            dianyabaohu = false;
           ;
          
       

        }
        public override void DestStart(int ctrlmode, double dest, double speed)
        {
            a9500.COMPLEXMOVEST move = new a9500.COMPLEXMOVEST();

            move.dest = Convert.ToSingle(dest);
            move.firstctl = Convert.ToInt16(ConvertCtrlMode(ctrlmode));
            move.destctl = Convert.ToInt16(ConvertCtrlMode(ctrlmode));


            move.destkeepstyle = 1;

            move.speed = Convert.ToSingle(speed / 60);
            move.num = 0;
            move.runmsg = 0;
            move.holdtime = 0;
            a9500.ARM_DEC_SendComplexMove(0, DeviceNum, 0, 1, 0, ref move);
            DelayS(0.1);
            a9500.ARM_DEC_Test_Start(DeviceNum, 0);
        }

        public override void DestStop(int ctrlmode)
        {
            ClsStaticStation.a9500.ARM_DEC_Test_Stop(DeviceNum, 0);

            DelayS(0.1);


            ClsStaticStation.a9500.ARM_DEC_MoveStop(0, DeviceNum,
               Convert.ToInt16(ConvertCtrlMode(ctrlmode)));
        }
        public override void demotest(bool testing)
        {
            mdemotesting = testing;
            mdemotestingp = 0;


        }

        private void demo()
        {

            int j;
            int i;
            int jj;
            int ii;

            b = new RawDataStruct();
            b.data = new double[24];
            if (mdemotesting == false)
            {
                Random r = new Random(System.Environment.TickCount);
                load = r.NextDouble();
                pos = r.NextDouble();
                ext = r.NextDouble();
                sensor4 = r.NextDouble();
               // sensor5 = r.NextDouble() + 1;
                sensor6 = r.NextDouble() + 2;
                sensor7 = r.NextDouble() + 3;
                sensor8 = r.NextDouble() + 4;
                time = System.Environment.TickCount / 1000.0;
                poscmd = 0;
                loadcmd = 0;
                extcmd = 0;
                count = 0;
                load1 = r.NextDouble();
                pos1 = r.NextDouble();

            }
            else
            {
                Random r = new Random(System.Environment.TickCount);
                load = r.NextDouble();
                pos = r.NextDouble();
                ext = r.NextDouble();
                sensor4 = r.NextDouble();
                sensor5 = r.NextDouble() + 1;
                sensor6 = r.NextDouble() + 2;
                sensor7 = r.NextDouble() + 3;
                sensor8 = r.NextDouble() + 4;
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
                    ext = mdemodata[mdemotestingp].ext;
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

            ClsStaticStation.m_Global.mext = ext;

            ClsStaticStation.m_Global.msensor4 = sensor4;
            ClsStaticStation.m_Global.msensor5 = sensor5;
            ClsStaticStation.m_Global.msensor6 = sensor6;
            ClsStaticStation.m_Global.msensor7 = sensor7;
            ClsStaticStation.m_Global.msensor8 = sensor8;


            ClsStaticStation.m_Global.mload1 = load1;
            ClsStaticStation.m_Global.mpos1 = pos1;


            if (time - mspeed_time0 >= 0.1)
            {
                mspeed_load1 = (load - mspeed_load0) / (time - mspeed_time0);
                mspeed_pos1 = (pos - mspeed_pos0) / (time - mspeed_time0);
                mspeed_time0 = time;
                mspeed_load0 = load;
                mspeed_pos0 = pos;


            }


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


                if (m_Global.mycls.datalist[j].SignName == "Ch Count")
                {

                    b.data[m_Global.mycls.datalist[j].EdcId] = count;

                    if (oldcount != Convert.ToInt64(count))
                    {
                        for (int m = 0; m < m_Global.mycls.chsignals.Count; m++)
                        {
                            m_Global.mycls.chsignals[m].cvaluemax = m_Global.mycls.chsignals[m].bvaluemax;
                            m_Global.mycls.chsignals[m].cvaluemin = m_Global.mycls.chsignals[m].bvaluemin;
                            m_Global.mycls.chsignals[m].bvaluemax = m_Global.mycls.chsignals[m].fullminbase;
                            m_Global.mycls.chsignals[m].bvaluemin = m_Global.mycls.chsignals[m].fullmaxbase;
                        }

                        oldcount = Convert.ToInt64(count);
                    }
                }


                if (m_Global.mycls.datalist[j].SignName == "Ch Disp Max")
                {
                    b.data[m_Global.mycls.datalist[j].EdcId] = m_Global.mycls.chsignals[0].cvaluemax;

                }
                if (m_Global.mycls.datalist[j].SignName == "Ch Disp Min")
                {
                    b.data[m_Global.mycls.datalist[j].EdcId] = m_Global.mycls.chsignals[0].cvaluemin;

                }

                if (m_Global.mycls.datalist[j].SignName == "Ch Load Max")
                {
                    b.data[m_Global.mycls.datalist[j].EdcId] = m_Global.mycls.chsignals[1].cvaluemax;

                }
                if (m_Global.mycls.datalist[j].SignName == "Ch Load Min")
                {
                    b.data[m_Global.mycls.datalist[j].EdcId] = m_Global.mycls.chsignals[1].cvaluemin;

                }

                if (m_Global.mycls.datalist[j].SignName == "Ch Ext Max")
                {
                    b.data[m_Global.mycls.datalist[j].EdcId] = m_Global.mycls.chsignals[2].cvaluemax;

                }
                if (m_Global.mycls.datalist[j].SignName == "Ch Ext Min")
                {
                    b.data[m_Global.mycls.datalist[j].EdcId] = m_Global.mycls.chsignals[2].cvaluemin;

                }

                if (m_Global.mycls.datalist[j].SignName == "Ch Sensor5")
                {

                    b.data[m_Global.mycls.datalist[j].EdcId] = sensor5;


                }


                if (m_Global.mycls.datalist[j].SignName == "Ch Sensor6")
                {

                    b.data[m_Global.mycls.datalist[j].EdcId] = sensor6;


                }

                if (m_Global.mycls.datalist[j].SignName == "Ch Sensor7")
                {

                    b.data[m_Global.mycls.datalist[j].EdcId] = sensor7;


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


                if (m_Global.mycls.datalist[j].SignName == "Ch Load Speed")
                {
                    b.data[m_Global.mycls.datalist[j].EdcId] = mspeed_load1;

                }

                if (m_Global.mycls.datalist[j].SignName == "Ch Disp Speed")
                {
                    b.data[m_Global.mycls.datalist[j].EdcId] = mspeed_pos1;

                }


            }

            RawDataDataGroup d;
            RawDataDataGroup c = new RawDataDataGroup();
            c.ID = 0;
            m_Global.mycls.structcopy_RawDataData(ref c.rdata, b);
            for (j = 0; j < 2; j++)
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


                if (m_Global.mycls.allsignals[j].SignName == "Ch Disp Speed")
                {
                    m_Global.mycls.allsignals[j].cvalue = mspeed_pos1;
                }

                if (m_Global.mycls.allsignals[j].SignName == "Ch Load Speed")
                {
                    m_Global.mycls.allsignals[j].cvalue = mspeed_load1;
                }

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

                if (m_Global.mycls.allsignals[j].SignName == "Ch Sensor5")
                {
                    m_Global.mycls.allsignals[j].cvalue = sensor5;

                }

                if (m_Global.mycls.allsignals[j].SignName == "Ch Sensor6")
                {
                    m_Global.mycls.allsignals[j].cvalue = sensor6;

                }

                if (m_Global.mycls.allsignals[j].SignName == "Ch Sensor7")
                {
                    m_Global.mycls.allsignals[j].cvalue = sensor7;

                }

                if (m_Global.mycls.allsignals[j].SignName == "Ch Count")
                {
                    m_Global.mycls.allsignals[j].cvalue = count;



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

        public void Timer()
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



                    if (mdatalist[jj].Id == 0)
                    {
                        switch (mdatalist[jj].mydatainfo.runmsg)
                        {
                            //直线移动 0A  横梁停止 0B  手轮操作 0C  ComplexLineSet 0D ComplexMoveSet 0E  单段结束 20
                            case 0xa:
                                m_runstate0 = 1;
                                break;
                            case 0xe:

                                m_runstate0 = 1;
                                break;

                            case 0xb:
                                m_runstate0 = 0;
                                break;


                            case 0x20:
                                m_runstate0 = 0;
                                break;


                        }
                        rrr = m_runstate0;
                    }

                    if (mdatalist[jj].Id == DeviceNum)
                    {
                        switch (mdatalist[jj].mydatainfo.runmsg)
                        {
                            //直线移动 0A  横梁停止 0B  手轮操作 0C  ComplexLineSet 0D ComplexMoveSet 0E  单段结束 20
                            case 0xa:
                                m_runstate1 = 1;
                                break;

                            case 0xe:

                                m_runstate1 = 1;
                                break;

                            case 0xb:
                                m_runstate1 = 0;
                                break;

                            case 0x20:
                                m_runstate1 = 0;
                                break;


                        }
                        www = m_runstate1;
                    }

                    b = new RawDataStruct();
                    b.data = new double[24];


                    if (mdatalist[jj].Id == DeviceNum)
                    {
                        unsafe
                        {
                            fixed (float* p = GGMsg.sensordata)
                            {
                                load = *(p + a9500.SENSOR_ARM_F);
                                pos = *(p + a9500.SENSOR_ARM_S);
                                ext = *(p + a9500.SENSOR_ARM_E);
                                sensor4 = *(p + a9500.SENSOR_ARM_D);

                                sensor5 = mdatalist[jj].sensor5;
                                sensor6 = mdatalist[jj].sensor6;
                                sensor7 = mdatalist[jj].sensor7;
                                time = mdatalist[jj].time1;
                                time2 = mdatalist[jj].time2;
                                //sensor5 = *(p + a9500.SENSOR_ARM_4);
                                //sensor6 = *(p + a9500.SENSOR_ARM_5);
                                //sensor7 = *(p + a9500.SENSOR_ARM_6);
                                sensor8 = *(p + a9500.SENSOR_ARM_7);


                            }

                            fixed (double* p1 = GGMsg.free2)
                            {
                                poscmd = *(p1 + 1);
                                loadcmd = *(p1 + 0);
                                extcmd = *(p1 + 2);
                            }

                            //time = GGMsg.time;
                            moritime = time;

                            //time = time - mstarttime;

                            count = GGMsg.incount + basecount;//?
                           
                        }
                    }



                    else if (mdatalist[jj].Id == 2)
                    {
                        unsafe
                        {
                            fixed (float* p = GGMsg.sensordata)
                            {
                                load1 = *(p + a9500.SENSOR_ARM_F);
                                pos1 = *(p + a9500.SENSOR_ARM_S);
                                // ext = *(p + a9500.SENSOR_ARM_E);

                            }

                            fixed (double* p1 = GGMsg.free2)
                            {
                                // poscmd = *(p1 + 1);
                                // loadcmd = *(p1 + 0);
                                // extcmd = *(p1 + 2);
                            }

                            // time = GGMsg.time;
                            // count = GGMsg.count;//?
                        }

                    }



                    //自定义通道赋值
                    ClsStaticStation.m_Global.mload = load;

                    ClsStaticStation.m_Global.mpos = pos;
                    ClsStaticStation.m_Global.mext = ext;


                    ClsStaticStation.m_Global.mload1 = load1;
                    ClsStaticStation.m_Global.mpos1 = pos1;
                    ClsStaticStation.m_Global.msensor4 = sensor4;
                    ClsStaticStation.m_Global.msensor5 = sensor5;
                    ClsStaticStation.m_Global.msensor6 = sensor6;
                    ClsStaticStation.m_Global.msensor7 = sensor7;
                    ClsStaticStation.m_Global.msensor8 = sensor8;



                    if (CComLibrary.GlobeVal.filesave == null)
                    {

                    }
                    else
                    {
                        
                    }

                    if (time - mspeed_time0 >= 0.1)
                    {
                        mspeed_load1 = (load - mspeed_load0) / (time - mspeed_time0);
                        mspeed_pos1 = (pos - mspeed_pos0) / (time - mspeed_time0);
                        mspeed_time0 = time;
                        mspeed_load0 = load;
                        mspeed_pos0 = pos;


                    }

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

                        if (m_Global.mycls.datalist[j].SignName == "Ch Time1")
                        {

                            b.data[m_Global.mycls.datalist[j].EdcId] = time2;


                            if (time > m_Global.mycls.datalist[j].bvaluemax)
                            {
                                m_Global.mycls.datalist[j].bvaluemax = time2;
                            }
                            if (time < m_Global.mycls.datalist[j].bvaluemin)
                            {
                                m_Global.mycls.datalist[j].bvaluemin = time2;
                            }


                            m_Global.mycls.datalist[j].rvaluemax = time2;


                            m_Global.mycls.datalist[j].rvaluemin = 0;



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

                        if (m_Global.mycls.datalist[j].SignName == "Ch Sensor5")
                        {

                            b.data[m_Global.mycls.datalist[j].EdcId] = sensor5;


                        }

                        if (m_Global.mycls.datalist[j].SignName == "Ch Sensor6")
                        {

                            b.data[m_Global.mycls.datalist[j].EdcId] = sensor6;


                        }
                        if (m_Global.mycls.datalist[j].SignName == "Ch Sensor7")
                        {

                            b.data[m_Global.mycls.datalist[j].EdcId] = sensor7;


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
                           

                            if (oldcount != Convert.ToInt64(count))
                            {
                                for (int m = 0; m < m_Global.mycls.chsignals.Count; m++)
                                {
                                    m_Global.mycls.chsignals[m].cvaluemax = m_Global.mycls.chsignals[m].bvaluemax;
                                    m_Global.mycls.chsignals[m].cvaluemin = m_Global.mycls.chsignals[m].bvaluemin;
                                    m_Global.mycls.chsignals[m].bvaluemax = m_Global.mycls.chsignals[m].fullminbase;
                                    m_Global.mycls.chsignals[m].bvaluemin = m_Global.mycls.chsignals[m].fullmaxbase;
                                }

                                oldcount = Convert.ToInt64(count);
                            }

                        }


                        if (m_Global.mycls.datalist[j].SignName == "Ch Disp Max")
                        {
                            b.data[m_Global.mycls.datalist[j].EdcId] = m_Global.mycls.chsignals[0].cvaluemax;

                        }
                        if (m_Global.mycls.datalist[j].SignName == "Ch Disp Min")
                        {
                            b.data[m_Global.mycls.datalist[j].EdcId] = m_Global.mycls.chsignals[0].cvaluemin;

                        }

                        if (m_Global.mycls.datalist[j].SignName == "Ch Load Max")
                        {
                            b.data[m_Global.mycls.datalist[j].EdcId] = m_Global.mycls.chsignals[1].cvaluemax ;
                            
                        }
                        if (m_Global.mycls.datalist[j].SignName == "Ch Load Min")
                        {
                            b.data[m_Global.mycls.datalist[j].EdcId] = m_Global.mycls.chsignals[1].cvaluemin;

                        }

                        if (m_Global.mycls.datalist[j].SignName == "Ch Ext Max")
                        {
                            b.data[m_Global.mycls.datalist[j].EdcId] = m_Global.mycls.chsignals[2].cvaluemax;

                        }
                        if (m_Global.mycls.datalist[j].SignName == "Ch Ext Min")
                        {
                            b.data[m_Global.mycls.datalist[j].EdcId] = m_Global.mycls.chsignals[2].cvaluemin;

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

                        if (m_Global.mycls.datalist[j].SignName == "Ch Load Speed")
                        {
                            b.data[m_Global.mycls.datalist[j].EdcId] = mspeed_load1;

                        }

                        if (m_Global.mycls.datalist[j].SignName == "Ch Disp Speed")
                        {
                            b.data[m_Global.mycls.datalist[j].EdcId] = mspeed_pos1;

                        }




                    }

                    RawDataDataGroup d;
                    RawDataDataGroup c = new RawDataDataGroup();
                    c.ID = 0;
                    m_Global.mycls.structcopy_RawDataData(ref c.rdata, b);
                    for (j = 0; j < 2; j++)
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
                        if (m_Global.mycls.allsignals[j].SignName == "Ch Disp Speed")
                        {
                            m_Global.mycls.allsignals[j].cvalue = mspeed_pos1;
                        }

                        if (m_Global.mycls.allsignals[j].SignName == "Ch Load Speed")
                        {
                            m_Global.mycls.allsignals[j].cvalue = mspeed_load1;
                        }

                        if (m_Global.mycls.allsignals[j].SignName == "Ch Time")
                        {
                            m_Global.mycls.allsignals[j].cvalue = time;
                        }

                        if (m_Global.mycls.allsignals[j].SignName == "Ch Time1")
                        {
                            m_Global.mycls.allsignals[j].cvalue = time2;
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

                        if (m_Global.mycls.allsignals[j].SignName == "Ch Ext")
                        {
                            m_Global.mycls.allsignals[j].cvalue = ext;


                        }

                        if (m_Global.mycls.allsignals[j].SignName == "Ch Sensor5")
                        {
                            m_Global.mycls.allsignals[j].cvalue = sensor5;

                        }

                        if (m_Global.mycls.allsignals[j].SignName == "Ch Sensor6")
                        {
                            m_Global.mycls.allsignals[j].cvalue = sensor6;

                        }


                        if (m_Global.mycls.allsignals[j].SignName == "Ch Sensor7")
                        {
                            m_Global.mycls.allsignals[j].cvalue = sensor7;

                        }

                        if (m_Global.mycls.allsignals[j].SignName == "Ch Count")
                        {
                            m_Global.mycls.allsignals[j].cvalue = count;
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

                for (jj = 0; jj < ii; jj++)
                {
                    //  mdatalist.RemoveAt(0);
                }

                if (ii > 2)
                {
                    mdatalist.RemoveRange(0, ii - 1);

                   
                }
                //mdatalist.Clear();

            }

        }

        public override void DelayS(double t)
        {
            double m = Environment.TickCount;

            while ((Environment.TickCount - m) / 1000 <= t)
            {
                Application.DoEvents();
            }


        }

        public override void endtest()
        {
            mstarttime = 0;

            if (mdemo == true)
            {
                m_runstate = 0;
            }
            else
            {
                ClsStaticStation.a9500.ARM_DEC_Test_Stop(DeviceNum, 0);

                DelayS(0.1);

                ClsStaticStation.a9500.ARM_DEC_MoveStop(0, DeviceNum, ClsStaticStation.a9500.mCTRL_POS);

                ClsStaticStation.a9500.ARM_DEC_Test_Stop(0, 0);

                DelayS(0.1);

                ClsStaticStation.a9500.ARM_DEC_MoveStop(0, 0, ClsStaticStation.a9500.mCTRL_POS);


            }
            mtestrun = false;
            mbeingtest = false;

            CComLibrary.GlobeVal.InitUserCalcChannel();//初始化用户自定义通道


        }



        public override void starttest(int spenum)
        {
            short k = 0;
            RawDataDataGroup d;

            dianyabaohu = false;

            maxload = 0;
            mstarttime = moritime;
            duanliebaohu = false;



            if (this.getrunstate() == 1)
            {
                MessageBox.Show("请先停止运行然后开始");
                return;
            }
          
            int iii = 0;

            int ncount = ClsStatic.arraydata[0].NodeCount;

            while (iii < ncount)
            {


                ClsStatic.arraydata[0].Read<RawDataDataGroup>(out d, 10);
              

                iii = iii + 1;


            }

            ClsStatic.arraydatacount[0] = 0;
            ClsStatic.arraydatacount[1] = 0;


            iii = 0;

            ncount = ClsStatic.arraydata[1].NodeCount;

            while (iii < ncount )
            {


                ClsStatic.arraydata[1].Read<RawDataDataGroup>(out d, 10);


                iii = iii + 1;


            }

            ClsStatic.arraydatacount[1] = 0;


            mspeed_time0 = 0;

            mspeed_load0 = 0;
            mspeed_load1 = 0;
            mspeed_pos0 = 0;
            mspeed_pos1 = 0;

            mbeingtest = true;
            mtestrun = true;

           

            if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 2)//简单试验
            {
                mrunlist = new List<CComLibrary.CmdSeg>();
                mrunlist.Clear();


              

            }

            if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 0) //一般试验
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
                    k, Convert.ToSingle(mrunlist[mcurseg].speedorigin()), 0, 0, 0, 0,0,ref mrunlist[mcurseg].tan );






            }
            else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 3) //高级试验
            {

            }
            else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 1)  //中级测试
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

                int tongbu = 0;


                for (int ii = mcurseg; ii < mrunlist.Count; ii++)
                {
                    if (mrunlist[ii].controlmode == mrunlist[ii].destcontrolmode)
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
                          mrunlist[ii].keeptime, mrunlist[ii].returnstep, mrunlist[ii].returncount, mrunlist[ii].action,0,ref mrunlist[ii].tan );

                        mcurseg = ii;

                        Debug.Print("abc" + mcurseg.ToString());
                        tongbu = tongbu + 1;

                        if (tongbu >= 2)
                        {
                            break;
                        }
                    }
                    else
                    {

                        if (ii == mcurseg)
                        {
                            segstep(mrunlist[ii].cmd, mrunlist[ii].destorigin(),
                           Convert.ToInt16(mrunlist[ii].controlmode),
                              Convert.ToInt16(mrunlist[ii].destcontrolmode),
                          k, Convert.ToSingle(mrunlist[ii].speedorigin()),
                          mrunlist[ii].keeptime, mrunlist[ii].returnstep, mrunlist[ii].returncount, mrunlist[ii].action,0,ref mrunlist[ii].tan );

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

           // Debug.Print("mrunlist cunt=" + mrunlist.Count.ToString());


        }

        public override void segstep(int cmd, double dest, short firstctl, short destctl, short destkeepstyle, float speed, double keeptime, int reurnstep, int returncount, int action,int destmode,ref short tan)
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

                    ClsStaticStation.a9500.COMPLEXMOVEST move = new ClsStaticStation.a9500.COMPLEXMOVEST();


                    move.dest = Convert.ToSingle(dest);
                    move.firstctl = Convert.ToInt16(ConvertCtrlMode(firstctl));
                    move.destctl = Convert.ToInt16(ConvertCtrlMode(destctl));

                    move.destkeepstyle = destkeepstyle;
                    move.speed = Convert.ToSingle(speed);
                    move.num = 0;
                    move.runmsg = 0;
                    move.holdtime = 0;

                    ClsStaticStation.a9500.ARM_DEC_SendComplexMove(0, 0, 0, 1, 0, ref move);
                    DelayS(0.1);
                    ClsStaticStation.a9500.ARM_DEC_Test_Start(0, 0);

                    DelayS(0.1);


                    b = false;
                    while (b == false)
                    {
                        Application.DoEvents();
                        if (m_runstate0 == 1)
                        {
                            b = true;
                        }

                    }

                    mrun = true;

                    Debug.Print("segcmd2 " + move.dest.ToString() + " " + move.speed.ToString());

                }
                else
                {


                    ClsStaticStation.a9500.COMPLEXMOVEST move = new ClsStaticStation.a9500.COMPLEXMOVEST();


                    move.dest = Convert.ToSingle(dest);
                    move.firstctl = Convert.ToInt16(ConvertCtrlMode(firstctl));
                    move.destctl = Convert.ToInt16(ConvertCtrlMode(destctl));

                    move.destkeepstyle = destkeepstyle;
                    move.speed = Convert.ToSingle(speed);
                    move.num = 0;
                    move.runmsg = 0;
                    move.holdtime = 0;

                    ClsStaticStation.a9500.ARM_DEC_SendComplexMove(0, DeviceNum, 0, 1, 0, ref move);
                    DelayS(0.1);
                    ClsStaticStation.a9500.ARM_DEC_Test_Start(DeviceNum, 0);

                    DelayS(0.1);

                    b = false;
                    while (b == false)
                    {
                        Application.DoEvents();
                        if (m_runstate1 == 1)
                        {
                            b = true;
                        }

                    }

                    mrun = true;

                }

            }








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
                if ((System.Environment.TickCount / 1000 - mrunstarttime) <= 20)
                {

                    return;
                }
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

                        int tongbu = 0;

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
                                    segstep(mrunlist[ii].cmd, mrunlist[ii].destorigin(),
                                       Convert.ToInt16(mrunlist[ii].controlmode),
                                         Convert.ToInt16(mrunlist[ii].destcontrolmode),
                                        k, Convert.ToSingle(mrunlist[ii].speedorigin()),
                                      mrunlist[ii].keeptime, mrunlist[ii].returnstep, mrunlist[ii].returncount, mrunlist[ii].action,0,ref mrunlist[ii].tan );
                                    mcurseg = ii;
                                    tongbu = tongbu + 1;
                                    if (tongbu >= 2)
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    if (ii == mcurseg)
                                    {
                                        segstep(mrunlist[ii].cmd, mrunlist[ii].destorigin(),
                                   Convert.ToInt16(mrunlist[ii].controlmode),
                                    Convert.ToInt16(mrunlist[ii].destcontrolmode),
                                   k, Convert.ToSingle(mrunlist[ii].speedorigin()),
                                   mrunlist[ii].keeptime, mrunlist[ii].returnstep, mrunlist[ii].returncount, mrunlist[ii].action,0,ref mrunlist[ii].tan );

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


        public override void Init(int handle)
        {


            short e;

            int rp = 0;

            CComLibrary.GlobeVal.InitUserCalcChannel();//初始化用户自定义通道

            e = System.Convert.ToInt16(a9500.ARM_DEC_Init(handle));

            GetDataIns = new a9500.OnGetDataDel(OnGetDataByMessage);

            a9500.ARM_DEC_OnCallBack(GetDataIns);

            OpenConnection();
           



            fConnected = true;
            //a9500.ARM_DEC_SetCtlerStyle((short)DeviceNum, (short)0); //蠕变方式 2017.05.02



        }


        public override void btnkey(Button b)
        {
            if (Convert.ToBoolean(b.Tag) == false)
            {
                b.Tag = true;
                btnzero(b);

            }
            else
            {
                b.Tag = false;
                restorezero(b);
            }

        }

        public override void btnzero(Button b)
        {
            if (b.Text == "位移")
            {

                a9500.ARM_DEC_ChannelZero(DeviceNum, a9500.SENSOR_ARM_S, 0);
            }

            if (b.Text == "力")
            {
                a9500.ARM_DEC_ChannelZero(DeviceNum, a9500.SENSOR_ARM_F, 0);
            }


            if (b.Text == "围压位移")
            {

                a9500.ARM_DEC_ChannelZero((short)0, (short)a9500.SENSOR_ARM_S, (short)0);
            }

            if (b.Text == "围压负荷")
            {

                a9500.ARM_DEC_ChannelZero(0, a9500.SENSOR_ARM_F, 0);
            }





        }

        public override void restorezero(Button b)
        {
            if (b.Text == "位移")
            {

                a9500.ARM_DEC_ChannelZero(DeviceNum, a9500.SENSOR_ARM_S, 1);
            }

            if (b.Text == "力")
            {
                a9500.ARM_DEC_ChannelZero(DeviceNum, a9500.SENSOR_ARM_F, 1);
            }


            if (b.Text == "围压位移")
            {

                a9500.ARM_DEC_ChannelZero(0, a9500.SENSOR_ARM_S, 1);
            }

            if (b.Text == "围压负荷")
            {

                a9500.ARM_DEC_ChannelZero(0, a9500.SENSOR_ARM_F, 1);
            }

        }

        void OnGetDataByMessage(int num, ref a9500.DataInfo Msg)
        {

            double mload = 0;



            GGMsg = Msg;



            int m = m_Global.madlist.Count;



            for (int i = 0; i < m; i++)


            {
               // m_MDataIno = new a9500.MDataIno();

                m_MDataIno.sensor5 = m_Global.madlist[i].x;
                m_MDataIno.sensor6 = m_Global.madlist[i].y;
                m_MDataIno.sensor7 = m_Global.madlist[i].z;
                m_MDataIno.time2 = m_Global.madlist[i].t;

                m_MDataIno.Id = DeviceNum;
                m_MDataIno.mydatainfo = GGMsg;

                //  m_MDataIno.time1 = GGMsg.time;
                m_MDataIno.time1 = m_Global.madlist[i].t;
               


               

                mdatalist.Add(m_MDataIno);

            }
            if (m >= 2)
            {
                mdatalist.RemoveRange(0, m - 2);

               
            }








            //   m_MDataIno.Id = num;
            //  m_MDataIno.mydatainfo = Msg;


            if (num == DeviceNum)
            {
                unsafe
                {
                    fixed (float* p = GGMsg.sensordata)
                    {
                        load = *(p + a9500.SENSOR_ARM_F);
                        load = Math.Abs(load);
                    }
                }
            }
            if (mbeingtest == true)
            {
                if (duanliebaohu == false)
                {
                    if (CComLibrary.GlobeVal.filesave == null)
                    {

                    }
                    else
                    {
                        //断裂检测判断
                        /*
                        if (CComLibrary.GlobeVal.filesave.crackcheck == true)
                        {

                            if (load > maxload)
                            {
                                maxload = load;
                            }

                            if (maxload > 1)
                            {
                                if (load < maxload * CComLibrary.GlobeVal.filesave.crackvalue / 100.0)
                                {

                                    CrossUp(0, 0.1);
                                    duanliebaohu = true;

                                }
                            }
                        }
                        */
                    }
                }
            }


            if (oldsystemState != Msg.systemState)
            {
                oldsystemState = Msg.systemState;

                switch (Msg.systemState)
                {
                    case -1://手控盒关闭系统
                        break;
                    case 0://离合器相关
                        m_limit = false;//未处于限位保护状态
                        m_EmergencyStop = false;//未处于急停状态

                        break;
                    case 25:
                    case 26:     //横梁硬限位保护
                        m_limit = true;
                        break;

                    case 27:
                        m_EmergencyStop = true;//急停按下
                        break;


                }
            }

            if (num == 0)
            {
                switch (Msg.runmsg)
                {
                    //直线移动 0A  横梁停止 0B  手轮操作 0C  ComplexLineSet 0D ComplexMoveSet 0E  单段结束 20
                    case 0xa:
                        m_runstate0 = 1;
                        break;
                    case 0xe:

                        m_runstate0 = 1;
                        break;

                    case 0xb:
                        m_runstate0 = 0;
                        break;


                    case 0x20:
                        m_runstate0 = 0;
                        break;


                }
                rrr = m_runstate0;
            }

            if (num == DeviceNum)
            {
                switch (Msg.runmsg)
                {
                    //直线移动 0A  横梁停止 0B  手轮操作 0C  ComplexLineSet 0D ComplexMoveSet 0E  单段结束 20
                    case 0xa:
                        m_runstate1 = 1;
                        break;

                    case 0xe:

                        m_runstate1 = 1;
                        break;

                    case 0xb:
                        m_runstate1 = 0;
                        break;

                    case 0x20:
                        m_runstate1 = 0;
                        break;


                }
                www = m_runstate1;
            }

            

        }






        public override int CloseConnection()
        {

            return 0;
        }



        public override int OpenConnection()
        {




            short reval;
            reval = System.Convert.ToInt16(a9500.ARM_DEC_Connect((short)DeviceNum));

            //reval = System.Convert.ToInt16(a9500.ARM_DEC_Connect((short)0));

            a9500.ARM_DEC_SetCtlerStyle(DeviceNum, (short)1);  //电拉方式 2017.05.02

            // a9500.ARM_DEC_SetCtlerStyle(0, (short)1);  //电拉方式 2017.05.02

            a9500.ARM_DEC_ReadMaxLoad((short)DeviceNum, a9500.SENSOR_ARM_F);

            double t = System.Environment.TickCount;

            while ((System.Environment.TickCount - t) < 1000)
            {

            }

            a9500.ARM_DEC_GetMaxLoad(ref mLoadCapacity);
            mLoadCapacity *= 1000;



            return 0;


        }
    }
    public sealed class a9500
    {


        public const int mCTRL_POS = 2;//2
        public const int mCTRL_LOAD = 0; // 0
        public const int mCTRL_EXTENSION = 1; // 1
        public const int mCTRL_STRESS = 3;
        public const int mCTRL_STRAIN = 4;

        //消息定义
        public const int WM_READMSG = 4024;
        public const int WM_CONNECT = 2074;
        public const int WM_READFROMTMC = 2084;
        public const int WM_READMAXVALUETMC = 2094;
        public const int WM_READSENSOR = 2104;

        //传感器通道
        public const short SENSOR_ARM_S = 2; //  X-head position
        public const short SENSOR_ARM_F = 0; //  Load
        public const short SENSOR_ARM_E = 1; //  Extension
        public const short SENSOR_ARM_D = 3; //  Extension1
        public const short SENSOR_ARM_4 = 4; //  Sensor 4
        public const short SENSOR_ARM_5 = 5; //  Sensor 5
        public const short SENSOR_ARM_6 = 6; //  Sensor 6
        public const short SENSOR_ARM_7 = 7; //  Sensor 7
        public const short SENSOR_ARM_8 = 8; //  Sensor 8
        public const short SENSOR_ARM_9 = 9; //  Sensor 9
        public const short SENSOR_ARM_10 = 10; //  Sensor 10

        public delegate void OnGetDataDel(int num, [MarshalAs(UnmanagedType.Struct)]ref DataInfo msg);
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]

        public struct MDataIno
        {
            public int Id;
            public DataInfo mydatainfo;
            public double sensor5;
            public double sensor6;
            public double sensor7;
            public double time1;
            public double time2;
        }

        public struct DataInfo
        {
            public short runmsg;
            public short sysState;
            public short isreadbuf;
            public short saveFlag;
            public short readflag;
            public short systemState;

            public unsafe fixed short free3[8];
            public unsafe fixed float sensordata[10];
            public unsafe fixed float sensorLINTdata[10];
            public unsafe fixed float tmperature[3];

            public float dataready;
            public float bufpecent;
            public float keepdata;
            public unsafe fixed float free[7];
            public int count;
            public int incount;
            public int CurrentCycle;
            public int CurrentSegment;
            public unsafe fixed int free1[4];
            public double time;
            public double RunTiming;
            public double test1;
            public double test2;
            public double info;
            public unsafe fixed double free2[4];


        }

        public struct WSensorPara
        {
            public short channelID; //传感器号
            public short hardwareID; //选择硬件接口
            public short chPolarity; //传感器方向
            public short ctlPolarity; //控制方向
            public short sensorvalid; //是否有效
            public short calisign; //标定方向
            public short FilterPoints1; //控制用滤波
            public short FilterPoints2; //采样、显示用滤波
            public short LinearPoints1; //线性修正正方向
            public short LinearPoints2; //线性修正负方向
            public short unit; //单位
            public short outchannel; //作为控制对象时输出通道
            public short crossdirect; //动横梁正向
            public short paranum; //第几套参数
            public short test1;
            public short test2;
            public unsafe fixed short fr[1]; //填充位
            public float MaxValue; //最大值
            public float MinValue; //最小值
            public float uplimit; //上限保护
            public float lowlimit; //下限保护
            public float CaliValue;
            public float AmpCoe; //放大器标定系数
            public float k; //动态标定系数
            public float CGValue; //切地值
            public float NowCaliValue; //当前标定值
            public float P; //比例系数
            public float i; //积分系数
            public float D; //微分系数
            public float SpeedP; //速度比例系数
            public float SpeedI; //速度积分系数
            public float SpeedD; //速度微分系数
            public float ctrlvaluedev; //控制值偏差
            public unsafe fixed float txtStandard[14]; //标准值
            public float sensordata;
            public unsafe fixed float ad[14]; //实际值
            public float sensorLINT;
            public float absolutezero; //绝对零点

            public unsafe fixed char sensorname[16]; //传感器名字


        }



        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct TESTPARA
        {
            public int OutLoopCount; ///*大循环次数*/
			public int PreLoadTime; ///*预负荷时间*/
			public int KeepTempTime; ///*保温时间*/

            public float preload; ///*预负荷*/
			public float PreLoadfirstspeed; ///*预负荷第一段速度*/
			public float PreLoadsecondspeed; ///*预负荷第二段速度*/
			public float PreLoadfirstdest; ///*预负荷第一段目标*/

            public float Temperature; //                   /*温度*/
            public float TemperFluct; //            /*温度波动度*/
            public float TemperReturn; //           /*试验结束返回温度*/
            public float uLowCtl; //         '   /*低于该值停止试验*/
            public float uHighCtl; //                 /*高于该值停止试验*/
            public float uMaxDif; //                          /*偏差高于该值于停止试验*/
            public float uMaxLowSpeed; //                     /*最大下降速度 用于停止试验*/
            public float uExtOrLoad; //                       /*选择变形判断异常还是负荷判断异常*/
            public float AddToLoad; //                        /*负荷目标增加*/
            public float CoefLoad; //                       /*负荷系数*/
            public float IntervalCaliTime; //  /*动态标定时间*/
            public float ExtenAlarm; //                      /*变形报警*/

            public short CtlerMoad; //                        /*控制器类型*//*蠕变 专机 围压 轴压*/
            public short WaveMode; //                         /*波形类型*/
            public short Teststyle; //                        /*试验状态*/
            public short IsPreLoad; //                        /*是否预负荷*/
            public short IsAddTemp; //                        /*是否加温*/
            public short IsDownTemp; //                       /*是否降温*/
            public short IsAutoUnLoad; //                     /*是否自动卸载至预负荷*/
            public short IsExtenAlarm; //                     /*是否变形报警*/
            public short TestSegNum; //                       /*试验段数*/
            public short PreLoadfirstctl; //                  /*预负荷第一段控制方式*/
            public short PreLoadsecondctl; //                 /*预负荷第二段控制方式*/
            public short PreLoaddestctl; //                   /*预负荷目标通道*/

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
            public cmdtestpara[] cmdPara;

            public cmdSaveCondition saveCondition; //                /*存储条件*/

            public void Initialize()
            {
                cmdPara = new cmdtestpara[11];
            }

        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct cmdtestpara
        {

            public byte cmdNum; //               //段号
            public byte waveMoad; //;             //何种波形
            public byte nextCmd; //;              //下一个指向那一组控制命令
            public byte ctlmoad; //;              //控制方式
            public byte ctlFlag; //;              //控制标识
            public byte subnum; //;               //子站号
            public short para1; // ;                //控制参数1
            public float para2; //             //控制参数2
            public float para3; //                 //控制参数3
            public float para4; //                  //控制参数4
            public float para5; //              //控制参数5
            public float para6; //                  //控制参数6
            public float para7; //                  //控制参数7
            public float para8; //                  //控制参数8
            public float para9; //                  //控制参数9
            public float para10; //                 //控制参数10
            public int para11; //               //控制参数11
            public int cycle; //;                //循环次数

        }

        public struct cmdSaveCondition
        {

            public short selectTime; //选择时间
            public short selectLoad; //选择负荷
            public short selectPos; //选择位移
            public short selectExt; //  选择平均变形

            public float time; //  相隔时间
            public float load; // 相隔负荷
            public float pos; //   相隔位移
            public float ext; //   相隔平均变形
        }


        public struct TestCondition
        {


            public short IsPreLoad;
            public short ctlMode;
            public float testtype;
            public float unload;
            public float wdbd;
            public float preloadvalue;
            public float testsegment;
            public float testtemperature;
            public string filename;

            public unsafe fixed float wavesz[12];
            //ctrlmode(0 To 11) As Integer

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
            public CSinWave[] sinewave;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]

            public CTriWave[] triwave;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]

            public CRect[] rectwave;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]

            public CTraWave[] trawave;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]

            public CHold[] hold;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]

            public CIncline[] incline;

            public void Initialize()
            {

                sinewave = new a9500.CSinWave[11];
                triwave = new a9500.CTriWave[11];
                rectwave = new a9500.CRect[11];
                trawave = new a9500.CTraWave[11];
                hold = new a9500.CHold[11];
                incline = new a9500.CIncline[11];
            }


        }
        //***温度
        public struct CTempreter
        {
            public int type;
            public int port;
            public int paranum;
            public float value;
        }

        //***正弦波
        public struct CSinWave
        {
            public byte num;
            public byte runseg;
            public short ctlMode;
            public float fspeed;
            public float fdestination;
            public float mdestination;
            public float lspeed;
            public float ldestination;
            public float frq;
            public float mphase;
            public int cycles;
        }


        //***三角波
        public struct CTriWave
        {
            public byte num;
            public byte runseg;
            public short ctlMode;
            public float fspeed;
            public float fdestination;
            public float mdestination;
            public float lspeed;
            public float ldestination;
            public float frq;
            public float mphase;
            public int cycles;
        }


        //***循环波
        public struct CTraWave
        {
            public byte num;
            public byte runseg;
            public short ctlMode;
            public float fspeed;
            public float fdestination;
            public float mdestination;
            public float lspeed;
            public float ldestination;
            public float sleeptime1;
            public float sleeptime2;
            public float speed1;
            public float speed2;
            public int cycles;
        }


        public struct CSensor
        {
            public short senserID;
            public short OutputID;
            public short ctlStyle;
            public short netNo;
            public short isTemCtl;
            public short isHandCtl;
            public float Modenum;

            public unsafe fixed short fre[2];

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]

            public WSensorPara[] sensor;

            public void Initialize()
            {
                sensor = new WSensorPara[12];
            }


        }

        public struct CRect
        {
            public byte num;
            public byte runseg;
            public short ctlMode;
            public float fspeed;
            public float fdestination;
            public float mdestination;
            public float lspeed;
            public float ldestination;
            public float frq;
            public float mphase;
            public int cycles;
        }
        public struct CHold //***保持
        {
            public byte num;
            public byte runseg;
            public short ctlMode;
            public float holdingtime;
            public float holdingaim;
        }



        public struct CIncline //***斜波
        {
            public byte num;
            public byte runseg;
            public short ctlMode;
            public float loadSpeed;
            public float loadaim;
        }

        public struct SIMPLELINE
        {
            public byte num;
            public byte ctl;
            public float speed;
            public float dest;
        }

        public struct COMPLEXMOVEST
        {
            public byte num;
            public byte runmsg; //直线移动 0A  横梁停止 0B  手轮操作 0C  ComplexLineSet 0D ComplexMoveSet 0E  单段结束 20
            public short firstctl;
            public short destctl;
            public short destkeepstyle; //0destctl控制方式，1时初始控制
            public float speed;
            public float dest;
            public int holdtime;
        }

        public struct COMPLEXLINEST
        {
            public byte num;
            public byte runmsg;
            public short firstctl;
            public short secondctl;
            public short destctl;
            public float firstspeed;
            public float secondspeed;
            public float firstdest;
            public float seconddest;
            public int holdtime;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct CParaAdministrator
        {
            public short machineNum;
            public short paranum;

            public unsafe fixed short disppos[8];

            public unsafe fixed short free[8];

            public unsafe fixed float fr[20];


        }

        //函 数 名 称： DEC_Init()

        //函 数 作 用：初始化动态链接库

        //输 入 参 数： handle：主窗体句柄

        //输 出 参 数：无
        [DllImport("WNetCtrl.dll", ExactSpelling =true , CharSet = CharSet.Ansi, SetLastError = true )]
        public static extern short ARM_DEC_Init(int handle);

        //函 数 名 称： DEC_Connect()

        //函 数 作 用：与控制器联机

        //输 入 参 数： num：主机号 i->0,1,...

        //输 出 参 数：无
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern short ARM_DEC_Connect(short num);

        //函 数 名 称： DEC_GetData()

        //函 数 作 用：从控制器中读取数据

        //输 入 参 数： num：主机号 i->0,1,...，data：读出来的数据结构

        //输 出 参 数：无
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_GetData(short num, ref DataInfo data);

        //函 数 名 称： DEC_Close()

        //函 数 作 用：关闭动态链接库

        //输 入 参 数： address 函数地址，

        //输 出 参 数：无
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_Close(short a);

        //函 数 名 称： DEC_WriteData()

        //函 数 作 用：向控制器写数据，留作其他用

        //输 入 参 数： port：主机号 i->0,1,...，

        //输 出 参 数：无

        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_WriteData(short port, short data);

        //函 数 名 称： DEC_OnCallBack()

        //函 数 作 用：用于回调函数

        //输 入 参 数： address 函数地址，

        //输 出 参 数：无

        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_OnCallBack(OnGetDataDel address);

        //函 数 名 称： DEC_System_ON()

        //函 数 作 用：打开控制器

        //输 入 参 数： port：主机号 i->0,1,...，

        //输 出 参 数：无

        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_System_ON(short i);

        //函 数 名 称： DEC_System_OFF()

        //函 数 作 用：关闭控制器

        //输 入 参 数： port：主机号 i->0,1,...，

        //输 出 参 数：无

        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_System_OFF(short i);
        //函 数 名 称： DEC_Destroy()

        //函 数 作 用：销毁动态链接库，释放资源

        //输 入 参 数： 无

        //输 出 参 数：无
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_Destroy();

        //函 数 名 称： DEC_Test_Stop()

        //函 数 作 用：向控制器发送试验开始参数

        //输 入 参 数： port：主机号 i->0,1,...，   data：0:正常开始 1：留用

        //输 出 参 数：无
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_Test_Start(short port, short data);

        //函 数 名 称： DEC_Test_Stop()

        //函 数 作 用：向控制器发送试验停止参数

        //输 入 参 数： port：主机号 i->0,1,...，   data：0:正常结束 1：留用

        //输 出 参 数：无
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_Test_Stop(short port, short data);

        //函 数 名 称： DEC_SendPIDPara()

        //函 数 作 用：向控制器发送传感器参数

        //输 入 参 数： i：传感器号 i->0,1,...9,工10个传感器   sensor：为传感器参数结构

        //输 出 参 数：无
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_SendSensorPara(short i, ref WSensorPara sensor);

        //函 数 名 称： DEC_SendPIDPara()

        //函 数 作 用：向控制器发送PID参数

        //输 入 参 数： i：传感器号 i->0,1,...9,工10个传感器   sensor：为传感器参数结构

        //输 出 参 数：无
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_SendPIDPara(short i, ref WSensorPara sensor);

        //函 数 名 称： DEC_SendCALIPara()

        //函 数 作 用：向控制器发送标定传感器参数

        //输 入 参 数： i：传感器号 i->0,1,...9,工10个传感器   sensor：为传感器参数结构

        //输 出 参 数：无
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_SendCALIPara(short i, ref WSensorPara sensor);


        //函 数 名 称： DEC_SendTestPara()

        //函 数 作 用：向控制器发送试验参数

        //输 入 参 数：i 设为0即可， n：主机号 n->0,1,..., P：为试验参数结构

        //输 出 参 数：无
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_SendTestPara(short i, short n, ref TESTPARA P);

        //函 数 名 称： DEC_SendTestPara()

        //函 数 作 用：向控制器发送试验参数 (一般试验参数，可以不用)

        //输 入 参 数：num：主机号 n->0,1,..., para：为试验参数结构

        //输 出 参 数：无
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_Condition(short num, ref TestCondition para);

        //函 数 名 称： DEC_AbsolutZero()

        //函 数 作 用：向控制器发送绝对清零

        //输 入 参 数：num：主机号 n->0,1,..., channel：传感器通道 channel->0,1..9

        //输 出 参 数：无
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_AbsolutZero(short num, short channel);

        //函 数 名 称： DEC_ChannelZero()

        //函 数 作 用：向控制器发送清零

        //输 入 参 数：num：主机号 n->0,1,..., channel：传感器通道 channel->0,1..9,nMode：=0时清零，=1时复原

        //输 出 参 数：无
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_ChannelZero(short i, short nChannel, short nMode);

        //函 数 名 称： DEC_MoveCtl()

        //函 数 作 用：向着目标移动

        //输 入 参 数：num：设为0即可， i：主机号 n->0,1,..., line：数据结构，

        ///'<注意>此函数有效时手轮起作用，即可通过手轮调节上升，下降的速度，同时，上升、下降指示灯会亮

        //输 出 参 数：无
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_MoveCtl(short num, short i, ref SIMPLELINE line);

        //函 数 名 称： DEC_MoveStop()

        //函 数 作 用：向控制器发送停止横梁移动命令

        //输 入 参 数：i：num：设为0即可， i：主机号 n->0,1,..., lctl：以何种方式停止移动

        //输 出 参 数：无
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_MoveStop(short num, short i, short ctl);

        //函 数 名 称： DEC_SendSineWave()

        //函 数 作 用：向控制器发送正弦波

        //输 入 参 数：i：设为0即可，subnum：主机号，subnum->0,1,...,num：当前段数，cycle：单段执行周期，nextp：下一段指针指向，s：正弦波数据结构

        //输 出 参 数：无

        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_SendSineWave(byte i, short subnum, byte num, int cycle, byte nextp, ref CSinWave s);

        //函 数 名 称： DEC_SendTriWave()

        //函 数 作 用：向控制器发送三角波

        //输 入 参 数：i：设为0即可，subnum：主机号，subnum->0,1,...,num：当前段数，cycle：单段执行周期，nextp：下一段指针指向，s：三角波数据结构

        //输 出 参 数：无

        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_SendTriWave(byte i, short subnum, byte num, int cycle, byte nextp, ref CTriWave s);

        //函 数 名 称： DEC_SendTraWave()

        //函 数 作 用：向控制器发送梯形波

        //输 入 参 数：i：设为0即可，subnum：主机号，subnum->0,1,...,num：当前段数，cycle：单段执行周期，nextp：下一段指针指向，s：梯形波数据结构

        //输 出 参 数：无

        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_SendTraWave(byte i, short subnum, byte num, int cycle, byte nextp, ref CTraWave s);

        //函 数 名 称： DEC_HoldHead()

        //函 数 作 用：向控制器发送保持

        //输 入 参 数：i：设为0即可，subnum：主机号，subnum->0,1,...,num：当前段数，cycle：单段执行周期，nextp：下一段指针指向，s：保持数据结构

        //输 出 参 数：无
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_HoldHead(byte i, short subnum, byte num, int cycle, byte nextp, ref CHold s);

        //函 数 名 称： DEC_SendRectWave()

        //函 数 作 用：向控制器发送方波

        //输 入 参 数：i：设为0即可，subnum：主机号，subnum->0,1,...,num：当前段数，cycle：单段执行周期，nextp：下一段指针指向，s：方波数据结构

        //输 出 参 数：无
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_SendRectWave(byte i, short subnum, byte num, int cycle, byte nextp, ref CRect s);

        //函 数 名 称： DEC_SendLineWave()

        //函 数 作 用：向控制器发送直线

        //输 入 参 数：i：设为0即可，subnum：主机号，subnum->0,1,...,num：当前段数，cycle：单段执行周期，nextp：下一段指针指向，s：直线数据结构

        //输 出 参 数：无
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_SendLineWave(byte i, short subnum, byte num, int cycle, byte nextp, ref CIncline s);

        //函 数 名 称： DEC_SendComplexMove()

        //函 数 作 用：向控制器发送复杂直线

        //输 入 参 数：i：设为0即可，subnum：主机号，subnum->0,1,...,num：当前段数，cycle：单段执行周期，nextp：下一段指针指向，s：复杂直线数据结构

        //输 出 参 数：无

        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_SendComplexMove(byte i, short subnum, byte num, int cycle, byte nextp, ref COMPLEXMOVEST s);


        //函 数 名 称： DEC_SumSegment()

        //函 数 作 用：向控制器发送总命令段数

        //输 入 参 数：i：设为0即可，subnum：主机号，subnum->0,1,...,num：需要运行总的段数

        //输 出 参 数：无
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_SumSegment(short i, short subnum, short sum);

        //函 数 名 称： DEC_StartCmd()

        //函 数 作 用： 发送波形命令开始

        //输 入 参 数：i：设为0即可，subnum：主机号，subnum->0,1,...

        //输 出 参 数：无
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_StartCmd(short i, short subnum);

        //函 数 名 称： DEC_StartCmd()

        //函 数 作 用： 发送波形命令结束

        //输 入 参 数：i：设为0即可，subnum：主机号，subnum->0,1,...

        //输 出 参 数：无

        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_EndCmd(short i, short subnum);


        //函 数 名 称： DEC_SendTemperature()

        //函 数 作 用： 向温度控制器发送温度

        //输 入 参 数：i：主机号，subnum->0,1,...,addr：温控器地址，temp：为温度目标值

        //输 出 参 数：无
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_SendTemperature(byte i, ref CTempreter s);

        //函 数 名 称： DEC_SendSingleComplexLineStart()

        //函 数 作 用： 单段复杂曲线开始

        //输 入 参 数：i：设为0即可，subnum：主机号，subnum->0,1,...

        //输 出 参 数：无
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_SendSingleComplexLineStart(byte i, short subnum);

        //函 数 名 称： DEC_SendSingleComplexLine()

        //函 数 作 用： 单段复杂曲线命令

        //输 入 参 数：i：设为0即可，subnum：主机号，subnum->0,1,...，cpline：复杂曲线数据结构

        //输 出 参 数：无
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_SendSingleComplexLine(byte i, short subnum, ref COMPLEXLINEST cpline);

        //函 数 名 称： DEC_SendMove()

        //函 数 作 用： 单段简单直线命令

        //输 入 参 数：i：设为0即可，subnum：主机号，subnum->0,1,...，cpline：单段简单直线数据结构

        //输 出 参 数：无
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_SendMove(short i, short subnum, ref SIMPLELINE s);


        //函 数 名 称： DEC_SendOUTSignal()

        //函 数 作 用： 向外输出开关量

        //输 入 参 数：i：设为0即可，subnum：主机号，subnum->0,1,...，cmd：按位设置开关量

        //输 出 参 数：无
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_SendOUTSignal(byte i, short subnum, byte cmd);


        //函 数 名 称： DEC_SendMove()

        //函 数 作 用： 单段简单直线命令

        //输 入 参 数：i：设为0即可，subnum：主机号，subnum->0,1,...，channel：传感器通道 channel->0,1,...9

        //输 出 参 数：无
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_SendAutoCalibtate(short i, short subnum, byte channel);

        //函 数 名 称： ARM_DEC_SendAutoCalibtate()

        //函 数 作 用： 单段简单直线命令

        //输 入 参 数：i：设为0即可，subnum：主机号，subnum->0,1,...，channel：传感器通道 channel->0,1,...9

        //输 出 参 数：无
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_SendChangeSwitch(short i, byte subnum, byte channel);

        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_SendDAOUTDATA(short i, short subnum, short data);

        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_BeginOUTDA(short i, short subnum);

        //函 数 名 称： ARM_DEC_SendparaAdmin()

        //函 数 作 用：向控制器发送试验参数

        //输 入 参 数： i：主机号 n->0,1,..., P：为主机参数结构

        //输 出 参 数：无
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_SendparaAdmin(short i, ref CParaAdministrator P);
        //函 数 名 称： ARM_DEC_WriteEEProm()

        //函 数 作 用：写EEPROM

        //输 入 参 数： i：主机号 n：传感器号

        //输 出 参 数：无
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_WriteEEProm(short i, short n);
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_ReadEEProm(short i, short n);
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_GetSensorPara(ref WSensorPara data);
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_SetCtlerStyle(short i, short n);

        //取消
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_ChangeSpeed(short deviceNum, byte j, short k);

        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_ReadMaxLoad(short deviceNum, short SensorChannelNum);

        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_GetMaxLoad(ref float maxload);

        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_SetCaliData(short subNum, short i, short channel);
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_SetCaliFlag(short subNum, short i, short channel, short flag, float k);
        [DllImport("WNetCtrl.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ARM_DEC_GetCaliData(short subNum, short i, short channel);




    }
}

