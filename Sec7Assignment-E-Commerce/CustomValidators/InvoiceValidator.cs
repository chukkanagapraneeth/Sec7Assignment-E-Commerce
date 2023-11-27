using Sec7Assignment_E_Commerce.Models;
using System.ComponentModel.DataAnnotations;

namespace Sec7Assignment_E_Commerce.CustomValidators
{
    public class InvoiceValidator : ValidationAttribute
    {
        public string DefaultErrMsg { get; set; } = "{0} should be equal to the total price of all the products i.e. {1} in this case";
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                double providedAmount = Convert.ToDouble(value);
                double totalAmount = 0;


                var prod = validationContext.ObjectType.GetProperty("Products");
                List<Product> prod_list = (List<Product>)prod.GetValue(validationContext.ObjectInstance);

                foreach (Product p in prod_list)
                {
                    totalAmount += p.Price * (double)p.Quantity;
                }

                if (totalAmount == providedAmount)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(String.Format(ErrorMessage ?? DefaultErrMsg, validationContext.MemberName, totalAmount));
                }
            }

            return null;


        }
    }
}
