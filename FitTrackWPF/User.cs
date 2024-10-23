using System;
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
        public WorkoutManager WorkoutManager { get; private set; }
        

        public User(string username, string password, string country) : base(username, password)
        {
            Country = country;
            // Initiera WorkoutManager för användaren
            WorkoutManager = new WorkoutManager();
        }


        public override void SignIn()
        {
            MessageBox.Show("Successfully login");
        }
    }
}
