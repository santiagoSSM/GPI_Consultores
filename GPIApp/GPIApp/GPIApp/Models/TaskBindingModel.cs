using System.Collections.ObjectModel;

namespace GPIApp.Models
{
    public class TaskBindingModel : TaskUserDraftModel
    {
        protected TaskPickersModel taskPickers;

        //Properties

        public TaskPickersModel TaskPickers
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