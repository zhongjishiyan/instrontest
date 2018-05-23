using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TabHeaderDemo
{
    public partial class UserControl系统安全 : UserControl
    {
        public UserControlMethod musercontrolmethod;
        public  void Init(int sel)
        {

            tabControl1.SelectedIndex = sel;

            grpuser.Visible = false;
            listBox1.Items.Clear();
           
            for (int i = 0; i < GlobeVal.mysys.UserCount; i++)
            {
                listBox1.Items.Add(GlobeVal.mysys.UserName[i]);

            }
           

        }
        public UserControl系统安全()
        {
            InitializeComponent();
            tabControl1.ItemSize = new Size(1, 1);
            chksystem.Checked = false;
            chksafe.Checked = GlobeVal.mysys.safe;

        }

        private void chksystem_CheckedChanged(object sender, EventArgs e)
        {
            if (chksystem.Checked == true)
            {

                FormMima f = new FormMima();
                f.ShowDialog();

                if (f.suc == true)
                {
                    chksystem.Checked = true;
                    grpuser.Visible = true;
                }
                else
                {
                    chksystem.Checked = false;
                    grpuser.Visible = false;
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            FormUser f = new FormUser();
            GlobeVal.suc = false;
            GlobeVal.username = "";
            GlobeVal.userpassword = "";
            GlobeVal.userkind = GlobeVal.mysys.UserLevels[GlobeVal.mysys.UserCount];
            f.ShowDialog();

            if (GlobeVal.suc  == true)
            {

                GlobeVal.mysys.UserName[GlobeVal.mysys.UserCount] = GlobeVal.username;
                GlobeVal.mysys.UserPassword[GlobeVal.mysys.UserCount] = GlobeVal.userpassword;
                GlobeVal.mysys.UserLevels[GlobeVal.mysys.UserCount] = GlobeVal.userkind;
                listBox1.Items.Add(GlobeVal.mysys.UserName[GlobeVal.mysys.UserCount]);
                GlobeVal.mysys.UserCount = GlobeVal.mysys.UserCount + 1;
                GlobeVal.mysys.SerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\sys\\setup.ini");
               
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > 0)
            {
                GlobeVal.suc = false;
                GlobeVal.username = GlobeVal.mysys.UserName[listBox1.SelectedIndex];
                GlobeVal.userpassword = GlobeVal.mysys.UserPassword[listBox1.SelectedIndex];
                GlobeVal.userkind = GlobeVal.mysys.UserLevels[listBox1.SelectedIndex];
                FormUser f = new FormUser();
                f.ShowDialog();

                if (GlobeVal.suc == true)
                {

                    GlobeVal.mysys.UserName[listBox1.SelectedIndex] = GlobeVal.username;
                    GlobeVal.mysys.UserPassword[listBox1.SelectedIndex] = GlobeVal.userpassword;
                    GlobeVal.mysys.UserLevels[listBox1.SelectedIndex] = GlobeVal.userkind;

                    listBox1.Items[listBox1.SelectedIndex] = GlobeVal.username;
                    GlobeVal.mysys.SerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\sys\\setup.ini");

                }

               
            }
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int a;
            if (listBox1.SelectedIndex >0)
            {

                a = listBox1.SelectedIndex;
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);


            for (int i = a; i < GlobeVal.mysys.UserCount-1; i++)
            {
                GlobeVal.mysys.UserName[i] = GlobeVal.mysys.UserName[i + 1];
                GlobeVal.mysys.UserPassword[i] = GlobeVal.mysys.UserPassword[i + 1];
                GlobeVal.mysys.UserLevels[i] = GlobeVal.mysys.UserLevels[i + 1];


            }

            GlobeVal.mysys.UserCount = GlobeVal.mysys.UserCount - 1;
            GlobeVal.mysys.SerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\sys\\setup.ini");

            }


        }

        private void chksafe_CheckedChanged(object sender, EventArgs e)
        {
            if (chksafe.Checked == true)
            {
                FormMima f = new FormMima();
                f.ShowDialog();

                if (f.suc == true)
                {

                    GlobeVal.mysys.safe = chksafe.Checked;

                }
                else
                {
                    chksafe.Checked = false;
                }
            }
            else
            {
                GlobeVal.mysys.safe = chksafe.Checked;
            }

           
        }
    }
}
