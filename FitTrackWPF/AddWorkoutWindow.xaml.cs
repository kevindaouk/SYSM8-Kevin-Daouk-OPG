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
using System.Windows.Shapes;

namespace FitTrackWPF
{
    /// <summary>
    /// Interaction logic for AddWorkoutWindow.xaml
    /// </summary>
    public partial class AddWorkoutWindow : Window
    {
        UserManager manager;
        public AddWorkoutWindow(UserManager manager)
        {
            InitializeComponent();
            this.manager = manager;
        }

            private void btnSaveWorkout(object sender, RoutedEventArgs e)
            {
                AddWorkoutWindow workoutwindow = new AddWorkoutWindow(manager);
                workoutwindow.Show();
                this.Close();
        }

        private void btnCancelWorkout(object sender, RoutedEventArgs e)
        {
            WorkoutsWindow workoutwindow = new WorkoutsWindow(manager);
            workoutwindow.Show();
            this.Close();
        }
    }
}
