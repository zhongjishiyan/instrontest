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
    public partial class UserControl系统选项 : UserControl
    {
        public UserControlMethod musercontrolmethod;
        public  void Init(int sel)
        {

            tabControl1.SelectedIndex = sel;

            if (GlobeVal.mysys.AppUserLevel == 0)
            {
                tabControl1.Enabled = false;
            }
            else
            {
                tabControl1.Enabled = true;
            }

            cbostartup.Items.Clear();
            cbostartup.Items.Add("在主屏幕");
            cbostartup.Items.Add("按照上次使用过的试验方法准备试验");
            cbostartup.Items.Add("按照指定的试验方法准备试验");
            cbostartup.SelectedIndex = GlobeVal.mysys.startupscreen;
            chkdemo.Checked = GlobeVal.mysys.demo;
            chktitle.Checked=GlobeVal.mysys.showapptitle;
            txtAppTitle.Text = GlobeVal.mysys.apptitle;
            txtshort.Text= GlobeVal.mysys.shorttitle;
            chkshort.Checked = GlobeVal.mysys.showshorttitle;

            txtlogo.Text = GlobeVal.mysys.bmplogo;

            chklogo.Checked = GlobeVal.mysys.showlogo;

        }
        public  UserControl系统选项()
        {
            InitializeComponent();
            tabControl1.ItemSize = new Size(1, 1);
            

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbostartup_SelectionChangeCommitted(object sender, EventArgs e)
        {
             GlobeVal.mysys.startupscreen=cbostartup.SelectedIndex;
             GlobeVal.mysys.SerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\sys\\setup.ini");
        }

        private void chkdemo_CheckedChanged(object sender, EventArgs e)
        {
           GlobeVal.mysys.demo= chkdemo.Checked ;

           if (GlobeVal.mysys.demo == true)
           {
               GlobeVal.MainStatusStrip.Items["tslbldevice"].Text = "演示";
           }
           else
           {
               GlobeVal.MainStatusStrip.Items["tslbldevice"].Text = GlobeVal.mysys.ControllerName[GlobeVal.mysys.controllerkind];
           }
           
           GlobeVal.mysys.SerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\sys\\setup.ini");
        }

        private void txtAppTitle_TextChanged(object sender, EventArgs e)
        {
            GlobeVal.mysys.apptitle = txtAppTitle.Text;
        }

        private void chktitle_CheckedChanged(object sender, EventArgs e)
        {
            GlobeVal.mysys.showapptitle = chktitle.Checked; 
        }

        private void txtshort_TextChanged(object sender, EventArgs e)
        {
            GlobeVal.mysys.shorttitle = txtshort.Text;
        }

        private void chkshort_CheckedChanged(object sender, EventArgs e)
        {
            GlobeVal.mysys.showshorttitle = chkshort.Checked;
        }

        private void btnlogo_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "(*.bmp" + ")|*.bmp";

            string s;
            s = System.Windows.Forms.Application.StartupPath;

            openFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\bmp\\";


            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == "")
            {

            }

            else
            {

               
                 txtlogo.Text = System.IO.Path.GetFileName(openFileDialog1.FileName);

                GlobeVal.mysys.bmplogo = txtlogo.Text;

            }

        }

        private void chklogo_CheckedChanged(object sender, EventArgs e)
        {
            GlobeVal.mysys.showlogo = chklogo.Checked;
        }
    }
}
