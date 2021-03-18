using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PomodoroTimer.viewmodels;

namespace PomodoroTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Private variables
        private MainWindowViewModel viewModel;


        // Constructor
        public MainWindow()
        {
            InitializeComponent();

            // Get a ViewModel
            viewModel = new MainWindowViewModel();

            // Handle changes to the ViewModel's state
            viewModel.PropertyChanged += (sender, args) =>
            {
                switch (args.PropertyName)
                {
                    case models.PomodoroTimer.PROPERTY_NAME_SECONDS:
                        // UI will be updated, must be on main thread
                        this.Dispatcher.Invoke(() => Seconds_Change());
                        break;
                    case models.PomodoroTimer.PROPERTY_NAME_NUM_POMODOROS:
                        this.Dispatcher.Invoke(() => NumPomodoros_Change());
                        break;
                }
            };

            // Initialize Views to ViewModel state
            Seconds_Change();
            NumPomodoros_Change();
        }


        // Event Handlers
        private void StartStopButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ToggleTimer();
        }


        // Private methods

        private void Seconds_Change()
        {
            int min = viewModel.Seconds / 60;
            int sec = viewModel.Seconds % 60;
            timeTextBlock.Text = string.Format("{0:D2}:{1:D2}", min, sec);
        }

        private void NumPomodoros_Change()
        {
            numPomodorosTextBlock.Text = $"{viewModel.NumPomodoros} pomodoros";
        }
    }
}
