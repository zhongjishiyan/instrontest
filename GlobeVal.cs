using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TabHeaderDemo
{
    public sealed  class   GlobeVal
    {

        private readonly int MOUSEEVENTF_LEFTDOWN = 0x2;
        private readonly int MOUSEEVENTF_LEFTUP = 0x4;
        [DllImport("user32")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        public GlobeVal()
        {
          
        }
        public static   string mmethodfilename;

        public static CComLibrary.FileStruct filesavecmp;

        public static int lastindex = -1;

        public static  Panel backpanel;
        public static  UserControlTest  userControltest1;
        public static UserControlMain UserControlMain1;
        public static UserControlPretest userControlpretest1;
        public static UserControlMethod userControlmethod1;

        public static Button mbtntest;
        public static  UserControlDynSet dynset;
        public static  UserControlWizard wizard;
        public static bool resizing = false;
        public static ClassSys mysys;


        public static UserControlResult UserControlResult1;
        public static UserControlResult UserControlResult2;
        public static UserControlSpe UserControlSpe1;
        public static UserControlGraph UserControlGraph1;
        public static UserControlGraph UserControlGraph2;
        public static bool suc = false;

        public static ClsStaticStation.ClsBaseControl myarm;

      


        public static string username = "";
        public static string userpassword = "";
        public static int userkind = 0;

        public static string spefilename = "";

        public static StatusStrip MainStatusStrip;

        public static FormMainLab FormmainLab;


    }
}
