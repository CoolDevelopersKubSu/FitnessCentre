using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;

namespace View
{
    class UserController
    {
        /// <summary>
        /// Возвращает всех пользователя
        /// </summary>
        /// <returns></returns>
        public static List<UserModel> Users()
        {
            DBController newRequest = new DBController("127.0.0.1", "fitness_club", 3306, "root", "");
            return newRequest.Users;
        }

        public static void AddNewUser(UserModel user)
        {
            DBController newRequest = new DBController("127.0.0.1", "fitness_club", 3306, "root", "");
            newRequest.AddNewUser(user);
        }

        public static void DeleteUser(string userCardNumber)
        {
            DBController newRequest = new DBController("127.0.0.1", "fitness_club", 3306, "root", "");
            newRequest.DeleteUser(userCardNumber);
        }

        public static void UpdateUser(UserModel user)
        {
            DBController newRequest = new DBController("127.0.0.1", "fitness_club", 3306, "root", "");
            newRequest.UpdateUser(user);
        }

        public static UserModel GetUserByCardNumber(string userCardNumber)
        {
            DBController newRequest = new DBController("127.0.0.1", "fitness_club", 3306, "root", "");
            return newRequest.GetUserByCardNumber(userCardNumber);            
        }

        public static List<GenderModel> GetGenders()
        {
            DBController newRequest = new DBController("127.0.0.1", "fitness_club", 3306, "root", "");
            return newRequest.Genders;
        }
    }
}
