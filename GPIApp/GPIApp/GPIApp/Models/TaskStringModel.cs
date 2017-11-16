using System.Collections.ObjectModel;

namespace GPIApp.Models
{
    public class TaskStringModel : TaskParentModel
    {
        protected ObservableCollection<string> nameRespUser;
        protected ObservableCollection<string> nameCopyUser;
        protected string textCategory;
        protected string textPriority;

        //Recurrence
        protected string textRecu;

        //Properties

        public ObservableCollection<string> NameRespUser
        {
            get
            {
                return nameRespUser;
            }

            set
            {
                nameRespUser = value;
            }
        }

        public ObservableCollection<string> NameCopyUser
        {
            get
            {
                return nameCopyUser;
            }

            set
            {
                nameCopyUser = value;
            }
        }

        public string TextCategory
        {
            get
            {
                return textCategory;
            }

            set
            {
                textCategory = value;
            }
        }

        public string TextPriority
        {
            get
            {
                return textPriority;
            }

            set
            {
                textPriority = value;
            }
        }


        //Recurrence
        public string TextRecu
        {
            get
            {
                return textRecu;
            }

            set
            {
                textRecu = value;
            }
        }

    }
}