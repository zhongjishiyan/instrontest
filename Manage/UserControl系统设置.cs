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
    public partial class UserControl系统设置 : UserControl
    {
        public UserControlMethod musercontrolmethod;

        string[] ms;
        string[] ms1;
        public  void Init(int sel)
        {

            tabControl1.SelectedIndex = sel;

            if (GlobeVal.mysys.AppUserLevel == 0)
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
            }
            else
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;  

            }
            cbokind.Items.Clear();

            for (int i = 0; i < GlobeVal.mysys.ControllerCount; i++)
            {
                cbokind.Items.Add(GlobeVal.mysys.ControllerName[i]);
              
            }

#if Demo 
            cbokind.SelectedIndex = 2;
            cbokind.Enabled = false;
#else
            cbokind.Enabled = true;
            cbokind.SelectedIndex = GlobeVal.mysys.controllerkind;
#endif
            cbomachine.Items.Clear();
            for (int i = 0; i < GlobeVal.mysys.MachineCount; i++)
            {
                cbomachine.Items.Add(GlobeVal.mysys.MachineName[i]);

            }
#if Demo
            cbomachine.SelectedIndex = 0;
            cbomachine.Enabled = false;
#else
             cbomachine.Enabled = true;
            cbomachine.SelectedIndex = GlobeVal.mysys.machinekind;
