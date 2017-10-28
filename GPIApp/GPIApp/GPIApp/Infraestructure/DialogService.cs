using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPIApp.Infraestructure
{
    public static class DialogService
    {
        public static async Task ShowMessage(string title, string message, string button)
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

        public static async Task<string> ShowOptions(string title, string[] options, string button)
        {
            return await App.Navigator.DisplayActionSheet(title, button, null, options);
        }
    }
}
