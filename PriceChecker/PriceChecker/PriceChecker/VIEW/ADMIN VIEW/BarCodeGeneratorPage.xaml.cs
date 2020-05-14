using PriceChecker.VIEWMODEL;
using PriceChecker.VIEWMODEL.ADMIN_VIEWMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PriceChecker.VIEW.ADMIN_VIEW
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BarCodeGeneratorPage : ContentPage
	{
		public BarCodeGeneratorPage(int productID, bool iseditable)
		{
            InitializeComponent();
            BindingContext = new ProductDetailViewModel(Navigation,productID, iseditable);
        }
    
    }
}