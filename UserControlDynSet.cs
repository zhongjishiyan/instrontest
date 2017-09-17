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
    public partial class UserControlDynSet : UserControl
    {
        public UserControlDynSet()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲

            TableLayoutPanel p;

            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i] is TableLayoutPanel)
                {
                    p = this.Controls[i] as TableLayoutPanel;
                    p.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(p, true, null);

                }
            }
        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tlbetest_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tlbetest.Controls.Count; i++)
            {
                if (tlbetest.Controls[i] is UserControlMeter)
                {
                    (tlbetest.Controls[i] as UserControlMeter).SuspendLayout();
                }


            }
           
        }

        private void tlbetest_MouseUp(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tlbetest.Controls.Count; i++)
            {
                if (tlbetest.Controls[i] is UserControlMeter)
                {
                    (tlbetest.Controls[i] as UserControlMeter).ResumeLayout();
                }


            }
        }

        private void tlbetest_MouseMove(object sender, MouseEventArgs e)
        {
            
        }
    }
}
