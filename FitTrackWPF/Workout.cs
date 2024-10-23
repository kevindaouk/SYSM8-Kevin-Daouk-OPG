using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrackWPF
{
    public abstract class Workout
    {
        public string Type { get; set; }
        public string Date { get; set; }
        public int Duration { get; set; } // Varaktighet i minuter
        public string Notes { get; set; }

        public Workout(string type, string date, int duration, string notes)
        {
            Type = type;
            Date = date;
            Duration = duration;
            Notes = notes;
        }

        public abstract void DisplayDetails();

    }
}
