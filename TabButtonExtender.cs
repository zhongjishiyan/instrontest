
using System.ComponentModel;
using System.Collections;
using System.Windows.Forms;

using System.Runtime.InteropServices;

namespace BorisBord.WinForms
{
	/// <summary>
	/// Summary description for TabButtonExtender.
	/// </summary>
	/// 	
	
	[DefaultProperty("ImageList")]

	[ProvideProperty("PaintExtender",typeof(BorisBord.WinForms.ImageButton))]
	
	[ProvideProperty("NormalDisableImageIndex",typeof(BorisBord.WinForms.ImageButton))]	
	[ProvideProperty("NormalLeaveImageIndex",typeof(BorisBord.WinForms.ImageButton))]	
	[ProvideProperty("NormalPressImageIndex",typeof(BorisBord.WinForms.ImageButton))]	
	[ProvideProperty("NormalEnterImageIndex",typeof(BorisBord.WinForms.ImageButton))]
	
	[ProvideProperty("CheckedDisableImageIndex",typeof(BorisBord.WinForms.ImageButton))]	
	[ProvideProperty("CheckedLeaveImageIndex",typeof(BorisBord.WinForms.ImageButton))]	
	[ProvideProperty("CheckedPressImageIndex",typeof(BorisBord.WinForms.ImageButton))]	
	[ProvideProperty("CheckedEnterImageIndex",typeof(BorisBord.WinForms.ImageButton))]
	

	
	public class TabButtonExtender : System.ComponentModel.Component, System.ComponentModel.IExtenderProvider, ISupportInitialize
	{
		private Hashtable m_ExtenderControls;
		private bool m_initializing=false;		

		#region ISupportInitialize
		void ISupportInitialize.BeginInit()
		{
			m_initializing=true;
		}

		void ISupportInitialize.EndInit()
		{
			if( !DesignMode )
			{
				foreach(DictionaryEntry de in m_ExtenderControls)
				{
					BorisBord.WinForms.ImageButton imageButton = de.Key as BorisBord.WinForms.ImageButton;
					ExtendersProperties extendersButton =de.Value as ExtendersProperties;					

					if( imageButton != null )
					{
						if (ImageList!=null)
						{	
							#region Refresh data before start 
							int index;
							if ((index=extendersButton.NormalDisableImageIndex)>-1&&index<ImageList.Images.Count)
								imageButton.NormalDisabledImage=ImageList.Images[extendersButton.NormalDisableImageIndex];							
							if ((index=extendersButton.NormalEnterImageIndex)>-1&&index<ImageList.Images.Count) 
								imageButton.NormalEnterImage=ImageList.Images[extendersButton.NormalEnterImageIndex];							
							if ((index=extendersButton.NormalLeaveImageIndex)>-1&&index<ImageList.Images.Count) 
								imageButton.NormalLeaveImage=ImageList.Images[extendersButton.NormalLeaveImageIndex];							
							if ((index=extendersButton.NormalPressImageIndex)>-1&&index<ImageList.Images.Count)
								imageButton.NormalPressImage=ImageList.Images[extendersButton.NormalPressImageIndex];							
							if ((index=extendersButton.CheckedDisableImageIndex)>-1&&index<ImageList.Images.Count)
								imageButton.CheckedDisabledImage=ImageList.Images[extendersButton.CheckedDisableImageIndex];							
							if ((index=extendersButton.CheckedEnterImageIndex)>-1&&index<ImageList.Images.Count)
								imageButton.CheckedEnterImage=ImageList.Images[extendersButton.CheckedEnterImageIndex];							
							if ((index=extendersButton.CheckedLeaveImageIndex)>-1&&index<ImageList.Images.Count)
								imageButton.CheckedLeaveImage=ImageList.Images[extendersButton.CheckedLeaveImageIndex];							
							if ((index=extendersButton.CheckedPressImageIndex)>-1&&index<ImageList.Images.Count)
								imageButton.CheckedPressImage=ImageList.Images[extendersButton.CheckedPressImageIndex];							
							imageButton.Invalidate();

							imageButton.RefreshLayout();
							#endregion
						}							
					}					
					if(extendersButton.PaintExtender!=null)
						imageButton.Paint += new PaintEventHandler(extendersButton.PaintExtender.Paint);
				}
			}
			m_initializing=false;
		}
		#endregion

		#region ImageList
		private System.Windows.Forms.ImageList m_ImageList;
		public System.Windows.Forms.ImageList ImageList 
		{
			get
			{ 
				return this.m_ImageList; 
			}
			set
			{
				if(value!=this.m_ImageList)
				{
					this.m_ImageList=value;
				}
			}
				
		}
		#endregion

		#region constructor
		public TabButtonExtender()
		{		
			m_ExtenderControls = new Hashtable();		
		}			

