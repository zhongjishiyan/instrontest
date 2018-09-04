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
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
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
            this.tableLayoutPanel1.Controls.Add(this.tlpback, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tlpback
            // 
            resources.ApplyResources(this.tlpback, "tlpback");
            this.tlpback.Controls.Add(this.label2, 0, 0);
            this.tlpback.Controls.Add(this.label3, 2, 0);
            this.tlpback.Controls.Add(this.lstavail, 0, 1);
            this.tlpback.Controls.Add(this.lstinclude, 2, 1);
            this.tlpback.Controls.Add(this.panel1, 1, 1);
            this.tlpback.Name = "tlpback";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // lstavail
            // 
            resources.ApplyResources(this.lstavail, "lstavail");
            this.lstavail.FormattingEnabled = true;
            this.lstavail.Name = "lstavail";
            this.lstavail.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstavail_MouseClick);
            // 
            // lstinclude
            // 
            resources.ApplyResources(this.lstinclude, "lstinclude");
            this.lstinclude.FormattingEnabled = true;
            this.lstinclude.Name = "lstinclude";
            this.lstinclude.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstinclude_MouseClick);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.btndown);
            this.panel1.Controls.Add(this.btnup);
            this.panel1.Controls.Add(this.btnremove);
            this.panel1.Controls.Add(this.btnadd);
            this.panel1.Name = "panel1";
            // 
            // btndown
            // 
            resources.ApplyResources(this.btndown, "btndown");
            this.btndown.Name = "btndown";
            this.btndown.UseVisualStyleBackColor = true;
            // 
            // btnup
            // 
            resources.ApplyResources(this.btnup, "btnup");
            this.btnup.Name = "btnup";
            this.btnup.UseVisualStyleBackColor = true;
            // 
            // btnremove
            // 
            resources.ApplyResources(this.btnremove, "btnremove");
            this.btnremove.Name = "btnremove";
            this.btnremove.UseVisualStyleBackColor = true;
            this.btnremove.Click += new System.EventHandler(this.btnremove_Click);
            // 
            // btnadd
            // 
            resources.ApplyResources(this.btnadd, "btnadd");
            this.btnadd.Name = "btnadd";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // tableLayoutPanel4
            // 
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Controls.Add(this.lblcaption, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // lblcaption
            // 
            resources.ApplyResources(this.lblcaption, "lblcaption");
            this.lblcaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblcaption.ForeColor = System.Drawing.Color.White;
            this.lblcaption.Name = "lblcaption";
            // 
            // tableLayoutPanel5
            // 
            resources.ApplyResources(this.tableLayoutPanel5, "tableLayoutPanel5");
            this.tableLayoutPanel5.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.txtExplain, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.cbounit, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.chkshow, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.txtprecise, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.btnchange, 0, 4);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtExplain
            // 
            resources.ApplyResources(this.txtExplain, "txtExplain");
            this.txtExplain.Name = "txtExplain";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // cbounit
            // 
            resources.ApplyResources(this.cbounit, "cbounit");
            this.cbounit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbounit.FormattingEnabled = true;
            this.cbounit.Name = "cbounit";
            this.cbounit.SelectionChangeCommitted += new System.EventHandler(this.cbounit_SelectionChangeCommitted);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // chkshow
            // 
            resources.ApplyResources(this.chkshow, "chkshow");
            this.chkshow.Name = "chkshow";
            this.chkshow.UseVisualStyleBackColor = true;
            // 
            // txtprecise
            // 
            resources.ApplyResources(this.txtprecise, "txtprecise");
            this.txtprecise.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(0);
            this.txtprecise.Name = "txtprecise";
            this.txtprecise.Range = new NationalInstruments.UI.Range(0D, 10D);
            // 
            // btnchange
            // 
            resources.ApplyResources(this.btnchange, "btnchange");
            this.btnchange.Name = "btnchange";
            this.btnchange.UseVisualStyleBackColor = true;
            this.btnchange.Click += new System.EventHandler(this.btnchange_Click);
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
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // UserControl计算
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "UserControl计算";
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
