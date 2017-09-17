
using System.ComponentModel;
using System.Drawing;

namespace BorisBord.WinForms
{
	/// <summary>
	/// Summary description for HelpPainter.
	
	/// </summary>
	///
	[DefaultProperty("BorderColor")]	
	public class PaintHelper: System.ComponentModel.Component,BorisBord.WinForms.IPaintHelper
	{
		private System.Drawing.Color m_EnterBackColor;
		private System.Drawing.Color m_LeaveBackColor;
		private System.Drawing.Color m_CheckBackColor;
		private System.Drawing.Color m_PressBackColor;
		private System.Drawing.Color m_BorderColor;
		private System.Drawing.Color m_BackColor;
		private System.Byte m_Alpha;

		#region default source
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PaintHelper(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();			
		}

		public PaintHelper()
		{
			InitializeComponent();
			m_BackColor=m_LeaveBackColor;
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
			components = new System.ComponentModel.Container();
		}
		#endregion

		#endregion

		#region property
		[Category("ExtenderBackColors")]			
		public System.Drawing.Color LeaveBackColor
		{
			get
			{
				return m_LeaveBackColor;
			}
			set
			{
				m_LeaveBackColor=value;
			}
		}

		[Category("ExtenderBackColors")]	
		public System.Drawing.Color CheckBackColor
		{
			get
			{
				return m_CheckBackColor;
			}
			set
			{
				m_CheckBackColor=value;
			}
		}

		[Category("ExtenderBackColors")]	
		public System.Drawing.Color EnterBackColor
		{
			get
			{
				return m_EnterBackColor;
			}
			set
			{
				m_EnterBackColor=value;
			}
		}

		[Category("ExtenderBackColors")]	
		public System.Drawing.Color PressBackColor
		{
			get
			{
				return m_PressBackColor;
			}
			set
			{
				m_PressBackColor=value;
			}
		}
		[Category("MyColors")]
		public System.Drawing.Color BorderColor
		{
			get
			{
				return m_BorderColor;
			}
			set
			{
				m_BorderColor=value;
			}
		}
		[Category("MyColors")]			
		public System.Byte Alpha
		{
			get
			{
				return m_Alpha;
			}
			set
			{
				m_Alpha=value;
			}
		}
		[Browsable(false)]	
		public System.Drawing.Color BackColor
		{
			get
			{
				return m_BackColor;
			}
			set
			{
				m_BackColor=value;
			}
		}
		#endregion

		virtual public void Paint(object sender, System.Windows.Forms.PaintEventArgs pe)
		{
		}
	}
				 
	
	public class PaintHelperRhomb : PaintHelper
	{		
		#region default source
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PaintHelperRhomb(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}

		public PaintHelperRhomb()
		{			
			InitializeComponent();
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
			components = new System.ComponentModel.Container();
		}
		#endregion

		#endregion

