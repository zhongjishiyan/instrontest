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
    public partial class FormPlotSet : Form
    {
        public Boolean Result = false;
        public FormPlotSet()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Result = true;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
