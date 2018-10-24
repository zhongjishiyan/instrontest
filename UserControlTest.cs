﻿using System;
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

using System.IO;
using org.in2bits.MyXls;


namespace TabHeaderDemo
{
    public partial class UserControlTest : UserControl
    {

        private int mlaststepi = 0;
        class btnstep
        {
            public int novalid = 0;
            public int valid = 0;
            public int current = 0;


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

        public void ExportToExcel(DataTable dtSource, string strFileName)
        {
            XlsDocument xls = new XlsDocument();
            Worksheet sheet = xls.Workbook.Worksheets.Add("sheet1");
            int i = 0;

            //write data from datatable in Excel file 
            foreach (DataColumn column in dtSource.Columns)
            {
                sheet.Cells.Add(1, i + 1, column.ColumnName);
                i++;
            }
            for (int j = 0; j < dtSource.Rows.Count; j++)
            {
                for (int k = 0; k < dtSource.Columns.Count; k++)
                {
                    sheet.Cells.Add(j + 2, k + 1, dtSource.Rows[j][k].ToString());
                }
            }
            // save
            xls.FileName = strFileName;
            if (File.Exists(strFileName))
            {
                File.Delete(strFileName);
            }
            xls.Save();
        }


        public UserControlTest()
        {
            InitializeComponent();

            lstspe.ItemMenu = contextMenuStrip1;

            lstspe.ContextMenuStrip = contextMenuStrip1;
            lstspe.TabMenu = null;

            mbtnstep = new List<btnstep>();

            for (int i = 0; i < 9; i++)
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

            mbtnstep[7].novalid = 14;
            mbtnstep[7].valid = 12;
            mbtnstep[7].current = 13;
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
                for (int j = 0; j < CComLibrary.GlobeVal.filesave.mstep.Count; j++)
                {
                    if (i == CComLibrary.GlobeVal.filesave.mstep[j].Id)
                    {
                        mbtnstep[i].btn.ImageIndex = mbtnstep[i].valid;
                    }
                }
            }

            mbtnstep[CComLibrary.GlobeVal.filesave.mstep[0].Id].btn.ImageIndex =
                mbtnstep[CComLibrary.GlobeVal.filesave.mstep[0].Id].current;

            mlistcurstep = 1;

            mstepi = 0;
            mbtnnextpress = false;

            btnebefore.Enabled = false;
            btneafter.Enabled = true;
        }
     

        private void drawFigure(PaintEventArgs e, PointF[] points)
        {



            GraphicsPath path = new GraphicsPath();


            Corners r = new Corners(points, 5);
            r.Execute(path);
            path.CloseFigure();
            Matrix matrix = new Matrix();
            matrix.Translate(3, 3);
            path.Transform(matrix);



            System.Drawing.Color c = (imageList3.Images[0] as Bitmap).GetPixel(imageList3.Images[0].Width - 5, imageList3.Images[0].Height / 2);



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

        private static void drawPath(PaintEventArgs e, GraphicsPath path, System.Drawing.Color color)
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
            tableLayoutPanelback.BackColor = System.Drawing.Color.Transparent;

            e.Graphics.PageUnit = System.Drawing.GraphicsUnit.Pixel;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.Clear(System.Drawing.Color.White);



            PointF[] roundedRectangle = new PointF[5];
            roundedRectangle[0].X = 8;
            roundedRectangle[0].Y = 3;
            roundedRectangle[1].X = this.pictureBox1.Width - 2 - 3;
            roundedRectangle[1].Y = 3;
            roundedRectangle[2].X = this.pictureBox1.Width - 2 - 3;
            roundedRectangle[2].Y = this.pictureBox1.Height - 2 - 3;
            roundedRectangle[3].X = 1;
            roundedRectangle[3].Y = this.pictureBox1.Height - 2 - 3;
            roundedRectangle[4].X = 1;
            roundedRectangle[4].Y = 8;
            drawFigure(e, roundedRectangle);

            //e.Graphics.EndContainer(containerState);

            //containerState = e.Graphics.BeginContainer();
            //e.Graphics.PageUnit = System.Drawing.GraphicsUnit.Pixel;
            //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //e.Graphics.Clear(Color.White);



            roundedRectangle = new PointF[5];
            roundedRectangle[0].X = paneltop.Left - 15;
            roundedRectangle[0].Y = paneltop.Top;
            roundedRectangle[1].X = paneltop.Right;
            roundedRectangle[1].Y = paneltop.Top;
            roundedRectangle[2].X = paneltop.Right;
            roundedRectangle[2].Y = roundedRectangle[0].Y + (panel8.Bottom - paneltop.Top);
            roundedRectangle[3].X = paneltop.Left - 15;
            roundedRectangle[3].Y = roundedRectangle[0].Y + (panel8.Bottom - paneltop.Top);
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
            drawPath1(e, path, System.Drawing.Color.White);
            path.Dispose();

        }

        private static void drawPath1(PaintEventArgs e, GraphicsPath path, System.Drawing.Color color)
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
            if (mlistcurstep <= 0)
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


