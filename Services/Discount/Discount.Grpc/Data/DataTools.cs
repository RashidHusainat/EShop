using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Discount.Grpc.Data
{
    static class DataTools
    {
        public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
        {
           using var scope= app.ApplicationServices.CreateScope();
            var appContext=scope.ServiceProvider.GetRequiredService<AppDbContext>();
            appContext.Database.Migrate();
            return app;
        }
    }
}
