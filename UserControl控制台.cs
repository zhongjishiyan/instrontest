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
    public partial class UserControl控制台 : UserControl
    {
        public UserControlMethod musercontrolmethod;


        public void Init主机()
        {
            if (CComLibrary.GlobeVal.filesave.mworkspace == 0)
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }


        }
        public void Init按键()
        {
            listavail.ClearItem();
            for (int j = 0; j < ClsStaticStation.m_Global.mycls.zerosignals.Count; j++)
            {

                if (CComLibrary.GlobeVal.filesave.mkey == null)
                {
                    listavail.Items.Add(ClsStaticStation.m_Global.mycls.zerosignals[j]);
                }
                else
                {
                    if (this.listinclude.MatchItem(CComLibrary.GlobeVal.filesave.mkey,
                        ClsStaticStation.m_Global.mycls.zerosignals[j]) == true)
                    {

                    }
                    else
                    {
                        listavail.AddItem(ClsStaticStation.m_Global.mycls.zerosignals[j]);
                    }


                }

            }

            listinclude.ClearItem();
            for (int j = 0; j < CComLibrary.GlobeVal.filesave.mkey.Count; j++)
            {


                listinclude.AddItem(CComLibrary.GlobeVal.filesave.mkey[j]);


            }

        }
        public void Init实时显示()
        {
            lstavail.ClearItem();
            for (int j = 0; j < ClsStaticStation.m_Global.mycls.allsignals.Count; j++)
            {

                if (CComLibrary.GlobeVal.filesave.mmeter == null)
                {
                    lstavail.AddItem(ClsStaticStation.m_Global.mycls.allsignals[j]);
                }
                else
                {
                    if (this.lstinclude.MatchItem(CComLibrary.GlobeVal.filesave.mmeter,
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
            for (int j = 0; j < CComLibrary.GlobeVal.filesave.mmeter.Count; j++)
            {


                lstinclude.AddItem(CComLibrary.GlobeVal.filesave.mmeter[j]);


            }


        }
        public void Init(int sel)
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

            if (sel == 0)
            {
                Init实时显示();
            }
            if (sel == 1)
            {
                Init按键();
            }
            if (sel == 2)
            {
                Init主机();
            }

        }
        public UserControl控制台()
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



        private void lstavail_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void list_keysetvalue()
        {
            int i;
            CComLibrary.GlobeVal.filesave.mkey.Clear();
            for (i = 0; i < this.listinclude.Items.Count; i++)
            {
                CComLibrary.GlobeVal.filesave.mkey.Add(this.listinclude.list[i]);
            }
        }

        private void list_metersetvalue()
        {
            int i;
            CComLibrary.GlobeVal.filesave.mmeter.Clear();
            for (i = 0; i < this.lstinclude.Items.Count; i++)
            {
                CComLibrary.GlobeVal.filesave.mmeter.Add(this.lstinclude.list[i]);
            }
        }
        private void btnaddmeter_Click(object sender, EventArgs e)
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

        private void btnremovemeter_Click(object sender, EventArgs e)
        {
            if (this.lstinclude.SelectedItem != null)
            {

                bool mb = false;
                for (int j = 0; j < ClsStaticStation.m_Global.mycls.allsignals.Count; j++)
                {


                    if (this.lstinclude.list[this.lstinclude.SelectedIndex].cName ==
                        ClsStaticStation.m_Global.mycls.allsignals[j].cName)
                    {
                        mb = true;
                    }




                }

                if (mb == true)
                {
                    this.lstavail.AddItem(this.lstinclude.list[this.lstinclude.SelectedIndex]);
                }

                this.lstinclude.RemoveItem(this.lstinclude.SelectedIndex);

                list_metersetvalue();
            }
        }

        private void btnupmeter_Click(object sender, EventArgs e)
        {
            if (this.lstinclude.SelectedItem != null)
            {
                this.lstinclude.UpItem(this.lstinclude.SelectedIndex);
                list_metersetvalue();
            }
        }

        private void btndownmeter_Click(object sender, EventArgs e)
        {
            if (this.lstinclude.SelectedItem != null)
            {
                this.lstinclude.DownItem(this.lstinclude.SelectedIndex);
                list_metersetvalue();
            }
        }

        private void btnaddkey_Click(object sender, EventArgs e)
        {
            if (this.listinclude.Items.Count < 4)
            {
                if (this.listavail.SelectedItem != null)
                {
                    this.listinclude.AddItem(this.listavail.list[this.listavail.SelectedIndex]);

                    this.listavail.RemoveItem(this.listavail.SelectedIndex);

                    list_keysetvalue();

                }
            }
        }

        private void btnremovekey_Click(object sender, EventArgs e)
        {
            if (this.listinclude.SelectedItem != null)
            {
                bool mb = false;
                for (int j = 0; j < ClsStaticStation.m_Global.mycls.allsignals.Count; j++)
                {


                    if (this.listinclude.list[this.listinclude.SelectedIndex].cName ==
                        ClsStaticStation.m_Global.mycls.allsignals[j].cName)
                    {
                        mb = true;
                    }




                }

                if (mb == true)
                {
                    this.listavail.AddItem(this.listinclude.list[this.listinclude.SelectedIndex]);
                }
                this.listinclude.RemoveItem(this.listinclude.SelectedIndex);

                list_keysetvalue();
            }
        }

        private void btnupkey_Click(object sender, EventArgs e)
        {
            if (this.listinclude.SelectedItem != null)
            {
                this.listinclude.UpItem(this.listinclude.SelectedIndex);
                list_keysetvalue();
            }
        }

        private void btndownkey_Click(object sender, EventArgs e)
        {
            if (this.listinclude.SelectedItem != null)
            {
                this.listinclude.DownItem(this.listinclude.SelectedIndex);
                list_keysetvalue();
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                CComLibrary.GlobeVal.filesave.mworkspace = 0;
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                CComLibrary.GlobeVal.filesave.mworkspace = 1;
            }


        }
    }
}
