using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using CustomControls.OS;
using CustomControls.Controls;
namespace TabHeaderDemo
{
    public partial class UserControlMethod : UserControl
    {
        

        private UserControl试样 UserControl试样1;
        private UserControl常规 UserControl常规1;
        private UserControl控制 UserControl控制1;
        private UserControl计算 UserControl计算1;
        private UserControl结果 UserControl结果1;
        private UserControl测试提示 UserControl测试提示1;
        private UserControl控制台 UserControl控制台1;
        private UserControl额外显示 UserControl额外显示1;
        private UserControl曲线 UserControl曲线1;
        private UserControl曲线 UserControl曲线2;
        private UserControl原始数据 UserControl原始数据1;
        private UserControl文件设置 UserControl文件设置1;
        private UserControl缺省表格 UserControl缺省表格1; 
       

        private string mmethodfilename;
        private void drawFigure(PaintEventArgs e, PointF[] points)
        {
            GraphicsPath path = new GraphicsPath();


            Corners r = new Corners(points, 5);
            r.Execute(path);
            path.CloseFigure();
            Matrix matrix = new Matrix();
            matrix.Translate(3, 3);
            path.Transform(matrix);



            Color c = (imageList3.Images[0] as Bitmap).GetPixel(imageList3.Images[0].Width - 5, imageList3.Images[0].Height / 2);
            

           
            drawPath(e, path, c);

            path.Reset();
            r = new Corners(points, 5);
            r.Execute(path);
            path.CloseFigure();
            matrix = new Matrix();
            matrix.Translate(0, 0);
            path.Transform(matrix);

            c = (imageList3.Images[0] as Bitmap) .GetPixel(imageList3.Images[0].Width / 2, imageList3.Images[0].Height / 2);

            if (treeView1 == null)
            {
            }
            else
            {
                if (c.Name == "0")
                {
                }
                else
                {
                    treeView1.BackColor = c;
                }
            }

            panelbutton.BackColor = c;

          

            drawPath(e, path, c);
           
            path.Dispose();
        }

