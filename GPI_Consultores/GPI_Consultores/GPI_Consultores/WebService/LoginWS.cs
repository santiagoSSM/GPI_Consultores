using GPI_Consultores.Models;

namespace GPI_Consultores.WebService
{
    class LoginWS
    {
        public User userWS;

        public LoginWS()
        {
            userWS = new User
            {
                UserId = "",
                UserPassword = ""
            };
        }

        public void Connect()
        {

        }

        public void SearchUser(string userID, string passID)
        {
            //usar el web service para conectar
            userWS.UserId = "user";
            userWS.UserPassword = "pass";
        }

        public bool ExistUser()
        {
            return userWS.UserId != null && userWS.UserPassword != null;
        }

        public User GetUser()
        {
            return userWS;
        }
    }
}
