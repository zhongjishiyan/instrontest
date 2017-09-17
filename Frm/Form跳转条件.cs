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
    public partial class Form跳转条件 : Form
    {
        public bool result = false;
        public Form跳转条件()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result = true;
            Close(); 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            result = false;
            Close();
        }

        private void numericEdit2_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            if (numericEdit2.Enabled == true)
            {
                numericEdit4.Value = CComLibrary.GlobeVal.filesave.LoadToStrain(numericEdit2.Value);
            }
        }

        private void rbtnload_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnload.Checked == true)
            {

                numericEdit2.Enabled = true;
                numericEdit4.Enabled = false;
            }

        }

        private void rbtnstrain_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnstrain.Checked == true)
            {
                numericEdit2.Enabled = false;
                numericEdit4.Enabled = true;
            }
        }

        private void numericEdit4_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            if (numericEdit4.Enabled == true)
            {
                numericEdit2.Value = CComLibrary.GlobeVal.filesave.StrainToLoad(numericEdit4.Value);
            }
        }

        private void rbtnpos_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
