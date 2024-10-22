using System;
using System.Collections.Generic;
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
using System.Globalization;

namespace FitTrackWPF
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private UserManager manager;
        public RegisterWindow(UserManager manager)
        {
            InitializeComponent();
            LoadCountries();
            this.manager = manager;

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
        private void BtnCreate(object sender, RoutedEventArgs e)
        {

            string userName = txtBoxUsername.Text;
            string passWord = txtBoxPassword.Text;
            string country = CmbBoxCountry.SelectedItem as string;

            //kollar ifall textboxarna är ifyllda
            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("Please fill in a username.");
            }
            else if (string.IsNullOrEmpty(passWord))
            {
                MessageBox.Show("Please fill in a password.");
            }
            else if (CmbBoxCountry.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a country.");
            }
            else
            {
                try
                {
                    User newUser = new User(userName, passWord, country);
                    manager.AddUser(newUser);
                    MessageBox.Show("User successfully created!");

                    MainWindow mainWindow = new MainWindow(manager);
                    mainWindow.Show();
                    this.Close();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        


    }
        //Ifall man vill avbryta registrering och gå tillbaka till första sidan.
        private void BtnCancel(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(manager);
            mainWindow.Show();
            this.Close();
        }
    }
}
