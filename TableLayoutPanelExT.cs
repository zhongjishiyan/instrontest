using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
namespace TabHeaderDemo
{

   public class TableLayoutPanelExT : TableLayoutPanel
	{
       
       [DllImport("user32.dll")]
          public static extern bool ReleaseCapture();
          [DllImport("user32.dll")]
          public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
		
		private const int WM_NCHITTEST = 0x84;
		private const int WM_MOUSEMOVE = 0x200;
		private const int WM_LBUTTONDOWN = 0x201;
		private const int WM_LBUTTONUP = 0x202;
		private const int MK_LBUTTON = 0x1;
		
		private List<int> VBorders = new List<int>();
		private List<int> HBorders = new List<int>();
		private int selColumn = -1;
		private int selRow = -1;

        private int mselcol = -1;
        private int mselrow = -1;

        private bool mrunbool = false;

        public  bool  RunBool
        {
            get { return mrunbool; }
            set { mrunbool = value; }
        }

        

        private  List<int> x1 = new List<int>();

        public int SelectColumn
        {
            get { return mselcol;}
            set { mselcol = value; }
        }


        public int SelectRow
        {
            get { return mselrow ; }
            set { mselrow = value; }
        }

		public TableLayoutPanelExT()
		{
			this.DoubleBuffered = true;
			this.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
		}
		
		protected override void OnHandleCreated(System.EventArgs e)
		{
			base.OnHandleCreated(e);
			if (!this.DesignMode)
			{
				ResetSizeAndSizeTypes();
			}
		}
		
		public new int ColumnCount
		{
			get
			{
				return base.ColumnCount;
			}
			set
			{
				base.ColumnCount = value;
				if (this.Created && !this.DesignMode)
				{
					ResetSizeAndSizeTypes();
				}
			}
		}
		
		public new int RowCount
		{
			get
			{
				return base.RowCount;
			}
			set
			{
				base.RowCount = value;
				if (this.Created && !this.DesignMode)
				{
					ResetSizeAndSizeTypes();
				}
			}
		}

        

		public void ResetSizeAndSizeTypes()
		{
			float cW = System.Convert.ToSingle((this.ClientSize.Width / this.GetColumnWidths().Length) - 1);
			for (int c = 0; c <= this.GetColumnWidths().Length - 1; c++)
			{
				this.ColumnStyles[c].SizeType = SizeType.Absolute;
				this.ColumnStyles[c].Width = cW;
			}
			
			float cH = System.Convert.ToSingle((this.ClientSize.Height / this.GetRowHeights().Length) - 1);
			for (int r = 0; r <= this.GetRowHeights().Length - 1; r++)
			{
				this.RowStyles[r].SizeType = SizeType.Absolute;
				this.RowStyles[r].Height = cH;
			}
		}

