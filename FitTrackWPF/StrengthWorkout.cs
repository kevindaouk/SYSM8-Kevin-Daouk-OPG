using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FitTrackWPF
{
    internal class StrengthWorkout : Workout
    {
        public int Repetitions { get; set; }
        public int Sets { get; set; }
        public string WorkoutType { get; }
        public string WorkoutDate { get; }
        
        public StrengthWorkout(string Type, string Date, int duration, int repetitions, int sets, string notes) : base(Type, Date, duration, notes)
        {
            Repetitions = repetitions;
            Sets = sets;
        }
        public override void DisplayDetails()
        {
           
        }

        public void DisplayDetails(
            ComboBox cmbWorkoutType,
            TextBox txtWorkoutDate,
            TextBox txtWorkoutDuration,
            TextBox txtNotes,
            TextBox txtRepetition,
            TextBox txtSets)
        {
            cmbWorkoutType.SelectedItem = cmbWorkoutType.Items.OfType<ComboBoxItem>().FirstOrDefault(item => (string)item.Content == "Strength");
            txtWorkoutDate.Text = Date;
            txtWorkoutDuration.Text = Duration.ToString();
            txtNotes.Text = Notes;
            txtRepetition.Text = Repetitions.ToString();
            txtSets.Text = Sets.ToString();
        }
    }
}
