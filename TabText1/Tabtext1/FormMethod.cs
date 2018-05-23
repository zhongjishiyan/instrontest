using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Data.OleDb;
using CComLibrary;
using ClsStaticStation;

namespace AppleLabApplication
{
    public partial class FormMethod : Form
    {
        private SampleProject.Extensions.GridBarChart gridBarChart1;
        private SampleProject.Extensions.GridBarChart gridBarChart2;
        private SampleProject.Extensions.GridBarChart gridBarChart3;
        private SampleProject.Extensions.GridBarChart gridBarChartText;
        private SampleProject.Extensions.GridBarChart gridBarChartCombo;
        public CComLibrary.FileStruct filesave;

       

        public int mrow=0;

        public string mmptpath;

        

        public FormMethod()
        {     
            InitializeComponent();
            filesave = CComLibrary.GlobeVal.filesave ;
          
        }

        public void loadfile(string filename)
        {
            
            string s;
            s = filename ;
            filesave = filesave.DeSerializeNow(s); 
          

        }

        private void wizardControl1_HelpButtonClick(object sender, EventArgs e)
        {
            
        }

        private void wizardControl1_FinishButtonClick(object sender, EventArgs e)
        {
            int i;


            filesave._flow测试前 = checklist.GetItemCheckState(0);

            filesave._flow测试结束=checklist.GetItemCheckState(1);

            filesave._flow数据采集=checklist.GetItemCheckState(2);

            filesave._flow应变= checklist.GetItemCheckState(3);


            filesave._flow试验选项= checklist.GetItemCheckState(4);



            filesave._flow测试= checklist.GetItemCheckState(5);


            filesave.fileextname = ".txt";

            string s;
            
            if (Directory.Exists(this.mmptpath +"\\"+ClsStaticStation.m_Global.mycls.TestkindList[filesave.methodkind])==true)
            {
            }
            else
            {
                Directory.CreateDirectory(this.mmptpath +"\\"+ClsStaticStation.m_Global.mycls.TestkindList[filesave.methodkind]);
            }

            s= this.mmptpath +"\\"+ClsStaticStation.m_Global.mycls.TestkindList[filesave.methodkind]+"\\"+filesave.methodname+@".dat";


            DialogResult a=  MessageBox.Show("是否重置试验方法？", "提示", MessageBoxButtons.YesNo);

            if (a == System.Windows.Forms.DialogResult.Yes)
            {
                filesave.checkchange();
            }

            

            filesave.SerializeNow(s);

            CComLibrary.GlobeVal.filesave = filesave;
            Close();

           
        }

