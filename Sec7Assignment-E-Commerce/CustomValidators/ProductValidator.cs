using System.ComponentModel.DataAnnotations;
using Sec7Assignment_E_Commerce.Models;

namespace Sec7Assignment_E_Commerce.CustomValidators
{
    public class ProductValidator : ValidationAttribute
    {
        string DefaultErrMsg { get; set; } = "Order Should have atleast one product";
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                List<Product> products = (List<Product>)value;
                if(products.Count == 0)
                {
                    return new ValidationResult(DefaultErrMsg,new string[] {nameof(validationContext.MemberName)});
                }
                return ValidationResult.Success;
            }
            return null;
        }
    }
}
