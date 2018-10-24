﻿using System;
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
            treeView1.StateImageList = imageList1;
            treeView1.Nodes[0].StateImageIndex = 0;
            treeView1.Nodes[1].StateImageIndex = 1;
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
            string sname = "";

            if (GlobeVal.mysys.language ==0)
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

            else
            {

                if (t == "Select Method")
                {
                    btnenext.Visible = true;
                    btneopen.Visible = true;
                    btneback.Visible = false;
                    tabControl1.SelectedIndex = 0;

                }

                if (t == "Select Sample")
                {
                    btnenext.Visible = true;
                    btneopen.Visible = true;
                    btneback.Visible = false;
                    tabControl1.SelectedIndex = 2;
                }
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
                CComLibrary.GlobeVal.continuetest = false;
            }
            else
            {
                CComLibrary.GlobeVal.continuetest = true;
            }



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

                if (System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\layout\\" + CComLibrary.GlobeVal.filesave.layfilename + ".lay"))
                {
                    GlobeVal.userControltest1.OpenDefaultlayout(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\layout\\" + CComLibrary.GlobeVal.filesave.layfilename + ".lay");

                }
                else
                {
                    GlobeVal.userControltest1.OpenDefaultlayout(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\layout\\default.lay");
                }

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
                /*
                double t = Environment.TickCount;
                while((Environment.TickCount -t)<500)
                        {
                    Application.DoEvents();
                }
                */
                GlobeVal.userControltest1.Visible = true;
            }

            GlobeVal.UserControlMain1.btnmmethod.Visible = true;

            if (GlobeVal.mysys.machinekind == 0)
            {
                GlobeVal.UserControlMain1.btnmreport.Visible = true;
                GlobeVal.UserControlMain1.btnmmanage.Visible = true;
            }
            else
            {
                GlobeVal.UserControlMain1.btnmreport.Visible = false ;
                GlobeVal.UserControlMain1.btnmmanage.Visible = false ;
            }

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

                }
                CComLibrary.GlobeVal.filesave.InitTable();
            }

            if (GlobeVal.mysys.language == 0)
            {
                GlobeVal.MainStatusStrip.Items["tslblkind"].Text = "试验类型：" + ClsStaticStation.m_Global.mycls.TestkindList[CComLibrary.GlobeVal.filesave.methodkind];

                GlobeVal.MainStatusStrip.Items["tslblsample"].Text = "样品：" + Path.GetFileNameWithoutExtension(GlobeVal.spefilename);

                GlobeVal.MainStatusStrip.Items["tslblmethod"].Text = "方法:" + CComLibrary.GlobeVal.filesave.methodname;
            }
            else
            {
                GlobeVal.MainStatusStrip.Items["tslblkind"].Text = "Test type" + ClsStaticStation.m_Global.mycls.TestkindList[CComLibrary.GlobeVal.filesave.methodkind];

                GlobeVal.MainStatusStrip.Items["tslblsample"].Text = "Sample:" + Path.GetFileNameWithoutExtension(GlobeVal.spefilename);

                GlobeVal.MainStatusStrip.Items["tslblmethod"].Text = "Method:" + CComLibrary.GlobeVal.filesave.methodname;

            }
        

            GlobeVal.myarm.mdemo = GlobeVal.mysys.demo;

            if (GlobeVal.myarm.mdemo == true)
            {
                if ((GlobeVal.ShowCameraForm == true) && (CComLibrary.GlobeVal.filesave.mplay == true) && (CComLibrary.GlobeVal.filesave.mplayfile == true))
                {
                    if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\demo\\"+CComLibrary.GlobeVal.filesave.play_avi_datafile)==true)
                    {
                        GlobeVal.myarm.readdemo(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\demo\\" + CComLibrary.GlobeVal.filesave.play_avi_datafile);
                    }
                }
                else
                {
                    if (System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\demo\\" + GlobeVal.mysys.demotxt) == true)
                    {
                        GlobeVal.myarm.readdemo(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\demo\\" + GlobeVal.mysys.demotxt);
                    }
                    else
                    {
                        GlobeVal.myarm.readdemo(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\demo\\tensile2demo.txt");
                    }
                }

            }

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
                    if (GlobeVal.mysys.language == 0)
                    {
                        MessageBox.Show("样品保存路径不存在,请点击浏览选择路径");
                    }
                    else
                    {
                        MessageBox.Show("The save path of the sample file does not exist. Please click Browse to select the path.");
                    }
                    return;
                }
                if (GlobeVal.mysys.SamplePath == "")
                {
                    if (GlobeVal.mysys.language == 0)
                    {
                        MessageBox.Show("请设置样品保存路径");
                    }
                    else
                    {
                        MessageBox.Show("Please set up the save path for the sample.");
                    }
                    return;
                }
                if (txtsample.Text.Trim() == "")
                {
                    if (GlobeVal.mysys.language == 0)
                    {
                        MessageBox.Show("请先读取样品文件");
                    }
                    else
                    {
                        MessageBox.Show("Please read the sample file first.");
                    }
                    return;
                }
              

               
                GlobeVal.spefilename = txtsamplepath.Text + "\\" + txtsample.Text + ".spe";
            

                SampleNextStep(false);

              



            }
            else if (tabControl1.SelectedIndex == 0)
            {
                if (txtmethod.Text.Trim() == "")
                {
                    if (GlobeVal.mysys.language == 0)
                    {
                        MessageBox.Show("请先读取试验方法");
                    }
                    else
                    {
                        MessageBox.Show("Please read the test method first.");
                    }
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
                    if (GlobeVal.mysys.language == 0)
                    {
                        MessageBox.Show("样品文件名不能为空");
                    }
                    else
                    {
                        MessageBox.Show("Please input sample file name.");
                    }
                    return;
                }
                if (System.IO.Directory.Exists(GlobeVal.mysys.SamplePath))
                {
                }
                else
                {
                    if (GlobeVal.mysys.language == 0)
                    {
                        MessageBox.Show("样品文件保存路径不存在,请点击浏览选择保存路径");
                    }
                    else
                    {
                        MessageBox.Show("The save path of the sample file does not exist. Please click Browse to choose the save path.");
                    }
                    return;
                }
                if (GlobeVal.mysys.SamplePath == "")
                {
                    if (GlobeVal.mysys.language == 0)
                    {
                        MessageBox.Show("请设置样品文件保存路径");
                    }
                    else
                    {
                        MessageBox.Show("Please set up the save path for sample files.");
                    }
                    return;
                }
               
               

                GlobeVal.spefilename = lblpath.Text + "\\" + txtsamplename.Text + ".spe";


                if (File.Exists(GlobeVal.spefilename)==true)
                {
                    DialogResult r;
                    if (GlobeVal.mysys.language == 0)
                    {
                        r = MessageBox.Show("相同样品文件已经存在，是否覆盖？", "提示", MessageBoxButtons.YesNo);
                    }
                    else
                    {
                        r = MessageBox.Show("The same sample file already exists. Is it covered ?", "Tips", MessageBoxButtons.YesNo);
                        
                    }
                    if (r == DialogResult.Yes)
                    {

                    }
                    else
                    {
                        return;
                    }
                }

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
                        if (GlobeVal.mysys.language == 0)
                        {
                            MessageBox.Show("方法文件不存在");
                        }
                        else
                        {
                            MessageBox.Show("Method files do not exist.");
                        }
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

                        GlobeVal.putlistboxitem(listBox1);

                      



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
                    if (GlobeVal.mysys.language == 0)
                    {
                        MessageBox.Show("请选择最近使用的试验方法");
                    }
                    else
                    {
                        MessageBox.Show("Please select the method file recently used.");
                    }
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
                        if (GlobeVal.mysys.language == 0)
                        {
                            MessageBox.Show("样品文件不存在");
                        }
                        else
                        {
                            MessageBox.Show("Sample files do not exist.");
                        }
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

                        GlobeVal.putlistboxitem(listBox2);

                        
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
                    if (GlobeVal.mysys.language == 0)
                    {
                        MessageBox.Show("请选择最近使用的样品文件");
                    }
                    else
                    {
                        MessageBox.Show("Please select the sample file recently used.");
                    }
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
                if (GlobeVal.mysys.language == 0)
                {
                    controlex.OpenDialog.Filter = "样品文件(*.spe)|*.spe";
                }
                else
                {
                    controlex.OpenDialog.Filter = "Sample Files(*.spe)|*.spe";

                }
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


                        GlobeVal.putlistboxitem(listBox2);

                        
                        ListViewItem lv = new ListViewItem();
                        lv.Text = this.txtsample.Text;


                        lv.SubItems.Add(ClsStaticStation.m_Global.mycls.TestkindList[CComLibrary.GlobeVal.filesave.methodkind]);
                        lv.SubItems.Add(System.IO.File.GetLastWriteTime(fileName).ToLongDateString() + " " + System.IO.File.GetLastWriteTime(fileName).ToLongTimeString());
                        lv.SubItems.Add(Path.GetDirectoryName(fileName));

                        if (listView2.Items.Count > 0)
                        {
                            if (this.txtsample.Text == listView2.Items[0].Text)
                            {
                                listView2.Items.RemoveAt(0);
                            }

                            if (listView2.Items.Count >= 20)
                            {
                                listView2.Items.RemoveAt(19);
                            }
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
                if (GlobeVal.mysys.language == 0)
                {
                    controlex.OpenDialog.Filter = "试验方法文件(*.dat)|*.dat";
                }
                else
                {
                    controlex.OpenDialog.Filter = "Method Files(*.dat)|*.dat";
                }
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

                        GlobeVal.putlistboxitem(listBox1);

                       
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

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = listView1.HitTest(e.X, e.Y);
            if (info.Item !=null)
            {
                btneopen_Click(null, null);  
            }
        }
    }
}
