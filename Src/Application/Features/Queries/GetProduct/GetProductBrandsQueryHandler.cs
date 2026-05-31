using Application.Contracts;
using Domain.Entities.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetProduct
{
    public class GetProductTypesQueryHandler : IRequestHandler<GetProductTypesQuery, ProductType>
    {
        private readonly IUnitOWork _uow;
        public GetProductTypesQueryHandler(IUnitOWork uow)
        {
            _uow = uow;
        }

        public async Task<ProductType> Handle(GetProductTypesQuery request, CancellationToken cancellationToken)
        {
            return await _uow.Repository<ProductType>().GetByIdAsync(request.Id,cancellationToken);
        }
    }
}
