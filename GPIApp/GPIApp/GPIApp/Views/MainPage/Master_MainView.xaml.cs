﻿using GPIApp.Views.NewTask;
using GPIApp.Views.TaskList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GPIApp.Views.MainPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master_MainView : MasterDetailPage
    {
        public Master_MainView()
        {
            InitializeComponent();
            Init();
        }


        void Init()
        {

            List<Menu> menu = new List<Menu>()
            {
                new Menu { MenuTitle = "Inicio", MenuDetail = "Regresa a la Pagina Principal"},
                new Menu { MenuTitle = "Crear Nueva Tarea", MenuDetail = "Nueva Tarea"}
            };

            ListMenu.ItemsSource = menu;

            Device.OnPlatform(Android: () => {

                ListMenu.Margin = new Thickness(0, 21, 0, 0);

            }, iOS: () => {

                ListMenu.Margin = new Thickness(0, 21, 0, 0);

            });

            Detail = new NavigationPage(new MainView());
            Detail = new NavigationPage(new NewTaskView());
            Detail = new NavigationPage(new TaskListView());

        }

        private void ListMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menu = e.SelectedItem as Menu;
            if (menu != null)
            {
                if (menu.MenuTitle.Equals("Inicio"))
                {
                    Detail = new NavigationPage(new MainView());
                }
                else if (menu.MenuTitle.Equals("Crear Nueva Tarea"))
                {
                    Detail = new NavigationPage(new TaskListView());
                }
            }
        }
    }

    public class Menu
    {

        public string MenuTitle
        {
            get;
            set;
        }

        public string MenuDetail
        {

            get;
            set;

        }
    }
}