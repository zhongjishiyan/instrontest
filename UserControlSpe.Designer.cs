namespace TabHeaderDemo
{
    partial class UserControlSpe
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
            IP.Components.Toolbox.Item item1 = new IP.Components.Toolbox.Item();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlSpe));
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listBox1 = new IP.Components.Toolbox(false);
            this.btnleft = new System.Windows.Forms.Button();
            this.btnright = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tlp1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "测试输入";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.Controls.Add(this.listBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnleft, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnright, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(292, 28);
            this.tableLayoutPanel1.TabIndex = 32;
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.AllowToolboxItems = true;
            this.listBox1.AutoScroll = false;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            item1.Tag = null;
            item1.Text = "试样1";
            item1.Tooltip = "试样1";
            this.listBox1.Items.AddRange(new IP.Components.Toolbox.Item[] {
            item1});
            this.listBox1.Location = new System.Drawing.Point(33, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.ShowPointer = false;
            this.listBox1.Size = new System.Drawing.Size(225, 22);
            this.listBox1.TabIndex = 34;
            this.listBox1.Text = "toolbox1";
            // 
            // btnleft
            // 
            this.btnleft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnleft.Image = ((System.Drawing.Image)(resources.GetObject("btnleft.Image")));
            this.btnleft.Location = new System.Drawing.Point(3, 3);
            this.btnleft.Name = "btnleft";
            this.btnleft.Size = new System.Drawing.Size(24, 22);
            this.btnleft.TabIndex = 0;
            this.btnleft.UseVisualStyleBackColor = true;
            this.btnleft.Click += new System.EventHandler(this.btnleft_Click);
            // 
            // btnright
            // 
            this.btnright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnright.Image = ((System.Drawing.Image)(resources.GetObject("btnright.Image")));
            this.btnright.Location = new System.Drawing.Point(264, 3);
            this.btnright.Name = "btnright";
            this.btnright.Size = new System.Drawing.Size(25, 22);
            this.btnright.TabIndex = 33;
            this.btnright.UseVisualStyleBackColor = true;
            this.btnright.Click += new System.EventHandler(this.btnright_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Selector_Status_PreTest.ico");
            this.imageList1.Images.SetKeyName(1, "Selector_Status_PostTest.ico");
            this.imageList1.Images.SetKeyName(2, "Selector_Status_Tested_Rejected.ico");
            this.imageList1.Images.SetKeyName(3, "Selector_Status_Tested.ico");
            this.imageList1.Images.SetKeyName(4, "Selector_Status_Ready_For_Test.ico");
            // 
            // tlp1
            // 
            this.tlp1.ColumnCount = 1;
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlp1.Location = new System.Drawing.Point(0, 46);
            this.tlp1.Name = "tlp1";
            this.tlp1.RowCount = 1;
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tlp1.Size = new System.Drawing.Size(292, 76);
            this.tlp1.TabIndex = 33;
            // 
            // UserControlSpe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Name = "UserControlSpe";
            this.Size = new System.Drawing.Size(292, 360);
            this.Load += new System.EventHandler(this.UserControlSpe_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnleft;
        private IP.Components.Toolbox listBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TableLayoutPanel tlp1;
        public System.Windows.Forms.Button btnright;
    }
}
