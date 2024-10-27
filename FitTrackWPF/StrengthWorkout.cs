using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FitTrackWPF
{
    internal class StrengthWorkout : Workout
    {
        public int Repetitions { get; set; }
        public int Sets { get; set; }
        public string WorkoutType { get; }
        public string WorkoutDate { get; }
        public int Repetition { get; }

        public StrengthWorkout(string Type, string Date, int duration, int repetition, int sets, string notes) : base(Type, Date, duration, notes)
        {
            Repetition = repetition;
            Sets = sets;
        }

        public override void DisplayDetails()
        {
            MessageBox.Show($"Strength Workout Details:\nType: {Type}\nDate: {Date}\nDuration: {Duration} minutes\nRepetitions: {Repetitions}\nSets: {Sets}\nNotes: {Notes}");
        }
    }
}
