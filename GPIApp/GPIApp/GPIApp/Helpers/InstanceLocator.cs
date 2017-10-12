using GPIApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPIApp.Helpers
{
    class InstanceLocator
    {
        public InstanceLocator()
        {
            VMControl = new ViewModelsControl();
        }

        public ViewModelsControl VMControl { get; set; }
    }
}
