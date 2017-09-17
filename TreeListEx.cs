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
    public partial class TreeListEx : TreeView 
    {
        public ImageList mimagelist;
        public TreeListEx()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            
        }

        public TreeListEx(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        protected override void  OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            this.Enabled = false;
            
            if (e.Node.Nodes.Count == 0)
            {
               
            }
            else
            {
                //if (e.Node.IsExpanded == true)
                {

                    
                }
               // else
                {
                    this.CollapseAll();

                    e.Node.Expand();

                    if (e.Node.Nodes[0] != this.SelectedNode)
                    {

                        this.SelectedNode = e.Node.Nodes[0];
                    }
                }
                
                
            }

            base.OnNodeMouseClick(e);
            this.Enabled = true;
            
        }
        protected  override  void  OnDrawNode( DrawTreeNodeEventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            if (mimagelist.Images.Count >= 2)
            {
            }
            else
            {
                return;
            }


            if (this.StateImageList == null)
            {
                return;
            }

            //base.OnDrawNode(e); 

            Color sel=new Color();

            if (e.Node.IsVisible == true)
            {

            }
            else
            {
                return;
            }

           

                if (this.SelectedNode == e.Node)
                {
                    sel = Color.LightYellow;
                }
                else
                {
                    sel = Color.White;
                }


                e.Graphics.DrawLine(SystemPens.ButtonFace, e.Bounds.Left
                ,
                 e.Node.Bounds.Bottom,
                 e.Bounds.Right,
                 e.Node.Bounds.Bottom);

                e.Graphics.DrawLine(SystemPens.ButtonFace, e.Bounds.Left
                 ,
                  e.Node.Bounds.Top,
                  e.Bounds.Right,
                  e.Node.Bounds.Top);

                float difH = (e.Bounds.Height - this.Font.Height) / 2;
               
                RectangleF rf = new RectangleF(e.Node.Bounds.X + this.StateImageList.ImageSize.Width, e.Node.Bounds.Y + difH, e.Node.Bounds.Width, this.Font.Height);
                


                if (e.Node.Parent == null)
                {
                    if (this.SelectedNode == e.Node)
                    {
                        Rectangle f = new Rectangle(e.Bounds.Left + mimagelist.Images[0].Width+5, e.Bounds.Top, e.Bounds.Width, e.Bounds.Height);
                        e.Graphics.DrawRectangle(new Pen(sel), f);
                        e.Graphics.FillRectangle(new SolidBrush(sel), f);
                        e.Graphics.DrawString(e.Node.Text, this.Font, new SolidBrush(Color.Red), rf.X, rf.Y);
                    }
                    else
                    {
                        e.Graphics.DrawString(e.Node.Text, this.Font, new SolidBrush(sel), rf.X, rf.Y);
                    }
                    e.Graphics.DrawImageUnscaled(this.StateImageList.Images[e.Node.StateImageIndex], e.Node.Bounds.Left - 16, e.Node.Bounds.Y + (e.Bounds.Height - this.StateImageList.ImageSize.Height) / 2);
                }
                else
                {

                    e.Graphics.DrawRectangle(new Pen(sel) , e.Bounds);
                    e.Graphics.FillRectangle(new SolidBrush(sel), e.Bounds);

                    if (this.SelectedNode == e.Node)
                    {
                        e.Graphics.DrawImageUnscaled(mimagelist.Images[1], e.Node.Bounds.Left - 16, e.Node.Bounds.Y + (e.Bounds.Height - mimagelist.ImageSize.Height) / 2);
                        e.Graphics.DrawString(e.Node.Text, this.Font, new SolidBrush(Color.Red), rf.X, rf.Y);
                    }
                    else
                    {
                        if (mimagelist.Images.Count > 0)
                        {
                            e.Graphics.DrawImageUnscaled(mimagelist.Images[0], e.Node.Bounds.Left - 16, e.Node.Bounds.Y + (e.Bounds.Height - mimagelist.ImageSize.Height) / 2);
                            e.Graphics.DrawString(e.Node.Text, this.Font, new SolidBrush(Color.Blue), rf.X, rf.Y);
                        }
                    }



                }

            


        }
    }
}
