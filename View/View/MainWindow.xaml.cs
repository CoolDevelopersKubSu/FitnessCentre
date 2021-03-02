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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            frame.Visibility = Visibility.Visible;
            allUsers.Visibility = Visibility.Hidden;
            allUsers.IsEnabled = false;
            add.Visibility = Visibility.Hidden;
            add.IsEnabled = false;
            back.Visibility = Visibility.Visible;
            frame.Navigate(new Add());
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {          
            frame.Visibility = Visibility.Hidden;
            allUsers.Visibility = Visibility.Visible;
            allUsers.IsEnabled = true;
            add.Visibility = Visibility.Visible;
            add.IsEnabled = true;
            back.Visibility = Visibility.Hidden;          
        }

        private void add_MouseEnter(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            add.Foreground = (Brush)bc.ConvertFrom("#222831");
        }

        private void add_MouseLeave(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            add.Foreground = (Brush)bc.ConvertFrom("#FFEEEEEE");
            add.Background = (Brush)bc.ConvertFrom("#222831");
        }

        private void back_MouseEnter(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            add.Foreground = (Brush)bc.ConvertFrom("#222831");
        }

        private void back_MouseLeave(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            add.Foreground = (Brush)bc.ConvertFrom("#FFEEEEEE");
            add.Background = (Brush)bc.ConvertFrom("#222831");
        }
    }
}
