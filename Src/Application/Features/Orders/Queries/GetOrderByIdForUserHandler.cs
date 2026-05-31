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
    public class GetOrderByIdForUserQuery:IRequest<OrderDto>
    {
        public int Id { get; set; }

        public GetOrderByIdForUserQuery(int id)
        {
            Id = id;
        }
    }
    public class GetOrderByIdForUserHandler : IRequestHandler<GetOrderByIdForUserQuery, OrderDto>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        private readonly IUnitOWork _unitOWork;

        public GetOrderByIdForUserHandler(ICurrentUserService currentUserService, IMapper mapper, IUnitOWork unitOWork)
        {
            _currentUserService = currentUserService;
            _mapper = mapper;
            _unitOWork = unitOWork;
        }

        public async Task<OrderDto> Handle(GetOrderByIdForUserQuery request, CancellationToken cancellationToken)
        {
            var orders = await _unitOWork.Repository<Domain.Entities.Order.Orders>().Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            return _mapper.Map<OrderDto>(orders);
        }
    }
}
