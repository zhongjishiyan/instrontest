using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppleLabApplication;
using ClsStaticStation;

using System.Reflection;


namespace TabHeaderDemo
{
    public partial class UserControlTop : UserBase
    {
        
       
        private double [] px;
        private int[] py;
        public UserControlTop()
        {
            InitializeComponent();
           
            
            px = new double [8];
            py = new int[8];

            px[0] = 775;
            px[1] = 671;
            px[2] = 590;
            px[3] = 534;
            px[4] = 488;
            px[5] = 468;
            px[6] = 454;

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲

            string chmpath = Application.StartupPath + "help.chm";
            helpProvider1.HelpNamespace = chmpath;


        }

        private void pnlback_Paint(object sender, PaintEventArgs e)
        {
            Pen myPen;

            Rectangle myRectangle;


            try

            {

                if (Screen.PrimaryScreen.Bounds.Width == 1366)
                {
                    myPen = new Pen(Color.SteelBlue, 3);//实例化Pen类
                    myRectangle = new Rectangle(pnlback.Width / 3+60, -60, pnlback.Width, pnlback.Height * 2);//定义一个Rectangle结构
                    e.Graphics.DrawArc(myPen, myRectangle, 170, 90);//绘制圆弧


                    e.Graphics.FillEllipse(Brushes.SteelBlue, myRectangle);

                    lbltip.BackColor = Color.SteelBlue;

                    // lbltip.BackColor = SystemColors.MenuHighlight;

                    myPen = new Pen(Color.CornflowerBlue, 3);//实例化Pen类
                    myRectangle = new Rectangle(pnlback.Width / 3+60 - 1, -61, pnlback.Width, pnlback.Height * 2);//定义一个Rectangle结构


                    e.Graphics.DrawArc(myPen, myRectangle, 0, 360);//绘制圆弧

                    e.Graphics.DrawLine(myPen, (pnlback.Width / 3+60) * 2 - 3, 1, pnlback.Width - 1, 1);
                    myPen = new Pen(Color.LightGray, 3);//实例化Pen类
                    myRectangle = new Rectangle(pnlback.Width / 3+60- 3, -63, pnlback.Width, pnlback.Height * 2);//定义一个Rectangle结构
                    e.Graphics.DrawArc(myPen, myRectangle, 0, 360);//绘制圆弧
                }
                else
                {
                    myPen = new Pen(Color.SteelBlue, 3);//实例化Pen类
                    myRectangle = new Rectangle(pnlback.Width / 3, -50, pnlback.Width, pnlback.Height * 2);//定义一个Rectangle结构
                    e.Graphics.DrawArc(myPen, myRectangle, 180, 90);//绘制圆弧


                    e.Graphics.FillEllipse(Brushes.SteelBlue, myRectangle);

                    lbltip.BackColor = Color.SteelBlue;

                    // lbltip.BackColor = SystemColors.MenuHighlight;

                    myPen = new Pen(Color.CornflowerBlue, 3);//实例化Pen类
                    myRectangle = new Rectangle(pnlback.Width / 3 - 1, -51, pnlback.Width, pnlback.Height * 2);//定义一个Rectangle结构


                    e.Graphics.DrawArc(myPen, myRectangle, 0, 360);//绘制圆弧

                    e.Graphics.DrawLine(myPen, pnlback.Width / 3 * 2 - 3, 1, pnlback.Width - 1, 1);
                    myPen = new Pen(Color.LightGray, 3);//实例化Pen类
                    myRectangle = new Rectangle(pnlback.Width / 3 - 3, -53, pnlback.Width, pnlback.Height * 2);//定义一个Rectangle结构
                    e.Graphics.DrawArc(myPen, myRectangle, 0, 360);//绘制圆弧
                }
            }

            catch
            {

            }
           
        
           
        }

        public void btntest_Click(object sender, EventArgs e)
        {
            ClsStaticStation.m_Global.mycls.initchannel();


            TabControl b = ((TabControl)Application.OpenForms["FormMainLab"].Controls["tabcontrol1"]);
            ((SplitContainer)b.TabPages[1].Controls[0]).Panel2Collapsed = false;


            double t = System.Environment.TickCount;
         

            

            while (System.Environment.TickCount - t <= 500)
            {
                Application.DoEvents();
            }
            UserControlMain c = GlobeVal.FormmainLab.umain;

            if (GlobeVal.mysys.machinekind == 3)
            {
                GlobeVal.FormmainLab.UserControl东光1.Init();
            }

            if(GlobeVal.FormmainLab.UserControl轴向1 !=null)
            {
                
                GlobeVal.FormmainLab.UserControl轴向1.init();
            }

            if(GlobeVal.FormmainLab.UserControl刚度双轴1 !=null)
            {
                GlobeVal.FormmainLab.UserControl刚度双轴1.init();
            }
            c.OpenTest();
            
            b.SelectedIndex = 1;

        }

