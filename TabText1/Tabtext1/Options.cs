using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AppleLabApplication
{
    public partial class Options : Form
    {
        public string documentDir;
        public string filenaamEmoticons = null;
        public string filenameTextFragments = null;

        public Options()
        {
            InitializeComponent();
            Location = ActiveForm.Location + SystemInformation.CaptionButtonSize + SystemInformation.FrameBorderSize;


        }

        private void comboBoxEmoticons_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxEmoticons.Items.Clear();
            comboBoxEmoticons.Text = "";
            comboBoxEmoticons.Items.Add("<Default>");
            DirectoryInfo info = new DirectoryInfo(documentDir);
            FileInfo[] files = info.GetFiles("*.sri");
            foreach (FileInfo file in files)
            {
                comboBoxEmoticons.Items.Add(file.Name.ToString());
            }
        }

        private void comboBoxTextFragmenten_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxTextFragmenten.Items.Clear();
            comboBoxTextFragmenten.Text = "";
            comboBoxTextFragmenten.Items.Add("<Default>");
            DirectoryInfo info = new DirectoryInfo(documentDir);
            FileInfo[] files = info.GetFiles("*.srl");
            foreach (FileInfo file in files)
            {
                comboBoxTextFragmenten.Items.Add(file.Name.ToString());
            }
        }

        private void Options_Load(object sender, EventArgs e)
        {
            comboBoxTextFragmenten.Items.Clear();
            comboBoxTextFragmenten.Text = "";
            comboBoxTextFragmenten.Items.Add("<Default>");
            DirectoryInfo info = new DirectoryInfo(documentDir);
            FileInfo[] files = info.GetFiles("*.srl");
            foreach (FileInfo file in files)
            {
                comboBoxTextFragmenten.Items.Add(file.Name.ToString());
            }
            comboBoxTextFragmenten.Text = filenameTextFragments;

            comboBoxEmoticons.Items.Clear();
            comboBoxEmoticons.Text = "";
            comboBoxEmoticons.Items.Add("<Default>");
            files = info.GetFiles("*.sri");
            foreach (FileInfo file in files)
            {
                comboBoxEmoticons.Items.Add(file.Name.ToString());
            }
            comboBoxEmoticons.Text = filenaamEmoticons;

            textBoxDocumentDir.Text = documentDir;
        }

        private void buttondocumentDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxDocumentDir.Text = folderBrowserDialog.SelectedPath;
                documentDir = textBoxDocumentDir.Text;

                comboBoxTextFragmenten.Items.Clear();
                comboBoxTextFragmenten.Text = "";
                comboBoxTextFragmenten.Items.Add("<Default>");
                DirectoryInfo info = new DirectoryInfo(documentDir);
                FileInfo[] files = info.GetFiles("*.srl");
                foreach (FileInfo file in files)
                {
                    comboBoxTextFragmenten.Items.Add(file.Name.ToString());
                }
                comboBoxTextFragmenten.Text = "<Default>";

                comboBoxEmoticons.Items.Clear();
                comboBoxEmoticons.Text = "";
                comboBoxEmoticons.Items.Add("<Default>");
                files = info.GetFiles("*.sri");
                foreach (FileInfo file in files)
                {
                    comboBoxEmoticons.Items.Add(file.Name.ToString());
                }
                comboBoxEmoticons.Text = "<Default>";
            }
        }
    }
}