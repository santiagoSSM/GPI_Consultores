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
                new Menu { MenuTitle = "Opciones", MenuDetail = "Navegar"}
            };

            ListMenu.ItemsSource = menu;

            Device.OnPlatform(Android: () => {

                ListMenu.Margin = new Thickness(0, 21, 0, 0);

            }, iOS: () => {

                ListMenu.Margin = new Thickness(0, 21, 0, 0);

            });
       
            Detail = new NavigationPage(new ItemsPage());
        }

        private void ListMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           var menu = e.SelectedItem as Menu;
            if (menu != null)
            {
                if (menu.MenuTitle.Equals("Inicio"))
                {
                    Detail = new NavigationPage( new ItemsPage());
                }else if (menu.MenuTitle.Equals("Opciones"))
                {
                    Detail = new NavigationPage(new ItemsPage());
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