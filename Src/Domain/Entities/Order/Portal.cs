using Domain.Entities.Base;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Order
{
    public class Portal:BaseEntity
    {
        public int OrderId {  get; set; }
        public PortalType Gateway { get; set; }=PortalType.Zarinpal;
        public PaymentDataStatus Status { get; set; }= PaymentDataStatus.Pending;
        public DateTime CreateOn { get; set; }=DateTime.Now;
        public long Amount { get; set; }
        public string ReferenceId { get; set; }
        //relation
        public Orders Order { get; set; }

    }
}
