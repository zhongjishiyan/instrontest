namespace TabHeaderDemo
{
    partial class UserControlMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlMain));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panelback = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnmain = new TabHeaderDemo.ButtonExNew(this.components);
            this.btnmmanage = new System.Windows.Forms.Button();
            this.btnmmethod = new System.Windows.Forms.Button();
            this.btnmtest = new System.Windows.Forms.Button();
            this.btnmreport = new System.Windows.Forms.Button();
            this.panelback.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "adobe1.ico");
            this.imageList1.Images.SetKeyName(1, "adobe2.ico");
            this.imageList1.Images.SetKeyName(2, "au sound.ico");
            this.imageList1.Images.SetKeyName(3, "Audio Cd.ico");
            this.imageList1.Images.SetKeyName(4, "AUTHOR.ICO");
            this.imageList1.Images.SetKeyName(5, "ICONMAKE.ICO");
            this.imageList1.Images.SetKeyName(6, "interface.ico");
            // 
            // panelback
            // 
            resources.ApplyResources(this.panelback, "panelback");
            this.panelback.Controls.Add(this.tabControl1);
            this.panelback.ForeColor = System.Drawing.Color.Black;
            this.panelback.Name = "panelback";
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            resources.ApplyResources(this.tabPage5, "tabPage5");
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            resources.ApplyResources(this.tabPage6, "tabPage6");
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            resources.ApplyResources(this.tabPage7, "tabPage7");
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.btnmain);
            this.panel1.Controls.Add(this.btnmmanage);
            this.panel1.Controls.Add(this.btnmmethod);
            this.panel1.Controls.Add(this.btnmtest);
            this.panel1.Controls.Add(this.btnmreport);
            this.panel1.Name = "panel1";
            // 
            // btnmain
            // 
            resources.ApplyResources(this.btnmain, "btnmain");
            this.btnmain.BackColor = System.Drawing.Color.Transparent;
            this.btnmain.FlatAppearance.BorderSize = 0;
            this.btnmain.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnmain.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnmain.ForeColor = System.Drawing.Color.White;
            this.btnmain.Name = "btnmain";
            this.btnmain.UseCompatibleTextRendering = true;
            this.btnmain.UseVisualStyleBackColor = true;
            this.btnmain.Click += new System.EventHandler(this.btnmain_Click);
            // 
            // btnmmanage
            // 
            resources.ApplyResources(this.btnmmanage, "btnmmanage");
            this.btnmmanage.BackColor = System.Drawing.Color.Transparent;
            this.btnmmanage.FlatAppearance.BorderSize = 0;
            this.btnmmanage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnmmanage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnmmanage.ForeColor = System.Drawing.Color.White;
            this.btnmmanage.Name = "btnmmanage";
            this.btnmmanage.UseCompatibleTextRendering = true;
            this.btnmmanage.UseVisualStyleBackColor = true;
            this.btnmmanage.Click += new System.EventHandler(this.btnmmanage_Click);
            // 
            // btnmmethod
            // 
            resources.ApplyResources(this.btnmmethod, "btnmmethod");
            this.btnmmethod.BackColor = System.Drawing.Color.Transparent;
            this.btnmmethod.FlatAppearance.BorderSize = 0;
            this.btnmmethod.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnmmethod.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnmmethod.ForeColor = System.Drawing.Color.White;
            this.btnmmethod.Name = "btnmmethod";
            this.btnmmethod.UseCompatibleTextRendering = true;
            this.btnmmethod.UseVisualStyleBackColor = true;
            this.btnmmethod.Click += new System.EventHandler(this.btnmmethod_Click);
            // 
            // btnmtest
            // 
            resources.ApplyResources(this.btnmtest, "btnmtest");
            this.btnmtest.BackColor = System.Drawing.Color.Transparent;
            this.btnmtest.FlatAppearance.BorderSize = 0;
            this.btnmtest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnmtest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnmtest.ForeColor = System.Drawing.Color.Yellow;
            this.btnmtest.Name = "btnmtest";
            this.btnmtest.UseCompatibleTextRendering = true;
            this.btnmtest.UseVisualStyleBackColor = true;
            this.btnmtest.Click += new System.EventHandler(this.btnmtest_Click);
            // 
            // btnmreport
            // 
            resources.ApplyResources(this.btnmreport, "btnmreport");
            this.btnmreport.BackColor = System.Drawing.Color.Transparent;
            this.btnmreport.FlatAppearance.BorderSize = 0;
            this.btnmreport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnmreport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnmreport.ForeColor = System.Drawing.Color.White;
            this.btnmreport.Name = "btnmreport";
            this.btnmreport.UseCompatibleTextRendering = true;
            this.btnmreport.UseVisualStyleBackColor = true;
            this.btnmreport.Click += new System.EventHandler(this.btnmreport_Click);
            // 
            // UserControlMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelback);
            this.Name = "UserControlMain";
            this.Load += new System.EventHandler(this.UserControlMain_Load);
            this.SizeChanged += new System.EventHandler(this.UserControlMain_SizeChanged);
            this.Resize += new System.EventHandler(this.UserControlMain_Resize);
            this.panelback.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.Panel panel1;
        public ButtonExNew btnmain;
        public System.Windows.Forms.Button btnmmanage;
        public System.Windows.Forms.Button btnmmethod;
        public System.Windows.Forms.Button btnmtest;
        public System.Windows.Forms.Button btnmreport;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage7;
    }
}
