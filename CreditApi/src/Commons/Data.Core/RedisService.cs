using CSRedis;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using Hangfire.Redis;

namespace Data.Core;

/// <summary>
///  Redis服务
/// </summary>
public static class RedisService
{
    //public static IServiceCollection AddRedisService(this IServiceCollection services,Action<RoadHangfireConnectionOptions> options)
    //{
        //var roadHangfire = new RoadHangfireConnectionOptions();
        //options.Invoke(roadHangfire);
        //services.AddHangfire(configuration =>
        //{
            //configuration.UseRedisStorage(roadHangfire.ConnectionString,new RedisStorageOptions
            //{
                //Prefix = roadHangfire.Prefix
            //});

        //});
        //return services;
    //}

    public static void Init(string connectionString)
    {
        var csredis = new CSRedisClient(connectionString);
        RedisHelper.Initialization(csredis);
    }
}

public class RoadHangfireConnectionOptions
{
    /// <summary>
    /// 链接字符串
    /// </summary>
    public string ConnectionString { get; set; }

    /// <summary>
    ///  数据库
    /// </summary>
    public int DbNum { get; set; }

    /// <summary>
    ///  前缀
    /// </summary>
    public string Prefix { get; set; }
}