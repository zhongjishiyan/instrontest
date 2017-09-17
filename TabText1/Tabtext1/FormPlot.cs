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
    public partial class FormPlot : Form
    {
        private NationalInstruments.UI.WindowsForms.ScatterGraph sp; 
        public FormPlot()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sp.Cursors[0].LabelForeColor = sp.Cursors[0].Color;
            sp.Cursors[1].LabelForeColor = sp.Cursors[1].Color;
            sp.Cursors[3].Color = sp.Cursors[2].Color;
            Close();
        }

        private void FormPlot_Load(object sender, EventArgs e)
        {
            int i;
            sp = CComLibrary.GlobeVal.m_mainform.scatterGraph1;

            comboBox1.Items.Clear();   
            for (i = 0; i < sp.Plots.Count; i++)
            {
                
                   
                    comboBox1.Items.Add(i+1);
                    comboBox1.SelectedIndex = 0;
                
            }

            

                propertyEditor1.Source  = new NationalInstruments.UI.PropertyEditorSource(sp, "CaptionVisible");
                propertyEditor2.Source = new NationalInstruments.UI.PropertyEditorSource(sp, "Caption");
                propertyEditor3.Source = new NationalInstruments.UI.PropertyEditorSource(sp, "CaptionForeColor");
                propertyEditor4.Source = new NationalInstruments.UI.PropertyEditorSource(sp, "CaptionBackColor");
                propertyEditor5.Source = new NationalInstruments.UI.PropertyEditorSource(sp, "CaptionFont");
                propertyEditor6.Source = new NationalInstruments.UI.PropertyEditorSource(sp, "ForeColor");
                propertyEditor7.Source = new NationalInstruments.UI.PropertyEditorSource(sp, "BackColor");
                propertyEditor8.Source = new NationalInstruments.UI.PropertyEditorSource(sp, "PlotAreaColor");
                propertyEditor9.Source = new NationalInstruments.UI.PropertyEditorSource(sp, "PlotAreaBorder");

                i = Convert.ToInt16(comboBox1.Text); 

                
                propertyEditor11.Source = new NationalInstruments.UI.PropertyEditorSource(sp.Plots[i - 1], "LineStyle");
                propertyEditor12.Source = new NationalInstruments.UI.PropertyEditorSource(sp.Plots[i - 1], "LineWidth" );
                propertyEditor13.Source = new NationalInstruments.UI.PropertyEditorSource(sp.Cursors[0],"Color");
                propertyEditor14.Source = new NationalInstruments.UI.PropertyEditorSource(sp.Cursors[1], "Color");
                propertyEditor15.Source = new NationalInstruments.UI.PropertyEditorSource(sp.Cursors[2], "Color"); 



            
        }

        private void propertyEditor11_SourceValueChanged(object sender, EventArgs e)
        {

        }
    }
}
