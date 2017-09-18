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

namespace ClsStaticStation
{
    public sealed class aEziMOTIONPlusR
    {

        [DllImport("EziMOTIONPlusR.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int FAS_Connect(byte nPortNo, int dwBaud);

        [DllImport("EziMOTIONPlusR.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int FAS_IsSlaveExist(byte nPortNo, byte iSlaveNo);

        [DllImport("EziMOTIONPlusR.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void FAS_Close(byte nPortNo);

        [DllImport("EziMOTIONPlusR.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int FAS_ServoEnable(byte nPortNo, byte iSlaveNo, int bOnOff);

        [DllImport("EziMOTIONPlusR.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int FAS_MoveSingleAxisIncPos(byte nPortNo, byte iSlaveNo, int lIncPos, int lVelocity);

        [DllImport("EziMOTIONPlusR.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int FAS_GetCommandPos(byte nPortNo, byte iSlaveNo, ref int lCmdPos);

        [DllImport("EziMOTIONPlusR.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int FAS_GetActualPos(byte nPortNo, byte iSlaveNo, ref int lActPos);

        [DllImport("EziMOTIONPlusR.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int FAS_MoveSingleAxisAbsPos(byte nPortNo, byte iSlaveNo, int lAbsPos, int lVelocity);

        [DllImport("EziMOTIONPlusR.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int FAS_MoveStop(byte nPortNo, byte iSlaveNo);


        [DllImport("EziMOTIONPlusR.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int FAS_EmergencyStop(byte nPortNo, byte iSlaveNo);


        [DllImport("EziMOTIONPlusR.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int FAS_ClearPosition(byte nPortNo, byte iSlaveNo);




    }



    public class C电机 : ClsBaseControl
    {
        private bool mbtnloadzero = false;
        private bool mbtnloadrestore = false;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public a9500.DataInfo GGMsg;
        private a9500.OnGetDataDel GetDataIns;
        public short DeviceNum = 1;
        private float mLoadCapacity; //力满量程值
        private RawDataStruct b;
        private byte  mcom_control = 7;
        private double mstarttime;

        private double mangle_coefficient = 0.0045; //扭角系数
        private List<a9500.MDataIno> mdatalist;

        private System.Windows.Forms.Timer mtimer;
        private System.IO.Ports.SerialPort mSerialPort;

        private double mTorque = 0;
        private double mAngle = 0;

        private bool mdemotesting = false;
        private int mdemotestingp = 0;

        private double pos;
        private double load;
        private double ext;
        private double poscmd;
        private double loadcmd;
        private double extcmd;
        private double time;
        private double moritime;
        private double count;
        private double pos1;//围压位移
        private double load1;//围压负荷

        private double mspeed_load0;
        private double mspeed_load1;
        private double mspeed_pos0;
        private double mspeed_pos1;
        private double mspeed_time0;
        private double mspeed_time1;

        public double maxload;

        private Boolean mrun = false;//函数执行后置位



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









        private int m_returnstep;//返回步骤
        private int m_returncount;//返回次数



        public int rrr = 0;
        public int www = 0;
        public override void setrunstate(int m)
        {
            m_runstate = m;
        }

        private List<demodata> mdemodata = new List<demodata>();


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
            bool  m=false ;
            if (ch == 1)
            {
                if (Math.Abs(load) >= 1.2)
                {
                    m = true  ;
                }
            }
            if (ch == 0)
            {
                if (Math.Abs(pos) >= 60)
                {
                    m = true ;
                }
            } 
            return m;
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

        public C电机()
        {
            GGMsg = new a9500.DataInfo();
            mdatalist = new List<a9500.MDataIno>();
            mtimer = new System.Windows.Forms.Timer();
            mSerialPort = new System.IO.Ports.SerialPort();
            
            mSerialPort.PortName = "COM8";
            mSerialPort.StopBits = System.IO.Ports.StopBits.One;
            mSerialPort.BaudRate = 9600;
            mSerialPort.DataBits = 8;
            mSerialPort.Parity = System.IO.Ports.Parity.None;
            mtimer.Tick += new EventHandler(mtimer_Tick);
            mtimer.Interval = 50;
            mtimer.Enabled = true;
         
            mtimer.Start();


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

            aEziMOTIONPlusR.FAS_ServoEnable(mcom_control, 0, 1);
        }

        public override void DriveOff()
        {
            aEziMOTIONPlusR.FAS_ServoEnable(mcom_control, 0, 0);


        }

        public override void CrossUp(int ctrlmode, double speed)
        {
            aEziMOTIONPlusR.FAS_MoveSingleAxisAbsPos(mcom_control, 0,  Convert.ToInt32(90 / mangle_coefficient), Convert.ToInt32( speed/60 / mangle_coefficient));

        }

        public override void CrossDown(int ctrlmode, double speed)
        {
            aEziMOTIONPlusR.FAS_MoveSingleAxisAbsPos(mcom_control , 0, Convert.ToInt32(-90 / mangle_coefficient), Convert.ToInt32(speed /60/ mangle_coefficient));

        }

        public override void CrossStop(int ctrlmode)
        {
            aEziMOTIONPlusR.FAS_MoveStop(mcom_control, 0);
        }

        public override void DestStart(int ctrlmode, double dest, double speed)
        {
            aEziMOTIONPlusR.FAS_MoveSingleAxisAbsPos(mcom_control, 0, Convert.ToInt32( dest / mangle_coefficient), Convert.ToInt32( speed /60/ mangle_coefficient));


        }

        public override void DestStop(int ctrlmode)
        {
            aEziMOTIONPlusR.FAS_MoveStop(mcom_control, 0);
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

        private void gatherdata()
        {
            int j;
            int i;
            int jj;
            int ii;

            int mActualPos = 0;



            ulong  mtemp = 0;

            byte[] msendbuf = new byte[3];
            byte[] recbuf = new byte[8];


            b = new RawDataStruct();
            b.data = new double[24];


            aEziMOTIONPlusR.FAS_GetActualPos(mcom_control, 0, ref mActualPos);
            
            if (mSerialPort.BytesToRead >= 7)
            {

                if ((recbuf[0] == 0) && (recbuf[1] == 0))

                {

                    mSerialPort.Read(recbuf, 0, 7);

                    mtemp = Convert.ToUInt32 (256.0 * 256 * 256 * recbuf[3 + 2] + recbuf[0 + 2] + 256.0 * recbuf[1 + 2] + 256.0 * 256 * recbuf[2 + 2]);


                    mSerialPort.DiscardInBuffer();
                    load = BitConverter.ToSingle(BitConverter.GetBytes(mtemp), 0);

                    time = System.Environment.TickCount / 1000.0;

                    if (Math.Abs(load) >= 1.2)
                    {
                        CrossStop(0); 
                    }

                    if (Math.Abs(pos) >= 60)
                    {
                        CrossStop(0); 
                    }
                }

            }


            if (this.mbtnloadzero == true)
            {
                msendbuf[0] = 0;
                msendbuf[1] = 6;
                msendbuf[2] = 0;
                mSerialPort.Write(msendbuf, 0, 3);
                mbtnloadzero = false;
            }
            if (this.mbtnloadrestore == true)
            {
                msendbuf[0] = 0;
                msendbuf[1] = 7;
                msendbuf[2] = 0;
                mSerialPort.Write(msendbuf, 0, 3);
                mbtnloadrestore  = false;
            }

            if ((this.mbtnloadrestore==false ) &&(this.mbtnloadzero ==false ))
            {
                pos = mActualPos * this.mangle_coefficient;
                msendbuf[0] = 0;
                msendbuf[1] = 0;
                msendbuf[2] = 0;
                mSerialPort.Write(msendbuf, 0, 3);
            }

            //自定义通道赋值
            ClsStaticStation.m_Global.mload = load;

            ClsStaticStation.m_Global.mpos = pos;

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



            if (mdemo == true)
            {
                demo();
            }
            else
            {

                gatherdata();

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
            }
            else
            {
                CrossStop(0); 

            }
            mtestrun = false;

            CComLibrary.GlobeVal.InitUserCalcChannel();//初始化用户自定义通道


        }



        public override void starttest()
        {
            short k = 0;


            maxload = 0;
            mstarttime = moritime;
            duanliebaohu = false;

          
            mspeed_time0 = 0;
            mspeed_time1 = 0;
            mspeed_load0 = 0;
            mspeed_load1 = 0;
            mspeed_pos0 = 0;
            mspeed_pos1 = 0;

            mtestrun = true;


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
                    k, Convert.ToSingle(mrunlist[mcurseg].speed), 0, 0, 0);






            }
            else //高级试验
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
                          mrunlist[ii].keeptime, mrunlist[ii].returnstep, mrunlist[ii].returncount);

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
                       mrunlist[ii].keeptime, mrunlist[ii].returnstep, mrunlist[ii].returncount);

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

        public override void segstep(int cmd, double dest, short firstctl, short destctl, short destkeepstyle, float speed, double keeptime, int reurnstep, int returncount)
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


                    mrun = true;

                }
                else
                {



                    aEziMOTIONPlusR.FAS_MoveSingleAxisAbsPos(mcom_control, 0,
                        Convert.ToInt32( dest / this.mangle_coefficient), Convert.ToInt32( speed / this.mangle_coefficient)); 


                    mrun = true;

                }

            }








        }

        void mtimer_Tick(object sender, EventArgs e)
        {
            short k;

            if (connected == false)
            {
                return;
            }
            Timer();

            if (mtestrun == false)
            {
                return;
            }

            if (mrun == true)
            {
                if ((System.Environment.TickCount / 1000 - mrunstarttime) <= 10)
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
                                      mrunlist[ii].keeptime, mrunlist[ii].returnstep, mrunlist[ii].returncount);
                                }
                                else
                                {
                                    if (ii == mcurseg)
                                    {
                                        segstep(mrunlist[ii].cmd, mrunlist[ii].dest,
                                   Convert.ToInt16(mrunlist[ii].controlmode),
                                    Convert.ToInt16(mrunlist[ii].destcontrolmode),
                                   k, Convert.ToSingle(mrunlist[ii].speed),
                                   mrunlist[ii].keeptime, mrunlist[ii].returnstep, mrunlist[ii].returncount);

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


            int r;

            mSerialPort.Open();

            CComLibrary.GlobeVal.InitUserCalcChannel();//初始化用户自定义通道


            ClsStaticStation.aEziMOTIONPlusR.FAS_Connect(mcom_control, 115200);

            r = ClsStaticStation.aEziMOTIONPlusR.FAS_IsSlaveExist(mcom_control, 0);




            OpenConnection();

            if (r == 1)
            {

                connected = true;
            }

            else
            {

                connected = false;
            }




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
            
            if (b.Text == "扭角")
            {
                aEziMOTIONPlusR.FAS_ClearPosition(mcom_control, 0);
                
            }

            if (b.Text == "扭矩")
            {
                mbtnloadzero = true;
            

            }







        }

        public override void restorezero(Button b)
        {
           
            if (b.Text == "扭角")
            {

            }

            if (b.Text == "扭矩")
            {

                mbtnloadrestore = true;
            
            }


           

        }





        public override int CloseConnection()
        {
            mSerialPort.Close();
            return 0;
        }


        public override int OpenConnection()
        {







            return 0;


        }
    }
}