        private void wizardControl1_CancelButtonClick(object sender, EventArgs e)
        {
            Close();
        }
        private void comboinit(DataGridViewComboBoxCell c)
        {
            c.Items.Clear();

            for (int i=0; i < ClsStaticStation.m_Global.mycls.SignalsNames.Length; i++)
            {
                c.Items.Add(ClsStaticStation.m_Global.mycls.SignalsNames[i]);  
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            int i;

         



            cbokind.Items.Clear();

            for (i = 0; i <ClsStaticStation.m_Global.mycls.TestkindList.Count; i++)
            {
                cbokind.Items.Add(ClsStaticStation.m_Global.mycls.TestkindList[i]);
            }

            cbokind.SelectedIndex = filesave.methodkind;

            if (listBox1.mlist ==null )
            {
                listBox1.mlist = new List<ClsStaticStation.shapeitem>();
            }
            listBox1.Items.Clear();
            listBox1.mlist.Clear();


            for (i = 0; i < ClsStaticStation.m_Global.mycls.shapelist.Count; i++)
            {
                bool b = false;

                for (int j = 0; j < filesave.mshapelist.Count; j++)
                {
                    if (filesave.mshapelist[j].shapename == ClsStaticStation.m_Global.mycls.shapelist[i].shapename)
                    {
                        b = true;
                       
                    }
                }

                if (b == false)
                {
                    listBox1.Items.Add(ClsStaticStation.m_Global.mycls.shapelist[i].shapename);
                    listBox1.mlist.Add(ClsStaticStation.m_Global.mycls.shapelist[i]);
                }

                 
            }

            if (listBox2.mlist ==null )
            {
                listBox2.mlist = new List<ClsStaticStation.shapeitem>();
            }
            listBox2.Items.Clear();
            listBox2.mlist.Clear(); 

            for (i = 0; i < filesave.mshapelist.Count; i++)
            {
                listBox2.Items.Add(filesave.mshapelist[i].shapename);
                listBox2.mlist.Add(filesave.mshapelist[i]);
            }
 
            txtName.Text = filesave.methodname;
            txtpath.Text = filesave.datapath;
            txtinterval.Text = filesave.minterval.ToString();
            txtauthor.Text = filesave.methodauthor;
            txtexplain.Text = filesave.methodmemo;

           
            if (filesave.lprocedurename == null)
            {
                filesave.lprocedurename = new List<string>();
            }
          
            cboitem.Items.Clear();
            for (i = 0; i < filesave.m_namelist.Count; i++)
            {
                cboitem.Items.Add(filesave.m_namelist[i]);
            }
            if (cboitem.Items.Count > 0)
            {
                cboitem.SelectedIndex = 0;
            }

            gridBarChart1 = new SampleProject.Extensions.GridBarChart();

            CComLibrary.inputitem aa = new CComLibrary.inputitem();


            
            for (i = 0; i < filesave.minput.Count; i++)
            {
               

                aa = filesave.minput[i];
                
                gridBarChart1.Bars.Add(new SampleProject.Extensions.ChartBar(aa.name, aa.value, aa.unit, aa.dimsel,Color.Red, Color.White));
                
            }

            
            
            listEditor1.List = new ArrayList(gridBarChart1.Bars);
            listEditor1.ItemType = typeof(SampleProject.Extensions.ChartBar);
            listEditor1.LoadList();



            gridBarChart2 = new SampleProject.Extensions.GridBarChart();

            CComLibrary.outputitem bb = new CComLibrary.outputitem();

            for (i = 0; i < filesave.moutput.Count; i++)
            {
                bb = filesave.moutput[i];

               
                if (bb == null)
                {

                    gridBarChart2.Bars.Add(new SampleProject.Extensions.ChartBarDefine(bb.formulaname, "无", bb.formulaunit, bb.check,bb.dimsel, bb.formulaexplain,bb.show ,   Color.Red, Color.White));
                }
                else
                {
                    gridBarChart2.Bars.Add(new SampleProject.Extensions.ChartBarDefine(bb.formulaname, "有", bb.formulaunit, bb.check, bb.dimsel, bb.formulaexplain,bb.show, Color.Red, Color.White));
                }

                

            }
            listEditor2.List = new ArrayList(gridBarChart2.Bars);
            listEditor2.ItemType = typeof(SampleProject.Extensions.ChartBarDefine);
            listEditor2.LoadList();
            listEditor2.Editors[1].EditableMode = SourceGrid2.EditableMode.None;



            for (i = 0; i < filesave.moutput.Count; i++)
            {

                (listEditor2.List[i] as SampleProject.Extensions.ChartBarDefine).value = filesave.moutput[i].formulavalue;
            }




            gridBarChartText = new SampleProject.Extensions.GridBarChart();

            CComLibrary.inputtextitem bb1 = new CComLibrary.inputtextitem();

            for (i = 0; i < filesave.minputtext.Count; i++)
            {
                bb1 = filesave.minputtext[i];
                if (bb1 == null)
                {

                    gridBarChartText.Bars.Add(new SampleProject.Extensions.ChartBarTextDefine("文档名称",""));
                }
                else
                {

                    gridBarChartText.Bars.Add(new SampleProject.Extensions.ChartBarTextDefine(bb1.name , bb1.value));
           
                }

                

            }
          

            listEditor4.List = new ArrayList(gridBarChartText.Bars);
            listEditor4.ItemType = typeof(SampleProject.Extensions.ChartBarTextDefine);
            listEditor4.LoadList();


            gridBarChartCombo = new SampleProject.Extensions.GridBarChart();

            CComLibrary.cboitem  bb2 = new CComLibrary.cboitem();

            for (i = 0; i < filesave.mcbo.Count; i++)
            {
                bb2 = filesave.mcbo[i];
                if (bb2 == null)
                {

                    gridBarChartCombo.Bars.Add(new SampleProject.Extensions.ChartBarComboDefine("名称", null ,0));
                }
                else
                {
                    string mcbo;
                    
                    mcbo ="";
                    for (int j = 0; j < bb2.mlist.Count-1; j++)
                    {
                        mcbo = mcbo + bb2.mlist[j]+",";
                    }
                    if (bb2.mlist.Count - 1 >= 0)
                    {
                        mcbo = mcbo + bb2.mlist[bb2.mlist.Count - 1];
                    }

                    gridBarChartCombo.Bars.Add(new SampleProject.Extensions.ChartBarComboDefine(bb2.Name, mcbo,bb2.value  ));

                }



            }


            listEditor5.List = new ArrayList(gridBarChartCombo.Bars);
            listEditor5.ItemType = typeof(SampleProject.Extensions.ChartBarComboDefine);
            listEditor5.LoadList();
           
            
           

           

            CComLibrary.userchannelitem cc = new CComLibrary.userchannelitem();
            for (i = 0; i < filesave.muserchannel.Count; i++)
            {
                cc = filesave.muserchannel[i];
                if (cc.channelvalue == null)
                {
                    DataGridViewRow b = new DataGridViewRow();
                    DataGridViewCell c = new DataGridViewTextBoxCell();
                    b.Cells.Add(c);
                    b.Cells[0].Value = cc.channelname;
                    c = new DataGridViewTextBoxCell();
                    b.Cells.Add(c);
                    b.Cells[1].Value = "无";
                    c = new DataGridViewTextBoxCell();
                    b.Cells.Add(c);
                    b.Cells[2].Value = cc.channelunit;
                    c = new DataGridViewComboBoxCell();
                    b.Cells.Add(c);
                    comboinit(c as DataGridViewComboBoxCell);
                    (b.Cells[3] as DataGridViewComboBoxCell).Value =(b.Cells[3] as DataGridViewComboBoxCell).Items[cc.channel_dimensionkind];
                    b.Tag = cc.channelvalue;
                    uListEditor1.dataGridView1.Rows.Add(b); 
                }
                else
                {
                    DataGridViewRow b = new DataGridViewRow();
                    DataGridViewCell c = new DataGridViewTextBoxCell();
                    b.Cells.Add(c);
                    b.Cells[0].Value = cc.channelname;
                    c = new DataGridViewTextBoxCell();
                    b.Cells.Add(c);
                    b.Cells[1].Value = "有";
                    c = new DataGridViewTextBoxCell();
                    b.Cells.Add(c);
                    b.Cells[2].Value = cc.channelunit;
                    c = new DataGridViewComboBoxCell();
                    b.Cells.Add(c);
                    comboinit(c as DataGridViewComboBoxCell);
                    (b.Cells[3] as DataGridViewComboBoxCell).Value = (c as DataGridViewComboBoxCell).Items[cc.channel_dimensionkind];
                    b.Tag = cc.channelvalue;
                    uListEditor1.dataGridView1.Rows.Add(b); 

                   
                }
            }
           

        }
        public DataSet ExcelToDS(string Path)
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string strExcel = "";
            OleDbDataAdapter myCommand = null;
            DataSet ds = null;


            DataTable schemaTable = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
            string tableName = schemaTable.Rows[0][2].ToString().Trim();


            strExcel = "select * from [" + tableName + "]";
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            ds = new DataSet();
            myCommand.Fill(ds, "table1");
            return ds;
        } 
        private void btnread_Click(object sender, EventArgs e)
        {
            

        }

