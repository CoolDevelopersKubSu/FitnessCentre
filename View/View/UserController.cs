using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace FitnessCenter
{


    class UserController
    {
        protected static List<string[]> RunRequests(string sql, MySqlConnection connection)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[9]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
            }
            reader.Close();
            connection.Close();
            return data;
        }

        public static List<string[]> Users()
        {
            MySqlConnection connection = DBController.GetConnection("127.0.0.1", "fitness_center_bd", 3306, "root", "");
            string sql = DBController.GetRequest("select Name, Surname, CardNumber");
            List<string[]> users = RunRequests(sql, connection);
            return users;
        }
    }
}
