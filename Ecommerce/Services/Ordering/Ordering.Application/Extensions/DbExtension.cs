using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Infrastructure.Extensions
{
    public static class DbExtension
    {
        public static async Task MigrateDatabaseAsync<TContext>(
            this IServiceProvider services)
            where TContext : DbContext
        {
            using var scope = services.CreateScope();

            var context = scope.ServiceProvider
                .GetRequiredService<TContext>();

            await context.Database.MigrateAsync();
        }
    }
}