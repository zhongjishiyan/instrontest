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
    public partial class UserControl系统设置 : UserControl
    {
        public UserControlMethod musercontrolmethod;
        public  void Init(int sel)
        {

            tabControl1.SelectedIndex = sel;

            if (GlobeVal.mysys.AppUserLevel == 0)
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
            }
            else
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;  

            }
            cbokind.Items.Clear();

            for (int i = 0; i < GlobeVal.mysys.ControllerCount; i++)
            {
                cbokind.Items.Add(GlobeVal.mysys.ControllerName[i]);
              
            }
            cbokind.SelectedIndex = GlobeVal.mysys.controllerkind;

            cbomachine.Items.Clear();
            for (int i = 0; i < GlobeVal.mysys.MachineCount; i++)
            {
                cbomachine.Items.Add(GlobeVal.mysys.MachineName[i]);

            }

            cbomachine.SelectedIndex = GlobeVal.mysys.machinekind;   
        }
        public  UserControl系统设置()
        {
            InitializeComponent();
            tabControl1.ItemSize = new Size(1, 1);
        }

        private void cbokind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GlobeVal.mysys.controllerkind = cbokind.SelectedIndex;
            GlobeVal.MainStatusStrip.Items["tslbldevice"].Text = GlobeVal.mysys.ControllerName[GlobeVal.mysys.controllerkind];

            GlobeVal.mysys.SerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\sys\\setup.ini");
        }

        private void cbomachine_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GlobeVal.mysys.machinekind = cbomachine.SelectedIndex;
            GlobeVal.MainStatusStrip.Items["tslblmachine"].Text = GlobeVal.mysys.ControllerName[GlobeVal.mysys.machinekind];

            GlobeVal.mysys.SerializeNow(System.Windows.Forms.Application.StartupPath + "\\AppleLabJ" + "\\sys\\setup.ini");
        }
    }
}
