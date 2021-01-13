using PriceChecker.VIEWMODEL.ADMIN_VIEWMODEL;
using Xamarin.Forms.Xaml;
using PriceChecker.VIEW.Custom;
namespace PriceChecker.VIEW.ADMIN_VIEW
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewProduct : CustomContentPage
    {
  
		public NewProduct(bool iseditable)
		{
       
			InitializeComponent ();
            BindingContext = new NewProductViewModel(Navigation,iseditable);
      


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
                        NewProductViewModel newProductViewModel = BindingContext as NewProductViewModel;
                        if (newProductViewModel.DeleteImgProductCommand.CanExecute(null))
                            newProductViewModel.DeleteImgProductCommand.Execute(null);
                        await Navigation.PopAsync(true);
                    }
                };
            }
        }


    }
}