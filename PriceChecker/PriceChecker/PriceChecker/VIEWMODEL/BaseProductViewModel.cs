using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using PriceChecker.MODEL;
using PriceChecker.SERVICE;
using System;
using PriceChecker.VIEWMODEL.ADMIN_VIEWMODEL;
using PriceChecker.Validation.Validators.Implementations;
using System.Collections.ObjectModel;
using System.Globalization;

namespace PriceChecker.VIEWMODEL
{
    public class BaseProductViewModel : INotifyPropertyChanged 
    {


         internal ProductInfo ProductInfo;
         internal INavigation Navigation;
         internal IProductRepository IProductRepositoty;
         internal NewProductViewModel NewProductViewModel;
         internal ProductDetailViewModel ProductDetailViewModel;

 

        public int ProductID
        {
            get => ProductInfo.ProductID;
            set
            {

                ProductInfo.ProductID = value;
                OnPropertyChanged(nameof(ProductID));
            }
        }

        public string ProductCode
        {
            get => ProductInfo.ProductCode;
            set
            {

                ProductInfo.ProductCode = value.ToUpper(CultureInfo.InvariantCulture);
                OnPropertyChanged(nameof(ProductCode));
            }
        }
   
        public string ProductName
        {
            get => ProductInfo.ProductName;
            set
            {
                ProductInfo.ProductName = value.ToUpper(CultureInfo.InvariantCulture);
                OnPropertyChanged(nameof(ProductName));
            }
        }
        public string ProductPrice
        {
            get => ProductInfo.ProductPrice;
            set
            {
                ProductInfo.ProductPrice = value;
                OnPropertyChanged(nameof(ProductPrice));
            }
        }
      
        public string ProductImagePath
        {
            get => ProductInfo.ProductImagePath;
            set
            {
                ProductInfo.ProductImagePath = value;
                OnPropertyChanged(nameof(ProductImagePath));
            }
        }

       private List<ProductInfo> _ProductList;
#pragma warning disable CA1002 // Do not expose generic lists
        public List<ProductInfo> ProductList
#pragma warning restore CA1002 // Do not expose generic lists

        {
            get => _ProductList;
          internal set
            {
                _ProductList = value;
                OnPropertyChanged(nameof(ProductList));
            }

        }


        private string _SearchText { get; set; }
        public string SearchText
        {
            get { return _SearchText; }
            set
            {
                _SearchText = value;

                OnPropertyChanged(nameof(SearchText));
                
            }
        }

        private string _lblConvertCode { get; set; }

        public string LblConverCode
        {
            get => _lblConvertCode;
            set
            {
                _lblConvertCode = value;
                OnPropertyChanged(nameof(LblConverCode));
            }
        }

        private bool isEditable { get; set; }

        public bool IsEditable
        {
            get => isEditable;
            set
            {
                isEditable = value;
                OnPropertyChanged(nameof(IsEditable));
            }
        }

   

        internal IProductRepository ProductRepository { get => ProductRepository1; set => ProductRepository1 = value; }
      internal IProductRepository ProductRepository1 { get => IProductRepositoty; set => IProductRepositoty = value; }


   
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            
        }

    } 
}
