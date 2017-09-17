using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppleLabApplication
{
    class AppleLab
    {
        
        MainForm f1;
        public AppleLab()
        {
            f1 = new MainForm();
            
        }

        public void show()
        {
            CComLibrary.GlobeVal.m_listline.Clear();

            f1.scatterGraph1.Annotations.Clear();
            f1.Show();
        }
        
    }
}
