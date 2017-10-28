using System;

namespace GPIApp.Modelsx
{
    public class TaskListItemModel
    {
        public int IdTask { get; set; }
        public string UserIssue { get; set; } //Todo cambiar a IssueText
        public string UserPriority { get; set; } //Todo cambiar a IdImgPriority
        public bool ActiveTask { get; set; } // Todo IsActive

        //Todo ImgPriority
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

        //Todo ImgIsActive
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
