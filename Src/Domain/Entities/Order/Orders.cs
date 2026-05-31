using Domain.Entities.Base;
using Domain.Entities.Identity;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Order
{
    public class Orders:BaseAuditableEntity
    {
        public string BuyerPhoneNumber { get; set; }
        public decimal SubTotal { get; set; }

        //order status
        public OrderStatus orderStatus { get; set; } = OrderStatus.Pending;//وضعیت سفارش
        public decimal TrackingCode {  get; set; }  //کد پیگیری
        //portal
        public Portal Portal {  get; set; }
        public PortalType PortalType { get; set; } = PortalType.Zarinpal;
        public DeliveryMethod DeliveryMethod { get; set; }
        public decimal GetOriginalType() { return (SubTotal + DeliveryMethod.Price); }
        public ShipToAddress ShipToAddress { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public bool IsFinally { get; set; }
        public string Authority { get; set; }
        public User User { get; set; }
    }
}
