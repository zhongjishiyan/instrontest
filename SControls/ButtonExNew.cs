using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing; 

namespace TabHeaderDemo
{
    public partial class ButtonExNew : Button 
    {
        public ButtonExNew()
        {
            InitializeComponent();
            base.BackColor = Color.Transparent;
        }

        public ButtonExNew(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            if (this.Enabled == true)
            {
                this.ForeColor = Color.White ;
            }
            else
            {
                this.ForeColor = Color.Black;
            }
        }
        
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if( (this.TextAlign== ContentAlignment.BottomCenter) ||(this.TextAlign ==ContentAlignment.MiddleCenter)
                ||(this.TextAlign ==ContentAlignment.TopCenter))
            {
            if ((e.X >= this.Width / 2 - 36 / 2) && (e.X <= this.Width / 2 + 36 / 2))
            {


            }
            else
            {
                return;
            }

            if ((e.Y >= this.Height / 2 - 36 / 2) && (e.Y <= this.Height / 2 + 36 / 2))
            {
            }
            else
            {
                return;
            }
            }


            base.OnMouseDown(e);
            this.ForeColor = Color.Yellow;
        }

        protected override void OnMouseUp(MouseEventArgs e)
         {
            
             base.OnMouseUp(e);
             if (this.Enabled == true)
             {
                 this.ForeColor = Color.White;
             }
             else
             {
                 this.ForeColor = Color.DarkBlue;
             }
         }

        protected override void OnMouseMove(MouseEventArgs mevent)
        {
            base.OnMouseMove(mevent);
            this.ForeColor  = Color.Yellow;
            
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.ForeColor = Color.White;
        }

    }
}
