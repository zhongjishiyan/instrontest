using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Collections.Generic;
/// <summary>
/// Summary description for Class1
/// </summary>

namespace TabHeaderDemo
{
    [Serializable]


    public class ReportItem : ICloneable,IDisposable  
    {
        public string Name;


        public bool once=false;//使用一次
 
     //下面是属性

         public bool showcaption=true ;//显示标题

         private Font mfont=new Font("宋体",8);//字体；

         public Font   font
         {
             get { return mfont; }
             set { mfont = value; }
         }

         public double vspace = 0.1;//垂直空格
         public double mspace=0.1;//水平空格  

         public bool defaultsize=true;//默认尺寸

         public double width=100;//宽度
         public double height=60;//高度

         public int align=0;//对齐方式

         
         public int kind = 0; //0 一般项目 1 自定义图片 2 自定义文本 3 曲线图 4结果

         public string filename="";//图片文件

         public string txtresult = "";//自定义文本内容

         private bool disposed = false;

         private void Dispose(bool disposing)
         {
             // Check to see if Dispose has already been called.
             if (!this.disposed)
             {
                 // If disposing equals true, dispose all managed
                 // and unmanaged resources.
                 if (disposing)
                 {
                     // Dispose managed resources.

                     

                 }

                 // Call the appropriate methods to clean up
                 // unmanaged resources here.
                 // If disposing is false,
                 // only the following code is executed.


                 // Note disposing has been done.
                 disposed = true;

             }
         }



         public void Dispose()
         {
             Dispose(true);
             // This object will be cleaned up by the Dispose method.
             // Therefore, you should call GC.SupressFinalize to
             // take this object off the finalization queue
             // and prevent finalization code for this object
             // from executing a second time.
             GC.SuppressFinalize(this);
         }

         public virtual Object Clone()
         {
             return this.MemberwiseClone();

         }



    }
    public struct PageSizeF 
    {
       public  String Name;
       public  SizeF size;
    }
    [Serializable]
    public class ReportApp
    {
       public  bool Landscape = false;
       public  float Margins_Top = 50f;
       public  float Margins_Bottom = 50f;
       public  float Margins_Left = 50f;
       public  float Margins_Right = 50f;
       public  float Margins = 50f;
       public string pagesize = "A4";

      
       
       public List<ReportItem> mreportitemlist;
       public List<ReportItem> mreportbody;
       public List<ReportItem> mreportheader;
       public List<ReportItem> mreportfooter;
    


       public int headerposition;//页眉对齐方式
       public int footerposition;//页脚对齐方式


       [NonSerialized]
       public List<PageSizeF> mPagelist;

