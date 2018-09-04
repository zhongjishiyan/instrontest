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
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.panelback1, 0, 1);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // panelback1
            // 
            resources.ApplyResources(this.panelback1, "panelback1");
            this.panelback1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelback1.Controls.Add(this.panelback);
            this.panelback1.Name = "panelback1";
            // 
            // panelback
            // 
            resources.ApplyResources(this.panelback, "panelback");
            this.panelback.Name = "panelback";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.treeView1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // treeView1
            // 
            resources.ApplyResources(this.treeView1, "treeView1");
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.treeView1.FullRowSelect = true;
            this.treeView1.ItemHeight = 32;
            this.treeView1.Name = "treeView1";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            ((System.Windows.Forms.TreeNode)(resources.GetObject("treeView1.Nodes"))),
            ((System.Windows.Forms.TreeNode)(resources.GetObject("treeView1.Nodes1"))),
            ((System.Windows.Forms.TreeNode)(resources.GetObject("treeView1.Nodes2"))),
            ((System.Windows.Forms.TreeNode)(resources.GetObject("treeView1.Nodes3")))});
            this.treeView1.ShowLines = false;
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.ShowRootLines = false;
            this.treeView1.StateImageList = this.imageList1;
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
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Controls.Add(this.buttonEx3);
            this.panel3.Controls.Add(this.buttonEx2);
            this.panel3.Controls.Add(this.buttonEx1);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.button7);
            this.panel3.Name = "panel3";
            // 
            // buttonEx3
            // 
            resources.ApplyResources(this.buttonEx3, "buttonEx3");
            this.buttonEx3.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx3.FlatAppearance.BorderSize = 0;
            this.buttonEx3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonEx3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonEx3.ForeColor = System.Drawing.Color.White;
            this.buttonEx3.Name = "buttonEx3";
            this.buttonEx3.UseMnemonic = false;
            this.buttonEx3.UseVisualStyleBackColor = false;
            // 
            // buttonEx2
            // 
            resources.ApplyResources(this.buttonEx2, "buttonEx2");
            this.buttonEx2.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx2.FlatAppearance.BorderSize = 0;
            this.buttonEx2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonEx2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonEx2.ForeColor = System.Drawing.Color.White;
            this.buttonEx2.Name = "buttonEx2";
            this.buttonEx2.UseMnemonic = false;
            this.buttonEx2.UseVisualStyleBackColor = false;
            // 
            // buttonEx1
            // 
            resources.ApplyResources(this.buttonEx1, "buttonEx1");
            this.buttonEx1.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx1.FlatAppearance.BorderSize = 0;
            this.buttonEx1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonEx1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonEx1.ForeColor = System.Drawing.Color.White;
            this.buttonEx1.Name = "buttonEx1";
            this.buttonEx1.UseMnemonic = false;
            this.buttonEx1.UseVisualStyleBackColor = false;
            this.buttonEx1.Click += new System.EventHandler(this.buttonEx1_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Name = "button1";
            this.button1.UseMnemonic = false;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            resources.ApplyResources(this.button7, "button7");
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Name = "button7";
            this.button7.UseMnemonic = false;
            this.button7.UseVisualStyleBackColor = false;
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
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UserManage";
            this.Load += new System.EventHandler(this.UserManage_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserManage_Paint);
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
        private System.Windows.Forms.ImageList imageList3;
        public System.Windows.Forms.Panel panelback;
    }
}
