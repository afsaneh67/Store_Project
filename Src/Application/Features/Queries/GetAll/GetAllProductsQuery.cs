using Application.Contracts;
using Application.Dtos.Products;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetAll
{
    public class GetAllProductsQuery : RequestParametersBasic, IRequest<PaginationResponse<ProductDto>>//, ICacheQuery
    {
        //public int HoursSaveData => 1;
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
    
    }
}
