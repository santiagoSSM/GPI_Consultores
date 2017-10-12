using GalaSoft.MvvmLight.Command;
using GPIApp.Helpers;
using GPIApp.Models;
using GPIApp.WebApi;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GPIApp.ViewModels.Login
{
    public class LoginViewModel
    {
        private DialogService dialogService;
        private NavigationService navigationService;
        public UserModel user { get; set; }
        private UserWA userWA;

        public LoginViewModel()
        {
            dialogService = new DialogService();
            navigationService = new NavigationService();
            user = new UserModel();
            userWA = new UserWA();
        }

        public async Task<bool> Login()
        {
            if (string.IsNullOrEmpty(user.UserId))
            {
                await dialogService.ShowMessage("Error", "Debe ingresar un usuario", "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(user.UserPassword))
            {
                await dialogService.ShowMessage("Error", "Debe ingresar una contraseña", "Aceptar");
                return false;
            }

            try
            {
                if (await userWA.PutLogin(user))
                {
                    //navigationService.SetPage("MasterPage");
                    return true;
                }
                else
                {
                    await dialogService.ShowMessage("Error", "Usuario y contraseña incorrectos", "Aceptar");
                    return false;
                }
            }
            catch (Exception ex)
            {
                await dialogService.ShowMessage("Error", ex.Message, "Aceptar");
                return false;
            }
        }
    }
}
