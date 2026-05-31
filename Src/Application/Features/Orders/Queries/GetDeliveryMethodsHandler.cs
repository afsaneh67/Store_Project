using Application.Contracts;
using Domain.Entities.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Orders.Queries
{
    public class GetDeliveryMethodsQuery:IRequest<List<DeliveryMethod>>
    {

    }
    public class GetDeliveryMethodsHandler : IRequestHandler<GetDeliveryMethodsQuery, List<DeliveryMethod>>
    {
        private readonly IUnitOWork _unitOWork;

        public GetDeliveryMethodsHandler(IUnitOWork unitOWork)
        {
            _unitOWork = unitOWork;
        }

        public async Task<List<DeliveryMethod>> Handle(GetDeliveryMethodsQuery request, CancellationToken cancellationToken)
        {
            return await _unitOWork.Repository<DeliveryMethod>().ToListAsync(cancellationToken);
        }
    }
}
