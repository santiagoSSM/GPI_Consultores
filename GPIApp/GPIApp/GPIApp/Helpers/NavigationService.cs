using GPIApp.Views.Login;
using GPIApp.Views.MainPage;
using GPIApp.Views.Task;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GPIApp.Helpers
{
    class NavigationService
    {
        public NavigationService()
        {
            dialogService = new DialogService();
        }

        private DialogService dialogService;

        public async void Navigate(string pageName)
        {
            try
            {
                App.Master.IsPresented = false;
                switch (pageName)
                {
                    case "Settings":
                        //await Navigate(new Settings());
                        break;
                    //Tasks
                    case "NewTask":
                        await Navigate(new NewTaskView());
                        break;
                    case "EditTask":
                        await Navigate(new EditTaskView());
                        break;
                    //other
                    case "MainPage":
                        await App.Navigator.PopToRootAsync();
                        break;
                    default:
                        await Navigate(new NewTaskView());
                        break;
                }
            }
            catch (Exception ex)
            {
                await dialogService.ShowMessage("Error", ex.Message, "Aceptar");
            }
        }

        private static async Task Navigate<T>(T page) where T : Page
        {
            NavigationPage.SetHasBackButton(page, true);
            NavigationPage.SetBackButtonTitle(page, "Atrás"); //iOS

            await App.Navigator.PushAsync(page);
        }

        internal async Task SetPageAsync(string pageName)
        {
            try
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
            catch (Exception ex)
            {
                await dialogService.ShowMessage("Error", ex.Message, "Aceptar");
            }
        }
    }
}
