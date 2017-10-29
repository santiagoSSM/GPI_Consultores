using GPIApp.ViewModels;
using GPIApp.Views.Login;
using GPIApp.Views.MainPage;
using GPIApp.Views.Task;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GPIApp.Infraestructure
{
    public class NavigationService
    {
        IVMContainer inter;

        public NavigationService(IVMContainer inter)
        {
            this.inter = inter;
        }

        public async Task Navigate(string pageName, int id=-1)
        {
            try
            {
                App.Master.IsPresented = false;
                switch (pageName)
                {
                    //Tasks
                    case "NewTask":
                        await inter.NewEditTaskVMInit("NewTask");
                        await Navigate(new NewEditTaskView());
                        break;
                    case "EditTask":
                        await inter.NewEditTaskVMInit("EditTask", id);
                        await Navigate(new NewEditTaskView());
                        break;
                    case "SeeTask":
                        //await Navigate(new EditTaskView());
                        break;
                    //other
                    case "MainPage":
                        await inter.MainVMInit();
                        await App.Navigator.PopToRootAsync();
                        break;
                    case "CloseMenu":
                        await App.Navigator.PopToRootAsync();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                await DialogService.ShowMessage("Error", ex.Message, "Aceptar");
            }
        }

        private async Task Navigate<T>(T page) where T : Page
        {
            NavigationPage.SetHasBackButton(page, true);
            NavigationPage.SetBackButtonTitle(page, "Atrás"); //iOS

            await App.Navigator.PushAsync(page);
        }

        public async Task SetPageAsync(string pageName)
        {
            try
            {
                switch (pageName)
                {
                    case "MasterPage":
                        await inter.MainVMInit();
                        App.Current.MainPage = new Master_MainView();
                        break;
                    case "LoginPage":
                        inter.LoginVMInit();
                        App.Current.MainPage = new LoginView();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                await DialogService.ShowMessage("Error", ex.Message, "Aceptar");
            }
        }
    }
}
