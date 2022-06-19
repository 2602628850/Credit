using Credit.BankServices;
using Credit.PayeeBankCardServices;
using Credit.UserBankCardServices;
using Credit.UserServices;
using Credit.UserWalletServices;
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
                .AddTransient<IPayeeBankCardService,PayeeBankCardService>()
                .AddTransient<IUserWalletService,UserWalletService>()
                .AddTransient<IUserBankCardService,UserBankCardService>()
                .AddTransient<ICacheManager,CacheManager>()
                .AddTransient<ITokenManager,TokenManager>();
        }
    }
}
