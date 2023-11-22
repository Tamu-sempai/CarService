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
    /// Логика взаимодействия для WorkPage.xaml
    /// </summary>
    public partial class WorkPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<Work> Works { get; private set; }
        public int CurrentCount { get; set; }
        public int TotalCount { get; set; }

        public WorkPage()
        {
            Works = new ObservableCollection<Work>(Session.Instance.Context.Works);
            CurrentCount = Works.Count;
            TotalCount = Works.Count;
            InitializeComponent();
        }
        private void notifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private IQueryable<Work> applySearch(IQueryable<Work> query) =>
         query.Where(q => q.Name.Contains(searchTextBox.Text));
        private void applyFilters()
        {
            IQueryable<Work> query = Session.Instance.Context.Works.AsQueryable();
            query = applySearch(query);

            Works.Clear();
            foreach (Work works in query.Take(100))
            {
                Works.Add(works);
            }
            CurrentCount = Works.Count;
            notifyPropertyChanged(nameof(CurrentCount));
            TotalCount = Session.Instance.Context.Works.Count();
            notifyPropertyChanged(nameof(TotalCount));
        }

        private void search(object sender, TextChangedEventArgs e)
        {
            applyFilters();
        }
        private void removeWork(object sender, RoutedEventArgs e)
        {
            var work = (sender as Button)?.DataContext as Work;
            if (work == null) return;

            bool hasClientService = Session.Instance.Context.WorkZakazNaryads.Any(cs => cs.WorkId == work.WorkId);

            if (hasClientService)
            {
                MessageBox.Show("Невозможно удалить услугу, по которой есть заказ", "Удаление невозможно",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var answer = MessageBox.Show("Вы уверены, что хотите удалить запись", "Подтверждение удаления",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (answer == MessageBoxResult.Yes)
            {
                try
                {
                    Session.Instance.Context.Works.Remove(work);
                    Session.Instance.Context.SaveChanges();
                    MessageBox.Show("Услуга удалена.", "Удаление успешно",
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
    }
}
