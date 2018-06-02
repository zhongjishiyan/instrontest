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
    public partial class UserControl常规 : UserControl
    {

        public UserControlMethod musercontrolmethod;


        private class PPP
        {
            public string caption;
            public int x;
            public int y;
            public int xx;
            public int yy;
            public PPP(int mx, int my)
            {
                x = mx;
                y = my;

                xx = 1;
                yy = 1;
            }

        }
        public void Open_method()
        {
            grid1.Enabled = false;
            grid1.RowsCount = 0;
            grid1.AutoStretchColumnsToFitWidth = true;

            grid1.BorderStyle = BorderStyle.FixedSingle;

            grid1.ColumnsCount = 2;
            grid1.Columns[0].Width = grid1.Width / 2;
            grid1.Columns[1].Width = grid1.Width - grid1.Columns[0].Width - 1;

            grid1.Columns[1].AutoSizeMode = SourceGrid2.AutoSizeMode.EnableStretch;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1[0, 0] = new SourceGrid2.Cells.Real.ColumnHeader("名称");
            grid1[0, 1] = new SourceGrid2.Cells.Real.ColumnHeader("单位");
            for (int i = 1; i <= ClsStaticStation.m_Global.mycls.allsignals.Count; i++)
            {
                grid1.Rows.Insert(i);
                grid1[i, 0] = new SourceGrid2.Cells.Real.Cell(
                    ClsStaticStation.m_Global.mycls.allsignals[i - 1].cName, typeof(string));

                grid1[i, 1] = new SourceGrid2.Cells.Real.ComboBox(
                    ClsStaticStation.m_Global.mycls.allsignals[i - 1].cUnits[
                    ClsStaticStation.m_Global.mycls.allsignals[i - 1].cUnitsel], typeof(string),
                    ClsStaticStation.m_Global.mycls.allsignals[i - 1].cUnits, false);


            }
            /*
            for (int i = 1 + ClsStaticStation.m_Global.mycls.hardsignals.Count;
                i <= CComLibrary.GlobeVal.filesave.muserchannel.Count + ClsStaticStation.m_Global.mycls.hardsignals.Count; i++)
            {
                grid1.Rows.Insert(i);

                grid1[i, 0] = new SourceGrid2.Cells.Real.Cell(
                   CComLibrary.GlobeVal.filesave.muserchannel[i - 1 - ClsStaticStation.m_Global.mycls.hardsignals.Count].channelname, typeof(string));
                grid1[i, 1] = new SourceGrid2.Cells.Real.ComboBox(
                   CComLibrary.GlobeVal.filesave.muserchannel[i - 1 - ClsStaticStation.m_Global.mycls.hardsignals.Count].myitemsignal.cUnits[
                   CComLibrary.GlobeVal.filesave.muserchannel[i - 1 - ClsStaticStation.m_Global.mycls.hardsignals.Count].myitemsignal.cUnitsel], typeof(string),
                  CComLibrary.GlobeVal.filesave.muserchannel[i - 1 - ClsStaticStation.m_Global.mycls.hardsignals.Count].myitemsignal.cUnits, false);

            }
             * */

            GlobeVal.putlistboxitem(listBox1);



        }

        public void ClearMethod()
        {
            CComLibrary.GlobeVal.filesave = null;
            txtmethodname.Text = "";
            txtmethodpath.Text = "";
            grid1.RowsCount = 0;
            listBox1.Items.Clear();



        }

        public void OpenRecentMethod()
        {
            if (listView1.SelectedIndices.Count > 0)
            {

                string fileName = System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\Method\\" + listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text + "\\"
                    + listView1.Items[listView1.SelectedIndices[0]].Text + ".dat";


                if (System.IO.File.Exists(fileName) == true)
                {

                }
                else
                {
                    MessageBox.Show("方法不存在");
                    return;
                }

                if (fileName == "")
                {
                    return;
                }
                else
                {


                    CComLibrary.GlobeVal.currentfilesavename = fileName;

                    this.txtmethodname.Text = System.IO.Path.GetFileNameWithoutExtension(fileName);
                    this.txtmethodpath.Text = System.IO.Path.GetDirectoryName(fileName);

                    if (CComLibrary.GlobeVal.filesave == null)
                    {
                        CComLibrary.GlobeVal.filesave = new CComLibrary.FileStruct();
                    }
                    CComLibrary.GlobeVal.filesave = CComLibrary.GlobeVal.filesave.DeSerializeNow(fileName);



                    if (System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\report\\" + CComLibrary.GlobeVal.filesave.ReportTemplate) == true)
                    {

                        GlobeVal.UserControlMain1.userreport1.mReportApp = GlobeVal.UserControlMain1.userreport1.mReportApp.DeSerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\report\\" + CComLibrary.GlobeVal.filesave.ReportTemplate);

                    }


                    CComLibrary.GlobeVal.currentfilesavename = fileName;

                    GlobeVal.putlistboxitem(listBox1);





                    ListViewItem lv = new ListViewItem();
                    lv.Text = this.txtmethodname.Text;


                    lv.SubItems.Add(ClsStaticStation.m_Global.mycls.TestkindList[CComLibrary.GlobeVal.filesave.methodkind]);
                    lv.SubItems.Add(System.IO.File.GetLastWriteTime(fileName).ToLongDateString() + " " + System.IO.File.GetLastWriteTime(fileName).ToLongTimeString());





                    if (this.txtmethodname.Text == listView1.Items[0].Text)
                    {
                        listView1.Items.RemoveAt(0);
                    }

                    if (listView1.Items.Count >= 20)
                    {
                        listView1.Items.RemoveAt(19);
                    }
                    listView1.Items.Insert(0, lv);

                    for (int i = 0; i < listView1.Items.Count; i++)
                    {

                        GlobeVal.mysys.RecentFilename[i] = listView1.Items[i].Text;
                        GlobeVal.mysys.RecentFilenameKind[i] = listView1.Items[i].SubItems[1].Text;
                    }

                    for (int i = listView1.Items.Count; i < 20; i++)
                    {
                        GlobeVal.mysys.RecentFilename[i] = "";
                        GlobeVal.mysys.RecentFilenameKind[i] = "";
                    }


                    Open_method();
                    ClsStaticStation.m_Global.mycls.initchannel();


                    ((FormMainLab)Application.OpenForms["FormMainLab"]).InitKey();
                    ((FormMainLab)Application.OpenForms["FormMainLab"]).InitMeter();
                }




            }

            else
            {
                MessageBox.Show("请选择最近使用的试验方法");
            }
        }

        public void Init(int sel, bool method)
        {
            tabControl1.SelectedIndex = sel;
            if (method == false)
            {
                lblunit.Text = "单位系统：";
                tabControl2.SelectedIndex = 1;
            }
            else
            {
                lblunit.Text = "最近使用的方法：";
                tabControl2.SelectedIndex = 0;

                listView1.Items.Clear();
                string fileName;
                for (int i = 0; i < 20; i++)
                {
                    if (GlobeVal.mysys.RecentFilename[i] == "")
                    {
                    }
                    else
                    {
                        ListViewItem lv = new ListViewItem();
                        lv.Text = GlobeVal.mysys.RecentFilename[i];



                        lv.SubItems.Add(GlobeVal.mysys.RecentFilenameKind[i]);
                        fileName = System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\Method\\" + GlobeVal.mysys.RecentFilenameKind[i] + "\\" + GlobeVal.mysys.RecentFilename[i] + ".dat";

                        if (System.IO.File.Exists(fileName) == true)
                        {
                            lv.SubItems.Add(System.IO.File.GetLastWriteTime(fileName).ToLongDateString() + " " + System.IO.File.GetLastWriteTime(fileName).ToLongTimeString());
                        }
                        listView1.Items.Add(lv);
                    }
                }

            }

            if (sel > 0)
            {

                if (GlobeVal.UserControlMain1.btnmtest.Visible == true)
                {
                    tabControl1.Enabled = false;
                }
                else
                {
                    tabControl1.Enabled = true;
                }
            }

            if (sel == 1)
            {


                txtmemo1.Text = CComLibrary.GlobeVal.filesave.samplememo1;
                txtmemo2.Text = CComLibrary.GlobeVal.filesave.samplememo2;
                txtmemo3.Text = CComLibrary.GlobeVal.filesave.samplememo3;
                txtmemo.Text = CComLibrary.GlobeVal.filesave.samplememo;
                txtauthor.Text = CComLibrary.GlobeVal.filesave.methodauthor;
                txtmethodmemo.Text = CComLibrary.GlobeVal.filesave.methodmemo;


            }

            if (sel == 2)
            {
                txtlay.Text = CComLibrary.GlobeVal.filesave.layfilename;
            }

        }


        public UserControl常规()
        {
            InitializeComponent();
            tabControl1.ItemSize = new Size(1, 1);

            tabControl2.ItemSize = new Size(1, 1);
        }



        private void button1_Click(object sender, EventArgs e)
        {

            tlbe.Controls.Clear();
            tlbe.ColumnCount = 1;
            tlbe.RowCount = 1;
            btnadvanceadd.Enabled = true;
            btnadvancedec.Enabled = true;
            结果1ToolStripMenuItem.Enabled = true;
            结果2ToolStripMenuItem.Enabled = true;
            曲线图1ToolStripMenuItem.Enabled = true;
            曲线图2ToolStripMenuItem.Enabled = true;
            仪表1ToolStripMenuItem.Enabled = true;
            仪表2ToolStripMenuItem.Enabled = true;
            试样输入ToolStripMenuItem.Enabled = true;
            this.原始数据ToolStripMenuItem.Enabled = true;
            this.摄像ToolStripMenuItem.Enabled = true;
            this.状态提示ToolStripMenuItem.Enabled = true;
            this.过程提示ToolStripMenuItem.Enabled = true;
            this.长时数据ToolStripMenuItem.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        void label1_MouseMove(object sender, MouseEventArgs e)
        {

            tlbe.getxy(e.Location.X, e.Location.Y);
            this.Cursor = Cursors.Default;




        }

        private void tlbe_Paint(object sender, PaintEventArgs e)
        {


        }

        private void tlbe_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {

        }

        private void tlbe_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void tlbe_Click(object sender, EventArgs e)
        {

        }

        private void label6_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void tlbe_MouseMove(object sender, MouseEventArgs e)
        {
            label5.Text = tlbe.SelectColumn.ToString();
            label6.Text = tlbe.SelectRow.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (tlbe.RowCount < 10)
            {
                tlbe.RowCount = tlbe.RowCount + 1;
                tlbe.ResetSizeAndSizeTypes();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (tlbe.ColumnCount < 10)
            {
                tlbe.ColumnCount = tlbe.ColumnCount + 1;
                tlbe.ResetSizeAndSizeTypes();
            }
        }

        private void 结果1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button label1;
            label1 = new Button();
            label1.TextImageRelation = TextImageRelation.ImageAboveText;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Text = "结果1";
            label1.AutoSize = false;
            label1.Dock = DockStyle.Fill;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            tlbe.SetCellPosition(label1, new TableLayoutPanelCellPosition(tlbe.SelectColumn, tlbe.SelectRow));
            //label1.ContextMenuStrip  = this.contextMenuStrip2;
            label1.BackColor = Color.White;
            label1.ForeColor = Color.Blue;
            label1.Image = imageList1.Images[1];
            label1.ImageAlign = ContentAlignment.MiddleCenter;

            PPP mp = new PPP(tlbe.SelectColumn, tlbe.SelectRow);
            mp.caption = label1.Text;
            label1.Tag = mp;
            label1.MouseUp += new MouseEventHandler(label1_MouseUp);
            label1.MouseMove += new MouseEventHandler(label1_MouseMove);

            btnadvanceadd.Enabled = false;
            btnadvancedec.Enabled = false;
            结果1ToolStripMenuItem.Enabled = false;
            tlbe.Controls.Add(label1);

        }


        private void 删除对象ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PPP e1 = this.contextMenuStrip2.Tag as PPP;




            if (tlbe.GetControlFromPosition(e1.x, e1.y) == null)
            {
            }
            else
            {



                tlbe.Controls.Remove(tlbe.GetControlFromPosition(e1.x, e1.y));

                if (e1.caption == "结果1")
                {
                    结果1ToolStripMenuItem.Enabled = true;
                }

                if (e1.caption == "结果2")
                {
                    结果2ToolStripMenuItem.Enabled = true;
                }

                if (e1.caption == "曲线图1")
                {
                    曲线图1ToolStripMenuItem.Enabled = true;
                }
                if (e1.caption == "曲线图2")
                {
                    曲线图2ToolStripMenuItem.Enabled = true;
                }

                if (e1.caption == "仪表1")
                {
                    仪表1ToolStripMenuItem.Enabled = true;
                }

                if (e1.caption == "仪表2")
                {
                    仪表2ToolStripMenuItem.Enabled = true;
                }
                if (e1.caption == "试样输入")
                {
                    试样输入ToolStripMenuItem.Enabled = true;
                }

                if (e1.caption == "原始数据")
                {
                    this.原始数据ToolStripMenuItem.Enabled = true;
                }

                if (e1.caption == "摄像")
                {
                    this.摄像ToolStripMenuItem.Enabled = true;

                }
                if (e1.caption == "过程提示")
                {
                    this.过程提示ToolStripMenuItem.Enabled = true;
                }

                if (e1.caption == "状态提示")
                {
                    this.状态提示ToolStripMenuItem.Enabled = true;
                }

                if (e1.caption == "峰值趋势数据")
                {
                    this.长时数据ToolStripMenuItem.Enabled = true;
                }
            }
        }

        private void 水平扩展ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PPP e1 = this.contextMenuStrip2.Tag as PPP;

            if (tlbe.GetControlFromPosition(e1.x + e1.xx, e1.y) == null)
            {

                e1.xx = e1.xx + 1;

                if (e1.x + e1.xx > tlbe.ColumnCount)
                {
                    MessageBox.Show("扩展到头");
                }
                else
                {
                    this.contextMenuStrip2.Tag = e1;

                    tlbe.SetColumnSpan(tlbe.GetControlFromPosition(e1.x, e1.y), e1.xx);

                    e1.xx = tlbe.GetColumnSpan(tlbe.GetControlFromPosition(e1.x, e1.y));
                }
            }
            else
            {
                MessageBox.Show("扩展到头");
            }


        }

        private void 垂直增加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PPP e1 = this.contextMenuStrip2.Tag as PPP;

            if (tlbe.GetControlFromPosition(e1.x, e1.y + e1.yy) == null)
            {

                e1.yy = e1.yy + 1;

                if (e1.y + e1.yy > tlbe.RowCount)
                {
                    MessageBox.Show("扩展到头");
                }
                else
                {
                    this.contextMenuStrip2.Tag = e1;

                    tlbe.SetRowSpan(tlbe.GetControlFromPosition(e1.x, e1.y), e1.yy);
                    e1.yy = tlbe.GetRowSpan(tlbe.GetControlFromPosition(e1.x, e1.y));
                }
            }
            else
            {
                MessageBox.Show("扩展到头");
            }

        }

        private void 水平减少ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PPP e1 = this.contextMenuStrip2.Tag as PPP;
            if (e1.xx > 1)
            {
                e1.xx = e1.xx - 1;
                this.contextMenuStrip2.Tag = e1;
                tlbe.SetColumnSpan(tlbe.GetControlFromPosition(e1.x, e1.y), e1.xx);
            }

        }

        private void 垂直减少ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PPP e1 = this.contextMenuStrip2.Tag as PPP;
            if (e1.yy > 1)
            {
                e1.yy = e1.yy - 1;
                this.contextMenuStrip2.Tag = e1;
                tlbe.SetRowSpan(tlbe.GetControlFromPosition(e1.x, e1.y), e1.yy);
            }

        }

        private void 结果2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button label1;
            label1 = new Button();
            label1.TextImageRelation = TextImageRelation.ImageAboveText;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Text = "结果2";
            label1.AutoSize = false;
            label1.Dock = DockStyle.Fill;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            tlbe.SetCellPosition(label1, new TableLayoutPanelCellPosition(tlbe.SelectColumn, tlbe.SelectRow));
            //label1.ContextMenuStrip = this.contextMenuStrip2;
            label1.BackColor = Color.White;
            label1.ForeColor = Color.Blue;
            label1.Image = imageList1.Images[1];
            label1.ImageAlign = ContentAlignment.MiddleCenter;

            PPP mp = new PPP(tlbe.SelectColumn, tlbe.SelectRow);
            mp.caption = label1.Text;
            label1.Tag = mp;
            label1.MouseUp += new MouseEventHandler(label1_MouseUp);
            label1.MouseMove += new MouseEventHandler(label1_MouseMove);

            btnadvanceadd.Enabled = false;
            btnadvancedec.Enabled = false;
            结果2ToolStripMenuItem.Enabled = false;
            tlbe.Controls.Add(label1);
        }

        private void 曲线图1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button label1;
            label1 = new Button();
            label1.TextImageRelation = TextImageRelation.ImageAboveText;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Text = "曲线图1";
            label1.AutoSize = false;
            label1.Dock = DockStyle.Fill;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            tlbe.SetCellPosition(label1, new TableLayoutPanelCellPosition(tlbe.SelectColumn, tlbe.SelectRow));
            //label1.ContextMenuStrip = this.contextMenuStrip2;
            label1.BackColor = Color.White;
            label1.ForeColor = Color.Blue;
            label1.Image = imageList1.Images[0];
            label1.ImageAlign = ContentAlignment.MiddleCenter;

            PPP mp = new PPP(tlbe.SelectColumn, tlbe.SelectRow);
            mp.caption = label1.Text;
            label1.Tag = mp;

            label1.MouseMove += new MouseEventHandler(label1_MouseMove);
            label1.MouseUp += new MouseEventHandler(label1_MouseUp);
            btnadvanceadd.Enabled = false;
            btnadvancedec.Enabled = false;
            曲线图1ToolStripMenuItem.Enabled = false;
            tlbe.Controls.Add(label1);
        }

        private void 曲线图2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button label1;
            label1 = new Button();
            label1.TextImageRelation = TextImageRelation.ImageAboveText;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Text = "曲线图2";
            label1.AutoSize = false;
            label1.Dock = DockStyle.Fill;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            tlbe.SetCellPosition(label1, new TableLayoutPanelCellPosition(tlbe.SelectColumn, tlbe.SelectRow));
            //label1.ContextMenuStrip = this.contextMenuStrip2;

            label1.Image = imageList1.Images[0];
            label1.ImageAlign = ContentAlignment.MiddleCenter;

            label1.BackColor = Color.White;
            label1.ForeColor = Color.Blue;
            label1.MouseUp += new MouseEventHandler(label1_MouseUp);
            PPP mp = new PPP(tlbe.SelectColumn, tlbe.SelectRow);
            mp.caption = label1.Text;
            label1.Tag = mp;

            label1.MouseMove += new MouseEventHandler(label1_MouseMove);
            label1.MouseUp += new MouseEventHandler(label1_MouseUp);
            btnadvanceadd.Enabled = false;
            btnadvancedec.Enabled = false;
            曲线图2ToolStripMenuItem.Enabled = false;
            tlbe.Controls.Add(label1);

        }

        void label1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                contextMenuStrip2.Tag = (sender as Button).Tag;

                contextMenuStrip2.Show((sender as Button).PointToScreen(e.Location));
            }
        }

        private void 仪表1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button label1;
            label1 = new Button();
            label1.Text = "仪表1";
            label1.TextImageRelation = TextImageRelation.ImageAboveText;
            label1.FlatStyle = FlatStyle.Flat;

            label1.AutoSize = false;
            label1.Dock = DockStyle.Fill;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            tlbe.SetCellPosition(label1, new TableLayoutPanelCellPosition(tlbe.SelectColumn, tlbe.SelectRow));
            //label1.ContextMenuStrip = this.contextMenuStrip2;
            label1.BackColor = Color.White;
            label1.ForeColor = Color.Blue;
            label1.Image = imageList1.Images[3];
            label1.ImageAlign = ContentAlignment.MiddleCenter;


            PPP mp = new PPP(tlbe.SelectColumn, tlbe.SelectRow);
            mp.caption = label1.Text;
            label1.Tag = mp;

            label1.MouseMove += new MouseEventHandler(label1_MouseMove);
            label1.MouseUp += new MouseEventHandler(label1_MouseUp);
            btnadvanceadd.Enabled = false;
            btnadvancedec.Enabled = false;
            仪表1ToolStripMenuItem.Enabled = false;
            tlbe.Controls.Add(label1);
        }

        private void 仪表2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button label1;
            label1 = new Button();
            label1.TextImageRelation = TextImageRelation.ImageAboveText;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Text = "仪表2";
            label1.AutoSize = false;
            label1.Dock = DockStyle.Fill;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            tlbe.SetCellPosition(label1, new TableLayoutPanelCellPosition(tlbe.SelectColumn, tlbe.SelectRow));
            label1.ContextMenuStrip = this.contextMenuStrip2;
            label1.BackColor = Color.White;
            label1.ForeColor = Color.Blue;
            label1.Image = imageList1.Images[3];
            label1.ImageAlign = ContentAlignment.MiddleCenter;
            PPP mp = new PPP(tlbe.SelectColumn, tlbe.SelectRow);
            mp.caption = label1.Text;
            label1.Tag = mp;

            label1.MouseMove += new MouseEventHandler(label1_MouseMove);
            label1.MouseUp += new MouseEventHandler(label1_MouseUp);
            btnadvanceadd.Enabled = false;
            btnadvancedec.Enabled = false;
            仪表2ToolStripMenuItem.Enabled = false;
            tlbe.Controls.Add(label1);


        }

        private void 试样输入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button label1;
            label1 = new Button();
            label1.TextImageRelation = TextImageRelation.ImageAboveText;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Text = "试样输入";
            label1.AutoSize = false;
            label1.Dock = DockStyle.Fill;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            tlbe.SetCellPosition(label1, new TableLayoutPanelCellPosition(tlbe.SelectColumn, tlbe.SelectRow));
            //label1.ContextMenuStrip = this.contextMenuStrip2;
            label1.BackColor = Color.White;
            label1.ForeColor = Color.Blue;
            label1.Image = imageList1.Images[2];
            label1.ImageAlign = ContentAlignment.MiddleCenter;
            PPP mp = new PPP(tlbe.SelectColumn, tlbe.SelectRow);
            mp.caption = label1.Text;
            label1.Tag = mp;

            label1.MouseMove += new MouseEventHandler(label1_MouseMove);
            label1.MouseUp += new MouseEventHandler(label1_MouseUp);

            btnadvanceadd.Enabled = false;
            btnadvancedec.Enabled = false;
            试样输入ToolStripMenuItem.Enabled = false;
            tlbe.Controls.Add(label1);
        }

        private void btnreadlayout_Click(object sender, EventArgs e)
        {

            结果1ToolStripMenuItem.Enabled = true;
            结果2ToolStripMenuItem.Enabled = true;
            曲线图1ToolStripMenuItem.Enabled = true;
            曲线图2ToolStripMenuItem.Enabled = true;
            仪表1ToolStripMenuItem.Enabled = true;
            仪表2ToolStripMenuItem.Enabled = true;
            试样输入ToolStripMenuItem.Enabled = true;
            this.原始数据ToolStripMenuItem.Enabled = true;
            this.摄像ToolStripMenuItem.Enabled = true;
            this.状态提示ToolStripMenuItem.Enabled = true;
            this.过程提示ToolStripMenuItem.Enabled = true;

            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "(*.lay" + ")|*.lay";
            openFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\layout\\";
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName == "")
            {

            }

            else
            {

                tlbe.Controls.Clear();
                tlbe.RowCount = 1;
                tlbe.ColumnCount = 1;


                CComLibrary.FileLayoutStruct f = new CComLibrary.FileLayoutStruct();

                f = f.DeSerializeNow(openFileDialog1.FileName);

                tlbe.RowCount = f.rowcount;
                tlbe.ColumnCount = f.colcount;

                for (int i = 0; i < f.colcount; i++)
                {
                    tlbe.GetColumnWidths()[i] = f.colWidth[i];
                }
                for (int i = 0; i < f.rowcount; i++)
                {
                    tlbe.GetRowHeights()[i] = f.rowheight[i];
                }

                for (int k = 0; k < 20; k++)
                {
                    if (f.Show[k] == true)
                    {
                        Button label1 = new Button();
                        label1.Text = f.ItemName[k];
                        label1.AutoSize = false;
                        label1.Dock = DockStyle.Fill;
                        label1.TextImageRelation = TextImageRelation.ImageAboveText;
                        label1.TextAlign = ContentAlignment.MiddleCenter;
                        label1.BackColor = Color.White;
                        label1.ForeColor = Color.Blue;
                        PPP mp = new PPP(f.ItemCol[k], f.ItemRow[k]);
                        mp.x = f.ItemCol[k];
                        mp.y = f.ItemRow[k];
                        mp.xx = f.ItemColSpan[k];
                        mp.yy = f.ItemRowSpan[k];

                        mp.caption = label1.Text;
                        label1.Tag = mp;

                        label1.MouseMove += new MouseEventHandler(label1_MouseMove);
                        label1.MouseUp += new MouseEventHandler(label1_MouseUp);

                        tlbe.SetCellPosition(label1, new TableLayoutPanelCellPosition(f.ItemCol[k], f.ItemRow[k]));

                        tlbe.SetColumnSpan(label1, f.ItemColSpan[k]);
                        tlbe.SetRowSpan(label1, f.ItemRowSpan[k]);
                        btnadvanceadd.Enabled = false;
                        btnadvancedec.Enabled = false;
                        tlbe.Controls.Add(label1);

                        if (label1.Text == "试样输入")
                        {
                            试样输入ToolStripMenuItem.Enabled = false;
                            label1.Image = imageList1.Images[2];
                            label1.ImageAlign = ContentAlignment.MiddleCenter;
                        }

                        if (label1.Text == "曲线图1")
                        {
                            曲线图1ToolStripMenuItem.Enabled = false;
                            label1.Image = imageList1.Images[0];
                            label1.ImageAlign = ContentAlignment.MiddleCenter;
                        }

                        if (label1.Text == "曲线图2")
                        {
                            曲线图2ToolStripMenuItem.Enabled = false;
                            label1.Image = imageList1.Images[0];
                            label1.ImageAlign = ContentAlignment.MiddleCenter;
                        }

                        if (label1.Text == "结果1")
                        {
                            结果1ToolStripMenuItem.Enabled = false;
                            label1.Image = imageList1.Images[1];
                            label1.ImageAlign = ContentAlignment.MiddleCenter;
                        }
                        if (label1.Text == "结果2")
                        {
                            结果2ToolStripMenuItem.Enabled = false;
                            label1.Image = imageList1.Images[1];
                            label1.ImageAlign = ContentAlignment.MiddleCenter;
                        }
                        if (label1.Text == "仪表1")
                        {
                            仪表1ToolStripMenuItem.Enabled = false;
                            label1.Image = imageList1.Images[3];
                            label1.ImageAlign = ContentAlignment.MiddleCenter;
                        }

                        if (label1.Text == "仪表2")
                        {
                            仪表2ToolStripMenuItem.Enabled = false;
                            label1.Image = imageList1.Images[3];
                            label1.ImageAlign = ContentAlignment.MiddleCenter;
                        }

                        if (label1.Text == "原始数据")
                        {
                            原始数据ToolStripMenuItem.Enabled = false;
                            label1.Image = imageList1.Images[4];
                            label1.ImageAlign = ContentAlignment.MiddleCenter;
                        }

                        if (label1.Text == "摄像")
                        {
                            this.摄像ToolStripMenuItem.Enabled = false;
                            label1.Image = imageList1.Images[5];
                            label1.ImageAlign = ContentAlignment.MiddleCenter;
                        }

                        if (label1.Text == "过程提示")
                        {
                            this.过程提示ToolStripMenuItem.Enabled = false;
                            label1.Image = imageList1.Images[6];
                            label1.ImageAlign = ContentAlignment.MiddleCenter;
                        }

                        if (label1.Text == "状态提示")
                        {
                            this.状态提示ToolStripMenuItem.Enabled = false;
                            label1.Image = imageList1.Images[7];
                            label1.ImageAlign = ContentAlignment.MiddleCenter;
                        }
                        if (label1.Text == "峰值趋势数据")
                        {
                            this.长时数据ToolStripMenuItem.Enabled = false;
                            label1.Image = imageList1.Images[4];
                            label1.ImageAlign = ContentAlignment.MiddleCenter;
                        }

                    }
                }
            }

        }

        private void btnsavelayout_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "(*.lay" + ")|*.lay";
            saveFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\layout\\";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName == "")
            {
            }

            else
            {


                CComLibrary.FileLayoutStruct f = new CComLibrary.FileLayoutStruct();
                f.colcount = tlbe.ColumnCount;
                f.rowcount = tlbe.RowCount;
                for (int i = 0; i < f.colcount; i++)
                {
                    f.colWidth[i] = tlbe.GetColumnWidths()[i];
                }
                for (int i = 0; i < f.rowcount; i++)
                {
                    f.rowheight[i] = tlbe.GetRowHeights()[i];
                }

                for (int i = 0; i < 20; i++)
                {
                    f.ItemName[i] = "";
                    f.Show[i] = false;
                }

                f.ItemName[0] = "结果1";
                f.ItemName[1] = "结果2";
                f.ItemName[2] = "曲线图1";
                f.ItemName[3] = "曲线图2";
                f.ItemName[4] = "仪表1";
                f.ItemName[5] = "仪表2";
                f.ItemName[6] = "试样输入";
                f.ItemName[7] = "原始数据";
                f.ItemName[8] = "摄像";
                f.ItemName[9] = "过程提示";
                f.ItemName[10] = "状态提示";
                f.ItemName[11] = "峰值趋势数据";


                for (int i = 0; i < f.colcount; i++)
                {
                    for (int j = 0; j < f.rowcount; j++)
                    {
                        if (tlbe.GetControlFromPosition(i, j) == null)
                        {

                        }
                        else
                        {
                            for (int k = 0; k < 20; k++)
                            {
                                if (f.ItemName[k] == (tlbe.GetControlFromPosition(i, j) as Button).Text)
                                {

                                    f.ItemCol[k] = ((tlbe.GetControlFromPosition(i, j) as Button).Tag as PPP).x;
                                    f.ItemRow[k] = ((tlbe.GetControlFromPosition(i, j) as Button).Tag as PPP).y;
                                    f.ItemColSpan[k] = ((tlbe.GetControlFromPosition(i, j) as Button).Tag as PPP).xx;
                                    f.ItemRowSpan[k] = ((tlbe.GetControlFromPosition(i, j) as Button).Tag as PPP).yy;
                                    f.Show[k] = true;
                                }
                            }

                        }
                    }
                }

                f.width = tlbe.Width;
                f.height = tlbe.Height;

                f.SerializeNow(saveFileDialog1.FileName);


            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "(*.lay" + ")|*.lay";
            openFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\layout\\";
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName == "")
            {

            }

            else
            {
                tlbebase.Controls.Clear();
                tlbebase.RowCount = 1;
                tlbebase.ColumnCount = 1;


                txtlay.Text = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);

                CComLibrary.FileLayoutStruct f = new CComLibrary.FileLayoutStruct();

                f = f.DeSerializeNow(openFileDialog1.FileName);

                tlbebase.RowCount = f.rowcount;
                tlbebase.ColumnCount = f.colcount;

                for (int i = 0; i < f.colcount; i++)
                {
                    tlbebase.GetColumnWidths()[i] = f.colWidth[i];
                }
                for (int i = 0; i < f.rowcount; i++)
                {
                    tlbebase.GetRowHeights()[i] = f.rowheight[i];
                }

                for (int k = 0; k < 20; k++)
                {
                    if (f.Show[k] == true)
                    {
                        Button label1 = new Button();

                        label1.FlatStyle = FlatStyle.Flat;
                        label1.Text = f.ItemName[k];
                        label1.AutoSize = false;
                        label1.Dock = DockStyle.Fill;
                        label1.TextAlign = ContentAlignment.MiddleCenter;
                        label1.BackColor = Color.White;
                        label1.ForeColor = Color.Blue;
                        PPP mp = new PPP(f.ItemCol[k], f.ItemRow[k]);
                        mp.caption = label1.Text;
                        mp.x = f.ItemCol[k];
                        mp.y = f.ItemRow[k];
                        mp.xx = f.ItemColSpan[k];
                        mp.yy = f.ItemRowSpan[k];
                        label1.Tag = mp;
                        label1.TextImageRelation = TextImageRelation.ImageAboveText;

                        //label1.MouseMove += new MouseEventHandler(label1_MouseMove);
                        //label1.MouseUp += new MouseEventHandler(label1_MouseUp);

                        tlbebase.SetCellPosition(label1, new TableLayoutPanelCellPosition(f.ItemCol[k], f.ItemRow[k]));

                        tlbebase.SetColumnSpan(label1, f.ItemColSpan[k]);
                        tlbebase.SetRowSpan(label1, f.ItemRowSpan[k]);
                        btnadvanceadd.Enabled = false;
                        btnadvancedec.Enabled = false;
                        tlbebase.Controls.Add(label1);

                        if (label1.Text == "试样输入")
                        {
                            试样输入ToolStripMenuItem.Enabled = false;
                            label1.Image = imageList1.Images[2];
                            label1.ImageAlign = ContentAlignment.MiddleCenter;

                        }

                        if (label1.Text == "曲线图1")
                        {
                            曲线图1ToolStripMenuItem.Enabled = false;
                            label1.Image = imageList1.Images[0];
                            label1.ImageAlign = ContentAlignment.MiddleCenter;
                        }

                        if (label1.Text == "曲线图2")
                        {
                            曲线图2ToolStripMenuItem.Enabled = false;
                            label1.Image = imageList1.Images[0];
                            label1.ImageAlign = ContentAlignment.MiddleCenter;
                        }

                        if (label1.Text == "结果1")
                        {
                            结果1ToolStripMenuItem.Enabled = false;
                            label1.Image = imageList1.Images[1];
                            label1.ImageAlign = ContentAlignment.MiddleCenter;
                        }
                        if (label1.Text == "结果2")
                        {
                            结果2ToolStripMenuItem.Enabled = false;
                            label1.Image = imageList1.Images[1];
                            label1.ImageAlign = ContentAlignment.MiddleCenter;
                        }
                        if (label1.Text == "仪表1")
                        {
                            仪表1ToolStripMenuItem.Enabled = false;
                            label1.Image = imageList1.Images[3];
                            label1.ImageAlign = ContentAlignment.MiddleCenter;
                        }

                        if (label1.Text == "仪表2")
                        {
                            仪表2ToolStripMenuItem.Enabled = false;
                            label1.Image = imageList1.Images[3];
                            label1.ImageAlign = ContentAlignment.MiddleCenter;
                        }
                        if (label1.Text == "原始数据")
                        {
                            原始数据ToolStripMenuItem.Enabled = false;
                            label1.Image = imageList1.Images[4];
                            label1.ImageAlign = ContentAlignment.MiddleCenter;
                        }

                        if (label1.Text == "摄像")
                        {
                            this.摄像ToolStripMenuItem.Enabled = false;
                            label1.Image = imageList1.Images[5];
                            label1.ImageAlign = ContentAlignment.MiddleCenter;
                        }

                        if (label1.Text == "过程提示")
                        {
                            this.过程提示ToolStripMenuItem.Enabled = false;
                            label1.Image = imageList1.Images[6];
                            label1.ImageAlign = ContentAlignment.MiddleCenter;
                        }

                        if (label1.Text == "状态提示")
                        {
                            this.状态提示ToolStripMenuItem.Enabled = false;
                            label1.Image = imageList1.Images[7];
                            label1.ImageAlign = ContentAlignment.MiddleCenter;
                        }
                    }
                }
            }

        }

        private void 原始数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button label1;
            label1 = new Button();
            label1.TextImageRelation = TextImageRelation.ImageAboveText;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Text = "原始数据";
            label1.AutoSize = false;
            label1.Dock = DockStyle.Fill;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            tlbe.SetCellPosition(label1, new TableLayoutPanelCellPosition(tlbe.SelectColumn, tlbe.SelectRow));
            //label1.ContextMenuStrip = this.contextMenuStrip2;
            label1.BackColor = Color.White;
            label1.ForeColor = Color.Blue;
            label1.Image = imageList1.Images[4];
            label1.ImageAlign = ContentAlignment.MiddleCenter;
            PPP mp = new PPP(tlbe.SelectColumn, tlbe.SelectRow);
            mp.caption = label1.Text;
            label1.Tag = mp;

            label1.MouseMove += new MouseEventHandler(label1_MouseMove);
            label1.MouseUp += new MouseEventHandler(label1_MouseUp);

            btnadvanceadd.Enabled = false;
            btnadvancedec.Enabled = false;
            原始数据ToolStripMenuItem.Enabled = false;
            tlbe.Controls.Add(label1);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void UserControl常规_SizeChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SizeChanged(object sender, EventArgs e)
        {

            // listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            // listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            int t;
            Color fcolor;

            if (e.Index < 0)
            {
                return;
            }

            if (listBox1.SelectedIndex == e.Index)
            {
                fcolor = Color.Black;
            }
            else
            {
                fcolor = Color.Black;
            }

            Pen p = new Pen(Color.Gray, 2);

            e.Graphics.DrawLine(p, e.Bounds.Left

             ,
             e.Bounds.Bottom,
             e.Bounds.Right,
             e.Bounds.Bottom);
            p.Dispose();

            //e.Graphics.DrawImage(this.imageList1.Images[0], e.Bounds.Left, e.Bounds.Top);

            StringFormat sf = new StringFormat(StringFormatFlags.NoWrap);

            SizeF sizef = e.Graphics.MeasureString(listBox1.Items[e.Index].ToString(), listBox1.Font, Int32.MaxValue, sf);

            t = Convert.ToInt16(Math.Ceiling(sizef.Width / (listBox1.Width)));
            //  t = t + 1;




            RectangleF rf = new RectangleF(e.Bounds.X, e.Bounds.Y + 1, listBox1.Width, e.Font.Height * t);



            e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), listBox1.Font, new SolidBrush(fcolor), rf);
            sf.Dispose();
        }

        private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            int t;



            StringFormat sf = new StringFormat(StringFormatFlags.NoWrap);


            SizeF sizef = e.Graphics.MeasureString(listBox1.Items[e.Index].ToString(), listBox1.Font, Int32.MaxValue, sf);

            t = Convert.ToInt16(Math.Ceiling(sizef.Width / (listBox1.Width)));

            // t = t + 1;
            if (t == 0)
            {
                t = 1;
            }

            e.ItemHeight = t * listBox1.Font.Height + 5;


            sf.Dispose();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtmethodname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtmemo1_TextChanged(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.samplememo1 = txtmemo1.Text;
        }

        private void txtmemo2_TextChanged(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.samplememo2 = txtmemo2.Text;
        }

        private void txtmemo3_TextChanged(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.samplememo3 = txtmemo3.Text;
        }

        private void txtmemo_TextChanged(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.samplememo = txtmemo.Text;
        }

        private void txtauthor_TextChanged(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.methodauthor = txtauthor.Text;
        }

        private void txtmethodmemo_TextChanged(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.methodmemo = this.txtmethodmemo.Text;
        }

        private void txtlay_TextChanged(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.layfilename = txtlay.Text;
        }

        private void 摄像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button label1;
            label1 = new Button();
            label1.TextImageRelation = TextImageRelation.ImageAboveText;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Text = "摄像";
            label1.AutoSize = false;
            label1.Dock = DockStyle.Fill;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            tlbe.SetCellPosition(label1, new TableLayoutPanelCellPosition(tlbe.SelectColumn, tlbe.SelectRow));
            //label1.ContextMenuStrip  = this.contextMenuStrip2;
            label1.BackColor = Color.White;
            label1.ForeColor = Color.Blue;
            label1.Image = imageList1.Images[5];
            label1.ImageAlign = ContentAlignment.MiddleCenter;

            PPP mp = new PPP(tlbe.SelectColumn, tlbe.SelectRow);
            mp.caption = label1.Text;
            label1.Tag = mp;
            label1.MouseUp += new MouseEventHandler(label1_MouseUp);
            label1.MouseMove += new MouseEventHandler(label1_MouseMove);

            btnadvanceadd.Enabled = false;
            btnadvancedec.Enabled = false;
            摄像ToolStripMenuItem.Enabled = false;
            tlbe.Controls.Add(label1);
        }

        private void 过程提示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button label1;
            label1 = new Button();
            label1.TextImageRelation = TextImageRelation.ImageAboveText;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Text = "过程提示";
            label1.AutoSize = false;
            label1.Dock = DockStyle.Fill;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            tlbe.SetCellPosition(label1, new TableLayoutPanelCellPosition(tlbe.SelectColumn, tlbe.SelectRow));
            //label1.ContextMenuStrip  = this.contextMenuStrip2;
            label1.BackColor = Color.White;
            label1.ForeColor = Color.Blue;
            label1.Image = imageList1.Images[6];
            label1.ImageAlign = ContentAlignment.MiddleCenter;

            PPP mp = new PPP(tlbe.SelectColumn, tlbe.SelectRow);
            mp.caption = label1.Text;
            label1.Tag = mp;
            label1.MouseUp += new MouseEventHandler(label1_MouseUp);
            label1.MouseMove += new MouseEventHandler(label1_MouseMove);

            btnadvanceadd.Enabled = false;
            btnadvancedec.Enabled = false;
            过程提示ToolStripMenuItem.Enabled = false;
            tlbe.Controls.Add(label1);
        }

        private void 状态提示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button label1;
            label1 = new Button();
            label1.TextImageRelation = TextImageRelation.ImageAboveText;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Text = "状态提示";
            label1.AutoSize = false;
            label1.Dock = DockStyle.Fill;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            tlbe.SetCellPosition(label1, new TableLayoutPanelCellPosition(tlbe.SelectColumn, tlbe.SelectRow));
            //label1.ContextMenuStrip  = this.contextMenuStrip2;
            label1.BackColor = Color.White;
            label1.ForeColor = Color.Blue;
            label1.Image = imageList1.Images[7];
            label1.ImageAlign = ContentAlignment.MiddleCenter;

            PPP mp = new PPP(tlbe.SelectColumn, tlbe.SelectRow);
            mp.caption = label1.Text;
            label1.Tag = mp;
            label1.MouseUp += new MouseEventHandler(label1_MouseUp);
            label1.MouseMove += new MouseEventHandler(label1_MouseMove);

            btnadvanceadd.Enabled = false;
            btnadvancedec.Enabled = false;
            状态提示ToolStripMenuItem.Enabled = false;
            tlbe.Controls.Add(label1);
        }

        private void 长时数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button label1;
            label1 = new Button();
            label1.TextImageRelation = TextImageRelation.ImageAboveText;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Text = "峰值趋势数据";
            label1.AutoSize = false;
            label1.Dock = DockStyle.Fill;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            tlbe.SetCellPosition(label1, new TableLayoutPanelCellPosition(tlbe.SelectColumn, tlbe.SelectRow));
            //label1.ContextMenuStrip  = this.contextMenuStrip2;
            label1.BackColor = Color.White;
            label1.ForeColor = Color.Blue;
            label1.Image = imageList1.Images[7];
            label1.ImageAlign = ContentAlignment.MiddleCenter;

            PPP mp = new PPP(tlbe.SelectColumn, tlbe.SelectRow);
            mp.caption = label1.Text;
            label1.Tag = mp;
            label1.MouseUp += new MouseEventHandler(label1_MouseUp);
            label1.MouseMove += new MouseEventHandler(label1_MouseMove);

            btnadvanceadd.Enabled = false;
            btnadvancedec.Enabled = false;
            长时数据ToolStripMenuItem.Enabled = false;
            tlbe.Controls.Add(label1);
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = listView1.HitTest(e.X, e.Y);
            if (info.Item != null)
            {

                OpenRecentMethod();
            }
        }
    }
}
