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
    /// Логика взаимодействия для ZapchastPage.xaml
    /// </summary>
    public partial class ZapchastPage : Page
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public int CurrentCount { get; set; }
        public int TotalCount { get; set; }
        public ZakazNaryad ZakazNaryad { get; set; }
        public List<ZakazNaryad> ZakazNaryads { get; set; }
        public ObservableCollection<ZapchastZakazNaryad> ZapchastZakazNaryads { get; private set; }
        public ZapchastPage(ZakazNaryad zakazNaryad)
        {
            ZakazNaryad = zakazNaryad;
            ZakazNaryads = Session.Instance.Context.ZakazNaryads.ToList();
            ZapchastZakazNaryads = new ObservableCollection<ZapchastZakazNaryad>(Session.Instance.Context.ZapchastZakazNaryads.Include(c => c.Zapchast));
            CurrentCount = ZapchastZakazNaryads.Count;
            TotalCount = ZapchastZakazNaryads.Count;
            InitializeComponent();
        }
        private void notifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private IQueryable<ZapchastZakazNaryad> applyWork(IQueryable<ZapchastZakazNaryad> query) =>
         query.Where(q => q.ZakazNaryadId == ZakazNaryad.ZakazNaryadId);
        private void applyFilters()
        {
            IQueryable<ZapchastZakazNaryad> query = Session.Instance.Context.ZapchastZakazNaryads.AsQueryable();
            query = applyWork(query);

            ZapchastZakazNaryads.Clear();
            foreach (ZapchastZakazNaryad zapchast in query.Take(100))
            {
                ZapchastZakazNaryads.Add(zapchast);
            }
            CurrentCount = ZapchastZakazNaryads.Count;
            notifyPropertyChanged(nameof(CurrentCount));
            TotalCount = CurrentCount;
            notifyPropertyChanged(nameof(TotalCount));
        }
    }
}
