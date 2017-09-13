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
        private BeforeDaysWA beforeDaysWA;

        public TaskAPP task { get; set; }
        public List<string> beforeDaysList { get; set; }

        public NewTaskViewModel()
        {
            taskWA = new TaskWA();
            beforeDaysWA = new BeforeDaysWA();
            task = new TaskAPP();
        }

        public async Task Charge()
        {
            beforeDaysList = await beforeDaysWA.Get();
        }

        public async Task NewTask()
        {
            await taskWA.Post(task);
        }
    }
}
