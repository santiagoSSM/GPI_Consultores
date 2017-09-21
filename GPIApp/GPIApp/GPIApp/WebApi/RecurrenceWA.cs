using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiConector;

namespace GPIApp.WebApi
{
    internal class RecurrenceImplemented<T> : RestClient<T>
    {
        public RecurrenceImplemented(string url) : base(url)
        {
        }
    }

    class RecurrenceWA
    {
        RecurrenceImplemented<string> client = new RecurrenceImplemented<string>(ConstantsWA.WebApiServer + "RecurrenceWA/");

        public async Task<List<string>> Get()
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
