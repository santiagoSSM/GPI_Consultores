using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PopUp_avanzado
{
    public partial class App : Application
    {
        public App()
        {
            try
            {
                var contentPage = new HomePage();
                MainPage = new NavigationPage(contentPage);
            }
            catch (Exception ex)
            {

            }
            
        }
    }
}
