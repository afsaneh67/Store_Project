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
    public class GetProductBrandsQueryHandler:IRequestHandler<GetProductBrandsQuery,ProductBrand>
    {
        private readonly IUnitOWork _uow;
        public GetProductBrandsQueryHandler(IUnitOWork uow)
        {
            _uow = uow;
        }

        public async Task<ProductBrand> Handle(GetProductBrandsQuery request, CancellationToken cancellationToken)
        {
            return await _uow.Repository<ProductBrand>().GetByIdAsync(request.Id,cancellationToken);
        }
    }
}
