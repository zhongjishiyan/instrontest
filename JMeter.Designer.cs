namespace TabHeaderDemo
{
    partial class JMeter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JMeter));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblcaption = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblvalue = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.lblunit = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblvalue)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.lblcaption, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // lblcaption
            // 
            resources.ApplyResources(this.lblcaption, "lblcaption");
            this.lblcaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblcaption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblcaption.Name = "lblcaption";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.lblvalue);
            this.panel1.Controls.Add(this.lblunit);
            this.panel1.Name = "panel1";
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // lblvalue
            // 
            resources.ApplyResources(this.lblvalue, "lblvalue");
            this.lblvalue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblvalue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblvalue.CausesValidation = false;
            this.lblvalue.FormatMode = NationalInstruments.UI.NumericFormatMode.CreateSimpleDoubleMode(3);
            this.lblvalue.ImmediateUpdates = true;
            this.lblvalue.InteractionMode = NationalInstruments.UI.NumericEditInteractionModes.Indicator;
            this.lblvalue.Name = "lblvalue";
            // 
            // lblunit
            // 
            resources.ApplyResources(this.lblunit, "lblunit");
            this.lblunit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblunit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblunit.Name = "lblunit";
            // 
            // JMeter
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(10, 10);
            this.Name = "JMeter";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.JMeter_Paint);
            this.Resize += new System.EventHandler(this.JMeter_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblvalue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblcaption;
        public System.Windows.Forms.Label lblunit;
        public NationalInstruments.UI.WindowsForms.NumericEdit lblvalue;
    }
}
