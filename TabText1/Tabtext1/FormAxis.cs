using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppleLabApplication
{
    public partial class FormAxis : Form
    {
        NationalInstruments.UI.Axis xx;

        public NationalInstruments.UI.WindowsForms.ScatterGraph  myplot;
  
        public FormAxis()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            //xx.BaseLineColor = (Color)propertyEditor1.Source.Object;
          
            xx.CaptionForeColor = xx.BaseLineColor;
            xx.MajorDivisions.TickColor = xx.BaseLineColor;
            xx.MajorDivisions.LabelForeColor = xx.BaseLineColor;
            xx.MajorDivisions.GridColor =xx.BaseLineColor;

            for (i = 0; i < myplot.Plots.Count; i++)
            {
                if (myplot.Plots[i].YAxis == this.Tag)
                {
                    myplot.Plots[i].LineColor = xx.BaseLineColor;
                }
            }
                   
            xx.Range = new NationalInstruments.UI.Range((double)propertyEditor2.Source.Value, (double)propertyEditor3.Source.Value); 
 
            Close();
        }

        private void FormAxis_Load(object sender, EventArgs e)
        {
             xx = this.Tag as NationalInstruments.UI.Axis;
            
            this.Text = xx.Caption+"坐标设置";
            propertyEditor1.Source = new NationalInstruments.UI.PropertyEditorSource(xx, "BaseLineColor");
            propertyEditor8.Source = new NationalInstruments.UI.PropertyEditorSource(xx, "Caption");  
            propertyEditor2.Source = new NationalInstruments.UI.PropertyEditorSource(xx.Range, "Minimum");    
            propertyEditor3.Source = new NationalInstruments.UI.PropertyEditorSource(xx.Range, "Maximum");
            propertyEditor4.Source = new NationalInstruments.UI.PropertyEditorSource(xx, "ScaleType");
            propertyEditor5.Source = new NationalInstruments.UI.PropertyEditorSource(xx.MajorDivisions, "GridVisible");
            propertyEditor6.Source = new NationalInstruments.UI.PropertyEditorSource(xx.MajorDivisions, "GridLineStyle");
            propertyEditor7.Source = new NationalInstruments.UI.PropertyEditorSource(xx.MajorDivisions, "Interval");
   


        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void propertyEditor8_SourceValueChanged(object sender, EventArgs e)
        {

        }
    }
}
