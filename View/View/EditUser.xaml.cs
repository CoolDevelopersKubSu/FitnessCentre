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

namespace View
{
    /// <summary>
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditUser : Page
    {
        private UserController controller = new UserController();
        private string card;
        public EditUser(UserModel user)
        {           
            InitializeComponent();           
            List<GenderModel> genders = controller.GetGenders();
            for (int i = 0; i < genders.Count; i++)
            {
                gender.Items.Add(genders[i].Name);
            }
            card = user.CardNumber;
            header.Text = "КАРТОЧКА КЛИЕНТА " + card;
            name.Text = user.Name;
            surname.Text = user.Surname;
            gender.Text = user.Gender.Name;
            birthday.Text = user.BirthDate.ToString("dd.MM.yyyy");
            weight.Text = user.Weight.ToString();
            height.Text = user.Height.ToString();
            date_exp.Text = user.ExpirationDate.ToString("dd.MM.yyyy");
            tariff_plan.Text = user.TariffPlan;
            trains.Text = user.ExpiredTrainings.ToString();
            trains_ind.Text = user.ExpiredIndividualTrainings.ToString();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CurrentUser(card));
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            GenderModel g = new GenderModel(gender.Text);
            UserModel user = new UserModel(
                name.Text,
                surname.Text,
                g,
                DateTime.Parse(birthday.Text),
                double.Parse(weight.Text),
                double.Parse(height.Text),
                card,
                DateTime.Parse(date_exp.Text),
                tariff_plan.Text,
                int.Parse(trains.Text),
                int.Parse(trains_ind.Text)
                );

            controller.UpdateUser(user);
            this.NavigationService.Navigate(new CurrentUser(card));
        }
    }
}
