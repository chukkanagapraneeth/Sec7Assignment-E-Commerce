using System.ComponentModel.DataAnnotations;

namespace Sec7Assignment_E_Commerce.CustomValidators
{
    public class DateValidator : ValidationAttribute
    {
        public DateTime? Date { get; set; } = Convert.ToDateTime("2000-01-01");
        public string Errormsg { get; set; } = "The date must be greater than or equal to {0} for {1}";
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if(value != null)
            {
                DateTime dt = Convert.ToDateTime(value);
                if (dt >= Date)
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult(String.Format(ErrorMessage ?? Errormsg, Date, validationContext.MemberName));
            }
            return null;
        }
    }
}
