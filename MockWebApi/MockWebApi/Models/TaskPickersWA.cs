using System.Collections.ObjectModel;

namespace MockWebApi.Models
{
    public class TaskPickersWA
    {
        protected ObservableCollection<UserWA> listUser;
        protected ObservableCollection<PickersWA> listCategory;
        protected ObservableCollection<PickersWA> listPriority;

        //Recurrence
        protected ObservableCollection<PickersWA> listRecu;

        //Properties

        public ObservableCollection<UserWA> ListUser
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

        public ObservableCollection<PickersWA> ListCategory
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

        public ObservableCollection<PickersWA> ListPriority
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
        public ObservableCollection<PickersWA> ListRecu
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

    }
}