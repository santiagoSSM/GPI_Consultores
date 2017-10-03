using GalaSoft.MvvmLight.Command;
using GPIApp.Helpers;
using GPIApp.Models;
using GPIApp.WebApi;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GPIApp.ViewModels
{
    public class LoginViewModel
    {
        private DialogService dialogService;
        private NavigationService navigationService;
        public UserAPP user { get; set; }
        private UserWA userWA;

        public LoginViewModel()
        {
            dialogService = new DialogService();
            navigationService = new NavigationService();
            user = new UserAPP();
            userWA = new UserWA();
        }

        public ICommand LoginCommand
        {
            get { return new RelayCommand(Login); }
        }

        public async void Login()
        {
            if (string.IsNullOrEmpty(user.UserId))
            {
                await dialogService.ShowMessage("Error", "Debe ingresar un usuario", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(user.UserPassword))
            {
                await dialogService.ShowMessage("Error", "Debe ingresar una contraseña", "Aceptar");
                return;
            }

            try
            {
                if (await userWA.PutLogin(user))
                {
                    navigationService.SetPage("MasterPage");
                }
                else
                {
                    await dialogService.ShowMessage("Error", "Usuario y contraseña incorrectos", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                await dialogService.ShowMessage("Error", ex.Message, "Aceptar");
            }
        }
    }
}
