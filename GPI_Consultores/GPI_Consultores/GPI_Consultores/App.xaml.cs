using GPI_Consultores.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace GPI_Consultores
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SetMainPage();

           // MainPage = new LoginPage();
        }

        public static void SetMainPage()
        {
            Current.MainPage = new NavigationPage(new MasterPageApp());
        }
    }
}
