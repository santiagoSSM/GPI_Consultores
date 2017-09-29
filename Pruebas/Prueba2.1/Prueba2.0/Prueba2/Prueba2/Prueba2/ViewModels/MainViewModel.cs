﻿using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Prueba2.ViewModels
{
    public class MainViewModel
    {

        public MainViewModel ()
        {
            LoadMenu();
        }

        public ObservableCollection <MenuItemViewModel> Menu { get; set; }

        public ICommand GoToCommand {

            
                get { return new RelayCommand<string>(GoTo); }
            


        }

        private void GoTo(string pageName)
        {
            switch (pageName)
            {


                case "NewTask":
                    App.Navigator.PushAsync(new NewTask());
                    break;
                default:
                    break;

            }
        }

        private void LoadMenu()
        {
            Menu = new ObservableCollection<MenuItemViewModel>();

            Menu.Add(new MenuItemViewModel(){

                Icon = "ic_action_donut_large",
                Title = "Tareas Activas",
                PageName = "ActiveTask"

            });

            Menu.Add(new MenuItemViewModel()
            {

                Icon = "ic_action_check",
                Title = "Tareas Completadas",
                PageName = "CompletedTask"

            });

            Menu.Add(new MenuItemViewModel()
            {

                Icon = "ic_action_clear",
                Title = "Tareas Canceladas",
                PageName = "CanceledTask"

            });

            Menu.Add(new MenuItemViewModel()
            {

                Icon = "ic_action_delete",
                Title = "Tareas Eliminadas",
                PageName = "DeletedTask"

            });

            Menu.Add(new MenuItemViewModel()
            {

                Icon = "ic_action_settings",
                Title = "Settings",
                PageName = "Settings"

            });



            Menu.Add(new MenuItemViewModel()
            {

                Icon = "ic_action_user",
                Title = "Cerrar Sesión",
                //PageName = ""

            });

        }

    }
}