using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockWebApi.Models.Recurrence
{
    public class WeeklyTaskModel
    {
        int userBeforeDays;
        bool userCancelRecu;
        DateTime userContractExp;

        public int UserBeforeDays
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

        public bool UserCancelRecu
        {
            get
            {
                return userCancelRecu;
            }

            set
            {
                userCancelRecu = value;
            }
        }

        public DateTime UserContractExp
        {
            get
            {
                return userContractExp;
            }

            set
            {
                userContractExp = value;
            }
        }
    }
}