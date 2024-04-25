using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Backend.Service.Configurations.Swagger
{
        public class SwaggerHeader : IOperationFilter
        {
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {


                operation.Parameters.Add(new OpenApiParameter()
                {
                    Name = "Token",
                    AllowEmptyValue = false,
                    In = ParameterLocation.Header,
                    Schema = new OpenApiSchema() { Type = "string" },
                    Required = false
                });
                operation.Parameters.Add(new OpenApiParameter()
                {
                    Name = "Accept-Language",
                    AllowEmptyValue = false,
                    In = ParameterLocation.Header,
                    Schema = new OpenApiSchema() { Type = "string" },
                    Required = false
                });

            }
        }

    
}
