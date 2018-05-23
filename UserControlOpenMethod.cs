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
using AppleLabApplication;
using ClsStaticStation;
using System.Runtime.InteropServices;
using CustomControls.OS;
using CustomControls.Controls;
namespace TabHeaderDemo
{

    public partial class UserControlOpenMethod : UserControl
    {
        [DllImport("user32")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, IntPtr lParam);
        private const int WM_SETREDRAW = 0xB;   
  
       
        
        public UserControl常规 UserControl常规1;

        

        

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

            c = (imageList3.Images[0] as Bitmap).GetPixel(imageList3.Images[0].Width / 2, imageList3.Images[0].Height / 2);

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
        public UserControlOpenMethod()
        {
            InitializeComponent();
            treeView1.mimagelist = imageList2;
           

            tableLayoutPanel1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel1, true, null);
            tableLayoutPanel2.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel2, true, null);
            tableLayoutPanel3.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel3, true, null);  
  
  
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
        }

        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            

 
            
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
            if (t == "打开方法")
            {

                UserControl常规1.Init(0,false );
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl常规1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl常规1);
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
                treeView1.SelectedNode = e.Node;
            }


        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
        }

        private void UserControlMethod_Load(object sender, EventArgs e)
        {

           

            UserControl常规1 = new UserControl常规();
            UserControl常规1.Init(0,true);
           
            panelback.Controls.Clear();
            UserControl常规1.Dock = DockStyle.Fill;
            UserControl常规1.Width = panelback.Width;
            UserControl常规1.Height= panelback.Height;
            
            panelback.Controls.Add(UserControl常规1);

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲

             this.tableLayoutPanel1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel1, true, null);
            this.tableLayoutPanel2.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel2, true, null);
            this.tableLayoutPanel3.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel3, true, null);
            
            treeView1.SelectedNode = treeView1.Nodes[0];

         
            
        }



      
        private void btnexopen_Click(object sender, EventArgs e)
        {
           
            UserControl常规1.OpenRecentMethod();

           
           


        }

        

        private void buttonExNext_Click(object sender, EventArgs e)
        {
            if (CComLibrary.GlobeVal.filesave == null)
            {
                MessageBox.Show("错误，试验方法不能为空"); 
                return;
            }


           
            
            
            GlobeVal.UserControlMain1.MethodNext(CComLibrary.GlobeVal.currentfilesavename);



               
            
            
            
          
               
        }

        
        private void btnexnew_Click(object sender, EventArgs e)
        {
            
        }

        private void panelback_ControlAdded(object sender, ControlEventArgs e)
        {
            
        }

        private void panelback_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UserControlOpenMethod_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void UserControlOpenMethod_Resize(object sender, EventArgs e)
        {
           
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.Visible = true;
        }

        private void buttonExLook_Click(object sender, EventArgs e)
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
                  
                    UserControl常规1.txtmethodname.Text = Path.GetFileNameWithoutExtension(fileName);
                    UserControl常规1.txtmethodpath.Text = Path.GetDirectoryName(fileName);

                    if (CComLibrary.GlobeVal.filesave == null)
                    {
                        CComLibrary.GlobeVal.filesave = new CComLibrary.FileStruct();
                    }
                    CComLibrary.GlobeVal.filesave = CComLibrary.GlobeVal.filesave.DeSerializeNow(fileName);


                    CComLibrary.GlobeVal.currentfilesavename = fileName;
                    UserControl常规1.Open_method();
                    ClsStaticStation.m_Global.mycls.initchannel();


                    ((FormMainLab)Application.OpenForms["FormMainLab"]).InitKey();
                    ((FormMainLab)Application.OpenForms["FormMainLab"]).InitMeter();
                }
            }

            controlex.Dispose();
        }

        private void btnexsaveclose_Click(object sender, EventArgs e)
        {

        }
    }
}
