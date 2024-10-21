using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrackWPF
{
    internal class Workout
    {
        public string Type { get; set; }
        public string Date {  get; set; }
        public int Duration { get; set; }
        public int CaloriesBurned { get; set; }
        public string Notes { get; set; }


        public Workout(string type, string date, int duration, int caloriesburned, string notes)
        {
            Type = type;
            Date = date;
            Duration = duration;
            CaloriesBurned = caloriesburned;
            Notes = notes;
        }

        // En override för att visa informationen i ListBox
        public override string ToString()
        {
            return $"{Date} - {Type}";
        }
    }
}
