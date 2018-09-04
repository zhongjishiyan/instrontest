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

            cboreportkind.Items.Clear();
            if (GlobeVal.mysys.language == 0)
            {
                cboreportkind.Items.Add("标准模板");
                cboreportkind.Items.Add("自定义模板");
            }
            else
            {
                cboreportkind.Items.Add("Standard Templates");
                cboreportkind.Items.Add("Custom Templates");
            }
            cboreportkind.SelectedIndex = CComLibrary.GlobeVal.filesave.ReportMode;

            txtUserReportTemplate.Text = CComLibrary.GlobeVal.filesave.UserReportTemplate;
            cboreportkind_SelectionChangeCommitted(null, null);

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

        private void btnchange_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\report\\";
            this.openFileDialog1.AddExtension = true;
            if (GlobeVal.mysys.language == 0)
            {
                this.openFileDialog1.Filter = "试验报告模板文件(*.it)|*.it";
            }
            else
            {
                this.openFileDialog1.Filter = "Test report template file(*.it)|*.it"; 
            }
            this.openFileDialog1.FileName = "";
            this.openFileDialog1.ShowDialog(this);
            if (this.openFileDialog1.FileName == null)
            {

                return;
            }
            else
            {
                string fileName = this.openFileDialog1.FileName;

                if (fileName == "")
                {
                    return;
                }
                else
                {
                    txtReportTemplate.Text = System.IO.Path.GetFileName(fileName);

                }

            }
        }

        private void txtReportTemplate_TextChanged(object sender, EventArgs e)
        {
             CComLibrary.GlobeVal.filesave.ReportTemplate= txtReportTemplate.Text;
        }

        private void btnuserchange_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\report\\";
            this.openFileDialog1.AddExtension = true;
            if (GlobeVal.mysys.language == 0)
            {
                this.openFileDialog1.Filter = "自定义报告模板文件(*.docx)|*.docx";
            }
            else
            {
                this.openFileDialog1.Filter = "Custom report template file(*.docx)|*.docx";
            }
            this.openFileDialog1.FileName = "";
            this.openFileDialog1.ShowDialog(this);
            if (this.openFileDialog1.FileName == null)
            {

                return;
            }
            else
            {
                string fileName = this.openFileDialog1.FileName;

                if (fileName == "")
                {
                    return;
                }
                else
                {
                    this.txtUserReportTemplate.Text = System.IO.Path.GetFileName(fileName);

                }

            }
        }

        private void cboreportkind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.ReportMode = cboreportkind.SelectedIndex; 

            if (cboreportkind.SelectedIndex ==0)
            {
                label6.Visible = true;
                this.tableLayoutPanel6.Visible = true;
                label9.Visible = false;
                this.tableLayoutPanel7.Visible = false;
            }
            else
            {
                label6.Visible = false;
                this.tableLayoutPanel6.Visible = false;
                label9.Visible = true;
                this.tableLayoutPanel7.Visible = true;
            }
        }

        private void txtUserReportTemplate_TextChanged(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.UserReportTemplate= txtUserReportTemplate.Text;
        }
    }
}
