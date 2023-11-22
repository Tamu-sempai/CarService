using CarService.Models;
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
using System.Text.RegularExpressions;

namespace CarService.Views
{
    /// <summary>
    /// Логика взаимодействия для UpdateClientPage.xaml
    /// </summary>
    public partial class UpdateClientPage : Page
    {
        public Client Client { get; set; }
        public List<Client> Clients { get; set; }
        public UpdateClientPage(Client client)
        {
            Client = client;
            Clients = Session.Instance.Context.Clients.ToList();
            InitializeComponent();
            if (Client.ClientId == 0)
            {
                headerLabel.Content = "Добавление клиента";
            }
            else
            {
                headerLabel.Content = "Изменение клиента";
                Session.Instance
                .Context
                .Clients
                .Entry(Client);
                txtPlaceholderEmail.Foreground = new SolidColorBrush(Colors.PaleTurquoise);
                txtPlaceholderNumber.Foreground = new SolidColorBrush(Colors.PaleTurquoise);
            }
        }

        private void goBack(object sender, RoutedEventArgs e)
        {
            if (Client.ClientId != 0)
            {
                Session.Instance.Context.Entry(Client).Reload();
            }
            NavigationService.GoBack();
        }
        private void number_TextChanged(Object sender, TextChangedEventArgs e)
        {
            if (Client.ClientId == 0)
            {
                if (number.Text != "")
                {
                    txtPlaceholderNumber.Visibility = Visibility.Hidden;
                }
                else
                {
                    txtPlaceholderNumber.Visibility = Visibility.Visible;
                }
            }
            else
            {
                return;
            }
            
        }
        private void email_TextChanged(Object sender, TextChangedEventArgs e)
        {
            if (Client.ClientId == 0)
            {
                if (email.Text != "")
                {
                    txtPlaceholderEmail.Visibility = Visibility.Hidden;
                }
                else
                {
                    txtPlaceholderEmail.Visibility = Visibility.Visible;
                }
            }
            else
            {
                return;
            }
        }

        private void saveChanges(object sender, RoutedEventArgs e)
        {
            if (fio.Text == "" || city.Text == "" || address.Text == "" || number.Text == "" || email.Text == "")
            {
                MessageBox.Show("Не все поля заполнены!!!");
            }
            else
            {
                string patternNumber = @"\+7\d{10}"; 
                string patternEmail = @"[a-zA-Z0-9._]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]+";

                if (Regex.IsMatch(number.ToString(), patternNumber, RegexOptions.IgnoreCase) && Regex.IsMatch(email.ToString(), patternEmail, RegexOptions.IgnoreCase))
                {
                    if (Client.ClientId == 0)
                    {
                        Session.Instance.Context.Add(Client);
                    }
                    try
                    {
                        Session.Instance.Context.SaveChanges();
                        MessageBox.Show("Данные сохранены.");
                        NavigationService.Navigate(new ClientPage());

                    }
                    catch
                    {
                        MessageBox.Show("При сохранении данных возникла ошибка!");
                        if (Client.ClientId == 0)
                        {
                            Session.Instance.Context.Remove(Client);
                        }
                    }
                }
                else
                {
                    
                    MessageBox.Show("Не верно введён формат данных!");
                }
            }
        }
    }
}