        private void btnpath_Click(object sender, EventArgs e)
        {
            int i;

            folderBrowserDialog1.ShowDialog();
           txtpath.Text = folderBrowserDialog1.SelectedPath;



        }

        private void listEditor2_DoubleClick(object sender, EventArgs e)
        {
                
        }

        private void listEditor2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            int j;
            int k=0;

            

            CComLibrary.GlobeVal.formulakind = 1;

            filesave.moutput.Clear();

            for (i = 0; i < listEditor2.List.Count; i++)
            {
                CComLibrary.outputitem moutput = new CComLibrary.outputitem();
                moutput.formulaname = (listEditor2.List[i] as SampleProject.Extensions.ChartBarDefine).公式名称;
                moutput.formulavalue = (listEditor2.List[i] as SampleProject.Extensions.ChartBarDefine).value;
                moutput.formulaunit = (listEditor2.List[i] as SampleProject.Extensions.ChartBarDefine).公式单位;
                moutput.show = (listEditor2.List[i] as SampleProject.Extensions.ChartBarDefine).曲线显示;
                moutput.check = (listEditor2.List[i] as SampleProject.Extensions.ChartBarDefine).是否计算;
                moutput.formulaexplain = (listEditor2.List[i] as SampleProject.Extensions.ChartBarDefine).公式说明;



                for (j = 0; j < ClsStaticStation.m_Global.mycls.SignalsNames.Length; j++)
                {
                    if (ClsStaticStation.m_Global.mycls.SignalsNames[j] == listEditor2.grid[i + 1, listEditor2.grid.ColumnsCount - 1].Value.ToString())
                    // if (ClsStaticStation.m_Global.mycls.SignalsNames[j] == ClsStaticStation.m_Global.mycls.SignalsNames[(listEditor2.List[i] as SampleProject.Extensions.ChartBarDefine).量纲])
                    {
                        moutput.dimsel = j;

                        break;
                    }
                }


                if (moutput.myitemsignal == null)
                {

                    moutput.myitemsignal = ClsStaticStation.m_Global.mycls.signalskindlist[moutput.dimsel].Clone() as ItemSignal;
                    moutput.myitemsignal.cUnitsel = 0;

                }
                else if (moutput.myitemsignal.cName != ClsStaticStation.m_Global.mycls.signalskindlist[moutput.dimsel].cName)
                {
                    moutput.myitemsignal = ClsStaticStation.m_Global.mycls.signalskindlist[moutput.dimsel].Clone() as ItemSignal;
                    moutput.myitemsignal.cUnitsel = 0;

                }

                if (filesave.moutput.Count == 0)
                {
                    filesave.moutput.Add(moutput);

                }

                else
                {

                    Boolean mb = false;
                    for (j = 0; j < filesave.moutput.Count; j++)
                    {

                        if (moutput.formulaname == filesave.moutput[j].formulaname)
                        {
                            mb = true;

                        }

                    }

                    if (mb == false)
                    {
                        filesave.moutput.Add(moutput);

                    }
                    else
                    {
                        MessageBox.Show("自定义公式定义重复，请重新定义");
                      
                        return;
                    }
                }
            }

            /*
            filesave.moutput.Clear();

            for (i = 0; i < listEditor2.List.Count; i++)
            {
                CComLibrary.outputitem moutput = new CComLibrary.outputitem();
                moutput.formulaname = (listEditor2.List[i] as SampleProject.Extensions.ChartBarDefine).公式名称;
                moutput.formulavalue = (listEditor2.List[i] as SampleProject.Extensions.ChartBarDefine).value;
                moutput.formulaunit = (listEditor2.List[i] as SampleProject.Extensions.ChartBarDefine).公式单位;
                moutput.check = (listEditor2.List[i] as SampleProject.Extensions.ChartBarDefine).是否计算;
                

                if (filesave.moutput.Count == 0)
                {
                    filesave.moutput.Add(moutput);

                }

                else
                {

                    Boolean mb = false;
                    for (j = 0; j < filesave.moutput.Count ; j++)
                    {

                        if (moutput.formulaname== filesave.moutput[j].formulaname )
                        {
                            mb = true;

                        }

                    }

                    if (mb == false)
                    {
                        filesave.moutput.Add(moutput);

                    }
                    else
                    {
                        MessageBox.Show("自定义公式定义重复，请重新定义");

                        return;
                    }
                }

            }
            */
            k = listEditor2.row-1; 
             
