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
    public partial class UserControlSpe : UserControl
    {

        public int specount = 0;

        public UserControlSpe()
        {
            InitializeComponent();
            
        }

        public void setinput()
        {
            tlp1.Controls.Clear();

            tlp1.RowStyles.Clear();

            tlp1.RowCount = (CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem.Count);


            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem.Count; i++)
            {
                RowStyle r = new RowStyle();


                r.SizeType = SizeType.Absolute;
                r.Height = 40;

                tlp1.RowStyles.Add(r);
            }
            tlp1.Height = (CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem.Count) * 40;


            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem.Count; i++)
            {

                CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem[i].getvalue();



                if (CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem[i].itemkind == 0)
                {

                    UserTextInput u = new UserTextInput();
                    u.lbltitle.Text = CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem[i].itemname;
                    u.txtvalue.Text = CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem[i].itemvalue.ToString();
                    u.Dock = DockStyle.Fill;
                    u.txtvalue.Tag = CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem[i];
                    u.txtvalue.TextChanged += new EventHandler(txtvalue_TextChanged);

                    tlp1.Controls.Add(u);
                }

                if (CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem[i].itemkind == 1)
                {
                    UserSizeInput m = new UserSizeInput();
                    m.lbltitle.Text = CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem[i].itemname;
                    double t = 0;
                    double.TryParse(CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem[i].itemvalue.ToString(), out  t);
                    m.txtvalue.Value = t;
                    m.txtvalue.Tag = CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem[i];
                    m.txtvalue.AfterChangeValue += Txtvalue_AfterChangeValue;
                    m.cbounit.Items.Clear();
                    m.cbounit.Items.Add(CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem[i].itemunit);
                    m.cbounit.SelectedIndex = 0;
                    m.Dock = DockStyle.Fill;
                    tlp1.Controls.Add(m);

                   

                }

                if (CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem[i].itemkind == 2)
                {
                    UserComboInput n = new UserComboInput();
                    n.lbltitle.Text = CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem[i].itemname;

                    n.cbo.Items.Clear();
                    for (int j = 0; j < CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem[i].mcboitem.mlist.Count; j++)
                    {
                        n.cbo.Items.Add(CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem[i].mcboitem.mlist[j]);
                    }

                    n.cbo.Tag = CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem[i];
                    n.cbo.SelectionChangeCommitted += new EventHandler(cbo_SelectionChangeCommitted);

                    n.cbo.SelectedIndex = Convert.ToInt32(CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem[i].itemvalue);

                    n.Dock = DockStyle.Fill;
                    tlp1.Controls.Add(n);
                }

            }
        }

        private void Txtvalue_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            double t;
           
            t = (sender as NationalInstruments.UI.WindowsForms.NumericEdit).Value;
            ((sender as NationalInstruments.UI.WindowsForms.NumericEdit).Tag as CComLibrary.PromptsItem).itemvalue = t;
        }

        void cbo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ((sender as ComboBox).Tag as CComLibrary.PromptsItem).itemvalue = (sender as ComboBox).SelectedIndex;
           // CComLibrary.GlobeVal.filesave.SerializeNow(GlobeVal.spefilename);

          

        }

        void txtvalue_TextChanged(object sender, EventArgs e)
        {
            ((sender as TextBox).Tag as CComLibrary.PromptsItem).itemvalue = (sender as TextBox).Text;
           // CComLibrary.GlobeVal.filesave.SerializeNow(GlobeVal.spefilename);


        }

        void txtvalue2_TextChanged(object sender, EventArgs e)
        {
            double t;
            double.TryParse((sender as TextBox).Text,  out t );
            ((sender as TextBox).Tag as CComLibrary.PromptsItem).itemvalue = t;
           // CComLibrary.GlobeVal.filesave.SerializeNow(GlobeVal.spefilename);
            
        }
        public void setspe( int num, CComLibrary.TestStatus  state)
        {
            if (state == CComLibrary.TestStatus.Untested)
            {
                listBox1.Items[0].Text = num.ToString()+"-未测试";
            }
            else if (state == CComLibrary.TestStatus.tested)
            {
                listBox1.Items[0].Text = num.ToString() + "-已完成";
            }
            else if (state == CComLibrary.TestStatus.novalid)
            {
                listBox1.Items[0].Text = num.ToString() + "-无效";
            }
            listBox1.Items[0].Image = imageList1.Images[ Convert.ToInt16( state)];
            listBox1.Refresh();

            if (GlobeVal.UserControlGraph1 != null)
            {
                GlobeVal.UserControlGraph1.RefreshCaption();
            }

            if (GlobeVal.UserControlGraph2 != null)
            {
                GlobeVal.UserControlGraph2.RefreshCaption();
            }
              
        }

        private void btnright_Click(object sender, EventArgs e)
        {
            if (listBox1.Items[0].Text.Contains("未测试")==true)
            {

            }
            else
            {

              

                if ((CComLibrary.GlobeVal.filesave.currentspenumber+1) > GlobeVal.userControltest1.lstspe.Items.Count)
                {

                    CComLibrary.GlobeVal.filesave.currentspenumber = CComLibrary.GlobeVal.filesave.currentspenumber + 1;
                    CComLibrary.GlobeVal.filesave.testedcount = CComLibrary.GlobeVal.filesave.currentspenumber;
                    setspe(CComLibrary.GlobeVal.filesave.currentspenumber + 1, CComLibrary.TestStatus.Untested);
                    btnright.Enabled = false;

                    if (GlobeVal.userControltest1 != null)
                    {
                        GlobeVal.userControltest1.lstspeRefresh();
                    }

                    if (GlobeVal.UserControlResult1 != null)
                    {

                        GlobeVal.UserControlResult1.InitGrid(1, false, false, CComLibrary.GlobeVal.filesave.mtablecol1, CComLibrary.GlobeVal.filesave.mtable1para,
                            CComLibrary.GlobeVal.filesave.mtable1statistics);

                    }

                    if (GlobeVal.UserControlResult2 != null)
                    {

                        GlobeVal.UserControlResult2.InitGrid(2, false, false, CComLibrary.GlobeVal.filesave.mtablecol2, CComLibrary.GlobeVal.filesave.mtable2para,
                            CComLibrary.GlobeVal.filesave.mtable2statistics);

                    }


                    for (int i = 0; i < CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem.Count; i++)
                    {
                        CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem[i].setvalue();
                    }
                }
                else
                {
                    CComLibrary.GlobeVal.filesave.currentspenumber = CComLibrary.GlobeVal.filesave.currentspenumber + 1;


                    setspe(CComLibrary.GlobeVal.filesave.currentspenumber + 1, CComLibrary.TestStatus.tested);

                    setinput();


                }
            }

        }

        private void UserControlSpe_Load(object sender, EventArgs e)
        {
            if (CComLibrary.GlobeVal.filesave.mwizard==true)
            {

                btnleft.Visible  = false;
                btnright.Visible  = false;
            }
            else
            {
                btnleft.Visible  = true;
                btnright.Visible = true;
            }
        }

        private void btnleft_Click(object sender, EventArgs e)
        {

            if (CComLibrary.GlobeVal.filesave.currentspenumber >= 1)
            {
                CComLibrary.GlobeVal.filesave.currentspenumber = CComLibrary.GlobeVal.filesave.currentspenumber - 1;


                setspe(CComLibrary.GlobeVal.filesave.currentspenumber + 1, CComLibrary.TestStatus.tested);

               setinput();

            

            }
            else
            {
                btnleft.Enabled = false;
            }
            

        }
    }
}