       public  ReportApp()
       {
           mPagelist = new List<PageSizeF>();
           PageSizeF f = new PageSizeF();
           f.Name = "A4";
           f.size = Spire.Doc.Documents.PageSize.A4;
           mPagelist.Add(f);

           f = new PageSizeF();
           f.Name = "A3";
           f.size = Spire.Doc.Documents.PageSize.A3;
           mPagelist.Add(f);

           f = new PageSizeF();
           f.Name = "A5";
           f.size = Spire.Doc.Documents.PageSize.A5;
           mPagelist.Add(f);

          
           
           f = new PageSizeF();
           f.Name = "A6";
           f.size = Spire.Doc.Documents.PageSize.A6;
           mPagelist.Add(f);

           f = new PageSizeF();
           f.Name = "B4";
           f.size = Spire.Doc.Documents.PageSize.B4;
           mPagelist.Add(f);


           f = new PageSizeF();
           f.Name = "B5";
           f.size = Spire.Doc.Documents.PageSize.B5;
           mPagelist.Add(f);

           f = new PageSizeF();
           f.Name = "B6";
           f.size = Spire.Doc.Documents.PageSize.B6;
           mPagelist.Add(f);

           f = new PageSizeF();
           f.Name = "EnvelopeDL";
           f.size = Spire.Doc.Documents.PageSize.EnvelopeDL;
           mPagelist.Add(f);

           f = new PageSizeF();
           f.Name = "Executive";
           f.size = Spire.Doc.Documents.PageSize.Executive;
           mPagelist.Add(f);

           f = new PageSizeF();
           f.Name = "Flsa";
           f.size = Spire.Doc.Documents.PageSize.Flsa;
           mPagelist.Add(f);

           f = new PageSizeF();
           f.Name = "HalfLetter";
           f.size = Spire.Doc.Documents.PageSize.HalfLetter;
           mPagelist.Add(f);

           f = new PageSizeF();
           f.Name = "Ledger";
           f.size = Spire.Doc.Documents.PageSize.Ledger;
           mPagelist.Add(f);

           f = new PageSizeF();
           f.Name = "Legal";
           f.size = Spire.Doc.Documents.PageSize.Legal;
           mPagelist.Add(f);


           f = new PageSizeF();
           f.Name = "Letter";
           f.size = Spire.Doc.Documents.PageSize.Letter;
           mPagelist.Add(f);


           f = new PageSizeF();
           f.Name = "Letter11x17";
           f.size = Spire.Doc.Documents.PageSize.Letter11x17;
           mPagelist.Add(f);

           f = new PageSizeF();
           f.Name = "Note";
           f.size = Spire.Doc.Documents.PageSize.Note;
           mPagelist.Add(f);

           f = new PageSizeF();
           f.Name = "Quarto";
           f.size = Spire.Doc.Documents.PageSize.Quarto;
           mPagelist.Add(f);

          

           ReportItem r;
           mreportitemlist = new List<ReportItem>();
           mreportbody = new List<ReportItem>();
           mreportheader= new List<ReportItem>();
           mreportfooter = new List<ReportItem>();

           r = new ReportItem();
           r.Name = "方法名称";

           r.kind = 0;
           mreportitemlist.Add(r);


           r = new ReportItem();
           r.Name = "方法说明";
          
           r.kind = 0;
           mreportitemlist.Add(r);

           r = new ReportItem();
           r.Name = "方法作者";
           r.kind = 0;
           mreportitemlist.Add(r);

           r = new ReportItem();
           r.Name = "样品文件名";
           r.kind = 0;
           mreportitemlist.Add(r);


           r = new ReportItem();
           r.Name = "样品说明";
         
           r.kind = 0;
           mreportitemlist.Add(r);
          


           r = new ReportItem();
           r.Name = "样品注释1";
           r.kind = 0;
           mreportitemlist.Add(r);
          

           r = new ReportItem();
           r.Name = "样品注释2";
           r.kind = 0;
           mreportitemlist.Add(r);
          
           r = new ReportItem();
           r.Name = "样品注释3";
           r.kind = 0;
           mreportitemlist.Add(r);
        

           r = new ReportItem();
           r.Name = "曲线图1";
           r.kind = 3;
           mreportitemlist.Add(r);

           r = new ReportItem();
           r.Name = "曲线图2";
           r.kind = 3;
           mreportitemlist.Add(r);

           r = new ReportItem();
           r.Name = "结果表格1";

           r.kind = 4;
           mreportitemlist.Add(r);

           r = new ReportItem();
           r.Name = "结果表格2";
           r.kind = 4;
           mreportitemlist.Add(r);

           r = new ReportItem();
           r.Name = "已试验试样";
           r.kind = 0;
           mreportitemlist.Add(r);

           r = new ReportItem();
           r.Name = "最后试验日期";
           r.kind = 0;
           mreportitemlist.Add(r);
          

           r = new ReportItem();
           r.Name = "控制过程";
           r.kind = 0;
           mreportitemlist.Add(r);


           r = new ReportItem();
           r.Name = "文本";
           r.kind = 1;
           mreportitemlist.Add(r);
        

           r = new ReportItem();
           r.Name = "图片";
           r.kind = 2;
           mreportitemlist.Add(r);

           r = new ReportItem();
           r.kind = 0;
           r.Name = "分页符";
           mreportitemlist.Add(r);

           r = new ReportItem();
           r.kind = 0;
           r.Name = "用户名";
           mreportitemlist.Add(r);

       }

       private void ReportItemChage(ReportItem v)
       {
           ReportItem mc;
           mc = v;
           if (mc.Name == "方法名称")
           {
               
               mc.txtresult = CComLibrary.GlobeVal.filesave.methodname;
           }

           if (mc.Name == "方法说明")
           {
               mc.txtresult = CComLibrary.GlobeVal.filesave.methodmemo;
           }

           if (mc.Name == "方法作者")
           {
               mc.txtresult = CComLibrary.GlobeVal.filesave.methodauthor;
           }

           if (mc.Name == "样品文件名")
           {
               mc.txtresult = GlobeVal.mysys.SampleFile;
           }

           if (mc.Name == "样品说明")
           {
               mc.txtresult = CComLibrary.GlobeVal.filesave.samplememo;
           }
           if (mc.Name == "样品注释1")
           {
               mc.txtresult = CComLibrary.GlobeVal.filesave.samplememo1;
           }

           if (mc.Name == "样品注释2")
           {
               mc.txtresult = CComLibrary.GlobeVal.filesave.samplememo2;
           }

           if (mc.Name == "样品注释3")
           {
               mc.txtresult = CComLibrary.GlobeVal.filesave.samplememo3;
           }

           if (mc.Name == "已试验试样")
           {
               mc.txtresult = CComLibrary.GlobeVal.filesave.mspecount.ToString();
           }

           if (mc.Name == "最后试验日期")
           {
               mc.txtresult = CComLibrary.GlobeVal.filesave.lasttestdatatime;
           }

           if (mc.Name == "用户名")
           {
               mc.txtresult = GlobeVal.mysys.UserName[GlobeVal.mysys.CurentUserIndex];
           }

           if (mc.Name == "控制过程")
           {
               string s="";
               if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 0)
               {
                   s=s+"控制过程:" + "一般测控"+"\r\n";
               }
               else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 1)
               {
                   s=s+"控制过程:" + "中级测控"+"\r\n";
               }
               else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 2)
               {
                   s=s+"控制过程:" + "简单控制"+"\r\n";
               }
               else if (CComLibrary.GlobeVal.filesave.mcontrolprocess ==3)
                {
                    s = s + "控制过程:" + "高级测控" + "\r\n";
                }
              

