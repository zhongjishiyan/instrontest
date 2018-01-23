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
    public partial class UserControlWizard : UserControl
    {

        public void Init(int sel)
        {
            tabControl1.SelectedIndex = sel;

            if (sel == 0)
            {
                int mold = 0;

                mold = CComLibrary.GlobeVal.filesave.currentspenumber;
                CComLibrary.GlobeVal.filesave.currentspenumber = 0;

                lblstartbefore.Text = CComLibrary.GlobeVal.filesave.teststep[0].mtooltip;
                numericEdit1.Value = CComLibrary.GlobeVal.filesave.mspecount;
                numericEdit2.Value  = mold+1;

                tlp0.Controls.Clear();
                
                tlp0.RowStyles.Clear();

                tlp0.RowCount = (CComLibrary.GlobeVal.filesave.teststep[0].mstepPromptsItem.Count);

              
                for (int i = 0; i < CComLibrary.GlobeVal.filesave.teststep[0].mstepPromptsItem.Count; i++)
                {
                    RowStyle r = new RowStyle();
                   
               
                    r.SizeType = SizeType.Absolute;
                    r.Height = 40;

                    tlp0.RowStyles.Add(r);
                }
                tlp0.Height = (CComLibrary.GlobeVal.filesave.teststep[0].mstepPromptsItem.Count) * 40;


              
                for (int i = 0; i < CComLibrary.GlobeVal.filesave.teststep[0].mstepPromptsItem.Count; i++)
                {

                    CComLibrary.GlobeVal.filesave.teststep[0].mstepPromptsItem[i].getvalue();

                    if (CComLibrary.GlobeVal.filesave.teststep[0].mstepPromptsItem[i].itemkind == 0)
                    {

                        UserTextInput u = new UserTextInput();
                        u.lbltitle.Text = CComLibrary.GlobeVal.filesave.teststep[0].mstepPromptsItem[i].itemname;
                        u.txtvalue.Text = CComLibrary.GlobeVal.filesave.teststep[0].mstepPromptsItem[i].itemvalue.ToString();
                        u.Dock = DockStyle.Fill;
                        u.txtvalue.Tag  = CComLibrary.GlobeVal.filesave.teststep[0].mstepPromptsItem[i];
                        u.txtvalue.TextChanged += new EventHandler(txtvalue_TextChanged);

                        tlp0.Controls.Add(u);
                    }

                    if (CComLibrary.GlobeVal.filesave.teststep[0].mstepPromptsItem[i].itemkind == 1)
                    {
                        UserSizeInput m = new UserSizeInput();
                        m.lbltitle.Text = CComLibrary.GlobeVal.filesave.teststep[0].mstepPromptsItem[i].itemname;
                        m.txtvalue.Text= CComLibrary.GlobeVal.filesave.teststep[0].mstepPromptsItem[i].itemvalue.ToString();
                        m.txtvalue.Tag = CComLibrary.GlobeVal.filesave.teststep[0].mstepPromptsItem[i];
                        m.txtvalue.TextChanged+=new EventHandler(txtvalue2_TextChanged);
                        m.Dock = DockStyle.Fill;
                        tlp0.Controls.Add(m);
                    }

                    if (CComLibrary.GlobeVal.filesave.teststep[0].mstepPromptsItem[i].itemkind == 2)
                    {
                        UserComboInput  n = new UserComboInput();
                        n.lbltitle.Text = CComLibrary.GlobeVal.filesave.teststep[0].mstepPromptsItem[i].itemname;

                        n.cbo.Items.Clear();
                        for (int j=0;j<CComLibrary.GlobeVal.filesave.teststep[0].mstepPromptsItem[i].mcboitem.mlist.Count;j++)
                        {
                           n.cbo.Items.Add(CComLibrary.GlobeVal.filesave.teststep[0].mstepPromptsItem[i].mcboitem.mlist[j]);
                        }

                        n.cbo.Tag = CComLibrary.GlobeVal.filesave.teststep[0].mstepPromptsItem[i];
                        n.cbo.SelectionChangeCommitted += new EventHandler(cbo_SelectionChangeCommitted);

                        n.cbo.SelectedIndex  = Convert.ToInt32(CComLibrary.GlobeVal.filesave.teststep[0].mstepPromptsItem[i].itemvalue);
                        n.Dock = DockStyle.Fill;
                        tlp0.Controls.Add(n);
                    }

                    
                }

                CComLibrary.GlobeVal.filesave.currentspenumber=mold;

                dataGridView1.DataSource = CComLibrary.GlobeVal.filesave.dt;

            }
            if (sel == 1)
            {
                lblspetestbefore.Text = CComLibrary.GlobeVal.filesave.teststep[1].mtooltip;

                 tlp1.Controls.Clear();
                
                tlp1.RowStyles.Clear();

                tlp1.RowCount = (CComLibrary.GlobeVal.filesave.teststep[1].mstepPromptsItem.Count);

              
                for (int i = 0; i < CComLibrary.GlobeVal.filesave.teststep[1].mstepPromptsItem.Count; i++)
                {
                    RowStyle r = new RowStyle();
                   
               
                    r.SizeType = SizeType.Absolute;
                    r.Height = 40;

                    tlp1.RowStyles.Add(r);
                }
                tlp1.Height = (CComLibrary.GlobeVal.filesave.teststep[1].mstepPromptsItem.Count) * 40;

               
                for (int i = 0; i < CComLibrary.GlobeVal.filesave.teststep[1].mstepPromptsItem.Count; i++)
                {

                    CComLibrary.GlobeVal.filesave.teststep[1].mstepPromptsItem[i].getvalue();

                   

                        if (CComLibrary.GlobeVal.filesave.teststep[1].mstepPromptsItem[i].itemkind == 0)
                        {

                            UserTextInput u = new UserTextInput();
                            u.lbltitle.Text = CComLibrary.GlobeVal.filesave.teststep[1].mstepPromptsItem[i].itemname;
                            u.txtvalue.Text = CComLibrary.GlobeVal.filesave.teststep[1].mstepPromptsItem[i].itemvalue.ToString();
                            u.Dock = DockStyle.Fill;
                            u.txtvalue.Tag = CComLibrary.GlobeVal.filesave.teststep[1].mstepPromptsItem[i];
                            u.txtvalue.TextChanged += new EventHandler(txtvalue_TextChanged);

                            tlp1.Controls.Add(u);
                        }

                        if (CComLibrary.GlobeVal.filesave.teststep[1].mstepPromptsItem[i].itemkind == 1)
                        {
                            UserSizeInput m = new UserSizeInput();
                            m.lbltitle.Text = CComLibrary.GlobeVal.filesave.teststep[1].mstepPromptsItem[i].itemname;
                            m.txtvalue.Text = CComLibrary.GlobeVal.filesave.teststep[1].mstepPromptsItem[i].itemvalue.ToString();
                            m.txtvalue.Tag = CComLibrary.GlobeVal.filesave.teststep[1].mstepPromptsItem[i];
                            m.txtvalue.TextChanged += new EventHandler(txtvalue2_TextChanged);
                            m.Dock = DockStyle.Fill;
                            tlp1.Controls.Add(m);
                        }

                        if (CComLibrary.GlobeVal.filesave.teststep[1].mstepPromptsItem[i].itemkind == 2)
                        {
                            UserComboInput n = new UserComboInput();
                            n.lbltitle.Text = CComLibrary.GlobeVal.filesave.teststep[1].mstepPromptsItem[i].itemname;

                            n.cbo.Items.Clear();
                            for (int j = 0; j < CComLibrary.GlobeVal.filesave.teststep[1].mstepPromptsItem[i].mcboitem.mlist.Count; j++)
                            {
                                n.cbo.Items.Add(CComLibrary.GlobeVal.filesave.teststep[1].mstepPromptsItem[i].mcboitem.mlist[j]);
                            }

                            n.cbo.Tag = CComLibrary.GlobeVal.filesave.teststep[1].mstepPromptsItem[i];
                            n.cbo.SelectionChangeCommitted += new EventHandler(cbo_SelectionChangeCommitted);

                            n.cbo.SelectedIndex = Convert.ToInt32(CComLibrary.GlobeVal.filesave.teststep[1].mstepPromptsItem[i].itemvalue);
                            n.Dock = DockStyle.Fill;
                            tlp1.Controls.Add(n);
                        }
                    
                }
            }

            if (sel == 2)
            {
                this.lblbeforetest.Text = CComLibrary.GlobeVal.filesave.teststep[2].mtooltip;
            }

            if (sel == 3)
            {
                lblbeforecalc.Text = CComLibrary.GlobeVal.filesave.teststep[4].mtooltip;


                tlp3.Controls.Clear();

                tlp3.RowStyles.Clear();

                tlp3.RowCount = (CComLibrary.GlobeVal.filesave.teststep[4].mstepPromptsItem.Count);


                for (int i = 0; i < CComLibrary.GlobeVal.filesave.teststep[4].mstepPromptsItem.Count; i++)
                {
                    RowStyle r = new RowStyle();


                    r.SizeType = SizeType.Absolute;
                    r.Height = 40;

                    tlp3.RowStyles.Add(r);
                }
                tlp3.Height = (CComLibrary.GlobeVal.filesave.teststep[4].mstepPromptsItem.Count) * 40;


                for (int i = 0; i < CComLibrary.GlobeVal.filesave.teststep[4].mstepPromptsItem.Count; i++)
                {

                    CComLibrary.GlobeVal.filesave.teststep[4].mstepPromptsItem[i].getvalue();



                    if (CComLibrary.GlobeVal.filesave.teststep[4].mstepPromptsItem[i].itemkind == 0)
                    {

                        UserTextInput u = new UserTextInput();
                        u.lbltitle.Text = CComLibrary.GlobeVal.filesave.teststep[4].mstepPromptsItem[i].itemname;
                        u.txtvalue.Text = CComLibrary.GlobeVal.filesave.teststep[4].mstepPromptsItem[i].itemvalue.ToString();
                        u.Dock = DockStyle.Fill;
                        u.txtvalue.Tag = CComLibrary.GlobeVal.filesave.teststep[4].mstepPromptsItem[i];
                        u.txtvalue.TextChanged += new EventHandler(txtvalue_TextChanged);

                        tlp3.Controls.Add(u);
                    }

                    if (CComLibrary.GlobeVal.filesave.teststep[4].mstepPromptsItem[i].itemkind == 1)
                    {
                        UserSizeInput m = new UserSizeInput();
                        m.lbltitle.Text = CComLibrary.GlobeVal.filesave.teststep[4].mstepPromptsItem[i].itemname;
                        m.txtvalue.Text = CComLibrary.GlobeVal.filesave.teststep[4].mstepPromptsItem[i].itemvalue.ToString();
                        m.txtvalue.Tag = CComLibrary.GlobeVal.filesave.teststep[4].mstepPromptsItem[i];
                        m.txtvalue.TextChanged += new EventHandler(txtvalue2_TextChanged);
                        m.Dock = DockStyle.Fill;
                        tlp3.Controls.Add(m);
                    }

                    if (CComLibrary.GlobeVal.filesave.teststep[4].mstepPromptsItem[i].itemkind == 2)
                    {
                        UserComboInput n = new UserComboInput();
                        n.lbltitle.Text = CComLibrary.GlobeVal.filesave.teststep[4].mstepPromptsItem[i].itemname;

                        n.cbo.Items.Clear();
                        for (int j = 0; j < CComLibrary.GlobeVal.filesave.teststep[4].mstepPromptsItem[i].mcboitem.mlist.Count; j++)
                        {
                            n.cbo.Items.Add(CComLibrary.GlobeVal.filesave.teststep[4].mstepPromptsItem[i].mcboitem.mlist[j]);
                        }

                        n.cbo.Tag = CComLibrary.GlobeVal.filesave.teststep[4].mstepPromptsItem[i];
                        n.cbo.SelectionChangeCommitted += new EventHandler(cbo_SelectionChangeCommitted);

                        n.cbo.SelectedIndex = Convert.ToInt32(CComLibrary.GlobeVal.filesave.teststep[4].mstepPromptsItem[i].itemvalue);
                        n.Dock = DockStyle.Fill;
                        tlp3.Controls.Add(n);
                    }

                }
            }

            if (sel == 4)
            {
                this.lblspeaftertest.Text = CComLibrary.GlobeVal.filesave.teststep[6].mtooltip;
                tlp4.Controls.Clear();

                tlp4.RowStyles.Clear();

                tlp4.RowCount = (CComLibrary.GlobeVal.filesave.teststep[6].mstepPromptsItem.Count);


                for (int i = 0; i < CComLibrary.GlobeVal.filesave.teststep[6].mstepPromptsItem.Count; i++)
                {
                    RowStyle r = new RowStyle();


                    r.SizeType = SizeType.Absolute;
                    r.Height = 40;

                    tlp4.RowStyles.Add(r);
                }
                tlp4.Height = (CComLibrary.GlobeVal.filesave.teststep[6].mstepPromptsItem.Count) * 40;


                for (int i = 0; i < CComLibrary.GlobeVal.filesave.teststep[6].mstepPromptsItem.Count; i++)
                {

                    CComLibrary.GlobeVal.filesave.teststep[6].mstepPromptsItem[i].getvalue();



                    if (CComLibrary.GlobeVal.filesave.teststep[6].mstepPromptsItem[i].itemkind == 0)
                    {

                        UserTextInput u = new UserTextInput();
                        u.lbltitle.Text = CComLibrary.GlobeVal.filesave.teststep[6].mstepPromptsItem[i].itemname;
                        u.txtvalue.Text = CComLibrary.GlobeVal.filesave.teststep[6].mstepPromptsItem[i].itemvalue.ToString();
                        u.Dock = DockStyle.Fill;
                        u.txtvalue.Tag = CComLibrary.GlobeVal.filesave.teststep[6].mstepPromptsItem[i];
                        u.txtvalue.TextChanged += new EventHandler(txtvalue_TextChanged);

                        tlp4.Controls.Add(u);
                    }

                    if (CComLibrary.GlobeVal.filesave.teststep[6].mstepPromptsItem[i].itemkind == 1)
                    {
                        UserSizeInput m = new UserSizeInput();
                        m.lbltitle.Text = CComLibrary.GlobeVal.filesave.teststep[6].mstepPromptsItem[i].itemname;
                        m.txtvalue.Text = CComLibrary.GlobeVal.filesave.teststep[6].mstepPromptsItem[i].itemvalue.ToString();
                        m.txtvalue.Tag = CComLibrary.GlobeVal.filesave.teststep[6].mstepPromptsItem[i];
                        m.txtvalue.TextChanged += new EventHandler(txtvalue2_TextChanged);
                        m.Dock = DockStyle.Fill;
                        tlp4.Controls.Add(m);
                    }

                    if (CComLibrary.GlobeVal.filesave.teststep[6].mstepPromptsItem[i].itemkind == 2)
                    {
                        UserComboInput n = new UserComboInput();
                        n.lbltitle.Text = CComLibrary.GlobeVal.filesave.teststep[6].mstepPromptsItem[i].itemname;

                        n.cbo.Items.Clear();
                        for (int j = 0; j < CComLibrary.GlobeVal.filesave.teststep[6].mstepPromptsItem[i].mcboitem.mlist.Count; j++)
                        {
                            n.cbo.Items.Add(CComLibrary.GlobeVal.filesave.teststep[6].mstepPromptsItem[i].mcboitem.mlist[j]);
                        }

                        n.cbo.Tag = CComLibrary.GlobeVal.filesave.teststep[6].mstepPromptsItem[i];
                        n.cbo.SelectionChangeCommitted += new EventHandler(cbo_SelectionChangeCommitted);

                        n.cbo.SelectedIndex = Convert.ToInt32(CComLibrary.GlobeVal.filesave.teststep[6].mstepPromptsItem[i].itemvalue);
                        n.Dock = DockStyle.Fill;
                        tlp4.Controls.Add(n);
                    }

                }

            }

            if (sel == 5)
            {
                this.lblbeforefinish.Text = CComLibrary.GlobeVal.filesave.teststep[7].mtooltip;
            }

        }

        void cbo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ((sender as ComboBox).Tag as CComLibrary.PromptsItem).itemvalue = (sender as ComboBox).SelectedIndex;
        }

        void txtvalue_TextChanged(object sender, EventArgs e)
        {
            ((sender as TextBox).Tag as CComLibrary.PromptsItem).itemvalue = (sender as TextBox).Text;
        }

        void txtvalue2_TextChanged(object sender, EventArgs e)
        {
            ((sender as TextBox).Tag as CComLibrary.PromptsItem).itemvalue =Convert.ToDouble( (sender as TextBox).Text);
        }
        public UserControlWizard()
        {
            InitializeComponent();
            tabControl1.ItemSize = new Size(1, 1);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲

            TableLayoutPanel p;

            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i] is TableLayoutPanel)
                {
                    p = this.Controls[i] as TableLayoutPanel;
                    p.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(p, true, null);

                }
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void numericEdit1_ValueChanged(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.mspecount=Convert.ToInt32( numericEdit1.Value);
        }

        private void numericEdit2_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void numericEdit2_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
          
        }

        private void numericEdit2_Validated(object sender, EventArgs e)
        {
             CComLibrary.GlobeVal.filesave.currentspenumber = Convert.ToInt32(numericEdit2.Value - 1);
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            
        }

        private void btntest_Click(object sender, EventArgs e)
        {
            GlobeVal.userControltest1.btnStart_Click(null, null);
        }

        private void btnend_Click(object sender, EventArgs e)
        {
            GlobeVal.UserControlMain1.btnmain_Click(null, null);
        }

        private void btncontiune_Click(object sender, EventArgs e)
        {
            GlobeVal.UserControlMain1.OpenTest();
        }
    }
}
