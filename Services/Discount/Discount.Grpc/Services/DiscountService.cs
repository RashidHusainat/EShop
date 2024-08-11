using Discount.Grpc;
using Discount.Grpc.Data;
using Discount.Grpc.Model;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Discount.Grpc.Services
{
    public class DiscountService(ILogger<DiscountService> logger,AppDbContext appContext) : DiscountProtoService.DiscountProtoServiceBase
    {
        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var discount = await appContext.Coupons.FirstOrDefaultAsync(i => i.ProductName.Equals(request.ProductName));
            if (discount is null) 
                return new CouponModel()
                {
                    Amount = 0,
                };
            else return discount.Adapt<CouponModel>();


        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
           var coupon=request.Coupon.Adapt<Coupon>();
            if (coupon is null)
                throw new RpcException(new Status(StatusCode.InvalidArgument,""));
            appContext.Coupons.Add(coupon);
            await appContext.SaveChangesAsync();
            return request.Coupon;
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var coupon = await appContext.Coupons.FirstOrDefaultAsync(i => i.ProductName == request.ProductName);
            if (coupon is null)
                return new DeleteDiscountResponse()
                {
                    Success = false,
                };
            appContext.Coupons.Remove(coupon);
            await appContext.SaveChangesAsync();
            return new DeleteDiscountResponse()
            {
                Success = true,
            };
        }

       

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon=request.Coupon.Adapt<Coupon>();
            if (coupon is null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, ""));
            appContext.Coupons.Update(coupon);
            await appContext.SaveChangesAsync(context.CancellationToken);
            return  coupon.Adapt<CouponModel>();

        }
    }
}
