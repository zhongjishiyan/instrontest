namespace TabHeaderDemo.Frm
{
    partial class Form跳转条件
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form跳转条件));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericEdit4 = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericEdit3 = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.numericEdit2 = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.rbtnload = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtnpos = new System.Windows.Forms.RadioButton();
            this.numericEdit1 = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.rbtnstrain = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnstrain);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numericEdit3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numericEdit2);
            this.groupBox1.Controls.Add(this.rbtnload);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rbtnpos);
            this.groupBox1.Controls.Add(this.numericEdit1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 264);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "自动跳转";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.numericEdit4);
            this.panel1.Location = new System.Drawing.Point(119, 108);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(193, 27);
            this.panel1.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "≈";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(157, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "MPa";
            // 
            // numericEdit4
            // 
            this.numericEdit4.BackColor = System.Drawing.Color.White;
            this.numericEdit4.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(3);
            this.numericEdit4.InteractionMode = NationalInstruments.UI.NumericEditInteractionModes.Text;
            this.numericEdit4.Location = new System.Drawing.Point(26, 3);
            this.numericEdit4.Name = "numericEdit4";
            this.numericEdit4.Size = new System.Drawing.Size(112, 21);
            this.numericEdit4.TabIndex = 4;
            this.numericEdit4.AfterChangeValue += new NationalInstruments.UI.AfterChangeNumericValueEventHandler(this.numericEdit4_AfterChangeValue);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "保持时间:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(283, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "S";
            // 
            // numericEdit3
            // 
            this.numericEdit3.InteractionMode = NationalInstruments.UI.NumericEditInteractionModes.Text;
            this.numericEdit3.Location = new System.Drawing.Point(145, 178);
            this.numericEdit3.Name = "numericEdit3";
            this.numericEdit3.Size = new System.Drawing.Size(112, 21);
            this.numericEdit3.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "kN";
            // 
            // numericEdit2
            // 
            this.numericEdit2.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(3);
            this.numericEdit2.InteractionMode = NationalInstruments.UI.NumericEditInteractionModes.Text;
            this.numericEdit2.Location = new System.Drawing.Point(145, 72);
            this.numericEdit2.Name = "numericEdit2";
            this.numericEdit2.Size = new System.Drawing.Size(112, 21);
            this.numericEdit2.TabIndex = 5;
            this.numericEdit2.AfterChangeValue += new NationalInstruments.UI.AfterChangeNumericValueEventHandler(this.numericEdit2_AfterChangeValue);
            // 
            // rbtnload
            // 
            this.rbtnload.AutoSize = true;
            this.rbtnload.Location = new System.Drawing.Point(12, 72);
            this.rbtnload.Name = "rbtnload";
            this.rbtnload.Size = new System.Drawing.Size(95, 16);
            this.rbtnload.TabIndex = 4;
            this.rbtnload.TabStop = true;
            this.rbtnload.Text = "当负荷到达：";
            this.rbtnload.UseVisualStyleBackColor = true;
            this.rbtnload.CheckedChanged += new System.EventHandler(this.rbtnload_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(277, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "mm";
            // 
            // rbtnpos
            // 
            this.rbtnpos.AutoSize = true;
            this.rbtnpos.Location = new System.Drawing.Point(12, 29);
            this.rbtnpos.Name = "rbtnpos";
            this.rbtnpos.Size = new System.Drawing.Size(95, 16);
            this.rbtnpos.TabIndex = 2;
            this.rbtnpos.TabStop = true;
            this.rbtnpos.Text = "当位移到达：";
            this.rbtnpos.UseVisualStyleBackColor = true;
            this.rbtnpos.CheckedChanged += new System.EventHandler(this.rbtnpos_CheckedChanged);
            // 
            // numericEdit1
            // 
            this.numericEdit1.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(3);
            this.numericEdit1.InteractionMode = NationalInstruments.UI.NumericEditInteractionModes.Text;
            this.numericEdit1.Location = new System.Drawing.Point(145, 27);
            this.numericEdit1.Name = "numericEdit1";
            this.numericEdit1.Size = new System.Drawing.Size(112, 21);
            this.numericEdit1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(349, 49);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 29);
            this.button2.TabIndex = 4;
            this.button2.Text = "取消";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(349, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 31);
            this.button1.TabIndex = 3;
            this.button1.Text = "确定";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rbtnstrain
            // 
            this.rbtnstrain.AutoSize = true;
            this.rbtnstrain.Location = new System.Drawing.Point(12, 114);
            this.rbtnstrain.Name = "rbtnstrain";
            this.rbtnstrain.Size = new System.Drawing.Size(95, 16);
            this.rbtnstrain.TabIndex = 12;
            this.rbtnstrain.TabStop = true;
            this.rbtnstrain.Text = "当应力到达：";
            this.rbtnstrain.UseVisualStyleBackColor = true;
            this.rbtnstrain.CheckedChanged += new System.EventHandler(this.rbtnstrain_CheckedChanged);
            // 
            // Form跳转条件
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 264);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form跳转条件";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "跳转条件";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public NationalInstruments.UI.WindowsForms.NumericEdit numericEdit1;
        public NationalInstruments.UI.WindowsForms.NumericEdit numericEdit2;
        public System.Windows.Forms.RadioButton rbtnload;
        public System.Windows.Forms.RadioButton rbtnpos;
        private System.Windows.Forms.Label label3;
        public NationalInstruments.UI.WindowsForms.NumericEdit numericEdit3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public NationalInstruments.UI.WindowsForms.NumericEdit numericEdit4;
        public System.Windows.Forms.RadioButton rbtnstrain;
    }
}