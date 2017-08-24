using GPI_Consultores.WebService;
using GPI_Consultores.Models;

namespace GPI_Consultores.ViewModels
{
    public class LoginViewModel
    {
        public User user { get; set; }
        private LoginWS loginWS;

        public LoginViewModel()
        {
            user = new User();
            loginWS = new LoginWS();
        }

        private bool LoadUser()
        {
            loginWS.SearchUser(user.UserId, user.UserPassword);
            return loginWS.ExistUser();
        }

        public bool CompareUser()
        {
            return loginWS.GetUser().UserId == user.UserId;
        }

        public bool ComparePass()
        {
            return loginWS.GetUser().UserPassword == user.UserPassword;
        }

        public bool Login()
        {
            if (LoadUser())
            {
                if (CompareUser() && ComparePass())
                {
                    user = loginWS.GetUser();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
