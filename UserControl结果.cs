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
    public partial class UserControl结果 : UserControl
    {
        public UserControlMethod musercontrolmethod;
        public int resulttab = 0;//结果1还是结果2

        private CComLibrary.outputitem mtempoutput;

        
        public void Init格式()
        {
            toolStripCboElement.Items.Clear();
            if (GlobeVal.mysys.language == 0)
            {
                toolStripCboElement.Items.Add("标题栏");
                toolStripCboElement.Items.Add("固定列");
                toolStripCboElement.Items.Add("内容");
            }
            else
            {
                toolStripCboElement.Items.Add("Title bar");
                toolStripCboElement.Items.Add("Fixed column");
                toolStripCboElement.Items.Add("Content");
            }
            toolStripCboElement.SelectedIndex = 0;

            if (resulttab == 0)
            {

                grid1.RowsCount = 0;
               

                grid1.BorderStyle = BorderStyle.Fixed3D;
                grid1.AutoStretchRowsToFitHeight = true;
                grid1.ColumnsCount = CComLibrary.GlobeVal.filesave.mtablecol1.Count + 2;

                grid1.FixedRows = 1;
                grid1.FixedColumns = 1;
                grid1.Rows.Insert(0);
                grid1.Rows[0].Height = 30;


                SourceGrid2.Cells.Real.ColumnHeader boldHeader = new SourceGrid2.Cells.Real.ColumnHeader();
                boldHeader.Font = new Font(CComLibrary.GlobeVal.filesave.mtable1para.mTableHeaderPara.HeaderFont.FontFamily,
                    CComLibrary.GlobeVal.filesave.mtable1para.mTableHeaderPara.HeaderFont.Size);
                boldHeader.EnableSort = false;
                boldHeader.WordWrap = true;
                boldHeader.Value = "";
                boldHeader.TextAlignment = CComLibrary.GlobeVal.filesave.mtable1para.mTableHeaderPara.HeaderAlignment;
                boldHeader.BackColor = CComLibrary.GlobeVal.filesave.mtable1para.mTableHeaderPara.HeaderBackColor;
                boldHeader.ForeColor = CComLibrary.GlobeVal.filesave.mtable1para.mTableHeaderPara.HeaderForeColor;

                grid1[0, 0] = boldHeader;



                for (int i = 0; i < CComLibrary.GlobeVal.filesave.mtablecol1.Count; i++)
                {

                    boldHeader = new SourceGrid2.Cells.Real.ColumnHeader();
                    boldHeader.Font = new Font(CComLibrary.GlobeVal.filesave.mtable1para.mTableHeaderPara.HeaderFont.FontFamily,
                    CComLibrary.GlobeVal.filesave.mtable1para.mTableHeaderPara.HeaderFont.Size);
                    boldHeader.EnableSort = false;
                    boldHeader.WordWrap = true;
                    if (CComLibrary.GlobeVal.filesave.mtablecol1[i].apply == false)
                    {
                        boldHeader.Value = CComLibrary.GlobeVal.filesave.mtablecol1[i].formulaname + "(" +
                            CComLibrary.GlobeVal.filesave.mtablecol1[i].myitemsignal.cUnits[
                            CComLibrary.GlobeVal.filesave.mtablecol1[i].myitemsignal.cUnitsel] + ")";
                    }
                    else
                    {
                        boldHeader.Value = CComLibrary.GlobeVal.filesave.mtablecol1[i].formulaexplain + "(" +
                            CComLibrary.GlobeVal.filesave.mtablecol1[i].myitemsignal.cUnits[
                            CComLibrary.GlobeVal.filesave.mtablecol1[i].myitemsignal.cUnitsel] + ")";
                    }
                    boldHeader.TextAlignment = CComLibrary.GlobeVal.filesave.mtable1para.mTableHeaderPara.HeaderAlignment;
                    boldHeader.BackColor = CComLibrary.GlobeVal.filesave.mtable1para.mTableHeaderPara.HeaderBackColor;
                    boldHeader.ForeColor = CComLibrary.GlobeVal.filesave.mtable1para.mTableHeaderPara.HeaderForeColor;

                    grid1[0, 1 + i] = boldHeader;
                }

                boldHeader = new SourceGrid2.Cells.Real.ColumnHeader();
                boldHeader.Font = new Font(CComLibrary.GlobeVal.filesave.mtable1para.mTableHeaderPara.HeaderFont.FontFamily,
                    CComLibrary.GlobeVal.filesave.mtable1para.mTableHeaderPara.HeaderFont.Size);
                boldHeader.EnableSort = false;
                boldHeader.WordWrap = true;
                boldHeader.Value = "";
                boldHeader.BackColor = CComLibrary.GlobeVal.filesave.mtable1para.mTableHeaderPara.HeaderBackColor;
                boldHeader.ForeColor = CComLibrary.GlobeVal.filesave.mtable1para.mTableHeaderPara.HeaderForeColor;


                grid1[0, CComLibrary.GlobeVal.filesave.mtablecol1.Count + 1] = boldHeader;


                int mw = grid1.Width / grid1.ColumnsCount;

                for (int i = 0; i < grid1.ColumnsCount; i++)
                {
                    grid1.Columns[i].Width = mw - 1;
                }


                grid1.Columns[grid1.ColumnsCount - 1].AutoSizeMode = SourceGrid2.AutoSizeMode.EnableStretch;

                grid1.AutoStretchColumnsToFitWidth = true;

                for (int i = 1; i <= 4; i++)
                {
                    grid1.Rows.Insert(i);


                    grid1[i, 0] = new SourceGrid2.Cells.Real.Button(
                        typeof(string));
                    (grid1[i, 0] as SourceGrid2.Cells.Real.Button).Value = i.ToString();

                    SourceGrid2.VisualModels.MultiImages view = new SourceGrid2.VisualModels.MultiImages();
                    view.BackColor = CComLibrary.GlobeVal.filesave.mtable1para.mTableColPara.ColBackColor;
                    view.ForeColor = CComLibrary.GlobeVal.filesave.mtable1para.mTableColPara.ColForeColor;

                    view.Font = new Font(CComLibrary.GlobeVal.filesave.mtable1para.mTableColPara.ColFont.FontFamily,
                    CComLibrary.GlobeVal.filesave.mtable1para.mTableColPara.ColFont.Size);

                    if ((i == 2) || (i == 3))
                    {
                        if (CComLibrary.GlobeVal.filesave.mtable1para.showvalidspe == true)
                        {
                            view.Image = imageList1.Images[1];
                        }
                        else
                        {
                            view.Image = imageList1.Images[0];
                        }

                       
                    }
                    else
                    {
                        view.Image = imageList1.Images[0];
                    }
                    view.TextAlignment = CComLibrary.GlobeVal.filesave.mtable1para.mTableColPara.ColAlignment;


                    grid1[i, 0].VisualModel = view;


                    for (int j = 0; j < CComLibrary.GlobeVal.filesave.mtablecol1.Count; j++)
                    {
                       

                        float t = 0;
                        string s = t.ToString("F" + CComLibrary.GlobeVal.filesave.mtablecol1[j].myitemsignal.precise.ToString().Trim());

                        if (CComLibrary.GlobeVal.filesave.mtablecol1[j].myitemsignal.cUnitKind == 19)
                        {
                            s = "";
                        }

                        grid1[i, 1 + j] = new SourceGrid2.Cells.Real.Cell(
                           s, typeof(string));
                        (grid1[i, 1 + j] as SourceGrid2.Cells.Real.Cell).TextAlignment = CComLibrary.GlobeVal.filesave.mtable1para.mTableGridPara.GridAlignment;
                        (grid1[i, 1 + j] as SourceGrid2.Cells.Real.Cell).BackColor = CComLibrary.GlobeVal.filesave.mtable1para.mTableGridPara.GridBackColor;
                        (grid1[i, 1 + j] as SourceGrid2.Cells.Real.Cell).ForeColor = CComLibrary.GlobeVal.filesave.mtable1para.mTableGridPara.GridForeColor;

                        (grid1[i, 1 + j] as SourceGrid2.Cells.Real.Cell).Font = new Font(CComLibrary.GlobeVal.filesave.mtable1para.mTableGridPara.GridFont.FontFamily,
                   CComLibrary.GlobeVal.filesave.mtable1para.mTableGridPara.GridFont.Size);
                    }

                    grid1[i, grid1.ColumnsCount - 1] = new SourceGrid2.Cells.Real.Cell(
                       "", typeof(string));
                }

                chkspe.Checked = CComLibrary.GlobeVal.filesave.mtable1para.showvalidspe;
                if (CComLibrary.GlobeVal.filesave.mtable1para.statisticssel == 0)
                {
                    this.radioButton1.Checked = true;
                    this.radioButton2.Checked = false;
                    this.radioButton3.Checked = false;
                }
                if (CComLibrary.GlobeVal.filesave.mtable1para.statisticssel == 1)
                {
                    this.radioButton1.Checked = false;
                    this.radioButton2.Checked = true;
                    this.radioButton3.Checked = false;
                }

                if (CComLibrary.GlobeVal.filesave.mtable1para.statisticssel == 2)
                {
                    this.radioButton1.Checked = false;
                    this.radioButton2.Checked = false;
                    this.radioButton3.Checked = true;
                }


                
              
            }

            if (resulttab == 1)
            {
                grid1.RowsCount = 0;


                grid1.BorderStyle = BorderStyle.Fixed3D;
                grid1.AutoStretchRowsToFitHeight = true;
                grid1.ColumnsCount = CComLibrary.GlobeVal.filesave.mtablecol2.Count + 2;

                grid1.FixedRows = 1;
                grid1.FixedColumns = 1;
                
                grid1.Rows.Insert(0);
                grid1.Rows[0].Height = 30;


                SourceGrid2.Cells.Real.ColumnHeader boldHeader = new SourceGrid2.Cells.Real.ColumnHeader();
                boldHeader.Font = new Font(CComLibrary.GlobeVal.filesave.mtable2para.mTableHeaderPara.HeaderFont.FontFamily,
                    CComLibrary.GlobeVal.filesave.mtable2para.mTableHeaderPara.HeaderFont.Size);
                boldHeader.EnableSort = false;
                boldHeader.WordWrap = true;
                boldHeader.Value = "";
                boldHeader.TextAlignment = CComLibrary.GlobeVal.filesave.mtable2para.mTableHeaderPara.HeaderAlignment;
                boldHeader.BackColor = CComLibrary.GlobeVal.filesave.mtable2para.mTableHeaderPara.HeaderBackColor;
                boldHeader.ForeColor = CComLibrary.GlobeVal.filesave.mtable2para.mTableHeaderPara.HeaderForeColor;

                grid1[0, 0] = boldHeader;



                for (int i = 0; i < CComLibrary.GlobeVal.filesave.mtablecol2.Count; i++)
                {

                    boldHeader = new SourceGrid2.Cells.Real.ColumnHeader();
                    boldHeader.Font = new Font(CComLibrary.GlobeVal.filesave.mtable2para.mTableHeaderPara.HeaderFont.FontFamily,
                    CComLibrary.GlobeVal.filesave.mtable2para.mTableHeaderPara.HeaderFont.Size);
                    boldHeader.EnableSort = false;
                    boldHeader.WordWrap = true;

                    if (CComLibrary.GlobeVal.filesave.mtablecol2[i].apply == false)
                    {
                        boldHeader.Value = CComLibrary.GlobeVal.filesave.mtablecol2[i].formulaname + "(" +
                            CComLibrary.GlobeVal.filesave.mtablecol2[i].myitemsignal.cUnits[
                            CComLibrary.GlobeVal.filesave.mtablecol2[i].myitemsignal.cUnitsel] + ")";
                    }
                    else
                    {
                        boldHeader.Value = CComLibrary.GlobeVal.filesave.mtablecol2[i].formulaexplain + "(" +
                            CComLibrary.GlobeVal.filesave.mtablecol2[i].myitemsignal.cUnits[
                            CComLibrary.GlobeVal.filesave.mtablecol2[i].myitemsignal.cUnitsel] + ")";
                    }
                    boldHeader.TextAlignment = CComLibrary.GlobeVal.filesave.mtable2para.mTableHeaderPara.HeaderAlignment;
                    boldHeader.BackColor = CComLibrary.GlobeVal.filesave.mtable2para.mTableHeaderPara.HeaderBackColor;
                    boldHeader.ForeColor = CComLibrary.GlobeVal.filesave.mtable2para.mTableHeaderPara.HeaderForeColor;

                    grid1[0, 1 + i] = boldHeader;
                }

                boldHeader = new SourceGrid2.Cells.Real.ColumnHeader();
                boldHeader.Font = new Font(CComLibrary.GlobeVal.filesave.mtable2para.mTableHeaderPara.HeaderFont.FontFamily,
                    CComLibrary.GlobeVal.filesave.mtable2para.mTableHeaderPara.HeaderFont.Size);
                boldHeader.EnableSort = false;
                boldHeader.WordWrap = true;
                boldHeader.Value = "";
                boldHeader.BackColor = CComLibrary.GlobeVal.filesave.mtable2para.mTableHeaderPara.HeaderBackColor;
                boldHeader.ForeColor = CComLibrary.GlobeVal.filesave.mtable2para.mTableHeaderPara.HeaderForeColor;


                grid1[0, CComLibrary.GlobeVal.filesave.mtablecol2.Count + 1] = boldHeader;


                int mw = grid1.Width / grid1.ColumnsCount;

                for (int i = 0; i < grid1.ColumnsCount; i++)
                {
                    grid1.Columns[i].Width = mw - 1;
                }


                grid1.Columns[grid1.ColumnsCount - 1].AutoSizeMode = SourceGrid2.AutoSizeMode.EnableStretch;

                grid1.AutoStretchColumnsToFitWidth = true;

                for (int i = 1; i <= 4; i++)
                {
                    grid1.Rows.Insert(i);


                    grid1[i, 0] = new SourceGrid2.Cells.Real.Button(
                        typeof(string));
                    (grid1[i, 0] as SourceGrid2.Cells.Real.Button).Value = i.ToString();

                    SourceGrid2.VisualModels.MultiImages view = new SourceGrid2.VisualModels.MultiImages();
                    view.BackColor = CComLibrary.GlobeVal.filesave.mtable2para.mTableColPara.ColBackColor;
                    view.ForeColor = CComLibrary.GlobeVal.filesave.mtable2para.mTableColPara.ColForeColor;

                    view.Font = new Font(CComLibrary.GlobeVal.filesave.mtable2para.mTableColPara.ColFont.FontFamily,
                    CComLibrary.GlobeVal.filesave.mtable2para.mTableColPara.ColFont.Size);

                    if ((i == 2) || (i == 3))
                    {
                        if (CComLibrary.GlobeVal.filesave.mtable1para.showvalidspe == true)
                        {
                            view.Image = imageList1.Images[1];
                        }
                        else
                        {
                            view.Image = imageList1.Images[0];
                        }


                    }
                    else
                    {
                        view.Image = imageList1.Images[0];
                    }
                    view.TextAlignment = CComLibrary.GlobeVal.filesave.mtable2para.mTableColPara.ColAlignment;


                    grid1[i, 0].VisualModel = view;


                    for (int j = 0; j < CComLibrary.GlobeVal.filesave.mtablecol2.Count; j++)
                    {
                        grid1[i, 1 + j] = new SourceGrid2.Cells.Real.Cell(
                           "0.000", typeof(string));
                        (grid1[i, 1 + j] as SourceGrid2.Cells.Real.Cell).TextAlignment = CComLibrary.GlobeVal.filesave.mtable2para.mTableGridPara.GridAlignment;
                        (grid1[i, 1 + j] as SourceGrid2.Cells.Real.Cell).BackColor = CComLibrary.GlobeVal.filesave.mtable2para.mTableGridPara.GridBackColor;
                        (grid1[i, 1 + j] as SourceGrid2.Cells.Real.Cell).ForeColor = CComLibrary.GlobeVal.filesave.mtable2para.mTableGridPara.GridForeColor;

                        (grid1[i, 1 + j] as SourceGrid2.Cells.Real.Cell).Font = new Font(CComLibrary.GlobeVal.filesave.mtable2para.mTableGridPara.GridFont.FontFamily,
                   CComLibrary.GlobeVal.filesave.mtable2para.mTableGridPara.GridFont.Size);
                    }

                    grid1[i, grid1.ColumnsCount - 1] = new SourceGrid2.Cells.Real.Cell(
                       "", typeof(string));
                }

                chkspe.Checked = CComLibrary.GlobeVal.filesave.mtable2para.showvalidspe;
                if (CComLibrary.GlobeVal.filesave.mtable2para.statisticssel == 0)
                {
                    this.radioButton1.Checked = true;
                    this.radioButton2.Checked = false;
                    this.radioButton3.Checked = false;
                }
                if (CComLibrary.GlobeVal.filesave.mtable2para.statisticssel == 1)
                {
                    this.radioButton1.Checked = false;
                    this.radioButton2.Checked = true;
                    this.radioButton3.Checked = false;
                }

                if (CComLibrary.GlobeVal.filesave.mtable2para.statisticssel == 2)
                {
                    this.radioButton1.Checked = false;
                    this.radioButton2.Checked = false;
                    this.radioButton3.Checked = true;
                }

               
            }

         
        }

        public void Init统计()
        {
            listinclude.Items.Clear();
            listinclude.mlist = new List<CComLibrary.outputitem>();
            listinclude.mlist.Clear();
            listavail.Items.Clear();
            listavail.mlist = new List<CComLibrary.outputitem>();
            listavail.mlist.Clear();

            if (resulttab == 0)
            {
                for (int i = 0; i < CComLibrary.GlobeVal.filesave.mtable1statistics.Count; i++)
                {
                    if (CComLibrary.GlobeVal.filesave.mtable1statistics[i].selected == false)
                    {
                        this.listavail.Items.Add(CComLibrary.GlobeVal.filesave.mtable1statistics[i].formulaname);
                        this.listavail.mlist.Add(CComLibrary.GlobeVal.filesave.mtable1statistics[i]);
                    }
                    else
                    {
                        this.listinclude.Items.Add(CComLibrary.GlobeVal.filesave.mtable1statistics[i].formulaname);
                        this.listinclude.mlist.Add(CComLibrary.GlobeVal.filesave.mtable1statistics[i]);
                    }
                }
            }

            if (resulttab == 1)
            {
                for (int i = 0; i < CComLibrary.GlobeVal.filesave.mtable2statistics.Count; i++)
                {
                    if (CComLibrary.GlobeVal.filesave.mtable2statistics[i].selected == false)
                    {
                        this.listavail.Items.Add(CComLibrary.GlobeVal.filesave.mtable2statistics[i].formulaname);
                        this.listavail.mlist.Add(CComLibrary.GlobeVal.filesave.mtable2statistics[i]);
                    }
                    else
                    {
                        this.listinclude.Items.Add(CComLibrary.GlobeVal.filesave.mtable2statistics[i].formulaname);
                        this.listinclude.mlist.Add(CComLibrary.GlobeVal.filesave.mtable2statistics[i]);
                    }
                }
            }

        }
        public void Init列()
        {

            lstinclude.mlist = new List<CComLibrary.outputitem>();
            lstinclude.Items.Clear();
            lstinclude.mlist.Clear();
            lstavail.Items.Clear();
            lstavail.mlist = new List<CComLibrary.outputitem>();
            lstavail.mlist.Clear();

            CComLibrary.GlobeVal.filesave.InitOutputExternal();

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.moutputexternal.Count; i++)
            {
                this.lstavail.Items.Add(CComLibrary.GlobeVal.filesave.moutputexternal[i].formulaname);
                this.lstavail.mlist.Add(CComLibrary.GlobeVal.filesave.moutputexternal[i]);

            }


            for (int i = 0; i < CComLibrary.GlobeVal.filesave.moutput.Count; i++)
            {
                if (CComLibrary.GlobeVal.filesave.moutput[i].check == true)
                {
                    this.lstavail.Items.Add(CComLibrary.GlobeVal.filesave.moutput[i].formulaname);
                    this.lstavail.mlist.Add(CComLibrary.GlobeVal.filesave.moutput[i]);
                }
                
            }



            if (resulttab == 0)
            {
                for (int i = 0; i < CComLibrary.GlobeVal.filesave.mtablecol1.Count; i++)
                {
                    this.lstinclude.Items.Add(CComLibrary.GlobeVal.filesave.mtablecol1[i].formulaname);
                    this.lstinclude.mlist.Add(CComLibrary.GlobeVal.filesave.mtablecol1[i]);
                }

            }

            if (resulttab == 1)
            {
                for (int i = 0; i < CComLibrary.GlobeVal.filesave.mtablecol2.Count; i++)
                {
                    this.lstinclude.Items.Add(CComLibrary.GlobeVal.filesave.mtablecol2[i].formulaname);
                    this.lstinclude.mlist.Add(CComLibrary.GlobeVal.filesave.mtablecol2[i]);
                }
            }
        }



        public void Init(int sel)
        {

            tabControl1.SelectedIndex = sel;

            if (GlobeVal.UserControlMain1.btnmtest.Visible == true)
            {
                tabControl1.Enabled = false;
            }
            else
            {
                tabControl1.Enabled = true;
            }

            if (resulttab == 0)
            {
                if (GlobeVal.mysys.language == 0)
                {
                    lbltitle.Text = "设置结果表1-列 ";
                    lbltitlestatic.Text = "设置结果表1-统计 ";
                    lbltitleformat.Text = "设置结果表1-格式 ";
                }
                else
                {
                    lbltitle.Text = "Configure Results table 1 -Column  ";
                    lbltitlestatic.Text = "Selected the statistics to include in results table 1";
                    lbltitleformat.Text = "Edit the format for result table 1 ";
                }
            }
            if (resulttab == 1)
            {
                if (GlobeVal.mysys.language == 0)
                {
                    lbltitle.Text = "设置结果表2-列 ";
                    lbltitlestatic.Text = "设置结果表2-统计 ";
                    lbltitleformat.Text = "设置结果表2-格式 ";
                }
                else
                {
                    lbltitle.Text = "Configure Results table 2 -Column  ";
                    lbltitlestatic.Text = "Selected the statistics to include in results table 2";
                    lbltitleformat.Text = "Edit the format for result table 1 ";
                }
            }
            


            if (sel == 0)
            {
                Init列();
            }

            if (sel == 1)
            {
                Init统计();
            }

            if (sel == 2)
            {
                Init格式();
            }
        }
        public  UserControl结果()
        {
            InitializeComponent();
            tabControl1.ItemSize = new Size(1, 1);
            toolStripCboElement.Items.Clear();
           
        }

        private void list_setvalue()
        {
            int i;

            if (resulttab == 0)
            {
                CComLibrary.GlobeVal.filesave.mtablecol1.Clear();
                for (i = 0; i < this.lstinclude.Items.Count; i++)
                {
                    CComLibrary.GlobeVal.filesave.mtablecol1.Add(this.lstinclude.mlist[i]);
                }
            }

            if (resulttab == 1)
            {
                CComLibrary.GlobeVal.filesave.mtablecol2.Clear();
                for (i = 0; i < this.lstinclude.Items.Count; i++)
                {
                    CComLibrary.GlobeVal.filesave.mtablecol2.Add(this.lstinclude.mlist[i]);
                }
            }
        }

        
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (lstavail.SelectedItem != null)
            {
                this.lstinclude.Items.Add(this.lstavail.mlist[this.lstavail.SelectedIndex].formulaname);
                this.lstinclude.mlist.Add((CComLibrary.outputitem)this.lstavail.mlist[this.lstavail.SelectedIndex].Clone());
                list_setvalue();
                
            }
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            if (lstinclude.SelectedItem != null)
            {
                this.lstinclude.mlist.RemoveAt(this.lstinclude.SelectedIndex);
                this.lstinclude.Items.RemoveAt(this.lstinclude.SelectedIndex);
                list_setvalue();
            }

        }

        private void lstinclude_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstinclude.SelectedIndex >= 0)
            {



                mtempoutput = lstinclude.mlist[lstinclude.SelectedIndex];

                if (mtempoutput.myitemsignal.cUnitKind == 19)
                {
                    tlpitem.Visible = false;
                }
                else
                {
                    tlpitem.Visible = true;
                }

                lblcaption.Text = lstinclude.mlist[lstinclude.SelectedIndex].formulaname;
                
                this.cbocolunit.Items.Clear();
                for (int i = 0; i < lstinclude.mlist[lstinclude.SelectedIndex].myitemsignal.cUnitCount; i++)
                {
                    this.cbocolunit.Items.Add(lstinclude.mlist[lstinclude.SelectedIndex].myitemsignal.cUnits[i]);
                }
                this.cbocolunit.SelectedIndex = lstinclude.mlist[lstinclude.SelectedIndex].myitemsignal.cUnitsel;
                this.editcolprecise.Value =lstinclude.mlist[lstinclude.SelectedIndex].myitemsignal.precise;
                this.editcolup.Value = lstinclude.mlist[lstinclude.SelectedIndex].limitup;
                this.editcoldown.Value = lstinclude.mlist[lstinclude.SelectedIndex].limitdown;
                this.cbomode.Items.Clear();
                if (GlobeVal.mysys.language == 0)
                {
                    cbomode.Items.Add("公式名称");
                    cbomode.Items.Add("公式说明");
                }
                else
                {
                    cbomode.Items.Add("Formula name");
                    cbomode.Items.Add("Formula description");
                }
                if (lstinclude.mlist[lstinclude.SelectedIndex].apply ==false )
                {
                    cbomode.SelectedIndex = 0;
                }
                else
                {
                    cbomode.SelectedIndex = 1;
                }



            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (mtempoutput!=null)
            {
                mtempoutput.myitemsignal.cUnitsel = this.cbocolunit.SelectedIndex;
                mtempoutput.myitemsignal.precise=Convert.ToInt32( this.editcolprecise.Value);
                mtempoutput.limitup=this.editcolup.Value;
                mtempoutput.limitdown=this.editcoldown.Value ;
                if (cbomode.SelectedIndex ==0)
                {
                    mtempoutput.apply = false;
                }
                 else
                {
                    mtempoutput.apply = true;
                }

            }
        }

        private void btnstaticadd_Click(object sender, EventArgs e)
        {
            if (listavail.SelectedItem != null)
            {
                this.listinclude.Items.Add(this.listavail.mlist[this.listavail.SelectedIndex].formulaname);
                this.listinclude.mlist.Add((CComLibrary.outputitem)this.listavail.mlist[this.listavail.SelectedIndex]);
                this.listavail.mlist[this.listavail.SelectedIndex].selected = true;

                listavail.mlist.RemoveAt(this.listavail.SelectedIndex);
                listavail.Items.RemoveAt(this.listavail.SelectedIndex);


            }
        }

        private void btnstaticremove_Click(object sender, EventArgs e)
        {
            if (this.listinclude.SelectedItem != null)
            {
                this.listavail.Items.Add(this.listinclude.mlist[this.listinclude.SelectedIndex].formulaname);
                this.listavail.mlist.Add((CComLibrary.outputitem)this.listinclude.mlist[this.listinclude.SelectedIndex]);
                this.listinclude.mlist[this.listinclude.SelectedIndex].selected = false;

                this.listinclude.mlist.RemoveAt(this.listinclude.SelectedIndex);
                this.listinclude.Items.RemoveAt(this.listinclude.SelectedIndex);


            }
        }

        private void btnup_Click(object sender, EventArgs e)
        {
            string v;
            CComLibrary.outputitem a;
            int index = lstinclude.SelectedIndex;

            if (index <= 0)
            {
            }
            else
            {
                v = this.lstinclude.Items[index] as string;
                a = this.lstinclude.mlist[index];
                this.lstinclude.Items.RemoveAt(index);
                this.lstinclude.mlist.RemoveAt(index);
                this.lstinclude.Items.Insert(index - 1, v);
                this.lstinclude.mlist.Insert(index - 1, a);
                list_setvalue();
            }
        }

        private void btnstaticup_Click(object sender, EventArgs e)
        {
            string v;
            CComLibrary.outputitem a;
            int index = listinclude.SelectedIndex;

            if (index <= 0)
            {
            }
            else
            {
                v = this.listinclude.Items[index] as string;
                a = this.listinclude.mlist[index];
                this.listinclude.Items.RemoveAt(index);
                this.listinclude.mlist.RemoveAt(index);
                this.listinclude.Items.Insert(index - 1, v);
                this.listinclude.mlist.Insert(index - 1, a);
            }
        }

        private void btndown_Click(object sender, EventArgs e)
        {
            string v;
                CComLibrary.outputitem a;

                int index = lstinclude.SelectedIndex;

            if (index == this.lstinclude.Items.Count - 1)
            {
            }
            else
            {
                v = this.lstinclude.Items[index] as string;
                a = this.lstinclude.mlist[index];
                this.lstinclude.Items.RemoveAt(index);
                this.lstinclude.mlist.RemoveAt(index);
                this.lstinclude.Items.Insert(index + 1, v);
                this.lstinclude.mlist.Insert(index + 1, a);
                list_setvalue();

            }
        }

        private void btnstaticdown_Click(object sender, EventArgs e)
        {
            string v;
            CComLibrary.outputitem a;

            int index = listinclude.SelectedIndex;

            if (index == this.listinclude.Items.Count - 1)
            {
            }
            else
            {
                v = this.listinclude.Items[index] as string;
                a = this.listinclude.mlist[index];
                this.listinclude.Items.RemoveAt(index);
                this.listinclude.mlist.RemoveAt(index);
                this.listinclude.Items.Insert(index + 1, v);
                this.listinclude.mlist.Insert(index + 1, a);

            }
        }

        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            TextFormatFlags flags = TextFormatFlags.Left;

            // Align text on the right for the subitems after row 11 in the 
            // first column
            if (e.ColumnIndex == 0)
            {
                flags = TextFormatFlags.Right;
            }
            e.Graphics.DrawImage(imageList1.Images[0],0,0);
            e.DrawText(flags);

        }

        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
            e.DrawBackground();
            e.DrawText();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                if (resulttab == 0)
                {   
                        CComLibrary.GlobeVal.filesave.mtable1para.statisticssel = 0;
                    
                }
                if (resulttab == 1)
                {
                    CComLibrary.GlobeVal.filesave.mtable2para.statisticssel = 0;
                    
                }
            }

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {

            CComLibrary.TablePara mtablepara;
            if (resulttab == 0)
            {

                mtablepara = CComLibrary.GlobeVal.filesave.mtable1para;


            }
            else
            {
                mtablepara = CComLibrary.GlobeVal.filesave.mtable2para;
            }

            if (this.toolStripCboElement.SelectedIndex == 0)
            {
                fontDialog1.Font = mtablepara.mTableHeaderPara.HeaderFont;
                fontDialog1.ShowDialog();

                mtablepara.mTableHeaderPara.HeaderFont = fontDialog1.Font;
                Init格式();
            }
            if (this.toolStripCboElement.SelectedIndex == 1)
            {
                fontDialog1.Font = mtablepara.mTableColPara.ColFont;
                fontDialog1.ShowDialog();

                mtablepara.mTableColPara.ColFont = fontDialog1.Font;
                Init格式();
            }

            if (this.toolStripCboElement.SelectedIndex == 2)
            {
                fontDialog1.Font = mtablepara.mTableGridPara.GridFont;
                fontDialog1.ShowDialog();

                mtablepara.mTableGridPara.GridFont = fontDialog1.Font;
                Init格式();
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            CComLibrary.TablePara mtablepara;

            if (resulttab == 0)
            {
                mtablepara =CComLibrary.GlobeVal.filesave.mtable1para;
            }
            else
            {
                mtablepara =CComLibrary.GlobeVal.filesave.mtable2para;
            }
                if (this.toolStripCboElement.SelectedIndex == 0)
                {
                    this.colorDialog1.Color = mtablepara.mTableHeaderPara.HeaderForeColor;
                    this.colorDialog1.ShowDialog();

                    mtablepara.mTableHeaderPara.HeaderForeColor = this.colorDialog1.Color;
                    Init格式();

                }

                if (this.toolStripCboElement.SelectedIndex == 1)
                {
                    this.colorDialog1.Color = mtablepara.mTableColPara.ColForeColor;
                    this.colorDialog1.ShowDialog();

                    mtablepara.mTableColPara.ColForeColor = this.colorDialog1.Color;
                    Init格式();

                }

                if (this.toolStripCboElement.SelectedIndex == 2)
                {
                    this.colorDialog1.Color = mtablepara.mTableGridPara.GridForeColor;
                    this.colorDialog1.ShowDialog();

                    mtablepara.mTableGridPara.GridForeColor = this.colorDialog1.Color;
                    Init格式();

                }

            
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            CComLibrary.TablePara mtablepara;

            if (resulttab == 0)
            {
                mtablepara = CComLibrary.GlobeVal.filesave.mtable1para;
            }
            else
            {
                mtablepara = CComLibrary.GlobeVal.filesave.mtable2para;
            }
           
                if (this.toolStripCboElement.SelectedIndex == 0)
                {
                    this.colorDialog1.Color = mtablepara.mTableHeaderPara.HeaderBackColor;
                    this.colorDialog1.ShowDialog();

                    mtablepara.mTableHeaderPara.HeaderBackColor = this.colorDialog1.Color;
                    Init格式();

                }
                if (this.toolStripCboElement.SelectedIndex == 1)
                {
                    this.colorDialog1.Color = mtablepara.mTableColPara.ColBackColor;
                    this.colorDialog1.ShowDialog();

                    mtablepara.mTableColPara.ColBackColor = this.colorDialog1.Color;
                    Init格式();

                }
                if (this.toolStripCboElement.SelectedIndex == 2)
                {
                    this.colorDialog1.Color = mtablepara.mTableGridPara.GridBackColor;
                    this.colorDialog1.ShowDialog();

                    mtablepara.mTableGridPara.GridBackColor = this.colorDialog1.Color;
                    Init格式();

                }
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (resulttab == 0)
            {
                if (this.toolStripCboElement.SelectedIndex == 0)
                {
                    CComLibrary.GlobeVal.filesave.mtable1para.mTableHeaderPara.HeaderAlignment = ContentAlignment.MiddleLeft;
                    Init格式();
                }
                if (this.toolStripCboElement.SelectedIndex == 1)
                {
                    CComLibrary.GlobeVal.filesave.mtable1para.mTableColPara.ColAlignment = ContentAlignment.MiddleLeft;
                    Init格式();
                }
                if (this.toolStripCboElement.SelectedIndex == 2)
                {
                    CComLibrary.GlobeVal.filesave.mtable1para.mTableGridPara.GridAlignment = ContentAlignment.MiddleLeft;
                    Init格式();
                }


            }

            if (resulttab == 1)
            {
                if (this.toolStripCboElement.SelectedIndex == 0)
                {
                    CComLibrary.GlobeVal.filesave.mtable2para.mTableHeaderPara.HeaderAlignment = ContentAlignment.MiddleLeft;
                    Init格式();
                }
                if (this.toolStripCboElement.SelectedIndex == 1)
                {
                    CComLibrary.GlobeVal.filesave.mtable2para.mTableColPara.ColAlignment = ContentAlignment.MiddleLeft;
                    Init格式();
                }
                if (this.toolStripCboElement.SelectedIndex == 2)
                {
                    CComLibrary.GlobeVal.filesave.mtable2para.mTableGridPara.GridAlignment = ContentAlignment.MiddleLeft;
                    Init格式();
                }
            }
           

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (resulttab == 0)
            {
                if (this.toolStripCboElement.SelectedIndex == 0)
                {
                    CComLibrary.GlobeVal.filesave.mtable1para.mTableHeaderPara.HeaderAlignment = ContentAlignment.MiddleCenter;
                    Init格式();
                }
                if (this.toolStripCboElement.SelectedIndex == 1)
                {
                    CComLibrary.GlobeVal.filesave.mtable1para.mTableColPara.ColAlignment = ContentAlignment.MiddleCenter;
                    Init格式();
                }
                if (this.toolStripCboElement.SelectedIndex == 2)
                {
                    CComLibrary.GlobeVal.filesave.mtable1para.mTableGridPara.GridAlignment = ContentAlignment.MiddleCenter;
                    Init格式();
                }


            }

            if (resulttab == 1)
            {
                if (this.toolStripCboElement.SelectedIndex == 0)
                {
                    CComLibrary.GlobeVal.filesave.mtable2para.mTableHeaderPara.HeaderAlignment = ContentAlignment.MiddleCenter;
                    Init格式();
                }
                if (this.toolStripCboElement.SelectedIndex == 1)
                {
                    CComLibrary.GlobeVal.filesave.mtable2para.mTableColPara.ColAlignment = ContentAlignment.MiddleCenter;
                    Init格式();
                }
                if (this.toolStripCboElement.SelectedIndex == 2)
                {
                    CComLibrary.GlobeVal.filesave.mtable2para.mTableGridPara.GridAlignment = ContentAlignment.MiddleCenter;
                    Init格式();
                }
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (resulttab == 0)
            {
                if (this.toolStripCboElement.SelectedIndex == 0)
                {
                    CComLibrary.GlobeVal.filesave.mtable1para.mTableHeaderPara.HeaderAlignment = ContentAlignment.MiddleRight;
                    Init格式();
                }
                if (this.toolStripCboElement.SelectedIndex == 1)
                {
                    CComLibrary.GlobeVal.filesave.mtable1para.mTableColPara.ColAlignment = ContentAlignment.MiddleRight;
                    Init格式();
                }
                if (this.toolStripCboElement.SelectedIndex == 2)
                {
                    CComLibrary.GlobeVal.filesave.mtable1para.mTableGridPara.GridAlignment = ContentAlignment.MiddleRight;
                    Init格式();
                }


            }

            if (resulttab == 1)
            {
                if (this.toolStripCboElement.SelectedIndex == 0)
                {
                    CComLibrary.GlobeVal.filesave.mtable2para.mTableHeaderPara.HeaderAlignment = ContentAlignment.MiddleRight;
                    Init格式();
                }
                if (this.toolStripCboElement.SelectedIndex == 1)
                {
                    CComLibrary.GlobeVal.filesave.mtable2para.mTableColPara.ColAlignment = ContentAlignment.MiddleRight;
                    Init格式();
                }
                if (this.toolStripCboElement.SelectedIndex == 2)
                {
                    CComLibrary.GlobeVal.filesave.mtable2para.mTableGridPara.GridAlignment = ContentAlignment.MiddleRight;
                    Init格式();
                }
            }
        }

        private void chkspe_CheckedChanged(object sender, EventArgs e)
        {
            if (resulttab == 0)
            {
                CComLibrary.GlobeVal.filesave.mtable1para.showvalidspe = chkspe.Checked;

                Init格式();
            }

            if (resulttab == 1)
            {
                CComLibrary.GlobeVal.filesave.mtable2para.showvalidspe = chkspe.Checked;
                Init格式();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                if (resulttab == 0)
                {
                    CComLibrary.GlobeVal.filesave.mtable1para.statisticssel = 1;

                }
                if (resulttab == 1)
                {
                    CComLibrary.GlobeVal.filesave.mtable2para.statisticssel = 1;

                }
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                if (resulttab == 0)
                {
                    CComLibrary.GlobeVal.filesave.mtable1para.statisticssel = 2;

                }
                if (resulttab == 1)
                {
                    CComLibrary.GlobeVal.filesave.mtable2para.statisticssel = 2;

                }
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Click(object sender, EventArgs e)
        {
            lstinclude.Items.Clear();
            list_setvalue();
        }

        private void lstinclude_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
