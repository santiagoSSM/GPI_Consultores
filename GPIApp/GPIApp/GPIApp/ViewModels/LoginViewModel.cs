﻿using GalaSoft.MvvmLight.Command;
using GPIApp.Infraestructure;
using GPIApp.Models;
using GPIApp.Views.PopUps.Generic;
using GPIApp.WebApi;
using Rg.Plugins.Popup.Services;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GPIApp.ViewModels
{
    public static class UserLogged
    {
        public static UserModel Value { get; set; }
    }
    public class LoginViewModel
    {
        NavigationService navServ;
        public UserPassModel User { get; set; }

        public LoginViewModel(IVMContainer inter)
        {
            navServ = new NavigationService(inter);
            User = new UserPassModel();
        }

        public ICommand LoginCommand
        {
            get { return new RelayCommand(Login); }
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(User.NameUser))
            {
                await DialogService.ShowMessage("Error", "Debe ingresar un usuario", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(User.PassUser))
            {
                await DialogService.ShowMessage("Error", "Debe ingresar una contraseña", "Aceptar");
                return;
            }


            try
            {
                await PopupNavigation.PushAsync(new ActivityIndicatorPopUp("Cargando"));
                UserLogged.Value = await UserWACtrl.Put(User);
                if (UserLogged.Value != null)
                {
                    await navServ.SetPageAsync("MasterPage");
                }
                else
                {
                    await DialogService.ShowMessage("Error", "Usuario y contraseña incorrectos", "Aceptar");
                }
            }
            catch (Exception e)
            {
                await DialogService.ShowMessage("Error", e.Message, "Aceptar");
            }
            finally
            {
                await PopupNavigation.PopAllAsync();
            }
        }
    }
}
