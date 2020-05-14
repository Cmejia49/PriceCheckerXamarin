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
	public partial class BarCodePageScan : ContentPage
	{
		public BarCodePageScan ()
		{
			InitializeComponent ();
            BindingContext = new BarCodeScanViewModel(Navigation);
		}
	}
}