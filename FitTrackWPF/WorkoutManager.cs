using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrackWPF
{
    public class WorkoutManager
    {
        //Lista för att lagra workouts
        public ObservableCollection<Workout> WorkoutsCollection { get; set; }

        public WorkoutManager()
        {
            WorkoutsCollection = new ObservableCollection<Workout>();
            
        }

        //Lägg till ett träningspass i listan
        public void AddWorkout(Workout workout)
        {
            WorkoutsCollection.Add(workout);
        }

        // Ta bort ett träningspass 
        public void RemoveWorkout(Workout workout)
        {
            WorkoutsCollection.Remove(workout);
        }



    }
}
