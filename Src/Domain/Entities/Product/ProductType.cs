using Domain.Entities.Base;
using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Domain.Entities.Product
{
    public class ProductType : BaseAuditableEntity, ICommands
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string Summary { get; set; }
        //relation
        public User User { get; set; }
    }
}
