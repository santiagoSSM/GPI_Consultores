using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MockService
{
    [DataContract]
    public class TaskWS
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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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