using Assignment2.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
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
    public sealed partial class SelectPlayerPage : Page
    {
        Player player1 = new Player();
        public SelectPlayerPage()
        {
            this.InitializeComponent();
            fillPlayer1();
            fillPlayer2();
        }

        public void fillPlayer1()//Called when initialized
        {
            SqlConnection con = new SqlConnection(@"Data Source=127.0.0.1\SQLEXPRESS;Initial Catalog=Assignment2DB; Integrated Security=SSPI");

            //TODO: Display Player names form database to ComboBox

            //Display PlayerName from Database
            string selectionQuery = "SELECT PlayerName FROM GamePlayers";

            //Connect query and connection
            SqlCommand cmd = new SqlCommand(selectionQuery, con);

            // Get the information (SqlDataReader)
            SqlDataReader myreader;
            try
            {
                con.Open();//Open Connection

                // Get the information (SqlDataReader)
                myreader = cmd.ExecuteReader();

                //use while loop to keep reading Information
                while (myreader.Read())
                {
                    //store Player Names from database to string playerName
                    string playerName = myreader.GetString(0);
                    //add playerName to ComboBox2
                    ComboBoxPlayer1.Items.Add(playerName);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ex.Message");
            }
        }

        public void fillPlayer2()
        {
            //TODO: Display Player names form database to ComboBox

            SqlConnection con = new SqlConnection(@"Data Source=127.0.0.1\SQLEXPRESS;Initial Catalog=Assignment2DB; Integrated Security=SSPI");

            //Display PlayerName from Database
            string selectionQuery = "SELECT PlayerName FROM GamePlayers";

            //Connect query and connection
            SqlCommand cmd = new SqlCommand(selectionQuery, con);

            // Get the information (SqlDataReader)
            SqlDataReader myreader;
            try
           {
                con.Open();//Open Connection

                // Get the information (SqlDataReader)
                myreader = cmd.ExecuteReader();

                //use while loop to keep reading Information
                while (myreader.Read())
                  {
                    //store Player Names from database to string playerName
                    string playerName = myreader.GetString(0);
                    //add playerName to ComboBox2
                    ComboBoxPlayer2.Items.Add(playerName);
                  }
                 
               }
               catch (Exception ex)
               {
                   Debug.WriteLine("ex.Message");
               }
        }



        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            Name name = new Name();

            // Store the selected Value to playerName 
            name.playerName1 = ComboBoxPlayer1.SelectedValue.ToString();
            name.playerName2 = ComboBoxPlayer2.SelectedValue.ToString();

            //Navigate information to Game Emulator Page
            this.Frame.Navigate(typeof(GameEmulatorPage),name);
          
           
        }
    }
}
