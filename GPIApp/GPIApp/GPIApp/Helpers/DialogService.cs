using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPIApp.Helpers
{
    class DialogService
    {
        public async Task ShowMessage(string title, string message, string button)
        {
            if (App.Navigator != null)
            {
                await App.Navigator.DisplayAlert(title, message, button);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(title, message, button);
            }
        }
    }
}
