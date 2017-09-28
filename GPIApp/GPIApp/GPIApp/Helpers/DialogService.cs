using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPIApp.Helpers
{
    class DialogService
    {
        public async Task ShowMessage(string message, string title, string button)
        {
            await App.Navigator.DisplayAlert(title, message, button);
        }
    }
}
