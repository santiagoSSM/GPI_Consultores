using GPI_Consultores.Helpers;
using GPI_Consultores.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace GPI_Consultores
{
    public partial class App : Application, ILoginManager
    {

        public App()
        {
            InitializeComponent();
            SetLoginPage();
        }

        public void SetLoginPage()
        {
            Current.MainPage = new LoginPage(this);
        }

        public void ShowMainPage()
        {
            Current.MainPage = new MasterPageApp();
        }

        public void Logout()
        {
            //Properties["IsLoggedIn"] = false; // usar propiedad para definir que no esta logeado desde sqlite
            Current.MainPage = new LoginPage(this);
        }
    }
}
