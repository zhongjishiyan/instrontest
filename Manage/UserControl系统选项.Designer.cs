namespace TabHeaderDemo
{
    partial class UserControl系统选项
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl系统选项));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbolanguage = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnlogo = new System.Windows.Forms.Button();
            this.txtlogo = new System.Windows.Forms.TextBox();
            this.chklogo = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtshort = new System.Windows.Forms.TextBox();
            this.chkshort = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtAppTitle = new System.Windows.Forms.TextBox();
            this.chktitle = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btndemotxt = new System.Windows.Forms.Button();
            this.txtdemo = new System.Windows.Forms.TextBox();
            this.chkdemo = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbostartup = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.panel1.Controls.Add(this.groupBox6);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Name = "panel1";
            // 
            // groupBox6
            // 
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.Controls.Add(this.cbolanguage);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            // 
            // cbolanguage
            // 
            resources.ApplyResources(this.cbolanguage, "cbolanguage");
            this.cbolanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbolanguage.FormattingEnabled = true;
            this.cbolanguage.Name = "cbolanguage";
            this.cbolanguage.SelectionChangeCommitted += new System.EventHandler(this.cbolanguage_SelectionChangeCommitted);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // groupBox5
            // 
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Controls.Add(this.btnlogo);
            this.groupBox5.Controls.Add(this.txtlogo);
            this.groupBox5.Controls.Add(this.chklogo);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // btnlogo
            // 
            resources.ApplyResources(this.btnlogo, "btnlogo");
            this.btnlogo.Name = "btnlogo";
            this.btnlogo.UseVisualStyleBackColor = true;
            this.btnlogo.Click += new System.EventHandler(this.btnlogo_Click);
            // 
            // txtlogo
            // 
            resources.ApplyResources(this.txtlogo, "txtlogo");
            this.txtlogo.Name = "txtlogo";
            this.txtlogo.ReadOnly = true;
            // 
            // chklogo
            // 
            resources.ApplyResources(this.chklogo, "chklogo");
            this.chklogo.Name = "chklogo";
            this.chklogo.UseVisualStyleBackColor = true;
            this.chklogo.CheckedChanged += new System.EventHandler(this.chklogo_CheckedChanged);
            // 
            // groupBox4
            // 
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Controls.Add(this.txtshort);
            this.groupBox4.Controls.Add(this.chkshort);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // txtshort
            // 
            resources.ApplyResources(this.txtshort, "txtshort");
            this.txtshort.Name = "txtshort";
            this.txtshort.TextChanged += new System.EventHandler(this.txtshort_TextChanged);
            // 
            // chkshort
            // 
            resources.ApplyResources(this.chkshort, "chkshort");
            this.chkshort.Name = "chkshort";
            this.chkshort.UseVisualStyleBackColor = true;
            this.chkshort.CheckedChanged += new System.EventHandler(this.chkshort_CheckedChanged);
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.txtAppTitle);
            this.groupBox3.Controls.Add(this.chktitle);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // txtAppTitle
            // 
            resources.ApplyResources(this.txtAppTitle, "txtAppTitle");
            this.txtAppTitle.Name = "txtAppTitle";
            this.txtAppTitle.TextChanged += new System.EventHandler(this.txtAppTitle_TextChanged);
            // 
            // chktitle
            // 
            resources.ApplyResources(this.chktitle, "chktitle");
            this.chktitle.Name = "chktitle";
            this.chktitle.UseVisualStyleBackColor = true;
            this.chktitle.CheckedChanged += new System.EventHandler(this.chktitle_CheckedChanged);
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.btndemotxt);
            this.groupBox2.Controls.Add(this.txtdemo);
            this.groupBox2.Controls.Add(this.chkdemo);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // btndemotxt
            // 
            resources.ApplyResources(this.btndemotxt, "btndemotxt");
            this.btndemotxt.Name = "btndemotxt";
            this.btndemotxt.UseVisualStyleBackColor = true;
            this.btndemotxt.Click += new System.EventHandler(this.btndemotxt_Click);
            // 
            // txtdemo
            // 
            resources.ApplyResources(this.txtdemo, "txtdemo");
            this.txtdemo.Name = "txtdemo";
            // 
            // chkdemo
            // 
            resources.ApplyResources(this.chkdemo, "chkdemo");
            this.chkdemo.Name = "chkdemo";
            this.chkdemo.UseVisualStyleBackColor = true;
            this.chkdemo.CheckedChanged += new System.EventHandler(this.chkdemo_CheckedChanged);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.cbostartup);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.Color.Teal;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // cbostartup
            // 
            resources.ApplyResources(this.cbostartup, "cbostartup");
            this.cbostartup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbostartup.FormattingEnabled = true;
            this.cbostartup.Name = "cbostartup";
            this.cbostartup.SelectedIndexChanged += new System.EventHandler(this.cbostartup_SelectedIndexChanged);
            this.cbostartup.SelectionChangeCommitted += new System.EventHandler(this.cbostartup_SelectionChangeCommitted);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Name = "label2";
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
            // panel4
            // 
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // UserControl系统选项
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "UserControl系统选项";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbostartup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkdemo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtAppTitle;
        private System.Windows.Forms.CheckBox chktitle;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtshort;
        private System.Windows.Forms.CheckBox chkshort;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnlogo;
        private System.Windows.Forms.TextBox txtlogo;
        private System.Windows.Forms.CheckBox chklogo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btndemotxt;
        private System.Windows.Forms.TextBox txtdemo;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbolanguage;
    }
}
