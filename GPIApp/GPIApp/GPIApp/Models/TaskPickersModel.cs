using System.Collections.ObjectModel;

namespace GPIApp.Models
{
    public class TaskPickersModel
    {
        protected ObservableCollection<UserModel> listUser;
        protected ObservableCollection<PickersModel> listCategory;
        protected ObservableCollection<PickersModel> listPriority;

        //Recurrence
        protected ObservableCollection<PickersModel> listRecu;

        //Properties

        public ObservableCollection<UserModel> ListUser
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

        public ObservableCollection<PickersModel> ListCategory
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

        public ObservableCollection<PickersModel> ListPriority
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
        public ObservableCollection<PickersModel> ListRecu
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