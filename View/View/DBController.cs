using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using View;
using MySql.Data.MySqlClient;


namespace View
{
    public class DBController
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

        /// <summary>
        /// Строка подключения к базе
        /// </summary>
        string connectionString;

        /// <summary>
        /// Список кортежей, где первый элемент кортежа - индекс строки в базе
        /// </summary>
        private List<(int, UserModel)> data;

        /// <summary>
        /// Список гендеров
        /// </summary>
        public List<GenderModel> Genders { get; private set; }

        /// <summary>
        /// Список клиентов
        /// </summary>
        public List<UserModel> Users { get; private set; }

        /// <summary>
        /// Обновляет списки гендеров и клиентов
        /// </summary>
        private void GetUsersData()
        {
            List<GenderModel> genders = new List<GenderModel>();
            List<UserModel> users = new List<UserModel>();
            data = new List<(int, UserModel)>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                
                MySqlCommand select_genders = new MySqlCommand("SELECT gender FROM clients", connection);

                using (MySqlDataReader gender_reader = select_genders.ExecuteReader())
                {
                    while (gender_reader.Read())
                    {
                        GenderModel gender = new GenderModel(gender_reader.GetString(0));
                        genders.Add(gender);
                    }
                }
                foreach (GenderModel gender in genders)
                {
                    MySqlCommand select_users = new MySqlCommand("SELECT * FROM clients WHERE gender = @gender", connection);
                    MySqlParameter genderParam = new MySqlParameter("@gender", gender.Name);
                    select_users.Parameters.Add(genderParam);

                    using (MySqlDataReader user_reader = select_users.ExecuteReader())
                    {
                        while (user_reader.Read())
                        {
                            int id = user_reader.GetInt32(0);
                            string name = user_reader.GetString(1);
                            string surname = user_reader.GetString(2);
                            DateTime birthdate = user_reader.GetDateTime(4);
                            double weight = user_reader.GetDouble(5);
                            double height = user_reader.GetDouble(6);
                            string cardNumber = user_reader.GetString(7);
                            DateTime expirationDate = user_reader.GetDateTime(8);
                            string tariffPlan = user_reader.GetString(9);
                            int expiredTrainings = user_reader.GetInt32(10);
                            int expiredIndividualTrainings = user_reader.GetInt32(11);

                            data.Add((id, new UserModel(name, surname, gender, birthdate, weight, height, cardNumber, expirationDate, tariffPlan, expiredTrainings, expiredIndividualTrainings)));
                        }
                    }
                }
            }
            data.ForEach(x => users.Add(x.Item2));
            Users = users;
            Genders = genders;
        }

        /// <summary>
        /// Добавляет нового клиента в базу
        /// </summary>
        public void AddNewUser(UserModel user)
        {
            string sqlExpression = "INSERT INTO clients (name, surname, gender, birthdate, weight, height, cardNumber, expirationDate, tariffPlan, expiredTrainings, expiredIndividualTrainings) " +
                "VALUES (@name, @surname, @gender, @birthdate, @weight, @height, @cardNumber, @expirationDate, @tariffPlan, @expiredTrainings, @expiredIndividualTrainings)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(sqlExpression, connection);

                MySqlParameter nameParam = new MySqlParameter("@name", user.Name);
                command.Parameters.Add(nameParam);

                MySqlParameter surnameParam = new MySqlParameter("@surname", user.Surname);
                command.Parameters.Add(surnameParam);

                MySqlParameter genderParam = new MySqlParameter("@gender", user.Gender.Name);
                command.Parameters.Add(genderParam);

                MySqlParameter birthdateParam = new MySqlParameter("@birthdate", user.BirthDate);
                command.Parameters.Add(birthdateParam);

                MySqlParameter weightParam = new MySqlParameter("@weight", user.Weight);
                command.Parameters.Add(weightParam);

                MySqlParameter heightParam = new MySqlParameter("@height", user.Height);
                command.Parameters.Add(heightParam);

                MySqlParameter cardNumberParam = new MySqlParameter("@cardNumber", user.CardNumber);
                command.Parameters.Add(cardNumberParam);

                MySqlParameter expirationDateParam = new MySqlParameter("@expirationDate", user.ExpirationDate);
                command.Parameters.Add(expirationDateParam);

                MySqlParameter tariffPlanParam = new MySqlParameter("@tariffPlan", user.TariffPlan);
                command.Parameters.Add(tariffPlanParam);

                MySqlParameter expiredTrainingsParam = new MySqlParameter("@expiredTrainings", user.ExpiredTrainings);
                command.Parameters.Add(expiredTrainingsParam);

                MySqlParameter expiredIndividualTrainingsParam = new MySqlParameter("@expiredIndividualTrainings", user.ExpiredIndividualTrainings);
                command.Parameters.Add(expiredIndividualTrainingsParam);

                command.ExecuteNonQuery();
            };
            GetUsersData();
        }

        /// <summary>
        /// Обновляет информацию о клиенте в базе
        /// </summary>
        public void Update(UserModel user)
        {
            int id = data.Find(x => x.Item2 == user).Item1;
            string sqlExpression = "UPDATE clients " +
                "SET name = @name, " +
                "SET surname = @surname, " +
                "SET gender = @gender, " +
                "SET birthdate = @birthdate, " +
                "SET weight = @weight, " +
                "SET height = @height, " +
                "SET cardNumber = @cardNumber, " +
                "SET expirationDate = @expirationDate, " +
                "SET tariffPlan = @tariffPlan, " +
                "SET withIndividualTrainings = @withIndividualTrainings, " +
                "SET expiredTrainings = @expiredTrainings, " +
                "SET expiredIndividualTrainings = @expiredIndividualTrainings " +
                "WHERE id_client = @id";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(sqlExpression, connection);

                MySqlParameter idParam = new MySqlParameter("@id", id);
                command.Parameters.Add(idParam);

                MySqlParameter nameParam = new MySqlParameter("@name", user.Name);
                command.Parameters.Add(nameParam);

                MySqlParameter surnameParam = new MySqlParameter("@surname", user.Surname);
                command.Parameters.Add(surnameParam);

                MySqlParameter genderParam = new MySqlParameter("@gender", user.Gender.Name);
                command.Parameters.Add(genderParam);

                MySqlParameter birthdateParam = new MySqlParameter("@birthdate", user.BirthDate);
                command.Parameters.Add(birthdateParam);

                MySqlParameter weightParam = new MySqlParameter("@weight", user.Weight);
                command.Parameters.Add(weightParam);

                MySqlParameter heightParam = new MySqlParameter("@height", user.Height);
                command.Parameters.Add(heightParam);

                MySqlParameter cardNumberParam = new MySqlParameter("@cardNumber", user.CardNumber);
                command.Parameters.Add(cardNumberParam);

                MySqlParameter expirationDateParam = new MySqlParameter("@expirationDate", user.ExpirationDate);
                command.Parameters.Add(expirationDateParam);

                MySqlParameter tariffPlanParam = new MySqlParameter("@tariffPlan", user.TariffPlan);
                command.Parameters.Add(tariffPlanParam);

                MySqlParameter withIndividualTrainingsParam = new MySqlParameter("@withIndividualTrainings", user.WithIndividualTrainings);
                command.Parameters.Add(withIndividualTrainingsParam);

                MySqlParameter expiredTrainingsParam = new MySqlParameter("@expiredTrainings", user.ExpiredTrainings);
                command.Parameters.Add(expiredTrainingsParam);

                MySqlParameter expiredIndividualTrainingsParam = new MySqlParameter("@expiredIndividualTrainings", user.ExpiredIndividualTrainings);
                command.Parameters.Add(expiredIndividualTrainingsParam);

                command.ExecuteNonQuery();
            }
            GetUsersData();
        }

        /// <summary>
        /// Удаляет клиента из базы
        /// </summary>
        public void DeleteUser(UserModel user)
        {
            int id = data.Find(x => x.Item2 == user).Item1;
            string sqlExpression = "UPDATE FROM clients WHERE id_client = @id";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(sqlExpression, connection);

                MySqlParameter idParam = new MySqlParameter("@id", id);
                command.Parameters.Add(idParam);

                command.ExecuteNonQuery();
            }
            GetUsersData();
        }

        public DBController(string host, string database, int port, string username, string password)
        {
            connectionString = $"Server={host};Database={database};port={port};User Id={username};password={password}";
            GetUsersData();
        }
    }
}
