using GPIApp.Infraestructure;
using GPIApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPIApp.ViewModels
{
    public class VMContainer : IVMContainer, INotifyPropertyChanged
    {
        public LoginViewModel LoginVM { get; set; }
        public MainViewModel MainVM { get; set; }
        //public TaskSeeModel SeeTaskVM { get; set; }
        public NewEditTaskViewModel NewEditTaskVM { get; set; }

        private void ReleaseResourses()
        {
            LoginVM = null;
            MainVM = null;
            NewEditTaskVM = null;
        }

        public void LoginVMInit()
        {
            ReleaseResourses();
            LoginVM = new LoginViewModel(this);
        }

        public async Task MainVMInit()
        {
            ReleaseResourses();
            MainVM = new MainViewModel(this);
            await MainVM.LoadInfo(UserLogged.Value.IdUser);
            OnPropertyChanged("MainVM");
        }

        public async Task NewEditTaskVMInit(string title, int id=-1)
        {
            ReleaseResourses();
            if (title == "EditTask")
            {
                NewEditTaskVM = new NewEditTaskViewModel(this, false);
                await NewEditTaskVM.LoadEditTask(id);
            }
            else
            {
                NewEditTaskVM = new NewEditTaskViewModel(this, true);
                await NewEditTaskVM.LoadNewTask();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
