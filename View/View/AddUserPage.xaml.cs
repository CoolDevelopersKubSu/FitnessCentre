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
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        public DataGrid tableUser { get; set; }
        public AddUserPage()
        {
            InitializeComponent();
            List<GenderModel> genders = UserController.GetGenders();
            for (int i = 0; i < genders.Count; i++)
            {
                gender.Items.Add(genders[i].Name);
            }
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
                cardnumber.Text,
                DateTime.Parse(date_exp.Text),
                tariff_plan.Text,
                int.Parse(trains.Text),
                int.Parse(trains_ind.Text)
                );

            UserController.AddNewUser(user);              
            this.NavigationService.Navigate(new HomePage());          
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new HomePage());
        }
    }
}
