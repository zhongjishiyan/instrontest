using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ClsStaticStation;
namespace TabHeaderDemo
{
    public partial class UserControl控制 : UserControl
    {
        public UserControlMethod musercontrolmethod;
        private CComLibrary.SegFile sf;

        private CComLibrary.SequenceFile sqf = new CComLibrary.SequenceFile();

        private bool mloaded = false;

        private int curcol = 0;
        private int currow = 0;



        public void Init_测试结束()
        {
            chktestend1.Checked = CComLibrary.GlobeVal.filesave.endoftest1;
            cbotestendCriteria1.Items.Clear();
            cbotestendCriteria1.Items.Add("载荷率");
            cbotestendCriteria1.Items.Add("载荷门槛值");
            cbotestendCriteria1.Items.Add("数据通道名");

            cbotestendCriteria1.SelectedIndex = CComLibrary.GlobeVal.filesave.endoftest1criteria;


            numtestendvalue1.Value = CComLibrary.GlobeVal.filesave.endoftest1value;


            if (cbotestendCriteria1.SelectedIndex == 0)
            {
                lbltestend1.Text = "灵敏度 (%)";


            }
            else if (cbotestendCriteria1.SelectedIndex == 1)
            {
                lbltestend1.Text = "载荷下降到 ";

            }
            else if (cbotestendCriteria1.SelectedIndex == 2)
            {
                lbltestend1.Text = "数值";
            }


            chktestend2.Checked = CComLibrary.GlobeVal.filesave.endoftest2;
            cbotestendCriteria2.Items.Clear();
            cbotestendCriteria2.Items.Add("载荷率");
            cbotestendCriteria2.Items.Add("载荷门槛值");
            cbotestendCriteria2.Items.Add("数据通道名");

            cbotestendCriteria2.SelectedIndex = CComLibrary.GlobeVal.filesave.endoftest2criteria;

            if (cbotestendCriteria2.SelectedIndex == 0)
            {
                lbltestend2.Text = "灵敏度 (%)";


            }
            else if (cbotestendCriteria2.SelectedIndex == 1)
            {
                lbltestend2.Text = "载荷下降到 ";

            }
            else if (cbotestendCriteria2.SelectedIndex == 2)
            {
                lbltestend2.Text = "数值";
            }

            numtestendvalue2.Value = CComLibrary.GlobeVal.filesave.endoftest2value;

            cbotestaction.Items.Clear();
            cbotestaction.Items.Add("停止");
            cbotestaction.Items.Add("返回");
            cbotestaction.Items.Add("停止，然后返回");

            cbotestaction.SelectedIndex = CComLibrary.GlobeVal.filesave.testaction;

        }

        public void Add(int i, ref CComLibrary.SegFile sf)
        {


            grid2.Rows.Insert(i);



            grid2[i, 0] = new SourceGrid2.Cells.Real.Cell(
                   i.ToString(), typeof(string));


            grid2[i, 1] = new SourceGrid2.Cells.Real.ComboBox(sf.cmdstring[sf.mseglist[i - 1].cmd]
                 , typeof(string),
                 sf.cmdstring, false);




            SourceGrid2.BehaviorModels.CustomEvents cmdclick = new SourceGrid2.BehaviorModels.CustomEvents();
            cmdclick.ValueChanged += new SourceGrid2.PositionEventHandler(cmdclick_ValueChanged);

            grid2[i, 1].Behaviors.Add(cmdclick);




            grid2[i, 2] = new SourceGrid2.Cells.Real.Button(
                    typeof(string));

            if (grid2[i, 1].Value.ToString() == "停止")
            {
                grid2[i, 2].Value = "";
            }
            else
            {
                grid2[i, 2].Value = sf.mseglist[i - 1].speedconvert() + " " + sf.mseglist[i - 1].dirconvert();
            }

            SourceGrid2.BehaviorModels.CustomEvents textclick = new SourceGrid2.BehaviorModels.CustomEvents();
            textclick.DoubleClick += new SourceGrid2.PositionEventHandler(textclick_DoubleClick);

            grid2[i, 2].Behaviors.Add(textclick);

            grid2[i, 3] = new SourceGrid2.Cells.Real.Button(
                                     typeof(string));

            if (grid2[i, 1].Value.ToString() == "停止")
            {
                grid2[i, 3].Value = "";
            }
            else
            {
                grid2[i, 3].Value = sf.mseglist[i - 1].destconvert();
            }


            grid2[i, 3].Behaviors.Add(textclick);

            grid2[i, 4] = new SourceGrid2.Cells.Real.ComboBox(sf.actionstring[sf.mseglist[i - 1].action]
                     , typeof(string),
                 sf.actionstring, false);

            SourceGrid2.BehaviorModels.CustomEvents actionclick = new SourceGrid2.BehaviorModels.CustomEvents();
            actionclick.ValueChanged += new SourceGrid2.PositionEventHandler(actionclick_ValueChanged);



            grid2[i, 4].Behaviors.Add(actionclick);

            grid2[i, 5] = new SourceGrid2.Cells.Real.Button(
                    typeof(string));
            if (grid2[i, 1].Value.ToString() == "停止")
            {
                grid2[i, 5].Value = "";
            }
            else
            {
                (grid2[i, 5] as SourceGrid2.Cells.Real.Button).Value = sf.mseglist[i - 1].cyclicconvert();

            }

            grid2[i, 5].Behaviors.Add(textclick);
            grid2[i, 6] = new SourceGrid2.Cells.Real.Cell(
                                sf.mseglist[i - 1].explain, typeof(string));
        }

        void textclick_DoubleClick(object sender, SourceGrid2.PositionEventArgs e)
        {
            if (e.Position.Column == 2)
            {

                if (GlobeVal.mysys.machinekind == 2)
                {
                    if (sf.mseglist[e.Position.Row - 1].cmd == 2)
                    {
                        Frm.Frm围压控制参数 f = new TabHeaderDemo.Frm.Frm围压控制参数();
                        f.result = false;

                        f.lblspeed.Text = "速度(MPa/s):";
                        f.numericEdit1.Value = sf.mseglist[e.Position.Row - 1].speed;
                        f.Text = "控制参数步骤" + e.Position.Row.ToString().Trim();
                        f.ShowDialog();
                        if (f.result == true)
                        {
                            sf.mseglist[e.Position.Row - 1].speed = f.numericEdit1.Value;


                            grid2[e.Position.Row, e.Position.Column].Value = sf.mseglist[e.Position.Row - 1].speedconvert();



                        }
                    }

                    else
                    {

                        Frm.Form控制参数 f = new TabHeaderDemo.Frm.Form控制参数();

                        f.result = false;


                        if (sf.mseglist[e.Position.Row - 1].controlmode == 0)
                        {
                            f.radioButton1.Text = "位移速度";
                            f.lblUnit.Text = "mm/s";
                            f.radioButton2.Visible = false;
                            f.panel1.Visible = false;

                        }
                        else
                        {
                            f.radioButton1.Text = "力速度";
                            f.lblUnit.Text = "kN/s";
                            f.radioButton2.Visible = true;
                            f.panel1.Visible = true;

                        }


                        f.numericEdit1.Value = sf.mseglist[e.Position.Row - 1].speed;
                        f.Text = "控制参数步骤" + e.Position.Row.ToString().Trim();
                        f.ShowDialog();
                        if (f.result == true)
                        {
                            sf.mseglist[e.Position.Row - 1].speed = f.numericEdit1.Value;


                            grid2[e.Position.Row, e.Position.Column].Value = sf.mseglist[e.Position.Row - 1].speedconvert();


                        }
                    }
                }
                else


                {
                    Frm.Form标准控制参数 f = new TabHeaderDemo.Frm.Form标准控制参数();

                    f.result = false;



                    f.lblname.Text = ClsStaticStation.m_Global.mycls.hardsignals[sf.mseglist[e.Position.Row - 1].controlmode].cName + "速度";
                    f.lblUnit.Text = ClsStaticStation.m_Global.mycls.hardsignals[sf.mseglist[e.Position.Row - 1].controlmode].speedSignal.cUnits[0];



                    if (ClsStaticStation.m_Global.mycls.hardsignals[sf.mseglist[e.Position.Row - 1].controlmode].cUnitKind == 1)
                    {
                        f.panel1.Visible = true;

                    }
                    else
                    {
                        f.panel1.Visible = false;
                    }

                    f.numericEdit1.Value = sf.mseglist[e.Position.Row - 1].speed;
                    f.Text = "控制参数步骤" + e.Position.Row.ToString().Trim();
                    f.ShowDialog();
                    if (f.result == true)
                    {
                        sf.mseglist[e.Position.Row - 1].speed = f.numericEdit1.Value;


                        grid2[e.Position.Row, e.Position.Column].Value = sf.mseglist[e.Position.Row - 1].speedconvert();


                    }

                }


            }
            if (e.Position.Column == 3)
            {
                if (GlobeVal.mysys.machinekind == 2)
                {


                    if (sf.mseglist[e.Position.Row - 1].cmd == 2)  //围压设置
                    {
                        Frm.Form围压跳转条件 f = new TabHeaderDemo.Frm.Form围压跳转条件();

                        f.Text = "跳转条件步骤" + e.Position.Row.ToString().Trim();
                        f.result = false;
                        f.rbtnload.Checked = true;

                        sf.mseglist[e.Position.Row - 1].destcontrolmode = 1;

                        f.numericEdit2.Value = sf.mseglist[e.Position.Row - 1].dest;
                        f.ShowDialog();

                        if (f.result == true)
                        {
                            sf.mseglist[e.Position.Row - 1].destcontrolmode = 1;
                            sf.mseglist[e.Position.Row - 1].dest = f.numericEdit2.Value;
                            sf.mseglist[e.Position.Row - 1].keeptime = 0;
                        }

                        grid2[e.Position.Row, e.Position.Column].Value = sf.mseglist[e.Position.Row - 1].destconvert();

                    }
                    else
                    {

                        Frm.Form跳转条件 f = new TabHeaderDemo.Frm.Form跳转条件();
                        f.Text = "跳转条件步骤" + e.Position.Row.ToString().Trim();
                        f.result = false;


                        if (sf.mseglist[e.Position.Row - 1].destcontrolmode == 0)
                        {
                            f.rbtnpos.Checked = true;
                        }
                        else
                        {
                            f.rbtnload.Checked = true;
                        }
                        f.numericEdit1.Value = sf.mseglist[e.Position.Row - 1].dest;
                        f.numericEdit2.Value = sf.mseglist[e.Position.Row - 1].dest;
                        f.numericEdit3.Value = sf.mseglist[e.Position.Row - 1].keeptime;
                        f.ShowDialog();

                        if (f.result == true)
                        {
                            if (f.rbtnpos.Checked == true)
                            {
                                sf.mseglist[e.Position.Row - 1].destcontrolmode = 0;
                                sf.mseglist[e.Position.Row - 1].dest = f.numericEdit1.Value;
                                sf.mseglist[e.Position.Row - 1].keeptime = f.numericEdit3.Value;

                            }
                            else
                            {
                                sf.mseglist[e.Position.Row - 1].destcontrolmode = 1;
                                sf.mseglist[e.Position.Row - 1].dest = f.numericEdit2.Value;
                                sf.mseglist[e.Position.Row - 1].keeptime = f.numericEdit3.Value;
                            }



                            grid2[e.Position.Row, e.Position.Column].Value = sf.mseglist[e.Position.Row - 1].destconvert();
                        }
                    }
                }
                else

                {

                    Frm.Form标准跳转条件 f = new TabHeaderDemo.Frm.Form标准跳转条件();

                    f.Text = "跳转条件步骤" + e.Position.Row.ToString().Trim();
                    f.result = false;

                    f.comboBox1.Items.Clear();

                    for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals.Count; i++)
                    {
                        f.comboBox1.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[i].cName);
                    }

                    if ((sf.mseglist[e.Position.Row - 1].destcontrolmode >= 0) && (sf.mseglist[e.Position.Row - 1].destcontrolmode < f.comboBox1.Items.Count))
                    {

                    }
                    else
                    {
                        sf.mseglist[e.Position.Row - 1].destcontrolmode = 0;
                    }

                    f.comboBox1.SelectedIndex = sf.mseglist[e.Position.Row - 1].destcontrolmode;

                    f.lblunit.Text = ClsStaticStation.m_Global.mycls.hardsignals[sf.mseglist[e.Position.Row - 1].destcontrolmode].cUnits[0];

                    if (ClsStaticStation.m_Global.mycls.hardsignals[sf.mseglist[e.Position.Row - 1].destcontrolmode].cUnitKind == 1)
                    {
                        f.panel1.Visible = true;

                    }
                    else
                    {
                        f.panel1.Visible = false;
                    }


                    f.numericEdit2.Value = sf.mseglist[e.Position.Row - 1].dest;
                    f.numericEdit3.Value = sf.mseglist[e.Position.Row - 1].keeptime;
                    f.ShowDialog();

                    if (f.result == true)
                    {
                        sf.mseglist[e.Position.Row - 1].destcontrolmode = f.comboBox1.SelectedIndex;
                        sf.mseglist[e.Position.Row - 1].dest = f.numericEdit2.Value;
                        sf.mseglist[e.Position.Row - 1].keeptime = f.numericEdit3.Value;
                    }

                    grid2[e.Position.Row, e.Position.Column].Value = sf.mseglist[e.Position.Row - 1].destconvert();
                }
            }

