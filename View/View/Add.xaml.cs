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
using Test;

namespace View
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : UserControl
    {
        public Add()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //List<object> data = new List<object>();
            //data.Add(name.Text);
            //data.Add(surname.Text);
            //data.Add(gender.Text);           
            //data.Add(DateTime.Parse(birthday.Text));
            //data.Add(double.Parse(weight.Text));
            //data.Add(double.Parse(height.Text));
            //data.Add(""); //card number
            //data.Add(DateTime.Parse(date_exp.Text));
            //data.Add(tariff_plan.Text);
            //data.Add(int.Parse(trains.Text));
            //int ind = trains_ind.Text != "" ? int.Parse(trains_ind.Text) : 0;
            //data.Add(ind);
            this.Visibility = Visibility.Hidden;
        }
    }
}
