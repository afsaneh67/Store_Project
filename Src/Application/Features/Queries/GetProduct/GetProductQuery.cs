using Domain.Entities.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetProduct
{
    public class GetProductQuery:IRequest<Product>
    {
        public int Id { get; set; }
        public GetProductQuery(int id)
        {
            Id = id;
                
        }
    }
}
