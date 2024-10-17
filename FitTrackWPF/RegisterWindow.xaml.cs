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
        public RegisterWindow()
        {
            InitializeComponent();

        }
        private void BtnCreate(object sender, RoutedEventArgs e)
        {

            string userName = txtBoxUsername.Text;
            string passWord = txtBoxPassword.Text;
            string country = CmbBoxCountry.SelectedItem as string;
            
            //kollar ifall textboxarna är ifyllda
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(passWord) || country == null)
            {
                MessageBox.Show("Fill in username and password and choose country!");
            }
            else
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }

           
        }
    }
}
