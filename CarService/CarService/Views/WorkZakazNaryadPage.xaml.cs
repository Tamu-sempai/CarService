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
    /// Логика взаимодействия для WorkZakazNaryadPage.xaml
    /// </summary>
    public partial class WorkZakazNaryadPage : Page
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public int CurrentCount { get; set; }
        public int TotalCount { get; set; }
        public ZakazNaryad ZakazNaryad { get; set; }
        public List<ZakazNaryad> ZakazNaryads { get; set; }
        public ObservableCollection<WorkZakazNaryad> WorkZakazNaryads { get; private set; }
        public WorkZakazNaryadPage(ZakazNaryad zakazNaryad)
        {
            ZakazNaryad = zakazNaryad;
            ZakazNaryads = Session.Instance.Context.ZakazNaryads.ToList();
            WorkZakazNaryads = new ObservableCollection<WorkZakazNaryad>(Session.Instance.Context.WorkZakazNaryads.Include(c => c.Work));
            CurrentCount = WorkZakazNaryads.Count;
            TotalCount = WorkZakazNaryads.Count;
            applyFilters();
            InitializeComponent();
        }
        private void notifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private IQueryable<WorkZakazNaryad> applyWork(IQueryable<WorkZakazNaryad> query) =>
         query.Where(q => q.ZakazNaryadId == ZakazNaryad.ZakazNaryadId);
        private void applyFilters()
        {
            IQueryable<WorkZakazNaryad> query = Session.Instance.Context.WorkZakazNaryads.AsQueryable();
            query = applyWork(query);

            WorkZakazNaryads.Clear();
            foreach (WorkZakazNaryad zapchast in query.Take(100))
            {
                WorkZakazNaryads.Add(zapchast);
            }
            CurrentCount = WorkZakazNaryads.Count;
            notifyPropertyChanged(nameof(CurrentCount));
            TotalCount = CurrentCount;
            notifyPropertyChanged(nameof(TotalCount));
        }

        private void goBack(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ZakazNaryadPage());
        }
    }
}
