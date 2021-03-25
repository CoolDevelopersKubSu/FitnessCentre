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
using View;

namespace View
{
    /// <summary>
    /// Логика взаимодействия для CurrentUser.xaml
    /// </summary>
    public partial class CurrentUser : Page
    {
        private UserModel user;
        public CurrentUser(string cardNumber)
        {         
            InitializeComponent();
            header.Text = "КАРТОЧКА КЛИЕНТА " + cardNumber;
            user = UserController.GetUserByCardNumber(cardNumber);
            name.Content = user.Name;
            surname.Content = user.Surname;
            gender.Content = user.Gender.Name;
            birthday.Content = user.BirthDate.ToString("dd.MM.yyyy");
            weight.Content = user.Weight;
            height.Content = user.Height;
            date_exp.Content = user.ExpirationDate.ToString("dd.MM.yyyy");
            tariff_plan.Content = user.TariffPlan;
            trains.Content = user.ExpiredTrainings;
            trains_ind.Content = user.ExpiredIndividualTrainings;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new HomePage());
        }

        private void change_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new EditUser(user));

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите удалить клиента?", "",  MessageBoxButton.YesNo,
            MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                UserController.DeleteUser(user.CardNumber);
                this.NavigationService.Navigate(new HomePage());
            }
        }
    }
}
