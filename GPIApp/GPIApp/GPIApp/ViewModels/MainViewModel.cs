using GalaSoft.MvvmLight.Command;
using GPIApp.Infraestructure;
using GPIApp.Models;
using GPIApp.WebApi;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GPIApp.ViewModels
{
    public class MainViewModel
    {
        IVMContainer inter;
        NavigationService navServ;
        public ObservableCollection<TaskListItemViewModel> ListTasks { get; set; }
        

        public MainViewModel(IVMContainer inter)
        {
            this.inter = inter;
            navServ = new NavigationService(inter);
            ListTasks = new ObservableCollection<TaskListItemViewModel>();
        }

        public async Task LoadInfo(int idUser)
        {
            //Todo programar correctamente los filtros
            ListTasks.Clear();
            foreach (TaskListItemModel element in await TaskWACtrl.PutTaskListItem(idUser, null))
            {
                ListTasks.Add(new TaskListItemViewModel(inter, element));
            }
        }

        public ICommand NewTaskCommand
        {
            get { return new RelayCommand(NewTask); }
        }

        private async void NewTask()
        {
            await navServ.Navigate("NewTask");
        }

        //Menu

        public ICommand ActiveTaskCommand
        {
            get { return new RelayCommand(ActiveTask); }
        }

        private async void ActiveTask()
        {
            await navServ.Navigate("CloseMenu");
        }

        public ICommand CompleteTaskCommand
        {
            get { return new RelayCommand(CompleteTask); }
        }

        private async void CompleteTask()
        {
            await navServ.Navigate("CloseMenu");
        }

        public ICommand CanceledTaskCommand
        {
            get { return new RelayCommand(CanceledTask); }
        }

        private async void CanceledTask()
        {
            await navServ.Navigate("CloseMenu");
        }

        public ICommand SettingsCommand
        {
            get { return new RelayCommand(Settings); }
        }

        private async void Settings()
        {
            await navServ.Navigate("CloseMenu");
        }

        public ICommand CloseSesionCommand
        {
            get { return new RelayCommand(CloseSesion); }
        }

        private async void CloseSesion()
        {
            await navServ.SetPageAsync("LoginPage");
        }
    }
}
