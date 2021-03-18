using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroTimer.viewmodels
{
    class MainWindowViewModel : BaseINPC
    {
        // Properties and their backing fields

        private int _seconds;
        public int Seconds
        {
            get { return _seconds; }
            set
            {
                _seconds = value;
                OnPropertyChanged(models.PomodoroTimer.PROPERTY_NAME_SECONDS);
            }
        }

        private int _numPomodoros;
        public int NumPomodoros
        {
            get { return _numPomodoros; }
            private set
            {
                _numPomodoros = value;
                OnPropertyChanged(models.PomodoroTimer.PROPERTY_NAME_NUM_POMODOROS);
            }
        }

        private models.PomodoroTimer.PomodoroTimerState _timerState;
        public models.PomodoroTimer.PomodoroTimerState TimerState
        {
            get { return _timerState; }
            private set
            {
                _timerState = value;
                OnPropertyChanged(models.PomodoroTimer.PROPERTY_NAME_STATE);
            }
        }


        // Private variables
        models.PomodoroTimer timer;


        // Constructor
        public MainWindowViewModel()
        {
            // Create timer
            timer = new models.PomodoroTimer();
            // Handle timer's property changed event
            timer.PropertyChanged += (sender, args) =>
            {
                switch (args.PropertyName)
                {
                    case models.PomodoroTimer.PROPERTY_NAME_SECONDS:
                        Seconds = timer.Seconds;
                        break;
                    case models.PomodoroTimer.PROPERTY_NAME_NUM_POMODOROS:
                        NumPomodoros = timer.NumPomodoros;
                        break;
                    case models.PomodoroTimer.PROPERTY_NAME_STATE:
                        TimerState = timer.State;
                        break;
                }
            };
            // Initialize fields to timer's state
            Seconds = timer.Seconds;
            NumPomodoros = timer.NumPomodoros;
            TimerState = timer.State;
        }


        // Public methods
        public void Button_Click()
        {
            switch (timer.State)
            {
                case models.PomodoroTimer.PomodoroTimerState.Stopped:
                    timer.Start();
                    break;
                case models.PomodoroTimer.PomodoroTimerState.Running:
                    timer.Reset();
                    break;
            }
        }

        public void ResetTimer()
        {
            timer.Reset();
        }
    }
}
