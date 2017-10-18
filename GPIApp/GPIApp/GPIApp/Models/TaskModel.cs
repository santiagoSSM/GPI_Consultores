using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPIApp.Models
{
    public class TaskModel
    {
        int    idTask;
        string userIssue;
        string userResp;
        string userCopy;
        string userCategory;
        bool   userAprob;
        string userPriority;
        string userDescription;
        string userRecurrence;
        object objRecurrence;

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

        public string UserIssue
        {
            get
            {
                return userIssue;
            }

            set
            {
                userIssue = value;
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

        public string UserDescription
        {
            get
            {
                return userDescription;
            }

            set
            {
                userDescription = value;
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

        public object ObjRecurrence
        {
            get
            {
                return objRecurrence;
            }

            set
            {
                objRecurrence = value;
            }
        }
    }
}
