using PriceChecker.VIEW.Custom;
using PriceChecker.VIEWMODEL.USER_VIEWMODEL;
using Xamarin.Forms.Xaml;

namespace PriceChecker.VIEW.USER_VIEW
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserProductDetailPage : CustomContentPage
	{
		public UserProductDetailPage(int selectedProductID)
		{
			InitializeComponent();
            BindingContext = new UserProductDetailViewModel(Navigation,selectedProductID);
        }
	}
}