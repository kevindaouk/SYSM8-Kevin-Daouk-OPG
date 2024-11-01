using System.Collections.ObjectModel;
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
            // Kontrollera och skapa instanser om manager eller workouts är null för att säkerställa att de alltid är giltiga objekt
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
            // sparar inmatad username & password i variabler
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

                // Kontrollera om det är admin som loggar in
                if (foundUser is AdminUser)
                {
                    // Samla alla träningspass från alla användare
                    ObservableCollection<Workout> allWorkouts = new ObservableCollection<Workout>();

                    // Lägg till alla användares träningspass i allWorkouts
                    foreach (var user in manager.GetAllUsers())
                    {
                        foreach (var workout in user.workoutManager.WorkoutsCollection)
                        {
                            allWorkouts.Add(workout);
                        }
                    }

                    // Öppna WorkoutsWindow för admin och visa alla träningspass
                    WorkoutsWindow workoutsWindow = new WorkoutsWindow(manager, new WorkoutManager { WorkoutsCollection = allWorkouts });
                    workoutsWindow.Show();
                }
                else
                {
                    // Öppna WorkoutsWindow för vanlig användare
                    WorkoutsWindow workoutsWindow = new WorkoutsWindow(manager, manager.CurrentUser.workoutManager);
                    workoutsWindow.Show();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect username or password.");
            }


        }
        //går in i registreringsrutan och stänger mainwindow
        private void BtnRegister(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow(manager);
            registerWindow.Show();
            this.Close();
        }
    }
}