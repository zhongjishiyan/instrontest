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
            this.panel4 = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
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
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(646, 404);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnfile);
            this.groupBox5.Controls.Add(this.txtplayfile);
            this.groupBox5.Controls.Add(this.chkplayfile);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(0, 155);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(646, 53);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Visible = false;
            // 
            // btnfile
            // 
            this.btnfile.Location = new System.Drawing.Point(561, 18);
            this.btnfile.Name = "btnfile";
            this.btnfile.Size = new System.Drawing.Size(71, 20);
            this.btnfile.TabIndex = 2;
            this.btnfile.Text = "浏览";
            this.btnfile.UseVisualStyleBackColor = true;
            this.btnfile.Click += new System.EventHandler(this.btnfile_Click);
            // 
            // txtplayfile
            // 
            this.txtplayfile.Location = new System.Drawing.Point(196, 18);
            this.txtplayfile.Name = "txtplayfile";
            this.txtplayfile.ReadOnly = true;
            this.txtplayfile.Size = new System.Drawing.Size(353, 21);
            this.txtplayfile.TabIndex = 1;
            // 
            // chkplayfile
            // 
            this.chkplayfile.AutoSize = true;
            this.chkplayfile.Location = new System.Drawing.Point(52, 20);
            this.chkplayfile.Name = "chkplayfile";
            this.chkplayfile.Size = new System.Drawing.Size(120, 16);
            this.chkplayfile.TabIndex = 0;
            this.chkplayfile.Text = "播放曲线数据文件";
            this.chkplayfile.UseVisualStyleBackColor = true;
            this.chkplayfile.CheckedChanged += new System.EventHandler(this.chkplayfile_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtshort);
            this.groupBox4.Controls.Add(this.chkautorecord);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 102);
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
            this.txtshort.Visible = false;
            this.txtshort.TextChanged += new System.EventHandler(this.txtshort_TextChanged);
            // 
            // chkautorecord
            // 
            this.chkautorecord.AutoSize = true;
            this.chkautorecord.Location = new System.Drawing.Point(52, 20);
            this.chkautorecord.Name = "chkautorecord";
            this.chkautorecord.Size = new System.Drawing.Size(132, 16);
            this.chkautorecord.TabIndex = 0;
            this.chkautorecord.Text = "试验开始时自动录制";
            this.chkautorecord.UseVisualStyleBackColor = true;
            this.chkautorecord.CheckedChanged += new System.EventHandler(this.chkautorecord_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtAppTitle);
            this.groupBox3.Controls.Add(this.chkautoplay);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 49);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(646, 53);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Visible = false;
            // 
            // txtAppTitle
            // 
            this.txtAppTitle.Location = new System.Drawing.Point(196, 18);
            this.txtAppTitle.Name = "txtAppTitle";
            this.txtAppTitle.Size = new System.Drawing.Size(353, 21);
            this.txtAppTitle.TabIndex = 1;
            this.txtAppTitle.Visible = false;
            this.txtAppTitle.TextChanged += new System.EventHandler(this.txtAppTitle_TextChanged);
            // 
            // chkautoplay
            // 
            this.chkautoplay.AutoSize = true;
            this.chkautoplay.Location = new System.Drawing.Point(52, 20);
            this.chkautoplay.Name = "chkautoplay";
            this.chkautoplay.Size = new System.Drawing.Size(132, 16);
            this.chkautoplay.TabIndex = 0;
            this.chkautoplay.Text = "试验开始时自动播放";
            this.chkautoplay.UseVisualStyleBackColor = true;
            this.chkautoplay.CheckedChanged += new System.EventHandler(this.chkautoplay_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnplay);
            this.groupBox2.Controls.Add(this.txtplay);
            this.groupBox2.Controls.Add(this.chkplay);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(646, 49);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // btnplay
            // 
            this.btnplay.Location = new System.Drawing.Point(561, 19);
            this.btnplay.Name = "btnplay";
            this.btnplay.Size = new System.Drawing.Size(71, 20);
            this.btnplay.TabIndex = 3;
            this.btnplay.Text = "浏览";
            this.btnplay.UseVisualStyleBackColor = true;
            this.btnplay.Click += new System.EventHandler(this.btnplay_Click);
            // 
            // txtplay
            // 
            this.txtplay.Location = new System.Drawing.Point(196, 18);
            this.txtplay.Name = "txtplay";
            this.txtplay.ReadOnly = true;
            this.txtplay.Size = new System.Drawing.Size(352, 21);
            this.txtplay.TabIndex = 1;
            // 
            // chkplay
            // 
            this.chkplay.AutoSize = true;
            this.chkplay.Location = new System.Drawing.Point(52, 20);
            this.chkplay.Name = "chkplay";
            this.chkplay.Size = new System.Drawing.Size(120, 16);
            this.chkplay.TabIndex = 0;
            this.chkplay.Text = "播放视频文件名称";
            this.chkplay.UseVisualStyleBackColor = true;
            this.chkplay.CheckedChanged += new System.EventHandler(this.chkplay_CheckedChanged);
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
            this.label1.Text = "设置摄像";
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
            // UserControl摄像
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "UserControl摄像";
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
