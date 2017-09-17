using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppleLabApplication.Extensions
{
    public partial class UListEditor : UserControl
    {

        public delegate void AddEventHandler(object sender, int index);
        public event AddEventHandler addevent;

        public delegate void RemoveEventHandler(object sender, int index);
        public event RemoveEventHandler removeevent;

        public delegate void CboEventHandler(object sender, int index);
        public event CboEventHandler cboevent;

        public UListEditor()
        {
            InitializeComponent();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (addevent != null)
            {
                addevent(sender, 0);
            }
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            if (removeevent != null)
            {
                removeevent(sender, 0);
            }
        }

        private void btUp_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (e.RowIndex >= 0)
                {
                    int a = (dataGridView1[e.ColumnIndex, e.RowIndex] as DataGridViewComboBoxCell).Items.IndexOf(dataGridView1[e.ColumnIndex, e.RowIndex].Value);
                    if (cboevent != null)
                    {
                        cboevent(sender, a);
                    }
                }


            }
        }
    }
}
