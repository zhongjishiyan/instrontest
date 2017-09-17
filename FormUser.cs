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
    public partial class FormUser : Form
    {
        
       
        public FormUser()
        {
            InitializeComponent();
        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            cbouser.Items.Clear();
            cbouser.Items.Add("操作员");
            cbouser.Items.Add("试验经理");
            cbouser.Items.Add("管理员");
            cbouser.SelectedIndex = GlobeVal.userkind;
            txtname.Text = GlobeVal.username;
            txtpassword.Text = GlobeVal.userpassword;
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            GlobeVal.suc = true;
            GlobeVal.userpassword = txtpassword.Text;
            GlobeVal.userkind = cbouser.SelectedIndex;
            GlobeVal.username = txtname.Text;
            Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            GlobeVal.suc = false;
            Close();
        }
    }
}
