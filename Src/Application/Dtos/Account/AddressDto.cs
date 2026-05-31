using Application.Common.Mapping;
using Application.Features.Account.Commands.CreateAddress;
using AutoMapper;
using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Account
{
    public class AddressDto:IMapFrom<Address>
    {
        public string Id { get; set; }
        public bool IsMain { get; set; }
        public string City { get; set; }
        public string FirstName { get; set; }
        public string FullAddress { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddressDto, Address>().ReverseMap();
        }
    }
}