        private void btnhelp_Click(object sender, EventArgs e)
        {
            String  s = Application.StartupPath;
            if (s.Contains("#") == true)
            {
                
                MessageBox.Show("软件目录中包含#字符，不能显示帮助");

            }
            else
            {
                if (System.IO.File.Exists(Application.StartupPath + @"\help.chm") == true)
                {

                    Help.ShowHelp(this, Application.StartupPath + @"\help.chm");//打开chm文件
                }
                else
                {
                    if (GlobeVal.mysys.language == 0)
                    {
                        MessageBox.Show("帮助文件不存在");
                    }
                    else
                    {
                        MessageBox.Show("The help files no longer exists");
                    }
                }
            }
        }

        private void btnreport_Click(object sender, EventArgs e)
        {


            if (CComLibrary.GlobeVal.filesave == null)
            {
                if (GlobeVal.mysys.language == 0)
                {
                    MessageBox.Show("请先读取试验方法");
                }
                else
                {
                    MessageBox.Show("Please read the test method first.");
                }
                return;
            }
            if (GlobeVal.mysys.safe == true)
            {
                if (GlobeVal.mysys.AppUserLevel < 1)
                {
                    if (GlobeVal.mysys.language == 0)
                    {
                        MessageBox.Show("您的当前权限不够，请使用试验经理或管理员权限登录");
                    }
                    else
                    {
                        MessageBox.Show("Insufficient permissio to login system.");
                    }
                    return;
                }
            }

            TabControl b = ((TabControl)Application.OpenForms["FormMainLab"].Controls["tabcontrol1"]);
            UserControlMain c = GlobeVal.FormmainLab.umain;
            ((SplitContainer)b.TabPages[1].Controls[0]).Panel2Collapsed =true  ;
            c.OpenReport();
            b.SelectedIndex = 1;
        }

        private void pnlback_Resize(object sender, EventArgs e)
        {
            btntest.Left = Convert.ToInt16 ( px[0] / 1366 * pnlback.Width )+30;
            btnmethod.Left = Convert.ToInt16(px[1] / 1366 * pnlback.Width)+30;
            btnreport.Left = Convert.ToInt16(px[2] / 1366 * pnlback.Width)+30;
            btnmanage.Left = Convert.ToInt16(px[3] / 1366 * pnlback.Width)+30;
            btnuser.Left = Convert.ToInt16(px[4] / 1366 * pnlback.Width)+30;
            btnhelp.Left = Convert.ToInt16(px[5] / 1366 * pnlback.Width)+30;
            btnexit.Left = Convert.ToInt16(px[6] / 1366 * pnlback.Width)+30;

            wordArt1.Top = pnlback.Height - wordArt1.Height - 30;

            lbltip.Left = btntest.Left;
         
            paneltip.Left = btntest.Left;
            paneltip.Width = pnlback.Width -paneltip.Left - 100;
            paneltip.Height = pnlback.Height - paneltip.Top - 50;
        }

        private void btnmanage_Click(object sender, EventArgs e)
        {
            if (GlobeVal.mysys.safe == true)
            {
                if (GlobeVal.mysys.AppUserLevel < 2)
                {
                    if (GlobeVal.mysys.language == 0)
                    {
                        MessageBox.Show("您的当前权限不够，请使用管理员权限登录");
                    }
                    else
                    {
                        MessageBox.Show("Insufficient permissio to login system.");
                    }
                    return;
                }
            }

            TabControl b = ((TabControl)Application.OpenForms["FormMainLab"].Controls["tabcontrol1"]);
            UserControlMain c = GlobeVal.FormmainLab.umain;
            ((SplitContainer)b.TabPages[1].Controls[0]).Panel2Collapsed  = true;
            c.OpenAdmin();
            b.SelectedIndex = 1;

        }

