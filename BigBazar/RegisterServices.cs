using BigBazarRepository.Interface;
using BigBazarRepository.Repository;
using BigBazarService.Interface;
using BigBazarService.Service;

namespace BigBazarAPI
{
    /* public class RegisterServices
     {
     }*/
    public static class SeriveRegisterExtention
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {

            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<ICustomerRepository, CustomerRepository>();

            services.AddSingleton<IStoreService, StoreService>();
            services.AddSingleton<IStoreRepository, StoreRepository>();

            services.AddSingleton<IWareHouseService, WareHouseService>();
            services.AddSingleton<IWareHouseRepository, WareHouseRepository>();

            return services;
        }
    }
}
