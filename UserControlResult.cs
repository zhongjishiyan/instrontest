using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TabHeaderDemo
{
    public partial class UserControlResult : UserControl
    {

        private bool mgrid1moved = false;

        public void Statistics(bool tested, CComLibrary.TablePara mtablepara,  List<CComLibrary.outputitem> tabcol,List<CComLibrary.outputitem> mstatic) //统计计算
        {
            for (int i = 1; i <= mstatic.Count; i++)
            {
                if (mstatic[i - 1].selected == true)

                {
                    grid2.Rows.Insert(i);


                    grid2[i, 0] = new SourceGrid2.Cells.Real.Button(
                        typeof(string));
                    (grid2[i, 0] as SourceGrid2.Cells.Real.Button).Value = mstatic[i - 1].formulaname;



                    for (int j = 0; j < tabcol.Count; j++)
                    {


                        float t = 0;

                        string s = "";

                        if (tested == false)
                        {
                            s = "---";
                        }
                        else
                        {


                            if (tested == true)
                            {


                                if (CComLibrary.GlobeVal.filesave.dt.Columns[tabcol[j].formulaname].DataType == Type.GetType("System.String"))
                                {
                                    s = "---";
                                }
                                else
                                {

                                    if (mstatic[i - 1].formulaname == "最小值")
                                    {
                                        // t = Convert.ToSingle(CComLibrary.GlobeVal.filesave.dt.Compute("min(" + tabcol[j].formulaname + ")", ""));

                                        int a = 0;
                                        for (int k = 0; k < CComLibrary.GlobeVal.filesave.dt.Columns.Count; k++)
                                        {
                                            if (CComLibrary.GlobeVal.filesave.dt.Columns[k].ColumnName == tabcol[j].formulaname)
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
                                    if (mstatic[i - 1].formulaname == "最大值")
                                    {
                                        int a = 0;
                                        for (int k = 0; k < CComLibrary.GlobeVal.filesave.dt.Columns.Count; k++)
                                        {
                                            if (CComLibrary.GlobeVal.filesave.dt.Columns[k].ColumnName == tabcol[j].formulaname)
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
                                    if (mstatic[i - 1].formulaname == "平均值")
                                    {
                                        //  t = Convert.ToSingle(CComLibrary.GlobeVal.filesave.dt.Compute("avg(" + tabcol[j].formulaname + ")", ""));
                                        int a = 0;
                                        for (int k = 0; k < CComLibrary.GlobeVal.filesave.dt.Columns.Count; k++)
                                        {
                                            if (CComLibrary.GlobeVal.filesave.dt.Columns[k].ColumnName == tabcol[j].formulaname)
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
                                    if (mstatic[i - 1].formulaname == "标准偏差")
                                    {
                                        // t = Convert.ToSingle(CComLibrary.GlobeVal.filesave.dt.Compute("StDev(" + tabcol[j].formulaname + ")", ""));

                                        int a = 0;
                                        for (int k = 0; k < CComLibrary.GlobeVal.filesave.dt.Columns.Count; k++)
                                        {
                                            if (CComLibrary.GlobeVal.filesave.dt.Columns[k].ColumnName == tabcol[j].formulaname)
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
                                    if (mstatic[i - 1].formulaname == "方差")
                                    {
                                        //  t = Convert.ToSingle(CComLibrary.GlobeVal.filesave.dt.Compute("Var(" + tabcol[j].formulaname + ")", ""));
                                        int a = 0;
                                        for (int k = 0; k < CComLibrary.GlobeVal.filesave.dt.Columns.Count; k++)
                                        {
                                            if (CComLibrary.GlobeVal.filesave.dt.Columns[k].ColumnName == tabcol[j].formulaname)
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


                                    s = t.ToString("F" + tabcol[j].myitemsignal.precise.ToString().Trim());


                                }

                            }

                            if (tabcol[j].myitemsignal.cUnitKind == 19)
                            {
                                s = "";
                            }
                        }

                        grid2[i, 1 + j] = new SourceGrid2.Cells.Real.Cell(
                           s, typeof(string));
                        (grid2[i, 1 + j] as SourceGrid2.Cells.Real.Cell).TextAlignment = mtablepara.mTableGridPara.GridAlignment;
                        (grid2[i, 1 + j] as SourceGrid2.Cells.Real.Cell).BackColor = mtablepara.mTableGridPara.GridBackColor;
                        (grid2[i, 1 + j] as SourceGrid2.Cells.Real.Cell).ForeColor = mtablepara.mTableGridPara.GridForeColor;

                        (grid2[i, 1 + j] as SourceGrid2.Cells.Real.Cell).Font = new Font(mtablepara.mTableGridPara.GridFont.FontFamily,
                   mtablepara.mTableGridPara.GridFont.Size);
                    }

                    grid2[i, grid1.ColumnsCount - 1] = new SourceGrid2.Cells.Real.Cell(
                       "", typeof(string));

                }
            }

        }

        public void ReCalcGrid(int index, bool tested, bool read, List<CComLibrary.outputitem> tabcol, CComLibrary.TablePara mtablepara, List<CComLibrary.outputitem> mstatic,int inum)
        {
            double result = 0;

            double m = 0;
            if (index == 1)
            {
                label1.Text = "结果1";
            }
            else
            {
                label1.Text = "结果2";
            }


            if (read == false)
            {
                if (tested == true)
                {
                    for (int j = 0; j < tabcol.Count; j++)
                    {
                        for (int i = 0; i < CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem.Length; i++)
                        {
                            if (CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[i].cName != "无")
                            {
                                if (tabcol[j].formulaname == CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[i].cName)
                                {

                                    CComLibrary.GlobeVal.filesave.dt.Rows[inum][tabcol[j].formulaname]
                                        = CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[i].cvalue.ToString();


                                }
                            }

                        }

                        for (int i = 0; i < CComLibrary.GlobeVal.filesave.minput.Count; i++)
                        {
                            if (tabcol[j].formulaname == CComLibrary.GlobeVal.filesave.minput[i].name)
                            {
                                CComLibrary.GlobeVal.filesave.dt.Rows[inum][tabcol[j].formulaname]
                                       = CComLibrary.GlobeVal.filesave.minput[i].value.ToString();
                            }
                        }

                        for (int i = 0; i < CComLibrary.GlobeVal.filesave.minputtext.Count; i++)
                        {
                            if (tabcol[j].formulaname == CComLibrary.GlobeVal.filesave.minputtext[i].name)
                            {
                                CComLibrary.GlobeVal.filesave.dt.Rows[inum][tabcol[j].formulaname]
                                     = CComLibrary.GlobeVal.filesave.minputtext[i].value.ToString();
                            }

                        }





                        for (int i = 0; i < CComLibrary.GlobeVal.filesave.mcbo.Count; i++)
                        {
                            if (tabcol[j].formulaname == CComLibrary.GlobeVal.filesave.mcbo[i].Name)
                            {
                                CComLibrary.GlobeVal.filesave.dt.Rows[inum][tabcol[j].formulaname]
                                    = CComLibrary.GlobeVal.filesave.mcbo[i].value.ToString();
                            }

                        }


                    }

                    for (int i = 0; i < CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem.Count; i++)
                    {
                        CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem[i].setvalue();
                    }

                    for (int j = 0; j < tabcol.Count; j++)
                    {
                        for (int i = 0; i < CComLibrary.GlobeVal.filesave.moutput.Count; i++)
                        {

                            if (tabcol[j].formulaname == CComLibrary.GlobeVal.filesave.moutput[i].formulaname)
                            {
                                // result = Convert.ToDouble(CComLibrary.GlobeVal.gcalc.getresult(i + 1).ToString("F3"));
                                result = ClsStaticStation.m_Global.mresult[i + 1];
                                tabcol[j].myitemsignal.originprecise = 3;
                                double.TryParse(tabcol[j].myitemsignal.GetValueFromUnit(result,
                                     tabcol[j].myitemsignal.cUnitsel), out m);
                                CComLibrary.GlobeVal.filesave.dt.Rows[inum][tabcol[j].formulaname]

                                 = tabcol[j].myitemsignal.format(m, tabcol[j].myitemsignal.precise);

                            }
                        }


                        for (int i = 0; i < CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem.Length; i++)
                        {
                            if (CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[i].cName != "无")
                            {
                                if (tabcol[j].formulaname == CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[i].cName)
                                {
                                    bool mb = false;
                                    for (int k = 0; k < CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem.Count; k++)
                                    {
                                        if (tabcol[j].formulaname == CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem[k].itemname)
                                        {

                                            mb = true;

                                        }
                                    }
                                    if (mb == false)
                                    {
                                        CComLibrary.GlobeVal.filesave.dt.Rows[inum][tabcol[j].formulaname]
                                        = CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[i].cvalue.ToString();
                                    }

                                }
                            }

                        }



                    }


                }
            }


            grid1.RowsCount = 0;


            grid1.BorderStyle = BorderStyle.Fixed3D;
            grid1.AutoStretchRowsToFitHeight = false;
            grid1.ColumnsCount = tabcol.Count + 2;

            grid1.FixedRows = 1;
            grid1.FixedColumns = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].AutoSizeMode = SourceGrid2.AutoSizeMode.None;
            grid1.Rows[0].Height = 25;


            SourceGrid2.Cells.Real.ColumnHeader boldHeader = new SourceGrid2.Cells.Real.ColumnHeader();
            boldHeader.Font = new Font(mtablepara.mTableHeaderPara.HeaderFont.FontFamily,
               mtablepara.mTableHeaderPara.HeaderFont.Size);
            boldHeader.EnableSort = false;
            boldHeader.WordWrap = true;
            boldHeader.Value = "";
            boldHeader.TextAlignment = mtablepara.mTableHeaderPara.HeaderAlignment;
            boldHeader.BackColor = mtablepara.mTableHeaderPara.HeaderBackColor;
            boldHeader.ForeColor = mtablepara.mTableHeaderPara.HeaderForeColor;

            grid1[0, 0] = boldHeader;



            for (int i = 0; i < tabcol.Count; i++)
            {

                boldHeader = new SourceGrid2.Cells.Real.ColumnHeader();
                boldHeader.Font = new Font(mtablepara.mTableHeaderPara.HeaderFont.FontFamily,
                mtablepara.mTableHeaderPara.HeaderFont.Size);
                boldHeader.EnableSort = false;
                boldHeader.WordWrap = true;

                if (tabcol[i].apply == false)
                {
                    boldHeader.Value = tabcol[i].formulaname + "(" +
                        tabcol[i].myitemsignal.cUnits[
                        tabcol[i].myitemsignal.cUnitsel] + ")";
                }
                else
                {
                    boldHeader.Value = tabcol[i].formulaexplain + "(" +
                        tabcol[i].myitemsignal.cUnits[
                        tabcol[i].myitemsignal.cUnitsel] + ")";
                }

                boldHeader.ToolTipText = tabcol[i].formulaname + "(" +
                        tabcol[i].myitemsignal.cUnits[
                        tabcol[i].myitemsignal.cUnitsel] + ")";

                boldHeader.TextAlignment = mtablepara.mTableHeaderPara.HeaderAlignment;
                boldHeader.BackColor = mtablepara.mTableHeaderPara.HeaderBackColor;
                boldHeader.ForeColor = mtablepara.mTableHeaderPara.HeaderForeColor;

                grid1[0, 1 + i] = boldHeader;
            }

            boldHeader = new SourceGrid2.Cells.Real.ColumnHeader();
            boldHeader.Font = new Font(mtablepara.mTableHeaderPara.HeaderFont.FontFamily,
                mtablepara.mTableHeaderPara.HeaderFont.Size);
            boldHeader.EnableSort = false;
            boldHeader.WordWrap = true;
            boldHeader.Value = "";
            boldHeader.BackColor = mtablepara.mTableHeaderPara.HeaderBackColor;
            boldHeader.ForeColor = mtablepara.mTableHeaderPara.HeaderForeColor;


            grid1[0, tabcol.Count + 1] = boldHeader;

            for (int i = 0; i < grid1.ColumnsCount - 1; i++)
            {
                grid1.Columns[i].AutoSizeMode = SourceGrid2.AutoSizeMode.None;
            }

            grid1.Columns[grid1.ColumnsCount - 1].AutoSizeMode = SourceGrid2.AutoSizeMode.EnableStretch;


            for (int i = 0; i < grid1.ColumnsCount; i++)
            {
                grid1.Columns[i].Width = 100;

            }
            grid1.AutoStretchColumnsToFitWidth = true;



            for (int i = 1; i <= CComLibrary.GlobeVal.filesave.testedcount + 1; i++)
            {
                grid1.Rows.Insert(i);


                grid1[i, 0] = new SourceGrid2.Cells.Real.Button(
                    typeof(string));
                (grid1[i, 0] as SourceGrid2.Cells.Real.Button).Value = "   " + i.ToString();



                SourceGrid2.VisualModels.MultiImages view = new SourceGrid2.VisualModels.MultiImages();
                view.BackColor = mtablepara.mTableColPara.ColBackColor;
                view.ForeColor = mtablepara.mTableColPara.ColForeColor;

                view.Font = new Font(mtablepara.mTableColPara.ColFont.FontFamily,
                mtablepara.mTableColPara.ColFont.Size);


                if (mtablepara.showvalidspe == true)
                {
                    if (CComLibrary.GlobeVal.filesave.dt.Rows[i - 1]["试样状态"] is DBNull)
                    {
                        CComLibrary.GlobeVal.filesave.dt.Rows[i - 1]["试样状态"] = CComLibrary.TestStatus.Untested;
                    }

                    if (Convert.ToInt16(CComLibrary.GlobeVal.filesave.dt.Rows[i - 1]["试样状态"]) == Convert.ToInt16(CComLibrary.TestStatus.novalid))
                    {

                        view.Image = imageList1.Images[1];
                    }
                    else
                    {
                        view.Image = null;

                    }
                }
                else
                {
                    view.Image = null;
                }




                view.TextAlignment = mtablepara.mTableColPara.ColAlignment;


                grid1[i, 0].VisualModel = view;


                for (int j = 0; j < tabcol.Count; j++)
                {


                    float t = 0;

                    string s = "";

                    if (i == (CComLibrary.GlobeVal.filesave.currentspenumber + 1))
                    {

                        if (tested == false)
                        {
                            s = "---";
                        }
                        else
                        {
                            if (CComLibrary.GlobeVal.filesave.dt.Rows[i - 1][tabcol[j].formulaname] is DBNull)
                            {
                                CComLibrary.GlobeVal.filesave.dt.Rows[i - 1][tabcol[j].formulaname] = 0;
                            }
                            t = Convert.ToSingle(CComLibrary.GlobeVal.filesave.dt.Rows[i - 1][tabcol[j].formulaname]);


                            s = t.ToString("F" + tabcol[j].myitemsignal.precise.ToString().Trim());

                            if (tabcol[j].myitemsignal.cUnitKind == 19)
                            {
                                s = "";
                            }

                        }
                    }
                    else
                    {

                        if (CComLibrary.GlobeVal.filesave.dt.Rows[i - 1][tabcol[j].formulaname] is DBNull)
                        {
                            CComLibrary.GlobeVal.filesave.dt.Rows[i - 1][tabcol[j].formulaname] = 0;
                        }

                        t = Convert.ToSingle(CComLibrary.GlobeVal.filesave.dt.Rows[i - 1][tabcol[j].formulaname]);


                        s = t.ToString("F" + tabcol[j].myitemsignal.precise.ToString().Trim());

                        if (tabcol[j].myitemsignal.cUnitKind == 19)
                        {
                            s = "";
                        }

                    }
                    grid1[i, 1 + j] = new SourceGrid2.Cells.Real.Cell(
                       s, typeof(string));
                    (grid1[i, 1 + j] as SourceGrid2.Cells.Real.Cell).TextAlignment = mtablepara.mTableGridPara.GridAlignment;
                    (grid1[i, 1 + j] as SourceGrid2.Cells.Real.Cell).BackColor = mtablepara.mTableGridPara.GridBackColor;
                    (grid1[i, 1 + j] as SourceGrid2.Cells.Real.Cell).ForeColor = mtablepara.mTableGridPara.GridForeColor;

                    (grid1[i, 1 + j] as SourceGrid2.Cells.Real.Cell).Font = new Font(mtablepara.mTableGridPara.GridFont.FontFamily,
               mtablepara.mTableGridPara.GridFont.Size);
                }

                grid1[i, grid1.ColumnsCount - 1] = new SourceGrid2.Cells.Real.Cell(
                   "", typeof(string));
            }



            grid2.RowsCount = 0;


            grid2.BorderStyle = BorderStyle.Fixed3D;
            grid2.AutoStretchRowsToFitHeight = false;
            grid2.ColumnsCount = tabcol.Count + 2;

            grid2.FixedRows = 1;
            grid2.FixedColumns = 1;
            grid2.Rows.Insert(0);
            grid2.Rows[0].AutoSizeMode = SourceGrid2.AutoSizeMode.None;
            grid2.Rows[0].Height = 0;

            boldHeader = new SourceGrid2.Cells.Real.ColumnHeader();
            boldHeader.Font = new Font(mtablepara.mTableHeaderPara.HeaderFont.FontFamily,
                mtablepara.mTableHeaderPara.HeaderFont.Size);
            boldHeader.EnableSort = false;
            boldHeader.WordWrap = true;
            boldHeader.Value = "";
            boldHeader.TextAlignment = mtablepara.mTableHeaderPara.HeaderAlignment;
            boldHeader.BackColor = mtablepara.mTableHeaderPara.HeaderBackColor;
            boldHeader.ForeColor = mtablepara.mTableHeaderPara.HeaderForeColor;

            grid2[0, 0] = boldHeader;



            for (int i = 0; i < tabcol.Count; i++)
            {

                boldHeader = new SourceGrid2.Cells.Real.ColumnHeader();
                boldHeader.Font = new Font(mtablepara.mTableHeaderPara.HeaderFont.FontFamily,
                mtablepara.mTableHeaderPara.HeaderFont.Size);
                boldHeader.EnableSort = false;
                boldHeader.WordWrap = true;
                if (tabcol[i].apply == false)
                {
                    boldHeader.Value = tabcol[i].formulaname + "(" +
                        tabcol[i].myitemsignal.cUnits[
                        tabcol[i].myitemsignal.cUnitsel] + ")";
                }
                else
                {
                    boldHeader.Value = tabcol[i].formulaexplain+ "(" +
                        tabcol[i].myitemsignal.cUnits[
                        tabcol[i].myitemsignal.cUnitsel] + ")";
                }

                boldHeader.ToolTipText =  tabcol[i].formulaname + "(" +
                        tabcol[i].myitemsignal.cUnits[
                        tabcol[i].myitemsignal.cUnitsel] + ")";

                boldHeader.TextAlignment = mtablepara.mTableHeaderPara.HeaderAlignment;
                boldHeader.BackColor = mtablepara.mTableHeaderPara.HeaderBackColor;
                boldHeader.ForeColor = mtablepara.mTableHeaderPara.HeaderForeColor;

                grid2[0, 1 + i] = boldHeader;
            }

            boldHeader = new SourceGrid2.Cells.Real.ColumnHeader();
            boldHeader.Font = new Font(mtablepara.mTableHeaderPara.HeaderFont.FontFamily,
                mtablepara.mTableHeaderPara.HeaderFont.Size);
            boldHeader.EnableSort = false;
            boldHeader.WordWrap = true;
            boldHeader.Value = "";
            boldHeader.BackColor = mtablepara.mTableHeaderPara.HeaderBackColor;
            boldHeader.ForeColor = mtablepara.mTableHeaderPara.HeaderForeColor;


            grid2[0, tabcol.Count + 1] = boldHeader;




            grid2.AutoStretchColumnsToFitWidth = true;


            Statistics(tested, mtablepara, tabcol, mstatic);

            /*
            for (int i = 1; i <= mstatic.Count; i++)
            {
                if (mstatic[i - 1].selected == true)

                {
                    grid2.Rows.Insert(i);


                    grid2[i, 0] = new SourceGrid2.Cells.Real.Button(
                        typeof(string));
                    (grid2[i, 0] as SourceGrid2.Cells.Real.Button).Value = mstatic[i - 1].formulaname;



                    for (int j = 0; j < tabcol.Count; j++)
                    {


                        float t = 0;

                        string s = "";

                        if (tested == false)
                        {
                            s = "---";
                        }
                        else
                        {


                            if (tested == true)
                            {


                                if (CComLibrary.GlobeVal.filesave.dt.Columns[tabcol[j].formulaname].DataType == Type.GetType("System.String"))
                                {
                                    s = "---";
                                }
                                else
                                {

                                    if (mstatic[i - 1].formulaname == "最小值")
                                    {
                                        t = Convert.ToSingle(CComLibrary.GlobeVal.filesave.dt.Compute("min(" + tabcol[j].formulaname + ")", ""));
                                    }
                                    if (mstatic[i - 1].formulaname == "最大值")
                                    {
                                        t = Convert.ToSingle(CComLibrary.GlobeVal.filesave.dt.Compute("max(" + tabcol[j].formulaname + ")", ""));
                                    }
                                    if (mstatic[i - 1].formulaname == "平均值")
                                    {
                                        t = Convert.ToSingle(CComLibrary.GlobeVal.filesave.dt.Compute("avg(" + tabcol[j].formulaname + ")", ""));


                                    }
                                    if (mstatic[i - 1].formulaname == "标准偏差")
                                    {
                                        t = Convert.ToSingle(CComLibrary.GlobeVal.filesave.dt.Compute("StDev(" + tabcol[j].formulaname + ")", ""));


                                    }
                                    if (mstatic[i - 1].formulaname == "方差")
                                    {
                                        t = Convert.ToSingle(CComLibrary.GlobeVal.filesave.dt.Compute("Var(" + tabcol[j].formulaname + ")", ""));


                                    }


                                    s = t.ToString("F" + tabcol[j].myitemsignal.precise.ToString().Trim());


                                }

                            }

                            if (tabcol[j].myitemsignal.cUnitKind == 19)
                            {
                                s = "";
                            }
                        }

                        grid2[i, 1 + j] = new SourceGrid2.Cells.Real.Cell(
                           s, typeof(string));
                        (grid2[i, 1 + j] as SourceGrid2.Cells.Real.Cell).TextAlignment = mtablepara.mTableGridPara.GridAlignment;
                        (grid2[i, 1 + j] as SourceGrid2.Cells.Real.Cell).BackColor = mtablepara.mTableGridPara.GridBackColor;
                        (grid2[i, 1 + j] as SourceGrid2.Cells.Real.Cell).ForeColor = mtablepara.mTableGridPara.GridForeColor;

                        (grid2[i, 1 + j] as SourceGrid2.Cells.Real.Cell).Font = new Font(mtablepara.mTableGridPara.GridFont.FontFamily,
                   mtablepara.mTableGridPara.GridFont.Size);
                    }

                    grid2[i, grid1.ColumnsCount - 1] = new SourceGrid2.Cells.Real.Cell(
                       "", typeof(string));

                }
            }
            */
            for (int i = 0; i < grid2.ColumnsCount - 1; i++)
            {
                grid2.Columns[i].AutoSizeMode = SourceGrid2.AutoSizeMode.None;
            }

            grid2.Columns[grid1.ColumnsCount - 1].AutoSizeMode = SourceGrid2.AutoSizeMode.EnableStretch;


            for (int i = 0; i < grid2.ColumnsCount; i++)
            {
                grid2.Columns[i].Width = 100;

            }




        }
        public string StringTruncat(string oldStr, int maxLength, string endWith)
        {
            //判断原字符串是否为空
            if (string.IsNullOrEmpty(oldStr))
                return oldStr + endWith;


            //返回字符串的长度必须大于1
            if (maxLength < 1)
                throw new Exception("返回的字符串长度必须大于[0] ");


            //判断原字符串是否大于最大长度
            if (oldStr.Length > maxLength)
            {
                //截取原字符串
                string strTmp = oldStr.Substring(0, maxLength);


                //判断后缀是否为空
                if (string.IsNullOrEmpty(endWith))
                    return strTmp;
                else
                    return strTmp + endWith;
            }
            return oldStr;
        }
        public void InitGrid(int index, bool tested, bool read, List<CComLibrary.outputitem> tabcol, CComLibrary.TablePara mtablepara, List<CComLibrary.outputitem> mstatic)
        {
            double result = 0;

            double m = 0;
            if (index == 1)
            {
                label1.Text = "结果1";
            }
            else
            {
                label1.Text = "结果2";
            }


            if (read == false)
            {
                if (tested == true)
                {
                    for (int j = 0; j < tabcol.Count; j++)
                    {
                        for (int i = 0; i < CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem.Length; i++)
                        {
                            if (CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[i].cName != "无")
                            {
                                if (tabcol[j].formulaname == CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[i].cName)
                                {


                                    CComLibrary.GlobeVal.filesave.dt.Rows[CComLibrary.GlobeVal.filesave.currentspenumber][tabcol[j].formulaname]
                                        = CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[i].cvalue.ToString();


                                }
                            }

                        }

                        for (int i = 0; i < CComLibrary.GlobeVal.filesave.minput.Count; i++)
                        {
                            if (tabcol[j].formulaname == CComLibrary.GlobeVal.filesave.minput[i].name)
                            {
                                CComLibrary.GlobeVal.filesave.dt.Rows[CComLibrary.GlobeVal.filesave.currentspenumber][tabcol[j].formulaname]
                                       = CComLibrary.GlobeVal.filesave.minput[i].value.ToString();
                            }
                        }

                        for (int i = 0; i < CComLibrary.GlobeVal.filesave.minputtext.Count; i++)
                        {
                            if (tabcol[j].formulaname == CComLibrary.GlobeVal.filesave.minputtext[i].name)
                            {
                                CComLibrary.GlobeVal.filesave.dt.Rows[CComLibrary.GlobeVal.filesave.currentspenumber][tabcol[j].formulaname]
                                     = CComLibrary.GlobeVal.filesave.minputtext[i].value.ToString();
                            }

                        }
                    




                        for (int i = 0; i < CComLibrary.GlobeVal.filesave.mcbo.Count; i++)
                        {
                            if (tabcol[j].formulaname == CComLibrary.GlobeVal.filesave.mcbo[i].Name)
                            {
                                CComLibrary.GlobeVal.filesave.dt.Rows[CComLibrary.GlobeVal.filesave.currentspenumber][tabcol[j].formulaname]
                                    = CComLibrary.GlobeVal.filesave.mcbo[i].value.ToString();
                            }
                              
                        }


                    }

                    for (int i = 0; i < CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem.Count; i++)
                    {
                        CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem[i].setvalue();
                    }

                    for (int j = 0; j < tabcol.Count; j++)
                    {
                        for (int i = 0; i < CComLibrary.GlobeVal.filesave.moutput.Count; i++)
                        {

                            if (tabcol[j].formulaname == CComLibrary.GlobeVal.filesave.moutput[i].formulaname)
                            {
                               // result = Convert.ToDouble(CComLibrary.GlobeVal.gcalc.getresult(i + 1).ToString("F3"));
                                result = ClsStaticStation.m_Global.mresult[i + 1];
                                tabcol[j].myitemsignal.originprecise = 3;
                                double.TryParse(tabcol[j].myitemsignal.GetValueFromUnit(result,
                                     tabcol[j].myitemsignal.cUnitsel), out m);
                                CComLibrary.GlobeVal.filesave.dt.Rows[CComLibrary.GlobeVal.filesave.currentspenumber][tabcol[j].formulaname]

                                 = tabcol[j].myitemsignal.format(m, tabcol[j].myitemsignal.precise);

                            }
                        }


                        for (int i = 0; i < CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem.Length; i++)
                        {
                            if (CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[i].cName != "无")
                            {
                                if (tabcol[j].formulaname == CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[i].cName)
                                {
                                    bool mb = false;
                                    for (int k = 0; k < CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem.Count; k++)
                                    {
                                        if (tabcol[j].formulaname == CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem[k].itemname)
                                        {

                                            mb = true;

                                        }
                                    }
                                    if (mb == false)
                                    {
                                        CComLibrary.GlobeVal.filesave.dt.Rows[CComLibrary.GlobeVal.filesave.currentspenumber][tabcol[j].formulaname]
                                        = CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[i].cvalue.ToString();
                                    }

                                }
                            }

                        }



                    }


                }
            }


            grid1.RowsCount = 0;


            grid1.BorderStyle = BorderStyle.Fixed3D;
            grid1.AutoStretchRowsToFitHeight = false;
            grid1.ColumnsCount = tabcol.Count + 2;

            grid1.FixedRows = 1;
            grid1.FixedColumns = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].AutoSizeMode = SourceGrid2.AutoSizeMode.None;
            grid1.Rows[0].Height = 25;


            SourceGrid2.Cells.Real.ColumnHeader boldHeader = new SourceGrid2.Cells.Real.ColumnHeader();
            boldHeader.Font = new Font(mtablepara.mTableHeaderPara.HeaderFont.FontFamily,
               mtablepara.mTableHeaderPara.HeaderFont.Size);
            boldHeader.EnableSort = false;
            boldHeader.WordWrap = true;
            boldHeader.Value = "";
            boldHeader.TextAlignment = mtablepara.mTableHeaderPara.HeaderAlignment;
            boldHeader.BackColor = mtablepara.mTableHeaderPara.HeaderBackColor;
            boldHeader.ForeColor = mtablepara.mTableHeaderPara.HeaderForeColor;

            grid1[0, 0] = boldHeader;



            for (int i = 0; i < tabcol.Count; i++)
            {

                boldHeader = new SourceGrid2.Cells.Real.ColumnHeader();
                boldHeader.Font = new Font(mtablepara.mTableHeaderPara.HeaderFont.FontFamily,
                mtablepara.mTableHeaderPara.HeaderFont.Size);
                boldHeader.EnableSort = false;
                boldHeader.WordWrap = false;
                string s = "";
                if (tabcol[i].apply == false)
                {
                     s = tabcol[i].formulaname + "(" +
                        tabcol[i].myitemsignal.cUnits[
                        tabcol[i].myitemsignal.cUnitsel] + ")";
                }
                else
                {
                     s = tabcol[i].formulaexplain + "(" +
                        tabcol[i].myitemsignal.cUnits[
                        tabcol[i].myitemsignal.cUnitsel] + ")";

                }
                /*
                Graphics g = this.CreateGraphics();

                //单位为mm
                g.PageUnit = GraphicsUnit.Point;
                SizeF sim = g.MeasureString("A", boldHeader.Font);
                SizeF im = g.MeasureString(s, boldHeader.Font);
                if (im.Width-10 > grid1.Columns[i].Width)
                {
                    boldHeader.Value = StringTruncat(s, Convert.ToInt16(grid1.Columns[0].Width / sim.Width), "...");
                }
                else
                {
                    boldHeader.Value = s;
                }
                g.Dispose();
                */

                boldHeader.Value = s;
                boldHeader.ToolTipText = tabcol[i].formulaname + "(" +
                        tabcol[i].myitemsignal.cUnits[
                        tabcol[i].myitemsignal.cUnitsel] + ")"; ;

                boldHeader.TextAlignment = mtablepara.mTableHeaderPara.HeaderAlignment;
                boldHeader.BackColor = mtablepara.mTableHeaderPara.HeaderBackColor;
                boldHeader.ForeColor = mtablepara.mTableHeaderPara.HeaderForeColor;

                grid1[0, 1 + i] = boldHeader;
            }

            boldHeader = new SourceGrid2.Cells.Real.ColumnHeader();
            boldHeader.Font = new Font(mtablepara.mTableHeaderPara.HeaderFont.FontFamily,
                mtablepara.mTableHeaderPara.HeaderFont.Size);
            boldHeader.EnableSort = false;
            boldHeader.WordWrap = true;
            boldHeader.Value = "";
            boldHeader.BackColor = mtablepara.mTableHeaderPara.HeaderBackColor;
            boldHeader.ForeColor = mtablepara.mTableHeaderPara.HeaderForeColor;


            grid1[0, tabcol.Count + 1] = boldHeader;

            for (int i = 0; i < grid1.ColumnsCount - 1; i++)
            {
                grid1.Columns[i].AutoSizeMode = SourceGrid2.AutoSizeMode.None;
            }

            grid1.Columns[grid1.ColumnsCount - 1].AutoSizeMode = SourceGrid2.AutoSizeMode.EnableStretch;


            for (int i = 0; i < grid1.ColumnsCount; i++)
            {
                grid1.Columns[i].Width = 100;

            }
            grid1.AutoStretchColumnsToFitWidth = true;



            for (int i = 1; i <= CComLibrary.GlobeVal.filesave.testedcount + 1; i++)
            {
                grid1.Rows.Insert(i);


                grid1[i, 0] = new SourceGrid2.Cells.Real.Button(
                    typeof(string));
                (grid1[i, 0] as SourceGrid2.Cells.Real.Button).Value = "   " + i.ToString();



                SourceGrid2.VisualModels.MultiImages view = new SourceGrid2.VisualModels.MultiImages();
                view.BackColor = mtablepara.mTableColPara.ColBackColor;
                view.ForeColor = mtablepara.mTableColPara.ColForeColor;

                view.Font = new Font(mtablepara.mTableColPara.ColFont.FontFamily,
                mtablepara.mTableColPara.ColFont.Size);


                if (mtablepara.showvalidspe == true)
                {
                    if (CComLibrary.GlobeVal.filesave.dt.Rows[i - 1]["试样状态"] is DBNull)
                    {
                        CComLibrary.GlobeVal.filesave.dt.Rows[i - 1]["试样状态"] = CComLibrary.TestStatus.Untested;
                    }

                    if (Convert.ToInt16(CComLibrary.GlobeVal.filesave.dt.Rows[i - 1]["试样状态"]) == Convert.ToInt16(CComLibrary.TestStatus.novalid))
                    {

                        view.Image = imageList1.Images[1];
                    }
                    else
                    {
                        view.Image = null;

                    }
                }
                else
                {
                    view.Image = null;
                }




                view.TextAlignment = mtablepara.mTableColPara.ColAlignment;


                grid1[i, 0].VisualModel = view;


                for (int j = 0; j < tabcol.Count; j++)
                {


                    float t = 0;

                    string s = "";

                    if (i == (CComLibrary.GlobeVal.filesave.currentspenumber + 1))
                    {

                        if (tested == false)
                        {
                            s = "---";
                        }
                        else
                        {
                            if (CComLibrary.GlobeVal.filesave.dt.Rows[i - 1][tabcol[j].formulaname] is DBNull)
                            {
                                CComLibrary.GlobeVal.filesave.dt.Rows[i - 1][tabcol[j].formulaname] = 0;
                            }
                            t = Convert.ToSingle(CComLibrary.GlobeVal.filesave.dt.Rows[i - 1][tabcol[j].formulaname]);


                            s = t.ToString("F" + tabcol[j].myitemsignal.precise.ToString().Trim());

                            if (tabcol[j].myitemsignal.cUnitKind == 19)
                            {
                                s = "";
                            }

                        }
                    }
                    else
                    {

                        if (CComLibrary.GlobeVal.filesave.dt.Rows[i - 1][tabcol[j].formulaname] is DBNull)
                        {
                            CComLibrary.GlobeVal.filesave.dt.Rows[i - 1][tabcol[j].formulaname] = 0;
                        }

                        t = Convert.ToSingle(CComLibrary.GlobeVal.filesave.dt.Rows[i - 1][tabcol[j].formulaname]);


                        s = t.ToString("F" + tabcol[j].myitemsignal.precise.ToString().Trim());

                        if (tabcol[j].myitemsignal.cUnitKind == 19)
                        {
                            s = "";
                        }

                    }
                    grid1[i, 1 + j] = new SourceGrid2.Cells.Real.Cell(
                       s, typeof(string));
                    (grid1[i, 1 + j] as SourceGrid2.Cells.Real.Cell).TextAlignment = mtablepara.mTableGridPara.GridAlignment;
                    (grid1[i, 1 + j] as SourceGrid2.Cells.Real.Cell).BackColor = mtablepara.mTableGridPara.GridBackColor;
                    (grid1[i, 1 + j] as SourceGrid2.Cells.Real.Cell).ForeColor = mtablepara.mTableGridPara.GridForeColor;

                    (grid1[i, 1 + j] as SourceGrid2.Cells.Real.Cell).Font = new Font(mtablepara.mTableGridPara.GridFont.FontFamily,
               mtablepara.mTableGridPara.GridFont.Size);
                }

                grid1[i, grid1.ColumnsCount - 1] = new SourceGrid2.Cells.Real.Cell(
                   "", typeof(string));
            }



            grid2.RowsCount = 0;


            grid2.BorderStyle = BorderStyle.Fixed3D;
            grid2.AutoStretchRowsToFitHeight = false;
            grid2.ColumnsCount = tabcol.Count + 2;

            grid2.FixedRows = 1;
            grid2.FixedColumns = 1;
            grid2.Rows.Insert(0);
            grid2.Rows[0].AutoSizeMode = SourceGrid2.AutoSizeMode.None;
            grid2.Rows[0].Height = 0;

            boldHeader = new SourceGrid2.Cells.Real.ColumnHeader();
            boldHeader.Font = new Font(mtablepara.mTableHeaderPara.HeaderFont.FontFamily,
                mtablepara.mTableHeaderPara.HeaderFont.Size);
            boldHeader.EnableSort = false;
            boldHeader.WordWrap = true;
            boldHeader.Value = "";
            boldHeader.TextAlignment = mtablepara.mTableHeaderPara.HeaderAlignment;
            boldHeader.BackColor = mtablepara.mTableHeaderPara.HeaderBackColor;
            boldHeader.ForeColor = mtablepara.mTableHeaderPara.HeaderForeColor;

            grid2[0, 0] = boldHeader;



            for (int i = 0; i < tabcol.Count; i++)
            {

                boldHeader = new SourceGrid2.Cells.Real.ColumnHeader();
                boldHeader.Font = new Font(mtablepara.mTableHeaderPara.HeaderFont.FontFamily,
                mtablepara.mTableHeaderPara.HeaderFont.Size);
                boldHeader.EnableSort = false;
                boldHeader.WordWrap = true;

                if (tabcol[i].apply == false)
                {
                    boldHeader.Value = tabcol[i].formulaname + "(" +
                        tabcol[i].myitemsignal.cUnits[
                        tabcol[i].myitemsignal.cUnitsel] + ")";
                }
                else
                {
                    boldHeader.Value = tabcol[i].formulaexplain + "(" +
                      tabcol[i].myitemsignal.cUnits[
                      tabcol[i].myitemsignal.cUnitsel] + ")";
                }

                boldHeader.ToolTipText = tabcol[i].formulaname + "(" +
                        tabcol[i].myitemsignal.cUnits[
                        tabcol[i].myitemsignal.cUnitsel] + ")";

                boldHeader.TextAlignment = mtablepara.mTableHeaderPara.HeaderAlignment;
                boldHeader.BackColor = mtablepara.mTableHeaderPara.HeaderBackColor;
                boldHeader.ForeColor = mtablepara.mTableHeaderPara.HeaderForeColor;

                grid2[0, 1 + i] = boldHeader;
            }

            boldHeader = new SourceGrid2.Cells.Real.ColumnHeader();
            boldHeader.Font = new Font(mtablepara.mTableHeaderPara.HeaderFont.FontFamily,
                mtablepara.mTableHeaderPara.HeaderFont.Size);
            boldHeader.EnableSort = false;
            boldHeader.WordWrap = true;
            boldHeader.Value = "";
            boldHeader.BackColor = mtablepara.mTableHeaderPara.HeaderBackColor;
            boldHeader.ForeColor = mtablepara.mTableHeaderPara.HeaderForeColor;


            grid2[0, tabcol.Count + 1] = boldHeader;




            grid2.AutoStretchColumnsToFitWidth = true;


            Statistics(tested, mtablepara, tabcol, mstatic);

          
            for (int i = 0; i < grid2.ColumnsCount - 1; i++)
            {
                grid2.Columns[i].AutoSizeMode = SourceGrid2.AutoSizeMode.None;
            }

            grid2.Columns[grid1.ColumnsCount - 1].AutoSizeMode = SourceGrid2.AutoSizeMode.EnableStretch;


            for (int i = 0; i < grid2.ColumnsCount; i++)
            {
                grid2.Columns[i].Width = 100;

            }




        }

        public UserControlResult()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲



        }

        private void grid2_VScrollPositionChanged(object sender, SourceGrid2.ScrollPositionChangedEventArgs e)
        {
            // grid1.VScrollBar.Value = grid2.VScrollBar.Value; 
        }

        private void grid2_HScrollPositionChanged(object sender, SourceGrid2.ScrollPositionChangedEventArgs e)
        {
            if (mgrid1moved == false)
            {
                grid1.HScrollBar.Value = grid2.HScrollBar.Value;
            }
        }

        private void grid1_HScrollPositionChanged(object sender, SourceGrid2.ScrollPositionChangedEventArgs e)
        {
            mgrid1moved = true;
            grid2.HScrollBar.Value = grid1.HScrollBar.Value;
            mgrid1moved = false;
        }
    }
}
