﻿using GPIApp.Helpers;
using GPIApp.Models;
using GPIApp.WebApi;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace GPIApp.ViewModels.TaskVM
{
    public class EditTaskViewModel
    {   //variable asunto temporal
        private string issueTemp;


        private DialogService dialogService;
        private NavigationService navigationService;
        private TaskWA taskWA;
        public TaskModel task { get; set; }

        private AfterDayWA afterDayWA;
        private BeforeDaysWA beforeDaysWA;
        private CategoryWA categoryWA;
        private PriorityWA priorityWA;
        private RecurrenceWA recurrenceWA;


        public ObservableCollection<string> afterDayList { get; set; }
        public ObservableCollection<string> beforeDaysList { get; set; }
        public ObservableCollection<string> categoryList { get; set; }
        public ObservableCollection<string> priorityList { get; set; }
        public ObservableCollection<string> recurrenceList { get; set; }

        public EditTaskViewModel()
        {
            dialogService = new DialogService();
            navigationService = new NavigationService();
            taskWA = new TaskWA();
            task = new TaskModel();

            afterDayWA = new AfterDayWA();
            beforeDaysWA = new BeforeDaysWA();
            categoryWA = new CategoryWA();
            priorityWA = new PriorityWA();
            recurrenceWA = new RecurrenceWA();
        }

        public async Task LoadPicker(string issue)
        {
            task = await taskWA.Get(issue);
            issueTemp = task.UserIssue;


            afterDayList = await afterDayWA.Get();
            beforeDaysList = await beforeDaysWA.Get();
            categoryList = await categoryWA.Get();
            priorityList = await priorityWA.Get();
            recurrenceList = await recurrenceWA.Get();
        }

        public async Task<bool> EditTask()
        {
            if (string.IsNullOrEmpty(task.UserIssue))
            {
                await dialogService.ShowMessage("Error", "Debe ingresar un asunto", "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(task.UserResp))
            {
                await dialogService.ShowMessage("Error", "Debe ingresar un responsable", "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(task.UserCopy))
            {
                await dialogService.ShowMessage("Error", "Ingresar el usuario al que se copia la tarea", "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(task.UserCategory))
            {
                await dialogService.ShowMessage("Error", "Debe ingresar una categoría", "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(task.UserPriority))
            {
                await dialogService.ShowMessage("Error", "Debe ingresar la prioridad", "Aceptar");
                return false;
            }
            
            await taskWA.Put(issueTemp, task);
            await dialogService.ShowMessage("Mensaje", "Tarea editada correctamente", "Aceptar");
            return true;
        }
    }
}
