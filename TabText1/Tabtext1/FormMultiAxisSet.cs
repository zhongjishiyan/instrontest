using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppleLabApplication
{
    public partial class FormMultiAxisSet : Form
    {

        private int  lastcol =-1;
        private int  lastrow = -1;

        List<int> mlistx;

        public FormMultiAxisSet()
        {
            InitializeComponent();
            mlistx=new List<int>();
         
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            int i;
            grid1.BorderStyle = BorderStyle.FixedSingle;

            grid1.ColumnsCount = 5;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1[0, 0] = new SourceGrid2.Cells.Real.ColumnHeader("名称");
            grid1[0, 1] = new SourceGrid2.Cells.Real.ColumnHeader("行");
            grid1[0, 2] = new SourceGrid2.Cells.Real.ColumnHeader("列");
            grid1[0, 3] = new SourceGrid2.Cells.Real.ColumnHeader("文件名称");
            grid1[0, 4] = new SourceGrid2.Cells.Real.ColumnHeader("文件日期");


            for (int r = 1; r < 2; r++)
            {
                grid1.Rows.Insert(r);
                grid1[r, 0] = new SourceGrid2.Cells.Real.Cell("数据1", typeof(string));
                grid1[r, 1] = new SourceGrid2.Cells.Real.Cell(CComLibrary.GlobeVal.outgrid[0].Rows.Count.ToString() , typeof(string));
                grid1[r, 2] = new SourceGrid2.Cells.Real.Cell(CComLibrary.GlobeVal.outgrid[0].Columns.Count.ToString()  , typeof(string));
                grid1[r, 3] = new SourceGrid2.Cells.Real.Cell(CComLibrary.GlobeVal.outgrid[0].Tag, typeof(string));
                grid1[r, 4] = new SourceGrid2.Cells.Real.Cell(" ", typeof(string));
            }

            for (i = 0; i < grid1.ColumnsCount; i++)
            {
                grid1.Columns[i].Width = (grid1.Width-30) / grid1.ColumnsCount ;
            }
 

            //grid1.AutoSizeAll();

            grid2.BorderStyle = BorderStyle.FixedSingle;

            grid2.ColumnsCount = 7;
            grid2.FixedRows = 1;
            grid2.Rows.Insert(0);
            grid2[0, 0] = new SourceGrid2.Cells.Real.ColumnHeader("X");
            grid2[0, 1] = new SourceGrid2.Cells.Real.ColumnHeader("Y");
            grid2[0, 2] = new SourceGrid2.Cells.Real.ColumnHeader("列");
            grid2[0, 3] = new SourceGrid2.Cells.Real.ColumnHeader("名称");
            grid2[0, 4] = new SourceGrid2.Cells.Real.ColumnHeader("第一个数据");
            grid2[0, 5] = new SourceGrid2.Cells.Real.ColumnHeader("位置");
            grid2[0, 6] = new SourceGrid2.Cells.Real.ColumnHeader("坐标轴位置");



            string[] l_CmbArr = new string[]{"左侧","右侧"};

            for (int r = 1; r < CComLibrary.GlobeVal.outgrid[0].ColumnsCount ; r++)
            {
                grid2.Rows.Insert(r);

               
                grid2[r, 0] = new SourceGrid2.Cells.Real.CheckBox(false);
               
                grid2[r, 1] = new SourceGrid2.Cells.Real.CheckBox(false);
                grid2[r, 2] = new SourceGrid2.Cells.Real.Cell(CComLibrary.GlobeVal.outgrid[0].m_ColHeaderCell.GetValue(new SourceGrid2.Position(1,r)) , typeof(string));
                grid2[r, 3] = new SourceGrid2.Cells.Real.Cell(CComLibrary.GlobeVal.outgrid[0].m_DataCell.GetValue(new SourceGrid2.Position(1, r)), typeof(string));
                grid2[r, 4] = new SourceGrid2.Cells.Real.Cell(CComLibrary.GlobeVal.outgrid[0].m_DataCell.GetValue(new SourceGrid2.Position(4, r)), typeof(string));
                grid2[r, 5] = new SourceGrid2.Cells.Real.Cell( r.ToString(), typeof(string));
                grid2[r, 6] = new SourceGrid2.Cells.Real.ComboBox(l_CmbArr[0],typeof(string),l_CmbArr,true );  

            }





            for (i = 0; i < grid2.ColumnsCount; i++)
            {
                grid2.Columns[i].Width = (grid2.Width-30) / grid2.ColumnsCount  ;
            }
            //grid2.AutoSizeAll();


            for (i = 1; i < grid2.RowsCount; i++)
            {

                if (CComLibrary.GlobeVal.xsel == i)
                {
                    grid2.SetCell(new SourceGrid2.Position(i, 0), new SourceGrid2.Cells.Real.CheckBox(true));  
                }

                for (int j = 0; j < CComLibrary.GlobeVal.yselcount; j++)
                {
                    if (CComLibrary.GlobeVal.ysels[j]==i)
                    {
                      grid2.SetCell(new SourceGrid2.Position(i, 1), new SourceGrid2.Cells.Real.CheckBox(true));
                      grid2.SetCell(new SourceGrid2.Position(i, 6), new SourceGrid2.Cells.Real.ComboBox(l_CmbArr[CComLibrary.GlobeVal.yselpostion[j]],typeof(string),l_CmbArr,true )); 

                    }

                    
                }
            }


            timer1.Enabled = true; 
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int i;
            int k = 0;
            for (i = 1; i < grid2.RowsCount; i++)
            {
                if (grid2[i, 0].DisplayText == "True")
                {
                    CComLibrary.GlobeVal.xsel = i;
                }
            }

           
            for (i = 1; i < grid2.RowsCount; i++)
            {
                if (grid2[i, 1].DisplayText == "True")
                {
                    CComLibrary.GlobeVal.ysels[k] = i;

                    
                    
                        if (grid2[i, 6].DisplayText == "左侧")
                        {
                            CComLibrary.GlobeVal.yselpostion[k] = 0;

                        }
                        else
                        {
                            CComLibrary.GlobeVal.yselpostion[k] = 1;
                        }

                    


                    k = k + 1;
                }
            }

            CComLibrary.GlobeVal.yselcount = k;


            if ((CComLibrary.GlobeVal.filesave.m_namelist.Count + 1) == CComLibrary.GlobeVal.outgrid[0].ColumnsCount)
            {
                CComLibrary.GlobeVal.filesave.xsel = CComLibrary.GlobeVal.xsel;
                CComLibrary.GlobeVal.filesave.yselcount = CComLibrary.GlobeVal.yselcount;
                for (i = 0; i < CComLibrary.GlobeVal.yselcount; i++)
                {
                    if (CComLibrary.GlobeVal.filesave.ysels == null)
                    {
                        CComLibrary.GlobeVal.filesave.ysels = new int[10];
 
                    }
                    if (CComLibrary.GlobeVal.filesave.yselpostion == null)
                    {
                        CComLibrary.GlobeVal.filesave.yselpostion = new int[10]; 
                    }
                     CComLibrary.GlobeVal.filesave.ysels[i]=CComLibrary.GlobeVal.ysels[i];
                    CComLibrary.GlobeVal.filesave.yselpostion[i]=CComLibrary.GlobeVal.yselpostion[i];
                }

                string s;
                s = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AppleLabJ" + "\\temp.dat";
                CComLibrary.GlobeVal.filesave.SerializeNow(s);

                s = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AppleLabJ" + @"\method\" + CComLibrary.GlobeVal.filesave.methodname + @".dat";

                CComLibrary.GlobeVal.filesave.SerializeNow(s);

                

            }
            else
            {

            }

            


            Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void grid2_SettingCell(object sender, SourceGrid2.PositionEventArgs e)
        {
           
           
        }

        private void grid2_CellLostFocus(object sender, SourceGrid2.PositionCancelEventArgs e)
        {

            

            

        }

        private void grid2_CellGotFocus(object sender, SourceGrid2.PositionCancelEventArgs e)
        {
           
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int i;
           
            for (i = 1; i < grid2.RowsCount; i++)
            {
                if (grid2.GetCell(i, 0).GetDisplayText(new SourceGrid2.Position(i, 0)) == "True")
                {
                    if (mlistx.Count > 0)
                    {
                        if (i == mlistx[0])
                        {

                        }
                        else
                        {
                            mlistx.Add(i);
                        }
                    }
                    else
                    {
                        mlistx.Add(i);
                    }

                    if (mlistx.Count > 1)
                    {

                        grid2.GetCell(mlistx[0], 0).SetValue(new SourceGrid2.Position(mlistx[0], 0), false);
                        mlistx.RemoveAt(0);
                    }

                }

                


            }



         

        }

        private void grid2_LocationChanged(object sender, EventArgs e)
        {
          
        }

        private void grid2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
