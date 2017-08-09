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
       
            Detail = new NavigationPage(new ItemsPage());
        }
	}
}