using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PipesClientTest
{
    public partial class Form1 : Form
    {
        private PipeClient _pipeClient;
        private int _ctr; 

        public Form1()
        {
            InitializeComponent();
            _ctr = 1;
        }

        private void cmdSend_Click(object sender, EventArgs e)
        {
            _pipeClient = new PipeClient();
            timer1.Enabled = true; 
            // _pipeClient.Send(txtMessage.Text + " - " + _ctr.ToString(), "TestPipe", 1000);
            
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _pipeClient = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _pipeClient.Send(_ctr.ToString(), "TestPipe", 1000);

            _ctr++;
        }
    }
}
