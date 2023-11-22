using CarService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для UpdateWorkZakazNaryadPage.xaml
    /// </summary>
    public partial class UpdateWorkZakazNaryadPage : Page
    {
        public Zapchast Zapchast { get; set; }
        public List<Zapchast> Zapchasts { get; set; } = new List<Zapchast>();
        public List<CarZapchast> CarZapchasts { get; set; }
        public CarClient CarClient { get; set; }
        public List<Car> Cars { get; set; }
        public List<Zapchast> zapchasts { get; set; }
        public List<Zapchast> Wokers { get; set; } = new List<Zapchast>();
        public ZakazNaryad ZakazNaryad { get; set; }

        public double Prices;
        public UpdateWorkZakazNaryadPage(ZakazNaryad zakazNaryad, double price)
        {
            Prices = price;
            ZakazNaryad = zakazNaryad;
            CarClient = zakazNaryad.CarClient;
            Cars = Session.Instance.Context.Cars.Where(q => q.Marka == CarClient.Marka && q.Model == CarClient.Model && q.TypeEngine.ToLower() == CarClient.TypeEngine.ToLower()).ToList();
            foreach (var c in Cars)
            {
                CarZapchasts = Session.Instance.Context.CarZapchasts.Where(q => q.CarId == c.CarId).ToList();
            }
            foreach (var zapts in CarZapchasts) 
            {
                zapchasts = Session.Instance.Context.Zapchasts.Where(q => q.ZapchastId == zapts.ZapchatId).ToList();
                foreach(var zapt in zapchasts)
                {
                    Zapchasts.Add(zapt);
                }
            }
            InitializeComponent();
        }
        private void save(object sender, RoutedEventArgs e)
        {
            if (Wokers.Count == 0)
            {
                MessageBox.Show("Ничего не выбрано!!!");
            }
            else
            {
                foreach (var item in Wokers)
                {

                    var zapchat_zakaz_naryad = new ZapchastZakazNaryad
                    {
                        ZakazNaryad = this.ZakazNaryad,
                        Zapchast = item,
                    };
                    Session.Instance.Context.Add(zapchat_zakaz_naryad);
                    try
                    {
                        ZakazNaryad.TotalCoast = Prices;
                        Session.Instance.Context.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("При сохранении данных возникла ошибка!");
                        Session.Instance.Context.Remove(zapchat_zakaz_naryad);
                        return;
                    }
                }
                
                MessageBox.Show("Данные сохранены!!!");
                NavigationService.Navigate(new ZakazNaryadPage());
            }
        }
        private void checkedWork(object sender, RoutedEventArgs e)
        {
            var works = (sender as CheckBox)?.DataContext as Zapchast;
            if (works == null) return;
            Wokers.Add(works);
            Prices += works.Price;
        }
    }
}
