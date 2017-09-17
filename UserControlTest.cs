using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using System.Drawing.Imaging;

namespace TabHeaderDemo
{
    public partial class UserControlTest : UserControl
    {

        private int  mlaststepi=0;
        class btnstep
        {
           public  int novalid=0;
           public  int valid=0;
           public  int current=0;
           
           
           public ButtonExNew btn; 

           public btnstep()
           {

           }
        }
        private List<btnstep> mbtnstep;
        
       

        private int mcurstep = 0;

        private int mlistcurstep = 1;

        private int mstepi = 0;

        private bool mbtnnextpress = false;
        
        public UserControlTest()
        {
            InitializeComponent();

            mbtnstep = new List<btnstep>();

            for (int i = 0; i <9; i++)
            {
                btnstep b = new btnstep();
                mbtnstep.Add(b);

            }

            mbtnstep[0].btn = btnstep1;
            mbtnstep[0].novalid = 2;
            mbtnstep[0].valid = 0;
            mbtnstep[0].current = 1;
           

            mbtnstep[1].novalid = 5;
            mbtnstep[1].valid = 3;
            mbtnstep[1].current = 4;
            mbtnstep[1].btn = btnstep2;

            mbtnstep[2].novalid = 8;
            mbtnstep[2].valid = 6;
            mbtnstep[2].current = 7;
            mbtnstep[2].btn = btnstep3; 

            
            mbtnstep[3].btn = btnstep3;

            mbtnstep[3].novalid = 8;
            mbtnstep[3].valid = 6;
            mbtnstep[3].current = 21;
            
           


            mbtnstep[4].novalid = 11;
            mbtnstep[4].valid = 9;
            mbtnstep[4].current = 10;
           
            mbtnstep[4].btn = btnstep4;


            mbtnstep[5].novalid = 11;
            mbtnstep[5].valid = 9;
            mbtnstep[5].current = 22;

            mbtnstep[5].btn = btnstep4;


            mbtnstep[6].novalid = 20;
            mbtnstep[6].valid = 18;
            mbtnstep[6].current = 19;
            mbtnstep[6].btn = btnstep5;

            mbtnstep[7].novalid =14;
            mbtnstep[7].valid = 12;
            mbtnstep[7].current =13;
            mbtnstep[7].btn = btnstep6;

            mbtnstep[8].novalid = 16;
            mbtnstep[8].valid = 15;
            mbtnstep[8].current = 17;
            mbtnstep[8].btn = btnstep7;


            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲

            this.tableLayoutPanel2.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel2, true, null);

            this.tableLayoutPanel4.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel4, true, null);

