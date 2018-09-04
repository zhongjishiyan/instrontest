using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppleLabApplication
{
    public partial class FormCalc : FormBase
    {
        public int num;

        public int kind;// 自定义通道还是自定义公式

        SheetView _SheetView1;
        RichTextBox outputwindow2;

   
       
        public void Init_Rule()
        {
            CComLibrary.GlobeVal.mrule.Clear();

            CComLibrary.Rule a = new CComLibrary.Rule();
            a.OperaWordsName = "=";
            a.replaceName = "=";
            a.count = 0;
            a.explain = "等于";
            a.LExplain[0] = "等于";
            a.LExplain[1] = "Be equal to";

            a.paraname[0] = "";
            a.parakind[0] = "";
            CComLibrary.GlobeVal.mrule.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "+";
            a.replaceName = "+";
            a.count = 0;
            a.explain = "加号";
            a.LExplain[0] = "加号";
            a.LExplain[1] = "Plus";

            a.paraname[0] = "";
            a.parakind[0] = "";
            CComLibrary.GlobeVal.mrule.Add(a);


            a = new CComLibrary.Rule();
            a.OperaWordsName = "-";
            a.replaceName = "-";
            a.count = 0;
            a.explain = "减号";
            a.LExplain[0] = "减号";
            a.LExplain[1] = "Minus sign";


            a.paraname[0] = "";
            a.parakind[0] = "";
            CComLibrary.GlobeVal.mrule.Add(a);


            a = new CComLibrary.Rule();
            a.OperaWordsName = "*";
            a.replaceName = "*";
            a.count = 0;
            a.explain = "乘号";
            a.LExplain[0] = "乘号";
            a.LExplain[1] = "Multiplication sign";

            a.paraname[0] = "";
            a.parakind[0] = "";
            CComLibrary.GlobeVal.mrule.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "/";
            a.replaceName = "/";
            a.count = 0;
            a.explain = "除号";
            a.LExplain[0] = "除号";
            a.LExplain[1] = "Sign of division";


            a.paraname[0] = "";
            a.parakind[0] = "";
            CComLibrary.GlobeVal.mrule.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "[";
            a.replaceName = "[";
            a.count = 0;
            a.explain = "数组左括号";
            a.LExplain[0] = "数组左括号";
            a.LExplain[1] = "Array left parenthesis";

            a.paraname[0] = "";
            a.parakind[0] = "";
            CComLibrary.GlobeVal.mrule.Add(a);


            a = new CComLibrary.Rule();
            a.OperaWordsName = "]";
            a.replaceName = "]";
            a.count = 0;
            a.explain = "数组右括号";
            a.LExplain[0] = "数组右括号";
            a.LExplain[1] = "Array right bracket";

            a.paraname[0] = "";
            a.parakind[0] = "";
            CComLibrary.GlobeVal.mrule.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "(";
            a.replaceName = "(";
            a.count = 0;
            a.explain = "计算左括号";
            a.LExplain[0] = "计算左括号";
            a.LExplain[1] = "Left parenthesis";

            a.paraname[0] = "";
            a.parakind[0] = "";
            CComLibrary.GlobeVal.mrule.Add(a);


            a = new CComLibrary.Rule();
            a.OperaWordsName = ")";
            a.replaceName = ")";
            a.count = 0;
            a.explain = "计算右括号";
            a.LExplain[0] = "计算右括号";
            a.LExplain[1] = "Right parenthesis";


            a.paraname[0] = "";
            a.parakind[0] = "";
            CComLibrary.GlobeVal.mrule.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "abs";
            a.replaceName = "Math.Abs";
            a.count = 1;
            a.explain = "求绝对值";
            a.LExplain[0] = "求绝对值";
            a.LExplain[1] = "Calculate absolute value";

            a.paraname[0] = "value";
            a.parakind[0] = "double";
            CComLibrary.GlobeVal.mrule.Add(a);
            a = new  CComLibrary.Rule();
            a.OperaWordsName = "sin";
            a.replaceName = "Math.Sin";
            a.count = 1;
            a.explain = "求正弦";
            a.LExplain[0] = "求正弦";
            a.LExplain[1] = "Calculate sine value";

            a.paraname[0] = "value";
            a.parakind[0] = "double";
            CComLibrary.GlobeVal.mrule.Add(a);
            a = new  CComLibrary.Rule();
            a.OperaWordsName = "cos";
            a.replaceName = "Math.Cos";
            a.count = 1;
            a.explain = "求余弦";
            a.LExplain[0] = "求余弦";
            a.LExplain[1] = "Cosine";

            a.paraname[0] = "value";
            a.parakind[0] = "double";
            CComLibrary.GlobeVal.mrule.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "ceiling";
            a.replaceName = "Math.Ceiling";
            a.count = 1;
            a.explain = "求大于或等于该指定双精度数最小整数";
            a.LExplain[0] = "求大于或等于该指定双精度数最小整数";
            a.LExplain[1] = "Obtain the smallest integer that is greater than or equal to the specified double precision number.";


            a.paraname[0] = "value";
            a.parakind[0] = "double";
            CComLibrary.GlobeVal.mrule.Add(a);


            a = new CComLibrary.Rule();
            a.OperaWordsName = "power";
            a.replaceName = "Math.Pow";
            a.count = 2;
            a.explain = "返回指定数字的指定次幂,x:要乘幂的浮点数,y:指定幂的浮点数";
            a.LExplain[0] = "返回指定数字的指定次幂,x:要乘幂的浮点数,y:指定幂的浮点数";
            a.LExplain[1] = "Returns the specified power of the specified number. The floating-point number of x: must be power, and y: specifies the floating point number of the power.";

            a.paraname[0] = "X";
            a.parakind[0] = "double";
            a.paraname[1] = "Y";
            a.parakind[1] = "double";
            CComLibrary.GlobeVal.mrule.Add(a);


            a = new  CComLibrary.Rule();
            a.OperaWordsName = "sqrt";
            a.replaceName = "Math.Sqrt";
            a.count = 1;
            a.explain = "返回指定数的平方根";
            a.LExplain[0] = "返回指定数的平方根";
            a.LExplain[1] = "Returns the square root of a specified number.";


            a.paraname[0] = "value";
            a.parakind[0] = "double";
            CComLibrary.GlobeVal.mrule.Add(a);


            a = new CComLibrary.Rule();
            a.OperaWordsName = "round"; 
            a.replaceName = "Convert.ToInt32";
            a.count = 1;
            a.explain = "把浮点数转换为整数";
            a.LExplain[0] = "把浮点数转换为整数";
            a.LExplain[1] = "Converting floating-point numbers into integers";

            a.paraname[0] = "float";
            a.parakind[0] = "double";
            CComLibrary.GlobeVal.mrule.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "revision";
            a.replaceName = "revision";
            a.count = 2;
            a.explain = "修约,保留有效位数";
            a.LExplain[0] = "修约,保留有效位数";
            a.LExplain[1] = "To fix a contract and keep the valid digit";

            a.paraname[0] = "float";
            a.parakind[0] = "double";
            a.paraname[1] = "valid ";
            a.paraname[1] = "integer";
            CComLibrary.GlobeVal.mrule.Add(a);

            for (int i=0;i<CComLibrary.GlobeVal.mrule.Count;i++)
            {
                if (CComLibrary.GlobeVal.languageselect ==0)
                {
                    CComLibrary.GlobeVal.mrule[i].explain = CComLibrary.GlobeVal.mrule[i].LExplain[0];
                }
                else
                {
                    CComLibrary.GlobeVal.mrule[i].explain = CComLibrary.GlobeVal.mrule[i].LExplain[1];

                }
            }

        }
        public void Init_SystemPara()
        {

            CComLibrary.SystemPara b;
            string s;
            int i;
            int j;
            CComLibrary.GlobeVal.msyspara.Clear();

            s = "";


            for (j = 0; j < CComLibrary.GlobeVal.filesave.m_namelist.Count; j++)
            {
                b = new CComLibrary.SystemPara();
                string r = CComLibrary.GlobeVal.filesave.m_namelist[j];

                r = r.Replace(" ", "_");
                if (CComLibrary.GlobeVal.languageselect == 0)
                {
                    b.Name = r + "通道";
                }
                else
                {
                    b.Name = r + "_Channel";
                }
                b.replaceName = b.Name;
                s = s + "public double " + b.replaceName + "=0;" + "\r\n";
                CComLibrary.GlobeVal.msyspara.Add(b);

            }

            

            for (j = 0; j < CComLibrary.GlobeVal.filesave.muserchannel.Count; j++)
            {
                b = new CComLibrary.SystemPara();
                if (CComLibrary.GlobeVal.languageselect == 0)
                {
                    b.Name = CComLibrary.GlobeVal.filesave.muserchannel[j].channelname + "通道";
                }
                else
                {
                    b.Name = CComLibrary.GlobeVal.filesave.muserchannel[j].channelname + "_Channel";
                }

                b.replaceName = b.Name;
                s = s + "public double " + b.replaceName + "=0;" + "\r\n";
                CComLibrary.GlobeVal.msyspara.Add(b);
            }
            

            for (j = 0; j < CComLibrary.GlobeVal.filesave.mshapelist.Count; j++)
            {
                for (i = 0; i < CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem.Length; i++)
                {

                    
                        if ((CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem[i].cName != "None") )
                        {
                            b = new CComLibrary.SystemPara();

                            
                            string r = CComLibrary.GlobeVal.filesave.mshapelist[j].shapename + "_" +
                                CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem[i].cName;
                            r = r.Replace(" ", "_");

                            b.Name = r;
                            b.replaceName = b.Name;
                            s = s + "public double " + b.replaceName + "=0;" + "\r\n";
                            CComLibrary.GlobeVal.msyspara.Add(b);
                        }
                    
                  

                }
            }

            

            for (i = 0; i < CComLibrary.GlobeVal.filesave.mcbo.Count; i++)
            {
                b = new CComLibrary.SystemPara();
                b.Name = CComLibrary.GlobeVal.filesave.mcbo[i].Name;
                b.replaceName = b.Name;
                s = s + "public int " + b.replaceName + "=0;" + "\r\n";
                CComLibrary.GlobeVal.msyspara.Add(b);
                 
            }

            for (i = 0; i < CComLibrary.GlobeVal.filesave.minput.Count; i++)
            {
                    b = new CComLibrary.SystemPara();
                    b.Name = CComLibrary.GlobeVal.filesave.minput[i].name;
                    b.replaceName = b.Name;
                    s = s + "public double " + b.replaceName + "=0;" + "\r\n";
                    CComLibrary.GlobeVal.msyspara.Add(b);
                
               

            }
            CComLibrary.GlobeVal.gcalc.refreshglobe(s);

            s = "";
            for (i = 0; i < CComLibrary.GlobeVal.filesave.moutput.Count; i++)
            {
                b = new CComLibrary.SystemPara();

                string r = CComLibrary.GlobeVal.filesave.moutput[i].formulaname;
                r = r.Replace(" ", "_");
                b.Name = r;
                b.replaceName = "@result" + (i + 1).ToString().Trim(); ;
                s = s+"double " + b.replaceName + "="+"m_Global.mresult[" + (i + 1).ToString().Trim()+"];" + "\r\n";
                CComLibrary.GlobeVal.msyspara.Add(b);



            }

            CComLibrary.GlobeVal.gcalc.refreshresult(s);


        }

        public void InitListViewChannel()
        {
            int i;
            int j;


            lvTips.View = View.SmallIcon;


            ImageList iList = new ImageList();
            iList.ImageSize = new Size(25, 25);//宽度和高度值必须大于等于1且不超过256
            lvTips.SmallImageList= iList;





            ListViewItem _lvi = new ListViewItem();


            if (CComLibrary.GlobeVal.languageselect == 0)
            {

                _lvi.Text = "_结果";
                _lvi.Tag = "_结果";
            }
            else
            {
                _lvi.Text = "_Result";
                _lvi.Tag = "_Result";
            }

            _lvi.Group = lvTips.Groups[0];



            lvTips.Items.Add(_lvi);


            _lvi = new ListViewItem();

            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                _lvi.Text = "_数组长度";
                _lvi.Tag = "_数组长度";
            }
            else
            {
                _lvi.Text = "_Length_of_array";
                _lvi.Tag = "_Length_of_array";
            }

            _lvi.Group = lvTips.Groups[0];


            lvTips.Items.Add(_lvi);


            _lvi = new ListViewItem();

            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                _lvi.Text = "_索引";
                _lvi.Tag = "_索引";
            }
            else
            {
                _lvi.Text = "_Index";
                _lvi.Tag = "_Index";
            }
            _lvi.Group = lvTips.Groups[0];
            lvTips.Items.Add(_lvi);

           

           
                for (i = 0; i < CComLibrary.GlobeVal.filesave.m_namelist.Count; i++)
                {
                    _lvi = new ListViewItem();

                string r = CComLibrary.GlobeVal.filesave.m_namelist[i];
                r = r.Replace(" ", "_");

                if (CComLibrary.GlobeVal.languageselect == 0)
                {
                    _lvi.Text = r + "通道";

                    _lvi.Tag = r + "通道";
                }
                else
                {
                    _lvi.Text = r + "_Channe";

                    _lvi.Tag = r + "_Channel";
                }
                    _lvi.Group = lvTips.Groups[0];
                    lvTips.Items.Add(_lvi);

                }

           

            
            
                for (i = 0; i < CComLibrary.GlobeVal.filesave.muserchannel.Count; i++)
                {
                    _lvi = new ListViewItem();
                if (CComLibrary.GlobeVal.languageselect == 0)
                {
                    _lvi.Text = CComLibrary.GlobeVal.filesave.muserchannel[i].channelname + "通道";
                    _lvi.Tag = CComLibrary.GlobeVal.filesave.muserchannel[i] + "通道";
                }
                else
                {
                    _lvi.Text = CComLibrary.GlobeVal.filesave.muserchannel[i].channelname + "_Channel";
                    _lvi.Tag = CComLibrary.GlobeVal.filesave.muserchannel[i] + "_Channel";
                }
                    _lvi.Group = lvTips.Groups[0];
                    lvTips.Items.Add(_lvi);
                }
           





            for (i = 0; i < CComLibrary.GlobeVal.mrule.Count; i++)
            {
                _lvi = new ListViewItem();
                _lvi.Text = CComLibrary.GlobeVal.mrule[i].OperaWordsName;
                _lvi.Tag = CComLibrary.GlobeVal.mrule[i];

                _lvi.Group = lvTips.Groups[1];
                lvTips.Items.Add(_lvi);

            }

            for (j = 0; j < CComLibrary.GlobeVal.filesave.mshapelist.Count; j++)
            {
                for (i = 0; i < CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem.Length; i++)
                {
                    if (CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem[i].cName != "None")
                    {
                        _lvi = new ListViewItem();

                        string r = CComLibrary.GlobeVal.filesave.mshapelist[j].shapename + "_" +
                            CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem[i].cName;
                        r = r.Replace(" ", "_");


                        _lvi.Text = r;

                        _lvi.Tag = CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem[i];

                        _lvi.Group = lvTips.Groups[2];
                        lvTips.Items.Add(_lvi);
                    }

                }
            }

        
            

            for (i = 0; i < CComLibrary.GlobeVal.filesave.minput.Count; i++)
            {
                _lvi = new ListViewItem();
                _lvi.Text = CComLibrary.GlobeVal.filesave.minput[i].name;
                _lvi.Tag = CComLibrary.GlobeVal.filesave.minput[i];

                _lvi.Group = lvTips.Groups[2];
                lvTips.Items.Add(_lvi);

            }
            for (i = 0; i < CComLibrary.GlobeVal.filesave.moutput.Count; i++)
            {
                _lvi = new ListViewItem();

                string r = CComLibrary.GlobeVal.filesave.moutput[i].formulaname;
                r = r.Replace(" ", "_");
                _lvi.Text = r;
                _lvi.Tag = CComLibrary.GlobeVal.filesave.moutput[i];

                _lvi.Group = lvTips.Groups[2];
                lvTips.Items.Add(_lvi);
            }


            for (i = 0; i < CComLibrary.GlobeVal.mfunc.Count; i++)
            {
                if (CComLibrary.GlobeVal.languageselect == 0)
                {
                    if (CComLibrary.GlobeVal.mfunc[i].OperaWordsName == "_面积")
                    {
                        _lvi = new ListViewItem();


                        _lvi.Text = CComLibrary.GlobeVal.mfunc[i].OperaWordsName;
                        _lvi.Tag = CComLibrary.GlobeVal.mfunc[i];

                        _lvi.Group = lvTips.Groups[3];
                        lvTips.Items.Add(_lvi);
                    }

                    if (CComLibrary.GlobeVal.mfunc[i].OperaWordsName == "_引伸计标距")
                    {
                        _lvi = new ListViewItem();


                        _lvi.Text = CComLibrary.GlobeVal.mfunc[i].OperaWordsName;
                        _lvi.Tag = CComLibrary.GlobeVal.mfunc[i];

                        _lvi.Group = lvTips.Groups[3];
                        lvTips.Items.Add(_lvi);
                    }

                    if (CComLibrary.GlobeVal.mfunc[i].OperaWordsName == "_引伸计2标距")
                    {
                        _lvi = new ListViewItem();


                        _lvi.Text = CComLibrary.GlobeVal.mfunc[i].OperaWordsName;
                        _lvi.Tag = CComLibrary.GlobeVal.mfunc[i];

                        _lvi.Group = lvTips.Groups[3];
                        lvTips.Items.Add(_lvi);
                    }
                }
                else
                {
                    if (CComLibrary.GlobeVal.mfunc[i].OperaWordsName == "_Area")
                    {
                        _lvi = new ListViewItem();


                        _lvi.Text = CComLibrary.GlobeVal.mfunc[i].OperaWordsName;
                        _lvi.Tag = CComLibrary.GlobeVal.mfunc[i];

                        _lvi.Group = lvTips.Groups[3];
                        lvTips.Items.Add(_lvi);
                    }

                    if (CComLibrary.GlobeVal.mfunc[i].OperaWordsName == "_ExtensometerGaugeForOne")
                    {
                        _lvi = new ListViewItem();


                        _lvi.Text = CComLibrary.GlobeVal.mfunc[i].OperaWordsName;
                        _lvi.Tag = CComLibrary.GlobeVal.mfunc[i];

                        _lvi.Group = lvTips.Groups[3];
                        lvTips.Items.Add(_lvi);
                    }

                    if (CComLibrary.GlobeVal.mfunc[i].OperaWordsName == "_ExtensometerGaugeForTow")
                    {
                        _lvi = new ListViewItem();


                        _lvi.Text = CComLibrary.GlobeVal.mfunc[i].OperaWordsName;
                        _lvi.Tag = CComLibrary.GlobeVal.mfunc[i];

                        _lvi.Group = lvTips.Groups[3];
                        lvTips.Items.Add(_lvi);
                    }
                }

            }







        }

        public void  InitListView()
        {
            int i;
            int j;


            //lvTips.View = View.LargeIcon;


            lvTips.View = View.SmallIcon;


            ImageList iList = new ImageList();
            iList.ImageSize = new Size(25, 25);//宽度和高度值必须大于等于1且不超过256
            lvTips.SmallImageList = iList;






            ListViewItem _lvi = new ListViewItem();



            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                _lvi.Text = "_结果";
                _lvi.Tag = "_结果";

            }
            else
            {
                _lvi.Text = "_Result";
                _lvi.Tag = "_Result";
            }

            _lvi.Group = lvTips.Groups[0] ;

          

            lvTips.Items.Add(_lvi);
           

             _lvi = new ListViewItem();
            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                _lvi.Text = "_数组长度";
                _lvi.Tag = "_数组长度";
            }
            else
            {
                _lvi.Text = "_Length_of_array";
                _lvi.Tag = "_Length_of_array";
            }

            _lvi.Group = lvTips.Groups[0];


            lvTips.Items.Add(_lvi);

           
            _lvi = new ListViewItem();

            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                _lvi.Text = "_索引";
                _lvi.Tag = "_索引";
            }
            else
            {
                _lvi.Text = "_Index";
                _lvi.Tag = "_Index";
            }
            _lvi.Group = lvTips.Groups[0];
            lvTips.Items.Add(_lvi);

            
                for (i = 0; i < CComLibrary.GlobeVal.filesave.m_namelist.Count; i++)
                {
                    _lvi = new ListViewItem();

                string s = CComLibrary.GlobeVal.filesave.m_namelist[i];

                  s=s.Replace(" ", "_");
                _lvi.Text = s;
                    _lvi.Tag = s;

                    _lvi.Group = lvTips.Groups[0];
                    lvTips.Items.Add(_lvi);

                }
            


            
           
                for (i = 0; i < CComLibrary.GlobeVal.filesave.muserchannel.Count; i++)
                {
                    _lvi = new ListViewItem();
                    _lvi.Text = CComLibrary.GlobeVal.filesave.muserchannel[i].channelname;
                    _lvi.Tag = CComLibrary.GlobeVal.filesave.muserchannel[i];
                    _lvi.Group = lvTips.Groups[0];
                    lvTips.Items.Add(_lvi);
                }
           
        
 

 


            for (i = 0; i < CComLibrary.GlobeVal.mrule.Count; i++)
            {
                 _lvi = new ListViewItem();
                _lvi.Text = CComLibrary.GlobeVal.mrule[i].OperaWordsName;
                _lvi.Tag = CComLibrary.GlobeVal.mrule[i];
                
                _lvi.Group = lvTips.Groups[1];
                lvTips.Items.Add(_lvi);

            }

            for (j = 0; j < CComLibrary.GlobeVal.filesave.mshapelist.Count; j++)
            {
                for (i = 0; i < CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem.Length; i++)
                {
                   
                        if ((CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem[i].cName != "None"))
                        {
                            _lvi = new ListViewItem();
                            string r = CComLibrary.GlobeVal.filesave.mshapelist[j].shapename + "_" +
                                CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem[i].cName;
                            r = r.Replace(" ", "_");

                            _lvi.Text = r;

                            _lvi.Tag = CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem[i];

                            _lvi.Group = lvTips.Groups[2];
                            lvTips.Items.Add(_lvi);
                        }
                   

                }
            }
            for (i = 0; i < CComLibrary.GlobeVal.filesave.mcbo.Count; i++)
            {
                _lvi = new ListViewItem();
                _lvi.Text = CComLibrary.GlobeVal.filesave.mcbo[i].Name;
                _lvi.Tag = CComLibrary.GlobeVal.filesave.mcbo[i];

                _lvi.Group = lvTips.Groups[2];
                lvTips.Items.Add(_lvi);

            }

            for (i = 0; i < CComLibrary.GlobeVal.filesave.minput.Count; i++)
            {
                _lvi = new ListViewItem();
                _lvi.Text = CComLibrary.GlobeVal.filesave.minput[i].name ;
                _lvi.Tag = CComLibrary.GlobeVal.filesave.minput[i];
                
                _lvi.Group = lvTips.Groups[2];
                lvTips.Items.Add(_lvi);

            }
            /*
            for (i = 0; i < CComLibrary.GlobeVal.filesave.moutput.Count; i++)
            {
                _lvi = new ListViewItem();
                string r = CComLibrary.GlobeVal.filesave.moutput[i].formulaname;
                r = r.Replace(" ", "_");
                _lvi.Text =r;
                _lvi.Tag = CComLibrary.GlobeVal.filesave.moutput[i];

                _lvi.Group = lvTips.Groups[2];
                lvTips.Items.Add(_lvi);
            }
            */


            for (i = 0; i < CComLibrary.GlobeVal.mfunc.Count; i++)
            {
                _lvi = new ListViewItem();
                _lvi.Text = CComLibrary.GlobeVal.mfunc[i].OperaWordsName;
                _lvi.Tag = CComLibrary.GlobeVal.mfunc[i];

                _lvi.Group = lvTips.Groups[3];
                lvTips.Items.Add(_lvi);

            }

            for (i = 0; i < CComLibrary.GlobeVal.mconst.Count; i++)
            {
                _lvi = new ListViewItem();
                _lvi.Text = CComLibrary.GlobeVal.mconst[i].OperaWordsName;
                _lvi.Tag = CComLibrary.GlobeVal.mconst[i];

                _lvi.Group = lvTips.Groups[4];
                lvTips.Items.Add(_lvi);

            }

           

          


        }
        public FormCalc()
        {
            InitializeComponent();
         
                  
        }

        private void FormCalc_Load(object sender, EventArgs e)
        {


          
            Init_Rule();
            Init_SystemPara();
           // Init_Const();

            
 
            this.txtContent.Settings.Keywords.Add("function");
            this.txtContent.Settings.Keywords.Add("if");
            this.txtContent.Settings.Keywords.Add("{");
            this.txtContent.Settings.Keywords.Add("}");
            this.txtContent.Settings.Keywords.Add("else");
            this.txtContent.Settings.Keywords.Add("else if");
            this.txtContent.Settings.Keywords.Add("break");
            this.txtContent.Settings.Keywords.Add("while");
            this.txtContent.Settings.Keywords.Add("for");

           

            this.txtContent.Settings.Comment = "//";

            // Set the colors that will be used.
            this.txtContent.Settings.KeywordColor = Color.Blue;
            this.txtContent.Settings.CommentColor = Color.Green;
            this.txtContent.Settings.StringColor = Color.Gray;
            this.txtContent.Settings.IntegerColor = Color.Red;
            this.txtContent.Settings.EnableComments = true; 
            
            // Let's not process strings and integers.
            this.txtContent.Settings.EnableStrings = true;
            this.txtContent.Settings.EnableIntegers = true;

            // Let's make the settings we just set valid by compiling
            // the keywords to a regular expression.
            this.txtContent.CompileKeywords();

            // Load a file and update the syntax highlighting.
            //m_syntaxRichTextBox.LoadFile("script.txt", RichTextBoxStreamType.PlainText);

            txtPropName.Text = CComLibrary.GlobeVal._programname;
            txtContent.Text = CComLibrary.GlobeVal._programstring;


            this.txtContent.ProcessAllLines();

            outputwindow2 = new RichTextBox();
            outputwindow2.BackColor = Color.White;
            outputwindow2.Visible = true;
            outputwindow2.Dock = DockStyle.Fill;
            outputwindow2.BorderStyle = BorderStyle.None; 

            _SheetView1 = new SheetView();
            _SheetView1.Dock = DockStyle.Bottom;
            _SheetView1.Height = 18;
            _SheetView1.Font = new Font("verdana", 8, GraphicsUnit.Point);
            _SheetView1.Sheets.Clear();
            if (CComLibrary.GlobeVal.languageselect == 0)
            {
                _SheetView1.Sheets.Add(new Sheet("输出"));
            }
            else
            {
                _SheetView1.Sheets.Add(new Sheet("Output"));
            }
           // _SheetView1.SelectionChanged += new EventHandler(_SheetView1_SelectionChanged);
            _SheetView1.SelectedIndex = 0;

            panel1.Controls.Clear();
            panel1.Controls.Add(_SheetView1);

            
            panel1.Controls.Add(outputwindow2);

            CComLibrary.GlobeVal.m_calc_outputwindow = outputwindow2;
            if (this.kind == 0)
            {
                InitListViewChannel(); 
            }
            else
            {
                InitListView();
            }
  
        }

        private void lvTips_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvTips_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int v;

            
             if (lvTips.SelectedItems ==null ) 
            {
            }
            else
            {
                 v=this.txtContent.SelectionStart;
                this.txtContent.Text = this.txtContent.Text.Insert(this.txtContent.SelectionStart, lvTips.SelectedItems[0].Text);
                this.txtContent.SelectionStart = v + lvTips.SelectedItems[0].Text.Length;
                this.txtContent.Focus();
               
            }

 
        }

        private void tsbTest_Click(object sender, EventArgs e)
        {
            bool a=false ;
            double w = 0;

             CComLibrary.GlobeVal.m_test = true;

           
             if (CComLibrary.GlobeVal.formulakind == 0)
             {
                 
                  CComLibrary.GlobeVal.gcalc.expchannel(txtContent.Text, 1, out a);
                 
             }
             else
             {
                 for (int i = 0; i < 100; i++)
                 {
                     ClsStaticStation.m_Global.mresult[i] = 0;
                 }

                 CComLibrary.GlobeVal.gcalc.expstr(txtContent.Text, 1, out a);
             }
             

            if (a == true)
            {
                if (CComLibrary.GlobeVal.languageselect == 0)
                {
                    CComLibrary.GlobeVal.m_calc_outputwindow.Text =
                        CComLibrary.GlobeVal.m_calc_outputwindow.Text + "成功";
                }
                else
                {
                    CComLibrary.GlobeVal.m_calc_outputwindow.Text =
                        CComLibrary.GlobeVal.m_calc_outputwindow.Text + "Success";
                }
            }
            else
            {
                if (CComLibrary.GlobeVal.languageselect == 0)
                {
                    CComLibrary.GlobeVal.m_calc_outputwindow.Text =
                       CComLibrary.GlobeVal.m_calc_outputwindow.Text + "失败";
                }
                else
                {
                    CComLibrary.GlobeVal.m_calc_outputwindow.Text =
                      CComLibrary.GlobeVal.m_calc_outputwindow.Text + "fail";
                }

               if (CComLibrary.GlobeVal.errorline >= 0)
               {
                  int st=  txtContent.Text.IndexOf(txtContent.Lines[CComLibrary.GlobeVal.errorline]);
                  txtContent.Select(st, txtContent.Lines[CComLibrary.GlobeVal.errorline].Length);
                  
               }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            string s;
            CComLibrary.GlobeVal._programstring = txtContent.Text;
            

        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            
  
            
        }

        private void txtContent_TextChanged(object sender, EventArgs e)
        {
            this.txtContent.CompileKeywords();

            this.txtContent.ProcessAllLines();
        }

        private void toolStripButton1_Click_2(object sender, EventArgs e)
        {
           
        }

        private void lvTips_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            int i;
            DataGridViewRow b;
            txtMethodName.Text = e.Item.Text;
            txtDescription.Text = "";
            dgvParameters.Rows.Clear();

            if (e.Item.Group == lvTips.Groups[0])
            {

            }

            if (e.Item.Group == lvTips.Groups[1])
            {
                txtDescription.Text = (e.Item.Tag as CComLibrary.Rule).explain;
               
                dgvParameters.Rows.Clear();

                for (i = 0; i < (e.Item.Tag as CComLibrary.Rule).count; i++)
                {
                    b = new DataGridViewRow();
                    dgvParameters.Rows.Add(b);
                    dgvParameters.Rows[i].Cells[0].Value = (e.Item.Tag as CComLibrary.Rule).paraname[i];
                    dgvParameters.Rows[i].Cells[1].Value = (e.Item.Tag as CComLibrary.Rule).parakind[i];
                   
                }
              
            }

            if (e.Item.Group == lvTips.Groups[2])
            {

            }

            if (e.Item.Group == lvTips.Groups[3])
            {
                txtDescription.Text = (e.Item.Tag as CComLibrary.Rule).explain;
               

                dgvParameters.Rows.Clear();

                for (i = 0; i < (e.Item.Tag as CComLibrary.Rule).count; i++)
                {
                    b = new DataGridViewRow();
                    dgvParameters.Rows.Add(b);
                    dgvParameters.Rows[i].Cells[0].Value = (e.Item.Tag as CComLibrary.Rule).paraname[i];
                    dgvParameters.Rows[i].Cells[1].Value = (e.Item.Tag as CComLibrary.Rule).parakind[i];

                }
            }

            if (e.Item.Group == lvTips.Groups[4])
            {
                txtDescription.Text = (e.Item.Tag as CComLibrary.Rule).explain;
               
                dgvParameters.Rows.Clear();

                for (i = 0; i < (e.Item.Tag as CComLibrary.Rule).count; i++)
                {
                    b = new DataGridViewRow();
                    dgvParameters.Rows.Add(b);
                    dgvParameters.Rows[i].Cells[0].Value = (e.Item.Tag as CComLibrary.Rule).paraname[i];
                    dgvParameters.Rows[i].Cells[1].Value = (e.Item.Tag as CComLibrary.Rule).parakind[i];

                }
            }
            
        }

        private void lvTips_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Clipboard.SetData(DataFormats.Rtf, this.txtContent.SelectedRtf);
        }

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Rtf, this.txtContent.SelectedRtf);//复制RTF数据到剪贴板
            this.txtContent.SelectedRtf = "";
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtContent.Paste();
        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtContent.Select(0, this.txtContent.Rtf.Length);
        }

        private void panel4_Scroll(object sender, ScrollEventArgs e)
        {
           
        }

        private void lvTips_VScroll(object sender, EventArgs e)
        {
            lvTips.Refresh();

          
        }

        private void lvTips_HScroll(object sender, EventArgs e)
        {
            lvTips.Refresh();

          

        }
    }
}
