using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
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
#if  Demo
            grid1[i, 1] = new SourceGrid2.Cells.Real.Cell(
                    "演示版", typeof(string));
            labelVersion1.Text = "版本 演示版";
#else
            grid1[i, 1] = new SourceGrid2.Cells.Real.Cell(
                   "完整版", typeof(string));
             labelVersion1.Text = "版本 完整版";
#endif
            i = 2;
            grid1.Rows.Insert(i);
            grid1[i, 0] = new SourceGrid2.Cells.Real.Cell(
                    "软件到期日期", typeof(string));

            grid1[i, 1] = new SourceGrid2.Cells.Real.Cell(
                    "3000.1.1", typeof(string));

            i = 3;
            grid1.Rows.Insert(i);
            grid1[i, 0] = new SourceGrid2.Cells.Real.Cell(
                    "软件编译日期", typeof(string));

            string ss = "";

            DateTime dt = new DateTime(2018, 2, 18).

                   AddDays(Assembly.GetExecutingAssembly().GetName().Version.Build).AddSeconds(Assembly.GetExecutingAssembly().GetName().Version.Revision * 2f);

            ss = Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString() + "(Build " +
                dt.ToString("yyyy-MM-dd HH:mm:ss") + ")";


            grid1[i, 1] = new SourceGrid2.Cells.Real.Cell(
                    ss, typeof(string));

            i = 4;
            grid1.Rows.Insert(i);
            grid1[i, 0] = new SourceGrid2.Cells.Real.Cell(
                    "软件版本", typeof(string));

            

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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel1.Links[0].LinkData = linkLabel1.Text;
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }
    }
}
