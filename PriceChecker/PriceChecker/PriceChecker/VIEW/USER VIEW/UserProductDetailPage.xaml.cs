using PriceChecker.VIEWMODEL.USER_VIEWMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PriceChecker.VIEW.USER_VIEW
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserProductDetailPage : ContentPage
	{
		public UserProductDetailPage(int selectedProductID)
		{
			InitializeComponent();
            BindingContext = new UserProductDetailViewModel(Navigation,selectedProductID);
        }
	}
}