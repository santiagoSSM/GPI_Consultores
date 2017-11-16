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
    public partial class NewEditTaskView : ContentPage
    {

        public NewEditTaskView()
        {
            InitializeComponent();
        }

        private void PickerResp_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelResp.Text = PickerResp.SelectedItem.ToString();
        }

        private void LabelResp_Focused(object sender, FocusEventArgs e)
        {
            LabelResp.Unfocus();
            PickerResp.Focus();
        }

        private void PickerCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelCategory.Text = PickerCategory.SelectedItem.ToString();
        }

        private void LabelCategory_Focused(object sender, FocusEventArgs e)
        {
            LabelCategory.Unfocus();
            PickerCategory.Focus();
        }

        private void PickerPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelPriority.Text = PickerPriority.SelectedItem.ToString();
        }

        private void LabelPriority_Focused(object sender, FocusEventArgs e)
        {
            LabelPriority.Unfocus();
            PickerPriority.Focus();
        }

        private void PickerCopy_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelCopy.Text = PickerCopy.SelectedItem.ToString();
        }

        private void LabelCopy_Focused(object sender, FocusEventArgs e)
        {
            LabelCopy.Unfocus();
            PickerCopy.Focus();
        }

        private void LabelRecu_Focused(object sender, FocusEventArgs e)
        {
            LabelRecu.Unfocus();
            stackL.Command.Execute(null);
        }
    }
}