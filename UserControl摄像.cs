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
    public partial class UserControl摄像 : UserControl
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

           if (GlobeVal.mysys.demo==true)
            {
                groupBox2.Visible = true;
                groupBox5.Visible = true;
                groupBox3.Visible = true;
                groupBox4.Visible = false;
            }
           else
            {
                groupBox2.Visible = false ;
                groupBox5.Visible = false ;
                groupBox3.Visible = false;
                groupBox4.Visible = true;
            }

            chkplay.Checked = CComLibrary.GlobeVal.filesave.mplay;
            txtplay.Text = CComLibrary.GlobeVal.filesave.play_avi_file;
            chkautoplay.Checked = CComLibrary.GlobeVal.filesave.mautoplay;
            chkautorecord.Checked = CComLibrary.GlobeVal.filesave.mautorecord;
            chkplayfile.Checked = CComLibrary.GlobeVal.filesave.mplayfile;
            txtplayfile.Text = CComLibrary.GlobeVal.filesave.play_avi_datafile;


        }
        public  UserControl摄像()
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
           
        }

        private void txtAppTitle_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void txtshort_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chkplay_CheckedChanged(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.mplay = chkplay.Checked;
        }

        private void btnplay_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "(*.avi" + ")|*.avi";

            string s;
            s = System.Windows.Forms.Application.StartupPath;

            openFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath +  "\\MyVideo\\";


            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == "")
            {

            }

            else
            {


                txtplay.Text = System.IO.Path.GetFileName(openFileDialog1.FileName);

                CComLibrary.GlobeVal.filesave.play_avi_file = txtplay.Text;



            }
        }

        private void chkautoplay_CheckedChanged(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.mautoplay = chkautoplay.Checked;
        }

        private void chkautorecord_CheckedChanged(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.mautorecord = chkautorecord.Checked;
        }

        private void chkplayfile_CheckedChanged(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.mplayfile = chkplayfile.Checked;

        }

        private void btnfile_Click(object sender, EventArgs e)
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


                txtplayfile.Text = System.IO.Path.GetFileName(openFileDialog1.FileName);

                CComLibrary.GlobeVal.filesave.play_avi_datafile  = txtplayfile.Text;

            }
        }
    }
}
