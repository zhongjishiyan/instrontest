using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TabHeaderDemo
{
    public partial class UserControl试样 : UserControl
    {
        public UserControlMethod musercontrolmethod;

        private void Init_ComboInput()
        {
            this.tableLayoutPanelCombo.Controls.Clear();
            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mcbo.Count; i++)
            {
                UserComboInput b = new UserComboInput();
                b.Dock = DockStyle.Fill;
                b.lbltitle.Text = CComLibrary.GlobeVal.filesave.mcbo[i].Name;

                b.cbo.Items.Clear();
                for (int j = 0; j < CComLibrary.GlobeVal.filesave.mcbo[i].mlist.Count; j++)
                {
                    b.cbo.Items.Add(CComLibrary.GlobeVal.filesave.mcbo[i].mlist[j]);
                }
                b.cbo.Tag = i;
                b.cbo.SelectionChangeCommitted += Cbo_SelectionChangeCommitted;
                b.cbo.SelectedIndex = CComLibrary.GlobeVal.filesave.mcbo[i].value;
                tableLayoutPanelCombo.RowStyles[0].Height = 30;
                tableLayoutPanelCombo.Controls.Add(b);

            }

        }

        private void Cbo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int c = Convert.ToInt16((sender as ComboBox).Tag);
            CComLibrary.GlobeVal.filesave.mcbo[c].value = (sender as ComboBox).SelectedIndex;
        }



        private void Init_textinput()
        {
            this.tableLayoutPanelText.Controls.Clear();
            for (int i = 0; i <
                CComLibrary.GlobeVal.filesave.minputtext.Count; i++)
            {

                UserTextInput b = new UserTextInput();
                b.Dock = DockStyle.Fill;

                b.lbltitle.Text = CComLibrary.GlobeVal.filesave.minputtext[i].name;

                if (CComLibrary.GlobeVal.filesave.minputtext[i].value==null)
                {
                    CComLibrary.GlobeVal.filesave.minputtext[i].value = "";
                }
                b.txtvalue.Text = CComLibrary.GlobeVal.filesave.minputtext[i].value.ToString();
                b.txtvalue.Tag = i;
                b.txtvalue.TextChanged += Txtvalue_TextChanged1;

            
                tableLayoutPanelText.RowStyles[0].Height = 30;
                tableLayoutPanelText.Controls.Add(b);

            }
        }

        private void Txtvalue_TextChanged1(object sender, EventArgs e)
        {
            int c = Convert.ToInt16((sender as TextBox).Tag);
            CComLibrary.GlobeVal.filesave.minputtext[c].value = (sender as TextBox).Text; 
        }

        private void Init_numbersize()
        {
            this.tableLayoutPanelNumber.Controls.Clear();
            for (int i = 0; i <
                CComLibrary.GlobeVal.filesave.minput.Count; i++)
            {
                
                    UserSizeInput b = new UserSizeInput();
                //

                    b.btnproperty.Tag = i;
                    b.btnproperty.Click += numbersize_btnproperty_Click;
                    b.Dock = DockStyle.Fill;
                   
                    b.lbltitle.Text = CComLibrary.GlobeVal.filesave.minput[i].name;
                    b.txtvalue.Value= CComLibrary.GlobeVal.filesave.minput[i].value;
                    b.txtvalue.Tag = i;
                    b.txtvalue.AfterChangeValue += Txtvalue_AfterChangeValue;
                    
                    b.cbounit.Items.Clear();
                    for (int j = 0; j <CComLibrary.GlobeVal.filesave.minput[i].myitemsignal.cUnitCount ; j++)
                    {

                        b.cbounit.Items.Add(
                             CComLibrary.GlobeVal.filesave.minput[i].myitemsignal.cUnits[j]
                        );

                    }
                b.cbounit.Enabled = false;
                    b.cbounit.SelectedIndex = CComLibrary.GlobeVal.filesave.minput[i].myitemsignal.cUnitsel;
                    tableLayoutPanelNumber.RowStyles[0].Height = 30;
                    tableLayoutPanelNumber.Controls.Add(b);
                
            }
        }

        private void numbersize_btnproperty_Click(object sender, EventArgs e)
        {
            int v = Convert.ToInt32((sender as Button).Tag);

            Frm.FormRange f = new Frm.FormRange();
            f.chkzero.Checked = CComLibrary.GlobeVal.filesave.minput[v].zerocheck;
            f.ShowDialog();
            CComLibrary.GlobeVal.filesave.minput[v].zerocheck = f.chkzero.Checked;
            f.Close();
            return;
        }

        private void Txtvalue_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            int c = Convert.ToInt16((sender as  NationalInstruments.UI.WindowsForms.NumericEdit ).Tag);

            CComLibrary.GlobeVal.filesave.minput[c].value = (sender as NationalInstruments.UI.WindowsForms.NumericEdit).Value;
        }

        
        private void Init_spesize()
        {
           
                if (cboshape.Text == ClsStaticStation.m_Global.mycls.shapelist[ClsStaticStation.m_Global.mycls.shapelist[0].Rect_Shape].shapename)
                {
                    pictureBox1.BackgroundImage = imageList1.Images[0];
                }

                if (cboshape.Text == ClsStaticStation.m_Global.mycls.shapelist[ClsStaticStation.m_Global.mycls.shapelist[0].Round_Shape].shapename)
                {
                    pictureBox1.BackgroundImage = imageList1.Images[1];
                }

                if (cboshape.Text == ClsStaticStation.m_Global.mycls.shapelist[ClsStaticStation.m_Global.mycls.shapelist[0].Double_shear_ring_Shape].shapename)
                {
                    pictureBox1.BackgroundImage = imageList1.Images[2];
                }
                if (cboshape.Text == ClsStaticStation.m_Global.mycls.shapelist[ClsStaticStation.m_Global.mycls.shapelist[0].Tube_Shape].shapename)
                {
                    pictureBox1.BackgroundImage = imageList1.Images[3];
                }
                if (cboshape.Text == ClsStaticStation.m_Global.mycls.shapelist[ClsStaticStation.m_Global.mycls.shapelist[0].Irregular_Shape].shapename)
            {
                    pictureBox1.BackgroundImage = imageList1.Images[4];
                }
            
           

            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;

            tableLayoutPanelSize.Controls.Clear();
            for (int i = 0; i <
                CComLibrary.GlobeVal.filesave.mshapelist[cboshape.SelectedIndex].sizeitem.Length; i++)
            {
                if (CComLibrary.GlobeVal.filesave.mshapelist[cboshape.SelectedIndex].sizeitem[i].cName != "None")
                {
                    UserSizeInput b = new UserSizeInput();
                    b.Dock = DockStyle.Fill;

                    //
                    b.btnproperty.Tag = i;
                    b.btnproperty.Click += spesize_Btnproperty_Click;
                  
                    b.lbltitle.Text = CComLibrary.GlobeVal.filesave.mshapelist[cboshape.SelectedIndex].sizeitem[i].cName;
                    b.txtvalue.Value = CComLibrary.GlobeVal.filesave.mshapelist[cboshape.SelectedIndex].sizeitem[i].cvalue;
                    b.txtvalue.Tag = i;
                    b.txtvalue.AfterChangeValue += Txtvalue_AfterChangeValue1; ;
                    b.cbounit.Items.Clear();
                    for (int j = 0; j < CComLibrary.GlobeVal.filesave.mshapelist[cboshape.SelectedIndex].sizeitem[i].cUnitCount; j++)
                    {

                        b.cbounit.Items.Add(
                             CComLibrary.GlobeVal.filesave.mshapelist[cboshape.SelectedIndex].sizeitem[i].cUnits[
                             j]
                        );

                    }
                    b.cbounit.Enabled = false;
                    b.cbounit.SelectedIndex = CComLibrary.GlobeVal.filesave.mshapelist[cboshape.SelectedIndex].sizeitem[i].cUnitsel;
                    tableLayoutPanelSize.RowStyles[0].Height = 30;
                    tableLayoutPanelSize.Controls.Add(b);
                }
            }


        }

        private void spesize_Btnproperty_Click(object sender, EventArgs e)
        {
            int v = Convert.ToInt32((sender as Button).Tag);
            Frm.FormRange f = new Frm.FormRange();
            f.chkzero.Checked = CComLibrary.GlobeVal.filesave.mshapelist[cboshape.SelectedIndex].sizeitem[v].checkzero;
            f.ShowDialog();
            CComLibrary.GlobeVal.filesave.mshapelist[cboshape.SelectedIndex].sizeitem[v].checkzero = f.chkzero.Checked;
            f.Close();

            return;
        }

        private void Txtvalue_AfterChangeValue1(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            int c = Convert.ToInt16((sender as NationalInstruments.UI.WindowsForms.NumericEdit).Tag);
            CComLibrary.GlobeVal.filesave.mshapelist[cboshape.SelectedIndex].sizeitem[c].cvalue= (sender as NationalInstruments.UI.WindowsForms.NumericEdit ).Value;
           
        }

        private void Txtvalue_TextChanged(object sender, EventArgs e)
        {
            int c = Convert.ToInt16((sender as TextBox).Tag);

            double.TryParse((sender as TextBox).Text, out CComLibrary.GlobeVal.filesave.mshapelist[cboshape.SelectedIndex].sizeitem[c].cvalue);
        }

        public void  Open_method()
        {
            
            cboshape.Items.Clear();

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mshapelist.Count; i++)
            {
                cboshape.Items.Add(CComLibrary.GlobeVal.filesave.mshapelist[i].shapename); 
            }
            if (cboshape.Items.Count > 0)
            {
                cboshape.SelectedIndex = CComLibrary.GlobeVal.filesave.shapeselect;

            }
            Init_spesize();
            Init_numbersize();
            Init_textinput();
            Init_ComboInput();

        }
        public  void Init(int sel)
        {
            tabControl1.SelectedIndex = sel;

            if (GlobeVal.UserControlMain1.btnmtest.Visible == true)
            {
                tabControl1.Enabled = false;
            }
            else
            {
                tabControl1.Enabled = true;
            }


        }
        public  UserControl试样()
        {
            InitializeComponent();
            tabControl1.ItemSize = new Size(1, 1);
        }

        private void cboshape_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.shapeselect = cboshape.SelectedIndex; 

            
            Init_spesize();

            CComLibrary.GlobeVal.filesave.InitTable();
        }
    }
}
