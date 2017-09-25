using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPI_Consultores.WebApi
{
    public static class ConstantsWA
    {
        private static string webApiServer = "http://192.168.2.8:63110/api/";
        public static string WebApiServer
        {
            get
            {
                return webApiServer;
            }

            set
            {
                webApiServer = value;
            }
        }
    }
}
