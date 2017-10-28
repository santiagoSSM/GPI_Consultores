using GPIApp.ViewModels;
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
            VMContainer.LoginVMInit();

            //Todo inicio rapido eliminar despues
            VMContainer.LoginVM.User.NameUser = "user";
            VMContainer.LoginVM.User.PassUser = "pass";

            MainPage = new LoginView();
        }
    }
}
