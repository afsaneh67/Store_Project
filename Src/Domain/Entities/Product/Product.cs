using Domain.Entities.Base;
using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product
{
    public class Product : BaseAuditableEntity, ICommands
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public int TypeId { get; set; }
        public int BrandId { get; set; }

        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string Summary { get; set; }

        //relation
        public User User { get; set; }
        public ProductBrand productBrand { get; set; }
        public ProductType productType { get; set; }

    }
}
