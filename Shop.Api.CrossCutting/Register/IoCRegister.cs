
using Shop.Api.DataAccess.Contracts.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Shop.Api.DataAccess.Repositories;
using Shop.Api.Application.Services;
using Shop.Api.Application.Contracts.Services;
using Shop.Api.Application.Configuration;

namespace Shop.Api.CrossCutting.Register
{
    public static class IoCRegister 
    {
        //IoC invercion de control
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            AddRegisterServices(services);
            AddRegisterRepositories(services);
            AddRegisterOthers(services);

            return services;

        }
        
        private static IServiceCollection AddRegisterServices(IServiceCollection services)
        {

            services.AddTransient<IUserService, UserService>();
       

            return services;
        }

        private static IServiceCollection AddRegisterRepositories(IServiceCollection services)
        {

            services.AddTransient<IUserRepository, UserRepository>();
          
            return services;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private static IServiceCollection AddRegisterOthers(IServiceCollection services)
        {
            //Configuración fuertemente tipada con Polly, basicamnete permite declarar variables el appsettings // los camibos no necesitan que pares la app para q impacten
            services.AddTransient<IAppConfig, AppConfig>();


          //  services.AddTransient<IApiCaller, ApiCaller>();


            return services;
        }





    }
}