               CComLibrary.GlobeVal.filesave.InitExplainList();

               for (int i = 0; i < CComLibrary.GlobeVal.filesave.mexplainlist.Count; i++)
               {

                    s = s+"   " + "步骤" + (i + 1).ToString() + " " + CComLibrary.GlobeVal.filesave.mexplainlist[i].explain(Convert.ToInt32(GlobeVal.mysys.machinekind)) +"\r\n";
                 
               }

               mc.txtresult = s;

           }
       }
       public void ChangeReportValue()
       {
         
           for (int i = 0; i <this.mreportheader.Count; i++)
           {
               ReportItemChage(mreportheader[i]);

           }

           for (int i = 0; i < this.mreportfooter.Count; i++)
           {
               ReportItemChage(mreportfooter[i]);
           }
           for (int i = 0; i < this.mreportbody.Count; i++)
           {
               ReportItemChage(mreportbody[i]);
           }

       }

       public void SerializeNow(string filename)
        {
            
            FileStream fileStream =
            new FileStream(filename, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(fileStream, this);
           

            fileStream.Close();
        }
       public ReportApp DeSerializeNow(string filename)
          {
              ReportApp c = new ReportApp();
              try
              {


                  using (FileStream fileStream =
                   new FileStream(filename,
                   FileMode.Open, FileAccess.Read, FileShare.Read))
                  {
                      BinaryFormatter b = new BinaryFormatter();

                      c = b.Deserialize(fileStream) as ReportApp;

                      if (c.mreportheader == null)
                      {
                          c.mreportheader = new List<ReportItem>();

                      }

                      if (c.mreportfooter == null)
                      {
                          c.mreportfooter = new List<ReportItem>();

                      }

                      
                      if (c.mPagelist == null)
                      {
                          c.mPagelist = new List<PageSizeF>();
                          PageSizeF f = new PageSizeF();
                          f.Name = "A4";
                          f.size = Spire.Doc.Documents.PageSize.A4;
                          c.mPagelist.Add(f);

                          f = new PageSizeF();
                          f.Name = "A3";
                          f.size = Spire.Doc.Documents.PageSize.A3;
                          c.mPagelist.Add(f);

                          f = new PageSizeF();
                          f.Name = "A5";
                          f.size = Spire.Doc.Documents.PageSize.A5;
                          c.mPagelist.Add(f);



                          f = new PageSizeF();
                          f.Name = "A6";
                          f.size = Spire.Doc.Documents.PageSize.A6;
                          c.mPagelist.Add(f);

                          f = new PageSizeF();
                          f.Name = "B4";
                          f.size = Spire.Doc.Documents.PageSize.B4;
                          c.mPagelist.Add(f);


                          f = new PageSizeF();
                          f.Name = "B5";
                          f.size = Spire.Doc.Documents.PageSize.B5;
                          c.mPagelist.Add(f);

                          f = new PageSizeF();
                          f.Name = "B6";
                          f.size = Spire.Doc.Documents.PageSize.B6;
                          c.mPagelist.Add(f);

                          f = new PageSizeF();
                          f.Name = "EnvelopeDL";
                          f.size = Spire.Doc.Documents.PageSize.EnvelopeDL;
                          c.mPagelist.Add(f);

                          f = new PageSizeF();
                          f.Name = "Executive";
                          f.size = Spire.Doc.Documents.PageSize.Executive;
                          c.mPagelist.Add(f);

                          f = new PageSizeF();
                          f.Name = "Flsa";
                          f.size = Spire.Doc.Documents.PageSize.Flsa;
                          c.mPagelist.Add(f);

                          f = new PageSizeF();
                          f.Name = "HalfLetter";
                          f.size = Spire.Doc.Documents.PageSize.HalfLetter;
                          c.mPagelist.Add(f);

                          f = new PageSizeF();
                          f.Name = "Ledger";
                          f.size = Spire.Doc.Documents.PageSize.Ledger;
                          c.mPagelist.Add(f);

                          f = new PageSizeF();
                          f.Name = "Legal";
                          f.size = Spire.Doc.Documents.PageSize.Legal;
                          c.mPagelist.Add(f);


                          f = new PageSizeF();
                          f.Name = "Letter";
                          f.size = Spire.Doc.Documents.PageSize.Letter;
                          c.mPagelist.Add(f);


                          f = new PageSizeF();
                          f.Name = "Letter11x17";
                          f.size = Spire.Doc.Documents.PageSize.Letter11x17;
                          c.mPagelist.Add(f);

                          f = new PageSizeF();
                          f.Name = "Note";
                          f.size = Spire.Doc.Documents.PageSize.Note;
                          c.mPagelist.Add(f);

                          f = new PageSizeF();
                          f.Name = "Quarto";
                          f.size = Spire.Doc.Documents.PageSize.Quarto;
                          c.mPagelist.Add(f);

                      }

                       fileStream.Close();

                    
                    
                   }
              }
            catch (Exception e1)
            {
                c = new ReportApp();

                MessageBox.Show(e1.Message,"读取文件");  
            }
            finally
            {

            }
            return (c);
          }
    }

    abstract class CornersItem
    {
        private bool visible;
        public CornersItem()
        {
            visible = true;
        }
        public abstract void addToPath(GraphicsPath path);
        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }
    }

    class CornersLine : CornersItem
    {
        private double x1;
        private double y1;
        private double x2;
        private double y2;
        private double newX1;
        private double newY1;
        private double newX2;
        private double newY2;

        public double X1
        {
            get { return x1; }
            set { x1 = value; newX1 = value; }
        }
        public double Y1
        {
            get { return y1; }
            set { y1 = value; newY1 = value; }
        }
        public double X2
        {
            get { return x2; }
            set { x2 = value; newX2 = value; }
        }
        public double Y2
        {
            get { return y2; }
            set { y2 = value; newY2 = value; }
        }
        public double NewX1
        {
            get { return newX1; }
            set { newX1 = value; }
        }
        public double NewY1
        {
            get { return newY1; }
            set { newY1 = value; }
        }
        public double NewX2
        {
            get { return newX2; }
            set { newX2 = value; }
        }
        public double NewY2
        {
            get { return newY2; }
            set { newY2 = value; }
        }
        public override void addToPath(GraphicsPath path)
        {
            if (Visible)
            {
                if (Math.Sqrt(Math.Pow(newX1 - newX2, 2) + Math.Pow(newY1 - newY2, 2)) > 0.01)
                {
                    path.AddLine((float)newX1, (float)newY1, (float)newX2, (float)newY2);
                }
            }
        }

    }

    class CornersArc : CornersItem
    {
        private double x;
        private double y;
        private double width;
        private double height;
        private double startAngle;
        private double sweepAngle;

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public double Width
        {
            get { return width; }
            set { width = value; }
        }
        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        public double StartAngle
        {
            get { return startAngle; }
            set { startAngle = value; }
        }

        public double SweepAngle
        {
            get { return sweepAngle; }
            set { sweepAngle = value; }
        }

        public override void addToPath(GraphicsPath path)
        {
            if (Visible)
            {
                path.AddArc((float)x, (float)y, (float)width, (float)height, (float)startAngle, (float)(sweepAngle));
            }
        }
    }


    public class Corners
    {
        private PointF[] points;
        private double radius;
        private ArrayList list = new ArrayList();

        private void fillList()
        {
            CornersLine line;
            switch (points.Length)
            {
                case 2:
                    line = new CornersLine();
                    list.Add(line);
                    line.X1 = points[0].X;
                    line.Y1 = points[0].Y;
                    line.X2 = points[1].X;
                    line.Y2 = points[1].Y;
                    break;
                default:
                    PointF firstPoint = new PointF(points[0].X, points[0].Y);
                    for (int i = 1, j = 0; i < points.Length; i++)
                    {
                        line = new CornersLine();
                        list.Add(line);
                        line.X1 = points[j].X;
                        line.Y1 = points[j].Y;
                        ++j;
                        line.X2 = points[j].X;
                        line.Y2 = points[j].Y;
                        if (i != points.Length - 1)
                        {
                            CornersArc arc = new CornersArc();
                            list.Add(arc);
                        }
                        else
                        {
                            if ((firstPoint.X == points[j].X) && (firstPoint.Y == points[j].Y))
                            {
                                CornersArc arc = new CornersArc();
                                list.Add(arc);
                            }

                        }
                    }
                    break;
            }
        }

        public Corners(PointF[] points, double radius)
        {
            this.points = points;
            this.radius = radius;
            fillList();
        }

        public void Execute(GraphicsPath path)
        {
            CornersLine line1, line2;
            CornersArc arc;

            int i = 0;
            while (true)
            {
                if (i == list.Count) break;
                line1 = list[i] as CornersLine;
                i++;
                if (i == list.Count) break;
                arc = list[i] as CornersArc;
                i++;
                if (i == list.Count)
                    line2 = list[0] as CornersLine;
                else
                    line2 = list[i] as CornersLine;
                CalculateRoundLines(line1, line2, arc);
            }

            for (int j = 0; j < list.Count; j++)
            {
                (list[j] as CornersItem).addToPath(path);
            }
        }

        private void CalculateRoundLines(CornersLine line1, CornersLine line2,
            CornersArc arc)
        {
            double f1 = Math.Atan2(line1.Y1 - line1.Y2, line1.X1 - line1.X2);
            double f2 = Math.Atan2(line2.Y2 - line2.Y1, line2.X2 - line2.X1);
            double alfa = f2 - f1;
            if ((alfa == 0) || (Math.Abs(alfa) == Math.PI))
                addWithoutArc(arc);
            else
                addWithArc(line1, line2, arc, f1, f2, alfa);
        }

        private static void addWithoutArc(CornersArc arc)
        {
            arc.Visible = false;
        }

        private void addWithArc(CornersLine line1, CornersLine line2, CornersArc arc, double f1, double f2, double alfa)
        {
            double s = radius / Math.Tan(alfa / 2);
            double line1Length = Math.Sqrt(Math.Pow(line1.X1 - line1.X2, 2) + Math.Pow(line1.Y1 - line1.Y2, 2));
            double line2Length = Math.Sqrt(Math.Pow(line2.X1 - line2.X2, 2) + Math.Pow(line2.Y1 - line2.Y2, 2));
            double newRadius = radius;

            if ((Math.Abs(s) > line1Length / 2) || (Math.Abs(s) > line2Length / 2))
            {
                if (s < 0)
                    s = -Math.Min(line1Length / 2, line2Length / 2);
                else
                    s = Math.Min(line1Length / 2, line2Length / 2);
                newRadius = s * Math.Tan(alfa / 2);
            }

            line1.NewX2 = line1.X2 + Math.Abs(s) * Math.Cos(f1);
            line1.NewY2 = line1.Y2 + Math.Abs(s) * Math.Sin(f1);
            line2.NewX1 = line2.X1 + Math.Abs(s) * Math.Cos(f2);
            line2.NewY1 = line2.Y1 + Math.Abs(s) * Math.Sin(f2);

            double circleCenterAngle = f1 + alfa / 2;
            double cs = newRadius / Math.Sin(alfa / 2);
            PointF circleCenter = new PointF();
            if (s > 0)
            {
                circleCenter.X = (float)(line1.X2 + cs * Math.Cos(circleCenterAngle));
                circleCenter.Y = (float)(line1.Y2 + cs * Math.Sin(circleCenterAngle));
            }
            else
            {
                circleCenter.X = (float)(line1.X2 - cs * Math.Cos(circleCenterAngle));
                circleCenter.Y = (float)(line1.Y2 - cs * Math.Sin(circleCenterAngle));
            }

            double firstAngle = Math.Atan2(line1.NewY2 - circleCenter.Y, line1.NewX2 - circleCenter.X);
            double secondAngle = Math.Atan2(line2.NewY1 - circleCenter.Y, line2.NewX1 - circleCenter.X);
            double startAngle = firstAngle;
            double sweepAngle = secondAngle - firstAngle;
            if (sweepAngle > Math.PI)
                sweepAngle = -(2 * Math.PI - sweepAngle);
            else
            {
                if (sweepAngle < -Math.PI)
                    sweepAngle = (2 * Math.PI + sweepAngle);
            }
            arc.X = circleCenter.X - newRadius;
            arc.Y = circleCenter.Y - newRadius;
            arc.Width = newRadius * 2;
            arc.Height = newRadius * 2;
            arc.StartAngle = startAngle * (180 / Math.PI);
            arc.SweepAngle = sweepAngle * (180 / Math.PI);
        }


    }
}
