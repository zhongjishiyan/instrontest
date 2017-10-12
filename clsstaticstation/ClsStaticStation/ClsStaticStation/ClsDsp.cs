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
        public long acount = 0;
        private float[] rr;
        private System.Windows.Forms.Timer mtimer;
        public XLNet.XLDOPE.Data  GGMsg;
        private RawDataStruct b;
        public short DeviceNum = 1;


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


        public XLDOPE.Edc myedc;


      


        private List<XLDOPE.MDataIno> mdatalist;


        public long oncount = 0;

    
       

        public override void starttest()
        {

        }
        public override void endtest()
        {

        }
        public override void demotest(bool testing)
        {
        }
        public override void readdemo(string fileName)
        {
        }
        public override int ConvertCtrlMode(int ctrl)
        {
            int t = 0;


            return t;
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
        }

        public CDsp()
        {
            rr = new float[10];
            GGMsg = new XLDOPE.Data();
            mdatalist = new List<XLDOPE.MDataIno>();
          
            mtimer = new System.Windows.Forms.Timer();
            mtimer.Tick += new EventHandler(mtimer_Tick);
            mtimer.Interval = 20;


            try
            {
                myedc = new XLDOPE.Edc();

            }
            catch (System.BadImageFormatException)
            {


            }

            myedc.Eh.OnHandlerFuncHdlr += new XLDOPE.OnHandlerFuncHdlr(Eh_OnHandlerFuncHdlr);


            myedc.Eh.OnDataHdlr += new XLDOPE.OnDataHdlr(Eh_OnDataHdlr);
            myedc.Eh.OnDataBlockHdlr += new XLDOPE.OnDataBlockHdlr(Eh_OnDataBlockHdlr);
            myedc.Eh.OnPosMsgHdlr +=new XLDOPE.OnPosMsgHdlr( Eh_OnPosMsgHdlr);

        }

        private int Eh_OnPosMsgHdlr(ref XLDOPE.OnPosMsg OnPosMsg, object Parameter)
        {

            return 0;
        }

        private int Eh_OnDataBlockHdlr(ref XLDOPE.OnDataBlock OnDataBlock, object Parameter)
        {
            oncount = oncount + 1;
            return 0;
        }

        private void  Eh_OnDataHdlr(ref XLDOPE.OnData m)
        {
            //oncount = (int) m.Data.Time;
            return ;
        }

        private void Eh_OnHandlerFuncHdlr(int NamelessParameter1, int NamelessParameter2, int NamelessParameter3)
        {
           // oncount = oncount + 1;
            return;
        }

        void mtimer_Tick(object sender, EventArgs e)
        {
            XLDOPE.Data m= new XLDOPE.Data();
           

            myedc.Data.CurrentData(ref m);
           

            acount = acount + 1;


            XLDOPE.XL_recvData();

            ma = new XLDOPE.MDataIno();
            ma.Id = 0;
            ma.mydatainfo = m;
            mdatalist.Add(ma);



            Timer();
        }

        void Timer()
        {
            int j;
            int i;
            int jj;
            int ii;

            if (mdemo == true)
            {

            }
            else
            {

                ii = mdatalist.Count;

                for (jj = 0; jj < ii; jj++)
                {



                    GGMsg = mdatalist[jj].mydatainfo;

                    b = new RawDataStruct();
                    b.data = new double[24];



                    load = GGMsg.Sensor[0];
                    pos = oncount ;
                    ext = GGMsg.Sensor[2];
                    poscmd = 0;
                    loadcmd = 0;
                    extcmd = 0;
                    time = GGMsg.Time;
                    count = 0;





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

