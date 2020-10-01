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
    public sealed partial class AddPlayerPage : Page
    {
       
        public AddPlayerPage()
        {
            this.InitializeComponent();
        }
        private void onclick(object sender, RoutedEventArgs e)
        {
            try
            {
                int stat = 0; //For the new Player win, loss and tie is zero
                int id = 1; // id starts from 1

                string insertQuery = "INSERT INTO GamePlayers(ID,PlayerName,WinCount,LossCount,TieCount) VALUES('" + ++id + "','" + txtAddPlayer.Text + "','" + stat + "','" + stat + "','" + stat + "')";
                // Connection to Database
                SqlConnection con = new SqlConnection(@"Data Source=127.0.0.1\SQLEXPRESS;Initial Catalog=Assignment2DB; Integrated Security=SSPI");

                con.Open(); // Open the connection

                //TODO: Insert provided name into database

                //Check if the state is open
                if (con.State == System.Data.ConnectionState.Open)
                {
                       //Set  query and connection in SqlCommand
                       SqlCommand cmd = new SqlCommand(insertQuery, con);
                        //Command executes Query
                       cmd.ExecuteNonQuery();
                    
                        con.Close();//Close the Connection
                    
                }

            }catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
            }



        }// end of onclick Method
    }
}
