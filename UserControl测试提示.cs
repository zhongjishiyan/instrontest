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
    public partial class UserControl测试提示 : UserControl
    {
        public UserControlMethod musercontrolmethod;
        private Boolean b = false;
        private int msel = 0;

        private List<CComLibrary.PromptsItem> mlist;

        private bool mchanged = false;
        public void Init提示顺序()
        {
            b = false;
            chkstep.Checked = CComLibrary.GlobeVal.filesave.mwizard;

            numericEdit1.Value = CComLibrary.GlobeVal.filesave.mspecount;

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                listView1.Items[i].Checked =false ;
               
            }
            for (int j=0;j<CComLibrary.GlobeVal.filesave.mstep.Count;j++)
            {
                 if (CComLibrary.GlobeVal.filesave.mstep[j].Id >=0)
                {
                        listView1.Items[CComLibrary.GlobeVal.filesave.mstep[j].Id].Checked = true;
                }
            }
            b = true;
            
        }

        public void Init开始前()
        {
            tlppara.Visible = true;
            mlist.Clear();
            lstincludetest.Items.Clear();

            TreeNode m1=new TreeNode() ;
            TreeNode m2 = new TreeNode();
            treeViewBeforeTest.Nodes.Clear();

            CComLibrary.GlobeVal.filesave.InitPrompts();

            string s = "";

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mpromptslist.Count ; i++)
            {
                if (s != CComLibrary.GlobeVal.filesave.mpromptslist[i].parentstring)
                {
                   
                    m1 = treeViewBeforeTest.Nodes.Add(CComLibrary.GlobeVal.filesave.mpromptslist[i].parentstring);
                    s = CComLibrary.GlobeVal.filesave.mpromptslist[i].parentstring;
                }

               
               m2= m1.Nodes.Add(CComLibrary.GlobeVal.filesave.mpromptslist[i].itemname);
               m2.Tag = CComLibrary.GlobeVal.filesave.mpromptslist[i];
                
              
            }

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.teststep[msel].mstepPromptsItem.Count; i++)
            {
                lstincludetest.Items.Add(CComLibrary.GlobeVal.filesave.teststep[msel].mstepPromptsItem[i].itemname);
               

                mlist.Add(CComLibrary.GlobeVal.filesave.teststep[msel].mstepPromptsItem[i]);
            }

           
        }

        public void Init试样试验前()
        {
            tlppara.Visible = true;
            mlist.Clear();
            lstincludetest.Items.Clear();

            TreeNode m1 = new TreeNode();
            TreeNode m2 = new TreeNode();
            treeViewBeforeTest.Nodes.Clear();

            CComLibrary.GlobeVal.filesave.InitPrompts();

            string s = "";

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mpromptslist.Count; i++)
            {
                if (CComLibrary.GlobeVal.filesave.mpromptslist[i].parentstring != "样品")
                {
                    if (s != CComLibrary.GlobeVal.filesave.mpromptslist[i].parentstring)
                    {

                        m1 = treeViewBeforeTest.Nodes.Add(CComLibrary.GlobeVal.filesave.mpromptslist[i].parentstring);
                        s = CComLibrary.GlobeVal.filesave.mpromptslist[i].parentstring;
                    }


                    m2 = m1.Nodes.Add(CComLibrary.GlobeVal.filesave.mpromptslist[i].itemname);
                    m2.Tag = CComLibrary.GlobeVal.filesave.mpromptslist[i];
                }

            }

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.teststep[msel].mstepPromptsItem.Count; i++)
            {
                lstincludetest.Items.Add(CComLibrary.GlobeVal.filesave.teststep[msel].mstepPromptsItem[i].itemname);
                mlist.Add(CComLibrary.GlobeVal.filesave.teststep[msel].mstepPromptsItem[i]);
            }

        }

        public void Init试验前()
        {

            tlppara.Visible = false;
        }

        public void Init计算前()
        {
            tlppara.Visible = true;
            mlist.Clear();
            lstincludetest.Items.Clear();

            TreeNode m1 = new TreeNode();
            TreeNode m2 = new TreeNode();
            treeViewBeforeTest.Nodes.Clear();

            CComLibrary.GlobeVal.filesave.InitPrompts();

            string s = "";

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mpromptslist.Count; i++)
            {
                if ((CComLibrary.GlobeVal.filesave.mpromptslist[i].parentstring == "试样数字输入")
                    ||(CComLibrary.GlobeVal.filesave.mpromptslist[i].parentstring == "试样尺寸输入"))
                {
                    if (s != CComLibrary.GlobeVal.filesave.mpromptslist[i].parentstring)
                    {

                        m1 = treeViewBeforeTest.Nodes.Add(CComLibrary.GlobeVal.filesave.mpromptslist[i].parentstring);
                        s = CComLibrary.GlobeVal.filesave.mpromptslist[i].parentstring;
                    }


                    m2 = m1.Nodes.Add(CComLibrary.GlobeVal.filesave.mpromptslist[i].itemname);
                    m2.Tag = CComLibrary.GlobeVal.filesave.mpromptslist[i];
                }

            }

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.teststep[msel].mstepPromptsItem.Count; i++)
            {
                lstincludetest.Items.Add(CComLibrary.GlobeVal.filesave.teststep[msel].mstepPromptsItem[i].itemname);
                mlist.Add(CComLibrary.GlobeVal.filesave.teststep[msel].mstepPromptsItem[i]);
            }

        }

        public void Init试样试验后()
        {
            tlppara.Visible = true;

            mlist.Clear();
            lstincludetest.Items.Clear();

            TreeNode m1 = new TreeNode();
            TreeNode m2 = new TreeNode();
            treeViewBeforeTest.Nodes.Clear();

            CComLibrary.GlobeVal.filesave.InitPrompts();

            string s = "";

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mpromptslist.Count; i++)
            {
                if (CComLibrary.GlobeVal.filesave.mpromptslist[i].parentstring == "试样文本输入")
                   

                {
                    if (s != CComLibrary.GlobeVal.filesave.mpromptslist[i].parentstring)
                    {

                        m1 = treeViewBeforeTest.Nodes.Add(CComLibrary.GlobeVal.filesave.mpromptslist[i].parentstring);
                        s = CComLibrary.GlobeVal.filesave.mpromptslist[i].parentstring;
                    }


                    m2 = m1.Nodes.Add(CComLibrary.GlobeVal.filesave.mpromptslist[i].itemname);
                    m2.Tag = CComLibrary.GlobeVal.filesave.mpromptslist[i];
                }

            }

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.teststep[msel].mstepPromptsItem.Count; i++)
            {
                lstincludetest.Items.Add(CComLibrary.GlobeVal.filesave.teststep[msel].mstepPromptsItem[i].itemname);
                mlist.Add(CComLibrary.GlobeVal.filesave.teststep[msel].mstepPromptsItem[i]);
            }
        }

        public void Init结束前()
        {
            tlppara.Visible = true;
            mlist.Clear();
            lstincludetest.Items.Clear();

            TreeNode m1 = new TreeNode();
            TreeNode m2 = new TreeNode();
            treeViewBeforeTest.Nodes.Clear();

            CComLibrary.GlobeVal.filesave.InitPrompts();

            string s = "";

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mpromptslist.Count; i++)
            {
                if (CComLibrary.GlobeVal.filesave.mpromptslist[i].parentstring == "样品")
                {
                    if (s != CComLibrary.GlobeVal.filesave.mpromptslist[i].parentstring)
                    {

                        m1 = treeViewBeforeTest.Nodes.Add(CComLibrary.GlobeVal.filesave.mpromptslist[i].parentstring);
                        s = CComLibrary.GlobeVal.filesave.mpromptslist[i].parentstring;
                    }


                    m2 = m1.Nodes.Add(CComLibrary.GlobeVal.filesave.mpromptslist[i].itemname);
                    m2.Tag = CComLibrary.GlobeVal.filesave.mpromptslist[i];
                }

            }

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.teststep[msel].mstepPromptsItem.Count; i++)
            {
                lstincludetest.Items.Add(CComLibrary.GlobeVal.filesave.teststep[msel].mstepPromptsItem[i].itemname);
                mlist.Add(CComLibrary.GlobeVal.filesave.teststep[msel].mstepPromptsItem[i]);
            }

        }

        public void Init结束()
        {
            tlppara.Visible = false;
        }

        public void Init(int sel)
        {
            mchanged = false;

            if (GlobeVal.UserControlMain1.btnmtest.Visible == true)
            {
                tabControl1.Enabled = false;
            }
            else
            {
                tabControl1.Enabled = true;
            }

            if (sel == 0)
            {
                tabControl1.SelectedIndex = 0;
            }
            else
            {
                tabControl1.SelectedIndex = 1;
                tabControl2.SelectedIndex = sel - 1;
              
            }
            if (sel == 0)
            {
               
                Init提示顺序(); 
            }
            if (sel == 1)
            {
                msel = 0;
                rtxtooltip.Text = CComLibrary.GlobeVal.filesave.teststep[0].mtooltip;    
                Init开始前();
            }

            if (sel == 2)
            {
                rtxtooltip.Text = CComLibrary.GlobeVal.filesave.teststep[1].mtooltip;
                msel = 1;
                Init试样试验前();
            }

            if (sel == 3)
            {
                msel = 2;
                rtxtooltip.Text = CComLibrary.GlobeVal.filesave.teststep[2].mtooltip; 
                Init试验前();
            }

            if (sel == 4)
            {
                rtxtooltip.Text = CComLibrary.GlobeVal.filesave.teststep[4].mtooltip;
                msel = 4;
                Init计算前();
            }

            if (sel == 5)
            {
                rtxtooltip.Text = CComLibrary.GlobeVal.filesave.teststep[6].mtooltip;
                msel = 6;
                Init试样试验后();
            }

            if (sel == 6)
            {
                rtxtooltip.Text = CComLibrary.GlobeVal.filesave.teststep[7].mtooltip;
                msel = 7;
                Init结束前();
            }

            if (sel == 7)
            {
                rtxtooltip.Text = CComLibrary.GlobeVal.filesave.teststep[8].mtooltip;

                msel = 8;
                Init结束();
            }

            mchanged = true;

        }
        public UserControl测试提示()
        {
            InitializeComponent();
            tabControl1.ItemSize = new Size(1, 1);
            tabControl2.ItemSize = new Size(1, 1);
            mlist = new List<CComLibrary.PromptsItem>();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chkstep_CheckedChanged(object sender, EventArgs e)
        {
            CComLibrary.GlobeVal.filesave.mwizard = chkstep.Checked;
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            
            if (b == true)
            {
                CComLibrary.GlobeVal.filesave.mstep.Clear();
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i] == null)
                    {
                    }
                    else
                    {

                        if (listView1.Items[i].Checked == true)
                        {
                            CComLibrary.GlobeVal.filesave.mstep.Add(CComLibrary.GlobeVal.filesave.teststep[i]);
                        }
                    }
                }

                int k=-1;
                int c = 0;

                CComLibrary.GlobeVal.filesave.mtestlist.Clear();

                if (CComLibrary.GlobeVal.filesave.mstep.Count > 0)
                {
                    CComLibrary.GlobeVal.filesave.mtestlist.Add(CComLibrary.GlobeVal.filesave.mstep[0].Id);
                }
                
                for (int i = 0; i < CComLibrary.GlobeVal.filesave.mstep.Count-1; i++)
                {
                    if (CComLibrary.GlobeVal.filesave.mstep[i].havedloop == false)
                    {
                        CComLibrary.GlobeVal.filesave.mstep[i].nextstep = CComLibrary.GlobeVal.filesave.mstep[i + 1].Id;

                        CComLibrary.GlobeVal.filesave.mtestlist.Add(CComLibrary.GlobeVal.filesave.mstep[i].nextstep); 
                    }
                    else
                    {
                        if (CComLibrary.GlobeVal.filesave.mstep[i + 1].havedloop == true)
                        {
                            CComLibrary.GlobeVal.filesave.mstep[i].nextstep = CComLibrary.GlobeVal.filesave.mstep[i + 1].Id;
                            CComLibrary.GlobeVal.filesave.mtestlist.Add(CComLibrary.GlobeVal.filesave.mstep[i].nextstep); 
                        }
                        else
                        {
                            if (c < numericEdit1.Value-1)
                            {
                                c = c + 1;
                                for (int j = 0; j < CComLibrary.GlobeVal.filesave.mstep.Count; j++)
                                {

                                    if (CComLibrary.GlobeVal.filesave.mstep[j].havedloop == true)
                                    {
                                        k = CComLibrary.GlobeVal.filesave.mstep[j].Id;
                                        i = j-1;
                                        break;
                                    }
                                }

                                CComLibrary.GlobeVal.filesave.mstep[i].nextstep = k;
                              
                                CComLibrary.GlobeVal.filesave.mtestlist.Add(CComLibrary.GlobeVal.filesave.mstep[i].nextstep); 
                            }
                            else
                            {
                                CComLibrary.GlobeVal.filesave.mstep[i].nextstep = CComLibrary.GlobeVal.filesave.mstep[i + 1].Id;
                                CComLibrary.GlobeVal.filesave.mtestlist.Add(CComLibrary.GlobeVal.filesave.mstep[i].nextstep); 
                            }
                        }
                    }
                }

                listBox1.Items.Clear();

                for (int i = 0; i < CComLibrary.GlobeVal.filesave.mtestlist.Count ; i++)
                {
                    listBox1.Items.Add(CComLibrary.GlobeVal.filesave.mtestlist[i].ToString());
                }

               
            }
        }

        private void numericEdit1_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void rtxtooltip_TextChanged(object sender, EventArgs e)
        {
            if (mchanged == true)
            {
                CComLibrary.GlobeVal.filesave.teststep[msel].mtooltip = rtxtooltip.Text;
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (treeViewBeforeTest.SelectedNode!=null)
            {
            lstincludetest.Items.Add(treeViewBeforeTest.SelectedNode.Text);



            if ((msel == 0) || (msel == 7))
            {
                (treeViewBeforeTest.SelectedNode.Tag as CComLibrary.PromptsItem).group = true;
            }
            else
            {
                (treeViewBeforeTest.SelectedNode.Tag as CComLibrary.PromptsItem).group = false;
            }

            mlist.Add(treeViewBeforeTest.SelectedNode.Tag as CComLibrary.PromptsItem);

           
            CComLibrary.GlobeVal.filesave.teststep[msel].mstepPromptsItem.Clear();
            

            for (int i = 0; i <this.lstincludetest.Items.Count; i++)
            {
                CComLibrary.GlobeVal.filesave.teststep[msel].mstepPromptsItem.Add(mlist[i]);
            }
            }
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            if (lstincludetest.SelectedIndex>=0)
            {
                mlist.RemoveAt(lstincludetest.SelectedIndex);
                lstincludetest.Items.RemoveAt(lstincludetest.SelectedIndex);

                CComLibrary.GlobeVal.filesave.teststep[msel].mstepPromptsItem.Clear();


                for (int i = 0; i < this.lstincludetest.Items.Count; i++)
                {
                    CComLibrary.GlobeVal.filesave.teststep[msel].mstepPromptsItem.Add(mlist[i]);
                }

            }
        }

        private void numericEdit1_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            CComLibrary.GlobeVal.filesave.mspecount = Convert.ToInt32(numericEdit1.Value);
        }
    }
}
