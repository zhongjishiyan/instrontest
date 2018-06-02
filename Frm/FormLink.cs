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
    public partial class FormLink : Form
    {

        private bool mb = false;
        public FormLink()
        {
            InitializeComponent();
        }

        private void FormLink_Load(object sender, EventArgs e)
        {
            mb = false;
            timer1.Enabled = true;
        }

        private void FormLink_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void label2_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (mb == true)
            {
                mb = false;
                pictureBox1.Image = imageList1.Images[0];
            }
            else
            {
                mb = true;
                pictureBox1.Image = imageList1.Images[1];
            }
        }
    }
}
