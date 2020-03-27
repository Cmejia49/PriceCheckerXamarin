using PriceChecker.MODEL;
using PriceChecker.SERVICE;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceChecker.VIEWMODEL.USER_VIEWMODEL
{
   public class UserProductDetailViewModel:BaseProductViewModel
    {
     
        public UserProductDetailViewModel(int selectedProductID)
        {
            ProductRepository = new ProductRepository();
            _ProductInfo = new ProductInfo();
            _ProductInfo.ProductID = selectedProductID;
            FetchProductData();
        }

        void FetchProductData()
        {
            _ProductInfo = ProductRepository.GetProduct(_ProductInfo.ProductID);
        }

        public int codeConverter()
        {

            char[] code = new char[10] { 'S', 'D', 'A', 'N', 'T', 'E', 'M', 'O', 'J', 'I' };

            return 0;
        }
    }
}
