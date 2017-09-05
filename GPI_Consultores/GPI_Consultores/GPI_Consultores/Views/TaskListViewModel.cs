using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace GPI_Consultores.Views
{
    public class TaskListViewModel
    {
        private ListTask _oldListTask;

        public ObservableCollection<ListTask> ListTasks { get; set; }


        public TaskListViewModel () {

            ListTasks = new ObservableCollection<ListTask>

            {
                new ListTask
                {
                    Title ="Esteban Arias",
                    IsVisible = false
                },

                 new ListTask
                {
                    Title ="Geovanny Rojas Fhunnez",
                    IsVisible = false
                },

                  new ListTask
                {
                    Title ="Santiago Sánchez Madrigal",
                    IsVisible = false
                },


            };


        }

        internal void HideOrShowTaskList(ListTask listTask)
        {
            if (_oldListTask == listTask)
            {
                listTask.IsVisible = !listTask.IsVisible;
                UpdateListTasks(listTask);
            }
            else
            {

                if (_oldListTask != null)
                {
                    _oldListTask.IsVisible = false;
                    UpdateListTasks(_oldListTask);

                }

                listTask.IsVisible = true;
                UpdateListTasks(listTask);
            }

            _oldListTask = listTask;
        }

        private void UpdateListTasks(ListTask listTask)
        {

            var index = ListTasks.IndexOf(listTask);
            ListTasks.Remove(listTask);
            ListTasks.Insert(index,listTask );
        }
    }
    }   

        

