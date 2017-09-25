using Prueba2;
using Prueba2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prueba2.Services
{
    public class NavigationService
    {
        public async void Navigate(string pageName)
        {
            App.Master.IsPresented = false;
            switch (pageName)
            {
                case "ActiveTask":
                    await Navigate(new ActiveTask());
                    break;
                case "CanceledTask":
                    await Navigate(new CanceledTask());
                    break;
                case "DeletedTask":
                    await Navigate(new DeletedTask());
                    break;
                case "Settings":
                    await Navigate(new Settings());
                    break;
                case "CompletedTask":
                    await Navigate(new CompletedTask());
                    break;
                case "MyTask":
                    await Navigate(new MyTask());
                    break;
                case "MainPage":
                    await App.Navigator.PopToRootAsync();
                    break;
                default:
                    break;
            }
        }

        private static async Task Navigate<T>(T page) where T : Page
        {
            NavigationPage.SetHasBackButton(page, true);
            NavigationPage.SetBackButtonTitle(page, "Atrás"); //iOS

            await App.Navigator.PushAsync(page);
        }

        internal void SetMainPage(string pageName)
        {
            switch (pageName)
            {
                case "MasterPage":
                    App.Current.MainPage = new MasterPage();
                    break;
                default:
                    break;
            }
        }
    }
}
