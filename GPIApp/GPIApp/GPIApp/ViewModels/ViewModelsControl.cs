using GalaSoft.MvvmLight.Command;
using GPIApp.Helpers;
using GPIApp.ViewModels.Login;
using GPIApp.ViewModels.MainPage;
using GPIApp.ViewModels.NewTask;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GPIApp.ViewModels
{
    class ViewModelsControl
    {
        #region Main

        //Utilities
        private DialogService dialogService;
        private NavigationService navigationService;

        public ViewModelsControl()
        {
            dialogService = new DialogService();
            navigationService = new NavigationService();

            LoginVM = new LoginViewModel();
        }

        public ICommand GoToCommand
        {
            get { return new RelayCommand<string>(GoTo); }
        }

        private async void GoTo(string pageName)
        {
            switch (pageName)
            {
                case "NewTask":
                    NewTask = new NewTaskViewModel();

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

        #endregion

        #region Login

        public LoginViewModel LoginVM { get; private set; }

        public ICommand LoginCommand
        {
            get { return new RelayCommand(Login); }
        }

        public async void Login()
        {
            if (await LoginVM.Login())
            {
                //load lists and View
                LoadMenu();
                LoadTask();
                navigationService.SetPage("MasterPage");
            }
        }

        #endregion

        #region Menu

        public ObservableCollection<MenuItemViewModel> Menu { get; set; }

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

        #endregion

        #region ListTask

        public ObservableCollection<MainViewModel> ListTasks { get; set; }

        private void LoadTask()
        {
            ListTasks = new ObservableCollection<MainViewModel>();

            ListTasks.Add(new MainViewModel()
            {

                Title = "Esteban Arias",
                IsVisible = false

            });

            ListTasks.Add(new MainViewModel()
            {

                Title = "Geovanny Rojas Fhunnez",
                IsVisible = false

            });

            ListTasks.Add(new MainViewModel()
            {

                Title = "Santiago Sánchez Madrigal",
                IsVisible = false

            });
        }

        #endregion

        #region NewTask

        public NewTaskViewModel NewTask { get; private set; }

        #endregion 
    }
}
