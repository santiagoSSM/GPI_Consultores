using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GPIApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var ltm = BindingContext as TaskListViewModel;

            var listTask = e.Item as ListTask;

            ltm.HideOrShowTaskList(listTask);
        }
    }

    public class TaskListViewModel
    {
        private ListTask _oldListTask;

        public ObservableCollection<ListTask> ListTasks { get; set; }


        public TaskListViewModel()
        {

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
            ListTasks.Insert(index, listTask);
        }
    }

    public class ListTask
    {
        public string Title { get; set; }
        public bool IsVisible { get; set; }
    }
}