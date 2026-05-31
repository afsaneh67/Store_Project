using Application.Interfaces;
using Domain.Entities.BasketEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Basket.Commands
{
    //public class UpdateBasketCommand:IRequest<CustomerBasket>
    //{
    //    public CustomerBasket CustomerBasket { get; set; }
    //    public UpdateBasketCommand(CustomerBasket customerBasket)
    //    {
    //        CustomerBasket=customerBasket;
    //    }
    //}
    public class UpdateBasketCommandHandler //: IRequestHandler<UpdateBasketCommand, CustomerBasket>
    {
        //private readonly IBasketRepository _basketRepository;
        //public UpdateBasketCommandHandler(IBasketRepository basketRepository)
        //{
        //    _basketRepository = basketRepository;
        //}
        //public Task<CustomerBasket> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //    //return await _basketRepository.UpdateBasketAsync(request.CustomerBasket);
        //}
    }
}
