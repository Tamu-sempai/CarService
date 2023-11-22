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

namespace CarService.Views
{
    /// <summary>
    /// Логика взаимодействия для UpdateZapchastZakazNaryadPage.xaml
    /// </summary>
    public partial class UpdateZapchastZakazNaryadPage : Page
    { 
        public Work Work { get; set; }
        public List<Work> Works { get; set; }
        public List<Work> Wokers { get; set; } = new List<Work>();
        public ZakazNaryad ZakazNaryad { get; set; }
        public double Prices;
        public UpdateZapchastZakazNaryadPage(ZakazNaryad zakazNaryad)
        {
            ZakazNaryad = zakazNaryad;
            Works = Session.Instance.Context.Works.ToList();
            InitializeComponent();
        }

        private void next(object sender, RoutedEventArgs e)
        {
            if (Wokers.Count == 0)
            {
                MessageBox.Show("Ничего не выбрано!!!");
            }
            else
            {
                foreach (var item in Wokers)
                {
                    
                    var zakaz_naryad = new WorkZakazNaryad
                    {
                        ZakazNaryad = this.ZakazNaryad,
                        Work = item,
                    };
                    Session.Instance.Context.Add(zakaz_naryad);
                    try
                    {
                        Session.Instance.Context.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("При сохранении данных возникла ошибка!");
                        Session.Instance.Context.Remove(zakaz_naryad);
                        return;
                    }
                }
                MessageBox.Show("Данные сохранены!!!");
                NavigationService.Navigate(new UpdateWorkZakazNaryadPage(ZakazNaryad, Prices));

            }
        }

        private void checkedWork(object sender, RoutedEventArgs e)
        {
            var zapchast = (sender as CheckBox)?.DataContext as Work;
            if (zapchast == null) return;
            Wokers.Add(zapchast);
            Prices += zapchast.Price;
        }
    }
}
