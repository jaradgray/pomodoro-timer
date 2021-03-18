using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PomodoroTimer.models
{
    class PomodoroTimer : BaseINPC
    {
        // Constants
        // property names
        public const string PROPERTY_NAME_SECONDS = "Seconds";
        public const string PROPERTY_NAME_NUM_POMODOROS = "NumPomodoros";

        //public const int DEFAULT_VALUE_SECONDS = 25 * 60; // 25 mins
        public const int DEFAULT_VALUE_SECONDS = 2; // 25 mins


        // Properties and their backing fields

        private int _seconds;
        public int Seconds
        {
            get { return _seconds; }
            set
            {
                _seconds = value;
                OnPropertyChanged(PROPERTY_NAME_SECONDS);
            }
        }

        private int _numPomodoros;
        public int NumPomodoros
        {
            get { return _numPomodoros; }
            private set
            {
                _numPomodoros = value;
                OnPropertyChanged(PROPERTY_NAME_NUM_POMODOROS);
            }
        }

        public bool IsRunning
        {
            get { return timer.Enabled; }
        }


        // Private variables
        private Timer timer;


        // Constructor
        public PomodoroTimer()
        {
            // Initialize members
            timer = new Timer();
            timer.Interval = 1000;
            timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;

            Seconds = DEFAULT_VALUE_SECONDS;
            NumPomodoros = 0;
        }


        // Public methods

        public void Start()
        {
            timer.Enabled = true;
        }

        public void Stop()
        {
            timer.Enabled = false;
            Seconds = DEFAULT_VALUE_SECONDS;
        }


        // Private methods

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Seconds--;
            if (Seconds == 0)
            {
                // POMODORO COMPLETE
                Console.WriteLine("Pomodoro complete!");
                NumPomodoros++;
                timer.Enabled = false;
                Seconds = DEFAULT_VALUE_SECONDS;
            }
        }
    }
}
