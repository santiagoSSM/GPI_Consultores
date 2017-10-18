using System;

namespace GPIApp.Models
{
    public class TaskListItemModel
    {
        public string UserIssue { get; set; }
        public string UserPriority { get; set; }
        public bool ActiveTask { get; set; }

        public string UserPriorityIcon
        {
            get
            {
                if (UserPriority == "Baja")
                {
                    return "low_Priority.png";
                }
                else
                {
                    return "high_Priority.png";
                }
            }
        }

        public string ExpirationIcon
        {
            
            get
            {
                if (ActiveTask)
                {
                    return "active_Task.png";
                }
                else
                {
                    return "inactive_Task.png";
                }
            }
        }
    }
}
