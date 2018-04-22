using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace TabHeaderDemo.SControls
{
    public class ListViewPro : ListView
    {

        public int curstep = 1;

        #region Windows API

        /*
        struct MEASUREITEMSTRUCT 
        {
            public int    CtlType;     // Offset = 0
            public int    CtlID;       // Offset = 1
            public int    itemID;      // Offset = 2
            public int    itemWidth;   // Offset = 3
            public int    itemHeight;  // Offset = 4
            public IntPtr itemData;
        }
        */

        [StructLayout(LayoutKind.Sequential)]
        struct DRAWITEMSTRUCT
        {
            public int ctlType;
            public int ctlID;
            public int itemID;
            public int itemAction;
            public int itemState;
            public IntPtr hWndItem;
            public IntPtr hDC;
            public int rcLeft;
            public int rcTop;
            public int rcRight;
            public int rcBottom;
            public IntPtr itemData;
        }

        // LVS_OWNERDRAWFIXED: The owner window can paint ListView items in report view. 
        // The ListView control sends a WM_DRAWITEM message to paint each item. It does not send separate messages for each subitem. 
        const int LVS_OWNERDRAWFIXED = 0x0400;
        const int WM_SHOWWINDOW = 0x0018;
        const int WM_DRAWITEM = 0x002B;
        const int WM_MEASUREITEM = 0x002C;
        const int WM_REFLECT = 0x2000;

        #endregion

        bool mb_Measured = false;
        int ms32_RowHeight = 25;


        public ListViewPro() :
            base()
        {
            this.OwnerDraw = true;//用于启用重绘
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, ms32_RowHeight);
            SmallImageList = imgList;

        }

        [Description("Sets the height of the ListView rows in Details view in pixels.")]
        public int RowHeight
        {
            get { return ms32_RowHeight; }
            set
            {
                if (!DesignMode) Debug.Assert(mb_Measured == false, "RowHeight must be set before ListViewEx is created.");
                ms32_RowHeight = value;
            }
        }




        /// <summary>
        /// The messages WM_MEASUREITEM and WM_DRAWITEM are sent to the parent control rather than to the ListView itself.
        /// They come here as WM_REFLECT + WM_MEASUREITEM and WM_REFLECT + WM_DRAWITEM
        /// They are sent from Control.WmOwnerDraw() --> Control.ReflectMessageInternal()
        /// </summary>

        /// <summary>
        /// 图标
        /// </summary>
        public Image Icon { get; set; }

        /// <summary>
        /// 重绘图标
        /// </summary>
        public bool IsDrawIcon { get; set; }

        /// <summary>
        /// 重绘网格线
        /// </summary>
        public bool IsDrawGridLines { get; set; }

        /// <summary>
        /// 重绘图标列
        /// </summary>
        /// <param name="e"></param>
        ///   private void listViewEx1_DrawItem(object sender, DrawListViewItemEventArgs e)
        ///   

        public Rectangle getsubitemrect(int row, int col)
        {
            Rectangle r = GetItemRect(row, ItemBoundsPortion.Entire);

            int x = 0;
            for (int i = 0; i < col; i++)
            {
                x = x + this.Columns[i].Width;

            }
            r.X = x + 3;
            r.Width = this.Columns[col].Width - 3;

            return r;
        }

        public Rectangle getsubitemmidrect(int row, int col)
        {
            Rectangle r = GetItemRect(row, ItemBoundsPortion.Entire);

            int x = 0;
            for (int i = 0; i < col; i++)
            {
                x = x + this.Columns[i].Width;

            }
            r.X = x + 3;
            
            r.Width = this.Columns[col].Width - 3;
            r.X = r.X + r.Width / 2;
            r.Width = 1;

            return r;
        }
        private void DrawArrow(DrawListViewItemEventArgs e, int x1, int y1, int x2, int y2)
        {
            System.Drawing.Drawing2D.AdjustableArrowCap lineCap = new System.Drawing.Drawing2D.AdjustableArrowCap(3, 3, true);

            Pen p = new Pen(Color.LightBlue , 3);
            p.CustomEndCap = lineCap;
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;//恢复实线  
            e.Graphics.DrawLine(p, x1, y1, x2, y2);

            p.Dispose();
        }
        protected override void OnDrawItem(DrawListViewItemEventArgs e)
        {
            /*
            Rectangle rectItem = this.GetItemRect(e.ItemIndex, ItemBoundsPortion.Entire);
            e.Graphics.FillRectangle(Brushes.Teal , rectItem);
            */

            Rectangle r = GetItemRect(1, ItemBoundsPortion.Entire);

            for (int i=0;i<CComLibrary.GlobeVal.filesave.mseglist.Count;i++)
            {
                if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 1)
                {
                    if (CComLibrary.GlobeVal.filesave.mseglist[i].returncount > 0)
                    {
                        Rectangle r1 = getsubitemmidrect(2, i + 1);
                        Pen p = new Pen(Brushes.LightBlue, 3);
                        DrawArrow(e, r1.X + r1.Width, r1.Y, r1.X + r1.Width, r.Y);
                        int rs = CComLibrary.GlobeVal.filesave.mseglist[i].returnstep;

                        Rectangle r2 = getsubitemmidrect(2, rs);

                        DrawArrow(e, r1.X + r1.Width, r.Y, r2.X, r.Y);
                        DrawArrow(e, r2.X, r.Y, r2.X, r2.Y);

                        /*
                        e.Graphics.DrawString(CComLibrary.GlobeVal.filesave.mseglist[i].returncount.ToString(), this.Font, Brushes.Black, r2.X+( r1.X -r2.X)/2, r.Y);

                        e.Graphics.DrawLine(Pens.Black, r2.X + (r1.X - r2.X) / 2 - 5, r.Y, r2.X + (r1.X - r2.X) / 2 + 10, r.Y);


                        e.Graphics.DrawString(CComLibrary.GlobeVal.filesave.mseglist[i].currentcount.ToString(), this.Font, Brushes.Black, r2.X +( r1.X - r2.X)/2, r.Y - this.FontHeight);
                        */
                    }
                }
                else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 3)
                {
                    if (CComLibrary.GlobeVal.filesave.mseglist[i].mseq.loop ==true)
                    {
                        Rectangle r1 = getsubitemmidrect(2, i + 1);
                        Pen p = new Pen(Brushes.LightBlue, 3);
                        DrawArrow(e, r1.X + r1.Width, r1.Y, r1.X + r1.Width, r.Y);
                        int rs = CComLibrary.GlobeVal.filesave.mseglist[i].mseq.returnstep;

                        Rectangle r2 = getsubitemmidrect(2, rs);

                        DrawArrow(e, r1.X + r1.Width, r.Y, r2.X, r.Y);
                        DrawArrow(e, r2.X, r.Y, r2.X, r2.Y);

                        /*
                        e.Graphics.DrawString(CComLibrary.GlobeVal.filesave.mseglist[i].mseq.loopcount.ToString(), this.Font, Brushes.Black,r2.X+(r1.X - r2.X)/2, r.Y);

                        e.Graphics.DrawLine(Pens.Black, r2.X+(r1.X-r2.X)/2-5, r.Y, r2.X + (r1.X-r2.X)/2 + 10, r.Y);


                        e.Graphics.DrawString(CComLibrary.GlobeVal.filesave.mseglist[i].currentcount.ToString(), this.Font, Brushes.Black, r2.X +( r1.X - r2.X)/2, r.Y - this.FontHeight);
                        */
                    }
                }
            }

        }
        protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
        {
            if (View != View.Details ||
                e.ItemIndex == -1)
            {
                e.DrawDefault = true;
                return;
            }


           /*
          
                DrawListViewItemEventArgs e1 = new DrawListViewItemEventArgs(e.Graphics, e.Item, this.DisplayRectangle, e.ItemIndex, e.ItemState);

                OnDrawItem(e1);
            */

            Rectangle r = e.Bounds;
            Graphics g = e.Graphics;
            int paddingLeft = 1;

            if (e.ItemIndex  ==2)
            {
                
                if (IsDrawIcon)
                {
                    paddingLeft = this.DrawIcon(g, r, this.Icon, e.Item.BackColor).Width;
                }

                if (IsDrawGridLines)
                {
                    using (Pen pen = new Pen(Color.Gray))
                    {
                        g.DrawRectangle(pen, r.X, r.Y, r.Width, r.Height + 1);//高度加1使横向线条重叠
                    }
                }

                if (!string.IsNullOrEmpty(e.SubItem.Text))
                {

                    if (e.ColumnIndex == curstep)
                    {
                        Rectangle r1 = getsubitemrect(e.ItemIndex, e.ColumnIndex);
                        r1 = new Rectangle(r1.X + 1, r1.Y + 1, r1.Width - 1, r1.Height - 1);
                        e.Graphics.FillRectangle(Brushes.LightBlue, r1);
                    }

                    Pen p = new Pen(Brushes.LightGray, 2);

                    e.Graphics.DrawRectangle(p, getsubitemrect(e.ItemIndex, e.ColumnIndex));
                    this.DrawText(e, g, r, paddingLeft);



                }

            }
            else

            {
                if (!string.IsNullOrEmpty(e.SubItem.Text))
                {

                   
                    Pen p = new Pen(Brushes.LightGray, 2);

                   // e.Graphics.DrawRectangle(p, getsubitemrect(e.ItemIndex, e.ColumnIndex));
                    this.DrawText(e, g, r, paddingLeft);



                }
            }

            
            
            //  DrawSelectedBackground(e, g, r);

            


        }

        /// <summary>
        /// 重绘选中时背景
        /// </summary>
        private void DrawSelectedBackground(DrawListViewSubItemEventArgs e, Graphics g, Rectangle r)
        {
            if ((e.ItemState & ListViewItemStates.Selected)
    == ListViewItemStates.Selected)
            {
                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    g.FillRectangle(brush, r);
                }
            }
        }

        /// <summary>
        /// 重绘图标
        /// </summary>
        private Size DrawIcon(Graphics g, Rectangle r, Image image, Color backColor)
        {
            Rectangle imageBounds = new Rectangle(r.Location, image.Size);
            if (image.Height > r.Height)
            {
                float scaleRatio = (float)r.Height / (float)image.Height;
                imageBounds.Width = (int)((float)Icon.Width * scaleRatio);
                imageBounds.Height = r.Height - 1;
            }
            //使图标不会紧贴着每一列的左上角
            imageBounds.X += 1;
            imageBounds.Y += 1;

            g.DrawImage(image, imageBounds);
            return imageBounds.Size;
        }

        /// <summary>
        /// 重绘文本
        /// </summary>
        private void DrawText(DrawListViewSubItemEventArgs e, Graphics g, Rectangle r, int paddingLeft)
        {
            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;

            r.X += 5 + paddingLeft;//重绘图标时，文本右移
            TextRenderer.DrawText(
                g,
                e.SubItem.Text,
                e.SubItem.Font,
                r,
                e.SubItem.ForeColor,
                flags);
        }

        /// <summary>
        /// 获取文本对齐
        /// </summary>
        private TextFormatFlags GetFormatFlags(
            HorizontalAlignment align)
        {
            TextFormatFlags flags =
                    TextFormatFlags.EndEllipsis |
                    TextFormatFlags.VerticalCenter;

            switch (align)
            {
                case HorizontalAlignment.Center:
                    flags |= TextFormatFlags.HorizontalCenter;
                    break;
                case HorizontalAlignment.Right:
                    flags |= TextFormatFlags.Right;
                    break;
                case HorizontalAlignment.Left:
                    flags |= TextFormatFlags.Left;
                    break;
            }

            return flags;
        }
    }

}
