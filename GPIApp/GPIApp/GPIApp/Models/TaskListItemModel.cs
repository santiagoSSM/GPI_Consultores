namespace GPIApp.Models
{
    public class TaskListItemModel
    {
        protected int idTask;
        protected string textIssue;
        private int idPriority;
        private bool isActive;

        //Properties

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

        public string TextIssue
        {
            get
            {
                return textIssue;
            }

            set
            {
                textIssue = value;
            }
        }

        public int IdPriority
        {
            get
            {
                return idPriority;
            }

            set
            {
                idPriority = value;
            }
        }

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