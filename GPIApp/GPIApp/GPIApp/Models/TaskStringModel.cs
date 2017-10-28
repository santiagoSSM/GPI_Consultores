namespace GPIApp.Models
{
    public class TaskStringModel : TaskParentModel
    {
        protected string nameRespUser;
        protected string nameCopyUser;
        protected string textCategory;
        protected string textPriority;

        //Recurrence
        protected string textRecu;

        //FinalDate

        protected string textFinalDate;

        //Properties

        public string NameRespUser
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

        public string NameCopyUser
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


        //FinalDate

        public string TextFinalDate
        {
            get
            {
                return textFinalDate;
            }

            set
            {
                textFinalDate = value;
            }
        }

    }
}