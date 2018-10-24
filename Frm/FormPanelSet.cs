using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TabHeaderDemo.Frm
{
    public partial class FormPanelSet : Form
    {
        public bool TowChannel;

        public FormPanelSet()
        {
            InitializeComponent();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }

        private void tsbok_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbcancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormPanelSet_Load(object sender, EventArgs e)
        {
            chkhlimit.Checked = GlobeVal.mysys.chk_hlimit;
            chkslimit.Checked = GlobeVal.mysys.chk_slimit;
            chkalarm.Checked = GlobeVal.mysys.chk_alarm;
            txtup.Text = GlobeVal.mysys.lbl_up;
            txtkeep.Text = GlobeVal.mysys.lbl_stop;
            txtdown.Text = GlobeVal.mysys.lbl_down;
            txtdest.Text = GlobeVal.mysys.lbl_start;
            txtstop.Text = GlobeVal.mysys.lbl_end;

            txtup1.Text = GlobeVal.mysys.lbl_up1;
            txtkeep1.Text = GlobeVal.mysys.lbl_stop1;
            txtdown1.Text = GlobeVal.mysys.lbl_down1;
            txtdest1.Text = GlobeVal.mysys.lbl_start1;
            txtstop1.Text = GlobeVal.mysys.lbl_end1;

            chkcyclc.Checked = GlobeVal.mysys.chk_cyclc;



            if(TowChannel ==false)
            {
                this.Width = 338;
            }
            else
            {
                this.Width = 620;
            }

        }

        private void chkhlimit_CheckedChanged(object sender, EventArgs e)
        {
            GlobeVal.mysys.chk_hlimit = chkhlimit.Checked;

        }

        private void chkslimit_CheckedChanged(object sender, EventArgs e)
        {
            GlobeVal.mysys.chk_slimit = chkslimit.Checked;
        }

        private void chkalarm_CheckedChanged(object sender, EventArgs e)
        {
            GlobeVal.mysys.chk_alarm = chkalarm.Checked;
        }

        private void txtup_TextChanged(object sender, EventArgs e)
        {
            GlobeVal.mysys.lbl_up = txtup.Text;

        }

        private void txtkeep_TextChanged(object sender, EventArgs e)
        {
            GlobeVal.mysys.lbl_stop = txtkeep.Text;
        }

        private void txtdown_TextChanged(object sender, EventArgs e)
        {
            GlobeVal.mysys.lbl_down = txtdown.Text;
        }

        private void txtdest_TextChanged(object sender, EventArgs e)
        {
            GlobeVal.mysys.lbl_start = txtdest.Text;
        }

        private void txtstop_TextChanged(object sender, EventArgs e)
        {
            GlobeVal.mysys.lbl_end = txtstop.Text;
        }

        private void chkcyclc_CheckedChanged(object sender, EventArgs e)
        {
            GlobeVal.mysys.chk_cyclc = chkcyclc.Checked;
        }

        private void txtup1_TextChanged(object sender, EventArgs e)
        {
            GlobeVal.mysys.lbl_up1 = txtup1.Text;
        }

        private void txtkeep1_TextChanged(object sender, EventArgs e)
        {
            GlobeVal.mysys.lbl_stop1= txtkeep1.Text;

        }

        private void txtdown1_TextChanged(object sender, EventArgs e)
        {
            GlobeVal.mysys.lbl_down1 = txtdown1.Text; 
        }

        private void txtdest1_TextChanged(object sender, EventArgs e)
        {
            GlobeVal.mysys.lbl_start1 = txtdest1.Text;
        }

        private void txtstop1_TextChanged(object sender, EventArgs e)
        {
            GlobeVal.mysys.lbl_end1 = txtstop1.Text;
        }
    }
}
