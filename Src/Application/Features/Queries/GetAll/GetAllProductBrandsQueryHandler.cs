using Application.Contracts;
using Domain.Entities.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetAll
{

    public class GetAllProductTypesQueryHandler : IRequestHandler<GetAllProductTypesQuery, IEnumerable<ProductType>>
    {
        private readonly IUnitOWork _uow;
        public GetAllProductTypesQueryHandler(IUnitOWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<ProductType>> Handle(GetAllProductTypesQuery request, CancellationToken cancellationToken)
        {
            return await _uow.Repository<ProductType>().GetAllAsync(cancellationToken);
        }
    }
}
