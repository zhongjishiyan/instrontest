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
    public partial class UserControlProcess : UserControl
    {

        
        public void Init()
        {

            listViewPro1.Clear();
            ColumnHeader f = new ColumnHeader();
            f.Width = 20;
            listViewPro1.Columns.Add(f);

            CComLibrary.GlobeVal.filesave.InitExplainList();

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mexplainlist.Count; i++)
            {
                f = new ColumnHeader();
                f.Width = 100;
                listViewPro1.Columns.Add(f);
            }


            ListViewItem v = new ListViewItem();
            listViewPro1.Items.Add(v);
            v = new ListViewItem();
            listViewPro1.Items.Add(v);
            v = new ListViewItem();
            listViewPro1.Items.Add(v);

         

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mseglist.Count; i++)
            {
                if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 1)
                {
                    v.SubItems.Add("步骤" + (i + 1).ToString());
                }
                else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 3)
                {
                    v.SubItems.Add(CComLibrary.GlobeVal.filesave.mseglist[i].mseq.stepname);
                }
            }
            v = new ListViewItem();
            listViewPro1.Items.Add(v);

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mseglist.Count; i++)
            {
                v.SubItems.Add("");
             }

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mseglist.Count; i++)
            {
                if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 1)
                {
                    if (CComLibrary.GlobeVal.filesave.mseglist[i].returncount > 0)
                    {
                        v.SubItems[i + 1].Text = CComLibrary.GlobeVal.filesave.mseglist[i].currentcount.ToString() + "|"+ CComLibrary.GlobeVal.filesave.mseglist[i].returncount.ToString();
                    }
                }
                else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 3)
                {
                    if (CComLibrary.GlobeVal.filesave.mseglist[i].mseq.loop == true)
                    {
                        v.SubItems[i+1].Text = CComLibrary.GlobeVal.filesave.mseglist[i].mseq.finishedloopcount.ToString()+  "|" + CComLibrary.GlobeVal.filesave.mseglist[i].mseq.loopcount.ToString();
                    }
                }
            }

            int w = 0;

            for (int i=0;i<listViewPro1.Columns.Count;i++)
            {
                w = w + listViewPro1.Columns[i].Width;
            }

            listViewPro1.Width = w+30;

                return;
        }
        public UserControlProcess()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if (CComLibrary.GlobeVal.filesave==null)
            {
                return;
            }
            if ((GlobeVal.myarm.mcurseg >= 0) && (GlobeVal.myarm.mcurseg < CComLibrary.GlobeVal.filesave.mseglist.Count ))
            {
                if (listViewPro1.curstep != GlobeVal.myarm.mcurseg + 1)
                {


                    listViewPro1.curstep = GlobeVal.myarm.mcurseg + 1;


                    int i = GlobeVal.myarm.mcurseg;
                    /*
                    for (int j = 0; j < CComLibrary.GlobeVal.filesave.mseglist.Count; j++)
                    {
                        if (CComLibrary.GlobeVal.filesave.mseglist[j].returncount > 0)
                        {
                            CComLibrary.GlobeVal.filesave.mseglist[j].currentcount = GlobeVal.myarm.current_returncount;
                            listViewPro1.Items[3].SubItems[j + 1].Text = CComLibrary.GlobeVal.filesave.mseglist[j].currentcount.ToString() + "|" + CComLibrary.GlobeVal.filesave.mseglist[j].returncount.ToString();
                        }
                    }
                     */

                    if (CComLibrary.GlobeVal.filesave.mseglist[i].returncount > 0)
                    {
                       // CComLibrary.GlobeVal.filesave.mseglist[i].currentcount = GlobeVal.myarm.current_returncount;

                        //出过错

                        listViewPro1.Items[3].SubItems[i + 1].Text = (CComLibrary.GlobeVal.filesave.mseglist[i].mseq.finishedloopcount+1).ToString() + "|" + CComLibrary.GlobeVal.filesave.mseglist[i].returncount.ToString();
                    }

                listViewPro1.RedrawItems(2, 3, true );
                    //listViewPro1.Refresh();
                }
            }
        
        }

        private void UserControlProcess_Paint(object sender, PaintEventArgs e)
        {
            listViewPro1.Refresh();
        }
    }
}
