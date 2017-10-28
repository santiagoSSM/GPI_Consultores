using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiConector;

namespace GPIApp.WebApi
{
    internal class AfterDayImplemented<T> : RestClient<T>
    {
        public AfterDayImplemented(string url) : base(url)
        {
        }
    }

    class AfterDayWA
    {
        AfterDayImplemented<string> client = new AfterDayImplemented<string>(ConstantsWA.WebApiServer + "AfterDayWA/");

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
