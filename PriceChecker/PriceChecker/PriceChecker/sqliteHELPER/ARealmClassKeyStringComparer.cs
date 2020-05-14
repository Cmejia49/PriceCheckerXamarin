using PriceChecker.MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceChecker.sqliteHELPER
{
    public class ARealmClassKeyStringComparer : IEqualityComparer<ProductInfo>
    {
        public bool Equals(ProductInfo x, ProductInfo y)
        {
            return (x.ProductName == y.ProductName);
        }

        public int GetHashCode(ProductInfo obj)
        {
            if (ReferenceEquals(obj, null)) return 0;
            return obj.ProductName.GetHashCode();
        }
    }
}
