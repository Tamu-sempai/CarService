using CarService.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace CarService.Views
{
    /// <summary>
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private int currentCount;
        public int CurrentCount {
            get => currentCount;
            set
            {
                currentCount = value;
                notifyPropertyChanged("CurrentCount");
            }
        }
        private int totalCount;
        public int TotalCount {
            get => totalCount;
            set
            {
                totalCount = value;
                notifyPropertyChanged("TotalCount");
            }
        }
        public ObservableCollection<Client> Clients { get; private set; }
        public ClientPage()
        {
            Clients = new ObservableCollection<Client>(Session.Instance.Context.Clients);
            CurrentCount = Clients.Count;
            TotalCount = Session.Instance.Context.Clients.Count();
            InitializeComponent();
        }
        private void notifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void goToAddClientPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UpdateClientPage(new Client()));
        }

        private IQueryable<Client> applySearch(IQueryable<Client> query) =>
         query.Where(q => q.Fio.Contains(searchTextBox.Text));


        private void applyFilters()
        {
            IQueryable<Client> query = Session.Instance.Context.Clients.AsQueryable();
            query = applySearch(query);

            Clients.Clear();
            foreach (Client client in query.Take(50))
            {
                Clients.Add(client);
            }
            CurrentCount = Clients.Count;
            notifyPropertyChanged(nameof(CurrentCount));
            TotalCount = Session.Instance.Context.Clients.Count();
            notifyPropertyChanged(nameof(TotalCount));
        }

        private void search(object sender, TextChangedEventArgs e)
        {
            applyFilters();
        }

        private void removeClient(object sender, RoutedEventArgs e)
        {
            var client = (sender as Button)?.DataContext as Client;
            if (client == null) return;

            bool hasClientService = Session.Instance.Context.ZakazNaryads.Any(cs => cs.ClientId == client.ClientId);

            if (hasClientService)
            {
                MessageBox.Show("Невозможно удалить клиента, по которому есть заказ", "Удаление невозможно",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var answer = MessageBox.Show("Вы уверены, что хотите удалить клиента?", "Подтверждение удаления",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (answer == MessageBoxResult.Yes)
            {
                try
                {
                    Session.Instance.Context.Clients.Remove(client);
                    Session.Instance.Context.SaveChanges();
                    MessageBox.Show("Клиент удалён.", "Удаление успешно",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                    applyFilters();
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка при удалении!", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void editClient(object sender, RoutedEventArgs e)
        {
            var client = (sender as Button)?.DataContext as Client;
            if (client == null) return;
            NavigationService.Navigate(new UpdateClientPage(client));
        }
    }
}
