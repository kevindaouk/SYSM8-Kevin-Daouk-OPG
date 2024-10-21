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

        public StrengthWorkout(string type, string date, int duration, int repetitions, int sets, string notes) : base(type, date, duration, notes)
        {
            Repetitions = repetitions;
            Sets = sets;
        }

        public override void DisplayDetails()
        {
            MessageBox.Show($"Strength Workout Details:\nType: {Type}\nDate: {Date}\nDuration: {Duration} minutes\nRepetitions: {Repetitions}\nSets: {Sets}\nNotes: {Notes}");
        }
    }
}
