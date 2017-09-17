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
    public partial class ButtonEx : Button 
    {
        protected System.Drawing.Image m_NormalEnterImage;
        [System.ComponentModel.DefaultValue(null)]
        public System.Drawing.Image NormalEnterImage
        {
            get
            {
                return m_NormalEnterImage;
            }
            set
            {
                m_NormalEnterImage = value;
            }
        }
        protected System.Drawing.Image m_NormalDisabledImage;
        [System.ComponentModel.DefaultValue(null)]
        public System.Drawing.Image NormalDisabledImage
        {
            get
            {
                return m_NormalDisabledImage;
            }
            set
            {
                m_NormalDisabledImage = value;
            }
        }

        public bool Enabled
        {
            get
            {
                return base.Enabled;
            }
            set
            {
                base.Enabled  = value;

                RefreshLayout();
            }
        }


        public virtual void RefreshLayout()
        {
            if (this.Enabled)
            {
                if (m_NormalEnterImage != null)
                {
                    base.Image = m_NormalEnterImage;
                }
            }
            else
            {
                if (m_NormalDisabledImage != null)
                {
                    base.Image = m_NormalDisabledImage;
                }
            }
        }
        public ButtonEx()
        {
            InitializeComponent();
            base.BackColor = Color.Transparent;
        }

        public ButtonEx(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override void OnHandleCreated(System.EventArgs e)
        {
            base.OnHandleCreated(e);

            
            RefreshLayout();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
             
            base.OnMouseDown(e);
            this.ForeColor = Color.White;
        }

        protected override void OnMouseUp(MouseEventArgs e)
         {
             base.OnMouseUp(e);
             this.ForeColor = Color.Navy  ;
         }
    }
}
