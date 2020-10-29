using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceChecker.VIEWMODEL.USER_VIEWMODEL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PriceChecker.VIEW.USER_VIEW
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserPage : ContentPage
	{
		public UserPage (string SearchString)
		{
			InitializeComponent ();
            BindingContext = new UserPageViewModel(Navigation, SearchString);
        }

	
	}
}