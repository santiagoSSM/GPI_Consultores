using GalaSoft.MvvmLight.Command;
using GPIApp.Helpers;
using GPIApp.Models;
using GPIApp.Views.PopUps.Generic;
using GPIApp.WebApi;
using Rg.Plugins.Popup.Services;
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
                await PopupNavigation.PushAsync(new ActivityIndicatorPopUp());
                if (await userWA.PutLogin(user))
                {
                    await PopupNavigation.PopAsync();
                    return true;
                }
                else
                {
                    await PopupNavigation.PopAsync();
                    await dialogService.ShowMessage("Error", "Usuario y contraseña incorrectos", "Aceptar");
                    return false;
                }
            }
            catch (Exception e)
            {
                await PopupNavigation.PopAsync();
                throw e;
            }
        }
    }
}
