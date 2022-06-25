using Swagger.UI;
using Data.Core;
using System.Reflection;
using FreeSql.Core;
using Credit.Api;
using Data.Commons.Helpers;
using Data.Commons.Attributes;
using Data.Commons.Converters.JsonConverters;
using Data.Commons.Runtime;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ApiResultAttribute));
}).AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    options.SerializerSettings.Converters.Add(new IdToStringConverter());
});
builder.Services.AddEndpointsApiExplorer();
//加载json文件
builder.Configuration.LoadJsonFile();
//Swagger配置
builder.Services.AddSwaggerService($"{Assembly.GetExecutingAssembly().GetName().Name}.xml");

//FreeSqlע初始化
var dbConnectionString = builder.Configuration.GetSection("ConnectionStrings:Credit").Value;
builder.Services.FreeSqlInit(dbConnectionString);
builder.Services.AddTransients();
//id初始化
IdHelper.Init(1,1);
//Redis初始化
var redisConnectionString = builder.Configuration.GetSection("Redis:Connection").Value;
RedisService.Init(redisConnectionString);

#region 跨域,目前允许所ip访问api,以后上线了在appsettings.json配置允许访问的ip
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
        .SetIsOriginAllowed(origin => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});
#endregion
var app = builder.Build();
//启用跨域
app.UseCors("AllowSpecificOrigin");

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.AddSeaggerConfigure();

app.UseAllRoadApiExceptionHandler();

app.MapControllers();


app.Run();
