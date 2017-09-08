using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockWebApi.Models
{
    public class UserWS
    {
        string userId;
        string userPassword;

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