		override public void Paint(object sender, System.Windows.Forms.PaintEventArgs pe)
		{	
					
			BorisBord.WinForms.ImageButton tabButton = sender as BorisBord.WinForms.ImageButton;
			if (tabButton==null) return;
			string text=tabButton.Text;							
			System.Drawing.Image image = tabButton.Image;
			System.Drawing.Color textColor = tabButton.Enabled?tabButton.ForeColor:System.Drawing.Color.Gray;						                    
			System.Drawing.SizeF sizeText = pe.Graphics.MeasureString(text, tabButton.Font);
			System.Drawing.SizeF sizeInterval = pe.Graphics.MeasureString("A", tabButton.Font);

			#region highlight rhomb
			
			if (tabButton.Entered) 
			{				
				BackColor=System.Drawing.Color.FromArgb(Alpha, EnterBackColor);
				if (tabButton.Pressed) 	BackColor=System.Drawing.Color.FromArgb(Alpha, PressBackColor);					
			}
			else
			{
				if (tabButton.Checked) 	
					BackColor=System.Drawing.Color.FromArgb(Alpha, CheckBackColor);
				else 
					BackColor=LeaveBackColor;
			}
			if (!tabButton.Enabled) BackColor=System.Drawing.Color.FromArgb(Alpha,System.Drawing.Color.Gray);						
			System.Drawing.Point[] Points = new System.Drawing.Point[]
							{						
								new System.Drawing.Point((int)tabButton.Size.Width/2, 0),
								new System.Drawing.Point((int)tabButton.Size.Width, (int)tabButton.Size.Height/2),								
								new System.Drawing.Point((int)tabButton.Size.Width/2, (int)tabButton.Size.Height),
								new System.Drawing.Point(0, (int)tabButton.Size.Height/2),								
								new System.Drawing.Point((int)tabButton.Size.Width/2, 0)
							};						
			pe.Graphics.FillPolygon(new System.Drawing.SolidBrush(BackColor), Points);

			if (tabButton.Entered||tabButton.Checked)
			{
				System.Drawing.Pen Pen;
				Pen = new System.Drawing.Pen(new System.Drawing.SolidBrush(BorderColor), 0);			 			
				Pen.StartCap = System.Drawing.Drawing2D.LineCap.Square;
				Pen.EndCap	 = System.Drawing.Drawing2D.LineCap.Square;				
				pe.Graphics.DrawLines(Pen, Points);
			}
			
			#endregion
			
			#region Paint Text and Image	
			if (tabButton.OwnerDraw)
			{
				if (image != null)						
				{
					#region 
					int dy=(tabButton.Size.Height- image.Height)/ 2;
					if(text.Length >0)
					{
					
						System.Drawing.Point dPoint= new System.Drawing.Point((int)sizeInterval.Width,dy);

						pe.Graphics.DrawImageUnscaled(image,dPoint );							
				
						pe.Graphics.DrawString(text, tabButton.Font, new System.Drawing.SolidBrush(textColor), 
							new System.Drawing.RectangleF( 
							dPoint.X+image.Width+sizeInterval.Width,(tabButton.Size.Height- sizeText.Height)/ 2, image.Width+3*sizeInterval.Width+sizeText.Width, image.Height-(tabButton.Size.Height- sizeText.Height)/ 2));
					}
					else
					{
											
						pe.Graphics.DrawImageUnscaled(image, (tabButton.Size.Width- image.Width)/ 2,dy);											
					}
					#endregion
				}	
				else 				
				{	
					#region 
					if(text.Length >0)
					{						
						tabButton.Width=(int)(sizeInterval.Width+sizeText.Width+sizeInterval.Width);
						tabButton.Height=(int)sizeText.Height+6;	
						System.Drawing.Point pp= new System.Drawing.Point((int)sizeInterval.Width,0);
						pe.Graphics.DrawString(text, tabButton.Font, new System.Drawing.SolidBrush(textColor), 
							new System.Drawing.RectangleF( 
							pp.X,3, 2*sizeInterval.Width+sizeText.Width, sizeText.Height));		
									
					}
					else
					{						
					}
					#endregion
				}
			}
			#endregion						
		}

	}

	
	public class PaintHelperRect : PaintHelper
	{		
		#region default 
		private System.ComponentModel.Container components = null;

