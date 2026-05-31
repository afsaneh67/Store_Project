using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.BasketEntity
{
    public class CustomerBasket
    {
        public string Id { get; set; }
        public CustomerBasket(string id)
        {
                Id = id;
        }
        //relation
        public List<CustomerBasketItem> Items { get; set; } = new();
        public decimal CalculateOriginalPrice()
        {
            return Items.Sum(x => x.Price*x.Discount);
        }
    }
}
