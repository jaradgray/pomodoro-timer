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
                }
            };
            // Initialize fields to timer's state
            Seconds = timer.Seconds;
        }


        // Public methods
        public void ToggleTimer()
        {
            if (timer.IsRunning)
            {
                timer.Stop();
            }
            else
            {
                timer.Start();
            }
        }
    }
}
