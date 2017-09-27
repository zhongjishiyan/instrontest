namespace TabHeaderDemo
{
    partial class UserReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserReport));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("常规");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("页眉");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("正文");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("页脚");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("报告", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelbutton = new System.Windows.Forms.Panel();
            this.btnprint = new TabHeaderDemo.ButtonExNew(this.components);
            this.btnopen = new TabHeaderDemo.ButtonExNew(this.components);
            this.buttonEx1 = new TabHeaderDemo.ButtonExNew(this.components);
            this.btnsave = new TabHeaderDemo.ButtonExNew(this.components);
            this.btnsaveas = new TabHeaderDemo.ButtonExNew(this.components);
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panelback1 = new System.Windows.Forms.Panel();
            this.panelback = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.treeView1 = new TabHeaderDemo.TreeListEx(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.dialog = new System.Windows.Forms.PrintDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelbutton.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panelback1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 187F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.Controls.Add(this.panelbutton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(681, 579);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panelbutton
            // 
            this.panelbutton.Controls.Add(this.btnprint);
            this.panelbutton.Controls.Add(this.btnopen);
            this.panelbutton.Controls.Add(this.buttonEx1);
            this.panelbutton.Controls.Add(this.btnsave);
            this.panelbutton.Controls.Add(this.btnsaveas);
            this.panelbutton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelbutton.Location = new System.Drawing.Point(586, 3);
            this.panelbutton.Name = "panelbutton";
            this.panelbutton.Size = new System.Drawing.Size(92, 573);
            this.panelbutton.TabIndex = 5;
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.Transparent;
            this.btnprint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnprint.BackgroundImage")));
            this.btnprint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnprint.FlatAppearance.BorderSize = 0;
            this.btnprint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnprint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprint.ForeColor = System.Drawing.Color.White;
            this.btnprint.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.Image")));
            this.btnprint.Location = new System.Drawing.Point(20, 353);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(48, 67);
            this.btnprint.TabIndex = 48;
            this.btnprint.Text = "打印";
            this.btnprint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnprint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnprint.UseMnemonic = false;
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // btnopen
            // 
            this.btnopen.BackColor = System.Drawing.Color.Transparent;
            this.btnopen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnopen.BackgroundImage")));
            this.btnopen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnopen.FlatAppearance.BorderSize = 0;
            this.btnopen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnopen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnopen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnopen.ForeColor = System.Drawing.Color.White;
            this.btnopen.Image = ((System.Drawing.Image)(resources.GetObject("btnopen.Image")));
            this.btnopen.Location = new System.Drawing.Point(20, 17);
            this.btnopen.Name = "btnopen";
            this.btnopen.Size = new System.Drawing.Size(48, 67);
            this.btnopen.TabIndex = 47;
            this.btnopen.Text = "打开";
            this.btnopen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnopen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnopen.UseMnemonic = false;
            this.btnopen.UseVisualStyleBackColor = false;
            this.btnopen.Click += new System.EventHandler(this.buttonEx2_Click_2);
            // 
            // buttonEx1
            // 
            this.buttonEx1.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonEx1.BackgroundImage")));
            this.buttonEx1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonEx1.FlatAppearance.BorderSize = 0;
            this.buttonEx1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonEx1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonEx1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx1.ForeColor = System.Drawing.Color.White;
            this.buttonEx1.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx1.Image")));
            this.buttonEx1.Location = new System.Drawing.Point(20, 269);
            this.buttonEx1.Name = "buttonEx1";
            this.buttonEx1.Size = new System.Drawing.Size(48, 67);
            this.buttonEx1.TabIndex = 46;
            this.buttonEx1.Text = "预览";
            this.buttonEx1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonEx1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonEx1.UseMnemonic = false;
            this.buttonEx1.UseVisualStyleBackColor = false;
            this.buttonEx1.Click += new System.EventHandler(this.buttonEx1_Click);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.Transparent;
            this.btnsave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnsave.FlatAppearance.BorderSize = 0;
            this.btnsave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnsave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.Image = ((System.Drawing.Image)(resources.GetObject("btnsave.Image")));
            this.btnsave.Location = new System.Drawing.Point(20, 101);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(48, 67);
            this.btnsave.TabIndex = 45;
            this.btnsave.Text = "保存";
            this.btnsave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnsave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnsave.UseMnemonic = false;
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnsaveas
            // 
            this.btnsaveas.BackColor = System.Drawing.Color.Transparent;
            this.btnsaveas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnsaveas.BackgroundImage")));
            this.btnsaveas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnsaveas.FlatAppearance.BorderSize = 0;
            this.btnsaveas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnsaveas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnsaveas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsaveas.ForeColor = System.Drawing.Color.White;
            this.btnsaveas.Image = ((System.Drawing.Image)(resources.GetObject("btnsaveas.Image")));
            this.btnsaveas.Location = new System.Drawing.Point(20, 185);
            this.btnsaveas.Name = "btnsaveas";
            this.btnsaveas.Size = new System.Drawing.Size(48, 67);
            this.btnsaveas.TabIndex = 44;
            this.btnsaveas.Text = "另存";
            this.btnsaveas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnsaveas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnsaveas.UseMnemonic = false;
            this.btnsaveas.UseVisualStyleBackColor = false;
            this.btnsaveas.Click += new System.EventHandler(this.button7_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.panelback1, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(190, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(390, 573);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // panelback1
            // 
            this.panelback1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelback1.Controls.Add(this.panelback);
            this.panelback1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelback1.Location = new System.Drawing.Point(3, 8);
            this.panelback1.Name = "panelback1";
            this.panelback1.Size = new System.Drawing.Size(384, 557);
            this.panelback1.TabIndex = 0;
            // 
            // panelback
            // 
            this.panelback.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelback.Location = new System.Drawing.Point(0, 0);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(384, 557);
            this.panelback.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.treeView1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 573F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(181, 573);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.treeView1.FullRowSelect = true;
            this.treeView1.ItemHeight = 32;
            this.treeView1.Location = new System.Drawing.Point(23, 3);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点1";
            treeNode1.StateImageIndex = 0;
            treeNode1.Text = "常规";
            treeNode2.Name = "页眉";
            treeNode2.StateImageIndex = 0;
            treeNode2.Text = "页眉";
            treeNode3.Name = "节点1";
            treeNode3.StateImageIndex = 0;
            treeNode3.Text = "正文";
            treeNode4.Name = "节点2";
            treeNode4.StateImageIndex = 0;
            treeNode4.Text = "页脚";
            treeNode5.Name = "节点1";
            treeNode5.StateImageIndex = 0;
            treeNode5.Text = "报告";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5});
            this.treeView1.ShowLines = false;
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.ShowRootLines = false;
            this.treeView1.Size = new System.Drawing.Size(155, 567);
            this.treeView1.StateImageList = this.imageList1;
            this.treeView1.TabIndex = 7;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "bg1.ico");
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(14, 380);
            this.panel1.TabIndex = 3;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Black;
            this.imageList2.Images.SetKeyName(0, "mt11.ico");
            this.imageList2.Images.SetKeyName(1, "mt12.ico");
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "13.ico");
            // 
            // dialog
            // 
            this.dialog.UseEXDialog = true;
            // 
            // UserReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "UserReport";
            this.Size = new System.Drawing.Size(681, 579);
            this.Load += new System.EventHandler(this.UserReport_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserReport_Paint);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelbutton.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panelback1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panelback1;
        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.ImageList imageList3;
        private System.Windows.Forms.Panel panelbutton;
        public ButtonExNew btnprint;
        public ButtonExNew btnopen;
        public ButtonExNew buttonEx1;
        public ButtonExNew btnsave;
        public ButtonExNew btnsaveas;
        private System.Windows.Forms.PrintDialog dialog;
        public TreeListEx treeView1;
    }
}