#endif

        }
        public  UserControl系统设置()
        {
            InitializeComponent();
            tabControl1.ItemSize = new Size(1, 1);

             ms = new string[20];

            if (GlobeVal.mysys.language == 0)
            {
                ms[0] = "内部";
                for (int i = 1; i <= 16; i++)
                {
                    ms[i] = "外部通道" + (i).ToString().Trim();
                }


                ms1 = new string[2];
                ms1[0] = "通道1";
                ms1[1] = "通道2";
            }
            else
            {
                ms[0] = "Inside";
                for (int i = 1; i <= 16; i++)
                {
                    ms[i] = "External channel" + (i).ToString().Trim();
                }


                ms1 = new string[2];
                ms1[0] = "Station 1";
                ms1[1] = "Station 2";
            }



            grid1.RowsCount = 0;
            grid1.AutoStretchColumnsToFitWidth = true;

            grid1.BorderStyle = BorderStyle.FixedSingle;

            

            grid1.ColumnsCount = 8;
            grid1.Columns[0].Width = grid1.Width / 8;
           
            grid1.Columns[1].Width = grid1.Width/8 ;
            grid1.Columns[2].Width = grid1.Width / 8;
            grid1.Columns[3].Width = grid1.Width / 8;
            grid1.Columns[4].Width = grid1.Width / 8;
            grid1.Columns[5].Width = grid1.Width / 8;
            grid1.Columns[6].Width = grid1.Width / 8;

            grid1.Columns[7].Width = grid1.Width - grid1.Columns[0].Width - 1;

            grid1.Columns[7].AutoSizeMode = SourceGrid2.AutoSizeMode.EnableStretch;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);

            string _temp = "";
            if(GlobeVal.mysys.language ==0)
            {
                _temp = "[硬件通道名称]";
            }
            else
            {
                _temp = "[hardware channel name]";
            }

            SourceGrid2.Cells.Real.ColumnHeader head = new SourceGrid2.Cells.Real.ColumnHeader(_temp);
            head.EnableSort = false;
            head.EnableEdit = false;
           
            grid1[0, 0] = head;

            if(GlobeVal.mysys.language ==0)
            {
                _temp = "[硬件通道量纲]";
            }
            else
            {
                _temp = "[hardware channel dimension]";
            }
             head = new SourceGrid2.Cells.Real.ColumnHeader(_temp);
            head.EnableSort = false;
            head.EnableEdit = false;
            grid1[0, 1] = head;

            if (GlobeVal.mysys.language == 0)
            {
                _temp = "[硬件通道单位]";
            }
            else
            {
                _temp = "[Hardware channel unit]";
            }


            head = new SourceGrid2.Cells.Real.ColumnHeader(_temp);
            head.EnableSort = false;
            head.EnableEdit = false;
            grid1[0, 2] = head;

            if (GlobeVal.mysys.language == 0)
            {
                _temp = "[硬件通道内部名称]";
            }
            else
            {
                _temp = "[Hardware channel internal name]";
            }
            head = new SourceGrid2.Cells.Real.ColumnHeader(_temp);
            head.EnableSort = false;
            head.EnableEdit = false;
            grid1[0, 3] = head;

            if (GlobeVal.mysys.language == 0)
            {
                _temp = "[硬件通道量程]";
            }
            else
            {
                _temp = "[Hardware channel range]";
            }

            head = new SourceGrid2.Cells.Real.ColumnHeader(_temp);
            head.EnableSort = false;
            grid1[0, 4] = head;

            if (GlobeVal.mysys.language == 0)
            {
                _temp = "[硬件通道闭环控制]";
            }
            else
            {
                _temp = "[Hardware channel closed loop control]";
            }

            head = new SourceGrid2.Cells.Real.ColumnHeader(_temp);
            head.EnableSort = false;
            grid1[0, 5] = head;


            if (GlobeVal.mysys.language == 0)
            {
                _temp = "[硬件通道采集方式]";
            }
            else
            {
                _temp = "[Hardware channel acquisition mode]";
            }

            
            head = new SourceGrid2.Cells.Real.ColumnHeader(_temp);
            head.EnableSort = false;
            grid1[0, 6] = head;

            if (GlobeVal.mysys.language == 0)
            {
                _temp = "[硬件控制通道]";
            }
            else
            {
                _temp = "[Hardware control channel]";
            }

            head = new SourceGrid2.Cells.Real.ColumnHeader(_temp);
            head.EnableSort = false;
            grid1[0, 7] = head;

            //判断如果没有控制通道，则设置一个控制通道，防止系统出错
            bool mb = false;
            for (int i = 1; i <= ClsStaticStation.m_Global.mycls.chsignals.Count; i++)
            {

                if (GlobeVal.mysys.ChannelControl[i - 1]==true)
                {
                    mb = true;
                }
            }

            if (mb ==false )
            {
                GlobeVal.mysys.ChannelControl[0] = true;

            }





                for (int i = 1; i <= ClsStaticStation.m_Global.mycls.chsignals.Count; i++)
            {
                grid1.Rows.Insert(i);
                grid1[i, 0] = new SourceGrid2.Cells.Real.Cell(
                    ClsStaticStation.m_Global.mycls.chsignals[i - 1].cName, typeof(string));
                

                grid1[i, 1] = new SourceGrid2.Cells.Real.ComboBox(

               ClsStaticStation.m_Global.mycls.SignalsNames[ClsStaticStation.m_Global.mycls.chsignals[i - 1].cUnitKind], typeof(string),
              ClsStaticStation.m_Global.mycls.SignalsNames, false);

                grid1[i, 2] = new SourceGrid2.Cells.Real.ComboBox(
                  ClsStaticStation.m_Global.mycls.chsignals[i - 1].cUnits[
                  ClsStaticStation.m_Global.mycls.chsignals[i - 1].cUnitsel], typeof(string),
                  ClsStaticStation.m_Global.mycls.chsignals[i - 1].cUnits, false);

                grid1[i, 3] = new SourceGrid2.Cells.Real.Cell(
                 ClsStaticStation.m_Global.mycls.chsignals[i - 1].SignName, typeof(string));


                grid1[i, 4] = new SourceGrid2.Cells.Real.Cell(
                   GlobeVal.mysys.ChannelRange[i-1], typeof(double));

              
           

                grid1[i, 5] = new SourceGrid2.Cells.Real.Cell(
                 GlobeVal.mysys.ChannelControl[i - 1], typeof(bool));



                grid1[i,6] = new SourceGrid2.Cells.Real.ComboBox(

               ms[GlobeVal.mysys.ChannelSamplemode[i-1]], typeof(string),
              ms, false);


                grid1[i, 7] = new SourceGrid2.Cells.Real.ComboBox(

              ms1[GlobeVal.mysys.ChannelControlChannel[i - 1]], typeof(string),
             ms1, false);




            }
        }

        private void cbokind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GlobeVal.mysys.controllerkind = cbokind.SelectedIndex;
            GlobeVal.MainStatusStrip.Items["tslbldevice"].Text = GlobeVal.mysys.ControllerName[GlobeVal.mysys.controllerkind];

            GlobeVal.mysys.SerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\sys\\setup.ini");
        }

        private void cbomachine_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GlobeVal.mysys.machinekind = cbomachine.SelectedIndex;
            GlobeVal.MainStatusStrip.Items["tslblmachine"].Text = GlobeVal.mysys.ControllerName[GlobeVal.mysys.machinekind];

            GlobeVal.mysys.SerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\sys\\setup.ini");
        }

        private void cbomachine_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void grid1_CellLostFocus(object sender, SourceGrid2.PositionCancelEventArgs e)
        {
            int k = 0;
            if (e.Position.Column == 4)
            {
                GlobeVal.mysys.ChannelRange[e.Position.Row - 1] = Convert.ToDouble(e.Cell.GetValue(new SourceGrid2.Position(e.Position.Row, e.Position.Column)));
            }

            if (e.Position.Column == 5)
            {
                GlobeVal.mysys.ChannelControl[e.Position.Row - 1] = Convert.ToBoolean(e.Cell.GetValue(new SourceGrid2.Position(e.Position.Row, e.Position.Column)));
            }

            if (e.Position.Column == 6)
            {
                for (int i = 0; i < 17; i++)
                {
                    if (Convert.ToString(e.Cell.GetValue(new SourceGrid2.Position(e.Position.Row, e.Position.Column))) == ms[i])
                     {
                        k = i;
                    }


                    GlobeVal.mysys.ChannelSamplemode[e.Position.Row - 1] = k;

                  
                }
            }
            if (e.Position.Column == 7)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (Convert.ToString(e.Cell.GetValue(new SourceGrid2.Position(e.Position.Row, e.Position.Column))) == ms1[i])
                    {
                        k = i;
                    }


                    GlobeVal.mysys.ChannelControlChannel[e.Position.Row - 1] = k;


                }
            }

        }

        private void grid1_CellGotFocus(object sender, SourceGrid2.PositionCancelEventArgs e)
        {
            if (e.Position.Column ==0)
            {
                e.Cancel = true;
            }
            if (e.Position.Column == 1)
            {
                e.Cancel = true;
            }
            if (e.Position.Column == 2)
            {
                e.Cancel = true;
            }

            if (e.Position.Column == 3)
            {
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GlobeVal.mysys.SerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\sys\\setup.ini");
            Application.Exit();
        }
    }
}
