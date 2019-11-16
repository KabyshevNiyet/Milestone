using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoService.Utilities
{
    public class ValidLogin: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                String v = value.ToString();
                if ((v.Any(char.IsLetter) && v.Any(char.IsDigit)) || (v.Any(char.IsLetter)))
                    return ValidationResult.Success;
            }
            return new ValidationResult("Text must be only with characters!");
        }
    }
}
