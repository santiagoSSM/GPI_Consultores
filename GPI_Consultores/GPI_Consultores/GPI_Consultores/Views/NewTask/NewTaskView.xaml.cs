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
    public partial class NewTaskView : ContentPage
    {
        public NewTaskView()
        {
            InitializeComponent();

            categoryPicker.Items.Add("Programación");
            categoryPicker.Items.Add("Base de Datos");
            categoryPicker.Items.Add("Diseño");
            categoryPicker.Items.Add("Otro");

            priority.Items.Add("Alta");
            priority.Items.Add("Baja");
            priority.Items.Add("Media");

            recurrence.Items.Add("Cada Semana");
            recurrence.Items.Add("Cada Mes");
            recurrence.Items.Add("Cada Año");

            beforeDays.Items.Add("5 días");
            beforeDays.Items.Add("10 días");
            beforeDays.Items.Add("15 días");

            //finalAfterOf.Items.Add("4 recurrencias");
            //finalAfterOf.Items.Add("8 recurrencias");
            //finalAfterOf.Items.Add("12 recurrencias");

        }

        private void categoryPicker_SelectedIndexChanged(object sender, EventArgs e)
        {

            var name = categoryPicker.Items[categoryPicker.SelectedIndex];
            DisplayAlert(name, "Ha sido seleccionada exitosamente", "Ok");
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

        private void priority_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = categoryPicker.Items[priority.SelectedIndex];
            DisplayAlert(name, "Ha sido seleccionada exitosamente", "Ok");
        }

        private void recurrence_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = recurrence.Items[recurrence.SelectedIndex];
            DisplayAlert(name, "Ha sido seleccionada exitosamente", "Ok");
        }

        private void beforeDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = beforeDays.Items[beforeDays.SelectedIndex];
            DisplayAlert(name, "Ha sido seleccionada exitosamente", "Ok");
        }

        private void cancelRecuSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                cancelRecurrence.Text = "Cancelar Recurrencia";
            }
            else
            {
                cancelRecurrence.Text = "No cancelar Recurrencia";
            }
        }

        private void finalDateSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {

                finalDate.Text = "Sin Fecha de Finalización";
            }
            else
            {
                finalDate.Text = "Con Fecha de Finalización";
            }
        }

       
    }

}


