using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Compenkie
{
    public partial class Add_Table : Form
    {
        public Add_Table()
        {
            InitializeComponent();
            Location = ActiveForm.Location + SystemInformation.CaptionButtonSize + SystemInformation.FrameBorderSize;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}