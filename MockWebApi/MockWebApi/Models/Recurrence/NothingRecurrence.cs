using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockWebApi.Models.Recurrence
{
    public class NothingRecurrence
    {
        string userBeforeDays;
        bool userCancelRecurrence;
        DateTime userContractDate;

        public string UserBeforeDays
        {
            get
            {
                return userBeforeDays;
            }

            set
            {
                userBeforeDays = value;
            }
        }

        public bool UserCancelRecurrence
        {
            get
            {
                return userCancelRecurrence;
            }

            set
            {
                userCancelRecurrence = value;
            }
        }

        public DateTime UserContractDate
        {
            get
            {
                return userContractDate;
            }

            set
            {
                userContractDate = value;
            }
        }
    }
}