using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GPIApp.ViewModels
{
    class ViewModelsCtrl : INotifyPropertyChanged
    {
        public LoginViewModel LoginVM
        {
            get
            {
                return VMContainer.LoginVM;
            }
        }

        public MainViewModel MainVM
        {
            get
            {
                return VMContainer.MainVM;
            }
        }

        public NewEditTaskViewModel NewEditTaskVM
        {
            get
            {
                return VMContainer.NewEditTaskVM;
            }
        }

        public ICommand PruebaCommand
        {
            get { return new RelayCommand(Prueba); }
        }

        public void Prueba()
        {
            OnPropertyChanged("MainVM");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
