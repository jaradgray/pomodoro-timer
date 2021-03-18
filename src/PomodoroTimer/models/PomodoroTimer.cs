using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroTimer.models
{
    class PomodoroTimer : BaseINPC
    {
        // Constants
        // property names
        public const string PROPERTY_NAME_SECONDS = "Seconds";
        public const string PROPERTY_NAME_NUM_POMODOROS = "NumPomodoros";

        public const int DEFAULT_VALUE_SECONDS = 25 * 60; // 25 mins


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
                // TODO raise PropertyChanged event
            }
        }


        // Constructor
        public PomodoroTimer()
        {
            Seconds = DEFAULT_VALUE_SECONDS;
        }
    }
}
