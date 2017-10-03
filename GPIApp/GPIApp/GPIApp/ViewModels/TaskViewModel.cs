﻿using GalaSoft.MvvmLight.Command;
using GPIApp.Helpers;
using GPIApp.Models;
using GPIApp.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GPIApp.ViewModels
{
    public class TaskViewModel
    {
        private DialogService dialogService;
        private TaskWA taskWA;
        public TaskAPP task { get; set; }

        private AfterDayWA afterDayWA;
        private BeforeDaysWA beforeDaysWA;
        private CategoryWA categoryWA;
        private PriorityWA priorityWA;
        private RecurrenceWA recurrenceWA;

        
        public List<string> afterDayList { get; set; }
        public List<string> beforeDaysList { get; set; }
        public List<string> categoryList { get; set; }
        public List<string> priorityList { get; set; }
        public List<string> recurrenceList { get; set; }

        public TaskViewModel()
        {
            dialogService = new DialogService();
            taskWA = new TaskWA();
            task = new TaskAPP();

            afterDayWA = new AfterDayWA();
            beforeDaysWA = new BeforeDaysWA();
            categoryWA = new CategoryWA();
            priorityWA = new PriorityWA();
            recurrenceWA = new RecurrenceWA();
        }

        public async Task LoadPicker()
        {
            afterDayList = await afterDayWA.Get();
            beforeDaysList = await beforeDaysWA.Get();
            categoryList = await categoryWA.Get();
            priorityList = await priorityWA.Get();
            recurrenceList = await recurrenceWA.Get();
        }

        public ICommand NewTaskCommand
        {
            get { return new RelayCommand(NewTask); }
        }

        public async void NewTask()
        {
            if (string.IsNullOrEmpty(task.UserIssue))
            {
                await dialogService.ShowMessage("Error", "Debe ingresar un asunto", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(task.UserResp))
            {
                await dialogService.ShowMessage("Error", "Debe ingresar un responsable", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(task.UserCopy))
            {
                await dialogService.ShowMessage("Error", "Ingresar el usuario al que se copia la tarea", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(task.UserCategory))
            {
                await dialogService.ShowMessage("Error", "Debe ingresar una categoría", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(task.UserPriority))
            {
                await dialogService.ShowMessage("Error", "Debe ingresar la prioridad", "Aceptar");
                return;
            }

            try
            {
                await taskWA.Post(task);
                await dialogService.ShowMessage("Mensaje", "Tarea registrada correctamente", "Aceptar");
            }
            catch (Exception ex)
            {
                await dialogService.ShowMessage("Error", ex.Message, "Aceptar");
            }
        }
    }
}
