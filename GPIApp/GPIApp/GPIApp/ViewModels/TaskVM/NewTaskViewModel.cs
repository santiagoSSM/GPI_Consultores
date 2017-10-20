using GPIApp.Helpers;
using GPIApp.Models;
using GPIApp.Models.Recurrence;
using GPIApp.WebApi;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace GPIApp.ViewModels.TaskVM
{
    public class NewTaskViewModel
    {
        private DialogService dialogService;
        private NavigationService navigationService;
        private TaskWA taskWA;
        public TaskModel task { get; set; }

        private AfterDayWA afterDayWA;
        private BeforeDaysWA beforeDaysWA;
        private CategoryWA categoryWA;
        private PriorityWA priorityWA;

        
        public ObservableCollection<string> afterDayList { get; set; }
        public ObservableCollection<string> beforeDaysList { get; set; }
        public ObservableCollection<string> categoryList { get; set; }
        public ObservableCollection<string> priorityList { get; set; }

        public NewTaskViewModel()
        {
            dialogService = new DialogService();
            navigationService = new NavigationService();
            taskWA = new TaskWA();

            //init task
            task = new TaskModel();
            task.UserRecurrence = "Ninguna";
            task.ObjRecurrence = new NoneTaskModel();

            afterDayWA = new AfterDayWA();
            beforeDaysWA = new BeforeDaysWA();
            categoryWA = new CategoryWA();
            priorityWA = new PriorityWA();
        }

        public async Task LoadPicker()
        {
            afterDayList = await afterDayWA.Get();
            beforeDaysList = await beforeDaysWA.Get();
            categoryList = await categoryWA.Get();
            priorityList = await priorityWA.Get();
        }

        public async Task<bool> NewTaskDraft()
        { 

            return true;
        }

        public async Task<bool> NewTask()
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

            await taskWA.Post(task);
            await dialogService.ShowMessage("Mensaje", "Tarea registrada correctamente", "Aceptar");
            return true;
        }
    }
}
