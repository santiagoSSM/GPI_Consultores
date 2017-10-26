using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockWebApi.Models
{
    public class FiltersParamWA
    {
        private string filter;

        public string Filter
        {
            get
            {
                return filter;
            }

            set
            {
                filter = value;
            }
        }
    }
}