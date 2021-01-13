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

       
        private List<ProductInfo> ItemsFiltered;
        private List<ProductInfo> ItemsUnfiltered;     
        public ICommand ShowScanPageCommand { get; set; }
        public ICommand SearchProductCommand { get; private set; }
        public UserPageViewModel(INavigation navigation,string searchString)
        {
            Navigation = navigation;
            ShowScanPageCommand = new Command(async () => await ShowScanPage().ConfigureAwait(false));
            SearchProductCommand = new Command(this.PerformSearch);
            ProductInfo = new ProductInfo();
            ProductRepository = new ProductRepository();
            SearchText = searchString;
            GetProductData();
        }

        void GetProductData()
        {
            ProductList = ProductRepository.GetAllProductInfos();
            ItemsUnfiltered = new List<ProductInfo>(ProductList);
        }
        private async Task ShowScanPage()
        {
            await Navigation.PushAsync(new BarCodePageScan());
        }
        private async void ShowProductDetail(int selectedProductID)
        {

            await Navigation.PushAsync(new UserProductDetailPage(selectedProductID));
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
                    OnPropertyChanged(nameof(SelectedProductID));
                    ShowProductDetail(_SelectedProductID.ProductID);
                }
            }
        }


        public void PerformSearch()
        {
            if (string.IsNullOrWhiteSpace(this.SearchText))
                ProductList = ItemsUnfiltered;
            else
            {
                ItemsFiltered = ProductRepository.FindProductInfos(SearchText);

                ProductList = ItemsFiltered;
            }
        }
    }
}
