using System;

using GPI_Consultores.Models;
using GPI_Consultores.ViewModels;

using Xamarin.Forms;

namespace GPI_Consultores.Views
{
    public partial class LoginPage : ContentPage
    {
        public User user { get; set; }
        public LoginViewModel loginViewModel { get; set; }

        public LoginPage()
        {
            InitializeComponent();

            user = new User
            {
                UserId = "",
                UserPassword = ""
            };

            loginViewModel = new LoginViewModel
            {
                user = this.user
            };

            BindingContext = this;
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
                await Navigation.PushModalAsync(
                    new TabbedPage
                    {
                        Children =
                        {
                            new NavigationPage(new ItemsPage())
                            {
                                Title = "Browse",
                                Icon = Device.OnPlatform("tab_feed.png",null,null)
                            },
                            new NavigationPage(new AboutPage())
                            {
                                Title = "About",
                                Icon = Device.OnPlatform("tab_about.png",null,null)
                            },
                        }
                    },
                 true);
            }
            else
            {
                await DisplayAlert("Error", "Usuario y contraseña incorrectos", "Aceptar");
            }
        }
    }
}