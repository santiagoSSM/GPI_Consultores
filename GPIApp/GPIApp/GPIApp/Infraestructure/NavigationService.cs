using GPIApp.ViewModels;
using GPIApp.Views.Login;
using GPIApp.Views.MainPage;
using GPIApp.Views.Task;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GPIApp.Infraestructure
{
    public static class NavigationService
    {
        public static async Task Navigate(string pageName, int id=-1)
        {
            try
            {
                App.Master.IsPresented = false;
                switch (pageName)
                {
                    //Tasks
                    case "NewTask":
                        VMContainer.ReleaseResourses();
                        VMContainer.NewEditTaskVMInit("Nueva tarea");
                        await VMContainer.NewEditTaskVM.LoadPickers();
                        await Navigate(new NewEditTaskView());
                        break;
                    case "EditTask":
                        VMContainer.ReleaseResourses();
                        VMContainer.NewEditTaskVMInit("Editar tarea");
                        await VMContainer.NewEditTaskVM.LoadEditTask(id);
                        await Navigate(new NewEditTaskView());
                        break;
                    case "SeeTask":
                        //await Navigate(new EditTaskView());
                        break;
                    //other
                    case "MainPage":
                        VMContainer.ReleaseResourses();
                        VMContainer.MainVMInit();
                        await VMContainer.MainVM.LoadInfo(VMContainer.UserLogged.IdUser);
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

        private static async Task Navigate<T>(T page) where T : Page
        {
            NavigationPage.SetHasBackButton(page, true);
            NavigationPage.SetBackButtonTitle(page, "Atrás"); //iOS

            await App.Navigator.PushAsync(page);
        }

        public static async Task SetPageAsync(string pageName)
        {
            try
            {
                switch (pageName)
                {
                    case "MasterPage":
                        VMContainer.ReleaseResourses();
                        VMContainer.MainVMInit();
                        await VMContainer.MainVM.LoadInfo(VMContainer.UserLogged.IdUser);
                        App.Current.MainPage = new Master_MainView();
                        break;
                    case "LoginPage":
                        VMContainer.ReleaseResourses();
                        VMContainer.LoginVMInit();
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
