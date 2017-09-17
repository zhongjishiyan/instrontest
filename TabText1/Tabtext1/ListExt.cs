using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppleLabApplication
{
    public partial class ListExt : ListBox 
    {
        public List<ClsStaticStation.shapeitem> mlist; 
        public ListExt()
        {
            InitializeComponent();
            
        }

        public ListExt(IContainer container)
        {
            container.Add(this);
            mlist = new List<ClsStaticStation.shapeitem>();
            InitializeComponent();
        }
    }
}
