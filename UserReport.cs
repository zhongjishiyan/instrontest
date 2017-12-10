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
namespace TabHeaderDemo
{
    public partial class UserReport : UserControl
    {
        private UserControl报告常规 UserControl报告常规1;
        

        public Document document = new Document();


        public ReportApp mReportApp = new ReportApp();

        public Section section;

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
            if (t == "常规")
            {
                if (CComLibrary.GlobeVal.filesave != null)
                {

                    if (System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\report\\" + CComLibrary.GlobeVal.filesave.ReportTemplate) == true)
                    {

                        mReportApp = mReportApp.DeSerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\report\\" + CComLibrary.GlobeVal.filesave.ReportTemplate);

                    }
                }
                    UserControl报告常规1.Init(0);
                
             
            }

            if (t == "页眉")
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

            if (t == "正文")
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

            if (t == "页脚")
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
            UserControl报告常规1 = new UserControl报告常规();
            UserControl报告常规1.muserreport = this;


            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲


            UserControl报告常规1.Init(0);
            panelback.Visible = false;
            panelback.Controls.Clear();
            UserControl报告常规1.Dock = DockStyle.Fill;
            panelback.Controls.Add(UserControl报告常规1);
            panelback.Visible = true;

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

                Control b = GlobeVal.UserControlGraph2.Parent;

                GlobeVal.UserControlGraph1.Parent = null;

                GlobeVal.UserControlGraph1.Dock = DockStyle.None;
                GlobeVal.UserControlGraph1.lblcaption.Visible = false;
                System.Threading.Thread.Sleep(10);


                GlobeVal.UserControlGraph1.Width = 800;
                GlobeVal.UserControlGraph1.Height =600;

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
                GlobeVal.UserControlGraph2.Height  = 600;

                w = GlobeVal.UserControlGraph2.Width;
                h = GlobeVal.UserControlGraph2.Height;

                im = new System.Drawing.Bitmap(w,
                    
                    h, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

               
              
                GlobeVal.UserControlGraph2.DrawToBitmap(im,
                    new Rectangle(0, 0, im.Width,
                        im.Height));

                DocPicture p = paragraph.AppendPicture(im);

                p.Width = section.PageSetup.PageSize.Width - section.PageSetup.Margins.Left - section.PageSetup.Margins.Right;
                p.Height = section.PageSetup.PageSize.Height /3;

                im.Dispose();

                System.Threading.Thread.Sleep(10);
                GlobeVal.UserControlGraph2.Dock = DockStyle.Fill;
                GlobeVal.UserControlGraph2.lblcaption.Visible = true;
                GlobeVal.UserControlGraph2.Parent = b;
            }

           
        }
        private void addTable(Section section,int id)
        {
            

            String[] header =new String[ CComLibrary.GlobeVal.filesave.mtablecol1.Count+1] ;

            header[0] = "序号";
            for (int i=0;i<CComLibrary.GlobeVal.filesave.mtablecol1.Count;i++)
            {
                header[i+1] = CComLibrary.GlobeVal.filesave.mtablecol1[i].formulaname + "(" +
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

            for (int i = 1; i <= CComLibrary.GlobeVal.filesave.currentspenumber+1+wt ; i++)
            {
                data[i-1]=new String[CComLibrary.GlobeVal.filesave.mtablecol1.Count+1];
            }

            for (int i = 1; i <= CComLibrary.GlobeVal.filesave.currentspenumber+1 ; i++)
            {
               
                data[i-1][0] = i.ToString();
                for (int j = 0; j < CComLibrary.GlobeVal.filesave.mtablecol1.Count; j++)
                {
                    float t = 0;

                    string s = "";

                   
                        
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

                            data[i-1][j+1] = s;
                   
                }

            }

            int mt=CComLibrary.GlobeVal.filesave.currentspenumber+1;
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

                                    if (CComLibrary.GlobeVal.filesave.mtable1statistics[i - 1].formulaname == "最小值")
                                    {
                                        t = Convert.ToSingle(CComLibrary.GlobeVal.filesave.dt.Compute("min(" + CComLibrary.GlobeVal.filesave.mtablecol1[j].formulaname + ")", ""));
                                    }
                                    if (CComLibrary.GlobeVal.filesave.mtable1statistics[i - 1].formulaname == "最大值")
                                    {
                                        t = Convert.ToSingle(CComLibrary.GlobeVal.filesave.dt.Compute("max(" + CComLibrary.GlobeVal.filesave.mtablecol1[j].formulaname + ")", ""));
                                    }
                                    if (CComLibrary.GlobeVal.filesave.mtable1statistics[i - 1].formulaname == "平均值")
                                    {
                                        t = Convert.ToSingle(CComLibrary.GlobeVal.filesave.dt.Compute("avg(" + CComLibrary.GlobeVal.filesave.mtablecol1[j].formulaname + ")", ""));


                                    }
                                    if (CComLibrary.GlobeVal.filesave.mtable1statistics[i - 1].formulaname == "标准偏差")
                                    {
                                        t = Convert.ToSingle(CComLibrary.GlobeVal.filesave.dt.Compute("StDev(" + CComLibrary.GlobeVal.filesave.mtablecol1[j].formulaname + ")", ""));


                                    }
                                    if (CComLibrary.GlobeVal.filesave.mtable1statistics[i - 1].formulaname == "方差")
                                    {
                                        t = Convert.ToSingle(CComLibrary.GlobeVal.filesave.dt.Compute("Var(" + CComLibrary.GlobeVal.filesave.mtablecol1[j].formulaname + ")", ""));


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

            section.PageSetup.PageSize =sf;
            section.PageSetup.Margins.Top = mReportApp.Margins;
            section.PageSetup.Margins.Bottom = mReportApp.Margins/2;
            section.PageSetup.Margins.Left = mReportApp.Margins;
            section.PageSetup.Margins.Right =mReportApp.Margins;

            if (mReportApp.Landscape == true)
            {
                section.PageSetup.Orientation  = PageOrientation.Landscape;
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
                        s = s + mReportApp.mreportheader[i].Name +":"+ mReportApp.mreportheader[i].txtresult;
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
                    s = s.PadLeft(Convert.ToInt16( mReportApp.mreportheader[i].mspace),Convert.ToChar(" "));
                     s=s   + mReportApp.mreportheader[i].txtresult;
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

                    if (mReportApp.mreportbody[i].Name == "曲线图1")
                    {
                        InsertImage(section, 1);
                    }

                    if (mReportApp.mreportbody[i].Name == "曲线图2")
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

                    if (mReportApp.mreportbody[i].Name == "结果表格1")
                    {
                        addTable(section, 1);
                    }

                    if (mReportApp.mreportbody[i].Name == "结果表格2")
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

 

 FParagraph.Format.Borders.Top.BorderType=  Spire.Doc.Documents.BorderStyle.Hairline;

 FParagraph.Format.Borders.Top.Space  = 0.01f;


 FParagraph.Format.Borders.Color = Color.Black;

            


            dialog.AllowCurrentPage = true;
            dialog.AllowSomePages = true;
            dialog.UseEXDialog = true;

            

            dialog.PrinterSettings.DefaultPageSettings.Landscape = mReportApp.Landscape;



            document.PrintDialog = dialog;



            if (printed == false)
            {

                UserControl报告常规1.printPreviewControl1.Document = document.PrintDocument;


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
                MessageBox.Show("请先打印预览");
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

                MessageBox.Show("请先打印预览");
            }
            
        }

        private void buttonEx3_Click(object sender, EventArgs e)
        {
            //Create word document
            
           
        }

        private void buttonEx2_Click_2(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            mReportApp.SerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\report\\default.it");

           
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

        private void button7_Click(object sender, EventArgs e)
        {

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

            else
            {
                btnopen.Visible = true;
                btnsave.Visible = true;
                btnsaveas.Visible = true;
            }

        }

       
    }
}