		#endregion		
		
		bool IExtenderProvider.CanExtend(object target) 
		{
			if (target is BorisBord.WinForms.ImageButton )
			{				
				if(((BorisBord.WinForms.ImageButton)target).OwnerDraw)
					return true;		
			}
			return false;
		}
	

		private ExtendersProperties IsPropertiesExists(BorisBord.WinForms.ImageButton imageButton)
		{
			ExtendersProperties extProperty = (ExtendersProperties) m_ExtenderControls[imageButton];
			if( extProperty == null )
			{
				extProperty = new ExtendersProperties();
				m_ExtenderControls[imageButton] = extProperty;				
			}			
			return extProperty;
		}


		private bool IsEmpty(ExtendersProperties ext)
		{		
			if (ext.NormalDisableImageIndex ==-1&&
				ext.NormalLeaveImageIndex   ==-1&&
				ext.NormalPressImageIndex   ==-1&&
				ext.NormalEnterImageIndex   ==-1&&
				ext.CheckedDisableImageIndex==-1&&
				ext.CheckedLeaveImageIndex  ==-1&&
				ext.CheckedPressImageIndex  ==-1&&	
				ext.CheckedEnterImageIndex  ==-1&&
				ext.PaintExtender			== null)	
			  return true;
			else 
			  return false;
		}


		private class ExtendersProperties
		{				
			public int NormalDisableImageIndex;
			public int NormalLeaveImageIndex;
			public int NormalPressImageIndex;
			public int NormalEnterImageIndex;
			public int CheckedDisableImageIndex;
			public int CheckedLeaveImageIndex;
			public int CheckedPressImageIndex;			
			public int CheckedEnterImageIndex;
			public BorisBord.WinForms.IPaintHelper PaintExtender;
			
			public ExtendersProperties()
			{
				NormalDisableImageIndex=-1;
				NormalLeaveImageIndex=-1;
				NormalPressImageIndex=-1;
				NormalEnterImageIndex=-1;
				CheckedDisableImageIndex=-1;
				CheckedLeaveImageIndex=-1;
				CheckedPressImageIndex=-1;	
				CheckedEnterImageIndex=-1;				
			}
		
		}
	

	#region Property

		#region Normal...ImageIndex
		
		
		[Category("Extender Property")]		
		public int GetNormalDisableImageIndex(BorisBord.WinForms.ImageButton imageButton) 
		{		
			ExtendersProperties extProperty = (ExtendersProperties) m_ExtenderControls[imageButton];
			if( extProperty == null ) return -1;
			else return extProperty.NormalDisableImageIndex;

		}

		public void SetNormalDisableImageIndex(BorisBord.WinForms.ImageButton imageButton, int index) 
		{			
			ExtendersProperties currentButton;
			if (!m_initializing)
				if (index>m_ImageList.Images.Count)index=m_ImageList.Images.Count-1;//-1;				
			if (index>=0) 
			{
				currentButton = IsPropertiesExists(imageButton) ;
				currentButton.NormalDisableImageIndex=index;
			}
			else 
			{
				if ((currentButton = (ExtendersProperties) m_ExtenderControls[imageButton])!=null)
				{
					currentButton.NormalDisableImageIndex=-1;			
					if(IsEmpty(currentButton)) m_ExtenderControls.Remove(currentButton);;
				}
			}
		}
		private bool ShouldSerializeNormalDisableImageIndex(BorisBord.WinForms.ImageButton imageButton)
		{				
			if (GetNormalDisableImageIndex(imageButton)>=0)
				return true;
			else
				return false;
		}
		

		[Category("Extender Property")]		
		public int GetNormalLeaveImageIndex(BorisBord.WinForms.ImageButton imageButton) 
		{
			ExtendersProperties extProperty = (ExtendersProperties) m_ExtenderControls[imageButton];
			if( extProperty == null ) return -1;
			else return extProperty.NormalLeaveImageIndex;
		}
		public void SetNormalLeaveImageIndex(BorisBord.WinForms.ImageButton imageButton, int index) 
		{	
			ExtendersProperties currentButton;
			if (!m_initializing)
				if (index>m_ImageList.Images.Count)index=m_ImageList.Images.Count-1;//-1;				
			if (index>=0) 
			{
				currentButton = IsPropertiesExists(imageButton) ;			
				currentButton.NormalLeaveImageIndex=index;				
			}
			else 
			{
				if ((currentButton = (ExtendersProperties) m_ExtenderControls[imageButton])!=null)
				{
					currentButton.NormalLeaveImageIndex=-1;			
					if(IsEmpty(currentButton)) m_ExtenderControls.Remove(currentButton);;
				}
			}
		
		}
		
