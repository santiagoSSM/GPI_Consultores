using GalaSoft.MvvmLight.Command;
using GPIApp.Infraestructure;
using GPIApp.Models;
using System;
using System.Windows.Input;

namespace GPIApp.ViewModels
{
    public class TaskListItemViewModel
    {
        NavigationService navServ;
        private int idTask;
        private string textIssue;
        private string textImgPriority;
        private string textImgActive;

        //Properties

        public TaskListItemViewModel(IVMContainer inter, TaskListItemModel item)
        {
            navServ = new NavigationService(inter);
            idTask = item.IdTask;
            textIssue = item.TextIssue;

            if (item.IdPriority == 2)
            {
                textImgPriority = "low_Priority.png";
            }
            else
            {
                textImgPriority = "high_Priority.png";
            }

            if (item.IsActive)
            {
                textImgActive = "active_Task.png";
            }
            else
            {
                textImgActive = "inactive_Task.png";
            }
        }

        public int IdTask
        {
            get
            {
                return idTask;
            }
        }

        public string TextIssue
        {
            get
            {
                return textIssue;
            }
        }

        public string TextImgPriority
        {
            get
            {
                return textImgPriority;
            }
        }

        public string TextImgActive
        {
            get
            {
                return textImgActive;
            }
        }

        public ICommand ClickedCommand
        {
            get { return new RelayCommand(Clicked); }
        }

        public async void Clicked()
        {
            try
            {
                var select = await DialogService.ShowOptions("Seleccionar", new string[] { "Ver", "Reasignar", "Editar", "Prorrogar", "Responder", "Delegar", "Crear borrador", "Eliminar borrador" }, "Cancelar");

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
                            await navServ.Navigate("EditTask", idTask);
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
                await DialogService.ShowMessage("Error", ex.Message, "Aceptar");
            }
        }
    }
}