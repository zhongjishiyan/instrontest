namespace TabHeaderDemo
{
    partial class UserControl计算
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl计算));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpback = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstavail = new TabHeaderDemo.ListExt(this.components);
            this.lstinclude = new TabHeaderDemo.ListExt(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btndown = new System.Windows.Forms.Button();
            this.btnup = new System.Windows.Forms.Button();
            this.btnremove = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblcaption = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtExplain = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbounit = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkshow = new System.Windows.Forms.CheckBox();
            this.txtprecise = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.btnchange = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpback.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtprecise)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
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
            this.tableLayoutPanel1.Controls.Add(this.tlpback, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.42202F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.57798F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(654, 437);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tlpback
            // 
            this.tlpback.ColumnCount = 3;
            this.tlpback.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpback.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tlpback.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpback.Controls.Add(this.label2, 0, 0);
            this.tlpback.Controls.Add(this.label3, 2, 0);
            this.tlpback.Controls.Add(this.lstavail, 0, 1);
            this.tlpback.Controls.Add(this.lstinclude, 2, 1);
            this.tlpback.Controls.Add(this.panel1, 1, 1);
            this.tlpback.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpback.Location = new System.Drawing.Point(4, 4);
            this.tlpback.Name = "tlpback";
            this.tlpback.RowCount = 2;
            this.tlpback.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tlpback.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpback.Size = new System.Drawing.Size(646, 238);
            this.tlpback.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(291, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "可用计算";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(351, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(292, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "选中计算";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstavail
            // 
            this.lstavail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstavail.FormattingEnabled = true;
            this.lstavail.ItemHeight = 12;
            this.lstavail.Location = new System.Drawing.Point(3, 24);
            this.lstavail.Name = "lstavail";
            this.lstavail.Size = new System.Drawing.Size(291, 211);
            this.lstavail.TabIndex = 2;
            this.lstavail.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstavail_MouseClick);
            // 
            // lstinclude
            // 
            this.lstinclude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstinclude.FormattingEnabled = true;
            this.lstinclude.ItemHeight = 12;
            this.lstinclude.Location = new System.Drawing.Point(351, 24);
            this.lstinclude.Name = "lstinclude";
            this.lstinclude.Size = new System.Drawing.Size(292, 211);
            this.lstinclude.TabIndex = 3;
            this.lstinclude.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstinclude_MouseClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btndown);
            this.panel1.Controls.Add(this.btnup);
            this.panel1.Controls.Add(this.btnremove);
            this.panel1.Controls.Add(this.btnadd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(300, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(45, 211);
            this.panel1.TabIndex = 4;
            // 
            // btndown
            // 
            this.btndown.Image = ((System.Drawing.Image)(resources.GetObject("btndown.Image")));
            this.btndown.Location = new System.Drawing.Point(6, 120);
            this.btndown.Name = "btndown";
            this.btndown.Size = new System.Drawing.Size(33, 26);
            this.btndown.TabIndex = 3;
            this.btndown.UseVisualStyleBackColor = true;
            this.btndown.Visible = false;
            // 
            // btnup
            // 
            this.btnup.Image = ((System.Drawing.Image)(resources.GetObject("btnup.Image")));
            this.btnup.Location = new System.Drawing.Point(6, 85);
            this.btnup.Name = "btnup";
            this.btnup.Size = new System.Drawing.Size(33, 26);
            this.btnup.TabIndex = 2;
            this.btnup.UseVisualStyleBackColor = true;
            this.btnup.Visible = false;
            // 
            // btnremove
            // 
            this.btnremove.Image = ((System.Drawing.Image)(resources.GetObject("btnremove.Image")));
            this.btnremove.Location = new System.Drawing.Point(6, 50);
            this.btnremove.Name = "btnremove";
            this.btnremove.Size = new System.Drawing.Size(33, 26);
            this.btnremove.TabIndex = 1;
            this.btnremove.UseVisualStyleBackColor = true;
            this.btnremove.Click += new System.EventHandler(this.btnremove_Click);
            // 
            // btnadd
            // 
            this.btnadd.Image = ((System.Drawing.Image)(resources.GetObject("btnadd.Image")));
            this.btnadd.Location = new System.Drawing.Point(6, 15);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(33, 26);
            this.btnadd.TabIndex = 0;
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.lblcaption, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 249);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(646, 184);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // lblcaption
            // 
            this.lblcaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblcaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblcaption.ForeColor = System.Drawing.Color.White;
            this.lblcaption.Location = new System.Drawing.Point(3, 0);
            this.lblcaption.Name = "lblcaption";
            this.lblcaption.Size = new System.Drawing.Size(640, 22);
            this.lblcaption.TabIndex = 2;
            this.lblcaption.Text = "公式设置";
            this.lblcaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.txtExplain, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.cbounit, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.chkshow, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.txtprecise, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.btnchange, 0, 4);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 25);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 5;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(461, 141);
            this.tableLayoutPanel5.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(224, 40);
            this.label4.TabIndex = 0;
            this.label4.Text = "说明";
            // 
            // txtExplain
            // 
            this.txtExplain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtExplain.Location = new System.Drawing.Point(233, 3);
            this.txtExplain.Multiline = true;
            this.txtExplain.Name = "txtExplain";
            this.txtExplain.Size = new System.Drawing.Size(225, 34);
            this.txtExplain.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(224, 27);
            this.label5.TabIndex = 2;
            this.label5.Text = "单位：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbounit
            // 
            this.cbounit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbounit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbounit.Enabled = false;
            this.cbounit.FormattingEnabled = true;
            this.cbounit.Location = new System.Drawing.Point(233, 43);
            this.cbounit.Name = "cbounit";
            this.cbounit.Size = new System.Drawing.Size(225, 20);
            this.cbounit.TabIndex = 3;
            this.cbounit.SelectionChangeCommitted += new System.EventHandler(this.cbounit_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(224, 24);
            this.label6.TabIndex = 4;
            this.label6.Text = "小数位数：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkshow
            // 
            this.chkshow.AutoSize = true;
            this.chkshow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkshow.Location = new System.Drawing.Point(3, 94);
            this.chkshow.Name = "chkshow";
            this.chkshow.Size = new System.Drawing.Size(224, 17);
            this.chkshow.TabIndex = 6;
            this.chkshow.Text = "在曲线上显示";
            this.chkshow.UseVisualStyleBackColor = true;
            // 
            // txtprecise
            // 
            this.txtprecise.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtprecise.Enabled = false;
            this.txtprecise.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(0);
            this.txtprecise.Location = new System.Drawing.Point(233, 70);
            this.txtprecise.Name = "txtprecise";
            this.txtprecise.Range = new NationalInstruments.UI.Range(0D, 10D);
            this.txtprecise.Size = new System.Drawing.Size(225, 21);
            this.txtprecise.TabIndex = 7;
            // 
            // btnchange
            // 
            this.btnchange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnchange.Location = new System.Drawing.Point(3, 117);
            this.btnchange.Name = "btnchange";
            this.btnchange.Size = new System.Drawing.Size(224, 21);
            this.btnchange.TabIndex = 8;
            this.btnchange.Text = "修改";
            this.btnchange.UseVisualStyleBackColor = true;
            this.btnchange.Visible = false;
            this.btnchange.Click += new System.EventHandler(this.btnchange_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
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
            this.label1.Size = new System.Drawing.Size(591, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "设置计算";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Location = new System.Drawing.Point(602, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(32, 30);
            this.panel4.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(660, 481);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // UserControl计算
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "UserControl计算";
            this.Size = new System.Drawing.Size(668, 507);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tlpback.ResumeLayout(false);
            this.tlpback.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtprecise)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tlpback;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ListExt lstavail;
        private ListExt  lstinclude;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btndown;
        private System.Windows.Forms.Button btnup;
        private System.Windows.Forms.Button btnremove;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lblcaption;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtExplain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbounit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkshow;
        private System.Windows.Forms.Button btnchange;
        public NationalInstruments.UI.WindowsForms.NumericEdit txtprecise;
    }
}
