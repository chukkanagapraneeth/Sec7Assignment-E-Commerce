using Microsoft.AspNetCore.Mvc;
using Sec7Assignment_E_Commerce.Models;

namespace Sec7Assignment_E_Commerce.Controllers
{
    public class OrderController : Controller
    {
        [Route("/order")]
        public IActionResult Order(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(String.Join("\n",ModelState.Values.SelectMany(val => val.Errors).Select(msg => msg.ErrorMessage).ToList()));
            }
            else
            {
                Random random = new Random();
                int randomno = random.Next(0, 9999);

                return Json(new { orderNumber = randomno });
            }
        }
    }
}
