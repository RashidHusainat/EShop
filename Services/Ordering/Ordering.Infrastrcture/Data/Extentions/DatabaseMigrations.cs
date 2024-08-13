using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastrcture.Data.Extentions;

public static class DatabaseMigrations
{
    public static WebApplication MigrateDatabaseAndSeedData(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext=scope.ServiceProvider.GetRequiredService<AppDbContext>();
        InsertCustomerData(dbContext);
        InsertProductData(dbContext);
        return app;
    }
    public static void InsertCustomerData(AppDbContext appDbContext)
    {
        if (!appDbContext.Customers.Any())
        {

            appDbContext.Customers.AddRange(InitData.GetCustomers());
            appDbContext.SaveChanges();

        }
    }

    public static void InsertProductData(AppDbContext appDbContext)
    {
        if (!appDbContext.Products.Any())
        {

            appDbContext.Products.AddRange(InitData.GetProducts());
            appDbContext.SaveChanges();

        }
    }
}

