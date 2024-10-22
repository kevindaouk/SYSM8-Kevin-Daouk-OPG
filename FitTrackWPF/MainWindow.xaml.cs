﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FitTrackWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        UserManager manager;

        public MainWindow(UserManager manager)
        {
            InitializeComponent();
            this.manager = manager; 

        }

        public MainWindow()
        {
            InitializeComponent();

        }

        private void BtnSignIn(object sender, RoutedEventArgs e)
        {
            
            //sparar inmatad username & password i variabler
            string enteredUsername = txtBoxUsername.Text;
            string enteredPassword = txtBoxPassword.Text;
            
            // Hämta användaren via UserManager
            User foundUser = manager.GetUser(enteredUsername);

            // Kontrollera om användaren finns och om lösenordet stämmer
            if (foundUser != null && foundUser.CheckPassword(enteredPassword))
            {
                MessageBox.Show("Login successful!");
                // Öppna WorkoutsWindow
                WorkoutsWindow workoutsWindow = new WorkoutsWindow(manager);
                workoutsWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect username or password.");
            }

            
        }

        private void BtnRegister(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow(manager);
            registerWindow.Show();
            this.Close();
        }
    }
}