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

namespace Application.Features.Account.Queries.GetAddresses
{
    public class GetAddressesQuery:IRequest<IEnumerable<AddressDto>>
    {
    }
    public class GetAddressesQueryHandler : IRequestHandler<GetAddressesQuery, IEnumerable<AddressDto>>
    {

        private readonly IMapper _mapper;
        private readonly IUnitOWork _uow;
        private readonly UserManager<User> _userManager;
        private readonly ICurrentUserService _currentUserService;

        public GetAddressesQueryHandler(IUnitOWork uow, IMapper mapper, UserManager<User> userManager, ICurrentUserService currentUserService)
        {
            _uow = uow;
            _mapper = mapper;
            _userManager = userManager;
            _currentUserService = currentUserService;
        }
        public async Task<IEnumerable<AddressDto>> Handle(GetAddressesQuery request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var user = await _userManager.Users.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);
            if (user == null) throw new NotFoundException();
            var entity = _mapper.Map<IEnumerable<AddressDto>>(user.Address);
            return entity;
        }
    }
}
