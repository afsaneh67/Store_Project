using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities.Order;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.OrderDto
{
    public class OrderDto:IMapFrom<Orders>
    {
        public DeliveryMethod DeliveryMethod { get; set; }
        public List<OrderItemsDto> orderItems { get; set; } 
        public ShipToAddress ShipToAddress { get; set; }

        public string BuyerPhoneNumber { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public decimal TrackingCode { get; set; }
        public Portal Portal { get; set; }
        public PortalType PortalType { get; set; }
        public bool IsFinally { get; set; }
        public string Authority { get; set; }
        public string Link { get; set; }//gateway link
        public int Status { get; set; }
        public void Mapping (Profile profile)
        {
            profile.CreateMap<Orders, OrderDto>()
                .ForMember(x => x.Total, c => c.MapFrom(v => v.GetOriginalType()))
                .ForMember(x => x.Status, c => c.MapFrom(v => (int)v.orderStatus));
        }
    }
}
