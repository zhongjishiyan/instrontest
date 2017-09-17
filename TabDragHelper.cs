using System;
using System.Windows.Forms;
using System.Collections;


namespace BorisBord.WinForms
{
	/// <summary>
	/// Summary description for TabDragging.
	/// </summary>
	public class TabDragHelper
	{
		public TabDragHelper()
		{
		}
				

		public void DragOverButtons(object sender, DragControlsEventArgs e)
		{
			
			if (typeof(TabHeader).IsAssignableFrom(sender.GetType()))
			{					
				if (((TabHeader)sender).AllowDrop) 				
					e.Effect = DragDropEffects.Move;
				else
					e.Effect = DragDropEffects.None;// 					
			}
			else
			{
				e.Effect = DragDropEffects.None;			
			}
			
		}


		public void DragDropButtons(object sender, DragControlsEventArgs me)
		{			
			TabHeader tabHeader; 
			TabButton tabButton;
			
			int index=0;
			
			if( typeof(BorisBord.WinForms.TabHeader).IsAssignableFrom(me.DragTarget.GetType()) ) 
			{
				tabHeader = (TabHeader)me.DragTarget;
			}			
			else 
			{
				tabButton=(TabButton) me.DragTarget;
				tabHeader = (TabHeader)(tabButton.Parent);				
				index = tabHeader.Controls.IndexOf(tabButton);
			}		
			
			if (me.DragTarget.AllowDrop)
			{					
				Control [] data =me.DragSource;
				tabButton=(TabButton) data[0];
				TabHeader tabHeader_begin = (TabHeader)((TabButton)data[0]).Parent;														

				tabHeader.Controls.AddRange(data);					

				if( typeof(BorisBord.WinForms.TabButton).IsAssignableFrom(me.DragTarget.GetType()) ) 
				{						
					for(int i = 0; i <data.Length; i++)
					{	
						if (tabHeader.Multiselect!=true)
							if(i!=0) 
							{
								((TabButton)data[i]).Checked=false;
							}						
						tabHeader.Controls.SetChildIndex(data[i],index+i);	//renumbering			
					}
				}
				#region Selection
				
				if (tabHeader.Multiselect!=true)
				{
					if(tabButton.Checked)
					{	
						tabHeader.SelectedButton=tabButton;
						tabButton.Checked=true;
						tabHeader.SelectedButton=tabButton;						
					}
				}
				else
				{					
				}
				#endregion

					
				try
				{
					#region draging TabPages			


					Panel begPanel = (Panel)(tabHeader_begin.Parent.Parent.Parent);
					Panel endPanel = (Panel)(tabHeader      .Parent.Parent.Parent);
				
					ArrayList ArrayTabPages = new ArrayList();// array TabPage			
					foreach( Control Contr in begPanel.Controls ) 
					{
						if (typeof(System.Windows.Forms.Panel).IsAssignableFrom(Contr.GetType())&&
							((System.Windows.Forms.Panel)Contr).Dock==System.Windows.Forms.DockStyle.Fill)
						{
							foreach( Control c in Contr.Controls ) 
							{
								if( typeof(BorisBord.WinForms.TabPage).IsAssignableFrom(c.GetType()) ) 
								{							
									BorisBord.WinForms.TabPage tabPage = (BorisBord.WinForms.TabPage)c; 							
									for (int i=0;i<data.Length;i++)
									{
										if(data[i]==tabPage.HeaderButton)
										{												
											ArrayTabPages.Add(tabPage);																		
										}
									}						
								}
							} // foreach for c	 					
						}
					}// foreach for Contr	

					foreach( Control Contr in endPanel.Controls ) 
					{
						if (typeof(System.Windows.Forms.Panel).IsAssignableFrom(Contr.GetType())&&
							 ((System.Windows.Forms.Panel)Contr).Dock==System.Windows.Forms.DockStyle.Fill)
						{
							Contr.Controls.AddRange((Control[])ArrayTabPages.ToArray(typeof(Control)));					
						}
					}	
					#endregion
				}
				catch
				{
				}

				tabHeader.RefreshLayout();   
				tabHeader_begin.RefreshLayout();
			}					
		}	
	}


}
