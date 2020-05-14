using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceChecker.VIEWMODEL.ADMIN_VIEWMODEL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PriceChecker.VIEW.ADMIN_VIEW
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductDetailPage : ContentPage
	{
		public ProductDetailPage (int productID, bool iseditable)
		{
            InitializeComponent();
               BindingContext = new ProductDetailViewModel(Navigation, productID,iseditable);
        }
	}
}