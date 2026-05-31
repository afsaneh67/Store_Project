using Application.Contracts;
using Application.Dtos.Account;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.Identity;
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

namespace Application.Features.Account.Commands.LoginUser
{
    public class LoginCommand : IRequest<UserDto>
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
    public class LoginCommandHandler : IRequestHandler<LoginCommand, UserDto>
    {
        private readonly IMapper _mapper;
        private readonly SignInManager<User> _signInManager;
        private readonly IUnitOWork _uow;
        private readonly ITokenService _tokenService;

        public LoginCommandHandler(IMapper mapper, SignInManager<User> signInManager, IUnitOWork uow, ITokenService tokenService)
        {
            _mapper = mapper;
            _signInManager = signInManager;
            _uow = uow;
            _tokenService = tokenService;
        }

        public async Task<UserDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User user = await _uow.Context.Set<User>().FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber, cancellationToken);
            if (user == null)  throw new BadRequestEntityException("چنین نام کاربری یافت نشد. لطفا ابتدا در سایت ثبت نام کنید");
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (result.Succeeded)  throw new BadRequestEntityException("نام کاربری یا رمز عبور اشتباه است");
            var mapper = _mapper.Map<UserDto>(user);
            mapper.Token = await _tokenService.CreateToken(user);
            return mapper;

        }
    }
}
