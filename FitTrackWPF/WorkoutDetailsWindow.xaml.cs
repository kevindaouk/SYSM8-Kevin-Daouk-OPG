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
    /// Interaction logic for WorkoutDetailsWindow.xaml
    /// </summary>
    public partial class WorkoutDetailsWindow : Window
    {
        Workout selectedWorkout;
        UserManager manager;
        WorkoutManager workouts;
        public WorkoutDetailsWindow(Workout selectedWorkout, UserManager manager, WorkoutManager workouts)
        {
            InitializeComponent();
            this.selectedWorkout = selectedWorkout;
            this.manager = manager;
            this.workouts = workouts;
            // Fyll fälten med information från det valda träningspasset
            if (selectedWorkout is StrengthWorkout strengthWorkout)
            {
                //fyller fälten med strengthworkout info med hjälp av metod som finns i strengthworkout klass
                strengthWorkout.DisplayDetails(cmbWorkoutType, txtWorkoutDate, txtWorkoutDuration, txtNotes, txtRepetitions, txtSets);
                strengthFields.Visibility = Visibility.Visible;
                cardioFields.Visibility = Visibility.Collapsed;
            }
            else if (selectedWorkout is CardioWorkout cardioWorkout)
            {
                //fyller fält med cardioworkout info med hjälp av metod som finns i cardioworkout klass
                cardioWorkout.DisplayDetails(cmbWorkoutType, txtWorkoutDate, txtWorkoutDuration, txtNotes, txtCaloriesBurned);
                cardioFields.Visibility = Visibility.Visible;
                strengthFields.Visibility = Visibility.Collapsed;
            }

            // Gör alla fält skrivskyddade tills man trycker på Edit
            LockFields();
        }
        //Metod som gör alla txtboxar låsta
        private void LockFields()
        {
            cmbWorkoutType.IsEnabled = false;
            txtWorkoutDate.IsReadOnly = true;
            txtWorkoutDuration.IsReadOnly = true;
            txtNotes.IsReadOnly = true;
            txtCaloriesBurned.IsReadOnly = true;
            txtRepetitions.IsReadOnly = true;
            txtSets.IsReadOnly = true;
        }
        //Metod som låser upp alla txtboxar 
        private void UnlockFields()
        {
            cmbWorkoutType.IsEnabled = true;
            txtWorkoutDate.IsReadOnly = false;
            txtWorkoutDuration.IsReadOnly = false;
            txtNotes.IsReadOnly = false;
            txtCaloriesBurned.IsReadOnly = false;
            txtRepetitions.IsReadOnly = false;
            txtSets.IsReadOnly = false;
        }



        private void btnEditDetails(object sender, RoutedEventArgs e)
        {
            // Lås upp alla fält för redigering med min metod
            UnlockFields();
        }

        private void btnCancelDetails(object sender, RoutedEventArgs e)
        {
            // Gå tillbaka till WorkoutsWindow utan att spara några ändringar
            WorkoutsWindow workoutsWindow = new WorkoutsWindow(manager, workouts);
            workoutsWindow.Show();
            this.Close();
        }

        private void btnSaveDetails(object sender, RoutedEventArgs e)
        {
            // Uppdatera träningspassets information
            selectedWorkout.Date = txtWorkoutDate.Text;

            if (int.TryParse(txtWorkoutDuration.Text, out int duration))
            {
                selectedWorkout.Duration = duration;
            }
            else
            {
                MessageBox.Show("Please enter a valid duration.");
                return;
            }

            selectedWorkout.Notes = txtNotes.Text;

            if (selectedWorkout is CardioWorkout cardio)
            {
                if (int.TryParse(txtCaloriesBurned.Text, out int caloriesBurned))
                {
                    cardio.CaloriesBurned = caloriesBurned;
                }
                else
                {
                    MessageBox.Show("Please enter a valid value for calories burned.");
                    return;
                }
            }
            else if (selectedWorkout is StrengthWorkout strength)
            {
                if (int.TryParse(txtRepetitions.Text, out int repetition) && int.TryParse(txtSets.Text, out int sets))
                {
                    strength.Repetitions = repetition;
                    strength.Sets = sets;
                }
                else
                {
                    MessageBox.Show("Please enter valid values for repetitions and sets.");
                    return;
                }
            }

            MessageBox.Show("Workout details updated successfully!");

            // Gå tillbaka till WorkoutsWindow
            WorkoutsWindow workoutsWindow = new WorkoutsWindow(manager, workouts);
            workoutsWindow.Show();
            this.Close();
        }
    }
}
