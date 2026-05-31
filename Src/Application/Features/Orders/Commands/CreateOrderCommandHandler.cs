using Application.Contracts;
using Application.Dtos.OrderDto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.Order;
using Domain.Enums;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZarinpalSandbox;

namespace Application.Features.Orders.Commands
{
    public class CreateOrderCommand:IRequest<OrderDto>
    {
        public string BasketId {  get; set; }
        public int DeliveryMethodId { get; set; }
        public string BuyerPhoneNumber { get; set; }
        public ShipToAddress ShipToAddress { get; set; }
        public PortalType PortalType { get; set; } = PortalType.Zarinpal;
    }
    public class CreateOrderCommandHandler //: IRequestHandler<CreateOrderCommand, OrderDto>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IConfiguration _configuration;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        private readonly IUnitOWork _unitOWork;

        public CreateOrderCommandHandler(IBasketRepository basketRepository,
            IConfiguration configuration, ICurrentUserService currentUserService,
            IMapper mapper, IUnitOWork unitOWork)
        {
            _basketRepository = basketRepository;
            _configuration = configuration;
            _currentUserService = currentUserService;
            _mapper = mapper;
            _unitOWork = unitOWork;
        }

        //    public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        //    {
        //        //1. get basket
        //        var basket = _basketRepository.GetBasketAsync(request.BasketId);
        //        //2. delivery method
        //        var deliveryMethod = await _unitOWork.Repository<DeliveryMethod>()
        //            .GetByIdAsync(request.DeliveryMethodId, cancellationToken);
        //        //3. content get-way zarinpal=> link,succsess,auth
        //        var amount = 100;// (int)basket.CalculateOriginalPrice();
        //        //var Payment=await Payment(amount).p
        //        //4. reducer
        //        //5. order create
        //        var orderItems = new List<OrderItem>();
        //        foreach (var item in basket.Result.Items)
        //        {
        //            var itemOrder = new ProductItemOrdered(item.Id, item.Product, item.Brand, item.Type, item.PictureUrl);
        //            orderItems.Add(new OrderItem()
        //            {
        //                ItemOrdered = itemOrder,
        //                Price = item.Price,
        //                Quantity = item.Quantity,
        //            });
        //            //2
        //            //orderItems.Add(new OrderItem(itemOrder, item.Price, item.Quantity));
        //        }

        //        var order1 = new Domain.Entities.Order.Orders()
        //        {
        //            BuyerPhoneNumber=request.BuyerPhoneNumber,
        //            ShipToAddress=request.ShipToAddress,
        //            DeliveryMethod=deliveryMethod,
        //            OrderItems=orderItems,
        //            //SubTotal=basket.ca
        //            PortalType=request.PortalType,
        //            //Authority=p
        //            CreateBY=_currentUserService.UserId
        //        };

        //        var result = await _unitOWork.Repository<Orders>().AddAsync(order1, cancellationToken);
        //        if (result == null) throw new BadRequestEntityException("سفارش شما با شکست مواجه گشته، لطفا مجدد تلاش نمایید");
        //        await _unitOWork.Save(cancellationToken);

        //        //6. delete basket
        //        await _basketRepository.DeleteBasketAsync(basket.Id);
        //        //7. create portal
        //        var portal = new Portal(request.BasketId, request.PortalType, PaymentDataStatus.Pending, amount, null);
        //        await _unitOWork.Repository<Portal>().AddAsync(portal, cancellationToken);

        //        //8. create response
        //        var model = _mapper.Map<OrderDto>(result);
        //        //9. redirect link (3)
        //        model.Link = Payment.link;
        //        //10. return (8)
        //        return model;
        //        throw new NotImplementedException();
        //    }
    }
}
