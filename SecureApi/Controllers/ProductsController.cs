using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = new[]
            {
                new { Id = 1, Name = "Notebook" },
                new { Id = 2, Name = "Mouse sem fio" },
                new { Id = 3, Name = "Teclado Mecânico" }
            };

            return Ok(products);
        }
    }
}