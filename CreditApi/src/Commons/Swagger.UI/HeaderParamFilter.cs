using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Swagger.UI;

/// <summary>
///  header加参数
/// </summary>
public class HeaderParamFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var filterPipeline = context.ApiDescription.ActionDescriptor.FilterDescriptors;
        var isAuthorized = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is AuthorizeFilter);
        var allowAnonymous = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is IAllowAnonymousFilter);

        if (isAuthorized && !allowAnonymous)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter 
            {
                Name = "Token",
                In = ParameterLocation.Header,
                Description = "token",
                Required = false,
                //Schema = new OpenApiSchema
                //{
                   // Type = "string",
                   // Default = new OpenApiString("")
                //}
            });
        }
    }
}