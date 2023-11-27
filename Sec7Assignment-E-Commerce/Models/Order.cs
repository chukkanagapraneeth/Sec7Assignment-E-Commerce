using Microsoft.AspNetCore.Mvc.ModelBinding;
using Sec7Assignment_E_Commerce.CustomValidators;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sec7Assignment_E_Commerce.Models
{
    public class Order
    {
        [DisplayName("Order Number")]
        [BindNever]
        public int? OrderNo { get; set; }

        [DisplayName("Order Date")]
        [DateValidator]
        [Required(ErrorMessage = "{0} can't be blank")]
        public DateTime OrderTime { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [InvoiceValidator]
        public double InvoicePrice { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [ProductValidator]
        public List<Product> Products { get; set; } = new List<Product>();
    }

}
