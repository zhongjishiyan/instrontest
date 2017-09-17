using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
//using TabText1.Properties;
using AppleLabApplication.Properties; 
using System.Runtime.Serialization.Formatters.Binary;
using Compenkie;

namespace AppleLabApplication
{
    public partial class HelpControl : TabControl
    {
        private System.Windows.Forms.TabPage[] tabPage = new TabPage[17];
        private RichTextBoxExtend[] richTextBox = new RichTextBoxExtend[17];

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public HelpControl()
        {
            for (int teller = 0; teller < 17; teller++)
            {
                richTextBox[teller] = new RichTextBoxExtend();
                // 
                // richTextBox1
                // 
                richTextBox[teller].Dock = System.Windows.Forms.DockStyle.Fill;
                richTextBox[teller].Location = new System.Drawing.Point(3, 3);
                richTextBox[teller].Size = new System.Drawing.Size(397, 380);
                richTextBox[teller].TabIndex = teller;
                richTextBox[teller].TabStop = true;
                richTextBox[teller].ReadOnly = true;

            }

            //Open the file written above and read values from it.
            this.TabPages.Clear();
            MemoryStream stream =new MemoryStream(Resources.HelpFile);
            BinaryFormatter bformatter = new BinaryFormatter();
            int maxTab = (int)bformatter.Deserialize(stream);
            for (int teller = 0; teller < maxTab; teller++)
            {
                AddPage(teller);
                richTextBox[teller].Clear();
                richTextBox[teller].printLandScape = (bool)bformatter.Deserialize(stream);
                richTextBox[teller].printMarginTop = (int)bformatter.Deserialize(stream);
                richTextBox[teller].printMarginLeft = (int)bformatter.Deserialize(stream);
                richTextBox[teller].printMarginRight = (int)bformatter.Deserialize(stream);
                richTextBox[teller].printMarginBottom = (int)bformatter.Deserialize(stream);

                tabPage[teller].Text = bformatter.Deserialize(stream).ToString();
                tabPage[teller].Tag = bformatter.Deserialize(stream).ToString();
                richTextBox[teller].SelectedRtf = bformatter.Deserialize(stream).ToString();
            }
            stream.Close();

            
            // 
            // tabControl1
            // 
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 24);
            this.Name = "tabControl1";
            this.SelectedIndex = 0;
            this.Size = new System.Drawing.Size(292, 242);
            this.TabIndex = 0;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.SuspendLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public void AddPage(int pagenummer)
        {
            tabPage[pagenummer] = new TabPage();
            tabPage[pagenummer].Location = new System.Drawing.Point(4, 22);
            tabPage[pagenummer].Name = "tabPage" + pagenummer.ToString();
            tabPage[pagenummer].Padding = new System.Windows.Forms.Padding(3);
            tabPage[pagenummer].Size = new System.Drawing.Size(403, 386);
            tabPage[pagenummer].TabIndex = pagenummer;
            tabPage[pagenummer].UseVisualStyleBackColor = true;
            tabPage[pagenummer].Controls.Add(richTextBox[pagenummer]);
            Controls.Add(tabPage[pagenummer]);
            tabPage[pagenummer].SuspendLayout();
            tabPage[pagenummer].ResumeLayout(false);
            int aantal = Controls.Count;
            SelectedIndex = aantal - 1;
        }
    }



}