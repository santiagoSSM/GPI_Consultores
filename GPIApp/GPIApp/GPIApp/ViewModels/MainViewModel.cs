using GalaSoft.MvvmLight.Command;
using GPIApp.Infraestructure;
using GPIApp.Models;
using GPIApp.WebApi;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GPIApp.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<TaskListItemViewModel> ListTasks { get; set; }
        

        public MainViewModel()
        {
            ListTasks = new ObservableCollection<TaskListItemViewModel>();
        }

        public async Task LoadInfo(int idUser)
        {
            //Todo programar correctamente los filtros y arreglar actualizar pantalla
            ListTasks.Clear();
            foreach (TaskListItemModel element in await TaskWACtrl.PutTaskListItem(idUser, null))
            {
                ListTasks.Add(new TaskListItemViewModel(element));
            }
        }

        public ICommand NewTaskCommand
        {
            get { return new RelayCommand(NewTask); }
        }

        private async void NewTask()
        {
            await NavigationService.Navigate("NewTask");
        }

        //Menu

        public ICommand ActiveTaskCommand
        {
            get { return new RelayCommand(ActiveTask); }
        }

        private async void ActiveTask()
        {
            await NavigationService.Navigate("CloseMenu");
        }

        public ICommand CompleteTaskCommand
        {
            get { return new RelayCommand(CompleteTask); }
        }

        private async void CompleteTask()
        {
            await NavigationService.Navigate("CloseMenu");
        }

        public ICommand CanceledTaskCommand
        {
            get { return new RelayCommand(CanceledTask); }
        }

        private async void CanceledTask()
        {
            await NavigationService.Navigate("CloseMenu");
        }

        public ICommand SettingsCommand
        {
            get { return new RelayCommand(Settings); }
        }

        private async void Settings()
        {
            await NavigationService.Navigate("CloseMenu");
        }

        public ICommand CloseSesionCommand
        {
            get { return new RelayCommand(CloseSesion); }
        }

        private async void CloseSesion()
        {
            await NavigationService.SetPageAsync("LoginPage");
        }
    }
}
