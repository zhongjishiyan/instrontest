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
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GlobeVal.myarm.myedc.Data.SetTime(XLNet.XLDOPE.SETTIME_MODE.IMMEDIATE, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            short tan=0;
            GlobeVal.myarm.myedc.Move.FMove(XLNet.XLDOPE.MOVE.UP, XLNet.XLDOPE.CTRL.OPEN, Convert.ToDouble(textBox1.Text), ref tan);
            textBox2.Text = tan.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            short tan = 0;

            XLNet.XLDOPE.ERR p;
            p= GlobeVal.myarm.myedc.Move.SHalt(ref tan);
           //p = GlobeVal.myarm.myedc.Move.Halt(XLNet.XLDOPE.CTRL.LOAD, ref tan);
            textBox2.Text = tan.ToString();
        }
           

        private void button4_Click(object sender, EventArgs e)
        {
            short tan = 0;
            GlobeVal.myarm.myedc.Move.FMove(XLNet.XLDOPE.MOVE.DOWN, XLNet.XLDOPE.CTRL.OPEN, Convert.ToDouble(textBox1.Text), ref tan);
            textBox2.Text = tan.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            short tan = 0;
            GlobeVal.myarm.myedc.Move.Pos(XLNet.XLDOPE.CTRL.OPEN, Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text), ref tan);

        }
    }
}
