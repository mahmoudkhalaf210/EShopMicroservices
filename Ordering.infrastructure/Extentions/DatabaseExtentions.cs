

using Microsoft.AspNetCore.Builder;

namespace Ordering.infrastructure.Extentions
{
    public static class DatabaseExtentions
    {
        public static async Task InitializeDatabaseAsync(this WebApplication app) {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            context.Database.MigrateAsync().GetAwaiter().GetResult();
        }
    }
}
