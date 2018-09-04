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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelbutton = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelbutton.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panelback1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.Controls.Add(this.panelbutton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // panelbutton
            // 
            resources.ApplyResources(this.panelbutton, "panelbutton");
            this.panelbutton.Controls.Add(this.button1);
            this.panelbutton.Controls.Add(this.btnprint);
            this.panelbutton.Controls.Add(this.btnopen);
            this.panelbutton.Controls.Add(this.buttonEx1);
            this.panelbutton.Controls.Add(this.btnsave);
            this.panelbutton.Controls.Add(this.btnsaveas);
            this.panelbutton.Name = "panelbutton";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnprint
            // 
            resources.ApplyResources(this.btnprint, "btnprint");
            this.btnprint.BackColor = System.Drawing.Color.Transparent;
            this.btnprint.FlatAppearance.BorderSize = 0;
            this.btnprint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnprint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnprint.ForeColor = System.Drawing.Color.White;
            this.btnprint.Name = "btnprint";
            this.btnprint.UseMnemonic = false;
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // btnopen
            // 
            resources.ApplyResources(this.btnopen, "btnopen");
            this.btnopen.BackColor = System.Drawing.Color.Transparent;
            this.btnopen.FlatAppearance.BorderSize = 0;
            this.btnopen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnopen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnopen.ForeColor = System.Drawing.Color.White;
            this.btnopen.Name = "btnopen";
            this.btnopen.UseMnemonic = false;
            this.btnopen.UseVisualStyleBackColor = false;
            this.btnopen.Click += new System.EventHandler(this.btnopen_Click);
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
            // btnsave
            // 
            resources.ApplyResources(this.btnsave, "btnsave");
            this.btnsave.BackColor = System.Drawing.Color.Transparent;
            this.btnsave.FlatAppearance.BorderSize = 0;
            this.btnsave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnsave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.Name = "btnsave";
            this.btnsave.UseMnemonic = false;
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
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
            ((System.Windows.Forms.TreeNode)(resources.GetObject("treeView1.Nodes")))});
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
            this.imageList1.Images.SetKeyName(0, "bg1.ico");
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
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
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // saveFileDialog1
            // 
            resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
            // 
            // UserReport
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "UserReport";
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
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button1;
    }
}
