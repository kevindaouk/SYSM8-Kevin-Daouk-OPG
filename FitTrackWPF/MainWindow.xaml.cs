using System.Text;
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
        WorkoutManager workouts;
        
        

        public MainWindow(UserManager manager, WorkoutManager workouts)
        {
            InitializeComponent();
            this.manager = manager; 
            this.workouts = workouts;

        }

        public MainWindow()
        {
            InitializeComponent();
            if (manager == null)
            {
                manager = new UserManager();
            }
            if (workouts == null)
            {
                workouts = new WorkoutManager();
            }

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
                // Sätta den inloggade användaren som CurrentUser
                manager.CurrentUser = foundUser;
                MessageBox.Show("Login successful!");
                // Öppna WorkoutsWindow
                WorkoutsWindow workoutsWindow = new WorkoutsWindow(manager, manager.CurrentUser.WorkoutManager);
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