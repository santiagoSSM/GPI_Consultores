using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPIApp.Models.Recurrence
{
    public class DailyTaskModel
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
