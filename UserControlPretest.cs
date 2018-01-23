using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using CustomControls.OS;
using CustomControls.Controls;
using System.IO;

namespace TabHeaderDemo
{
    public partial class UserControlPretest : UserControl
    {
        public string gfilename = ""; //方法单元读取的文件名


        public void ClearMethod()
        {
            txtmethod.Text = "";
            txtpath.Text = "";
            this.listBox1.Items.Clear();
            CComLibrary.GlobeVal.filesave = null;
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





            Color c = (this.imageList3.Images[0] as Bitmap).GetPixel((this.imageList3.Images[0] as Bitmap).Width - 5, (this.imageList3.Images[0] as Bitmap).Height / 2);



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

            panel3.BackColor = c;
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
        public UserControlPretest()
        {
            InitializeComponent();
            treeView1.mimagelist = imageList2;
            tabControl1.ItemSize = new Size(1, 1);

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲



            this.tableLayoutPanel1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel1, true, null);
            this.tableLayoutPanel2.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel2, true, null);
            this.tableLayoutPanel3.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel3, true, null);
            this.tableLayoutPanel4.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel4, true, null);
            this.tableLayoutPanel5.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel5, true, null);
            this.tableLayoutPanel6.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel6, true, null);
            this.tableLayoutPanel7.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel7, true, null);
            this.tableLayoutPanel8.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel8, true, null);

            this.tableLayoutPanel9.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel9, true, null);

        }

        private void UserControl5_Paint(object sender, PaintEventArgs e)
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
            roundedRectangle[0].X = 8;
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
        }

        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {




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

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                methodon(e.Node.Text, "");
            }
            else
            {
                methodon(e.Node.Text, e.Node.Parent.Text);
            }
        }

        public void methodon(String t, String parent)
        {
            if (t == "选择方法")
            {
                btnenext.Visible = true;
                btneopen.Visible = true;
                btneback.Visible = false;
                tabControl1.SelectedIndex = 0;

            }

            if (t == "选择样品")
            {
                btnenext.Visible = true;
                btneopen.Visible = true;
                btneback.Visible = false;
                tabControl1.SelectedIndex = 2;
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        public void SampleNextStep(bool newfile)
        {
            string s;






            if (newfile == true)
            {
                CComLibrary.GlobeVal.filesave.InitTable();
                CComLibrary.GlobeVal.filesave.SerializeNow(GlobeVal.spefilename);





            }
            else

            {
                if (File.Exists(GlobeVal.spefilename) == false)
                {
                    CComLibrary.GlobeVal.filesave.InitTable();
                    CComLibrary.GlobeVal.filesave.SerializeNow(GlobeVal.spefilename);
                }
                else
                {
                    CComLibrary.GlobeVal.filesave = CComLibrary.GlobeVal.filesave.DeSerializeNow(GlobeVal.spefilename);
                }
            }

            if (CComLibrary.GlobeVal.filesave.mwizard == true)
            {

                GlobeVal.UserControlMain1.tabControl1.SelectedIndex = 3;

                GlobeVal.userControltest1.paneltestright.Controls.Clear();

                GlobeVal.userControltest1.splitContainer1.SplitterDistance = 100;
                if (GlobeVal.wizard == null)
                {
                    GlobeVal.wizard = new UserControlWizard();
                    GlobeVal.wizard.Dock = DockStyle.Fill;
                    GlobeVal.wizard.BackColor = Color.Cyan;
                }


                GlobeVal.userControltest1.lstspe.Visible = false;
                GlobeVal.userControltest1.paneltestright.Controls.Add(GlobeVal.wizard);

                GlobeVal.userControltest1.tableLayoutPanelback.RowStyles[1].Height = 84;
                GlobeVal.userControltest1.tableLayoutPanelTop.Visible = true;


                GlobeVal.wizard.Init(CComLibrary.GlobeVal.filesave.mstep[0].Id);



                GlobeVal.userControltest1.Init_btnstep();








            }
            else
            {


                GlobeVal.userControltest1.Visible = false;


                GlobeVal.UserControlMain1.tabControl1.SelectedIndex = 3;

                GlobeVal.userControltest1.tableLayoutPanelback.RowStyles[1].Height = 0;

                GlobeVal.userControltest1.tableLayoutPanelTop.Visible = false;


                GlobeVal.userControltest1.splitContainer1.SplitterDistance = 100;

                GlobeVal.userControltest1.paneltestright.Visible = false;



                GlobeVal.userControltest1.lstspe.Visible = true;


                if (GlobeVal.dynset == null)
                {

                    GlobeVal.dynset = new UserControlDynSet();

                }


                GlobeVal.dynset.Dock = DockStyle.Fill;
                GlobeVal.dynset.BackColor = Color.Cyan;
                GlobeVal.dynset.tlbetest.Controls.Clear();
                GlobeVal.dynset.tlbetest.RowCount = 0;
                GlobeVal.dynset.tlbetest.ColumnCount = 0;
                GlobeVal.dynset.Dock = DockStyle.None;

                GlobeVal.userControltest1.OpenDefaultlayout(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\layout\\模板1.lay");

                GlobeVal.dynset.Dock = DockStyle.Fill;
                GlobeVal.userControltest1.paneltestright.Controls.Clear();

                GlobeVal.userControltest1.paneltestright.Controls.Add(GlobeVal.dynset);

                GlobeVal.dynset.tlbetest.Dock = DockStyle.Fill;


                GlobeVal.dynset.tlbetest.ResetSizeAndSizeTypes();

                GlobeVal.userControltest1.paneltestright.Visible = true;










                if (newfile == true)
                {
                    GlobeVal.userControltest1.FreeFormRefresh(false, false);
                }
                else
                {
                    GlobeVal.userControltest1.FreeFormRefresh(true, true);
                }


                GlobeVal.userControltest1.Visible = true;
                GlobeVal.userControltest1.Visible = false;
                GlobeVal.dynset.tlbetest.ResetSizeAndSizeTypes();


                GlobeVal.userControltest1.Visible = true;
            }

            GlobeVal.UserControlMain1.btnmmethod.Visible = true;
            GlobeVal.UserControlMain1.btnmreport.Visible = true;
            GlobeVal.UserControlMain1.btnmmanage.Visible = true;


            if (GlobeVal.userControlpretest1.gfilename.Trim() == "")
            {

            }
            else
            {
                GlobeVal.userControlmethod1.OpenTheMethodSilently(GlobeVal.userControlpretest1.gfilename);
            }

            if (newfile == true)
            {
                if (CComLibrary.GlobeVal.filesave.mwizard == true)
                {
                   // CComLibrary.GlobeVal.filesave.mspecount = 100;
                }
                CComLibrary.GlobeVal.filesave.InitTable();
            }


            GlobeVal.MainStatusStrip.Items["tslblkind"].Text = "试验类型：" + ClsStaticStation.m_Global.mycls.TestkindList[CComLibrary.GlobeVal.filesave.methodkind];

            GlobeVal.MainStatusStrip.Items["tslblsample"].Text = "样品：" + Path.GetFileNameWithoutExtension(GlobeVal.spefilename);

            GlobeVal.MainStatusStrip.Items["tslblmethod"].Text = "方法:" + txtmethod.Text;

        }

        private void btnenext_Click(object sender, EventArgs e)
        {
            string s;

            if (tabControl1.SelectedIndex == 2)
            {
                if (System.IO.Directory.Exists(GlobeVal.mysys.SamplePath))
                {
                }
                else
                {
                    MessageBox.Show("数据保存路径不存在,请点击浏览选择试验路径");
                    return;
                }
                if (GlobeVal.mysys.SamplePath == "")
                {
                    MessageBox.Show("请设置数据保存路径");

                    return;
                }
                if (txtsample.Text.Trim() == "")
                {
                    MessageBox.Show("请先读取样品文件");
                    return;
                }

                GlobeVal.spefilename = txtsamplepath.Text + "\\" + txtsample.Text + ".spe";


                SampleNextStep(false);

            }
            else if (tabControl1.SelectedIndex == 0)
            {
                if (txtmethod.Text.Trim() == "")
                {
                    MessageBox.Show("请先读取试验方法");
                    return;
                }
                tabControl1.SelectedIndex = 1;
                btneback.Visible = true;
                btneopen.Visible = false;



            }
            else if (tabControl1.SelectedIndex == 1)
            {

                if (txtsamplename.Text.Trim() == "")
                {

                    MessageBox.Show("样品文件名不能为空");
                    return;
                }
                if (System.IO.Directory.Exists(GlobeVal.mysys.SamplePath))
                {
                }
                else
                {
                    MessageBox.Show("数据保存路径不存在,请点击浏览选择试验路径");
                    return;
                }
                if (GlobeVal.mysys.SamplePath == "")
                {
                    MessageBox.Show("请设置数据保存路径");

                    return;
                }

                GlobeVal.spefilename = lblpath.Text + "\\" + txtsamplename.Text + ".spe";

                SampleNextStep(true);

                CComLibrary.GlobeVal.filesave.currentspenumber = 0;


            }




        }

        private void btneopen_Click(object sender, EventArgs e)
        {

            if (tabControl1.SelectedIndex == 0)
            {
                if (listView1.SelectedIndices.Count > 0)
                {

                    string fileName = System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\Method\\" + listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text + "\\"
                        + listView1.Items[listView1.SelectedIndices[0]].Text + ".dat";
                    gfilename = fileName;

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


                        this.txtmethod.Text = Path.GetFileNameWithoutExtension(fileName);
                        this.txtpath.Text = Path.GetDirectoryName(fileName);

                        if (CComLibrary.GlobeVal.filesave == null)
                        {
                            CComLibrary.GlobeVal.filesave = new CComLibrary.FileStruct();
                        }
                        CComLibrary.GlobeVal.filesave = CComLibrary.GlobeVal.filesave.DeSerializeNow(fileName);

                        CComLibrary.GlobeVal.currentfilesavename = fileName;


                        listBox1.Items.Clear();
                        listBox1.Items.Add("试验方法类型：" + ClsStaticStation.m_Global.mycls.TestkindList[CComLibrary.GlobeVal.filesave.methodkind]);
                        listBox1.Items.Add("试验方法描述：" + CComLibrary.GlobeVal.filesave.methodmemo);
                        listBox1.Items.Add("试验方法作者：" + CComLibrary.GlobeVal.filesave.methodauthor);
                        if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 0)
                        {
                            listBox1.Items.Add("控制过程:" + "一般测控");
                        }
                        else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 1)
                        {
                            listBox1.Items.Add("控制过程:" + "中级测控");
                        }
                        else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 2)
                        {
                            listBox1.Items.Add("控制过程:" + "简单控制");
                        }
                        else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 3)
                        {
                            listBox1.Items.Add("控制过程:" + "高级测控");
                        }



                        CComLibrary.GlobeVal.filesave.InitExplainList();

                        for (int i = 0; i < CComLibrary.GlobeVal.filesave.mexplainlist.Count; i++)
                        {
                            string s = "   " + "步骤" + (i + 1).ToString() + " " + CComLibrary.GlobeVal.filesave.mexplainlist[i].explain(GlobeVal.mysys.machinekind);
                            listBox1.Items.Add(s);
                        }
                        listBox1.Items.Add("结果表格1：");
                        for (int i = 0; i < CComLibrary.GlobeVal.filesave.mtablecol1.Count; i++)
                        {
                            string s = "   列" + (i + 1).ToString() + "：" + CComLibrary.GlobeVal.filesave.mtablecol1[i].formulaname;
                            listBox1.Items.Add(s);
                        }



                        ListViewItem lv = new ListViewItem();
                        lv.Text = this.txtmethod.Text;


                        lv.SubItems.Add(ClsStaticStation.m_Global.mycls.TestkindList[CComLibrary.GlobeVal.filesave.methodkind]);
                        lv.SubItems.Add(System.IO.File.GetLastWriteTime(fileName).ToLongDateString() + " " + System.IO.File.GetLastWriteTime(fileName).ToLongTimeString());





                        if (this.txtmethod.Text == listView1.Items[0].Text)
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

                        ClsStaticStation.m_Global.mycls.initchannel();
                        ((FormMainLab)Application.OpenForms["FormMainLab"]).InitKey();
                        ((FormMainLab)Application.OpenForms["FormMainLab"]).InitMeter();

                        lblmethodkind.Text = ClsStaticStation.m_Global.mycls.TestkindList[CComLibrary.GlobeVal.filesave.methodkind];
                        lblmethod.Text = this.txtmethod.Text;



                    }




                }

                else
                {
                    MessageBox.Show("请选择最近使用的试验方法");
                }

            }

            if (tabControl1.SelectedIndex == 2)
            {
                if (listView2.SelectedIndices.Count > 0)
                {

                    string fileName = listView2.Items[listView2.SelectedIndices[0]].SubItems[3].Text + "\\"
                    + listView2.Items[listView2.SelectedIndices[0]].Text + ".spe";
                    gfilename = fileName;

                    if (System.IO.File.Exists(fileName) == true)
                    {

                    }
                    else
                    {
                        MessageBox.Show("样品文件不存在");
                        return;
                    }

                    if (fileName == "")
                    {
                        return;
                    }
                    else
                    {

                        this.txtsample.Text = Path.GetFileNameWithoutExtension(fileName);
                        this.txtsamplepath.Text = Path.GetDirectoryName(fileName);

                        if (CComLibrary.GlobeVal.filesave == null)
                        {
                            CComLibrary.GlobeVal.filesave = new CComLibrary.FileStruct();
                        }
                        CComLibrary.GlobeVal.filesave = CComLibrary.GlobeVal.filesave.DeSerializeNow(fileName);

                        CComLibrary.GlobeVal.currentfilesavename = fileName;


                        listBox2.Items.Clear();
                        listBox2.Items.Add("试验方法类型：" + ClsStaticStation.m_Global.mycls.TestkindList[CComLibrary.GlobeVal.filesave.methodkind]);
                        listBox2.Items.Add("试验方法描述：" + CComLibrary.GlobeVal.filesave.methodmemo);
                        listBox2.Items.Add("试验方法作者：" + CComLibrary.GlobeVal.filesave.methodauthor);

                        if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 0)
                        {
                            listBox2.Items.Add("控制过程:" + "一般测控");
                        }
                        else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 1)
                        {
                            listBox2.Items.Add("控制过程:" + "中级测控");
                        }
                        else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 2)
                        {
                            listBox2.Items.Add("控制过程:" + "简单控制");
                        }
                        else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 3)
                        {
                            listBox2.Items.Add("控制过程:" + "高级测控");
                        }


                        CComLibrary.GlobeVal.filesave.InitExplainList();

                        for (int i = 0; i < CComLibrary.GlobeVal.filesave.mexplainlist.Count; i++)
                        {
                            string s = "   " + "步骤" + (i + 1).ToString() + " " + CComLibrary.GlobeVal.filesave.mexplainlist[i].explain(GlobeVal.mysys.machinekind);
                            listBox2.Items.Add(s);
                        }

                        listBox2.Items.Add("结果表格1：");
                        for (int i = 0; i < CComLibrary.GlobeVal.filesave.mtablecol1.Count; i++)
                        {
                            string s = "   列" + (i + 1).ToString() + "：" + CComLibrary.GlobeVal.filesave.mtablecol1[i].formulaname;
                            listBox2.Items.Add(s);
                        }
                        ListViewItem lv = new ListViewItem();
                        lv.Text = this.txtsample.Text;


                        lv.SubItems.Add(ClsStaticStation.m_Global.mycls.TestkindList[CComLibrary.GlobeVal.filesave.methodkind]);
                        lv.SubItems.Add(System.IO.File.GetLastWriteTime(fileName).ToLongDateString() + " " + System.IO.File.GetLastWriteTime(fileName).ToLongTimeString());
                        lv.SubItems.Add(Path.GetDirectoryName(fileName));

                        if (this.txtsample.Text == listView2.Items[0].Text)
                        {
                            listView2.Items.RemoveAt(0);
                        }


                        if (listView2.Items.Count >= 20)
                        {
                            listView2.Items.RemoveAt(19);
                        }
                        listView2.Items.Insert(0, lv);



                        for (int i = 0; i < listView2.Items.Count; i++)
                        {

                            GlobeVal.mysys.RecentSampleFilename[i] = listView2.Items[i].Text;
                            GlobeVal.mysys.RecentSampleFilenameKind[i] = listView2.Items[i].SubItems[1].Text;
                            GlobeVal.mysys.RecentSampleFilePath[i] = listView2.Items[i].SubItems[3].Text;

                        }

                        for (int i = listView2.Items.Count; i < 20; i++)
                        {
                            GlobeVal.mysys.RecentSampleFilename[i] = "";
                            GlobeVal.mysys.RecentSampleFilenameKind[i] = "";
                            GlobeVal.mysys.RecentSampleFilePath[i] = "";
                        }

                        ClsStaticStation.m_Global.mycls.initchannel();
                        ((FormMainLab)Application.OpenForms["FormMainLab"]).InitKey();
                        ((FormMainLab)Application.OpenForms["FormMainLab"]).InitMeter();

                        //lblmethodkind.Text = ClsStaticStation.m_Global.mycls.TestkindList[CComLibrary.GlobeVal.filesave.methodkind];
                        //lblmethod.Text = this.txtmethod.Text;

                    }


                }
                else
                {
                    MessageBox.Show("请选择最近使用的样本");
                }

            }

        }

        private void btnelook_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                CustomControls.MethodOpenFileDialog controlex = new CustomControls.MethodOpenFileDialog();
                controlex.StartLocation = AddonWindowLocation.Right;
                controlex.DefaultViewMode = FolderViewMode.Details;
                controlex.OpenDialog.InitialDirectory = lblpath.Text;
                controlex.OpenDialog.AddExtension = true;
                controlex.OpenDialog.Filter = "样品文件(*.spe)|*.spe";
                controlex.ShowDialog(this);

                if (controlex.OpenDialog.FileName == null)
                {

                    return;
                }
                else
                {
                    string fileName = controlex.OpenDialog.FileName;
                    gfilename = fileName;
                    if (fileName == "")
                    {
                        return;
                    }
                    else
                    {

                        this.txtsample.Text = Path.GetFileNameWithoutExtension(fileName);
                        this.txtsamplepath.Text = Path.GetDirectoryName(fileName);

                        if (CComLibrary.GlobeVal.filesave == null)
                        {
                            CComLibrary.GlobeVal.filesave = new CComLibrary.FileStruct();
                        }
                        CComLibrary.GlobeVal.filesave = CComLibrary.GlobeVal.filesave.DeSerializeNow(fileName);

                        CComLibrary.GlobeVal.currentfilesavename = fileName;


                        listBox2.Items.Clear();
                        listBox2.Items.Add("试验方法类型：" + ClsStaticStation.m_Global.mycls.TestkindList[CComLibrary.GlobeVal.filesave.methodkind]);
                        listBox2.Items.Add("试验方法描述：" + CComLibrary.GlobeVal.filesave.methodmemo);
                        listBox2.Items.Add("试验方法作者：" + CComLibrary.GlobeVal.filesave.methodauthor);

                        if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 0)
                        {
                            listBox2.Items.Add("控制过程:" + "一般测控");
                        }
                        if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 1)
                        {
                            listBox2.Items.Add("控制过程:" + "中级测控");
                        }
                        else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 2)
                        {
                            listBox2.Items.Add("控制过程:" + "简单控制");
                        }
                        else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 3)
                        {
                            listBox2.Items.Add("控制过程:" + "高级测控");
                        }

                            CComLibrary.GlobeVal.filesave.InitExplainList();

                        for (int i = 0; i < CComLibrary.GlobeVal.filesave.mexplainlist.Count; i++)
                        {
                            string s = "   " + "步骤" + (i + 1).ToString() + " " + CComLibrary.GlobeVal.filesave.mexplainlist[i].explain(GlobeVal.mysys.machinekind);
                            listBox2.Items.Add(s);
                        }

                        listBox2.Items.Add("结果表格1：");
                        for (int i = 0; i < CComLibrary.GlobeVal.filesave.mtablecol1.Count; i++)
                        {
                            string s = "   列" + (i + 1).ToString() + "：" + CComLibrary.GlobeVal.filesave.mtablecol1[i].formulaname;
                            listBox2.Items.Add(s);
                        }
                        ListViewItem lv = new ListViewItem();
                        lv.Text = this.txtsample.Text;


                        lv.SubItems.Add(ClsStaticStation.m_Global.mycls.TestkindList[CComLibrary.GlobeVal.filesave.methodkind]);
                        lv.SubItems.Add(System.IO.File.GetLastWriteTime(fileName).ToLongDateString() + " " + System.IO.File.GetLastWriteTime(fileName).ToLongTimeString());
                        lv.SubItems.Add(Path.GetDirectoryName(fileName));

                        if (this.txtsample.Text == listView2.Items[0].Text)
                        {
                            listView2.Items.RemoveAt(0);
                        }

                        if (listView2.Items.Count >= 20)
                        {
                            listView2.Items.RemoveAt(19);
                        }
                        listView2.Items.Insert(0, lv);



                        for (int i = 0; i < listView2.Items.Count; i++)
                        {

                            GlobeVal.mysys.RecentSampleFilename[i] = listView2.Items[i].Text;
                            GlobeVal.mysys.RecentSampleFilenameKind[i] = listView2.Items[i].SubItems[1].Text;
                            GlobeVal.mysys.RecentSampleFilePath[i] = listView2.Items[i].SubItems[3].Text;

                        }

                        for (int i = listView2.Items.Count; i < 20; i++)
                        {
                            GlobeVal.mysys.RecentSampleFilename[i] = "";
                            GlobeVal.mysys.RecentSampleFilenameKind[i] = "";
                            GlobeVal.mysys.RecentSampleFilePath[i] = "";
                        }

                        ClsStaticStation.m_Global.mycls.initchannel();
                        ((FormMainLab)Application.OpenForms["FormMainLab"]).InitKey();
                        ((FormMainLab)Application.OpenForms["FormMainLab"]).InitMeter();

                        //lblmethodkind.Text = ClsStaticStation.m_Global.mycls.TestkindList[CComLibrary.GlobeVal.filesave.methodkind];
                        //lblmethod.Text = this.txtmethod.Text;



                    }
                }

                controlex.Dispose();

            }
            if (tabControl1.SelectedIndex == 1)
            {
                this.folderBrowserDialog1.SelectedPath = lblpath.Text;
                this.folderBrowserDialog1.ShowDialog();

                lblpath.Text = this.folderBrowserDialog1.SelectedPath;

                GlobeVal.mysys.SamplePath = lblpath.Text;


            }
            if (tabControl1.SelectedIndex == 0)
            {
                CustomControls.MethodOpenFileDialog controlex = new CustomControls.MethodOpenFileDialog();
                controlex.StartLocation = AddonWindowLocation.Right;
                controlex.DefaultViewMode = FolderViewMode.Details;
                controlex.OpenDialog.InitialDirectory = System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\Method";
                controlex.OpenDialog.AddExtension = true;
                controlex.OpenDialog.Filter = "试验方法文件(*.dat)|*.dat";
                controlex.ShowDialog(this);





                if (controlex.OpenDialog.FileName == null)
                {

                    return;
                }
                else
                {
                    string fileName = controlex.OpenDialog.FileName;
                    gfilename = fileName;

                    if (fileName == "")
                    {
                        return;
                    }
                    else
                    {

                        this.txtmethod.Text = Path.GetFileNameWithoutExtension(fileName);
                        this.txtpath.Text = Path.GetDirectoryName(fileName);

                        if (CComLibrary.GlobeVal.filesave == null)
                        {
                            CComLibrary.GlobeVal.filesave = new CComLibrary.FileStruct();
                        }
                        CComLibrary.GlobeVal.filesave = CComLibrary.GlobeVal.filesave.DeSerializeNow(fileName);

                        CComLibrary.GlobeVal.currentfilesavename = fileName;


                        listBox1.Items.Clear();
                        listBox1.Items.Add("试验方法类型：" + ClsStaticStation.m_Global.mycls.TestkindList[CComLibrary.GlobeVal.filesave.methodkind]);
                        listBox1.Items.Add("试验方法描述：" + CComLibrary.GlobeVal.filesave.methodmemo);
                        listBox1.Items.Add("试验方法作者：" + CComLibrary.GlobeVal.filesave.methodauthor);

                        if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 0)
                        {
                            listBox1.Items.Add("控制过程:" + "一般测控");
                        }
                        if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 1)
                        {
                            listBox1.Items.Add("控制过程:" + "中级测控");
                        }
                        else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 2)
                        {
                            listBox1.Items.Add("控制过程:" + "简单控制");
                        }
                        else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 3)
                        {
                            listBox1.Items.Add("控制过程:" + "高级测控");
                        }

                            CComLibrary.GlobeVal.filesave.InitExplainList();

                        for (int i = 0; i < CComLibrary.GlobeVal.filesave.mexplainlist.Count; i++)
                        {
                            string s = "   " + "步骤" + (i + 1).ToString() + " " + CComLibrary.GlobeVal.filesave.mexplainlist[i].explain(GlobeVal.mysys.machinekind);
                            listBox1.Items.Add(s);
                        }
                        listBox1.Items.Add("结果表格1：");
                        for (int i = 0; i < CComLibrary.GlobeVal.filesave.mtablecol1.Count; i++)
                        {
                            string s = "   列" + (i + 1).ToString() + "：" + CComLibrary.GlobeVal.filesave.mtablecol1[i].formulaname;
                            listBox1.Items.Add(s);
                        }
                        ListViewItem lv = new ListViewItem();
                        lv.Text = this.txtmethod.Text;


                        lv.SubItems.Add(ClsStaticStation.m_Global.mycls.TestkindList[CComLibrary.GlobeVal.filesave.methodkind]);
                        lv.SubItems.Add(System.IO.File.GetLastWriteTime(fileName).ToLongDateString() + " " + System.IO.File.GetLastWriteTime(fileName).ToLongTimeString());


                        if (listView1.Items.Count > 0)
                        {
                            if (this.txtmethod.Text == listView1.Items[0].Text)
                            {
                                listView1.Items.RemoveAt(0);
                            }

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

                        ClsStaticStation.m_Global.mycls.initchannel();
                        ((FormMainLab)Application.OpenForms["FormMainLab"]).InitKey();
                        ((FormMainLab)Application.OpenForms["FormMainLab"]).InitMeter();

                        lblmethodkind.Text = ClsStaticStation.m_Global.mycls.TestkindList[CComLibrary.GlobeVal.filesave.methodkind];
                        lblmethod.Text = this.txtmethod.Text;

                    }
                }

                controlex.Dispose();
            }
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





            RectangleF rf = new RectangleF(e.Bounds.X, e.Bounds.Y + 2, listBox1.Width, e.Font.Height * t);



            e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, new SolidBrush(fcolor), rf);
            sf.Dispose();
        }

        private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            int t;



            StringFormat sf = new StringFormat(StringFormatFlags.NoWrap);


            SizeF sizef = e.Graphics.MeasureString(listBox1.Items[e.Index].ToString(), listBox1.Font, Int32.MaxValue, sf);

            t = Convert.ToInt16(Math.Ceiling(sizef.Width / (listBox1.Width)));


            if (t == 0)
            {
                t = 1;
            }
            e.ItemHeight = t * listBox1.Font.Height + 5;


            sf.Dispose();
        }

        public void LoadResentFile()
        {
            string s = "";

            treeView1.CollapseAll();



            this.treeView1.SelectedNode = treeView1.Nodes[0].Nodes[0];

            tabControl1.SelectedIndex = 0;

            btnenext.Visible = true;
            btnelook.Visible = true;
            btneback.Visible = false;
            btneopen.Visible = true;



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

                    if (File.Exists(fileName) == true)
                    {
                        lv.SubItems.Add(System.IO.File.GetLastWriteTime(fileName).ToLongDateString() + " " + System.IO.File.GetLastWriteTime(fileName).ToLongTimeString());
                    }
                    listView1.Items.Add(lv);
                }
            }


            listView2.Items.Clear();
            for (int i = 0; i < 20; i++)
            {
                if (GlobeVal.mysys.RecentSampleFilename[i] == "")
                {
                }
                else
                {
                    ListViewItem lv = new ListViewItem();
                    lv.Text = GlobeVal.mysys.RecentSampleFilename[i];



                    lv.SubItems.Add(GlobeVal.mysys.RecentSampleFilenameKind[i]);
                    fileName = GlobeVal.mysys.RecentSampleFilePath[i] + "\\" + GlobeVal.mysys.RecentSampleFilename[i] + ".spe";



                    if (File.Exists(fileName) == true)
                    {
                        lv.SubItems.Add(System.IO.File.GetLastWriteTime(fileName).ToLongDateString() + " " + System.IO.File.GetLastWriteTime(fileName).ToLongTimeString());
                    }
                    else
                    {
                        lv.SubItems.Add(" ");
                    }
                    lv.SubItems.Add(GlobeVal.mysys.RecentSampleFilePath[i]);

                    listView2.Items.Add(lv);
                }
            }

            if (GlobeVal.mysys.SamplePath == "")
            {
                s = System.Windows.Forms.Application.StartupPath;

                if (Directory.Exists(s + "\\AppleLabJ") == true)
                {
                }
                else
                {
                    Directory.CreateDirectory(s + "\\AppleLabJ");

                    GlobeVal.mysys.SamplePath = s + "\\AppleLabJ";

                }

            }

            lblpath.Text = GlobeVal.mysys.SamplePath;
            txtsamplename.Text = GlobeVal.mysys.SampleFile;
        }

        private void UserControlPretest_Load(object sender, EventArgs e)
        {

            LoadResentFile();

        }

        private void listBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            int t;
            Color fcolor;

            if (e.Index < 0)
            {
                return;
            }

            if (listBox2.SelectedIndex == e.Index)
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

            SizeF sizef = e.Graphics.MeasureString(listBox2.Items[e.Index].ToString(), listBox2.Font, Int32.MaxValue, sf);

            t = Convert.ToInt16(Math.Ceiling(sizef.Width / (listBox2.Width)));





            RectangleF rf = new RectangleF(e.Bounds.X, e.Bounds.Y + 2, listBox2.Width, e.Font.Height * t);



            e.Graphics.DrawString(listBox2.Items[e.Index].ToString(), e.Font, new SolidBrush(fcolor), rf);
            sf.Dispose();
        }

        private void listBox2_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            int t;



            StringFormat sf = new StringFormat(StringFormatFlags.NoWrap);


            SizeF sizef = e.Graphics.MeasureString(listBox2.Items[e.Index].ToString(), listBox2.Font, Int32.MaxValue, sf);

            t = Convert.ToInt16(Math.Ceiling(sizef.Width / (listBox2.Width)));


            if (t == 0)
            {
                t = 1;
            }
            e.ItemHeight = t * listBox2.Font.Height + 5;


            sf.Dispose();
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            for (int i = 0; i < 20; i++)
            {
                GlobeVal.mysys.RecentSampleFilename[i] = "";
                GlobeVal.mysys.RecentSampleFilenameKind[i] = "";
                GlobeVal.mysys.RecentSampleFilePath[i] = "";
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            for (int i = 0; i < 20; i++)
            {
                GlobeVal.mysys.RecentFilename[i] = "";
                GlobeVal.mysys.RecentFilenameKind[i] = "";

            }
        }

        private void txtsamplename_TextChanged(object sender, EventArgs e)
        {
            GlobeVal.mysys.SampleFile = txtsamplename.Text;
        }

        private void txtsample_TextChanged(object sender, EventArgs e)
        {
            GlobeVal.mysys.SampleFile = txtsample.Text;
        }
    }
}
