using Microsoft.Extensions.DependencyInjection;

namespace DEVinCar.DI
{
    public static class DI
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            return services;
        }
    }
}