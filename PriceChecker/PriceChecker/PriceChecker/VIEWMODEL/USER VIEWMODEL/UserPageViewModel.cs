using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using PriceChecker.VIEW.USER_VIEW;
using PriceChecker.MODEL;
using PriceChecker.SERVICE;
using System.Collections.ObjectModel;
using System.Linq;

namespace PriceChecker.VIEWMODEL.USER_VIEWMODEL
{
   public class UserPageViewModel:BaseProductViewModel
    {

       
        private List<ProductInfo> _ItemsFiltered;
        private List<ProductInfo> _ItemsUnfiltered;
      


#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable CA1707 // Identifiers should not contain underscores
        public ICommand _ShowScanPage { get; set; }
#pragma warning restore CA1707 // Identifiers should not contain underscores
#pragma warning restore IDE1006 // Naming Styles
#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable CA1707 // Identifiers should not contain underscores
        public ICommand _SearchProduct { get; private set; }
#pragma warning restore CA1707 // Identifiers should not contain underscores
#pragma warning restore IDE1006 // Naming Styles
       

        public UserPageViewModel(INavigation navigation,string searchString)
        {
            _Navigation = navigation;
#pragma warning disable CA2007 // Consider calling ConfigureAwait on the awaited task
            _ShowScanPage = new Xamarin.Forms.Command(async () => await ShowScanPage());
#pragma warning restore CA2007 // Consider calling ConfigureAwait on the awaited task
            _SearchProduct = new Xamarin.Forms.Command(this.PerformSearch);
            _ProductInfo = new ProductInfo();
            ProductRepository = new ProductRepository();
            SearchText = searchString;



            GetProductData();
        }

        void GetProductData()
        {
            ProductList = ProductRepository.GetAllProductInfos();
            _ItemsUnfiltered = new List<ProductInfo>(ProductList);
        }

        public async Task ShowScanPage()
        {
#pragma warning disable CA2007 // Consider calling ConfigureAwait on the awaited task
            await _Navigation.PushAsync(new BarCodePageScan());
#pragma warning restore CA2007 // Consider calling ConfigureAwait on the awaited task
        }
        async void ShowProductDetail(int selectedProductID)
        {
#pragma warning disable CA2007 // Consider calling ConfigureAwait on the awaited task
            await _Navigation.PushAsync(new UserProductDetailPage(selectedProductID));
#pragma warning restore CA2007 // Consider calling ConfigureAwait on the awaited task
        }

        ProductInfo _SelectedProductID;
        public ProductInfo SelectedProductID
        {
            get
            {
                return _SelectedProductID;
            }

            set
            {
                if (value != null)
                {
                    _SelectedProductID = value;
                    OnpropertyChanged(nameof(SelectedProductID));
                    ShowProductDetail(_SelectedProductID.ProductID);
                }
            }
        }


        public void PerformSearch()
        {
            if (string.IsNullOrWhiteSpace(this._SearchText))
                ProductList = _ItemsUnfiltered;
            else
            {
                _ItemsFiltered = ProductRepository.FindProductInfos(_SearchText);

                ProductList = _ItemsFiltered;
            }
        }
    }
}
