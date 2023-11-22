using CarService.Models;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
    /// Логика взаимодействия для UpdateZakazNaryadPage.xaml
    /// </summary>
    public partial class UpdateZakazNaryadPage : Page
    {
        public CarClient CarClient { get; set; }
        public Client Client { get; set; }
        public ZakazNaryad ZakazNaryad { get; set; }
        public List<Client> Clients { get; set; }
        public List<CarClient> CarClients { get; set; }
        public List<ZakazNaryad> ZakazNaryads { get; set; }

        public string newFilename;
        public UpdateZakazNaryadPage(ZakazNaryad zakazNaryad)
        {
            ZakazNaryad = zakazNaryad;
            Clients = Session.Instance.Context.Clients.ToList();
            CarClients = Session.Instance.Context.CarClients.ToList();
            ZakazNaryads = Session.Instance.Context.ZakazNaryads.ToList();
            InitializeComponent();
            serviceDatePicker.DisplayDateStart = DateTime.Today;
            serviceDatePicker.SelectedDate = DateTime.Today;
        }
        private void next(object sender, RoutedEventArgs e)
        {
            if (client.SelectedIndex == -1 || auto.SelectedIndex == -1 )
            {
                MessageBox.Show("Не все поля заполнены!!!");
            }
            else
            {
                if (Client.ClientId != CarClient.ClientId)
                {
                    MessageBox.Show("Выбранный автомобиль не является собственностью клиента!!!");
                }
                else
                {
                    if(applyFilters() == true)
                    {
                        var date = serviceDatePicker.SelectedDate.Value;
                        var zakaz_naryad = new ZakazNaryad
                        {
                            Client = this.Client,
                            CarClient = this.CarClient,
                            WorkZakazNaryadId = 1,
                            ZapchastZakazNaryadId = 1,
                            TotalCoast = 1,
                            EndDate = date,
                            StartDate = DateTime.Now,
                        };
                        if (ZakazNaryad.ZakazNaryadId == 0)
                        {
                            Session.Instance.Context.Add(zakaz_naryad);
                        }
                        try
                        {
                            Session.Instance.Context.SaveChanges();
                            MessageBox.Show("Данные сохранены.");
                            NavigationService.Navigate(new UpdateZapchastZakazNaryadPage(zakaz_naryad));
                        }
                        catch
                        {
                            MessageBox.Show("При сохранении данных возникла ошибка!");
                            if (ZakazNaryad.ZakazNaryadId == 0)
                            {
                                Session.Instance.Context.Remove(zakaz_naryad);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Такой заказ уже существует");
                    }
                }
            }
        }
        private IQueryable<ZakazNaryad> applyCar(IQueryable<ZakazNaryad> query) =>
         query.Where(q => q.ClientId == Client.ClientId && q.CarClientId == CarClient.CarClientId && q.EndDate >= DateTime.Now);
        private bool applyFilters()
        {
            IQueryable<ZakazNaryad> query = Session.Instance.Context.ZakazNaryads.AsQueryable();
            query = applyCar(query);
            int count = query.Count();
            if (count > 0)
            {
                return false;
            }
            return true;
        }


        private void goBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        /*private IQueryable<CarClient> applyCarClient(IQueryable<CarClient> query) =>
         query.Where(q => q.ClientId == Client.ClientId);
        private void clientComboBox(object sender, SelectionChangedEventArgs e)
        {
            if (Client == null) return;
            fillComboBoxCar();
        }
        private void fillComboBoxCar()
        {
            IQueryable<CarClient> query = Session.Instance.Context.CarClients.AsQueryable();
            query = applyCarClient(query);
            int count = query.Count();
            if (count == 0 && CarClients.Count > 0)
            {
                CarClients.Clear();
            }
            else
            {
                if (CarClients.Count > 0)
                {
                    CarClients.Clear();
                }
                
                foreach (var item in query)
                {
                    CarClients.Add(item);
                }
            }
            
        }*/
    }
}
