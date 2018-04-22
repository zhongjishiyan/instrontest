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
    public partial class UserControlStatus : UserControl
    {

        public void Init()
        {

            timer1.Enabled = true;

            return;
        }
        public UserControlStatus()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (GlobeVal.myarm.getrunstate() == 1)
            {
                lblstate.Text = "运行";
            }
            else
            {
                lblstate.Text = "停止";
            }

            if (CComLibrary.GlobeVal.filesave != null)
            {

                if (CComLibrary.GlobeVal.filesave.mseglist.Count > 0)
                {
                    if (GlobeVal.myarm.mcurseg < CComLibrary.GlobeVal.filesave.mseglist.Count)
                    {
                        lblstep.Text = CComLibrary.GlobeVal.filesave.mseglist[GlobeVal.myarm.mcurseg].mseq.stepname;
                    }
                }
            }
        }
    }
}
