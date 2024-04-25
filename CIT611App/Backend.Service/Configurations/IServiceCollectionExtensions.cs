using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Mapster;
using System.Reflection;
using MapsterMapper;
using FluentValidation;
using Backend.Service.Features.Common;
using StackExchange.Redis;
using Hangfire;
using Hangfire.Redis.StackExchange;
using System;
using Microsoft.AspNetCore.Builder;
using Backend.Service.Configurations;
using Backend.Service.Data;
using Backend.Service.MessageBroker;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using Backend.Service.Configurations.Swagger;
using System.IO;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace Backend.Service.Configurations
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddControllersWithJson(this IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.ReferenceResolverProvider = null;
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.Formatting = Formatting.Indented;
            });
            services.AddScoped(typeof(EndpointCommonDependencyCollection<>));
            return services;
        }
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c=>
            {
                c.CustomSchemaIds(x => x.FullName);
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {

                });
                c.OperationFilter<SwaggerHeader>();
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                 c.TagActionsBy(api =>
        {
            if (api.GroupName != null)
            {
                return new[] { api.GroupName };
            }
            if (api.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
            {
                return new[] { controllerActionDescriptor.ControllerName };
            }
            throw new InvalidOperationException("Unable to determine tag for endpoint.");
        });
        c.DocInclusionPredicate((name, api) => true);
            });
            return services;
        }
        public static IServiceCollection AddMapster(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton(config);
            services.AddScoped<IMapper, Mapper>();
            return services;
        }
        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));
            return services;
        }
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(Program).Assembly);
            return services;
        }
        public static IServiceCollection AddMessageBroker(this IServiceCollection services)
        {
            services.AddScoped<IMessageBroker, MessageBroker.MessageBroker>();
            return services;
        }
        public static IServiceCollection EnableCORS(this IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed(_ => true)
                .AllowCredentials();
            }));
            return services;
        }
    }
}
