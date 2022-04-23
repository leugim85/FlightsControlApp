using Business.Models;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DepartureFlights.App
{
    /// <summary>
    /// Interaction logic for AddFlight.xaml
    /// </summary>
    public partial class AddFlight : Page
    {
        public AddFlight()
        {
            InitializeComponent();
            GetStatus();
            GetCitiesOrigin();
            GetAirlines();
            GetCitiesDestination();
        }

        public void GetAirlines() 
        {
            List<EntityDto> airlines = new List<EntityDto>();
            var statusListResult = MainWindow._airlineService.GetAirlines();
            foreach (var item in statusListResult)
            {
                var airline = new EntityDto();
                airline.Name = item;
                airlines.Add(airline);
            }
           Airline.ItemsSource = airlines;          
        }

        public void GetCitiesOrigin() 
        {
            List<EntityDto> cities = new List<EntityDto>();
            var statusListResult = MainWindow._citiesService.GetCities();
            foreach (var item in statusListResult)
            {
                var city = new EntityDto();
                city.Name = item;
                cities.Add(city);
            }
            Origin.ItemsSource = cities;
        }

        public void GetCitiesDestination()
        {
            List<EntityDto> cities = new List<EntityDto>();
            var statusListResult = MainWindow._citiesService.GetCities();
            foreach (var item in statusListResult)
            {
                var city = new EntityDto();
                city.Name = item;
                cities.Add(city);
            }
            Destination.ItemsSource = cities;
        }

        public void GetStatus() 
        {
            List<EntityDto> statusList = new List<EntityDto>(); 
            var statusListResult = MainWindow._statusService.GetStatusList();
            foreach (var item in statusListResult) 
            {
                var status = new EntityDto();
                status.Name = item;
                statusList.Add(status);
            }
            Status.ItemsSource = statusList;
        }

        public void addNewFlight() 
        {
            if (Status.SelectedItem is null || Date.SelectedDate is null || Destination.SelectedItem is null || Airline.SelectedItem is null || 
                Origin.SelectedItem is null || DepartureTime.Text.Length < 1 || ArrivalTime.Text.Length < 1) 
            {
                MessageBox.Show("Se deben ingresar todos los campos");
                return; 
            }
            var city = Destination.SelectedItem as EntityDto;
            var status = Status.SelectedItem as EntityDto;
            var airline = Airline.SelectedItem as EntityDto;
            var origin = Origin.SelectedItem as EntityDto;  

            FligthDto flight = new FligthDto();
            flight.DestinationCityId= MainWindow._citiesService.GetId(city.Name);
            flight.AirlineId= MainWindow._airlineService.GetId(airline.Name);
            flight.OriginCityId = MainWindow._citiesService.GetId(origin.Name);
            flight.FlightStatusId = MainWindow._statusService.GetId(status.Name);
            flight.Date = Date.SelectedDate.Value;
            if (DateTime.TryParse(DepartureTime.Text, out DateTime result))
            {
                flight.DepartureTime = result;
            }
            else 
            {
                MessageBox.Show("Debe ingresar un formato valido en 'Hora de Salida': 'hh:mm'");
                return;
            }
            if (DateTime.TryParse(ArrivalTime.Text, out DateTime time))
            {
                flight.ArrivalTime = time;
            }
            else 
            {
                MessageBox.Show("Debe ingresar un formato valido en 'Hora de Llegada': 'hh:mm'");
                return;
            }

            MainWindow._service.AddFligth(flight);

            DepartureTime.Clear();
            ArrivalTime.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addNewFlight();
        }

        private void Button_AddStatus(object sender, RoutedEventArgs e)
        {
            if (newStatus.Text.Length < 1) { return; }
            var result = MainWindow._statusService.AddStatus(newStatus.Text);
            if (result)
            {
                MessageBox.Show("Se ha agregado con exito!");
                newStatus.Clear();
            }
            else
            {
                MessageBox.Show("EL Status ya se encuentra registrada");
                newStatus.Clear();
                return;
            }
        }

        private void Button_AddAirline(object sender, RoutedEventArgs e)
        {
            if(newAirline.Text.Length < 1) { return; }
            var result =  MainWindow._airlineService.AddAirline(newAirline.Text);
            if (result)
            {
                MessageBox.Show("Se ha agregado con exito!");
                newAirline.Clear();
            }
            else 
            {
                MessageBox.Show("La aerolínea ya se encuentra registrada");
                newAirline.Clear();
                return;
            }
        }

        private void Button_AddCity(object sender, RoutedEventArgs e)
        {
            if (newCity.Text.Length < 1) { return; }
            var result = MainWindow._citiesService.AddCity(newCity.Text);
            if (result)
            {
                MessageBox.Show("Se ha agregado con exito!");
                newCity.Clear();
            }
            else
            {
                MessageBox.Show("La ciudad ya se encuentra registrada");
                newCity.Clear();
                return;
            }
        }
    }
}
