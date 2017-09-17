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
    public partial class UserControl系统信息 : UserControl
    {
        public UserControlMethod musercontrolmethod;
        public  void Init(int sel)
        {
            int i = 0;

            tabControl1.SelectedIndex = sel;

            grid1.RowsCount = 0;
            grid1.AutoStretchColumnsToFitWidth = true;

            grid1.BorderStyle = BorderStyle.FixedSingle;

            grid1.ColumnsCount = 2;
            grid1.Columns[0].Width = grid1.Width / 2;
            grid1.Columns[1].Width = grid1.Width - grid1.Columns[0].Width - 1;

            grid1.Columns[1].AutoSizeMode = SourceGrid2.AutoSizeMode.EnableStretch;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1[0, 0] = new SourceGrid2.Cells.Real.ColumnHeader("系统属性");
            grid1[0, 1] = new SourceGrid2.Cells.Real.ColumnHeader("值");


            i = 1;
            grid1.Rows.Insert(i);
            grid1[i, 0] = new SourceGrid2.Cells.Real.Cell(
                    "软件设置", typeof(string));

            grid1[i, 1] = new SourceGrid2.Cells.Real.Cell(
                    GlobeVal.mysys.softwareconfig, typeof(string));

            i = 2;
            grid1.Rows.Insert(i);
            grid1[i, 0] = new SourceGrid2.Cells.Real.Cell(
                    "软件安装日期", typeof(string));

            grid1[i, 1] = new SourceGrid2.Cells.Real.Cell(
                    GlobeVal.mysys.softwareinstalldate, typeof(string));

            i = 3;
            grid1.Rows.Insert(i);
            grid1[i, 0] = new SourceGrid2.Cells.Real.Cell(
                    "软件版本", typeof(string));

            

            grid1[i, 1] = new SourceGrid2.Cells.Real.Cell(
                    Application.ProductVersion.ToString(), typeof(string));

            i = 4;
            grid1.Rows.Insert(i);
            grid1[i, 0] = new SourceGrid2.Cells.Real.Cell(
                    "系统版本", typeof(string));

            grid1[i, 1] = new SourceGrid2.Cells.Real.Cell(
                    GlobeVal.mysys.SystemID, typeof(string));


              grid1[i, 1] = new SourceGrid2.Cells.Real.Cell(
                    System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(), typeof(string));
             


        /*    i = 5;
            grid1.Rows.Insert(i);
            grid1[i, 0] = new SourceGrid2.Cells.Real.Cell(
                    "秘钥", typeof(string));

            grid1[i, 1] = new SourceGrid2.Cells.Real.Cell(
                    GlobeVal.mysys.KeyCode, typeof(string));

            i = 6;
            grid1.Rows.Insert(i);
            grid1[i, 0] = new SourceGrid2.Cells.Real.Cell(
                    "主机型号", typeof(string));

            grid1[i, 1] = new SourceGrid2.Cells.Real.Cell(
                    GlobeVal.mysys.framemodel.ToString(), typeof(string));


            i = 7;
            grid1.Rows.Insert(i);
            grid1[i, 0] = new SourceGrid2.Cells.Real.Cell(
                    "主机序列号", typeof(string));

            grid1[i, 1] = new SourceGrid2.Cells.Real.Cell(
                    GlobeVal.mysys.frameserialnumber.ToString(), typeof(string));


            i = 8;
            grid1.Rows.Insert(i);
            grid1[i, 0] = new SourceGrid2.Cells.Real.Cell(
                    "网卡地址", typeof(string));

            grid1[i, 1] = new SourceGrid2.Cells.Real.Cell(
                    GlobeVal.mysys.macaddress.ToString(), typeof(string));*/


        }
        public  UserControl系统信息()
        {
            InitializeComponent();
            tabControl1.ItemSize = new Size(1, 1);
        }
    }
}
