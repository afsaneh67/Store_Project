using Application.Contracts;
using Application.Interfaces;
using Infrastucture.Persistance;
using Infrastucture.Persistance.Context;
using Infrastucture.Security;
using Infrastucture.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture
{
    public static class ConfigureService
    {
        public static IServiceCollection AddInfrastuctureServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>
           (option =>
           {
               option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
           });
            services.AddScoped<IUnitOWork, UnitOWork>();
            services.AddScoped<ITokenService, TokenService>();
            //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


            //Identity
            //IdentityServiceExtension.AddIdentityService(services,configuration);
            services.AddIdentityService(configuration);

            ////Redis
            //services.AddSingleton<IConnectionMultiplexer>
            //(
            //    opt =>
            //    {
            //        var options=ConfigurationOptions.Parse(configuration.GetConnectionString("Redis"),false);
            //        return ConnectionMultiplexer.Connect(options);
            //    });
            // services.AddScoped<IBasketRepository, BasketRepository>();
            return services;
        }

    }
}
