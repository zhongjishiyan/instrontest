using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TabHeaderDemo.Frm
{
    public partial class FormLink : Form
    {
        public FormLink()
        {
            InitializeComponent();
        }

        private void FormLink_Load(object sender, EventArgs e)
        {
            progress_CPI.IndicatorType = CircularIndeterminateProgress.CircularIndeterminateProgress.INDICATORTYPES.ANIMATED;
            progress_CPI.Animate = true
             ;
        }

        private void FormLink_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Close();
        }
    }
}
