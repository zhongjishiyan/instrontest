using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.IO.Pipes;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PipesServerTest
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TransferData
    {


        public double Channel1;
        public double Channel2;
        public double Channel3;
        public double Channel4;
        public double Channel5;
        public double Channel6;
        public double Channel7;
        public double Channel8;
        public double Channel9;
        public double Channel10;
        public double Channel11;
        public double Channel12;
        public double Channel13;
        public double Channel14;
        public double Channel15;
        public double Channel16;



        public ulong tcount;




    }
    // Delegate for passing received message back to caller
    public delegate void DelegateMessage(byte[] Reply);


    class PipeServer
    {
        public event DelegateMessage PipeMessage;
        string _pipeName;

        public TransferData _TransferData;

        public void Listen(string PipeName)
        {
            try
            {
                // Set to class level var so we can re-use in the async callback method
                _pipeName = PipeName;
                // Create the new async pipe 
                NamedPipeServerStream pipeServer = new NamedPipeServerStream(PipeName, PipeDirection.In, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);

                // Wait for a connection
                pipeServer.BeginWaitForConnection(new AsyncCallback(WaitForConnectionCallBack), pipeServer);
            }
            catch (Exception oEX)
            {
                Debug.WriteLine(oEX.Message);
            }
        }

        private void WaitForConnectionCallBack(IAsyncResult iar)
        {
            try
            {


                // Get the pipe
                NamedPipeServerStream pipeServer = (NamedPipeServerStream)iar.AsyncState;
                // End waiting for the connection
                pipeServer.EndWaitForConnection(iar);
                int l = Marshal.SizeOf(_TransferData);

                byte[] buffer = new byte[l];

                // Read the incoming message
                pipeServer.Read(buffer, 0, l);

                // Convert byte buffer to string
                //  string stringData = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                // Debug.WriteLine(stringData + Environment.NewLine);

                // Pass message back to calling form

                // char[] stringData = Encoding.UTF8.GetChars(buffer, 0,l); 
                PipeMessage.Invoke(buffer);




                // Kill original sever and create new wait server
                pipeServer.Close();
                pipeServer = null;
                pipeServer = new NamedPipeServerStream(_pipeName, PipeDirection.In, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);

                // Recursively wait for the connection again and again....
                pipeServer.BeginWaitForConnection(new AsyncCallback(WaitForConnectionCallBack), pipeServer);
            }
            catch
            {
                return;
            }
        }

       
    }
}
