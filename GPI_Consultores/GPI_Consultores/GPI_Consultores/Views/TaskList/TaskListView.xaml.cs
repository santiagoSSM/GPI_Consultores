using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GPI_Consultores.Views.TaskList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskListView : ContentPage
    {
        public TaskListView()
        {
            InitializeComponent();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var ltm = BindingContext as TaskListViewModel;

            var  listTask = e.Item as ListTask;

            ltm.HideOrShowTaskList(listTask);
        }
    }
}