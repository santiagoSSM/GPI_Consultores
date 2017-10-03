using GPIApp.Helpers;
using GPIApp.Views.Login;
using GPIApp.Views.MainPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace GPIApp
{
    public partial class App : Application
    {
        public static NavigationPage Navigator { get; internal set; }
        public static Master_MainView Master { get; internal set; }

        public App()
        {
            InitializeComponent();

            MainPage = new Master_MainView();

            //MainPage = new LoginView();
        }
    }
}
