using GalaSoft.MvvmLight.Command;
using GPIApp.Helpers;
using GPIApp.Views.NewTask;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GPIApp.ViewModels
{
    class MainViewModel
    {

        public MainViewModel()
        {
            dialogService = new DialogService();
            navigationService = new NavigationService();

            Login = new LoginViewModel();

            Tasks = new ObservableCollection<Task>();

            LoadMenu();
            LoadTask();
        }

        #region Properties

        private DialogService dialogService;

        private NavigationService navigationService;

        public String User { get; private set; }

        public LoginViewModel Login { get; private set; }

        //Tasks

        public TaskViewModel NewTask { get; private set; }

        public ObservableCollection<Task> Tasks { get; set; }

        //Menu

        public ObservableCollection<MenuItemViewModel> Menu { get; set; } 

        public MenuItemViewModel CerrarSesion { get; set; }

        //ListTask

        public ObservableCollection<TaskListViewModel> ListTasks { get; set; }

        #endregion

        #region Commands

        public ICommand GoToCommand
        {
            get { return new RelayCommand<string>(GoTo); }
        }

        private async void GoTo(string pageName)
        {
            switch (pageName)
            {
                case "NewTask":
                    NewTask = new TaskViewModel();

                    try
                    {
                        await NewTask.LoadPicker();
                    }
                    catch (Exception ex)
                    {
                        await dialogService.ShowMessage("Error", ex.Message, "Aceptar");
                    }

                    break;
                default:
                    break;
            }
            navigationService.Navigate(pageName);
        }

        public ICommand LogoutCommand
        {
            get { return new RelayCommand(Logout); }
        }

        private void Logout()
        {
            navigationService.SetPage("LoginPage");
        }

        #endregion

        #region Methods

        private void LoadMenu()
        {
            Menu = new ObservableCollection<MenuItemViewModel>();

            Menu.Add(new MenuItemViewModel()
            {

                Icon = "ic_action_donut_large",
                Title = "Tareas Activas",
                PageName = "NewTask"

            });

            Menu.Add(new MenuItemViewModel()
            {

                Icon = "ic_action_check",
                Title = "Tareas Completadas",
                PageName = "NewTask"

            });

            Menu.Add(new MenuItemViewModel()
            {

                Icon = "ic_action_clear",
                Title = "Tareas Canceladas",
                PageName = "NewTask"

            });

            Menu.Add(new MenuItemViewModel()
            {

                Icon = "ic_action_delete",
                Title = "Tareas Eliminadas",
                PageName = "NewTask"

            });

            Menu.Add(new MenuItemViewModel()
            {

                Icon = "ic_action_settings",
                Title = "Settings",
                PageName = "NewTask"

            });

            Menu.Add(new MenuItemViewModel()
            {

                Icon = "ic_action_user",
                Title = "Cerrar Sesión",
                PageName = "CloseSesion"

            });
        }

        private void LoadTask()
        {
            ListTasks = new ObservableCollection<TaskListViewModel>();

            ListTasks.Add(new TaskListViewModel()
            {

                Title = "Esteban Arias",
                IsVisible = false

            });

            ListTasks.Add(new TaskListViewModel()
            {

                Title = "Geovanny Rojas Fhunnez",
                IsVisible = false

            });

            ListTasks.Add(new TaskListViewModel()
            {

                Title = "Santiago Sánchez Madrigal",
                IsVisible = false

            });
        }

        #endregion
    }
}
