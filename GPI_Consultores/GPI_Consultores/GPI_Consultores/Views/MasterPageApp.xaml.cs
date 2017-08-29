using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GPI_Consultores.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterPageApp : MasterDetailPage
	{
		public MasterPageApp ()
		{
			InitializeComponent ();
            Init();
		}


        void Init ()
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
       
            Detail = new NavigationPage(new ItemsPage());
            Detail = new NavigationPage(new AgregarTarea());
        }

        private void ListMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           var menu = e.SelectedItem as Menu;
            if (menu != null)
            {
                if (menu.MenuTitle.Equals("Inicio"))
                {
                    Detail = new NavigationPage( new ItemsPage());
                }else if (menu.MenuTitle.Equals("Crear Nueva Tarea"))
                {
                    Detail = new NavigationPage(new AgregarTarea());
                }
            }
        }
    }

    public class Menu
    {

        public string MenuTitle { 
            get;
            set;
        }

        public string MenuDetail {

            get;
            set;

        }
    }
}