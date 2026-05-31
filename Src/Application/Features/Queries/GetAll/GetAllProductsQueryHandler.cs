using Application.Contracts;
using Application.Dtos.Products;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Product;
using Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetAll
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, PaginationResponse<ProductDto>>
    {
        private readonly IUnitOWork _uow;
        private readonly IMapper _mapper;
        public GetAllProductsQueryHandler(IUnitOWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<PaginationResponse<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            // return await _uow.Repository<Product>().GetAllAsync(cancellationToken);
            //request.TypeSort = Wrappers.TypeSort.Desc;
            var spec = new GetProductsSpec(request);
            var result = await _uow.Repository<Product>().ListAsyncSpec(spec, cancellationToken);

            var specCount = new ProductsCountSpec(request);
            var resultCount = await _uow.Repository<Product>().CountAsyncSpec(specCount, cancellationToken);

            //result = null;
            //if (result==null) { throw new NotFoundException(); }
            var model= _mapper.Map<IEnumerable<ProductDto>>(result);
            return new PaginationResponse<ProductDto>(request.PageIndex, request.PageSize, resultCount, model);
        }


    }
}
