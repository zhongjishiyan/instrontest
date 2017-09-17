using System;
using System.Collections;
using System.ComponentModel;  
using System.Drawing;
using System.Windows.Forms;

namespace BorisBord {   

    [ ProvideProperty("HelpText",typeof(Control)),   ]
    public class Helper : Control, System.ComponentModel.IExtenderProvider {
     
		private System.ComponentModel.Container m_components;
        private Hashtable HelpTable;
		private string m_HelpText="";     
		public System.Resources.ResourceManager m_ResManag;

		private void Load()
		{				
			m_ResManag = new System.Resources.ResourceManager("TabHeaderDemo.helper", this.GetType().Assembly);//			
		}
		

        public Helper() {
            InitializeComponent();
            HelpTable = new Hashtable();
			Load();
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                m_components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            this.m_components = new System.ComponentModel.Container ();          
            this.TabStop = false;
        }

        
        bool IExtenderProvider.CanExtend(object target)
		{
            if (target is BorisBord.WinForms.TabButton||
				target is BorisBord.WinForms.TabHeader||
				target is BorisBord.WinForms.TabPage||
				target is System.Windows.Forms.TrackBar)  
			{
				return true;        				
			}
			
            return false;
        }


        [DefaultValue(""),]
        public string GetHelpText(Control control) {
            string text = (string)HelpTable[control];           
            if (text == null) 
			{
                text = string.Empty;
            }
            return text;
        }
		public void SetHelpText(Control control, string value) 
		{
			if (value == null) 
			{
				value = string.Empty;
			}
			if (value.Length == 0) 
			{
				HelpTable.Remove(control);				
				control.MouseEnter -=new EventHandler(OnMouseEnter);
				control.MouseLeave -=new EventHandler(OnMouseLeave);
			}
			else 
			{							
				HelpTable[control] = value;					
				control.MouseEnter +=new EventHandler(OnMouseEnter);
				control.MouseLeave +=new EventHandler(OnMouseLeave);
			}			
		}
   
		private bool ShouldSerializeHelpText(Control control)
		{
			if( GetHelpText(control) !="")
				return true;
			else
				return false;
		}
		
        
		protected override void OnPaint(PaintEventArgs pe) 
		{
			base.OnPaint(pe);
			Rectangle rect = ClientRectangle;
			Pen borderPen = new Pen(ForeColor);
			pe.Graphics.DrawRectangle(borderPen, rect);
			borderPen.Dispose();
			string text = m_HelpText;
			if (text != null && text.Length > 0) 
			{
				rect.Inflate(-2, -2);
				Brush brush = new SolidBrush(ForeColor);
				pe.Graphics.DrawString(text, Font, brush, rect);
				brush.Dispose();
            
			}
		}

		#region 
		private void OnMouseEnter(object sender, EventArgs e) 
		{
			string s="";
			try
			{
				s =  m_ResManag.GetString((string)HelpTable[sender]);	
			}
			catch{}
			//m_HelpText = "sender.GetHashCode() = "+sender.GetHashCode()+" "+"\n"+s;
			m_HelpText = s;
			Invalidate();
		}
		 
		protected void OnMouseLeave(object sender,EventArgs e)
		{
			m_HelpText = "";	
			Invalidate();
		}
		#endregion

       

	}
}

