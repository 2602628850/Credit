using Swagger.UI;
using Data.Core;
using System.Reflection;
using FreeSql.Core;
using Credit.Api;
using Data.Commons.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//配置文件加载
builder.Configuration.LoadJsonFile();
//Swagger配置
builder.Services.AddSwaggerService($"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
//FreeSql注入
var dbConnection = builder.Configuration.GetSection("ConnectionStrings:Credit").Value;
builder.Services.FreeSqlInit(dbConnection);
builder.Services.AddTransients();
//雪花算法
IdHelper.Init(1,1);
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.AddSeaggerConfigure();

app.MapControllers();


app.Run();
