namespace TabHeaderDemo
{
    partial class UserControlOpenMethod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlOpenMethod));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("选择方法");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("打开方法", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelbutton = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panelback1 = new System.Windows.Forms.Panel();
            this.panelback = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonExNext = new TabHeaderDemo.ButtonExNew(this.components);
            this.btnexprint = new TabHeaderDemo.ButtonExNew(this.components);
            this.btnexsave = new TabHeaderDemo.ButtonExNew(this.components);
            this.btnexsaveclose = new TabHeaderDemo.ButtonExNew(this.components);
            this.btnsaveas = new TabHeaderDemo.ButtonExNew(this.components);
            this.btnexread = new TabHeaderDemo.ButtonExNew(this.components);
            this.btnexopen = new TabHeaderDemo.ButtonExNew(this.components);
            this.btnexnew = new TabHeaderDemo.ButtonExNew(this.components);
            this.treeView1 = new TabHeaderDemo.TreeListEx(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panelbutton.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panelback1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel1.Controls.Add(this.panelbutton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1066, 592);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // panelbutton
            // 
            this.panelbutton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelbutton.Controls.Add(this.buttonExNext);
            this.panelbutton.Controls.Add(this.btnexprint);
            this.panelbutton.Controls.Add(this.btnexsave);
            this.panelbutton.Controls.Add(this.btnexsaveclose);
            this.panelbutton.Controls.Add(this.btnsaveas);
            this.panelbutton.Controls.Add(this.btnexread);
            this.panelbutton.Controls.Add(this.btnexopen);
            this.panelbutton.Controls.Add(this.btnexnew);
            this.panelbutton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelbutton.Location = new System.Drawing.Point(968, 3);
            this.panelbutton.Name = "panelbutton";
            this.panelbutton.Size = new System.Drawing.Size(95, 586);
            this.panelbutton.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.panelback1, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(162, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(800, 586);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // panelback1
            // 
            this.panelback1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelback1.Controls.Add(this.panelback);
            this.panelback1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelback1.Location = new System.Drawing.Point(3, 8);
            this.panelback1.Name = "panelback1";
            this.panelback1.Size = new System.Drawing.Size(794, 570);
            this.panelback1.TabIndex = 0;
            // 
            // panelback
            // 
            this.panelback.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelback.Location = new System.Drawing.Point(0, 0);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(794, 570);
            this.panelback.TabIndex = 1;
            this.panelback.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.panelback_ControlAdded);
            this.panelback.Paint += new System.Windows.Forms.PaintEventHandler(this.panelback_Paint);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.treeView1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 586F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(153, 586);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Red;
            this.imageList1.Images.SetKeyName(0, "mt1.png");
            this.imageList1.Images.SetKeyName(1, "mt2.png");
            this.imageList1.Images.SetKeyName(2, "mt3.png");
            this.imageList1.Images.SetKeyName(3, "mt4.png");
            this.imageList1.Images.SetKeyName(4, "mt5.png");
            this.imageList1.Images.SetKeyName(5, "mt5.png");
            this.imageList1.Images.SetKeyName(6, "mt6.png");
            this.imageList1.Images.SetKeyName(7, "mt7.png");
            this.imageList1.Images.SetKeyName(8, "mt8.png");
            this.imageList1.Images.SetKeyName(9, "mt9.png");
            this.imageList1.Images.SetKeyName(10, "mt10.png");
            this.imageList1.Images.SetKeyName(11, "mt11.ico");
            this.imageList1.Images.SetKeyName(12, "mt12.ico");
            this.imageList1.Images.SetKeyName(13, "控制台图标.png");
            this.imageList1.Images.SetKeyName(14, "额外显示图标.png");
            this.imageList1.Images.SetKeyName(15, "打开方法图标.ico");
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
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "12.ico");
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonExNext
            // 
            this.buttonExNext.BackColor = System.Drawing.Color.Transparent;
            this.buttonExNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonExNext.BackgroundImage")));
            this.buttonExNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExNext.FlatAppearance.BorderSize = 0;
            this.buttonExNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonExNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonExNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExNext.ForeColor = System.Drawing.Color.White;
            this.buttonExNext.Image = ((System.Drawing.Image)(resources.GetObject("buttonExNext.Image")));
            this.buttonExNext.Location = new System.Drawing.Point(3, 76);
            this.buttonExNext.Name = "buttonExNext";
            this.buttonExNext.Size = new System.Drawing.Size(89, 67);
            this.buttonExNext.TabIndex = 82;
            this.buttonExNext.Text = "下一步";
            this.buttonExNext.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonExNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonExNext.UseMnemonic = false;
            this.buttonExNext.UseVisualStyleBackColor = false;
            this.buttonExNext.Click += new System.EventHandler(this.buttonExNext_Click);
            // 
            // btnexprint
            // 
            this.btnexprint.BackColor = System.Drawing.Color.Transparent;
            this.btnexprint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnexprint.BackgroundImage")));
            this.btnexprint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnexprint.FlatAppearance.BorderSize = 0;
            this.btnexprint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnexprint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnexprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexprint.ForeColor = System.Drawing.Color.White;
            this.btnexprint.Image = ((System.Drawing.Image)(resources.GetObject("btnexprint.Image")));
            this.btnexprint.Location = new System.Drawing.Point(3, 544);
            this.btnexprint.Name = "btnexprint";
            this.btnexprint.Size = new System.Drawing.Size(89, 67);
            this.btnexprint.TabIndex = 81;
            this.btnexprint.Text = "打印";
            this.btnexprint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnexprint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnexprint.UseMnemonic = false;
            this.btnexprint.UseVisualStyleBackColor = false;
            this.btnexprint.Visible = false;
            // 
            // btnexsave
            // 
            this.btnexsave.BackColor = System.Drawing.Color.Transparent;
            this.btnexsave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnexsave.BackgroundImage")));
            this.btnexsave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnexsave.FlatAppearance.BorderSize = 0;
            this.btnexsave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnexsave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnexsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexsave.ForeColor = System.Drawing.Color.White;
            this.btnexsave.Image = ((System.Drawing.Image)(resources.GetObject("btnexsave.Image")));
            this.btnexsave.Location = new System.Drawing.Point(3, 392);
            this.btnexsave.Name = "btnexsave";
            this.btnexsave.Size = new System.Drawing.Size(89, 67);
            this.btnexsave.TabIndex = 80;
            this.btnexsave.Text = "保存";
            this.btnexsave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnexsave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnexsave.UseMnemonic = false;
            this.btnexsave.UseVisualStyleBackColor = false;
            this.btnexsave.Visible = false;
            // 
            // btnexsaveclose
            // 
            this.btnexsaveclose.BackColor = System.Drawing.Color.Transparent;
            this.btnexsaveclose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnexsaveclose.BackgroundImage")));
            this.btnexsaveclose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnexsaveclose.FlatAppearance.BorderSize = 0;
            this.btnexsaveclose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnexsaveclose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnexsaveclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexsaveclose.ForeColor = System.Drawing.Color.White;
            this.btnexsaveclose.Image = ((System.Drawing.Image)(resources.GetObject("btnexsaveclose.Image")));
            this.btnexsaveclose.Location = new System.Drawing.Point(3, 316);
            this.btnexsaveclose.Name = "btnexsaveclose";
            this.btnexsaveclose.Size = new System.Drawing.Size(89, 67);
            this.btnexsaveclose.TabIndex = 79;
            this.btnexsaveclose.Text = "保存后关闭";
            this.btnexsaveclose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnexsaveclose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnexsaveclose.UseMnemonic = false;
            this.btnexsaveclose.UseVisualStyleBackColor = false;
            this.btnexsaveclose.Visible = false;
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
            this.btnsaveas.Location = new System.Drawing.Point(3, 468);
            this.btnsaveas.Name = "btnsaveas";
            this.btnsaveas.Size = new System.Drawing.Size(89, 67);
            this.btnsaveas.TabIndex = 78;
            this.btnsaveas.Text = "另存为";
            this.btnsaveas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnsaveas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnsaveas.UseMnemonic = false;
            this.btnsaveas.UseVisualStyleBackColor = false;
            this.btnsaveas.Visible = false;
            // 
            // btnexread
            // 
            this.btnexread.BackColor = System.Drawing.Color.Transparent;
            this.btnexread.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnexread.BackgroundImage")));
            this.btnexread.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnexread.FlatAppearance.BorderSize = 0;
            this.btnexread.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnexread.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnexread.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexread.ForeColor = System.Drawing.Color.White;
            this.btnexread.Image = ((System.Drawing.Image)(resources.GetObject("btnexread.Image")));
            this.btnexread.Location = new System.Drawing.Point(-15, 316);
            this.btnexread.Name = "btnexread";
            this.btnexread.Size = new System.Drawing.Size(89, 67);
            this.btnexread.TabIndex = 74;
            this.btnexread.Text = "浏览";
            this.btnexread.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnexread.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnexread.UseMnemonic = false;
            this.btnexread.UseVisualStyleBackColor = false;
            this.btnexread.Visible = false;
            // 
            // btnexopen
            // 
            this.btnexopen.BackColor = System.Drawing.Color.Transparent;
            this.btnexopen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnexopen.FlatAppearance.BorderSize = 0;
            this.btnexopen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnexopen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnexopen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexopen.ForeColor = System.Drawing.Color.White;
            this.btnexopen.Image = ((System.Drawing.Image)(resources.GetObject("btnexopen.Image")));
            this.btnexopen.Location = new System.Drawing.Point(3, 3);
            this.btnexopen.Name = "btnexopen";
            this.btnexopen.Size = new System.Drawing.Size(89, 67);
            this.btnexopen.TabIndex = 73;
            this.btnexopen.Text = "打开";
            this.btnexopen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnexopen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnexopen.UseMnemonic = false;
            this.btnexopen.UseVisualStyleBackColor = false;
            this.btnexopen.Click += new System.EventHandler(this.btnexopen_Click);
            // 
            // btnexnew
            // 
            this.btnexnew.BackColor = System.Drawing.Color.Transparent;
            this.btnexnew.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnexnew.BackgroundImage")));
            this.btnexnew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnexnew.FlatAppearance.BorderSize = 0;
            this.btnexnew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnexnew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnexnew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexnew.ForeColor = System.Drawing.Color.White;
            this.btnexnew.Image = ((System.Drawing.Image)(resources.GetObject("btnexnew.Image")));
            this.btnexnew.Location = new System.Drawing.Point(3, 159);
            this.btnexnew.Name = "btnexnew";
            this.btnexnew.Size = new System.Drawing.Size(89, 67);
            this.btnexnew.TabIndex = 69;
            this.btnexnew.Text = "新建";
            this.btnexnew.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnexnew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnexnew.UseMnemonic = false;
            this.btnexnew.UseVisualStyleBackColor = false;
            this.btnexnew.Visible = false;
            this.btnexnew.Click += new System.EventHandler(this.btnexnew_Click);
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.CausesValidation = false;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.treeView1.FullRowSelect = true;
            this.treeView1.ItemHeight = 32;
            this.treeView1.Location = new System.Drawing.Point(23, 3);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点0";
            treeNode1.StateImageIndex = 0;
            treeNode1.Text = "选择方法";
            treeNode2.Name = "节点0";
            treeNode2.StateImageIndex = 0;
            treeNode2.Text = "打开方法";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.treeView1.Scrollable = false;
            this.treeView1.ShowLines = false;
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.ShowRootLines = false;
            this.treeView1.Size = new System.Drawing.Size(127, 580);
            this.treeView1.StateImageList = this.imageList1;
            this.treeView1.TabIndex = 5;
            this.treeView1.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeView1_DrawNode);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // UserControlOpenMethod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UserControlOpenMethod";
            this.Size = new System.Drawing.Size(1066, 592);
            this.Load += new System.EventHandler(this.UserControlMethod_Load);
            this.SizeChanged += new System.EventHandler(this.UserControlOpenMethod_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserControl5_Paint);
            this.Resize += new System.EventHandler(this.UserControlOpenMethod_Resize);
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
        private TreeListEx treeView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panelback1;
        public ButtonExNew buttonExNext;
        public ButtonExNew btnexprint;
        public ButtonExNew btnexsave;
        public ButtonExNew btnexsaveclose;
        public ButtonExNew btnsaveas;
        public ButtonExNew btnexread;
        public ButtonExNew btnexopen;
        public ButtonExNew btnexnew;
        public System.Windows.Forms.Panel panelback;
        public System.Windows.Forms.Panel panelbutton;
        private System.Windows.Forms.ImageList imageList3;
        private System.Windows.Forms.Timer timer1;

    }
}
