using Application.Interfaces;
using Domain.Exceptions;
using Infrastucture.Persistance.Configurations;
using Infrastucture.Persistance.Context;
using Infrastucture.Persistance.SeedData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Extensions;
using Web.Services;

namespace Web
{
    public static class ConfigureService
    {
        public static IServiceCollection AddWebServiceCollection(this WebApplicationBuilder builder )
        {
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            //builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.Configure<ApiBehaviorOptions>(options => 
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var error = actionContext.ModelState
                    .Where(e => e.Value.Errors.Count > 0).SelectMany(v => v.Value.Errors)
                    .Select(c => c.ErrorMessage).ToList();
                    return new BadRequestObjectResult(new ApiToReturn(400, error));
                };
            });
            //builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerDocumentation();
            builder.Services.AddSingleton<ICurrentUserService,CurrentUserService>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReact",
                    policy =>
                    {
                        policy
                            .WithOrigins("http://localhost:3001")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            return builder.Services;
        }
        public static async Task<IApplicationBuilder> AddWebAppService(this WebApplication app)
        {
            //get services
            var scope = app.Services.CreateScope();
            var services1 = scope.ServiceProvider;
            var context = services1.GetRequiredService<ApplicationDbContext>();
            var LoggerFactory = services1.GetRequiredService<ILoggerFactory>();
            try
            {
                // auto migration
                await context.Database.MigrateAsync();
                await GenerateFakeData.SeedDataAsync(context, LoggerFactory);
            }
            catch (Exception e)
            {
                var logger = LoggerFactory.CreateLogger<Program>();
                logger.LogError(e, "error exception for migration");
            }




            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                ////app.MapOpenApi();
                //app.UseSwagger();
                ////app.UseSwaggerUI();

                //app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi.Cloth v1"); });

                app.UseSwaggerDocumentation();
            }
            app.UseCors("AllowReact");
            app.UseAuthentication();
            app.UseAuthorization();


          

            


            app.MapControllers();

            app.Run();
            return app;
        }
    }
}
