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
    public partial class UserControl原始数据 : UserControl
    {
        public UserControlMethod musercontrolmethod;
        private ClsStaticStation.ItemSignal mtempitesm;
        private int msel = 0;
        private void list_metersetvalue()
        {
            int i;
            CComLibrary.GlobeVal.filesave.mrawdata.Clear();
            for (i = 0; i < this.lstinclude.Items.Count; i++)
            {
                CComLibrary.GlobeVal.filesave.mrawdata.Add(this.lstinclude.list[i].Clone() as ClsStaticStation.ItemSignal );
            }
        }
        public  void Init(int sel)
        {

            if (GlobeVal.UserControlMain1.btnmtest.Visible == true)
            {
                tabControl1.Enabled = false;
            }
            else
            {
                tabControl1.Enabled = true;
            }

            tabControl1.SelectedIndex = sel;

            
            lstavail.ClearItem();
            for (int j = 0; j < ClsStaticStation.m_Global.mycls.allsignals.Count; j++)
            {

                if (CComLibrary.GlobeVal.filesave.mrawdata == null)
                {
                   lstavail.AddItem(ClsStaticStation.m_Global.mycls.allsignals[j]);
                }
                else
                {
                    if (this.lstinclude.MatchItem(CComLibrary.GlobeVal.filesave.mrawdata,
                        ClsStaticStation.m_Global.mycls.allsignals[j]) == true)
                    {

                    }
                    else
                    {
                        lstavail.AddItem(ClsStaticStation.m_Global.mycls.allsignals[j]);
                    }


                }

            }

            lstinclude.ClearItem();
            for (int j = 0; j < CComLibrary.GlobeVal.filesave.mrawdata.Count; j++)
            {


                lstinclude.AddItem(CComLibrary.GlobeVal.filesave.mrawdata[j]);


            }


        }
        public  UserControl原始数据()
        {
            InitializeComponent();
            tabControl1.ItemSize = new Size(1, 1);
            mtempitesm =null;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void lstavail_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btndown_Click(object sender, EventArgs e)
        {
            if (this.lstinclude.SelectedItem != null)
            {
                this.lstinclude.DownItem(this.lstinclude.SelectedIndex);
                list_metersetvalue();
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
           
                if (this.lstavail.SelectedItem != null)
                {
                    this.lstinclude.AddItem(this.lstavail.list[this.lstavail.SelectedIndex]);

                    this.lstavail.RemoveItem(this.lstavail.SelectedIndex);

                    list_metersetvalue();

                }
           

        }

        private void btndec_Click(object sender, EventArgs e)
        {
            if (this.lstinclude.SelectedItem != null)
            {
                bool mb = false;
                for (int j = 0; j < ClsStaticStation.m_Global.mycls.allsignals.Count; j++)
                {


                    if (this.lstinclude.list[this.lstinclude.SelectedIndex].cName ==
                        ClsStaticStation.m_Global.mycls.allsignals[j].cName)
                    {
                        mb = true;
                    }




                }
                if (mb == true)
                {
                    this.lstavail.AddItem(this.lstinclude.list[this.lstinclude.SelectedIndex]);
                }
                this.lstinclude.RemoveItem(this.lstinclude.SelectedIndex);

                list_metersetvalue();
            }
        }

        private void btnup_Click(object sender, EventArgs e)
        {
            if (this.lstinclude.SelectedItem != null)
            {
                this.lstinclude.UpItem(this.lstinclude.SelectedIndex);
                list_metersetvalue();
            }
        }

        private void lstinclude_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstinclude.SelectedIndex >= 0)
            {
                mtempitesm = lstinclude.list[lstinclude.SelectedIndex];

                msel = lstinclude.SelectedIndex;
                this.txtExplain.Text = lstinclude.list[lstinclude.SelectedIndex].cName;
                this.cbounit.Items.Clear();
                for (int i = 0; i < lstinclude.list[lstinclude.SelectedIndex].cUnitCount; i++)
                {
                    this.cbounit.Items.Add(lstinclude.list[lstinclude.SelectedIndex].cUnits[i]);
                }
                this.cbounit.SelectedIndex = lstinclude.list[lstinclude.SelectedIndex].cUnitsel;
                this.numericEdit1.Value  = lstinclude.list[lstinclude.SelectedIndex].precise;
                this.txtExplain.Tag = lstinclude.list[lstinclude.SelectedIndex];

            }
        }

        private void cbounit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (lstinclude.SelectedIndex >= 0)
            {
                lstinclude.list[lstinclude.SelectedIndex].cUnitsel = cbounit.SelectedIndex;

            }

        }

        private void numericEdit1_ValueChanged(object sender, EventArgs e)
        {
            if (lstinclude.SelectedIndex >= 0)
            {
                lstinclude.list[lstinclude.SelectedIndex].precise = Convert.ToInt32( numericEdit1.Value);
            }
        } 

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void lstinclude_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
    }
}
