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
    public partial class Frm围压控制参数 : Form
    {
        public bool result = false;

        public Frm围压控制参数()
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
    }
}
