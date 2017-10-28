using GPIApp.ViewModels;

namespace GPIApp.Infraestructure
{
    class InstanceLocator
    {
        public InstanceLocator()
        {
            VMControl = new ViewModelsCtrl();
        }

        public ViewModelsCtrl VMControl { get; set; }
    }
}
