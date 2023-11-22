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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            ResizeMode = ResizeMode.NoResize;
            WindowState = WindowState.Maximized;
            InitializeComponent();
        }
        private void navigateToSpareParts(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new SparePartsPage());
        }

        private void navigateToClient(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new ClientPage());
        }

        private void navigateToCar(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new CarClientPage());
        }

        private void navigateToWorks(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new WorkPage());

        }

        private void navigateZakazNaryad(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new ZakazNaryadPage());
        }
    }
}
