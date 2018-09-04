namespace TabHeaderDemo
{
    partial class UserControlMethod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlMethod));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelbutton = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panelback1 = new System.Windows.Forms.Panel();
            this.panelback = new System.Windows.Forms.Panel();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.treeView1 = new TabHeaderDemo.TreeListEx(this.components);
            this.btnexprint = new TabHeaderDemo.ButtonExNew(this.components);
            this.btnexsave = new TabHeaderDemo.ButtonExNew(this.components);
            this.btnexsaveclose = new TabHeaderDemo.ButtonExNew(this.components);
            this.btnexread = new TabHeaderDemo.ButtonExNew(this.components);
            this.btnexopen = new TabHeaderDemo.ButtonExNew(this.components);
            this.btnsaveas = new TabHeaderDemo.ButtonExNew(this.components);
            this.btnexnew = new TabHeaderDemo.ButtonExNew(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelbutton.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panelback1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelbutton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.treeView1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
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
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // panelbutton
            // 
            resources.ApplyResources(this.panelbutton, "panelbutton");
            this.panelbutton.BackColor = System.Drawing.Color.Silver;
            this.panelbutton.Controls.Add(this.btnexprint);
            this.panelbutton.Controls.Add(this.btnexsave);
            this.panelbutton.Controls.Add(this.btnexsaveclose);
            this.panelbutton.Controls.Add(this.btnexread);
            this.panelbutton.Controls.Add(this.btnexopen);
            this.panelbutton.Controls.Add(this.btnsaveas);
            this.panelbutton.Controls.Add(this.btnexnew);
            this.panelbutton.Name = "panelbutton";
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
            this.panelback.Paint += new System.Windows.Forms.PaintEventHandler(this.panelback_Paint);
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
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "12.ico");
            // 
            // saveFileDialog1
            // 
            resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // treeView1
            // 
            resources.ApplyResources(this.treeView1, "treeView1");
            this.treeView1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.CausesValidation = false;
            this.treeView1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.treeView1.FullRowSelect = true;
            this.treeView1.ItemHeight = 32;
            this.treeView1.Name = "treeView1";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            ((System.Windows.Forms.TreeNode)(resources.GetObject("treeView1.Nodes"))),
            ((System.Windows.Forms.TreeNode)(resources.GetObject("treeView1.Nodes1"))),
            ((System.Windows.Forms.TreeNode)(resources.GetObject("treeView1.Nodes2"))),
            ((System.Windows.Forms.TreeNode)(resources.GetObject("treeView1.Nodes3"))),
            ((System.Windows.Forms.TreeNode)(resources.GetObject("treeView1.Nodes4"))),
            ((System.Windows.Forms.TreeNode)(resources.GetObject("treeView1.Nodes5"))),
            ((System.Windows.Forms.TreeNode)(resources.GetObject("treeView1.Nodes6"))),
            ((System.Windows.Forms.TreeNode)(resources.GetObject("treeView1.Nodes7"))),
            ((System.Windows.Forms.TreeNode)(resources.GetObject("treeView1.Nodes8"))),
            ((System.Windows.Forms.TreeNode)(resources.GetObject("treeView1.Nodes9"))),
            ((System.Windows.Forms.TreeNode)(resources.GetObject("treeView1.Nodes10"))),
            ((System.Windows.Forms.TreeNode)(resources.GetObject("treeView1.Nodes11")))});
            this.treeView1.Scrollable = false;
            this.treeView1.ShowLines = false;
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.ShowRootLines = false;
            this.treeView1.StateImageList = this.imageList1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            this.treeView1.EnabledChanged += new System.EventHandler(this.treeView1_EnabledChanged);
            // 
            // btnexprint
            // 
            resources.ApplyResources(this.btnexprint, "btnexprint");
            this.btnexprint.BackColor = System.Drawing.Color.Transparent;
            this.btnexprint.FlatAppearance.BorderSize = 0;
            this.btnexprint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnexprint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnexprint.ForeColor = System.Drawing.Color.White;
            this.btnexprint.Name = "btnexprint";
            this.btnexprint.UseMnemonic = false;
            this.btnexprint.UseVisualStyleBackColor = false;
            this.btnexprint.Click += new System.EventHandler(this.btnexprint_Click);
            // 
            // btnexsave
            // 
            resources.ApplyResources(this.btnexsave, "btnexsave");
            this.btnexsave.BackColor = System.Drawing.Color.Transparent;
            this.btnexsave.FlatAppearance.BorderSize = 0;
            this.btnexsave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnexsave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnexsave.ForeColor = System.Drawing.Color.White;
            this.btnexsave.Name = "btnexsave";
            this.btnexsave.UseMnemonic = false;
            this.btnexsave.UseVisualStyleBackColor = false;
            this.btnexsave.Click += new System.EventHandler(this.btnexsave_Click);
            // 
            // btnexsaveclose
            // 
            resources.ApplyResources(this.btnexsaveclose, "btnexsaveclose");
            this.btnexsaveclose.BackColor = System.Drawing.Color.Transparent;
            this.btnexsaveclose.FlatAppearance.BorderSize = 0;
            this.btnexsaveclose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnexsaveclose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnexsaveclose.ForeColor = System.Drawing.Color.White;
            this.btnexsaveclose.Name = "btnexsaveclose";
            this.btnexsaveclose.UseMnemonic = false;
            this.btnexsaveclose.UseVisualStyleBackColor = false;
            this.btnexsaveclose.Click += new System.EventHandler(this.btnexsaveclose_Click);
            // 
            // btnexread
            // 
            resources.ApplyResources(this.btnexread, "btnexread");
            this.btnexread.BackColor = System.Drawing.Color.Transparent;
            this.btnexread.FlatAppearance.BorderSize = 0;
            this.btnexread.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnexread.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnexread.ForeColor = System.Drawing.Color.White;
            this.btnexread.Name = "btnexread";
            this.btnexread.UseMnemonic = false;
            this.btnexread.UseVisualStyleBackColor = false;
            // 
            // btnexopen
            // 
            resources.ApplyResources(this.btnexopen, "btnexopen");
            this.btnexopen.BackColor = System.Drawing.Color.Transparent;
            this.btnexopen.FlatAppearance.BorderSize = 0;
            this.btnexopen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnexopen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnexopen.ForeColor = System.Drawing.Color.White;
            this.btnexopen.Name = "btnexopen";
            this.btnexopen.UseMnemonic = false;
            this.btnexopen.UseVisualStyleBackColor = false;
            this.btnexopen.Click += new System.EventHandler(this.btnexopen_Click);
            // 
            // btnsaveas
            // 
            resources.ApplyResources(this.btnsaveas, "btnsaveas");
            this.btnsaveas.BackColor = System.Drawing.Color.Transparent;
            this.btnsaveas.FlatAppearance.BorderSize = 0;
            this.btnsaveas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnsaveas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnsaveas.ForeColor = System.Drawing.Color.White;
            this.btnsaveas.Name = "btnsaveas";
            this.btnsaveas.UseMnemonic = false;
            this.btnsaveas.UseVisualStyleBackColor = false;
            this.btnsaveas.Click += new System.EventHandler(this.btnsaveas_Click);
            // 
            // btnexnew
            // 
            resources.ApplyResources(this.btnexnew, "btnexnew");
            this.btnexnew.BackColor = System.Drawing.Color.Transparent;
            this.btnexnew.FlatAppearance.BorderSize = 0;
            this.btnexnew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnexnew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnexnew.ForeColor = System.Drawing.Color.White;
            this.btnexnew.Name = "btnexnew";
            this.btnexnew.UseMnemonic = false;
            this.btnexnew.UseVisualStyleBackColor = false;
            // 
            // UserControlMethod
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UserControlMethod";
            this.Load += new System.EventHandler(this.UserControlMethod_Load);
            this.TabIndexChanged += new System.EventHandler(this.UserControlMethod_TabIndexChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserControl5_Paint);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panelbutton.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panelback1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        public ButtonExNew btnexnew;
        public ButtonExNew btnexprint;
        public ButtonExNew btnexsave;
        public ButtonExNew btnexsaveclose;
        public ButtonExNew btnexread;
        public ButtonExNew btnexopen;
        public ButtonExNew btnsaveas;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panelback1;
        public System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.ImageList imageList3;
        public System.Windows.Forms.Panel panelbutton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public TreeListEx treeView1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}
