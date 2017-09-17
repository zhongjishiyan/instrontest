namespace TabHeaderDemo.Frm
{
    partial class Form循环执行
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form循环执行));
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericEdit1 = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.chkcyclic = new System.Windows.Forms.CheckBox();
            this.numericEdit2 = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(287, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 31);
            this.button1.TabIndex = 3;
            this.button1.Text = "确定";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericEdit2);
            this.groupBox1.Controls.Add(this.chkcyclic);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numericEdit1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 90);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "返回到步骤：";
            // 
            // numericEdit1
            // 
            this.numericEdit1.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(0);
            this.numericEdit1.InteractionMode = NationalInstruments.UI.NumericEditInteractionModes.Text;
            this.numericEdit1.Location = new System.Drawing.Point(124, 21);
            this.numericEdit1.Name = "numericEdit1";
            this.numericEdit1.Size = new System.Drawing.Size(112, 21);
            this.numericEdit1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "返回次数:";
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(287, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 29);
            this.button2.TabIndex = 4;
            this.button2.Text = "取消";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // chkcyclic
            // 
            this.chkcyclic.AutoSize = true;
            this.chkcyclic.Location = new System.Drawing.Point(22, 0);
            this.chkcyclic.Name = "chkcyclic";
            this.chkcyclic.Size = new System.Drawing.Size(72, 16);
            this.chkcyclic.TabIndex = 4;
            this.chkcyclic.Text = "循环执行";
            this.chkcyclic.UseVisualStyleBackColor = true;
            // 
            // numericEdit2
            // 
            this.numericEdit2.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(0);
            this.numericEdit2.InteractionMode = NationalInstruments.UI.NumericEditInteractionModes.Text;
            this.numericEdit2.Location = new System.Drawing.Point(124, 53);
            this.numericEdit2.Name = "numericEdit2";
            this.numericEdit2.Size = new System.Drawing.Size(112, 21);
            this.numericEdit2.TabIndex = 5;
            // 
            // Form循环执行
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 102);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form循环执行";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "循环";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        public NationalInstruments.UI.WindowsForms.NumericEdit numericEdit1;
        public NationalInstruments.UI.WindowsForms.NumericEdit numericEdit2;
        public System.Windows.Forms.CheckBox chkcyclic;
    }
}