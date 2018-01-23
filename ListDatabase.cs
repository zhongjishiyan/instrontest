using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace TabHeaderDemo
{
    public partial class ListDatabase : ListBox
    {
        public List<CComLibrary.DatabaseItem > mlist;
        private string v;
        private CComLibrary.DatabaseItem a;

        public ListDatabase()
        {
            InitializeComponent();
        }

        public ListDatabase(IContainer container)
        {
            container.Add(this);
            mlist = new List<CComLibrary.DatabaseItem>();
            InitializeComponent();
        }

        public void ClearItem()
        {
            this.Items.Clear();
            mlist.Clear();

        }

        public void AddItem(CComLibrary.DatabaseItem  v)
        {
            CComLibrary.DatabaseItem m = v.Clone() as CComLibrary.DatabaseItem;
            this.Items.Add(v.Name);
            this.mlist.Add(m);
        }

        public void RemoveItem(int index)
        {
            this.Items.RemoveAt(index);
            this.mlist.RemoveAt(index);
        }

        public void UpItem(int index)
        {
            if (index == 0)
            {
            }
            else
            {
                v = this.Items[index] as string;
                a = this.mlist[index];
                this.Items.RemoveAt(index);
                this.mlist.RemoveAt(index);
                this.Items.Insert(index - 1, v);
                this.mlist.Insert(index - 1, a);
            }

        }

        public void DownItem(int index)
        {
            if (index == this.Items.Count - 1)
            {
            }
            else
            {
                v = this.Items[index] as string;
                a = this.mlist[index];
                this.Items.RemoveAt(index);
                this.mlist.RemoveAt(index);
                this.Items.Insert(index + 1, v);
                this.mlist.Insert(index + 1, a);

            }

        }
    }
}
