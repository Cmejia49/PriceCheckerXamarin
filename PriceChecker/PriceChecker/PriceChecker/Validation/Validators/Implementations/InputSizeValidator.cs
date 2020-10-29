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
#pragma warning disable CA1062 // Validate arguments of public methods
            return value.Length >= 3 && value.Length <= 12;
#pragma warning restore CA1062 // Validate arguments of public methods
        }
    }
}