        public void FreeFormRefresh(bool calced, bool readed)
        {
            lstspe.Items.Clear();

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.testedcount + 1; i++)
            {
                IP.Components.Toolbox.Item m = new IP.Components.Toolbox.Item();
                m.Text = (i + 1).ToString();
                lstspe.Items.Add(m);

                if (CComLibrary.GlobeVal.filesave.dt.Rows[i]["SpeStatus"] == null)
                {
                    CComLibrary.GlobeVal.filesave.dt.Rows[i]["SpeStatus"] = CComLibrary.TestStatus.Untested;
                }

                if (CComLibrary.GlobeVal.filesave.dt.Rows[i]["SpeStatus"] is System.DBNull)
                {
                    CComLibrary.GlobeVal.filesave.dt.Rows[i]["SpeStatus"] = CComLibrary.TestStatus.Untested;
                }

                m.Image = imageList2.Images[Convert.ToInt16(CComLibrary.GlobeVal.filesave.dt.Rows[i]["SpeStatus"])];
            }
            if (GlobeVal.UserControlResult1 != null)
            {
                if (calced == false)
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
                if (calced == false)
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
                if (calced == false)
                {
                    GlobeVal.UserControlSpe1.setspe(CComLibrary.GlobeVal.filesave.currentspenumber + 1, CComLibrary.TestStatus.Untested);
                }
                if (calced == true)
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

                if (GlobeVal.UserControlGraph1.myplotsettings == null)
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

                if (GlobeVal.UserControlGraph2.myplotsettings == null)
                {
                    GlobeVal.UserControlGraph2.Init曲线(2);
                }

            }
        }

        public void OpenDefaultlayout(string filename)
        {
            string _temp = "";


            CComLibrary.FileLayoutStruct f = new CComLibrary.FileLayoutStruct();

            f = f.DeSerializeNow(filename);
            GlobeVal.dynset.tlbetest.Controls.Clear();

            GlobeVal.dynset.tlbetest.RowCount = f.rowcount;
            GlobeVal.dynset.tlbetest.ColumnCount = f.colcount;




            GlobeVal.ShowCameraForm = false;


            for (int k = 0; k < 20; k++)
            {
                if (f.Show[k] == true)
                {
                    _temp = "";
                    if (GlobeVal.mysys.language == 0)
                    {
                        _temp = "曲线图1";
                    }
                    else
                    {
                        _temp = "Graph 1";
                    }
                    if (f.ItemName[k] ==_temp )
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
                    _temp = "";
                    if(GlobeVal.mysys.language ==0)
                    {
                        _temp = "曲线图2";
                    }
                    else
                    {
                        _temp = "Graph 2";
                    }
                    if (f.ItemName[k] ==_temp)
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

                    _temp = "";
                    if (GlobeVal.mysys.language == 0)
                    {
                        _temp = "结果1";
                    }
                    else
                    {
                        _temp = "Result 1";
                    }
                    if (f.ItemName[k] ==_temp )
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

                    _temp = "";
                    if (GlobeVal.mysys.language == 0)
                    {
                        _temp = "结果2";
                    }
                    else
                    {
                        _temp = "Result 2";
                    }
                    if (f.ItemName[k] == _temp )
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
                    _temp = "";
                    if (GlobeVal.mysys.language ==0)
                    {
                        _temp = "原始数据";
                    }
                    else
                    {
                        _temp = "Raw data";
                    }
                    if (f.ItemName[k] ==_temp )
                    {
                        UserControlRawdata ug = new UserControlRawdata();
                        ug.Visible = true;
                        ug.Dock = DockStyle.Fill;
                        GlobeVal.dynset.tlbetest.SetCellPosition(ug, new TableLayoutPanelCellPosition(f.ItemCol[k], f.ItemRow[k]));

                        GlobeVal.dynset.tlbetest.SetColumnSpan(ug, f.ItemColSpan[k]);
                        GlobeVal.dynset.tlbetest.SetRowSpan(ug, f.ItemRowSpan[k]);

                        GlobeVal.dynset.tlbetest.Controls.Add(ug);

                        ug.Init();
                        GlobeVal.UserControlRawdata1 = ug;

                    }

                    _temp = "";
                    if (GlobeVal.mysys.language ==0)
                    {
                        _temp = "试样输入";
                    }
                    else
                    {
                        _temp = "Specimen Input";
                    }
                    if (f.ItemName[k] ==_temp)
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

                    _temp = "";
                    if (GlobeVal.mysys.language ==0)
                    {
                        _temp = "仪表1";
                    }
                    else
                    {
                        _temp = "Meter 1";
                    }
                    if (f.ItemName[k] == _temp)
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


                    _temp = "";
                     
                    if (GlobeVal.mysys.language ==0)
                    {
                        _temp = "仪表2";
                    }
                    else
                    {
                        _temp = "Meter 2";
                    }
                    if (f.ItemName[k] == _temp)
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


                    _temp = "";
                    if (GlobeVal.mysys.language ==0)
                    {
                        _temp = "摄像";
                    }
                    else
                    {
                        _temp = "Camera";
                    }
                    if (f.ItemName[k] == _temp)
                    {
                        UserControlCamera1 ug = new UserControlCamera1();
                        ug.Init();

                        ug.Dock = DockStyle.Fill;
                        GlobeVal.dynset.tlbetest.SetCellPosition(ug, new TableLayoutPanelCellPosition(f.ItemCol[k], f.ItemRow[k]));

                        GlobeVal.dynset.tlbetest.SetColumnSpan(ug, f.ItemColSpan[k]);
                        GlobeVal.dynset.tlbetest.SetRowSpan(ug, f.ItemRowSpan[k]);



                        GlobeVal.dynset.tlbetest.Controls.Add(ug);

                        GlobeVal.UserControlCamera = ug;

                        ug.Visible = true;

                        GlobeVal.ShowCameraForm = true;

                    }

                    _temp = "";
                    if (GlobeVal.mysys.language ==0)
                    {
                        _temp = "过程提示";
                    }
                    else
                    {
                        _temp = "Process Tips";
                    }
                    if (f.ItemName[k] == _temp)
                    {
                        UserControlProcess ug = new UserControlProcess();
                        ug.Init();

                        ug.Dock = DockStyle.Fill;
                        GlobeVal.dynset.tlbetest.SetCellPosition(ug, new TableLayoutPanelCellPosition(f.ItemCol[k], f.ItemRow[k]));

                        GlobeVal.dynset.tlbetest.SetColumnSpan(ug, f.ItemColSpan[k]);
                        GlobeVal.dynset.tlbetest.SetRowSpan(ug, f.ItemRowSpan[k]);



                        GlobeVal.dynset.tlbetest.Controls.Add(ug);
                        GlobeVal.UserControlProcess1 = ug;
                        ug.Visible = true;

                    }

                    _temp = "";
                    if (GlobeVal.mysys.language == 0)
                    {
                        _temp = "状态提示";
                    }
                    else
                    {
                        _temp = "State prompting";
                    }

                    
                    if (f.ItemName[k] == _temp)
                    {
                        UserControlStatus ug = new UserControlStatus();
                        ug.Init();

                        ug.Dock = DockStyle.Fill;
                        GlobeVal.dynset.tlbetest.SetCellPosition(ug, new TableLayoutPanelCellPosition(f.ItemCol[k], f.ItemRow[k]));

                        GlobeVal.dynset.tlbetest.SetColumnSpan(ug, f.ItemColSpan[k]);
                        GlobeVal.dynset.tlbetest.SetRowSpan(ug, f.ItemRowSpan[k]);



                        GlobeVal.dynset.tlbetest.Controls.Add(ug);

                        ug.Visible = true;

                    }

                    _temp = "";
                    if (GlobeVal.mysys.language ==0)
                    {
                        _temp = "峰值趋势数据";
                    }
                    else
                    {
                        _temp = "Trend data";
                    }

                    if (f.ItemName[k] == _temp)
                    {
                        UserControlLongRecord ug = new UserControlLongRecord();
                        ug.Visible = true;
                        ug.Dock = DockStyle.Fill;
                        GlobeVal.dynset.tlbetest.SetCellPosition(ug, new TableLayoutPanelCellPosition(f.ItemCol[k], f.ItemRow[k]));

                        GlobeVal.dynset.tlbetest.SetColumnSpan(ug, f.ItemColSpan[k]);
                        GlobeVal.dynset.tlbetest.SetRowSpan(ug, f.ItemRowSpan[k]);

                        GlobeVal.dynset.tlbetest.Controls.Add(ug);

                        ug.Init();
                        GlobeVal.UserControlLongRecord1 = ug;

                    }


                }
            }



        }

