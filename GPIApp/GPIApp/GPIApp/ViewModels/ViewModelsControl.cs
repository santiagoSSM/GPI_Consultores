using GalaSoft.MvvmLight.Command;
using GPIApp.Helpers;
using GPIApp.ViewModels.Login;
using GPIApp.ViewModels.MainPage;
using GPIApp.ViewModels.TaskVM;
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

        public string TaskTemp { get; set; }

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
                            await NewTaskVM.LoadPicker();
                            navigationService.Navigate(pageName);
                            break;
                        }

                    case "MainPage":
                        {
                            await MainVM.LoadListTask();
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
                    MainVM = new MainViewModel();

                    await MainVM.LoadListTask();
                    navigationService.SetPage("MasterPage");
                }
            }
            catch (Exception ex)
            {
                await dialogService.ShowMessage("Error", ex.Message, "Aceptar");
            }
        }

        #endregion

        #region Main

        public MainViewModel MainVM { get; private set; }

        public ICommand TaskListElementCommand
        {
            get { return new RelayCommand<string>(TaskListElement); }
        }

        public async void TaskListElement(string taskIssue)
        {
            try
            {
                var select = await dialogService.ShowOptions("Seleccionar", new string[] { "Ver", "Reasignar", "Editar", "Prorrogar", "Responder", "Delegar", "Crear borrador", "Eliminar borrador" }, "Cancelar");

                switch (select)
                {
                    case "Ver":
                        {
                            //Code
                            break;
                        }
                    case "Reasignar":
                        {
                            //Code
                            break;
                        }
                    case "Editar":
                        {
                            EditTaskVM = new EditTaskViewModel();
                            await EditTaskVM.LoadPicker(taskIssue);
                            navigationService.Navigate("EditTask");
                            break;
                        }
                    case "Prorrogar":
                        {
                            //Code
                            break;
                        }
                    case "Responder":
                        {
                            //Code
                            break;
                        }
                    case "Delegar":
                        {
                            //Code
                            break;
                        }
                    case "Crear borrador":
                        {
                            //Code
                            break;
                        }
                    case "Eliminar borrador":
                        {
                            //Code
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

        #endregion

        #region NewTask

        public EditTaskViewModel EditTaskVM { get; private set; }

        public ICommand EditTaskCommand
        {
            get { return new RelayCommand(EditTask); }
        }

        private async void EditTask()
        {
            try
            {
                await EditTaskVM.EditTask();
                GoTo("MainPage");
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
                    MainVM = new MainViewModel();

                    await MainVM.LoadListTask();
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
