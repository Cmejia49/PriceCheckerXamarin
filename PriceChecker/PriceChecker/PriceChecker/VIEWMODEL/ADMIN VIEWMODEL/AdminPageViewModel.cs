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

#pragma warning disable CA1707 // Identifiers should not contain underscores
namespace PriceChecker.VIEWMODEL.ADMIN_VIEWMODEL
#pragma warning restore CA1707 // Identifiers should not contain underscores
{
   public class AdminPageViewModel:BaseProductViewModel
    {
        private readonly int _selectedID;
        
        private List<ProductInfo> _ItemsFiltered;
        private List<ProductInfo> _ItemsUnfiltered;


#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable IDE1006 // Naming Styles
        public ICommand _ShowNewProductPage { get; set; }
#pragma warning restore IDE1006 // Naming Styles
#pragma warning restore CA1707 // Identifiers should not contain underscores
#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable CA1707 // Identifiers should not contain underscores
        public ICommand _SearchProduct { get; private set; }
#pragma warning restore CA1707 // Identifiers should not contain underscores
#pragma warning restore IDE1006 // Naming Styles
        public AdminPageViewModel(INavigation navigation)
        {

            PropertyChanged -= OnProductAddPropertyChanged;
            PropertyChanged -= OnProductUpdatePropertyChanged;
            _NewProductViewModel = new NewProductViewModel(navigation,isEditable);
            _ProductDetailViewModel = new ProductDetailViewModel(navigation, _selectedID,IsEditable);

            _Navigation = navigation;

            _SearchProduct = new Xamarin.Forms.Command(this.PerformSearch);

            _ShowNewProductPage = new Xamarin.Forms.Command(
                execute: async () =>
                {
#pragma warning disable CA2007 // Consider calling ConfigureAwait on the awaited task
                    await ShowNewProductPage();
#pragma warning restore CA2007 // Consider calling ConfigureAwait on the awaited task
                });
         
            ProductRepository = new ProductRepository();
            _ProductInfo = new ProductInfo();
            GetProductData();
        }

        void GetProductData()
        {
            ProductList = ProductRepository.GetAllProductInfos();
            _ItemsUnfiltered = new List<ProductInfo>(ProductList);
        }

        public async Task ShowNewProductPage()
        {

            IsEditable = false;
#pragma warning disable CA2007 // Consider calling ConfigureAwait on the awaited task
            await _Navigation.PushAsync(new NewProduct(IsEditable));
#pragma warning restore CA2007 // Consider calling ConfigureAwait on the awaited task
        }
        async void ShowProductDetail(int selectedProductID)
        {
            IsEditable = true;
#pragma warning disable CA2007 // Consider calling ConfigureAwait on the awaited task
            await _Navigation.PushAsync(new ProductDetailPage(selectedProductID, IsEditable));
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

        void RefreshCanExecutes()
        {
            (_ShowNewProductPage as Command).ChangeCanExecute();
            (_NewProductViewModel.AddProductCommand as Command).ChangeCanExecute();
        }

        void OnProductAddPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            (_NewProductViewModel.AddProductCommand as Command).ChangeCanExecute();
        }
        void OnProductUpdatePropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            (_ProductDetailViewModel.UpdateProductCommand as Command).ChangeCanExecute();
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
