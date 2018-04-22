using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace TabHeaderDemo
{
    public partial class WaitForm :  Frm.FormLink 
    {
        public WaitForm()
        {
           
            SetText("");
        }

        private delegate void SetTextHandler(string text);
        public void SetText(string text)
        {
            if (this.label2.InvokeRequired)
            {
                this.Invoke(new SetTextHandler(SetText), text);
            }
            else
            {
                this.label2.Text = text;
            }
        }
    }
    public class WaitFormService
    {
        public static void CreateWaitForm()
        {
            WaitFormService.Instance.CreateForm();
        }

        public static void CloseWaitForm()
        {
            WaitFormService.Instance.CloseForm();
        }

        public static void SetWaitFormCaption(string text)
        {
            WaitFormService.Instance.SetFormCaption(text);
        }

        private static WaitFormService _instance;
        private static readonly Object syncLock = new Object();

        public static WaitFormService Instance
        {
            get
            {
                if (WaitFormService._instance == null)
                {
                    lock (syncLock)
                    {
                        if (WaitFormService._instance == null)
                        {
                            WaitFormService._instance = new WaitFormService();
                        }
                    }
                }
                return WaitFormService._instance;
            }
        }

        private WaitFormService()
        {
        }

        private Thread waitThread;
        private WaitForm waitForm;

        public void CreateForm()
        {
            if (waitThread != null)
            {
                try
                {
                    waitThread.Abort();
                }
                catch (Exception)
                {
                }
            }

            waitThread = new Thread(new ThreadStart(delegate ()
            {
                waitForm = new WaitForm();
                Application.Run(waitForm);
            }));
            waitThread.Start();
        }

        public void CloseForm()
        {
            if (waitThread != null)
            {
                try
                {
                    waitThread.Abort();
                }
                catch (Exception)
                {
                }
            }
        }

        public void SetFormCaption(string text)
        {
            if (waitForm != null)
            {
                try
                {
                    waitForm.SetText(text);
                }
                catch (Exception)
                {
                }
            }
        }
    }
   
}
