using System;
using GPIApp.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GPIApp.Views.Login;
using GPIApp.Views.MainPage;
using GPIApp.Views.NewTask;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace GPIApp
{
    public partial class App : Application, ILoginManager
    {
        public App()
        {
            InitializeComponent();
            SetLoginPage();
            //ShowMainPage();
            //Current.MainPage = new NewTaskView();
        }

        public void SetLoginPage()
        {
            Current.MainPage = new LoginView(this);
        }

        public void Logout()
        {
            //Properties["IsLoggedIn"] = false; // usar propiedad para definir que no esta logeado desde sqlite
            SetLoginPage();
        }

        public void ShowMainPage(string user)
        {
            //Verificar uso del intent si es necesario
            Current.MainPage = new Master_MainView();
        }
    }
}
