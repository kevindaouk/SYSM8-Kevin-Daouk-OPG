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
    /// Interaction logic for WorkoutsWindow.xaml
    /// </summary>
    public partial class WorkoutsWindow : Window
    {
        public WorkoutsWindow()
        {
            InitializeComponent();
        }

        private void btnAddWorkout(object sender, RoutedEventArgs e)
        {
            AddWorkoutWindow workoutwindow = new AddWorkoutWindow();
            workoutwindow.Show();
            this.Close();

        }

        private void btnInfo(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Our goal is to help you reach your personal goals in training. Click on the workouts that you see in the list below and then \"Add Workout.\"." +
                " If you would like to remove a workout that you didn't do, simply click \"Remove Workout.\"");
        }

        private void btnSignOut(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
