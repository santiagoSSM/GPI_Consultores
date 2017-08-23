using GPI_Consultores.AzureDataBase;
using GPI_Consultores.Models;

namespace GPI_Consultores.ViewModels
{
    public class LoginViewModel
    {
        public User user { get; set; }
        private LoginDB loginDB;

        public LoginViewModel()
        {
            user = new User();
            loginDB = new LoginDB();
        }

        private bool LoadUser()
        {
            loginDB.SearchUser(user.UserId, user.UserPassword);
            return loginDB.ExistUser();
        }

        public bool CompareUser()
        {
            return loginDB.GetUser().UserId == user.UserId;
        }

        public bool ComparePass()
        {
            return loginDB.GetUser().UserPassword == user.UserPassword;
        }

        public bool Login()
        {
            if (LoadUser())
            {
                if (CompareUser() && ComparePass())
                {
                    user = loginDB.GetUser();
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
