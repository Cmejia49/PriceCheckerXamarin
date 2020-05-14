using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using PriceChecker.MODEL;
using PriceChecker.SERVICE;
using PriceChecker.VIEW.ADMIN_VIEW;
using Xamarin.Forms;

namespace PriceChecker.VIEWMODEL.ADMIN_VIEWMODEL
{
    public class ProductDetailViewModel:BaseProductViewModel
    {
        public ICommand UpdateProductCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }
        public ICommand BarCodeGeneratorCommand { get; set; }
        private static string ShopCode = "^[D,A,N,T,E,M,O,J,I,S]{1,10}$";

        public ProductDetailViewModel(INavigation navigation, int selectedProductID, bool iseditable)
        {
            IsEditable = iseditable;
            Regex rgx = new Regex(ShopCode);
            PropertyChanged += OnPersonEditPropertyChanged;
            _Navigation = navigation;
            ProductRepository = new ProductRepository();
            _ProductInfo = new ProductInfo();
            _ProductInfo.ProductID = selectedProductID;
            UpdateProductCommand = new Xamarin.Forms.Command(
                execute: async () => {
                    PropertyChanged -= OnPersonEditPropertyChanged;
                    await UpdateCommand();
                }, 
                canExecute: () =>
                {
                    return ProductCode != null &&
                            ProductName != null &&
                             ProductPrice != null &&
                              ProductCode.Length > 0 &&
                               ProductName.Length > 2 &&
                                ProductPrice.Length > 0 &&
                                 rgx.IsMatch(ProductCode);

                });
            DeleteProductCommand = new Command(async () => await DeleteCommand());
            BarCodeGeneratorCommand = new Command(async () => await ShowBarCodeGenerator());
            GetProductData();
        }

        void GetProductData()
        {
            _ProductInfo = ProductRepository.GetProduct(_ProductInfo.ProductID);
        }
        async Task UpdateCommand()
        {
            ProductRepository.UpdateProduct(_ProductInfo);
            await _Navigation.PopAsync();
        }
        async Task DeleteCommand()
        {
            PropertyChanged -= OnPersonEditPropertyChanged;
            ProductRepository.DeleteProduct(_ProductInfo.ProductID);
            await _Navigation.PopAsync();
        }

        async Task ShowBarCodeGenerator()
        {
            await _Navigation.PushAsync(new BarCodeGeneratorPage(_ProductInfo.ProductID, IsEditable));
        }

        void OnPersonEditPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            (UpdateProductCommand as Command).ChangeCanExecute();
        }

        //productname == productname && productid != _selectedID
        //error

    }
}
