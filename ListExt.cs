using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TabHeaderDemo
{
    public partial class ListExt : ListBox 
    {
        public List<CComLibrary.outputitem> mlist=new List<CComLibrary.outputitem>(); 
        public ListExt()
        {
           
            InitializeComponent();
            
            
        }

        public ListExt(IContainer container)
        {
            container.Add(this);
            
            InitializeComponent();
        }
    }
}