              if (k >=0)
              {
              }
              else
              {
                  MessageBox.Show("请选择要编辑的公式");
                  return; 
              }


            double[,] t = new double[20,100];

            for (i = 0; i < 20; i++)
            {
                for (j = 0; j < 100; j++)
                {
                    t[i, j] = j+i;
                }
            }
            

            string s;
            s="";
            for (i=0;i<cboitem.Items.Count;i++)
            {
              s=s+cboitem.Items[i]+" ";

            }
            
            s=s.Trim();

            CComLibrary.GlobeVal.filesave = filesave;
 
            CComLibrary.GlobeVal.gcalc.Initialize();  

            CComLibrary.GlobeVal.gcalc.setarrayvalueold(t, 100,2);
            CComLibrary.GlobeVal.gcalc.initarray(s, 100);
            CComLibrary.GlobeVal.filesave = filesave;

                CComLibrary.GlobeVal._programname = (listEditor2.List[k] as SampleProject.Extensions.ChartBarDefine).公式名称;
                CComLibrary.GlobeVal._programstring = (listEditor2.List[k] as SampleProject.Extensions.ChartBarDefine).value;
                
            
            FormCalc f = new FormCalc();
            f.kind = 1;
            f.ShowDialog();

            if (CComLibrary.GlobeVal._programstring == null)
            {

                (listEditor2.List[k] as SampleProject.Extensions.ChartBarDefine).公式内容 = "无";
            }
            else
            {
                (listEditor2.List[k] as SampleProject.Extensions.ChartBarDefine).公式内容 ="有";
            }

            (listEditor2.List[k] as SampleProject.Extensions.ChartBarDefine).value = CComLibrary.GlobeVal._programstring;
            
           // listEditor2.LoadList(); 

                
        }

        private void listEditor2_Click(object sender, EventArgs e)
        {
          
        }

        private void listEditor2_Enter(object sender, EventArgs e)
        {
          
        }

        private void wizardControl1_Click(object sender, EventArgs e)
        {

        }

        private void listEditor3_Load(object sender, EventArgs e)
        {

        }

