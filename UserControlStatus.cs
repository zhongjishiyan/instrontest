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
    public partial class UserControlStatus : UserControl
    {

        public void Init()
        {

            timer1.Enabled = true;

            if (CComLibrary.GlobeVal.filesave.Samplingmode == 0)
            {
                label8.Visible = false;
                label4.Visible = false;
                lblcurlargecount.Visible = false;
                lbllargecount.Visible = false;

            }
            else
            {
                label8.Visible = true;
                label4.Visible = true;
                lblcurlargecount.Visible = true;
                lbllargecount.Visible = true;

            }
                return;
        }
        public UserControlStatus()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (GlobeVal.myarm.getrunstate() == 1)
            {
                if (GlobeVal.mysys.language == 0)
                {
                    lblstate.Text = "运行";
                }
                else
                {
                    lblstate.Text = "Run";
                }
            }
            else
            {
                if (GlobeVal.mysys.language == 0)
                {
                    lblstate.Text = "停止";
                }
                else
                {
                    lblstate.Text = "Stop";
                }

                    
            }

            if (CComLibrary.GlobeVal.filesave != null)
            {


                if (CComLibrary.GlobeVal.filesave.mseglist.Count > 0)
                {
                    if (GlobeVal.myarm.mcurseg < CComLibrary.GlobeVal.filesave.mseglist.Count)
                    {
                        if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 1)
                        {
                            if (GlobeVal.mysys.language == 0)
                            {
                                lblstep.Text = "步骤" + (GlobeVal.myarm.mcurseg).ToString();
                            }
                            else
                            {
                                lblstep.Text = "Step " + (GlobeVal.myarm.mcurseg).ToString();
                            }
                        }
                        else if (CComLibrary.GlobeVal.filesave.mcontrolprocess == 3)
                        {
                          
                            lblstep.Text =CComLibrary.GlobeVal.filesave.mseglist[GlobeVal.myarm.mcurseg].mseq.stepname;

                            if ((CComLibrary.GlobeVal.filesave.mseglist[GlobeVal.myarm.mcurseg].mseq.wavekind ==2) ||(CComLibrary.GlobeVal.filesave.mseglist[GlobeVal.myarm.mcurseg].mseq.wavekind == 3))
                            {
                                label8.Visible = true;
                                label4.Visible = true;
                                lblcurlargecount.Visible = true;
                                lbllargecount.Visible = true;
                               
                                label7.Visible = true;

                                lblcurlargecount.Text = CComLibrary.GlobeVal.filesave.mseglist[GlobeVal.myarm.mcurseg].mseq.mcurrentcount.ToString();
                                lbllargecount.Text = CComLibrary.GlobeVal.filesave.mseglist[GlobeVal.myarm.mcurseg].mseq.mcount.ToString();
                             
                            }
                           
                            else
                            {
                                label8.Visible = false ;
                                label4.Visible = false ;
                                lblcurlargecount.Visible = false ;
                                lbllargecount.Visible = false ;
                             
                                label7.Visible = false;
                            
                            } 


                        }

                       
                    }


                }
            }
        }
    }
}
