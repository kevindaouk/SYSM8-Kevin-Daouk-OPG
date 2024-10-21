using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            MessageBox.Show($"Cardio Workout Details:\nType: {Type}\nDate: {Date}\nDuration: {Duration} minutes\nCalories Burned: {CaloriesBurned}\nNotes: {Notes}");
        }
    }
}
