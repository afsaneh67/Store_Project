using Application.Contracts;
using Domain.Entities.Order;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Orders.Queries
{
    public class GetDeliveryMethodByIdQuery:IRequest<DeliveryMethod>
    {
        public int Id { get; set; }

        public GetDeliveryMethodByIdQuery(int id)
        {
            Id = id;
        }
    }
    public class GetDeliveryMethodByIdHandler : IRequestHandler<GetDeliveryMethodByIdQuery, DeliveryMethod>
    {
        private readonly IUnitOWork _unitOWork;

        public GetDeliveryMethodByIdHandler(IUnitOWork unitOWork)
        {
            _unitOWork = unitOWork;
        }

        public async Task<DeliveryMethod> Handle(GetDeliveryMethodByIdQuery request, CancellationToken cancellationToken)
        {
           return await _unitOWork.Repository<DeliveryMethod>().
                Where(x=>x.Id==request.Id).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
