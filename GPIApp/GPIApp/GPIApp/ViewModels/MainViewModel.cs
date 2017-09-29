using GalaSoft.MvvmLight.Command;
using GPIApp.Helpers;
using GPIApp.Views.NewTask;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GPIApp.ViewModels
{
    class MainViewModel
    {

        public MainViewModel()
        {
            navigationService = new NavigationService();

            Login = new LoginViewModel();

            Tasks = new ObservableCollection<Task>();

            LoadMenu();
        }

        #region Properties

        private NavigationService navigationService;

        public String User { get; private set; }

        public LoginViewModel Login { get; private set; }

        public TaskViewModel NewTask { get; private set; }

        public ObservableCollection<Task> Tasks { get; set; }

        public ObservableCollection<MenuItemViewModel> Menu { get; set; } 

        #endregion

        #region Commands

        public ICommand GoToCommand
        {
            get { return new RelayCommand<string>(GoTo); }
        }

        private void GoTo(string pageName)
        {
            switch (pageName)
            {
                case "NewTask":
                    NewTask = new TaskViewModel();
                    break;
                default:
                    break;
            }
            navigationService.Navigate(pageName);
        }

        public ICommand StartCommand
        {
            get { return new RelayCommand(Start); }
        }

        private async void Start()
        {
            /*var list = await apiService.GetAllOrders();
            Orders.Clear();

            foreach (var item in list)
            {
                Orders.Add(new OrderViewModel()
                {
                    Title = item.Title,
                    DeliveryDate = item.DeliveryDate,
                    Description = item.Description
                });
            }*/
            

            if (await Login.Login())
            {
                navigationService.SetMainPage("MasterPage");
            }
        }

        #endregion

        #region Methods

        private void LoadMenu()
        {
            Menu = new ObservableCollection<MenuItemViewModel>();

            Menu.Add(new MenuItemViewModel()
            {

                Icon = "ic_action_donut_large",
                Title = "Tareas Activas",
                PageName = "NewTask"

            });

            Menu.Add(new MenuItemViewModel()
            {

                Icon = "ic_action_check",
                Title = "Tareas Completadas",
                PageName = "NewTask"

            });

            Menu.Add(new MenuItemViewModel()
            {

                Icon = "ic_action_clear",
                Title = "Tareas Canceladas",
                PageName = "NewTask"

            });

            Menu.Add(new MenuItemViewModel()
            {

                Icon = "ic_action_delete",
                Title = "Tareas Eliminadas",
                PageName = "NewTask"

            });

            Menu.Add(new MenuItemViewModel()
            {

                Icon = "ic_action_settings",
                Title = "Settings",
                PageName = "NewTask"

            });



            Menu.Add(new MenuItemViewModel()
            {

                Icon = "ic_action_user",
                Title = "Cerrar Sesión",
                //PageName = ""

            });

        }

        #endregion
    }
}
