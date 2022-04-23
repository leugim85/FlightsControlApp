using Business.Entities;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DepartureFlights.App
{
    /// <summary>
    /// Interaction logic for List.xaml
    /// </summary>
    public partial class List : Page
    {       
        public List()
        {            
            InitializeComponent();
            Refresh();            
        }

        private void Refresh()
        {
            var fligths = MainWindow._service.GetFligths();

            fligthsList.ItemsSource = fligths;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("AddFlight.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void fligthsList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {           
            DetailsFlightWindow details = new DetailsFlightWindow();
            var flight = fligthsList.SelectedItem as Fligth;
            var id = flight.FligthId;
            details.GetFlightDetails(id);
            details.Show();
        }
    }
}
