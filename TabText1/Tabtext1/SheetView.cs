using System;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;


class SheetView : UserControl
{
	Sheets _Sheets;
	Int32 _SelectedIndex;

	public SheetView()
	{
		SetStyle(
			ControlStyles.AllPaintingInWmPaint |
			ControlStyles.UserPaint |
			ControlStyles.DoubleBuffer,
			true
			);

		_Sheets = new Sheets();
	}

	public Int32 SelectedIndex
	{
		get
		{
			return _SelectedIndex;
		}
		set
		{
			if (value > Sheets.Count - 1)
			{
				throw new ArgumentOutOfRangeException();
			}
			else
			{
				_SelectedIndex = value;

				// update control
				this.Invalidate();
				this.Update();

				// fire SelectionChanged event
				OnSelectionChanged(EventArgs.Empty);
			}
		}
	}

	public Sheets Sheets
	{
		get { return _Sheets; }
	}

	protected void RecalcLayout(Graphics g, Font boldFont)
	{
		Int32 offset = 0;
		SizeF size;

		for (Int32 i = 0; i < Sheets.Count; i++)
		{
			Sheet sheet = Sheets[i];
			sheet._X = offset;

			// measure string with bold font so tabs
			// wouldn't "jump" when selection changes

			size = g.MeasureString(sheet.Name, boldFont);

			sheet._Width = (Int32)size.Width;
			sheet._Margin = (Int32)(size.Width / 8);
			offset += 9 + sheet._Margin + sheet._Width + sheet._Margin + 9;
			offset -= 9;	// overlapping effect
		}
	}

	protected Point[] GetTabPoints(Sheet sheet)
	{
		Point[] points = new Point[4];

		Int32 height = this.ClientSize.Height;

		points[0] = new Point(sheet._X, 0);
		points[1] = new Point(sheet._X + 9, height - 1);
		points[2] = new Point(sheet._X + 9 + sheet._Margin + sheet._Width +
				 		 	  sheet._Margin, height - 1);
		points[3] = new Point(sheet._X + 9 + sheet._Margin + sheet._Width +
							  sheet._Margin + 9, 0);
		return points;
	}

	protected Region GetTabRegion(Sheet sheet)
	{
		GraphicsPath path = new GraphicsPath();
		path.AddLines(GetTabPoints(sheet));

		Region region = new Region(path);

		path.Dispose();

		return region;
	}

	protected void DrawTab(Graphics g, Int32 index, Font font, Brush textBrush,
						   Pen blackPen, Pen whitePen)
	{
		Sheet sheet = Sheets[index];

		Int32 height = this.ClientSize.Height;

		Point[] points = GetTabPoints(sheet);

		// tab background
		g.FillPolygon((index == this.SelectedIndex) ?
					  SystemBrushes.Control :
					  SystemBrushes.ControlDark,
					  points);

		// left highlight line
		g.DrawLine((index == this.SelectedIndex) ?
				   whitePen :
				   SystemPens.Control,
				   points[0].X + 1, points[0].Y,
				   points[1].X + 1, points[1].Y);

		// tab frame
		GraphicsPath path = new GraphicsPath();
		path.AddLines(points);
		g.DrawPath(blackPen, path);

		// tab name
		RectangleF rect = new RectangleF(
			sheet._X,
			0,
			9 + sheet._Margin + sheet._Width + sheet._Margin + 9,
			height
			);

		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = StringAlignment.Center;
		stringFormat.LineAlignment = StringAlignment.Center;
		g.DrawString(sheet.Name, font, textBrush, rect, stringFormat);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Font boldFont = new Font(this.Font, this.Font.Style | FontStyle.Bold);

		RecalcLayout(e.Graphics, boldFont);

		Pen blackPen = new Pen(Color.Black);
		Pen whitePen = new Pen(Color.White);
		Brush whiteBrush = new SolidBrush(Color.White);
		Brush blackBrush = new SolidBrush(Color.Black);

		// draw tabs from right to left because they overlap
		for (Int32 i = Sheets.Count - 1; i >= 0; i--)
		{
			if (i != this.SelectedIndex)
				DrawTab(e.Graphics, i, this.Font, whiteBrush, blackPen,
						whitePen);
		}

		// draw selected tab
		DrawTab(e.Graphics, this.SelectedIndex, boldFont, blackBrush, blackPen,
				whitePen);

		// draw top line
		Sheet sheet = Sheets[this.SelectedIndex];
		Point[] points = GetTabPoints(sheet);
		e.Graphics.DrawLine(blackPen, points[3].X, 0, this.ClientSize.Width, 0);

		whiteBrush.Dispose();
		blackBrush.Dispose();
		blackPen.Dispose();
		whitePen.Dispose();
	}

	protected Int32 HitTest(Point point)
	{
		// return index of tab which contains point
		// test in reverse order to take overlapping
		// into account

		for (Int32 i = Sheets.Count - 1; i >= 0; i--)
		{
			Region region = GetTabRegion(Sheets[i]);
			if (region.IsVisible(point))
			{
				if (i == this.SelectedIndex)
				{
					region.Dispose();
					return i;
				}

				// maybe in left overlapping part
				if (i - 1 >= 0)
				{
					Region rgn = GetTabRegion(Sheets[i - 1]);
					if (rgn.IsVisible(point))
					{
						rgn.Dispose();
						return i - 1;
					}
					rgn.Dispose();
				}

				region.Dispose();
				return i;
			}
			region.Dispose();
		}

		return -1;
	}

	public event EventHandler SelectionChanged;

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);

		Int32 index = HitTest(new Point(e.X, e.Y));
		if ((index != this.SelectedIndex) && (index >= 0))
		{
			// new index
			this.SelectedIndex = index;
		}
	}

	protected virtual void OnSelectionChanged(EventArgs e)
	{
		// fire SelectionChanged event
		if (SelectionChanged != null)
			SelectionChanged(this, new EventArgs());
	}
}

class Sheet
{
    String _Name;
    internal Int32 _X;
    internal Int32 _Width;	// width of text
    internal Int32 _Margin;	// before and after name

    public Sheet(String name)
    {
        _Name = name;
    }

    public String Name
    {
        get { return _Name; }
    }
}

class Sheets
{
    ArrayList _Sheets;

    public Sheets()
    {
        _Sheets = new ArrayList();

   
    }

    public Int32 Count
    {
        get { return _Sheets.Count; }
    }

    public Sheet this[Int32 index]
    {
        
       
        get { return (Sheet)_Sheets[index]; }
    
    
    }

    public void Add(Sheet sheet)
    {
        _Sheets.Add(sheet);
    }

    public void Clear()
    {
        _Sheets.Clear();
    }
}