        private void wizardControl1_NextButtonClick(WizardBase.WizardControl sender, WizardBase.WizardNextButtonClickEventArgs args)
        {
            int i=0, j = 0;
            ColumnHeader c;
            ListViewItem b;

            if (wizardControl1.CurrentStepIndex == 1)
            {
                filesave.methodname = txtName.Text;
                filesave.datapath = txtpath.Text;
                filesave.lprocedurename.Clear();
                filesave.methodauthor = txtauthor.Text;
                filesave.methodmemo = txtexplain.Text;

                filesave.filekind = 0;
                filesave.m_namelist.Clear();
                filesave.minput.Clear();
                filesave.moutput.Clear();
                for (i = 0; i < cboitem.Items.Count; i++)
                {
                    filesave.m_namelist.Add(Convert.ToString(cboitem.Items[i]));
                   
                }

                filesave.mshapelist.Clear();
                for (i = 0; i < listBox2.Items.Count; i++)
                {
                    filesave.mshapelist.Add(listBox2.mlist[i]);

                }

                cboshape.Items.Clear();
                for (i = 0; i < filesave.mshapelist.Count; i++)
                {
                    cboshape.Items.Add(filesave.mshapelist[i].shapename);
                }
                if ((filesave.shapeselect>=0) &&(filesave.shapeselect<filesave.mshapelist.Count))
                {
                    cboshape.SelectedIndex = filesave.shapeselect;
                }
                else
                {
                    filesave.shapeselect = 0;
                    cboshape.SelectedIndex = filesave.shapeselect;
                }

                
                dataGridView1.Rows.Clear();

                for (i = 0; i < filesave.mshapelist[cboshape.SelectedIndex].sizeitem.Length; i++)
                {
                    if (filesave.mshapelist[cboshape.SelectedIndex].sizeitem[i].cName != "无")
                    {
                        DataGridViewRow dd = new DataGridViewRow();


                        DataGridViewCell mc = new DataGridViewTextBoxCell();
                        mc.Value = filesave.mshapelist[cboshape.SelectedIndex].sizeitem[i].cName;
                        dd.Cells.Add(mc);


                        mc = new DataGridViewTextBoxCell();
                        mc.Value = filesave.mshapelist[cboshape.SelectedIndex].sizeitem[i].cvalue;
                        dd.Cells.Add(mc);

                        mc = new DataGridViewComboBoxCell();
                        (mc as DataGridViewComboBoxCell).Items.Clear();

                        for ( j = 0; j < filesave.mshapelist[cboshape.SelectedIndex].sizeitem[i].cUnitCount; j++)
                        {
                            (mc as DataGridViewComboBoxCell).Items.Add(
                                filesave.mshapelist[cboshape.SelectedIndex].sizeitem[i].cUnits[j]
                                );
                        }

                        mc.Value = (mc as DataGridViewComboBoxCell).Items[filesave.mshapelist[cboshape.SelectedIndex].sizeitem[i].cUnitsel];
                        dd.Cells.Add(mc);

                        dataGridView1.Rows.Add(dd);
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Tag = filesave.mshapelist[cboshape.SelectedIndex].sizeitem[i];
                        

                    }
                }


            }

            if (wizardControl1.CurrentStepIndex == 2)
            {
                



              
                filesave.minput.Clear();
                for (i = 0; i < listEditor1.List.Count; i++)
                {
                    CComLibrary.inputitem minput1 = new CComLibrary.inputitem();

                    minput1.name = (listEditor1.List[i] as SampleProject.Extensions.ChartBar).名称;
                    minput1.value = (listEditor1.List[i] as SampleProject.Extensions.ChartBar).值;
                    minput1.unit = (listEditor1.List[i] as SampleProject.Extensions.ChartBar).单位;

                    for ( j = 0; j < ClsStaticStation.m_Global.mycls.SignalsNames.Length; j++)
                    {
                        if (ClsStaticStation.m_Global.mycls.SignalsNames[j] == listEditor1.grid[i+1,3].Value.ToString())
                        {
                            minput1.dimsel = j;
                            
                            break;
                        }
                    }

                    if (minput1.myitemsignal == null)
                    {

                        minput1.myitemsignal = ClsStaticStation.m_Global.mycls.signalskindlist[minput1.dimsel].Clone() as ItemSignal;
                        minput1.myitemsignal.cUnitsel = 0;
                    }
                    else if (minput1.myitemsignal.cName != ClsStaticStation.m_Global.mycls.signalskindlist[minput1.dimsel].cName)
                    {
                        minput1.myitemsignal = ClsStaticStation.m_Global.mycls.signalskindlist[minput1.dimsel].Clone() as ItemSignal;
                        minput1.myitemsignal.cUnitsel = 0;
                    }
                  
                    if (filesave.minput.Count ==0)
                    {
                        filesave.minput.Add(minput1);
                    }
                    else
                    {
                        Boolean mb = false;
                        for (j = 0; j < filesave.minput.Count; j++)
                        {

                            if (filesave.minput[j].name  == minput1.name )
                            {
                                mb = true;

                            }

                        }

                        if (mb == false)
                        {
                            filesave.minput.Add(minput1);
                        }
                        else
                        {
                            MessageBox.Show("自定义变量定义重复，请重新定义");
                            args.Cancel = true;
                            return;
                        }

                    }


                }

               int.TryParse(txtinterval.Text,out filesave.minterval);


               for (i = 0; i < dataGridView1.Rows.Count; i++)
               {
                   

                       (dataGridView1.Rows[i].Tag as ClsStaticStation.ItemSignal).cvalue =
                           Convert.ToDouble(
                       dataGridView1.Rows[i].Cells[1].Value);

                   
                          
               }
            }

            if (wizardControl1.CurrentStepIndex == 3)
            {

                filesave.minputtext.Clear();
                for (i = 0; i < listEditor4.List.Count; i++)
                {
                    CComLibrary.inputtextitem minput1 = new CComLibrary.inputtextitem();

                    minput1.name = (listEditor4.List[i] as SampleProject.Extensions.ChartBarTextDefine).文档名称;
                    minput1.value = (listEditor4.List[i] as SampleProject.Extensions.ChartBarTextDefine).文档内容 ;
                    filesave.minputtext.Add(minput1); 

                }
                filesave.mcbo.Clear();


                for (i = 0; i < listEditor5.List.Count; i++)
                {
                    CComLibrary.cboitem mcbo1 = new cboitem();
                    mcbo1.Name = (listEditor5.List[i] as SampleProject.Extensions.ChartBarComboDefine).组合框名称;
                    char[] sp=new char[2]; 
                    sp[0] = Convert.ToChar(",");
                    string[] s= (listEditor5.List[i] as SampleProject.Extensions.ChartBarComboDefine).组合框内容.Split(sp);
                    mcbo1.mlist.Clear(); 
                    for (int jj=0;jj<s.Length;jj++)
                    {
                        mcbo1.mlist.Add(s[jj]);
                    }
                    mcbo1.value =(listEditor5.List[i] as SampleProject.Extensions.ChartBarComboDefine).选择; 
                    filesave.mcbo.Add(mcbo1);
   
                }
                filesave.muserchannel.Clear();
                for (i = 0; i <this.uListEditor1.dataGridView1.Rows.Count; i++)
                {
                    
                    CComLibrary.userchannelitem muserchannelitem = new CComLibrary.userchannelitem();
                    muserchannelitem.channelname = uListEditor1.dataGridView1.Rows[i].Cells[0].Value.ToString();
                    muserchannelitem.channelvalue = uListEditor1.dataGridView1.Rows[i].Tag as string; 
                    muserchannelitem.channelunit = uListEditor1.dataGridView1.Rows[i].Cells[2].Value.ToString();

                    DataGridViewComboBoxCell dcc =
                            (DataGridViewComboBoxCell)uListEditor1.dataGridView1[3, i];

                    muserchannelitem.channel_dimensionkind = dcc.Items.IndexOf(dcc.Value);

                    if (muserchannelitem.myitemsignal == null)
                    {

                        muserchannelitem.myitemsignal = ClsStaticStation.m_Global.mycls.signalskindlist[muserchannelitem.channel_dimensionkind].Clone() as ItemSignal;
                        muserchannelitem.myitemsignal.cUnitsel = 0;
                    }
                    else if (muserchannelitem.myitemsignal.cName != ClsStaticStation.m_Global.mycls.signalskindlist[muserchannelitem.channel_dimensionkind].cName)
                    {
                        muserchannelitem.myitemsignal = ClsStaticStation.m_Global.mycls.signalskindlist[muserchannelitem.channel_dimensionkind].Clone() as ItemSignal;
                        muserchannelitem.myitemsignal.cUnitsel = 0;
                    }
                  
                  
                    if (filesave.muserchannel.Count == 0)
                    {
                        filesave.muserchannel.Add(muserchannelitem);

                    }

                    else
                    {

                       Boolean   mb = false;
                        for (j = 0; j < filesave.muserchannel.Count; j++)
                        {

                            if (muserchannelitem.channelname == filesave.muserchannel[j].channelname)
                            {
                                mb = true;
                                
                            }
                           
                        }

                        if (mb == false)
                        {
                            filesave.muserchannel.Add(muserchannelitem);
                        }
                        else
                        {
                            MessageBox.Show("自定义通道定义重复，请重新定义");
                            args.Cancel = true;
                            return;
                        }
                    }
                    

                }

              
            }
            if (wizardControl1.CurrentStepIndex == 4)
            {
                filesave.moutput.Clear();

                for (i = 0; i < listEditor2.List.Count; i++)
                {
                    CComLibrary.outputitem moutput = new CComLibrary.outputitem();
                    moutput.formulaname = (listEditor2.List[i] as SampleProject.Extensions.ChartBarDefine).公式名称;
                    moutput.formulavalue = (listEditor2.List[i] as SampleProject.Extensions.ChartBarDefine).value;
                    moutput.formulaunit = (listEditor2.List[i] as SampleProject.Extensions.ChartBarDefine).公式单位;
                    moutput.show = (listEditor2.List[i] as SampleProject.Extensions.ChartBarDefine).曲线显示;
                    moutput.check = (listEditor2.List[i] as SampleProject.Extensions.ChartBarDefine).是否计算;
                    moutput.formulaexplain = (listEditor2.List[i] as SampleProject.Extensions.ChartBarDefine).公式说明;

                    
                    
                    for (j = 0; j < ClsStaticStation.m_Global.mycls.SignalsNames.Length; j++)
                    {
                        if (ClsStaticStation.m_Global.mycls.SignalsNames[j] == listEditor2.grid[i + 1, listEditor2.grid.ColumnsCount-1].Value.ToString())
                       // if (ClsStaticStation.m_Global.mycls.SignalsNames[j] == ClsStaticStation.m_Global.mycls.SignalsNames[(listEditor2.List[i] as SampleProject.Extensions.ChartBarDefine).量纲])
                        {
                            moutput.dimsel = j;

                            break;
                        }
                    }


                    if (moutput.myitemsignal == null)
                    {

                        moutput.myitemsignal = ClsStaticStation.m_Global.mycls.signalskindlist[moutput.dimsel].Clone() as ItemSignal;
                        moutput.myitemsignal.cUnitsel = 0;
                        
                    }
                    else if (moutput.myitemsignal.cName != ClsStaticStation.m_Global.mycls.signalskindlist[moutput.dimsel].cName)
                    {
                        moutput.myitemsignal = ClsStaticStation.m_Global.mycls.signalskindlist[moutput.dimsel].Clone() as ItemSignal;
                        moutput.myitemsignal.cUnitsel = 0;
                        
                    }

                    if (filesave.moutput.Count == 0)
                    {
                        filesave.moutput.Add(moutput);

                    }

                    else
                    {

                        Boolean mb = false;
                        for (j = 0; j < filesave.moutput.Count; j++)
                        {

                            if (moutput.formulaname == filesave.moutput[j].formulaname)
                            {
                                mb = true;

                            }

                        }

                        if (mb == false)
                        {
                            filesave.moutput.Add(moutput);

                        }
                        else
                        {
                            MessageBox.Show("自定义公式定义重复，请重新定义");
                            args.Cancel = true;
                            return;
                        }
                    }
                }

                listEditor3.listViewEx1.Clear();

                for (i = 0; i < filesave.mcalcpanel.colcount; i++)
                {
                    c = new ColumnHeader();
                    c.Text = "";
                    c.Width = 120;
                    c.TextAlign = HorizontalAlignment.Center;
                    listEditor3.listViewEx1.Columns.Add(c);
                }


                for (i = 0; i < filesave.mcalcpanel.rowcount; i++)
                {
                    b = new ListViewItem();

                    b.Text = "";

                    b.BackColor = Color.White;

                    for (j = 0; j < filesave.mcalcpanel.colcount; j++)
                    {
                        b.SubItems.Add("");
                    }
                    
                    for (j = 0; j < filesave.mcalcpanel.colcount; j++)
                    {
                        b.SubItems[j].Text  = filesave.mcalcpanel.textgrid[i][j]; 
                    }
                    listEditor3.listViewEx1.Items.Add(b); 
                }


                listEditor3.cboitem.Items.Clear();

                for (i = 0; i < filesave.moutput.Count; i++)
                {
                    
                    listEditor3.cboitem.Items.Add("["+filesave.moutput[i].formulaname+"]");
                    listEditor3.cboitem.Items.Add("{" + filesave.moutput[i].formulaname + "结果}");
                }

                if (listEditor3.cboitem.Items.Count > 0)
                {
                    listEditor3.cboitem.SelectedIndex = 0;
                }
            }
          
            if (wizardControl1.CurrentStepIndex == 5)
            {

                

                filesave.mcalcpanel.colcount = listEditor3.listViewEx1.Columns.Count;
                filesave.mcalcpanel.rowcount = listEditor3.listViewEx1.Items.Count;

                filesave.mcalcpanel.init_textgrid(); 

                for (i = 0; i < filesave.mcalcpanel.colcount; i++)
                {
                    for (j = 0; j < filesave.mcalcpanel.rowcount; j++)
                    {
                        
                        
                      filesave.mcalcpanel.textgrid[j][i] = listEditor3.listViewEx1.Items[j].SubItems[i].Text ; 
                        
                    }
                }

               
                checklist.SetItemCheckState(0, filesave._flow测试前);

                checklist.SetItemCheckState(1, filesave._flow测试结束);

                checklist.SetItemCheckState(2, filesave._flow数据采集);

                checklist.SetItemCheckState(3, filesave._flow应变);
               
               
                checklist.SetItemCheckState(4, filesave._flow试验选项);



                checklist.SetItemCheckState(5, filesave._flow测试);
               

            }

           
          }



