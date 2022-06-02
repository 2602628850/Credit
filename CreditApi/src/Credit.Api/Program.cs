using Swagger.UI;
using Data.Core;
using System.Reflection;
using FreeSql.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();
builder.Services.AddMvc();
//配置文件加载
builder.Configuration.LoadJsonFile();
//Swagger配置
builder.Services.AddSwaggerService($"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
//FreeSql注入
var dbConnection = builder.Configuration.GetSection("ConnectionStrings:Credit").Value;
builder.Services.FreeSqlInit(dbConnection);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.AddSeaggerConfigure();

//app.UseAuthorization();

//app.MapRazorPages();

app.Run();
