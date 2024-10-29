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
            users.Add(new AdminUser("admin", "admin", "Sverige"));
            users.Add(new User("user", "user", "Sverige"));

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

