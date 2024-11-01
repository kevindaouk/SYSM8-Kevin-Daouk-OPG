﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FitTrackWPF
{
    public class User : Person
    {
        public string Country { get; set; }
        // Använd WorkoutManager för att hantera träningspass
        public WorkoutManager workoutManager { get; private set; }
        
        public List<Workout> Workouts { get;  set; }

        public User(string username, string password, string country) : base(username, password)
        {
            Country = country;
            // Initiera WorkoutManager för användaren
            workoutManager = new WorkoutManager();
        }


        public override void SignIn()
        {
            MessageBox.Show("Successfully login");
        }
        
        
    }
}
