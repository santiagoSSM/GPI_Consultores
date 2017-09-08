using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPI_Consultores.Models
{
    class TaskAPP
    {
        int idTask;
        string userResp;
        string userCopy;
        string userCategory;
        bool userAprob;
        string userPriority;
        string userRecurrence;
        decimal userBeforeDays;
        bool userCancelRecurrence;
        DateTime userContractDate;

        public int IdTask
        {
            get
            {
                return idTask;
            }

            set
            {
                idTask = value;
            }
        }

        public string UserResp
        {
            get
            {
                return userResp;
            }

            set
            {
                userResp = value;
            }
        }

        public string UserCopy
        {
            get
            {
                return userCopy;
            }

            set
            {
                userCopy = value;
            }
        }

        public string UserCategory
        {
            get
            {
                return userCategory;
            }

            set
            {
                userCategory = value;
            }
        }

        public bool UserAprob
        {
            get
            {
                return userAprob;
            }

            set
            {
                userAprob = value;
            }
        }

        public string UserPriority
        {
            get
            {
                return userPriority;
            }

            set
            {
                userPriority = value;
            }
        }

        public string UserRecurrence
        {
            get
            {
                return userRecurrence;
            }

            set
            {
                userRecurrence = value;
            }
        }

        public decimal UserBeforeDays
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
