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
            this.chkdemo = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbostartup = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtdemo = new System.Windows.Forms.TextBox();
            this.btndemotxt = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(668, 507);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Controls.Add(this.tableLayoutPanel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(660, 481);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(654, 437);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(646, 404);
            this.panel1.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnlogo);
            this.groupBox5.Controls.Add(this.txtlogo);
            this.groupBox5.Controls.Add(this.chklogo);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(0, 233);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(646, 53);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            // 
            // btnlogo
            // 
            this.btnlogo.Location = new System.Drawing.Point(561, 18);
            this.btnlogo.Name = "btnlogo";
            this.btnlogo.Size = new System.Drawing.Size(71, 20);
            this.btnlogo.TabIndex = 2;
            this.btnlogo.Text = "浏览";
            this.btnlogo.UseVisualStyleBackColor = true;
            this.btnlogo.Click += new System.EventHandler(this.btnlogo_Click);
            // 
            // txtlogo
            // 
            this.txtlogo.Location = new System.Drawing.Point(196, 18);
            this.txtlogo.Name = "txtlogo";
            this.txtlogo.ReadOnly = true;
            this.txtlogo.Size = new System.Drawing.Size(353, 21);
            this.txtlogo.TabIndex = 1;
            // 
            // chklogo
            // 
            this.chklogo.AutoSize = true;
            this.chklogo.Location = new System.Drawing.Point(52, 20);
            this.chklogo.Name = "chklogo";
            this.chklogo.Size = new System.Drawing.Size(72, 16);
            this.chklogo.TabIndex = 0;
            this.chklogo.Text = "图片logo";
            this.chklogo.UseVisualStyleBackColor = true;
            this.chklogo.CheckedChanged += new System.EventHandler(this.chklogo_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtshort);
            this.groupBox4.Controls.Add(this.chkshort);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 180);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(646, 53);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            // 
            // txtshort
            // 
            this.txtshort.Location = new System.Drawing.Point(196, 18);
            this.txtshort.Name = "txtshort";
            this.txtshort.Size = new System.Drawing.Size(353, 21);
            this.txtshort.TabIndex = 1;
            this.txtshort.TextChanged += new System.EventHandler(this.txtshort_TextChanged);
            // 
            // chkshort
            // 
            this.chkshort.AutoSize = true;
            this.chkshort.Location = new System.Drawing.Point(52, 20);
            this.chkshort.Name = "chkshort";
            this.chkshort.Size = new System.Drawing.Size(96, 16);
            this.chkshort.TabIndex = 0;
            this.chkshort.Text = "软件缩写修改";
            this.chkshort.UseVisualStyleBackColor = true;
            this.chkshort.CheckedChanged += new System.EventHandler(this.chkshort_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtAppTitle);
            this.groupBox3.Controls.Add(this.chktitle);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 127);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(646, 53);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // txtAppTitle
            // 
            this.txtAppTitle.Location = new System.Drawing.Point(196, 18);
            this.txtAppTitle.Name = "txtAppTitle";
            this.txtAppTitle.Size = new System.Drawing.Size(353, 21);
            this.txtAppTitle.TabIndex = 1;
            this.txtAppTitle.TextChanged += new System.EventHandler(this.txtAppTitle_TextChanged);
            // 
            // chktitle
            // 
            this.chktitle.AutoSize = true;
            this.chktitle.Location = new System.Drawing.Point(52, 20);
            this.chktitle.Name = "chktitle";
            this.chktitle.Size = new System.Drawing.Size(96, 16);
            this.chktitle.TabIndex = 0;
            this.chktitle.Text = "软件标题修改";
            this.chktitle.UseVisualStyleBackColor = true;
            this.chktitle.CheckedChanged += new System.EventHandler(this.chktitle_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btndemotxt);
            this.groupBox2.Controls.Add(this.txtdemo);
            this.groupBox2.Controls.Add(this.chkdemo);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(646, 49);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // chkdemo
            // 
            this.chkdemo.AutoSize = true;
            this.chkdemo.Location = new System.Drawing.Point(52, 20);
            this.chkdemo.Name = "chkdemo";
            this.chkdemo.Size = new System.Drawing.Size(138, 16);
            this.chkdemo.TabIndex = 0;
            this.chkdemo.Text = "在\"演示\"模式下工作 ";
            this.chkdemo.UseVisualStyleBackColor = true;
            this.chkdemo.CheckedChanged += new System.EventHandler(this.chkdemo_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbostartup);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.Color.Teal;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(646, 78);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "缺省启动";
            // 
            // cbostartup
            // 
            this.cbostartup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbostartup.FormattingEnabled = true;
            this.cbostartup.Location = new System.Drawing.Point(196, 42);
            this.cbostartup.Name = "cbostartup";
            this.cbostartup.Size = new System.Drawing.Size(353, 20);
            this.cbostartup.TabIndex = 2;
            this.cbostartup.SelectionChangeCommitted += new System.EventHandler(this.cbostartup_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(50, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "启动模式：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(49, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "选择软件启动时默认启动界面";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(654, 38);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(579, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "设置系统选项";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Location = new System.Drawing.Point(590, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(32, 30);
            this.panel4.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtdemo
            // 
            this.txtdemo.Location = new System.Drawing.Point(196, 18);
            this.txtdemo.Name = "txtdemo";
            this.txtdemo.Size = new System.Drawing.Size(352, 21);
            this.txtdemo.TabIndex = 1;
            // 
            // btndemotxt
            // 
            this.btndemotxt.Location = new System.Drawing.Point(561, 19);
            this.btndemotxt.Name = "btndemotxt";
            this.btndemotxt.Size = new System.Drawing.Size(71, 20);
            this.btndemotxt.TabIndex = 3;
            this.btndemotxt.Text = "浏览";
            this.btndemotxt.UseVisualStyleBackColor = true;
            this.btndemotxt.Click += new System.EventHandler(this.btndemotxt_Click);
            // 
            // UserControl系统选项
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "UserControl系统选项";
            this.Size = new System.Drawing.Size(668, 507);
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
    }
}