            tableLayoutPanel5.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel5, true, null);

            tableLayoutPanel8.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel8, true, null);

            tableLayoutPanel9.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel9, true, null);


            this.tableLayoutPanelback.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanelback, true, null);

            this.tableLayoutPanelTop.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanelTop, true, null);

            
        }

        public void Init_btnstep()
        {
            for (int i = 0; i < mbtnstep.Count; i++)
            {
                mbtnstep[i].btn.ImageIndex = mbtnstep[i].novalid;
                for (int j=0;j<CComLibrary.GlobeVal.filesave.mstep.Count;j++)
                {
                    if (i==CComLibrary.GlobeVal.filesave.mstep[j].Id)
                    {
                        mbtnstep[i].btn.ImageIndex = mbtnstep[i].valid; 
                    }
                }
            }

            mbtnstep[CComLibrary.GlobeVal.filesave.mstep[0].Id].btn.ImageIndex =
                mbtnstep[CComLibrary.GlobeVal.filesave.mstep[0].Id].current;

            mlistcurstep = 1;

            mbtnnextpress = false;
        }
        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            DialogResult a;
            a = MessageBox.Show("是否要使用相同的试样参数开始另外一个新样品？", "开始另外一个新样品？", MessageBoxButtons.YesNo);
            if (a == DialogResult.Yes)
            {

            }
            else
            {

            }
        }

        private   void drawFigure(PaintEventArgs e, PointF[] points)
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
            

            drawPath(e, path, c);
            btnfinish.BackColor = c;


            btnfinish.FlatAppearance.MouseOverBackColor = c;
            btnfinish.FlatAppearance.MouseDownBackColor = c;
            btnfinish.FlatAppearance.CheckedBackColor = c;

            

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

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            if (this.DesignMode)
            {
                return;
            }

            GraphicsContainer containerState = e.Graphics.BeginContainer();
            tableLayoutPanelback.BackColor = Color.Transparent;
           
            e.Graphics.PageUnit = System.Drawing.GraphicsUnit.Pixel;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.Clear(Color.White);



            PointF[] roundedRectangle = new PointF[5];
            roundedRectangle[0].X = 2;
            roundedRectangle[0].Y = 3;
            roundedRectangle[1].X = this.pictureBox1.Width - 2 - 3;
            roundedRectangle[1].Y = 3;
            roundedRectangle[2].X = this.pictureBox1.Width - 2 - 3;
            roundedRectangle[2].Y = this.pictureBox1.Height -2 - 3;
            roundedRectangle[3].X = 1;
            roundedRectangle[3].Y = this.pictureBox1.Height -2 - 3;
            roundedRectangle[4].X = 1;
            roundedRectangle[4].Y = 3;
            drawFigure(e, roundedRectangle);

            //e.Graphics.EndContainer(containerState);

            //containerState = e.Graphics.BeginContainer();
            //e.Graphics.PageUnit = System.Drawing.GraphicsUnit.Pixel;
            //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //e.Graphics.Clear(Color.White);



            roundedRectangle = new PointF[5];
            roundedRectangle[0].X = paneltop.Left   - 15;
            roundedRectangle[0].Y = paneltop.Top;
            roundedRectangle[1].X = paneltop.Right;
            roundedRectangle[1].Y = paneltop.Top;
            roundedRectangle[2].X = paneltop.Right ;  
            roundedRectangle[2].Y = roundedRectangle[0].Y + (panel8.Bottom - paneltop.Top);
            roundedRectangle[3].X = paneltop.Left - 15;
            roundedRectangle[3].Y = roundedRectangle[0].Y + (panel8.Bottom-paneltop.Top)  ;
            roundedRectangle[4].X = paneltop.Left - 15;
            roundedRectangle[4].Y = paneltop.Top;
            drawFigure1(e, roundedRectangle);

            e.Graphics.EndContainer(containerState);

        }
        private static void drawFigure1(PaintEventArgs e, PointF[] points)
        {
            GraphicsPath path = new GraphicsPath();


            Corners r = new Corners(points, 5);
            r.Execute(path);
            path.CloseFigure();
            Matrix matrix = new Matrix();
            matrix.Translate(0, 0);
            path.Transform(matrix);
            drawPath1(e, path, Color.White);
            path.Dispose();

        }

        private static void drawPath1(PaintEventArgs e, GraphicsPath path, Color color)
        {
            LinearGradientBrush brush = new LinearGradientBrush(path.GetBounds(),
                color, color, LinearGradientMode.Horizontal);
            e.Graphics.FillPath(brush, path);
            Pen pen = new Pen(color, 1);
            e.Graphics.DrawPath(pen, path);

            brush.Dispose();
            pen.Dispose();
        }

       

        

        private void btnebefore_Click(object sender, EventArgs e)
        {
            if (mlistcurstep <=0)
            {
               
                return;
            }

            if (mbtnnextpress == true)
            {
                mlistcurstep = mlistcurstep - 2;
                mbtnnextpress = false;
            }
            else
            {
                mlistcurstep = mlistcurstep - 1;
            }

            mstepi = CComLibrary.GlobeVal.filesave.mtestlist[mlistcurstep];



            if (mlistcurstep == 0)
            {
                btnebefore.Enabled = false; 
            }

            steprefresh();
            
         

        }


        public void FreeFormRefresh(bool calced,bool readed)
        {
            lstspe.Items.Clear();

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.currentspenumber + 1; i++)
            {
                IP.Components.Toolbox.Item m = new IP.Components.Toolbox.Item();
                m.Text = (i + 1).ToString();
                lstspe.Items.Add(m);

                if (CComLibrary.GlobeVal.filesave.dt.Rows[i]["试样状态"] == null)
                {
                    CComLibrary.GlobeVal.filesave.dt.Rows[i]["试样状态"] = CComLibrary.TestStatus.Untested;
                }

                if (CComLibrary.GlobeVal.filesave.dt.Rows[i]["试样状态"] is System.DBNull)
                {
                    CComLibrary.GlobeVal.filesave.dt.Rows[i]["试样状态"] = CComLibrary.TestStatus.Untested;
                }

                m.Image = imageList2.Images[Convert.ToInt16(CComLibrary.GlobeVal.filesave.dt.Rows[i]["试样状态"])];
            }
            if (GlobeVal.UserControlResult1 != null)
            {
                if (calced ==false )
                {
                    GlobeVal.UserControlResult1.InitGrid(1, false, readed, CComLibrary.GlobeVal.filesave.mtablecol1, CComLibrary.GlobeVal.filesave.mtable1para,
                        CComLibrary.GlobeVal.filesave.mtable1statistics);
                }
                else
                {
                    GlobeVal.UserControlResult1.InitGrid(1, true, readed, CComLibrary.GlobeVal.filesave.mtablecol1, CComLibrary.GlobeVal.filesave.mtable1para,
                        CComLibrary.GlobeVal.filesave.mtable1statistics);
                }
            }

            if (GlobeVal.UserControlResult2 != null)
            {
                if (calced ==false )
                {
                    GlobeVal.UserControlResult2.InitGrid(2, false, readed, CComLibrary.GlobeVal.filesave.mtablecol2, CComLibrary.GlobeVal.filesave.mtable2para,
                        CComLibrary.GlobeVal.filesave.mtable2statistics);
                }
                else
                {
                    GlobeVal.UserControlResult2.InitGrid(2, true, readed, CComLibrary.GlobeVal.filesave.mtablecol2, CComLibrary.GlobeVal.filesave.mtable2para,
                        CComLibrary.GlobeVal.filesave.mtable2statistics);
                }
            }



            if (GlobeVal.UserControlSpe1 != null)
            {
                if (calced ==false )
                {
                    GlobeVal.UserControlSpe1.setspe(CComLibrary.GlobeVal.filesave.currentspenumber + 1, CComLibrary.TestStatus.Untested);
                }
                if (calced ==true)
                {
                    GlobeVal.UserControlSpe1.setspe(CComLibrary.GlobeVal.filesave.currentspenumber + 1, CComLibrary.TestStatus.tested);

                }

                GlobeVal.UserControlSpe1.setinput();
            }

            if (GlobeVal.UserControlGraph1 != null)
            {
                if (calced == false)
                {
                    GlobeVal.UserControlGraph1.Init曲线(1);
                }
                    
            }


            if (GlobeVal.UserControlGraph2 != null)
            {
                if (calced == false)
                {
                    GlobeVal.UserControlGraph2.Init曲线(2);
                }

            }
        }
        
        public void OpenDefaultlayout(string filename)
        {



            CComLibrary.FileLayoutStruct f = new CComLibrary.FileLayoutStruct();

            f = f.DeSerializeNow(filename);
            GlobeVal.dynset.tlbetest.Controls.Clear();

            GlobeVal.dynset.tlbetest.RowCount = f.rowcount;
            GlobeVal.dynset.tlbetest.ColumnCount = f.colcount;

           

            
           

           
            for (int k = 0; k < 10; k++)
            {
                if (f.Show[k] == true)
                {
                    if (f.ItemName[k] == "曲线图1")
                    {
                        UserControlGraph ug = new UserControlGraph();
                        ug.Visible = true;
                        ug.Dock = DockStyle.Fill;
                        GlobeVal.dynset.tlbetest.SetCellPosition(ug, new TableLayoutPanelCellPosition(f.ItemCol[k], f.ItemRow[k]));

                        GlobeVal.dynset.tlbetest.SetColumnSpan(ug, f.ItemColSpan[k]);
                        GlobeVal.dynset.tlbetest.SetRowSpan(ug, f.ItemRowSpan[k]);

                        GlobeVal.dynset.tlbetest.Controls.Add(ug);
                        GlobeVal.UserControlGraph1 = ug;


                    }

                    if (f.ItemName[k] == "曲线图2")
                    {
                        UserControlGraph ug = new UserControlGraph();
                        ug.Visible = true;
                        ug.Dock = DockStyle.Fill;
                        GlobeVal.dynset.tlbetest.SetCellPosition(ug, new TableLayoutPanelCellPosition(f.ItemCol[k], f.ItemRow[k]));

                        GlobeVal.dynset.tlbetest.SetColumnSpan(ug, f.ItemColSpan[k]);
                        GlobeVal.dynset.tlbetest.SetRowSpan(ug, f.ItemRowSpan[k]);

                        GlobeVal.dynset.tlbetest.Controls.Add(ug);
                        GlobeVal.UserControlGraph2 = ug;

                    }
                    if (f.ItemName[k] == "结果1")
                    {
                        UserControlResult ug = new UserControlResult();
                        
                        
                        ug.Visible = true;
                        ug.Dock = DockStyle.Fill;
                        GlobeVal.dynset.tlbetest.SetCellPosition(ug, new TableLayoutPanelCellPosition(f.ItemCol[k], f.ItemRow[k]));

                        GlobeVal.dynset.tlbetest.SetColumnSpan(ug, f.ItemColSpan[k]);
                        GlobeVal.dynset.tlbetest.SetRowSpan(ug, f.ItemRowSpan[k]);

                        GlobeVal.dynset.tlbetest.Controls.Add(ug);
                        GlobeVal.UserControlResult1 = ug;



                    }

                    if (f.ItemName[k] == "结果2")
                    {
                        UserControlResult ug = new UserControlResult();
                        
                        ug.Visible = true;
                        ug.Dock = DockStyle.Fill;
                        GlobeVal.dynset.tlbetest.SetCellPosition(ug, new TableLayoutPanelCellPosition(f.ItemCol[k], f.ItemRow[k]));

                        GlobeVal.dynset.tlbetest.SetColumnSpan(ug, f.ItemColSpan[k]);
                        GlobeVal.dynset.tlbetest.SetRowSpan(ug, f.ItemRowSpan[k]);

                        GlobeVal.dynset.tlbetest.Controls.Add(ug);
                        GlobeVal.UserControlResult2 = ug;


                    }
                    if (f.ItemName[k] == "原始数据")
                    {
                        UserControlRawdata ug = new UserControlRawdata();
                        ug.Visible = true;
                        ug.Dock = DockStyle.Fill;
                        GlobeVal.dynset.tlbetest.SetCellPosition(ug, new TableLayoutPanelCellPosition(f.ItemCol[k], f.ItemRow[k]));

                        GlobeVal.dynset.tlbetest.SetColumnSpan(ug, f.ItemColSpan[k]);
                        GlobeVal.dynset.tlbetest.SetRowSpan(ug, f.ItemRowSpan[k]);

                        GlobeVal.dynset.tlbetest.Controls.Add(ug);


                    }
                    

                    if (f.ItemName[k] == "试样输入")
                    {
                        UserControlSpe ug = new UserControlSpe();
                        
                        //ug.setspe(CComLibrary.GlobeVal.filesave.currentspenumber + 1, CComLibrary.TestStatus.Untested);
                        ug.Dock = DockStyle.Fill;
                        GlobeVal.dynset.tlbetest.SetCellPosition(ug, new TableLayoutPanelCellPosition(f.ItemCol[k], f.ItemRow[k]));

                        GlobeVal.dynset.tlbetest.SetColumnSpan(ug, f.ItemColSpan[k]);
                        GlobeVal.dynset.tlbetest.SetRowSpan(ug, f.ItemRowSpan[k]);

                        GlobeVal.dynset.tlbetest.Controls.Add(ug);
                        ug.Visible = true;
                        GlobeVal.UserControlSpe1 = ug;


                    }
                    if (f.ItemName[k] == "仪表1")
                    {
                        UserControlMeter ug = new UserControlMeter();
                        ug.Init();
                        
                        ug.Dock = DockStyle.Fill;
                        GlobeVal.dynset.tlbetest.SetCellPosition(ug, new TableLayoutPanelCellPosition(f.ItemCol[k], f.ItemRow[k]));

                        GlobeVal.dynset.tlbetest.SetColumnSpan(ug, f.ItemColSpan[k]);
                        GlobeVal.dynset.tlbetest.SetRowSpan(ug, f.ItemRowSpan[k]);
                      
                       
                        GlobeVal.dynset.tlbetest.Controls.Add(ug);
                        ug.Visible = true;
                       
                    }
                    if (f.ItemName[k] == "仪表2")
                    {
                        UserControlMeter ug = new UserControlMeter();
                        ug.Init();
                        
                        ug.Dock = DockStyle.Fill;
                        GlobeVal.dynset.tlbetest.SetCellPosition(ug, new TableLayoutPanelCellPosition(f.ItemCol[k], f.ItemRow[k]));

                        GlobeVal.dynset.tlbetest.SetColumnSpan(ug, f.ItemColSpan[k]);
                        GlobeVal.dynset.tlbetest.SetRowSpan(ug, f.ItemRowSpan[k]);
                       
                       

                        GlobeVal.dynset.tlbetest.Controls.Add(ug);

                        ug.Visible = true;
                       
                    }

                    

                }
            }


            
        }

        public void lstspeRefresh()

    {
        lstspe.Items.Clear();

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.currentspenumber + 1; i++)
            {
                IP.Components.Toolbox.Item m = new IP.Components.Toolbox.Item();
                m.Text = (i + 1).ToString();
                lstspe.Items.Add(m);

               

                if (CComLibrary.GlobeVal.filesave.dt.Rows[i]["试样状态"] is System.DBNull)
                {
                    CComLibrary.GlobeVal.filesave.dt.Rows[i]["试样状态"] = CComLibrary.TestStatus.Untested;
                }

                m.Image = imageList2.Images[Convert.ToInt16(CComLibrary.GlobeVal.filesave.dt.Rows[i]["试样状态"])];
            }
    }
       

        private void steprefresh()
        {
            this.SuspendLayout();

            
            if (mstepi == 0)
            {
                btneafter.Enabled = true;
                btnebefore.Enabled = false;
                
                GlobeVal.userControltest1.lstspe.Visible = false;
                if (GlobeVal.userControltest1.paneltestright.Controls.Contains(
                        GlobeVal.wizard) == true)
                {
                    GlobeVal.wizard.Init(0);
                }
                else
                {
                    GlobeVal.userControltest1.paneltestright.Controls.Clear();
                    GlobeVal.userControltest1.paneltestright.Controls.Add(GlobeVal.wizard);
                    GlobeVal.wizard.Init(0);
                }

            }



            if (mstepi == 1)
            {
               


                

                GlobeVal.wizard.lblspe1.Text = "试样" + (CComLibrary.GlobeVal.filesave.currentspenumber+1).ToString() + ", 共" + CComLibrary.GlobeVal.filesave.mspecount.ToString();
                GlobeVal.wizard.lblspe2.Text = "试样" + (CComLibrary.GlobeVal.filesave.currentspenumber+1).ToString() + ", 共" + CComLibrary.GlobeVal.filesave.mspecount.ToString();
                GlobeVal.wizard.lblspe3.Text = "试样" + (CComLibrary.GlobeVal.filesave.currentspenumber+1).ToString() + ", 共" + CComLibrary.GlobeVal.filesave.mspecount.ToString();
                GlobeVal.wizard.lblspe4.Text = "试样" + (CComLibrary.GlobeVal.filesave.currentspenumber+1).ToString() + ", 共" + CComLibrary.GlobeVal.filesave.mspecount.ToString();
                GlobeVal.wizard.lblspe5.Text = "试样" + (CComLibrary.GlobeVal.filesave.currentspenumber+1).ToString() + ", 共" + CComLibrary.GlobeVal.filesave.mspecount.ToString();
                GlobeVal.wizard.lblspe6.Text = "试样" + (CComLibrary.GlobeVal.filesave.currentspenumber+1).ToString() + ", 共" + CComLibrary.GlobeVal.filesave.mspecount.ToString();


            

                GlobeVal.userControltest1.lstspe.Visible = false;
                if (GlobeVal.userControltest1.paneltestright.Controls.Contains(
                        GlobeVal.wizard) == true)
                {
                    GlobeVal.wizard.Init(1);
                }
                else
                {
                    GlobeVal.userControltest1.paneltestright.Controls.Clear();
                    GlobeVal.userControltest1.paneltestright.Controls.Add(GlobeVal.wizard);
                    GlobeVal.wizard.Init(1);
                }



            }

            if (mstepi == 2)
            {


               

                GlobeVal.userControltest1.lstspe.Visible = false;
                if (GlobeVal.userControltest1.paneltestright.Controls.Contains(
                        GlobeVal.wizard) == true)
                {
                    GlobeVal.wizard.Init(2);
                }
                else
                {
                    GlobeVal.userControltest1.paneltestright.Controls.Clear();
                    GlobeVal.userControltest1.paneltestright.Controls.Add(GlobeVal.wizard);
                    GlobeVal.wizard.Init(2);
                }

                btneafter.Enabled = false;




            }
            if ((mstepi == 3) || (mstepi == 5))
            {

              

                
               

                GlobeVal.userControltest1.paneltestright.Visible = false;

                GlobeVal.userControltest1.paneltestright.Controls.Clear();

                GlobeVal.userControltest1.lstspe.Visible = true;


                if (GlobeVal.dynset == null)
                {

                    GlobeVal.dynset = new UserControlDynSet();
                    GlobeVal.dynset.Dock = DockStyle.Fill;
                    GlobeVal.dynset.BackColor = Color.Cyan;
                    GlobeVal.dynset.tlbetest.Controls.Clear();
                    GlobeVal.dynset.tlbetest.RowCount = 0;
                    GlobeVal.dynset.tlbetest.ColumnCount = 0;
                    GlobeVal.dynset.Dock = DockStyle.None;
                    GlobeVal.UserControlResult1 = null;
                    GlobeVal.UserControlResult2 = null;
                    OpenDefaultlayout(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AppleLabJ" + "\\layout\\模板1.lay");
                }
                

                
                GlobeVal.userControltest1.paneltestright.Controls.Add(GlobeVal.dynset);

               

                GlobeVal.userControltest1.paneltestright.Visible = true;

                GlobeVal.dynset.Dock = DockStyle.Fill;

                GlobeVal.userControltest1.paneltestright.Refresh();

                GlobeVal.dynset.tlbetest.ResetSizeAndSizeTypes();


                if (mstepi == 3)
                {
                    FreeFormRefresh(false, false);
                }
                else
                {
                    FreeFormRefresh(true, false);
                }
              
            }



            if (mstepi == 4)
            {

              

                GlobeVal.userControltest1.lstspe.Visible = false;
                if (GlobeVal.userControltest1.paneltestright.Controls.Contains(
                        GlobeVal.wizard) == true)
                {
                    GlobeVal.wizard.Init(3);
                }
                else
                {
                    GlobeVal.userControltest1.paneltestright.Controls.Clear();
                    GlobeVal.userControltest1.paneltestright.Controls.Add(GlobeVal.wizard);
                    GlobeVal.wizard.Init(3);
                }





            }

            if (mstepi == 6)
            {

                

                GlobeVal.userControltest1.lstspe.Visible = false;
                if (GlobeVal.userControltest1.paneltestright.Controls.Contains(
                        GlobeVal.wizard) == true)
                {
                    GlobeVal.wizard.Init(4);
                }
                else
                {
                    GlobeVal.userControltest1.paneltestright.Controls.Clear();
                    GlobeVal.userControltest1.paneltestright.Controls.Add(GlobeVal.wizard);
                    GlobeVal.wizard.Init(4);
                }





            }

            if (mstepi == 7)
            {

              
                GlobeVal.userControltest1.lstspe.Visible = false;
                if (GlobeVal.userControltest1.paneltestright.Controls.Contains(
                        GlobeVal.wizard) == true)
                {
                    GlobeVal.wizard.Init(5);
                }
                else
                {
                    GlobeVal.userControltest1.paneltestright.Controls.Clear();
                    GlobeVal.userControltest1.paneltestright.Controls.Add(GlobeVal.wizard);
                    GlobeVal.wizard.Init(5);
                }





            }


            if (mstepi == 8)
            {
               


                GlobeVal.userControltest1.lstspe.Visible = false;
                if (GlobeVal.userControltest1.paneltestright.Controls.Contains(
                        GlobeVal.wizard) == true)
                {
                    GlobeVal.wizard.Init(6);
                }
                else
                {
                    GlobeVal.userControltest1.paneltestright.Controls.Clear();
                    GlobeVal.userControltest1.paneltestright.Controls.Add(GlobeVal.wizard);
                    GlobeVal.wizard.Init(6);
                }





            }

            for (int ii = 0; ii < CComLibrary.GlobeVal.filesave.mstep.Count; ii++)
            {
                mbtnstep[CComLibrary.GlobeVal.filesave.mstep[ii].Id].btn.ImageIndex =
                    mbtnstep[CComLibrary.GlobeVal.filesave.mstep[ii].Id].valid;
            }




            mbtnstep[mstepi].btn.ImageIndex =
            mbtnstep[mstepi].current;

            this.ResumeLayout();
 
            
        }
        private void btneafter_Click(object sender, EventArgs e)
        {
            int i;

            if (btnebefore.Enabled == false)
            {
                btnebefore.Enabled = true;
                mlistcurstep = 1;
            }

            if (mlistcurstep > CComLibrary.GlobeVal.filesave.mtestlist.Count - 1)
            {
                return;
            }


            mbtnnextpress = true;

            if (mstepi >= CComLibrary.GlobeVal.filesave.mtestlist[mlistcurstep])
            {

                if (CComLibrary.GlobeVal.filesave.currentspenumber + 1 < CComLibrary.GlobeVal.filesave.mspecount)
                {
                    CComLibrary.GlobeVal.filesave.currentspenumber = CComLibrary.GlobeVal.filesave.currentspenumber + 1;
                }
                else
                {
                    mlistcurstep = CComLibrary.GlobeVal.filesave.mtestlist.Count - 1;
                }

                
  

            }

            mstepi = CComLibrary.GlobeVal.filesave.mtestlist[mlistcurstep];

            

            mlistcurstep = mlistcurstep + 1;


            steprefresh();

            
         
        }

        private void paneltestright_SizeChanged(object sender, EventArgs e)
        {
           
        }

        private void tableLayoutPanelback_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.SerializeNow(GlobeVal.spefilename);


        }

        private void lstspe_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (GlobeVal.myarm.connected == false)
            {
                MessageBox.Show("您还没有联机");
                return;
            }
           


            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem.Count; i++)
            {
                CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem[i].getvalue();
            }


            if (CComLibrary.GlobeVal.filesave.mwizard == true)
            {
                if (btneafter.Enabled == false)
                {
                    btneafter_Click(null, null);
                    btnStart.Enabled = false;
                    btnStart.BackgroundImage = imageList4.Images[1];

                    btnend.Enabled = true;
                    btnend.BackgroundImage = imageList4.Images[2];
                }
                else
                {
                    MessageBox.Show("请点击下一步继续");
                    return;
                }

            }
            else
            {
                btnStart.Enabled = false;
                btnStart.BackgroundImage = imageList4.Images[1];
                
                btnend.Enabled = true;
                btnend.BackgroundImage = imageList4.Images[2];

               

                
            }

            if (GlobeVal.myarm.mdemo == true)
            {

                GlobeVal.myarm.demotest(true);
            }
            else
            {

            }

            if (GlobeVal.UserControlSpe1 != null)
            {
                GlobeVal.UserControlSpe1.Enabled = false;

            }

            if (GlobeVal.UserControlGraph1 != null)
            {
                GlobeVal.UserControlGraph1.startrun();
            }

            if (GlobeVal.UserControlGraph2 != null)
            {
                GlobeVal.UserControlGraph2.startrun();
            }

            GlobeVal.myarm.starttest();

            timer1.Enabled = true;
            GlobeVal.MainStatusStrip.Items["toolstatustest"].Visible = true;


        }

        private void btnend_Click(object sender, EventArgs e)
        {
            string mspefiledat;

            CComLibrary.GlobeVal.filesave.dt.Rows[CComLibrary.GlobeVal.filesave.currentspenumber]["试样状态"] = CComLibrary.TestStatus.tested;

            CComLibrary.GlobeVal.filesave.lasttestdatatime = System.DateTime.Now.ToString();

            if (GlobeVal.UserControlSpe1 != null)
            {
                GlobeVal.UserControlSpe1.Enabled = true;
                GlobeVal.UserControlSpe1.btnright.Enabled = true;

            }
            if (GlobeVal.UserControlGraph1 != null)
            {
                GlobeVal.UserControlGraph1.endrun();
            }

            if (GlobeVal.UserControlGraph2 != null)
            {
                GlobeVal.UserControlGraph2.endrun();
            }

            mspefiledat = GlobeVal.mysys.SamplePath + "\\" + GlobeVal.mysys.SampleFile + "-" +
                  (CComLibrary.GlobeVal.filesave.currentspenumber + 1).ToString().Trim() + ".txt";

            CComLibrary.GlobeVal.filesave.calc(mspefiledat);//计算数据

            if (CComLibrary.GlobeVal.filesave.mwizard == true)
            {
                btneafter.Enabled = true;

                btnStart.Enabled = true;
                btnStart.BackgroundImage = imageList4.Images[0];

                btnend.Enabled = false;
                btnend.BackgroundImage = imageList4.Images[3];
                FreeFormRefresh(true, false);

            }
            else
            {
                btnStart.Enabled = true;
                btnStart.BackgroundImage = imageList4.Images[0];

                btnend.Enabled = false;
                btnend.BackgroundImage = imageList4.Images[3];
                FreeFormRefresh(true,false);

                
               
                
            }

            if (GlobeVal.myarm.mdemo == true)
            {

                GlobeVal.myarm.demotest(false);
            }
            else
            {

            }

            GlobeVal.myarm.endtest();
            timer1.Enabled = false;
            GlobeVal.MainStatusStrip.Items["toolstatustest"].Visible = false;

           
        }

        private void btnfinish_Click(object sender, EventArgs e)
        {
            ((TabControl)Application.OpenForms["FormMainLab"].Controls["tabcontrol1"]).SelectedIndex = 0;

            GlobeVal.MainStatusStrip.Items["tslblkind"].Text = "试验类型：空";
            GlobeVal.MainStatusStrip.Items["tslblsample"].Text = "样品：关闭" ;

            GlobeVal.MainStatusStrip.Items["tslblmethod"].Text = "方法:关闭";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            

            


            if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 0)
            {
                GlobeVal.MainStatusStrip.Items["toolstatustest"].Text = "一般测试";


            }

            else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 1)
            {
              
                if  (GlobeVal.myarm.keepingstate==true)
                {

                    

                    GlobeVal.MainStatusStrip.Items["toolstatustest"].Text = "高级测试：步骤" + (GlobeVal.myarm.mcurseg + 1).ToString()
                        +"当前保持时间:"+GlobeVal.myarm.keepingtime.ToString("F1")+"秒";
                }
                else
                {
                    GlobeVal.MainStatusStrip.Items["toolstatustest"].Text = "高级测试：步骤"+(GlobeVal.myarm.mcurseg+1).ToString();

                }

                if (GlobeVal.myarm.duanliebaohu == true)
                {
                    GlobeVal.MainStatusStrip.Items["toolstatustest"].Text = "断裂保护：进入位移控制";
                }


                if (GlobeVal.myarm.total_returncount > 0)
                {
                    GlobeVal.MainStatusStrip.Items["toolstatustest"].Text =
                        GlobeVal.MainStatusStrip.Items["toolstatustest"].Text + " "
                        + "当前次数：" + GlobeVal.myarm.current_returncount.ToString() +
                        "总循环次数：" + GlobeVal.myarm.total_returncount.ToString();

                }


            }

            if (btnStart.Enabled == false)
            {

                if (GlobeVal.myarm.mtestrun == false)
                {
                     btnend_Click(null, null);
                }
            }
        }

        private void tableLayoutPanel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timermain_Tick(object sender, EventArgs e)
        {
           
        }

        private void UserControlTest_Load(object sender, EventArgs e)
        {
            timermain.Enabled = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            if (CComLibrary.GlobeVal.filesave.ReportPrint == true)
            {

                GlobeVal.UserControlMain1.userreport1.printreport();


            }

            else
            {
                MessageBox.Show("方法中没设置报告打印");
            }
            if (CComLibrary.GlobeVal.filesave.ReportSave == true)
            {
                if (CComLibrary.GlobeVal.filesave.ReportFormat == 0)
                {
                    GlobeVal.UserControlMain1.userreport1.document.SaveToFile(
                        GlobeVal.mysys.SamplePath + "\\" + GlobeVal.mysys.SampleFile + ".docx", FileFormat.Docx);
                }
                else
                {
                    Image image = GlobeVal.UserControlMain1.userreport1.document.SaveToImages(0, ImageType.Metafile);
                    image.Save(GlobeVal.mysys.SamplePath + "\\" + GlobeVal.mysys.SampleFile + ".tif", ImageFormat.Tiff);
                }
            }
        }
    }
}
