namespace GPI_Consultores.Models
{
    public class User : BaseDataObject
    {
        string userId = string.Empty;
        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }

        string userPassword = string.Empty;
        public string UserPassword
        {
            get { return userPassword; }
            set { SetProperty(ref userPassword, value); }
        }
    }
}
