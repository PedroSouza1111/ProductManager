
using Microsoft.AspNetCore.Mvc;
using ProductManager.Application.Services;
using ProductManager.Domain.Entities;

namespace ProductManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductsController(ProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            return product is null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            var id = await _service.CreateAsync(product);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Product product)
        {
            var success = await _service.UpdateAsync(id, product);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
