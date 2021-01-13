using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceChecker.VIEW.Custom;
using PriceChecker.VIEWMODEL.ADMIN_VIEWMODEL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PriceChecker.VIEW.ADMIN_VIEW
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductDetailPage : CustomContentPage
	{
		public ProductDetailPage (int productID, bool iseditable)
		{
            InitializeComponent();
               BindingContext = new ProductDetailViewModel(Navigation, productID,iseditable);

            if (EnableBackButtonOverride)
            {
                this.CustomBackButtonAction = async () =>
                {
                    var result = await this.DisplayAlert(null,
                        "Hey wait now! are you sure " +
                        "you want to go back?",
                        "Yes go back", "Nope");

                    if (result)
                    {
                        await Navigation.PopAsync(true);
                    }
                };
            }
        }
	}
}