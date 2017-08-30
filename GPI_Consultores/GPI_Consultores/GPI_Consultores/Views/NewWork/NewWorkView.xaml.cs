using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GPI_Consultores
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewWorkView : ContentPage
    {
        public NewWorkView()
        {
            InitializeComponent();
            categoryPicker.Items.Add("Hola");
            categoryPicker.Items.Add("Hola");
            categoryPicker.Items.Add("Hola");
            categoryPicker.Items.Add("Hola");
        }

        private void categoryPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = categoryPicker.Items[categoryPicker.SelectedIndex];
            DisplayAlert(name, "Selecciona una Opción", "Ok");
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                reqApproval.Text = "Requiere";
            }
            else
            {
                reqApproval.Text = "No requiere";
            }
        }
    }
}