		private bool ShouldSerializeNormalLeaveImageIndex(BorisBord.WinForms.ImageButton imageButton)
		{
			if( GetNormalLeaveImageIndex(imageButton) >= 0 )
				return true;
			else
				return false;
		}

		[Category("Extender Property")]		
		public int GetNormalPressImageIndex(BorisBord.WinForms.ImageButton imageButton) 
		{
			ExtendersProperties extProperty = (ExtendersProperties) m_ExtenderControls[imageButton];
			if( extProperty == null ) return -1;
			else return extProperty.NormalPressImageIndex;
		}
		public void SetNormalPressImageIndex(BorisBord.WinForms.ImageButton imageButton, int index) 
		{				
			ExtendersProperties currentButton;
			if (!m_initializing)
				if (index>m_ImageList.Images.Count)index=m_ImageList.Images.Count-1;//-1;				
			if (index>=0) 
			{
				currentButton = IsPropertiesExists(imageButton) ;			
				currentButton.NormalPressImageIndex=index;		
			}
			else 
			{
				if ((currentButton = (ExtendersProperties) m_ExtenderControls[imageButton])!=null)
				{
					currentButton.NormalPressImageIndex=-1;			
					if(IsEmpty(currentButton)) m_ExtenderControls.Remove(currentButton);;
				}
			}		
		}
		private bool ShouldSerializeNormalPressImageIndex(BorisBord.WinForms.ImageButton imageButton)
		{
			if( GetNormalPressImageIndex(imageButton) >= 0 )
				return true;
			else
				return false;
		}
		

		[Category("Extender Property")]		
		public int GetNormalEnterImageIndex(BorisBord.WinForms.ImageButton imageButton) 
		{
			ExtendersProperties extProperty = (ExtendersProperties) m_ExtenderControls[imageButton];
			if( extProperty == null ) return -1;
			else return extProperty.NormalEnterImageIndex;
		}
		public void SetNormalEnterImageIndex(BorisBord.WinForms.ImageButton imageButton, int index) 
		{				
			ExtendersProperties currentButton;
			if (!m_initializing)
				if (index>m_ImageList.Images.Count)index=m_ImageList.Images.Count-1;//-1;				
			if (index>=0) 
			{
				currentButton = IsPropertiesExists(imageButton) ;			
				currentButton.NormalEnterImageIndex=index;	
			}
			else 
			{
				if ((currentButton = (ExtendersProperties) m_ExtenderControls[imageButton])!=null)
				{
					currentButton.NormalEnterImageIndex =-1;			
					if(IsEmpty(currentButton)) m_ExtenderControls.Remove(currentButton);;
				}
			}		
			
		}
		private bool ShouldSerializeNormalEnterImageIndex(BorisBord.WinForms.ImageButton imageButton)
		{
			if( GetNormalEnterImageIndex(imageButton) >= 0 )
				return true;
			else
				return false;
		}

		#endregion

		#region Checked...ImageIndex
		
		[Category("Extender Property")]		
		public int GetCheckedDisableImageIndex(BorisBord.WinForms.ImageButton imageButton) 
		{
			ExtendersProperties extProperty = (ExtendersProperties) m_ExtenderControls[imageButton];
			if( extProperty == null ) return -1;
			else return extProperty.CheckedDisableImageIndex;
		}

		public void SetCheckedDisableImageIndex(BorisBord.WinForms.ImageButton imageButton, int index) 
		{	
			ExtendersProperties currentButton;
			if (!m_initializing)
				if (index>m_ImageList.Images.Count)index=m_ImageList.Images.Count-1;//-1;				
			if (index>=0) 
			{
				currentButton = IsPropertiesExists(imageButton) ;			
				currentButton.CheckedDisableImageIndex=index;	
			}
			else 
			{
				if ((currentButton = (ExtendersProperties) m_ExtenderControls[imageButton])!=null)
				{
					currentButton.CheckedDisableImageIndex =-1;			
					if(IsEmpty(currentButton)) m_ExtenderControls.Remove(currentButton);;
				}
			}		

		}
		private bool ShouldSerializeCheckedDisableImageIndex(BorisBord.WinForms.ImageButton imageButton)
		{
			if( GetCheckedDisableImageIndex(imageButton) >= 0 )
				return true;
			else
				return false;
		}
		

