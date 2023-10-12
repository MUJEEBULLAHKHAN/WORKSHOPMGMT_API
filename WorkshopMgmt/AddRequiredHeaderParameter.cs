using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WorkshopMgmt
{
    public class AddRequiredHeaderParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Culture",
                In = ParameterLocation.Header,
                Description = "Language",
                Required = false,

                Schema = new OpenApiSchema
                {
                    Type = "String",
                    Default = new OpenApiString("en")
                }
            });

        }
    }
}
