using Domain.Entities.Identity;
using Domain.Exceptions;
using Infrastucture.Persistance.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Infrastucture.Security
{
    public static class IdentityServiceExtension
    {
        public static void AddIdentityService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddIdentityCore<User>()
                .AddUserManager<UserManager<User>>()
                .AddSignInManager<SignInManager<User>>()
                .AddTokenProvider("MyApp", typeof(DataProtectorTokenProvider<User>))
                .AddRoles<Role>()
                .AddRoleManager<RoleManager<Role>>()
                .AddRoleValidator<RoleValidator<Role>>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.Configure(ConfigureOptionIdentity());

            //policy
                services.AddAuthorization();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters= OptionTokenValidationParameters(configuration);
                    options.Events = JwtOptionsEvents();
                });

        }

        private static Action<IdentityOptions> ConfigureOptionIdentity()
        {
            return options =>
            {
                //Password setting
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 1;

                //Lockout setting
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                //user setting
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_.-@+";
            };
        }

        private static JwtBearerEvents JwtOptionsEvents()
        {
            return new JwtBearerEvents
            {
                OnAuthenticationFailed = c =>
                {
                    c.NoResult();
                    c.Response.StatusCode = 500;
                    c.Response.ContentType = "application/json";
                    return c.Response.WriteAsync("مشکل در سمت سرور رخ داده است. لطفا مجددا تلاش کنید");
                },
                OnChallenge = context =>
                {
                    context.HandleResponse();
                    context.Response.StatusCode = 400;
                    context.Response.ContentType = "application/json";
                    var result = JsonConvert.SerializeObject(new ApiToReturn(401, "شما اهراز هویت نشده اید"));
                    return context.Response.WriteAsync(result);
                },
                OnForbidden = context =>
                {
                    context.Response.StatusCode = 403;
                    context.Response.ContentType = "application/json";
                    var result = JsonConvert.SerializeObject(new ApiToReturn(401, "شما به این بخش دسترسی ندارید، لطفا ابتدا وارد سایت شوید"));
                    return context.Response.WriteAsync(result);
                },
            };
        }
        private static TokenValidationParameters OptionTokenValidationParameters(IConfiguration configuration)
        {
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSetting:Key"] ?? string.Empty)),
                ValidateIssuer = true,
                ValidIssuer = configuration["JwtSetting:Issuer"],
                ValidateAudience = Convert.ToBoolean(configuration["JwtSetting:Audience"]),
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true
            };
        }
    }
}
