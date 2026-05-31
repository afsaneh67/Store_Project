using Domain.Entities.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetProduct
{
    public class GetProductBrandsQuery:IRequest<ProductBrand>
    {
        public int Id { get; set; }
        public GetProductBrandsQuery(int id)
        {
            Id = id;
        }
    }
}
