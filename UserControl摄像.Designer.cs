namespace TabHeaderDemo
{
    partial class UserControl摄像
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl摄像));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnfile = new System.Windows.Forms.Button();
            this.txtplayfile = new System.Windows.Forms.TextBox();
            this.chkplayfile = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtshort = new System.Windows.Forms.TextBox();
            this.chkautorecord = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtAppTitle = new System.Windows.Forms.TextBox();
            this.chkautoplay = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnplay = new System.Windows.Forms.Button();
            this.txtplay = new System.Windows.Forms.TextBox();
            this.chkplay = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Controls.Add(this.tableLayoutPanel3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Name = "panel1";
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox5
            // 
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Controls.Add(this.btnfile);
            this.groupBox5.Controls.Add(this.txtplayfile);
            this.groupBox5.Controls.Add(this.chkplayfile);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // btnfile
            // 
            resources.ApplyResources(this.btnfile, "btnfile");
            this.btnfile.Name = "btnfile";
            this.btnfile.UseVisualStyleBackColor = true;
            this.btnfile.Click += new System.EventHandler(this.btnfile_Click);
            // 
            // txtplayfile
            // 
            resources.ApplyResources(this.txtplayfile, "txtplayfile");
            this.txtplayfile.Name = "txtplayfile";
            this.txtplayfile.ReadOnly = true;
            // 
            // chkplayfile
            // 
            resources.ApplyResources(this.chkplayfile, "chkplayfile");
            this.chkplayfile.Name = "chkplayfile";
            this.chkplayfile.UseVisualStyleBackColor = true;
            this.chkplayfile.CheckedChanged += new System.EventHandler(this.chkplayfile_CheckedChanged);
            // 
            // groupBox4
            // 
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Controls.Add(this.txtshort);
            this.groupBox4.Controls.Add(this.chkautorecord);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // txtshort
            // 
            resources.ApplyResources(this.txtshort, "txtshort");
            this.txtshort.Name = "txtshort";
            this.txtshort.TextChanged += new System.EventHandler(this.txtshort_TextChanged);
            // 
            // chkautorecord
            // 
            resources.ApplyResources(this.chkautorecord, "chkautorecord");
            this.chkautorecord.Name = "chkautorecord";
            this.chkautorecord.UseVisualStyleBackColor = true;
            this.chkautorecord.CheckedChanged += new System.EventHandler(this.chkautorecord_CheckedChanged);
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.txtAppTitle);
            this.groupBox3.Controls.Add(this.chkautoplay);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // txtAppTitle
            // 
            resources.ApplyResources(this.txtAppTitle, "txtAppTitle");
            this.txtAppTitle.Name = "txtAppTitle";
            this.txtAppTitle.TextChanged += new System.EventHandler(this.txtAppTitle_TextChanged);
            // 
            // chkautoplay
            // 
            resources.ApplyResources(this.chkautoplay, "chkautoplay");
            this.chkautoplay.Name = "chkautoplay";
            this.chkautoplay.UseVisualStyleBackColor = true;
            this.chkautoplay.CheckedChanged += new System.EventHandler(this.chkautoplay_CheckedChanged);
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.btnplay);
            this.groupBox2.Controls.Add(this.txtplay);
            this.groupBox2.Controls.Add(this.chkplay);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // btnplay
            // 
            resources.ApplyResources(this.btnplay, "btnplay");
            this.btnplay.Name = "btnplay";
            this.btnplay.UseVisualStyleBackColor = true;
            this.btnplay.Click += new System.EventHandler(this.btnplay_Click);
            // 
            // txtplay
            // 
            resources.ApplyResources(this.txtplay, "txtplay");
            this.txtplay.Name = "txtplay";
            this.txtplay.ReadOnly = true;
            // 
            // chkplay
            // 
            resources.ApplyResources(this.chkplay, "chkplay");
            this.chkplay.Name = "chkplay";
            this.chkplay.UseVisualStyleBackColor = true;
            this.chkplay.CheckedChanged += new System.EventHandler(this.chkplay_CheckedChanged);
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Name = "label1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // panel4
            // 
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // UserControl摄像
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "UserControl摄像";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkplay;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtAppTitle;
        private System.Windows.Forms.CheckBox chkautoplay;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtshort;
        private System.Windows.Forms.CheckBox chkautorecord;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnfile;
        private System.Windows.Forms.TextBox txtplayfile;
        private System.Windows.Forms.CheckBox chkplayfile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnplay;
        private System.Windows.Forms.TextBox txtplay;
    }
}
