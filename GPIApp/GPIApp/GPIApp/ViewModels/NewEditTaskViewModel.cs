using GalaSoft.MvvmLight.Command;
using GPIApp.Infraestructure;
using GPIApp.Models;
using GPIApp.Views.PopUps.Generic;
using GPIApp.Views.Task;
using GPIApp.WebApi;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GPIApp.ViewModels
{
    public class NewEditTaskViewModel
    {
        NavigationService navServ;
        public string Title { get; private set; }
        public TaskUserDraftModel TaskBind { get; set; }
        public TaskPickersModel TaskPickers { get; set; }

        public NewEditTaskViewModel(IVMContainer inter, string title)
        {
            navServ = new NavigationService(inter);
            Title = title;
            TaskBind = new TaskUserDraftModel();
            TaskPickers = new TaskPickersModel();
        }

        public async Task LoadPickers()
        {
            TaskPickers = await TaskWACtrl.GetTaskPickers();
        }

        public async Task LoadEditTask(int idTask)
        {
            var editTask = await TaskWACtrl.GetEditTask(idTask);

            TaskPickers = editTask.TaskPickers;

            //NoTaskAttributes

            TaskBind.IdUser = editTask.IdUser;
            TaskBind.IsDraft = editTask.IsDraft;

            //Task

            TaskBind.IdTask = editTask.IdTask;
            TaskBind.TextIssue = editTask.TextIssue;
            TaskBind.TextDescription = editTask.TextDescription;
            TaskBind.NameRespUser = editTask.NameRespUser;
            TaskBind.NameCopyUser = editTask.NameCopyUser;
            TaskBind.TextCategory = editTask.TextCategory;
            TaskBind.IsAprob = editTask.IsAprob;
            TaskBind.TextPriority = editTask.TextPriority;

            //Recurrence

            TaskBind.TextRecu = editTask.TextRecu;
            TaskBind.BeforeDays = editTask.BeforeDays;
            TaskBind.IsCancelRecu = editTask.IsCancelRecu;

            //Daily,Montly,Annual Vector info

            TaskBind.SelectTimeOfRecu = editTask.SelectTimeOfRecu;
            TaskBind.TimeOfRecu0 = editTask.TimeOfRecu0;
            TaskBind.TimeOfRecu1 = editTask.TimeOfRecu1;
            TaskBind.TimeOfRecu2 = editTask.TimeOfRecu2;

            //Final Date

            TaskBind.TextFinalDate = editTask.TextFinalDate;
            TaskBind.NumRecu = editTask.NumRecu;
            TaskBind.ContractExp = editTask.ContractExp;
        }

        public ICommand SaveTaskCommand
        {
            get { return new RelayCommand<string>(SaveTask); }
        }

        private async void SaveTask(string isDraft)
        {
            //TaskBind.TextDescription = editTask.TextDescription;//Optional?

            //Task
            if (string.IsNullOrEmpty(TaskBind.TextIssue))
            {
                await DialogService.ShowMessage("Error", "Debe ingresar un asunto", "Aceptar");
                return;
            }
			
			if (string.IsNullOrEmpty(TaskBind.NameRespUser))
            {
                await DialogService.ShowMessage("Error", "Debe ingresar un responsable", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(TaskBind.NameCopyUser))
            {
                await DialogService.ShowMessage("Error", "Ingresar el usuario al que se copia la tarea", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(TaskBind.TextCategory))
            {
                await DialogService.ShowMessage("Error", "Debe ingresar una categoría", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(TaskBind.TextPriority))
            {
                await DialogService.ShowMessage("Error", "Debe ingresar la prioridad", "Aceptar");
                return;
            }

            //Todo informacion de pruebas recurrencia
            #region Recurrencia
            //Recurrence

            TaskBind.TextRecu = "Ninguna";
            TaskBind.BeforeDays = 1;
            TaskBind.IsCancelRecu = false;

            //Daily,Montly,Annual Vector info

            TaskBind.SelectTimeOfRecu = false;
            TaskBind.TimeOfRecu0 = 0;
            TaskBind.TimeOfRecu1 = 0;
            TaskBind.TimeOfRecu2 = 0;

            //Final Date

            TaskBind.TextFinalDate = "Sin fecha de finalización";
            TaskBind.NumRecu = 0;
            TaskBind.ContractExp = new DateTime(2010, 8, 10);
            #endregion

            TaskBind.IdUser = UserLogged.Value.IdUser;
            TaskBind.IsDraft = isDraft == "true";

            try
            {
                await PopupNavigation.PushAsync(new ActivityIndicatorPopUp());//Todo cambiar por guardando
                if (await TaskWACtrl.Post(TaskBind))
                {
                    await DialogService.ShowMessage("Mensaje", "Tarea registrada correctamente", "Aceptar");
                    await navServ.Navigate("MainPage");
                }
                else
                {
                    await DialogService.ShowMessage("Error", "Error al guardar la tarea", "Aceptar");
                }
            }
            catch (Exception e)
            {
                await DialogService.ShowMessage("Error", e.Message, "Aceptar");
            }
            finally
            {
                await PopupNavigation.PopAllAsync();
            }
        }

        ////Recurrence

        public ICommand TaskRecuCommand
        {
            get { return new RelayCommand (TaskRecu); }
        }

        private async void TaskRecu()

        {
            //Todo cambiar estructura de pickers y guardado
            try
            {
                var select = await DialogService.ShowOptions("Seleccionar", new string[] { "Ninguna", "Diaria", "Semanal", "Mensual", "Anual" }, "Cancelar");

                switch (select)
                {
                    case "Ninguna":
                        {
                            //Init the objectClass
                            TaskBind.TextRecu= "Ninguna";
                            var temp = new NoneRecurrence() { CloseWhenBackgroundIsClicked = true };
                            await PopupNavigation.PushAsync(temp);

                            break;
                        }
                    case "Diaria":
                        {
                            TaskBind.TextRecu = "Diaria";
                            var temp = new DailyRecurrence() { CloseWhenBackgroundIsClicked = true };
                            await PopupNavigation.PushAsync(temp);

                            break;
                        }
                    case "Semanal":
                        {

                            TaskBind.TextRecu = "Semanal";
                            var temp = new WeeklyRecurrence() { CloseWhenBackgroundIsClicked = true };
                            await PopupNavigation.PushAsync(temp);
                            //Init the objectClass
                            //NewTaskVM.task.UserRecurrence = "Semanal";
                            //NewTaskVM.task.ObjRecurrence = new WeeklyTaskModel();

                            //var temp = new WeeklyRecurrence() { CloseWhenBackgroundIsClicked = true };
                            //await PopupNavigation.PushAsync(temp);
                            break;
                        }
                    case "Mensual":
                        {

                            TaskBind.TextRecu = "Mensual";
                            var temp = new MonthlyRecurrence() { CloseWhenBackgroundIsClicked = true };
                            await PopupNavigation.PushAsync(temp);
                            //Init the objectClass
                            //NewTaskVM.task.UserRecurrence = "Mensual";
                            //NewTaskVM.task.ObjRecurrence = new MonthlyTaskModel();

                            //var temp = new MonthlyRecurrence() { CloseWhenBackgroundIsClicked = true };
                            //await PopupNavigation.PushAsync(temp);

                            break;
                        }
                    case "Anual":
                        {

                            TaskBind.TextRecu = "Anual";
                            var temp = new AnnualRecurrence() { CloseWhenBackgroundIsClicked = true };
                            await PopupNavigation.PushAsync(temp);
                            //Init the objectClass
                            //NewTaskVM.task.UserRecurrence = "Anual";
                            //NewTaskVM.task.ObjRecurrence = new AnnualTaskModel();

                            //var temp = new AnnualRecurrence() { CloseWhenBackgroundIsClicked = true };
                            //await PopupNavigation.PushAsync(temp);
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
                await DialogService.ShowMessage("Error", ex.Message, "Aceptar");
            }
        }


    }
}
