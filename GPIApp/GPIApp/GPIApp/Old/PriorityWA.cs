using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiConector;

namespace GPIApp.WebApi
{
    internal class PriorityImplemented<T> : RestClient<T>
    {
        public PriorityImplemented(string url) : base(url)
        {
        }
    }

    class PriorityWA
    {
        PriorityImplemented<string> client = new PriorityImplemented<string>(ConstantsWA.WebApiServer + "PriorityWA/");

        public async Task<ObservableCollection<string>> Get()
        {
            try
            {
                return await client.Get();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
