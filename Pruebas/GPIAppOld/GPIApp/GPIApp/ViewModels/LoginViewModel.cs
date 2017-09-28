using GPIApp.Helpers;
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

        //Navigation
        ILoginManager inter;

        public LoginViewModel(ILoginManager inter)
        {
            this.inter = inter;
            user = new UserAPP();
            userWA = new UserWA();
        }

        public async Task<bool> Login()
        {
            var temp = await userWA.PutLogin(user);

            if (temp)
            {
                inter.ShowMainPage(user.UserId);
                return true;
            }
            return false;
        }
    }
}
