using Application.Dtos.OrderDto;
using Application.Features.Orders.Commands;
using Application.Features.Orders.Commands.Verify;
using Application.Features.Orders.Queries;
using Domain.Entities.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Common;

namespace Web.Controllers
{
    public class OrderController:BaseApiController
    {
        //[HttpPost("CreateOrder")]
        //public async Task<ActionResult<OrderDto>> CreateOrder([FromBody] CreateOrderCommand request,CancellationToken cancellationToken)
        //{
        //    return Ok(await Mediator.Send(request,cancellationToken));
        //}

        //[HttpGet("GetOrdersForUser")]
        //public async Task<ActionResult<List<OrderDto>>> GetOrdersForUser( CancellationToken cancellationToken)
        //{
        //    return Ok(await Mediator.Send(new GetOrdersForUserQuery(), cancellationToken));
        //}


        //[HttpGet("GetOrderByIdForUser")]
        //public async Task<ActionResult<OrderDto>> GetOrderByIdForUser([FromBody]int id,CancellationToken cancellationToken)
        //{
        //    return Ok(await Mediator.Send(new GetOrderByIdForUserQuery(id), cancellationToken));
        //}


        //[HttpGet("GetDeliveryMethods")]
        //public async Task<ActionResult<List<DeliveryMethod>>> GetDeliveryMethods(CancellationToken cancellationToken)
        //{
        //    return Ok(await Mediator.Send(new GetDeliveryMethodsQuery(), cancellationToken));
        //}

        //[HttpGet("GetDeliveryMethodById")]
        //public async Task<ActionResult<DeliveryMethod>> GetDeliveryMethodById([FromBody] int id,CancellationToken cancellationToken)
        //{
        //    return Ok(await Mediator.Send(new GetDeliveryMethodByIdQuery(id), cancellationToken));
        //}

        //[AllowAnonymous]
        //[HttpGet("Verify")]
        //public async Task<ActionResult<DeliveryMethod>> Verify(string authority,string status, CancellationToken cancellationToken)
        //{
        //    return Redirect(await Mediator.Send(new VerifyCommand(authority, status), cancellationToken));
        //}
    }
}
