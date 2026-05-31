using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Account
{
    public class UserDto:IMapFrom<User>
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public string DisplayName { get; set; }
        public string NationalCode { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDto>()
                .ForMember(x=>x.UserName,c=>c.MapFrom(v=>v.PhoneNumber))
                .ReverseMap();
        }

    }
}
