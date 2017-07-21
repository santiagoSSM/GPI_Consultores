using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GPI_Consultores.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            enterButton.Clicked += EnterButton_Clicked;
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



        }
    }
}