using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceChecker.VIEWMODEL.ADMIN_VIEWMODEL;
using PriceChecker.VIEWMODEL.ValidationCommands;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PriceChecker.VIEW.ADMIN_VIEW
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewProduct : ContentPage
	{
		public NewProduct()
		{
			InitializeComponent ();
            this.BindingContext = new NewProductViewModel(Navigation);
        //    this.BindingContext = new ValidationCommand();

        }
    }
}