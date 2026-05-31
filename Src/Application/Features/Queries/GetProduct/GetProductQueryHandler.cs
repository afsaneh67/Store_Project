using Application.Contracts;
using Application.Features.Queries.GetAll;
using Domain.Entities.Product;
using Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
    {
        private readonly IUnitOWork _uow;
        public GetProductQueryHandler(IUnitOWork uow)
        {
            _uow = uow;
        }
        public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var spec = new GetProductsSpec(request.Id);
            spec.IsPagingEnabled = false;
            var result= await _uow.Repository<Product>().GetEntityWithSpec(spec, cancellationToken);

            if (result == null) { throw new NotFoundException(); }
            else
                return result;
            //return await _uow.Repository<Product>().GetByIdAsync(request.Id,cancellationToken);
        }
    }
}
