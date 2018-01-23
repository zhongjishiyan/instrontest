using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace TabHeaderDemo
{
    public partial class UserControl文件设置 : UserControl
    {
        public UserControlMethod musercontrolmethod;
        public  void Init(int sel)
        {
            if (GlobeVal.UserControlMain1.btnmtest.Visible == true)
            {
                tabControl1.Enabled = false;
            }
            else
            {
                tabControl1.Enabled = true;
            }
            tabControl1.SelectedIndex = sel;

            txtpath.Text = CComLibrary.GlobeVal.filesave.SamplePath;
            txtSampleName.Text = CComLibrary.GlobeVal.filesave.SampleDefaultName;

            txtReportTemplate.Text = CComLibrary.GlobeVal.filesave.ReportTemplate;

            cboformat.Items.Clear();
            cboformat.Items.Add("word");
            cboformat.Items.Add("tiff");
            cboformat.SelectedIndex = CComLibrary.GlobeVal.filesave.ReportFormat;

            chksave.Checked = CComLibrary.GlobeVal.filesave.ReportSave;
            chkprint.Checked = CComLibrary.GlobeVal.filesave.ReportPrint;

            chkdatabase.Checked = CComLibrary.GlobeVal.filesave.UseDatabase;


        }
        public  UserControl文件设置()
        {
            InitializeComponent();
            tabControl1.ItemSize = new Size(1, 1);
        }

        private void btnpath_Click(object sender, EventArgs e)
        {
            string s;
            


            if (Directory.Exists(CComLibrary.GlobeVal.filesave.SamplePath) == true)
            {

            }
            else
            {
                if (txtpath.Text.Trim() == "")
                {
                    s = System.Windows.Forms.Application.StartupPath;

                    if (Directory.Exists(s + "\\AppleLabJ") == true)
                    {

                    }
                    else
                    {
                        Directory.CreateDirectory(s + "\\AppleLabJ");

                    }
                    CComLibrary.GlobeVal.filesave.SamplePath = s + "\\AppleLabJ";
                }

            }

                this.folderBrowserDialog1.SelectedPath = CComLibrary.GlobeVal.filesave.SamplePath;
                this.folderBrowserDialog1.ShowDialog();

                CComLibrary.GlobeVal.filesave.SamplePath = this.folderBrowserDialog1.SelectedPath;

               

                txtpath.Text = CComLibrary.GlobeVal.filesave.SamplePath;
            
        }

        private void txtpath_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSampleName_TextChanged(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.SampleDefaultName = txtSampleName.Text;
        }

        private void cboformat_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.ReportFormat = cboformat.SelectedIndex;
        }

        private void chksave_CheckedChanged(object sender, EventArgs e)
        {
             CComLibrary.GlobeVal.filesave.ReportSave=chksave.Checked;
        }

        private void chkprint_CheckedChanged(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.ReportPrint= chkprint.Checked;
        }

        private void chkdatabase_CheckedChanged(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.UseDatabase = chkdatabase.Checked;
        }
    }
}
