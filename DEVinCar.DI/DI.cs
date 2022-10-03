using DEVinCar.Repository.Data;
using DEVinCar.Repository.Data.Repositories;
using DEVinCar.Service.Interfaces.Repositories;
using DEVinCar.Service.Interfaces.Services;
using DEVinCar.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DEVinCar.DI
{
    public static class DI
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            services.AddDbContext<DevInCarDbContext>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ISaleCarRepository, SaleCarRepository>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IDeliveryRepository, DeliveryRepository>();
            services.AddScoped<IDeliveryService, DeliveryService>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}