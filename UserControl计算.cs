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
    public partial class UserControl计算 : UserControl
    {
        public UserControlMethod musercontrolmethod;

        private CComLibrary.outputitem mtempoutput;
        public void Open_method()
        {
            if (GlobeVal.UserControlMain1.btnmtest.Visible == true)
            {
                tlpback.Enabled = false;
            }
            else
            {
                tlpback.Enabled = true;
            }
            mtempoutput = null;
            lstinclude.Items.Clear();
            lstinclude.mlist.Clear();
            lstavail.Items.Clear();
            lstavail.mlist.Clear();
            for (int i = 0; i < CComLibrary.GlobeVal.filesave.moutput.Count; i++)
            {
                if (CComLibrary.GlobeVal.filesave.moutput[i].check == true)
                {
                    lstinclude.Items.Add(CComLibrary.GlobeVal.filesave.moutput[i].formulaname);
                    lstinclude.mlist.Add(CComLibrary.GlobeVal.filesave.moutput[i]);
                }
                else
                {
                    lstavail.Items.Add(CComLibrary.GlobeVal.filesave.moutput[i].formulaname);
                    lstavail.mlist.Add(CComLibrary.GlobeVal.filesave.moutput[i]);
                }
            }

        }

        public void Init()
        {
           


        }
        public  UserControl计算()
        {
            InitializeComponent();
            tabControl1.ItemSize = new Size(1, 1);
        }

        private void lstinclude_MouseClick(object sender, MouseEventArgs e)
        {
            if  (lstinclude.SelectedIndex >=0)
            {
                mtempoutput = lstinclude.mlist[lstinclude.SelectedIndex];
            lblcaption.Text = lstinclude.mlist[lstinclude.SelectedIndex].formulaname; 
            this.txtExplain.Text = lstinclude.mlist[lstinclude.SelectedIndex].formulaexplain;
            this.cbounit.Items.Clear();
            for (int i = 0; i < lstinclude.mlist[lstinclude.SelectedIndex].myitemsignal.cUnitCount; i++)
            {
                this.cbounit.Items.Add(lstinclude.mlist[lstinclude.SelectedIndex].myitemsignal.cUnits[i]);  
            }
            this.cbounit.SelectedIndex = lstinclude.mlist[lstinclude.SelectedIndex].myitemsignal.cUnitsel;
            this.txtprecise.Text = lstinclude.mlist[lstinclude.SelectedIndex].myitemsignal.precise.ToString();
            this.chkshow.Checked = lstinclude.mlist[lstinclude.SelectedIndex].show; 


            }
        }

        private void cbounit_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void lstavail_MouseClick(object sender, MouseEventArgs e)
        {
            

            if (lstavail.SelectedIndex >= 0)
            {
                lblcaption.Text = lstavail.mlist[lstavail.SelectedIndex].formulaname;
                mtempoutput = lstavail.mlist[lstavail.SelectedIndex];
                this.txtExplain.Text = lstavail.mlist[lstavail.SelectedIndex].formulaexplain;
                this.cbounit.Items.Clear();
                for (int i = 0; i < lstavail.mlist[lstavail.SelectedIndex].myitemsignal.cUnitCount; i++)
                {
                    this.cbounit.Items.Add(lstavail.mlist[lstavail.SelectedIndex].myitemsignal.cUnits[i]);
                }
                this.cbounit.SelectedIndex = lstavail.mlist[lstavail.SelectedIndex].myitemsignal.cUnitsel;
                this.txtprecise.Text = lstavail.mlist[lstavail.SelectedIndex].myitemsignal.precise.ToString();
                this.chkshow.Checked = lstavail.mlist[lstavail.SelectedIndex].show;
            }
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            if (this.lstinclude.SelectedItem != null)
            {
                this.lstavail.Items.Add(this.lstinclude.mlist[this.lstinclude.SelectedIndex].formulaname);
                this.lstavail.mlist.Add(this.lstinclude.mlist[this.lstinclude.SelectedIndex]);

                this.lstinclude.mlist[this.lstinclude.SelectedIndex].check = false;
                    
                this.lstinclude.mlist.RemoveAt(this.lstinclude.SelectedIndex);
                this.lstinclude.Items.RemoveAt(this.lstinclude.SelectedIndex);

            }

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (this.lstavail.SelectedItem != null)
            {
                this.lstinclude.Items.Add(this.lstavail.mlist[this.lstavail.SelectedIndex].formulaname);
                this.lstinclude.mlist.Add(this.lstavail.mlist[this.lstavail.SelectedIndex]);

                this.lstavail.mlist[this.lstavail.SelectedIndex].check = true;

                this.lstavail.mlist.RemoveAt(this.lstavail.SelectedIndex);
                this.lstavail.Items.RemoveAt(this.lstavail.SelectedIndex);

               

            }
        }

        private void btnchange_Click(object sender, EventArgs e)
        {
            if (mtempoutput != null)
            {
               mtempoutput.myitemsignal.cUnitsel= this.cbounit.SelectedIndex;
               mtempoutput.myitemsignal.precise = Convert.ToInt32(this.txtprecise.Text);
               mtempoutput.show = this.chkshow.Checked;
            }
        }
    }
}
