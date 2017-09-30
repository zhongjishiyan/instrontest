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
                    b.Dock = DockStyle.Fill;

                    b.lbltitle.Text = CComLibrary.GlobeVal.filesave.minput[i].name;
                    b.txtvalue.Text= CComLibrary.GlobeVal.filesave.minput[i].value.ToString();
                    b.txtvalue.Tag = i;
                    b.txtvalue.TextChanged += Txtvalue_TextChanged2;
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

        private void Txtvalue_TextChanged2(object sender, EventArgs e)
        {
            int c = Convert.ToInt16((sender as TextBox).Tag);
            double.TryParse((sender as TextBox).Text, out CComLibrary.GlobeVal.filesave.minput[c].value);
        }

        private void Init_spesize()
        {
            if (cboshape.Text == "矩形")
            {
                pictureBox1.BackgroundImage = imageList1.Images[0];
            }

            if (cboshape.Text == "圆形")
            {
                pictureBox1.BackgroundImage = imageList1.Images[1];
            }

            if (cboshape.Text == "双剪切环")
            {
                pictureBox1.BackgroundImage = imageList1.Images[2];
            }
            if (cboshape.Text == "管状")
            {
                pictureBox1.BackgroundImage = imageList1.Images[3];
            }
            if (cboshape.Text == "不规则形状")
            {
                pictureBox1.BackgroundImage = imageList1.Images[4];
            }

            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;

            tableLayoutPanelSize.Controls.Clear();
            for (int i = 0; i <
                CComLibrary.GlobeVal.filesave.mshapelist[cboshape.SelectedIndex].sizeitem.Length; i++)
            {
                if (CComLibrary.GlobeVal.filesave.mshapelist[cboshape.SelectedIndex].sizeitem[i].cName != "无")
                {
                    UserSizeInput b = new UserSizeInput();
                    b.Dock = DockStyle.Fill;

                    b.lbltitle.Text = CComLibrary.GlobeVal.filesave.mshapelist[cboshape.SelectedIndex].sizeitem[i].cName;
                    b.txtvalue.Text = CComLibrary.GlobeVal.filesave.mshapelist[cboshape.SelectedIndex].sizeitem[i].cvalue.ToString();
                    b.txtvalue.Tag = i;
                    b.txtvalue.TextChanged += Txtvalue_TextChanged;
              
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
            cboshape.SelectedIndex = CComLibrary.GlobeVal.filesave.shapeselect; 
            Init_spesize(); 
        }
    }
}
