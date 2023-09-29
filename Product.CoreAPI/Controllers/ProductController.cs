using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Contract;
using Product.Application.Contractor.IProductService;

namespace Product.CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public ProductController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await serviceManager.ProductService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetProductById(int Id)
        {
            var res = await serviceManager.ProductService.GetByIdAsync(Id);
            return Ok(res);
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> CreateProduct([FromBody]Domain.Entites.Product product)
        {
            var res = await serviceManager.ProductService.AddAsync(product);
            return Ok(res);
        }

        [HttpPut("EditProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody]Domain.Entites.Product product)
        {
            var res = await serviceManager.ProductService.UpdateAsync(product);
            return Ok(res);
        }
    }
}
