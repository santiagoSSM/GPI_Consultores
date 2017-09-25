using Prueba2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba2
{
    public class InstanceLocator
    {

        public InstanceLocator ()
        {
            Main = new MainViewModel();
        }

        public MainViewModel Main { get; set; }
    }
}
