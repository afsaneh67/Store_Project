using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Identity
{
    public class User:IdentityUser
    {
        public string DisplayName { get; set; }

        //relation
       
        public List<Address> Address { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
    }
}
