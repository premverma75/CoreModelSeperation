using CoreModelSeperation.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreModelSeperation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await productService.GetProducts();
            return Ok(products);
        }
    }
}