        private void button2_Click(object sender, EventArgs e)
        {
            int i;
            int j;
            int k = 0;

            filesave.muserchannel.Clear();
            for (i = 0; i < this.uListEditor1.dataGridView1.Rows.Count; i++)
            {
                CComLibrary.userchannelitem muserchannelitem = new CComLibrary.userchannelitem();
                muserchannelitem.channelname = uListEditor1.dataGridView1.Rows[i].Cells[0].Value.ToString() ;
                muserchannelitem.channelvalue = uListEditor1.dataGridView1.Rows[i].Tag as string; 
                muserchannelitem.channelunit = uListEditor1.dataGridView1.Rows[i].Cells[2].Value.ToString();

                DataGridViewComboBoxCell dcc =
                        (DataGridViewComboBoxCell)uListEditor1.dataGridView1[3, i];

                muserchannelitem.channel_dimensionkind = dcc.Items.IndexOf(dcc.Value);  



                if (filesave.muserchannel.Count == 0)
                {
                    filesave.muserchannel.Add(muserchannelitem);

                }

                else
                {

                    Boolean mb = false;
                    for (j = 0; j < filesave.muserchannel.Count; j++)
                    {

                        if (muserchannelitem.channelname == filesave.muserchannel[j].channelname)
                        {
                            mb = true;

                        }

                    }

                    if (mb == false)
                    {
                        filesave.muserchannel.Add(muserchannelitem);
                    }
                    else
                    {
                        MessageBox.Show("自定义通道定义重复，请重新定义");
                        
                        return;
                    }
                }
                    

            }

            CComLibrary.GlobeVal.formulakind = 0;

            k = this.uListEditor1.dataGridView1.SelectedCells[0].RowIndex; 

            
            if (k >= 0)
            {
            }
            else
            {
                MessageBox.Show("请选择要编辑的公式");
                return;
            }


            double[,] t = new double[20, 100];

            for (i = 0; i < 20; i++)
            {
                for (j = 0; j < 100; j++)
                {
                    t[i, j] = j + i;
                }
            }


            string s;
            s = "";
            for (i = 0; i < cboitem.Items.Count; i++)
            {
                s = s + cboitem.Items[i] + " ";

            }

            s = s.Trim();

            CComLibrary.GlobeVal.filesave = filesave;

            CComLibrary.GlobeVal.gcalc.Initialize();

            CComLibrary.GlobeVal.gcalc.setarrayvalueold(t, 100,2);
            CComLibrary.GlobeVal.gcalc.initarray(s, 100);
            CComLibrary.GlobeVal.filesave = filesave;

            CComLibrary.GlobeVal._programname = this.uListEditor1.dataGridView1.Rows[k].Cells[0].Value.ToString();
            CComLibrary.GlobeVal._programstring = filesave.muserchannel[k].channelvalue ;


            FormCalc f = new FormCalc();
            f.kind = 0;
            f.num = k;
            f.ShowDialog();

            uListEditor1.dataGridView1.Rows[k].Tag = CComLibrary.GlobeVal._programstring;
            

           

        }

