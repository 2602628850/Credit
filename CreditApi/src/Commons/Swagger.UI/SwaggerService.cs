using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Microsoft.OpenApi.Models;
using System.Reflection;

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
                //header加参数
                //option.OperationFilter<HeaderParamFilter>();
                option.AddSecurityDefinition("Header-Token",new OpenApiSecurityScheme
                {
                    Description = "输入用户登录Token",
                    Name = "Token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { 
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference()
                            {
                                Id = "Header-Token",
                                Type = ReferenceType.SecurityScheme
                            }
                        },Array.Empty<string>()
                    }
                });
                //文档注释
                var xmlAssemblies = DependencyContext.Default.CompileLibraries
                        .Where(s => s.Type != "package")
                        .Where(s => s.Name.EndsWith(".Api") || s.Name.EndsWith("Services"));
                foreach (var assembly in xmlAssemblies)
                {
                    var path = assembly.Name;
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, $"{assembly.Name}.xml");
                    if (File.Exists(xmlPath))
                    {
                        option.IncludeXmlComments(xmlPath, true);
                    }
                }
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