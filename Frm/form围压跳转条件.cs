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
    public partial class Form围压跳转条件 : Form
    {
        public bool result = false;
        public Form围压跳转条件()
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
