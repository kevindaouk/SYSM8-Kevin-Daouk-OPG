using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FitTrackWPF
{
    public class UserManager
    {
        private static List<User> users;
        
        public User CurrentUser { get; set; } //håller koll på inloggad användare
        public UserManager()
        {
            users = new List<User>();
            User user1 = new User("user", "password", "Sweden");
            user1.workoutManager.AddWorkout(new StrengthWorkout("Strength", "20241030", 60, 20, 10, "Bra dag"));
            user1.workoutManager.AddWorkout(new CardioWorkout("Cardio", "20241029", 40, 400, "Svettigt pass"));
            users.Add(user1);
            //users.Add(new AdminUser("admin", "password", "Sweden"));
            User user2 = new User("admin", "password", "Sweden");
            users.Add(user2);
            
        }

        // Metod för att lägga till en ny användare
        public void AddUser(User newUser)
        {
            //Any() är en metod som går igenom listan users och kontrollerar om något objekt uppfyller villkoret.
            //kontrollerar om någon användare (u) har samma användarnamn (u.Username) som användarnamnet på den nya användaren (newUser.Username).
            if (users.Any(u => u.Username == newUser.Username))
            {
                MessageBox.Show("Username is already taken.");
                return;
            }
            users.Add(newUser);
        }

        // Metod för att hämta en användare baserat på användarnamn
        public User GetUser(string username)
        {
            return users.FirstOrDefault(u => u.Username == username);
        }

        // Metod för att kontrollera om en användare finns
        public bool UserExists(string username)
        {
            return users.Any(u => u.Username == username);
        }

        public bool SignIn(string username, string password)
        {
            User user = GetUser(username);
            if (user != null && user.CheckPassword(password))
            {
                CurrentUser = user;
                return true;
            }
            return false;
        }
    }
}

