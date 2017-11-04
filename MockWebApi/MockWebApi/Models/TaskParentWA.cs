using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockWebApi.Models
{
    public class TaskParentWA
    {
        protected int idTask = -1;
        protected string textIssue = "";
        protected string textDescription = "";
        protected bool isAprob = false;

        //Recurrence

        protected int beforeDays = 0;
        protected bool isCancelRecu = false;

        //Daily Monthly Annual vector info

        protected bool selectTimeOfRecu = false;
        protected int timeOfRecu0 = 0;
        protected int timeOfRecu1 = 0;
        protected int timeOfRecu2 = 0;

        //FinalDate

        private int finalDate = 0; //0 = sin fecha de finalizacion 1 = Finaliza después de 2 = Finaliza el
        protected int numRecu = 0;
        protected DateTime contractExp = DateTime.Now;

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

        public string TextDescription
        {
            get
            {
                return textDescription;
            }

            set
            {
                textDescription = value;
            }
        }

        public bool IsAprob
        {
            get
            {
                return isAprob;
            }

            set
            {
                isAprob = value;
            }
        }

        //Recurrence

        public int BeforeDays
        {
            get
            {
                return beforeDays;
            }

            set
            {
                beforeDays = value;
            }
        }

        public bool IsCancelRecu
        {
            get
            {
                return isCancelRecu;
            }

            set
            {
                isCancelRecu = value;
            }
        }

        //Daily Monthly Annual vector info

        public bool SelectTimeOfRecu
        {
            get
            {
                return selectTimeOfRecu;
            }

            set
            {
                selectTimeOfRecu = value;
            }
        }

        public int TimeOfRecu0
        {
            get
            {
                return timeOfRecu0;
            }

            set
            {
                timeOfRecu0 = value;
            }
        }

        public int TimeOfRecu1
        {
            get
            {
                return timeOfRecu1;
            }

            set
            {
                timeOfRecu1 = value;
            }
        }

        public int TimeOfRecu2
        {
            get
            {
                return timeOfRecu2;
            }

            set
            {
                timeOfRecu2 = value;
            }
        }

        //Final Date

        public int NumRecu
        {
            get
            {
                return numRecu;
            }

            set
            {
                numRecu = value;
            }
        }

        public int FinalDate
        {
            get
            {
                return finalDate;
            }

            set
            {
                finalDate = value;
            }
        }

        public DateTime ContractExp
        {
            get
            {
                return contractExp;
            }

            set
            {
                contractExp = value;
            }
        }
    }
}