using Domain.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DepartureFlights.App
{
    /// <summary>
    /// Interaction logic for UserRegister.xaml
    /// </summary>
    public partial class UserRegister : Page
    {
        public UserRegister()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (User.Text.Length == 0 || password.Password == String.Empty || confirmPassword.Password == String.Empty) 
            {
                MessageBox.Show("Debe ingresar todos los campos");
                return;
            }
            var user = new UserDto();
            user.UserName = User.Text;
            if (!password.Password.Equals(confirmPassword.Password))
            {
                MessageBox.Show("La contraseña debe coincidir");
                return;
            }
            else 
            {
                user.Password = password.Password;
            }

            var result = MainWindow._userService.Register(user);
            if (result is null) 
            {
                MessageBox.Show("El nombre de usuario no esta disponible");
                return;
            }
            User.Clear();
            password.Clear();
            confirmPassword.Clear();
            MessageBox.Show("Usuario registrado exitosamente");
            Uri uri = new Uri("AuthUser.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
