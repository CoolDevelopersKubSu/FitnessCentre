using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FitnessCenter;
using Test;

namespace View
{
    /// <summary>
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        public AddUserPage()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            UserModel user = new UserModel();
            user.Name = name.Text;
            user.Surname = surname.Text;
            user.Gender = gender.Text;
            user.BirthDate = DateTime.Parse(birthday.Text);
            user.Weight = int.Parse(weight.Text);
            user.Height = int.Parse(height.Text);
            user.ExpirationDate = DateTime.Parse(date_exp.Text);
            user.TariffPlan = tariff_plan.Text;
            user.ExpiredTrainings = int.Parse(trains.Text);
            user.ExpiredIndividualTrainings = int.Parse(trains_ind.Text);
            this.NavigationService.GoBack();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
