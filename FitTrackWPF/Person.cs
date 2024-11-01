using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrackWPF
{
    public abstract class Person
    {

        public string Username { get; set; }
        private string Password;

       public Person(string username, string password)
        {
            Username = username;
            Password = password;
        }
        //Metod som säkerställer att det är rätt lösenord
        public bool CheckPassword(string password)
        {
            return Password == password;
        }


        public abstract void SignIn();
        //metod som uppdaterar lösenord 
        public void UpdatePassword(string newPassword)
        {
            Password = newPassword;
        }
        //metod som uppdaterar användarnamn
        public void UpdateUsername(string username)
        {
            Username = username;
        }
    }
}
