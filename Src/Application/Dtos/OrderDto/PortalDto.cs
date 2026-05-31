using Application.Common.Mapping;
using Domain.Entities.Order;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.OrderDto
{
    public class PortalDto:IMapFrom<Portal>
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public PortalType Gateway { get; set; } 
        public PaymentDataStatus Status { get; set; } 
        public DateTime CreateOn { get; set; }
        public long Amount { get; set; }
        public string ReferenceId { get; set; }
    }
}
