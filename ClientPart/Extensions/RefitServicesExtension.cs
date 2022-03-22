using ClientPart.ApiConnection.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.Extensions
{
    public static class RefitServicesExtension
    {
        public static void AddRefitServicesDependecies(this IServiceCollection services)
        {
            services.AddScoped<AuthenticationService>();
            services.AddScoped<FridgesService>();
            services.AddScoped<FridgeModelService>();
            services.AddScoped<ProductsService>();
            services.AddScoped<FridgeProductsService>();
            services.AddScoped<AuthenticationService>();
        }
            
    }
}
