using GPI_Consultores.WebApi;
using GPI_Consultores.Models;
using System.Threading.Tasks;

namespace GPI_Consultores.ViewModels
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
