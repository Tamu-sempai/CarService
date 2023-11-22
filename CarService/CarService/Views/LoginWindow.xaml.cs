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
using System.Windows.Shapes;

namespace CarService.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        private void login(object sender, RoutedEventArgs e)
        {
            var login = "admin";
            var pin = "0000";
            if(Login.Text == "" || PIN.Password == "")
            {
                MessageBox.Show("Не все поля заполнены!", "Вход не выполнен", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                if (Login.Text != login || PIN.Password != pin)
                {
                    MessageBox.Show("Не верный Логин или PIN-код!", "Вход не выполнен", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                else
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Close();
                }
            }
            
        }
    }
}
