using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrackWPF
{
    public class WorkoutManager
    {
        //Lista för att lagra workouts
        private List<Workout> workouts;

        public WorkoutManager()
        {
            workouts = new List<Workout>();
        }

        //Lägg till ett träningspass i listan
        public void AddWorkout(Workout workout)
        {
            workouts.Add(workout);
        }

        public List<Workout> GetAllWorkouts()
        {
            return workouts;    
        }
    }
}
