using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GPIApp.Views.PopUps.Generic
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityIndicatorPopUp : PopupPage
    {
        public ActivityIndicatorPopUp(string text)
        {
            InitializeComponent();
            Text.Text = text;
            BackgroundColor = Color.FromRgba(0, 0, 0, 200);
        }
    }
}