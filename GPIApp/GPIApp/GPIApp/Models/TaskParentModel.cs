﻿using System;

namespace GPIApp.Models
{
    public class TaskParentModel
    {
        protected int idTask = -1;
        protected string textIssue;
        protected string textDescription;
        protected bool isAprob;

        //Recurrence

        protected int beforeDays;
        protected bool isCancelRecu;

        //Daily Monthly Annual vector info

        protected bool selectTimeOfRecu;
        protected int timeOfRecu0;
        protected int timeOfRecu1;
        protected int timeOfRecu2;

        //FinalDate

        protected int numRecu;
        protected DateTime contractExp;

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