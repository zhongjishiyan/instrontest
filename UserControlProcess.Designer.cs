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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlProcess));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listViewPro1 = new TabHeaderDemo.SControls.ListViewPro();
            timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.listViewPro1);
            this.panel1.Name = "panel1";
            // 
            // listViewPro1
            // 
            resources.ApplyResources(this.listViewPro1, "listViewPro1");
            this.listViewPro1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewPro1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewPro1.Icon = null;
            this.listViewPro1.IsDrawGridLines = false;
            this.listViewPro1.IsDrawIcon = false;
            this.listViewPro1.Name = "listViewPro1";
            this.listViewPro1.OwnerDraw = true;
            this.listViewPro1.RowHeight = 25;
            this.listViewPro1.Scrollable = false;
            this.listViewPro1.UseCompatibleStateImageBehavior = false;
            this.listViewPro1.View = System.Windows.Forms.View.Details;
            // 
            // UserControlProcess
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "UserControlProcess";
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
