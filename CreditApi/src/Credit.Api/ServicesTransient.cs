using Credit.BankServices;
using Credit.UserServices;
using Data.Commons.Caching;
using Data.Commons.Helpers;

namespace Credit.Api
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServicesTransient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void AddTransients(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>()
                .AddTransient<IBankService,BankService>()
                .AddTransient<ICacheManager,CacheManager>()
                .AddTransient<ITokenManager,TokenManager>();
        }
    }
}
