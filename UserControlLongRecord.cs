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
    public partial class UserControlLongRecord : UserControl
    {

        public void Init()
        {
           
            this.dataGridView1.Columns.Clear();
            DataGridViewTextBoxColumn column1;

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mlongdata.Count; i++)
            {
                column1 = new DataGridViewTextBoxColumn();
                column1.HeaderText = CComLibrary.GlobeVal.filesave.mlongdata[i].cName+"["+CComLibrary.GlobeVal.filesave.mlongdata[i].cUnits[0]+"]";
                column1.DataPropertyName = "column"+i.ToString().Trim();
                this.dataGridView1.Columns.Add(column1);
            }

           
           // this.dataGridView1.Rows.Add("黑色头发", "1行2列", "1行3列");

            return;
        }
        public UserControlLongRecord()
        {
            InitializeComponent();
        }
    }
}
