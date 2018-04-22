namespace TabHeaderDemo
{
    partial class UserControlProcess
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Timer timer1;
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listViewPro1 = new TabHeaderDemo.SControls.ListViewPro();
            timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "过程指示";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.listViewPro1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 343);
            this.panel1.TabIndex = 6;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // listViewPro1
            // 
            this.listViewPro1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewPro1.Dock = System.Windows.Forms.DockStyle.Left;
            this.listViewPro1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewPro1.Icon = null;
            this.listViewPro1.IsDrawGridLines = false;
            this.listViewPro1.IsDrawIcon = false;
            this.listViewPro1.Location = new System.Drawing.Point(0, 0);
            this.listViewPro1.Name = "listViewPro1";
            this.listViewPro1.OwnerDraw = true;
            this.listViewPro1.RowHeight = 25;
            this.listViewPro1.Scrollable = false;
            this.listViewPro1.Size = new System.Drawing.Size(680, 326);
            this.listViewPro1.TabIndex = 0;
            this.listViewPro1.UseCompatibleStateImageBehavior = false;
            this.listViewPro1.View = System.Windows.Forms.View.Details;
            // 
            // UserControlProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "UserControlProcess";
            this.Size = new System.Drawing.Size(362, 361);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserControlProcess_Paint);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private SControls.ListViewPro listViewPro1;
    }
}
