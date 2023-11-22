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
    /// Логика взаимодействия для SparePartsPage.xaml
    /// </summary>
    public partial class SparePartsPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private int currentCount;
        public int CurrentCount
        {
            get => currentCount;
            set
            {
                currentCount = value;
                notifyPropertyChanged("CurrentCount");
            }
        }
        private int totalCount;
        public int TotalCount
        {
            get => totalCount;
            set
            {
                totalCount = value;
                notifyPropertyChanged("TotalCount");
            }
        }
        public ObservableCollection<Car> Cars { get; private set; }
        public SparePartsPage()
        {
            Cars = new ObservableCollection<Car>(Session.Instance.Context.Cars.Include(z => z.CarZapchasts));
            CurrentCount = Cars.Count;
            TotalCount = CurrentCount;
            InitializeComponent();
        }
        private void notifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private IQueryable<Car> applyMarkaSearch(IQueryable<Car> query) =>
         query.Where(q => q.Marka.Contains(searchMarkaTextBox.Text));
        private IQueryable<Car> applyModelSearch(IQueryable<Car> query) =>
         query.Where(q => q.Model.Contains(searchModelTextBox.Text));
        private IQueryable<Car> applyTypeSearch(IQueryable<Car> query) =>
        sortingTypeComboBox.SelectedIndex switch
        {
            1 => query.Where(q => q.TypeEngine == "бензиновый"),
            2 => query.Where(q => q.TypeEngine == "дизельный"),
            _ => query
        };

        private void applyFilters()
        {
            IQueryable<Car> query = Session.Instance.Context.Cars.AsQueryable();
            query = applyMarkaSearch(query);
            query = applyModelSearch(query);
            query = applyTypeSearch(query);

            Cars.Clear();
            foreach (Car car in query.Take(100))
            {
                Cars.Add(car);
            }
            CurrentCount = Cars.Count;
            notifyPropertyChanged(nameof(CurrentCount));
            TotalCount = Session.Instance.Context.Cars.Count();
            notifyPropertyChanged(nameof(TotalCount));
        }
        private void searchMarka(object sender, TextChangedEventArgs e)
        {
            applyFilters();
        }
        private void searchModel(object sender, TextChangedEventArgs e)
        {
            applyFilters();
        }
        private void searchType(object sender, SelectionChangedEventArgs e)
        {
            applyFilters();
        }
        private void MyListView_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            var car = (sender as Button)?.DataContext as Car;
            if (car == null) return;
            NavigationService.Navigate(new AutoZapchastPage(car));
        }

    }
}
