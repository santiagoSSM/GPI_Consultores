using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GPIApp.Views.PopUps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonthlyRecurrence : PopupPage
    {
        public MonthlyRecurrence()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync();
        }



    }
}