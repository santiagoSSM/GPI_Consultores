using GPIApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GPIApp.Views.NewTask
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTaskView : ContentPage
    {
        public NewTaskViewModel newTaskViewModel { get; set; }

        //load items before displaying the page, replace with the constructor
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = newTaskViewModel = new NewTaskViewModel();

            
            try
            {
                //load server information
                await newTaskViewModel.Charge();
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "Ok");
            }

            InitializeComponent();

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

        private void AfterDayOfSwitch_Toggled(object sender, ToggledEventArgs e)
        {

        }

        private void AfterDayOfPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = AfterDayOfPicker.Items[AfterDayOfPicker.SelectedIndex];
            DisplayAlert(name, "Ha sido seleccionada exitosamente", "Ok");
        }

        private void FinalSwitch_Toggled(object sender, ToggledEventArgs e)
        {

        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                //faltan las validaciones

                try
                {
                    await newTaskViewModel.NewTask();
                    await DisplayAlert("Mensaje", "Tarea registrada correctamente", "Aceptar");
                    //navegar a MainPage
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", ex.Message, "Aceptar");
                }
            });
        }
    }
}