        private void button3_Click(object sender, EventArgs e)
        {  
           

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void cboshape_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int i;
            dataGridView1.Rows.Clear();
            filesave.shapeselect = cboshape.SelectedIndex;

            for (i = 0; i < filesave.mshapelist[cboshape.SelectedIndex].sizeitem.Length; i++)
            {
                if (filesave.mshapelist[cboshape.SelectedIndex].sizeitem[i].cName != "无")
                {
                    DataGridViewRow dd = new DataGridViewRow();


                    DataGridViewCell mc = new DataGridViewTextBoxCell();
                    mc.Value = filesave.mshapelist[cboshape.SelectedIndex].sizeitem[i].cName;
                    dd.Cells.Add(mc);


                    mc = new DataGridViewTextBoxCell();
                    mc.Value = filesave.mshapelist[cboshape.SelectedIndex].sizeitem[i].cvalue;
                    dd.Cells.Add(mc);

                    mc = new DataGridViewComboBoxCell();
                    (mc as DataGridViewComboBoxCell).Items.Clear();

                    for (int j = 0; j < filesave.mshapelist[cboshape.SelectedIndex].sizeitem[i].cUnitCount; j++)
                    {
                        (mc as DataGridViewComboBoxCell).Items.Add(
                            filesave.mshapelist[cboshape.SelectedIndex].sizeitem[i].cUnits[j]
                            );
                    }

                    mc.Value = (mc as DataGridViewComboBoxCell).Items[filesave.mshapelist[cboshape.SelectedIndex].sizeitem[i].cUnitsel];
                    dd.Cells.Add(mc);

                    dataGridView1.Rows.Add(dd);
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Tag = filesave.mshapelist[cboshape.SelectedIndex].sizeitem[i];
                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void intermediateStep2_Click(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                listBox2.Items.Add(listBox1.Items[listBox1.SelectedIndex]  );

                listBox2.mlist.Add(listBox1.mlist[listBox1.SelectedIndex]);
                listBox1.mlist.RemoveAt(listBox1.SelectedIndex);  
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                
            }

        }

        private void btndel_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                listBox1.Items.Add(listBox2.Items[listBox2.SelectedIndex]);

                listBox1.mlist.Add(listBox2.mlist[listBox2.SelectedIndex]);
                listBox2.mlist.RemoveAt(listBox2.SelectedIndex);    
                listBox2.Items.RemoveAt(listBox2.SelectedIndex );
                
            }
        }

