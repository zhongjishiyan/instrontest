using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AppleLabApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

         

        [STAThread]
        static void Main()
        {
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            CComLibrary.GlobeVal.m_mainform = new MainForm(); 
            Application.Run(CComLibrary.GlobeVal.m_mainform );
        }
    }
}