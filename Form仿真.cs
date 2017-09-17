using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TabHeaderDemo
{
    public partial class Form仿真 : Form
    {
        public Form仿真()
        {
            InitializeComponent();
        }

        private void switch1_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (switch1.Value == true)
            {
                GlobeVal.myarm.setrunstate(1);
                led1.Value = true;
            }
            else
            {
                GlobeVal.myarm.setrunstate(0);
                led1.Value = false;
            }


        }
    }
}
