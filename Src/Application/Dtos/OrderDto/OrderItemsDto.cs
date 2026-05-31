using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.OrderDto
{
    public class OrderItemsDto:IMapFrom<OrderItem>
    {
        public int Id { get; set; }
        public int ProductItemId { get; set; }
        public string ProductName { get; set; }
        public string ProductBrandName { get; set; }
        public string ProductTypeName { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderItem, OrderItemsDto>()
                .ForMember(x => x.ProductTypeName, c => c.MapFrom(v => v.ItemOrdered.ProductTypeName))
                .ForMember(x => x.ProductBrandName, c => c.MapFrom(v => v.ItemOrdered.ProductBrandName));
        }

    }
}
