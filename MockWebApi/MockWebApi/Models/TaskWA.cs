using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockWebApi.Models
{
    public class TaskWA : TaskParentWA
    {
        //NoTaskAttributes

        private int idUser;
        private bool isDraft;

        //Task

        private int idRespUser;
        private int idCopyUser;
        private int idCategory;
        private int idPriority;

        //Recurrence
        private int idRecu;

        //FinalDate

        private int idFinalDate;

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


        //FinalDate

        public int IdFinalDate
        {
            get
            {
                return idFinalDate;
            }

            set
            {
                idFinalDate = value;
            }
        }

    }
}