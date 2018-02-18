using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PipesClientTest;
using System.Windows.Forms;
namespace DriverDll
{
    public class CDriver
    {
        private PipeClient _pipeClient;
        private int _ctr=0;
        private Timer mtimer;

        public CDriver()
        {
            _pipeClient = new PipeClient();
            mtimer = new Timer();
            mtimer.Interval = 20;
            mtimer.Enabled = false;
            mtimer.Tick += Mtimer_Tick;

        }
        public void Start()
        {
            mtimer.Enabled = true;
        }
        private void Mtimer_Tick(object sender, EventArgs e)
        {
            _pipeClient.Send(_ctr.ToString(), "TestPipe", 1000);

            _ctr++;
            return;
        }

        ~CDriver()
        {
            mtimer.Enabled = false;
            mtimer.Tick -= Mtimer_Tick;
            mtimer.Dispose();
            _pipeClient = null;

        }

    }
}
