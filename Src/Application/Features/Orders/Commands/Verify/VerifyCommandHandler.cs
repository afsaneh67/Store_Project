using Application.Contracts;
using Domain.Entities.Order;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Features.Orders.Commands.Verify
{
    public class VerifyCommand:IRequest<string>
    {
        public string Authority {  get; set; }
        public string Status { get; set; }

        public VerifyCommand(string authority, string status)
        {
            Authority = authority;
            Status = status;
        }
    }
    //public class VerifyCommandHandler : IRequestHandler<VerifyCommand, string>
    //{
    //    private readonly IConfiguration _configuration;
    //    private readonly IUnitOWork _unitOWork;

    //    public VerifyCommandHandler(IConfiguration configuration, IUnitOWork unitOWork)
    //    {
    //        _configuration = configuration;
    //        _unitOWork = unitOWork;
    //    }

    //    public async Task<string> Handle(VerifyCommand request, CancellationToken cancellationToken)
    //    {
    //        //1. get order authority
    //        var order=await _unitOWork.Context.Set<Orders>()
    //            .Include(x=>x.deliverymethod).Where(x=>x.authority==request.Authority)
    //            .SingleOrDefaultAsync(cancellationToken);   
    //        if (order == null) throw new BadImageFormatException("سفارش شما یافت نشد-لطفا مجدد تلاش کنید");
    //        //2. portal with order id
    //        var portal1=await _unitOWork.Repository<Portal>().Where(x=>x.OrderId==order.id).SingleOrDefaultAsync(cancellationToken);
    //        if (order == null) throw new BadImageFormatException("پرداخت شما مشکل دارد-لطفا با پشتیبانی تماس بگیرید");
    //        //3. cancelled submit=>gate way
    //        if(request.Status!="OK")
    //        {
    //            //cancell request sumbit
    //            order.orderstatus=OrderStatus.Cancelled;
    //            await _unitOWork.Repository<Order>().UpdateAsync(order);
    //            portal1.status = PaymentDataStatus.Canceled;
    //            await _unitOWork.Repository<Portal>().UpdateAsync(portal1);
    //            return _configuration["Order:CallBackCancelled"];
    //        }
    //        //4. status=>success:100,unsuccess
    //        var amount = (int)order.getoriginaltotal();
    //        var payment=new Payment(amount);
    //        var result = await payment.Verification(request.Authority);
    //        if (result.Status == 100)
    //        {
    //            order.isfinally() = true;
    //            order.orderstatus = OrderStatus.Pending;
    //            _unitOWork.Repository<order>().UpdateAsync(order);
    //            portal1.refrenceid = request.refid.tostring();
    //            portal1.status = PaymentDataStatus.Success;
    //            await _unitOWork.Repository<Portal>().UpdateAsync(portal1);
    //            await _unitOWork.Save(cancellationToken);
    //            return _configuration["Order:CallBackSuccess"];
    //        }
    //        //failed,unsuccess
    //        else
    //        {
    //            order.orderstatus = OrderStatus.PaymentFailed;
    //            _unitOWork.Repository<order>().UpdateAsync(order);
    //            portal1.status = PaymentDataStatus.Failed;
    //            await _unitOWork.Repository<Portal>().UpdateAsync(portal1);
    //            await _unitOWork.Save(cancellationToken);
    //            return _configuration["Order:CallBackFailed"];

    //        }
    //    }
    //}
}
