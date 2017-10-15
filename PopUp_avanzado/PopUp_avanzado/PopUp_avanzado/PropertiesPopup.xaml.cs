using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Rg.Plugins.Popup.Pages;

namespace PopUp_avanzado
{
    public partial class PropertiesPopup : PopupPage
    {
        public PropertiesPopup()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync();
        }
    }
}