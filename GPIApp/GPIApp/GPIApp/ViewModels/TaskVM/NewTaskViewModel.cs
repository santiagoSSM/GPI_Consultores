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
        private RecurrenceWA recurrenceWA;

        
        public ObservableCollection<string> afterDayList { get; set; }
        public ObservableCollection<string> beforeDaysList { get; set; }
        public ObservableCollection<string> categoryList { get; set; }
        public ObservableCollection<string> priorityList { get; set; }
        public ObservableCollection<string> recurrenceList { get; set; }

        public NewTaskViewModel()
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

        public async Task LoadPicker()
        {
            InitObjRecurrence();

            afterDayList = await afterDayWA.Get();
            beforeDaysList = await beforeDaysWA.Get();
            categoryList = await categoryWA.Get();
            priorityList = await priorityWA.Get();
            recurrenceList = await recurrenceWA.Get();
        }

        private void InitObjRecurrence()
        {
            switch (task.UserRecurrence)
            {
                case "Ninguna":
                    {
                        task.ObjRecurrence = new NoneTaskModel();
                        break;
                    }
                case "Diaria":
                    {
                        task.ObjRecurrence = new DailyTaskModel();
                        break;
                    }
                case "Semanal":
                    {
                        task.ObjRecurrence = new WeeklyTaskModel();
                        break;
                    }
                case "Mensual":
                    {
                        task.ObjRecurrence = new MonthlyTaskModel();
                        break;
                    }
                case "Anual":
                    {
                        task.ObjRecurrence = new AnnualTaskModel();
                        break;
                    }
                default:
                    {
                        task.ObjRecurrence = new NoneTaskModel();
                        break;
                    }
            }
        }

        public async Task<bool> NewTaskDraft()
        {
            await taskWA.Delete(0);

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
