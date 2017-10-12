using GalaSoft.MvvmLight.Command;
using GPIApp.Helpers;
using GPIApp.ViewModels.Login;
using GPIApp.ViewModels.MainPage;
using GPIApp.ViewModels.NewTask;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GPIApp.ViewModels
{
    class ViewModelsControl
    {
        #region VMControl

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
            try
            {
                switch (pageName)
                {
                    case "NewTask":
                        {
                            NewTaskVM = new NewTaskViewModel();
                            await LoadPicker();
                            navigationService.Navigate(pageName);
                            break;
                        }

                    case "MainPage":
                        {
                            await MainVM.LoadTask();
                            navigationService.Navigate(pageName);
                            break;
                        }

                    case "CloseSesion":
                        {
                            navigationService.SetPage("LoginPage");
                            break;
                        }

                    default:
                        {
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                await dialogService.ShowMessage("Error", ex.Message, "Aceptar");
            }
        }

        #endregion

        #region Login

        public LoginViewModel LoginVM { get; private set; }

        public ICommand LoginCommand
        {
            get { return new RelayCommand(Login); }
        }

        private async void Login()
        {
            try
            {
                if (await LoginVM.Login())
                {
                    //load lists and View
                    LoadMenu();

                    MainVM = new MainViewModel();

                    await MainVM.LoadTask();
                    navigationService.SetPage("MasterPage");
                }
            }
            catch (Exception ex)
            {
                await dialogService.ShowMessage("Error", ex.Message, "Aceptar");
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

        #region Main

        public MainViewModel MainVM { get; private set; }

        #endregion

        #region NewTask

        public NewTaskViewModel NewTaskVM { get; private set; }

        public ICommand NewTaskCommand
        {
            get { return new RelayCommand(NewTask); }
        }

        private async void NewTask()
        {
            try
            {
                await NewTaskVM.NewTask();
                GoTo("MainPage");
            }
            catch (Exception ex)
            {
                await dialogService.ShowMessage("Error", ex.Message, "Aceptar");
            }
        }

        private async Task LoadPicker()
        {
            try
            {
                await NewTaskVM.LoadPicker();
            }
            catch (Exception ex)
            {
                await dialogService.ShowMessage("Error", ex.Message, "Aceptar");
            }
        }

        #endregion

        #region INIT
        public ICommand INITCommand
        {
            get { return new RelayCommand(INIT); }
        }

        private async void INIT()
        {
            try
            {
                if (true)
                {
                    //load lists and View
                    LoadMenu();

                    MainVM = new MainViewModel();

                    await MainVM.LoadTask();
                    navigationService.SetPage("MasterPage");
                }
            }
            catch (Exception ex)
            {
                await dialogService.ShowMessage("Error", ex.Message, "Aceptar");
            }
        }
        #endregion
    }
}
