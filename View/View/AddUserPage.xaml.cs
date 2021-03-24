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
        public AddUserPage()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            GenderModel g = new GenderModel(gender.Text);
            UserModel user = new UserModel(
                name.Text,
                surname.Text,
                g,
                DateTime.Parse(birthday.Text),
                int.Parse(weight.Text),
                int.Parse(height.Text),
                cardnumber.Text,
                DateTime.Parse(date_exp.Text),
                tariff_plan.Text,
                int.Parse(trains.Text),
                int.Parse(trains_ind.Text)
                );
            
            this.NavigationService.GoBack();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