		[Category("Extender Property")]		
		public int GetCheckedLeaveImageIndex(BorisBord.WinForms.ImageButton imageButton) 
		{
			ExtendersProperties extProperty = (ExtendersProperties) m_ExtenderControls[imageButton];
			if( extProperty == null ) return -1;
			else return extProperty.CheckedLeaveImageIndex;
		}
		public void SetCheckedLeaveImageIndex(BorisBord.WinForms.ImageButton imageButton, int index) 
		{	
			ExtendersProperties currentButton;
			if (!m_initializing)
				if (index>m_ImageList.Images.Count)index=m_ImageList.Images.Count-1;//-1;				
			if (index>=0) 
			{
				currentButton = IsPropertiesExists(imageButton) ;			
				currentButton.CheckedLeaveImageIndex=index;	
			}
			else 
			{
				if ((currentButton = (ExtendersProperties) m_ExtenderControls[imageButton])!=null)
				{
					currentButton.CheckedLeaveImageIndex =-1;			
					if(IsEmpty(currentButton)) m_ExtenderControls.Remove(currentButton);;
				}
			}				
		}
		private bool ShouldSerializeCheckedLeaveImageIndex(BorisBord.WinForms.ImageButton imageButton)
		{
			if( GetCheckedLeaveImageIndex(imageButton) >= 0 )
				return true;
			else
				return false;
		}
		

		[Category("Extender Property")]		
		public int GetCheckedPressImageIndex(BorisBord.WinForms.ImageButton imageButton) 
		{
			ExtendersProperties extProperty = (ExtendersProperties) m_ExtenderControls[imageButton];
			if( extProperty == null ) return -1;
			else return extProperty.CheckedPressImageIndex;
		}
		public void SetCheckedPressImageIndex(BorisBord.WinForms.ImageButton imageButton, int index) 
		{	
			ExtendersProperties currentButton;
			if (!m_initializing)
				if (index>m_ImageList.Images.Count)index=m_ImageList.Images.Count-1;//-1;				
			if (index>=0) 
			{
				currentButton = IsPropertiesExists(imageButton) ;			
				currentButton.CheckedPressImageIndex=index;	
			}
			else 
			{
				if ((currentButton = (ExtendersProperties) m_ExtenderControls[imageButton])!=null)
				{
					currentButton.CheckedPressImageIndex =-1;			
					if(IsEmpty(currentButton)) m_ExtenderControls.Remove(currentButton);;
				}
			}
			
			
		}
		private bool ShouldSerializeCheckedPressImageIndex(BorisBord.WinForms.ImageButton imageButton)
		{
			if( GetCheckedPressImageIndex(imageButton) >= 0 )
				return true;
			else
				return false;
		}
		

		[Category("Extender Property")]		
		public int GetCheckedEnterImageIndex(BorisBord.WinForms.ImageButton imageButton) 
		{			
			ExtendersProperties extProperty = (ExtendersProperties) m_ExtenderControls[imageButton];
			if( extProperty == null ) return -1;
			else return extProperty.CheckedEnterImageIndex;			
		}
		public void SetCheckedEnterImageIndex(BorisBord.WinForms.ImageButton imageButton, int index) 
		{	
			ExtendersProperties currentButton;
			if (!m_initializing)
				if (index>m_ImageList.Images.Count)index=m_ImageList.Images.Count-1;//-1;				
			if (index>=0) 
			{
				currentButton = IsPropertiesExists(imageButton) ;			
				currentButton.CheckedEnterImageIndex=index;	
			}
			else 
			{
				if ((currentButton = (ExtendersProperties) m_ExtenderControls[imageButton])!=null)
				{
					currentButton.CheckedEnterImageIndex =-1;			
					if(IsEmpty(currentButton)) m_ExtenderControls.Remove(currentButton);;
				}
			}				
		}
		private bool ShouldSerializeCheckedEnterImageIndex(BorisBord.WinForms.ImageButton imageButton)
		{
			if( GetCheckedEnterImageIndex(imageButton) >= 0 )
				return true;
			else
				return false;
		}

		#endregion

		[Category("Extender Property")]				
		public BorisBord.WinForms.IPaintHelper  GetPaintExtender(BorisBord.WinForms.ImageButton imageButton) 
		{
			ExtendersProperties extProperty = (ExtendersProperties) m_ExtenderControls[imageButton];
			if( extProperty == null ) return null;
			else return extProperty.PaintExtender;
		}
		public void SetPaintExtender(BorisBord.WinForms.ImageButton imageButton,BorisBord.WinForms.IPaintHelper paintExtender) 
		{		
			ExtendersProperties currentButton;
			if (paintExtender!=null) 
			{
				currentButton =IsPropertiesExists(imageButton);
				currentButton.PaintExtender=paintExtender;					
			}
			else 
			{
				if ((currentButton = (ExtendersProperties) m_ExtenderControls[imageButton])!=null)
				{
					currentButton.PaintExtender=null;
					if(IsEmpty(currentButton)) m_ExtenderControls.Remove(currentButton);;
				}		
			}
		}
		private bool ShouldSerializePaintExtender(BorisBord.WinForms.ImageButton imageButton)
		{
			if( GetPaintExtender(imageButton) !=null )
				return true;
			else
				return false;
		}
		

	#endregion		
		
	}
}
