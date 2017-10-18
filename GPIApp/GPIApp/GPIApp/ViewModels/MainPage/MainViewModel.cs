using GalaSoft.MvvmLight.Command;
using GPIApp.Helpers;
using GPIApp.Models;
using GPIApp.WebApi;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GPIApp.ViewModels.MainPage
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private DialogService dialogService;
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
            dialogService = new DialogService();
            taskWA = new TaskWA();
            ListTasks = new ObservableCollection<TaskListItemModel>();
        }

        public async Task LoadListTask(char select)
        {
            ListTasks = await taskWA.GetSelect(select);
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
