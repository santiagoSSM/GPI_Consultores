using GPI_Consultores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPI_Consultores.ViewModels
{
    public class LoginViewModel
    {
        public User user { get; set; }

        public LoginViewModel()
        { }

        public bool ValidateUserId()
        {
            if (this.user.UserId == "userLogin") //remplazar user por el de la base de datos
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PasswordValidate()
        {
            if (this.user.UserPassword == "passLogin") //remplazar contraseña por el de la base de datos
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Login()
        {
            if(ValidateUserId() && PasswordValidate())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
