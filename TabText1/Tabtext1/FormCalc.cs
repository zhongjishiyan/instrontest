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
    public partial class FormCalc : Form
    {
        public int num;

        public int kind;// 自定义通道还是自定义公式

        SheetView _SheetView1;
        RichTextBox outputwindow2;

        public void Init_Const()
        {
            CComLibrary.GlobeVal.mconst.Clear();
            CComLibrary.Rule a = new CComLibrary.Rule();
            a.OperaWordsName = "_单坐标";
            a.replaceName = a.OperaWordsName;
            a.count = 0;
            a.explain = "坐标轴设置函数使用";

            CComLibrary.GlobeVal.mconst.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_双坐标";
            a.replaceName = a.OperaWordsName;
            a.count = 0;
            a.explain = "坐标轴设置函数使用";

            CComLibrary.GlobeVal.mconst.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_曲线1";
            a.replaceName = a.OperaWordsName;
            a.count = 0;
            a.explain = "曲线序号1";

            CComLibrary.GlobeVal.mconst.Add(a);


            a = new CComLibrary.Rule();
            a.OperaWordsName = "_曲线2";
            a.replaceName = a.OperaWordsName;
            a.count = 0;
            a.explain = "曲线序号2";

            CComLibrary.GlobeVal.mconst.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_曲线3";
            a.replaceName = a.OperaWordsName;
            a.count = 0;
            a.explain = "曲线序号3";

            CComLibrary.GlobeVal.mconst.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_曲线4";
            a.replaceName = a.OperaWordsName;
            a.count = 0;
            a.explain = "曲线序号4";

            CComLibrary.GlobeVal.mconst.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_曲线5";
            a.replaceName = a.OperaWordsName;
            a.count = 0;
            a.explain = "曲线序号5";

            CComLibrary.GlobeVal.mconst.Add(a);


            a = new CComLibrary.Rule();
            a.OperaWordsName = "_曲线6";
            a.replaceName = a.OperaWordsName;
            a.count = 0;
            a.explain = "曲线序号6";

            CComLibrary.GlobeVal.mconst.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_曲线7";
            a.replaceName = a.OperaWordsName;
            a.count = 0;
            a.explain = "曲线序号7";

            CComLibrary.GlobeVal.mconst.Add(a);

            CComLibrary.GlobeVal.mconst.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_曲线8";
            a.replaceName = a.OperaWordsName;
            a.count = 0;
            a.explain = "曲线序号8";

            CComLibrary.GlobeVal.mconst.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_左轴";
            a.replaceName = a.OperaWordsName;
            a.count = 0;
            a.explain = "左侧坐标轴";

            CComLibrary.GlobeVal.mconst.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_右轴";
            a.replaceName = a.OperaWordsName;
            a.count = 0;
            a.explain = "右侧坐标轴";

            CComLibrary.GlobeVal.mconst.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_底轴";
            a.replaceName = a.OperaWordsName;
            a.count = 0;
            a.explain = "底侧坐标轴";

            CComLibrary.GlobeVal.mconst.Add(a);



            a = new CComLibrary.Rule();
            a.OperaWordsName = "_不画特征点";
            a.replaceName = a.OperaWordsName;
            a.count = 0;
            a.explain = "是否画特征点";

            CComLibrary.GlobeVal.mconst.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_画特征点";
            a.replaceName = a.OperaWordsName;
            a.count = 0;
            a.explain = "是否画特征点";

            CComLibrary.GlobeVal.mconst.Add(a);

        }
        public void Init_Func()
        {
            CComLibrary.GlobeVal.mfunc.Clear();

            CComLibrary.Rule a = new CComLibrary.Rule();
            a.OperaWordsName = "_坐标轴设置";
            a.replaceName = a.OperaWordsName;
            a.count = 1;
            a.explain = "坐标轴是单坐标轴还是左右双坐标轴";
            a.paraname[0] = "坐标轴类型";
            a.parakind[0] = "integer";

            CComLibrary.GlobeVal.mfunc.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_消息框";
            a.replaceName = a.OperaWordsName;
            a.count = 1;
            a.explain = "显示消息文本框";
            a.paraname[0] = "文本";
            a.parakind[0] = "string";

            CComLibrary.GlobeVal.mfunc.Add(a);


            a = new CComLibrary.Rule();
            a.OperaWordsName = "_调试输出";
            a.replaceName = a.OperaWordsName;
            a.count = 1;
            a.explain = "在调试界面中输出";
            a.paraname[0] = "文本";
            a.parakind[0] = "string";

            CComLibrary.GlobeVal.mfunc.Add(a);


            a = new CComLibrary.Rule();
            a.OperaWordsName = "_清除曲线";
            a.replaceName = a.OperaWordsName;
            a.count = 1;
            a.explain = "清除指定曲线数据";
            a.paraname[0] = "曲线号";
            a.parakind[0] = "int";

            CComLibrary.GlobeVal.mfunc.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_设置曲线Y坐标轴";
            a.replaceName = a.OperaWordsName;
            a.count = 2;
            a.explain = "指定曲线号对应的坐标轴";
            a.paraname[0] = "曲线号";
            a.parakind[0] = "int";
            a.paraname[1] = "坐标轴";
            a.parakind[1] = "int";
            CComLibrary.GlobeVal.mfunc.Add(a);

          


             a = new CComLibrary.Rule();
             a.OperaWordsName = "_清除所有曲线";
            a.replaceName = a.OperaWordsName;
            a.count = 0;
            a.explain = "清除所有数据";
            a.paraname[0] = "";
            a.parakind[0] = "";

            CComLibrary.GlobeVal.mfunc.Add(a);


            a = new CComLibrary.Rule();
            a.OperaWordsName = "_闭合曲线";
            a.replaceName = a.OperaWordsName;
            a.count = 1;
            a.explain = "从头到尾连接曲线";
            a.paraname[0] = "曲线号";
            a.parakind[0] = "integer";

            CComLibrary.GlobeVal.mfunc.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_画XY曲线";
            a.replaceName = a.OperaWordsName;
            a.count = 3;
            a.explain = "画曲线";
            a.paraname[0] = "X";
            a.parakind[0] = "double []";
            a.paraname[1] = "Y";
            a.parakind[1] = "double []";
            a.paraname[2] = "曲线号";
            a.parakind[2] = "integer";

            CComLibrary.GlobeVal.mfunc.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_画XY点";
            a.replaceName = a.OperaWordsName;
            a.count = 3;
            a.explain = "画曲线点";
            a.paraname[0] = "X";
            a.parakind[0] = "double";
            a.paraname[1] = "Y";
            a.parakind[1] = "double";
            a.paraname[2] = "曲线号";
            a.parakind[2] = "integer";

            CComLibrary.GlobeVal.mfunc.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_拐点";
            a.replaceName = a.OperaWordsName;
            a.count = 4;
            a.explain = "计算拐点";
            a.paraname[0] = "X";
            a.parakind[0] = "double []";
           
            a.paraname[1] = "Y";
            a.parakind[1] = "double []";

            a.paraname[2] = "偏移值";
            a.parakind[2] = "double";

            a.paraname[3] = "是否画特征点";
            a.parakind[3] = "布尔型";

            CComLibrary.GlobeVal.mfunc.Add(a);

           
            


            a = new CComLibrary.Rule();
            a.OperaWordsName = "_斜率";
            a.replaceName = a.OperaWordsName;
            a.count = 3;
            a.explain = "计算斜率";
            a.paraname[0] = "X";
            a.parakind[0] = "double []";

            a.paraname[1] = "Y";
            a.parakind[1] = "double []";

            a.paraname[2] = "是否画特征点";
            a.parakind[2] = "布尔型";
            CComLibrary.GlobeVal.mfunc.Add(a);



            a = new CComLibrary.Rule();
            a.OperaWordsName = "_斜率1";
            a.replaceName = a.OperaWordsName;
            a.count = 5;
            a.explain = "计算斜率";
            a.paraname[0] = "X";
            a.parakind[0] = "double []";

            a.paraname[1] = "Y";
            a.parakind[1] = "double []";

            a.paraname[2] = "YMin%";
            a.parakind[2] = "double";

            a.paraname[3] = "YMax%";
            a.parakind[3] = "double";

            a.paraname[4] = "是否画特征点";
            a.parakind[4] = "布尔型";
            CComLibrary.GlobeVal.mfunc.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_偏置斜率交点";
            a.replaceName = a.OperaWordsName;
            a.count = 6;
            a.explain = "计算斜率平行线和曲线相交点";
            a.paraname[0] = "X";
            a.parakind[0] = "double []";

            a.paraname[1] = "Y";
            a.parakind[1] = "double []";

            a.paraname[2] = "YMin%";
            a.parakind[2] = "double";

            a.paraname[3] = "YMax%";
            a.parakind[3] = "double";

            a.paraname[4] = "偏置量";
            a.parakind[4] = "double";

           

            a.paraname[5] = "是否画特征点";
            a.parakind[5] = "布尔型";
            CComLibrary.GlobeVal.mfunc.Add(a);
           


            a = new CComLibrary.Rule();
            a.OperaWordsName = "_数组Y最大值";
            a.replaceName = a.OperaWordsName;
            a.count = 3;
            a.explain = "计算数组Y最大值";
            a.paraname[0] = "X";
            a.parakind[0] = "double []";
            a.paraname[1] = "Y";
            a.parakind[1] = "double []";

            a.paraname[2] = "是否画特征点";
            a.parakind[2] = "布尔型";
            CComLibrary.GlobeVal.mfunc.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_引伸计标距";
            a.replaceName = a.OperaWordsName;
            a.count = 0;
            a.explain = "取得引伸计标距值";

            CComLibrary.GlobeVal.mfunc.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_引伸计2标距";
            a.replaceName = a.OperaWordsName;
            a.count = 0;
            a.explain = "取得引伸计2标距值";

            CComLibrary.GlobeVal.mfunc.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_断后标距";
            a.replaceName = a.OperaWordsName;
            a.count = 0;
            a.explain = "输入断后标距";
            CComLibrary.GlobeVal.mfunc.Add(a);


            a = new CComLibrary.Rule();
            a.OperaWordsName = "_面积";
            a.replaceName = a.OperaWordsName;
            a.count = 0;
            a.explain = "计算面积";

            CComLibrary.GlobeVal.mfunc.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_断后面积";
            a.replaceName = a.OperaWordsName;
            a.count = 0;
            a.explain = "输入并计算断后试样面积";


            CComLibrary.GlobeVal.mfunc.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_预设点";
            a.replaceName = a.OperaWordsName;
            a.count = 4;
            a.explain = "指定X求对应的Y值";
            a.paraname[0] = "设定通道";
            a.parakind[0] = "double []";

            a.paraname[1] = "计算通道";
            a.parakind[1] = "double []";

            a.paraname[2] = "指定值";
            a.parakind[2] = "double";

            a.paraname[3] = "是否画特征点";
            a.parakind[3] = "布尔型";


            CComLibrary.GlobeVal.mfunc.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_弦向弹模";
            a.replaceName = a.OperaWordsName;
            a.count = 2;
            a.explain = "计算弦向弹模";
            a.paraname[0] = "X";
            a.parakind[0] = "double []";

            a.paraname[1] = "Y";
            a.parakind[1] = "double []";
            //CComLibrary.GlobeVal.mfunc.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_曲线拟合";
            a.replaceName = a.OperaWordsName;
            a.count = 2;
            a.explain = "X 数组";
            a.paraname[0] = "X";
            a.parakind[0] = "double []";
            a.explain = "Y 数组";
            a.paraname[1] = "Y";
            a.parakind[1] = "double []";
            CComLibrary.GlobeVal.mfunc.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_坐标轴标题";
            a.replaceName = a.OperaWordsName;
            a.count = 2;
            a.explain = "坐标轴";
            a.paraname[0] = "C";
            a.parakind[0] = "Integer";
            a.explain = "标题";
            a.paraname[1] = "标题内容";
            a.parakind[1] = "String";
            CComLibrary.GlobeVal.mfunc.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "_曲线标题";
            a.replaceName = a.OperaWordsName;
            a.count = 1;
            a.explain = "标题";
            a.paraname[0] = "标题内容";
            a.parakind[0] = "String";
            CComLibrary.GlobeVal.mfunc.Add(a);
 
        }
        public void Init_Rule()
        {
            CComLibrary.GlobeVal.mrule.Clear();

            CComLibrary.Rule a = new CComLibrary.Rule();
            a.OperaWordsName = "=";
            a.replaceName = "=";
            a.count = 0;
            a.explain = "等于";
            a.paraname[0] = "";
            a.parakind[0] = "";
            CComLibrary.GlobeVal.mrule.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "+";
            a.replaceName = "+";
            a.count = 0;
            a.explain = "加号";
            a.paraname[0] = "";
            a.parakind[0] = "";
            CComLibrary.GlobeVal.mrule.Add(a);


            a = new CComLibrary.Rule();
            a.OperaWordsName = "-";
            a.replaceName = "-";
            a.count = 0;
            a.explain = "减号";
            a.paraname[0] = "";
            a.parakind[0] = "";
            CComLibrary.GlobeVal.mrule.Add(a);


            a = new CComLibrary.Rule();
            a.OperaWordsName = "*";
            a.replaceName = "*";
            a.count = 0;
            a.explain = "乘号";
            a.paraname[0] = "";
            a.parakind[0] = "";
            CComLibrary.GlobeVal.mrule.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "/";
            a.replaceName = "/";
            a.count = 0;
            a.explain = "除号";
            a.paraname[0] = "";
            a.parakind[0] = "";
            CComLibrary.GlobeVal.mrule.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "[";
            a.replaceName = "[";
            a.count = 0;
            a.explain = "数组左括号";
            a.paraname[0] = "";
            a.parakind[0] = "";
            CComLibrary.GlobeVal.mrule.Add(a);


            a = new CComLibrary.Rule();
            a.OperaWordsName = "]";
            a.replaceName = "]";
            a.count = 0;
            a.explain = "数组右括号";
            a.paraname[0] = "";
            a.parakind[0] = "";
            CComLibrary.GlobeVal.mrule.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "(";
            a.replaceName = "(";
            a.count = 0;
            a.explain = "计算左括号";
            a.paraname[0] = "";
            a.parakind[0] = "";
            CComLibrary.GlobeVal.mrule.Add(a);


            a = new CComLibrary.Rule();
            a.OperaWordsName = ")";
            a.replaceName = ")";
            a.count = 0;
            a.explain = "计算右括号";
            a.paraname[0] = "";
            a.parakind[0] = "";
            CComLibrary.GlobeVal.mrule.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "abs";
            a.replaceName = "Math.Abs";
            a.count = 1;
            a.explain = "求绝对值";
            a.paraname[0] = "值";
            a.parakind[0] = "double";
            CComLibrary.GlobeVal.mrule.Add(a);
            a = new  CComLibrary.Rule();
            a.OperaWordsName = "sin";
            a.replaceName = "Math.Sin";
            a.count = 1;
            a.explain = "求正弦";
            a.paraname[0] = "值";
            a.parakind[0] = "double";
            CComLibrary.GlobeVal.mrule.Add(a);
            a = new  CComLibrary.Rule();
            a.OperaWordsName = "cos";
            a.replaceName = "Math.Cos";
            a.count = 1;
            a.explain = "求余弦";
            a.paraname[0] = "值";
            a.parakind[0] = "double";
            CComLibrary.GlobeVal.mrule.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "ceiling";
            a.replaceName = "Math.Ceiling";
            a.count = 1;
            a.explain = "求大于或等于该指定双精度数最小整数";
            a.paraname[0] = "值";
            a.parakind[0] = "double";
            CComLibrary.GlobeVal.mrule.Add(a);


            a = new CComLibrary.Rule();
            a.OperaWordsName = "power";
            a.replaceName = "Math.Pow";
            a.count = 2;
            a.explain = "返回指定数字的指定次幂";
            a.paraname[0] = "x:要乘幂的浮点数";
            a.parakind[0] = "double";
            a.paraname[1] = "y:指定幂的浮点数";
            a.parakind[1] = "double";
            CComLibrary.GlobeVal.mrule.Add(a);


            a = new  CComLibrary.Rule();
            a.OperaWordsName = "sqrt";
            a.replaceName = "Math.Sqrt";
            a.count = 1;
            a.explain = "返回指定数的平方根";
            a.paraname[0] = "要求平方根的数字";
            a.parakind[0] = "double";
            CComLibrary.GlobeVal.mrule.Add(a);


            a = new CComLibrary.Rule();
            a.OperaWordsName = "取整"; 
            a.replaceName = "Convert.ToInt32";
            a.count = 1;
            a.explain = "把浮点数转换为整数";
            a.paraname[0] = "浮点数";
            a.parakind[0] = "double";
            CComLibrary.GlobeVal.mrule.Add(a);

            a = new CComLibrary.Rule();
            a.OperaWordsName = "修约";
            a.replaceName = "修约";
            a.count = 2;
            a.explain = "保留有效位数";
            a.paraname[0] = "浮点数";
            a.parakind[0] = "double";
            a.paraname[1] = "有效位数";
            a.paraname[1] = "integer";
            CComLibrary.GlobeVal.mrule.Add(a);

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
                b.Name = CComLibrary.GlobeVal.filesave.m_namelist[j] + "通道";

                b.replaceName = b.Name;
                s = s + "public double " + b.replaceName + "=0;" + "\r\n";
                CComLibrary.GlobeVal.msyspara.Add(b);

            }

            

            for (j = 0; j < CComLibrary.GlobeVal.filesave.muserchannel.Count; j++)
            {
                b = new CComLibrary.SystemPara();
                b.Name = CComLibrary.GlobeVal.filesave.muserchannel[j].channelname + "通道";

                b.replaceName = b.Name;
                s = s + "public double " + b.replaceName + "=0;" + "\r\n";
                CComLibrary.GlobeVal.msyspara.Add(b);
            }
            

            for (j = 0; j < CComLibrary.GlobeVal.filesave.mshapelist.Count; j++)
            {
                for (i = 0; i < CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem.Length; i++)
                {
                    if (CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem[i].cName != "无")
                    {
                        b = new CComLibrary.SystemPara();
                        b.Name = CComLibrary.GlobeVal.filesave.mshapelist[j].shapename + "_" +
                            CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem[i].cName;
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
                b.Name = CComLibrary.GlobeVal.filesave.moutput[i].formulaname;
                b.replaceName = b.Name;
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




            _lvi.Text = "_结果";
            _lvi.Tag = "_结果";


            _lvi.Group = lvTips.Groups[0];



            lvTips.Items.Add(_lvi);


            _lvi = new ListViewItem();
            _lvi.Text = "_数组长度";
            _lvi.Tag = "_数组长度";


            _lvi.Group = lvTips.Groups[0];


            lvTips.Items.Add(_lvi);


            _lvi = new ListViewItem();
            _lvi.Text = "_索引";
            _lvi.Tag = "_索引";
            _lvi.Group = lvTips.Groups[0];
            lvTips.Items.Add(_lvi);

           

           
                for (i = 0; i < CComLibrary.GlobeVal.filesave.m_namelist.Count; i++)
                {
                    _lvi = new ListViewItem();
                    _lvi.Text = CComLibrary.GlobeVal.filesave.m_namelist[i] + "通道";
                    
                    _lvi.Tag = CComLibrary.GlobeVal.filesave.m_namelist[i] + "通道";

                    _lvi.Group = lvTips.Groups[0];
                    lvTips.Items.Add(_lvi);

                }

           

            
            
                for (i = 0; i < CComLibrary.GlobeVal.filesave.muserchannel.Count; i++)
                {
                    _lvi = new ListViewItem();
                    _lvi.Text = CComLibrary.GlobeVal.filesave.muserchannel[i].channelname + "通道";
                    _lvi.Tag = CComLibrary.GlobeVal.filesave.muserchannel[i] + "通道";
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
                    if (CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem[i].cName != "无")
                    {
                        _lvi = new ListViewItem();
                        _lvi.Text = CComLibrary.GlobeVal.filesave.mshapelist[j].shapename + "_" +
                            CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem[i].cName;

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
                _lvi.Text = CComLibrary.GlobeVal.filesave.moutput[i].formulaname;
                _lvi.Tag = CComLibrary.GlobeVal.filesave.moutput[i];

                _lvi.Group = lvTips.Groups[2];
                lvTips.Items.Add(_lvi);
            }


            for (i = 0; i < CComLibrary.GlobeVal.mfunc.Count; i++)
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

           


            _lvi.Text = "_结果";
           _lvi.Tag = "_结果";


            _lvi.Group = lvTips.Groups[0] ;

          

            lvTips.Items.Add(_lvi);
           

             _lvi = new ListViewItem();
            _lvi.Text = "_数组长度";
            _lvi.Tag = "_数组长度";


            _lvi.Group = lvTips.Groups[0];


            lvTips.Items.Add(_lvi);

           
            _lvi = new ListViewItem();
            _lvi.Text = "_索引";
            _lvi.Tag = "_索引";
            _lvi.Group = lvTips.Groups[0];
            lvTips.Items.Add(_lvi);

            
                for (i = 0; i < CComLibrary.GlobeVal.filesave.m_namelist.Count; i++)
                {
                    _lvi = new ListViewItem();
                    _lvi.Text = CComLibrary.GlobeVal.filesave.m_namelist[i];
                    _lvi.Tag = CComLibrary.GlobeVal.filesave.m_namelist[i];

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
                    if (CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem[i].cName != "无")
                    {
                        _lvi = new ListViewItem();
                        _lvi.Text = CComLibrary.GlobeVal.filesave.mshapelist[j].shapename + "_" +
                            CComLibrary.GlobeVal.filesave.mshapelist[j].sizeitem[i].cName;

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
            for (i = 0; i < CComLibrary.GlobeVal.filesave.moutput.Count; i++)
            {
                _lvi = new ListViewItem();
                _lvi.Text = CComLibrary.GlobeVal.filesave.moutput[i].formulaname ;
                _lvi.Tag = CComLibrary.GlobeVal.filesave.moutput[i];

                _lvi.Group = lvTips.Groups[2];
                lvTips.Items.Add(_lvi);
            }
            


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


            Init_Func();
            Init_Rule();
            Init_SystemPara();
            Init_Const();

            
 
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
             _SheetView1.Sheets.Add(new Sheet("输出"));
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

                CComLibrary.GlobeVal.m_calc_outputwindow.Text =
                    CComLibrary.GlobeVal.m_calc_outputwindow.Text + "成功";
            }
            else
            {
                 CComLibrary.GlobeVal.m_calc_outputwindow.Text =
                    CComLibrary.GlobeVal.m_calc_outputwindow.Text +"失败";

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
    }
}
