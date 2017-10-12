using GPIApp.Models;
using GPIApp.WebApi;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace GPIApp.ViewModels.MainPage
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private TaskWA taskWA;
        public ObservableCollection<TaskListItemModel> listTasks;

        public ObservableCollection<TaskListItemModel> ListTasks
        {
            get
            {
                return listTasks;
            }

            set
            {
                listTasks = value;
                OnPropertyChanged("ListTasks");
            }
        }

        public MainViewModel()
        {
            taskWA = new TaskWA();
            ListTasks = new ObservableCollection<TaskListItemModel>();
        }

        public async Task LoadTask()
        {
            ListTasks = await taskWA.GetSelect();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
