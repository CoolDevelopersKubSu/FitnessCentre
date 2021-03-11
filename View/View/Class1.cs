using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MySql.Data.MySqlClient;


namespace FitnessCenter
{
    class DBController
    {
        /// <summary>
        /// Создать новый SQL-запрос по имющемуся списку параметров заданного типа.
        /// </summary>
        /// <param name="requestArgs"> Набор параметров запроса </param>
        /// <param name="requestType"> Тип запросы </param>
        /// <returns> Готовый SQL-запрос в виде строки. </returns>
        public static string GetRequest(string requestType, string[] requestArgs = null)
        {
            switch (requestType.ToLower())
            {
                case "select all":
                    return("SELECT * FROM clients");

                case "select name, surname, cardnumber":
                    return "SELECT Name, Surname, CardNumber FROM clients";

                case "insert":
                    return String.Format("INSERT INTO clients VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}'," +
                                         "'{6}', '{7}', '{8}', '{9}', '{10}', '{11}')", 
                                         requestArgs[0], requestArgs[1], requestArgs[2], requestArgs[3],
                                         requestArgs[4], requestArgs[5], requestArgs[6], requestArgs[7],
                                         requestArgs[8], requestArgs[9], requestArgs[10]);

;                case "update":
                    return String.Format("UPDATE clients " +
                                         "SET Name = '{0}'," +
                                         "    Surname = '{1}'," +
                                         "    Gender = '{2}'," +
                                         "    Weight = '{3}'," +
                                         "    Height = '{4}'," +
                                         "    ExpirationDate = '{5}'," +
                                         "    TariffPlan = '{6}'," +
                                         "    ExpiredTrainings = '{7}'," +
                                         "    ExpiredIndividualTrainings = '{8}'" +
                                         "WHERE ID_Client = '{9}')",
                                         requestArgs[0], requestArgs[1], requestArgs[2], requestArgs[3],
                                         requestArgs[4], requestArgs[5], requestArgs[6], requestArgs[7],
                                         requestArgs[8]);

                default:
                    return "not found";
            }
        }


        public static MySqlConnection GetConnection(string host, string database, int port, string username, string password)
        {
            string connectionString = $"Server={host};Database={database};port={port};User Id={username};password={password}";

            MySqlConnection connection = new MySqlConnection(connectionString);

            return connection;
        }
    }
}
