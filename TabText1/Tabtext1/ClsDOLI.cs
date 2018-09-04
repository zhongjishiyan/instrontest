//#define ONDATABLOCK
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
using System.Drawing;


using Doli.DoPE;



namespace ClsStaticStation
{


    [StructLayout(LayoutKind.Sequential)]
    public struct MSG
    {
        public IntPtr handle;
        public uint msg;
        public IntPtr wParam;
        public IntPtr lParam;
        public uint time;
        public System.Drawing.Point p;
    }
    public class AccurateTimer
    {
        public static bool IsTimeBeginPeriod = false;

        const int PM_REMOVE = 0x0001;

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool PeekMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin,
           uint wMsgFilterMax, uint wRemoveMsg);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool TranslateMessage(ref MSG lpMsg);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool DispatchMessage(ref MSG lpMsg);


        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool QueryPerformanceCounter(ref Int64 count);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool QueryPerformanceFrequency(ref Int64 frequency);

        public static int GetTimeTick()
        {
            return Environment.TickCount;
        }

        public static void AccurateSleep(int a_i4MSec)
        {
            Int64 t_i8Frequency = 0;
            Int64 t_i8StartTime = 0;
            Int64 t_i8EndTime = 0;
            double t_r8PassedMSec = 0;
            MSG msg;
            AccurateTimer.QueryPerformanceCounter(ref t_i8StartTime);
            AccurateTimer.QueryPerformanceFrequency(ref t_i8Frequency);
            do
            {
                if (AccurateTimer.PeekMessage(out msg, IntPtr.Zero, 0, 0, PM_REMOVE))
                {
                    AccurateTimer.TranslateMessage(ref msg);
                    AccurateTimer.DispatchMessage(ref msg);
                }
                AccurateTimer.QueryPerformanceCounter(ref t_i8EndTime);
                t_r8PassedMSec = ((double)(t_i8EndTime - t_i8StartTime) / (double)t_i8Frequency) * 1000;
            } while (t_r8PassedMSec <= a_i4MSec);
        }
    }

    public class EventMsg
    {
        public DoPE.OnPosMsg PosMsg;
        public EventMsg()
        {
            PosMsg = new DoPE.OnPosMsg();
        }



    }

    public struct MDataInfo
    {
        public int Id;
        public DoPE.Data mydatainfo;

        public double mtime;

        public double mwave;
    }

    public class DoPeEvent
    {

        public Edc myedc;
        public short MyTan;

      
       
        public List<MDataInfo> mdatalist;
        RawDataStruct b = new RawDataStruct();

        public int mcount = 0;

        public DoPeEvent()
        {
            mdatalist = new List<MDataInfo>();
        }
        public int ID;

        private void DisplayError(DoPE.ERR error, string Text)
        {
            // if (error != DoPE.ERR.NOERROR)
            //Display(Text + " Error: " + error + "\n");
            //gHelper.WriteLogError(Text + " Error: " + error + "\n", null);
        }

        ///----------------------------------------------------------------------
        /// <summary>Display debug text</summary>
        ///----------------------------------------------------------------------
        private void Display(string Text)
        {
           // MessageBox.Show(Text);


        }

        public int OnLine(DoPE.LineState LineState, object Parameter)
        {
            Display(string.Format(ID.ToString() + " OnLine: {0}\n", LineState));

            return 0;
        }

#if ONDATABLOCK
        public int OnDataBlock(ref DoPE.OnDataBlock Block, object Parameter)
        {
            int i;

            RawDataStruct b = new RawDataStruct();

            MDataInfo ma;



            if (Block.Data.Length > 0)
            {
                // refesh edit controls with the latest sample

                for (i = 0; i < Block.Data.Length; i++)
                {

                    DoPE.Data Sample = Block.Data[i].Data;


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


                    if (b.ctrl_move == 1)
                    {
                        m_runstate = 1;
                    }
                    else
                    {
                        m_runstate = 0;
                    }
                    ma = new MDataInfo();
                    ma.Id = 0;
                    ma.mydatainfo = Sample;

                    mcount = mcount + 1;

                    if (mcount >= 0)
                    {

                        mcount = 0;
                        mdatalist.Add(ma);


                    }


                }



            }
            return 0;
        }
#else
    private Int32 LastTime = Environment.TickCount;
    public  int OnData(ref DoPE.OnData Data, object Parameter)
    {
      
        long a=0;
        long c = 0;
        

        MDataInfo ma;

      if (Data.DoPError == DoPE.ERR.NOERROR)
      {
        DoPE.Data Sample = Data.Data;


       

      //  AccurateTimer.QueryPerformanceCounter(ref a);
      //  AccurateTimer.QueryPerformanceFrequency(ref c);
      //  double Time = a / (double)c;

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


     
      
        ma = new MDataInfo();
        ma.Id = 0;
        ma.mydatainfo = Sample;
        ma.mtime =Sample.Time;
        ma.mwave = m_Global.mwave;
        mdatalist.Add(ma);
       


       

       
      }
      return 0;
    }
#endif

        public int OnCommandError(ref DoPE.OnCommandError CommandError, object Parameter)
        {
            Display(string.Format("OnCommandError: CommandNumber={0} ErrorNumber={1} usTAN={2} \n",
              CommandError.CommandNumber, CommandError.ErrorNumber, CommandError.usTAN));

            return 0;
        }

        public int OnPosMsg(ref DoPE.OnPosMsg PosMsg, object Parameter)
        {

            m_Global.m_runstate = 0;
            return 0;
            Display(string.Format("OnPosMsg: DoPError={0} Reached={1} Time={2} Control={3} Position={4} DControl={5} Destination={6} usTAN={7} \n",
              PosMsg.DoPError, PosMsg.Reached, PosMsg.Time, PosMsg.Control, PosMsg.Position, PosMsg.DControl, PosMsg.Destination, PosMsg.usTAN));

            return 0;
        }

        public int OnTPosMsg(ref DoPE.OnPosMsg PosMsg, object Parameter)
        {
            Display(string.Format("OnTPosMsg: DoPError={0} Reached={1} Time={2} Control={3} Position={4} DControl={5} Destination={6} usTAN={7} \n",
              PosMsg.DoPError, PosMsg.Reached, PosMsg.Time, PosMsg.Control, PosMsg.Position, PosMsg.DControl, PosMsg.Destination, PosMsg.usTAN));

            return 0;
        }

        public int OnLPosMsg(ref DoPE.OnPosMsg PosMsg, object Parameter)
        {
            Display(string.Format("OnLPosMsg: DoPError={0} Reached={1} Time={2} Control={3} Position={4} DControl={5} Destination={6} usTAN={7} \n",
              PosMsg.DoPError, PosMsg.Reached, PosMsg.Time, PosMsg.Control, PosMsg.Position, PosMsg.DControl, PosMsg.Destination, PosMsg.usTAN));

            return 0;
        }

        public int OnSftMsg(ref DoPE.OnSftMsg SftMsg, object Parameter)
        {
            Display(string.Format("OnSftMsg: DoPError={0} Upper={1} Time={2} Control={3} Position={4} usTAN={5} \n",
              SftMsg.DoPError, SftMsg.Upper, SftMsg.Time, SftMsg.Control, SftMsg.Position, SftMsg.usTAN));
            // mycls.PciControl.myeventmsg[ID].PosMsg.Time = SftMsg.Time;
            return 0;
        }

        public int OnOffsCMsg(ref DoPE.OnOffsCMsg OffsCMsg, object Parameter)
        {
            Display(string.Format("OnOffsCMsg: DoPError={0} Time={1} Offset={2} usTAN={3} \n",
              OffsCMsg.DoPError, OffsCMsg.Time, OffsCMsg.Offset, OffsCMsg.usTAN));

            return 0;
        }

        public int OnCheckMsg(ref DoPE.OnCheckMsg CheckMsg, object Parameter)
        {
            Display(string.Format("OnCheckMsg: DoPError={0} Action={1} Time={2} CheckId={3} Position={4} SensorNo={5} usTAN={6} \n",
              CheckMsg.DoPError, CheckMsg.Action, CheckMsg.Time, CheckMsg.CheckId, CheckMsg.Position, CheckMsg.SensorNo, CheckMsg.usTAN));

            return 0;
        }

        public int OnShieldMsg(ref DoPE.OnShieldMsg ShieldMsg, object Parameter)
        {
            Display(string.Format("OnShieldMsg: DoPError={0} Action={1} Time={2} SensorNo={3} Position={4} usTAN={5} \n",
              ShieldMsg.DoPError, ShieldMsg.Action, ShieldMsg.Time, ShieldMsg.SensorNo, ShieldMsg.Position, ShieldMsg.usTAN));

            return 0;
        }

        public int OnRefSignalMsg(ref DoPE.OnRefSignalMsg RefSignalMsg, object Parameter)
        {
            Display(string.Format("OnRefSignalMsg: DoPError={0} Time={1} SensorNo={2} Position={3} usTAN={4} \n",
              RefSignalMsg.DoPError, RefSignalMsg.Time, RefSignalMsg.SensorNo, RefSignalMsg.Position, RefSignalMsg.usTAN));

            return 0;
        }

        public int OnSensorMsg(ref DoPE.OnSensorMsg SensorMsg, object Parameter)
        {
            Display(string.Format("OnSensorMsg: DoPError={0} Time={1} SensorNo={2} usTAN={3} \n",
              SensorMsg.DoPError, SensorMsg.Time, SensorMsg.SensorNo, SensorMsg.usTAN));

            return 0;
        }

        public int OnIoSHaltMsg(ref DoPE.OnIoSHaltMsg IoSHaltMsg, object Parameter)
        {
            Display(string.Format("OnIoSHaltMsg: DoPError={0} Upper={1} Time={2} Control={3} Position={4} usTAN={5} \n",
              IoSHaltMsg.DoPError, IoSHaltMsg.Upper, IoSHaltMsg.Time, IoSHaltMsg.Control, IoSHaltMsg.Position, IoSHaltMsg.usTAN));

            return 0;
        }

        public int OnKeyMsg(ref DoPE.OnKeyMsg KeyMsg, object Parameter)
        {
            Display(string.Format("OnKeyMsg: DoPError={0} Time={1} Keys={2} NewKeys={3} GoneKeys={4} OemKeys={5} NewOemKeys={6} GoneOemKeys={7} usTAN={8} \n",
              KeyMsg.DoPError, KeyMsg.Time, KeyMsg.Keys, KeyMsg.NewKeys, KeyMsg.GoneKeys, KeyMsg.OemKeys, KeyMsg.NewOemKeys, KeyMsg.GoneOemKeys, KeyMsg.usTAN));

            return 0;
        }

        public int OnRuntimeError(ref DoPE.OnRuntimeError RuntimeError, object Parameter)
        {
            Display(string.Format("OnRuntimeError: DoPError={0} ErrorNumber={1} Time={2} Device={3} Bits={4} usTAN={5} \n",
              RuntimeError.DoPError, RuntimeError.ErrorNumber, RuntimeError.Time, RuntimeError.Device, RuntimeError.Bits, RuntimeError.usTAN));

            return 0;
        }

        public int OnOverflow(int Overflow, object Parameter)
        {
            Display(string.Format("OnOverflow: Overflow={0} \n", Overflow));

            return 0;
        }

        public int OnDebugMsg(ref DoPE.OnDebugMsg DebugMsg, object Parameter)
        {
            Display(string.Format("OnDebugMsg: DoPError={0} MsgType={1} Time={2} Text={3} \n",
              DebugMsg.DoPError, DebugMsg.MsgType, DebugMsg.Time, DebugMsg.Text));

            return 0;
        }

        public int OnSystemMsg(ref DoPE.OnSystemMsg SystemMsg, object Parameter)
        {
            Display(string.Format("OnSystemMsg: DoPError={0} MsgNumber={1} Time={2} Text={3} \n",
              SystemMsg.DoPError, SystemMsg.MsgNumber, SystemMsg.Time, SystemMsg.Text));

            return 0;
        }

        public int OnRmcEvent(ref DoPE.OnRmcEvent RmcEvent, object Parameter)
        {
            Display(string.Format("OnRmcEvent: Keys={0} NewKeys={1} GoneKeys={2} Leds={3} NewLeds={4} GoneLeds={5} \n",
              RmcEvent.Keys, RmcEvent.NewKeys, RmcEvent.GoneKeys, RmcEvent.Leds, RmcEvent.NewLeds, RmcEvent.GoneLeds));

            return 0;
        }
    }

    public class CDOLI : ClsBaseControl
    {

        private double mstarttickcount;


        bool mstartcontrol = false;

        double  mstartcontroltime = 0;

        double mstartcontrolpos = 0;

        DoPE.Data mcurrentdata = new DoPE.Data();

        public long merrorcount = 0;

        private long ma = 0;
        UltraHighAccurateTimer.UltraHighAccurateTimer uhat;

        MDataInfo GGMsg;
        private double fv;

        public Queue<DoPE.Data>[] mydata;

        public int[] oldcount;

        public int[] m_oldcount;

        public EventMsg[] myeventmsg;
        private int[] EdcId;

        public Edc[] MyEdc;

        private int[] fcontrolmode;


        private bool fConnected = false;
        public bool Connected//
        {
            get { return fConnected; }

            set
            {
                fConnected = value;
            }
        }


        private DoPeEvent[] Myevent;

        /// <summary>
        /// TAN number assigned to a DoPE command.
        /// (To get informed when a task has been performed.)
        /// </summary>
       // public short[] MyTan;

        /// <summary>
        /// Just an error constant string which is used
        /// when the EDC could not be initialized correctly.
        /// </summary>
        private const string CommandFailedStringE = "Command failed. Please make sure, that the Edc is successfully initialized. \n";
        private const string CommandFailedString = "命令失败，请确保Edc成功初始化\n";

        private void DisplayError(DoPE.ERR error, string Text)
        {
            // if (error != DoPE.ERR.NOERROR)
            //Display(Text + " Error: " + error + "\n");

        }

        ///----------------------------------------------------------------------
        /// <summary>Display debug text</summary>
        ///----------------------------------------------------------------------
        private void Display(string Text)
        {



        }

        public override void Exit()
        {
           // uhat.Stop();
        }
        public override  void btnzeroall()
        {

        }

        public override void btnrestoreall()
        {

        }
        public override void DriveOn()
        {
            try
            {

                DoPE.ERR error = MyEdc[DeviceNum].Move.On();
                DisplayError(error, "On");
            }
            catch (NullReferenceException)
            {
                Display(CommandFailedString);
            }
        }

        public override void DriveOff()
        {
            try
            {
                DoPE.ERR error = MyEdc[DeviceNum].Move.Off();
                DisplayError(error, "Off");
            }
            catch (NullReferenceException)
            {
                Display(CommandFailedString);
            }
        }



        public override void CrossUp(int ctrlmode, double speed)
        {
            try
            {
                DoPE.ERR error = MyEdc[DeviceNum].Move.FDPoti(DoPE.CTRL.POS, speed / 60, DoPE.SENSOR.SENSOR_DP, 3, DoPE.EXT.SPEED_UP, 2, ref Myevent[DeviceNum].MyTan);
                DisplayError(error, "FDPoti");
            }
            catch (NullReferenceException)
            {
                Display(CommandFailedString);
            }
        }
        public override void CrossDown(int ctrlmode, double speed)
        {
            try
            {
                DoPE.ERR error = MyEdc[DeviceNum].Move.FDPoti(DoPE.CTRL.POS, speed / 60, DoPE.SENSOR.SENSOR_DP, 3, DoPE.EXT.SPEED_DOWN, 2, ref Myevent[DeviceNum].MyTan);
                DisplayError(error, "FDPoti");
            }
            catch (NullReferenceException)
            {
                Display(CommandFailedString);
            }
        }

        public override void CrossStop(int ctrlmode)
        {
            try
            {
                DoPE.ERR error = MyEdc[DeviceNum].Move.Halt(DoPE.CTRL.POS, ref Myevent[DeviceNum].MyTan);
                DisplayError(error, "Halt");
            }
            catch (NullReferenceException)
            {
                Display(CommandFailedString);
            }

        }

        public override void startcontrol()
        {
            MyEdc[DeviceNum].Data.CurrentData(ref mcurrentdata);

            mstartcontroltime = mcurrentdata.Time;
            mstartcontrolpos = mcurrentdata.Sensor[Convert.ToInt16(DoPE.SENSOR.SENSOR_S)];

            mstartcontrol = true;

         


        }

        public override void endcontrol()
        {
            mstartcontrol = false;
        }


        public override void DestStart(int ctrlmode, double dest, double speed)
        {
            DoPE.CTRL control;

            double destination;
            double mspeed;

            try
            {

                mspeed = speed / 60;
                Int32 i = MyEdc[DeviceNum].DoPEDllHdl;

                control = (DoPE.CTRL)ConvertCtrlMode(ctrlmode);

                destination = dest;

                DoPE.ERR error = MyEdc[DeviceNum].Move.Pos(control, mspeed, dest, ref Myevent[DeviceNum].MyTan);
                DisplayError(error, "Pos");
            }
            catch (NullReferenceException)
            {
                Display(CommandFailedString);
            }
        }
        public override void DestStop(int ctrlmode)
        {
            try
            {
                DoPE.ERR error = MyEdc[DeviceNum].Move.Halt(DoPE.CTRL.POS, ref Myevent[DeviceNum].MyTan);
                DisplayError(error, "Halt");
            }
            catch (NullReferenceException)
            {
                Display(CommandFailedString);
            }
        }

        private int GetCurrentControlMode(int CDeviceID)
        {

            return fcontrolmode[CDeviceID];
        }

        private void ConnectToEdc(int CDeviceID)
        {
            // tell DoPE which DoPENet.dll and DoPE.dll version we are using
            // THE API CANNOT BE USED WITHOUT THIS CHECK !
            int i;
            int j;
            DoPE.CheckApi("2.82");

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                DoPE.ERR error;

                // open the first EDC found on this PC



                MyEdc[CDeviceID] = new Edc(DoPE.OpenBy.DeviceId, EdcId[CDeviceID]);

                // hang in event-handler to receive DoPE-events
                MyEdc[CDeviceID].Eh.OnLineHdlr += new DoPE.OnLineHdlr(Myevent[CDeviceID].OnLine);
#if ONDATABLOCK
                MyEdc[CDeviceID].Eh.OnDataBlockHdlr += new DoPE.OnDataBlockHdlr(Myevent[CDeviceID].OnDataBlock);
                // Set number of samples for OnDataBlock events
                // (with 1 ms data refresh rate this leads to a
                //  display refresh every 300 ms)
                error = MyEdc[CDeviceID].Eh.SetOnDataBlockSize(100);
                DisplayError(error, "SetOnDataBlockSize");
#else
                MyEdc[CDeviceID].Eh.OnDataHdlr += new DoPE.OnDataHdlr(Myevent[CDeviceID].OnData);
#endif
                MyEdc[CDeviceID].Eh.OnCommandErrorHdlr += new DoPE.OnCommandErrorHdlr(Myevent[CDeviceID].OnCommandError);
                MyEdc[CDeviceID].Eh.OnPosMsgHdlr += new DoPE.OnPosMsgHdlr(Myevent[CDeviceID].OnPosMsg);
                MyEdc[CDeviceID].Eh.OnTPosMsgHdlr += new DoPE.OnTPosMsgHdlr(Myevent[CDeviceID].OnTPosMsg);
                MyEdc[CDeviceID].Eh.OnLPosMsgHdlr += new DoPE.OnLPosMsgHdlr(Myevent[CDeviceID].OnLPosMsg);
                MyEdc[CDeviceID].Eh.OnSftMsgHdlr += new DoPE.OnSftMsgHdlr(Myevent[CDeviceID].OnSftMsg);
                MyEdc[CDeviceID].Eh.OnOffsCMsgHdlr += new DoPE.OnOffsCMsgHdlr(Myevent[CDeviceID].OnOffsCMsg);
                MyEdc[CDeviceID].Eh.OnCheckMsgHdlr += new DoPE.OnCheckMsgHdlr(Myevent[CDeviceID].OnCheckMsg);
                MyEdc[CDeviceID].Eh.OnShieldMsgHdlr += new DoPE.OnShieldMsgHdlr(Myevent[CDeviceID].OnShieldMsg);
                MyEdc[CDeviceID].Eh.OnRefSignalMsgHdlr += new DoPE.OnRefSignalMsgHdlr(Myevent[CDeviceID].OnRefSignalMsg);
                MyEdc[CDeviceID].Eh.OnSensorMsgHdlr += new DoPE.OnSensorMsgHdlr(Myevent[CDeviceID].OnSensorMsg);
                MyEdc[CDeviceID].Eh.OnIoSHaltMsgHdlr += new DoPE.OnIoSHaltMsgHdlr(Myevent[CDeviceID].OnIoSHaltMsg);
                MyEdc[CDeviceID].Eh.OnKeyMsgHdlr += new DoPE.OnKeyMsgHdlr(Myevent[CDeviceID].OnKeyMsg);
                MyEdc[CDeviceID].Eh.OnRuntimeErrorHdlr += new DoPE.OnRuntimeErrorHdlr(Myevent[CDeviceID].OnRuntimeError);
                MyEdc[CDeviceID].Eh.OnOverflowHdlr += new DoPE.OnOverflowHdlr(Myevent[CDeviceID].OnOverflow);
                MyEdc[CDeviceID].Eh.OnSystemMsgHdlr += new DoPE.OnSystemMsgHdlr(Myevent[CDeviceID].OnSystemMsg);
                MyEdc[CDeviceID].Eh.OnDebugMsgHdlr += new DoPE.OnDebugMsgHdlr(Myevent[CDeviceID].OnDebugMsg);
                MyEdc[CDeviceID].Eh.OnRmcEventHdlr += new DoPE.OnRmcEventHdlr(Myevent[CDeviceID].OnRmcEvent);

                MyEdc[CDeviceID].Rmc.Enable(-1, -1);




                //if (CDeviceID ==1)
                {


                }

                // Set UserScale
                DoPE.UserScale userScale = new DoPE.UserScale();
                // set position and extension scale to mm
                userScale[DoPE.SENSOR.SENSOR_S] = 1000;
                userScale[DoPE.SENSOR.SENSOR_F] = 0.001;
                userScale[DoPE.SENSOR.SENSOR_E] = 1000;

                // Select machine setup and initialize
                error = MyEdc[CDeviceID].Setup.SelSetup(DoPE.SETUP_NUMBER.SETUP_1, userScale, ref Myevent[CDeviceID].MyTan, ref Myevent[CDeviceID].MyTan);

                //if (CDeviceID == 0)
                {
                    DoPE.Setup ss1 = default(DoPE.Setup);

                    MyEdc[CDeviceID].Setup.RdSetupAll(DoPE.SETUP_NUMBER.SETUP_1, ref ss1);





                }


                if (error != DoPE.ERR.NOERROR)
                    DisplayError(error, "Device" + CDeviceID.ToString() + " " + "SelectSetup");
                else
                {
                    Display("Device" + CDeviceID.ToString() + " " + "SelectSetup : OK !\n");
                    //mtimer.Interval = 10;
                    //mtimer.Enabled = true;


                }





            }
            catch (DoPEException ex)
            {
                // During the initialization and the
                // shut-down phase a DoPE Exception can arise.
                // Other errors are reported by the DoPE
                // error return codes.
                Display(string.Format("{0}\n", ex));
                fConnected = false;
                
                return;
            }

            fConnected = true;

            Cursor.Current = Cursors.Default;


        }

        public void DeviceOn(int CDeviceID)
        {
            try
            {

                DoPE.ERR error = MyEdc[CDeviceID].Move.On();
                DisplayError(error, "On");

                MyEdc[CDeviceID].Data.CtrlTestValues(true);
            }
            catch (NullReferenceException)
            {
                Display(CommandFailedString);

            }

        }

        public void DeviceOff(int CDeviceID)
        {
            try
            {

                DoPE.ERR error = MyEdc[CDeviceID].Move.Off();
                DisplayError(error, "Off");
            }
            catch (NullReferenceException)
            {
                Display(CommandFailedString);
            }


        }

        [MarshalAs(UnmanagedType.FunctionPtr)]

        public short DeviceNum = 0;

        private RawDataStruct b;

        private double mstarttime;


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

        private double mspeed_mtime0;
        private double mspeed_mtime1;



        private Boolean mrun = false;//函数执行后置位



        public List<CComLibrary.CmdSeg> mrunlist;



        public double mrunstarttime = 0;

        private Boolean m_limit = false;//硬限位


        private Boolean m_EmergencyStop = false;//急停



       

       

        private double m_keeptime;//保持时间

        private double m_keepstarttime;//开始保持时时间

        private bool m_keepstart = false;//开始保持







        private int m_returnstep;//返回步骤
        private int m_returncount;//返回次数


        public int rrr = 0;
        public int www = 0;
        public override void setrunstate(int m)
        {
            //m_runstate = m;
        }

        private List<demodata> mdemodata = new List<demodata>();




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

               
            }

            return m_Global.m_runstate;
        }



        public override int ConvertCtrlMode(int ctrl)
        {
            DoPE.CTRL t = default(DoPE.CTRL);
            if (ctrl == 0) //位移
            {

                t = DoPE.CTRL.POS;
            }
            if (ctrl == 1)  //负荷
            {
                t = DoPE.CTRL.LOAD;
            }

            if (ctrl == 2) //变形
            {
                t = DoPE.CTRL.EXTENSION;
            }

            return Convert.ToInt16(t);
        }
       
        public CDOLI()
        {
            int i;

            mstarttickcount = Environment.TickCount;

            myeventmsg = new EventMsg[16];

            mydata = new Queue<DoPE.Data>[16];

            fcontrolmode = new int[16];
            EdcId = new int[16];
            MyEdc = new Edc[16];

            Myevent = new DoPeEvent[16];

            oldcount = new int[16];
            m_oldcount = new int[16];
            for (i = 0; i < 16; i++)
            {
                Myevent[i] = new DoPeEvent();

                Myevent[i].ID = i;

                Myevent[i].myedc = MyEdc[i];


                myeventmsg[i] = new EventMsg();
                mydata[i] = new Queue<DoPE.Data>();
                oldcount[i] = 0;
                m_oldcount[i] = 0;

            }


            GGMsg = new MDataInfo();

            mtimer = new System.Windows.Forms.Timer();
            mtimer.Tick += new EventHandler(mtimer_Tick);
            mtimer.Interval = 50;
            mtimer.Enabled = true;
            mtimer.Start();
            /*
             uhat = new UltraHighAccurateTimer.UltraHighAccurateTimer();
             uhat.Interval = 10;  //定时间隔1毫秒
             uhat.Tick += new UltraHighAccurateTimer.UltraHighAccurateTimer.ManualTimerEventHandler(uhat_Tick);
             uhat.Start();
             */
        }
        private void uhat_Tick(object sender)
        {
            
            if (mstartcontrol == true)
            {

                MyEdc[DeviceNum].Data.CurrentData(ref mcurrentdata);
              
                m_Global.mwave   = mstartcontrolpos  +5*Math.Sin((mcurrentdata.Time - mstartcontroltime)* 0.3);

              //  MyEdc[DeviceNum].Move.Pos(DoPE.CTRL.POS, 10, m_Global.mwave, ref Myevent[DeviceNum].MyTan);

               

                /*
                if (mcurrentdata.Sensor[0]<m_Global.mwave)
                {
                    MyEdc[DeviceNum].Move.FMove(DoPE.MOVE.UP, DoPE.CTRL.POS, 1, ref Myevent[DeviceNum].MyTan);

                }

                else
                {
                    MyEdc[DeviceNum].Move.FMove(DoPE.MOVE.DOWN, DoPE.CTRL.POS, 1, ref Myevent[DeviceNum].MyTan);
                }*/

            }
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

        private void demo()
        {

            int j;
            int i;
            int jj;
            int ii;

            Random r;
            r = new Random(System.Environment.TickCount);
            b = new RawDataStruct();
            b.data = new double[24];
            if (mdemotesting == false)
            {
               
                load = r.NextDouble();
                pos = r.NextDouble();
                ext = r.NextDouble();
                time = (System.Environment.TickCount-mstarttickcount) / 1000;
                poscmd = 0;
                loadcmd = 0;
                extcmd = 0;
                count = 0;
                load1 = r.NextDouble();
                pos1 = r.NextDouble();

            }
            else
            {
                
                load = r.NextDouble();
                pos = r.NextDouble();
                ext = r.NextDouble();
                time = (System.Environment.TickCount-mstarttickcount) / 1000;
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

            ClsStaticStation.m_Global.mload1 = load1;
            ClsStaticStation.m_Global.mpos1 = pos1;

            ClsStaticStation.m_Global.msensor4 = r.NextDouble() + 1;

            ClsStaticStation.m_Global.msensor5 = r.NextDouble() + 2;

            ClsStaticStation.m_Global.msensor6 = r.NextDouble() + 3;


            ClsStaticStation.m_Global.msensor7 = r.NextDouble() + 4;

            ClsStaticStation.m_Global.msensor8 = r.NextDouble() + 5;
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

                ii = this.Myevent[0].mdatalist.Count;

                for (jj = 0; jj < ii; jj++)
                {



                    GGMsg = this.Myevent[0].mdatalist[jj];




                    b = new RawDataStruct();
                    b.data = new double[24];

                    if (this.Myevent[0].mdatalist[jj].Id == DeviceNum)
                    {
                        time = GGMsg.mydatainfo.Time;
                        pos = GGMsg.mydatainfo.Sensor[(int)DoPE.SENSOR.SENSOR_S];
                        load = GGMsg.mydatainfo.Sensor[(int)DoPE.SENSOR.SENSOR_F];

                        //load = GGMsg.mwave;
                        ext = GGMsg.mydatainfo.Sensor[(int)DoPE.SENSOR.SENSOR_E];

                        poscmd = GGMsg.mydatainfo.Test1;

                        time = GGMsg.mydatainfo.Time;
                        moritime = time;

                        time = time - mstarttime;

                        count = GGMsg.mydatainfo.Cycles / 2;


                    }



                    else if (Myevent[1].mdatalist[jj].Id == 1)
                    {
                        load1 = 0;
                        pos1 = 0;

                    }



                    //自定义通道赋值
                    ClsStaticStation.m_Global.mload = load;

                    ClsStaticStation.m_Global.mpos = pos;

                    ClsStaticStation.m_Global.mext = ext;

                    ClsStaticStation.m_Global.msensor4 = GGMsg.mydatainfo.Sensor[(int)DoPE.SENSOR.SENSOR_3];
                    ClsStaticStation.m_Global.msensor5 = GGMsg.mydatainfo.Sensor[(int)DoPE.SENSOR.SENSOR_4];
                    ClsStaticStation.m_Global.msensor6 = GGMsg.mydatainfo.Sensor[(int)DoPE.SENSOR.SENSOR_6];
                    ClsStaticStation.m_Global.msensor7 = GGMsg.mydatainfo.Sensor[(int)DoPE.SENSOR.SENSOR_7];
                    ClsStaticStation.m_Global.msensor8 = GGMsg.mydatainfo.Sensor[(int)DoPE.SENSOR.SENSOR_8];

                    ClsStaticStation.m_Global.mload1 = load1;
                    ClsStaticStation.m_Global.mpos1 = pos1;



                    ma = ma + 1;


                    if (ma >= 10)

                    //if (time - mspeed_time0 >= 0.01)
                    {


                        mspeed_load1 = (load - mspeed_load0) / (time - mspeed_time0);
                        mspeed_pos1 = (GGMsg.mtime - mspeed_mtime0);
                        mspeed_time0 = time;
                        mspeed_load0 = load;
                        mspeed_pos0 = pos;
                        mspeed_mtime0 = GGMsg.mtime;
                        ma = 0;

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


                this.Myevent[0].mdatalist.Clear();

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



        public override void starttest(int spenum)
        {
            short k = 0;
            RawDataDataGroup d;


            m_Global.m_runstate = 0;

            mstarttime = moritime;


            bool b = false;
            while (b == false)
            {
                Application.DoEvents();
                if (time < 10)
                {
                    b = true;
                }
            }

            int iii = 0;

            int a = ClsStatic.arraydata[0].NodeCount;

            while (iii < a)
            {


                ClsStatic.arraydata[0].Read<RawDataDataGroup>(out d, 0);

                iii = iii + 1;


            }

            iii = 0;

            a = ClsStatic.arraydata[1].NodeCount;
            while (iii < a)
            {


                ClsStatic.arraydata[1].Read<RawDataDataGroup>(out d, 0);

                iii = iii + 1;


            }

            ClsStatic.arraydatacount[0] = 0;
            ClsStatic.arraydatacount[1] = 0;


            mspeed_time0 = 0;
            mspeed_time1 = 0;
            mspeed_load0 = 0;
            mspeed_load1 = 0;
            mspeed_pos0 = 0;
            mspeed_pos1 = 0;
            mspeed_mtime0 = 0;
            mspeed_mtime1 = 0;

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
                    k, Convert.ToSingle(mrunlist[mcurseg].speedorigin()), 0, 0, 0, 0,mrunlist[mcurseg].destmode);






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
                        n.mseq.wavekind = sqf.mSequencelist[i].wavekind;
                        n.mseq.stepname = sqf.mSequencelist[i].stepname;
                        n.mseq = sqf.mSequencelist[i];
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

                    if (sqf.mSequencelist[i].wavekind == 3) //正弦波
                    {
                        n.keeptime = sqf.mSequencelist[i].keeptime;
                     
                        n.mseq = sqf.mSequencelist[i];
                        n.mseq.wavekind = sqf.mSequencelist[i].wavekind;
                        n.mseq.stepname  = sqf.mSequencelist[i].stepname ;
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


                    if (ii == mcurseg)
                    {
                        segstep(mrunlist[ii].cmd, mrunlist[ii].destorigin(),
                   Convert.ToInt16(mrunlist[ii].controlmode),
                    Convert.ToInt16(mrunlist[ii].destcontrolmode),
                   k, Convert.ToSingle(mrunlist[ii].speedorigin()),
                   mrunlist[ii].keeptime, mrunlist[ii].returnstep, mrunlist[ii].returncount, mrunlist[ii].action,mrunlist[ii].destmode);

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
                          mrunlist[ii].keeptime, mrunlist[ii].returnstep, mrunlist[ii].returncount, mrunlist[ii].action,mrunlist[ii].destmode);

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
                       mrunlist[ii].keeptime, mrunlist[ii].returnstep, mrunlist[ii].returncount, mrunlist[ii].action,mrunlist[ii].destmode);

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

        public override void segstep(int cmd, double dest, short firstctl, short destctl, short destkeepstyle, float speed, double keeptime, int reurnstep, int returncount, int action,int destmode)
        {
            bool b = false;
            short m;
            m_keeptime = keeptime;
            m_keepstart = false;
            keepingstate = false;

            short tan = 0;

            m_returncount = returncount;
            m_returnstep = reurnstep;
            if (m_returncount > 0)
            {
                total_returncount = m_returncount;

            }

            if (mdemo == true)
            {
                m_Global.m_runstate = 0;
            }
            else
            {
                if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 3)
                {
                    if (mrunlist[mcurseg].mseq.wavekind <= 0)
                    {
                        m_Global.m_runstate = 1;

                        MyEdc[DeviceNum].Move.PosExt((DoPE.CTRL)ConvertCtrlMode(firstctl), Convert.ToSingle(speed), DoPE.LIMITMODE.NOT_ACTIVE, 5, (DoPE.CTRL)ConvertCtrlMode(destctl)
                            , Convert.ToSingle(dest), DoPE.DESTMODE.DEST_POSITION, ref tan);

                    }

                    if (mrunlist[mcurseg].mseq.wavekind == 1)
                    {
                        m_Global.m_runstate = 0;
                    }

                    if (mrunlist[mcurseg].mseq.wavekind == 2)

                    {
                        m_Global.m_runstate = 1;
                        double m_speed = Convert.ToDouble(m_Global.mycls.hardsignals[mrunlist[mcurseg].controlmode].speedSignal.GetOriValue(mrunlist[mcurseg].mseq.mtrirate, mrunlist[mcurseg].mseq.mtrirateunit));
                        double m_dest1 = mrunlist[mcurseg].mseq.mtrimax;
                        double m_dest2 = mrunlist[mcurseg].mseq.mtrimin;


                        MyEdc[DeviceNum].Move.Cycle((DoPE.CTRL)mrunlist[mcurseg].mseq.controlmode, m_speed, m_dest1, 0, m_speed, m_dest2, 0, Convert.ToInt32( mrunlist[mcurseg].mseq.mcount- mrunlist[mcurseg].mseq.mfinishedcount), m_speed, m_dest2, ref tan);
                    }


                    if (mrunlist[mcurseg].mseq.wavekind == 3)

                    {
                        m_Global.m_runstate = 1;
                        double m_speed = Convert.ToDouble(m_Global.mycls.hardsignals[mrunlist[mcurseg].controlmode].speedSignal.GetOriValue(mrunlist[mcurseg].mseq.msinrate, mrunlist[mcurseg].mseq.msinrateunit));
                        double m_dest1 = mrunlist[mcurseg].mseq.msinmax;
                        double m_dest2 = mrunlist[mcurseg].mseq.mtrimin;

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


                        MyEdc[DeviceNum].Move.DynCycles(DoPE.DYN_WAVEFORM.COSINE,false, (DoPE.DYN_PEAKCTRL)0, (DoPE.CTRL)mrunlist[mcurseg].mseq.controlmode, false, m_speed, m_offset, m_amp,0,0,
                            mrunlist[mcurseg].mseq.msinfreq, Convert.ToInt32( mrunlist[mcurseg].mseq.mcount- mrunlist[mcurseg].mseq.mfinishedcount), m_speed, m_offset,DoPE.DYN_SWEEP.OFF,0,0,0,DoPE.DYN_SWEEP.OFF,0,0,0,DoPE.DYN_SWEEP.OFF,0,0,0,
                            DoPE.DYN_SUPERPOS.OFF,0,0,DoPE.DYN_BIMODAL.CTRL_OFF,DoPE.SENSOR.SENSOR_S,0,0,0, ref tan);
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

                        m_Global.m_runstate = 1;
                        m = Myevent[DeviceNum].MyTan;


                        MyEdc[DeviceNum].Move.PosExt((DoPE.CTRL)ConvertCtrlMode(firstctl), Convert.ToSingle(speed), DoPE.LIMITMODE.NOT_ACTIVE, 5, (DoPE.CTRL)ConvertCtrlMode(destctl)
                            , Convert.ToSingle(dest), DoPE.DESTMODE.DEST_POSITION, ref Myevent[DeviceNum].MyTan);



                        if (m != Myevent[DeviceNum].MyTan)
                        {

                            mrun = true;
                        }

                    }
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
                      

                            if (current_returncount >= m_returncount)
                            {
                                mcurseg = mcurseg + 1;
                                total_returncount = 0;
                                current_returncount = 0;

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
                                    segstep(mrunlist[ii].cmd, mrunlist[ii].destorigin(),
                                       Convert.ToInt16(mrunlist[ii].controlmode),
                                         Convert.ToInt16(mrunlist[ii].destcontrolmode),
                                        k, Convert.ToSingle(mrunlist[ii].speedorigin()),
                                      mrunlist[ii].keeptime, mrunlist[ii].returnstep, mrunlist[ii].returncount, mrunlist[ii].action,mrunlist[ii].destmode);
                                }
                                else
                                {
                                    if (ii == mcurseg)
                                    {
                                        segstep(mrunlist[ii].cmd, mrunlist[ii].destorigin(),
                                   Convert.ToInt16(mrunlist[ii].controlmode),
                                    Convert.ToInt16(mrunlist[ii].destcontrolmode),
                                   k, Convert.ToSingle(mrunlist[ii].speedorigin()),
                                   mrunlist[ii].keeptime, mrunlist[ii].returnstep, mrunlist[ii].returncount, mrunlist[ii].action,mrunlist[ii].destmode);

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


            ConnectToEdc(0);


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

        public override  void btnzero(Button b)
        {
            if (b.Text == "位移")
            {

                
                MyEdc[DeviceNum].Tare.SetTare(DoPE.SENSOR.SENSOR_S, pos);

            }

            if (b.Text == "力")
            {
                MyEdc[DeviceNum].Tare.SetTare(DoPE.SENSOR.SENSOR_F, load );

            }

            if (b.Text == "变形")
            {
                MyEdc[DeviceNum].Tare.SetTare(DoPE.SENSOR.SENSOR_E, ext );
            }

            if (b.Text == "围压位移")
            {

            }

            if (b.Text == "围压负荷")
            {


            }





        }

        public override void restorezero(Button b)
        {
            if (b.Text == "位移")
            {
                MyEdc[DeviceNum].Tare.SetTare(DoPE.SENSOR.SENSOR_S, 0);

            }

            if (b.Text == "力")
            {
                MyEdc[DeviceNum].Tare.SetTare(DoPE.SENSOR.SENSOR_F, 0);
            }
            if (b.Text == "变形")
            {
                MyEdc[DeviceNum].Tare.SetTare(DoPE.SENSOR.SENSOR_E, 0);
            }


        }







        public override int CloseConnection()
        {

            return 0;
        }
        public override int OpenConnection()
        {






            return 0;


        }
    }

}

