using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Windows.Input;

namespace GPIApp.Models
{
    public static class StaticTaskItem
    {
        public static TaskListItemModel previousElement;
    }

    public class TaskListItemModel : INotifyPropertyChanged
    {
        public string Title { get; set; }
        public bool IsVisible { get; set; }
        //Buttons
        public int Btn1 { get; set; }
        public int Btn2 { get; set; }
        public int Btn3 { get; set; }

        public ICommand HideOrShowElementCommand
        {
            get { return new RelayCommand(HideOrShowElement); }
        }

        public void HideOrShowElement()
        {
            HideOrShowElementMethod();


            if (StaticTaskItem.previousElement == null)
            {
                StaticTaskItem.previousElement = this;
            }
            else
            {
                if (!StaticTaskItem.previousElement.Equals(this))
                {
                    StaticTaskItem.previousElement.HideOrShowElementMethod();
                    StaticTaskItem.previousElement = this;
                }
                else
                {
                    StaticTaskItem.previousElement = null;
                }
            }
        }

        public void HideOrShowElementMethod()
        {
            IsVisible = !IsVisible;
            if (IsVisible)
            {
                Btn1 = 1;
                Btn2 = 2;
                Btn3 = 3;
            }
            else
            {
                Btn1 = Btn2 = Btn3 = 0;
            }

            OnPropertyChanged("IsVisible");
            OnPropertyChanged("Btn1");
            OnPropertyChanged("Btn2");
            OnPropertyChanged("Btn3");
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
