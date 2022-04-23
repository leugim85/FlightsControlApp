using Business.Services;
using System;
using System.Windows;

namespace DepartureFlights.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static IFligthService _service;
        public static IUserService _userService;
        public static IAirlineService _airlineService;
        public static ICitiesService _citiesService;
        public static IStatusService _statusService;
        public MainWindow(IFligthService service, IUserService userService, 
                          IAirlineService airlineService, ICitiesService citiesService, IStatusService statusService)
        {
            InitializeComponent();
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _airlineService = airlineService ?? throw new ArgumentNullException(nameof(airlineService));
            _citiesService = citiesService ?? throw new ArgumentNullException(nameof(citiesService));
            _statusService = statusService ?? throw new ArgumentNullException(nameof(statusService));
            DataContext = this;
        }
    }
}
