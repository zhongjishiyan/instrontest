namespace TabHeaderDemo
{
    partial class UserManage
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("查看");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("系统信息", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("启动");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("安全事项", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("系统");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("首选项", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("选项");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("配置", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManage));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panelback1 = new System.Windows.Forms.Panel();
            this.panelback = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.treeView1 = new TabHeaderDemo.TreeListEx(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonEx3 = new TabHeaderDemo.ButtonExNew(this.components);
            this.buttonEx2 = new TabHeaderDemo.ButtonExNew(this.components);
            this.buttonEx1 = new TabHeaderDemo.ButtonExNew(this.components);
            this.button1 = new TabHeaderDemo.ButtonExNew(this.components);
            this.button7 = new TabHeaderDemo.ButtonExNew(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panelback1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 196F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(681, 579);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.panelback1, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(199, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(381, 573);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // panelback1
            // 
            this.panelback1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelback1.Controls.Add(this.panelback);
            this.panelback1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelback1.Location = new System.Drawing.Point(3, 8);
            this.panelback1.Name = "panelback1";
            this.panelback1.Size = new System.Drawing.Size(375, 557);
            this.panelback1.TabIndex = 0;
            // 
            // panelback
            // 
            this.panelback.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelback.Location = new System.Drawing.Point(0, 0);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(375, 557);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(190, 573);
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
            treeNode1.Name = "节点5";
            treeNode1.Text = "查看";
            treeNode2.Name = "节点0";
            treeNode2.StateImageIndex = 0;
            treeNode2.Text = "系统信息";
            treeNode3.Name = "节点6";
            treeNode3.Text = "启动";
            treeNode4.Name = "节点1";
            treeNode4.StateImageIndex = 1;
            treeNode4.Text = "安全事项";
            treeNode5.Name = "节点7";
            treeNode5.Text = "系统";
            treeNode6.Name = "节点0";
            treeNode6.StateImageIndex = 2;
            treeNode6.Text = "首选项";
            treeNode7.Name = "节点0";
            treeNode7.Text = "选项";
            treeNode8.Name = "节点1";
            treeNode8.StateImageIndex = 3;
            treeNode8.Text = "配置";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode4,
            treeNode6,
            treeNode8});
            this.treeView1.ShowLines = false;
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.ShowRootLines = false;
            this.treeView1.Size = new System.Drawing.Size(164, 567);
            this.treeView1.StateImageList = this.imageList1;
            this.treeView1.TabIndex = 7;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "h1.ico");
            this.imageList1.Images.SetKeyName(1, "h2.ico");
            this.imageList1.Images.SetKeyName(2, "h3.ico");
            this.imageList1.Images.SetKeyName(3, "mt3.ico");
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(14, 380);
            this.panel1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonEx3);
            this.panel3.Controls.Add(this.buttonEx2);
            this.panel3.Controls.Add(this.buttonEx1);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.button7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(586, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(92, 573);
            this.panel3.TabIndex = 2;
            // 
            // buttonEx3
            // 
            this.buttonEx3.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonEx3.BackgroundImage")));
            this.buttonEx3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonEx3.FlatAppearance.BorderSize = 0;
            this.buttonEx3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonEx3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonEx3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx3.ForeColor = System.Drawing.Color.White;
            this.buttonEx3.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx3.Image")));
            this.buttonEx3.Location = new System.Drawing.Point(20, 355);
            this.buttonEx3.Name = "buttonEx3";
            this.buttonEx3.Size = new System.Drawing.Size(48, 67);
            this.buttonEx3.TabIndex = 48;
            this.buttonEx3.Text = "浏览";
            this.buttonEx3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonEx3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonEx3.UseMnemonic = false;
            this.buttonEx3.UseVisualStyleBackColor = false;
            this.buttonEx3.Visible = false;
            // 
            // buttonEx2
            // 
            this.buttonEx2.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonEx2.BackgroundImage")));
            this.buttonEx2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonEx2.FlatAppearance.BorderSize = 0;
            this.buttonEx2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonEx2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonEx2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx2.ForeColor = System.Drawing.Color.White;
            this.buttonEx2.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx2.Image")));
            this.buttonEx2.Location = new System.Drawing.Point(20, 17);
            this.buttonEx2.Name = "buttonEx2";
            this.buttonEx2.Size = new System.Drawing.Size(48, 67);
            this.buttonEx2.TabIndex = 47;
            this.buttonEx2.Text = "打开";
            this.buttonEx2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonEx2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonEx2.UseMnemonic = false;
            this.buttonEx2.UseVisualStyleBackColor = false;
            this.buttonEx2.Visible = false;
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
            this.buttonEx1.Location = new System.Drawing.Point(20, 250);
            this.buttonEx1.Name = "buttonEx1";
            this.buttonEx1.Size = new System.Drawing.Size(48, 67);
            this.buttonEx1.TabIndex = 46;
            this.buttonEx1.Text = "预览";
            this.buttonEx1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonEx1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonEx1.UseMnemonic = false;
            this.buttonEx1.UseVisualStyleBackColor = false;
            this.buttonEx1.Visible = false;
            this.buttonEx1.Click += new System.EventHandler(this.buttonEx1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(20, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 67);
            this.button1.TabIndex = 45;
            this.button1.Text = "保存";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseMnemonic = false;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.Location = new System.Drawing.Point(20, 160);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(48, 67);
            this.button7.TabIndex = 44;
            this.button7.Text = "另存";
            this.button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button7.UseMnemonic = false;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Visible = false;
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
            this.imageList3.Images.SetKeyName(0, "14.ico");
            // 
            // UserManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UserManage";
            this.Size = new System.Drawing.Size(681, 579);
            this.Load += new System.EventHandler(this.UserManage_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserReport_Paint);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panelback1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        public ButtonExNew buttonEx3;
        public ButtonExNew buttonEx2;
        public ButtonExNew buttonEx1;
        public ButtonExNew button1;
        public ButtonExNew button7;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private TreeListEx treeView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panelback1;
        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.ImageList imageList3;
    }
}
