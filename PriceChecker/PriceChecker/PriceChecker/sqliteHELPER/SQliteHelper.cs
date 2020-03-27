using SQLite;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using PriceChecker.MODEL;
using System;

namespace PriceChecker.sqliteHELPER
{
    public class SQliteHelper
    {

        SQLiteConnection sqliteConnection;
        public const string DbFileName = "product.db3";

        public SQliteHelper()
        {
            sqliteConnection = DependencyService.Get<ISQLite>().GetConnection();
            sqliteConnection.CreateTable<ProductInfo>();
        }

        // Get All Contact data      
        public List<ProductInfo> GetAllProductInfos()
        {
            return (from data in sqliteConnection.Table<ProductInfo>()
                    select data).ToList();
        }
        // Search Product
        public List<ProductInfo> FindProductInfos(string productName)
        {
            return ( from s in sqliteConnection.Table<ProductInfo>()
                        where s.ProductName.StartsWith(productName)
                        select s).ToList();
        
        }

        public ProductInfo GetProductData(int id)
        {
            return sqliteConnection.Table<ProductInfo>().FirstOrDefault(t => t.ProductID == id);
        }

        //Insert data
        public void InsertProduct(ProductInfo product)
        {
            sqliteConnection.Insert(product);
        }

        public void DeleteProduct(int productID)
        {
            sqliteConnection.Delete<ProductInfo>(productID);
        }
        public void UpdateProduct(ProductInfo product)
        {
            sqliteConnection.Update(product);
        }
    }
}
