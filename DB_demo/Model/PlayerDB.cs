using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Model
{
    class PlayerDB
    {
        public ObservableCollection<Player> GetPlayers(string connectionString)
        {
            string getPlayersQuery = "SELECT ID, PlayerName, WinCount, LossCount, TieCount from GamePlayers ORDER BY WinCount DESC";

            var Players = new ObservableCollection<Player>();
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=127.0.0.1\SQLEXPRESS;Initial Catalog=Assignment2DB; Integrated Security=SSPI");
                

                    conn.Open(); // Open the connection

                    // TODO: Read the data from the database    

                    // Check if the state is open
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            // Set the command's text property
                            cmd.CommandText = getPlayersQuery;

                            // Get the information (SqlDataReader)
                            SqlDataReader reader = cmd.ExecuteReader();

                            // Use a while loop to keep reading the information
                            while (reader.Read())
                            {

                                Player Player = new Player();

                            // Modify the properties of the object       
                            Player.id = reader.GetInt32(0);
                            Player.name = reader.GetString(1);
                            
                                Player.wins = reader.GetInt32(2);
                                Player.losses = reader.GetInt32(3);
                                Player.ties = reader.GetInt32(4);

                                // Add the modified object to the collection
                                Players.Add(Player);
                            }

                        }
                    }
                

                return Players;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }

            return null;

        }// End of GetPlayers method
    }
}
