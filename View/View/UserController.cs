using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace View
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
                data.Add(new string[12]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = reader[6].ToString();
                data[data.Count - 1][7] = reader[7].ToString();
                data[data.Count - 1][8] = reader[8].ToString();
                data[data.Count - 1][9] = reader[9].ToString();
                data[data.Count - 1][10] = reader[10].ToString();
                data[data.Count - 1][11] = reader[11].ToString();
            }
            reader.Close();
            connection.Close();
            return data;
        }

        //сделай нормальный список
        public static List<UserModel> Users()
        {
            MySqlConnection connection = DBController.GetConnection("127.0.0.1", "fitness_club", 3306, "root", "");
            string sql = DBController.GetRequest("select all");
            List<string[]> users = RunRequests(sql, connection);
            List<UserModel> listUsers = new List<UserModel>();
            for (int i = 0; i < users.Count; i++)
            {
                UserModel user = new UserModel(users[i]);
                listUsers.Add(user);
            }
            return listUsers;            
        }
    }
}
