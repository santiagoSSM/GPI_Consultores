namespace GPIApp.Models
{
    public class TaskModel : TaskParentModel
    {
        //NoTaskAttributes

        private int idUser = -1;
        private bool isDraft;

        //Task

        private int idRespUser = -1;
        private int idCopyUser = -1;
        private int idCategory = -1;
        private int idPriority = -1;

        //Recurrence
        private int idRecu = -1;

        //Properties

        //NoTaskAttributes

        public int IdUser
        {
            get
            {
                return idUser;
            }

            set
            {
                idUser = value;
            }
        }

        public bool IsDraft
        {
            get
            {
                return isDraft;
            }

            set
            {
                isDraft = value;
            }
        }


        //Task

        public int IdRespUser
        {
            get
            {
                return idRespUser;
            }

            set
            {
                idRespUser = value;
            }
        }

        public int IdCopyUser
        {
            get
            {
                return idCopyUser;
            }

            set
            {
                idCopyUser = value;
            }
        }

        public int IdCategory
        {
            get
            {
                return idCategory;
            }

            set
            {
                idCategory = value;
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


        //Recurrence
        public int IdRecu
        {
            get
            {
                return idRecu;
            }

            set
            {
                idRecu = value;
            }
        }

    }
}