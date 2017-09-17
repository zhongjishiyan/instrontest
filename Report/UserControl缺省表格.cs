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
    public partial class UserControl缺省表格 : UserControl
    {
        public UserControlMethod musercontrolmethod;
        public  void Init(int sel)
        {
            TreeNode m1 = new TreeNode();

            tabControl1.SelectedIndex = sel;

            treeView1.Nodes.Clear();
            m1 = treeView1.Nodes.Add("样品");
            m1.Nodes.Add("样品注释1");
            m1.Nodes.Add("样品注释2");
            m1.Nodes.Add("样品注释3");
            m1.Nodes.Add("样品说明");

            m1=treeView1.Nodes.Add("数据采集");
            m1.Nodes.Add("数据采集方式");
            m1.Nodes.Add("准侧1");
            m1.Nodes.Add("测量1");
            m1.Nodes.Add("间隔1");
            m1.Nodes.Add("准侧2");
            m1.Nodes.Add("测量2");
            m1.Nodes.Add("间隔2");
            m1.Nodes.Add("准侧3");
            m1.Nodes.Add("测量3");
            m1.Nodes.Add("间隔3");
            m1 = treeView1.Nodes.Add("测试结束");
            m1.Nodes.Add("试验结束1准则");
            m1.Nodes.Add("试验结束2准则");
            m1 = treeView1.Nodes.Add("主机");
            m1.Nodes.Add("试验区域");
            m1 = treeView1.Nodes.Add("试样尺寸输入");

            m1.Nodes.Add("试样形状");

            for (int i = 0; i <
               CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem.Length; i++)
            {
                if (CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[i].cName != "无")
                {

                    m1.Nodes.Add(CComLibrary.GlobeVal.filesave.mshapelist[CComLibrary.GlobeVal.filesave.shapeselect].sizeitem[i].cName);
                }
            }

            m1 = treeView1.Nodes.Add("试样数字输入");

            for (int i = 0; i <
              CComLibrary.GlobeVal.filesave.minput.Count; i++)
            {
               m1.Nodes.Add(CComLibrary.GlobeVal.filesave.minput[i].name);
            }


            m1 = treeView1.Nodes.Add("试样文本输入");

            for (int i = 0; i <
              CComLibrary.GlobeVal.filesave.minputtext.Count; i++)
            {

                m1.Nodes.Add(CComLibrary.GlobeVal.filesave.minputtext[i].name);
            }


            m1 = treeView1.Nodes.Add("试样选项输入");

            for (int i = 0; i < CComLibrary.GlobeVal.filesave.mcbo.Count; i++)
            {
                m1.Nodes.Add(CComLibrary.GlobeVal.filesave.mcbo[i].Name);

            }


            m1 = treeView1.Nodes.Add("应变选项");

            m1.Nodes.Add("试验过程中摘除引伸计");
            m1.Nodes.Add("引伸计去除准则");
            m1.Nodes.Add("引伸计去除时动作");
            m1.Nodes.Add("冻结去除点应变值");

            m1 = treeView1.Nodes.Add("预加载");
            m1.Nodes.Add("预加载控制通道");
            m1.Nodes.Add("预加载速率");
            m1.Nodes.Add("预加载控制通道");
            m1.Nodes.Add("预加载数值");

            m1 = treeView1.Nodes.Add("测试");

            m1.Nodes.Add("斜线段1速度");
            m1.Nodes.Add("斜线段2速度");
            m1.Nodes.Add("斜线段3速度");
            m1.Nodes.Add("斜线段4速度");

            m1.Nodes.Add("斜线段1控制通道");
            m1.Nodes.Add("斜线段2控制通道");
            m1.Nodes.Add("斜线段3控制通道");
            m1.Nodes.Add("斜线段4控制通道");



        }
        public  UserControl缺省表格()
        {
            InitializeComponent();
            tabControl1.ItemSize = new Size(1, 1);
        }
    }
}
