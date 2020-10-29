using PriceChecker.MODEL;
using PriceChecker.SERVICE;
using PriceChecker.VIEW.USER_VIEW;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PriceChecker.VIEWMODEL.USER_VIEWMODEL
{
   public class UserProductDetailViewModel:BaseProductViewModel
    {

#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable CA1707 // Identifiers should not contain underscores
        public ICommand _codeConverter { get; private set; }
#pragma warning restore CA1707 // Identifiers should not contain underscores
#pragma warning restore IDE1006 // Naming Styles

        public UserProductDetailViewModel(INavigation navigation, int selectedProductID)
        {
            ProductRepository = new ProductRepository();
            _ProductInfo = new ProductInfo();
            _ProductInfo.ProductID = selectedProductID;
            _Navigation = navigation;

            _codeConverter = new Xamarin.Forms.Command(execute:  () =>
            {
                PropertyChanged += OnCodeConverterPropertyChanged;
                 CodeConverter();
            },
            canExecute: () =>
            {
                return LblConverCode == null;

            });

            FetchProductData();
        }

        void FetchProductData()
        {
            _ProductInfo = ProductRepository.GetProduct(_ProductInfo.ProductID);
        }

        public void CodeConverter()
        {
            char[] code = new char[10] { 'S', 'D', 'A', 'N', 'T', 'E', 'M', 'O', 'J', 'I' };
            char[] arrayProductCode = _ProductInfo.ProductCode.ToCharArray();
            for (int i = 0; i < arrayProductCode.Length; i++)
            {
                for(int j = 0; j < code.Length; j++)
                {
                    if(arrayProductCode[i] == code[j] )
                    {

#pragma warning disable CA1305 // Specify IFormatProvider
                        LblConverCode += j.ToString();
#pragma warning restore CA1305 // Specify IFormatProvider

                    }
                }   
            }

          
        }
        void OnCodeConverterPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            (_codeConverter as Command).ChangeCanExecute();
        }

    }
}