            if (e.Position.Column == 5)
            {
                if (sf.mseglist[e.Position.Row - 1].cmd == 3)
                {
                    grid2[e.Position.Row, e.Position.Column].Value = "";
                    return;
                }
                Frm.Form循环执行 f = new TabHeaderDemo.Frm.Form循环执行();
                f.Text = "循环执行步骤" + e.Position.Row.ToString().Trim();
                f.result = false;

                f.chkcyclic.Checked = sf.mseglist[e.Position.Row - 1].cyclicrun;
                f.numericEdit1.Value = sf.mseglist[e.Position.Row - 1].cycliccount;
                f.numericEdit2.Value = sf.mseglist[e.Position.Row - 1].returnstep;
                f.ShowDialog();
                if (f.result == true)
                {
                    sf.mseglist[e.Position.Row - 1].cyclicrun = f.chkcyclic.Checked;
                    sf.mseglist[e.Position.Row - 1].cycliccount = Convert.ToInt32(f.numericEdit1.Value);
                    sf.mseglist[e.Position.Row - 1].returnstep = Convert.ToInt32(f.numericEdit2.Value);
                    grid2[e.Position.Row, e.Position.Column].Value = sf.mseglist[e.Position.Row - 1].cyclicconvert();
                }
            }

            return;
        }

        void actionclick_ValueChanged(object sender, SourceGrid2.PositionEventArgs e)
        {
            int c = 0;
            for (int i = 0; i < sf.actionstring.Length; i++)
            {
                if (sf.actionstring[i] == e.Cell.GetValue(e.Position).ToString())
                {
                    c = i;
                }
            }
            sf.mseglist[e.Position.Row - 1].action = c;

        }

        void cmdclick_ValueChanged(object sender, SourceGrid2.PositionEventArgs e)
        {
            int c = 0;
            for (int i = 0; i < sf.cmdstring.Length; i++)
            {
                if (sf.cmdstring[i] == e.Cell.GetValue(e.Position).ToString())
                {
                    c = i;
                }
            }

            sf.mseglist[e.Position.Row - 1].cmd = c;

            if (c == 0)
            {
                sf.mseglist[e.Position.Row - 1].controlmode = 0;

            }
            if (c == 1)
            {
                sf.mseglist[e.Position.Row - 1].controlmode = 1;
            }

            if (c == 2)
            {
                sf.mseglist[e.Position.Row - 1].controlmode = -1;
            }


            SourceGrid2.PositionEventArgs m;

            m = new SourceGrid2.PositionEventArgs(new SourceGrid2.Position(e.Position.Row, 2), null);
            this.textclick_DoubleClick(sender, m);

            m = new SourceGrid2.PositionEventArgs(new SourceGrid2.Position(e.Position.Row, 3), null);
            this.textclick_DoubleClick(sender, m);
        }

        void behaviorClick_Click(object sender, SourceGrid2.PositionEventArgs e)
        {

        }

        public void Init_简单()
        {

        }

        private void Init_Grid3()
        {
            grid3.RowsCount = 0;
            grid3.AutoStretchColumnsToFitWidth = true;

            grid3.BorderStyle = BorderStyle.FixedSingle;

            grid3.ColumnsCount = 4;
            grid3.Columns[0].Width = grid3.Width / 4;
            grid3.Columns[1].Width = grid3.Width / 4;
            grid3.Columns[2].Width = grid3.Width / 4;

            grid3.Columns[3].Width = grid3.Width - grid3.Columns[0].Width - 1;

            grid3.Columns[1].AutoSizeMode = SourceGrid2.AutoSizeMode.EnableStretch;
            grid3.FixedRows = 0;
            grid3.Rows.Insert(0);

            SourceGrid2.Cells.Real.ColumnHeader head = new SourceGrid2.Cells.Real.ColumnHeader("准则");
            head.EnableSort = false;
            grid3[0, 0] = head;

            head = new SourceGrid2.Cells.Real.ColumnHeader("通道");
            head.EnableSort = false;
            grid3[0, 1] = head;

            head = new SourceGrid2.Cells.Real.ColumnHeader("间隔");
            head.EnableSort = false;
            grid3[0, 2] = head;

            head = new SourceGrid2.Cells.Real.ColumnHeader("单位");
            head.EnableSort = false;
            grid3[0, 3] = head;


            double v = 0;
            for (int i = 1; i <= ClsStaticStation.m_Global.mycls.allsignals.Count; i++)
            {
                grid3.Rows.Insert(i);

                grid3[i, 0] = new SourceGrid2.Cells.Real.CheckBox(false);


                grid3[i, 1] = new SourceGrid2.Cells.Real.Cell(
                    ClsStaticStation.m_Global.mycls.allsignals[i - 1].cName, typeof(string));
                grid3[i, 2] = new SourceGrid2.Cells.Real.Cell(
                v, typeof(double));

                grid3[i, 3] = new SourceGrid2.Cells.Real.ComboBox(
                    ClsStaticStation.m_Global.mycls.allsignals[i - 1].cUnits[
                    ClsStaticStation.m_Global.mycls.allsignals[i - 1].cUnitsel], typeof(string),
                    ClsStaticStation.m_Global.mycls.allsignals[i - 1].cUnits, false);


            }

        }

        public void Init_高级()
        {


            // Put it in the first column of the fourth row

            cbomethod.Items.Clear();
            cbomethod.Items.Add("试验方法默认");
            cbomethod.Items.Add("自定义采集");
            cbomethod.Items.Add("不采集");

            cbomethod.SelectedIndex = 0;

            cbocontrol.Items.Clear();

            for (int i = 0; i < m_Global.mycls.chsignals.Count; i++)
            {
                cbocontrol.Items.Add(m_Global.mycls.chsignals[i].cName);
            }
            cbocontrol.SelectedIndex = 0;
            cbodestcontrol.Items.Clear();

            for (int i = 0; i < m_Global.mycls.chsignals.Count; i++)
            {
                cbodestcontrol.Items.Add(m_Global.mycls.chsignals[i].cName);
            }
            cbodestcontrol.SelectedIndex = 0;


            tscbos.Items.Clear();
            DirectoryInfo info = new DirectoryInfo(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ\\sequence");
            FileInfo[] files = info.GetFiles("*.seq");
            foreach (FileInfo file in files)
            {
                tscbos.Items.Add(file.Name);

                if (CComLibrary.GlobeVal.filesave.SequenceName == file.Name)
                {
                    tscbos.Text = file.Name;
                }
            }


            imageList1.ImageSize = new Size(16, listViewEx1.Height - 17);





            tlpscroll.ColumnStyles[0].Width = 50;
            tlpscroll.ColumnStyles[2].Width = 50;


            Init_Grid3();

            if (listViewEx1.mlist.Count > 0)
            {
                UserControlStep1_btnselectevent(listViewEx1.mlist[0], 0);

            }
        }
        public void Init_中级()
        {

            int i = 0;
            toolStrip1.Visible = true;

            mloaded = true;

            grid2.RowsCount = 0;
            grid2.AutoStretchColumnsToFitWidth = true;

            grid2.BorderStyle = BorderStyle.FixedSingle;

            grid2.ColumnsCount = 7;
            grid2.Columns[0].Width = 50;
            grid2.Columns[1].Width = grid1.Width / 7;
            grid2.Columns[2].Width = grid1.Width / 7;
            grid2.Columns[3].Width = grid1.Width / 7;
            grid2.Columns[4].Width = grid1.Width / 7;
            grid2.Columns[5].Width = grid1.Width / 7;
            grid2.Columns[6].Width = grid1.Width / 7;
            grid2.CustomSort = false;
            grid2.Columns[1].AutoSizeMode = SourceGrid2.AutoSizeMode.EnableStretch;
            grid2.FixedRows = 1;
            grid2.Rows.Insert(0);
            grid2.Rows[0].Height = 25;

            SourceGrid2.Cells.Real.ColumnHeader head;
            head = new SourceGrid2.Cells.Real.ColumnHeader("步骤");
            head.EnableSort = false;
            grid2[0, 0] = head;



            head = new SourceGrid2.Cells.Real.ColumnHeader("控制模式");

            head.EnableSort = false;
            grid2[0, 1] = head;

            head = new SourceGrid2.Cells.Real.ColumnHeader("控制参数");
            head.EnableSort = false;
            grid2[0, 2] = head;

            head = new SourceGrid2.Cells.Real.ColumnHeader("跳转条件");
            head.EnableSort = false;
            grid2[0, 3] = head;

            head = new SourceGrid2.Cells.Real.ColumnHeader("动作");
            head.EnableSort = false;
            grid2[0, 4] = head;

            head = new SourceGrid2.Cells.Real.ColumnHeader("循环");
            head.EnableSort = false;
            grid2[0, 5] = head;

            head = new SourceGrid2.Cells.Real.ColumnHeader("说明");
            head.EnableSort = false;
            grid2[0, 6] = head;

            sf = new CComLibrary.SegFile();


            for (i = 1; i <= sf.mseglist.Count; i++)
            {
                Add(i, ref sf);
            }
            tscbo.Items.Clear();
            DirectoryInfo info = new DirectoryInfo(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ\\seg");
            FileInfo[] files = info.GetFiles("*.seg");
            foreach (FileInfo file in files)
            {
                tscbo.Items.Add(file.Name);

                if (CComLibrary.GlobeVal.filesave.SegName == file.Name)
                {
                    tscbo.Text = file.Name;
                }
            }

            mloaded = false;


            if (tscbo.Text == "")
            {
            }
            else
            {
                tscbo_SelectedIndexChanged(null, null);
            }



        }
        public void Init_数据()
        {
            cbodatacapture.Items.Clear();
            cbodatacapture.Items.Add("默认");
            cbodatacapture.Items.Add("手动");
            cbodatacapture.SelectedIndex = CComLibrary.GlobeVal.filesave.mdatacaptureselect;

            chkcriteria1.Checked = CComLibrary.GlobeVal.filesave.chkcriteria[0];

            chkcriteria2.Checked = CComLibrary.GlobeVal.filesave.chkcriteria[1];

            chkcriteria3.Checked = CComLibrary.GlobeVal.filesave.chkcriteria[2];


            cbomeasurement1.Items.Clear();


            for (int i = 0; i < ClsStaticStation.m_Global.mycls.allsignals.Count; i++)
            {
                cbomeasurement1.Items.Add(ClsStaticStation.m_Global.mycls.allsignals[i].cName);
            }
            cbomeasurement1.SelectedIndex = CComLibrary.GlobeVal.filesave.cbomeasurement[0];

            cbomeasurement2.Items.Clear();


            for (int i = 0; i < ClsStaticStation.m_Global.mycls.allsignals.Count; i++)
            {
                cbomeasurement2.Items.Add(ClsStaticStation.m_Global.mycls.allsignals[i].cName);
            }
            cbomeasurement2.SelectedIndex = CComLibrary.GlobeVal.filesave.cbomeasurement[1];

            cbomeasurement3.Items.Clear();


            for (int i = 0; i < ClsStaticStation.m_Global.mycls.allsignals.Count; i++)
            {
                cbomeasurement3.Items.Add(ClsStaticStation.m_Global.mycls.allsignals[i].cName);
            }
            cbomeasurement3.SelectedIndex = CComLibrary.GlobeVal.filesave.cbomeasurement[2];

            lblinterval1.Text = ClsStaticStation.m_Global.mycls.allsignals[cbomeasurement1.SelectedIndex].cUnits[0];
            lblinterval2.Text = ClsStaticStation.m_Global.mycls.allsignals[cbomeasurement2.SelectedIndex].cUnits[0];
            lblinterval3.Text = ClsStaticStation.m_Global.mycls.allsignals[cbomeasurement3.SelectedIndex].cUnits[0];



            numinterval1.Value = CComLibrary.GlobeVal.filesave.numinterval[0];
            numinterval2.Value = CComLibrary.GlobeVal.filesave.numinterval[1];
            numinterval3.Value = CComLibrary.GlobeVal.filesave.numinterval[2];


        }

        public void Init_应变()
        {
            chkremoveext.Checked = CComLibrary.GlobeVal.filesave.chkextremove;
            CComLibrary.GlobeVal.filesave.Extensometer_removal = 0;
            cboextruler.SelectedIndex = 0;
            cboextchannel.Items.Clear();

            for (int i = 0; i < m_Global.mycls.hardsignals.Count; i++)
            {
                cboextchannel.Items.Add(m_Global.mycls.hardsignals[i].cName);

            }
            if ((CComLibrary.GlobeVal.filesave.Extensometer_DataChannel >= 0) && (CComLibrary.GlobeVal.filesave.Extensometer_DataChannel < cboextchannel.Items.Count))
            {
                cboextchannel.SelectedIndex = CComLibrary.GlobeVal.filesave.Extensometer_DataChannel;
            }
            else
            {
                CComLibrary.GlobeVal.filesave.Extensometer_DataChannel = 0;
                cboextchannel.SelectedIndex = 0;
            }

            numext.Value = CComLibrary.GlobeVal.filesave.Extensometer_DataValue;
            cboextunit.Items.Clear();
            for (int i = 0; i < m_Global.mycls.hardsignals[CComLibrary.GlobeVal.filesave.Extensometer_DataChannel].cUnitCount; i++)
            {
                cboextunit.Items.Add(m_Global.mycls.hardsignals[CComLibrary.GlobeVal.filesave.Extensometer_DataChannel].cUnits[i]);

            }

        
            if ((CComLibrary.GlobeVal.filesave.Extensometer_DataValueUnit>=0) && (CComLibrary.GlobeVal.filesave.Extensometer_DataValueUnit< 
            m_Global.mycls.hardsignals[CComLibrary.GlobeVal.filesave.Extensometer_DataChannel].cUnitCount))
            {
            
            cboextunit.SelectedIndex = CComLibrary.GlobeVal.filesave.Extensometer_DataValueUnit; 
            }

            else
            {
               CComLibrary.GlobeVal.filesave.Extensometer_DataValueUnit=0;
                cboextunit.SelectedIndex =0;
            }
            cboextact.SelectedIndex = CComLibrary.GlobeVal.filesave.Extensometer_Action;
            chkfrozen.Checked = CComLibrary.GlobeVal.filesave.Extensometer_DataFrozen;
            numgauge.Value = CComLibrary.GlobeVal.filesave.Extensometer_gauge;
            numgauge1.Value = CComLibrary.GlobeVal.filesave.Extensometer1_gauge; 

        }
        public void Init_设置控制()
        {

            cbocontrolprocess.Items.Clear();
            cbocontrolprocess.Items.Add("一般测试");
            cbocontrolprocess.Items.Add("中级测试");
            cbocontrolprocess.Items.Add("简单测试");
#if Advanced
            cbocontrolprocess.Items.Add("高级测试");
#endif



            cbocontrolprocess.SelectedIndex = CComLibrary.GlobeVal.filesave.mcontrolprocess;

            numericEdit1.Value = CComLibrary.GlobeVal.filesave.SampleInterval;
            num1.Value = CComLibrary.GlobeVal.filesave.crackvalue;

            chkcrack.Checked = CComLibrary.GlobeVal.filesave.crackcheck;

            grid1.RowsCount = 0;
            grid1.AutoStretchColumnsToFitWidth = true;

            grid1.BorderStyle = BorderStyle.FixedSingle;

            grid1.ColumnsCount = 5;
            for (int i = 0; i < grid1.ColumnsCount; i++)
            {
                grid1.Columns[i].Width = grid1.Width / grid1.ColumnsCount;
            }

            grid1.Columns[grid1.ColumnsCount - 1].Width = grid1.Columns[0].Width - 1;

            grid1.Columns[grid1.ColumnsCount - 1].AutoSizeMode = SourceGrid2.AutoSizeMode.EnableStretch;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 25;

            SourceGrid2.Cells.Real.ColumnHeader head = new SourceGrid2.Cells.Real.ColumnHeader("名称");
            head.EnableSort = false;
            grid1[0, 0] = head;

            head = new SourceGrid2.Cells.Real.ColumnHeader("单位");
            head.EnableSort = false;
           grid1[0, 1] =head;

            head = new SourceGrid2.Cells.Real.ColumnHeader("上限");
            head.EnableSort = false;
            grid1[0, 2] = head;

            head = new SourceGrid2.Cells.Real.ColumnHeader("下限");
            head.EnableSort = false;
            grid1[0, 3] = head;

            head = new SourceGrid2.Cells.Real.ColumnHeader("量程");
            head.EnableSort = false;
            grid1[0, 4] = head;


            for (int i = 1; i <= m_Global.mycls.chsignals.Count; i++)
            {
                grid1.Rows.Insert(i);
                grid1[i, 0] = new SourceGrid2.Cells.Real.Cell(
                    m_Global.mycls.chsignals[i - 1].cName, typeof(string));

                grid1[i, 1] = new SourceGrid2.Cells.Real.Cell(
                    m_Global.mycls.chsignals[i - 1].cUnits[
                    0], typeof(string)
                   );

                grid1[i, 2] = new SourceGrid2.Cells.Real.Cell(
                   m_Global.mycls.chsignals[i - 1].uplimit, typeof(double));

                grid1[i, 3] = new SourceGrid2.Cells.Real.Cell(
                  m_Global.mycls.chsignals[i - 1].donwlimit, typeof(double));

                grid1[i, 4] = new SourceGrid2.Cells.Real.Cell(
                   m_Global.mycls.chsignals[i - 1].fullmaxbase
                   , typeof(double)
                  );


            }

            chkSample.Checked = CComLibrary.GlobeVal.filesave.Samplecheck;
            numsampletime.Value = CComLibrary.GlobeVal.filesave.SampleChecktime;

            cbosamplemode.Items.Clear();
            cbosamplemode.Items.Add("静态采集方式");
            cbosamplemode.Items.Add("动态采集方式");
            cbosamplemode.Items.Add("高级控制采集方式");

            cbosamplemode.SelectedIndex = CComLibrary.GlobeVal.filesave.Samplingmode;
            numsaveinterval.Value = CComLibrary.GlobeVal.filesave.SamplingInterval;
            numsavepointcount.Value = CComLibrary.GlobeVal.filesave.SamplingCount;

            cbosamplemode_SelectionChangeCommitted(null, null);


        }
        private void list_autozerosetvalue()
        {
            int i;
            CComLibrary.GlobeVal.filesave.mautozero.Clear();
            for (i = 0; i < this.lstinclude.Items.Count; i++)
            {
                CComLibrary.GlobeVal.filesave.mautozero.Add(this.lstinclude.list[i]);
            }
        }
        public void Init_测试()
        {
            cbomode1.Items.Clear();
            cbomode1.Items.Add("轴向");
            cbomode1.SelectedIndex = 0;

            cbomode2.Items.Clear();
            cbomode2.Items.Add("轴向");
            cbomode2.SelectedIndex = 0;

            cbomode3.Items.Clear();
            cbomode3.Items.Add("轴向");
            cbomode3.SelectedIndex = 0;


            cbomode4.Items.Clear();
            cbomode4.Items.Add("轴向");
            cbomode4.SelectedIndex = 0;


            chkline1.Checked = CComLibrary.GlobeVal.filesave.testcmdstep[0].check;
            chkline2.Checked = CComLibrary.GlobeVal.filesave.testcmdstep[1].check;
            chkline3.Checked = CComLibrary.GlobeVal.filesave.testcmdstep[2].check;
            chkline4.Checked = CComLibrary.GlobeVal.filesave.testcmdstep[3].check;

            cbocontrol1.Items.Clear();
            cbocontrol2.Items.Clear();
            cbocontrol3.Items.Clear();
            cbocontrol4.Items.Clear();

            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals.Count; i++)
            {
                cbocontrol1.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[i].cName);
                cbocontrol2.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[i].cName);
                cbocontrol3.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[i].cName);
                cbocontrol4.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[i].cName);
            }

            if ((CComLibrary.GlobeVal.filesave.testcmdstep[0].controlmode >= 0) && (CComLibrary.GlobeVal.filesave.testcmdstep[0].controlmode < cbocontrol1.Items.Count))
            {
                cbocontrol1.SelectedIndex = CComLibrary.GlobeVal.filesave.testcmdstep[0].controlmode;
            }
            else
            {
                CComLibrary.GlobeVal.filesave.testcmdstep[0].controlmode = 0;
                cbocontrol1.SelectedIndex = 0;
            }

            if ((CComLibrary.GlobeVal.filesave.testcmdstep[1].controlmode >= 0) && (CComLibrary.GlobeVal.filesave.testcmdstep[1].controlmode < cbocontrol2.Items.Count))
            {
                cbocontrol2.SelectedIndex = CComLibrary.GlobeVal.filesave.testcmdstep[1].controlmode;
            }
            else
            {
                CComLibrary.GlobeVal.filesave.testcmdstep[1].controlmode = 0;
                cbocontrol2.SelectedIndex = 0;
            }

            if ((CComLibrary.GlobeVal.filesave.testcmdstep[2].controlmode >= 0) && (CComLibrary.GlobeVal.filesave.testcmdstep[2].controlmode < cbocontrol3.Items.Count))
            {
                cbocontrol3.SelectedIndex = CComLibrary.GlobeVal.filesave.testcmdstep[2].controlmode;
            }
            else
            {
                CComLibrary.GlobeVal.filesave.testcmdstep[2].controlmode = 0;
                cbocontrol3.SelectedIndex = 0;
            }


            if ((CComLibrary.GlobeVal.filesave.testcmdstep[3].controlmode >= 0) && (CComLibrary.GlobeVal.filesave.testcmdstep[3].controlmode < cbocontrol4.Items.Count))
            {
                cbocontrol4.SelectedIndex = CComLibrary.GlobeVal.filesave.testcmdstep[3].controlmode;
            }
            else
            {
                CComLibrary.GlobeVal.filesave.testcmdstep[3].controlmode = 0;
                cbocontrol4.SelectedIndex = 0;
            }
            cbospeedunit1.Items.Clear();
            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals[cbocontrol1.SelectedIndex].speedSignal.cUnitCount; i++)
            {
                cbospeedunit1.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[cbocontrol1.SelectedIndex].speedSignal.cUnits[i]);

            }

            if ((CComLibrary.GlobeVal.filesave.testcmdstep[0].speedunit > 0) && (CComLibrary.GlobeVal.filesave.testcmdstep[0].speedunit < cbospeedunit1.Items.Count))

            {
                cbospeedunit1.SelectedIndex = CComLibrary.GlobeVal.filesave.testcmdstep[0].speedunit;
            }
            else
            {
                CComLibrary.GlobeVal.filesave.testcmdstep[0].speedunit = 0;
                cbospeedunit1.SelectedIndex = 0;
            }
            cbospeedunit2.Items.Clear();
            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals[cbocontrol2.SelectedIndex].speedSignal.cUnitCount; i++)
            {
                cbospeedunit2.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[cbocontrol2.SelectedIndex].speedSignal.cUnits[i]);

            }
            if ((CComLibrary.GlobeVal.filesave.testcmdstep[1].speedunit > 0) && (CComLibrary.GlobeVal.filesave.testcmdstep[1].speedunit < cbospeedunit2.Items.Count))

            {
                cbospeedunit2.SelectedIndex = CComLibrary.GlobeVal.filesave.testcmdstep[1].speedunit;
            }
            else
            {
                CComLibrary.GlobeVal.filesave.testcmdstep[1].speedunit = 0;
                cbospeedunit2.SelectedIndex = 0;
            }
        
            cbospeedunit3.Items.Clear();
            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals[cbocontrol3.SelectedIndex].speedSignal.cUnitCount; i++)
            {
                cbospeedunit3.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[cbocontrol3.SelectedIndex].speedSignal.cUnits[i]);

            }

            if ((CComLibrary.GlobeVal.filesave.testcmdstep[2].speedunit > 0) && (CComLibrary.GlobeVal.filesave.testcmdstep[2].speedunit < cbospeedunit3.Items.Count))

            {
                cbospeedunit3.SelectedIndex = CComLibrary.GlobeVal.filesave.testcmdstep[2].speedunit;
            }
            else
            {
                CComLibrary.GlobeVal.filesave.testcmdstep[2].speedunit = 0;
                cbospeedunit3.SelectedIndex = 0;
            }

          


            cbospeedunit4.Items.Clear();
            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals[cbocontrol4.SelectedIndex].speedSignal.cUnitCount; i++)
            {
                cbospeedunit4.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[cbocontrol4.SelectedIndex].speedSignal.cUnits[i]);

            }
            if ((CComLibrary.GlobeVal.filesave.testcmdstep[3].speedunit > 0) && (CComLibrary.GlobeVal.filesave.testcmdstep[3].speedunit < cbospeedunit4.Items.Count))

            {
                cbospeedunit4.SelectedIndex = CComLibrary.GlobeVal.filesave.testcmdstep[3].speedunit;
            }
            else
            {
                CComLibrary.GlobeVal.filesave.testcmdstep[3].speedunit = 0;
                cbospeedunit4.SelectedIndex = 0;
            }

          

            cbodestcontrol1.Items.Clear();
            cbodestcontrol2.Items.Clear();
            cbodestcontrol3.Items.Clear();
            cbodestcontrol4.Items.Clear();

            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals.Count; i++)
            {
                cbodestcontrol1.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[i].cName);
                cbodestcontrol2.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[i].cName);
                cbodestcontrol3.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[i].cName);
                cbodestcontrol4.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[i].cName);

            }
            if ((CComLibrary.GlobeVal.filesave.testcmdstep[0].destcontrolmode >= 0) && (CComLibrary.GlobeVal.filesave.testcmdstep[0].destcontrolmode < cbodestcontrol1.Items.Count))
            {
                cbodestcontrol1.SelectedIndex = CComLibrary.GlobeVal.filesave.testcmdstep[0].destcontrolmode;
            }
            else
            {
                CComLibrary.GlobeVal.filesave.testcmdstep[0].destcontrolmode = 0;
                cbodestcontrol1.SelectedIndex = 0;
            }
            if ((CComLibrary.GlobeVal.filesave.testcmdstep[1].destcontrolmode >= 0) && (CComLibrary.GlobeVal.filesave.testcmdstep[1].destcontrolmode < cbodestcontrol2.Items.Count))
            {
                cbodestcontrol2.SelectedIndex = CComLibrary.GlobeVal.filesave.testcmdstep[1].destcontrolmode;
            }
            else
            {
                CComLibrary.GlobeVal.filesave.testcmdstep[1].destcontrolmode = 0;
                cbodestcontrol2.SelectedIndex = 0;
            }

            if ((CComLibrary.GlobeVal.filesave.testcmdstep[2].destcontrolmode >= 0) && (CComLibrary.GlobeVal.filesave.testcmdstep[2].destcontrolmode < cbodestcontrol3.Items.Count))
            {
                cbodestcontrol3.SelectedIndex = CComLibrary.GlobeVal.filesave.testcmdstep[2].destcontrolmode;
            }
            else
            {
                CComLibrary.GlobeVal.filesave.testcmdstep[2].destcontrolmode = 0;
                cbodestcontrol3.SelectedIndex = 0;
            }

            if ((CComLibrary.GlobeVal.filesave.testcmdstep[3].destcontrolmode >= 0) && (CComLibrary.GlobeVal.filesave.testcmdstep[3].destcontrolmode < cbodestcontrol4.Items.Count))
            {
                cbodestcontrol4.SelectedIndex = CComLibrary.GlobeVal.filesave.testcmdstep[3].destcontrolmode;
            }
            else
            {
                CComLibrary.GlobeVal.filesave.testcmdstep[3].destcontrolmode = 0;
                cbodestcontrol4.SelectedIndex = 0;
            }
            cbovalueunit1.Items.Clear();

            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals[cbodestcontrol1.SelectedIndex].cUnitCount; i++)
            {

                cbovalueunit1.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[cbodestcontrol1.SelectedIndex].cUnits[i]);
            }

            if ((CComLibrary.GlobeVal.filesave.testcmdstep[0].destunit >= 0) && (CComLibrary.GlobeVal.filesave.testcmdstep[0].destunit < cbovalueunit1.Items.Count))

            {
                cbovalueunit1.SelectedIndex = CComLibrary.GlobeVal.filesave.testcmdstep[0].destunit;

            }
            else
            {
                CComLibrary.GlobeVal.filesave.testcmdstep[0].destunit = 0;
                cbovalueunit1.SelectedIndex = 0;
            }

            cbovalueunit2.Items.Clear();

            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals[cbodestcontrol2.SelectedIndex].cUnitCount; i++)
            {

                cbovalueunit2.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[cbodestcontrol2.SelectedIndex].cUnits[i]);
            }


            if ((CComLibrary.GlobeVal.filesave.testcmdstep[1].destunit >= 0) && (CComLibrary.GlobeVal.filesave.testcmdstep[1].destunit < cbovalueunit2.Items.Count))

            {
                cbovalueunit2.SelectedIndex = CComLibrary.GlobeVal.filesave.testcmdstep[1].destunit;

            }
            else
            {
                CComLibrary.GlobeVal.filesave.testcmdstep[1].destunit = 0;
                cbovalueunit2.SelectedIndex = 0;
            }
          


            cbovalueunit3.Items.Clear();

            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals[cbodestcontrol3.SelectedIndex].cUnitCount; i++)
            {

                cbovalueunit3.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[cbodestcontrol3.SelectedIndex].cUnits[i]);
            }

            if ((CComLibrary.GlobeVal.filesave.testcmdstep[2].destunit >= 0) && (CComLibrary.GlobeVal.filesave.testcmdstep[2].destunit < cbovalueunit3.Items.Count))

            {
                cbovalueunit3.SelectedIndex = CComLibrary.GlobeVal.filesave.testcmdstep[2].destunit;

            }
            else
            {
                CComLibrary.GlobeVal.filesave.testcmdstep[2].destunit = 0;
                cbovalueunit3.SelectedIndex = 0;
            }


            cbovalueunit4.Items.Clear();

            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals[cbodestcontrol4.SelectedIndex].cUnitCount; i++)
            {

                cbovalueunit4.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[cbodestcontrol4.SelectedIndex].cUnits[i]);
            }

            if ((CComLibrary.GlobeVal.filesave.testcmdstep[3].destunit >= 0) && (CComLibrary.GlobeVal.filesave.testcmdstep[3].destunit < cbovalueunit4.Items.Count))

            {
                cbovalueunit4.SelectedIndex = CComLibrary.GlobeVal.filesave.testcmdstep[3].destunit;

            }
            else
            {
                CComLibrary.GlobeVal.filesave.testcmdstep[3].destunit = 0;
                cbovalueunit4.SelectedIndex = 0;
            }



            numspeed1.Value = CComLibrary.GlobeVal.filesave.testcmdstep[0].speed;

            numvalue1.Value = CComLibrary.GlobeVal.filesave.testcmdstep[0].dest;

            numspeed2.Value = CComLibrary.GlobeVal.filesave.testcmdstep[1].speed;

            numvalue2.Value = CComLibrary.GlobeVal.filesave.testcmdstep[1].dest;

            numspeed3.Value = CComLibrary.GlobeVal.filesave.testcmdstep[2].speed;

            numvalue3.Value = CComLibrary.GlobeVal.filesave.testcmdstep[2].dest;

            numspeed4.Value = CComLibrary.GlobeVal.filesave.testcmdstep[3].speed;

            numvalue4.Value = CComLibrary.GlobeVal.filesave.testcmdstep[3].dest;




        }
        public void Init_测试前()
        {
            chkpreload.Checked = CComLibrary.GlobeVal.filesave.pretest_cmd.check;
            cbopreload_controlmode.Items.Clear();
            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals.Count; i++)
            {
                cbopreload_controlmode.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[i].cName);
            }

            if ((CComLibrary.GlobeVal.filesave.pretest_cmd.controlmode >= 0) && (CComLibrary.GlobeVal.filesave.pretest_cmd.controlmode < cbopreload_controlmode.Items.Count))
            {
                cbopreload_controlmode.SelectedIndex = CComLibrary.GlobeVal.filesave.pretest_cmd.controlmode;
            }
            else
            {
                CComLibrary.GlobeVal.filesave.pretest_cmd.controlmode = 0;
                cbopreload_controlmode.SelectedIndex = 0;
            }

            cbopreload_speedunit.Items.Clear();
            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals[cbopreload_controlmode.SelectedIndex].speedSignal.cUnitCount; i++)
            {
                cbopreload_speedunit.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[cbopreload_controlmode.SelectedIndex].speedSignal.cUnits[i]);

            }
            if ((CComLibrary.GlobeVal.filesave.pretest_cmd.speedunit >= 0) && (CComLibrary.GlobeVal.filesave.pretest_cmd.speedunit < cbopreload_speedunit.Items.Count))

            {
                cbopreload_speedunit.SelectedIndex = CComLibrary.GlobeVal.filesave.pretest_cmd.speedunit;
            }
            else
            {
                CComLibrary.GlobeVal.filesave.pretest_cmd.speedunit = 0;
                cbopreload_speedunit.SelectedIndex = 0; 
            }


            cbopreload_channel.Items.Clear();

            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals.Count; i++)
            {
                cbopreload_channel.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[i].cName);
            }

            if ((CComLibrary.GlobeVal.filesave.pretest_cmd.destcontrolmode >= 0) && (CComLibrary.GlobeVal.filesave.pretest_cmd.destcontrolmode < cbopreload_channel.Items.Count))
            {
                cbopreload_channel.SelectedIndex = CComLibrary.GlobeVal.filesave.pretest_cmd.destcontrolmode;
            }
            else
            {
                CComLibrary.GlobeVal.filesave.pretest_cmd.destcontrolmode = 0;
                cbopreload_channel.SelectedIndex = 0;
            }

            cboprelaod_valueunit.Items.Clear();

            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals[cbopreload_channel.SelectedIndex].cUnitCount; i++)
            {

                cboprelaod_valueunit.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[cbopreload_channel.SelectedIndex].cUnits[i]);
            }

            if ((CComLibrary.GlobeVal.filesave.pretest_cmd.destunit >= 0) && (CComLibrary.GlobeVal.filesave.pretest_cmd.destunit < cboprelaod_valueunit.Items.Count))

            {
                cboprelaod_valueunit.SelectedIndex = CComLibrary.GlobeVal.filesave.pretest_cmd.destunit;
            }
            else
            {
                CComLibrary.GlobeVal.filesave.pretest_cmd.destunit = 0;
                cboprelaod_valueunit.SelectedIndex = 0;
            }

            editpreload_speed.Value = CComLibrary.GlobeVal.filesave.pretest_cmd.speed;

            editpreload_value.Value = CComLibrary.GlobeVal.filesave.pretest_cmd.dest;


            lstavail.ClearItem();
            for (int j = 0; j < ClsStaticStation.m_Global.mycls.chsignals.Count; j++)
            {

                if (CComLibrary.GlobeVal.filesave.mautozero == null)
                {
                    lstavail.Items.Add(ClsStaticStation.m_Global.mycls.chsignals[j]);
                }
                else
                {
                    if (this.lstinclude.MatchItem(CComLibrary.GlobeVal.filesave.mautozero,
                        ClsStaticStation.m_Global.mycls.chsignals[j]) == true)
                    {

                    }
                    else
                    {
                        lstavail.AddItem(ClsStaticStation.m_Global.mycls.chsignals[j]);
                    }


                }

            }

            lstinclude.ClearItem();
            for (int j = 0; j < CComLibrary.GlobeVal.filesave.mautozero.Count; j++)
            {


                lstinclude.AddItem(CComLibrary.GlobeVal.filesave.mautozero[j]);


            }

        }
        public void Init(int sel)
        {


            tabControl1.SelectedIndex = sel;
            tlpline1.RowStyles[1].Height = 2;

            if (GlobeVal.UserControlMain1.btnmtest.Visible == true)
            {
                tabControl1.Enabled = false;
            }
            else
            {
                tabControl1.Enabled = true;
            }

            if (sel == 0)
            {
                Init_设置控制();
            }
            if (sel ==1)
            {
                Init_应变();
            }
            if (sel == 2)
            {
                Init_测试前();
            }

            if (sel == 3)
            {
                Init_测试();
            }

            if (sel == 4)
            {
                Init_测试结束();
            }
            if (sel == 5)
            {
                Init_数据();
            }

            if (sel == 6)
            {
                Init_中级();
            }

            if (sel == 7)
            {
                Init_简单();
            }
            if (sel == 8)
            {
                Init_高级();
            }



        }
        public UserControl控制()
        {
            InitializeComponent();
            tabControl1.ItemSize = new Size(1, 1);
            tabControl3.ItemSize = new System.Drawing.Size(1, 1);
            tabControl4.ItemSize = new System.Drawing.Size(1, 1);
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
            this.tableLayoutPanel10.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel10, true, null);
            this.tableLayoutPanel11.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel11, true, null);

            this.tableLayoutPanel12.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel12, true, null);
            this.tableLayoutPanel13.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel13, true, null);

            this.tableLayoutPanel14.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel14, true, null);

            this.tableLayoutPanel15.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel15, true, null);

            this.tableLayoutPanel16.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel16, true, null);

            this.tlpline4.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tlpline4, true, null);

            this.tableLayoutPanel18.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel18, true, null);

            this.tableLayoutPanel19.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel19, true, null);

            this.tlpline2.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tlpline2, true, null);

            this.tlpline1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tlpline1, true, null);
            this.tlpline3.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tlpline3, true, null);

            this.tableLayoutPanel23.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel23, true, null);
            this.tableLayoutPanel30.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel30, true, null);
            this.tableLayoutPanel36.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel36, true, null);
            this.tableLayoutPanel38.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this.tableLayoutPanel38, true, null);


        }

        private void waveshape0_sel()
        {
            cbocontrol.SelectedIndex = getselect().msequence.controlmode;
           

            cbodestcontrol.SelectedIndex = getselect().msequence.destcontrolmode;

            cbocontrol_SelectionChangeCommitted(null, null);
            cbodestcontrol_SelectionChangeCommitted(null, null);


            getselect().msequence.rate = (ItemSignal)m_Global.mycls.chsignals[cbocontrol.SelectedIndex].speedSignal.Clone();

           

            cbospeedunit.Items.Clear();
            for (int i = 0; i < getselect().msequence.rate.cUnitCount; i++)
            {
                cbospeedunit.Items.Add(getselect().msequence.rate.cUnits[i]);
            }

            cbospeedunit.SelectedIndex = getselect().msequence.mrateunit;
            numspeed.Value = getselect().msequence.mrate;
           
        }

        private void waveshape1_sel()
        {

            cbocontrol.SelectedIndex = getselect().msequence.controlmode;
            cbocontrol_SelectionChangeCommitted(null, null);
            numkeeptime.Value = getselect().msequence.keeptime;
            cbokeeptimeunit.Items.Clear();
            cbokeeptimeunit.Items.Add("S");
            cbokeeptimeunit.SelectedIndex = 0;

        }

        private void waveshape2_sel()
        {
            cbocontrol.SelectedIndex = getselect().msequence.controlmode;
            cbocontrol_SelectionChangeCommitted(null, null);
            numtrispeed.Value = getselect().msequence.mtrirate;
            numtricount.Value = getselect().msequence.mtricount;

            cbotriinitdir.Items.Clear();
            cbotriinitdir.Items.Add("向上");
            cbotriinitdir.Items.Add("向下");
            cbotriinitdir.SelectedIndex = getselect().msequence.mtriinitdir;


            numtrimax.Value = getselect().msequence.mtrimax;
            numtrimin.Value = getselect().msequence.mtrimin;
           
        }


        private void waveshape3_sel()
        {
            cbocontrol.SelectedIndex = getselect().msequence.controlmode;
            cbocontrol_SelectionChangeCommitted(null, null);
            cbosinspeedunit.SelectedIndex = getselect().msequence.msinrateunit;
            numsinspeed.Value = getselect().msequence.msinrate;
            numsincount.Value = getselect().msequence.msincount;
            cbosininitdir.Items.Clear();
            cbosininitdir.Items.Add("向上");
            cbosininitdir.Items.Add("向下");
            cbosininitdir.SelectedIndex = getselect().msequence.msininitdir;
            numfreq.Value = getselect().msequence.msinfreq;
            numsinmax.Value = getselect().msequence.msinmax;
            numsinmin.Value = getselect().msequence.msinmin;

        }

        private void waveshape4_sel()
        {
            cbocontrol.SelectedIndex = getselect().msequence.controlmode;
            cbocontrol_SelectionChangeCommitted(null, null);

            numrectspeed.Value = getselect().msequence.mrectrate;
            cborectspeedunit.SelectedIndex = getselect().msequence.mrectrateunit;
            numrectcount.Value = getselect().msequence.mrectcount;
            cborectinitdir.Items.Clear();
            cborectinitdir.Items.Add("向上");
            cborectinitdir.Items.Add("向下");
            cborectinitdir.SelectedIndex = getselect().msequence.mrectinitdir;

            numrectupspeed.Value = getselect().msequence.mrectuprate;
            numrectdownspeed.Value = getselect().msequence.mrectdownrate;
            numrectupdest.Value = getselect().msequence.mrectupdest;
            numrectdowndest.Value = getselect().msequence.mrectdowndest;
            numrectupkeeptime.Value = getselect().msequence.mrectupkeeptime;
            numrectdownkeeptime.Value = getselect().msequence.mrectdownkeeptime;
        }

        private void UserControlStep1_btnselectevent(object sender, int index)
        {
            if ((sender as UserControlStep).selected)
            {
                return;
            }
            for (int i = 0; i < listViewEx1.mlist.Count; i++)
            {
                listViewEx1.mlist[i].selected = false;
            }



            (sender as UserControlStep).selected = true;


            for (int i = 0; i < toolStripWave.Items.Count; i++)
            {
                (toolStripWave.Items[i] as ToolStripButton).Checked = false;
            }
            (toolStripWave.Items[(sender as UserControlStep).Kind] as ToolStripButton).Checked = true;


            lblstep.Text = "步骤" + ((sender as UserControlStep).Id + 1).ToString() + "名称：";

            txtstep.Text = (sender as UserControlStep).msequence.stepname;


            chkjump.Checked = (sender as UserControlStep).msequence.chkjump;
            cbojump.Items.Clear();

            for( int i=0;i<listViewEx1.mlist.Count;i++)
            {
                cbojump.Items.Add((i+1).ToString());
            }
            cbojump.SelectedIndex = (sender as UserControlStep).msequence.intjumpto;
            numcount.Value = (sender as UserControlStep).msequence.cycliccount;

            cbomethod.SelectedIndex = (sender as UserControlStep).msequence.samplingmode;

            cbomethod_SelectionChangeCommitted(null, null);


            

            for (int i = 1; i < grid3.Rows.Count ; i++)
            {


                grid3[i, 0].Value = (sender as UserControlStep).msequence.chkchannel[i - 1];

                grid3[i, 2].Value = (sender as UserControlStep).msequence.sampleinterval[i - 1];
            }


                if ((sender as UserControlStep).msequence.wavekind == 0)
            {


              
                tbtnramp_Click (null, null);
            }

            if ((sender as UserControlStep).msequence.wavekind == 1)
            {
                
               tbtnkeep_Click (null, null);
            }

            if ((sender as UserControlStep).msequence.wavekind == 2)
            {
                toolStripButton3_Click(null, null);
            }

            if ((sender as UserControlStep).msequence.wavekind ==3)
            {
               
                toolStripButton7_Click(null, null);
            }

            if ((sender as UserControlStep).msequence.wavekind ==4)
            {
               
                toolStripButton8_Click(null, null);
            }

            return;
        }

        private void UserControlStep1_btnrightevent(object sender, int index)
        {
            UserControlStep p = new UserControlStep();

            p.Kind = 0;
            p.selected = false;
            p.settail(1);

            p.btnrightevent += this.UserControlStep1_btnrightevent;
            p.btncopyevent += this.UserControlStep1_btncopyevent;
            p.btncutevent += this.UserControlStep1_btncutevent;
            p.btnleftevent += this.UserControlStep1_btnleftevent;
            p.btnselectevent += this.UserControlStep1_btnselectevent;

            int mm = (sender as UserControlStep).Id;
            ColumnHeader m = new ColumnHeader();
            p.Width = 270;
            m.Width = p.Width;


            listViewEx1.mlist.Insert(mm + 1, p);
            listViewEx1.Columns.Insert(mm + 1, m);

            listViewEx1.reset();

            return;
        }

        private void UserControlStep1_btnleftevent(object sender, int index)
        {
            UserControlStep p = new UserControlStep();

            p.Kind = 0;
            p.selected = false;
            p.settail(1);

            p.btnrightevent += this.UserControlStep1_btnrightevent;
            p.btncopyevent += this.UserControlStep1_btncopyevent;
            p.btncutevent += this.UserControlStep1_btncutevent;
            p.btnleftevent += this.UserControlStep1_btnleftevent;
            p.btnselectevent += this.UserControlStep1_btnselectevent;

            int mm = (sender as UserControlStep).Id;
            ColumnHeader m = new ColumnHeader();
            p.Width = 270;
            m.Width = p.Width;


            listViewEx1.mlist.Insert(mm, p);
            listViewEx1.Columns.Insert(mm, m);


            listViewEx1.reset();



            return;
        }

        private void UserControlStep1_btncutevent(object sender, int index)
        {

            DialogResult a = MessageBox.Show("是否删除当前模块？", "提示", MessageBoxButtons.YesNo);

            if (a == DialogResult.Yes)
            {
                UserControlStep p;
                int b = 0;
                for (int i = 0; i < listViewEx1.mlist.Count; i++)
                {
                    if (listViewEx1.mlist[i].selected == true)
                    {
                        b = i;
                    }
                }

                p = listViewEx1.mlist[b];

                p.btnrightevent -= this.UserControlStep1_btnrightevent;
                p.btncopyevent -= this.UserControlStep1_btncopyevent;
                p.btncutevent -= this.UserControlStep1_btncutevent;
                p.btnleftevent -= this.UserControlStep1_btnleftevent;
                p.btnselectevent -= this.UserControlStep1_btnselectevent;


                listViewEx1.mlist.RemoveAt(b);
                listViewEx1.Columns.RemoveAt(b);
                listViewEx1.reset();
                p.Dispose();
            }
            return;
        
           
        }

        private void UserControlStep1_btncopyevent(object sender, int index)
        {
            UserControlStep p1;
            UserControlStep p;
            int b = 0;
            for (int i = 0; i < listViewEx1.mlist.Count; i++)
            {
                if (listViewEx1.mlist[i].selected == true)
                {
                    b = i;
                }
            }

            p1 = listViewEx1.mlist[b];

           p = new UserControlStep();

            p.Kind = p1.Kind;
            p.msequence.stepname = p1.msequence.stepname;
            p.msequence.wavekind = p1.msequence.wavekind;

            p.selected = false;
            p.settail(1);

            p.btnrightevent += this.UserControlStep1_btnrightevent;
            p.btncopyevent += this.UserControlStep1_btncopyevent;
            p.btncutevent += this.UserControlStep1_btncutevent;
            p.btnleftevent += this.UserControlStep1_btnleftevent;
            p.btnselectevent += this.UserControlStep1_btnselectevent;

            int mm = (sender as UserControlStep).Id;
            ColumnHeader m = new ColumnHeader();
            p.Width = 270;
            m.Width = p.Width;


            listViewEx1.mlist.Insert(mm + 1, p);
            listViewEx1.Columns.Insert(mm + 1, m);

            listViewEx1.reset();

            
            return;
        }



        private void cbocontrolprocess_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.mcontrolprocess = cbocontrolprocess.SelectedIndex;

        }

        private void btnadd_Click(object sender, EventArgs e)
        {

            if (this.lstavail.SelectedItem != null)
            {
                this.lstinclude.AddItem(this.lstavail.list[this.lstavail.SelectedIndex]);

                this.lstavail.RemoveItem(this.lstavail.SelectedIndex);

                list_autozerosetvalue();

            }

        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            if (this.lstinclude.SelectedItem != null)
            {
                this.lstavail.AddItem(this.lstinclude.list[this.lstinclude.SelectedIndex]);
                this.lstinclude.RemoveItem(this.lstinclude.SelectedIndex);

                list_autozerosetvalue();
            }
        }

        private void cbotestendCriteria1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbotestendCriteria1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.endoftest1criteria = cbotestendCriteria1.SelectedIndex;


            numtestendvalue1.Value = 0;


            if (cbotestendCriteria1.SelectedIndex == 0)
            {
                lbltestend1.Text = "灵敏度 (%)";


            }
            else if (cbotestendCriteria1.SelectedIndex == 1)
            {
                lbltestend1.Text = "载荷下降到 ";

            }
            else if (cbotestendCriteria1.SelectedIndex == 2)
            {
                lbltestend1.Text = "数值";
            }
        }

        private void cbotestendCriteria2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.endoftest2criteria = cbotestendCriteria2.SelectedIndex;

            if (cbotestendCriteria2.SelectedIndex == 0)
            {
                lbltestend2.Text = "灵敏度 (%)";


            }
            else if (cbotestendCriteria2.SelectedIndex == 1)
            {
                lbltestend2.Text = "载荷下降到 ";

            }
            else if (cbotestendCriteria2.SelectedIndex == 2)
            {
                lbltestend2.Text = "数值";
            }

            numtestendvalue2.Value = 0;
        }


        private void num1_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            CComLibrary.GlobeVal.filesave.crackvalue = num1.Value;
        }

        private void grid1_CellLostFocus(object sender, SourceGrid2.PositionCancelEventArgs e)
        {

            if (e.Position.Column == 2)
            {
                for (int i = 1; i <= CComLibrary.GlobeVal.filesave.mchsignals.Count; i++)
                {
                    if (i == e.Position.Row)
                    {
                        CComLibrary.GlobeVal.filesave.mchsignals[i - 1].uplimit = Convert.ToDouble(e.Cell.GetDisplayText(new SourceGrid2.Position(e.Position.Row, e.Position.Column)));
                    }
                }
            }

            if (e.Position.Column == 3)
            {
                for (int i = 1; i <= CComLibrary.GlobeVal.filesave.mchsignals.Count; i++)
                {
                    if (i == e.Position.Row)
                    {
                        CComLibrary.GlobeVal.filesave.mchsignals[i - 1].donwlimit = Convert.ToDouble(e.Cell.GetDisplayText(new SourceGrid2.Position(e.Position.Row, e.Position.Column)));
                    }
                }
            }
        }

        private void cbopreload_controlmode_SelectionChangeCommitted(object sender, EventArgs e)
        {

            CComLibrary.GlobeVal.filesave.pretest_cmd.controlmode = cbopreload_controlmode.SelectedIndex;
            cbopreload_speedunit.Items.Clear();
            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals[cbopreload_controlmode.SelectedIndex].speedSignal.cUnitCount; i++)
            {
                cbopreload_speedunit.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[cbopreload_controlmode.SelectedIndex].speedSignal.cUnits[i]);

            }

            cbopreload_speedunit.SelectedIndex = 0;

        }

        private void chkpreload_CheckStateChanged(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.pretest_cmd.check = chkpreload.Checked;
        }

        private void editpreload_speed_ValueChanged(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.pretest_cmd.speed = editpreload_speed.Value;
        }

        private void cbopreload_channel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.pretest_cmd.destcontrolmode = cbopreload_channel.SelectedIndex;
            cboprelaod_valueunit.Items.Clear();

            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals[cbopreload_channel.SelectedIndex].cUnitCount; i++)
            {

                cboprelaod_valueunit.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[cbopreload_channel.SelectedIndex].cUnits[i]);
            }

            cboprelaod_valueunit.SelectedIndex = 0;
        }

        private void editpreload_value_ValueChanged(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.pretest_cmd.dest = editpreload_value.Value;
        }

        private void chkline1_CheckStateChanged(object sender, EventArgs e)
        {

            CComLibrary.GlobeVal.filesave.testcmdstep[0].check = chkline1.Checked;
        }

        private void chkline2_CheckStateChanged(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.testcmdstep[1].check = chkline2.Checked;
        }

        private void chkline3_CheckStateChanged(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.testcmdstep[2].check = chkline3.Checked;
        }

        private void chkline4_CheckStateChanged(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.testcmdstep[3].check = chkline4.Checked;
        }


        private void cbocontrol1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.testcmdstep[0].controlmode = cbocontrol1.SelectedIndex;

            cbospeedunit1.Items.Clear();
            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals[cbocontrol1.SelectedIndex].speedSignal.cUnitCount; i++)
            {
                cbospeedunit1.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[cbocontrol1.SelectedIndex].speedSignal.cUnits[i]);

            }

            cbospeedunit1.SelectedIndex = 0;
        }

        private void cbocontrol2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.testcmdstep[1].controlmode = cbocontrol2.SelectedIndex;

            cbospeedunit2.Items.Clear();
            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals[cbocontrol2.SelectedIndex].speedSignal.cUnitCount; i++)
            {
                cbospeedunit2.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[cbocontrol2.SelectedIndex].speedSignal.cUnits[i]);

            }

            cbospeedunit2.SelectedIndex = 0;
        }

        private void cbocontrol3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.testcmdstep[2].controlmode = cbocontrol3.SelectedIndex;

            cbospeedunit3.Items.Clear();
            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals[cbocontrol3.SelectedIndex].speedSignal.cUnitCount; i++)
            {
                cbospeedunit3.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[cbocontrol3.SelectedIndex].speedSignal.cUnits[i]);

            }

            cbospeedunit3.SelectedIndex = 0;
        }

        private void cbocontrol4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.testcmdstep[3].controlmode = cbocontrol4.SelectedIndex;

            cbospeedunit4.Items.Clear();
            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals[cbocontrol4.SelectedIndex].speedSignal.cUnitCount; i++)
            {
                cbospeedunit4.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[cbocontrol4.SelectedIndex].speedSignal.cUnits[i]);

            }

            cbospeedunit4.SelectedIndex = 0;
        }

        private void cbodestcontrol1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.testcmdstep[0].destcontrolmode = cbodestcontrol1.SelectedIndex;

            cbovalueunit1.Items.Clear();

            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals[cbodestcontrol1.SelectedIndex].cUnitCount; i++)
            {

                cbovalueunit1.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[cbodestcontrol1.SelectedIndex].cUnits[i]);
            }

            cbovalueunit1.SelectedIndex = 0;
        }

        private void cbodestcontrol2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.testcmdstep[1].destcontrolmode = cbodestcontrol2.SelectedIndex;

            cbovalueunit2.Items.Clear();

            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals[cbodestcontrol2.SelectedIndex].cUnitCount; i++)
            {

                cbovalueunit2.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[cbodestcontrol2.SelectedIndex].cUnits[i]);
            }

            cbovalueunit2.SelectedIndex = 0;
        }

        private void cbodestcontrol3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.testcmdstep[2].destcontrolmode = cbodestcontrol3.SelectedIndex;

            cbovalueunit3.Items.Clear();

            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals[cbodestcontrol3.SelectedIndex].cUnitCount; i++)
            {

                cbovalueunit3.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[cbodestcontrol3.SelectedIndex].cUnits[i]);
            }

            cbovalueunit3.SelectedIndex = 0;
        }

        private void cbodestcontrol4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.testcmdstep[3].destcontrolmode = cbodestcontrol4.SelectedIndex;

            cbovalueunit4.Items.Clear();

            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals[cbodestcontrol4.SelectedIndex].cUnitCount; i++)
            {

                cbovalueunit4.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[cbodestcontrol4.SelectedIndex].cUnits[i]);
            }

            cbovalueunit4.SelectedIndex = 0;
        }



        private void numspeed1_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            CComLibrary.GlobeVal.filesave.testcmdstep[0].speed = numspeed1.Value;
        }

        private void numspeed2_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            CComLibrary.GlobeVal.filesave.testcmdstep[1].speed = numspeed2.Value;
        }

        private void numspeed3_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            CComLibrary.GlobeVal.filesave.testcmdstep[2].speed = numspeed3.Value;
        }

        private void numspeed4_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            CComLibrary.GlobeVal.filesave.testcmdstep[3].speed = numspeed4.Value;
        }

        private void numvalue1_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            CComLibrary.GlobeVal.filesave.testcmdstep[0].dest = numvalue1.Value;
        }

        private void numvalue2_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            numvalue2.Value = CComLibrary.GlobeVal.filesave.testcmdstep[1].dest;
        }

        private void numvalue3_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            numvalue3.Value = CComLibrary.GlobeVal.filesave.testcmdstep[2].dest;
        }

        private void numvalue4_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            numvalue4.Value = CComLibrary.GlobeVal.filesave.testcmdstep[3].dest;
        }

        private void tsbtnadd_Click(object sender, EventArgs e)
        {
            sf.add();
            Add(grid2.RowsCount, ref sf);
        }

        private void tsbtnnew_Click(object sender, EventArgs e)
        {
            String s;
            Frm.Form新建程序文件 f = new TabHeaderDemo.Frm.Form新建程序文件();
            f.result = false;
            f.ShowDialog();

            if (f.result == true)
            {
                s = f.txtname.Text;

                sf = new CComLibrary.SegFile();
                grid2.RowsCount = 1;
                sf.mseglist.Clear();
                sf.add();
                Add(1, ref sf);

                sf.SerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ\\seg\\" + s + ".seg");

                tscbo.Items.Clear();
                tscbo.Text = s + ".seg";
                DirectoryInfo info = new DirectoryInfo(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ\\seg");
                FileInfo[] files = info.GetFiles("*.seg");
                foreach (FileInfo file in files)
                {
                    tscbo.Items.Add(file.Name);
                }

                tscbo.Text = s + ".seg";
            }


        }

        private void tsbtnsave_Click(object sender, EventArgs e)
        {

            if (System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ\\seg\\" + tscbo.Text) == true)
            {
                System.IO.File.Delete(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ\\seg\\" + tscbo.Text);
            }

            sf.SerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ\\seg\\" + tscbo.Text);


        }

        private void tsbtnkill_Click(object sender, EventArgs e)
        {


            if (System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ\\seg\\" + tscbo.Text) == true)
            {
                DialogResult b = MessageBox.Show("是否删除文件[" + tscbo.Text + "]?", "提示", MessageBoxButtons.YesNo);

                if (b == DialogResult.Yes)
                {

                    System.IO.File.Delete(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ\\seg\\" + tscbo.Text);
                }
                else
                {
                    return;
                }
            }
            grid2.RowsCount = 1;

            sf.clear();

            DirectoryInfo info = new DirectoryInfo(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ\\seg");
            FileInfo[] files = info.GetFiles("*.seg");
            foreach (FileInfo file in files)
            {
                tscbo.Items.Add(file.Name);
            }


        }

        private void tscbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mloaded == false)
            {
                sf.mseglist.Clear();
                sf = sf.DeSerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ\\seg\\" + tscbo.Text);

                int i = 0;

                grid2.RowsCount = 1;


                int c = sf.mseglist.Count;

                for (i = 1; i <= c; i++)
                {
                    Add(i, ref sf);
                }
                CComLibrary.GlobeVal.filesave.SegName = tscbo.Text;

            }
        }


        private void grid2_CellGotFocus(object sender, SourceGrid2.PositionCancelEventArgs e)
        {
            if (grid2.Rows.Count > 0)
            {
                curcol = e.Position.Column;
                currow = e.Position.Row;
            }

        }

        private void grid2_SettingCell(object sender, SourceGrid2.PositionEventArgs e)
        {

        }

        private void tsbtnrename_Click(object sender, EventArgs e)
        {
            String s;
            string s1;
            Frm.Form新建程序文件 f = new TabHeaderDemo.Frm.Form新建程序文件();
            f.result = false;
            f.Text = "重命名";
            f.ShowDialog();
            if (f.result == true)
            {
                s = f.txtname.Text;
                if (System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ\\seg\\" + tscbo.Text) == true)
                {
                    s1 = System.Windows.Forms.Application.StartupPath + "\\AppleLabJ\\seg\\" + tscbo.Text;
                    System.IO.File.Move(s1,
                        System.Windows.Forms.Application.StartupPath + "\\AppleLabJ\\seg\\" + s + ".seg");

                }
                tscbo.Items.Clear();
                DirectoryInfo info = new DirectoryInfo(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ\\seg");
                FileInfo[] files = info.GetFiles("*.seg");
                foreach (FileInfo file in files)
                {
                    tscbo.Items.Add(file.Name);
                }

                tscbo.Text = s + ".seg";
            }
        }

        private void tsbtninsert_Click(object sender, EventArgs e)
        {
            if (currow <= 1)
            {
                MessageBox.Show("不能在第一行插入");
                return;
            }

            DialogResult a = MessageBox.Show("是否在当前位置之前插入？", "提示", MessageBoxButtons.YesNo);


            if (a == DialogResult.Yes)
            {
                CComLibrary.SegTest m = new CComLibrary.SegTest();
                sf.mseglist.Insert(currow - 1, m);
                Add(currow - 1, ref sf);

            }




        }

        private void tsbtndel_Click(object sender, EventArgs e)
        {
            int w = 0;
            DialogResult a = MessageBox.Show("是否删除？", "提示", MessageBoxButtons.YesNo);
            if (a == DialogResult.Yes)
            {
                w = currow - 1;
                sf.mseglist.RemoveAt(w);
                grid2.Rows.Remove(w + 1);
            }

        }

        private void tscbo_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void numericEdit1_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            CComLibrary.GlobeVal.filesave.SampleInterval = numericEdit1.Value;
        }

        private void chkcrack_CheckedChanged(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.crackcheck = chkcrack.Checked;
        }

        private void chkstep1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        
        private UserControlStep getselect()
        {
            int j = 0;

            for (int i = 0; i < listViewEx1.mlist.Count; i++)
            {
                if (listViewEx1.mlist[i].selected == true)
                {
                    j = i;



                }
            }

            return listViewEx1.mlist[j];

        }
        private void tbtnramp_Click(object sender, EventArgs e)
        {


            tabControl3.SelectedIndex = 0;

            getselect().Kind = 0;

            getselect().msequence.wavekind = 0;

            tbtnramp.Checked = true;
            tbtnkeep.Checked = false;
            toolStripButton3.Checked = false;
            toolStripButton7.Checked = false;
            toolStripButton8.Checked = false;
            toolStripButton9.Checked = false;

            waveshape0_sel();
            
        }

        private void tbtnkeep_Click(object sender, EventArgs e)
        {
            tabControl3.SelectedIndex = 1;
            getselect().Kind = 1;
            getselect().msequence.wavekind = 1;
            tbtnramp.Checked = false;
            tbtnkeep.Checked = true;
            toolStripButton3.Checked = false;
            toolStripButton7.Checked = false;
            toolStripButton8.Checked = false;
            toolStripButton9.Checked = false;
            waveshape1_sel();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            tabControl3.SelectedIndex = 2;
            getselect().Kind = 2;
            getselect().msequence.wavekind = 2;
            tbtnramp.Checked = false;
            tbtnkeep.Checked = false;
            toolStripButton3.Checked = true;
            toolStripButton7.Checked = false;
            toolStripButton8.Checked = false;
            toolStripButton9.Checked = false;
            waveshape2_sel();
        }

        private void tlpedit_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listViewEx1_VScroll(object sender, EventArgs e)
        {

        }

        private void listViewEx1_HScroll(object sender, EventArgs e)
        {


        }



        private void addSequence(CComLibrary.Sequence seq)
        {
            listViewEx1.mlist.Clear();

            listViewEx1.Columns.Clear();

            UserControlStep p = new UserControlStep();

            p.Kind = 0;
            p.selected = true;
            p.settail(1);
            p.Id = 0;
            p.btnrightevent += this.UserControlStep1_btnrightevent;
            p.btncopyevent += this.UserControlStep1_btncopyevent;
            p.btncutevent += this.UserControlStep1_btncutevent;
            p.btnleftevent += this.UserControlStep1_btnleftevent;
            p.btnselectevent += this.UserControlStep1_btnselectevent;
            p.Width = 270;
            ColumnHeader m = new ColumnHeader();
            m.Width = p.Width;

            listViewEx1.mlist.Add(p);
            listViewEx1.Columns.Add(m);

            listViewEx1.AddEmbeddedControl(p, 0, 0);
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            String s;
            Frm.Form新建程序文件 f = new TabHeaderDemo.Frm.Form新建程序文件();
            f.result = false;
            f.ShowDialog();

            if (f.result == true)
            {
                s = f.txtname.Text;


                sqf.mSequencelist.Clear();
                sqf.add();

                addSequence(sqf.mSequencelist[0]);





                sqf.SerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ\\sequence\\" + s + ".seq");

                tscbos.Items.Clear();
                tscbos.Text = s + ".seq";
                DirectoryInfo info = new DirectoryInfo(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ\\sequence");
                FileInfo[] files = info.GetFiles("*.seq");
                foreach (FileInfo file in files)
                {
                    tscbos.Items.Add(file.Name);
                }

                tscbos.Text = s + ".seq";
            }

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ\\sequence\\" + tscbos.Text) == true)
            {
                System.IO.File.Delete(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ\\sequence\\" + tscbos.Text);
            }

            sqf.clear();

            for (int i = 0; i < listViewEx1.mlist.Count; i++)
            {
                sqf.add(listViewEx1.mlist[i].msequence);
            }
            sqf.SerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ\\sequence\\" + tscbos.Text);


        }

       

        private void tscbos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mloaded == false)
            {

                sqf.clear();
                sqf = sqf.DeSerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ\\sequence\\" + tscbos.Text);



                listViewEx1.mlist.Clear();

                listViewEx1.Columns.Clear();



                for (int i = 0; i < sqf.mSequencelist.Count; i++)
                {
                    UserControlStep p = new UserControlStep();

                    p.msequence = sqf.mSequencelist[i];

                    p.Kind = sqf.mSequencelist[i].wavekind;

                   
                    p.selected = false;

                    if (sqf.mSequencelist[i].chkjump == true)
                    {
                        p.settail(2);
                       
                    }
                    else
                    {
                        if (i == sqf.mSequencelist.Count-1)
                        {
                            p.settail(1);
                        }
                        else
                        {
                            p.settail(0);
                        }
                    }
                    p.Id = i;

                    

                    p.btnrightevent += this.UserControlStep1_btnrightevent;
                    p.btncopyevent += this.UserControlStep1_btncopyevent;
                    p.btncutevent += this.UserControlStep1_btncutevent;
                    p.btnleftevent += this.UserControlStep1_btnleftevent;
                    p.btnselectevent += this.UserControlStep1_btnselectevent;
                    p.Width = 270;
                    ColumnHeader m = new ColumnHeader();
                    m.Width = p.Width;

                    listViewEx1.mlist.Add(p);
                    listViewEx1.Columns.Add(m);




                }

                listViewEx1.reset();

                CComLibrary.GlobeVal.filesave.SequenceName = tscbos.Text;


            }
        }

        private void numspeed_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            getselect().msequence.mrate = numspeed.Value;
        }

        private void cbospeedunit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getselect().msequence.mrateunit = cbospeedunit.SelectedIndex;
        }

        private void cbocontrol_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getselect().msequence.controlmode = cbocontrol.SelectedIndex;

      


            if (getselect().msequence.wavekind == 0)
            {
                getselect().msequence.rate = (ItemSignal)m_Global.mycls.chsignals[cbocontrol.SelectedIndex].speedSignal.Clone();

                cbospeedunit.Items.Clear();
                for (int i = 0; i < getselect().msequence.rate.cUnitCount; i++)
                {
                    cbospeedunit.Items.Add(getselect().msequence.rate.cUnits[i]);
                }

                cbospeedunit.SelectedIndex = getselect().msequence.mrateunit;
            }

            if (getselect().msequence.wavekind == 1)
            {
                cbokeeptimeunit.Items.Clear();
                cbokeeptimeunit.Items.Add("S");
                cbokeeptimeunit.SelectedIndex = 0;

            }

            if (getselect().msequence.wavekind == 2)
            {
                getselect().msequence.trirate = (ItemSignal)m_Global.mycls.chsignals[cbocontrol.SelectedIndex].speedSignal.Clone();

                cbotrispeedunit.Items.Clear();

                for (int i = 0; i < getselect().msequence.trirate.cUnitCount; i++)
                {
                    cbotrispeedunit.Items.Add(getselect().msequence.trirate.cUnits[i]);
                }

                cbotrispeedunit.SelectedIndex = getselect().msequence.mtrirateunit;

                txttrimaxunit.Text = m_Global.mycls.chsignals[cbocontrol.SelectedIndex].cUnits[0];
                txttriminunit.Text = m_Global.mycls.chsignals[cbocontrol.SelectedIndex].cUnits[0];

            }
            if (getselect().msequence.wavekind ==3)
            {
                getselect().msequence.sinrate = (ItemSignal)m_Global.mycls.chsignals[cbocontrol.SelectedIndex].speedSignal.Clone();
                cbosinspeedunit.Items.Clear();
                for (int i = 0; i < getselect().msequence.sinrate.cUnitCount; i++)
                {
                    cbosinspeedunit.Items.Add(getselect().msequence.sinrate.cUnits[i]);
                }

                cbosinspeedunit.SelectedIndex = getselect().msequence.msinrateunit;
                txtsinmaxunit.Text = m_Global.mycls.chsignals[cbocontrol.SelectedIndex].cUnits[0];
                txtsinminunit.Text = m_Global.mycls.chsignals[cbocontrol.SelectedIndex].cUnits[0];
            }

            if (getselect().msequence.wavekind ==4)
            {
                getselect().msequence.rectrate = (ItemSignal)m_Global.mycls.chsignals[cbocontrol.SelectedIndex].speedSignal.Clone();
                cborectspeedunit.Items.Clear();
                for (int i = 0; i < getselect().msequence.rectrate.cUnitCount; i++)
                {
                    cborectspeedunit.Items.Add(getselect().msequence.rectrate.cUnits[i]);
                }

                cborectspeedunit.SelectedIndex = getselect().msequence.mrectrateunit;
                txtrectupspeedunit.Text = getselect().msequence.rectrate.cUnits[getselect().msequence.mrectrateunit];
                txtrectdownspeedunit.Text = getselect().msequence.rectrate.cUnits[getselect().msequence.mrectrateunit];
                txtrectudestunit.Text = m_Global.mycls.chsignals[cbocontrol.SelectedIndex].cUnits[0];
                txtrectdowndestunit.Text = m_Global.mycls.chsignals[cbocontrol.SelectedIndex].cUnits[0];
                txtrectupkeeptimeunit.Text = "S";
                txtrectdownkeeptimeunit.Text = "S";
            }

            if (getselect().msequence.wavekind ==5)
            {

            }
        }

        private void cbocontrol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbodestcontrol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numdest_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            getselect().msequence.mdest = numdest.Value;
        }

        private void cbodestunit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getselect().msequence.mdestunit = cbodestunit.SelectedIndex;
        }

        private void cbodestcontrol_SizeChanged(object sender, EventArgs e)
        {

        }

        private void cbodestcontrol_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getselect().msequence.destcontrolmode = cbodestcontrol.SelectedIndex;
            getselect().msequence.dest = (ItemSignal)m_Global.mycls.chsignals[cbodestcontrol.SelectedIndex].Clone();
            numdest.Value = getselect().msequence.mdest;
            cbodestunit.Items.Clear();
            for (int i = 0; i < getselect().msequence.dest.cUnitCount; i++)
            {
                cbodestunit.Items.Add(getselect().msequence.dest.cUnits[i]);
            }

            cbodestunit.SelectedIndex = getselect().msequence.mdestunit;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            tabControl3.SelectedIndex = 3;
            getselect().Kind = 3;
            getselect().msequence.wavekind = 3;
            tbtnramp.Checked = false;
            tbtnkeep.Checked = false;
            toolStripButton3.Checked = false;
            toolStripButton7.Checked = true;
            toolStripButton8.Checked = false;
            toolStripButton9.Checked = false;
            waveshape3_sel();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            tabControl3.SelectedIndex = 4;
            getselect().Kind = 4;
            getselect().msequence.wavekind = 4;
            tbtnramp.Checked = false;
            tbtnkeep.Checked = false;
            toolStripButton3.Checked = false;
            toolStripButton7.Checked = false;
            toolStripButton8.Checked = true;
            toolStripButton9.Checked = false;
            waveshape4_sel();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            tabControl3.SelectedIndex = 5;
            getselect().Kind = 5;
            getselect().msequence.wavekind = 5;
            tbtnramp.Checked = false;
            tbtnkeep.Checked = false;
            toolStripButton3.Checked = false;
            toolStripButton7.Checked = false;
            toolStripButton8.Checked = false;
            toolStripButton9.Checked = true;
            
        }

        private void txtstep_TextChanged(object sender, EventArgs e)
        {
            getselect().msequence.stepname = txtstep.Text;
            getselect().setcaption();
        }

        private void numkeeptime_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            getselect().msequence.keeptime = numkeeptime.Value;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void numtrispeed_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            getselect().msequence.mtrirate = numtrispeed.Value;
        }

        private void numtricount_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            getselect().msequence.mtricount = Convert.ToInt32( numtricount.Value);
        }

        private void numtrimax_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            getselect().msequence.mtrimax = numtrimax.Value;
        }

        private void numtrimin_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            getselect().msequence.mtrimin = numtrimin.Value;
        }

        private void cbotriinitdir_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getselect().msequence.mtriinitdir = cbotriinitdir.SelectedIndex;
        }

        private void cbotrispeedunit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getselect().msequence.mtrirateunit = cbotrispeedunit.SelectedIndex ;
        }

        private void numsinspeed_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            getselect().msequence.msinrate = numsinspeed.Value;
        }

        private void numsincount_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            getselect().msequence.msincount = Convert.ToInt32( numsincount.Value);
        }

        private void cbosininitdir_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getselect().msequence.msininitdir = cbosininitdir.SelectedIndex;
        }

        private void numsinmax_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            getselect().msequence.msinmax = numsinmax.Value;
        }

        private void numsinmin_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            getselect().msequence.msinmin = numsinmin.Value;
        }

        private void cbosinspeedunit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getselect().msequence.msinrateunit = cbosinspeedunit.SelectedIndex;
        }

        private void numrectspeed_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            getselect().msequence.mrectrate = numrectspeed.Value;
        }

        private void cborectspeedunit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getselect().msequence.mrectrateunit = cborectspeedunit.SelectedIndex;
        }

        private void numrectcount_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            getselect().msequence.mrectcount = Convert.ToInt32( numrectcount.Value);
        }

        private void cborectinitdir_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getselect().msequence.mrectinitdir = cborectinitdir.SelectedIndex;

        }

        private void numrectupspeed_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            getselect().msequence.mrectuprate = numrectupspeed.Value;
        }

        private void numrectupdest_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            getselect().msequence.mrectupdest = numrectupdest.Value;
        }

        private void numrectupkeeptime_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            getselect().msequence.mrectupkeeptime = numrectupkeeptime.Value;
        }

        private void numrectdownspeed_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            getselect().msequence.mrectdownrate = numrectdownspeed.Value;
        }

        private void numrectdowndest_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            getselect().msequence.mrectdowndest = numrectdowndest.Value;
        }

        private void numrectdownkeeptime_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            getselect().msequence.mrectdownkeeptime = numrectdownkeeptime.Value;
        }

        private void cbocontrol_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void numfreq_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            getselect().msequence.msinfreq = numfreq.Value; 
        }

        private void cbomethod_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cbomethod_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getselect().msequence.samplingmode = cbomethod.SelectedIndex;
            if (cbomethod.SelectedIndex == 0)
            {
                grid3.Visible  = false;
            }
            else if( cbomethod.SelectedIndex ==1)
            {
                grid3.Visible  = true;
            }
            else if(cbomethod.SelectedIndex ==2)
            {
                grid3.Visible = false;
            }
        }

        private void grid3_SettingCell(object sender, SourceGrid2.PositionEventArgs e)
        {
            
        }

        private void grid3_CellLostFocus(object sender, SourceGrid2.PositionCancelEventArgs e)
        {
            if (e.Position.Column ==0)
            {
                getselect().msequence.chkchannel[e.Position.Row - 1] =  Convert.ToBoolean( e.Cell.GetValue(new SourceGrid2.Position(e.Position.Row, e.Position.Column)));
            }

            if (e.Position.Column ==2)
            {
                getselect().msequence.sampleinterval[e.Position.Row - 1] = Convert.ToDouble(e.Cell.GetValue(new SourceGrid2.Position(e.Position.Row, e.Position.Column)));
            }
        }

        private void chkjump_CheckStateChanged(object sender, EventArgs e)
        {
            getselect().msequence.chkjump = chkjump.Checked;

            if (chkjump.Checked == true)
            {
                getselect().settail(2);

            }
            else
            {
                if (getselect().Id == listViewEx1.mlist.Count - 1)
                {
                    getselect().settail(1);
                }
                else
                {
                    getselect().settail(0); 
                }

            }

           // getselect().Refresh();
        }

        private void cbojump_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getselect().msequence.intjumpto = cbojump.SelectedIndex;
        }

        private void numcount_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            getselect().msequence.cycliccount = Convert.ToInt32( numcount.Value);
        }

        private void btnpre_Click(object sender, EventArgs e)
        {
            int j = 0;

            for (int i = 0; i < listViewEx1.mlist.Count; i++)
            {
                if (listViewEx1.mlist[i].selected == true)
                {
                    j = i;


                    break;
                }
            }

            if (j == 0)
            {
                return;
            }
            else
            {
                j = j - 1;
            }

            UserControlStep1_btnselectevent(listViewEx1.mlist[j], 0);
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            int j = 0;

            for (int i = 0; i < listViewEx1.mlist.Count; i++)
            {
                if (listViewEx1.mlist[i].selected == true)
                {
                    j = i;


                    break;
                }
            }

            if (j == listViewEx1.mlist.Count-1)
            {
                return;
            }
            else
            {
                j = j + 1;
            }
         
            UserControlStep1_btnselectevent(listViewEx1.mlist[j], 0);
               
        }

        private void btnlast_Click(object sender, EventArgs e)
        {
            int j = 0;

           

            j = listViewEx1.mlist.Count - 1;

            if (listViewEx1.mlist[j].selected ==true )
            {
                return;
            }
          

            UserControlStep1_btnselectevent(listViewEx1.mlist[j], 0);
        }

        private void btnfirst_Click(object sender, EventArgs e)
        {
            int j = 0;



            j = 0;

            if (listViewEx1.mlist[j].selected == true)
            {
                return;
            }


            UserControlStep1_btnselectevent(listViewEx1.mlist[j], 0);
        }

        private void chkjump_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbopreload_speedunit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.pretest_cmd.speedunit = cbopreload_speedunit.SelectedIndex;
        }

        private void cboprelaod_valueunit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.pretest_cmd.destunit = cboprelaod_valueunit.SelectedIndex; 
        }

        private void cbospeedunit1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.testcmdstep[0].speedunit =cbospeedunit1.SelectedIndex ;
        }

        private void cbospeedunit2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.testcmdstep[1].speedunit = cbospeedunit2.SelectedIndex;
        }

        private void cbospeedunit3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.testcmdstep[2].speedunit = cbospeedunit3.SelectedIndex;
        }

        private void cbospeedunit4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.testcmdstep[3].speedunit = cbospeedunit4.SelectedIndex;
        }

        private void cbovalueunit2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.testcmdstep[1].destunit = cbovalueunit2.SelectedIndex;
        }

        private void cbovalueunit1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.testcmdstep[0].destunit = cbovalueunit1.SelectedIndex;
        }

        private void cbovalueunit3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.testcmdstep[2].destunit = cbovalueunit3.SelectedIndex;
        }

        private void cbovalueunit4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.testcmdstep[3].destunit = cbovalueunit4.SelectedIndex;
        }

        private void numgauge_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            CComLibrary.GlobeVal.filesave.Extensometer_gauge = numgauge.Value;
        }

        private void numgauge1_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            CComLibrary.GlobeVal.filesave.Extensometer1_gauge = numgauge1.Value;
        }

        private void chkfrozen_CheckedChanged(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.Extensometer_DataFrozen = chkfrozen.Checked;
        }

        private void cboextact_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.Extensometer_Action = cboextact.SelectedIndex;
        }

        private void numext_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            CComLibrary.GlobeVal.filesave.Extensometer_DataValue  = numext.Value; 
        }

        private void cboextunit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.Extensometer_DataValueUnit = cboextunit.SelectedIndex; 
        }

        private void cboextchannel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.Extensometer_DataChannel = cboextchannel.SelectedIndex;
        }

        private void cboextruler_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.Extensometer_removal = cboextruler.SelectedIndex; 
        }

        private void chkremoveext_CheckedChanged(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.chkextremove = chkremoveext.Checked;
        }

        private void chkSample_CheckedChanged(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.Samplecheck = chkSample.Checked;
        }

        private void numsampletime_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            CComLibrary.GlobeVal.filesave.SampleChecktime = numsampletime.Value;
        }

        private void cbosamplemode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.Samplingmode = cbosamplemode.SelectedIndex;

            if (CComLibrary.GlobeVal.filesave.Samplingmode  ==0)
            {
                label98.Visible = false;
                label97.Visible = false;
                numsaveinterval.Visible = false;
                numsavepointcount.Visible = false;
                label48.Visible = true;
                numericEdit1.Visible = true;
            }
            else
            {
                label98.Visible = true;
                label97.Visible = true;
                numsaveinterval.Visible = true;
                numsavepointcount.Visible = true;
                label48.Visible = false ;
                numericEdit1.Visible = false ;
            }
        }

        private void numsaveinterval_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            CComLibrary.GlobeVal.filesave.SamplingInterval = Convert.ToInt32(numsaveinterval.Value);
        }

        private void numsavepointcount_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            CComLibrary.GlobeVal.filesave.SamplingCount = Convert.ToInt32(numsavepointcount.Value);
        }
    }
}
