using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiConector;

namespace GPIApp.WebApi
{
    internal class RestBeforeDaysImplemented<T> : RestClient<T>
    {
        public RestBeforeDaysImplemented(string url) : base(url)
        {
        }
    }

    public class BeforeDaysWA
    {
        RestBeforeDaysImplemented<string> client = new RestBeforeDaysImplemented<string>(ConstantsWA.WebApiServer + "BeforeDaysWA/");

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
