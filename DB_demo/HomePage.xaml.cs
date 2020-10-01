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
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
            SetText();
        }

        private void HomeBtnNavViewSelectPlayer(object sender, RoutedEventArgs e)
        {
            //Load page in child Frame on ButtonClick
            this.Frame.Navigate(typeof(ScoreboardPage)); // TODO: Start Game with ScoreboardPage
        }
        private void HomeBtnNavViewScoreboard(object sender, RoutedEventArgs e)
        {
            //Load page in child Frame on ButtonClick
            this.Frame.Navigate(typeof(ScoreboardPage)); // TODO: ScoreboardPage
        }

        private void HomeBtnNavAddPlayer(object sender, RoutedEventArgs e)
        {
            //Load page in child Frame on ButtonClick
            this.Frame.Navigate(typeof(AddPlayerPage)); //TODO: AddPlayerPage
        }


        public void SetText()
        {
            // Input text in TextBoxIntro
            TextBoxInto.Text = "Hello All ! Welcome ! to Guessing Game \n";
        }
    }
}
