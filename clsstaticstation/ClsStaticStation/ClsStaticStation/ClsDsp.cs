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

namespace ClsStaticStation
{
   
    public sealed class a1100
    {
        public class EVENT_INFO
        {
            public int specVal; //特征值
            public HandlerFunc_t cbHandlerFunc;
            public int handle;
            public int param2;
            public IntPtr param3;
        }


        public struct DataInfo
        {
            public float c0;
            public float c1;
            public float c2;
            public float c3;
            public float c4;
            public float c5;
            public float c6;
            public float c7;
            public float c8;
            public float c9;

        }

        public struct MDataIno
        {
            public int Id;
            public DataInfo mydatainfo;
        }


        public  delegate uint HandlerFunc_t(int NamelessParameter1, int NamelessParameter2, IntPtr NamelessParameter3);


        [DllImport("XLWinPcap.dll")]
        public static extern Int32 XL_init();

        [DllImport("XLWinPcap.dll")]
        public static extern Int32 XL_setNetCardIndex(int cardIndex);

        [DllImport("XLWinPcap.dll")]
        public static extern Int32 XL_start(int cardIndex);

        [DllImport("XLWinPcap.dll")]
        public static extern Int32 XL_recv( float[] fpdate);

        [DllImport("XLWinPcap.dll")]
        public static extern Int32 XL_stop();

        [DllImport("XLWinPcap.dll")]
        public static extern Int32 XL_free();

        [DllImport("XLWinPcap.dll")]

        public static extern Int32 XL_addEvent(out EVENT_INFO eventInfo);

        [DllImport("XLWinPcap.dll")]

        public static extern Int32 XL_delEvent(  EVENT_INFO eventInfo);

       


    }

    

   public  class CDsp : ClsBaseControl
    {
       public long acount = 0;
       private float[] rr; 
        private System.Windows.Forms.Timer mtimer;
        public a1100.DataInfo GGMsg;
        private RawDataStruct b;
        public short DeviceNum = 1;


        private a1100.MDataIno ma;
        private a1100.DataInfo ww;

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

      

       
       

        
        private List<a1100.MDataIno> mdatalist;


        public long oncount = 0;


        public uint OnData(int NamelessParameter1, int NamelessParameter2, IntPtr NamelessParameter3)
        {
            oncount = oncount + 1;

            return 0;

        }

        public void starttest()
        {

        }
        public void endtest()
        {

        }
        public void demotest(bool testing)
        {
        }
        public void readdemo(string fileName)
        {
        }
        public int ConvertCtrlMode(int ctrl)
        {
            int t = 0;
          

            return t;
        }
        public bool getlimit()
        {
            return false;
        }

        public bool getEmergencyStop()
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

        public void setrunstate(int m)
        {

        }

        public void segstep(int cmd, double dest, short firstctl, short destctl, short destkeepstyle, float speed, double keeptime, int reurnstep, int returncount)
        {

        }
        public CDsp()
        {
            rr = new float[10];
            GGMsg = new a1100.DataInfo();
            mdatalist = new List<a1100.MDataIno>();
            ww = new a1100.DataInfo();
            mtimer = new System.Windows.Forms.Timer();
            mtimer.Tick += new EventHandler(mtimer_Tick);
            mtimer.Interval = 20;

            a1100.EVENT_INFO p = new a1100.EVENT_INFO();

            p.specVal = 10;
            p.param2 = 0;
            p.param3 = (IntPtr)0;
            p.handle = 0;
           
            p.cbHandlerFunc = new a1100.HandlerFunc_t(OnData);
            a1100.XL_addEvent(out p);
           
        }
        void mtimer_Tick(object sender, EventArgs e)
        {
           
            a1100.XL_recv(rr);

            acount = acount + 1;

            ww.c0=rr[0];
            ww.c1=oncount;
            ww.c2=rr[2];
            ww.c3=rr[3];
            ww.c4 = rr[4];
            ww.c5 = rr[5];
            ww.c6 = rr[6];
            ww.c7 = rr[7];
            ww.c8 = rr[8];
            ww.c9 = rr[9];

            ma = new a1100.MDataIno();
            ma.Id = 0;
            ma.mydatainfo =ww ;
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

                   

                        load = GGMsg.c0;
                        pos = GGMsg.c1;
                        ext = GGMsg.c2;
                        poscmd = 0;
                        loadcmd = 0;
                        extcmd = 0;
                        time = 0;
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

        public void Init(int handle)
        {
            OpenConnection();
        }

        int OpenConnection()
        {
            a1100.XL_init();
         
            a1100.XL_start(1);


            mtimer.Start();


            return 0;
        }

        public int CloseConnection()
        {
            mtimer.Stop();
            a1100.XL_stop();
            a1100.XL_free();

            return 0;
        }
     }
}

