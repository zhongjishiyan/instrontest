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

        private bool mloaded = false;

        private int curcol=0;
        private int currow=0;

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

        public void Add(int i,ref CComLibrary.SegFile sf)
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
                        f.groupBox2.Visible = false;
                    }
                    else
                    {
                        f.radioButton1.Text = "力速度";
                        f.lblUnit.Text = "kN/s";
                        f.radioButton2.Visible = true;
                        f.panel1.Visible = true;
                        f.groupBox2.Visible = true;
                    }
                    f.numstart.Value = sf.mseglist[e.Position.Row - 1].mstartload;
                     f.numend.Value=sf.mseglist[e.Position.Row - 1].mendload;
                     f.numstrainspeed.Value=sf.mseglist[e.Position.Row - 1].mstrainspeed;
                     f.numstarinstart.Value=sf.mseglist[e.Position.Row - 1].mstartstrain;
                     f.numstarinend.Value=sf.mseglist[e.Position.Row - 1].mendstrain;

                    f.numericEdit1.Value = sf.mseglist[e.Position.Row - 1].speed;
                    f.Text = "控制参数步骤" + e.Position.Row.ToString().Trim();
                    f.ShowDialog();
                    if (f.result == true)
                    {
                        sf.mseglist[e.Position.Row - 1].speed = f.numericEdit1.Value;
                        

                        grid2[e.Position.Row, e.Position.Column].Value = sf.mseglist[e.Position.Row - 1].speedconvert();

                        sf.mseglist[e.Position.Row - 1].mstartload = f.numstart.Value;
                        sf.mseglist[e.Position.Row - 1].mendload = f.numend.Value;
                        sf.mseglist[e.Position.Row - 1].mstrainspeed = f.numstrainspeed.Value;
                        sf.mseglist[e.Position.Row - 1].mstartstrain = f.numstarinstart.Value;
                        sf.mseglist[e.Position.Row - 1].mendstrain = f.numstarinend.Value;
                    }
                }


            }
            if (e.Position.Column == 3)
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
            int c=0;
            for (int i=0;i<sf.cmdstring.Length;i++)
            {
                if (sf.cmdstring[i]==e.Cell.GetValue(e.Position).ToString())
                {
                  c=i;
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
            
            m = new SourceGrid2.PositionEventArgs( new SourceGrid2.Position(e.Position.Row, 2),null);
            this.textclick_DoubleClick(sender, m);

            m= new SourceGrid2.PositionEventArgs( new SourceGrid2.Position(e.Position.Row, 3),null);
            this.textclick_DoubleClick(sender, m);
        }

        void behaviorClick_Click(object sender, SourceGrid2.PositionEventArgs e)
        {
            
        }

        public void Init_简单()
        {

        }



        public void Init_高级()
        {
           

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

            grid2.Columns[1].AutoSizeMode = SourceGrid2.AutoSizeMode.EnableStretch;
            grid2.FixedRows = 1;
            grid2.Rows.Insert(0);
            grid2.Rows[0].Height = 25;
            grid2[0, 0] = new SourceGrid2.Cells.Real.ColumnHeader("步骤");
            grid2[0, 1] = new SourceGrid2.Cells.Real.ColumnHeader("控制模式");
            grid2[0, 2] = new SourceGrid2.Cells.Real.ColumnHeader("控制参数");
            grid2[0, 3] = new SourceGrid2.Cells.Real.ColumnHeader("跳转条件");
            grid2[0, 4] = new SourceGrid2.Cells.Real.ColumnHeader("动作");
            grid2[0, 5] = new SourceGrid2.Cells.Real.ColumnHeader("循环");
            grid2[0, 6] = new SourceGrid2.Cells.Real.ColumnHeader("说明");

            sf = new CComLibrary.SegFile();
            

            for ( i = 1; i <= sf.mseglist.Count; i++)
            {
                Add(i, ref sf);
            }
            tscbo.Items.Clear();
            DirectoryInfo info = new DirectoryInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AppleLabJ\\seg");
            FileInfo[] files = info.GetFiles("*.seg");
            foreach (FileInfo file in files)
            {
                tscbo.Items.Add(file.Name);

                if (CComLibrary.GlobeVal.filesave.SegName ==file.Name)
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

        public void Init_设置控制()
        {
           
                cbocontrolprocess.Items.Clear();
                cbocontrolprocess.Items.Add("一般测试");
                cbocontrolprocess.Items.Add("中级测试");
			    cbocontrolprocess.Items.Add("简单测试");
                cbocontrolprocess.Items.Add("高级测试"); 
                
           


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

                grid1.Columns[grid1.ColumnsCount-1].Width = grid1.Columns[0].Width - 1;

                grid1.Columns[grid1.ColumnsCount - 1].AutoSizeMode = SourceGrid2.AutoSizeMode.EnableStretch;
                grid1.FixedRows = 1;
                grid1.Rows.Insert(0);
                grid1.Rows[0].Height = 25;
                grid1[0, 0] = new SourceGrid2.Cells.Real.ColumnHeader("名称");
                grid1[0, 1] = new SourceGrid2.Cells.Real.ColumnHeader("单位");

                grid1[0, 2] = new SourceGrid2.Cells.Real.ColumnHeader("上限");
                grid1[0, 3] = new SourceGrid2.Cells.Real.ColumnHeader("下限");
                grid1[0, 4] = new SourceGrid2.Cells.Real.ColumnHeader("量程");


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


            cbocontrol1.SelectedIndex = CComLibrary.GlobeVal.filesave.testcmdstep[0].controlmode;
            cbocontrol2.SelectedIndex = CComLibrary.GlobeVal.filesave.testcmdstep[1].controlmode;
            cbocontrol3.SelectedIndex = CComLibrary.GlobeVal.filesave.testcmdstep[2].controlmode;
            cbocontrol4.SelectedIndex = CComLibrary.GlobeVal.filesave.testcmdstep[3].controlmode;

            cbospeedunit1.Items.Clear();
            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals[cbocontrol1.SelectedIndex].speedSignal.cUnitCount; i++)
            {
                cbospeedunit1.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[cbocontrol1.SelectedIndex].speedSignal.cUnits[i]);

            }

            cbospeedunit1.SelectedIndex = 0;

            cbospeedunit2.Items.Clear();
            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals[cbocontrol2.SelectedIndex].speedSignal.cUnitCount; i++)
            {
                cbospeedunit2.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[cbocontrol2.SelectedIndex].speedSignal.cUnits[i]);

            }

            cbospeedunit2.SelectedIndex = 0;

            cbospeedunit3.Items.Clear();
            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals[cbocontrol3.SelectedIndex].speedSignal.cUnitCount; i++)
            {
                cbospeedunit3.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[cbocontrol3.SelectedIndex].speedSignal.cUnits[i]);

            }

            cbospeedunit3.SelectedIndex = 0;


            cbospeedunit4.Items.Clear();
            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals[cbocontrol4.SelectedIndex].speedSignal.cUnitCount; i++)
            {
                cbospeedunit4.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[cbocontrol4.SelectedIndex].speedSignal.cUnits[i]);

            }

            cbospeedunit4.SelectedIndex = 0;

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

            cbodestcontrol1.SelectedIndex = CComLibrary.GlobeVal.filesave.testcmdstep[0].destcontrolmode;
            cbodestcontrol2.SelectedIndex = CComLibrary.GlobeVal.filesave.testcmdstep[1].destcontrolmode;
            cbodestcontrol3.SelectedIndex = CComLibrary.GlobeVal.filesave.testcmdstep[2].destcontrolmode;
            cbodestcontrol4.SelectedIndex = CComLibrary.GlobeVal.filesave.testcmdstep[3].destcontrolmode;

            cbovalueunit1.Items.Clear();

            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals[cbodestcontrol1.SelectedIndex].cUnitCount; i++)
            {

                cbovalueunit1.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[cbodestcontrol1.SelectedIndex].cUnits[i]);
            }

            cbovalueunit1.SelectedIndex = 0;


            cbovalueunit2.Items.Clear();

            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals[cbodestcontrol2.SelectedIndex].cUnitCount; i++)
            {

                cbovalueunit2.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[cbodestcontrol2.SelectedIndex].cUnits[i]);
            }

            cbovalueunit2.SelectedIndex = 0;


            cbovalueunit3.Items.Clear();

            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals[cbodestcontrol3.SelectedIndex].cUnitCount; i++)
            {

                cbovalueunit3.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[cbodestcontrol3.SelectedIndex].cUnits[i]);
            }

            cbovalueunit3.SelectedIndex = 0;

            cbovalueunit4.Items.Clear();

            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals[cbodestcontrol4.SelectedIndex].cUnitCount; i++)
            {

                cbovalueunit4.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[cbodestcontrol4.SelectedIndex].cUnits[i]);
            }

            cbovalueunit4.SelectedIndex = 0;


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

            cbopreload_controlmode.SelectedIndex = CComLibrary.GlobeVal.filesave.pretest_cmd.controlmode;

            cbopreload_speedunit.Items.Clear();
            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals[cbopreload_controlmode.SelectedIndex].speedSignal.cUnitCount; i++)
            {
                cbopreload_speedunit.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[cbopreload_controlmode.SelectedIndex].speedSignal.cUnits[i]);

            }

            cbopreload_speedunit.SelectedIndex = 0;

            cbopreload_channel.Items.Clear();

            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals.Count; i++)
            {
                cbopreload_channel.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[i].cName);
            }

            cbopreload_channel.SelectedIndex = CComLibrary.GlobeVal.filesave.pretest_cmd.destcontrolmode ;


            cboprelaod_valueunit.Items.Clear();

            for (int i = 0; i < ClsStaticStation.m_Global.mycls.hardsignals[cbopreload_channel.SelectedIndex].cUnitCount; i++)
            {

                cboprelaod_valueunit.Items.Add(ClsStaticStation.m_Global.mycls.hardsignals[cbopreload_channel.SelectedIndex].cUnits[i]);
            }

            cboprelaod_valueunit.SelectedIndex = 0;

            editpreload_speed.Value = CComLibrary.GlobeVal.filesave.pretest_cmd.speed;

            editpreload_value.Value=CComLibrary.GlobeVal.filesave.pretest_cmd.dest;


            lstavail.ClearItem();
            for (int j = 0; j < ClsStaticStation.m_Global.mycls.chsignals.Count; j++)
            {

                if (CComLibrary.GlobeVal.filesave.mautozero== null)
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
        public  void Init(int sel)
        {
            
            
                tabControl1.SelectedIndex = sel;
                tlpline1.RowStyles[1].Height = 2;

                if (GlobeVal.mysys.AppUserLevel == 0)
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
        public  UserControl控制()
        {
            InitializeComponent();
            tabControl1.ItemSize = new Size(1, 1);
            tabControl3.ItemSize = new System.Drawing.Size(1, 1); 
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

        private void tableLayoutPanel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void cbocontrolprocess_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.mcontrolprocess = cbocontrolprocess.SelectedIndex;

        }

        private void lstavail_SelectedIndexChanged(object sender, EventArgs e)
        {
           
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

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void cbotestendCriteria1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbotestendCriteria1_SelectionChangeCommitted(object sender, EventArgs e)
        {
           CComLibrary.GlobeVal.filesave.endoftest1criteria= cbotestendCriteria1.SelectedIndex;


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
            CComLibrary.GlobeVal.filesave.endoftest2criteria=cbotestendCriteria2.SelectedIndex;

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

       
        private void num1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void num2_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            
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
                        CComLibrary.GlobeVal.filesave.mchsignals[i-1].uplimit = Convert.ToDouble(e.Cell.GetDisplayText(new SourceGrid2.Position(e.Position.Row, e.Position.Column)));
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
            CComLibrary.GlobeVal.filesave.testcmdstep[0].controlmode=cbocontrol1.SelectedIndex ;

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
           CComLibrary.GlobeVal.filesave.testcmdstep[0].destcontrolmode= cbodestcontrol1.SelectedIndex;

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

                sf.SerializeNow(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AppleLabJ\\seg\\" + s + ".seg");

                tscbo.Items.Clear();
                tscbo.Text = s + ".seg";
                DirectoryInfo info = new DirectoryInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AppleLabJ\\seg");
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
            
            if (System.IO.File.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AppleLabJ\\seg\\" + tscbo.Text) == true)
            {
                System.IO.File.Delete(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AppleLabJ\\seg\\" + tscbo.Text);
            }
           
            sf.SerializeNow(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AppleLabJ\\seg\\" + tscbo.Text);

           
        }

        private void tsbtnkill_Click(object sender, EventArgs e)
        {
           

            if (System.IO.File.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AppleLabJ\\seg\\" + tscbo.Text) == true)
            {
                 DialogResult b=MessageBox.Show("是否删除文件["+tscbo.Text+"]?","提示",MessageBoxButtons.YesNo);

                 if (b == DialogResult.Yes)
                 {

                     System.IO.File.Delete(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AppleLabJ\\seg\\" + tscbo.Text);
                 }
                 else
                 {
                     return;
                 }
            }
            grid2.RowsCount = 1;

            sf.clear(); 

            DirectoryInfo info = new DirectoryInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AppleLabJ\\seg");
            FileInfo[] files = info.GetFiles("*.seg");
            foreach (FileInfo file in files)
            {
                tscbo.Items.Add(file.Name);
            }


        }

        private void tscbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mloaded == false )
            {
                sf.mseglist.Clear();
                sf = sf.DeSerializeNow(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AppleLabJ\\seg\\" + tscbo.Text);

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

        private void tscbo_DropDownClosed(object sender, EventArgs e)
        {
            
        }

        private void grid2_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void grid2_Click(object sender, EventArgs e)
        {
            
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
                if (System.IO.File.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AppleLabJ\\seg\\" + tscbo.Text) == true)
                {
                    s1 = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AppleLabJ\\seg\\" + tscbo.Text;
                    System.IO.File.Move(s1,
                        System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AppleLabJ\\seg\\" + s + ".seg");

                }
                tscbo.Items.Clear();
                DirectoryInfo info = new DirectoryInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AppleLabJ\\seg");
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
            DialogResult a = MessageBox.Show("是否插入？","提示",MessageBoxButtons.YesNo);
            if (a == DialogResult.Yes)
            {
                CComLibrary.SegTest m = new CComLibrary.SegTest();
                sf.mseglist.Insert(currow - 1, m);
                Add(currow-1, ref sf);
                
            }




        }

        private void tsbtndel_Click(object sender, EventArgs e)
        {
            int w=0;
            DialogResult a = MessageBox.Show("是否删除？", "提示", MessageBoxButtons.YesNo);
            if (a == DialogResult.Yes)
            {
                w=currow-1;
                sf.mseglist.RemoveAt(w);
                grid2.Rows.Remove(w+1); 
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            userControlStep1.Kind = 0;
            userControlStep1.selected = false;


            userControlStep2.Kind = 1;
            userControlStep2.selected = false;

            userControlStep3.Kind = 2;
            userControlStep3.selected = true;

            tlpedit.Refresh();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