        private static void drawPath(PaintEventArgs e, GraphicsPath path, Color color)
        {
            LinearGradientBrush brush = new LinearGradientBrush(path.GetBounds(),
                color, color, LinearGradientMode.Horizontal);
            e.Graphics.FillPath(brush, path);
            Pen pen = new Pen(color, 1);
            e.Graphics.DrawPath(pen, path);

            brush.Dispose();
            pen.Dispose();
        }
        public UserControlMethod()
        {
            InitializeComponent();
            treeView1.mimagelist = imageList2;

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲

            this.tableLayoutPanel1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel1, true, null);
            this.tableLayoutPanel2.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel2, true, null);
            this.tableLayoutPanel3.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel3, true, null);


            UserControl试样1 = new UserControl试样();
            UserControl常规1 = new UserControl常规();
            UserControl控制1 = new UserControl控制();
            UserControl计算1 = new UserControl计算();
            UserControl结果1 = new UserControl结果();
            UserControl测试提示1 = new UserControl测试提示();
            UserControl控制台1 = new UserControl控制台();
            UserControl额外显示1 = new UserControl额外显示();
            UserControl曲线1 = new UserControl曲线();
            UserControl曲线2 = new UserControl曲线();
            UserControl原始数据1 = new UserControl原始数据();
            UserControl文件设置1 = new UserControl文件设置();
            UserControl缺省表格1 = new UserControl缺省表格();

            UserControl试样1.musercontrolmethod = this;
            UserControl常规1.musercontrolmethod = this;
            UserControl控制1.musercontrolmethod = this;
            UserControl计算1.musercontrolmethod = this;
            UserControl结果1.musercontrolmethod = this;
            UserControl测试提示1.musercontrolmethod = this;
            UserControl控制台1.musercontrolmethod = this;
            UserControl额外显示1.musercontrolmethod = this;
            UserControl曲线1.musercontrolmethod = this;
            UserControl曲线2.musercontrolmethod = this;
            UserControl原始数据1.musercontrolmethod = this;
            UserControl文件设置1.musercontrolmethod = this;
            UserControl缺省表格1.musercontrolmethod = this;

            UserControl常规1.Init(0);
            panelback.Visible = false;
            panelback.Controls.Clear();
            UserControl常规1.Dock = DockStyle.Fill;
            panelback.Controls.Add(UserControl常规1);
            panelback.Visible = true;
           
            
        }

        private void UserControl5_Paint(object sender, PaintEventArgs e)
        {

            if (this.DesignMode)
            {
                return;
            }
            GraphicsContainer containerState = e.Graphics.BeginContainer();
            tableLayoutPanel1.BackColor = Color.Transparent;
            


            e.Graphics.PageUnit = System.Drawing.GraphicsUnit.Pixel;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.Clear(Color.White);



            PointF[] roundedRectangle = new PointF[5];
            roundedRectangle[0].X = 1;
            roundedRectangle[0].Y = 0;
            roundedRectangle[1].X = this.Width - 2 - 3;
            roundedRectangle[1].Y = 0;
            roundedRectangle[2].X = this.Width - 2 - 3;
            roundedRectangle[2].Y = this.Height - 2 - 3;
            roundedRectangle[3].X = 1;
            roundedRectangle[3].Y = this.Height - 2 - 3;
            roundedRectangle[4].X = 1;
            roundedRectangle[4].Y = 0;
            drawFigure(e, roundedRectangle);

         

            e.Graphics.EndContainer(containerState);

            if (GlobeVal.UserControlMain1.btnmtest.Visible==true)
            {
                panelbutton.Visible = false;
            }
            else
            {
                panelbutton.Visible = true;
            }
        }

       

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes.Count == 0)
            {
               
            }
            else
            {
                treeView1.SelectedNode = e.Node.Nodes[0];
                
                methodon(e.Node.Nodes[0].Text,e.Node.Text);
            }
        }

        public void methodon(String t,String parent)
        {
            if (t == "方法")
            {

                UserControl常规1.Init(0);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl常规1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl常规1);
                panelback.Visible = true;
            }

            if (t == "样品")
            {

                UserControl常规1.Init(1);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl常规1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl常规1);
                panelback.Visible = true;
            }

            if (t == "基本布局")
            {

                UserControl常规1.Init(2);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl常规1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl常规1);
                panelback.Visible = true;
            }
            if (t == "高级布局")
            {

                UserControl常规1.Init(3);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl常规1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl常规1);
                panelback.Visible = true;
            }


            if (t == "尺寸")
            {

                UserControl试样1.Init(0);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl试样1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl试样1);
                panelback.Visible = true;

            }
            if (t == "数字输入")
            {

                UserControl试样1.Init(1);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl试样1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl试样1);
                panelback.Visible = true;

            }

            if (t == "文本输入")
            {

                UserControl试样1.Init(2);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl试样1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl试样1);
                panelback.Visible = true;

            }

            if (t == "选项输入")
            {

                UserControl试样1.Init(3);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl试样1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl试样1);
                panelback.Visible = true;

            }

            if (t == "测试")
            {
                UserControl控制1.Visible = false;
				if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 0)
				{
					UserControl控制1.Init(3);
				}
				else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 1)
				{
					
                    UserControl控制1.Init(6);
				}

				else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 2)
				{
					UserControl控制1.Init(7);
				}
                else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 3)
                {
                    UserControl控制1.Init(8);
                }
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl控制1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl控制1);
                panelback.Visible = true;
                UserControl控制1.Visible = true;
            }

            if (t == "测试前")
            {
               
                UserControl控制1.Init(2);
               
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl控制1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl控制1);
                panelback.Visible = true;
            }
            if (t == "测试结束")
            {
                UserControl控制1.Init(4);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl控制1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl控制1);
                panelback.Visible = true;
            }
            if (t == "数据采集")
            {
                UserControl控制1.Init(5);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl控制1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl控制1);
                panelback.Visible = true;
            }
            if (t == "应变")
            {
                UserControl控制1.Init(1);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl控制1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl控制1);
                panelback.Visible = true;
            }
            if (t == "试验选项")
            {
                UserControl控制1.Init(0);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl控制1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl控制1);
                panelback.Visible = true;
            }

            if (t == "设定")
            {
                UserControl计算1.Init();
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl计算1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl计算1);
                panelback.Visible = true;
            }

            if (t == "列")
            {
                if (parent == "结果1")
                {
                    UserControl结果1.resulttab = 0;
                }

                if (parent == "结果2")
                {
                    UserControl结果1.resulttab = 1;
                }
                UserControl结果1.Init(0);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl结果1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl结果1);
                panelback.Visible = true;
            }
            if (t == "统计")
            {
                if (parent == "结果1")
                {
                    UserControl结果1.resulttab = 0;
                }

                if (parent == "结果2")
                {
                    UserControl结果1.resulttab = 1;
                }
                UserControl结果1.Init(1);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl结果1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl结果1);
                panelback.Visible = true;
            }
            if (t == "格式")
            {
                if (parent == "结果1")
                {
                    UserControl结果1.resulttab = 0;
                }

                if (parent == "结果2")
                {
                    UserControl结果1.resulttab = 1;
                }
                UserControl结果1.Init(2);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl结果1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl结果1);
                panelback.Visible = true;
            }


            if (t == "提示顺序")
            {
                UserControl测试提示1.Init(0);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl测试提示1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl测试提示1);
                panelback.Visible = true;
            }
            if (t == "开始前")
            {
                UserControl测试提示1.Init(1);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl测试提示1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl测试提示1);
                panelback.Visible = true;
            }


            if (t == "试样试验前")
            {
                UserControl测试提示1.Init(2);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl测试提示1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl测试提示1);
                panelback.Visible = true;
            }

            if (t == "试验前")
            {
                UserControl测试提示1.Init(3);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl测试提示1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl测试提示1);
                panelback.Visible = true;
            }

            if (t == "计算前")
            {
                UserControl测试提示1.Init(4);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl测试提示1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl测试提示1);
                panelback.Visible = true;
            }
            if (t == "试样试验后")
            {
                UserControl测试提示1.Init(5);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl测试提示1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl测试提示1);
                panelback.Visible = true;
            }
            if (t == "结束前")
            {
                UserControl测试提示1.Init(6);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl测试提示1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl测试提示1);
                panelback.Visible = true;
            }
            if (t == "结束")
            {
                UserControl测试提示1.Init(7);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl测试提示1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl测试提示1);
                panelback.Visible = true;
            }

            if (t == "实时显示")
            {
                UserControl控制台1.Init(0);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl控制台1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl控制台1);
                panelback.Visible = true;
            }
            if (t == "按键")
            {
                UserControl控制台1.Init(1);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl控制台1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl控制台1);
                panelback.Visible = true;
            }
            if (t == "主机")
            {
                UserControl控制台1.Init(2);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl控制台1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl控制台1);
                panelback.Visible = true;
            }

            if (t == "电表设置")
            {

                UserControl额外显示1.Init(0);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl额外显示1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl额外显示1);
                panelback.Visible = true;
            }
            if (t == "操作输入")
            {

                UserControl额外显示1.Init(1);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl额外显示1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl额外显示1);
                panelback.Visible = true;
            }


            if (t == "类型")
            {
                if (parent == "曲线图1")
                {
                    UserControl曲线1.curvetab = 0;
                    UserControl曲线1.Init(0);
                    panelback.Visible = false;
                    panelback.Controls.Clear();
                    UserControl曲线1.Dock = DockStyle.Fill;
                    panelback.Controls.Add(UserControl曲线1);
                    panelback.Visible = true;
                }
                if (parent == "曲线图2")
                {
                    UserControl曲线2.curvetab = 1;
                    UserControl曲线2.Init(0);
                    panelback.Visible = false;
                    panelback.Controls.Clear();
                    UserControl曲线2.Dock = DockStyle.Fill;
                    panelback.Controls.Add(UserControl曲线2);
                    panelback.Visible = true;
                }
            }

            if (t == "X轴数据")
            {
                if (parent == "曲线图1")
                {
                    UserControl曲线1.Init(1);
                    panelback.Visible = false;
                    panelback.Controls.Clear();
                    UserControl曲线1.Dock = DockStyle.Fill;
                    panelback.Controls.Add(UserControl曲线1);
                    panelback.Visible = true;
                }
                if (parent == "曲线图2")
                {
                    UserControl曲线2.Init(1);
                    panelback.Visible = false;
                    panelback.Controls.Clear();
                    UserControl曲线2.Dock = DockStyle.Fill;
                    panelback.Controls.Add(UserControl曲线2);
                    panelback.Visible = true;
                }
            }
            if (t == "Y轴数据")
            {
                if (parent == "曲线图1")
                {
                    UserControl曲线1.Init(2);
                    panelback.Visible = false;
                    panelback.Controls.Clear();
                    UserControl曲线1.Dock = DockStyle.Fill;
                    panelback.Controls.Add(UserControl曲线1);
                    panelback.Visible = true;
                }
                if (parent == "曲线图2")
                {
                    UserControl曲线2.Init(2);
                    panelback.Visible = false;
                    panelback.Controls.Clear();
                    UserControl曲线2.Dock = DockStyle.Fill;
                    panelback.Controls.Add(UserControl曲线2);
                    panelback.Visible = true;
                }
            }

            if (t == "高级")
            {
                if (parent == "曲线图1")
                {
                    UserControl曲线1.Init(3);
                    panelback.Visible = false;
                    panelback.Controls.Clear();
                    UserControl曲线1.Dock = DockStyle.Fill;
                    panelback.Controls.Add(UserControl曲线1);
                    panelback.Visible = true;
                }
                if (parent == "曲线图2")
                {
                    UserControl曲线2.Init(3);
                    panelback.Visible = false;
                    panelback.Controls.Clear();
                    UserControl曲线2.Dock = DockStyle.Fill;
                    panelback.Controls.Add(UserControl曲线2);
                    panelback.Visible = true;
                }
            }

            if (t == "原始数据输出")
            {
                UserControl原始数据1.Init(0);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl原始数据1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl原始数据1);
                panelback.Visible = true;

            }

            if (t == "文档设置")
            {
                
                UserControl文件设置1.Init(0);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl文件设置1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl文件设置1);
                panelback.Visible = true;

            }

            if (t == "缺省表格")
            {
                UserControl缺省表格1.Init(0);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl缺省表格1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl缺省表格1);
                panelback.Visible = true;
            }


        }
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {


            if (e.Node.Parent ==null)
            {
                methodon(e.Node.Text, "");
            }
            else
            {
                methodon(e.Node.Text,e.Node.Parent.Text);
            }


        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
        }


        private void UserControlMethod_Load(object sender, EventArgs e)
        {
          

        }

        public void OpenTheMethodSilently(string fileName)
        {
            
                mmethodfilename = fileName;
                UserControl常规1.txtmethodname.Text = Path.GetFileNameWithoutExtension(fileName);
                UserControl常规1.txtmethodpath.Text = Path.GetDirectoryName(fileName);

                if (CComLibrary.GlobeVal.filesave == null)
                {
                    CComLibrary.GlobeVal.filesave = new CComLibrary.FileStruct();
                }
                CComLibrary.GlobeVal.filesave = CComLibrary.GlobeVal.filesave.DeSerializeNow(fileName);
                CComLibrary.GlobeVal.currentfilesavename = fileName;
                UserControl常规1.Open_method();
                UserControl试样1.Open_method();
                UserControl计算1.Open_method();
                this.treeView1.CollapseAll();
                this.treeView1.SelectedNode = this.treeView1.Nodes[0].Nodes[0];
                methodon(this.treeView1.Nodes[0].Nodes[0].Text, this.treeView1.Nodes[0].Text);

                CComLibrary.GlobeVal.InitUserCalcChannel();
            
            
        }


        public void OpenTheMethod(string fileName)
        {
            mmethodfilename = fileName; 
            UserControl常规1.txtmethodname.Text = Path.GetFileNameWithoutExtension(fileName);
            UserControl常规1.txtmethodpath.Text = Path.GetDirectoryName(fileName);

            GlobeVal.mmethodfilename = fileName;

            if (CComLibrary.GlobeVal.filesave == null)
            {
                CComLibrary.GlobeVal.filesave = new CComLibrary.FileStruct();
            }
            CComLibrary.GlobeVal.filesave = CComLibrary.GlobeVal.filesave.DeSerializeNow(fileName);

            GlobeVal.filesavecmp = CComLibrary.GlobeVal.filesave.DeSerializeNow(fileName); 


            CComLibrary.GlobeVal.currentfilesavename = fileName;
            UserControl常规1.Open_method();
            UserControl试样1.Open_method();
            UserControl计算1.Open_method();
            this.treeView1.CollapseAll();
            this.treeView1.SelectedNode = this.treeView1.Nodes[0].Nodes[0];
            methodon(this.treeView1.Nodes[0].Nodes[0].Text, this.treeView1.Nodes[0].Text);
            CComLibrary.GlobeVal.InitUserCalcChannel();
            
        }



        private void btnexopen_Click(object sender, EventArgs e)
        {
            CustomControls.MethodOpenFileDialog controlex = new CustomControls.MethodOpenFileDialog();
            controlex.StartLocation = AddonWindowLocation.Right;
            controlex.DefaultViewMode = FolderViewMode.Details;
            controlex.OpenDialog.InitialDirectory = System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\Method";
            controlex.OpenDialog.AddExtension = true;
            controlex.OpenDialog.Filter = "试验方法文件(*.dat)|*.dat";
            controlex.ShowDialog(this);
            if (controlex.OpenDialog.FileName == null)
            {

                return;
            }
            else
            {
                string fileName = controlex.OpenDialog.FileName;

                if (fileName == "")
                {
                    return;
                }
                else
                {
                    OpenTheMethod(fileName);

                    
                }
                ClsStaticStation.m_Global.mycls.initchannel();
                ((FormMainLab)Application.OpenForms["FormMainLab"]).InitKey();
                ((FormMainLab)Application.OpenForms["FormMainLab"]).InitMeter();
            }
            controlex.Dispose();

        }

        private void btnexsave_Click(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.currentspenumber = 0;
            CComLibrary.GlobeVal.filesave.mspecount = 100;
            CComLibrary.GlobeVal.filesave.SerializeNow(mmethodfilename);
            GlobeVal.filesavecmp = CComLibrary.GlobeVal.filesave.DeSerializeNow(mmethodfilename); 
            ((FormMainLab)Application.OpenForms["FormMainLab"]).InitKey() ;
            ((FormMainLab)Application.OpenForms["FormMainLab"]).InitMeter();
        }

        private void panelback_Paint(object sender, PaintEventArgs e)
        {

        }

        private void treeView1_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void btnsaveas_Click(object sender, EventArgs e)
        {
            
            saveFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\Method";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.Filter = "试验方法文件(*.dat)|*.dat";
            saveFileDialog1.ShowDialog(this);
            if ((saveFileDialog1.FileName == "") ||(saveFileDialog1.FileName ==null))
            {

               // CComLibrary.GlobeVal.filesave.SerializeNow(saveFileDialog1.FileName);

                return;
            }
            else
            {


                CComLibrary.GlobeVal.filesave.SerializeNow(saveFileDialog1.FileName);
                mmethodfilename = Path.GetFileName(saveFileDialog1.FileName);
                this.UserControl常规1.txtmethodname.Text = mmethodfilename;
            }

           
        }

        private void btnexsaveclose_Click(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.currentspenumber = 0;
            CComLibrary.GlobeVal.filesave.mspecount = 100;
            CComLibrary.GlobeVal.filesave.SerializeNow(mmethodfilename);
            GlobeVal.filesavecmp = CComLibrary.GlobeVal.filesave.DeSerializeNow(mmethodfilename);
            ((FormMainLab)Application.OpenForms["FormMainLab"]).InitKey();
            ((FormMainLab)Application.OpenForms["FormMainLab"]).InitMeter();
            ((TabControl)Application.OpenForms["FormMainLab"].Controls["tabcontrol1"]).SelectedIndex = 0;
        }

        private void UserControlMethod_TabIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
