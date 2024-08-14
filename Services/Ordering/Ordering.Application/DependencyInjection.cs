using EShop.BuildingBlocks.Behaviours;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(options => {
            options.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            options.AddOpenBehavior(typeof(ValidationBehaviour<,>));
            options.AddOpenBehavior(typeof(LoggingBehaviours<,>));


        });

        return serviceCollection;
    }

}

