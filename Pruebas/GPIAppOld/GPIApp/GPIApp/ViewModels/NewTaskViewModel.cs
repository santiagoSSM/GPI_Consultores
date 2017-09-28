using GPIApp.Models;
using GPIApp.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPIApp.ViewModels
{
    public class NewTaskViewModel
    {
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

        public NewTaskViewModel()
        {
            taskWA = new TaskWA();
            task = new TaskAPP();

            afterDayWA = new AfterDayWA();
            beforeDaysWA = new BeforeDaysWA();
            categoryWA = new CategoryWA();
            priorityWA = new PriorityWA();
            recurrenceWA = new RecurrenceWA();
        }

        public async Task Charge()
        {
            afterDayList = await afterDayWA.Get();
            beforeDaysList = await beforeDaysWA.Get();
            categoryList = await categoryWA.Get();
            priorityList = await priorityWA.Get();
            recurrenceList = await recurrenceWA.Get();
        }

        public async Task NewTask()
        {
            await taskWA.Post(task);
        }
    }
}
