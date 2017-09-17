using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppleLabApplication
{
    public partial class FormChannel : Form
    {
        Random ran;

        public FormChannel()
        {
            InitializeComponent();
            ran = new Random();
        }

        public void Init_SystemPara通道()
        {

            CComLibrary.SystemPara b;
            string s;
            int i;
            int j;
            CComLibrary.GlobeVal.msyspara.Clear();

            s = "";


            s = s + "\r\n";


            for (j = 0; j < CComLibrary.GlobeVal.filesave.m_namelist.Count; j++)
            {
                b = new CComLibrary.SystemPara();
                b.Name = CComLibrary.GlobeVal.filesave.m_namelist[j] + "通道";

                b.replaceName = b.Name;
                if (CComLibrary.GlobeVal.filesave.m_namelist[j] == "负荷")
                {
                    s = s + "public double " + b.replaceName + "=" + "ClsStaticStation.m_Global.mload" +";" + "\r\n";
                }

                else if (CComLibrary.GlobeVal.filesave.m_namelist[j] == "位移")
                {
                    s = s + "public double " + b.replaceName + "=" + "ClsStaticStation.m_Global.mpos" + ";" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_namelist[j] == "变形")
                {
                    s = s + "public double " + b.replaceName + "=" + "ClsStaticStation.m_Global.mext" + ";" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_namelist[j] == "时间")
                {
                    s = s + "public double " + b.replaceName + "=0;" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_namelist[j] == "围压压力")
                {
                    s = s + "public double " + b.replaceName + "=" + "ClsStaticStation.m_Global.mload1" + ";" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_namelist[j] == "围压位移")
                {
                    s = s + "public double " + b.replaceName + "=" + "ClsStaticStation.m_Global.mpos1" + ";" + "\r\n";
                }

                CComLibrary.GlobeVal.msyspara.Add(b);

            }

            for (j = 0; j < CComLibrary.GlobeVal.filesave.muserchannel.Count; j++)
            {
                b = new CComLibrary.SystemPara();
                b.Name = CComLibrary.GlobeVal.filesave.muserchannel[j].channelname + "通道";

                b.replaceName = b.Name;
                s = s + "public double " + b.replaceName + "=0;" + "\r\n";
                CComLibrary.GlobeVal.msyspara.Add(b);
            }
            

            for (j = 0; j < CComLibrary.GlobeVal.filesave.mshapelist.Count; j++)
            {
                for (i = 0; i < CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem.Length; i++)
                {
                    if (CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem[i].cName != "无")
                    {
                        b = new CComLibrary.SystemPara();
                        b.Name = CComLibrary.GlobeVal.filesave.mshapelist[j].shapename + "_" +
                            CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem[i].cName;
                        b.replaceName = b.Name;
                        s = s + "public double " + b.replaceName + "=" +
                            CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem[i].cvalue.ToString() + ";" + "\r\n";
                        CComLibrary.GlobeVal.msyspara.Add(b);
                    }


                }
            }

            for (i = 0; i < CComLibrary.GlobeVal.filesave.minput.Count; i++)
            {
                b = new CComLibrary.SystemPara();
                b.Name = CComLibrary.GlobeVal.filesave.minput[i].name;
                b.replaceName = b.Name;
                s = s + "public  double " + b.replaceName + "=" + CComLibrary.GlobeVal.filesave.minput[i].value.ToString() + ";" + "\r\n";
                CComLibrary.GlobeVal.msyspara.Add(b);
            }


            CComLibrary.GlobeVal.gcalc.refreshglobe(s);


            s = "";
            for (j = 0; j < CComLibrary.GlobeVal.filesave.m_namelist.Count; j++)
            {
                b = new CComLibrary.SystemPara();
                b.Name = CComLibrary.GlobeVal.filesave.m_namelist[j] + "通道";

                b.replaceName = b.Name;
                if (CComLibrary.GlobeVal.filesave.m_namelist[j] == "负荷")
                {
                    s = s  + b.replaceName + "=" + "ClsStaticStation.m_Global.mload" + ";" + "\r\n";
                }

                else if (CComLibrary.GlobeVal.filesave.m_namelist[j] == "位移")
                {
                    s = s + b.replaceName + "=" + "ClsStaticStation.m_Global.mpos" + ";" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_namelist[j] == "变形")
                {
                    s = s  + b.replaceName + "=" + "ClsStaticStation.m_Global.mext" + ";" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_namelist[j] == "时间")
                {
                    s = s  + b.replaceName + "=0;" + "\r\n";
                }

                else if (CComLibrary.GlobeVal.filesave.m_namelist[j] == "围压压力")
                {
                    s = s  + b.replaceName + "=" + "ClsStaticStation.m_Global.mload1" + ";" + "\r\n";
                }
                else if (CComLibrary.GlobeVal.filesave.m_namelist[j] == "围压位移")
                {
                    s = s  + b.replaceName + "=" + "ClsStaticStation.m_Global.mpos1" + ";" + "\r\n";
                }
              

            }

            CComLibrary.GlobeVal.gcalc.refreshhardglobe(s);

            s = "";
            for (i = 0; i < CComLibrary.GlobeVal.filesave.moutput.Count; i++)
            {
                b = new CComLibrary.SystemPara();
                b.Name = CComLibrary.GlobeVal.filesave.moutput[i].formulaname;
                b.replaceName = b.Name;
                s = s + "public  double " + b.replaceName + "= 0" + ";" + "\r\n";
                CComLibrary.GlobeVal.msyspara.Add(b);
            }


            CComLibrary.GlobeVal.gcalc.refreshresulthard(s);


        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int i, j;
            String s;
            
            int RandKey = ran.Next(100, 999);
           
            ClsStaticStation.m_Global.mload = -RandKey / 10;

            ClsStaticStation.m_Global.mpos = -RandKey / 10;

            ClsStaticStation.m_Global.mload1 =10 -RandKey / 10;

            ClsStaticStation.m_Global.mpos1 = 10-RandKey / 10;


            label1.Text = ClsStaticStation.m_Global.mload.ToString();

            label2.Text = ClsStaticStation.m_Global.mpos.ToString();

          

            double[] rr;

            rr = new double[100];
            for (j = 0; j < CComLibrary.GlobeVal.filesave.muserchannel.Count; j++)
            {
                rr[j] = 0;
            }

            for (j = 0; j < CComLibrary.GlobeVal.filesave.muserchannel.Count; j++)
            {

                //CComLibrary.GlobeVal.gcalc.Initexpr通道(CComLibrary.GlobeVal.filesave.muserchannel[j].channelvalue, j + 1);


               
                rr[j + 1] = CComLibrary.GlobeVal.gcalc.getresult通道(j + 1);

                label5.Text = rr[1].ToString();
                label6.Text = rr[2].ToString();


            }

        }

        private void FormChannel_Load(object sender, EventArgs e)
        {
            int j;
           

            Init_SystemPara通道();
            for (j = 0; j < CComLibrary.GlobeVal.filesave.muserchannel.Count; j++)
            {

                CComLibrary.GlobeVal.gcalc.Initexpr通道(CComLibrary.GlobeVal.filesave.muserchannel[j].channelvalue, j + 1);

            }

            CComLibrary.GlobeVal.gcalc.calc通道();
               
           
            timer1.Enabled = true;
        }

        private void FormChannel_Leave(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
    }
}
