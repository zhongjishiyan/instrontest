using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;

namespace UltraHighAccurateTimer
{
    ///
    /// ManualTimer
    /// A simulated timer by loop
    /// It creates a new thread in Thread Pool using ThreadPool class
    /// Nocky Tian @ 2008-3-16
    ///
    /// The timer starts a new thread using  object,
    /// and the value of the property Priority is set to
    /// so that the accuray could be kept 1ms around.
    ///
    ///
    ///
    ///
    public class UltraHighAccurateTimer
    {
        public delegate void ManualTimerEventHandler(object sender);

        public event ManualTimerEventHandler Tick;

        private long clockFrequency;            // result of QueryPerformanceFrequency()
        private bool running = false;
        private Thread timerThread;

        private int intervalMs;                     // interval in mimliseccond;

        ///
        /// Timer inteval in milisecond
        ///
        public int Interval
        {
            get { return intervalMs; }
            set
            {
                intervalMs = value;
                intevalTicks = (long)((double)value * (double)clockFrequency / (double)1000);
            }
        }

        private long intevalTicks;

        ///
        /// Pointer to a variable that receives the current performance-counter value, in counts.
        ///
        ///
        /// If the function succeeds, the return value is nonzero.
        ///
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

        ///
        /// Pointer to a variable that receives the current performance-counter frequency,
        /// in counts per second.
        /// If the installed hardware does not support a high-resolution performance counter,
        /// this parameter can be zero.
        ///
        ///
        /// If the installed hardware supports a high-resolution performance counter,
        /// the return value is nonzero.
        ///
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);

        public UltraHighAccurateTimer()
        {
            if (QueryPerformanceFrequency(out clockFrequency) == false)
            {
                // Frequency not supported
                throw new Win32Exception("QueryPerformanceFrequency() function is not supported");
            }
        }

        ///
        /// 进程主程序
        ///
        ///
        private void ThreadProc()
        {
            long currTime;
            long nextTriggerTime;               // the time when next task will be executed
            GetTick(out currTime);
            nextTriggerTime = currTime + intevalTicks;
            while (running)
            {
                while (currTime < nextTriggerTime)
                {
                    GetTick(out currTime);
                }   // wailt an interval
                nextTriggerTime = currTime + intevalTicks;
                if (Tick != null)
                {
                    Tick(this);
                }
            }
        }

        public bool GetTick(out long currentTickCount)
        {
            if (QueryPerformanceCounter(out currentTickCount) == false)
                throw new Win32Exception("QueryPerformanceCounter() failed!");
            else
                return true;
        }

        public void Start()
        {
            running = true;

            timerThread = new Thread(new ThreadStart(ThreadProc));
            timerThread.Name = "HighAccuracyTimer";
            timerThread.Priority = ThreadPriority.Highest;

            timerThread.Start();
        }

        public void Stop()
        {
            running = false;
            timerThread.Abort();
        }

        ~UltraHighAccurateTimer()
        {
            running = false;
            timerThread.Abort();
        }
    }
}