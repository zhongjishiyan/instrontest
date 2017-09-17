using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace TabHeaderDemo
{
    public partial class UserControlMain : UserControl
    {
        public  int btnindex = 0;
        ReportDesigner.ToolBox toolBox1;

        private int  mtestindex=0;
        private UserControlOpenMethod usercontrolopenmetho1;
        private UserControlMethod usercontrolmethod1;
        private UserControlPretest usercontrolpretest1;
        private UserControlTest userControlTest1;
        public UserReport  userreport1;
        private UserManage usermanage1;
        public List<Button> mlist;

        private Point[] buttonxy;
 

        private void button4_Click(object sender, EventArgs e)
        {

        }

       
     

        private void button3_Click(object sender, EventArgs e)
        {
            

            

        }

        private void button5_Click(object sender, EventArgs e)
        {
          
          
        }
        public UserControlMain()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲

            TableLayoutPanel p;

            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i] is TableLayoutPanel)
                {
                    p = this.Controls[i] as TableLayoutPanel;
                    p.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(p, true, null);

                }
            }
            mlist = new List<Button>();
            
            userreport1 = new UserReport();
            usermanage1 = new UserManage();
            usercontrolmethod1 = new UserControlMethod();
            usercontrolopenmetho1 = new UserControlOpenMethod();
            usercontrolpretest1 = new UserControlPretest();
            userControlTest1 = new UserControlTest();

            usermanage1.Dock = DockStyle.Fill;
            userreport1.Dock = DockStyle.Fill;
            usercontrolmethod1.Dock = DockStyle.Fill;
            usercontrolopenmetho1.Dock = DockStyle.Fill;
            usercontrolpretest1.Dock = DockStyle.Fill;
            userControlTest1.Dock = DockStyle.Fill;
            


            tabPage1.Controls.Add(usercontrolopenmetho1);
            tabPage2.Controls.Add(usercontrolmethod1);
            tabPage3.Controls.Add(usercontrolpretest1);
            tabPage4.Controls.Add(userControlTest1);
            tabPage5.Controls.Add(userreport1);
            tabPage6.Controls.Add(usermanage1);

            


            GlobeVal.backpanel = this.panelback;
            GlobeVal.userControltest1 = userControlTest1;
            GlobeVal.UserControlMain1 = this;
            GlobeVal.userControlpretest1 = usercontrolpretest1;
            GlobeVal.userControlmethod1 = usercontrolmethod1;


            GlobeVal.mbtntest = this.btnmtest;
            mlist.Add(btnmtest);
            mlist.Add(btnmmethod);
            mlist.Add(btnmreport);
            mlist.Add(btnmmanage);

            buttonxy = new Point[4];

            buttonxy[0].X = 161;
            buttonxy[0].Y = 9;

            buttonxy[1].X = 322;
            buttonxy[1].Y = 9;

            buttonxy[2].X = 483;
            buttonxy[2].Y = 9;

            buttonxy[3].X = 644;
            buttonxy[3].Y = 9;

            btnmtest.Left = buttonxy[0].X;
            btnmtest.Top = buttonxy[0].Y;

            btnmmethod.Left = buttonxy[1].X;
            btnmmethod.Top = buttonxy[1].Y;

            btnmreport.Left = buttonxy[2].X;
            btnmreport.Top = buttonxy[2].Y;

            btnmmanage.Left = buttonxy[3].X;
            btnmmanage.Top  = buttonxy[3].Y;


        }

        public void MethodNext(string filename)
        {
           
            btnmtest.Visible = false;
            btnmmethod.Visible = true;
            btnmreport.Visible = true;
            btnmmanage.Visible = true;
            btnmmethod.Left = buttonxy[0].X;
            btnmmethod.Top = buttonxy[0].Y;
            btnmreport.Left = buttonxy[1].X;
            btnmreport.Top = buttonxy[1].Y;
            btnmmanage.Left = buttonxy[2].X;
            btnmmanage.Top = buttonxy[2].Y;

            

            btnmtest.ForeColor = Color.White;
            btnmmethod.ForeColor = Color.Yellow;
            btnmreport.ForeColor = Color.White;
            btnmmanage.ForeColor = Color.White;
            
            tabControl1.SelectedIndex = 1;

            this.usercontrolmethod1.OpenTheMethod(filename);
            
            

        }

        public void OpenMethod()
        {

           
                btnmtest.Visible = false;
                btnmmethod.Visible = true;
                btnmreport.Visible = false;
                btnmmanage.Visible = false;

                btnmmethod.Left = buttonxy[0].X;
                btnmmethod.Top = buttonxy[0].Y;


                btnmtest.ForeColor = Color.White;
                btnmmethod.ForeColor = Color.Yellow;
                btnmreport.ForeColor = Color.White;
                btnmmanage.ForeColor = Color.White;


                tabControl1.SelectedIndex = 0;

               
        }

        public void OpenReport()
        {
            btnmtest.Visible = false;
            btnmmethod.Visible = false ;
            btnmreport.Visible = true;
            btnmmanage.Visible = false;

            btnmreport.Left = buttonxy[0].X;
            btnmreport.Top = buttonxy[0].Y;


            btnmtest.ForeColor = Color.White;
            btnmmethod.ForeColor = Color.White;
            btnmreport.ForeColor = Color.Yellow;
            btnmmanage.ForeColor = Color.White;

           
            tabControl1.SelectedIndex = 4;
            
        }

        public void OpenAdmin()
        {
            btnmtest.Visible = false;
            btnmmethod.Visible = false;
            btnmreport.Visible = false;
            btnmmanage.Visible = true;

            btnmmanage.Left = buttonxy[0].X;
            btnmmanage.Top = buttonxy[0].Y;


            btnmtest.ForeColor = Color.White;
            btnmmethod.ForeColor = Color.White;
            btnmreport.ForeColor = Color.White;
            btnmmanage.ForeColor = Color.Yellow;

            
            tabControl1.SelectedIndex = 5;

        }

        public void OpenTest()
        {
            btnmtest.Visible = true;
            btnmmethod.Visible = false ;
            btnmreport.Visible = false ;
            btnmmanage.Visible = false ;

           


            btnmtest.Left = buttonxy[0].X;
            btnmtest.Top = buttonxy[0].Y;

            btnmmethod.Left = buttonxy[1].X;
            btnmmethod.Top = buttonxy[1].Y;

            btnmreport.Left = buttonxy[2].X;
            btnmreport.Top = buttonxy[2].Y;

            btnmmanage.Left = buttonxy[3].X;
            btnmmanage.Top = buttonxy[3].Y;


            btnmtest.ForeColor = Color.White;

            
                btnmtest.ForeColor = Color.Yellow;
                btnmmethod.ForeColor = Color.White;
                btnmreport.ForeColor = Color.White;
                btnmmanage.ForeColor = Color.White;

                tabControl1.SelectedIndex = 2;
                
               
                usercontrolpretest1.LoadResentFile();

            
           

        }

        private void UserControl2_Load(object sender, EventArgs e)
        {

           
            
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelback_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnmain_Click(object sender, EventArgs e)
        {
            ((TabControl)Application.OpenForms["FormMainLab"].Controls["tabcontrol1"]).SelectedIndex = 0;
        }

        private void btnmtest_Click(object sender, EventArgs e)
        {
            if (btnmtest.ForeColor == Color.White)
            {
                btnmtest.ForeColor = Color.Yellow;
                btnmmethod.ForeColor = Color.White;
                btnmreport.ForeColor = Color.White;
                btnmmanage.ForeColor = Color.White;


                tabControl1.SelectedIndex =3;

                

               
            }
        }

        private void btnmmethod_Click(object sender, EventArgs e)
        {
            if (btnmmethod.ForeColor == Color.White)
            {
                btnmtest.ForeColor = Color.White;
                btnmmethod.ForeColor = Color.Yellow;
                btnmreport.ForeColor = Color.White;
                btnmmanage.ForeColor = Color.White;

                tabControl1.SelectedIndex = 1;

                
            }
        }

        private void btnmreport_Click(object sender, EventArgs e)
        {
            if (this.btnmreport.ForeColor == Color.White)
            {
                btnmtest.ForeColor = Color.White;
                btnmmethod.ForeColor = Color.White;
                btnmreport.ForeColor = Color.Yellow;
                btnmmanage.ForeColor = Color.White;

                tabControl1.SelectedIndex = 4;

                
            }
        }

        private void btnmmanage_Click(object sender, EventArgs e)
        {
            if (this.btnmmanage.ForeColor == Color.White)
            {
                btnmtest.ForeColor = Color.White;
                btnmmethod.ForeColor = Color.White;
                btnmreport.ForeColor = Color.White;
                btnmmanage.ForeColor = Color.Yellow;
                tabControl1.SelectedIndex = 5;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void UserControlMain_Load(object sender, EventArgs e)
        {
            tabControl1.ItemSize = new Size(1, 1);
        }

        private void UserControlMain_SizeChanged(object sender, EventArgs e)
        {
            panelback.Top = panel1.Height  -8;
            panelback.Height = this.ClientSize.Height - panel1.Height+8;
            panelback.Left = 0;
            panelback.Width = this.ClientSize.Width;
            this.ResumeLayout();
           
        }

        private void UserControlMain_Resize(object sender, EventArgs e)
        {
            
            this.SuspendLayout();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
