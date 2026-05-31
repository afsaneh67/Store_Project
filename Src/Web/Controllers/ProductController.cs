using Application.Dtos.Products;
using Application.Features.Queries.GetAll;
using Application.Features.Queries.GetProduct;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Common;

namespace Web.Controllers
{
    public class ProductController : BaseApiController
    {
        [Authorize]
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProduct([FromQuery] GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return  Ok(await Mediator.Send(request,cancellationToken));
        }
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductQuery(id), cancellationToken));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllProductBrand(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetAllProductBrandsQuery(), cancellationToken));
        }
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> GetProductBrand([FromRoute] int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductBrandsQuery(id), cancellationToken));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllProductTypes(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetAllProductTypesQuery(), cancellationToken));
        }
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> GetProductTypes([FromRoute] int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductTypesQuery(id), cancellationToken));
        }
    }
}
