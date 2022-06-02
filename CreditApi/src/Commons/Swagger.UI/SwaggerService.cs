using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Swagger.UI
{
    public static class SwaggerService
    {
        public static void AddSwaggerService(this IServiceCollection services,string xmlFile)
        {
            services.AddSwaggerGen(option => {
                option.SwaggerDoc("v1",new OpenApiInfo { 
                    Version = "v1",
                    Title = "Credit API"
                });
                //文档注释
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                option.IncludeXmlComments(xmlPath, true);
                option.OrderActionsBy(o => o.RelativePath);
            });
        }

        public static void AddSeaggerConfigure(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Credit API V1");
                c.RoutePrefix = "docs";
            });
        }
    }
}