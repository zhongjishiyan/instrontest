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
    public partial class Form循环执行 : Form
    {
        public bool result = false;
        public Form循环执行()
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

        private void chkcyclic_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
