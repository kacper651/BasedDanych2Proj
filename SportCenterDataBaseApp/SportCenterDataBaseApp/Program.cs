using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportCenterDataBaseApp
{
    internal static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=sport_center";

            var query = "SELECT * FROM  customer;";

            MySqlConnection con = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(query, con);

            try
            {
                con.Open();

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0));
                }
                else
                {
                    MessageBox.Show("Query Successful");
                }

            }catch (Exception ex)
            {
                MessageBox.Show("Query error" + ex.Message);
            }
        }
    }
}
