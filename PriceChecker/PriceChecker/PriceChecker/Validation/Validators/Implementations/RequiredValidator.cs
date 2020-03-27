using System;
using System.Collections.Generic;
using System.Text;
using PriceChecker.Validation.Validators.Contracts;
namespace PriceChecker.Validation.Validators.Implementations
{
    public class RequiredValidator : IValidator
    {
        public string Message { get; set; } = "Please Don't Leave This Empty";

        public bool check(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}
