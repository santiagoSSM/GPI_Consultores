using GPIApp.Models;
using GPIApp.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPIApp.ViewModels
{
    public class LoginViewModel
    {
        public UserAPP user { get; set; }
        private UserWA userWA;

        public LoginViewModel()
        {
            user = new UserAPP();
            userWA = new UserWA();
        }

        private void LoadUser(UserAPP user)
        {
            //Cargar usuario en el intent
        }

        public async Task<bool> Login()
        {
            var temp = await userWA.PutLogin(user);

            if (temp != null)
            {
                LoadUser(temp);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
