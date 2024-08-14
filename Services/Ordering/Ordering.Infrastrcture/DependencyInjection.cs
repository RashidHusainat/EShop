using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Data;
using Ordering.Infrastrcture.Data;
using Ordering.Infrastrcture.Data.InterCeptor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastrcture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastrcture(this IServiceCollection serviceCollection,IConfiguration configuration)
        {
            serviceCollection.AddScoped<ISaveChangesInterceptor,DomainEventReaderInterceptor>();
            serviceCollection.AddScoped<ISaveChangesInterceptor, AuditInterception>();
            serviceCollection.AddDbContext<AppDbContext>((sp,op) =>
            {
                op.UseSqlServer(configuration.GetConnectionString("Database"));
                op.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            });
            serviceCollection.AddScoped<IAppDbContext, AppDbContext>();
            return serviceCollection;
        }
    }
}
