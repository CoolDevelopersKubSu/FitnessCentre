using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class UserModel
    {

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Пол.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Вес.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Рост.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Возраст.
        /// </summary>
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        
        /// <summary>
        /// Номер абонемента.
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// Дата окончания срока действия абонемента.
        /// </summary>
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Тип абонемента.
        /// </summary>
        public string TariffPlan { get; set; }

        /// <summary>
        /// Входят ли в абонемент индивидуальные занятия с тренером.
        /// </summary>
        public bool WithIndividualTrainings { get; } = false;

        /// <summary>
        /// Количество оставшихся занятий.
        /// </summary>
        public int ExpiredTrainings { get; set; }

        /// <summary>
        /// Количество оставшихся индивидуальных занятий.
        /// </summary>
        public int ExpiredIndividualTrainings { get; set; }

        public UserModel(string[] data)
        {
            Name = data[1];
            Surname = data[2];
            Gender = data[3];
            BirthDate = DateTime.Parse(data[4]);
            Weight = double.Parse(data[5]);
            Height = double.Parse(data[6]);
            CardNumber = data[7];
            ExpirationDate = DateTime.Parse(data[8]);
            TariffPlan = data[9];
            ExpiredTrainings = int.Parse(data[10]);
            ExpiredIndividualTrainings = data[11] != "" ? int.Parse(data[11]) : 0;
        }
        
        public UserModel()
        {

        }
    }
}
