using SQLite;
using System;
using System.Collections.Generic;

namespace PriceChecker.MODEL
{
  
    [System.ComponentModel.DataAnnotations.Schema.Table("ProductInfo")]
    public class ProductInfo
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int ProductID { get; set; }

        [Column("ProductCode")]
        public string ProductCode { get; set; }

        [Column("ProductName")]
        public string ProductName { get; set; }

        [Column("ProductPrice")]
        public string ProductPrice { get; set; }

        [Column("ProductImagePath")]
        public string ProductImagePath { get; set; }


    }

   
     

}


    

