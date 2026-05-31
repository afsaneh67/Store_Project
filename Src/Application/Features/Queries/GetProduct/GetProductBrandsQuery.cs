using Domain.Entities.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetProduct
{
    public class GetProductTypesQuery: IRequest<ProductType>
    {
        public int Id { get; set; }
        public GetProductTypesQuery(int id)
        {
            Id = id;
        }
    }
}
