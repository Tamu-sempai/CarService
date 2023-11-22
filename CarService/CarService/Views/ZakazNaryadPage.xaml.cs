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
    /// Логика взаимодействия для ZakazNaryadPage.xaml
    /// </summary>
    public partial class ZakazNaryadPage : Page, INotifyPropertyChanged
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
        public ObservableCollection<ZakazNaryad> ZakazNaryads { get; private set; }

        public ObservableCollection<ZapchastZakazNaryad> ZapchastZakazNaryads { get; private set; }
        public ObservableCollection<WorkZakazNaryad> WorkZakazNaryads { get; private set; }
        public ZakazNaryadPage()
        {
            ZakazNaryads = new ObservableCollection<ZakazNaryad>(Session.Instance.Context.ZakazNaryads.OrderBy(cs => cs.EndDate).Where(cs => cs.EndDate >= DateTime.Today).Include(z => z.Client).Include(z => z.CarClient));
            ZapchastZakazNaryads = new ObservableCollection<ZapchastZakazNaryad>(Session.Instance.Context.ZapchastZakazNaryads.Include(z => z.Zapchast));
            CurrentCount = ZakazNaryads.Count;
            TotalCount = Session.Instance.Context.ZakazNaryads.Count();
            InitializeComponent();
        }
        private void notifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void applyFilters()
        {
            IQueryable<ZakazNaryad> query = Session.Instance.Context.ZakazNaryads.AsQueryable();

            ZakazNaryads.Clear();
            foreach (ZakazNaryad zakazNaryad in query.Take(50))
            {
                ZakazNaryads.Add(zakazNaryad);
            }
            CurrentCount = ZakazNaryads.Count;
            notifyPropertyChanged(nameof(CurrentCount));
            TotalCount = Session.Instance.Context.ZakazNaryads.Count();
            notifyPropertyChanged(nameof(TotalCount));
        }
       private void zapchastMessage(object sender, RoutedEventArgs e)
        {
            var zapchast = (sender as Button)?.DataContext as ZakazNaryad;
            if (zapchast == null) return;
            NavigationService.Navigate(new ZapchastZakazNaryadPage(zapchast));
        }

        private void workMessage(object sender, RoutedEventArgs e)
        {
            var work = (sender as Button)?.DataContext as ZakazNaryad;
            if (work == null) return;
            NavigationService.Navigate(new WorkZakazNaryadPage(work));
        }

        private void goToAddZakazNaryadPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UpdateZakazNaryadPage(new ZakazNaryad()));

        }
    }
}
