namespace GPI_Consultores.Models
{
    public class User : BaseDataObject
    {
        string usuario = string.Empty;
        public string Usuario
        {
            get { return usuario; }
            set { SetProperty(ref usuario, value); }
        }

        string contrasenia = string.Empty;
        public string Contrasenia
        {
            get { return contrasenia; }
            set { SetProperty(ref contrasenia, value); }
        }
    }
}
