using Assignment2.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    public sealed partial class GameEmulatorPage : Page
    {
        GuessingGame game = new GuessingGame();

        // A random generator that is used to generate the number to guess
        Random randomGuessP1 = new Random();
        Random randomGuessP2 = new Random();

        // GuessPlayer to store random generated values
        int guessPlayer1;
        int guessPlayer2;

        // round
        int round = 1;

        //Player Names to store in string format
        string pName1;
        string pName2;

        public GameEmulatorPage()
        {
            this.InitializeComponent();

            
        }

        // Called on Selecting Players
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //TODO: Convert Object Name to String received from SelectPlayerPage

             // Store the Object Name as var 
            var nameOfPlayers = e.Parameter as Name;

            //Convertinf values passed in  Name object into string format
            pName1 = nameOfPlayers.playerName1.ToString();
            pName2 = nameOfPlayers.playerName2.ToString();

            // Display Players name 
            txtPlayerName1.Text = nameOfPlayers.playerName1.ToString();
            txtPlayerName2.Text = nameOfPlayers.playerName2.ToString();
            TextBlockCorrectGuess.Text = "Guess: " + game.NumberToGuess();



        }

        private void Button_Click(object sender, RoutedEventArgs e) // Called on click of Start and Next Round Button
        {
            //generate random number between two ounds
            guessPlayer1 = randomGuessP1.Next(1, 11);
            guessPlayer2 = randomGuessP2.Next(1, 11);
            
            // Display Random numbers
            txtPlayerGuess1.Text = guessPlayer1.ToString();
            txtPlayerGuess2.Text = guessPlayer2.ToString();

            // Increment and display round
            TextBlockRound.Text = "Round: " + (round++);

            //Disable start button after game started
            btnStart.IsEnabled = false;

            if(guessPlayer1==guessPlayer2 && guessPlayer1==game.NumberToGuess()) //Players guess is same as winner guess then it is tie
            {
                try
                {
                    TextBlockWinnerName.Text = "Winner: " + pName1+ ", " +pName2;
                   //
                    //TODO: Increment TieCount for Player 1

                    SqlConnection conn = new SqlConnection(@"Data Source=127.0.0.1\SQLEXPRESS;Initial Catalog=Assignment2DB; Integrated Security=SSPI");

                    //update database  for Player 1
                    string getPlayersQuery = "UPDATE GamePlayers SET TieCount += 1 WHERE PlayerName = '" + pName1 + "' ";

                    conn.Open();

                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            // Set the command's text property
                            cmd.CommandText = getPlayersQuery;

                            // Get the information (SqlDataReader)
                            SqlDataReader reader = cmd.ExecuteReader();
                            Button_Scoreboard();
                            
                        }
                    }
                }
                catch (Exception) { }

                try
                {
                    //TODO: Increment TieCount for Player 2

                    SqlConnection conn = new SqlConnection(@"Data Source=127.0.0.1\SQLEXPRESS;Initial Catalog=Assignment2DB; Integrated Security=SSPI");

                    //Update database for Player 2
                    string getPlayersQuery = "UPDATE GamePlayers SET TieCount += 1 WHERE PlayerName = '" + pName2 + "' ";

                    conn.Open();

                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            // Set the command's text property
                            cmd.CommandText = getPlayersQuery;

                            // Get the information (SqlDataReader)
                            SqlDataReader reader = cmd.ExecuteReader();
                            Button_Scoreboard();
                            
                        }
                    }
                }
                catch (Exception) { }
            }
            else if (guessPlayer1 == game.NumberToGuess()) //If Player 1 is winner
            {
                //Print player 1 name on header
                TextBlockWinnerName.Text = "Winner: " + pName1;
                

                try
                {
                    // TODO: Increment WinCOunt for Player 1
                    SqlConnection conn = new SqlConnection(@"Data Source=127.0.0.1\SQLEXPRESS;Initial Catalog=Assignment2DB; Integrated Security=SSPI");

                    //Increment 1 in Wincount for player 1
                    string getPlayersQuery = "UPDATE GamePlayers SET WinCount += 1 WHERE PlayerName = '" + pName1 + "' ";

                    conn.Open();

                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            // Set the command's text property
                            cmd.CommandText = getPlayersQuery;

                            // Get the information (SqlDataReader)
                            SqlDataReader reader = cmd.ExecuteReader();
                            Button_Scoreboard();
                            
                        }
                    }
                }
                catch (Exception) { }

                try
                {
                    //TODO: Increment LossCount for Player 2
                    SqlConnection conn = new SqlConnection(@"Data Source=127.0.0.1\SQLEXPRESS;Initial Catalog=Assignment2DB; Integrated Security=SSPI");

                    //Increment 1 in LossCount for Player 2
                    string getPlayersQuery = "UPDATE GamePlayers SET LossCount += 1 WHERE PlayerName = '" + pName2 + "' ";

                    conn.Open();

                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            // Set the command's text property
                            cmd.CommandText = getPlayersQuery;

                            // Get the information (SqlDataReader)
                            SqlDataReader reader = cmd.ExecuteReader();
                            Button_Scoreboard();
                           
                           

                        }
                    }
                }
                catch (Exception) { }
            }
        
        

            else if (guessPlayer2 == game.NumberToGuess()) // If Player 2 is winner
            {
                //print Player 2 name
                TextBlockWinnerName.Text = "Winner: " + pName2;

                try
                {
                    //TODO: Increment LossCount for Player 2

                    SqlConnection conn = new SqlConnection(@"Data Source=127.0.0.1\SQLEXPRESS;Initial Catalog=Assignment2DB; Integrated Security=SSPI");

                    //Increment 1 in WinCount for Player 2
                    string getPlayersQuery = "UPDATE GamePlayers SET WinCount += 1 WHERE PlayerName = '" + pName2 + "' ";

                    conn.Open();

                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            // Set the command's text property
                            cmd.CommandText = getPlayersQuery;

                            // Get the information (SqlDataReader)
                            SqlDataReader reader = cmd.ExecuteReader();
                            Button_Scoreboard();
                            
                            // Use a while loop to keep reading the information

                        }
                    }
                }
                catch (Exception) { }

                try
                {
                    //TODO: Increment LossCount for Player 2
                    SqlConnection conn = new SqlConnection(@"Data Source=127.0.0.1\SQLEXPRESS;Initial Catalog=Assignment2DB; Integrated Security=SSPI");
                    //Increment 1 in LossCount for Player 1
                    string getPlayersQuery = "UPDATE GamePlayers SET LossCount += 1 WHERE PlayerName = '" + pName1 + "' ";

                    conn.Open();

                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            // Set the command's text property
                            cmd.CommandText = getPlayersQuery;

                            // Get the information (SqlDataReader)
                            SqlDataReader reader = cmd.ExecuteReader();
                            Button_Scoreboard();
                            
                            // Use a while loop to keep reading the information

                        }
                    }
                }
                catch (Exception) { }

             }

            
          

        }

        private void Button_Scoreboard()//Called when winner is declared
        {
            //On result next round button is diasbled
            btnNextRound.IsEnabled = false;
        }

        private void NavScoreboard(object sender, RoutedEventArgs e)//called on click of Scorecard button
        {
            //navigates to scoreboard Page
            this.Frame.Navigate(typeof(ScoreboardPage));
        }
    }
}
