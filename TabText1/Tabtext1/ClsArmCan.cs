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
using ECAN;
using ECanTest;
namespace ClsStaticStation
{

   

    public class CArmCan : ClsBaseControl
    {


        a9500.MDataIno m_MDataIno = new a9500.MDataIno();

        double m_lvload = 0;

        static double m_samplestarttime;//采样信号开始时间

        bool m_dianyabaohucontrol = false;
        bool m_sensor5state0 = false;
        bool m_sensor5state1 = false;
        bool m_sensor5state2 = false;
        bool m_sensor6state0 = false;
        bool m_sensor6state1 = false;
        bool m_sensor6state2 = false;
        bool m_sensor7state0 = false;
        bool m_sensor7state1 = false;
        bool m_sensor7state2 = false;

        bool m_sensor5state3 = false;
        bool m_sensor6state3 = false;
        bool m_sensor7state3 = false;
        bool m_sensor5state4 = false;
        bool m_sensor6state4 = false;
        bool m_sensor7state4 = false;
        bool m_sensor5state5 = false;
        bool m_sensor6state5 = false;
        bool m_sensor7state5 = false;


        int m_sensor5state3count = 0;
        int m_sensor6state3count = 0;
        int m_sensor7state3count = 0;

        int m_sensor5state4count = 0;
        int m_sensor6state4count = 0;
        int m_sensor7state4count = 0;

        int m_sensor5state5count = 0;
        int m_sensor6state5count = 0;
        int m_sensor7state5count = 0;

        long basecount = 0;
        static double m_starttime = 0;

        byte m_Baudrate = 3;
        byte m_Baudrate2 = 3;

        byte[] m_connect = new byte[2];
        ComProc[] mCan = new ComProc[2];

        bool mcanenabled = false;

        private RawDataDataGroup[] r = new RawDataDataGroup[1];
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public a9500.DataInfo GGMsg;
        private a9500.OnGetDataDel GetDataIns;
        public short DeviceNum = 0;
        private float mLoadCapacity; //力满量程值
        private RawDataStruct b;



        private static double mad0 = 0;
        private static double mad1 = 0;
        private static double mad2 = 0;





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

