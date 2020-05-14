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
      


        public ICommand _ShowScanPage { get; set; }
        public ICommand _SearchProduct { get; private set; }
       

        public UserPageViewModel(INavigation navigation,string searchString)
        {
            _Navigation = navigation;
            _ShowScanPage = new Xamarin.Forms.Command(async () => await ShowScanPage());
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
            await _Navigation.PushAsync(new BarCodePageScan());
        }
        async void ShowProductDetail(int selectedProductID)
        {
            await _Navigation.PushAsync(new UserProductDetailPage(selectedProductID));
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
                    OnpropertyChanged("SelectedProductID");
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
