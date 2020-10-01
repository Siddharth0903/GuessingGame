using Assignment2.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Assignment2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ScoreboardPage : Page
    {
        public ScoreboardPage()
        {
            this.InitializeComponent();
            this.InitializeComponent();

            PlayerDB dba = new PlayerDB();
           
            // Initialize the list item source to load the student information
            playersList.ItemsSource = dba.GetPlayers((App.Current as App).connectionString);
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)//Called on Start Game Button
        {
            //Navigate to SelectPlayerPage
            this.Frame.Navigate(typeof(SelectPlayerPage));
        }
    }
}
