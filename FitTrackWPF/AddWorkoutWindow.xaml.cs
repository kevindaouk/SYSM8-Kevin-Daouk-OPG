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
        WorkoutManager workouts;
        public AddWorkoutWindow(UserManager manager, WorkoutManager workouts)
        {
            InitializeComponent();
            this.manager = manager;
            this.workouts = workouts;
        }

        private void btnSaveWorkout(object sender, RoutedEventArgs e)
        {
            string workoutType = cmbWorkoutType.Text;   
            string workoutDate = txtWorkoutDate.Text;
            bool isDurationValid = int.TryParse(txtWorkoutDuration.Text, out int duration);
            string notes = txtNotes.Text;


            if (string.IsNullOrEmpty(workoutType) || string.IsNullOrEmpty(workoutDate) || !isDurationValid)
            {
                MessageBox.Show("Please fill in all the fields correctly.");
                return;

            }
            Workout newWorkout = null;

            if (workoutType == "Cardio")
            {
                bool isCaloriesValid = int.TryParse(txtCaloriesBurned.Text, out int caloriesBurned);
                if (!isCaloriesValid)
                {
                    MessageBox.Show("Please fill in amount of calories burned");
                    return;
                }
                //Skapar cardioworkout
                newWorkout = new CardioWorkout(workoutType, workoutDate, duration, caloriesBurned, notes);
            }
            else if (workoutType == "Strength")
            {
                bool isRepetitionsValid = int.TryParse(txtRepetitions.Text, out int repetitions);
                bool isSetsValid = int.TryParse(txtSets.Text, out int sets);

                if (!isRepetitionsValid || !isSetsValid)
                {
                    MessageBox.Show("Please fill in repetitions and sets");
                    return;
                }
                //Skapar strengthworkout
                newWorkout = new StrengthWorkout(workoutType, workoutDate, duration, repetitions, sets, notes);
            }
            else
            {
                MessageBox.Show("Select valid workout type");
                return;
            }

            if (manager.CurrentUser != null && newWorkout != null)
            {
                manager.CurrentUser.workoutManager.AddWorkout(newWorkout);
                MessageBox.Show("Workout added!");

                // Gå tillbaka till WorkoutsWindow
                WorkoutsWindow workoutsWindow = new WorkoutsWindow(manager, manager.CurrentUser.workoutManager);
                workoutsWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("No user is currently logged in.");
            }

        }

        private void btnCancelWorkout(object sender, RoutedEventArgs e)
        {
            WorkoutsWindow workoutsWindow = new WorkoutsWindow(manager, workouts);
            workoutsWindow.Show();
            this.Close();

        }

        private void cmbWorkoutType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbWorkoutType.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedWorkoutType = selectedItem.Content.ToString();

                // Hantera visningen baserat på typen av träningspass
                if (selectedWorkoutType == "Cardio")
                {
                    cardioFields.Visibility = Visibility.Visible;
                    strengthFields.Visibility = Visibility.Collapsed;
                    
                }
                else if (selectedWorkoutType == "Strength")
                {
                    strengthFields.Visibility = Visibility.Visible;
                    cardioFields.Visibility = Visibility.Collapsed;
                    
                }
                else
                {
                    // Döljer båda om ingen är vald
                    cardioFields.Visibility = Visibility.Collapsed;
                    strengthFields.Visibility = Visibility.Collapsed;
                }
            }
        }
    } 


}


