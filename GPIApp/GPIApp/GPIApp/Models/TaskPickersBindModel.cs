using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPIApp.Models
{
    public class TaskPickersBindModel
    {
        protected ObservableCollection<string> listUser;
        protected ObservableCollection<string> listCategory;
        protected ObservableCollection<string> listPriority;

        //Recurrence
        protected string[] listRecu;

        //Properties

        public TaskPickersBindModel(TaskPickersModel value)
        {
            listUser = new ObservableCollection<string>();
            foreach (UserModel element in value.ListUser)
            {
                listUser.Add(element.NameUser);
            }

            listCategory = new ObservableCollection<string>();
            foreach (PickersModel element in value.ListCategory)
            {
                listCategory.Add(element.TextValue);
            }

            listPriority = new ObservableCollection<string>();
            foreach (PickersModel element in value.ListPriority)
            {
                listPriority.Add(element.TextValue);
            }

            var temp = new ObservableCollection<string>();
            foreach (PickersModel element in value.ListRecu)
            {
                temp.Add(element.TextValue);
            }

            listRecu = temp.ToArray();
        }

        public ObservableCollection<string> ListUser
        {
            get
            {
                return listUser;
            }
        }

        public ObservableCollection<string> ListCategory
        {
            get
            {
                return listCategory;
            }
        }

        public ObservableCollection<string> ListPriority
        {
            get
            {
                return listPriority;
            }
        }


        //Recurrence
        public string[] ListRecu
        {
            get
            {
                return listRecu;
            }
        }
    }
}
