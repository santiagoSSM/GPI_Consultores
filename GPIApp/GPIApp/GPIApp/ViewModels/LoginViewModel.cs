using GPIApp.Helpers;
using GPIApp.Models;
using GPIApp.WebApi;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPIApp.ViewModels
{
    public class LoginViewModel
    {
        private DialogService dialogService;
        public UserAPP user { get; set; }
        private UserWA userWA;

        public LoginViewModel()
        {
            dialogService = new DialogService();
            user = new UserAPP();
            userWA = new UserWA();
        }

        public async Task<bool> Login()
        {
            if (string.IsNullOrEmpty(user.UserId))
            {
                await dialogService.ShowMessage("Error", "Debe ingresar un usuario", "Aceptar");
                //userLogin.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(user.UserPassword))
            {
                await dialogService.ShowMessage("Error", "Debe ingresar una contraseña", "Aceptar");
                //userPass.Focus();
                return false;
            }

            if (await userWA.PutLogin(user))
            {
                return true;
            }
            else
            {
                await dialogService.ShowMessage("Error", "Usuario y contraseña incorrectos", "Aceptar");
                return false;
            }
            
        }
    }
}
