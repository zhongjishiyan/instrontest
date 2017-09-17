using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClsStaticStation;
namespace TabHeaderDemo
{
    public partial class ListExtObject : ListBox 
    {
        public List<ClsStaticStation.ItemSignal> list= new List<ClsStaticStation.ItemSignal>();
        private string v;
        private ItemSignal a;

        public ListExtObject()
        {
            InitializeComponent();
            
        }

        public ListExtObject(IContainer container)
        {
            container.Add(this);
        
            InitializeComponent();
        }
        public bool MatchItem(List<ItemSignal> l, ItemSignal a)
        {
            bool b = false;
            int i;
            for (i = 0; i < l.Count; i++)
            {
                if (a.cName == l[i].cName)
                {
                    b = true;
                }
            }
            return b;
        }

        public void ClearItem()
        {
            this.Items.Clear();
            list.Clear();

        }

        public void AddItem(ItemSignal v)
        {
            if (v.cName == null)
            {
                v.cName = "";
            }
            this.Items.Add(v.cName );
            this.list.Add(v);
        }

        public void RemoveItem(int index)
        {
            this.Items.RemoveAt(index);
            this.list.RemoveAt(index);
        }

        public void UpItem(int index)
        {
            if (index == 0)
            {
            }
            else
            {
                v = this.Items[index] as string;
                a = this.list[index];
                this.Items.RemoveAt(index);
                this.list.RemoveAt(index);
                this.Items.Insert(index - 1, v);
                this.list.Insert(index - 1, a);
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
                a = this.list[index];
                this.Items.RemoveAt(index);
                this.list.RemoveAt(index);
                this.Items.Insert(index + 1, v);
                this.list.Insert(index + 1, a);

            }

        }
    }
}
