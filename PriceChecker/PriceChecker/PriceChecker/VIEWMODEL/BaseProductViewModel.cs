using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using PriceChecker.MODEL;
using PriceChecker.SERVICE;
using System;
using PriceChecker.VIEWMODEL.ADMIN_VIEWMODEL;
using PriceChecker.Validation.Validators.Implementations;

namespace PriceChecker.VIEWMODEL
{
    public class BaseProductViewModel : INotifyPropertyChanged 
    {

#pragma warning disable CA1051 // Do not declare visible instance fields
        public ProductInfo _ProductInfo;
  
#pragma warning restore CA1051 // Do not declare visible instance fields
#pragma warning disable CA1051 // Do not declare visible instance fields
        public INavigation _Navigation;
#pragma warning restore CA1051 // Do not declare visible instance fields
#pragma warning disable CA1051 // Do not declare visible instance fields
        public IProductRepository _IProductRepositoty;
#pragma warning restore CA1051 // Do not declare visible instance fields
#pragma warning disable CA1051 // Do not declare visible instance fields
        public NewProductViewModel _NewProductViewModel;
#pragma warning restore CA1051 // Do not declare visible instance fields
#pragma warning disable CA1051 // Do not declare visible instance fields
        public ProductDetailViewModel _ProductDetailViewModel;
#pragma warning restore CA1051 // Do not declare visible instance fields
 

        public int ProductID
        {
            get => _ProductInfo.ProductID;
            set
            {

                _ProductInfo.ProductID = value;
                OnpropertyChanged(nameof(ProductID));
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1304:Specify CultureInfo", Justification = "<Pending>")]
        public string ProductCode
        {
            get => _ProductInfo.ProductCode;
            set
            {
#pragma warning disable CA1062 // Validate arguments of public methods
                _ProductInfo.ProductCode = value.ToUpper();
#pragma warning restore CA1062 // Validate arguments of public methods
                OnpropertyChanged(nameof(ProductCode));
            }
        }

       
       public string ProductCategory
        {
            get => _ProductInfo.ProductCategory;
            set
            {
                _ProductInfo.ProductCategory = value;
                OnpropertyChanged(nameof(ProductCategory));
            }
        }
      
        public string ProductName
        {
            get => _ProductInfo.ProductName;
            set
            {
#pragma warning disable CA1062 // Validate arguments of public methods
#pragma warning disable CA1304 // Specify CultureInfo
                _ProductInfo.ProductName = value.ToUpper();
#pragma warning restore CA1304 // Specify CultureInfo
#pragma warning restore CA1062 // Validate arguments of public methods
                OnpropertyChanged(nameof(ProductName));
            }
        }
        public string ProductPrice
        {
            get => _ProductInfo.ProductPrice;
            set
            {
                _ProductInfo.ProductPrice = value;
                OnpropertyChanged(nameof(ProductPrice));
            }
        }
        List<ProductInfo> _ProductList;
#pragma warning disable CA2227 // Collection properties should be read only
        public List<ProductInfo> ProductList
#pragma warning restore CA2227 // Collection properties should be read only
        {
            get => _ProductList;
            set
            {
                _ProductList = value;
                OnpropertyChanged(nameof(ProductList));
            }
        }

        //Search property
#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable CA1707 // Identifiers should not contain underscores
        public string _SearchText { get; set; }
#pragma warning restore CA1707 // Identifiers should not contain underscores
#pragma warning restore IDE1006 // Naming Styles
        public string SearchText
        {
            get { return _SearchText; }
            set
            {
                _SearchText = value;

                OnpropertyChanged(nameof(SearchText));
                
            }
        }
#pragma warning disable IDE1006 // Naming Styles
        public string lblConvertCode { get; set; }
#pragma warning restore IDE1006 // Naming Styles
        public string LblConverCode
        {
            get => lblConvertCode;
            set
            {
                lblConvertCode = value;
                OnpropertyChanged(nameof(LblConverCode));
            }
        }

#pragma warning disable IDE1006 // Naming Styles
        public bool isEditable { get; set; }
#pragma warning restore IDE1006 // Naming Styles
        public bool IsEditable
        {
            get => isEditable;
            set
            {
                isEditable = value;
                OnpropertyChanged(nameof(IsEditable));
            }
        }

        internal IProductRepository ProductRepository { get => ProductRepository1; set => ProductRepository1 = value; }
      internal IProductRepository ProductRepository1 { get => _IProductRepositoty; set => _IProductRepositoty = value; }


   
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnpropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            
        }

    } 
}
