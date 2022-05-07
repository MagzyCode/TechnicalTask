using ClientPart.ApiConnection.Services;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<RolesService>();
        }
            
    }
}
