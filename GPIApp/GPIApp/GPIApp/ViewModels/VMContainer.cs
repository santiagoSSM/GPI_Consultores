using GPIApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPIApp.ViewModels
{
    public static class VMContainer
    {
        public static int TaskidSelect { get; set; }
        public static UserModel UserLogged { get; set; }
        public static LoginViewModel LoginVM { get; set; }
        public static MainViewModel MainVM { get; set; }
        //public static TaskSeeModel SeeTaskVM { get; set; }
        public static NewEditTaskViewModel NewEditTaskVM { get; set; }

        public static void ReleaseResourses()
        {
            LoginVM = null;
            MainVM = null;
            NewEditTaskVM = null;
        }

        public static void LoginVMInit()
        {
            LoginVM = new LoginViewModel();
        }

        public static void MainVMInit()
        {
            MainVM = new MainViewModel();
        }

        public static void NewEditTaskVMInit(string title)
        {
            NewEditTaskVM = new NewEditTaskViewModel(title);
        }
    }
}
