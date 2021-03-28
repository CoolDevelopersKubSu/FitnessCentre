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
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private UserController controller = new UserController();

        public class columnName
        {
            public string name { get; set; }
            public string card { get; set; }
        }
        public void ShowUsers()
        {         
            List<UserModel> records = controller.Users();
            for (int i = 0; i < records.Count; i++)
            {
                allUsers_table.Items.Add(new columnName()
                {
                    name = records[i].Name + " " + records[i].Surname,
                    card = records[i].CardNumber,
                });
            }
        }
        public HomePage()
        {
            InitializeComponent();
            ShowUsers();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {           
            this.NavigationService.Navigate(new AddUserPage());
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

        private void allUsers_table_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }
        
        private void RowDoubleClick(object sender, RoutedEventArgs e)
        {
            var row = (DataGridRow)sender;          
            TextBlock card = allUsers_table.Columns[1].GetCellContent(row) as TextBlock;
            string cardNum = card.Text;                     
            this.NavigationService.Navigate(new CurrentUser(cardNum));
        }
    }
}
