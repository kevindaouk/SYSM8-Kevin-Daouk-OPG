using System.Configuration;
using System.Data;
using System.Windows;

namespace FitTrackWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
   public partial class App : Application
    {
        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    base.OnStartup(e);

        //    UserManager manager = new UserManager();

        //    MainWindow window = new MainWindow(manager);
        //    window.Show();
        //}

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            WorkoutManager workouts = new WorkoutManager();
            UserManager manager = new UserManager(); // Skapa UserManager-instans
            MainWindow window = new MainWindow(manager, workouts); // Skapa MainWindow med UserManager
            window.Show(); // Visa MainWindow
        }
    }


}
