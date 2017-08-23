using GPI_Consultores.Models;

namespace GPI_Consultores.AzureDataBase
{
    class LoginDB
    {
        public User userDB;

        public LoginDB()
        {
            userDB = new User
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
            //usar la base de datos de asure
            userDB.UserId = "user";
            userDB.UserPassword = "pass";
        }

        public bool ExistUser()
        {
            return userDB.UserId != null && userDB.UserPassword != null;
        }

        public User GetUser()
        {
            return userDB;
        }
    }
}
