using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FitTrackWPF
{
    internal class AdminUser : User
    {
        public AdminUser(string username, string password, string country) : base(username, password, country)
        {
        }

        public override void SignIn()
        {
            MessageBox.Show("Login successfully!");
        }
    }
}
