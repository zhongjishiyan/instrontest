using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Management;  //必须在项目中添加System.Management引用！
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ClsStaticStation
{
    public partial class FormOnLine : Form
    {
        public uint device = 0;
        public int sel = -1;

        public Byte byte0;
        public Byte byte1;
        public Byte byte2;
        public Byte byte3;

        public FormOnLine()
        {
            InitializeComponent();

            comboBox2.Items.Clear();
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            for (int i=0;i<=7;i++)
            {
                comboBox2.Items.Add(i.ToString().Trim());
            }
            comboBox1.Items.Clear();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            for (int i=0;i<=5;i++)
            {

                comboBox1.Items.Add(i.ToString().Trim());
            }
            //comboBox1.Items.AddRange(GetMacByWMI().ToArray());

        }

        public  List<string> GetMacByWMI()
        {
            List<string> macs = new List<string>();
            try
            {
                string mac = "";
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"])
                    {
                        mac = mo["MacAddress"].ToString();
                        macs.Add(mo["Description"].ToString() +" ip "+ ((string[])mo["IPAddress"])[0].ToString());
                    }
                }
                moc = null;
                mc = null;
            }
            catch
            {
            }

            return macs;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sel = comboBox1.SelectedIndex;
            device = Convert.ToUInt32(comboBox2.SelectedIndex);
            byte0 = Convert.ToByte(textBox1.Text);
            byte1 = Convert.ToByte(textBox2.Text);
            byte2 = Convert.ToByte(textBox3.Text);
            byte3 = Convert.ToByte(textBox4.Text); 
            Close();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

            sel = comboBox1.SelectedIndex;
        }
    }
}