		public PaintHelperRect()
		{
			InitializeComponent();
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		public PaintHelperRect(System.ComponentModel.IContainer container) : this()
		{
			container.Add(this);
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

		#endregion

		override public void Paint(object sender, System.Windows.Forms.PaintEventArgs pe)
		{	
					
			BorisBord.WinForms.ImageButton tabButton = sender as BorisBord.WinForms.ImageButton;
			if (tabButton==null) return;

			string text=tabButton.Text;		
			System.Drawing.Color textColor = tabButton.Enabled?tabButton.ForeColor:System.Drawing.Color.Gray;				                    		
			System.Drawing.Image image = tabButton.Image;			
			System.Drawing.SizeF sizeText = pe.Graphics.MeasureString(text, tabButton.Font);
			System.Drawing.SizeF sizeInterval = pe.Graphics.MeasureString("A", tabButton.Font);			
			
			#region highlight bar
			
			if (tabButton.Entered) 
			{				
				BackColor=System.Drawing.Color.FromArgb(Alpha, EnterBackColor);
				if (tabButton.Pressed) 	BackColor=System.Drawing.Color.FromArgb(Alpha,PressBackColor);					
			}
			else
			{
				if (tabButton.Checked) 	
					BackColor=System.Drawing.Color.FromArgb(Alpha,CheckBackColor);
				else 
					BackColor=(LeaveBackColor);
			}
			
						
			pe.Graphics.FillRectangle(new System.Drawing.SolidBrush(BackColor), 0, 0, tabButton.Size.Width, tabButton.Size.Height);

			if (tabButton.Entered||tabButton.Checked)
			{
				System.Drawing.Pen Pen;
				Pen = new System.Drawing.Pen(new System.Drawing.SolidBrush(BorderColor), 0);			 			
				Pen.StartCap = System.Drawing.Drawing2D.LineCap.Square;
				Pen.EndCap	 = System.Drawing.Drawing2D.LineCap.Square;
				System.Drawing.Point[] Points = new System.Drawing.Point[]
							{
								new System.Drawing.Point(0, 0),
								new System.Drawing.Point(tabButton.Size.Width- 1, 0),
								new System.Drawing.Point(tabButton.Size.Width- 1, tabButton.Size.Height- 1),
								new System.Drawing.Point(0, tabButton.Size.Height- 1),
								new System.Drawing.Point(0, 0)
							};
				pe.Graphics.DrawLines(Pen, Points);
			}
			
			#endregion
			
			
			#region Paint Text and Image	
			if (tabButton.OwnerDraw)
			{
				if (image != null)						
				{
					#region 	
					int dy=(tabButton.Size.Height- image.Height)/ 2;
					if(text.Length >0)
					{		
						#region Paint Icon+Text
						System.Drawing.Point dPoint= new System.Drawing.Point((int)sizeInterval.Width,dy);

						pe.Graphics.DrawImageUnscaled(image,dPoint );							
				
						pe.Graphics.DrawString(text, tabButton.Font, new System.Drawing.SolidBrush(textColor), 
							new System.Drawing.RectangleF( 
							dPoint.X+image.Width+sizeInterval.Width,(tabButton.Size.Height- sizeText.Height)/ 2, image.Width+3*sizeInterval.Width+sizeText.Width, tabButton.Size.Height-(tabButton.Size.Height- sizeText.Height)/ 2));
						#endregion
					}
					else
					{
						#region Paint Icon							
						int x=(int)(tabButton.Size.Width- image.Width)/ 2;
						int y=dy;	
						if (tabButton.Enabled)
						{
							#region Enable=true
							if (tabButton.Entered)
							{
								System.Windows.Forms.ControlPaint.DrawImageDisabled(pe.Graphics,image,x+1,y+1,BackColor);
								x-=1;y-=1;
							}								
							if(tabButton.Pressed)
							{
								x+=1;y+=1;
							}
							pe.Graphics.DrawImage(image, x,y);	
							#endregion			
						}
						else 		
							System.Windows.Forms.ControlPaint.DrawImageDisabled(pe.Graphics,image,x,y,BackColor);
						#endregion
					}
					#endregion
				}	
				else 				
				{	
					#region Paint Text
					if(text.Length >0)
					{	
						tabButton.Height=(int)sizeText.Height+6;	
						System.Drawing.Point pp= new System.Drawing.Point((int)sizeInterval.Width,0);
						pe.Graphics.DrawString(text, tabButton.Font, new System.Drawing.SolidBrush(textColor), 
							new System.Drawing.RectangleF( 
							pp.X,3, 2*sizeInterval.Width+sizeText.Width, sizeText.Height));		
									
					}
					else
					{						
					}
					#endregion
				}
			}
			#endregion			
		}
	}
	
	
	public class PaintHelperEllipse : PaintHelper
	{
		#region default

		private System.ComponentModel.Container components = null;

		public PaintHelperEllipse()
		{
			InitializeComponent();
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		public PaintHelperEllipse(System.ComponentModel.IContainer container) : this()
		{
			container.Add(this);
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

		#endregion		

		override public void Paint(object sender, System.Windows.Forms.PaintEventArgs pe)
		{	
					
			BorisBord.WinForms.ImageButton tabButton = sender as BorisBord.WinForms.ImageButton;
			if (tabButton==null) return;

			#region highlight Ellipse
			
			if (tabButton.Entered) 
			{				
				BackColor=System.Drawing.Color.FromArgb(Alpha, EnterBackColor);
				if (tabButton.Pressed) 	BackColor=System.Drawing.Color.FromArgb(Alpha, PressBackColor);					
			}
			else
			{
				if (tabButton.Checked) 	
					BackColor=System.Drawing.Color.FromArgb(Alpha,CheckBackColor);
				else 
					BackColor=LeaveBackColor;
			}			
			if (!tabButton.Enabled) BackColor=System.Drawing.Color.FromArgb(Alpha,System.Drawing.Color.Gray);						
			pe.Graphics.FillEllipse(new System.Drawing.SolidBrush(BackColor), 0, 0, tabButton.Size.Width-1, tabButton.Size.Height-1);

			if (tabButton.Entered||tabButton.Checked)
			{
				System.Drawing.Pen Pen;
				Pen = new System.Drawing.Pen(new System.Drawing.SolidBrush(BorderColor), 0);			 			
				Pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
				Pen.EndCap	 = System.Drawing.Drawing2D.LineCap.Round;
				pe.Graphics.DrawEllipse(Pen,0,0,tabButton.Size.Width-1,tabButton.Size.Height-1);
			}
			
			#endregion
			
			#region Paint Text and Image
			string text=tabButton.Text;		
			System.Drawing.Color textColor = tabButton.Enabled?tabButton.ForeColor:System.Drawing.Color.Gray;		//???????				                    		
			System.Drawing.Image image = tabButton.Image;			
			System.Drawing.SizeF sizeText = pe.Graphics.MeasureString(text, tabButton.Font);
			System.Drawing.SizeF sizeInterval = pe.Graphics.MeasureString("A", tabButton.Font);				
			if (tabButton.OwnerDraw)
			{						
			
				if (image != null)						
				{
					#region image != null
					if(text.Length >0)
					{					
						System.Drawing.Point pp= new System.Drawing.Point((int)sizeInterval.Width,0);
						pe.Graphics.DrawImageUnscaled(image,pp );							
						pe.Graphics.DrawString(text, tabButton.Font, new System.Drawing.SolidBrush(textColor), 
							new System.Drawing.RectangleF( 
							pp.X+image.Width+sizeInterval.Width,3, image.Width+3*sizeInterval.Width+sizeInterval.Width, sizeInterval.Height));						
					}
					else
					{		
						pe.Graphics.DrawImageUnscaled(image, (tabButton.Size.Width- image.Width)/ 2, (tabButton.Size.Height- image.Height)/ 2);						
					}
					#endregion
				}	
				else 							
				{	
					#region image == null
					if(text.Length >0)
					{						
						System.Drawing.Point pp= new System.Drawing.Point((int)sizeInterval.Width,0);
						pe.Graphics.DrawString(text, tabButton.Font, new System.Drawing.SolidBrush(textColor), 
							new System.Drawing.RectangleF( 
							pp.X,3, 2*sizeInterval.Width+sizeInterval.Width, sizeInterval.Height));		
					}
					else
					{
					}
					#endregion
				}
			}
			#endregion			
		}

	}
	
	
	public class PaintHelperRect2 : PaintHelper
	{

		#region default

		private System.ComponentModel.Container components = null;

		public PaintHelperRect2()
		{
			InitializeComponent();
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		public PaintHelperRect2(System.ComponentModel.IContainer container) : this()
		{
			container.Add(this);
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

		#endregion

		override public void Paint(object sender, System.Windows.Forms.PaintEventArgs pe)
		{	
					
			BorisBord.WinForms.ImageButton tabButton = sender as BorisBord.WinForms.ImageButton;
			if (tabButton==null) return;

			string text=tabButton.Text;		
			System.Drawing.Color textColor = tabButton.Enabled?tabButton.ForeColor:System.Drawing.Color.Gray;					                    		
			System.Drawing.Image image = tabButton.Image;			
			System.Drawing.SizeF sizeText = pe.Graphics.MeasureString(text, tabButton.Font);
			System.Drawing.SizeF sizeInterval = pe.Graphics.MeasureString("A", tabButton.Font);
			
			
			#region highlight bar
			
			if (tabButton.Entered) 
			{				
				BackColor=System.Drawing.Color.FromArgb(Alpha, EnterBackColor);
				if (tabButton.Pressed) 	BackColor=System.Drawing.Color.FromArgb(Alpha,PressBackColor);					
			}
			else
			{
				if (tabButton.Checked) 	
					BackColor=System.Drawing.Color.FromArgb(Alpha,CheckBackColor);
				else 
					BackColor=(LeaveBackColor);
			}
			if (!tabButton.Enabled) BackColor=System.Drawing.Color.FromArgb(Alpha,System.Drawing.Color.Gray);						
						
			pe.Graphics.FillRectangle(new System.Drawing.SolidBrush(BackColor), 0, 0, tabButton.Size.Width, tabButton.Size.Height);

			if (tabButton.Entered||tabButton.Checked)
			{
				System.Drawing.Pen Pen;
				Pen = new System.Drawing.Pen(new System.Drawing.SolidBrush(BorderColor), 0);			 			
				Pen.StartCap = System.Drawing.Drawing2D.LineCap.Square;
				Pen.EndCap	 = System.Drawing.Drawing2D.LineCap.Square;
				System.Drawing.Point[] Points = new System.Drawing.Point[]
						{
							new System.Drawing.Point(0, 0),
							new System.Drawing.Point(tabButton.Size.Width- 1, 0),
							new System.Drawing.Point(tabButton.Size.Width- 1, tabButton.Size.Height- 1),
							new System.Drawing.Point(0, tabButton.Size.Height- 1),
							new System.Drawing.Point(0, 0)
						};
				pe.Graphics.DrawLines(Pen, Points);
			}
			
			#endregion			
			
			#region Paint Text and Image	
			
			if (tabButton.OwnerDraw)
			{
				if (image != null)						
				{
					#region 

	
					int dy=(tabButton.Size.Height- image.Height)/ 2;
					if(text.Length >0)
					{						
						System.Drawing.Point dPoint= new System.Drawing.Point((int)sizeInterval.Width,dy);

						pe.Graphics.DrawImageUnscaled(image,dPoint );							
				
						pe.Graphics.DrawString(text, tabButton.Font, new System.Drawing.SolidBrush(textColor), 
							new System.Drawing.RectangleF( 
							dPoint.X+image.Width+sizeInterval.Width,(tabButton.Size.Height- sizeText.Height)/ 2, image.Width+3*sizeInterval.Width+sizeText.Width, tabButton.Size.Height-(tabButton.Size.Height- sizeText.Height)/ 2));
					}
					else
					{	
						pe.Graphics.DrawImageUnscaled(image, (tabButton.Size.Width- image.Width)/ 2,dy);											
					}
					#endregion
				}	
				else 				
				{	
					#region 
					if(text.Length >0)
					{	
							
						System.Drawing.Point pp= new System.Drawing.Point((int)sizeInterval.Width,0);
						pe.Graphics.DrawString(text, tabButton.Font, new System.Drawing.SolidBrush(textColor), 
							new System.Drawing.RectangleF( 
							pp.X,3, 2*sizeInterval.Width+sizeText.Width, sizeText.Height));										
					}
					else
					{						
					}
					#endregion
				}
			}
			else	
			if(text.Length >0)
			{
				#region
				System.Drawing.Font font=new Font(tabButton.Font,System.Drawing.FontStyle.Bold);
											
				System.Drawing.Point pp= new System.Drawing.Point((int)(int)(tabButton.Width-sizeText.Width)/2,(int)(tabButton.Height-sizeText.Height)/2);
				pe.Graphics.DrawString(text, font, new System.Drawing.SolidBrush(textColor), 
					new System.Drawing.RectangleF( 
					pp.X,pp.Y,pp.X+sizeText.Width , pp.Y+sizeText.Height));		
				#endregion					
			}
			
			#endregion			
		}
	}

}

	


		


		


