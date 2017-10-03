using GPIApp.Views.Login;
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

        private DialogService dialogService;

        public async void Navigate(string pageName)
        {
            dialogService = new DialogService();

            App.Master.IsPresented = false;
            switch (pageName)
            {
                //Menu
                case "ActiveTask":
                    //await Navigate(new ActiveTask());
                    break;
                case "CompletedTask":
                    //await Navigate(new CompletedTask());
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
                //Nueva Tarea
                case "NewTask":
                    await Navigate(new NewTask());
                    break;
                //otros
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

        internal void SetPage(string pageName)
        {
            switch (pageName)
            {
                case "MasterPage":
                    App.Current.MainPage = new Master_MainView();
                    break;
                case "LoginPage":
                    App.Current.MainPage = new LoginView();
                    break;
                default:
                    break;
            }
        }
    }
}
