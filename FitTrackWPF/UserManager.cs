using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrackWPF
{
    class UserManager
    {
        //public UserManager()
        //{
        //    users = new List<User>();
        //    users.Add(new User("kevin", "kevin", "Sverige"));
        //    users.Add(new User("richard", "richard", "Sverige"));
        //}

        // Lista som sparar alla användare
        private static List<User> users = new List<User>();

        // Metod för att lägga till en ny användare
        public static void AddUser(User newUser)
        {
            if (users.Any(u => u.Username == newUser.Username))
            {
                throw new InvalidOperationException("Username is already taken.");
            }
            users.Add(newUser);
        }

        // Metod för att hämta en användare baserat på användarnamn
        public static User GetUser(string username)
        {
            return users.FirstOrDefault(u => u.Username == username);
        }

        // Metod för att kontrollera om en användare finns
        public static bool UserExists(string username)
        {
            return users.Any(u => u.Username == username);
        }
    }
}

