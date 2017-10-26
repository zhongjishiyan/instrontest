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
    public partial class Form标准控制参数 : Form
    {
        public bool result = false;
        public Form标准控制参数()
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
            result = true;
            Close();
        }

        private void numericEdit1_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            if (numericEdit1.Enabled == true)
            {
                numericEdit2.Value = CComLibrary.GlobeVal.filesave.LoadToStrain(numericEdit1.Value);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked ==true )
            {

                numericEdit1.Enabled = false ;
                numericEdit2.Enabled = true;
            }
            else

            {
                numericEdit1.Enabled = true;
                numericEdit2.Enabled = false;
            }
        }

        private void numericEdit2_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            if (numericEdit2.Enabled  == true)
            {
                numericEdit1.Value = CComLibrary.GlobeVal.filesave.StrainToLoad(numericEdit2.Value);
            }
        }
    }
}
