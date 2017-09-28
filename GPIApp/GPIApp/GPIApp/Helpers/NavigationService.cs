using GPIApp.Views.MainPage;
using GPIApp.Views.NewTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GPIApp.Helpers
{
    class NavigationService
    {
        public async void Navigate(string pageName)
        {
            App.Master.IsPresented = false;
            switch (pageName)
            {
                case "ActiveTask":
                    //await Navigate(new ActiveTask());
                    break;
                case "CanceledTask":
                    //await Navigate(new CanceledTask());
                    break;
                case "DeletedTask":
                    //await Navigate(new DeletedTask());
                    break;
                case "Settings":
                    //await Navigate(new Settings());
                    break;
                case "CompletedTask":
                    //await Navigate(new CompletedTask());
                    break;
                case "MyTask":
                    //await Navigate(new MyTask());
                    break;
                case "MainPage":
                    await App.Navigator.PopToRootAsync();
                    break;
                default:
                    await Navigate(new NewTask());
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
                    App.Current.MainPage = new Master_MainView();
                    break;
                default:
                    break;
            }
        }
    }
}
