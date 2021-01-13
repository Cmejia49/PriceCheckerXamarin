using PriceChecker.VIEW.Custom;
using PriceChecker.VIEWMODEL.USER_VIEWMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

#pragma warning disable CA1707 // Identifiers should not contain underscores
namespace PriceChecker.VIEW.USER_VIEW
#pragma warning restore CA1707 // Identifiers should not contain underscores
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BarCodePageScan : CustomContentPage
	{
		public BarCodePageScan ()
		{
			InitializeComponent ();
            BindingContext = new BarCodeScanViewModel(Navigation);
		}
	}
}