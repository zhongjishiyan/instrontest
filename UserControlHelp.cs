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
    public partial class UserControlHelp : UserControl
    {
        public MeasureItemEventArgs em=null;
        public UserControlHelp()
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


        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            int t;
            Color fcolor;

            if (e.Index < 0)
            {
                return;
            }

            if (listBox1.SelectedIndex == e.Index)
            {
                fcolor = Color.Red;
            }
            else
            {
                fcolor = Color.Black; 
            }
            
            Pen p = new Pen(Color.Gray,2);
          
            e.Graphics.DrawLine(p, e.Bounds.Left

             + this.imageList1.ImageSize.Width,
             e.Bounds.Bottom,
             e.Bounds.Right - this.imageList1.ImageSize.Width,
             e.Bounds.Bottom);
            p.Dispose();
            
            e.Graphics.DrawImage(this.imageList1.Images[0], e.Bounds.Left  , e.Bounds.Top );  

             StringFormat sf = new StringFormat(StringFormatFlags.NoWrap);
         
             SizeF sizef = e.Graphics.MeasureString(listBox1.Items[e.Index].ToString(), listBox1.Font , Int32.MaxValue, sf);

             t = Convert.ToInt16(Math.Ceiling(sizef.Width / (listBox1.Width  - this.imageList1.ImageSize.Width*2)));
        

       
            

             RectangleF rf = new RectangleF(e.Bounds.X + imageList1.ImageSize.Width, e.Bounds.Y + 2, listBox1.Width - this.imageList1.ImageSize.Width*2, e.Font.Height * t);

             

            e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, new SolidBrush(fcolor), rf);
            sf.Dispose();
            
        }

        private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
           
            int t;

            
            em = e;
            StringFormat sf = new StringFormat(StringFormatFlags.NoWrap);
            

            SizeF sizef = e.Graphics.MeasureString(listBox1.Items[e.Index].ToString(), listBox1.Font , Int32.MaxValue, sf);

            t = Convert.ToInt16( Math.Ceiling(sizef.Width / (listBox1.Width - this.imageList1.ImageSize.Width * 2)));

      
            if (t == 0)
            {
                t = 1;
            }
            e.ItemHeight = t * listBox1.Font.Height+5;

           
            sf.Dispose();
        }

        private void btnmain_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SizeChanged(object sender, EventArgs e)
        {

           
            
            
        }

        private void listBox1_Resize(object sender, EventArgs e)
        {

        }

        private void UserControlHelp_SizeChanged(object sender, EventArgs e)
        {
            listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Refresh(); 
        }
    }
}
