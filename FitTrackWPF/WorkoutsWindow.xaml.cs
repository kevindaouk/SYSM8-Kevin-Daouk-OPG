using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        UserManager manager;
        WorkoutManager workouts;

        public WorkoutsWindow(UserManager manager, WorkoutManager workouts)
        {
            InitializeComponent();
            this.manager = manager;
            this.workouts = workouts;

            // Få WorkoutManager från den inloggade användaren
            if (manager.CurrentUser != null)
            {
                this.workouts = manager.CurrentUser.WorkoutManager;
            }
            else
            {
                this.workouts = workouts ?? new WorkoutManager();
            }

            DataContext = workouts;
            
         }

        private void btnAddWorkout(object sender, RoutedEventArgs e)
        {
            AddWorkoutWindow workoutwindow = new AddWorkoutWindow(manager, workouts);
            workoutwindow.Show();
            this.Close();

        }

        private void btnInfo(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Our goal is to help you reach your personal goals in training. Click on the workouts that you see in the list below and then \"Add Workout.\"." +
                " If you would like to remove a workout that you didn't do, simply click mark the workout and click \"Remove Workout.\"");
        }

        private void btnSignOut(object sender, RoutedEventArgs e)
        {
            //Nollställer curentuser till null vid utloggning
            manager.CurrentUser = null;
            MainWindow mainWindow = new MainWindow(manager, workouts);
            mainWindow.Show();
            this.Close();
        }

        private void btnRemoveWorkout(object sender, RoutedEventArgs e)
        {
            // Ta bort det träningspass som användaren har valt
            if (lstWorkouts.SelectedItem is Workout selectedWorkout)
            {
                workouts.RemoveWorkout(selectedWorkout);
            }
            else
            {
                MessageBox.Show("Please select a workout to remove.");
            }
        }

        private void btnDetails(object sender, RoutedEventArgs e)
        {
            if (lstWorkouts.SelectedItem is Workout selectedWorkout)
            {
                WorkoutDetailsWindow detailsWindow = new WorkoutDetailsWindow(selectedWorkout, manager, workouts);
                detailsWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a workout to view details.");
            }

        }
    }
}
