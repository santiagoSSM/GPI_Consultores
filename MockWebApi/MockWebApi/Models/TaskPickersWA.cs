using System.Collections.ObjectModel;

namespace MockWebApi.Models
{
    public class TaskPickersWA
    {
        protected ObservableCollection<string> listUser;
        protected ObservableCollection<string> listCategory;
        protected ObservableCollection<string> listPriority;

        //Recurrence
        protected ObservableCollection<string> listRecu;

        //FinalDate

        protected ObservableCollection<string> listFinalDate;

        //Properties

        public ObservableCollection<string> ListUser
        {
            get
            {
                return listUser;
            }

            set
            {
                listUser = value;
            }
        }

        public ObservableCollection<string> ListCategory
        {
            get
            {
                return listCategory;
            }

            set
            {
                listCategory = value;
            }
        }

        public ObservableCollection<string> ListPriority
        {
            get
            {
                return listPriority;
            }

            set
            {
                listPriority = value;
            }
        }


        //Recurrence
        public ObservableCollection<string> ListRecu
        {
            get
            {
                return listRecu;
            }

            set
            {
                listRecu = value;
            }
        }


        //FinalDate

        public ObservableCollection<string> ListFinalDate
        {
            get
            {
                return listFinalDate;
            }

            set
            {
                listFinalDate = value;
            }
        }
    }
}