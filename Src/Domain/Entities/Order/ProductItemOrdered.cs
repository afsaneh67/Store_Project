using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Order
{
    public class ProductItemOrdered
    {
        public int ProductItemId { get; set; }
        public string ProductName { get; set; }
        public string ProductBrandName { get; set; }
        public string ProductTypeName { get; set; }
        public string PictureUrl { get; set; }

        public ProductItemOrdered(int productItemId, string productName, string productBrandName, string productTypeName, string pictureUrl)
        {
            ProductItemId = productItemId;
            ProductName = productName;
            ProductBrandName = productBrandName;
            ProductTypeName = productTypeName;
            PictureUrl = pictureUrl;
        }

        public ProductItemOrdered()
        {
                
        }

    }
}