        public void getxy(int x, int y)
        {

            Point  loc = new Point(x, y);

           // Point loc = this.PointToClient(Point1 );

            x1.Clear();
            int w = 0;

            for (int c = 0; c < this.ColumnCount; c++)
            {
                w = 0;
                for (int i = 0; i <= c; i++)
                {
                    w = w + this.GetColumnWidths()[i];
                }
                x1.Add(w);
            }
            for (int c = 0; c < this.ColumnCount; c++)
            {

                if (loc.X < x1[c])
                {
                    this.mselcol = c;
                    break;
                }
            }

            x1.Clear();
            for (int r = 0; r < this.RowCount; r++)
            {
                w = 0;
                for (int i = 0; i <= r; i++)
                {
                    w = w + this.GetRowHeights()[i];
                }
                x1.Add(w);
            }

            for (int r = 0; r < this.RowCount; r++)
            {
                if (loc.Y < x1[r])
                {
                    this.mselrow = r;
                    break;
                }
            }
        }
		protected override void WndProc(ref System.Windows.Forms.Message m)
		{
			base.WndProc(ref m);
			if (this.Created && !this.Disposing)
			{
				if (m.Msg == WM_NCHITTEST)
				{
					Point loc = this.PointToClient(MousePosition);
					VBorders.Clear();
					HBorders.Clear();
					if (this.ColumnCount > 1)
					{
						for (int w = 0; w <= this.GetColumnWidths().Length - 1; w++)
						{
							if (w == 0)
							{
								VBorders.Add(this.GetColumnWidths()[w]);
							}
							else
							{
								VBorders.Add(VBorders[VBorders.Count - 1] + this.GetColumnWidths()[w]);
							}
						}
					}
					if (this.RowCount > 1)
					{
						for (int h = 0; h <= this.GetRowHeights().Length - 1; h++)
						{
							if (h == 0)
							{
								HBorders.Add(this.GetRowHeights()[h]);
							}
							else
							{
								HBorders.Add(HBorders[HBorders.Count - 1] + this.GetRowHeights()[h]);
                              
							}
						}
					}
					
					bool onV = System.Convert.ToBoolean(VBorders.Contains(loc.X) || VBorders.Contains(loc.X - 1) || VBorders.Contains(loc.X + 1));
					bool onH = System.Convert.ToBoolean(HBorders.Contains(loc.Y) || HBorders.Contains(loc.Y - 1) || HBorders.Contains(loc.Y + 1));
                  

					if (onV && onH)
					{
						this.Cursor = Cursors.SizeAll;
					}
					else if (onV)
					{
						this.Cursor = Cursors.VSplit;
					}
					else if (onH)
					{
						this.Cursor = Cursors.HSplit;
					}
					else
					{
						this.Cursor = Cursors.Default;
					}

					
				}
				else if (m.Msg == WM_LBUTTONDOWN && this.Cursor != Cursors.Default)
				{
                    GlobeVal.resizing = true;
					Point loc = this.PointToClient(MousePosition);
					selColumn = -1;
					selRow = -1;
					for (int c = 0; c <= VBorders.Count - 1; c++)
					{
						if (VBorders[c] >= loc.X - 1 && VBorders[c] <= loc.X + 1)
						{
							selColumn = c;
							break;
						}
					}
					for (int r = 0; r <= HBorders.Count - 1; r++)
					{
						if (HBorders[r] >= loc.Y - 1 && HBorders[r] <= loc.Y + 1)
						{
							selRow = r;
							break;
						}
					}
					
				}
                else if (m.Msg == WM_MOUSEMOVE)
                {
                    Point loc = this.PointToClient(MousePosition);

                    x1.Clear();
                    int w=0;
                    
                    for (int c = 0; c <this.ColumnCount ; c++)
                    {
                        w = 0;
                        for (int i=0;i<=c;i++)
                        {
                          w=w+this.GetColumnWidths()[i];  
                        }
                        x1.Add(w);
                    }
                    for (int c = 0; c <this.ColumnCount; c++)
                    {

                        if (loc.X < x1[c])
                        {
                            this.mselcol = c;
                            break;
                        }
                    }

                    x1.Clear();
                    for (int r = 0; r < this.RowCount; r++)
                    {
                        w = 0;
                        for (int i = 0; i <= r; i++)
                        {
                            w = w + this.GetRowHeights()[i];
                        }
                        x1.Add(w);
                    }

                    for (int r = 0; r < this.RowCount; r++)
                    {
                        if (loc.Y < x1[r])
                        {
                            this.mselrow = r;
                            break;
                        }
                    }

                    if (m.WParam.ToInt32() == MK_LBUTTON)
                    {
                        GlobeVal.resizing = false;

                        if (this.Cursor != Cursors.Default)
                        {

                            if (selRow > -1 & loc.Y >= 1 & loc.Y <= this.ClientSize.Height - 2)
                            {
                                this.RowStyles[selRow].SizeType = SizeType.Absolute;

                                float @ref = loc.Y - this.RowStyles[selRow].Height;
                               
                                if (selRow > 0)
                                {
                                    

                                   @ref -= HBorders[selRow - 1];

                                  

                                }

                                if (this.RowStyles[selRow].Height + @ref > 0)
                                {
                                    if (this.mrunbool ==false)
                                    {
                                      if (this.RowCount > selRow + 1)
                                    {
                                       if (this.RowStyles[selRow + 1].Height - @ref < 1)
                                        {
                                        return;
                                        }
                                        this.RowStyles[selRow + 1].Height -= @ref;
                                    }
                                    }


                                    this.RowStyles[selRow].Height += @ref;
                                }
                            }

                            if (selColumn > -1 & loc.X >= 1 & loc.X <= this.ClientSize.Width - 2)
                            {
                                this.ColumnStyles[selColumn].SizeType = SizeType.Absolute;

                                float @ref = loc.X - this.ColumnStyles[selColumn].Width;
                                if (selColumn > 0)
                                {
                                    @ref -= VBorders[selColumn - 1];
                                }

                                if (this.ColumnStyles[selColumn].Width + @ref > 0)
                                {
                                    if (this.mrunbool == false)
                                    {
                                        if (this.ColumnCount > selColumn + 1)
                                        {
                                            if (this.ColumnStyles[selColumn + 1].Width - @ref < 1)
                                            {
                                                return;
                                            }
                                            this.ColumnStyles[selColumn + 1].Width -= @ref;
                                        }
                                    }

                                    this.ColumnStyles[selColumn].Width += @ref;
                                }

                            }

                        }

                    }
                     
                     

                }

                else if (m.Msg == WM_LBUTTONUP)
                {
                    

                    
                    selColumn = -1;
                    selRow = -1;
                }
			}
		}

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TableLayoutPanelExT
            // 
            this.Name = "TableLayoutPanelExT";
            this.ResumeLayout(false);

        }
	}


}
