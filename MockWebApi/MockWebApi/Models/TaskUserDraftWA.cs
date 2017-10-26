using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockWebApi.Models
{
    public class TaskUserDraftWA : TaskStringWA
    {
        private int idUser;
        private bool isDraft;

        //Properties

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
    }
}