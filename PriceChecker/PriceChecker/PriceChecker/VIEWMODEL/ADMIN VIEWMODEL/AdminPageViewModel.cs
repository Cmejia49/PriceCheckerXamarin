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
        private int _selectedID;
        public ICommand _ShowNewProductPage { get; set; }
        public AdminPageViewModel(INavigation navigation)
        {

            PropertyChanged -= OnProductAddPropertyChanged;
            PropertyChanged -= OnProductUpdatePropertyChanged;
            _NewProductViewModel = new NewProductViewModel(navigation);
            _ProductDetailViewModel = new ProductDetailViewModel(navigation, _selectedID);

            _Navigation = navigation;


            _ShowNewProductPage = new Xamarin.Forms.Command(
                execute: async () =>
                {
                    await ShowNewProductPage();
                });
         
            ProductRepository = new ProductRepository();
            _ProductInfo = new ProductInfo();
            GetProductData();
        }

        void GetProductData()
        {
            ProductList = ProductRepository.GetAllProductInfos();
        }

        public async Task ShowNewProductPage()
        {
           
            await _Navigation.PushAsync(new NewProduct());
        }
        async void ShowProductDetail(int selectedProductID)
        {
            await _Navigation.PushAsync(new ProductDetailPage(selectedProductID));
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

    }
}
