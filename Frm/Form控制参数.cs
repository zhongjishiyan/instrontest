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
    public partial class Form控制参数 : Form
    {
        public bool result = false;
        public Form控制参数()
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

        private void numericEdit1_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            if (numericEdit1.Enabled == true)
            {
                numericEdit2.Value = CComLibrary.GlobeVal.filesave.LoadToStrain(numericEdit1.Value);
            }
        }

        private void numericEdit2_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            if (numericEdit2.Enabled == true)
            {
                numericEdit1.Value = CComLibrary.GlobeVal.filesave.StrainToLoad(numericEdit2.Value);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked == true)
            {

                numericEdit1.Enabled = true;
                numericEdit2.Enabled = false;
                
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton2.Checked == true)
            {

                numericEdit1.Enabled = false ;
                numericEdit2.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void Form控制参数_Load(object sender, EventArgs e)
        {

        }
    }
}
