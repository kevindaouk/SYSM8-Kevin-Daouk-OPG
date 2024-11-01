﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for WorkoutsWindow.xaml
    /// </summary>
    public partial class WorkoutsWindow : Window
    {
        public UserManager manager;
        public WorkoutManager workouts;
       
        public WorkoutsWindow(UserManager manager, WorkoutManager workouts)
        {
            InitializeComponent();
            this.manager = manager;
            this.workouts = workouts;

            // Få WorkoutManager från den inloggade användaren
            if (manager.CurrentUser != null)
            {
                //KAN LÄGGAS IN EN WORKOUT manager.currentuser.workout.add
                this.workouts = manager.CurrentUser.workoutManager;
                //Sätter vem som är nuvarande inloggad användare samt låser txtboxen.
                txtCurrentInlog.Text = manager.CurrentUser.Username;
                txtCurrentInlog.IsReadOnly = true;
            }
            else
            {
                this.workouts = workouts ?? new WorkoutManager();
            }

            DataContext = workouts;
           
         }

        private void btnAddWorkout(object sender, RoutedEventArgs e)
        {
            //går vidare till addworkout window för att lägga till träningspass
            AddWorkoutWindow workoutwindow = new AddWorkoutWindow(manager, workouts);
            workoutwindow.Show();
            this.Close();

        }

        private void btnInfo(object sender, RoutedEventArgs e)
        {
            //informations ruta om appen
            MessageBox.Show("Our goal is to help you reach your personal goals in training. Click on \"Add Workout\" to add workouts." +
                " If you would like to remove a workout that you didn't do, simply mark the workout and click \"Remove Workout.\"");
        }

        private void btnSignOut(object sender, RoutedEventArgs e)
        {
            //Nollställer curentuser till null vid utloggning
            manager.CurrentUser = null;
            MainWindow mainWindow = new MainWindow(manager, workouts);
            mainWindow.Show();
            this.Close();
        }

        private void btnRemoveWorkout(object sender, RoutedEventArgs e)
        {
            // Ta bort det träningspass som användaren eller admin har valt
            if (lstWorkouts.SelectedItem is Workout selectedWorkout)
            {
                // Om det är admin som är inloggad, ta bort träningspasset från WorkoutManager
                if (manager.CurrentUser is AdminUser)
                {
                    
                    workouts.WorkoutsCollection.Remove(selectedWorkout);
                    MessageBox.Show("Workout successfully removed by admin!");
                }
                else
                {
                    // Om det är en vanlig användare, ta bort träningspasset från deras WorkoutManager
                    manager.CurrentUser.workoutManager.RemoveWorkout(selectedWorkout);
                    MessageBox.Show("Workout successfully removed!");
                }
            }
            else
            {
                MessageBox.Show("Please select a workout to remove.");
            }

        }

        private void btnDetails(object sender, RoutedEventArgs e)
        {
            //Om något träningspass är markerat så går den in i if satsen
            if (lstWorkouts.SelectedItem is Workout selectedWorkout)
            {
                WorkoutDetailsWindow detailsWindow = new WorkoutDetailsWindow(selectedWorkout, manager, workouts);
                detailsWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a workout to view details.");
            }

        }

        private void btnUserDetails(object sender, RoutedEventArgs e)
        {
            //går in och visar information om inloggad användare
            UserDetailsWindow userdetailsWindow = new UserDetailsWindow(manager, workouts);
            userdetailsWindow.Show();
            this.Close();
        }
    
    }
}
