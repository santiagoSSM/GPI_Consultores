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
        public TaskAPP task { get; set; }
        private TaskWA taskWA;

        public NewTaskViewModel()
        {
            task = new TaskAPP();
            taskWA = new TaskWA();
        }

        public async Task NewTask()
        {
            await taskWA.Post(task);
        }
    }
}
