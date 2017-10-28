using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiConector;

namespace GPIApp.WebApi
{
    internal class CategoryImplemented<T> : RestClient<T>
    {
        public CategoryImplemented(string url) : base(url)
        {
        }
    }

    class CategoryWA
    {
        CategoryImplemented<string> client = new CategoryImplemented<string>(ConstantsWA.WebApiServer + "CategoryWA/");

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
