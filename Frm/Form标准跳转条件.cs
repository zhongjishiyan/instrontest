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
    public partial class Form标准跳转条件 : Form
    {
        public bool result = false;
        public Form标准跳转条件()
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
            result = false ;
            Close();
        }

        private void Form标准跳转条件_Load(object sender, EventArgs e)
        {
            
        }

        private void numericEdit2_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            if (numericEdit2.Enabled == true)
            {
                numericEdit4.Value = CComLibrary.GlobeVal.filesave.LoadToStrain(numericEdit2.Value);
            }
        }

        private void numericEdit4_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            if (numericEdit4.Enabled == true)
            {
                numericEdit2.Value = CComLibrary.GlobeVal.filesave.StrainToLoad(numericEdit4.Value);
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked ==true )
            {
                numericEdit4.Enabled = true;
                numericEdit2.Enabled = false;
            }
            else
            {
                numericEdit4.Enabled = false ;
                numericEdit2.Enabled = true;
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lblunit.Text = ClsStaticStation.m_Global.mycls.hardsignals[comboBox1.SelectedIndex].cUnits[0];
            if (ClsStaticStation.m_Global.mycls.hardsignals[comboBox1.SelectedIndex].cUnitKind == 1)
            {
                if (GlobeVal.mysys.machinekind == 0)
                {
                    panel1.Visible = true;
                }
                else
                {
                    panel1.Visible = false;
                }
            }
            else
            {
                panel1.Visible = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
