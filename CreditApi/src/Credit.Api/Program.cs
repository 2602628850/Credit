using Swagger.UI;
using Data.Core;
using System.Reflection;
using FreeSql.Core;
using Credit.Api;
using Data.Commons.Helpers;
using Data.Commons.Attributes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ApiResultAttribute));
});
builder.Services.AddEndpointsApiExplorer();
//加载json文件
builder.Configuration.LoadJsonFile();
//Swagger配置
builder.Services.AddSwaggerService($"{Assembly.GetExecutingAssembly().GetName().Name}.xml");

//FreeSqlע初始化
var dbConnection = builder.Configuration.GetSection("ConnectionStrings:Credit").Value;
builder.Services.FreeSqlInit(dbConnection);
builder.Services.AddTransients();
//id初始化
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
