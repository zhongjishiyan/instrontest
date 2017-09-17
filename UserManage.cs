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
    public partial class UserManage : UserControl
    {
        
        private UserControl系统信息 UserControl系统信息1;

        private UserControl系统选项 UserControl系统选项1;

        private UserControl系统安全 UserControl安全1;
        private UserControl系统设置 UserControl系统设置1;
 
        private void drawFigure(PaintEventArgs e, PointF[] points)
        {
            GraphicsPath path = new GraphicsPath();


            Corners r = new Corners(points, 5);
            r.Execute(path);
            path.CloseFigure();
            Matrix matrix = new Matrix();
            matrix.Translate(3, 3);
            path.Transform(matrix);



            Color c = (this.imageList3.Images[0] as Bitmap).GetPixel(this.imageList3.Images[0].Width - 5, this.imageList3.Images[0].Height / 2);


           
            drawPath(e, path, c);

            path.Reset();
            r = new Corners(points, 5);
            r.Execute(path);
            path.CloseFigure();
            matrix = new Matrix();
            matrix.Translate(0, 0);
            path.Transform(matrix);

            c = (this.imageList3.Images[0] as Bitmap).GetPixel(this.imageList3.Images[0].Width / 2, this.imageList3.Images[0].Height / 2);

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
        public UserManage()
        {
            InitializeComponent();
            treeView1.mimagelist = imageList2;
            UserControl系统信息1 = new UserControl系统信息();
            UserControl系统选项1 = new UserControl系统选项();
            UserControl安全1 = new UserControl系统安全();
            UserControl系统设置1 = new UserControl系统设置();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲


            this.tableLayoutPanel1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel1, true, null);
            this.tableLayoutPanel2.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel2, true, null);
            this.tableLayoutPanel3.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel3, true, null);

           
        }

        private void UserReport_Paint(object sender, PaintEventArgs e)
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
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes.Count == 0)
            {

            }
            else
            {
                treeView1.SelectedNode = e.Node.Nodes[0];

                methodon(e.Node.Nodes[0].Text, e.Node.Text);
            }
        }

        public void methodon(String t, String parent)
        {
            if (t == "查看")
            {

                UserControl系统信息1.Init(0);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl系统信息1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl系统信息1);
                panelback.Visible = true;
            }

            if (t == "启动")
            {

                UserControl安全1.Init(0);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl安全1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl安全1);
                panelback.Visible = true;
            }

            if (t == "系统")
            {

                UserControl系统选项1.Init(0);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl系统选项1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl系统选项1);
                panelback.Visible = true;
            }

            if (t == "选项")
            {
                UserControl系统设置1.Init(0);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl系统设置1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl系统设置1);
                panelback.Visible = true;
            }

            if (t == "传感器")
            {
                UserControl系统设置1.Init(1);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl系统设置1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl系统设置1);
                panelback.Visible = true;
            }

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent == null)
            {
               // methodon(e.Node.Text, "");
            }
            else
            {
                methodon(e.Node.Text, e.Node.Parent.Text);
            }

        }

        private void UserManage_Load(object sender, EventArgs e)
        {
            treeView1.SelectedNode = treeView1.Nodes[0];
        }

        private void buttonEx1_Click(object sender, EventArgs e)
        {

        }
    }
}
