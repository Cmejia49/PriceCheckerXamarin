using PriceChecker.Validation.Validators.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceChecker.Validation.Validators.Implementations
{
    public class InputSizeValidator : IValidator
    {
        public string Message { get; set; } = "Name must be 3 to 12 characters";

        public bool check(string value)
        {
            return value.Length >= 3 && value.Length <= 12;
        }
    }
}
