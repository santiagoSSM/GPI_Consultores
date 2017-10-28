namespace GPIApp.Models
{
    public class UserPassModel : UserModel
    {
        string passUser;

        public string PassUser
        {
            get
            {
                return passUser;
            }

            set
            {
                passUser = value;
            }
        }
    }
}