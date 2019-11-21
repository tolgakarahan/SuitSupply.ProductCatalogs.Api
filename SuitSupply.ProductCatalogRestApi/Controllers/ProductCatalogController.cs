using System.Threading.Tasks;
using Application.ProductCatalogs.Commands.CreateProductCatalog;
using Application.ProductCatalogs.Commands.DeleteProductCatalog;
using Application.ProductCatalogs.Commands.UpdateProductCatalog;
using Application.ProductCatalogs.Queries.GetProductCatalog;
using Application.ProductCatalogs.Queries.GetProductCatalogList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuitSupply.ProductCatalogRestApi.Common;

namespace SuitSupply.ProductCatalogRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCatalogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductCatalogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProductCatalogListVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductCatalogListVm>> Get()
        {
            var vm = await _mediator.Send(new GetProductCatalogListQuery());

            return Ok(vm);
        }

        // GET: api/ProductCatalog/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(typeof(ProductCatalogVm), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(DefaultExceptionDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductCatalogVm>> Get(int id)
        {
            var vm = await _mediator.Send(new GetProductCatalogQuery() { Id = id });
            return Ok(vm);
        }

        // POST: api/ProductCatalog
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesErrorResponseType(typeof(DefaultExceptionDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<int>> Post([FromBody] CreateProductCatalogCommand command)
        {
            var newProductCatalogId = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), newProductCatalogId);
        }

        // PUT: api/ProductCatalog/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesErrorResponseType(typeof(DefaultExceptionDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateProductCatalogCommand command)
        {
            if (id != command.Id)
                return BadRequest("Invalid Id, Command and Request must have same Id");

            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesErrorResponseType(typeof(DefaultExceptionDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteProductCatalogCommand { Id = id });
            return NoContent();
        }
    }
}
