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
            //SetLoginPage();
            //ShowMainPage();
            Current.MainPage = new NewTaskView();
        }

        public void SetLoginPage()
        {
            Current.MainPage = new LoginView(this);
        }

        public void ShowMainPage()
        {
            Current.MainPage = new Master_MainView();
        }

        public void Logout()
        {
            //Properties["IsLoggedIn"] = false; // usar propiedad para definir que no esta logeado desde sqlite
            SetLoginPage();
        }
    }
}
