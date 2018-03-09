using System;
using System.Collections.Generic;
using System.Text;
using ECAN;
using System.Threading;
namespace ECanTest
{
    public  struct xyz
    {
        public double x;
        public double y;
        public double z;
        public double t;

    };

    class ComProc
    {
        xyz p = new xyz();
        uint i = 0;
        static double mad0 =0;
        static double mad1 = 0;
        static double mad2 = 0;
        static double m_starttime = 0;
        // Fields
        public bool EnableProc;

        public const int REC_MSG_BUF_MAX = 0x2710;


        public CAN_OBJ[] gRecMsgBuf;
        public uint gRecMsgBufHead;
        public uint gRecMsgBufTail;

        public CAN_OBJ[] gRecMsgBuf2;
        public uint gRecMsgBufHead2;
        public uint gRecMsgBufTail2;

        public const int SEND_MSG_BUF_MAX = 0x2710;

        public CAN_OBJ[] gSendMsgBuf;
        public uint gSendMsgBufHead;
        public uint gSendMsgBufTail;

        public CAN_OBJ[] gSendMsgBuf2;
        public uint gSendMsgBufHead2;
        public uint gSendMsgBufTail2;



        private Timer _RecTimer;
        private Timer _SendTimer;

        private AutoResetEvent RecEvent;
        private TimerCallback RecTimerDelegate;
        private AutoResetEvent SendEvent;
        private TimerCallback SendTimerDelegate;


      
        public ComProc(uint i)
        {
            this.i = i;
            this.gSendMsgBuf = new CAN_OBJ[SEND_MSG_BUF_MAX];
            this.gSendMsgBufHead = 0;
            this.gSendMsgBufTail = 0;

            this.gSendMsgBuf2 = new CAN_OBJ[SEND_MSG_BUF_MAX];
            this.gSendMsgBufHead2 = 0;
            this.gSendMsgBufTail2 = 0;

            this.gRecMsgBuf = new CAN_OBJ[REC_MSG_BUF_MAX];
            this.gRecMsgBufHead = 0;
            this.gRecMsgBufTail = 0;

            this.gRecMsgBuf2 = new CAN_OBJ[REC_MSG_BUF_MAX];
            this.gRecMsgBufHead2 = 0;
            this.gRecMsgBufTail2 = 0;


            this.EnableProc = false;
            this.RecEvent = new AutoResetEvent(false);
            this.RecTimerDelegate = new TimerCallback(this.RecTimer_Tick);
            this._RecTimer = new Timer(this.RecTimerDelegate, this.RecEvent, 0, 25);
            this.SendEvent = new AutoResetEvent(false);
            this.SendTimerDelegate = new TimerCallback(this.SendTimer_Tick);
            this._SendTimer = new Timer(this.SendTimerDelegate, this.SendEvent, 0, 20);

        }


        private void ReadMessagesold()
        {
            CAN_OBJ mMsg = new CAN_OBJ();
            int m = 0;
            int sCount = 0;
            do
            {
                uint mLen = 1;
                if (!((ECANDLL.Receive(1, i, 0, out mMsg, mLen, 1) == ECANStatus.STATUS_OK) & (mLen > 0)))
                {
                    break;
                }

                // m = m + 1;

                //if (m == 5)
                {

                    m = 0;
                    this.gRecMsgBuf[this.gRecMsgBufHead].ID = mMsg.ID;
                    this.gRecMsgBuf[this.gRecMsgBufHead].DataLen = mMsg.DataLen;
                    this.gRecMsgBuf[this.gRecMsgBufHead].data = mMsg.data;
                    this.gRecMsgBuf[this.gRecMsgBufHead].ExternFlag = mMsg.ExternFlag;
                    this.gRecMsgBuf[this.gRecMsgBufHead].RemoteFlag = mMsg.RemoteFlag;




                    this.gRecMsgBufHead += 1;
                    if (this.gRecMsgBufHead >= REC_MSG_BUF_MAX)
                    {
                        this.gRecMsgBufHead = 0;
                    }




                    sCount++;
                }

            }
            while (sCount < 50);
        }

