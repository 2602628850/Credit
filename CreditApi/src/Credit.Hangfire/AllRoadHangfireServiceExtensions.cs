using Credit.OrderServices;
using Hangfire;
using Hangfire.Dashboard.BasicAuthorization;
using Hangfire.Redis;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Credit.Hangfire;

public static class AllRoadHangfireServiceExtensions
{
    public static IServiceCollection AddAllRoadHangfire(this IServiceCollection services, Action<AllRoadHangfireConnectionOptions> options)
        {
            var op = new AllRoadHangfireConnectionOptions();
            options.Invoke(op);
            
            services.AddHangfire(configuration =>
            {
                // configuration.UseRedisStorage(op.ConnectionStrings);
                configuration.UseRedisStorage(op.ConnectionStrings, new RedisStorageOptions
                {
                    Prefix = op.Prefix
                });
            });

            services.AddHangfireServer(options =>
            {
                options.WorkerCount = 3;
            });

            // 设置任务1分钟后过期
            GlobalStateHandlers.Handlers.Add(new SucceededStateExpireHandler(1));

            return services;
        }

        public static void UseAllRoadHangfire(this IApplicationBuilder app)
        {
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[]
                {
                    new BasicAuthAuthorizationFilter(new BasicAuthAuthorizationFilterOptions
                    {
                        SslRedirect = false,          // 是否将所有非SSL请求重定向到SSL URL
                        RequireSsl = false,           // 需要SSL连接才能访问HangFire Dahsboard。强烈建议在使用基本身份验证时使用SSL
                        LoginCaseSensitive = false,   // 登录检查是否区分大小写
                        Users = new[]                 // 配置登陆账号和密码
                        {
                            new BasicAuthAuthorizationUser
                            {
                                Login ="admin",//用户名
                                PasswordClear="Abc123.."
                            }
                        }
                    })
                 }
            });

            Task.Run(async () =>
            {
                await Task.Delay(3000);

                #region 定时任务

                // 每5分钟执行一次
                //RecurringJob.AddOrUpdate<IOrderService>("TASK_FUND_ORDERS_EXECUTE", s => s.ExecuteFundOrder(100), "*/5 * * * *");
                RecurringJob.AddOrUpdate<IFinancilOrderService>("TASK_SETTLE_ORDER", s => s.SettleOrders(),"0 0/20 0 * * ?  ");
                
                #endregion 

            });
        }
}