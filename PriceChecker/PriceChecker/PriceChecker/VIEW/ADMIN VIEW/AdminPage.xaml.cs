using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceChecker.VIEW.Custom;
using PriceChecker.VIEWMODEL.ADMIN_VIEWMODEL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PriceChecker.VIEW
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdminPage : CustomContentPage
	{
		public AdminPage ()
		{
			InitializeComponent ();
         
		}
        protected override void OnAppearing()
        {
            BindingContext = new AdminPageViewModel(Navigation);
        }
    }
}