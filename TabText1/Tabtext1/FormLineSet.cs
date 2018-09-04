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
    public partial class FormLineSet : Form
    {

        private int  lastcol =-1;
        private int  lastrow = -1;

        List<int> mlistx;
        List<int> mlisty; 
        
        public FormLineSet()
        {
            InitializeComponent();
            mlistx=new List<int>();
            mlisty = new List<int>(); 
         
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            int i;
            grid1.BorderStyle = BorderStyle.FixedSingle;

            grid1.ColumnsCount = 5;
            //grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                grid1[0, 0] = new SourceGrid2.Cells.Real.ColumnHeader("名称");
                grid1[0, 1] = new SourceGrid2.Cells.Real.ColumnHeader("行");
                grid1[0, 2] = new SourceGrid2.Cells.Real.ColumnHeader("列");
                grid1[0, 3] = new SourceGrid2.Cells.Real.ColumnHeader("文件名称");
                grid1[0, 4] = new SourceGrid2.Cells.Real.ColumnHeader("文件日期");
            }
            else
            {
                grid1[0, 0] = new SourceGrid2.Cells.Real.ColumnHeader("Name");
                grid1[0, 1] = new SourceGrid2.Cells.Real.ColumnHeader("Row");
                grid1[0, 2] = new SourceGrid2.Cells.Real.ColumnHeader("Column");
                grid1[0, 3] = new SourceGrid2.Cells.Real.ColumnHeader("File name");
                grid1[0, 4] = new SourceGrid2.Cells.Real.ColumnHeader("File date");
            }

            for (int r = 1; r < 2; r++)
            {
                grid1.Rows.Insert(r);
                if (CComLibrary.GlobeVal.languageselect == 0)
                {
                    grid1[r, 0] = new SourceGrid2.Cells.Real.Cell("数据1", typeof(string));
                }
                else
                {
                    grid1[r, 0] = new SourceGrid2.Cells.Real.Cell("First data", typeof(string));
                }
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

            grid2.ColumnsCount = 6;
            //grid1.FixedRows = 1;
            grid2.Rows.Insert(0);
            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                grid2[0, 0] = new SourceGrid2.Cells.Real.ColumnHeader("X");
                grid2[0, 1] = new SourceGrid2.Cells.Real.ColumnHeader("Y");
                grid2[0, 2] = new SourceGrid2.Cells.Real.ColumnHeader("列");
                grid2[0, 3] = new SourceGrid2.Cells.Real.ColumnHeader("名称");
                grid2[0, 4] = new SourceGrid2.Cells.Real.ColumnHeader("第一个数据");
                grid2[0, 5] = new SourceGrid2.Cells.Real.ColumnHeader("位置");
            }
            else
            {
                grid2[0, 0] = new SourceGrid2.Cells.Real.ColumnHeader("X");
                grid2[0, 1] = new SourceGrid2.Cells.Real.ColumnHeader("Y");
                grid2[0, 2] = new SourceGrid2.Cells.Real.ColumnHeader("Column");
                grid2[0, 3] = new SourceGrid2.Cells.Real.ColumnHeader("Name");
                grid2[0, 4] = new SourceGrid2.Cells.Real.ColumnHeader("First data");
                grid2[0, 5] = new SourceGrid2.Cells.Real.ColumnHeader("Postion");
            }
            for (int r = 1; r < CComLibrary.GlobeVal.outgrid[0].ColumnsCount ; r++)
            {
                grid2.Rows.Insert(r);
                grid2[r, 0] = new SourceGrid2.Cells.Real.CheckBox(false);
                grid2[r, 1] = new SourceGrid2.Cells.Real.CheckBox(false);
                grid2[r, 2] = new SourceGrid2.Cells.Real.Cell(CComLibrary.GlobeVal.outgrid[0].m_ColHeaderCell.GetValue(new SourceGrid2.Position(1,r)) , typeof(string));
                grid2[r, 3] = new SourceGrid2.Cells.Real.Cell(CComLibrary.GlobeVal.outgrid[0].m_DataCell.GetValue(new SourceGrid2.Position(1, r)), typeof(string));
                grid2[r, 4] = new SourceGrid2.Cells.Real.Cell(CComLibrary.GlobeVal.outgrid[0].m_DataCell.GetValue(new SourceGrid2.Position(4, r)), typeof(string));
                grid2[r, 5] = new SourceGrid2.Cells.Real.Cell( r.ToString(), typeof(string));


            }

            for (i = 0; i < grid2.ColumnsCount; i++)
            {
                grid2.Columns[i].Width = (grid2.Width-30) / grid2.ColumnsCount  ;
            }
            //grid2.AutoSizeAll();

            timer1.Enabled = true; 
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int i;
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
                    CComLibrary.GlobeVal.ysel = i;
                }
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

                if (grid2.GetCell(i,1).GetDisplayText(new SourceGrid2.Position(i,1))=="True")
                {

                    if (mlisty.Count>0)
                    {
                        if (i==mlisty[0])
                        {
                        }
                        else
                        {
                            mlisty.Add(i); 
                        }
                    }
                    else
                    {
                        mlisty.Add(i);
                    }

                    if (mlisty.Count > 1)
                    {

                        grid2.GetCell(mlisty[0], 1).SetValue(new SourceGrid2.Position(mlisty[0], 1), false);
                        mlisty.RemoveAt(0);
                    }

                }


            }



         

        }

        private void grid2_LocationChanged(object sender, EventArgs e)
        {
          
        }
    }
}
