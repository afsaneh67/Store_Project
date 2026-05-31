using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.BasketEntity
{
    public class CustomerBasketItem:BaseEntity
    {
        public string Product {  get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string PictureUrl { get; set; }
    }
}
