using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            return serviceCollection;
        }
    }
}
