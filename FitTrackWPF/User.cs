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

        public User(string username, string password, string country) : base(username, password)
        {
            Country = country;
        }


        public override void SignIn()
        {
            MessageBox.Show("Successfully login");
        }
    }
}
