using Microsoft.Extensions.DependencyInjection;

namespace Restaurant.Products
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProducts(this IServiceCollection services)
        {
            return services;
        }
    }
}