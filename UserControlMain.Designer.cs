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
            this.panelback.Controls.Add(this.tabControl1);
            this.panelback.ForeColor = System.Drawing.Color.Black;
            this.panelback.Location = new System.Drawing.Point(0, 38);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(1042, 551);
            this.panelback.TabIndex = 8;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1042, 551);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1034, 525);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1034, 525);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1034, 525);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1034, 525);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1034, 525);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1034, 525);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(1034, 525);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnmain);
            this.panel1.Controls.Add(this.btnmmanage);
            this.panel1.Controls.Add(this.btnmmethod);
            this.panel1.Controls.Add(this.btnmtest);
            this.panel1.Controls.Add(this.btnmreport);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1042, 38);
            this.panel1.TabIndex = 16;
            // 
            // btnmain
            // 
            this.btnmain.BackColor = System.Drawing.Color.Transparent;
            this.btnmain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnmain.BackgroundImage")));
            this.btnmain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnmain.FlatAppearance.BorderSize = 0;
            this.btnmain.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnmain.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnmain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnmain.ForeColor = System.Drawing.Color.White;
            this.btnmain.Location = new System.Drawing.Point(3, 6);
            this.btnmain.Name = "btnmain";
            this.btnmain.Size = new System.Drawing.Size(133, 29);
            this.btnmain.TabIndex = 36;
            this.btnmain.Text = "AppleLab  ";
            this.btnmain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnmain.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnmain.UseCompatibleTextRendering = true;
            this.btnmain.UseVisualStyleBackColor = true;
            this.btnmain.Click += new System.EventHandler(this.btnmain_Click);
            // 
            // btnmmanage
            // 
            this.btnmmanage.BackColor = System.Drawing.Color.Transparent;
            this.btnmmanage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnmmanage.BackgroundImage")));
            this.btnmmanage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnmmanage.FlatAppearance.BorderSize = 0;
            this.btnmmanage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnmmanage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnmmanage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmmanage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnmmanage.ForeColor = System.Drawing.Color.White;
            this.btnmmanage.Image = ((System.Drawing.Image)(resources.GetObject("btnmmanage.Image")));
            this.btnmmanage.Location = new System.Drawing.Point(644, 10);
            this.btnmmanage.Name = "btnmmanage";
            this.btnmmanage.Size = new System.Drawing.Size(138, 29);
            this.btnmmanage.TabIndex = 35;
            this.btnmmanage.Text = " 管理器";
            this.btnmmanage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnmmanage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnmmanage.UseCompatibleTextRendering = true;
            this.btnmmanage.UseVisualStyleBackColor = true;
            this.btnmmanage.Click += new System.EventHandler(this.btnmmanage_Click);
            // 
            // btnmmethod
            // 
            this.btnmmethod.BackColor = System.Drawing.Color.Transparent;
            this.btnmmethod.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnmmethod.BackgroundImage")));
            this.btnmmethod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnmmethod.FlatAppearance.BorderSize = 0;
            this.btnmmethod.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnmmethod.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnmmethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmmethod.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnmmethod.ForeColor = System.Drawing.Color.White;
            this.btnmmethod.Image = ((System.Drawing.Image)(resources.GetObject("btnmmethod.Image")));
            this.btnmmethod.Location = new System.Drawing.Point(322, 9);
            this.btnmmethod.Name = "btnmmethod";
            this.btnmmethod.Size = new System.Drawing.Size(138, 29);
            this.btnmmethod.TabIndex = 33;
            this.btnmmethod.Text = " 方法";
            this.btnmmethod.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnmmethod.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnmmethod.UseCompatibleTextRendering = true;
            this.btnmmethod.UseVisualStyleBackColor = true;
            this.btnmmethod.Click += new System.EventHandler(this.btnmmethod_Click);
            // 
            // btnmtest
            // 
            this.btnmtest.BackColor = System.Drawing.Color.Transparent;
            this.btnmtest.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnmtest.BackgroundImage")));
            this.btnmtest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnmtest.FlatAppearance.BorderSize = 0;
            this.btnmtest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnmtest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnmtest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmtest.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnmtest.ForeColor = System.Drawing.Color.Yellow;
            this.btnmtest.Image = ((System.Drawing.Image)(resources.GetObject("btnmtest.Image")));
            this.btnmtest.Location = new System.Drawing.Point(161, 9);
            this.btnmtest.Name = "btnmtest";
            this.btnmtest.Size = new System.Drawing.Size(138, 30);
            this.btnmtest.TabIndex = 32;
            this.btnmtest.Text = " 测试";
            this.btnmtest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnmtest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnmtest.UseCompatibleTextRendering = true;
            this.btnmtest.UseVisualStyleBackColor = true;
            this.btnmtest.Click += new System.EventHandler(this.btnmtest_Click);
            // 
            // btnmreport
            // 
            this.btnmreport.BackColor = System.Drawing.Color.Transparent;
            this.btnmreport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnmreport.BackgroundImage")));
            this.btnmreport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnmreport.FlatAppearance.BorderSize = 0;
            this.btnmreport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnmreport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnmreport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmreport.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnmreport.ForeColor = System.Drawing.Color.White;
            this.btnmreport.Image = ((System.Drawing.Image)(resources.GetObject("btnmreport.Image")));
            this.btnmreport.Location = new System.Drawing.Point(483, 10);
            this.btnmreport.Name = "btnmreport";
            this.btnmreport.Size = new System.Drawing.Size(138, 29);
            this.btnmreport.TabIndex = 34;
            this.btnmreport.Text = " 报告";
            this.btnmreport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnmreport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnmreport.UseCompatibleTextRendering = true;
            this.btnmreport.UseVisualStyleBackColor = true;
            this.btnmreport.Click += new System.EventHandler(this.btnmreport_Click);
            // 
            // UserControlMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelback);
            this.Name = "UserControlMain";
            this.Size = new System.Drawing.Size(1042, 589);
            this.Load += new System.EventHandler(this.UserControlMain_Load);
            this.Resize += new System.EventHandler(this.UserControlMain_Resize);
            this.SizeChanged += new System.EventHandler(this.UserControlMain_SizeChanged);
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
