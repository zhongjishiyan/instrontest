using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using NationalInstruments.UI;

namespace AppleLabApplication
{
    public partial class FormPopupMenu : Form
    {
        public FormPopupMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.Tag is XYPointAnnotation)
            {

                XYPointAnnotation b = (XYPointAnnotation)(this.Tag);

                b.ArrowColor= (Color) this.propertyEditor2.Source.Value;
                b.ArrowLineWidth = (float)this.propertyEditor1.Source.Value;
                b.ArrowLineStyle = (LineStyle)this.propertyEditor3.Source.Value;
                b.ArrowHeadStyle = (ArrowStyle)this.propertyEditor4.Source.Value;
                b.ArrowTailStyle = (ArrowStyle)this.propertyEditor5.Source.Value;
                b.ArrowHeadSize= (Size)this.propertyEditor6.Source.Value;
                
                b.ArrowTailSize = (Size)this.propertyEditor8.Source.Value;

                b.CaptionVisible = (bool)this.propertyEditor7.Source.Value;
                b.Caption = (string)this.propertyEditor9.Source.Value;
                b.CaptionForeColor = (Color)this.propertyEditor10.Source.Value;
                b.CaptionFont  = (Font)this.propertyEditor11.Source.Value;
                b.ShapeStyle = (ShapeStyle)this.propertyEditor12.Source.Value;
                b.ShapeLineColor = (Color)this.propertyEditor13.Source.Value;
                b.ShapeFillColor = (Color)this.propertyEditor14.Source.Value;
                b.ShapeSize = (Size)this.propertyEditor15.Source.Value;   

                
            }
            if (this.Tag is XYRangeAnnotation)
            {
                XYRangeAnnotation b = (XYRangeAnnotation)(this.Tag);
                b.RangeLineColor = (Color)this.propertyEditor2.Source.Value;
                b.RangeFillColor = (Color)this.propertyEditor2.Source.Value;
                

            }

            Close();
        }

        private void FormPopupMenu_Load(object sender, EventArgs e)
        {

            if (this.Tag is XYPointAnnotation)
            {

                XYPointAnnotation b = (XYPointAnnotation)(this.Tag);
                CComLibrary.LineStruct l = b.Tag as CComLibrary.LineStruct;
                if (l.kind == 0)
                {


                   
                }


                propertyEditor2.Source = new PropertyEditorSource(b, "ArrowColor");
                propertyEditor1.Source = new PropertyEditorSource(b, "ArrowLineWidth");
                propertyEditor3.Source = new PropertyEditorSource(b, "ArrowLineStyle");
                propertyEditor4.Source = new PropertyEditorSource(b, "ArrowHeadStyle");  
                propertyEditor5.Source =new PropertyEditorSource(b,"ArrowTailStyle");
                propertyEditor6.Source = new PropertyEditorSource(b, "ArrowHeadSize");
                

                propertyEditor8.Source = new PropertyEditorSource(b, "ArrowTailSize");

                propertyEditor7.Source = new PropertyEditorSource(b, "CaptionVisible");
                propertyEditor9.Source = new PropertyEditorSource(b, "Caption");
                propertyEditor10.Source = new PropertyEditorSource(b, "CaptionForeColor");
                propertyEditor11.Source = new PropertyEditorSource(b, "CaptionFont");
                propertyEditor12.Source = new PropertyEditorSource(b, "ShapeStyle");
                propertyEditor13.Source = new PropertyEditorSource(b, "ShapeLineColor");
                propertyEditor14.Source = new PropertyEditorSource(b, "ShapeFillColor");
                propertyEditor15.Source = new PropertyEditorSource(b, "ShapeSize");   
                


            }

            if (this.Tag is XYRangeAnnotation)
            {
                XYRangeAnnotation c = (XYRangeAnnotation)(this.Tag);
                

            }
        }
    }
}