        private void uListEditor1_addevent(object sender, int index)
        {
            DataGridViewRow b = new DataGridViewRow();
            DataGridViewCell c = new DataGridViewTextBoxCell();
            b.Cells.Add(c);
            b.Cells[0].Value = "";
            c = new DataGridViewTextBoxCell();
            b.Cells.Add(c);
            b.Cells[1].Value = "无";
            c = new DataGridViewTextBoxCell();
            b.Cells.Add(c);
            b.Cells[2].Value = "";
            c = new DataGridViewComboBoxCell();
            b.Cells.Add(c);
            comboinit(c as DataGridViewComboBoxCell);
            (b.Cells[3] as DataGridViewComboBoxCell).Value = (b.Cells[3] as DataGridViewComboBoxCell).Items[0];
            b.Tag = "";
            uListEditor1.dataGridView1.Rows.Add(b);

            CComLibrary.userchannelitem muserchannelitem = new CComLibrary.userchannelitem();
            muserchannelitem.channelname = b.Cells[0].Value.ToString();
            muserchannelitem.channelvalue = b.Tag as string;
            muserchannelitem.channelunit = b.Cells[2].Value.ToString();

            filesave.muserchannel.Add(muserchannelitem);

        }

        private void uListEditor1_removeevent(object sender, int index)
        {
            filesave.muserchannel.RemoveAt(uListEditor1.dataGridView1.SelectedCells[0].RowIndex);    
        
            uListEditor1.dataGridView1.Rows.RemoveAt(uListEditor1.dataGridView1.SelectedCells[0].RowIndex);
            
        }

        private void uListEditor1_cboevent(object sender, int index)
        {
            if (uListEditor1.dataGridView1.SelectedCells[0].RowIndex>=0)
            {
                filesave.muserchannel[uListEditor1.dataGridView1.SelectedCells[0].RowIndex].channel_dimensionkind = index;
                uListEditor1.dataGridView1.Rows[uListEditor1.dataGridView1.SelectedCells[0].RowIndex].Cells[2].Value = ClsStaticStation.m_Global.mycls.signalskindlist[index].cUnits[0];
                
                
            }
        }

        private void listEditor1_ListChanged(object sender, SourceGrid2.PositionEventArgs e)
        {
            if (e == null)
            {
            }
            else
            {
                if (e.Position.Column == 3)
                {

                    for (int i = 0; i < ClsStaticStation.m_Global.mycls.SignalsNames.Length; i++)
                    {
                        if (ClsStaticStation.m_Global.mycls.SignalsNames[i] == listEditor1.grid[e.Position.Row, e.Position.Column].Value.ToString())
                        {

                            listEditor1.grid[e.Position.Row, 2].Value = ClsStaticStation.m_Global.mycls.signalskindlist[i].cUnits[0];
                            break;
                        }
                    }
                }
            }
        }

        private void listEditor2_ListChanged(object sender, SourceGrid2.PositionEventArgs e)
        {

            if (e == null)
            {
            }
            else
            {
                if (e.Position.Column == listEditor2.grid.ColumnsCount - 1)
                {

                    for (int i = 0; i < ClsStaticStation.m_Global.mycls.SignalsNames.Length; i++)
                    {
                        if (ClsStaticStation.m_Global.mycls.SignalsNames[i] == listEditor2.grid[e.Position.Row, e.Position.Column].Value.ToString())
                        {

                            listEditor2.grid[e.Position.Row, 2].Value = ClsStaticStation.m_Global.mycls.signalskindlist[i].cUnits[0];

                            
                            break;
                        }
                    }
                }
            }
        }

        private void cbokind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            filesave.methodkind = cbokind.SelectedIndex;
        }

        private void checklist_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void checklist_ItemCheck(object sender, ItemCheckEventArgs e)
        {
                 if(e.Index==0)
            {
                filesave._flow测试前 = e.NewValue;
            }

                 if (e.Index ==1)
            {
                filesave._flow测试结束 = e.NewValue;
            }
                 if (e.Index ==2)
            {
                filesave._flow数据采集 = e.NewValue;
            }
                 if (e.Index ==3)
            {
                filesave._flow应变 = e.NewValue;
            }
                 if(e.Index ==4)
            {
                filesave._flow试验选项 = e.NewValue;
               
            }
                 if (e.Index ==5)
            {
                filesave._flow测试 = e.NewValue;
            }
                 
        }
    }
}
