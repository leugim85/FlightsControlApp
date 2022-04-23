using Business.Entities;
using System.Collections.Generic;
using System.Windows;

namespace DepartureFlights.App
{
    /// <summary>
    /// Interaction logic for DetailsFlightWindow.xaml
    /// </summary>
    public partial class DetailsFlightWindow : Window
    {
        public DetailsFlightWindow()
        {
            InitializeComponent();
        }

        public void GetFlightDetails(int id) 
        {
           List<Fligth> fligths = new List<Fligth>();
           var detailsFlight = MainWindow._service.GetFligthByid(id);
           fligths.Add(detailsFlight);
           Details.ItemsSource = fligths;
           DetailsDown.ItemsSource = fligths;
        }
    }
}
