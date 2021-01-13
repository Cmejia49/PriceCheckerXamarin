using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PriceChecker.VIEWMODEL;
using Xamarin.Forms;
using PriceChecker.SERVICE;
using PriceChecker.VIEW.ADMIN_VIEW;
using PriceChecker.MODEL;
using System.ComponentModel;

namespace PriceChecker.VIEWMODEL.ADMIN_VIEWMODEL

{
   public class AdminPageViewModel:BaseProductViewModel
    {
        private readonly int _selectedID;
        
        private List<ProductInfo> ItemsFiltered;
        private List<ProductInfo> ItemsUnfiltered;
        public ICommand SearchProductCommand { get; private set; }
        public ICommand ShowNewProductPageCommand { get; set; }

        public AdminPageViewModel(INavigation navigation)
        {

            PropertyChanged -= OnProductAddPropertyChanged;
            PropertyChanged -= OnProductUpdatePropertyChanged;
            NewProductViewModel = new NewProductViewModel(navigation,IsEditable);
            ProductDetailViewModel = new ProductDetailViewModel(navigation, _selectedID,IsEditable);
            Navigation = navigation;
            SearchProductCommand = new Xamarin.Forms.Command(this.PerformSearch);
            ShowNewProductPageCommand = new Command(async () => await ShowNewProductPage().ConfigureAwait(false));
            ProductRepository = new ProductRepository();
            ProductInfo = new ProductInfo();
            GetProductData();
        }
        void GetProductData()
        {
            ProductList = ProductRepository.GetAllProductInfos();
            ItemsUnfiltered = new List<ProductInfo>(ProductList);
        }
        private async Task ShowNewProductPage()
        {
            IsEditable = false;
            await Navigation.PushAsync(new NewProduct(IsEditable));
        }
        private async void ShowProductDetail(int selectedProductID)
        {
            IsEditable = true;
            await Navigation.PushAsync(new ProductDetailPage(selectedProductID, IsEditable));

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

        void RefreshCanExecutes()
        {
            (ShowNewProductPageCommand as Command).ChangeCanExecute();
            (NewProductViewModel.AddProductCommand as Command).ChangeCanExecute();
        }

        void OnProductAddPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            (NewProductViewModel.AddProductCommand as Command).ChangeCanExecute();
        }
        void OnProductUpdatePropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            (ProductDetailViewModel.UpdateProductCommand as Command).ChangeCanExecute();
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
