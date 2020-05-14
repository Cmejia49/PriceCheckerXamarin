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

        public ProductInfo _ProductInfo;
        public INavigation _Navigation;
        public IProductRepository _IProductRepositoty;
        public NewProductViewModel _NewProductViewModel;
        public ProductDetailViewModel _ProductDetailViewModel;
      
        public int ProductID
        {
            get => _ProductInfo.ProductID;
            set
            {

                _ProductInfo.ProductID = value;
                OnpropertyChanged("ProductID");
            }
        }
        public string ProductCode
        {
            get => _ProductInfo.ProductCode;
            set
            {  
                    _ProductInfo.ProductCode = value.ToUpper();
                    OnpropertyChanged("ProductCode");
            }
        }

        public string ProductName
        {
            get => _ProductInfo.ProductName;
            set
            {
                _ProductInfo.ProductName = value.ToUpper();
                OnpropertyChanged("ProductName");
            }
        }
        public string ProductPrice
        {
            get => _ProductInfo.ProductPrice;
            set
            {
                _ProductInfo.ProductPrice = value;
                OnpropertyChanged("ProductPrice");
            }
        }
        List<ProductInfo> _ProductList;
        public List<ProductInfo> ProductList
        {
            get => _ProductList;
            set
            {
                _ProductList = value;
                OnpropertyChanged("ProductList");
            }
        }

        //Search property
        public string _SearchText { get; set; }
        public string SearchText
        {
            get { return _SearchText; }
            set
            {
                _SearchText = value;

                OnpropertyChanged("SearchText");
                
            }
        }
        public string lblConvertCode { get; set; }
        public string LblConverCode
        {
            get => lblConvertCode;
            set
            {
                lblConvertCode = value;
                OnpropertyChanged("LblConverCode");
            }
        }

        public bool isEditable { get; set; }
        public bool IsEditable
        {
            get => isEditable;
            set
            {
                isEditable = value;
                OnpropertyChanged("IsEditable");
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
