using System;

using GPI_Consultores.Models;
using GPI_Consultores.ViewModels;

using Xamarin.Forms;
using GPI_Consultores.Helpers;

namespace GPI_Consultores.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginViewModel loginViewModel { get; set; }
        ILoginManager inter;

        public LoginPage(ILoginManager inter)
        {
            this.inter = inter;
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            BindingContext = loginViewModel = new LoginViewModel();
        }

        private async void EnterButton_Clicked(object sender, EventArgs e)
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

            if (loginViewModel.Login())
            {
                inter.ShowMainPage();
            }
            else
            {
                await DisplayAlert("Error", "Usuario y contraseña incorrectos", "Aceptar");
            }
        }
    }
}