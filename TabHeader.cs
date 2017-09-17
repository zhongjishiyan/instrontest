#define DRAG_AND_DROP_SUPPORT

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace BorisBord.WinForms
{
#if DRAG_AND_DROP_SUPPORT
	#region DRAG AND DROP
	public class DragControlsEventArgs: EventArgs
	{		
		public DragControlsEventArgs(System.Windows.Forms.Control DragTarget, System.Windows.Forms.Control[] DragSource) 
		{
			this.m_DragTarget=DragTarget;
			this.m_DragSource=DragSource;
		}

		protected DragDropEffects m_Effect = DragDropEffects.None;
		public DragDropEffects Effect
		{
			get
			{
				return m_Effect;
			}
			set
			{
				m_Effect = value;
			}
		}

		public DragControlsEventArgs() 
		{
			this.m_DragTarget=null;
			this.m_DragSource=null;
		}

		protected System.Windows.Forms.Control m_DragTarget;
		public System.Windows.Forms.Control DragTarget
		{
			get 
			{
				return m_DragTarget;
			}
			set
			{	
				m_DragTarget = value;									
			}
		}
	

		protected System.Windows.Forms.Control[] m_DragSource;			
		public System.Windows.Forms.Control[] DragSource
		{
			get 
			{
				return m_DragSource;
			}
			set
			{	
				m_DragSource = value;									
			}
		}

	}
	
	public delegate void DragControlsEventHandler(object sender, DragControlsEventArgs me);	
	#endregion
#endif

	public class TabPage : System.Windows.Forms.Panel 
	{
		protected TabButton m_HeaderButton;
		[System.ComponentModel.DefaultValue(null)]
		public TabButton HeaderButton
		{
			get
			{
				return m_HeaderButton;
			}
			set
			{
				if(m_HeaderButton!=value)
				{
					if(m_HeaderButton!=null)
					{
						m_HeaderButton.CheckedChanged -= new System.EventHandler(HeaderButton_CheckedChanged);
					}
					m_HeaderButton = value;
					if(m_HeaderButton!=null)
					{
						m_HeaderButton.CheckedChanged += new System.EventHandler(HeaderButton_CheckedChanged);
					}
				}
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
				m_MenuItem = value;
			}
		}

		private void HeaderButton_CheckedChanged(object sender, System.EventArgs e)
		{
			OnHeaderButtonCheckedChanged(sender, e);
		}
		protected virtual void OnHeaderButtonCheckedChanged(object sender, System.EventArgs e)
		{
			this.Visible = m_HeaderButton.Checked;
		}
		
		protected override void OnVisibleChanged(System.EventArgs e)
		{
			try
			{ // something wrong in MenuItem
				if ( m_MenuItem != null)
				{
					m_MenuItem.Visible = this.Visible;
				}
			}
			catch
			{
			}
			base.OnVisibleChanged(e);
		}

		protected override void OnEnabledChanged(System.EventArgs e)
		{
			try
			{
			if ( m_MenuItem != null)
			{
				m_MenuItem.Enabled = this.Enabled;
			}
			}
			catch
			{
			}
			base.OnEnabledChanged(e);
		}

	}


	public class TabButton : ImageButton 
	{			
		[Browsable(true), EditorBrowsable(EditorBrowsableState.Always),	]
		public new bool AllowDrop 
		{
			get 
			{
				return base.AllowDrop;
			}
			set 
			{				
				base.AllowDrop = value;
			}
		}
		
		public bool BaseVisible 
		{
			get 
			{
				return base.Visible;
			}
			set 
			{
				base.Visible = value;
			}
		}

		private bool myVisible = true;
		public new bool Visible 
		{
			set 
			{
				if( value != myVisible ) 
				{
					myVisible = value;
					if( this.Parent != null )
						((TabHeader)(this.Parent)).RefreshLayout();
				}
			}
			get 
			{
				return myVisible;
			}
		}
		
	}

	///
	///
	///
	/// <summary>
	/// Summary description for TabHeader.
	/// </summary>
	///
	///
	public class TabHeader : TabPage 
	{

		// private fields
		private ImageButton m_ScrollLeftButton;
		private ImageButton m_SrcollRightButton;		
		private TabButton m_ActiveTab;
		private TabButton m_LastShiftKeyTab;
		private int m_LeftFirst;		
		private bool m_Scrolling; 
		private bool m_Vertical = false; 
		private bool m_Multiselect = false;

		// proprties
		public bool Multiselect 
		{
			get 
			{
				return m_Multiselect;
			}
			set 
			{
				m_Multiselect = value;
				RefreshLayout();
			}
		}

		public bool Vertical 
		{
			get 
			{
				return m_Vertical;
			}
			set 
			{
				m_Vertical = value;
				RefreshLayout();
			}
		}

		public event System.EventHandler SelectedTabChanged;
		protected void OnSelectedTabChanged(System.EventArgs e)
		{
			if(SelectedTabChanged!=null)
			{
				SelectedTabChanged(this, e);
			}
		}

		public TabButton SelectedButton 
		{
			get 
			{
				return m_ActiveTab;
			}
			set 
			{
				if( m_ActiveTab == value )
					return;
 
				TabButton oldTab = m_ActiveTab;

				m_ActiveTab = value;

				if( !m_Multiselect && oldTab != null )
					oldTab.Checked = false;

				if( m_ActiveTab != null && !m_ActiveTab.Checked)
					m_ActiveTab.Checked = true;

				RefreshLayout();
				OnSelectedTabChanged(System.EventArgs.Empty);
			}
		}

		public ImageButton SrcollLeftButton
		{
			get
			{
				return m_ScrollLeftButton;
			}
			set 
			{
				if(m_ScrollLeftButton != value)
				{
					if(m_ScrollLeftButton!=null)
					{
						m_ScrollLeftButton.Click -= new EventHandler(ScrollLeftButton_Click);
					}
					m_ScrollLeftButton = value;
					if(m_ScrollLeftButton!=null)
					{
						m_ScrollLeftButton.Visible = false;
						m_ScrollLeftButton.Click += new EventHandler(ScrollLeftButton_Click);
					}
				}
			}
		}

		public ImageButton SrcollRightButton
		{
			get
			{
				return m_SrcollRightButton;
			}
			set 
			{
				if(m_SrcollRightButton!=value)
				{					
					if(m_SrcollRightButton!=null)
					{
						m_SrcollRightButton.Click -= new EventHandler(SrcollRightButton_Click);
					}
					m_SrcollRightButton = value;
					if(m_SrcollRightButton!=null)
					{
						m_SrcollRightButton.Visible = false;
						m_SrcollRightButton.Click += new EventHandler(SrcollRightButton_Click);
					}
				}
			}
		}

		
#if DRAG_AND_DROP_SUPPORT
		#region DRAG AND DROP
		public event DragControlsEventHandler DragDropButtons;
		public event DragControlsEventHandler DragOverButtons;
		
		protected virtual void OnDragDropButtons(DragControlsEventArgs de)
		{
			if(DragDropButtons!=null)
			{
				DragDropButtons(this, de);
			}
		}
		
		protected virtual void OnDragOverButtons(DragControlsEventArgs de)
		{
			if(DragOverButtons!=null)
			{
				DragOverButtons(this, de);
			}
		}

		private void Control_DragStarting(object sender, DragEventArgs e)
		{
			ArrayList ArrayTabButton =new ArrayList();// 

			TabButton currentButton = null;						
			if( typeof(TabButton).IsAssignableFrom(sender.GetType()) ) 	currentButton = (TabButton)sender;				
			
			if(currentButton != null) 
			{						 
				if (currentButton.Checked)
				{			
					foreach( Control c in Controls ) 
					{
						if( typeof(TabButton).IsAssignableFrom(c.GetType()) ) 
						{							
							TabButton tabButton = (TabButton)c; 
							if( tabButton.Visible && tabButton.Checked &&tabButton.AllowDrag) 
							{
								ArrayTabButton.Add(tabButton);																		
							}
						}
					} // foreach					
				}
				else
				{
					ArrayTabButton.Add(currentButton);	
				}	
			}						
				
			e.Data.SetData(ArrayTabButton.ToArray(typeof(System.Windows.Forms.Control)));			
		}

		
		private void Control_DragDrop(object sender, DragEventArgs de) 
		{			
			DragControlsEventArgs me =new DragControlsEventArgs();

			me.DragTarget = (System.Windows.Forms.Control) sender;
			me.DragSource=(System.Windows.Forms.Control[])de.Data.GetData(de.Data.GetFormats(false)[0]);										
			
			OnDragDropButtons(me);
			de.Effect = me.Effect;
		}
			
		private void Control_DragOver(object sender, DragEventArgs de)
		{
			DragControlsEventArgs me =new DragControlsEventArgs();

			me.DragTarget = (System.Windows.Forms.Control) sender;
			me.DragSource=(System.Windows.Forms.Control[])de.Data.GetData(de.Data.GetFormats(false)[0]);										
			
			OnDragOverButtons(me);	
			de.Effect = me.Effect;
		}
		#endregion
#endif
		///
		///
		///
		public TabHeader() 
		{
			m_LeftFirst = 0;
			m_Scrolling = false;
			m_Multiselect = false;
			m_ActiveTab = null;
			m_LastShiftKeyTab = null;

			this.ControlAdded += new ControlEventHandler(TabHeader_OnControlAdded);
			this.ControlRemoved += new ControlEventHandler(TabHeader_OnControlRemoved);

#if DRAG_AND_DROP_SUPPORT
			this.DragOver+=new DragEventHandler(Control_DragOver);
			this.DragDrop+=new DragEventHandler(Control_DragDrop);
#endif
		}
           

		private void TabHeader_OnControlAdded(object sender,
			ControlEventArgs e) 
		{
			if( typeof(TabButton).IsAssignableFrom(e.Control.GetType()) ) 
			{
				TabButton tabButton = (TabButton)e.Control;
				tabButton.Click += new EventHandler(TabButton_OnClick); 
				tabButton.CheckedChanged += new EventHandler(TabButton_OnCheckedChanged); 

#if DRAG_AND_DROP_SUPPORT
				tabButton.DragOver    +=new DragEventHandler(Control_DragOver);
				tabButton.DragDrop    +=new DragEventHandler(Control_DragDrop);								
				tabButton.DragStarting+=new DragEventHandler(Control_DragStarting);
#endif
			}
		}


		private void TabHeader_OnControlRemoved(object sender,
			ControlEventArgs e) 
		{
			if( typeof(TabButton).IsAssignableFrom(e.Control.GetType()) ) 
			{
				TabButton tabButton = (TabButton)e.Control;
				tabButton.Click -= new EventHandler(TabButton_OnClick); 
				tabButton.CheckedChanged -= new EventHandler(TabButton_OnCheckedChanged); 

#if DRAG_AND_DROP_SUPPORT
				if(this.m_ActiveTab == tabButton)
					this.m_ActiveTab=null;// unselect
				if(this.m_LastShiftKeyTab == tabButton)
					this.m_LastShiftKeyTab=null;// unselect

				tabButton.DragOver    -=new DragEventHandler(Control_DragOver);
				tabButton.DragDrop    -=new DragEventHandler(Control_DragDrop);								
				tabButton.DragStarting-=new DragEventHandler(Control_DragStarting);			
#endif
			}
		}


		private void TabButton_OnClick(object sender, 
			System.EventArgs e) 
		{

			if(sender==null || !typeof(TabButton).IsAssignableFrom(sender.GetType()) ) 
			{
				return;
			}

			TabButton currentButton = (TabButton)sender;

			if( !m_Multiselect ) 
			{
				m_LastShiftKeyTab = null;
				this.SelectedButton = currentButton;
			}
			else 
			{
				// Multiselect
   
				System.Windows.Forms.Keys keys = ModifierKeys;
				bool bCtrlPressed = (keys&Keys.Control) == Keys.Control;
				bool bShiftPressed = (keys&Keys.Shift) == Keys.Shift;
               
				if( bCtrlPressed ) 
				{
					m_LastShiftKeyTab = null;

					if( currentButton != null ) 
						currentButton.Checked = !currentButton.Checked;

					if( m_ActiveTab == currentButton ) 
					{
						if( !currentButton.Checked ) 
						{
							m_ActiveTab = null;

							// m_ActiveTab = first checked
							foreach( Control c in Controls ) 
							{
								if( typeof(TabButton).IsAssignableFrom(c.GetType()) ) 
								{
									TabButton tabButton = (TabButton)c; 
									if( tabButton.Visible && tabButton.Checked ) 
									{
										m_ActiveTab = tabButton;
										break;
									}
								}
							} // foreach
						}
					}
					else
					{
						m_ActiveTab = currentButton;
					}
				}
				else if( bShiftPressed && currentButton != null ) 
				{
					// TODO: ShiftKeyUp -- m_ActiveTab = currentButton
					m_LastShiftKeyTab = currentButton;

					int first = -1, last = -1,  m = -1;

					// has no selection ? m_ActiveTab = first item from container
					if( m_ActiveTab == null ) 
					{
						foreach( Control c in Controls ) 
						{
							if( typeof(TabButton).IsAssignableFrom(c.GetType()) ) 
							{
								TabButton tabButton = (TabButton)c; 
								if( tabButton.Visible ) 
								{
									m_ActiveTab = tabButton;
									break;
								}
							}
						}
					}

					// get btn range to be checked
					if( m_Vertical ) 
					{
						first = currentButton.Top+currentButton.Height/2;
						last = m_ActiveTab.Top+m_ActiveTab.Height/2;
					}
					else 
					{
						first = currentButton.Left+currentButton.Width/2;
						last = m_ActiveTab.Left+m_ActiveTab.Width/2;
					}

					if( first > last ) 
					{
						m = last;
						last = first;
						first = m;
					}

					// check btns
					foreach( Control c in Controls ) 
					{
						if( typeof(TabButton).IsAssignableFrom(c.GetType()) ) 
						{
							TabButton tabButton = (TabButton)c; 
							if( tabButton.Visible ) 
							{
                           
								if( m_Vertical ) 
									m = tabButton.Top+tabButton.Height/2;
								else
									m = tabButton.Left+tabButton.Width/2;

								if( first <= m && last >= m ) 
									tabButton.Checked = true;
								else
									tabButton.Checked = false;
							}
						}
					} // foreach
				}
				else 
				{
					foreach( Control c in Controls ) 
					{
						if( typeof(TabButton).IsAssignableFrom(c.GetType()) ) 
						{
							TabButton tabButton = (TabButton)c; 
							tabButton.Checked = currentButton == tabButton;
						}
					}

					m_ActiveTab = currentButton;
				}

				RefreshLayout();
				OnSelectedTabChanged(System.EventArgs.Empty);
			}            
		}


		private void TabButton_OnCheckedChanged(object sender, 
			System.EventArgs e)
		{
			if(sender!=null && typeof(TabButton).IsAssignableFrom(sender.GetType()))
			{
				if(!m_Multiselect && (sender as TabButton).Checked)
				{
					this.SelectedButton = (TabButton)sender;
				}
			}
		}


		private void ScrollLeftButton_Click(object sender, 
			System.EventArgs e) 
		{
			--m_LeftFirst;
			RefreshLayout();
		}


		private void SrcollRightButton_Click(object sender, 
			System.EventArgs e) 
		{
			++m_LeftFirst;
			RefreshLayout();
		}


		/*public void AddTab(int index, TabButton tab, Object o) 
		{
			Controls.Add(tab);
			RefreshLayout();     
		}*/

		//
		//
		//

		public void RefreshLayout() 
		{
			int u, i;
			bool bs = !(m_SrcollRightButton == null || m_ScrollLeftButton == null);

			Size size = this.Size;
			Size isize;
			Size scrollersSize;

			if( bs ) 
				isize = m_SrcollRightButton.Size;
			else 
				isize = new Size(0, 0);

			if( m_Vertical ) 
			{
				scrollersSize = new Size(isize.Width, isize.Height*2+5);
			}
			else 
			{
				scrollersSize = new Size(isize.Width*2+5, isize.Height*2);
			}

			// calculate the sum width of all tabs... need scroling????
			int totalWidth = 0;
			int tabCnt = 0;

			ArrayList alWidths = new ArrayList();

			foreach( Control c in Controls ) 
			{
				if( typeof(TabButton).IsAssignableFrom(c.GetType()) ) 
				{
					TabButton tabButton = (TabButton)c; 
					if( tabButton.Visible ) 
					{
						if( m_Vertical ) 
						{
							totalWidth += tabButton.Size.Height;
							alWidths.Add(tabButton.Size.Height);
						}
						else 
						{
							totalWidth += tabButton.Size.Width;
							alWidths.Add(tabButton.Size.Width);
						}
						tabCnt++;
					}
				}
			}
			totalWidth += (tabCnt - 1) * m_Interval;

			#region Vertical
			if( m_Vertical ) 
			{
				if( totalWidth >= size.Height ) 
				{
					m_Scrolling = bs & true;
					size.Height -= scrollersSize.Height;

					if( m_LeftFirst < 0 ) 
						m_LeftFirst = 0;

					// i = number of visible tabs from right side
					for( u = 0, i = 0; i < alWidths.Count; i++ ) 
					{
						u += (int)alWidths[alWidths.Count-i-1];
						if(i>0) u+= m_Interval;
						if( u > size.Height ) 
							break;
					}

					if( m_LeftFirst > (tabCnt-i) )
						m_LeftFirst = tabCnt-i;

				}
				else 
				{
					m_LeftFirst = 0;
					m_Scrolling = false;
				}
			}
			else 
			{
				if( totalWidth >= size.Width ) 
				{
					m_Scrolling = true&bs;
					size.Width -= scrollersSize.Width;

					if( m_LeftFirst < 0 ) 
						m_LeftFirst = 0;

					// i = number of visible tabs from right side
					for( u = 0, i = 0; i < alWidths.Count; i++ ) 
					{
						u += (int)alWidths[alWidths.Count-i-1];
						if(i>0) u+= m_Interval;
						if( u > size.Width ) 
							break;
					}

					if( m_LeftFirst > (tabCnt-i) )
						m_LeftFirst = tabCnt-i;

				}
				else 
				{
					m_LeftFirst = 0;
					m_Scrolling = false;
				}
			}
			#endregion

			//
			u = i = 0;
			foreach( Control c in Controls ) 
			{
				if( typeof(TabButton).IsAssignableFrom(c.GetType()) ) 
				{
					TabButton tabButton = (TabButton)c; 
					if( tabButton.Visible ) 
					{
						int ci = i++;

						if( m_LeftFirst > ci ) 
						{
							tabButton.BaseVisible = false;
							continue;
						}

						if( m_Vertical ) 
						{
							Size curImgSize = tabButton.Size;
							tabButton.SetBounds(0, u, curImgSize.Width, curImgSize.Height);
							u += curImgSize.Height;

							tabButton.BaseVisible = (m_LeftFirst == ci) || !(u > size.Height)|!bs;
						}
						else 
						{
							Size curImgSize = tabButton.Size;
							tabButton.SetBounds(u, 0, curImgSize.Width, curImgSize.Height);
							u += curImgSize.Width;

							tabButton.BaseVisible = (m_LeftFirst == ci) || !(u > size.Width)|!bs;
						}
						u += m_Interval;
					}
					else 
					{
						tabButton.BaseVisible = false;
					}
				}
			}

			#region Scrolling
			//
			if( m_Scrolling ) 
			{            
				if( m_Vertical ) 
				{
					m_ScrollLeftButton.SetBounds(5, 
						ClientRectangle.Bottom-scrollersSize.Height, 
						isize.Width, isize.Height);

					m_SrcollRightButton.SetBounds(5, 
						ClientRectangle.Bottom-scrollersSize.Height+isize.Width,
						isize.Width, isize.Height);
				}
				else 
				{
					m_ScrollLeftButton.SetBounds(ClientRectangle.Right-scrollersSize.Width, 
						(size.Height/2)-(isize.Height/2), 
						isize.Width, isize.Height);

					m_SrcollRightButton.SetBounds(ClientRectangle.Right-scrollersSize.Width+isize.Width, 
						(size.Height/2)-(isize.Height/2), 
						isize.Width, isize.Height);
				}

				m_ScrollLeftButton.Visible = true;
				m_SrcollRightButton.Visible = true;
			}
			else 
			{
				if( m_ScrollLeftButton != null )
					m_ScrollLeftButton.Visible = false;
				if( m_SrcollRightButton != null )
					m_SrcollRightButton.Visible = false;
			}
			#endregion
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		/*protected override void OnPaint(System.Windows.Forms.PaintEventArgs e) 
		{
			//RefreshLayout();
			base.OnPaint(e);
		}*/

		protected override void OnResize(System.EventArgs e) 
		{
			base.OnResize(e);
			RefreshLayout();
		}

		protected override void OnHeaderButtonCheckedChanged(object sender, 
			System.EventArgs e)
		{
			base.OnHeaderButtonCheckedChanged(sender, e);
			if(this.Visible)
			{
				if(this.SelectedButton==null)
				{
					foreach( Control c in Controls ) 
					{
						if( typeof(TabButton).IsAssignableFrom(c.GetType()) ) 
						{
							TabButton tabButton = (TabButton)c; 
							if( tabButton.Visible ) 
							{
								this.SelectedButton = tabButton;
								break;
							}
						}
					}
				}
				else
				{
					if(!this.SelectedButton.Checked)
					{
						this.SelectedButton.Checked = true;
						RefreshLayout();
						OnSelectedTabChanged(System.EventArgs.Empty);
					}
				}
			}
			else
			{
				if(this.SelectedButton!=null)
				{
					this.SelectedButton.Checked = false;
					RefreshLayout();
					OnSelectedTabChanged(System.EventArgs.Empty);
				}
			}
		}


		protected int m_Interval = 0;		
		[System.ComponentModel.DefaultValue(0)]
		public int Interval
		{
			get
			{
				return m_Interval;
			}
			set
			{
				m_Interval = value;
			}
		}
	}        
	
}
