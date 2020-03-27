using PriceChecker.Validation.Validators.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PriceChecker.Validation.Validators.Implementations
{
    public class FormatValidator:IValidator
    {
        public string Message { get; set; } = "Invalid format";
        public string Format { get; set; }

        public bool check(string value)
        {
            Regex rgx = new Regex(Format);
            if (!string.IsNullOrWhiteSpace(value))
            {
                return rgx.IsMatch(value);
            }

            return false;
        }
    }
}
