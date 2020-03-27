using System.Collections.Generic;
using PriceChecker.MODEL;
using PriceChecker.sqliteHELPER;
namespace PriceChecker.SERVICE
{
    public class ProductRepository : IProductRepository
    {
        SQliteHelper _SqliteHelper;
        public ProductRepository()
        {
            _SqliteHelper = new SQliteHelper();
        }

        public void DeleteProduct(int productID)
        {
            _SqliteHelper.DeleteProduct(productID);
        }

        public List<ProductInfo> FindProductInfos(string productName)
        {
           return _SqliteHelper.FindProductInfos(productName);
        }

        public List<ProductInfo> GetAllProductInfos()
        {
          return  _SqliteHelper.GetAllProductInfos();
        }

        public ProductInfo GetProduct(int ID)
        {
          return  _SqliteHelper.GetProductData(ID);
        }

        public void InsertProduct(ProductInfo product)
        {
            _SqliteHelper.InsertProduct(product);
        }

        public void UpdateProduct(ProductInfo product)
        {
            _SqliteHelper.UpdateProduct(product);
        }
    }
}
