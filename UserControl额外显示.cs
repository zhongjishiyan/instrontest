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
    public partial class UserControl额外显示 : UserControl
    {
        public UserControlMethod musercontrolmethod;
        private List<CComLibrary.PromptsItem> mlist;

        private void list_metersetvalue()
        {
            int i;
            CComLibrary.GlobeVal.filesave.mextrameter.Clear();
            for (i = 0; i < this.lstinclude.Items.Count; i++)
            {
                CComLibrary.GlobeVal.filesave.mextrameter.Add(this.lstinclude.list[i]);
            }
        }

        public void Init操作输入()
        {
           
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

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem.Count; i++)
            {
                lstincludetest.Items.Add(CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem[i].itemname);
                mlist.Add(CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem[i]);
            }

        }
        public void Init额外显示()
        {
            lstavail.ClearItem();
            for (int j = 0; j < ClsStaticStation.m_Global.mycls.allsignals.Count; j++)
            {

                if (CComLibrary.GlobeVal.filesave.mextrameter == null)
                {
                    lstavail.Items.Add(ClsStaticStation.m_Global.mycls.allsignals[j]);
                }
                else
                {
                    if (this.lstinclude.MatchItem(CComLibrary.GlobeVal.filesave.mextrameter,
                        ClsStaticStation.m_Global.mycls.allsignals[j]) == true)
                    {

                    }
                    else
                    {
                        lstavail.AddItem(ClsStaticStation.m_Global.mycls.allsignals[j]);
                    }


                }

            }

            lstinclude.ClearItem();
            for (int j = 0; j < CComLibrary.GlobeVal.filesave.mextrameter.Count; j++)
            {


                lstinclude.AddItem(CComLibrary.GlobeVal.filesave.mextrameter[j]);


            }


        }
        public  void Init(int sel)
        {

            tabControl1.SelectedIndex = sel;

            if (GlobeVal.UserControlMain1.btnmtest.Visible   == true)
            {
                tabControl1.Enabled = false;
            }
            else
            {
                tabControl1.Enabled = true;
            }



            if (sel == 0)
            {
                Init额外显示();
            }
            if (sel == 1)
            {
                Init操作输入();
            }
        }
        public  UserControl额外显示()
        {
            InitializeComponent();
            tabControl1.ItemSize = new Size(1, 1);
            mlist = new List<CComLibrary.PromptsItem>();
        }

        
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (this.lstinclude.Items.Count < 4)
            {
                if (this.lstavail.SelectedItem != null)
                {
                    this.lstinclude.AddItem(this.lstavail.list[this.lstavail.SelectedIndex]);

                    this.lstavail.RemoveItem(this.lstavail.SelectedIndex);

                    list_metersetvalue();

                }
            }
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            if (this.lstinclude.SelectedItem != null)
            {
                this.lstavail.AddItem(this.lstinclude.list[this.lstinclude.SelectedIndex]);
                this.lstinclude.RemoveItem(this.lstinclude.SelectedIndex);

                list_metersetvalue();
            }
        }

        private void btnup_Click(object sender, EventArgs e)
        {
            if (this.lstinclude.SelectedItem != null)
            {
                this.lstinclude.UpItem(this.lstinclude.SelectedIndex);
                list_metersetvalue();
            }
        }

        private void btndown_Click(object sender, EventArgs e)
        {
            if (this.lstinclude.SelectedItem != null)
            {
                this.lstinclude.DownItem(this.lstinclude.SelectedIndex);
                list_metersetvalue();
            }
        }

        private void lstinclude_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstinclude.SelectedIndex >= 0)
            {
                this.txtExplain.Text = lstinclude.list[lstinclude.SelectedIndex].cName;
                this.cbounit.Items.Clear();
                for (int i = 0; i < lstinclude.list[lstinclude.SelectedIndex].cUnitCount; i++)
                {
                    this.cbounit.Items.Add(lstinclude.list[lstinclude.SelectedIndex].cUnits[i]);
                }
                this.cbounit.SelectedIndex = lstinclude.list[lstinclude.SelectedIndex].cUnitsel;
                this.txtprecise.Text = lstinclude.list[lstinclude.SelectedIndex].precise.ToString();
                this.txtExplain.Tag = lstinclude.list[lstinclude.SelectedIndex];

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.txtExplain.Tag == null)
            {
            }
            else
            {
                (this.txtExplain.Tag as ClsStaticStation.ItemSignal).precise = Convert.ToInt32(txtprecise.Value);
                (this.txtExplain.Tag as ClsStaticStation.ItemSignal).cUnitsel = this.cbounit.SelectedIndex;

            }
        }

        private void btnadd1_Click(object sender, EventArgs e)
        {
            if (treeViewBeforeTest.SelectedNode != null)
            {
                lstincludetest.Items.Add(treeViewBeforeTest.SelectedNode.Text);



                
                    (treeViewBeforeTest.SelectedNode.Tag as CComLibrary.PromptsItem).group = false;
               

                mlist.Add(treeViewBeforeTest.SelectedNode.Tag as CComLibrary.PromptsItem);


                CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem.Clear();


                for (int i = 0; i < this.lstincludetest.Items.Count; i++)
                {
                    CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem.Add(mlist[i]);
                }
            }
        }

        private void btnremove1_Click(object sender, EventArgs e)
        {
            if (lstincludetest.SelectedIndex >= 0)
            {
                mlist.RemoveAt(lstincludetest.SelectedIndex);
                lstincludetest.Items.RemoveAt(lstincludetest.SelectedIndex);

                CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem.Clear();


                for (int i = 0; i < this.lstincludetest.Items.Count; i++)
                {
                    CComLibrary.GlobeVal.filesave.mFreeFormPromptsItem.Add(mlist[i]);
                }

            }
        }

      
        
    }
}
