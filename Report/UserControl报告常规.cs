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
    public partial class UserControl报告常规 : UserControl
    {
        //public UserReport GlobeVal.muserreport;
        private ReportItem mreportitem;

        public void Init页脚()
        {
            bool b = false;
           this.cbopostionfooter.Items.Clear();
            if (GlobeVal.mysys.language == 0)
            {
                this.cbopostionfooter.Items.Add("居左");
                this.cbopostionfooter.Items.Add("居中");
                this.cbopostionfooter.Items.Add("居右");
            }
            else
            {
                this.cbopostionfooter.Items.Add("Left");
                this.cbopostionfooter.Items.Add("Middle");
                this.cbopostionfooter.Items.Add("Right");
            }
           cbopostionfooter.SelectedIndex = GlobeVal.muserreport.mReportApp.footerposition;

           listBox3.ClearItem();
           for (int i = 0; i < GlobeVal.muserreport.mReportApp.mreportitemlist.Count; i++)
           {
               b = false;
               for (int j = 0; j< GlobeVal.muserreport.mReportApp.mreportfooter.Count; j++)
               {
                  
                   if (GlobeVal.muserreport.mReportApp.mreportfooter[j].Name == GlobeVal.muserreport.mReportApp.mreportitemlist[i].Name)
                   {
                       b = true;
                   }
                   
               }
               if ((GlobeVal.muserreport.mReportApp.mreportitemlist[i].kind == 1) || (GlobeVal.muserreport.mReportApp.mreportitemlist[i].kind == 1))
               {
                   listBox3.AddItem(GlobeVal.muserreport.mReportApp.mreportitemlist[i]);
               }
               else
               {
                   if (b == false)
                   {
                       listBox3.AddItem(GlobeVal.muserreport.mReportApp.mreportitemlist[i]);
                   }
               }
           }
           listReport3.ClearItem();
           for (int i = 0; i < GlobeVal.muserreport.mReportApp.mreportfooter.Count; i++)
           {
               listReport3.AddItem(GlobeVal.muserreport.mReportApp.mreportfooter[i]);
           }

        }


        public void Init页眉()
        {
            bool f = false;
            cbopostionheader.Items.Clear();
            if (GlobeVal.mysys.language == 0)
            {
                cbopostionheader.Items.Add("居左");
                cbopostionheader.Items.Add("居中");
                cbopostionheader.Items.Add("居右");
            }
            else
            {
                cbopostionheader.Items.Add("Left");
                cbopostionheader.Items.Add("Middle");
                cbopostionheader.Items.Add("Right");

            }
            cbopostionheader.SelectedIndex = GlobeVal.muserreport.mReportApp.headerposition;
            listBox2.ClearItem();
            for (int i = 0; i < GlobeVal.muserreport.mReportApp.mreportitemlist.Count; i++)
            {
                f = false;
                for (int j = 0; j < GlobeVal.muserreport.mReportApp.mreportheader.Count; j++)
                {
                    if (GlobeVal.muserreport.mReportApp.mreportheader[j].Name == GlobeVal.muserreport.mReportApp.mreportitemlist[i].Name)
                    {
                        f = true;
                    }
                }

                if ((GlobeVal.muserreport.mReportApp.mreportitemlist[i].kind == 1) || (GlobeVal.muserreport.mReportApp.mreportitemlist[i].kind == 2))
                {
                    listBox2.AddItem(GlobeVal.muserreport.mReportApp.mreportitemlist[i]);
                }
                else
                {
                    if (f == false)
                    {
                        listBox2.AddItem(GlobeVal.muserreport.mReportApp.mreportitemlist[i]);
                    }
                }
            }


           
            listReport2.ClearItem();
            for (int i = 0; i < GlobeVal.muserreport.mReportApp.mreportheader.Count; i++)
            {
                listReport2.AddItem(GlobeVal.muserreport.mReportApp.mreportheader[i]);
            }


        }

        public void Init常规()
        {
            //this.peditMargins.Source=new NationalInstruments.UI.PropertyEditorSource (GlobeVal.muserreport.mReportApp,"Margins");

            rtxttemplatename.Text = CComLibrary.GlobeVal.filesave.ReportTemplate; 

            nummargins.Value = GlobeVal.muserreport.mReportApp.Margins;

            cbopagesize.Items.Clear();

            for (int i=0;i<GlobeVal.muserreport.mReportApp.mPagelist.Count;i++)
            {
              cbopagesize.Items.Add(GlobeVal.muserreport.mReportApp.mPagelist[i].Name.ToString());

                if (GlobeVal.muserreport.mReportApp.mPagelist[i].Name.ToString()==GlobeVal.muserreport.mReportApp.pagesize)
                {
                    cbopagesize.SelectedIndex =i;
                }
               
            }


            cboLandscape.Items.Clear();
            if (GlobeVal.mysys.language == 0)
            {
                cboLandscape.Items.Add("横向");
                cboLandscape.Items.Add("竖向");
            }
            else
            {
                cboLandscape.Items.Add("Landscape");
                cboLandscape.Items.Add("Vertical");
            }
            if (GlobeVal.muserreport.mReportApp.Landscape == true)
            {
                cboLandscape.SelectedIndex = 0;
            }
            else
            {
                cboLandscape.SelectedIndex = 1;
            }

            if (GlobeVal.mysys.AppUserLevel == 0)
            {
                grp1.Enabled = false;
            }
            else
            {
                grp1.Enabled = true;
            }

        }

        public void Init报告正文()
        {
            bool f = false;

            listBox1.ClearItem();

            for (int i = 0; i < GlobeVal.muserreport.mReportApp.mreportitemlist.Count; i++)
            {
                f = false;

                
                for (int j = 0; j < GlobeVal.muserreport.mReportApp.mreportbody.Count; j++)
                {
                    if (GlobeVal.muserreport.mReportApp.mreportitemlist[i].Name == GlobeVal.muserreport.mReportApp.mreportbody[j].Name)
                    {
                        f = true;
                    }
                }

                if ((GlobeVal.muserreport.mReportApp.mreportitemlist[i].kind == 1) || (GlobeVal.muserreport.mReportApp.mreportitemlist[i].kind == 2))
                {
                    listBox1.AddItem(GlobeVal.muserreport.mReportApp.mreportitemlist[i]);
                }
                else
                {
                    if (f == false)
                    {
                        listBox1.AddItem(GlobeVal.muserreport.mReportApp.mreportitemlist[i]);
                    }
                }
            }
            listReport1.ClearItem();
            for (int i = 0; i < GlobeVal.muserreport.mReportApp.mreportbody.Count; i++)
            {
                listReport1.AddItem(GlobeVal.muserreport.mReportApp.mreportbody[i]); 
            }

            cbobodypostion.Items.Clear();

            if (GlobeVal.mysys.language == 0)
            {
                cbobodypostion.Items.Add("居左");
                cbobodypostion.Items.Add("居中");
                cbobodypostion.Items.Add("居右");
            }
            else
            {
                cbobodypostion.Items.Add("Left");
                cbobodypostion.Items.Add("Middle");
                cbobodypostion.Items.Add("Right");
            }

        }

        public void Init(int sel)
        {

            tabControl1.SelectedIndex = sel;
            tabControl2.SelectedIndex = sel;

            splitContainer1.SplitterDistance = this.Width / 3 * 2;
           
            if (sel == 0)
            {
                Init常规();
            }
            if (sel == 1)
            {
                Init页眉();
            }
            if (sel == 2)
            {
                Init报告正文();
            }

            if (sel == 3)
            {
                Init页脚();
            }

           
        }
        public  UserControl报告常规()
        {
            InitializeComponent();
            tabControl1.ItemSize = new Size(1, 1);
            tabControl2.ItemSize = new Size(1, 1);

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void propertyEditor1_SourceValueChanged(object sender, EventArgs e)
        {
            //GlobeVal.muserreport.daPrintDocument.Margins = (System.Drawing.Printing.Margins) propertyEditor1.Source.Value;
        }

        private void propertyEditor2_SourceValueChanged(object sender, EventArgs e)
        {
            //GlobeVal.muserreport.daPrintDocument.PaperType = (AppleReport.Paper.Type)propertyEditor2.Source.Value;
        }

        private void propertyEditor3_SourceValueChanged(object sender, EventArgs e)
        {
            //GlobeVal.muserreport.daPrintDocument.DefaultPageSettings.Landscape = (bool)propertyEditor3.Source.Value;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            GlobeVal.muserreport.nextpage();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            GlobeVal.muserreport.prepage();
        }

        private void nummargins_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            GlobeVal.muserreport.mReportApp.Margins=Convert.ToSingle(nummargins.Value);
        }

        private void cbopagesize_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GlobeVal.muserreport.mReportApp.pagesize = cbopagesize.Text;
        }

        private void cboLandscape_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboLandscape.SelectedIndex == 0)
            {
                GlobeVal.muserreport.mReportApp.Landscape = true;
            }
            else
            {
                GlobeVal.muserreport.mReportApp.Landscape = false;
            }
        }
        private void list_setvalue()
        {
            int i;
            GlobeVal.muserreport.mReportApp.mreportbody.Clear();
            for (i = 0; i < this.listReport1.Items.Count; i++)
            {
                GlobeVal.muserreport.mReportApp.mreportbody.Add(this.listReport1.mlist[i]);
            }
        }

        private void list_setvalue2()
        {
            int i;

            GlobeVal.muserreport.mReportApp.mreportheader.Clear();
            for (i = 0; i < this.listReport2.Items.Count; i++)
            {
                GlobeVal.muserreport.mReportApp.mreportheader.Add(this.listReport2.mlist[i]);
            }


        }

        private void list_setvalue3()
        {
            int i;
            GlobeVal.muserreport.mReportApp.mreportfooter.Clear();
            for (i = 0; i < this.listReport3.Items.Count; i++)
            {
                GlobeVal.muserreport.mReportApp.mreportfooter.Add(this.listReport3.mlist[i]);
            }


        }
        private void btnreportadd_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItem != null)
            {
                this.listReport1.AddItem(this.listBox1.mlist[this.listBox1.SelectedIndex]);

                if ((this.listBox1.mlist[this.listBox1.SelectedIndex].kind == 0)||(this.listBox1.mlist[this.listBox1.SelectedIndex].kind == 3)
                    ||(this.listBox1.mlist[this.listBox1.SelectedIndex].kind == 4))

                {
                    this.listBox1.RemoveItem(this.listBox1.SelectedIndex);
                }

             

                list_setvalue();

            }
        }

        private void btnreportremove_Click(object sender, EventArgs e)
        {
            if (this.listReport1.SelectedItem != null)
            {
               

                if ((this.listReport1.mlist[this.listReport1.SelectedIndex].kind == 0)|| (this.listReport1.mlist[this.listReport1.SelectedIndex].kind == 3)
                    ||(this.listReport1.mlist[this.listReport1.SelectedIndex].kind == 4))
                {
                    for (int i = 0; i < GlobeVal.muserreport.mReportApp.mreportitemlist.Count; i++)
                    {
                        if (this.listReport1.mlist[this.listReport1.SelectedIndex].Name == GlobeVal.muserreport.mReportApp.mreportitemlist[i].Name)
                        {
                            this.listBox1.AddItem(this.listReport1.mlist[this.listReport1.SelectedIndex]);
                        }
                    }
                }

                this.listReport1.RemoveItem(this.listReport1.SelectedIndex);

                list_setvalue();
            }
        }

        private void btnreportup_Click(object sender, EventArgs e)
        {
            if (this.listReport1.SelectedItem != null)
            {
                this.listReport1.UpItem(this.listReport1.SelectedIndex);
                list_setvalue();
            }
        }

        private void btnreportdown_Click(object sender, EventArgs e)
        {
            if (this.listReport1.SelectedItem != null)
            {
                this.listReport1.DownItem(this.listReport1.SelectedIndex);
                list_setvalue();
            }
        }

        private void btnheaderadd_Click(object sender, EventArgs e)
        {
            if (this.listBox2.SelectedItem != null)
            {
                
                this.listReport2.AddItem(this.listBox2.mlist[this.listBox2.SelectedIndex]);
                if ((this.listBox2.mlist[this.listBox2.SelectedIndex].kind == 0) ||(this.listBox2.mlist[this.listBox2.SelectedIndex].kind == 3) ||

                    (this.listBox2.mlist[this.listBox2.SelectedIndex].kind == 4))

                {
                    this.listBox2.RemoveItem(this.listBox2.SelectedIndex);
                }


                list_setvalue2();

            }
        }

        private void btnheaderremove_Click(object sender, EventArgs e)
        {
            if (this.listReport2.SelectedItem != null)
            {
                if ((this.listReport2.mlist[this.listReport2.SelectedIndex].kind == 0)||(this.listReport2.mlist[this.listReport2.SelectedIndex].kind == 3)
                    ||(this.listReport2.mlist[this.listReport2.SelectedIndex].kind == 4))
                {
                    for (int i = 0; i < GlobeVal.muserreport.mReportApp.mreportitemlist.Count; i++)
                    {
                        if (this.listReport2.mlist[this.listReport2.SelectedIndex].Name == GlobeVal.muserreport.mReportApp.mreportitemlist[i].Name)
                        {
                            this.listBox2.AddItem(this.listReport2.mlist[this.listReport2.SelectedIndex]);
                        }
                    }
                }
                this.listReport2.RemoveItem(this.listReport2.SelectedIndex);

                list_setvalue2();
            }
        }

        private void btnheaderup_Click(object sender, EventArgs e)
        {
            if (this.listReport2.SelectedItem != null)
            {
                this.listReport2.UpItem(this.listReport2.SelectedIndex);
                list_setvalue2();
            }
        }

        private void btnheaderdown_Click(object sender, EventArgs e)
        {
            if (this.listReport2.SelectedItem != null)
            {
                this.listReport2.DownItem(this.listReport2.SelectedIndex);
                list_setvalue2();
            }
        }

        private void btnfooteradd_Click(object sender, EventArgs e)
        {
            if (this.listBox3.SelectedItem != null)
            {
                this.listReport3.AddItem(this.listBox3.mlist[this.listBox3.SelectedIndex]);
                if ((this.listBox3.mlist[this.listBox3.SelectedIndex].kind == 0) || (this.listBox3.mlist[this.listBox3.SelectedIndex].kind == 3) ||

                   (this.listBox3.mlist[this.listBox3.SelectedIndex].kind == 4))
                {
                    this.listBox3.RemoveItem(this.listBox3.SelectedIndex);
                }

                list_setvalue3();

            }
        }

        private void btnfooterremove_Click(object sender, EventArgs e)
        {
            if (this.listReport3.SelectedItem != null)
            {
                if ((this.listReport3.mlist[this.listReport3.SelectedIndex].kind == 0) || (this.listReport3.mlist[this.listReport3.SelectedIndex].kind == 3)
                   || (this.listReport3.mlist[this.listReport3.SelectedIndex].kind == 4))
                {
                    for (int i = 0; i < GlobeVal.muserreport.mReportApp.mreportitemlist.Count; i++)
                    {
                        if (this.listReport3.mlist[this.listReport3.SelectedIndex].Name==GlobeVal.muserreport.mReportApp.mreportitemlist[i].Name)
                        {
                            this.listBox3.AddItem(this.listReport3.mlist[this.listReport3.SelectedIndex]);
                        }
                    }
                }
                this.listReport3.RemoveItem(this.listReport3.SelectedIndex);

                list_setvalue3();
            }
        }

        private void btnfooterup_Click(object sender, EventArgs e)
        {
            if (this.listReport3.SelectedItem != null)
            {
                this.listReport3.UpItem(this.listReport3.SelectedIndex);
                list_setvalue3();
            }
        }

        private void btnfooterdown_Click(object sender, EventArgs e)
        {
            if (this.listReport3.SelectedItem != null)
            {
                this.listReport3.DownItem(this.listReport3.SelectedIndex);
                list_setvalue3();
            }
        }

        private void listReport2_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.listReport2.SelectedIndex>=0)
            {
                mreportitem = this.listReport2.mlist[this.listReport2.SelectedIndex];
                numheaderspace.Value = this.listReport2.mlist[this.listReport2.SelectedIndex].mspace;
                chkheader.Checked = this.listReport2.mlist[this.listReport2.SelectedIndex].showcaption;


            if (this.listReport2.mlist[this.listReport2.SelectedIndex].kind == 2)
            {
                lblheaderfont.Visible = false;
                peditheaderfont.Visible = false;
                lblheadertxt.Visible = false;
                txtheader.Visible = false;
                lblheaderpicture.Visible = true;
                tlpheaderpicture.Visible = true;
                txtheaderpicture.Text = this.listReport2.mlist[this.listReport2.SelectedIndex].filename;

            }
            else
            {
                if (this.listReport2.mlist[this.listReport2.SelectedIndex].kind == 0)
                {
                    lblheadertxt.Visible = false ;
                    txtheader.Visible = false ;
                }
                else
                {
                    lblheadertxt.Visible = true;
                    txtheader.Visible = true;

                }
                lblheaderpicture.Visible = false ;
                tlpheaderpicture.Visible = false ;
               
                lblheaderfont.Visible = true;
                peditheaderfont.Visible = true ;
                this.peditheaderfont.Source = new NationalInstruments.UI.PropertyEditorSource(
                  this.listReport2.mlist[this.listReport2.SelectedIndex], "font");

                txtheader.Text = this.listReport2.mlist[this.listReport2.SelectedIndex].txtresult;
            }

            }

        }

        private void txtheader_TextChanged(object sender, EventArgs e)
        {
            if (mreportitem == null)
            {
            }
            else
            {
                if (listReport2.SelectedIndex >= 0)
                {
                    mreportitem.txtresult = txtheader.Text;
                    GlobeVal.muserreport.mReportApp.mreportheader[listReport2.SelectedIndex].txtresult = txtheader.Text;

                }
            }
        }

        private void btnheaderpicture_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "(*.bmp" + ")|*.bmp";
            openFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\bmp\\";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == "")
            {

            }

            else
            {

                if (mreportitem == null)
                {
                }
                else
                {
                    txtheaderpicture.Text = System.IO.Path.GetFileName(openFileDialog1.FileName);
                   
                }

            }

        }

        private void txtheaderpicture_TextChanged(object sender, EventArgs e)
        {
            if (listReport2.SelectedIndex >= 0)
            {

                mreportitem.filename = txtheaderpicture.Text;
                GlobeVal.muserreport.mReportApp.mreportheader[listReport2.SelectedIndex].filename = txtheaderpicture.Text;
            }
           
        }

        private void numheaderspace_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            if (listReport2.SelectedIndex >= 0)
            {

               mreportitem.mspace = numheaderspace.Value;
                GlobeVal.muserreport.mReportApp.mreportheader[listReport2.SelectedIndex].mspace = numheaderspace.Value;
            }
        }

        private void peditheaderfont_SourceValueChanged(object sender, EventArgs e)
        {
            if (listReport2.SelectedIndex >= 0)
            {

                mreportitem.font = peditheaderfont.Source.Value as Font;

                GlobeVal.muserreport.mReportApp.mreportheader[listReport2.SelectedIndex].font = peditheaderfont.Source.Value as Font;
            }
        }

        private void numheaderspace_ValueChanged(object sender, EventArgs e)
        {
            

        }

        private void cbopostionheader_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GlobeVal.muserreport.mReportApp.headerposition = cbopostionheader.SelectedIndex;
        }

        private void chkheader_CheckedChanged(object sender, EventArgs e)
        {
            if (listReport2.SelectedIndex >= 0)
            {
                mreportitem.showcaption = chkheader.Checked;
                GlobeVal.muserreport.mReportApp.mreportheader[listReport2.SelectedIndex].showcaption = chkheader.Checked ;
            }
        }

        private void listReport1_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.listReport1.SelectedIndex >= 0)
            {
                mreportitem = this.listReport1.mlist[this.listReport1.SelectedIndex];
                cbobodypostion.SelectedIndex = this.listReport1.mlist[this.listReport1.SelectedIndex].align;

                this.numbodyspace.Value = this.listReport1.mlist[this.listReport1.SelectedIndex].mspace;
                this.numbodymspace.Value = this.listReport1.mlist[this.listReport1.SelectedIndex].vspace;

                this.chkbody.Checked = this.listReport1.mlist[this.listReport1.SelectedIndex].showcaption;


                if (this.listReport1.mlist[this.listReport1.SelectedIndex].kind == 2)
                {
                    lblbodyfont.Visible = false;
                    peditbodyfont.Visible = false;
                    lblbodytxt.Visible = false;
                    this.txtbodyvalue.Visible = false;
                    lblbodypicture.Visible = true;
                    tlpbody.Visible = true;
                    txtbodypicture.Text = this.listReport1.mlist[this.listReport1.SelectedIndex].filename;

                }
                else
                {
                    if (this.listReport1.mlist[this.listReport1.SelectedIndex].kind == 0)
                    {
                        lblbodytxt.Visible = false;
                        this.txtbodyvalue.Visible = false;
                    }
                    else
                    {
                        lblbodytxt.Visible = true;
                        this.txtbodyvalue.Visible = true;

                    }
                    lblbodypicture.Visible = false;
                    tlpbody.Visible = false;

                    lblbodyfont.Visible = true;
                    peditbodyfont.Visible = true;
                    this.peditbodyfont.Source = new NationalInstruments.UI.PropertyEditorSource(
                      this.listReport1.mlist[this.listReport1.SelectedIndex], "font");

                    txtbodyvalue.Text = this.listReport1.mlist[this.listReport1.SelectedIndex].txtresult;
                }
            }

        }

        private void numbodyspace_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            if (listReport1.SelectedIndex >= 0)
            {

                mreportitem.mspace = numbodyspace.Value;
                GlobeVal.muserreport.mReportApp.mreportbody[listReport1.SelectedIndex].mspace = numbodyspace.Value;
            }
        }

        private void numbodymspace_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            if (listReport1.SelectedIndex >= 0)
            {

                mreportitem.vspace = numbodymspace.Value;
                GlobeVal.muserreport.mReportApp.mreportbody[listReport1.SelectedIndex].vspace = numbodymspace.Value;
            }
        }

        private void peditbodyfont_SourceValueChanged(object sender, EventArgs e)
        {
            if (listReport1.SelectedIndex >= 0)
            {

                mreportitem.font = peditbodyfont.Source.Value as Font;

                GlobeVal.muserreport.mReportApp.mreportbody[listReport1.SelectedIndex].font = peditbodyfont.Source.Value as Font;
            }
        }

        private void listReport3_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.listReport3.SelectedIndex >= 0)
            {
                mreportitem = this.listReport3.mlist[this.listReport3.SelectedIndex];
                numfooterspace.Value = this.listReport3.mlist[this.listReport3.SelectedIndex].mspace;
                chkfooter.Checked = this.listReport3.mlist[this.listReport3.SelectedIndex].showcaption;


                if (this.listReport3.mlist[this.listReport3.SelectedIndex].kind == 2)
                {
                    lblfooterfont.Visible = false;
                    peditfooterfont.Visible = false;
                    this.lblfootertext.Visible = false;
                    txtfooter.Visible = false;
                    lblfooterpicture.Visible = true;
                    tlpfooterpicture.Visible = true;
                    txtfooterpicture.Text = this.listReport3.mlist[this.listReport3.SelectedIndex].filename;

                }
                else
                {
                    if (this.listReport3.mlist[this.listReport3.SelectedIndex].kind == 0)
                    {
                        lblfootertext.Visible = false;
                        txtfooter.Visible = false;
                    }
                    else
                    {
                        lblfootertext.Visible = true;
                        txtfooter.Visible = true;

                    }
                    lblfooterpicture.Visible = false;
                    tlpfooterpicture.Visible = false;

                    lblfooterfont.Visible = true;
                    peditfooterfont.Visible = true;
                    this.peditfooterfont.Source = new NationalInstruments.UI.PropertyEditorSource(
                      this.listReport3.mlist[this.listReport3.SelectedIndex], "font");

                    txtfooter.Text = this.listReport3.mlist[this.listReport3.SelectedIndex].txtresult;
                }

            }
        }

        private void btnfooterpicture_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "(*.bmp" + ")|*.bmp";
            openFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\bmp\\";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == "")
            {

            }

            else
            {

                if (mreportitem == null)
                {
                }
                else
                {
                    txtfooterpicture.Text = System.IO.Path.GetFileName(openFileDialog1.FileName);

                }

            }
        }

        private void txtfooterpicture_TextChanged(object sender, EventArgs e)
        {
            if (listReport3.SelectedIndex >= 0)
            {

                mreportitem.filename = txtfooterpicture.Text;
                GlobeVal.muserreport.mReportApp.mreportfooter[listReport3.SelectedIndex].filename = txtfooterpicture.Text;
            }
        }

        private void peditfooterfont_SourceValueChanged(object sender, EventArgs e)
        {
            if (listReport3.SelectedIndex >= 0)
            {

                mreportitem.font = peditfooterfont.Source.Value as Font;

                GlobeVal.muserreport.mReportApp.mreportfooter[listReport3.SelectedIndex].font = peditfooterfont.Source.Value as Font;
            }
        }

        private void numfooterspace_AfterChangeValue(object sender, NationalInstruments.UI.AfterChangeNumericValueEventArgs e)
        {
            if (listReport3.SelectedIndex >= 0)
            {

                mreportitem.mspace = numfooterspace.Value;
                GlobeVal.muserreport.mReportApp.mreportfooter[listReport3.SelectedIndex].mspace = numfooterspace.Value;
            }
        }

        private void chkfooter_CheckedChanged(object sender, EventArgs e)
        {
            if (listReport3.SelectedIndex >= 0)
            {
                mreportitem.showcaption = chkfooter.Checked;
                GlobeVal.muserreport.mReportApp.mreportfooter[listReport3.SelectedIndex].showcaption = chkfooter.Checked;
            }
        }

        private void cbopostionfooter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GlobeVal.muserreport.mReportApp.footerposition  = cbopostionfooter.SelectedIndex;
        }

        private void txtfooter_TextChanged(object sender, EventArgs e)
        {
            if (mreportitem == null)
            {
            }
            else
            {
                if (listReport3.SelectedIndex >= 0)
                {
                    mreportitem.txtresult = txtfooter.Text;
                    GlobeVal.muserreport.mReportApp.mreportfooter[listReport3.SelectedIndex].txtresult = txtfooter.Text;

                }
            }
        }

        private void chkbody_CheckedChanged(object sender, EventArgs e)
        {
            if (listReport1.SelectedIndex >= 0)
            {
                mreportitem.showcaption = chkbody.Checked;
                GlobeVal.muserreport.mReportApp.mreportbody[listReport1.SelectedIndex].showcaption = chkbody.Checked;
            }
        }

        private void txtbodyvalue_TextChanged(object sender, EventArgs e)
        {
            if (mreportitem == null)
            {
            }
            else
            {
                if (listReport1.SelectedIndex >= 0)
                {
                    mreportitem.txtresult = txtbodyvalue.Text;
                    GlobeVal.muserreport.mReportApp.mreportbody[listReport1.SelectedIndex].txtresult = txtbodyvalue.Text;

                }
            }
        }

        private void btnbodypicture_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "(*.bmp" + ")|*.bmp";
            openFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\bmp\\";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == "")
            {

            }

            else
            {

                if (mreportitem == null)
                {
                }
                else
                {
                    txtbodypicture.Text = System.IO.Path.GetFileName(openFileDialog1.FileName);

                }

            }
        }

        private void txtbodypicture_TextChanged(object sender, EventArgs e)
        {
            if (listReport1.SelectedIndex >= 0)
            {

                mreportitem.filename = txtbodypicture.Text;
                GlobeVal.muserreport.mReportApp.mreportbody[listReport1.SelectedIndex].filename = txtbodypicture.Text;
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