        public void lstspeRefresh()

        {
            lstspe.Items.Clear();

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.testedcount + 1; i++)
            {
                IP.Components.Toolbox.Item m = new IP.Components.Toolbox.Item();
                m.Text = (i + 1).ToString();
                lstspe.Items.Add(m);



                if (CComLibrary.GlobeVal.filesave.dt.Rows[i]["SpeStatus"] is System.DBNull)
                {
                    CComLibrary.GlobeVal.filesave.dt.Rows[i]["SpeStatus"] = CComLibrary.TestStatus.Untested;
                }

                m.Image = imageList2.Images[Convert.ToInt16(CComLibrary.GlobeVal.filesave.dt.Rows[i]["SpeStatus"])];
            }
        }


        private void steprefresh()
        {
            string _temp = "";
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
                if (GlobeVal.mysys.language ==0)
                {
                    _temp = "试样" + (CComLibrary.GlobeVal.filesave.currentspenumber + 1).ToString() + ", 共" + CComLibrary.GlobeVal.filesave.mspecount.ToString();
                }
                else
                {
                    _temp = "Specimen" + (CComLibrary.GlobeVal.filesave.currentspenumber + 1).ToString() + ", Total" + CComLibrary.GlobeVal.filesave.mspecount.ToString();
                }
                GlobeVal.wizard.lblspe1.Text = _temp;
                GlobeVal.wizard.lblspe2.Text = _temp;
                GlobeVal.wizard.lblspe3.Text = _temp;
                GlobeVal.wizard.lblspe4.Text = _temp;
                GlobeVal.wizard.lblspe5.Text = _temp;
                GlobeVal.wizard.lblspe6.Text = _temp;




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
                    GlobeVal.dynset.BackColor = System.Drawing.Color.Cyan;
                    GlobeVal.dynset.tlbetest.Controls.Clear();
                    GlobeVal.dynset.tlbetest.RowCount = 0;
                    GlobeVal.dynset.tlbetest.ColumnCount = 0;
                    GlobeVal.dynset.Dock = DockStyle.None;
                    GlobeVal.UserControlResult1 = null;
                    GlobeVal.UserControlResult2 = null;

                    if (System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\layout\\" + CComLibrary.GlobeVal.filesave.layfilename + ".lay"))
                    {
                        GlobeVal.userControltest1.OpenDefaultlayout(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\layout\\" + CComLibrary.GlobeVal.filesave.layfilename + ".lay");

                    }
                    else
                    {
                        if (GlobeVal.mysys.language == 0)
                        {
                            OpenDefaultlayout(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\layout\\模板1.lay");
                        }
                        else
                        {
                            OpenDefaultlayout(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\layout\\Default.lay");
                        }
                    }
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
                    if (CComLibrary.GlobeVal.filesave.Samplingmode == 0)//静态采集

                    {

                        string mspefiledat = GlobeVal.mysys.SamplePath + "\\" + GlobeVal.mysys.SampleFile + "-" +
                 (CComLibrary.GlobeVal.filesave.currentspenumber + 1).ToString().Trim() + ".txt";
                        CComLibrary.GlobeVal.mscattergraph = GlobeVal.UserControlGraph1.userGraph1.scatterGraph1;

                        CComLibrary.GlobeVal.m_listline.Clear();
                        CComLibrary.GlobeVal.mscattergraph.Annotations.Clear();

                        CComLibrary.GlobeVal.filesave.calc(mspefiledat);//计算数据
                        if (CComLibrary.GlobeVal.filesave.UseDatabase == true)
                        {
                            if (System.IO.Directory.Exists(Application.StartupPath + "\\mdb\\") == true)
                            {
                                System.IO.Directory.CreateDirectory(Application.StartupPath + "\\mdb\\");
                            }
                            CComLibrary.GlobeVal.filesave.samplename = System.IO.Path.GetFileNameWithoutExtension(GlobeVal.spefilename);
                            CComLibrary.GlobeVal.filesave.Init_databaselist(true, CComLibrary.GlobeVal.filesave.currentspenumber);

                            if (System.IO.File.Exists(Application.StartupPath + "\\mdb\\" + CComLibrary.GlobeVal.filesave.methodname + ".mdb") == false)
                            {

                                GlobeVal.NewDatabase();

                            }

                            GlobeVal.SaveDatabase();
                        }

                    }
                    else if (CComLibrary.GlobeVal.filesave.Samplingmode == 1)//动态采集
                    {

                    }
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
                    CComLibrary.GlobeVal.filesave.testedcount = CComLibrary.GlobeVal.filesave.currentspenumber;
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



        private void btnsave_Click(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.SerializeNow(GlobeVal.spefilename);


        }

        private void lstspe_Click(object sender, EventArgs e)
        {

        }

        public void btnStart_Click(object sender, EventArgs e)
        {


            if (GlobeVal.myarm.connected == false)
            {
                if (GlobeVal.mysys.language == 0)
                {
                    MessageBox.Show("请先联机");
                }
                else
                {
                    MessageBox.Show("Please go online first.");
                }
                return;
            }

            if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 3)
            {
                for (int j = 0; j < CComLibrary.GlobeVal.filesave.mseglist.Count; j++)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        CComLibrary.GlobeVal.filesave.mseglist[j].mseq.sampleintervaltemp[i] = 0;
                    }
                }
            }

            if (CComLibrary.GlobeVal.filesave.dt.Rows[CComLibrary.GlobeVal.filesave.currentspenumber]["SpeStatus"] is DBNull)
            {

            }
            else
            {
                /*
                if (CComLibrary.GlobeVal.filesave.Samplingmode == 0)
                {
                    if (Convert.ToInt16(CComLibrary.GlobeVal.filesave.dt.Rows[CComLibrary.GlobeVal.filesave.currentspenumber]["试样状态"]) == Convert.ToInt16(CComLibrary.TestStatus.tested))
                    {
                        DialogResult r = MessageBox.Show("当前试样数据已存在,是否覆盖？", "提示", MessageBoxButtons.YesNo);
                        if (r == DialogResult.Yes)
                        {

                        }
                        else
                        {
                            return;
                        }
                    }
                }
                */
            }



            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem.Count; i++)
            {
                CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem[i].getvalue();

            }

            bool mb = false;

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem.Count; i++)
            {

               mb= CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem[i].checkzero();

                if(mb==true)
                {


                    return;

                   
                }
            }

           

                if (CComLibrary.GlobeVal.filesave.mwizard == true)
            {
                if (btneafter.Enabled == false)
                {
                    btneafter_Click(null, null);
                    btnStart.Enabled = false;
                    btnStart.BackgroundImage = imageList4.Images[1];
                    btnStart.Refresh();

                    btnend.Enabled = true;
                    btnend.BackgroundImage = imageList4.Images[2];
                    btnend.Refresh();
                }
                else
                {
                    if (GlobeVal.mysys.language == 0)
                    {
                        MessageBox.Show("请点击下一步继续");
                    }
                    else
                    {
                        MessageBox.Show("Please click next to continue.");
                    }
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
                if ((GlobeVal.ShowCameraForm == true) && (CComLibrary.GlobeVal.filesave.mplay == true) && (CComLibrary.GlobeVal.filesave.mplayfile == true))
                {



                    if (System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\demo\\" + CComLibrary.GlobeVal.filesave.play_avi_datafile) == true)
                    {

                        if (GlobeVal.UserControlCamera != null)
                        {
                            GlobeVal.UserControlCamera.play();
                        }

                    }
                }

            }
            else
            {

            }

            if (GlobeVal.UserControlSpe1 != null)
            {
                GlobeVal.UserControlSpe1.SetEnabled(false);

            }


            for (int i = 0; i < CComLibrary.GlobeVal.filesave.numintervallast.Length; i++)
            {
                CComLibrary.GlobeVal.filesave.numintervallast[i] = 0;
            }

            CComLibrary.GlobeVal.filesave.endoftest1tempmax = 0;
            CComLibrary.GlobeVal.filesave.endoftest1tempbool = false;
            CComLibrary.GlobeVal.filesave.endoftest2tempbool = false;
            CComLibrary.GlobeVal.filesave.endoftest2tempmax = 0;

            GlobeVal.myarm.cleartime();

            double t1 = Environment.TickCount;
            while (Environment.TickCount - t1 < 500)

            {
                Application.DoEvents();
            }

            if (GlobeVal.UserControlGraph1 != null)
            {
              if  (GlobeVal.UserControlGraph1.startrun()==false)
                {
                    btnStart.Enabled = true;
                    btnStart.BackgroundImage = imageList4.Images[0];
                    btnStart.Refresh();
                    btnend.Enabled = false;
                    btnend.BackgroundImage = imageList4.Images[3];
                    btnend.Refresh();


                    if (GlobeVal.myarm.mdemo == true)
                    {

                        GlobeVal.myarm.demotest(false);

                        if ((GlobeVal.ShowCameraForm == true) && (CComLibrary.GlobeVal.filesave.mplay == true) && (CComLibrary.GlobeVal.filesave.mplayfile == true))
                        {



                            if (System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\demo\\" + CComLibrary.GlobeVal.filesave.play_avi_datafile) == true)
                            {
                                if (GlobeVal.UserControlCamera != null)
                                {
                                    GlobeVal.UserControlCamera.stop();
                                }
                            }
                        }
                    }
                    else
                    {

                    }
                    if (GlobeVal.UserControlSpe1 != null)
                    {
                        GlobeVal.UserControlSpe1.SetEnabled(true);
                        GlobeVal.UserControlSpe1.btnright.Enabled = true;

                    }

                    return;
                }
            }

            if (GlobeVal.UserControlGraph2 != null)
            {
              
              if (  GlobeVal.UserControlGraph2.startrun()==false)
                {
                    btnStart.Enabled = true;
                    btnStart.BackgroundImage = imageList4.Images[0];
                    btnStart.Refresh();
                    btnend.Enabled = false;
                    btnend.BackgroundImage = imageList4.Images[3];
                    btnend.Refresh();

                    return;
                }
            }


            GlobeVal.myarm.starttest(CComLibrary.GlobeVal.filesave.currentspenumber + 1);

            if (GlobeVal.myarm.mtestrun == false)
            {
                btnStart.Enabled = true;
                btnStart.BackgroundImage = imageList4.Images[0];
                btnStart.Refresh();
                btnend.Enabled = false;
                btnend.BackgroundImage = imageList4.Images[3];
                btnend.Refresh();

                if (GlobeVal.UserControlGraph1 != null)
                {
                    GlobeVal.UserControlGraph1.endrun();
                }

                if (GlobeVal.UserControlGraph2 != null)
                {
                    GlobeVal.UserControlGraph2.endrun();
                }
                return;
            }





            timer1.Enabled = true;
            GlobeVal.MainStatusStrip.Items["toolstatustest"].Visible = true;

            GlobeVal.UserControlMain1.btnmmethod.Visible = false;
            GlobeVal.UserControlMain1.btnmreport.Visible = false;
            GlobeVal.UserControlMain1.btnmmanage.Visible = false;
            GlobeVal.UserControlMain1.btnmain.Visible = false;


            if (GlobeVal.mysys.language ==0)
            {
                GlobeVal.MainStatusStrip.Items["tslblstate"].Text = "状态：运行";
            }
           
            else
            {
                GlobeVal.MainStatusStrip.Items["tslblstate"].Text = "Status: run";
            }
            GlobeVal.MainStatusStrip.Items["tslblstate"].Image = GlobeVal.FormmainLab.imageListState.Images[1];

            lstspe.Items[CComLibrary.GlobeVal.filesave.currentspenumber].Image = imageList2.Images[4];
            lstspe.Refresh();

            TabControl b = ((TabControl)Application.OpenForms["FormMainLab"].Controls["tabcontrol1"]);
            ((SplitContainer)b.TabPages[1].Controls[0]).Panel2Collapsed = true;

        }

        public void btnend_Click(object sender, EventArgs e)
        {

            timer1.Enabled = false;

            string mspefiledat;

            CComLibrary.GlobeVal.filesave.dt.Rows[CComLibrary.GlobeVal.filesave.currentspenumber]["SpeStatus"] = CComLibrary.TestStatus.tested;

            CComLibrary.GlobeVal.filesave.lasttestdatatime = System.DateTime.Now.ToString();

            if (GlobeVal.UserControlSpe1 != null)
            {
                GlobeVal.UserControlSpe1.SetEnabled(true);
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




            if (GlobeVal.myarm.mdemo == true)
            {

                GlobeVal.myarm.demotest(false);

                if ((GlobeVal.ShowCameraForm == true) && (CComLibrary.GlobeVal.filesave.mplay == true) && (CComLibrary.GlobeVal.filesave.mplayfile == true))
                {



                    if (System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\demo\\" + CComLibrary.GlobeVal.filesave.play_avi_datafile) == true)
                    {
                        if (GlobeVal.UserControlCamera != null)
                        {
                            GlobeVal.UserControlCamera.stop();
                        }
                    }
                }
            }
            else
            {

            }

            GlobeVal.myarm.endtest();






            if (CComLibrary.GlobeVal.filesave.mwizard == true)
            {
                btneafter.Enabled = true;

                btnStart.Enabled = true;
                btnStart.BackgroundImage = imageList4.Images[0];
                btnStart.Refresh();

                btnend.Enabled = false;
                btnend.BackgroundImage = imageList4.Images[3];
                btnend.Refresh();
                // FreeFormRefresh(true, false);
                btneafter_Click(null, null);


            }
            else
            {
                btnStart.Enabled = true;
                btnStart.BackgroundImage = imageList4.Images[0];
                btnStart.Refresh();
                btnend.Enabled = false;
                btnend.BackgroundImage = imageList4.Images[3];
                btnend.Refresh();


                if (CComLibrary.GlobeVal.filesave.Samplingmode == 0)//静态采集

                {

                    mspefiledat = GlobeVal.mysys.SamplePath + "\\" + GlobeVal.mysys.SampleFile + "-" +
           (CComLibrary.GlobeVal.filesave.currentspenumber + 1).ToString().Trim() + ".txt";
                    CComLibrary.GlobeVal.mscattergraph = GlobeVal.UserControlGraph1.userGraph1.scatterGraph1;

                    CComLibrary.GlobeVal.m_listline.Clear();
                    CComLibrary.GlobeVal.mscattergraph.Annotations.Clear();
                  
                    CComLibrary.GlobeVal.filesave.calc(mspefiledat);//计算数据
                    if (CComLibrary.GlobeVal.filesave.UseDatabase == true)
                    {
                        if (System.IO.Directory.Exists(Application.StartupPath + "\\mdb\\") == true)
                        {
                            System.IO.Directory.CreateDirectory(Application.StartupPath + "\\mdb\\");
                        }
                        CComLibrary.GlobeVal.filesave.samplename = System.IO.Path.GetFileNameWithoutExtension(GlobeVal.spefilename);
                        CComLibrary.GlobeVal.filesave.Init_databaselist(true, CComLibrary.GlobeVal.filesave.currentspenumber);

                        if (System.IO.File.Exists(Application.StartupPath + "\\mdb\\" + CComLibrary.GlobeVal.filesave.methodname + ".mdb") == false)
                        {
                            GlobeVal.NewDatabase();

                        }

                        GlobeVal.SaveDatabase();
                    }


                }
                else if (CComLibrary.GlobeVal.filesave.Samplingmode == 1)//动态采集
                {

                }
                FreeFormRefresh(true, false);

                if (GlobeVal.myarm.duanliebaohu == true)
                {
                    if (GlobeVal.mysys.language == 0)
                    {
                        GlobeVal.MainStatusStrip.Items["tslblstate"].Text = "状态：断裂保护,停止";
                    }
                    else
                    {
                        GlobeVal.MainStatusStrip.Items["tslblstate"].Text = "Status: fracture protection, stop";
                    }
                    GlobeVal.MainStatusStrip.Items["tslblstate"].Image = GlobeVal.FormmainLab.imageListState.Images[0];

                }
                else
                {
                    if (GlobeVal.mysys.language == 0)
                    {
                        GlobeVal.MainStatusStrip.Items["tslblstate"].Text = "状态：停止";
                    }
                    else
                    {
                        GlobeVal.MainStatusStrip.Items["tslblstate"].Text = "Status: stop";
                    }

                    GlobeVal.MainStatusStrip.Items["tslblstate"].Image = GlobeVal.FormmainLab.imageListState.Images[0];
                }


            }

            CComLibrary.GlobeVal.filesave.SerializeNow(GlobeVal.spefilename);

            if (CComLibrary.GlobeVal.m_test == false)
            {
                GlobeVal.UserControlGraph1.scatterGraph.Annotations.Clear();
                for (int i = 0; i < CComLibrary.GlobeVal.m_listline.Count; i++)
                {
                    if (CComLibrary.GlobeVal.m_listline[i].kind == 0)
                    {

                        GlobeVal.UserControlGraph1.userGraph1.drawsign(CComLibrary.GlobeVal.m_listline[i].xstart, CComLibrary.GlobeVal.m_listline[i].ystart, CComLibrary.GlobeVal.m_listline[i]);



                    }
                    else if (CComLibrary.GlobeVal.m_listline[i].kind == 1)
                    {
                        GlobeVal.UserControlGraph1.userGraph1.drawline(CComLibrary.GlobeVal.m_listline[i].xstart, CComLibrary.GlobeVal.m_listline[i].ystart,
                             CComLibrary.GlobeVal.m_listline[i].xend, CComLibrary.GlobeVal.m_listline[i].yend, CComLibrary.GlobeVal.m_listline[i]);


                    }

                }

            }

            if ((CComLibrary.GlobeVal.filesave.mcontrolprocess == 3) && (CComLibrary.GlobeVal.filesave.Samplingmode == 1))  //高级试验保存分段条件状态
            {
                CComLibrary.SequenceFile sqf = new CComLibrary.SequenceFile();
                if ((GlobeVal.myarm.mcurseg >= 0) && (GlobeVal.myarm.mcurseg < CComLibrary.GlobeVal.filesave.mseglist.Count))
                {
                    CComLibrary.GlobeVal.filesave.mseglist[GlobeVal.myarm.mcurseg].mseq.mfinishedcount = GlobeVal.myarm.count;
                }
                for (int i = 0; i < CComLibrary.GlobeVal.filesave.mseglist.Count; i++)
                {
                    sqf.add(CComLibrary.GlobeVal.filesave.mseglist[i].mseq);
                }
                sqf.SerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ\\sequence\\" + CComLibrary.GlobeVal.filesave.SequenceName);

            }

            GlobeVal.MainStatusStrip.Items["toolstatustest"].Visible = false;

            GlobeVal.UserControlMain1.btnmmethod.Visible = true;
            if (GlobeVal.mysys.machinekind == 0)
            {
                GlobeVal.UserControlMain1.btnmreport.Visible = true;
                GlobeVal.UserControlMain1.btnmmanage.Visible = true;
            }
            else
            {
                GlobeVal.UserControlMain1.btnmreport.Visible = false;
                GlobeVal.UserControlMain1.btnmmanage.Visible = false;
            }
            GlobeVal.UserControlMain1.btnmain.Visible = true;
            GlobeVal.dopanel.Visible = false;
            TabControl b = ((TabControl)Application.OpenForms["FormMainLab"].Controls["tabcontrol1"]);
            ((SplitContainer)b.TabPages[1].Controls[0]).Panel2Collapsed = false;


            double t1 = Environment.TickCount;
            while (Environment.TickCount - t1 < 5)
            {
                // Application.DoEvents();
            }
            GlobeVal.dopanel.Visible = true;


        }

        private void btnfinish_Click(object sender, EventArgs e)
        {
            ((TabControl)Application.OpenForms["FormMainLab"].Controls["tabcontrol1"]).SelectedIndex = 0;

            if (GlobeVal.mysys.language == 0)
            {
                GlobeVal.MainStatusStrip.Items["tslblkind"].Text = "试验类型：空";
                GlobeVal.MainStatusStrip.Items["tslblsample"].Text = "样品：关闭";

                GlobeVal.MainStatusStrip.Items["tslblmethod"].Text = "方法:关闭";
            }
            else
            {
                GlobeVal.MainStatusStrip.Items["tslblkind"].Text = "Test Type：None";
                GlobeVal.MainStatusStrip.Items["tslblsample"].Text = "Sample ：Closed";

                GlobeVal.MainStatusStrip.Items["tslblmethod"].Text = "Method:Closed";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {





            if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 0)
            {
                if (GlobeVal.mysys.language == 0)
                {
                    GlobeVal.MainStatusStrip.Items["toolstatustest"].Text = "一般测控";
                }
                else
                {
                    GlobeVal.MainStatusStrip.Items["toolstatustest"].Text = "General test";
                }

            }

            else if ((CComLibrary.GlobeVal.filesave.mcontrolprocess == 1) || (CComLibrary.GlobeVal.filesave.mcontrolprocess == 3))
            {
                if ((GlobeVal.myarm.mcurseg + 1) > CComLibrary.GlobeVal.filesave.mseglist.Count)
                {
                    btnend_Click(null, null);
                }
                if (GlobeVal.myarm.keepingstate == true)
                {

                    if (GlobeVal.mysys.language == 0)
                    {

                        GlobeVal.MainStatusStrip.Items["toolstatustest"].Text = "高级测控：步骤" + (GlobeVal.myarm.mcurseg + 1).ToString()
                            + "当前保持时间:" + GlobeVal.myarm.keepingtime.ToString("F1") + "秒";
                    }
                    else
                    {
                        GlobeVal.MainStatusStrip.Items["toolstatustest"].Text = "Advanced test：Step" + (GlobeVal.myarm.mcurseg + 1).ToString()
                           + "Current hold time:" + GlobeVal.myarm.keepingtime.ToString("F1") + "S";
                    }
                }
                else
                {
                    GlobeVal.MainStatusStrip.Items["toolstatustest"].Text = "Advanced test：Step" + (GlobeVal.myarm.mcurseg + 1).ToString();

                }




                if (GlobeVal.myarm.total_returncount > 0)
                {
                    if (GlobeVal.mysys.language == 0)
                    {
                        GlobeVal.MainStatusStrip.Items["toolstatustest"].Text =
                            GlobeVal.MainStatusStrip.Items["toolstatustest"].Text + " "
                            + "当前次数：" + GlobeVal.myarm.current_returncount.ToString() +
                            "总循环次数：" + GlobeVal.myarm.total_returncount.ToString();
                    }
                    else
                    {
                        GlobeVal.MainStatusStrip.Items["toolstatustest"].Text =
                          GlobeVal.MainStatusStrip.Items["toolstatustest"].Text + " "
                          + "Current times：" + GlobeVal.myarm.current_returncount.ToString() +
                          "Total times：" + GlobeVal.myarm.total_returncount.ToString();
                    }

                }


            }

            if (btnStart.Enabled == false)
            {



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
            if (Screen.PrimaryScreen.Bounds.Width == 1366)
            {
                splitContainer1.SplitterDistance = 40;
                tableLayoutPanelback.ColumnStyles[0].Width = 30;
            }
            else
            {
                splitContainer1.SplitterDistance = 100;
                tableLayoutPanelback.ColumnStyles[0].Width = 50;
            }

            imageList4.Images.Clear();
            imageList4.Images.Add(TabHeaderDemo.Properties.Resources._50);
            imageList4.Images.Add(TabHeaderDemo.Properties.Resources._50_1);
            imageList4.Images.Add(TabHeaderDemo.Properties.Resources.r2_2);
            imageList4.Images.Add(TabHeaderDemo.Properties.Resources.r2);

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
                if (GlobeVal.mysys.language == 0)
                {
                    MessageBox.Show("方法中没设置报告打印");
                }
                else
                {
                    MessageBox.Show("Report print setup does not exist in the method.");
                }
                return;
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

        private void tableLayoutPanelback_Resize(object sender, EventArgs e)
        {
            splitContainer1.Dock = DockStyle.None;
            splitContainer1.Dock = DockStyle.Fill;
        }

        private void paneltestright_SizeChanged_1(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void lstspe_Click_1(object sender, EventArgs e)
        {

        }

        private void lstspe_ContextMenuStripChanged(object sender, EventArgs e)
        {

        }

        private void 重新计算当前试样ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mspefiledat = "";


            int num = 0;

            if (lstspe.SelectedItem == null)
            {
                return;
            }


            num = Convert.ToInt16(lstspe.SelectedItem.Text);

            if (CComLibrary.GlobeVal.filesave.dt.Rows[num - 1]["SpeStatus"] is DBNull)
            {
                if (GlobeVal.mysys.language == 0)
                {
                    
                    MessageBox.Show("试验完成后才能计算");
                }

                else
                {
                    MessageBox.Show("Only after the test is completed can it be calculated.");
                }
                return;
            }
            else
            {
                if (Convert.ToInt16(CComLibrary.GlobeVal.filesave.dt.Rows[num - 1]["SpeStatus"]) == Convert.ToInt16(CComLibrary.TestStatus.Untested))
                {
                    if (GlobeVal.mysys.language == 0)
                    {
                        MessageBox.Show("试验完成后才能计算");
                    }
                    else
                    {
                        MessageBox.Show("Only after the test is completed can it be calculated.");
                    }
                    return;
                }
            }



            mspefiledat = GlobeVal.mysys.SamplePath + "\\" + GlobeVal.mysys.SampleFile + "-" +
          (num).ToString().Trim() + ".txt";

            CComLibrary.GlobeVal.mscattergraph = GlobeVal.UserControlGraph1.userGraph1.scatterGraph1;






            CComLibrary.GlobeVal.m_listline.Clear();
            CComLibrary.GlobeVal.mscattergraph.Annotations.Clear();

            CComLibrary.GlobeVal.filesave.calc(mspefiledat);//计算数据
            if (CComLibrary.GlobeVal.filesave.UseDatabase == true)
            {
                if (System.IO.Directory.Exists(Application.StartupPath + "\\mdb\\") == true)
                {
                    System.IO.Directory.CreateDirectory(Application.StartupPath + "\\mdb\\");
                }
                CComLibrary.GlobeVal.filesave.samplename = System.IO.Path.GetFileNameWithoutExtension(GlobeVal.spefilename);
                CComLibrary.GlobeVal.filesave.Init_databaselist(true, num - 1);

                if (System.IO.File.Exists(Application.StartupPath + "\\mdb\\" + CComLibrary.GlobeVal.filesave.methodname + ".mdb") == false)
                {
                    GlobeVal.NewDatabase();

                }

                GlobeVal.SaveDatabase();
            }


            if (GlobeVal.UserControlResult1 != null)
            {
                GlobeVal.UserControlResult1.ReCalcGrid(1, true, false, CComLibrary.GlobeVal.filesave.mtablecol1, CComLibrary.GlobeVal.filesave.mtable1para,
                CComLibrary.GlobeVal.filesave.mtable1statistics, num - 1);
            }

            if (GlobeVal.UserControlResult2 != null)
            {
                GlobeVal.UserControlResult2.ReCalcGrid(2, true, false, CComLibrary.GlobeVal.filesave.mtablecol2, CComLibrary.GlobeVal.filesave.mtable2para,
                CComLibrary.GlobeVal.filesave.mtable2statistics, num - 1);
            }


            if (GlobeVal.UserControlGraph1 != null)
            {
                GlobeVal.UserControlGraph1.userGraph1.Init();
            }

            if (GlobeVal.UserControlGraph2 != null)
            {
                GlobeVal.UserControlGraph2.userGraph1.Init();
            }


            // FreeFormRefresh(true, false);



            CComLibrary.GlobeVal.filesave.SerializeNow(GlobeVal.spefilename);

            if (CComLibrary.GlobeVal.m_test == false)
            {
                GlobeVal.UserControlGraph1.scatterGraph.Annotations.Clear();
                for (int i = 0; i < CComLibrary.GlobeVal.m_listline.Count; i++)
                {
                    if (CComLibrary.GlobeVal.m_listline[i].kind == 0)
                    {

                        GlobeVal.UserControlGraph1.userGraph1.drawsign(CComLibrary.GlobeVal.m_listline[i].xstart, CComLibrary.GlobeVal.m_listline[i].ystart, CComLibrary.GlobeVal.m_listline[i]);



                    }
                    else if (CComLibrary.GlobeVal.m_listline[i].kind == 1)
                    {
                        GlobeVal.UserControlGraph1.userGraph1.drawline(CComLibrary.GlobeVal.m_listline[i].xstart, CComLibrary.GlobeVal.m_listline[i].ystart,
                             CComLibrary.GlobeVal.m_listline[i].xend, CComLibrary.GlobeVal.m_listline[i].yend, CComLibrary.GlobeVal.m_listline[i]);


                    }

                }

            }

        }

        private void 试验数据导出为ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mspefiledat = "";
            string firstline = "";
            string secondline = "";

            int i = 0;

            int num = 0;

            if (lstspe.SelectedItem == null)
            {
                return;
            }


            num = Convert.ToInt16(lstspe.SelectedItem.Text);

            if (CComLibrary.GlobeVal.filesave.dt.Rows[num - 1]["SpeStatus"] is DBNull)
            {
                if (GlobeVal.mysys.language == 0)
                {
                    MessageBox.Show("试验完成后数据才能导出到Excel");
                }
                else
                {
                    MessageBox.Show("Data can only be exported to Excel after completion of test.");
                }
                return;
            }
            else
            {
                if (Convert.ToInt16(CComLibrary.GlobeVal.filesave.dt.Rows[num - 1]["SpeStatus"]) == Convert.ToInt16(CComLibrary.TestStatus.Untested))
                {
                    if (GlobeVal.mysys.language == 0)
                    {
                        MessageBox.Show("试验完成后数据才能导出到Excel");
                    }
                    else
                    {
                        MessageBox.Show("Data can only be exported to Excel after completion of test.");
                    }
                    return;
                }
            }

            mspefiledat = GlobeVal.mysys.SamplePath + "\\" + GlobeVal.mysys.SampleFile + "-" +
       (num).ToString().Trim() + ".txt";

            StreamReader m_streamReader = new StreamReader(mspefiledat, System.Text.Encoding.Default);

            XlsDocument xls = new XlsDocument();
            Worksheet sheet = xls.Workbook.Worksheets.Add("sheet1");

            try
            {
                //使用StreamReader类来读取文件
                m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                // 从数据流中读取每一行，直到文件的最后一行，并在richTextBox1中显示出内容


                string strLine = "";

                char[] sp;
                char[] sp1;
                string[] ww;
                bool r = true;

                sp = new char[2];
                sp1 = new char[2];

                sp[0] = Convert.ToChar(" ");




                i = 0;
                while (r == true)
                {

                    strLine = m_streamReader.ReadLine();



                    if (strLine == null)
                    {
                        r = false;

                    }
                    else
                    {

                        ww = strLine.Split(sp);

                        for (int j = 0; j < ww.Length; j++)
                        {
                            sheet.Cells.Add(i + 1, j + 1, ww[j].ToString());
                        }
                        i = i + 1;
                    }

                }
                //关闭此StreamReader对象
                m_streamReader.Close();


                // legend.Items[curvescount - 1].Text = fileName;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (GlobeVal.mysys.language == 0)
            {
                xls.FileName = Application.StartupPath + "\\ExcelData\\" + "导出数据.xls";
            }
            else
            {
                xls.FileName = Application.StartupPath + "\\ExcelData\\" + " ExportData.xls";
            }
            if (File.Exists(xls.FileName))
            {
                File.Delete(xls.FileName);
            }
            xls.Save();

            if (GlobeVal.mysys.language == 0)
            {
                MessageBox.Show("数据已经导出到" + xls.FileName);
            }
            else
            {
                MessageBox.Show("Data has been exported to" + xls.FileName);
            }

        }

        private void btnsaveas_Click(object sender, EventArgs e)
        {

        }
    }
}
