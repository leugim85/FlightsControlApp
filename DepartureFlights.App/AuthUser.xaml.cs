using Domain.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DepartureFlights.App
{
    /// <summary>
    /// Interaction logic for AuthUser.xaml
    /// </summary>
    public partial class AuthUser : Page
    {
        public AuthUser()
        {
            InitializeComponent();
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Uri uri = new Uri("UserRegister.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (User.Text.Length == 0 || password.Password == String.Empty) 
            {
                MessageBox.Show("Debe ingresar los datos solicitados para continuar");
                return;
            }
            UserDto user = new UserDto();
            user.UserName = User.Text;
            user.Password = password.Password;

            var result =MainWindow._userService.Login(user);

            if (result is null)
            {
                MessageBox.Show("Usuario o pasword incorrectos");
            }
            else 
            {
                Uri uri = new Uri("List.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }
    }
}
