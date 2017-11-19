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
	public partial class RecurrencePopUp : PopupPage
    {
        public RecurrencePopUp()
        {
            InitializeComponent();
            PickerDate_DateSelected();
        }

        private void PickerRecu_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelRecu.Text = PickerRecu.SelectedItem.ToString();
        }

        private void LabelRecu_Focused(object sender, FocusEventArgs e)
        {
            LabelRecu.Unfocus();
            PickerRecu.Focus();
        }

        private void PickerDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelDay.Text = PickerDay.SelectedItem.ToString();
        }

        private void LabelDay_Focused(object sender, FocusEventArgs e)
        {
            LabelDay.Unfocus();
            PickerDay.Focus();
        }

        private void LabelDayOrWeek_Focused(object sender, FocusEventArgs e)
        {
            LabelDayOrWeek.Unfocus();
            LabelDayOrWeek2.Unfocus();
            stackL.Command.Execute(null);
        }

        private void PickerDay_SelectedIndexChanged2(object sender, EventArgs e)
        {
            LabelDay2.Text = PickerDay2.SelectedItem.ToString();
        }

        private void LabelDay_Focused2(object sender, FocusEventArgs e)
        {
            LabelDay2.Unfocus();
            PickerDay2.Focus();
        }

        private void PickerDay_SelectedIndexChanged3(object sender, EventArgs e)
        {
            LabelDay3.Text = PickerDay3.SelectedItem.ToString();
        }

        private void LabelDay_Focused3(object sender, FocusEventArgs e)
        {
            LabelDay3.Unfocus();
            PickerDay3.Focus();
        }

        private void PickerMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelMonth.Text = PickerMonth.SelectedItem.ToString();
        }

        private void LabelMonth_Focused(object sender, FocusEventArgs e)
        {
            LabelMonth.Unfocus();
            PickerMonth.Focus();
        }

        private void PickerMonth_SelectedIndexChanged2(object sender, EventArgs e)
        {
            LabelMonth2.Text = PickerMonth2.SelectedItem.ToString();
        }

        private void LabelMonth_Focused2(object sender, FocusEventArgs e)
        {
            LabelMonth2.Unfocus();
            PickerMonth2.Focus();
        }

        private void PickerFinalDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelFinalDate.Text = PickerFinalDate.SelectedItem.ToString();
            var xyz = LabelFinalDate.Measure(25, 25);
        }

        private void LabelFinalDate_Focused(object sender, FocusEventArgs e)
        {
            LabelFinalDate.Unfocus();
            PickerFinalDate.Focus();
        }

        private void PickerDate_DateSelected()
        {
            LabelDate.Text = PickerDate.Date.Date.ToString("dd-MM-yyyy");
        }

        private void PickerDate_DateSelected(object sender, EventArgs e)
        {
            PickerDate_DateSelected();
        }

        private void LabelDate_Focused(object sender, FocusEventArgs e)
        {
            PickerDate.Unfocus();
            LabelDate.Unfocus();
            PickerDate.Focus();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync();
        }
    }
}