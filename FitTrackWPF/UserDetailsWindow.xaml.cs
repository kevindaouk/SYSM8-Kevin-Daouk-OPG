using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FitTrackWPF
{
    /// <summary>
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetailsWindow : Window
    {
        UserManager manager;
        WorkoutManager workouts;
        
        public UserDetailsWindow(UserManager manager, WorkoutManager workouts)
        {
            InitializeComponent();
            this.manager = manager;
            this.workouts = workouts;
            LoadCountries();
            txtBoxCurrentUsername.IsReadOnly = true;
            if (manager.CurrentUser != null && !string.IsNullOrEmpty(manager.CurrentUser.Country))
            {
                txtBoxCurrentUsername.Text = manager.CurrentUser.Username;
                CmbBoxCountry.SelectedItem = manager.CurrentUser.Country;
            }
           
            
        }

        private void LoadCountries()
        {
            // Hämta alla specifika kulturer från System.Globalization och skapa en lista över alla unika länder.
            var countries = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                                       .Select(culture => new RegionInfo(culture.Name).EnglishName)
                                       .Distinct()
                                       .OrderBy(name => name)
                                       .ToList();

            // Fyll ComboBox med listan av länder
            CmbBoxCountry.ItemsSource = countries;
        }

        private void btnSave(object sender, RoutedEventArgs e)
        {
            string newUsername = txtBoxNewUsername.Text;
            string newPassword = txtBoxNewPassword.Text;
            string confirmPassword = txtBoxConfirmPassword.Text;
            string newCountry = CmbBoxCountry.SelectedItem as string;

            if (newPassword  == confirmPassword)
            {
                manager.CurrentUser.UpdatePassword(newPassword);
                MessageBox.Show("Password changed successfully!");
            }
            else
            {
                MessageBox.Show("Password does not match, try again!");
            }
        }

        private void btnCancel(object sender, RoutedEventArgs e)
        {
            WorkoutsWindow workoutsWindow = new WorkoutsWindow(manager, workouts);
            workoutsWindow.Show();
            this.Close();
        }
    }
}
