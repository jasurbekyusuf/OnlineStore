using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Service.Configuration;
using OnlineStore.Service.Interfaces;
using OnlineStore.Service.Services;

namespace OnlineStore.Service.Extensions
{
    public static class ExtensionsService
    {
        public static void AddServicesCustom(this IServiceCollection services)
        {
            services.AddScoped<ISellerService, SellerService>()
                .AddScoped<ICustomerService, CustomerService>()
                .AddScoped<IProductService, ProductService>()
                .AddScoped<IOrderService, OrderService>()
                .AddAutoMapper(typeof(MappingInitializer));
        }
    }
}
