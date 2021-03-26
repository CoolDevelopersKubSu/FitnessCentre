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
       private DBController newRequest;


        public UserController(string user = "root", string password = "")
        {
            newRequest = new DBController("127.0.0.1", "fitness_club", 3306, user, password);
        }

        /// <summary>
        /// Возвращает всех пользователя
        /// </summary>
        /// <returns></returns>
        public List<UserModel> Users()
        {
            return newRequest.Users;
        }

        public void AddNewUser(UserModel user)
        {
            newRequest.AddNewUser(user);
        }

        public void DeleteUser(string userCardNumber)
        {
            newRequest.DeleteUser(userCardNumber);
        }

        public void UpdateUser(UserModel user)
        {
            newRequest.UpdateUser(user);
        }

        public UserModel GetUserByCardNumber(string userCardNumber)
        {
            return newRequest.GetUserByCardNumber(userCardNumber);            
        }

        public List<GenderModel> GetGenders()
        {
            return newRequest.Genders;
        }
    }
}
