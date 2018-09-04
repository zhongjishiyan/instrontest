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
            if (GlobeVal.mysys.language == 0)
            {
                cbostartup.Items.Add("在主屏幕");
                cbostartup.Items.Add("按照上次使用过的试验方法准备试验");
                cbostartup.Items.Add("按照指定的试验方法准备试验");
            }
            else
            {
                cbostartup.Items.Add("Home Screen");
                cbostartup.Items.Add("Continue testing the last-used sample");
                cbostartup.Items.Add("Create a new sample with a specific test method");
            }
            cbostartup.SelectedIndex = GlobeVal.mysys.startupscreen;


            cbolanguage.Items.Clear();

            if (GlobeVal.mysys.language == 0)
            {
                cbolanguage.Items.Add("中文版");
                cbolanguage.Items.Add("英文版");
            }
            else
            {
                cbolanguage.Items.Add("Chinese version");
                cbolanguage.Items.Add("English version");
            }
            cbolanguage.SelectedIndex = GlobeVal.mysys.language;

#if Demo
            chkdemo.Enabled = false;
            chkdemo.Checked = true;
#else
            chkdemo.Enabled=true;
            chkdemo.Checked = GlobeVal.mysys.demo;
#endif 
            chktitle.Checked=GlobeVal.mysys.showapptitle;
            txtAppTitle.Text = GlobeVal.mysys.Lapptile[GlobeVal.mysys.language];
            txtshort.Text= GlobeVal.mysys.Lshorttitle[GlobeVal.mysys.language];
            chkshort.Checked = GlobeVal.mysys.showshorttitle;

            txtlogo.Text = GlobeVal.mysys.bmplogo;
            txtdemo.Text = GlobeVal.mysys.demotxt;
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
                if (GlobeVal.mysys.language == 0)
                {
                    GlobeVal.MainStatusStrip.Items["tslbldevice"].Text = "演示";
                }
                else
                {
                    GlobeVal.MainStatusStrip.Items["tslbldevice"].Text = "Demo";
                }
           }
           else
           {
               GlobeVal.MainStatusStrip.Items["tslbldevice"].Text = GlobeVal.mysys.ControllerName[GlobeVal.mysys.controllerkind];
           }
           
           GlobeVal.mysys.SerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\sys\\setup.ini");
        }

        private void txtAppTitle_TextChanged(object sender, EventArgs e)
        {
            GlobeVal.mysys.Lapptile[GlobeVal.mysys.language] = txtAppTitle.Text;
          
        }

        private void chktitle_CheckedChanged(object sender, EventArgs e)
        {
            GlobeVal.mysys.showapptitle = chktitle.Checked; 
        }

        private void txtshort_TextChanged(object sender, EventArgs e)
        {
           
                GlobeVal.mysys.Lshorttitle[GlobeVal.mysys.language] = txtshort.Text;
            
             
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

        private void btndemotxt_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "(*.txt" + ")|*.txt";

            string s;
            s = System.Windows.Forms.Application.StartupPath;

            openFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\demo\\";


            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == "")
            {

            }

            else
            {


                txtdemo.Text = System.IO.Path.GetFileName(openFileDialog1.FileName);

                GlobeVal.mysys.demotxt = txtdemo.Text;

            }
        }

        private void cbolanguage_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GlobeVal.mysys.language = cbolanguage.SelectedIndex;
            txtAppTitle.Text = GlobeVal.mysys.Lapptile[GlobeVal.mysys.language];
            txtshort.Text = GlobeVal.mysys.Lshorttitle[GlobeVal.mysys.language];
        }

        private void cbostartup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
