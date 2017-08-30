using System;

using GPI_Consultores.Models;
using GPI_Consultores.ViewModels;

using Xamarin.Forms;

namespace GPI_Consultores.Views
{
    public partial class MainView : ContentPage
    {
        ItemsViewModel viewModel;

        public MainView()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {

        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
        }

        protected override void OnAppearing()
        {
 
        }
    }
}
