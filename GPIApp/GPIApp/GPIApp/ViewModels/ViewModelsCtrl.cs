using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPIApp.ViewModels
{
    class ViewModelsCtrl
    {
        public LoginViewModel LoginVM
        {
            get
            {
                return VMContainer.LoginVM;
            }
        }

        public MainViewModel MainVM
        {
            get
            {
                return VMContainer.MainVM;
            }
        }

        public NewEditTaskViewModel NewEditTaskVM
        {
            get
            {
                return VMContainer.NewEditTaskVM;
            }
        }
    }
}
