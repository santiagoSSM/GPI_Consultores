namespace GPIApp.Models
{
    public class TaskSeeModel : TaskStringModel
    {
        private bool isActive;

        public bool IsActive
        {
            get
            {
                return isActive;
            }
            set
            {
                isActive = value;
            }
        }
    }
}