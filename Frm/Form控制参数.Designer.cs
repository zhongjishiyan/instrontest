namespace TabHeaderDemo.Frm
{
    partial class Form控制参数
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form控制参数));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.numstarinend = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.numstarinstart = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.numstrainspeed = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.numend = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.numstart = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.numericEdit1 = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericEdit2 = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numstarinend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numstarinstart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numstrainspeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numstart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericEdit1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.lblUnit);
            this.groupBox1.Controls.Add(this.numericEdit1);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(1, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(441, 289);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "等速力";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(33, 48);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(71, 16);
            this.radioButton2.TabIndex = 17;
            this.radioButton2.Text = "应力速度";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(33, 21);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(59, 16);
            this.radioButton1.TabIndex = 16;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "力速度";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Location = new System.Drawing.Point(25, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(410, 197);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "高级计算输入";
            this.groupBox2.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.numstarinend);
            this.panel3.Controls.Add(this.numstarinstart);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.numstrainspeed);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.numend);
            this.panel3.Controls.Add(this.numstart);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(8, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(396, 163);
            this.panel3.TabIndex = 15;
            // 
            // numstarinend
            // 
            this.numstarinend.BackColor = System.Drawing.Color.White;
            this.numstarinend.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(3);
            this.numstarinend.InteractionMode = NationalInstruments.UI.NumericEditInteractionModes.Text;
            this.numstarinend.Location = new System.Drawing.Point(262, 133);
            this.numstarinend.Name = "numstarinend";
            this.numstarinend.Size = new System.Drawing.Size(86, 21);
            this.numstarinend.TabIndex = 32;
            // 
            // numstarinstart
            // 
            this.numstarinstart.BackColor = System.Drawing.Color.White;
            this.numstarinstart.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(3);
            this.numstarinstart.InteractionMode = NationalInstruments.UI.NumericEditInteractionModes.Text;
            this.numstarinstart.Location = new System.Drawing.Point(262, 105);
            this.numstarinstart.Name = "numstarinstart";
            this.numstarinstart.Size = new System.Drawing.Size(86, 21);
            this.numstarinstart.TabIndex = 31;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(356, 139);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 12);
            this.label13.TabIndex = 30;
            this.label13.Text = "MPa";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(356, 110);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 12);
            this.label14.TabIndex = 29;
            this.label14.Text = "MPa";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(179, 139);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 12);
            this.label15.TabIndex = 28;
            this.label15.Text = "围压结束力：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(178, 110);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 12);
            this.label16.TabIndex = 27;
            this.label16.Text = "围压起始力：";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(28, 135);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(84, 20);
            this.button3.TabIndex = 26;
            this.button3.Text = "计算";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // numstrainspeed
            // 
            this.numstrainspeed.BackColor = System.Drawing.Color.White;
            this.numstrainspeed.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(3);
            this.numstrainspeed.InteractionMode = NationalInstruments.UI.NumericEditInteractionModes.Text;
            this.numstrainspeed.Location = new System.Drawing.Point(262, 77);
            this.numstrainspeed.Name = "numstrainspeed";
            this.numstrainspeed.Size = new System.Drawing.Size(86, 21);
            this.numstrainspeed.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(356, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 12);
            this.label12.TabIndex = 24;
            this.label12.Text = "MPa/S";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(190, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 23;
            this.label11.Text = "围压速度：";
            // 
            // numend
            // 
            this.numend.BackColor = System.Drawing.Color.White;
            this.numend.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(3);
            this.numend.InteractionMode = NationalInstruments.UI.NumericEditInteractionModes.Text;
            this.numend.Location = new System.Drawing.Point(262, 49);
            this.numend.Name = "numend";
            this.numend.Size = new System.Drawing.Size(86, 21);
            this.numend.TabIndex = 22;
            // 
            // numstart
            // 
            this.numstart.BackColor = System.Drawing.Color.White;
            this.numstart.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(3);
            this.numstart.InteractionMode = NationalInstruments.UI.NumericEditInteractionModes.Text;
            this.numstart.Location = new System.Drawing.Point(262, 21);
            this.numstart.Name = "numstart";
            this.numstart.Size = new System.Drawing.Size(86, 21);
            this.numstart.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(355, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 20;
            this.label10.Text = "kN";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(354, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 18;
            this.label9.Text = "kN";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(202, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "结束力：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(202, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "起始力：";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(342, 20);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(29, 12);
            this.lblUnit.TabIndex = 3;
            this.lblUnit.Text = "kN/s";
            // 
            // numericEdit1
            // 
            this.numericEdit1.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(3);
            this.numericEdit1.InteractionMode = NationalInstruments.UI.NumericEditInteractionModes.Text;
            this.numericEdit1.Location = new System.Drawing.Point(192, 16);
            this.numericEdit1.Name = "numericEdit1";
            this.numericEdit1.Size = new System.Drawing.Size(112, 21);
            this.numericEdit1.TabIndex = 1;
            this.numericEdit1.AfterChangeValue += new NationalInstruments.UI.AfterChangeNumericValueEventHandler(this.numericEdit1_AfterChangeValue);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.numericEdit2);
            this.panel1.Location = new System.Drawing.Point(192, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(193, 27);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "≈";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "MPa/s";
            // 
            // numericEdit2
            // 
            this.numericEdit2.BackColor = System.Drawing.Color.White;
            this.numericEdit2.Enabled = false;
            this.numericEdit2.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(3);
            this.numericEdit2.InteractionMode = NationalInstruments.UI.NumericEditInteractionModes.Text;
            this.numericEdit2.Location = new System.Drawing.Point(21, 3);
            this.numericEdit2.Name = "numericEdit2";
            this.numericEdit2.Size = new System.Drawing.Size(112, 21);
            this.numericEdit2.TabIndex = 4;
            this.numericEdit2.AfterChangeValue += new NationalInstruments.UI.AfterChangeNumericValueEventHandler(this.numericEdit2_AfterChangeValue);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(448, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "确定";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(448, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = "取消";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form控制参数
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 302);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form控制参数";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "控制参数";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numstarinend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numstarinstart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numstrainspeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numstart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericEdit1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public NationalInstruments.UI.WindowsForms.NumericEdit numericEdit1;
        private System.Windows.Forms.Label label3;
        public NationalInstruments.UI.WindowsForms.NumericEdit numericEdit2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblUnit;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        public NationalInstruments.UI.WindowsForms.NumericEdit numstarinend;
        public NationalInstruments.UI.WindowsForms.NumericEdit numstarinstart;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button3;
        public NationalInstruments.UI.WindowsForms.NumericEdit numstrainspeed;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        public NationalInstruments.UI.WindowsForms.NumericEdit numend;
        public NationalInstruments.UI.WindowsForms.NumericEdit numstart;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.RadioButton radioButton1;
        public System.Windows.Forms.RadioButton radioButton2;
        public System.Windows.Forms.GroupBox groupBox2;
    }
}