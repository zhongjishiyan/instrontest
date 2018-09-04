namespace TabHeaderDemo
{
    partial class UserControl控制台
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl控制台));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstavail = new TabHeaderDemo.ListExtObject(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btndownmeter = new System.Windows.Forms.Button();
            this.btnupmeter = new System.Windows.Forms.Button();
            this.btnremovemeter = new System.Windows.Forms.Button();
            this.btnaddmeter = new System.Windows.Forms.Button();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.txtExplain = new System.Windows.Forms.Label();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.cbounit = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtprecise = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.button1 = new System.Windows.Forms.Button();
            this.lstinclude = new TabHeaderDemo.ListExtObject(this.components);
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listavail = new TabHeaderDemo.ListExtObject(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.btndownkey = new System.Windows.Forms.Button();
            this.btnupkey = new System.Windows.Forms.Button();
            this.btnremovekey = new System.Windows.Forms.Button();
            this.btnaddkey = new System.Windows.Forms.Button();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.listinclude = new TabHeaderDemo.ListExtObject(this.components);
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtprecise)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
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
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lstavail, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel7, 2, 1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
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
            this.lstavail.SelectedIndexChanged += new System.EventHandler(this.lstavail_SelectedIndexChanged);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.btndownmeter);
            this.panel1.Controls.Add(this.btnupmeter);
            this.panel1.Controls.Add(this.btnremovemeter);
            this.panel1.Controls.Add(this.btnaddmeter);
            this.panel1.Name = "panel1";
            // 
            // btndownmeter
            // 
            resources.ApplyResources(this.btndownmeter, "btndownmeter");
            this.btndownmeter.Name = "btndownmeter";
            this.btndownmeter.UseVisualStyleBackColor = true;
            this.btndownmeter.Click += new System.EventHandler(this.btndownmeter_Click);
            // 
            // btnupmeter
            // 
            resources.ApplyResources(this.btnupmeter, "btnupmeter");
            this.btnupmeter.Name = "btnupmeter";
            this.btnupmeter.UseVisualStyleBackColor = true;
            this.btnupmeter.Click += new System.EventHandler(this.btnupmeter_Click);
            // 
            // btnremovemeter
            // 
            resources.ApplyResources(this.btnremovemeter, "btnremovemeter");
            this.btnremovemeter.Name = "btnremovemeter";
            this.btnremovemeter.UseVisualStyleBackColor = true;
            this.btnremovemeter.Click += new System.EventHandler(this.btnremovemeter_Click);
            // 
            // btnaddmeter
            // 
            resources.ApplyResources(this.btnaddmeter, "btnaddmeter");
            this.btnaddmeter.Name = "btnaddmeter";
            this.btnaddmeter.UseVisualStyleBackColor = true;
            this.btnaddmeter.Click += new System.EventHandler(this.btnaddmeter_Click);
            // 
            // tableLayoutPanel7
            // 
            resources.ApplyResources(this.tableLayoutPanel7, "tableLayoutPanel7");
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel8, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.lstinclude, 0, 0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            // 
            // tableLayoutPanel8
            // 
            resources.ApplyResources(this.tableLayoutPanel8, "tableLayoutPanel8");
            this.tableLayoutPanel8.Controls.Add(this.txtExplain, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel9, 0, 1);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            // 
            // txtExplain
            // 
            resources.ApplyResources(this.txtExplain, "txtExplain");
            this.txtExplain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtExplain.ForeColor = System.Drawing.Color.White;
            this.txtExplain.Name = "txtExplain";
            // 
            // tableLayoutPanel9
            // 
            resources.ApplyResources(this.tableLayoutPanel9, "tableLayoutPanel9");
            this.tableLayoutPanel9.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.cbounit, 1, 1);
            this.tableLayoutPanel9.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel9.Controls.Add(this.txtprecise, 1, 2);
            this.tableLayoutPanel9.Controls.Add(this.button1, 0, 3);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // cbounit
            // 
            resources.ApplyResources(this.cbounit, "cbounit");
            this.cbounit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbounit.FormattingEnabled = true;
            this.cbounit.Name = "cbounit";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // txtprecise
            // 
            resources.ApplyResources(this.txtprecise, "txtprecise");
            this.txtprecise.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(0);
            this.txtprecise.InteractionMode = ((NationalInstruments.UI.NumericEditInteractionModes)((NationalInstruments.UI.NumericEditInteractionModes.Buttons | NationalInstruments.UI.NumericEditInteractionModes.Text)));
            this.txtprecise.Name = "txtprecise";
            this.txtprecise.Range = new NationalInstruments.UI.Range(0D, 10D);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstinclude
            // 
            resources.ApplyResources(this.lstinclude, "lstinclude");
            this.lstinclude.FormattingEnabled = true;
            this.lstinclude.Name = "lstinclude";
            this.lstinclude.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstinclude_MouseClick);
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
            this.tabPage2.Controls.Add(this.tableLayoutPanel5);
            this.tabPage2.Controls.Add(this.tableLayoutPanel4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            resources.ApplyResources(this.tableLayoutPanel5, "tableLayoutPanel5");
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            // 
            // tableLayoutPanel6
            // 
            resources.ApplyResources(this.tableLayoutPanel6, "tableLayoutPanel6");
            this.tableLayoutPanel6.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.listavail, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.panel3, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel10, 2, 1);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // listavail
            // 
            resources.ApplyResources(this.listavail, "listavail");
            this.listavail.FormattingEnabled = true;
            this.listavail.Name = "listavail";
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Controls.Add(this.btndownkey);
            this.panel3.Controls.Add(this.btnupkey);
            this.panel3.Controls.Add(this.btnremovekey);
            this.panel3.Controls.Add(this.btnaddkey);
            this.panel3.Name = "panel3";
            // 
            // btndownkey
            // 
            resources.ApplyResources(this.btndownkey, "btndownkey");
            this.btndownkey.Name = "btndownkey";
            this.btndownkey.UseVisualStyleBackColor = true;
            this.btndownkey.Click += new System.EventHandler(this.btndownkey_Click);
            // 
            // btnupkey
            // 
            resources.ApplyResources(this.btnupkey, "btnupkey");
            this.btnupkey.Name = "btnupkey";
            this.btnupkey.UseVisualStyleBackColor = true;
            this.btnupkey.Click += new System.EventHandler(this.btnupkey_Click);
            // 
            // btnremovekey
            // 
            resources.ApplyResources(this.btnremovekey, "btnremovekey");
            this.btnremovekey.Name = "btnremovekey";
            this.btnremovekey.UseVisualStyleBackColor = true;
            this.btnremovekey.Click += new System.EventHandler(this.btnremovekey_Click);
            // 
            // btnaddkey
            // 
            resources.ApplyResources(this.btnaddkey, "btnaddkey");
            this.btnaddkey.Name = "btnaddkey";
            this.btnaddkey.UseVisualStyleBackColor = true;
            this.btnaddkey.Click += new System.EventHandler(this.btnaddkey_Click);
            // 
            // tableLayoutPanel10
            // 
            resources.ApplyResources(this.tableLayoutPanel10, "tableLayoutPanel10");
            this.tableLayoutPanel10.Controls.Add(this.listinclude, 0, 0);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            // 
            // listinclude
            // 
            resources.ApplyResources(this.listinclude, "listinclude");
            this.listinclude.FormattingEnabled = true;
            this.listinclude.Name = "listinclude";
            // 
            // tableLayoutPanel4
            // 
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.Teal;
            this.label4.Name = "label4";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // tabPage3
            // 
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Controls.Add(this.tableLayoutPanel12);
            this.tabPage3.Controls.Add(this.tableLayoutPanel11);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel12
            // 
            resources.ApplyResources(this.tableLayoutPanel12, "tableLayoutPanel12");
            this.tableLayoutPanel12.Controls.Add(this.panel6, 0, 0);
            this.tableLayoutPanel12.Controls.Add(this.panel7, 0, 1);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            // 
            // panel6
            // 
            resources.ApplyResources(this.panel6, "panel6");
            this.panel6.Controls.Add(this.radioButton2);
            this.panel6.Controls.Add(this.radioButton1);
            this.panel6.Controls.Add(this.label10);
            this.panel6.Name = "panel6";
            // 
            // radioButton2
            // 
            resources.ApplyResources(this.radioButton2, "radioButton2");
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.TabStop = true;
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            resources.ApplyResources(this.radioButton1, "radioButton1");
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.ForeColor = System.Drawing.Color.Teal;
            this.label10.Name = "label10";
            // 
            // panel7
            // 
            resources.ApplyResources(this.panel7, "panel7");
            this.panel7.Controls.Add(this.label11);
            this.panel7.Name = "panel7";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.ForeColor = System.Drawing.Color.Teal;
            this.label11.Name = "label11";
            // 
            // tableLayoutPanel11
            // 
            resources.ApplyResources(this.tableLayoutPanel11, "tableLayoutPanel11");
            this.tableLayoutPanel11.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.panel5, 1, 0);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.Teal;
            this.label7.Name = "label7";
            // 
            // panel5
            // 
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Name = "panel5";
            // 
            // UserControl控制台
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "UserControl控制台";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtprecise)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel12.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.tableLayoutPanel11.ResumeLayout(false);
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btndownmeter;
        private System.Windows.Forms.Button btnupmeter;
        private System.Windows.Forms.Button btnremovemeter;
        private System.Windows.Forms.Button btnaddmeter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label txtExplain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbounit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private ListExtObject listavail;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btndownkey;
        private System.Windows.Forms.Button btnupkey;
        private System.Windows.Forms.Button btnremovekey;
        private System.Windows.Forms.Button btnaddkey;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private ListExtObject listinclude;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label11;
        public ListExtObject lstavail;
        public ListExtObject lstinclude;
        private NationalInstruments.UI.WindowsForms.NumericEdit txtprecise;
        private System.Windows.Forms.Button button1;
    }
}
