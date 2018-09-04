namespace TabHeaderDemo
{
    partial class UserControlTop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlTop));
            this.pnlback = new System.Windows.Forms.Panel();
            this.paneltip = new System.Windows.Forms.Panel();
            this.paneldefine = new System.Windows.Forms.Panel();
            this.wordArt1 = new TabHeaderDemo.WordArt();
            this.btnuser = new TabHeaderDemo.ButtonExNew(this.components);
            this.btnexit = new TabHeaderDemo.ButtonExNew(this.components);
            this.btnhelp = new TabHeaderDemo.ButtonExNew(this.components);
            this.btnmanage = new TabHeaderDemo.ButtonExNew(this.components);
            this.btnreport = new TabHeaderDemo.ButtonExNew(this.components);
            this.btnmethod = new TabHeaderDemo.ButtonExNew(this.components);
            this.btntest = new TabHeaderDemo.ButtonExNew(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.lbltip = new System.Windows.Forms.Label();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.pnlback.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlback
            // 
            resources.ApplyResources(this.pnlback, "pnlback");
            this.pnlback.BackColor = System.Drawing.Color.White;
            this.pnlback.Controls.Add(this.paneltip);
            this.pnlback.Controls.Add(this.paneldefine);
            this.pnlback.Controls.Add(this.wordArt1);
            this.pnlback.Controls.Add(this.btnuser);
            this.pnlback.Controls.Add(this.btnexit);
            this.pnlback.Controls.Add(this.btnhelp);
            this.pnlback.Controls.Add(this.btnmanage);
            this.pnlback.Controls.Add(this.btnreport);
            this.pnlback.Controls.Add(this.btnmethod);
            this.pnlback.Controls.Add(this.btntest);
            this.pnlback.Controls.Add(this.panel6);
            this.pnlback.ForeColor = System.Drawing.Color.White;
            this.helpProvider1.SetHelpKeyword(this.pnlback, resources.GetString("pnlback.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.pnlback, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("pnlback.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.pnlback, resources.GetString("pnlback.HelpString"));
            this.pnlback.Name = "pnlback";
            this.helpProvider1.SetShowHelp(this.pnlback, ((bool)(resources.GetObject("pnlback.ShowHelp"))));
            this.pnlback.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlback_Paint);
            this.pnlback.Resize += new System.EventHandler(this.pnlback_Resize);
            // 
            // paneltip
            // 
            resources.ApplyResources(this.paneltip, "paneltip");
            this.paneltip.BackColor = System.Drawing.Color.Transparent;
            this.helpProvider1.SetHelpKeyword(this.paneltip, resources.GetString("paneltip.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.paneltip, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("paneltip.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.paneltip, resources.GetString("paneltip.HelpString"));
            this.paneltip.Name = "paneltip";
            this.helpProvider1.SetShowHelp(this.paneltip, ((bool)(resources.GetObject("paneltip.ShowHelp"))));
            // 
            // paneldefine
            // 
            resources.ApplyResources(this.paneldefine, "paneldefine");
            this.paneldefine.BackColor = System.Drawing.Color.Transparent;
            this.helpProvider1.SetHelpKeyword(this.paneldefine, resources.GetString("paneldefine.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.paneldefine, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("paneldefine.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.paneldefine, resources.GetString("paneldefine.HelpString"));
            this.paneldefine.Name = "paneldefine";
            this.helpProvider1.SetShowHelp(this.paneldefine, ((bool)(resources.GetObject("paneldefine.ShowHelp"))));
            // 
            // wordArt1
            // 
            resources.ApplyResources(this.wordArt1, "wordArt1");
            this.wordArt1.BackColor = System.Drawing.Color.Transparent;
            this.wordArt1.Caption = "AppleLab";
            this.helpProvider1.SetHelpKeyword(this.wordArt1, resources.GetString("wordArt1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.wordArt1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("wordArt1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.wordArt1, resources.GetString("wordArt1.HelpString"));
            this.wordArt1.Name = "wordArt1";
            this.helpProvider1.SetShowHelp(this.wordArt1, ((bool)(resources.GetObject("wordArt1.ShowHelp"))));
            this.wordArt1.WordArtBackColor = System.Drawing.Color.Gray;
            this.wordArt1.WordArtEffect = TabHeaderDemo.WordArtEffectStyle.projection;
            this.wordArt1.WordArtFont = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wordArt1.WordArtForeColor = System.Drawing.Color.BlueViolet;
            this.wordArt1.WordArtSmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.wordArt1.WordArtTextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // btnuser
            // 
            resources.ApplyResources(this.btnuser, "btnuser");
            this.btnuser.BackColor = System.Drawing.Color.Transparent;
            this.btnuser.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnuser.FlatAppearance.BorderSize = 0;
            this.btnuser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnuser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.helpProvider1.SetHelpKeyword(this.btnuser, resources.GetString("btnuser.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.btnuser, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("btnuser.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.btnuser, resources.GetString("btnuser.HelpString"));
            this.btnuser.Name = "btnuser";
            this.helpProvider1.SetShowHelp(this.btnuser, ((bool)(resources.GetObject("btnuser.ShowHelp"))));
            this.btnuser.UseVisualStyleBackColor = false;
            this.btnuser.Click += new System.EventHandler(this.btnuser_Click);
            this.btnuser.MouseEnter += new System.EventHandler(this.btnuser_MouseEnter);
            this.btnuser.MouseLeave += new System.EventHandler(this.btnuser_MouseLeave);
            // 
            // btnexit
            // 
            resources.ApplyResources(this.btnexit, "btnexit");
            this.btnexit.BackColor = System.Drawing.Color.Transparent;
            this.btnexit.FlatAppearance.BorderSize = 0;
            this.btnexit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnexit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.helpProvider1.SetHelpKeyword(this.btnexit, resources.GetString("btnexit.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.btnexit, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("btnexit.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.btnexit, resources.GetString("btnexit.HelpString"));
            this.btnexit.Name = "btnexit";
            this.helpProvider1.SetShowHelp(this.btnexit, ((bool)(resources.GetObject("btnexit.ShowHelp"))));
            this.btnexit.UseVisualStyleBackColor = false;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            this.btnexit.MouseEnter += new System.EventHandler(this.btnexit_MouseEnter);
            this.btnexit.MouseLeave += new System.EventHandler(this.btnexit_MouseLeave);
            // 
            // btnhelp
            // 
            resources.ApplyResources(this.btnhelp, "btnhelp");
            this.btnhelp.BackColor = System.Drawing.Color.Transparent;
            this.btnhelp.FlatAppearance.BorderSize = 0;
            this.btnhelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnhelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.helpProvider1.SetHelpKeyword(this.btnhelp, resources.GetString("btnhelp.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.btnhelp, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("btnhelp.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.btnhelp, resources.GetString("btnhelp.HelpString"));
            this.btnhelp.Name = "btnhelp";
            this.helpProvider1.SetShowHelp(this.btnhelp, ((bool)(resources.GetObject("btnhelp.ShowHelp"))));
            this.btnhelp.UseVisualStyleBackColor = false;
            this.btnhelp.Click += new System.EventHandler(this.btnhelp_Click);
            this.btnhelp.MouseEnter += new System.EventHandler(this.btnhelp_MouseEnter);
            this.btnhelp.MouseLeave += new System.EventHandler(this.btnhelp_MouseLeave);
            // 
            // btnmanage
            // 
            resources.ApplyResources(this.btnmanage, "btnmanage");
            this.btnmanage.BackColor = System.Drawing.Color.Transparent;
            this.btnmanage.FlatAppearance.BorderSize = 0;
            this.btnmanage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnmanage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.helpProvider1.SetHelpKeyword(this.btnmanage, resources.GetString("btnmanage.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.btnmanage, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("btnmanage.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.btnmanage, resources.GetString("btnmanage.HelpString"));
            this.btnmanage.Name = "btnmanage";
            this.helpProvider1.SetShowHelp(this.btnmanage, ((bool)(resources.GetObject("btnmanage.ShowHelp"))));
            this.btnmanage.UseVisualStyleBackColor = false;
            this.btnmanage.Click += new System.EventHandler(this.btnmanage_Click);
            this.btnmanage.MouseEnter += new System.EventHandler(this.btnmanage_MouseEnter);
            this.btnmanage.MouseLeave += new System.EventHandler(this.btnmanage_MouseLeave);
            // 
            // btnreport
            // 
            resources.ApplyResources(this.btnreport, "btnreport");
            this.btnreport.BackColor = System.Drawing.Color.Transparent;
            this.btnreport.FlatAppearance.BorderSize = 0;
            this.btnreport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnreport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.helpProvider1.SetHelpKeyword(this.btnreport, resources.GetString("btnreport.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.btnreport, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("btnreport.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.btnreport, resources.GetString("btnreport.HelpString"));
            this.btnreport.Name = "btnreport";
            this.helpProvider1.SetShowHelp(this.btnreport, ((bool)(resources.GetObject("btnreport.ShowHelp"))));
            this.btnreport.UseVisualStyleBackColor = false;
            this.btnreport.Click += new System.EventHandler(this.btnreport_Click);
            this.btnreport.MouseEnter += new System.EventHandler(this.btnreport_MouseEnter);
            this.btnreport.MouseLeave += new System.EventHandler(this.btnreport_MouseLeave);
            // 
            // btnmethod
            // 
            resources.ApplyResources(this.btnmethod, "btnmethod");
            this.btnmethod.BackColor = System.Drawing.Color.Transparent;
            this.btnmethod.FlatAppearance.BorderSize = 0;
            this.btnmethod.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnmethod.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.helpProvider1.SetHelpKeyword(this.btnmethod, resources.GetString("btnmethod.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.btnmethod, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("btnmethod.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.btnmethod, resources.GetString("btnmethod.HelpString"));
            this.btnmethod.Name = "btnmethod";
            this.helpProvider1.SetShowHelp(this.btnmethod, ((bool)(resources.GetObject("btnmethod.ShowHelp"))));
            this.btnmethod.UseVisualStyleBackColor = false;
            this.btnmethod.Click += new System.EventHandler(this.btnmethod_Click);
            this.btnmethod.MouseEnter += new System.EventHandler(this.btnmethod_MouseEnter);
            this.btnmethod.MouseLeave += new System.EventHandler(this.btnmethod_MouseLeave);
            this.btnmethod.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnmethod_MouseMove);
            // 
            // btntest
            // 
            resources.ApplyResources(this.btntest, "btntest");
            this.btntest.BackColor = System.Drawing.Color.Transparent;
            this.btntest.FlatAppearance.BorderSize = 0;
            this.btntest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btntest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.helpProvider1.SetHelpKeyword(this.btntest, resources.GetString("btntest.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.btntest, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("btntest.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.btntest, resources.GetString("btntest.HelpString"));
            this.btntest.Name = "btntest";
            this.helpProvider1.SetShowHelp(this.btntest, ((bool)(resources.GetObject("btntest.ShowHelp"))));
            this.btntest.UseVisualStyleBackColor = false;
            this.btntest.Click += new System.EventHandler(this.btntest_Click);
            this.btntest.MouseEnter += new System.EventHandler(this.btntest_MouseEnter);
            this.btntest.MouseLeave += new System.EventHandler(this.btntest_MouseLeave);
            this.btntest.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btntest_MouseMove);
            // 
            // panel6
            // 
            resources.ApplyResources(this.panel6, "panel6");
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.helpProvider1.SetHelpKeyword(this.panel6, resources.GetString("panel6.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.panel6, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("panel6.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.panel6, resources.GetString("panel6.HelpString"));
            this.panel6.Name = "panel6";
            this.helpProvider1.SetShowHelp(this.panel6, ((bool)(resources.GetObject("panel6.ShowHelp"))));
            // 
            // lbltip
            // 
            resources.ApplyResources(this.lbltip, "lbltip");
            this.lbltip.BackColor = System.Drawing.Color.Transparent;
            this.lbltip.ForeColor = System.Drawing.Color.Yellow;
            this.helpProvider1.SetHelpKeyword(this.lbltip, resources.GetString("lbltip.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.lbltip, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("lbltip.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.lbltip, resources.GetString("lbltip.HelpString"));
            this.lbltip.Name = "lbltip";
            this.helpProvider1.SetShowHelp(this.lbltip, ((bool)(resources.GetObject("lbltip.ShowHelp"))));
            // 
            // helpProvider1
            // 
            resources.ApplyResources(this.helpProvider1, "helpProvider1");
            // 
            // UserControlTop
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbltip);
            this.Controls.Add(this.pnlback);
            this.helpProvider1.SetHelpKeyword(this, resources.GetString("$this.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("$this.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this, resources.GetString("$this.HelpString"));
            this.Name = "UserControlTop";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            this.Load += new System.EventHandler(this.UserControlTop_Load);
            this.SizeChanged += new System.EventHandler(this.UserControlTop_SizeChanged);
            this.pnlback.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlback;
        private ButtonExNew btnuser;
        private ButtonExNew btnexit;
        private ButtonExNew btnhelp;
        private ButtonExNew btnmanage;
        private ButtonExNew btnreport;
        private ButtonExNew btnmethod;
        private ButtonExNew btntest;
        public WordArt wordArt1;
        public System.Windows.Forms.Panel paneldefine;
        public System.Windows.Forms.Panel panel6;
        public System.Windows.Forms.Panel paneltip;
        private System.Windows.Forms.Label lbltip;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}
