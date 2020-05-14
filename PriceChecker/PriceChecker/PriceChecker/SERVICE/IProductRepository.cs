using System;
using System.Collections.Generic;
using System.Text;
using PriceChecker.MODEL;
namespace PriceChecker.SERVICE
{
  public  interface IProductRepository
    {
        List<ProductInfo> GetAllProductInfos();

        List<ProductInfo> FindProductInfos(string productName);

        List<ProductInfo> CheckProductDuplicateInsert(string productName);

        ProductInfo GetProduct(int ID);

        void InsertProduct(ProductInfo product);

        void DeleteProduct(int productID);

        void UpdateProduct(ProductInfo product);


    }
}
