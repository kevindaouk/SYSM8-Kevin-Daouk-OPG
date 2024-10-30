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
                //Sätter textbox användarnamn och cmbboxcountry till dens nuvarande värde
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
            // Hämta inmatade värden från fälten
            string newUsername = txtBoxNewUsername.Text;
            string newPassword = txtBoxNewPassword.Text;
            string confirmPassword = txtBoxConfirmPassword.Text;
            string newCountry = CmbBoxCountry.SelectedItem as string;

            bool updated = false; // Håller koll på om något faktiskt har ändrats

            // Validering och uppdatering av användarnamn
            if (!string.IsNullOrEmpty(newUsername) && newUsername != manager.CurrentUser.Username)
            {
                if (newUsername.Length >= 3)
                {
                    //metod som kollar ifall användarnamnet är upptaget
                    if (!manager.UserExists(newUsername))
                    {
                        manager.CurrentUser.Username = newUsername;
                        updated = true;
                    }
                    else
                    {
                        MessageBox.Show("Username is already taken.");
                        return; // Avbryt om användarnamnet är upptaget
                    }
                }
                else
                {
                    MessageBox.Show("Username must be at least 3 characters long.");
                    return; // Avbryt om användarnamnet är för kort
                }
            }

            // Validering och uppdatering av lösenord
            if (!string.IsNullOrEmpty(newPassword))
            {
                //kollar ifall lösenordet matchar och att det är minst 5 tecken
                if (newPassword == confirmPassword && newPassword.Length >= 5)
                {
                    manager.CurrentUser.UpdatePassword(newPassword);
                    updated = true;
                }
                else if (newPassword.Length < 5)
                {
                    MessageBox.Show("Password must contain at least 5 characters.");
                    return; // Avbryt om lösenordet är för kort
                }
                else
                {
                    MessageBox.Show("Passwords do not match, please try again!");
                    return; // Avbryt om lösenorden inte stämmer överens
                }
            }

            // Uppdatering av land
            if (!string.IsNullOrEmpty(newCountry) && newCountry != manager.CurrentUser.Country)
            {
                manager.CurrentUser.Country = newCountry;
                updated = true;
            }

            // Om något faktiskt ändrades, visa ett meddelande
            if (updated)
            {
                MessageBox.Show("Account details updated successfully.");
            }
            else
            {
                MessageBox.Show("No changes were made.");
            }

            // Stäng fönstret och återgå till WorkoutsWindow
            WorkoutsWindow workoutsWindow = new WorkoutsWindow(manager, manager.CurrentUser.workoutManager);
            workoutsWindow.Show();
            this.Close();

        }

        private void btnCancel(object sender, RoutedEventArgs e)
        {
            WorkoutsWindow workoutsWindow = new WorkoutsWindow(manager, workouts);
            workoutsWindow.Show();
            this.Close();
        }
    }
}
