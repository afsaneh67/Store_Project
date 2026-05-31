using Application.Contracts;
using Application.Dtos.OrderDto;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Orders.Queries
{
    public class GetOrdersForUserQuery:IRequest<List<OrderDto>>
    {
    }
    public class GetOrdersForUserQueryHandler : IRequestHandler<GetOrdersForUserQuery, List<OrderDto>>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        private readonly IUnitOWork _unitOWork;

        public GetOrdersForUserQueryHandler(ICurrentUserService currentUserService, IMapper mapper, IUnitOWork unitOWork)
        {
            _currentUserService = currentUserService;
            _mapper = mapper;
            _unitOWork = unitOWork;
        }

        public async Task<List<OrderDto>> Handle(GetOrdersForUserQuery request, CancellationToken cancellationToken)
        {
            var orders=await _unitOWork.Repository<Domain.Entities.Order.Orders>().Where(x=>x.CreateBY==_currentUserService.UserId).ToListAsync(cancellationToken);
           return _mapper.Map<List<OrderDto>>(orders);
        }
    }
}
