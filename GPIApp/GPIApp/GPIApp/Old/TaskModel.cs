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
        string userIssue; //Todo IssueText
        string userResp; // Todo IdUserResp y agregar UserRespName
        string userCopy; // Todo IdUserCopy y agregar UserCopyName
        string userCategory; // Todo IdCategory y agregar CategoryName
        bool   userAprob; // Todo IsAprob
        string userPriority; // Todo IdPriority y agregar PriorityName
        string userDescription;// Todo Description
        string userRecurrence;// Todo IdRecurrence y agregar RecurrenceName
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
