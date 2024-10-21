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
        public AddWorkoutWindow()
        {
            InitializeComponent();
        }

        private void btnSaveWorkout(object sender, RoutedEventArgs e)
        {
            string type = txtWorkoutType.Text;
            string date = txtWorkoutDate.Text;
            bool isDurationValid = int.TryParse(txtWorkoutDuration.Text, out int duration);
            bool isCaloriesValid = int.TryParse(txtCaloriesBurned.Text, out int calories);
            string notes = txtNotes.Text;

            if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(date) || !isDurationValid || !isCaloriesValid)
            {
                MessageBox.Show("Please fill in all information above, notes are voluntarily");
                
            }
            else
            {
                Workout = new Workout(type, date, duration, calories, notes);
                DialogResult = true; // Stänger fönstret och signalerar att träningen är skapad.
                this.Close();
            }
        }

        private void btnCancelWorkout(object sender, RoutedEventArgs e)
        {
            WorkoutsWindow workoutwindow = new WorkoutsWindow();
            workoutwindow.Show();
            this.Close();
        }
    }
}
