namespace TabHeaderDemo
{
    partial class UserControlMeter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlMeter));
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.jMeter8 = new TabHeaderDemo.JMeter();
            this.jMeter7 = new TabHeaderDemo.JMeter();
            this.jMeter6 = new TabHeaderDemo.JMeter();
            this.jMeter5 = new TabHeaderDemo.JMeter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.jMeter1 = new TabHeaderDemo.JMeter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.jMeter2 = new TabHeaderDemo.JMeter();
            this.jMeter3 = new TabHeaderDemo.JMeter();
            this.jMeter4 = new TabHeaderDemo.JMeter();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.jMeter8, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.jMeter7, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.jMeter6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.jMeter5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.jMeter3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.jMeter4, 0, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // jMeter8
            // 
            resources.ApplyResources(this.jMeter8, "jMeter8");
            this.jMeter8.BackColor = System.Drawing.Color.Transparent;
            this.jMeter8.Name = "jMeter8";
            // 
            // jMeter7
            // 
            resources.ApplyResources(this.jMeter7, "jMeter7");
            this.jMeter7.BackColor = System.Drawing.Color.Transparent;
            this.jMeter7.Name = "jMeter7";
            // 
            // jMeter6
            // 
            resources.ApplyResources(this.jMeter6, "jMeter6");
            this.jMeter6.BackColor = System.Drawing.Color.Transparent;
            this.jMeter6.Name = "jMeter6";
            // 
            // jMeter5
            // 
            resources.ApplyResources(this.jMeter5, "jMeter5");
            this.jMeter5.BackColor = System.Drawing.Color.Transparent;
            this.jMeter5.Name = "jMeter5";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.jMeter1);
            this.panel1.Name = "panel1";
            // 
            // jMeter1
            // 
            resources.ApplyResources(this.jMeter1, "jMeter1");
            this.jMeter1.BackColor = System.Drawing.Color.Transparent;
            this.jMeter1.Name = "jMeter1";
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Controls.Add(this.jMeter2);
            this.panel3.Name = "panel3";
            // 
            // jMeter2
            // 
            resources.ApplyResources(this.jMeter2, "jMeter2");
            this.jMeter2.BackColor = System.Drawing.Color.Transparent;
            this.jMeter2.Name = "jMeter2";
            // 
            // jMeter3
            // 
            resources.ApplyResources(this.jMeter3, "jMeter3");
            this.jMeter3.BackColor = System.Drawing.Color.Transparent;
            this.jMeter3.Name = "jMeter3";
            // 
            // jMeter4
            // 
            resources.ApplyResources(this.jMeter4, "jMeter4");
            this.jMeter4.BackColor = System.Drawing.Color.Transparent;
            this.jMeter4.Name = "jMeter4";
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // UserControlMeter
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Name = "UserControlMeter";
            this.Load += new System.EventHandler(this.UserControlMeter_Load);
            this.SizeChanged += new System.EventHandler(this.UserControlMeter_SizeChanged);
            this.Resize += new System.EventHandler(this.UserControlMeter_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private JMeter jMeter1;
        private System.Windows.Forms.Timer timer1;
        private JMeter jMeter2;
        private JMeter jMeter3;
        private JMeter jMeter4;
        private JMeter jMeter8;
        private JMeter jMeter7;
        private JMeter jMeter6;
        private JMeter jMeter5;
    }
}
