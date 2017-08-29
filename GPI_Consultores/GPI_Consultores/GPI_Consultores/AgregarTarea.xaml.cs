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
    public partial class AgregarTarea : ContentPage
    {
        public AgregarTarea()
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
            DisplayAlert(name, "Select Value", "Ok");
        }
    }
}