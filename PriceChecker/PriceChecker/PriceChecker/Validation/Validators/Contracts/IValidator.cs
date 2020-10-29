using System;
using System.Collections.Generic;
using System.Text;

namespace PriceChecker.Validation.Validators.Contracts
{
   public interface IValidator
    {
        string Message { get; set; }
        
#pragma warning disable IDE1006 // Naming Styles
        bool check(string value);
#pragma warning restore IDE1006 // Naming Styles
    }
}