        private void btnmethod_Click(object sender, EventArgs e)
        {
          
            if (GlobeVal.mysys.safe == true)
            {


                if (GlobeVal.mysys.AppUserLevel < 1)
                {
                    if (GlobeVal.mysys.language == 0)
                    {
                        MessageBox.Show("您的当前权限不够，请使用试验经理或管理员权限登录");
                    }
                    else
                    {
                        MessageBox.Show("Insufficient permissio to login system.");

                     }
                    return;
                }
            }
            TabControl b = ((TabControl)Application.OpenForms["FormMainLab"].Controls["tabcontrol1"]);
            ((SplitContainer)b.TabPages[1].Controls[0]).Panel2Collapsed =true;

            UserControlMain c = GlobeVal.FormmainLab.umain; ;
            c.OpenMethod();
            
            b.SelectedIndex = 1;
            
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        private void btnuser_Click(object sender, EventArgs e)
        {
            if (GlobeVal.mysys.safe == true)
            {
                Frm.Form登录 f = new TabHeaderDemo.Frm.Form登录();
                f.result = false;

                f.ShowDialog();


                f.Close();
            }
            else
            {
                if (GlobeVal.mysys.language == 0)
                {
                    MessageBox.Show("安全策略没有启用");
                }
                else
                {
                    MessageBox.Show("security password policy rules are not enforced");
                }
            }
        }

        private void btntest_MouseMove(object sender, MouseEventArgs e)
        {
         
            
            
           
        }

        private void btntest_MouseLeave(object sender, EventArgs e)
        {
            paneltip.Visible = false;
            lbltip.Text = "";
        }

        private void btntest_MouseEnter(object sender, EventArgs e)
        {

            if (GlobeVal.mysys.language == 0)
            {
                lbltip.Text = "开始试验";
            }
            else

            {
                lbltip.Text = "Run tests on specimens";
            }
            paneltip.BackgroundImage = TabHeaderDemo.Properties.Resources.试验提示1;
            paneltip.Visible = true;
        }

        private void btnmethod_MouseEnter(object sender, EventArgs e)
        {
            if (GlobeVal.mysys.language == 0)
            {
                lbltip.Text = "创建或编辑现有试验方法";
            }
            else
            {
                lbltip.Text = " Create a new or edit an existing test method";
            }
            paneltip.BackgroundImage = TabHeaderDemo.Properties.Resources.方法提示1;
            paneltip.Visible = true;
        }

        private void btnreport_MouseEnter(object sender, EventArgs e)
        {
            if (GlobeVal.mysys.language == 0)
            {
                lbltip.Text = "创建或编辑现有试验报告模板";
            }
            else
            {
                lbltip.Text = "Create a new or edit an existing test Report template";
            }
            paneltip.BackgroundImage = TabHeaderDemo.Properties.Resources.报告提示1;
            paneltip.Visible = true; 
        }

        private void btnmanage_MouseEnter(object sender, EventArgs e)
        {

            if (GlobeVal.mysys.language == 0)
            {
                lbltip.Text = "配置系统";
            }
            else
            {
                lbltip.Text = "Change the configuration of the testing system";
            }

            paneltip.BackgroundImage = TabHeaderDemo.Properties.Resources.管理器提示1;
            paneltip.Visible = true;
        }

        private void btnmethod_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void btnmethod_MouseLeave(object sender, EventArgs e)
        {
            paneltip.Visible = false;
            lbltip.Text = "";
        }

        private void btnreport_MouseLeave(object sender, EventArgs e)
        {
            paneltip.Visible = false;
            lbltip.Text = "";
        }

        private void btnmanage_MouseLeave(object sender, EventArgs e)
        {
            paneltip.Visible = false;
            lbltip.Text = "";
        }

        private void btnuser_MouseEnter(object sender, EventArgs e)
        {
            if (GlobeVal.mysys.language == 0)
            {
                lbltip.Text = "设置用户权限";
            }
            else
            {
                lbltip.Text = "set the permission for users";
            }
        }

        private void btnhelp_MouseEnter(object sender, EventArgs e)
        {
            if (GlobeVal.mysys.language == 0)
            {
                lbltip.Text = "显示系统帮助文件";
            }
            else
            {
                lbltip.Text = "Open the Help system";
            }
        }

        private void btnexit_MouseEnter(object sender, EventArgs e)
        {
            if (GlobeVal.mysys.language == 0)
            {
                lbltip.Text = "退出试验软件";
            }
            else
            {
                lbltip.Text = "Exit the software";
            }
        }

        private void btnuser_MouseLeave(object sender, EventArgs e)
        {
            lbltip.Text = "";
        }

        private void btnhelp_MouseLeave(object sender, EventArgs e)
        {
            lbltip.Text = "";
        }

        private void btnexit_MouseLeave(object sender, EventArgs e)
        {
            lbltip.Text = "";
        }

        private void UserControlTop_Load(object sender, EventArgs e)
        {
          

        }

        private void UserControlTop_SizeChanged(object sender, EventArgs e)
        {
            wordArt1.Width = btnhelp.Left - 50 - wordArt1.Left;
        }
    }
    public class AssemblyHelper
    {
        #region 常量
        /// <summary>
        /// 程序集名称
        /// </summary>
        private static string CurrentAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
        #endregion

        #region  变量
        /// <summary>
        /// 当前程序集
        /// </summary>
        private static Assembly CurrentAssembly = Assembly.GetExecutingAssembly();
        #endregion

        #region 方法
        /// <summary>
        /// 在嵌入的资源文件中查找相应的图片
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Image GetImage(string name)
        {
            Image img = null;
            try
            {
                if (!string.IsNullOrEmpty(name))
                {
                    StringBuilder sb = new StringBuilder();
                    if (name[0] != '.')
                    {
                        sb.Append(AssemblyHelper.CurrentAssemblyName + "." + name);
                    }
                    else
                    {
                        sb.Append(AssemblyHelper.CurrentAssemblyName + name);
                    }
                    using (System.IO.Stream stream = CurrentAssembly.GetManifestResourceStream(sb.ToString()))
                    {
                        if (stream != null)
                        {
                            img = Image.FromStream(stream);
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return img;
        }
        #endregion
    }
    
}
