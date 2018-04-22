namespace TabHeaderDemo.Frm
{
    partial class FormPanelSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPanelSet));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbok = new System.Windows.Forms.ToolStripButton();
            this.tsbcancel = new System.Windows.Forms.ToolStripButton();
            this.tsbhelp = new System.Windows.Forms.ToolStripButton();
            this.chkalarm = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkslimit = new System.Windows.Forms.CheckBox();
            this.chkhlimit = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtstop = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtdest = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtdown = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtkeep = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtup = new System.Windows.Forms.TextBox();
            this.chkcyclc = new System.Windows.Forms.CheckBox();
            this.toolStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbok,
            this.tsbcancel,
            this.tsbhelp});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(372, 25);
            this.toolStrip2.TabIndex = 5;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbok
            // 
            this.tsbok.Image = ((System.Drawing.Image)(resources.GetObject("tsbok.Image")));
            this.tsbok.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbok.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbok.Name = "tsbok";
            this.tsbok.Size = new System.Drawing.Size(54, 22);
            this.tsbok.Text = "确认";
            this.tsbok.Click += new System.EventHandler(this.tsbok_Click);
            // 
            // tsbcancel
            // 
            this.tsbcancel.Image = ((System.Drawing.Image)(resources.GetObject("tsbcancel.Image")));
            this.tsbcancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbcancel.Name = "tsbcancel";
            this.tsbcancel.Size = new System.Drawing.Size(52, 22);
            this.tsbcancel.Text = "取消";
            this.tsbcancel.Click += new System.EventHandler(this.tsbcancel_Click);
            // 
            // tsbhelp
            // 
            this.tsbhelp.Image = ((System.Drawing.Image)(resources.GetObject("tsbhelp.Image")));
            this.tsbhelp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbhelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbhelp.Name = "tsbhelp";
            this.tsbhelp.Size = new System.Drawing.Size(54, 22);
            this.tsbhelp.Text = "帮助";
            this.tsbhelp.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // chkalarm
            // 
            this.chkalarm.AutoSize = true;
            this.chkalarm.Location = new System.Drawing.Point(24, 95);
            this.chkalarm.Name = "chkalarm";
            this.chkalarm.Size = new System.Drawing.Size(48, 16);
            this.chkalarm.TabIndex = 8;
            this.chkalarm.Text = "报警";
            this.chkalarm.UseVisualStyleBackColor = true;
            this.chkalarm.CheckedChanged += new System.EventHandler(this.chkalarm_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkslimit);
            this.groupBox1.Controls.Add(this.chkhlimit);
            this.groupBox1.Controls.Add(this.chkalarm);
            this.groupBox1.Location = new System.Drawing.Point(54, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 130);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "提示";
            // 
            // chkslimit
            // 
            this.chkslimit.AutoSize = true;
            this.chkslimit.Location = new System.Drawing.Point(24, 57);
            this.chkslimit.Name = "chkslimit";
            this.chkslimit.Size = new System.Drawing.Size(84, 16);
            this.chkslimit.TabIndex = 10;
            this.chkslimit.Text = "软限位保护";
            this.chkslimit.UseVisualStyleBackColor = true;
            this.chkslimit.CheckedChanged += new System.EventHandler(this.chkslimit_CheckedChanged);
            // 
            // chkhlimit
            // 
            this.chkhlimit.AutoSize = true;
            this.chkhlimit.Location = new System.Drawing.Point(24, 20);
            this.chkhlimit.Name = "chkhlimit";
            this.chkhlimit.Size = new System.Drawing.Size(84, 16);
            this.chkhlimit.TabIndex = 9;
            this.chkhlimit.Text = "硬限位保护";
            this.chkhlimit.UseVisualStyleBackColor = true;
            this.chkhlimit.CheckedChanged += new System.EventHandler(this.chkhlimit_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtstop);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtdest);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtdown);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtkeep);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtup);
            this.groupBox2.Location = new System.Drawing.Point(44, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(273, 211);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "文字修改";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "目标结束：";
            // 
            // txtstop
            // 
            this.txtstop.Location = new System.Drawing.Point(123, 172);
            this.txtstop.Name = "txtstop";
            this.txtstop.Size = new System.Drawing.Size(134, 21);
            this.txtstop.TabIndex = 22;
            this.txtstop.TextChanged += new System.EventHandler(this.txtstop_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "目标开始：";
            // 
            // txtdest
            // 
            this.txtdest.Location = new System.Drawing.Point(123, 136);
            this.txtdest.Name = "txtdest";
            this.txtdest.Size = new System.Drawing.Size(134, 21);
            this.txtdest.TabIndex = 20;
            this.txtdest.TextChanged += new System.EventHandler(this.txtdest_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "下降：";
            // 
            // txtdown
            // 
            this.txtdown.Location = new System.Drawing.Point(123, 95);
            this.txtdown.Name = "txtdown";
            this.txtdown.Size = new System.Drawing.Size(134, 21);
            this.txtdown.TabIndex = 18;
            this.txtdown.TextChanged += new System.EventHandler(this.txtdown_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "保持：";
            // 
            // txtkeep
            // 
            this.txtkeep.Location = new System.Drawing.Point(123, 57);
            this.txtkeep.Name = "txtkeep";
            this.txtkeep.Size = new System.Drawing.Size(134, 21);
            this.txtkeep.TabIndex = 16;
            this.txtkeep.TextChanged += new System.EventHandler(this.txtkeep_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "上升：";
            // 
            // txtup
            // 
            this.txtup.Location = new System.Drawing.Point(123, 20);
            this.txtup.Name = "txtup";
            this.txtup.Size = new System.Drawing.Size(134, 21);
            this.txtup.TabIndex = 14;
            this.txtup.TextChanged += new System.EventHandler(this.txtup_TextChanged);
            // 
            // chkcyclc
            // 
            this.chkcyclc.AutoSize = true;
            this.chkcyclc.Location = new System.Drawing.Point(85, 395);
            this.chkcyclc.Name = "chkcyclc";
            this.chkcyclc.Size = new System.Drawing.Size(84, 16);
            this.chkcyclc.TabIndex = 15;
            this.chkcyclc.Text = "周期波操作";
            this.chkcyclc.UseVisualStyleBackColor = true;
            this.chkcyclc.CheckedChanged += new System.EventHandler(this.chkcyclc_CheckedChanged);
            // 
            // FormPanelSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 456);
            this.Controls.Add(this.chkcyclc);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPanelSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "操作面板设置";
            this.Load += new System.EventHandler(this.FormPanelSet_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbok;
        private System.Windows.Forms.ToolStripButton tsbcancel;
        private System.Windows.Forms.ToolStripButton tsbhelp;
        private System.Windows.Forms.CheckBox chkalarm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkslimit;
        private System.Windows.Forms.CheckBox chkhlimit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtdown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtkeep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtstop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtdest;
        private System.Windows.Forms.CheckBox chkcyclc;
    }
}