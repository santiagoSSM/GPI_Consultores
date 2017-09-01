using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MockService
{
    [DataContract]
    public static class TaskList
    {
        private static List<TaskWS> listTask = new List<TaskWS>();

        [DataMember]
        public static List<TaskWS> ListTask
        {
            get
            {
                return listTask;
            }

            set
            {
                listTask = value;
            }
        }

        public static void NewTask(TaskWS tarea)
        {
            tarea.IdTask = listTask.Count();
            listTask.Add(tarea);
        }
    }
}