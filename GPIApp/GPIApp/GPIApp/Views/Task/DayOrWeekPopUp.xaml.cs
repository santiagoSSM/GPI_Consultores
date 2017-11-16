using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GPIApp.Views.Task
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DayOrWeek : PopupPage
    {
        public DayOrWeek()
        {
            InitializeComponent();
        }

        private void PickerDayOrWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelDayOrWeek.Text = PickerDayOrWeek.SelectedItem.ToString();
        }

        private void LabelDayOrWeek_Focused(object sender, FocusEventArgs e)
        {
            LabelDayOrWeek.Unfocus();
            PickerDayOrWeek.Focus();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync();
        }
    }
}