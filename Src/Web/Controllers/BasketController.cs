using Application.Features.Basket.Commands;
using Application.Features.Basket.Queries;
using Domain.Entities.BasketEntity;
using Microsoft.AspNetCore.Mvc;
using Web.Common;

namespace Web.Controllers
{
    public class BasketController : BaseApiController
    {
        //[HttpGet]
        //public IActionResult index()
        //{
        //    return Ok();
        //}
        //[HttpGet("{basketId}")]
        //public async Task<IActionResult<CustomerBasket>> GetBasketById([FromBody]string basketId,CancellationToken cancellationToken)
        //{
        //    return Ok(await Mediator.Send(new GetBasketByIdQuery(basketId), cancellationToken));   
        //}


        //[HttpPost]
        //public async Task<IActionResult<CustomerBasket>> UpdateBasket([FromBody] CustomerBasket basket, CancellationToken cancellationToken)
        //{
        //    return Ok(await Mediator.Send(new UpdateBasketCommand(basket), cancellationToken));
        //}

        //[HttpDelete("{basketId}")]
        //public async Task<IActionResult<bool>> DeleteBasket([FromBody] string basketId, CancellationToken cancellationToken)
        //{
        //    return Ok(await Mediator.Send(new DeleteBasketCommand(basketId), cancellationToken));
        //}

    }
}
