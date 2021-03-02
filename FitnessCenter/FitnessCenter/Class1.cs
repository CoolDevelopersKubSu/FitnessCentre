using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FitnessCenter
{
    class DBController
    {
        public DBController()
        {

        }


        /// <summary>
        /// Создать новый SQL-запрос по имющемуся списку параметров заданного типа.
        /// </summary>
        /// <param name="requestArgs"> Набор параметров запроса </param>
        /// <param name="requestType"> Тип запросы </param>
        /// <returns> Готовый SQL-запрос в виде строки. </returns>
        public string DBGetRequest(string[] requestArgs, string requestType)
        {
            switch (requestType.ToLower())
            {
                case "select all":
                    return("SELECT * FROM table");

                case "select":
                    return String.Format("SELECT * FROM table WHERE id = '{0}'", requestType[0]);

                case "insert":
                    return String.Format("INSERT INTO table VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}'," +
                                         "'{6}', '{7}', '{8}', '{9}', '{10}', '{11}')", 
                                         requestArgs[0], requestArgs[1], requestArgs[2], requestArgs[3],
                                         requestArgs[4], requestArgs[5], requestArgs[6], requestArgs[7],
                                         requestArgs[8], requestArgs[9], requestArgs[10]);

;                case "update":
                    return String.Format("UPDATE table " +
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
    }
}
