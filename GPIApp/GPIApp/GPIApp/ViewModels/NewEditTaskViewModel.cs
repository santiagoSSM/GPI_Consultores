using GalaSoft.MvvmLight.Command;
using GPIApp.Infraestructure;
using GPIApp.Models;
using GPIApp.Views.PopUps.Generic;
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
        public TaskUserDraftModel Task { get; set; }
        public TaskPickersModel TaskPickers { get; set; }

        public NewEditTaskViewModel(IVMContainer inter, string title)
        {
            navServ = new NavigationService(inter);
            Title = title;
            Task = new TaskUserDraftModel();
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

            Task.IdUser = editTask.IdUser;
            Task.IsDraft = editTask.IsDraft;

            //Task

            Task.IdTask = editTask.IdTask;
            Task.TextIssue = editTask.TextIssue;
            Task.TextDescription = editTask.TextDescription;
            Task.NameRespUser = editTask.NameRespUser;
            Task.NameCopyUser = editTask.NameCopyUser;
            Task.TextCategory = editTask.TextCategory;
            Task.IsAprob = editTask.IsAprob;
            Task.TextPriority = editTask.TextPriority;

            //Recurrence

            Task.TextRecu = editTask.TextRecu;
            Task.BeforeDays = editTask.BeforeDays;
            Task.IsCancelRecu = editTask.IsCancelRecu;

            //Daily,Montly,Annual Vector info

            Task.SelectTimeOfRecu = editTask.SelectTimeOfRecu;
            Task.TimeOfRecu0 = editTask.TimeOfRecu0;
            Task.TimeOfRecu1 = editTask.TimeOfRecu1;
            Task.TimeOfRecu2 = editTask.TimeOfRecu2;

            //Final Date

            Task.TextFinalDate = editTask.TextFinalDate;
            Task.NumRecu = editTask.NumRecu;
            Task.ContractExp = editTask.ContractExp;
        }

        public ICommand SaveTaskCommand
        {
            get { return new RelayCommand<string>(SaveTask); }
        }

        public async void SaveTask(string isDraft)
        {
            //Todo validacion de entradas de informacion
            /*if (string.IsNullOrEmpty(Task.TextIssue))
            {
                await DialogService.ShowMessage("Error", "Debe ingresar un asunto", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(Task.TextIssue))
            {
                await DialogService.ShowMessage("Error", "Debe ingresar un responsable", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(Task.TextIssue))
            {
                await DialogService.ShowMessage("Error", "Ingresar el usuario al que se copia la tarea", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(Task.TextIssue))
            {
                await DialogService.ShowMessage("Error", "Debe ingresar una categoría", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(Task.TextIssue))
            {
                await DialogService.ShowMessage("Error", "Debe ingresar la prioridad", "Aceptar");
                return;
            }*/

            //Todo informacion de pruebas
            #region Recurrencia
            //Recurrence

            Task.TextRecu = "Ninguna";
            Task.BeforeDays = 1;
            Task.IsCancelRecu = false;

            //Daily,Montly,Annual Vector info

            Task.SelectTimeOfRecu = false;
            Task.TimeOfRecu0 = 0;
            Task.TimeOfRecu1 = 0;
            Task.TimeOfRecu2 = 0;

            //Final Date

            Task.TextFinalDate = "Sin fecha de finalización";
            Task.NumRecu = 0;
            Task.ContractExp = new DateTime(2010, 8, 10);
            #endregion

            Task.IdUser = UserLogged.Value.IdUser;
            Task.IsDraft = isDraft == "true";

            try
            {
                await PopupNavigation.PushAsync(new ActivityIndicatorPopUp());//Todo cambiar por guardando
                if (await TaskWACtrl.Post(Task))
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
    }
}
