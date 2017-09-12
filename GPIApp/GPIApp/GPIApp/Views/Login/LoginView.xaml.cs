using GPIApp.Helpers;
using GPIApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GPIApp.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginViewModel loginViewModel { get; set; }

        public LoginView(ILoginManager inter)
        {
            InitializeComponent();
            BindingContext = loginViewModel = new LoginViewModel(inter);
        }

        private void EnterButton_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
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

                try
                {
                    if (!await loginViewModel.Login())
                    {
                        await DisplayAlert("Error", "Usuario y contraseña incorrectos", "Aceptar");
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", ex.Message, "Aceptar");
                }
            });
        }
    }
}