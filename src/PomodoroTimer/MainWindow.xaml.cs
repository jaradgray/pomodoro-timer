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
                        this.Dispatcher.Invoke(() => ViewModel_SecondsChanged());
                        break;
                }
            };

            // Initialize Views to ViewModel state
            ViewModel_SecondsChanged();
        }


        // Event Handlers
        private void StartStopButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ToggleTimer();
        }


        // Private methods

        private void ViewModel_SecondsChanged()
        {
            timeTextBlock.Text = viewModel.Seconds.ToString();
        }
    }
}
