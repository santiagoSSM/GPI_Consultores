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
        public User User { get; set; }

        public LoginViewModel()
        { }

        public bool validarUsuario()
        {
            if (this.User.Usuario == "user") //remplazar user por el de la base de datos
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool validarContrasenia()
        {
            if (this.User.Contrasenia == "contraseña") //remplazar contraseña por el de la base de datos
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool logear()
        {
            if(validarUsuario() && validarContrasenia())
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
