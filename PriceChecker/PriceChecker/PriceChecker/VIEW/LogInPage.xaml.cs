using PriceChecker.VIEWMODEL;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PriceChecker.VIEW
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LogInPage:PopupPage
    {
    
		public LogInPage (INavigation navigation)
		{
			InitializeComponent ();
            BindingContext = new AdminViewModel(navigation);   
        }
	}
}