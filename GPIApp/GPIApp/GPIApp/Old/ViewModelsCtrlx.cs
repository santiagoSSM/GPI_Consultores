using GalaSoft.MvvmLight.Command;
using GPIApp.Helpers;
using GPIApp.Models.Recurrence;
using GPIApp.ViewModels.Login;
using GPIApp.ViewModels.MainPage;
using GPIApp.Views.NewTask;
using GPIApp.ViewModels.TaskVM;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GPIApp.ViewModels
{
    class ViewModelsCtrlx
    {
        #region VMControl

        //Utilities
        private DialogService dialogService;

        public string TaskTemp { get; set; }

        public ViewModelsCtrl()
        {
            dialogService = new DialogService();
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
                    case "ActiveTask":
                        {
                            await MainVM.LoadListTask('a');
                            NavigationService.Navigate("MainPage");
                            break;
                        }
                    case "NewTask":
                        {
                            NewTaskVM = new NewTaskViewModel();
                            await NewTaskVM.LoadPicker();
                            NavigationService.Navigate("NewTask");
                            break;
                        }

                    case "MainPage":
                        {
                            await MainVM.LoadListTask('l');
                            NavigationService.Navigate("MainPage");
                            break;
                        }

                    case "CloseSesion":
                        {
                            await NavigationService.SetPageAsync("LoginPage");
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

        public LoginViewModel LoginVM
        {
            get
            {
                return VMContainer.LoginVM;
            }
        }

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
                    //MainVM = new MainViewModel();

                    //await MainVM.LoadListTask('l');
                    await NavigationService.SetPageAsync("MasterPage");
                }
            }
            catch (Exception ex)
            {
                await dialogService.ShowMessage("Error", ex.Message, "Aceptar");
            }
        }

        #endregion

        #region Main

        public MainViewModel MainVM
        {
            get
            {
                return VMContainer.MainVM;
            }
        }

        public ICommand TaskListElementCommand
        {
            get { return new RelayCommand<int>(TaskListElement); }
        }

        public async void TaskListElement(int taskId)
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
                            await EditTaskVM.LoadPicker(taskId);
                            NavigationService.Navigate("EditTask");
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

        public ICommand NewTaskDraftCommand
        {
            get { return new RelayCommand(NewTaskDraft); }
        }

        private async void NewTaskDraft()
        {
            try
            {
                if (await NewTaskVM.NewTaskDraft())
                {
                    GoTo("MainPage");
                }
            }
            catch (Exception ex)
            {
                await dialogService.ShowMessage("Error", ex.Message, "Aceptar");
            }
        }

        public ICommand NewTaskCommand
        {
            get { return new RelayCommand(NewTask); }
        }

        private async void NewTask()
        {
            try
            {
                if (await NewTaskVM.NewTask())
                {
                    GoTo("MainPage");
                }
            }
            catch (Exception ex)
            {
                await dialogService.ShowMessage("Error", ex.Message, "Aceptar");
            }
        }

        //NoneRecurrence

        public ICommand NewTaskUserRecuCommand
        {
            get { return new RelayCommand<string>(NewTaskUserRecu); }
        }

        private async void NewTaskUserRecu(string pageName)

        {
            try
            {
                var select = await dialogService.ShowOptions("Seleccionar", new string[] { "Ninguna", "Diaria", "Semanal", "Mensual", "Anual" }, "Cancelar");

                switch (select)
                {
                    case "Ninguna":
                        {
                            //Init the objectClass
                            NewTaskVM.task.UserRecurrence = "Ninguna";
                            NewTaskVM.task.ObjRecurrence = new NoneTaskModel();

                            var temp = new NoneRecurrence() { CloseWhenBackgroundIsClicked = true };
                            await PopupNavigation.PushAsync(temp);

                            break;
                        }
                    case "Diaria":
                        {
                            //Init the objectClass
                            NewTaskVM.task.UserRecurrence = "Diaria";
                            NewTaskVM.task.ObjRecurrence = new DailyTaskModel();

                            var temp = new DailyRecurrence() { CloseWhenBackgroundIsClicked = true };
                            await PopupNavigation.PushAsync(temp);

                            break;
                        }
                    case "Semanal":
                        {
                            //Init the objectClass
                            NewTaskVM.task.UserRecurrence = "Semanal";
                            NewTaskVM.task.ObjRecurrence = new WeeklyTaskModel();

                            var temp = new WeeklyRecurrence() { CloseWhenBackgroundIsClicked = true };
                            await PopupNavigation.PushAsync(temp);
                            break;
                        }
                    case "Mensual":
                        {
                            //Init the objectClass
                            NewTaskVM.task.UserRecurrence = "Mensual";
                            NewTaskVM.task.ObjRecurrence = new MonthlyTaskModel();

                            var temp = new MonthlyRecurrence() { CloseWhenBackgroundIsClicked = true };
                            await PopupNavigation.PushAsync(temp);

                            break;
                        }
                    case "Anual":
                        {
                            //Init the objectClass
                            NewTaskVM.task.UserRecurrence = "Anual";
                            NewTaskVM.task.ObjRecurrence = new AnnualTaskModel();

                            var temp = new AnnualRecurrence() { CloseWhenBackgroundIsClicked = true };
                            await PopupNavigation.PushAsync(temp);
                            break;
                        }
                    default:
                        {
                            throw new Exception("Error en el tipo de recurrencia");
                        }
                }
            }
            catch (Exception ex)
            {
                await dialogService.ShowMessage("Error", ex.Message, "Aceptar");
            }
        }

        #endregion

        #region EditTask

        public EditTaskViewModel EditTaskVM { get; private set; }

        public ICommand EditTaskDraftCommand
        {
            get { return new RelayCommand(EditTaskDraft); }
        }

        private async void EditTaskDraft()
        {
            try
            {
                if (await EditTaskVM.EditTaskDraft())
                {
                    GoTo("MainPage");
                }
            }
            catch (Exception ex)
            {
                await dialogService.ShowMessage("Error", ex.Message, "Aceptar");
            }
        }

        public ICommand EditTaskCommand
        {
            get { return new RelayCommand(EditTask); }
        }

        private async void EditTask()
        {
            try
            {
                if (await EditTaskVM.EditTask())
                {
                    GoTo("MainPage");
                }
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
                    //MainVM = new MainViewModel();

                    //await MainVM.LoadListTask('l');
                    await NavigationService.SetPageAsync("MasterPage");
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
