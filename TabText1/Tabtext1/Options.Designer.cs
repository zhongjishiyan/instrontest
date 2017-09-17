namespace AppleLabApplication
{
    partial class Options
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.comboBoxEmoticons = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxTextFragmenten = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDocumentDir = new System.Windows.Forms.TextBox();
            this.buttondocumentDir = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(285, 146);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(376, 146);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Annuleer";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // comboBoxEmoticons
            // 
            this.comboBoxEmoticons.FormattingEnabled = true;
            this.comboBoxEmoticons.Items.AddRange(new object[] {
            "< None >"});
            this.comboBoxEmoticons.Location = new System.Drawing.Point(11, 73);
            this.comboBoxEmoticons.Name = "comboBoxEmoticons";
            this.comboBoxEmoticons.Size = new System.Drawing.Size(449, 21);
            this.comboBoxEmoticons.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Selecteer een bestand voor de emoticons";
            // 
            // comboBoxTextFragmenten
            // 
            this.comboBoxTextFragmenten.FormattingEnabled = true;
            this.comboBoxTextFragmenten.Items.AddRange(new object[] {
            "< None >"});
            this.comboBoxTextFragmenten.Location = new System.Drawing.Point(11, 119);
            this.comboBoxTextFragmenten.Name = "comboBoxTextFragmenten";
            this.comboBoxTextFragmenten.Size = new System.Drawing.Size(449, 21);
            this.comboBoxTextFragmenten.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(235, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Selecteer een bestand voor de tekst fragmenten";
            // 
            // textBoxDocumentDir
            // 
            this.textBoxDocumentDir.Location = new System.Drawing.Point(11, 25);
            this.textBoxDocumentDir.Name = "textBoxDocumentDir";
            this.textBoxDocumentDir.Size = new System.Drawing.Size(420, 20);
            this.textBoxDocumentDir.TabIndex = 10;
            // 
            // buttondocumentDir
            // 
            this.buttondocumentDir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttondocumentDir.BackColor = System.Drawing.Color.Yellow;
            this.buttondocumentDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttondocumentDir.Location = new System.Drawing.Point(437, 25);
            this.buttondocumentDir.Name = "buttondocumentDir";
            this.buttondocumentDir.Size = new System.Drawing.Size(23, 23);
            this.buttondocumentDir.TabIndex = 11;
            this.buttondocumentDir.Text = "...";
            this.buttondocumentDir.UseVisualStyleBackColor = false;
            this.buttondocumentDir.Click += new System.EventHandler(this.buttondocumentDir_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Selecteer een folder voor de documenten";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Folder voor de documenten van:";
            // 
            // Options
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(472, 177);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttondocumentDir);
            this.Controls.Add(this.textBoxDocumentDir);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxTextFragmenten);
            this.Controls.Add(this.comboBoxEmoticons);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Optie\'s";
            this.Load += new System.EventHandler(this.Options_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox comboBoxEmoticons;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.ComboBox comboBoxTextFragmenten;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDocumentDir;
        private System.Windows.Forms.Button buttondocumentDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label1;

    }
}