using GPIApp.ViewModels;

namespace GPIApp.Infraestructure
{
    class InstanceLocator
    {
        public InstanceLocator()
        {
            VMControl = new VMContainer();

            VMControl.LoginVMInit();

            //Todo inicio rapido eliminar despues
            VMControl.LoginVM.User.NameUser = "user";
            VMControl.LoginVM.User.PassUser = "pass";
        }

        public VMContainer VMControl { get; set; }
    }
}
