using Application.Common.Mapping;
using Application.Contracts;
using Application.Dtos.Account;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.Identity;
using Domain.Enums;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Account.Commands.RegisterUser
{
    public class RegisterCommand:IRequest<UserDto>,IMapFrom<User>
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<RegisterCommand, User>();
        }


    }
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, UserDto>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public RegisterCommandHandler(IMapper mapper, UserManager<User> userManager, ITokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _tokenService = tokenService;
        }
        public async Task<UserDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var checkUser=await _userManager.Users.AnyAsync(x=>x.PhoneNumber== request.PhoneNumber);
            if (checkUser) throw new BadRequestEntityException("شماره موبایل تکراری است");
            var user = _mapper.Map<User>(request);
            //user.UserName = request.PhoneNumber;
            var result=await _userManager.CreateAsync(user);
            if (!result.Succeeded) throw new BadRequestEntityException(result.Errors.FirstOrDefault().Description);//throw new BadRequestEntityException("عملیات با شکست مواجه شده است");
           
            var resultRole=_userManager.AddToRoleAsync(user,RoleType.User.ToString());
            if (!resultRole.Result.Succeeded) throw new BadRequestEntityException(resultRole.Result.Errors.FirstOrDefault().Description);

            var mapper = _mapper.Map<UserDto>(user);
            mapper.Token =await _tokenService.CreateToken(user);
            return mapper;
        }
    }
}
