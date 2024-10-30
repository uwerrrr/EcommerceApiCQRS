using Application;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly CreateProductCommandHandler _createHandler;
        private readonly GetProductByIdQueryHandler _queryByIdHandler;
        private readonly GetAllProductsQueryHandler _queryAllHandler;
        private readonly UpdateProductCommandHandler _updateHandler;
        private readonly DeleteProductCommandHandler _deleteHandler;

        public ProductsController(
            CreateProductCommandHandler createHandler,
            GetProductByIdQueryHandler queryByIdHandler,
            GetAllProductsQueryHandler queryAllHandler,
            UpdateProductCommandHandler updateHandler,
            DeleteProductCommandHandler deleteHandler)
        {
            _createHandler = createHandler;
            _queryByIdHandler = queryByIdHandler;
            _queryAllHandler = queryAllHandler;
            _updateHandler = updateHandler;
            _deleteHandler = deleteHandler;
        }
        
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAllProducts()
        {
            var products = await _queryAllHandler.Handle(new GetAllProductsQuery());
            return Ok(products);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(Guid id)
        {
            var productDto = await _queryByIdHandler.Handle(new GetProductByIdQuery(id));
            return Ok(productDto);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            await _createHandler.Handle(command);
            return Ok();
        }


        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("ID in URL and command do not match.");
            }

            await _updateHandler.Handle(command);
            return Ok();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _deleteHandler.Handle(new DeleteProductCommand(id));
            return NoContent();
        }
    }
}
