using CarService.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для CarClientPage.xaml
    /// </summary>
    public partial class CarClientPage : Page, INotifyPropertyChanged
    { 
        public event PropertyChangedEventHandler? PropertyChanged;
        public int CurrentCount { get; set; }
        public int TotalCount { get; set; }
        public ObservableCollection<CarClient> CarClients { get; private set; }
        public CarClientPage()
        {
            CarClients = new ObservableCollection<CarClient>(Session.Instance.Context.CarClients.Include(c => c.Client));
            CurrentCount = CarClients.Count;
            TotalCount = Session.Instance.Context.CarClients.Count();
            InitializeComponent();
        }
        private void notifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private IQueryable<CarClient> applyVinSearch(IQueryable<CarClient> query) =>
         query.Where(q => q.Vin.Contains(searchVinTextBox.Text) ||
        q.Marka.Contains(searchVinTextBox.Text) ||
        q.Model.Contains(searchVinTextBox.Text));
        private IQueryable<CarClient> applyFIOSearch(IQueryable<CarClient> query) =>
         query.Where(q => q.Client.Fio.Contains(searchFIOTextBox.Text));

        private void applyFilters()
        {
            IQueryable<CarClient> query = Session.Instance.Context.CarClients.AsQueryable();
            query = applyVinSearch(query);
            query = applyFIOSearch(query);

            CarClients.Clear();
            foreach (CarClient carclient in query.Take(25))
            {
                CarClients.Add(carclient);
            }
            CurrentCount = CarClients.Count;
            notifyPropertyChanged(nameof(CurrentCount));
            TotalCount = Session.Instance.Context.CarClients.Count();
            notifyPropertyChanged(nameof(TotalCount));
        }

        private void search(object sender, TextChangedEventArgs e)
        {
            applyFilters();
        }
        private void searchFIO(object sender, TextChangedEventArgs e)
        {
            applyFilters();
        }
        private void editCarClient(object sender, RoutedEventArgs e)
        {
            var carclient = (sender as Button)?.DataContext as CarClient;
            if (carclient == null) return;
            NavigationService.Navigate(new UpdateCarClientPage(carclient));
        }
        private void removeCarClient(object sender, RoutedEventArgs e)
        {
            var carclient = (sender as Button)?.DataContext as CarClient;
            if (carclient == null) return;

            bool hasClientService = Session.Instance.Context.ZakazNaryads.Any(cs => cs.CarClientId == carclient.CarClientId);

            if (hasClientService)
            {
                MessageBox.Show("Невозможно удалить автомобиль, по которому есть заказ", "Удаление невозможно",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var answer = MessageBox.Show("Вы уверены, что хотите удалить автомобиль?", "Подтверждение удаления",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (answer == MessageBoxResult.Yes)
            {
                try
                {
                    Session.Instance.Context.CarClients.Remove(carclient);
                    Session.Instance.Context.SaveChanges();
                    MessageBox.Show("Автомобиль удален.", "Удаление успешно",
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

        private void goToAddCarClientPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UpdateCarClientPage(new CarClient()));
        }

    }
}
