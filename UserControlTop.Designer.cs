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
            this.btnuser = new TabHeaderDemo.ButtonExNew(this.components);
            this.btnexit = new TabHeaderDemo.ButtonExNew(this.components);
            this.btnhelp = new TabHeaderDemo.ButtonExNew(this.components);
            this.btnmanage = new TabHeaderDemo.ButtonExNew(this.components);
            this.btnreport = new TabHeaderDemo.ButtonExNew(this.components);
            this.btnmethod = new TabHeaderDemo.ButtonExNew(this.components);
            this.btntest = new TabHeaderDemo.ButtonExNew(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pnlback.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlback
            // 
            this.pnlback.BackColor = System.Drawing.Color.White;
            this.pnlback.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlback.Controls.Add(this.btnuser);
            this.pnlback.Controls.Add(this.btnexit);
            this.pnlback.Controls.Add(this.btnhelp);
            this.pnlback.Controls.Add(this.btnmanage);
            this.pnlback.Controls.Add(this.btnreport);
            this.pnlback.Controls.Add(this.btnmethod);
            this.pnlback.Controls.Add(this.btntest);
            this.pnlback.Controls.Add(this.panel5);
            this.pnlback.Controls.Add(this.panel6);
            this.pnlback.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlback.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlback.ForeColor = System.Drawing.Color.White;
            this.pnlback.Location = new System.Drawing.Point(0, 0);
            this.pnlback.Name = "pnlback";
            this.pnlback.Size = new System.Drawing.Size(1026, 553);
            this.pnlback.TabIndex = 34;
            this.pnlback.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlback_Paint);
            this.pnlback.Resize += new System.EventHandler(this.pnlback_Resize);
            // 
            // btnuser
            // 
            this.btnuser.BackColor = System.Drawing.Color.Transparent;
            this.btnuser.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnuser.FlatAppearance.BorderSize = 0;
            this.btnuser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnuser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnuser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnuser.Image = ((System.Drawing.Image)(resources.GetObject("btnuser.Image")));
            this.btnuser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnuser.Location = new System.Drawing.Point(488, 326);
            this.btnuser.Name = "btnuser";
            this.btnuser.Size = new System.Drawing.Size(122, 68);
            this.btnuser.TabIndex = 7;
            this.btnuser.Text = "用户";
            this.btnuser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnuser.UseVisualStyleBackColor = false;
            this.btnuser.Click += new System.EventHandler(this.btnuser_Click);
            // 
            // btnexit
            // 
            this.btnexit.BackColor = System.Drawing.Color.Transparent;
            this.btnexit.FlatAppearance.BorderSize = 0;
            this.btnexit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnexit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexit.Image = ((System.Drawing.Image)(resources.GetObject("btnexit.Image")));
            this.btnexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnexit.Location = new System.Drawing.Point(454, 493);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(136, 68);
            this.btnexit.TabIndex = 6;
            this.btnexit.Text = "退出";
            this.btnexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexit.UseVisualStyleBackColor = false;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnhelp
            // 
            this.btnhelp.BackColor = System.Drawing.Color.Transparent;
            this.btnhelp.FlatAppearance.BorderSize = 0;
            this.btnhelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnhelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnhelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnhelp.Image = ((System.Drawing.Image)(resources.GetObject("btnhelp.Image")));
            this.btnhelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnhelp.Location = new System.Drawing.Point(468, 410);
            this.btnhelp.Name = "btnhelp";
            this.btnhelp.Size = new System.Drawing.Size(122, 68);
            this.btnhelp.TabIndex = 5;
            this.btnhelp.Text = "帮助";
            this.btnhelp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnhelp.UseVisualStyleBackColor = false;
            this.btnhelp.Click += new System.EventHandler(this.btnhelp_Click);
            // 
            // btnmanage
            // 
            this.btnmanage.BackColor = System.Drawing.Color.Transparent;
            this.btnmanage.FlatAppearance.BorderSize = 0;
            this.btnmanage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnmanage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnmanage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmanage.Image = ((System.Drawing.Image)(resources.GetObject("btnmanage.Image")));
            this.btnmanage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnmanage.Location = new System.Drawing.Point(534, 241);
            this.btnmanage.Name = "btnmanage";
            this.btnmanage.Size = new System.Drawing.Size(130, 68);
            this.btnmanage.TabIndex = 4;
            this.btnmanage.Text = "管理器";
            this.btnmanage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnmanage.UseVisualStyleBackColor = false;
            this.btnmanage.Click += new System.EventHandler(this.btnmanage_Click);
            // 
            // btnreport
            // 
            this.btnreport.BackColor = System.Drawing.Color.Transparent;
            this.btnreport.FlatAppearance.BorderSize = 0;
            this.btnreport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnreport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnreport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreport.Image = ((System.Drawing.Image)(resources.GetObject("btnreport.Image")));
            this.btnreport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnreport.Location = new System.Drawing.Point(590, 164);
            this.btnreport.Name = "btnreport";
            this.btnreport.Size = new System.Drawing.Size(125, 68);
            this.btnreport.TabIndex = 3;
            this.btnreport.Text = "报告";
            this.btnreport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnreport.UseVisualStyleBackColor = false;
            this.btnreport.Click += new System.EventHandler(this.btnreport_Click);
            // 
            // btnmethod
            // 
            this.btnmethod.BackColor = System.Drawing.Color.Transparent;
            this.btnmethod.FlatAppearance.BorderSize = 0;
            this.btnmethod.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnmethod.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnmethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmethod.Image = ((System.Drawing.Image)(resources.GetObject("btnmethod.Image")));
            this.btnmethod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnmethod.Location = new System.Drawing.Point(671, 90);
            this.btnmethod.Name = "btnmethod";
            this.btnmethod.Size = new System.Drawing.Size(122, 68);
            this.btnmethod.TabIndex = 2;
            this.btnmethod.Text = "方法";
            this.btnmethod.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnmethod.UseVisualStyleBackColor = false;
            this.btnmethod.Click += new System.EventHandler(this.btnmethod_Click);
            // 
            // btntest
            // 
            this.btntest.BackColor = System.Drawing.Color.Transparent;
            this.btntest.FlatAppearance.BorderSize = 0;
            this.btntest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btntest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btntest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntest.Image = ((System.Drawing.Image)(resources.GetObject("btntest.Image")));
            this.btntest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btntest.Location = new System.Drawing.Point(775, 25);
            this.btntest.Name = "btntest";
            this.btntest.Size = new System.Drawing.Size(123, 68);
            this.btntest.TabIndex = 1;
            this.btntest.Text = "测试";
            this.btntest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btntest.UseVisualStyleBackColor = false;
            this.btntest.Click += new System.EventHandler(this.btntest_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel5.BackgroundImage")));
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Location = new System.Drawing.Point(74, 549);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(337, 102);
            this.panel5.TabIndex = 21;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel6.BackgroundImage")));
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Location = new System.Drawing.Point(63, 71);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(315, 264);
            this.panel6.TabIndex = 22;
            // 
            // UserControlTop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlback);
            this.Name = "UserControlTop";
            this.Size = new System.Drawing.Size(1026, 553);
            this.pnlback.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
    }
}
