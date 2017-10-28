using GalaSoft.MvvmLight.Command;
using GPIApp.Models;
using System.Windows.Input;

namespace GPIApp.ViewModels
{
    public class TaskListItemViewModel
    {
        private int idTask;
        private string textIssue;
        private string textImgPriority;
        private string textImgActive;

        //Properties

        public TaskListItemViewModel(TaskListItemModel item)
        {
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
            //user idTask
        }
    }
}