        private void CanInit(uint i)
        {
            mcanenabled = false;

            if (m_connect[i] == 1)
            {
                m_connect[i] = 0;
                this.mCan[i].EnableProc = false;


                ECANDLL.CloseDevice(1, i);


                return;
            }

            INIT_CONFIG init_config = new INIT_CONFIG();

            init_config.AccCode = 0;
            init_config.AccMask = 0xffffff;
            init_config.Filter = 0;

            switch (m_Baudrate)
            {
                case 0: //1000

                    init_config.Timing0 = 0;
                    init_config.Timing1 = 0x14;
                    break;
                case 1: //800

                    init_config.Timing0 = 0;
                    init_config.Timing1 = 0x16;
                    break;
                case 2: //666

                    init_config.Timing0 = 0x80;
                    init_config.Timing1 = 0xb6;
                    break;
                case 3: //500

                    init_config.Timing0 = 0;
                    init_config.Timing1 = 0x1c;
                    break;
                case 4://400

                    init_config.Timing0 = 0x80;
                    init_config.Timing1 = 0xfa;
                    break;
                case 5://250

                    init_config.Timing0 = 0x01;
                    init_config.Timing1 = 0x1c;
                    break;
                case 6://200

                    init_config.Timing0 = 0x81;
                    init_config.Timing1 = 0xfa;
                    break;
                case 7://125

                    init_config.Timing0 = 0x03;
                    init_config.Timing1 = 0x1c;
                    break;
                case 8://100

                    init_config.Timing0 = 0x04;
                    init_config.Timing1 = 0x1c;
                    break;
                case 9://80

                    init_config.Timing0 = 0x83;
                    init_config.Timing1 = 0xff;
                    break;
                case 10://50

                    init_config.Timing0 = 0x09;
                    init_config.Timing1 = 0x1c;
                    break;

            }

            init_config.Mode = 0;

            if (ECANDLL.OpenDevice(1, i, 0) != ECAN.ECANStatus.STATUS_OK)
            {

                MessageBox.Show("Open device 0 fault!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            //Set can1 baud
            if (ECANDLL.InitCAN(1, i, 0, ref init_config) != ECAN.ECANStatus.STATUS_OK)
            {

                MessageBox.Show("Init can 0 fault!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ECANDLL.CloseDevice(1, i);
                return;
            }

            //set can2 baud


            switch (m_Baudrate2)
            {
                case 0: //1000

                    init_config.Timing0 = 0;
                    init_config.Timing1 = 0x14;
                    break;
                case 1: //800

                    init_config.Timing0 = 0;
                    init_config.Timing1 = 0x16;
                    break;
                case 2: //666

                    init_config.Timing0 = 0x80;
                    init_config.Timing1 = 0xb6;
                    break;
                case 3: //500

                    init_config.Timing0 = 0;
                    init_config.Timing1 = 0x1c;
                    break;
                case 4://400

                    init_config.Timing0 = 0x80;
                    init_config.Timing1 = 0xfa;
                    break;
                case 5://250

                    init_config.Timing0 = 0x01;
                    init_config.Timing1 = 0x1c;
                    break;
                case 6://200

                    init_config.Timing0 = 0x81;
                    init_config.Timing1 = 0xfa;
                    break;
                case 7://125

                    init_config.Timing0 = 0x03;
                    init_config.Timing1 = 0x1c;
                    break;
                case 8://100

                    init_config.Timing0 = 0x04;
                    init_config.Timing1 = 0x1c;
                    break;
                case 9://80

                    init_config.Timing0 = 0x83;
                    init_config.Timing1 = 0xff;
                    break;
                case 10://50

                    init_config.Timing0 = 0x09;
                    init_config.Timing1 = 0x1c;
                    break;

            }

            init_config.Mode = 0;





            if (ECANDLL.InitCAN(1, i, 1, ref init_config) != ECAN.ECANStatus.STATUS_OK)
            {

                MessageBox.Show("Init can 1 fault!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ECANDLL.CloseDevice(1, i);
                return;
            }


            m_connect[i] = 1;
            this.mCan[i].EnableProc = true;





            if (m_connect[i] == 0)
            {
                MessageBox.Show("Not open device 0!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            //Start Can1

            if (ECANDLL.StartCAN(1, i, 0) == ECAN.ECANStatus.STATUS_OK)
            {
                //  MessageBox.Show("Start CAN1 Success");


            }
            else
            {
                MessageBox.Show("Start 1 Fault");
            }
            //start CAN2
            if (ECANDLL.StartCAN(1, i, 1) == ECAN.ECANStatus.STATUS_OK)
            {
                // MessageBox.Show("Start CAN2 Success");


            }
            else
            {
                MessageBox.Show("Start 2 Fault");
            }


            mcanenabled = true;


        }


        private void ReadMessagesOld(int i)
        {

         

        }
        private void ReadMessages(int i)
        {


        }

        private void ReadMessages3(int i)
        {

            CAN_OBJ frameinfo = new CAN_OBJ();
            int mCount = 0;
            while (this.mCan[i].gRecMsgBufHead != this.mCan[i].gRecMsgBufTail)
            {
                string tmpstr;
                frameinfo = this.mCan[i].gRecMsgBuf[this.mCan[i].gRecMsgBufTail];
                this.mCan[i].gRecMsgBufTail += 1;
                if (this.mCan[i].gRecMsgBufTail >= ComProc.REC_MSG_BUF_MAX)
                {
                    this.mCan[i].gRecMsgBufTail = 0;
                }
                string str = "Rec: ";
                if (frameinfo.TimeFlag == 0)
                {
                    tmpstr = "Time:  ";
                }
                else
                {
                    tmpstr = "Time:" + string.Format("{0:X8}h", frameinfo.TimeStamp);
                }

                if (frameinfo.ID == 0x139)
                {
                    mad0 = (frameinfo.data[0] + frameinfo.data[1] * 256) / 1000.0;

                }

                if (frameinfo.ID == 0x141)
                {
                    mad1 = (frameinfo.data[0] + frameinfo.data[1] * 256) / 1000.0;


                }
                if (frameinfo.ID == 0x143)
                {
                    mad2 = (frameinfo.data[0] + frameinfo.data[1] * 256) / 1000.0;


                    m_MDataIno = new a9500.MDataIno();
                    m_MDataIno.sensor5 = mad0;
                    m_MDataIno.sensor6 = mad1;
                    m_MDataIno.sensor7 = mad2;


                    m_MDataIno.Id = DeviceNum;
                    m_MDataIno.mydatainfo = GGMsg;


                    m_starttime = m_starttime + 0.01;
                    //m_MDataIno.time1 = GGMsg.time;
                    m_MDataIno.time1 = m_starttime;

                    // if (mCount % 2 == 1)
                    {
                        mdatalist.Add(m_MDataIno);
                    }
                }

                mCount++;
                if (mCount >= 10)
                {
                    break;
                }
                Application.DoEvents();
            }



        }
        private void ReadMessages2(int i)
        {

            CAN_OBJ frameinfo = new CAN_OBJ();
            int mCount = 0;
            while (this.mCan[i].gRecMsgBufHead2 != this.mCan[i].gRecMsgBufTail2)
            {
                string tmpstr;
                frameinfo = this.mCan[i].gRecMsgBuf2[this.mCan[i].gRecMsgBufTail2];
                this.mCan[i].gRecMsgBufTail2 += 1;
                if (this.mCan[i].gRecMsgBufTail2 >= ComProc.REC_MSG_BUF_MAX)
                {
                    this.mCan[i].gRecMsgBufTail2 = 0;
                }
                string str = "Rec: ";
                if (frameinfo.TimeFlag == 0)
                {
                    tmpstr = "Time:  ";
                }
                else
                {
                    tmpstr = "Time:" + string.Format("{0:X8}h", frameinfo.TimeStamp);
                }


                if (frameinfo.ID == 0x139)
                {
                    mad0 = (frameinfo.data[0] + frameinfo.data[1] * 256) / 1000.0;

                }

                if (frameinfo.ID == 0x141)
                {
                    mad1 = (frameinfo.data[0] + frameinfo.data[1] * 256) / 1000.0;


                }
                if (frameinfo.ID == 0x143)
                {
                    mad2 = (frameinfo.data[0] + frameinfo.data[1] * 256) / 1000.0;


                    m_MDataIno = new a9500.MDataIno();
                    m_MDataIno.sensor5 = mad0;
                    m_MDataIno.sensor6 = mad1;
                    m_MDataIno.sensor7 = mad2;


                    m_MDataIno.Id = DeviceNum;
                    m_MDataIno.mydatainfo = GGMsg;


                    m_starttime = m_starttime + 0.01;
                    // m_MDataIno.time1 = GGMsg.time;
                    m_MDataIno.time1 = m_starttime;

                    //if (mCount % 2 == 1)
                    {
                        mdatalist.Add(m_MDataIno);
                    }
                }
                mCount++;
                if (mCount >= 10)
                {
                    break;
                }
                Application.DoEvents();
            }



        }

        private void ReadMessages4(int i)
        {

            CAN_OBJ frameinfo = new CAN_OBJ();
            int mCount = 0;
            while (this.mCan[i].gRecMsgBufHead2 != this.mCan[i].gRecMsgBufTail2)
            {
                string tmpstr;
                frameinfo = this.mCan[i].gRecMsgBuf2[this.mCan[i].gRecMsgBufTail2];
                this.mCan[i].gRecMsgBufTail2 += 1;
                if (this.mCan[i].gRecMsgBufTail2 >= ComProc.REC_MSG_BUF_MAX)
                {
                    this.mCan[i].gRecMsgBufTail2 = 0;
                }


                if (frameinfo.ID == 0x139)
                {
                    mad0 = (frameinfo.data[0] + frameinfo.data[1] * 256) / 1000.0;

                }

                if (frameinfo.ID == 0x141)
                {
                    mad1 = (frameinfo.data[0] + frameinfo.data[1] * 256) / 1000.0;


                }
                if (frameinfo.ID == 0x143)
                {
                    mad2 = (frameinfo.data[0] + frameinfo.data[1] * 256) / 1000.0;


                    m_MDataIno = new a9500.MDataIno();
                    m_MDataIno.sensor5 = mad0;
                    m_MDataIno.sensor6 = mad1;
                    m_MDataIno.sensor7 = mad2;


                    m_MDataIno.Id = DeviceNum;
                    m_MDataIno.mydatainfo = GGMsg;


                    m_starttime = m_starttime + 0.01;
                    m_MDataIno.time1 = GGMsg.time;
                    m_MDataIno.time2 = m_starttime;



                    mdatalist.Add(m_MDataIno);

                }
                mCount++;
                if (mCount >= 20)
                {
                    break;
                }
                Application.DoEvents();
            }



        }

        private void ReadError1()
        {
            string s = "";
            CAN_ERR_INFO mErrInfo = new CAN_ERR_INFO();

            if (ECANDLL.ReadErrInfo(1, 0, 0, out mErrInfo) == ECANStatus.STATUS_OK)
            {
                s = string.Format("{0:X4}h", mErrInfo.ErrCode);
                s = s + string.Format("{0:X4}h", mErrInfo.Passive_ErrData[1]);
                s = s + string.Format("{0:X4}h", mErrInfo.Passive_ErrData[2]);

            }
            else
            {

                s = "Read Error Fault";
            }



        }
        private void ReadError2()
        {
            string s = "";
            CAN_ERR_INFO mErrInfo = new CAN_ERR_INFO();

            if (ECANDLL.ReadErrInfo(1, 0, 1, out mErrInfo) == ECANStatus.STATUS_OK)
            {
                s = string.Format("{0:X4}h", mErrInfo.ErrCode);

            }
            else
            {

                s = "Read Error Fault";
            }



        }

        public CArmCan()
        {
            GGMsg = new a9500.DataInfo();
            mdatalist = new List<a9500.MDataIno>();
            mtimer = new System.Windows.Forms.Timer();
            mtimer.Tick += new EventHandler(mtimer_Tick);
            mtimer.Interval = 10;
            mtimer.Enabled = true;
            mtimer.Start();

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
            m_dianyabaohucontrol = false;
        }
        public override void fatigtest(int wavekind, float freq, float ave, float range, double count)
        {
            a9500.CSinWave SinS = new a9500.CSinWave();
            a9500.CTriWave TriangleS = new a9500.CTriWave();
            m_lvload = range;

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
            m_samplestarttime = GGMsg.time;

            m_sensor5state0 = false;
            m_sensor5state1 = false;
            m_sensor5state2 = false;
            m_sensor6state0 = false;
            m_sensor6state1 = false;
            m_sensor6state2 = false;
            m_sensor7state0 = false;
            m_sensor7state1 = false;
            m_sensor7state2 = false;
            m_sensor5state3 = false;
            m_sensor6state3 = false;
            m_sensor7state3 = false;
            m_sensor5state4 = false;
            m_sensor6state4 = false;
            m_sensor7state4 = false;
            m_sensor5state5 = false;
            m_sensor6state5 = false;
            m_sensor7state5 = false;

            m_sensor5state3count = 0;
            m_sensor6state3count = 0;
            m_sensor7state3count = 0;
            m_sensor5state4count = 0;
            m_sensor6state4count = 0;
            m_sensor7state4count = 0;
            m_sensor5state5count = 0;
            m_sensor6state5count = 0;
            m_sensor7state5count = 0;

            m_dianyabaohucontrol = true;

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
                sensor5 = r.NextDouble() + 1;
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

            double[] rr;

            rr = new double[100];

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

                                if( m_dianyabaohucontrol ==true)
                                {
                                    if ( load>m_lvload )
                                    {
                                        load  = m_lvload;
                                    }

                                    else if (load  <-m_lvload)
                                    {
                                       load = -m_lvload;
                                    }
                                 
                                    
                                }


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
                            totalcount = Convert.ToInt32(count);
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
                        if (CComLibrary.GlobeVal.filesave.Samplecheck)
                        {
                            if ((m_dianyabaohucontrol == true) )
                            {
                                if (Math.Abs(GGMsg.time - m_samplestarttime) < CComLibrary.GlobeVal.filesave.SampleChecktime)
                                {
                                    if ((sensor5 >1.586) && (sensor5 <1.786))
                                    {
                                        m_sensor5state3count = m_sensor5state3count + 1;

                                        if (m_sensor5state3count>=10)
                                        {
                                            m_sensor5state3 = true;
                                        }
                                    }
                                    if ((sensor6>1.586) && (sensor6 <1.786))
                                    {
                                        m_sensor6state3count = m_sensor6state3count + 1;
                                        if (m_sensor6state3count >= 10)
                                        {
                                            m_sensor6state3 = true;
                                        }
                                    }
                                    if ((sensor7 >1.586) && (sensor7 <1.786))
                                    {
                                        m_sensor7state3count = m_sensor7state3count + 1;
                                        if (m_sensor7state3count >= 10)
                                        {
                                            m_sensor7state3 = true;
                                        }

                                    }

                                    if ((sensor5 > 3.003) && (sensor5 < 3.203))
                                    {
                                        m_sensor5state4count = m_sensor5state4count + 1;

                                        if (m_sensor5state4count >= 10)
                                        {
                                            m_sensor5state4 = true;
                                        }
                                    }
                                    if ((sensor6 > 3.003) && (sensor6 < 3.203))
                                    {
                                        m_sensor6state4count = m_sensor6state4count + 1;
                                        if (m_sensor6state4count >= 10)
                                        {
                                            m_sensor6state4 = true;
                                        }
                                    }
                                    if ((sensor7 > 3.003) && (sensor7 < 3.203))
                                    {
                                        m_sensor7state3count = m_sensor7state3count + 1;
                                        if (m_sensor7state4count >= 10)
                                        {
                                            m_sensor7state4 = true;
                                        }

                                    }

                                    if ((sensor5 > 4.416) && (sensor5 < 4.616))
                                    {
                                        m_sensor5state5count = m_sensor5state5count + 1;

                                        if (m_sensor5state5count >= 10)
                                        {
                                            m_sensor5state5 = true;
                                        }
                                    }
                                    if ((sensor6 >4.416) && (sensor6 < 4.616))
                                    {
                                        m_sensor6state5count = m_sensor6state5count + 1;
                                        if (m_sensor6state5count >= 10)
                                        {
                                            m_sensor6state5 = true;
                                        }
                                    }
                                    if ((sensor7 > 4.416) && (sensor7 < 4.616))
                                    {
                                        m_sensor7state5count = m_sensor7state5count + 1;
                                        if (m_sensor7state5count >= 10)
                                        {
                                            m_sensor7state5 = true;
                                        }

                                    }


                                    if ((sensor5 > 1.200) && (sensor5 < 1.400))
                                    {
                                        m_sensor5state0 = true;
                                    }

                                    if ((sensor6 > 1.200) && (sensor6 < 1.400))
                                    {
                                        m_sensor6state0 = true;
                                    }

                                    if ((sensor7 > 1.200) && (sensor7 < 1.400))
                                    {
                                        m_sensor7state0 = true;
                                    }

                                    if ((sensor5 > 1.950) && (sensor5 < 2.150))
                                    {
                                        m_sensor5state1 = true;
                                    }

                                    if ((sensor6 > 1.95) && (sensor6 < 2.15))
                                    {
                                        m_sensor6state1 = true;
                                    }

                                    if ((sensor7 > 1.95) && (sensor7 < 2.15))
                                    {
                                        m_sensor7state1 = true;
                                    }

                                    if ((sensor5 > 2.5) && (sensor5 < 2.7))
                                    {
                                        m_sensor5state2 = true;
                                    }

                                    if ((sensor6 > 2.5) && (sensor6 < 2.7))
                                    {
                                        m_sensor6state2 = true;
                                    }

                                    if ((sensor7 > 2.5) && (sensor7 < 2.7))
                                    {
                                        m_sensor7state2 = true;
                                    }

                                }
                                else
                                {
                                    if ((m_sensor5state0 == true) && (m_sensor5state1 == true) && (m_sensor5state2 == true)
                                           && (m_sensor6state0 == true) && (m_sensor6state1 == true) && (m_sensor6state2 == true)
                                         && (m_sensor7state0 == true) && (m_sensor7state1 == true) && (m_sensor7state2 == true)
                                        && (m_sensor5state3 ==false) && (m_sensor5state4 ==false) && (m_sensor5state5 ==false )
                                         && (m_sensor6state3==false)&& (m_sensor6state4 ==false) && (m_sensor6state5 ==false)
                                         && (m_sensor7state3 ==false) && (m_sensor7state4 ==false) && (m_sensor7state5 ==false)) 
                                    {


                                        m_samplestarttime = GGMsg.time;
                                        m_sensor5state0 = false;
                                        m_sensor5state1 = false;
                                        m_sensor5state2 = false;
                                        m_sensor6state0 = false;
                                        m_sensor6state1 = false;
                                        m_sensor6state2 = false;
                                        m_sensor7state0 = false;
                                        m_sensor7state1 = false;
                                        m_sensor7state2 = false;

                                        m_sensor5state3 = false;
                                        m_sensor5state4 = false;
                                        m_sensor5state5 = false;
                                        m_sensor5state3count = 0;
                                        m_sensor5state4count = 0;
                                        m_sensor5state5count = 0;
                                        m_sensor6state3 = false;
                                        m_sensor6state4 = false;
                                        m_sensor6state5 = false;
                                        m_sensor6state3count = 0;
                                        m_sensor6state4count = 0;
                                        m_sensor6state5count = 0;
                                        m_sensor7state3 = false;
                                        m_sensor7state4 = false;
                                        m_sensor7state5 = false;
                                        m_sensor7state3count = 0;
                                        m_sensor7state4count = 0;
                                        m_sensor7state5count = 0;

                                    }
                                    else
                                    {
                                        m_dianyabaohucontrol = false;
                                        dianyabaohu = true;
                                    }
                                }

                            }
                        }
                    }

                    

                    

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

                    if (mdatalist.Count >100)
                    {
                        mdatalist.Clear();
                    }
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



        public override void starttest()
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
            /*
            bool b = false;
            while (b == false)
            {
                Application.DoEvents();
                if (time < 1)
                {
                    b = true;
                }
            }
            */

            int iii = 0;



            while (iii < ClsStatic.arraydata[0].NodeCount)
            {


                ClsStatic.arraydata[0].Read<RawDataDataGroup>(out d, 10);


                iii = iii + 1;


            }

            ClsStatic.arraydatacount[0] = 0;


            iii = 0;

            while (iii < ClsStatic.arraydata[1].NodeCount)
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

            m_starttime = 0;

            if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 2)//简单试验
            {
                mrunlist = new List<CComLibrary.CmdSeg>();
                mrunlist.Clear();


                mrunlist.Add(CComLibrary.GlobeVal.filesave.simple_cmd);

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

                /*
				segstep(mrunlist[mcurseg].cmd, mrunlist[mcurseg].destorigin(),
					Convert.ToInt16(mrunlist[mcurseg].controlmode),
					 Convert.ToInt16(mrunlist[mcurseg].destcontrolmode),
					k, Convert.ToSingle(mrunlist[mcurseg].speedorigin()), 0, 0, 0,0);
                    */


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


                segstep(mrunlist[mcurseg].cmd, mrunlist[mcurseg].destorigin(),
                    Convert.ToInt16(mrunlist[mcurseg].controlmode),
                     Convert.ToInt16(mrunlist[mcurseg].destcontrolmode),
                    k, Convert.ToSingle(mrunlist[mcurseg].speedorigin()), 0, 0, 0, 0);






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
                          mrunlist[ii].keeptime, mrunlist[ii].returnstep, mrunlist[ii].returncount, mrunlist[ii].action);

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

            Debug.Print("mrunlist cunt=" + mrunlist.Count.ToString());


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
                                      mrunlist[ii].keeptime, mrunlist[ii].returnstep, mrunlist[ii].returncount, mrunlist[ii].action);
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


        public override void Init(int handle)
        {


            short e;

            int rp = 0;

            CComLibrary.GlobeVal.InitUserCalcChannel();//初始化用户自定义通道

            e = System.Convert.ToInt16(a9500.ARM_DEC_Init(handle));

            GetDataIns = new a9500.OnGetDataDel(OnGetDataByMessage);

            a9500.ARM_DEC_OnCallBack(GetDataIns);

            OpenConnection();
            m_connect[0] = 0;
            m_connect[1] = 0;
            mCan[0] = new ComProc(0);
            // mCan[1] = new ComProc(1);

            CanInit(0);
            // CanInit(1);




            connected = true;
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
                m_MDataIno = new a9500.MDataIno();

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
                m_Global.madlist.RemoveRange(0, m - 2);


                if (m_Global.madlist.Count > 900)
                {
                    m_Global.madlist.Clear();
                }

                mdatalist.RemoveRange(0, m - 2);
                if (mdatalist.Count >100)
                {
                    mdatalist.Clear();
                }

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

            if (this.mcanenabled == true)
            {
                // ReadMessages(0);
                //  ReadMessages2(0);
                // ReadMessages3(1);
                // ReadMessages4(1);
                // ReadError1();
                // ReadError2();
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
    
}

