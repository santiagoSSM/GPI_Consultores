﻿using GalaSoft.MvvmLight.Command;
using GPIApp.Infraestructure;
using GPIApp.Models;
using GPIApp.Views.PopUps.Generic;
using GPIApp.Views.Task;
using GPIApp.WebApi;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GPIApp.ViewModels
{
    public class NewEditTaskViewModel : INotifyPropertyChanged
    {
        NavigationService navServ;
        private TaskPickersModel taskPickers;
        public bool isInitPopUp = true;//Variable that determines the execution of this method as protection for the binding context
        public bool IsNewTask { get; private set; }
        public string Title { get; private set; }

        //Todo usuarios temporales mejorar con seleccion multiple mediante color

        public string User { get;  set; }
        public string Copy { get; set; }

        #region Pop-up control

        #region Clear and Update Recurrence

        private void ClearRecu()
        {
            TaskBind.BeforeDays = 0;
            TaskBind.IsCancelRecu = false;

            //Daily,Montly,Annual Vector info

            TaskBind.SelectTimeOfRecu = false;
            TaskBind.TimeOfRecu0 = 0;
            TaskBind.TimeOfRecu1 = 0;
            TaskBind.TimeOfRecu2 = 0;

            //Final Date

            TaskBind.FinalDate = 0;
            TaskBind.NumRecu = 0;
            TaskBind.ContractExp = DateTime.Now;
        }

        private void NoneRecuClear()
        {
            ClearRecu();
            OnPropertyChanged("TaskBind");
        }

        private void DailyRecuClear()
        {
            ClearRecu();
            OnPropertyChanged("TaskBind");
            FinalDateIndexC = 0;
        }

        private void WeeklyRecuClear()
        {
            ClearRecu();
            OnPropertyChanged("TaskBind");
            FinalDateIndexC = 0;
        }

        private void MontlyRecuClear()
        {
            ClearRecu();
            OnPropertyChanged("TaskBind");
            SelectTimeOfRecuC = false;
            FinalDateIndexC = 0;
        }

        private void AnnualRecuClear()
        {
            ClearRecu();
            OnPropertyChanged("TaskBind");
            SelectTimeOfRecuC = false;
            FinalDateIndexC = 0;
        }

        #endregion

        #region hide or show elements

        private void NoneRecuControl()
        {
            VisEverSTC = false;
            OnPropertyChanged("VisEverSTC");

            VisDayOfWeekSTC = false;
            OnPropertyChanged("VisDayOfWeekSTC");

            VisSelectRecuMontlySTC = false;
            OnPropertyChanged("VisSelectRecuMontlySTC");

            VisSelectRecuAnnualSTC = false;
            OnPropertyChanged("VisSelectRecuAnnualSTC");

            VisFinalDateSTC = false;
            OnPropertyChanged("VisFinalDateSTC");

            VisNumRecuSTC = false;
            OnPropertyChanged("VisNumRecuSTC");

            VisContractExpSTC = true;
            OnPropertyChanged("VisContractExpSTC");

            VisContractExpLC = true;
            OnPropertyChanged("VisContractExpLC");
        }

        private void DailyRecuControl()
        {
            TextEverLC = "Días";
            OnPropertyChanged("TextEverLC");

            VisEverSTC = true;
            OnPropertyChanged("VisEverSTC");

            VisDayOfWeekSTC = false;
            OnPropertyChanged("VisDayOfWeekSTC");

            VisSelectRecuMontlySTC = false;
            OnPropertyChanged("VisSelectRecuMontlySTC");

            VisSelectRecuAnnualSTC = false;
            OnPropertyChanged("VisSelectRecuAnnualSTC");

            VisFinalDateSTC = true;
            OnPropertyChanged("VisFinalDateSTC");
        }

        private void WeeklyRecuControl()
        {
            TextEverLC = "Semana(s)";
            OnPropertyChanged("TextEverLC");

            VisEverSTC = true;
            OnPropertyChanged("VisEverSTC");

            VisDayOfWeekSTC = true;
            OnPropertyChanged("VisDayOfWeekSTC");

            VisSelectRecuMontlySTC = false;
            OnPropertyChanged("VisSelectRecuMontlySTC");

            VisSelectRecuAnnualSTC = false;
            OnPropertyChanged("VisSelectRecuAnnualSTC");

            VisFinalDateSTC = true;
            OnPropertyChanged("VisFinalDateSTC");
        }

        private void MontlyRecuControl()
        {
            VisEverSTC = false;
            OnPropertyChanged("VisEverSTC");

            VisDayOfWeekSTC = false;
            OnPropertyChanged("VisDayOfWeekSTC");

            VisSelectRecuMontlySTC = true;
            OnPropertyChanged("VisSelectRecuMontlySTC");

            VisSelectRecuAnnualSTC = false;
            OnPropertyChanged("VisSelectRecuAnnualSTC");

            VisMontlyLC = true;
            OnPropertyChanged("VisMontlyLC");

            VisFinalDateSTC = true;
            OnPropertyChanged("VisFinalDateSTC");
        }

        private void AnnualRecuControl()
        {
            VisEverSTC = false;
            OnPropertyChanged("VisEverSTC");

            VisDayOfWeekSTC = false;
            OnPropertyChanged("VisDayOfWeekSTC");

            VisSelectRecuMontlySTC = false;
            OnPropertyChanged("VisSelectRecuMontlySTC");

            VisSelectRecuAnnualSTC = true;
            OnPropertyChanged("VisSelectRecuAnnualSTC");

            VisMontlyLC = false;
            OnPropertyChanged("VisMontlyLC");

            VisFinalDateSTC = true;
            OnPropertyChanged("VisFinalDateSTC");
        }

        private void FinalDateControl(int idFinalDateSelect)
        {
            switch (idFinalDateSelect)
            {
                //Sin Fecha de Finalización
                case 0:
                    {
                        VisNumRecuSTC = false;
                        OnPropertyChanged("VisNumRecuSTC");

                        VisContractExpSTC = false;
                        OnPropertyChanged("VisContractExpSTC");

                        VisContractExpLC = false;
                        OnPropertyChanged("VisContractExpLC");
                        break;
                    }
                //Finaliza Después de
                case 1:
                    {
                        VisNumRecuSTC = true;
                        OnPropertyChanged("VisNumRecuSTC");

                        VisContractExpSTC = false;
                        OnPropertyChanged("VisContractExpSTC");

                        VisContractExpLC = false;
                        OnPropertyChanged("VisContractExpLC");
                        break;
                    }
                //Finaliza el
                case 2:
                    {
                        VisNumRecuSTC = false;
                        OnPropertyChanged("VisNumRecuSTC");

                        VisContractExpSTC = true;
                        OnPropertyChanged("VisContractExpSTC");

                        VisContractExpLC = false;
                        OnPropertyChanged("VisContractExpLC");
                        break;
                    }
            }
        }

        #endregion

        #region Pickers Control

        public string RecuC
        {
            get
            {
                return TaskBind.TextRecu;
            }

            set
            {
                TaskBind.TextRecu = value;
                OnPropertyChanged("RecuC");
                ConfigPopup(value);
            }
        }

        private void ConfigPopup(string TextRecu)
        {
            switch (taskPickers.ListRecu.FirstOrDefault(x => x.TextValue == TextRecu).IdValue)
            {
                //None
                case 0:
                    {
                        if (!isInitPopUp)
                        {
                            NoneRecuClear();
                        }
                        NoneRecuControl();
                        break;
                    }
                //Daily
                case 1:
                    {
                        if (!isInitPopUp)
                        {
                            DailyRecuClear();
                        }
                        DailyRecuControl();
                        FinalDateControl(TaskBind.FinalDate);
                        break;
                    }
                //Weekly
                case 2:
                    {
                        if (!isInitPopUp)
                        {
                            WeeklyRecuClear();
                        }
                        WeeklyRecuControl();
                        FinalDateControl(TaskBind.FinalDate);
                        break;
                    }
                //Monthly
                case 3:
                    {
                        if (!isInitPopUp)
                        {
                            MontlyRecuClear();
                        }
                        MontlyRecuControl();
                        FinalDateControl(TaskBind.FinalDate);
                        break;
                    }
                //Annual
                case 4:
                    {
                        if (!isInitPopUp)
                        {
                            AnnualRecuClear();
                        }
                        AnnualRecuControl();
                        FinalDateControl(TaskBind.FinalDate);
                        break;
                    }
            }
        }

        public bool SelectTimeOfRecuC
        {
            get
            {
                return TaskBind.SelectTimeOfRecu;
            }

            set
            {
                TaskBind.SelectTimeOfRecu = value;
                OnPropertyChanged("SelectTimeOfRecuC");
                if (!isInitPopUp)
                {
                    DayOrWeekIntC = 0;
                }
            }
        }

        public int DayOrWeekIntC
        {
            get
            {
                return TaskBind.TimeOfRecu0;
            }

            set
            {
                TaskBind.TimeOfRecu0 = value;
                OnPropertyChanged("DayOrWeekIntC");
                OnPropertyChanged("DayOrWeekTextC");
            }
        }

        public string DayOrWeekTextC
        {
            get
            {
                if (TaskBind.SelectTimeOfRecu)
                {
                    return ((TaskBind.TimeOfRecu0 + 1).ToString() + "°");
                }
                else
                {
                    return (TaskBind.TimeOfRecu0 + 1).ToString();
                }
            }
        }  

        public int FinalDateIndexC
        {
            get
            {
                return TaskBind.FinalDate;
            }

            set
            {
                TaskBind.FinalDate = value;
                OnPropertyChanged("FinalDateIndexC");
                if (!isInitPopUp)
                {
                    FinalDateControl(value);
                }
            }
        }

        #endregion

        #region Properties

        public string TextEverLC { get; set; }
        public bool VisEverSTC { get; set; }
        public bool VisDayOfWeekSTC { get; set; }
        public bool VisSelectRecuMontlySTC { get; set; }
        public bool VisSelectRecuAnnualSTC { get; set; }
        public bool VisMontlyLC { get; set; }
        public bool VisFinalDateSTC { get; set; }
        public bool VisNumRecuSTC { get; set; }
        public bool VisContractExpSTC { get; set; }
        public bool VisContractExpLC { get; set; }

        #endregion

        #region Variables
        public ObservableCollection<string> DaysText { get; private set; }
        public ObservableCollection<string> Days { get; private set; }
        public ObservableCollection<string> Weeks { get; private set; }
        public ObservableCollection<string> Months { get; private set; }
        #endregion

        #endregion

        public TaskBindingModel TaskBind { get; set; }
        public TaskPickersBindModel TaskPickers { get; set; }

        public NewEditTaskViewModel(IVMContainer inter, bool isNewTask)
        {
            navServ = new NavigationService(inter);
            taskPickers = new TaskPickersModel();
            IsNewTask = isNewTask;
            Days = new ObservableCollection<string>();
            DaysText = new ObservableCollection<string>()
            {
                "Domingo",
                "Lunes",
                "Martes",
                "Miércoles",
                "Jueves",
                "Viernes",
                "Sábado"
            };
            Weeks = new ObservableCollection<string>()
            {
                "Primera",
                "Segunda",
                "Tercera",
                "Cuarta",
                "Quinta"
            };
            Months = new ObservableCollection<string>()
            {
                "Enero",
                "Febrero",
                "Marzo",
                "Abril",
                "Mayo",
                "Junio",
                "Julio",
                "Agosto",
                "Septiembre",
                "Octubre",
                "Noviembre",
                "Diciembre"
            };

            for (int i = 1; i <= 31; i++)
            {
                Days.Add(i.ToString());
            }

            if (IsNewTask)
            {
                Title = "Nueva Tarea";
            }
            else
            {
                Title = "Editar Tarea";
            }

            TaskBind = new TaskBindingModel();
        }

        public async Task LoadNewTask()
        {
            taskPickers = await TaskWACtrl.GetTaskPickers();
            TaskPickers = new TaskPickersBindModel(taskPickers);

            TaskBind.TextRecu = taskPickers.ListRecu.First().TextValue;
        }

        public async Task LoadEditTask(int idTask)
        {
            var editTask = await TaskWACtrl.GetEditTask(idTask);

            taskPickers = editTask.TaskPickers;
            TaskPickers = new TaskPickersBindModel(taskPickers);

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

            TaskBind.FinalDate = editTask.FinalDate;
            TaskBind.NumRecu = editTask.NumRecu;
            TaskBind.ContractExp = editTask.ContractExp;


            //Todo usuarios temporales mejorar con seleccion multiple mediante color

            User = TaskBind.NameRespUser.FirstOrDefault();
            Copy = TaskBind.NameCopyUser.FirstOrDefault();
        }

        public ICommand SaveTaskCommand
        {
            get { return new RelayCommand<string>(SaveTask); }
        }

        private async void SaveTask(string isDraft)
        {
            //Todo usuarios temporales mejorar con seleccion multiple mediante color

            TaskBind.NameRespUser = new ObservableCollection<string>()
            {
                User
            };

            TaskBind.NameCopyUser = new ObservableCollection<string>()
            {
                Copy
            };

            //Todo TaskBind.TextDescription = editTask.TextDescription;//Optional?

            //Task
            if (string.IsNullOrEmpty(TaskBind.TextIssue))
            {
                await DialogService.ShowMessage("Error", "Debe ingresar un asunto", "Aceptar");
                return;
            }

            if (TaskBind.NameRespUser == null || TaskBind.NameRespUser.Count <= 0)
            {
                await DialogService.ShowMessage("Error", "Debe ingresar un responsable", "Aceptar");
                return;
            }

            if (TaskBind.NameCopyUser == null || TaskBind.NameCopyUser.Count <= 0)
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

            try
            {
                await PopupNavigation.PushAsync(new ActivityIndicatorPopUp("Guardando"));

                TaskBind.IdUser = UserLogged.Value.IdUser;
                TaskBind.IsDraft = isDraft == "true";

                #region Convertion Users Name to Id List

                ObservableCollection<int> idRespUser = new ObservableCollection<int>();

                foreach (string element in TaskBind.NameRespUser)
                {
                    idRespUser.Add(taskPickers.ListUser.FirstOrDefault(x => x.NameUser == element).IdUser);
                }

                ObservableCollection<int> idCopyUser = new ObservableCollection<int>();

                foreach (string element in TaskBind.NameCopyUser)
                {
                    idCopyUser.Add(taskPickers.ListUser.FirstOrDefault(x => x.NameUser == element).IdUser);
                }

                #endregion

                if (await TaskWACtrl.Post(new TaskModel
                {
                    //NoTaskAttributes

                    IdUser = TaskBind.IdUser,
                    IsDraft = TaskBind.IsDraft,

                    //Task

                    IdTask = TaskBind.IdTask,
                    TextIssue = TaskBind.TextIssue,
                    TextDescription = TaskBind.TextDescription,
                    IdRespUser = idRespUser,
                    IdCopyUser = idCopyUser,
                    IdCategory = taskPickers.ListCategory.FirstOrDefault(x => x.TextValue == TaskBind.TextCategory).IdValue,
                    IsAprob = TaskBind.IsAprob,
                    IdPriority = taskPickers.ListPriority.FirstOrDefault(x => x.TextValue == TaskBind.TextPriority).IdValue,

                    //Recurrence

                    IdRecu = taskPickers.ListRecu.FirstOrDefault(x => x.TextValue == TaskBind.TextRecu).IdValue,//
                    BeforeDays = TaskBind.BeforeDays,//
                    IsCancelRecu = TaskBind.IsCancelRecu,//

                    //Daily,Montly,Annual

                    SelectTimeOfRecu = TaskBind.SelectTimeOfRecu,
                    TimeOfRecu0 = TaskBind.TimeOfRecu0,
                    TimeOfRecu1 = TaskBind.TimeOfRecu1,
                    TimeOfRecu2 = TaskBind.TimeOfRecu2,

                    //Final Date

                    FinalDate = TaskBind.FinalDate,
                    NumRecu = TaskBind.NumRecu,
                    ContractExp = TaskBind.ContractExp
                }))
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
            //Init the popup
            isInitPopUp = true;
            var temp = new RecurrencePopUp() { CloseWhenBackgroundIsClicked = true };
            await PopupNavigation.PushAsync(temp);
            isInitPopUp = false;
        }

        public ICommand TaskRecuCommand2
        {
            get { return new RelayCommand(TaskRecu2); }
        }

        private async void TaskRecu2()

        {
            //Init the popup
            isInitPopUp = true;
            var temp = new DayOrWeek() { CloseWhenBackgroundIsClicked = true };
            await PopupNavigation.PushAsync(temp);
            isInitPopUp = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
