using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockWebApi.Models
{
    public class UserPassWA : UserWA
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