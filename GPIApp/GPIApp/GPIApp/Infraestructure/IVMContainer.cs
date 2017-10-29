using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPIApp.Infraestructure
{
    public interface IVMContainer
    {
        void LoginVMInit();
        Task MainVMInit();
        Task NewEditTaskVMInit(string title, int id=-1);
    }
}
