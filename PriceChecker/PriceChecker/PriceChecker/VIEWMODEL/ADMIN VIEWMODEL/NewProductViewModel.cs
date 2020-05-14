using PriceChecker.SERVICE;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PriceChecker.MODEL;
using Xamarin.Forms;
using PriceChecker.VIEW;
using PriceChecker.Validation.Behavior;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using static Android.Media.MediaCodec.CryptoInfo;

namespace PriceChecker.VIEWMODEL.ADMIN_VIEWMODEL
{
    public class NewProductViewModel : BaseProductViewModel
    {
        public ICommand AddProductCommand { get; set; }

        private List<ProductInfo> _CheckedProductList;
        private static string ShopCode = "^[D,A,N,T,E,M,O,J,I,S]{1,10}$";
       

        public NewProductViewModel(INavigation navigation,bool iseditable)
        {
            IsEditable = iseditable;
            Regex rgx = new Regex(ShopCode);
            PropertyChanged += OnProductAddPropertyChanged;
            _Navigation = navigation;
            ProductRepository = new ProductRepository();
            _ProductInfo = new ProductInfo();
           AddProductCommand = new Command(
               execute:async () => 
                   {
                       PropertyChanged -= OnProductAddPropertyChanged;
                        await AddCommand();
                   },
            canExecute: () =>
            {
                _CheckedProductList = ProductRepository.CheckProductDuplicateInsert(ProductName);
                return ProductCode != null &&
                         ProductName != null &&
                          ProductPrice != null &&
                           ProductCode.Length > 0 &&
                            ProductName.Length > 2 &&
                             ProductPrice.Length > 0 &&
                             _CheckedProductList.Count == 0 &&
                              rgx.IsMatch(ProductCode);
                           
            });

        }
    

        public async Task AddCommand()
        {
           
            ProductRepository.InsertProduct(_ProductInfo);
            await _Navigation.PushAsync(new AdminPage());
        }

    

        void OnProductAddPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            (AddProductCommand as Command).ChangeCanExecute();
        }


    }
}
