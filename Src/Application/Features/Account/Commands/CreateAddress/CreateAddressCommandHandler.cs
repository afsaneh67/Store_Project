using Application.Common.Mapping;
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

namespace Application.Features.Account.Commands.CreateAddress
{
    public class CreateAddressCommand:IRequest<AddressDto>, IMapFrom<Address>
    {
        public bool IsMain { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string FirstName { get; set; }
        public string FullAddress { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAddressCommand, Address>();
        }
    }
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, AddressDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOWork _uow;
        private readonly UserManager<User> _userManager;
        private readonly ICurrentUserService _currentUserService;

        public CreateAddressCommandHandler(IUnitOWork uow, IMapper mapper, UserManager<User> userManager, ICurrentUserService currentUserService)
        {
            _uow= uow;
            _mapper = mapper;
            _userManager = userManager;
            _currentUserService = currentUserService;
        }
        public async Task<AddressDto> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var user=await _userManager.Users.Include(x => x.Address).FirstOrDefaultAsync(x=>x.Id==userId,cancellationToken);
            if (user == null) throw new NotFoundException();
            if (request.IsMain && user.Address.Any())
                user.Address.ForEach(x => x.IsMain = false);
            if (!user.Address.Any())
                request.IsMain = true;

            var entity=_mapper.Map<Address>(request); 
            entity.UserId= userId;
            user.Address.Add(entity);
            var result=await _userManager.UpdateAsync(user);
            if (!result.Succeeded) throw new BadRequestEntityException();
            return _mapper.Map<AddressDto>(entity);

        }
    }
}
