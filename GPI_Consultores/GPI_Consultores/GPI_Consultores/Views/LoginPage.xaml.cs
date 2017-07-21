using System;

using GPI_Consultores.Models;
using GPI_Consultores.ViewModels;

using Xamarin.Forms;

namespace GPI_Consultores.Views
{
    public partial class LoginPage : ContentPage
    {
        public User User { get; set; }
        public LoginViewModel LoginViewModel { get; set; }

        public LoginPage()
        {
            InitializeComponent();

            User = new User { };
            LoginViewModel = new LoginViewModel
            {
                User = this.User
            };

            BindingContext = this;

            InitializeComponent();
        }

        private async void enterButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(userLogin.Text))
            {
                await DisplayAlert("Error", "Debe ingresar un Usuario", "Aceptar");
                userLogin.Focus();
                return;
            }

            if (string.IsNullOrEmpty(userLogin.Text))
            {
                await DisplayAlert("Error", "Debe ingresar una Contraseña", "Aceptar");
                userPass.Focus();
                return;
            }

            if (LoginViewModel.logear())
            {
                await DisplayAlert("Iniciar", "Usuario y contraseña correctos", "Aceptar");
            }
            else
            {
                await DisplayAlert("Error", "Usuario y contraseña incorrectos", "Aceptar");
            }
        }
    }
}