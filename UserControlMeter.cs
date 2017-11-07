using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms; 
namespace TabHeaderDemo
{
    public partial class UserControlMeter : UserControl
    {
        public List<JMeter> mlistmeter;  
        public UserControlMeter()
        {
            InitializeComponent();
            mlistmeter = new List<JMeter>();
            mlistmeter.Add(jMeter1);
            mlistmeter.Add(jMeter2);
            mlistmeter.Add(jMeter3);
            mlistmeter.Add(jMeter4);
            jMeter1.BackColor = this.BackColor;
            jMeter2.BackColor = this.BackColor;
            jMeter3.BackColor = this.BackColor;
            jMeter4.BackColor = this.BackColor;
            jMeter1.Visible = false;
            jMeter2.Visible = false;
            jMeter3.Visible = false;
            jMeter4.Visible = false; 
 
        }

        public void Init()
        {

            for (int i = 0; i < mlistmeter.Count; i++)
            {
                mlistmeter[i].Visible = false;
            }
            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mextrameter.Count; i++)
            {
                mlistmeter[i].Visible = true;
            }


            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mextrameter.Count; i++)
            {

                mlistmeter[i].lblcaption.Text = CComLibrary.GlobeVal.filesave.mextrameter[i].cName;
                mlistmeter[i].lblunit.Text = CComLibrary.GlobeVal.filesave.mextrameter[i].cUnits[CComLibrary.GlobeVal.filesave.mextrameter[i].cUnitsel];
                mlistmeter[i].Visible = true;
                mlistmeter[i].lblvalue.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(
                    CComLibrary.GlobeVal.filesave.mextrameter[i].precise);
                mlistmeter[i].Refresh();
            }
          
            timer1.Enabled = true;

          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CComLibrary.GlobeVal.filesave==null)
            {
                return;
            }
            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mextrameter.Count; i++)
            {
                for (int j = 0; j <ClsStaticStation.m_Global.mycls.allsignals.Count; j++)
                {
                    if (CComLibrary.GlobeVal.filesave.mextrameter[i].cName ==ClsStaticStation.m_Global.mycls.allsignals[j].cName)
                    {
                        mlistmeter[i].lblvalue.Text =ClsStaticStation.m_Global.mycls.allsignals[j].GetValueFromUnit(
                            ClsStaticStation.m_Global.mycls.allsignals[j].cvalue,
                            CComLibrary.GlobeVal.filesave.mextrameter[i].cUnitsel);



                    }
                }
            }
        }

        private void UserControlMeter_Resize(object sender, EventArgs e)
        {
           
        }

        private void UserControlMeter_SizeChanged(object sender, EventArgs e)
        {

            
            
        }
       
    }
}
