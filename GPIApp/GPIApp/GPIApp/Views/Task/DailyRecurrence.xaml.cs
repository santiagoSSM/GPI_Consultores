﻿using Rg.Plugins.Popup.Pages;
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
    public partial class DailyRecurrence : PopupPage
    {
        public DailyRecurrence()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync();
        }
    }
}