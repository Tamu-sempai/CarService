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
    /// Логика взаимодействия для AutoZapchastPage.xaml
    /// </summary>
    public partial class AutoZapchastPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public int CurrentCount { get; set; }
        public int TotalCount { get; set; }
        public Car Car { get; set; }
        public List<Car> Cars { get; set; }
        public ObservableCollection<CarZapchast> CarZapchasts { get; private set; }
        public AutoZapchastPage(Car car)
        {
            Car = car;
            Cars = Session.Instance.Context.Cars.ToList();
            CarZapchasts = new ObservableCollection<CarZapchast>(Session.Instance.Context.CarZapchasts.Include(c => c.Zapchat));
            CurrentCount = CarZapchasts.Count;
            TotalCount = CarZapchasts.Count;
            applyFilters();
            InitializeComponent();
        }
        private void notifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private IQueryable<CarZapchast> applyZapchast(IQueryable<CarZapchast> query) =>
         query.Where(q => q.CarId == Car.CarId);

        private IQueryable<CarZapchast> applyName(IQueryable<CarZapchast> query) =>
         query.Where(q => q.Zapchat.Name.Contains(searchZapchastTextBox.Text));
        private IQueryable<CarZapchast> applyTypeSearch(IQueryable<CarZapchast> query) =>
        sortingManufactureComboBox.SelectedIndex switch
        {
            1 => query.Where(q => q.Zapchat.Manufacturer == "ASParts"),
            2 => query.Where(q => q.Zapchat.Manufacturer == "ASSO"),
            3 => query.Where(q => q.Zapchat.Manufacturer == "BMW"),
            4 => query.Where(q => q.Zapchat.Manufacturer == "Bosch truck"),
            5 => query.Where(q => q.Zapchat.Manufacturer == "Eurorepar"),
            6 => query.Where(q => q.Zapchat.Manufacturer == "Ford"),
            7 => query.Where(q => q.Zapchat.Manufacturer == "GM"),
            8 => query.Where(q => q.Zapchat.Manufacturer == "Hans Pries"),
            9 => query.Where(q => q.Zapchat.Manufacturer == "Hyundai-Kia"),
            10 => query.Where(q => q.Zapchat.Manufacturer == "JP Group"),
            11 => query.Where(q => q.Zapchat.Manufacturer == "Mitsubishi"),
            12 => query.Where(q => q.Zapchat.Manufacturer == "Nissan"),
            13 => query.Where(q => q.Zapchat.Manufacturer == "SWAG"),
            14 => query.Where(q => q.Zapchat.Manufacturer == "Toyota"),
            15 => query.Where(q => q.Zapchat.Manufacturer == "VAG"),
            _ => query
        };
        private void applyFilters()
        {
            IQueryable<CarZapchast> query = Session.Instance.Context.CarZapchasts.AsQueryable();
            query = applyZapchast(query);

            CarZapchasts.Clear();
            foreach (CarZapchast carzapchast in query.Take(100))
            {
                CarZapchasts.Add(carzapchast);
            }
            CurrentCount = CarZapchasts.Count;
            notifyPropertyChanged(nameof(CurrentCount));
            TotalCount = CurrentCount;
            notifyPropertyChanged(nameof(TotalCount));
        }
        private void applyFiltersTwo()
        {
            IQueryable<CarZapchast> query = Session.Instance.Context.CarZapchasts.Where(c => c.CarId == Car.CarId).AsQueryable();
            query = applyName(query);
            query = applyTypeSearch(query);

            CarZapchasts.Clear();
            foreach (CarZapchast carzapchast in query.Take(40))
            {
                CarZapchasts.Add(carzapchast);
            }
            CurrentCount = CarZapchasts.Count;
            notifyPropertyChanged(nameof(CurrentCount));
            TotalCount = Session.Instance.Context.CarZapchasts.Count();
            notifyPropertyChanged(nameof(TotalCount));
        }
        private void searchZapchast(object sender, TextChangedEventArgs e)
        {
            applyFiltersTwo();
        }

        private void sortingManufacture(object sender, SelectionChangedEventArgs e)
        {
            applyFiltersTwo();
        }

        private void goBack(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SparePartsPage());
        }
    }
}
