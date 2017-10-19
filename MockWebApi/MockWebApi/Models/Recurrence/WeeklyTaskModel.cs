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
        int repeatRecu;
        string day;
        string finalDate;
        int recurrence;
        DateTime userContractFinal;

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

        public int RepeatRecu
        {
            get
            {
                return repeatRecu;
            }

            set
            {
                repeatRecu = value;
            }
        }

        public string Day
        {
            get
            {
                return day;
            }

            set
            {
                day = value;
            }
        }

        public string FinalDate
        {
            get
            {
                return finalDate;
            }

            set
            {
                finalDate = value;
            }
        }

        public int Recurrence
        {
            get
            {
                return recurrence;
            }

            set
            {
                recurrence = value;
            }
        }

        public DateTime UserContractFinal
        {
            get
            {
                return userContractFinal;
            }

            set
            {
                userContractFinal = value;
            }
        }
    }
}