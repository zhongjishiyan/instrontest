namespace TabHeaderDemo
{
    partial class UserSizeInput
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbltitle = new System.Windows.Forms.Label();
            this.cbounit = new System.Windows.Forms.ComboBox();
            this.btnproperty = new System.Windows.Forms.Button();
            this.txtvalue = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtvalue)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.64579F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.53132F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.97849F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.Controls.Add(this.lbltitle, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbounit, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnproperty, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtvalue, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(523, 29);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbltitle
            // 
            this.lbltitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbltitle.Location = new System.Drawing.Point(23, 0);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(122, 29);
            this.lbltitle.TabIndex = 0;
            this.lbltitle.Text = "宽度：";
            this.lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbounit
            // 
            this.cbounit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbounit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbounit.FormattingEnabled = true;
            this.cbounit.Location = new System.Drawing.Point(422, 3);
            this.cbounit.Name = "cbounit";
            this.cbounit.Size = new System.Drawing.Size(58, 20);
            this.cbounit.TabIndex = 2;
            // 
            // btnproperty
            // 
            this.btnproperty.Location = new System.Drawing.Point(486, 3);
            this.btnproperty.Name = "btnproperty";
            this.btnproperty.Size = new System.Drawing.Size(32, 23);
            this.btnproperty.TabIndex = 3;
            this.btnproperty.Text = "...";
            this.btnproperty.UseVisualStyleBackColor = true;
            this.btnproperty.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtvalue
            // 
            this.txtvalue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtvalue.InteractionMode = NationalInstruments.UI.NumericEditInteractionModes.Text;
            this.txtvalue.Location = new System.Drawing.Point(151, 3);
            this.txtvalue.Name = "txtvalue";
            this.txtvalue.Size = new System.Drawing.Size(265, 21);
            this.txtvalue.TabIndex = 4;
            // 
            // UserSizeInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UserSizeInput";
            this.Size = new System.Drawing.Size(523, 29);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtvalue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Label lbltitle;
        public System.Windows.Forms.ComboBox cbounit;
        public NationalInstruments.UI.WindowsForms.NumericEdit txtvalue;
        public System.Windows.Forms.Button btnproperty;
    }
}
