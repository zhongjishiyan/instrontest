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
    public partial class Form登录 : Form
    {
        public Boolean result = false;
        public Form登录()
        {
            InitializeComponent();
        }

        private void Form登录_Load(object sender, EventArgs e)
        {
            cboname.Items.Clear();
            for (int i = 0; i < GlobeVal.mysys.UserCount; i++)
            {
                cboname.Items.Add(GlobeVal.mysys.UserName[i]);

            }

            cboname.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cboname.SelectedIndex >= 0)
            {
                if (GlobeVal.mysys.UserPassword[cboname.SelectedIndex] == txtpassword.Text)
                {
                    GlobeVal.mysys.AppUserLevel = GlobeVal.mysys.UserLevels[cboname.SelectedIndex];
                    GlobeVal.mysys.CurentUserIndex = cboname.SelectedIndex;
                    result = true;
                }
            }

            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            result = false;
            Close();
        }
    }
}
