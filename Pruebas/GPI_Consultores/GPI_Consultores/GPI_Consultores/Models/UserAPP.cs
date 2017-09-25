namespace GPI_Consultores.Models
{
    public class UserAPP
    {
        string userId = string.Empty;
        public string UserId
        {
            get
            {
                return userId;
            }

            set
            {
                userId = value;
            }
        }

        string userPassword = string.Empty;
        public string UserPassword
        {
            get
            {
                return userPassword;
            }

            set
            {
                userPassword = value;
            }
        }
    }
}