        private void ReadMessages()
        {
            
            int m = 0;
            int sCount = 0;
            do
            {
                CAN_OBJ mMsg = new CAN_OBJ();
                mMsg.ID = 0;

                uint mLen = 1;

                if ((ECANDLL.Receive(1, i, 0, out mMsg, mLen, 0) == ECANStatus.STATUS_OK))
                {
                    
                }
                else
                {
                    break;
                }
              

                    if (mMsg.ID == 0x139)
                    {
                        mad0 = (mMsg.data[0] + mMsg.data[1] * 256) / 1000.0;

                    }

                    if (mMsg.ID == 0x141)
                    {
                        mad1 = (mMsg.data[0] + mMsg.data[1] * 256) / 1000.0;


                    }
                    if (mMsg.ID == 0x143)
                    {
                        mad2 = (mMsg.data[0] + mMsg.data[1] * 256) / 1000.0;

                        m_starttime = m_starttime + 0.01;
                        
                        p.x = mad0;
                        p.y = mad1;
                        p.z = mad2;
                        p.t = m_starttime;

                        ClsStaticStation.m_Global.madlist.Add(p);

                   


                }

                sCount++;



            }
            while (sCount < 500);
        }



        private void ReadMessages2()
        {
            CAN_OBJ mMsg = new CAN_OBJ();

            int sCount = 0;
            do
            {
                uint mLen = 1;
                if (!((ECANDLL.Receive(1, i, 1, out mMsg, mLen, 0) == ECANStatus.STATUS_OK) & (mLen > 0)))
                {
                    break;
                }

                this.gRecMsgBuf2[this.gRecMsgBufHead2].ID = mMsg.ID;
                this.gRecMsgBuf2[this.gRecMsgBufHead2].DataLen = mMsg.DataLen;
                this.gRecMsgBuf2[this.gRecMsgBufHead2].data = mMsg.data;
                this.gRecMsgBuf2[this.gRecMsgBufHead2].ExternFlag = mMsg.ExternFlag;
                this.gRecMsgBuf2[this.gRecMsgBufHead2].RemoteFlag = mMsg.RemoteFlag;
               

                if ((mMsg.ID == 0x141) || (mMsg.ID == 0x139) || (mMsg.ID == 0x143))
                {
                    this.gRecMsgBufHead2 += 1;
                    if (this.gRecMsgBufHead2 >= REC_MSG_BUF_MAX)
                    {
                        this.gRecMsgBufHead2 = 0;
                    }
                }
                sCount++;

                
            }
            while (sCount < 500);
        }


        private void SendMessages()
        {
            int sCount = 0;
            do
            {
                if (this.gSendMsgBufHead == this.gSendMsgBufTail)
                {
                    break;
                }
                CAN_OBJ mMsg = this.gSendMsgBuf[this.gSendMsgBufTail];
                this.gSendMsgBufTail += 1;
                if (this.gSendMsgBufTail >= SEND_MSG_BUF_MAX)
                {
                    this.gSendMsgBufTail = 0;
                }
                uint mLen = 1;
                if (ECANDLL.Transmit(1, i, 0, ref mMsg, (ushort)mLen) != ECANStatus.STATUS_OK)
                {
                }
                sCount++;
            }
            while (sCount < 200);
        }

        private void SendMessages2()
        {
            int sCount = 0;
            do
            {
                if (this.gSendMsgBufHead2 == this.gSendMsgBufTail2)
                {
                    break;
                }
                CAN_OBJ mMsg = this.gSendMsgBuf2[this.gSendMsgBufTail2];
                this.gSendMsgBufTail2 += 1;
                if (this.gSendMsgBufTail2 >= SEND_MSG_BUF_MAX)
                {
                    this.gSendMsgBufTail2 = 0;
                }
                uint mLen = 1;
                if (ECANDLL.Transmit(1, i, 1, ref mMsg, (ushort)mLen) != ECANStatus.STATUS_OK)
                {
                }
                sCount++;
            }
            while (sCount < 200);
        }


        public void RecTime()
        {
            if (this.EnableProc)
            {
                this.ReadMessages();
                this.ReadMessages2();
            }
        }

        private void RecTimer_Tick(object mObject)
        {
            this.RecTime();
           
        }

        private void SendTimer_Tick(object mObject)
        {
            this.SendTime();
        }


        public void SendTime()
        {
            if (this.EnableProc)
            {
                this.SendMessages();
                this.SendMessages2();
            
            }
        }




        public void Close()
        {
        }

 
    }
}
