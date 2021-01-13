using PriceChecker.VIEWMODEL;
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
	public partial class MainMenuPage : ContentPage
	{
		public MainMenuPage ()
		{
			InitializeComponent ();
            this.BindingContext = new MainMuneViewModel(Navigation);
        }
	}
}