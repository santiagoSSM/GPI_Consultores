using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPIApp.Models.Recurrence
{
    class NoneTaskModel
    {
        int userBeforeDays;
        bool userCancelRecurrence;
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
