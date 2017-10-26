using System.Collections.ObjectModel;

namespace MockWebApi.Models
{
    public class TaskBindingWA : TaskUserDraftWA
    {
        protected TaskPickersWA taskPickers;

        //Properties

        public TaskPickersWA TaskPickers
        {
            get
            {
                return taskPickers;
            }

            set
            {
                taskPickers = value;
            }
        }
    }
}