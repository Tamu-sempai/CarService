using CarService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для UpdateCarClientPage.xaml
    /// </summary>
    public partial class UpdateCarClientPage : Page
    {
        public CarClient CarClient { get; set; }
        public Client Client { get; set; }
        public List<Client> Clients { get; set; }
        public List<Car> Cars { get; set; }
        public List<CarClient> CarClients { get; set; }
        public string newFilename;
        public UpdateCarClientPage(CarClient carClient)
        {
            CarClient = carClient;
            Client = CarClient.Client;
            Clients = Session.Instance.Context.Clients.ToList();
            CarClients = Session.Instance.Context.CarClients.ToList();
            Cars = Session.Instance.Context.Cars.ToList();
            DataContext = this;
            InitializeComponent();
            if (CarClient.CarClientId == 0)
            {
                headerLabel.Content = "Добавление автомобиля";
                serviceDatePicker.DisplayDateEnd = DateTime.Today;
                serviceDatePicker.SelectedDate = DateTime.Today;
            }
            else
            {
                headerLabel.Content = "Изменение автомобиля";
                serviceDatePicker.DisplayDateEnd = DateTime.Today;
                serviceDatePicker.SelectedDate = CarClient.DateRegistration;
            }
        }
        private void saveChanges(object sender, RoutedEventArgs e)
        {
            if (vin.Text == "" || clientId.Text == "" || marka.Text == "" || model.Text == "" || typeEngine.Text == "" || yearRelese.Text == "" || run.Text == "" || stateNumber.Text == "" || color.Text == "" || serviceDatePicker.Text == "")
            {
                MessageBox.Show("Не все поля заполнены!!!");
            }
            else
            {
                int year = 0;
                if ((int.TryParse(yearRelese.Text, out year) == false))
                {
                    MessageBox.Show("Год выпуска должен быть настоящим!!!");
                }
                else
                {
                    if (year > DateTime.Now.Year)
                    {
                        MessageBox.Show("Год выпуска не может превышать настоящий!!!");
                    }
                    else
                    {
                        if (CarClient.CarClientId == 0)
                        {
                            if(applyFiltersVin() == false)
                            {
                                if (applyFilters() == true)
                                {
                                    var date = serviceDatePicker.SelectedDate.Value;
                                    var car_client = new CarClient
                                    {
                                        Vin = vin.Text,
                                        Client = this.Client,
                                        Marka = marka.Text,
                                        Model = model.Text,
                                        TypeEngine = typeEngine.Text,
                                        YearRelese = int.Parse(yearRelese.Text),
                                        Run = int.Parse(run.Text),
                                        StateNumber = stateNumber.Text,
                                        Color = color.Text,
                                        DateRegistration = date,
                                        imageCar = newFilename,
                                    };
                                    CarClient.Client = this.Client;
                                    if (CarClient.CarClientId == 0)
                                    {
                                        Session.Instance.Context.Add(car_client);
                                    }
                                    try
                                    {
                                        Session.Instance.Context.SaveChanges();
                                        MessageBox.Show("Данные сохранены.");
                                        NavigationService.Navigate(new CarClientPage());
                                    }
                                    catch
                                    {
                                        MessageBox.Show("При сохранении данных возникла ошибка!");
                                        if (CarClient.CarClientId == 0)
                                        {
                                            Session.Instance.Context.Remove(car_client);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Запчасти на данный автомобиль отсутствуют");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Этот автомобиль уже зарегистрирован");
                            }
                        }
                        else
                        {
                            if (applyFilters() == true)
                            {
                                var date = serviceDatePicker.SelectedDate.Value;
                                var car_client = new CarClient
                                {
                                    Vin = vin.Text,
                                    Client = this.Client,
                                    Marka = marka.Text,
                                    Model = model.Text,
                                    TypeEngine = typeEngine.Text,
                                    YearRelese = int.Parse(yearRelese.Text),
                                    Run = int.Parse(run.Text),
                                    StateNumber = stateNumber.Text,
                                    Color = color.Text,
                                    DateRegistration = date,
                                    imageCar = newFilename,
                                };
                                CarClient.Client = this.Client;
                                if (CarClient.CarClientId == 0)
                                {
                                    Session.Instance.Context.Add(car_client);
                                }
                                try
                                {
                                    Session.Instance.Context.SaveChanges();
                                    MessageBox.Show("Данные сохранены.");
                                    NavigationService.Navigate(new CarClientPage());
                                }
                                catch
                                {
                                    MessageBox.Show("При сохранении данных возникла ошибка!");
                                    if (CarClient.CarClientId == 0)
                                    {
                                        Session.Instance.Context.Remove(car_client);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Запчасти на данный автомобиль отсутствуют");
                            }
                        }
                            
                    }
                }
            }
        }
        private IQueryable<Car> applyCar(IQueryable<Car> query) =>
         query.Where(q => q.Marka.ToLower() == CarClient.Marka.ToLower() && q.Model.ToLower() == CarClient.Model.ToLower());
        private IQueryable<CarClient> applyVin(IQueryable<CarClient> query) =>
         query.Where(q => q.Vin.ToLower() == CarClient.Vin.ToLower());
        private bool applyFilters()
        {
            IQueryable<Car> query = Session.Instance.Context.Cars.AsQueryable();
            query = applyCar(query);
            int count = query.Count();
            if(count > 0)
            {
                return true;
            }
            return false;
        }
        private bool applyFiltersVin()
        {
            IQueryable<CarClient> query = Session.Instance.Context.CarClients.AsQueryable();
            query = applyVin(query);
            int count = query.Count();
            if (count > 0)
            {
                return true;
            }
            return false;
        }
        private void updateImage(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Jpg Images|*.jpg"
            };

            var result = dialog.ShowDialog();
            if (result != true)
            {
                return;
            }

            newFilename = Guid.NewGuid().ToString().Replace("-", "") + ".png";
            string pathToCopy = $"Assets/CarClientFoto/{newFilename}";

            try
            {
                File.Copy(dialog.FileName, pathToCopy);
                CarClient.imageCar = newFilename;
            }
            catch
            {
                MessageBox.Show("Ошибка при копировании файла!");
            }
        }
        private void goBack(object sender, RoutedEventArgs e)
        {
            if (CarClient.CarClientId != 0)
            {
                Session.Instance.Context.Entry(CarClient).Reload();
            }
            NavigationService.GoBack();
        }
    }
}
