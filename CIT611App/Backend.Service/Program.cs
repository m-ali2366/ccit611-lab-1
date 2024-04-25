



using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Backend.Service.Data.Extensions;
using Backend.Service.Data;
using Hangfire;
using Microsoft.Extensions.Configuration;
using Backend.Service.Configurations;
using Backend.Service.Configurations.Jwt;
using Backend.Service.Configurations.Hangfire;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Backend.Service.Configurations.Localizations;
using Backend.Service.Configurations.CAP;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigureDependencies(builder.Services, builder.Configuration);
        var app = builder.Build();
        ConfigureMiddlwares(app, builder.Configuration);
        app.Run();
    }

    private static void ConfigureDependencies(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataServices(configuration);
        services.AddControllersWithJson();
        services.AddAuthenticationConfigurations();
        services.AddSwagger();
        services.AddMediatR();
        services.AddValidators();
        services.AddMapster();
        services.EnableCORS();
        services.AddHangfire(configuration);
        services.AddLocalizationWithCache();
        services.AddCapService();
        services.AddMessageBroker();
        services.AddControllers().AddNewtonsoftJson(options =>
       {
           // Use the default property (Pascal) casing
           options.SerializerSettings.ContractResolver = null; //new CamelCasePropertyNamesContractResolver();

       });
         services.AddMvc()
          .AddJsonOptions(options =>
          options.JsonSerializerOptions.PropertyNamingPolicy
           = null);
    }
    public static void ConfigureMiddlwares(WebApplication app, IConfiguration configuration)
    {

        app.ConfigCORS();
        //if (app.Environment.IsDevelopment())
        //{
        app.UseSwagger();
        app.UseSwaggerUI();
        //}
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseStaticFiles();
        app.UseHttpsRedirection();
        app.UseMiddleware<TransactionMiddleware>();
        app.MapControllers();
        app.UseHangfire(configuration);
        app.UseMiddleware<LocalizationMiddleware>();


    }
}


