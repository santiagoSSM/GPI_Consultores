using System.Collections.ObjectModel;

namespace GPIApp.Models
{
    public class TaskModel : TaskParentModel
    {
        //NoTaskAttributes

        private int idUser = -1;
        private bool isDraft = false;

        //Task

        private ObservableCollection<int> idRespUser = null;
        private ObservableCollection<int> idCopyUser = null;
        private int idCategory = -1;
        private int idPriority = -1;

        //Recurrence
        private int idRecu = 0;

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

        public ObservableCollection<int> IdRespUser
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

        public ObservableCollection<int> IdCopyUser
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