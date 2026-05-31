using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Basket.Commands
{
    //public class DeleteBasketCommand:IRequest<bool>
    //{
    //    public string Id { get; set; }
    //    public DeleteBasketCommand(string id)
    //    {
    //        Id = id;
    //    }
    //}
    public class DeleteBasketCommandHandler //: IRequestHandler<DeleteBasketCommand, bool>
    {
        //private readonly IBasketRepository _basketRepository;
        //public DeleteBasketCommandHandler(IBasketRepository basketRepository)
        //{
        //    _basketRepository = basketRepository;
        //}

        //public Task<bool> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<bool> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        //{
        //    //return await _basketRepository.DeleteBasketAsync(request.Id);
        //}
    }
}
