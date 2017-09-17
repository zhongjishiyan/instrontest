#define DRAG_AND_DROP_SUPPORT
#define OWNER_DRAW_SUPPORT

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BorisBord.WinForms
{
	/// <summary>
	/// Summary description for ImageButton.
	/// </summary>
	public class ImageButton : System.Windows.Forms.PictureBox
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ImageButton()
		{
			SetStyle(System.Windows.Forms.ControlStyles.StandardClick, false);

			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
			m_Entered = false;
			m_Checked = false;
			m_Pressed = false;

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// ImageButton
			// 
			this.Name = "ImageButton";

		}
		#endregion
	
	

		#region " Image Properties "

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

		protected System.Drawing.Image m_NormalLeaveImage;
		[System.ComponentModel.DefaultValue(null)]
		public System.Drawing.Image NormalLeaveImage
		{
			get
			{
				return m_NormalLeaveImage;
			}
			set
			{
				m_NormalLeaveImage = value;
			}
		}
		protected System.Drawing.Image m_NormalPressImage;
		[System.ComponentModel.DefaultValue(null)]
		public System.Drawing.Image NormalPressImage
		{
			get
			{
				return m_NormalPressImage;
			}
			set
			{
				m_NormalPressImage = value;
			}
		}
		protected System.Drawing.Image m_CheckedEnterImage;
		[System.ComponentModel.DefaultValue(null)]
		public System.Drawing.Image CheckedEnterImage
		{
			get
			{
				return m_CheckedEnterImage;
			}
			set
			{
				m_CheckedEnterImage = value;
			}
		}
		protected System.Drawing.Image m_CheckedLeaveImage;
		[System.ComponentModel.DefaultValue(null)]
		public System.Drawing.Image CheckedLeaveImage
		{
			get
			{
				return m_CheckedLeaveImage;
			}
			set
			{
				m_CheckedLeaveImage = value;
			}
		}
		protected System.Drawing.Image m_CheckedPressImage;
		[System.ComponentModel.DefaultValue(null)]
		public System.Drawing.Image CheckedPressImage
		{
			get
			{
				return m_CheckedPressImage;
			}
			set
			{
				m_CheckedPressImage = value;
			}
		}
		
		protected System.Drawing.Image m_CheckedDisabledImage;
		[System.ComponentModel.DefaultValue(null)]
		public System.Drawing.Image CheckedDisabledImage
		{
			get
			{
				return m_CheckedDisabledImage;
			}
			set
			{
				m_CheckedDisabledImage = value;
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

		//public new System.Drawing.Image Image
		//{
		//	get
		//	{
		//		return base.Image;
		//	}
		//}

		#endregion

		public event System.EventHandler CheckedChanged;

		protected bool m_Checked;
		public bool Checked
		{
			get 
			{
				return m_Checked;
			}
			set
			{
				if(m_Checked != value)
				{
					m_Checked = value;
					RefreshLayout();
					this.Refresh();
					OnCheckedChanged(System.EventArgs.Empty);
				}
			}
		}


		protected bool m_Entered;
		public bool Entered
		{
			get 
			{
				return m_Entered;
			}			
		}


		protected bool m_Pressed;
		public bool Pressed
		{
			get 
			{
				return m_Pressed;
			}
		}


		protected System.Windows.Forms.MenuItem m_MenuItem;
		[System.ComponentModel.DefaultValue(null)]
		public System.Windows.Forms.MenuItem MenuItem
		{
			get
			{
				return m_MenuItem;
			}
			set
			{
				if(m_MenuItem!=null)
				{
					m_MenuItem.Click -= new System.EventHandler(m_MenuItem_Click);
				}
				m_MenuItem = value;
				if(m_MenuItem!=null)
				{
					m_MenuItem.Click += new System.EventHandler(m_MenuItem_Click);
				}
			}
		}
		
		private void m_MenuItem_Click(Object sender, System.EventArgs e)
		{
			this.OnClick(e);
		}

		
		[
		Browsable(true), 
		EditorBrowsable(EditorBrowsableState.Always),      		
		]
		public new string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			m_Entered = true;			
			RefreshLayout();
			base.OnMouseEnter (e);

		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			m_Pressed = true;
			RefreshLayout();

			base.OnMouseDown(e);
		}


		protected override void OnMouseLeave(EventArgs e)
		{
			m_Entered = false;
			RefreshLayout();

			base.OnMouseLeave(e);
		}


		protected override void OnMouseUp(MouseEventArgs e)
		{
			m_Pressed = false;
			if(e.X < this.Width && e.Y < this.Height)
			{
				m_Entered = true;
			}
			else
			{
				m_Entered = false;
			}
			RefreshLayout();

			base.OnMouseUp(e);

			if(e.Button==System.Windows.Forms.MouseButtons.Left)
			{
				this.OnClick(e);
			}
		}


		public virtual void RefreshLayout()
		{
			if(this.Enabled)
			{
				if(!m_Entered && !m_Pressed)
					if(CheckedLeaveImage!=null && m_Checked)
					{
						base.Image = CheckedLeaveImage;
					}
					else if(NormalLeaveImage!=null)
						base.Image = NormalLeaveImage;
				if(m_Entered && !m_Pressed)
					if(CheckedEnterImage!=null && m_Checked)
					{
						base.Image = CheckedEnterImage;
					}
					else if(CheckedLeaveImage!=null && m_Checked)
					{
						base.Image = CheckedLeaveImage;
					}
					else if(NormalEnterImage!=null)
					{
						base.Image = NormalEnterImage;
					}
					else if(NormalLeaveImage!=null)
					{
						base.Image = NormalLeaveImage;
					}
				if(m_Pressed)
					if(CheckedPressImage!=null && m_Checked)
					{
						base.Image = CheckedPressImage;
					}
					else if(NormalPressImage!=null)
					{
						base.Image = NormalPressImage;
					}
					else if(NormalEnterImage!=null)
						base.Image = NormalEnterImage;
			}
			else
			{
				if(m_Checked && m_CheckedDisabledImage!=null)
				{
					base.Image = m_CheckedDisabledImage;
				}
				else if(m_NormalDisabledImage!=null)
				{
					base.Image = m_NormalDisabledImage;
				}
				else if(NormalLeaveImage!=null)
				{
					base.Image = NormalLeaveImage;
				}
			}			
			/*if (base.Image==null)*/
			Invalidate();			
		}

		protected virtual  void OnCheckedChanged(System.EventArgs e)
		{
			try
			{ // something wrong in MenuItem
				if ( m_MenuItem != null)
				{
					m_MenuItem.Checked = this.Checked;
				}
			}
			catch
			{
			}
			if(CheckedChanged!=null)
			{
				CheckedChanged(this, e);
			}
		}

		protected override void OnVisibleChanged(System.EventArgs e)
		{
			/*try
			{ // something wrong in MenuItem
				if ( m_MenuItem != null)
				{
					m_MenuItem.Visible = this.Visible;
				}
			}
			catch
			{
			}*/
			base.OnVisibleChanged(e);
		}

		protected override void OnEnabledChanged(System.EventArgs e)
		{
			try
			{ // something wrong in MenuItem
				if ( m_MenuItem != null)
				{
					m_MenuItem.Enabled = this.Enabled;
				}
			}
			catch
			{
			}
			RefreshLayout();
			base.OnEnabledChanged(e);
		}

		protected override void OnHandleCreated(System.EventArgs e)
		{
			base.OnHandleCreated(e);

			m_Entered = false;
			RefreshLayout();
		}

#if OWNER_DRAW_SUPPORT
		protected bool m_OwnerDraw = false;
		[System.ComponentModel.DefaultValue(false)]
		public bool OwnerDraw
		{
			get 
			{
				return m_OwnerDraw;
			}
			set
			{	
				m_OwnerDraw = value;									
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if(m_OwnerDraw)
			{
				System.Reflection.FieldInfo field = typeof(System.Windows.Forms.Control).GetField("EventPaint", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
				if(field!=null)
				{
					System.Windows.Forms.PaintEventHandler handler = (System.Windows.Forms.PaintEventHandler)this.Events[field.GetValue(this)];
					if(handler!=null)
						handler(this, e);
				}
			}
			else
			{
				base.OnPaint(e);
			}
		}
 
#endif

#if DRAG_AND_DROP_SUPPORT
		protected bool m_AllowDrag = false;	
		public bool AllowDrag
		{
			get 
			{
				return m_AllowDrag;
			}
			set
			{	
				m_AllowDrag = value;									
			}
		}

		
		
		public event System.Windows.Forms.DragEventHandler DragStarting;// my event for begin signal dragging	
		public event System.Windows.Forms.DragEventHandler DragFinished;// my event for finish signal dragging		
				
		protected virtual void OnDragStarting(object sender,System.Windows.Forms.DragEventArgs e)
		{
			if(DragStarting!=null)
			{
				DragStarting(this, e);
			}
		}
		protected virtual void OnDragFinished(object sender,System.Windows.Forms.DragEventArgs e)
		{
			if(DragFinished!=null)
			{
				DragFinished(this, e);
			}
		}
		
	
		protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
		{
			base.OnMouseMove (e);			
			
			if (this.AllowDrag)			
			{
				if	(e.X < this.Width && e.Y < this.Height&&e.X>0&&e.Y>0)
				{
				}
				else
				{
					if(e.Button==System.Windows.Forms.MouseButtons.Left)
					{
						System.Windows.Forms.DataObject data = new System.Windows.Forms.DataObject();
						System.Windows.Forms.DragEventArgs de= 
							new System.Windows.Forms.DragEventArgs(data,
							1,/*left mouse down*/
							e.X,e.Y,
							System.Windows.Forms.DragDropEffects.All,
							System.Windows.Forms.DragDropEffects.All);

						OnDragStarting(this,de);
						DoDragDrop(de.Data.GetData(data.GetFormats(false)[0]), System.Windows.Forms.DragDropEffects.All);
						OnDragFinished(this,de);
						//we there because need workaround of missing MouseUp after completing DoDragDrop
						m_Pressed=false;			
						RefreshLayout();							
					}					
				}
			}		
		}
#endif
	}
}
