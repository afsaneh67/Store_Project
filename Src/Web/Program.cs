using Application;
using Infrastucture;
using Infrastucture.Persistance;
using Infrastucture.Persistance.Configurations;
using Infrastucture.Persistance.SeedData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Web;
using Web.MiddleWare;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastuctureServices(builder.Configuration);
builder.AddWebServiceCollection();

//builder.Services.AddDbContext<ApplicationDbContext>
//    (options =>
//{ options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); });



var app = builder.Build();
app.UseStaticFiles();
app.UseMiddleware<MiddleWareExceptionHandler>();
await app.AddWebAppService().ConfigureAwait(false);
