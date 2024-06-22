using Discount.Grpc.Data;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Data
{
    public static class Extentions
    {
        public static IApplicationBuilder UseMigration(this IApplicationBuilder app) 
        {
            using var scope = app.ApplicationServices.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<DiscountContext>();
            dbContext.Database.MigrateAsync();
            return app;
        }
    }
}
