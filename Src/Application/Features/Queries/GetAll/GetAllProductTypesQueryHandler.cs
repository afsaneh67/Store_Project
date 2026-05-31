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

    public class GetAllProductBrandsQueryHandler : IRequestHandler<GetAllProductBrandsQuery, IEnumerable<ProductBrand>>
    {
        private readonly IUnitOWork _uow;
        public GetAllProductBrandsQueryHandler(IUnitOWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<ProductBrand>> Handle(GetAllProductBrandsQuery request, CancellationToken cancellationToken)
        {
            return await _uow.Repository<ProductBrand>().GetAllAsync(cancellationToken);
        }
    }
}
