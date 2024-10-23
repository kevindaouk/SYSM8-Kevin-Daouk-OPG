using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrackWPF
{
    public class UserManager
    {
        private static List<User> users;
        public UserManager()
        {
            users = new List<User>();
            users.Add(new User("admin", "admin", "Sverige"));
            users.Add(new User("user", "user", "Sverige"));
        }

        // Metod för att lägga till en ny användare
        public void AddUser(User newUser)
        {
            if (users.Any(u => u.Username == newUser.Username))
            {
                throw new InvalidOperationException("Username is already taken.");
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
    }
}

