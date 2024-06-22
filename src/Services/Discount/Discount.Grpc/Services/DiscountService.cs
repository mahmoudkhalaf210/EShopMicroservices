using Discount.Grpc.Data;
using Discount.Grpc.Models;
using Discount.Grpc.Protos;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Services
{
    public class DiscountService(DiscountContext dbContext , ILogger<DiscountService> logger)
        : discountProtoService.discountProtoServiceBase
    {
        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await dbContext
                .Coupons
                .FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

            if (coupon is null) 
                coupon = new Models.Coupon { ProductName = "No Discount" , Amount =0 , Description ="No Discount to this Product Name" };

            logger.LogInformation("Discount is retrieved fro ProdutName : {ProductName} , Amount : {amount}" , coupon.ProductName , coupon.Amount );

            var couponModel = coupon.Adapt<CouponModel>();
            return couponModel;
        
        }


        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();
            if (coupon is null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request Data Object"));

             dbContext.Coupons.Add(coupon);
            await dbContext.SaveChangesAsync();

            logger.LogInformation("Discount is successfully created. ProductName : {ProductName}", coupon.ProductName);
            var couponModel = coupon.Adapt<CouponModel>();
            return couponModel;

        }

        public async override Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();
            if (coupon is null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request Data Object"));

            dbContext.Coupons.Update(coupon);
            await dbContext.SaveChangesAsync();

            logger.LogInformation("Discount is successfully Updated. ProductName : {ProductName}", coupon.ProductName);
            var couponModel = coupon.Adapt<CouponModel>();
            return couponModel;
        }

        public async override Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var coupon = await dbContext
               .Coupons
               .FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

            if (coupon is null)
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount With ProductName = {request.ProductName} not Found"));

            dbContext.Coupons.Remove(coupon);
            await dbContext.SaveChangesAsync();

            logger.LogInformation("Discount is successfully Deleted. ProductName : {ProductName}", coupon.ProductName);

            return new DeleteDiscountResponse { Success = true };


        }

    }
}
