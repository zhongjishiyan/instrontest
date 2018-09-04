using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections;

using System.Diagnostics;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using NationalInstruments.UI;
using NationalInstruments.UI.WindowsForms;

using System.Reflection;
namespace TabHeaderDemo
{
    public partial class UserReport : UserControl
    {
        private UserControl报告常规 UserControl报告常规1;


        public Document document = new Document();


        public ReportApp mReportApp = new ReportApp();

        public Section section;

        private string mcurfilename = "";

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
        public UserReport()
        {
            InitializeComponent();
            treeView1.mimagelist = imageList2;


            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲


            this.tableLayoutPanel1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel1, true, null);
            this.tableLayoutPanel2.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel2, true, null);
            this.tableLayoutPanel3.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel3, true, null);
            treeView1.Nodes.Clear();

            if (GlobeVal.mysys.language == 0)
            {
                treeView1.Nodes.Add("报告", "报告");
                treeView1.Nodes["报告"].StateImageIndex = 0;

                treeView1.Nodes["报告"].Nodes.Add("常规");
                treeView1.Nodes["报告"].Nodes.Add("页眉");
                treeView1.Nodes["报告"].Nodes.Add("正文");
                treeView1.Nodes["报告"].Nodes.Add("页脚");
            }
            else
            {
                treeView1.Nodes.Add("Report", "Report");
                treeView1.Nodes["Report"].StateImageIndex = 0;

                treeView1.Nodes["Report"].Nodes.Add("General");
                treeView1.Nodes["Report"].Nodes.Add("Header");
                treeView1.Nodes["Report"].Nodes.Add("Body");
                treeView1.Nodes["Report"].Nodes.Add("Footer");

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

                methodon(e.Node.Nodes[0].Text, e.Node.Text);
            }
        }

        public void methodon(String t, String parent)
        {
            string _temp = "";
            if (GlobeVal.mysys.language == 0)
            {
                _temp = "常规";
            }
            else
            {
                _temp = "General";
            }
            if (t == _temp )
            {
                if (CComLibrary.GlobeVal.filesave != null)
                {


                }
                UserControl报告常规1.Init(0);


            }
            if (GlobeVal.mysys.language == 0)
            {
                _temp = "页眉";
            }
            else
            {
                _temp = "Header";
            }


            if (t == _temp )
            {
                UserControl报告常规1.Init(1);

                /*

                UserControl报告页眉1.Init(0);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl报告页眉1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl报告页眉1);
                panelback.Visible = true;
                */
            }

            if (GlobeVal.mysys.language == 0)
            {
                _temp = "正文";
            }
            else
            {
                _temp = "Body";
            }

            if (t == _temp )
            {
                UserControl报告常规1.Init(2);


                /*
                UserControl报告正文1.Init(0);
                panelback.Visible = false;
                panelback.Controls.Clear();
                UserControl报告正文1.Dock = DockStyle.Fill;
                panelback.Controls.Add(UserControl报告正文1);
                panelback.Visible = true;
                 */
            }

            if (GlobeVal.mysys.language == 0)
            {
                _temp = "页脚";
            }
            else
            {
                _temp = "Footer";
            }

            if (t == _temp)
            {
                UserControl报告常规1.Init(3);


                /*
               UserControl报告页脚1.Init(0);
               panelback.Visible = false;
               panelback.Controls.Clear();
               UserControl报告页脚1.Dock = DockStyle.Fill;
               panelback.Controls.Add(UserControl报告页脚1);
               panelback.Visible = true;
                 */
            }

        }



        private void buttonEx1_Click(object sender, EventArgs e)
        {



            dialog.PrinterSettings.FromPage = 1;
            printpage(false);





        }




        private void buttonEx2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonEx2_Click_1(object sender, EventArgs e)
        {

        }

        private void UserReport_Load(object sender, EventArgs e)
        {
            GlobeVal.muserreport = this;
            UserControl报告常规1 = new UserControl报告常规();



            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲


            UserControl报告常规1.Init(0);
            panelback.Visible = false;
            panelback.Controls.Clear();
            UserControl报告常规1.Dock = DockStyle.Fill;
            panelback.Controls.Add(UserControl报告常规1);
            panelback.Visible = true;

            if (System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\report\\" + CComLibrary.GlobeVal.filesave.ReportTemplate) == true)
            {
                mcurfilename = CComLibrary.GlobeVal.filesave.ReportTemplate;
                mReportApp = mReportApp.DeSerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\report\\" + CComLibrary.GlobeVal.filesave.ReportTemplate);

            }

            treeView1.SelectedNode = treeView1.Nodes[0];



        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                methodon(e.Node.Text, "");
            }
            else
            {
                methodon(e.Node.Text, e.Node.Parent.Text);
                treeView1.SelectedNode = e.Node;
            }

        }

        private void InsertImage(Section section, int id)
        {
            if (id == 1)
            {
                if (GlobeVal.UserControlGraph1 == null)
                {
                    return;
                }


                Paragraph paragraph;




                paragraph = section.AddParagraph();
                paragraph.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Center;
                Bitmap im;

                int w;
                int h;


                Control b = GlobeVal.UserControlGraph1.Parent;

                GlobeVal.UserControlGraph1.Parent = null;

                GlobeVal.UserControlGraph1.Dock = DockStyle.None;
                GlobeVal.UserControlGraph1.lblcaption.Visible = false;
                System.Threading.Thread.Sleep(10);


                GlobeVal.UserControlGraph1.Width = 800;
                GlobeVal.UserControlGraph1.Height = 600;

                w = GlobeVal.UserControlGraph1.Width;
                h = GlobeVal.UserControlGraph1.Height;
                im = new System.Drawing.Bitmap(w,
                    h, System.Drawing.Imaging.PixelFormat.Format32bppArgb);



                GlobeVal.UserControlGraph1.DrawToBitmap(im, new Rectangle(0, 0, im.Width, im.Height));

                DocPicture p = paragraph.AppendPicture(im);

                p.Width = section.PageSetup.PageSize.Width - section.PageSetup.Margins.Left - section.PageSetup.Margins.Right;
                p.Height = section.PageSetup.PageSize.Height / 3;

                im.Dispose();

                System.Threading.Thread.Sleep(10);
                GlobeVal.UserControlGraph1.Dock = DockStyle.Fill;
                GlobeVal.UserControlGraph1.lblcaption.Visible = true;
                GlobeVal.UserControlGraph1.Parent = b;
            }

            if (id == 2)
            {
                if (GlobeVal.UserControlGraph2 == null)
                {
                    return;
                }


                Paragraph paragraph;

                paragraph = section.AddParagraph();


                paragraph.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Center;
                Bitmap im;
                int w;
                int h;

                Control b = GlobeVal.UserControlGraph2.Parent;

                GlobeVal.UserControlGraph2.Parent = null;

                GlobeVal.UserControlGraph2.Dock = DockStyle.None;
                GlobeVal.UserControlGraph2.lblcaption.Visible = false;
                System.Threading.Thread.Sleep(10);
                GlobeVal.UserControlGraph2.Width = 800;
                GlobeVal.UserControlGraph2.Height = 600;

                w = GlobeVal.UserControlGraph2.Width;
                h = GlobeVal.UserControlGraph2.Height;

                im = new System.Drawing.Bitmap(w,

                    h, System.Drawing.Imaging.PixelFormat.Format32bppArgb);



                GlobeVal.UserControlGraph2.DrawToBitmap(im,
                    new Rectangle(0, 0, im.Width,
                        im.Height));

                DocPicture p = paragraph.AppendPicture(im);

                p.Width = section.PageSetup.PageSize.Width - section.PageSetup.Margins.Left - section.PageSetup.Margins.Right;
                p.Height = section.PageSetup.PageSize.Height / 3;

                im.Dispose();

                System.Threading.Thread.Sleep(10);
                GlobeVal.UserControlGraph2.Dock = DockStyle.Fill;
                GlobeVal.UserControlGraph2.lblcaption.Visible = true;
                GlobeVal.UserControlGraph2.Parent = b;
            }


        }
        private void addTable(Section section, int id)
        {


            String[] header = new String[CComLibrary.GlobeVal.filesave.mtablecol1.Count + 1];

            header[0] = CComLibrary.GlobeVal.filesave.dt.Columns[0].ColumnName; //_序号

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mtablecol1.Count; i++)
            {
                header[i + 1] = CComLibrary.GlobeVal.filesave.mtablecol1[i].formulaname + "(" +
                        CComLibrary.GlobeVal.filesave.mtablecol1[i].myitemsignal.cUnits[
                        CComLibrary.GlobeVal.filesave.mtablecol1[i].myitemsignal.cUnitsel] + ")";
            }




            int wt = 0;

            for (int i = 1; i <= CComLibrary.GlobeVal.filesave.mtable1statistics.Count; i++)
            {
                if (CComLibrary.GlobeVal.filesave.mtable1statistics[i - 1].selected == true)
                {
                    wt = wt + 1;
                }
            }

            String[][] data = new String[CComLibrary.GlobeVal.filesave.currentspenumber + 1 + wt][];

            for (int i = 1; i <= CComLibrary.GlobeVal.filesave.currentspenumber + 1 + wt; i++)
            {
                data[i - 1] = new String[CComLibrary.GlobeVal.filesave.mtablecol1.Count + 1];
            }

            for (int i = 1; i <= CComLibrary.GlobeVal.filesave.currentspenumber + 1; i++)
            {

                data[i - 1][0] = i.ToString();
                for (int j = 0; j < CComLibrary.GlobeVal.filesave.mtablecol1.Count; j++)
                {
                    float t = 0;

                    string s = "";


                    //历史出错

                    if (CComLibrary.GlobeVal.filesave.dt.Rows[i - 1][CComLibrary.GlobeVal.filesave.mtablecol1[j].formulaname] is DBNull)
                    {
                        CComLibrary.GlobeVal.filesave.dt.Rows[i - 1][CComLibrary.GlobeVal.filesave.mtablecol1[j].formulaname] = 0;
                    }
                    t = Convert.ToSingle(CComLibrary.GlobeVal.filesave.dt.Rows[i - 1][CComLibrary.GlobeVal.filesave.mtablecol1[j].formulaname]);


                    s = t.ToString("F" + CComLibrary.GlobeVal.filesave.mtablecol1[j].myitemsignal.precise.ToString().Trim());

                    if (CComLibrary.GlobeVal.filesave.mtablecol1[j].myitemsignal.cUnitKind == 19)
                    {
                        s = "";
                    }

                    data[i - 1][j + 1] = s;

                }

            }

            int mt = CComLibrary.GlobeVal.filesave.currentspenumber + 1;
            for (int i = 1; i <= CComLibrary.GlobeVal.filesave.mtable1statistics.Count; i++)
            {
                if (CComLibrary.GlobeVal.filesave.mtable1statistics[i - 1].selected == true)
                {




                    data[mt][0] = CComLibrary.GlobeVal.filesave.mtable1statistics[i - 1].formulaname;



                    for (int j = 0; j < CComLibrary.GlobeVal.filesave.mtablecol1.Count; j++)
                    {


                        float t = 0;

                        string s = "";







                        if (CComLibrary.GlobeVal.filesave.dt.Columns[CComLibrary.GlobeVal.filesave.mtablecol1[j].formulaname].DataType == Type.GetType("System.String"))
                        {
                            s = "---";
                        }
                        else
                        {
                            string _temp = "";
                            if (GlobeVal.mysys.language ==0)
                            {
                                _temp = "最小值";
                            }
                            else
                            {
                                _temp = "Min";
                            }

                            if (CComLibrary.GlobeVal.filesave.mtable1statistics[i - 1].formulaname == _temp )
                            {
                                // t = Convert.ToSingle(CComLibrary.GlobeVal.filesave.dt.Compute("min(" + CComLibrary.GlobeVal.filesave.mtablecol1[j].formulaname + ")", ""));
                                int a = 0;
                                for (int k = 0; k < CComLibrary.GlobeVal.filesave.dt.Columns.Count; k++)
                                {
                                    if (CComLibrary.GlobeVal.filesave.dt.Columns[k].ColumnName == CComLibrary.GlobeVal.filesave.mtablecol1[j].formulaname)
                                    {
                                        a = k;
                                        break;
                                    }
                                }



                                string mo = CComLibrary.GlobeVal.filesave.dt.Columns[a].ColumnName;
                                CComLibrary.GlobeVal.filesave.dt.Columns[a].ColumnName = "@temp";
                                t = Convert.ToSingle(CComLibrary.GlobeVal.filesave.dt.Compute("min(" + "@temp" + ")", ""));
                                CComLibrary.GlobeVal.filesave.dt.Columns[a].ColumnName = mo;

                            }
                            if (GlobeVal.mysys.language == 0)
                            {
                                _temp = "最大值";
                            }
                            else
                            {
                                _temp = "Max";
                            }

                            if (CComLibrary.GlobeVal.filesave.mtable1statistics[i - 1].formulaname == _temp )
                            {
                                // t = Convert.ToSingle(CComLibrary.GlobeVal.filesave.dt.Compute("max(" + CComLibrary.GlobeVal.filesave.mtablecol1[j].formulaname + ")", ""));
                                int a = 0;
                                for (int k = 0; k < CComLibrary.GlobeVal.filesave.dt.Columns.Count; k++)
                                {
                                    if (CComLibrary.GlobeVal.filesave.dt.Columns[k].ColumnName == CComLibrary.GlobeVal.filesave.mtablecol1[j].formulaname)
                                    {
                                        a = k;
                                        break;
                                    }
                                }



                                string mo = CComLibrary.GlobeVal.filesave.dt.Columns[a].ColumnName;
                                CComLibrary.GlobeVal.filesave.dt.Columns[a].ColumnName = "@temp";
                                t = Convert.ToSingle(CComLibrary.GlobeVal.filesave.dt.Compute("max(" + "@temp" + ")", ""));
                                CComLibrary.GlobeVal.filesave.dt.Columns[a].ColumnName = mo;
                            }

                            if (GlobeVal.mysys.language == 0)
                            {
                                _temp = "平均值";
                            }
                            else
                            {
                                _temp = "Average";
                            }

                            if (CComLibrary.GlobeVal.filesave.mtable1statistics[i - 1].formulaname ==_temp)
                            {
                                // t = Convert.ToSingle(CComLibrary.GlobeVal.filesave.dt.Compute("avg(" + CComLibrary.GlobeVal.filesave.mtablecol1[j].formulaname + ")", ""));

                                int a = 0;
                                for (int k = 0; k < CComLibrary.GlobeVal.filesave.dt.Columns.Count; k++)
                                {
                                    if (CComLibrary.GlobeVal.filesave.dt.Columns[k].ColumnName == CComLibrary.GlobeVal.filesave.mtablecol1[j].formulaname)
                                    {
                                        a = k;
                                        break;
                                    }
                                }



                                string mo = CComLibrary.GlobeVal.filesave.dt.Columns[a].ColumnName;
                                CComLibrary.GlobeVal.filesave.dt.Columns[a].ColumnName = "@temp";
                                t = Convert.ToSingle(CComLibrary.GlobeVal.filesave.dt.Compute("avg(" + "@temp" + ")", ""));
                                CComLibrary.GlobeVal.filesave.dt.Columns[a].ColumnName = mo;

                            }

                            if (GlobeVal.mysys.language == 0)
                            {
                                _temp = "标准偏差";
                            }
                            else
                            {
                                _temp = "Standard deviation";
                            }


                            if (CComLibrary.GlobeVal.filesave.mtable1statistics[i - 1].formulaname ==_temp)
                            {
                                //  t = Convert.ToSingle(CComLibrary.GlobeVal.filesave.dt.Compute("StDev(" + CComLibrary.GlobeVal.filesave.mtablecol1[j].formulaname + ")", ""));
                                int a = 0;
                                for (int k = 0; k < CComLibrary.GlobeVal.filesave.dt.Columns.Count; k++)
                                {
                                    if (CComLibrary.GlobeVal.filesave.dt.Columns[k].ColumnName == CComLibrary.GlobeVal.filesave.mtablecol1[j].formulaname)
                                    {
                                        a = k;
                                        break;
                                    }
                                }



                                string mo = CComLibrary.GlobeVal.filesave.dt.Columns[a].ColumnName;
                                CComLibrary.GlobeVal.filesave.dt.Columns[a].ColumnName = "@temp";
                                t = Convert.ToSingle(CComLibrary.GlobeVal.filesave.dt.Compute("StDev(" + "@temp" + ")", ""));
                                CComLibrary.GlobeVal.filesave.dt.Columns[a].ColumnName = mo;

                            }
                            if (GlobeVal.mysys.language == 0)
                            {
                                _temp = "方差";
                            }
                            else
                            {
                                _temp = "Variance";
                            }


                            if (CComLibrary.GlobeVal.filesave.mtable1statistics[i - 1].formulaname ==_temp)
                            {
                                //  t = Convert.ToSingle(CComLibrary.GlobeVal.filesave.dt.Compute("Var(" + CComLibrary.GlobeVal.filesave.mtablecol1[j].formulaname + ")", ""));
                                int a = 0;
                                for (int k = 0; k < CComLibrary.GlobeVal.filesave.dt.Columns.Count; k++)
                                {
                                    if (CComLibrary.GlobeVal.filesave.dt.Columns[k].ColumnName == CComLibrary.GlobeVal.filesave.mtablecol1[j].formulaname)
                                    {
                                        a = k;
                                        break;
                                    }
                                }



                                string mo = CComLibrary.GlobeVal.filesave.dt.Columns[a].ColumnName;
                                CComLibrary.GlobeVal.filesave.dt.Columns[a].ColumnName = "@temp";
                                t = Convert.ToSingle(CComLibrary.GlobeVal.filesave.dt.Compute("Var(" + "@temp" + ")", ""));
                                CComLibrary.GlobeVal.filesave.dt.Columns[a].ColumnName = mo;

                            }


                            s = t.ToString("F" + CComLibrary.GlobeVal.filesave.mtablecol1[j].myitemsignal.precise.ToString().Trim());


                        }



                        if (CComLibrary.GlobeVal.filesave.mtablecol1[j].myitemsignal.cUnitKind == 19)
                        {
                            s = "";
                        }

                        data[mt][1 + j] = s;


                    }
                    mt = mt + 1;


                }
            }

            Spire.Doc.Table table = section.AddTable();
            table.ResetCells(data.Length + 1, header.Length);

            // ***************** First Row *************************
            TableRow row = table.Rows[0];
            row.IsHeader = true;
            row.Height = 20;    //unit: point, 1point = 0.3528 mm
            row.HeightType = TableRowHeightType.AtLeast;
            row.RowFormat.BackColor = Color.Gray;


            for (int i = 0; i < header.Length; i++)
            {
                row.Cells[i].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                Paragraph p = row.Cells[i].AddParagraph();
                p.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Center;
                TextRange txtRange = p.AppendText(header[i]);
                txtRange.CharacterFormat.Bold = true;
                row.Cells[i].CellFormat.Borders.LineWidth = 1;
            }

            for (int r = 0; r < data.Length; r++)
            {
                TableRow dataRow = table.Rows[r + 1];
                dataRow.Height = 20;
                dataRow.HeightType = TableRowHeightType.Exactly;
                dataRow.RowFormat.BackColor = Color.Empty;
                for (int c = 0; c < data[r].Length; c++)
                {
                    dataRow.Cells[c].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                    dataRow.Cells[c].AddParagraph().AppendText(data[r][c]);
                    dataRow.Cells[c].CellFormat.Borders.LineWidth = 1;
                }
            }



        }
        private void printpage(bool printed)
        {




            document.Sections.Clear();



            section = document.AddSection();

            SizeF sf = new SizeF();

            for (int i = 0; i < mReportApp.mPagelist.Count; i++)
            {
                if (mReportApp.mPagelist[i].Name == mReportApp.pagesize)
                {
                    sf = mReportApp.mPagelist[i].size;
                }
            }

            section.PageSetup.PageSize = sf;
            section.PageSetup.Margins.Top = mReportApp.Margins;
            section.PageSetup.Margins.Bottom = mReportApp.Margins / 2;
            section.PageSetup.Margins.Left = mReportApp.Margins;
            section.PageSetup.Margins.Right = mReportApp.Margins;

            if (mReportApp.Landscape == true)
            {
                section.PageSetup.Orientation = PageOrientation.Landscape;
            }
            else
            {
                section.PageSetup.Orientation = PageOrientation.Portrait;

            }



            HeaderFooter header = section.HeadersFooters.Header;
            HeaderFooter footer = section.HeadersFooters.Footer;


            Paragraph headerParagraph = header.AddParagraph();


            if (mReportApp.headerposition == 0)
            {
                headerParagraph.Format.HorizontalAlignment
                 = Spire.Doc.Documents.HorizontalAlignment.Left;
            }
            else if (mReportApp.headerposition == 1)
            {
                headerParagraph.Format.HorizontalAlignment
                 = Spire.Doc.Documents.HorizontalAlignment.Center;
            }
            else if (mReportApp.headerposition == 2)
            {
                headerParagraph.Format.HorizontalAlignment
                 = Spire.Doc.Documents.HorizontalAlignment.Right;
            }



            headerParagraph.Format.Borders.Bottom.BorderType
                = Spire.Doc.Documents.BorderStyle.Single;
            headerParagraph.Format.Borders.Bottom.Space = 0.05F;

            mReportApp.ChangeReportValue();

            for (int i = 0; i < mReportApp.mreportheader.Count; i++)
            {


                if (mReportApp.mreportheader[i].kind == 0)
                {

                    string s = "";
                    s = s.PadLeft(Convert.ToInt16(mReportApp.mreportheader[i].mspace), Convert.ToChar(" "));
                    if (mReportApp.mreportheader[i].showcaption == false)
                    {
                        s = s + mReportApp.mreportheader[i].txtresult;
                    }
                    else
                    {
                        s = s + mReportApp.mreportheader[i].Name + ":" + mReportApp.mreportheader[i].txtresult;
                    }



                    TextRange text = headerParagraph.AppendText(s);
                    text.CharacterFormat.FontName = mReportApp.mreportheader[i].font.Name;
                    text.CharacterFormat.FontSize = mReportApp.mreportheader[i].font.Size;
                    text.CharacterFormat.Italic = mReportApp.mreportheader[i].font.Italic;
                    text.CharacterFormat.Bold = mReportApp.mreportheader[i].font.Bold;
                }
                if (mReportApp.mreportheader[i].kind == 2)
                {
                    if (mReportApp.mreportheader[i].filename.Trim() == "")
                    {
                    }
                    else
                    {
                        string s = "";
                        s = s.PadLeft(Convert.ToInt16(mReportApp.mreportheader[i].mspace), Convert.ToChar(" "));

                        TextRange text = headerParagraph.AppendText(s);
                        text.CharacterFormat.FontName = mReportApp.mreportheader[i].font.Name;
                        text.CharacterFormat.FontSize = mReportApp.mreportheader[i].font.Size;
                        text.CharacterFormat.Italic = mReportApp.mreportheader[i].font.Italic;
                        text.CharacterFormat.Bold = mReportApp.mreportheader[i].font.Bold;

                        DocPicture headerPicture
                       = headerParagraph.AppendPicture(Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ\\bmp\\" + mReportApp.mreportheader[i].filename));

                        headerPicture.HorizontalAlignment = ShapeHorizontalAlignment.Left;
                    }
                }

                if (mReportApp.mreportheader[i].kind == 1)
                {
                    string s = "";
                    s = s.PadLeft(Convert.ToInt16(mReportApp.mreportheader[i].mspace), Convert.ToChar(" "));
                    s = s + mReportApp.mreportheader[i].txtresult;
                    TextRange text = headerParagraph.AppendText(s);
                    text.CharacterFormat.FontName = mReportApp.mreportheader[i].font.Name;
                    text.CharacterFormat.FontSize = mReportApp.mreportheader[i].font.Size;
                    text.CharacterFormat.Italic = mReportApp.mreportheader[i].font.Italic;
                    text.CharacterFormat.Bold = mReportApp.mreportheader[i].font.Bold;

                }

            }








            for (int i = 0; i < mReportApp.mreportbody.Count; i++)
            {

                Paragraph paragraph = section.AddParagraph();

                if (mReportApp.mreportbody[i].align == 0)
                {
                    paragraph.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Left;
                }
                else if (mReportApp.mreportbody[i].align == 1)
                {
                    paragraph.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Center;
                }
                else if (mReportApp.mreportbody[i].align == 2)
                {
                    paragraph.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Right;
                }

                for (int j = 0; j < mReportApp.mreportbody[i].vspace; j++)
                {
                    paragraph.AppendBreak(BreakType.LineBreak);
                }

                if (mReportApp.mreportbody[i].kind == 0)
                {

                    string s = "";
                    s = s.PadLeft(Convert.ToInt16(mReportApp.mreportbody[i].mspace), Convert.ToChar(" "));
                    if (mReportApp.mreportbody[i].showcaption == false)
                    {
                        s = s + mReportApp.mreportbody[i].txtresult;
                    }
                    else
                    {
                        s = s + mReportApp.mreportbody[i].Name + ":" + mReportApp.mreportbody[i].txtresult;
                    }
                    TextRange text = paragraph.AppendText(s);
                    text.CharacterFormat.FontName = mReportApp.mreportbody[i].font.Name;
                    text.CharacterFormat.FontSize = mReportApp.mreportbody[i].font.Size;
                    text.CharacterFormat.Italic = mReportApp.mreportbody[i].font.Italic;
                    text.CharacterFormat.Bold = mReportApp.mreportbody[i].font.Bold;

                }

                if (mReportApp.mreportbody[i].kind == 3)
                {
                    string s = "";
                    s = s.PadLeft(Convert.ToInt16(mReportApp.mreportbody[i].mspace), Convert.ToChar(" "));
                    if (mReportApp.mreportbody[i].showcaption == false)
                    {

                    }
                    else
                    {
                        s = s + mReportApp.mreportbody[i].Name + ":";
                    }
                    TextRange text = paragraph.AppendText(s);
                    text.CharacterFormat.FontName = mReportApp.mreportbody[i].font.Name;
                    text.CharacterFormat.FontSize = mReportApp.mreportbody[i].font.Size;
                    text.CharacterFormat.Italic = mReportApp.mreportbody[i].font.Italic;
                    text.CharacterFormat.Bold = mReportApp.mreportbody[i].font.Bold;
                    string _temp = "";

                    

                    if (GlobeVal.mysys.language == 0)
                    {
                        _temp = "曲线图1";
                    }
                    else
                    {
                        _temp = "Graph 1";

                    }

                    if (mReportApp.mreportbody[i].Name == _temp)
                    {
                        InsertImage(section, 1);
                    }
                    if (GlobeVal.mysys.language == 0)
                    {
                        _temp = "曲线图2";
                    }
                    else
                    {
                        _temp = "Graph 2";

                    }

                    if (mReportApp.mreportbody[i].Name == _temp)
                    {
                        InsertImage(section, 2);
                    }
                }

                if (mReportApp.mreportbody[i].kind == 4)
                {
                    string s = "";
                    s = s.PadLeft(Convert.ToInt16(mReportApp.mreportbody[i].mspace), Convert.ToChar(" "));
                    if (mReportApp.mreportbody[i].showcaption == false)
                    {

                    }
                    else
                    {
                        s = s + mReportApp.mreportbody[i].Name + ":";
                    }
                    TextRange text = paragraph.AppendText(s);
                    text.CharacterFormat.FontName = mReportApp.mreportbody[i].font.Name;
                    text.CharacterFormat.FontSize = mReportApp.mreportbody[i].font.Size;
                    text.CharacterFormat.Italic = mReportApp.mreportbody[i].font.Italic;
                    text.CharacterFormat.Bold = mReportApp.mreportbody[i].font.Bold;

                    string _temp = "";



                    if (GlobeVal.mysys.language == 0)
                    {
                        _temp = "结果表格1";
                    }
                    else
                    {
                        _temp = "Results 1";

                    }

                    if (mReportApp.mreportbody[i].Name ==_temp )
                    {
                        addTable(section, 1);
                    }

                    if (GlobeVal.mysys.language == 0)
                    {
                        _temp = "结果表格2";
                    }
                    else
                    {
                        _temp = "Results 2";

                    }

                    if (mReportApp.mreportbody[i].Name == _temp)
                    {
                        addTable(section, 2);
                    }
                }

            }







            Paragraph footerParagraph = footer.AddParagraph();

            footerParagraph.Format.Borders.Bottom.BorderType
              = Spire.Doc.Documents.BorderStyle.Single;

            Paragraph FParagraph = footer.AddParagraph();



            for (int i = 0; i < mReportApp.mreportfooter.Count; i++)
            {


                if (mReportApp.mreportfooter[i].kind == 0)
                {

                    string s = "";
                    s = s.PadLeft(Convert.ToInt16(mReportApp.mreportfooter[i].mspace), Convert.ToChar(" "));
                    if (mReportApp.mreportfooter[i].showcaption == false)
                    {
                        s = s + mReportApp.mreportfooter[i].txtresult;
                    }
                    else
                    {
                        s = s + mReportApp.mreportfooter[i].Name + ":" + mReportApp.mreportfooter[i].txtresult;
                    }



                    TextRange text = FParagraph.AppendText(s);
                    text.CharacterFormat.FontName = mReportApp.mreportfooter[i].font.Name;
                    text.CharacterFormat.FontSize = mReportApp.mreportfooter[i].font.Size;
                    text.CharacterFormat.Italic = mReportApp.mreportfooter[i].font.Italic;
                    text.CharacterFormat.Bold = mReportApp.mreportfooter[i].font.Bold;
                }
                if (mReportApp.mreportfooter[i].kind == 2)
                {
                    if (mReportApp.mreportfooter[i].filename.Trim() == "")
                    {
                    }
                    else
                    {
                        string s = "";
                        s = s.PadLeft(Convert.ToInt16(mReportApp.mreportfooter[i].mspace), Convert.ToChar(" "));

                        TextRange text = footerParagraph.AppendText(s);
                        text.CharacterFormat.FontName = mReportApp.mreportfooter[i].font.Name;
                        text.CharacterFormat.FontSize = mReportApp.mreportfooter[i].font.Size;
                        text.CharacterFormat.Italic = mReportApp.mreportfooter[i].font.Italic;
                        text.CharacterFormat.Bold = mReportApp.mreportfooter[i].font.Bold;

                        DocPicture footerPicture
                     = FParagraph.AppendPicture(Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ\\bmp\\" + mReportApp.mreportfooter[i].filename));

                        footerPicture.HorizontalAlignment = ShapeHorizontalAlignment.Left;
                    }
                }

                if (mReportApp.mreportfooter[i].kind == 1)
                {
                    string s = "";
                    s = s.PadLeft(Convert.ToInt16(mReportApp.mreportfooter[i].mspace), Convert.ToChar(" "));
                    s = s + mReportApp.mreportfooter[i].txtresult;
                    TextRange text = FParagraph.AppendText(s);
                    text.CharacterFormat.FontName = mReportApp.mreportfooter[i].font.Name;
                    text.CharacterFormat.FontSize = mReportApp.mreportfooter[i].font.Size;
                    text.CharacterFormat.Italic = mReportApp.mreportfooter[i].font.Italic;
                    text.CharacterFormat.Bold = mReportApp.mreportfooter[i].font.Bold;

                }

            }









            FParagraph.AppendText("    ");
            FParagraph.AppendField("page number", FieldType.FieldPage);
            FParagraph.AppendText(" of ");
            FParagraph.AppendField("number of pages", FieldType.FieldNumPages);


            if (mReportApp.footerposition == 0)
            {
                FParagraph.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Left;
            }
            else if (mReportApp.footerposition == 1)
            {
                FParagraph.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Center;
            }
            else if (mReportApp.footerposition == 2)
            {
                FParagraph.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Right;
            }



            //Set Footer Paragrah Format



            FParagraph.Format.Borders.Top.BorderType = Spire.Doc.Documents.BorderStyle.Hairline;

            FParagraph.Format.Borders.Top.Space = 0.01f;


            FParagraph.Format.Borders.Color = Color.Black;




            dialog.AllowCurrentPage = true;
            dialog.AllowSomePages = true;
            dialog.UseEXDialog = true;



            dialog.PrinterSettings.DefaultPageSettings.Landscape = mReportApp.Landscape;



            document.PrintDialog = dialog;



            if (printed == false)
            {

                UserControl报告常规1.printPreviewControl1.Document = document.PrintDocument;

                UserControl报告常规1.printPreviewControl1.Zoom = 1;

                UserControl报告常规1.printPreviewControl1.InvalidatePreview();
            }
            else
            {
                document.PrintDialog = dialog;


                document.PrintDocument.Print();

            }

        }

        public void prepage()
        {
            //Create word document
            if (document.Sections.Count > 0)
            {
                if (dialog.PrinterSettings.FromPage > 1)
                {

                    dialog.PrinterSettings.FromPage = dialog.PrinterSettings.FromPage - 1;
                }
                else
                {
                    return;
                }

                printpage(false);
            }
            else
            {

                if (GlobeVal.mysys.language == 0)
                {
                    MessageBox.Show("请先打印预览");
                }
                else
                {

                    MessageBox.Show("Please choose preview first.");
                }
            }


        }

        public void nextpage()
        {
            //Create word document
            if (document.Sections.Count > 0)
            {
                if (dialog.PrinterSettings.FromPage < document.PageCount)
                {

                    dialog.PrinterSettings.FromPage = dialog.PrinterSettings.FromPage + 1;
                }
                else
                {
                    return;
                }

                printpage(false);

            }
            else
            {
                if (GlobeVal.mysys.language == 0)
                {
                    MessageBox.Show("请先打印预览");
                }
                else
                {

                    MessageBox.Show("Please choose preview first.");
                }
                
            }

        }

        private void buttonEx3_Click(object sender, EventArgs e)
        {
            //Create word document


        }

        public void printreport()
        {
            dialog.PrinterSettings.FromPage = 1;
            printpage(true);

        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            dialog.PrinterSettings.FromPage = 1;
            printpage(true);


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
            roundedRectangle[0].X = 6;
            roundedRectangle[0].Y = 0;
            roundedRectangle[1].X = this.Width - 2 - 3;
            roundedRectangle[1].Y = 0;
            roundedRectangle[2].X = this.Width - 2 - 3;
            roundedRectangle[2].Y = this.Height - 2 - 3;
            roundedRectangle[3].X = 1;
            roundedRectangle[3].Y = this.Height - 2 - 3;
            roundedRectangle[4].X = 1;
            roundedRectangle[4].Y = 6;
            drawFigure(e, roundedRectangle);



            e.Graphics.EndContainer(containerState);

            if (GlobeVal.UserControlMain1.btnmtest.Visible == true)
            {

                btnopen.Visible = false;
                btnsave.Visible = false;
                btnsaveas.Visible = false;
            }

            else if (GlobeVal.UserControlMain1.btnmmethod.Visible == true)
            {
                btnopen.Visible = false;
                btnsave.Visible = true;
                btnsaveas.Visible = false;
            }
            else
            {
                btnopen.Visible = true;
                btnsave.Visible = true;
                btnsaveas.Visible = true;
            }

        }

        private void btnopen_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\report\\";
            this.openFileDialog1.AddExtension = true;

            this.openFileDialog1.Filter = "试验报告模板文件(*.it)|*.it";
            this.openFileDialog1.FileName = "";
            this.openFileDialog1.ShowDialog(this);
            if (this.openFileDialog1.FileName == null)
            {

                return;
            }
            else
            {
                string fileName = this.openFileDialog1.FileName;

                if (fileName == "")
                {
                    return;
                }
                else
                {

                    mcurfilename = System.IO.Path.GetFileName(fileName);
                    mReportApp = mReportApp.DeSerializeNow(fileName);



                    UserControl报告常规1.Init(0);




                    panelback.Visible = false;
                    panelback.Controls.Clear();
                    UserControl报告常规1.Dock = DockStyle.Fill;
                    panelback.Controls.Add(UserControl报告常规1);
                    panelback.Visible = true;



                    treeView1.SelectedNode = treeView1.Nodes[0];


                    UserControl报告常规1.rtxttemplatename.Text = mcurfilename;

                }

            }

        }

        private void btnsaveas_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\report\\";
            this.saveFileDialog1.AddExtension = true;
            this.saveFileDialog1.Filter = "试验报告模板文件(*.it)|*.it";
            this.saveFileDialog1.FileName = "";
            this.saveFileDialog1.ShowDialog(this);
            if ((saveFileDialog1.FileName == "") || (saveFileDialog1.FileName == null))
            {


                return;
            }
            else
            {
                mcurfilename = System.IO.Path.GetFileName(saveFileDialog1.FileName);
                mReportApp.SerializeNow(saveFileDialog1.FileName);

                UserControl报告常规1.rtxttemplatename.Text = mcurfilename;
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            mReportApp.SerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\report\\" + mcurfilename);
        }
    
        private static BindingFlags s_flag = BindingFlags.Instance | BindingFlags.Public;
        private void button1_Click_1(object sender, EventArgs e)
        {

            bool printed = false;


            
            //生成一个类t。
            Type t = ClassHelper.BuildType("MyClass");
          

         
            //先定义两个属性。
            List<ClassHelper.CustPropertyInfo> lcpi = new List<ClassHelper.CustPropertyInfo>();
            ClassHelper.CustPropertyInfo cpi;
            for (int i = 0; i < CComLibrary.GlobeVal.filesave.minputtext.Count; i++)
            {
                cpi = new ClassHelper.CustPropertyInfo("System.String",CComLibrary.GlobeVal.filesave.minputtext[i].intername);
                lcpi.Add(cpi);
            }

            cpi = new ClassHelper.CustPropertyInfo("System.String", "_Curve");
            lcpi.Add(cpi);

            //再加入上面定义的两个属性到我们生成的类t。
            t = ClassHelper.AddProperty(t, lcpi);


            object o = ClassHelper.CreateInstance(t);

             


            for (int i = 0; i < CComLibrary.GlobeVal.filesave.minputtext.Count; i++)
            {
                Type type =t;
                PropertyInfo[] properties = type.GetProperties(s_flag);
                foreach (PropertyInfo prop in properties)
                {
                    if (prop.Name == CComLibrary.GlobeVal.filesave.minputtext[i].intername)
                    {
                       

                        prop.SetValue(o,CComLibrary.GlobeVal.filesave.minputtext[i].value,null);
                    }
                }
            }




           

            document.Sections.Clear();
            document = new Document(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\report\\学生试验报告模板.docx");

            //清除表单域阴影
            document.Properties.FormFieldShading = false;
            
            try
            {
                Type type = t;
                PropertyInfo[] properties = type.GetProperties(s_flag);
                int length = properties.Length;
                Dictionary<string, PropertyInfo> dict = new Dictionary<string, PropertyInfo>(length, StringComparer.OrdinalIgnoreCase);
                foreach (PropertyInfo prop in properties)
                {
                    dict[prop.Name] = prop;
                }
                object value = null;

                for (int i = 0; i < document.Sections.Count; i++)
                {
                    foreach (FormField field in document.Sections[i].Body.FormFields)
                    {
                        //field.name对应设置模版文本域名称
                        
                      
                        

                        PropertyInfo prop = dict[field.Name];

                        if (prop != null)
                        {
                            value = prop.GetValue(o, null);
                            if (value != null && value != DBNull.Value)
                            {
                              
                                switch (field.Type)
                                {
                                    case FieldType.FieldFormTextInput:
                                        field.Text = value.ToString();

                                        


                                        break;
                                        
                                       
                                    default:
                                        break;
                                }
                            }
                        }

                        if (field.Name == "_Curve")
                        {
                         

                            field.Text = " ";
                          

                            GlobeVal.UserControlGraph1.scatterGraph.ToFile(@"d:\a.bmp", NationalInstruments.UI.ImageType.Bmp);
                          
                            DocPicture p = field.OwnerParagraph.AppendPicture(Image.FromFile(@"d:\a.bmp"));
                            
                            p.VerticalAlignment = ShapeVerticalAlignment.None;
                            p.HorizontalAlignment = ShapeHorizontalAlignment.None;
                            p.VerticalPosition = 0;
                            p.HorizontalPosition = 0;

                            for (int mm = 0; mm < document.Sections.Count; mm++)
                            {
                                for (int nn = 0; nn < document.Sections[mm].Tables.Count; nn++)
                                {
                                    for (i = 0; i < document.Sections[mm].Tables[nn].Rows.Count; i++)
                                    {
                                        for (int j = 0; j < document.Sections[mm].Tables[nn].Rows[i].Cells.Count; j++)

                                            for (int k = 0; k < document.Sections[mm].Tables[nn].Rows[i].Cells[j].FormFields.Count; k++)
                                            {
                                                if (document.Sections[mm].Tables[nn].Rows[i].Cells[j].FormFields[k].Name == field.Name)
                                                {

                                                    p.Width = document.Sections[mm].Tables[nn].Rows[i].Cells[j].Width -
                                                        TextRenderer.MeasureText(field.Text, this.Font).Width;

                                                    p.Height = document.Sections[mm].Tables[nn].Rows[i].Height;


                                                }
                                            }

                                    }
                                }
                            }
                           
                        }


                    }


                    
                }

                /*
                DocPicture picture = document.Sections[0].Tables[0].Rows[1].Cells[1].Paragraphs[0].AppendPicture(Image.FromFile(@"d\a.bmp"));
                //设置图片的宽度和高度
                picture.Width = 100;
                picture.Height = 100;
                */

                


                for (int mm = 0; mm < document.Sections.Count; mm++)
                {
                    for (int nn = 0; nn < document.Sections[mm].Tables.Count; nn++)
                    {
                        for (int k = 0; k < document.Sections[mm].Tables[nn].Rows.Count; k++)
                        {
                            for (int j = 0; j < document.Sections[mm].Tables[nn].Rows[k].Cells.Count; j++)

                            {
                                if (Convert.ToString(document.Sections[mm].Tables[nn].Rows[k].Cells[j].Paragraphs[0].Text) == "试验前需测量数据")
                                {

                                    float tw = document.Sections[mm].Tables[nn].Rows[k].Cells[j + 1].Width;
                                    float l = document.Sections[mm].Tables[nn].Rows[k].Cells[j + 1].CellFormat.Borders.Right.LineWidth;
                                    document.Sections[mm].Tables[nn].Rows[k].Cells.RemoveAt(j+1);


                                    TableCell tc=new TableCell(document);


                                    for (int pp = 0; pp <3; pp++)
                                    {
                                         tc = new TableCell(document);
                                        document.Sections[mm].Tables[nn].Rows[k].Cells.Insert(j+1+pp,tc);
                                        tc.Width = tw / 3;
                                        tc.CellFormat.VerticalAlignment = VerticalAlignment.Middle;


                                        tc.AddParagraph().Text = CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[pp].cName +
                                            "[" +
                                            CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[pp].cUnits[0] +"]";

                                           

                                    }
                                   tc.CellFormat.Borders.Right.LineWidth = l;

                                    break;
                                   

                                }
                            }
                        }
                    }
                }

                for (int mm = 0; mm < document.Sections.Count; mm++)
                {
                    for (int nn = 0; nn < document.Sections[mm].Tables.Count; nn++)
                    {
                        for (int k = 0; k < document.Sections[mm].Tables[nn].Rows.Count; k++)
                        {
                            for (int j = 0; j < document.Sections[mm].Tables[nn].Rows[k].Cells.Count; j++)

                            {
                                if (Convert.ToString(document.Sections[mm].Tables[nn].Rows[k].Cells[j].Paragraphs[0].Text) == "试验前需测量数据")
                                {

                                    float tw = document.Sections[mm].Tables[nn].Rows[k+1].Cells[j + 1].Width;
                                    float l = document.Sections[mm].Tables[nn].Rows[k+1].Cells[j + 1].CellFormat.Borders.Right.LineWidth;
                                    document.Sections[mm].Tables[nn].Rows[k+1].Cells.RemoveAt(j + 1);


                                    TableCell tc = new TableCell(document);


                                    for (int pp = 0; pp < 3; pp++)
                                    {
                                        tc = new TableCell(document);
                                        document.Sections[mm].Tables[nn].Rows[k+1].Cells.Insert(j + 1 + pp, tc);
                                        tc.Width = tw / 3;
                                        tc.CellFormat.VerticalAlignment = VerticalAlignment.Middle;


                                        tc.AddParagraph().Text = CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[pp].cvalue.ToString()
                                           ;



                                    }
                                    tc.CellFormat.Borders.Right.LineWidth = l;

                                    break;


                                }
                            }
                        }
                    }
                }

                for (int mm = 0; mm < document.Sections.Count; mm++)
                {
                    for (int nn = 0; nn < document.Sections[mm].Tables.Count; nn++)
                    {
                        for (int k = 0; k < document.Sections[mm].Tables[nn].Rows.Count; k++)
                        {
                            for (int j = 0; j < document.Sections[mm].Tables[nn].Rows[k].Cells.Count; j++)

                            {
                                if (Convert.ToString(document.Sections[mm].Tables[nn].Rows[k].Cells[j].Paragraphs[0].Text) == "试验后需测量数据")
                                {

                                    float tw = document.Sections[mm].Tables[nn].Rows[k].Cells[j + 1].Width;

                                    float  l = document.Sections[mm].Tables[nn].Rows[k].Cells[j + 1].CellFormat.Borders.Right.LineWidth;
                                    document.Sections[mm].Tables[nn].Rows[k].Cells.RemoveAt(j + 1);


                                    TableCell tc = new TableCell(document);


                                    for (int pp = 3; pp < 6; pp++)
                                    {
                                        tc = new TableCell(document);
                                        document.Sections[mm].Tables[nn].Rows[k].Cells.Insert(j + 1 + pp-3, tc);
                                        tc.Width = tw / 3;
                                        tc.CellFormat.VerticalAlignment = VerticalAlignment.Middle;


                                        tc.AddParagraph().Text = CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[pp].cName+
                                            "["+
                                            CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[pp].cUnits[0]+"]";


                                    }
                                    tc.CellFormat.Borders.Right.LineWidth = l;

                                    break;


                                }
                            }
                        }
                    }
                }

                for (int mm = 0; mm < document.Sections.Count; mm++)
                {
                    for (int nn = 0; nn < document.Sections[mm].Tables.Count; nn++)
                    {
                        for (int k = 0; k < document.Sections[mm].Tables[nn].Rows.Count; k++)
                        {
                            for (int j = 0; j < document.Sections[mm].Tables[nn].Rows[k].Cells.Count; j++)

                            {
                                if (Convert.ToString(document.Sections[mm].Tables[nn].Rows[k].Cells[j].Paragraphs[0].Text) == "试验后需测量数据")
                                {

                                    float tw = document.Sections[mm].Tables[nn].Rows[k+1].Cells[j + 1].Width;

                                    float l = document.Sections[mm].Tables[nn].Rows[k+1].Cells[j + 1].CellFormat.Borders.Right.LineWidth;
                                    document.Sections[mm].Tables[nn].Rows[k+1].Cells.RemoveAt(j + 1);


                                    TableCell tc = new TableCell(document);


                                    for (int pp = 3; pp < 6; pp++)
                                    {
                                        tc = new TableCell(document);
                                        document.Sections[mm].Tables[nn].Rows[k+1].Cells.Insert(j + 1 + pp - 3, tc);
                                        tc.Width = tw / 3;
                                        tc.CellFormat.VerticalAlignment = VerticalAlignment.Middle;


                                        tc.AddParagraph().Text = CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[pp].cvalue.ToString() ;


                                    }
                                    tc.CellFormat.Borders.Right.LineWidth = l;

                                    break;


                                }
                            }
                        }
                    }
                }


                if (CComLibrary.GlobeVal.filesave.mtablecol1.Count > 0)
                {

                    for (int mm = 0; mm < document.Sections.Count; mm++)
                    {
                        for (int nn = 0; nn < document.Sections[mm].Tables.Count; nn++)
                        {
                            for (int k = 0; k < document.Sections[mm].Tables[nn].Rows.Count; k++)
                            {
                                for (int j = 0; j < document.Sections[mm].Tables[nn].Rows[k].Cells.Count; j++)

                                {
                                    if (Convert.ToString(document.Sections[mm].Tables[nn].Rows[k].Cells[j].Paragraphs[0].Text) == CComLibrary.GlobeVal.filesave.dt.Columns[0].ColumnName)  //_序号
                                    {

                                        float tw = document.Sections[mm].Tables[nn].Rows[k].Cells[j + 1].Width;
                                        document.Sections[mm].Tables[nn].Rows[k].Cells.RemoveAt(1);

                                        TableCell tc = new TableCell(document);
                                        for (int pp = 0; pp < CComLibrary.GlobeVal.filesave.mtablecol1.Count; pp++)
                                        {
                                            tc = document.Sections[mm].Tables[nn].Rows[k].AddCell();
                                            tc.Width = tw / CComLibrary.GlobeVal.filesave.mtablecol1.Count;
                                            tc.CellFormat.VerticalAlignment = VerticalAlignment.Middle;


                                            tc.AddParagraph().Text =  CComLibrary.GlobeVal.filesave.mtablecol1[pp].formulaname + "(" +
                                                CComLibrary.GlobeVal.filesave.mtablecol1[pp].formulaunit + ")";

                                            

                                        }
                                        tc.CellFormat.Borders.Right.LineWidth = 3;

                                        break;
                                        /*
                                        Spire.Doc.Table tb;

                                        tb = document.Sections[mm].Tables[nn].Rows[k].Cells[j + 1].AddTable(true);
                                        tb.ResetCells(1, 6);*/

                                    }
                                }
                            }
                        }
                    }
                    for (int mm = 0; mm < document.Sections.Count; mm++)
                    {
                        for (int nn = 0; nn < document.Sections[mm].Tables.Count; nn++)
                        {
                            for (int k = 0; k < document.Sections[mm].Tables[nn].Rows.Count; k++)
                            {
                                for (int j = 0; j < document.Sections[mm].Tables[nn].Rows[k].Cells.Count; j++)

                                {
                                    if (Convert.ToString(document.Sections[mm].Tables[nn].Rows[k].Cells[j].Paragraphs[0].Text) == CComLibrary.GlobeVal.filesave.dt.Columns[0].ColumnName)  //_序号
                                    {

                                        float tw = document.Sections[mm].Tables[nn].Rows[k+1].Cells[j + 1].Width;
                                        document.Sections[mm].Tables[nn].Rows[k+1].Cells.RemoveAt(1);

                                        TableCell tc = new TableCell(document);
                                        for (int pp = 0; pp < CComLibrary.GlobeVal.filesave.mtablecol1.Count; pp++)
                                        {
                                            tc = document.Sections[mm].Tables[nn].Rows[k+1].AddCell();
                                            tc.Width = tw / CComLibrary.GlobeVal.filesave.mtablecol1.Count;
                                            tc.CellFormat.VerticalAlignment = VerticalAlignment.Middle;


                                            tc.AddParagraph().Text = CComLibrary.GlobeVal.filesave.dt.Rows[0][CComLibrary.GlobeVal.filesave.mtablecol1[pp].formulaname].ToString();



                                        }
                                        tc.CellFormat.Borders.Right.LineWidth = 3;

                                        break;
                                        /*
                                        Spire.Doc.Table tb;

                                        tb = document.Sections[mm].Tables[nn].Rows[k].Cells[j + 1].AddTable(true);
                                        tb.ResetCells(1, 6);*/

                                    }
                                }
                            }
                        }
                    }
                    
                }



                document.SaveToFile(@"d:\DocXResume.docx", FileFormat.Docx);

              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dialog.AllowCurrentPage = true;
            dialog.AllowSomePages = true;
            dialog.UseEXDialog = true;



            dialog.PrinterSettings.DefaultPageSettings.Landscape = mReportApp.Landscape;



            document.PrintDialog = dialog;



            if (printed == false)
            {

                UserControl报告常规1.printPreviewControl1.Document = document.PrintDocument;

                UserControl报告常规1.printPreviewControl1.Zoom = 1;

                UserControl报告常规1.printPreviewControl1.InvalidatePreview();
            }
            else
            {
                document.PrintDialog = dialog;


                document.PrintDocument.Print();

            }
        }
    }
}
