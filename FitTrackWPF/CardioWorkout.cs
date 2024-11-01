using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FitTrackWPF
{
    internal class CardioWorkout : Workout
    {
        public int CaloriesBurned { get; set; }


        public CardioWorkout(string type, string date, int duration, int caloriesburned, string notes) : base(type, date, duration, notes)
        {
            CaloriesBurned = caloriesburned;
        }

        public override void DisplayDetails()
        {
           
        }
        // Metod för att visa detaljer om ett träningspass i användargränssnittet
        public void DisplayDetails(
        ComboBox cmbWorkoutType,
        TextBox txtWorkoutDate,
        TextBox txtWorkoutDuration,
        TextBox txtNotes,
        TextBox txtCaloriesBurned)
        {
            cmbWorkoutType.SelectedItem = cmbWorkoutType.Items.OfType<ComboBoxItem>().FirstOrDefault(item => (string)item.Content == "Cardio");
            txtWorkoutDate.Text = Date;
            txtWorkoutDuration.Text = Duration.ToString();
            txtNotes.Text = Notes;
            txtCaloriesBurned.Text = CaloriesBurned.ToString();
        }
    }
}
