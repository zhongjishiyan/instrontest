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
            resources.ApplyResources(this.toolStrip2, "toolStrip2");
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbok,
            this.tsbcancel,
            this.tsbhelp});
            this.toolStrip2.Name = "toolStrip2";
            // 
            // tsbok
            // 
            resources.ApplyResources(this.tsbok, "tsbok");
            this.tsbok.Name = "tsbok";
            this.tsbok.Click += new System.EventHandler(this.tsbok_Click);
            // 
            // tsbcancel
            // 
            resources.ApplyResources(this.tsbcancel, "tsbcancel");
            this.tsbcancel.Name = "tsbcancel";
            this.tsbcancel.Click += new System.EventHandler(this.tsbcancel_Click);
            // 
            // tsbhelp
            // 
            resources.ApplyResources(this.tsbhelp, "tsbhelp");
            this.tsbhelp.Name = "tsbhelp";
            this.tsbhelp.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // chkalarm
            // 
            resources.ApplyResources(this.chkalarm, "chkalarm");
            this.chkalarm.Name = "chkalarm";
            this.chkalarm.UseVisualStyleBackColor = true;
            this.chkalarm.CheckedChanged += new System.EventHandler(this.chkalarm_CheckedChanged);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.chkslimit);
            this.groupBox1.Controls.Add(this.chkhlimit);
            this.groupBox1.Controls.Add(this.chkalarm);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // chkslimit
            // 
            resources.ApplyResources(this.chkslimit, "chkslimit");
            this.chkslimit.Name = "chkslimit";
            this.chkslimit.UseVisualStyleBackColor = true;
            this.chkslimit.CheckedChanged += new System.EventHandler(this.chkslimit_CheckedChanged);
            // 
            // chkhlimit
            // 
            resources.ApplyResources(this.chkhlimit, "chkhlimit");
            this.chkhlimit.Name = "chkhlimit";
            this.chkhlimit.UseVisualStyleBackColor = true;
            this.chkhlimit.CheckedChanged += new System.EventHandler(this.chkhlimit_CheckedChanged);
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
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
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtstop
            // 
            resources.ApplyResources(this.txtstop, "txtstop");
            this.txtstop.Name = "txtstop";
            this.txtstop.TextChanged += new System.EventHandler(this.txtstop_TextChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtdest
            // 
            resources.ApplyResources(this.txtdest, "txtdest");
            this.txtdest.Name = "txtdest";
            this.txtdest.TextChanged += new System.EventHandler(this.txtdest_TextChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtdown
            // 
            resources.ApplyResources(this.txtdown, "txtdown");
            this.txtdown.Name = "txtdown";
            this.txtdown.TextChanged += new System.EventHandler(this.txtdown_TextChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtkeep
            // 
            resources.ApplyResources(this.txtkeep, "txtkeep");
            this.txtkeep.Name = "txtkeep";
            this.txtkeep.TextChanged += new System.EventHandler(this.txtkeep_TextChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtup
            // 
            resources.ApplyResources(this.txtup, "txtup");
            this.txtup.Name = "txtup";
            this.txtup.TextChanged += new System.EventHandler(this.txtup_TextChanged);
            // 
            // chkcyclc
            // 
            resources.ApplyResources(this.chkcyclc, "chkcyclc");
            this.chkcyclc.Name = "chkcyclc";
            this.chkcyclc.UseVisualStyleBackColor = true;
            this.chkcyclc.CheckedChanged += new System.EventHandler(this.chkcyclc_CheckedChanged);
            // 
            // FormPanelSet
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkcyclc);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPanelSet";
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