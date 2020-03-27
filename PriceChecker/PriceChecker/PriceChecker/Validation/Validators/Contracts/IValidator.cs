using System;
using System.Collections.Generic;
using System.Text;

namespace PriceChecker.Validation.Validators.Contracts
{
   public interface IValidator
    {
        string Message { get; set; }
        bool check(string value);
    }
}
