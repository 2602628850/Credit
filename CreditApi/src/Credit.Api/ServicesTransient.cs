using Credit.BankServices;
using Credit.CreditLevelServices;
using Credit.CreditLevelServices.Interfaces;
using Credit.IntegralServices;
using Credit.IntegralServices.Implements;
using Credit.OrderServices;
using Credit.OrderServices.Implements;
using Credit.PayeeBankCardServices;
using Credit.ProductServices;
using Credit.RepayServices;
using Credit.SettingServices;
using Credit.TeamServices;
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
                .AddTransient<IFinancilOrderService,FinancilOrderService>()
                .AddTransient<IFinancilProductService,FinancilProductService>()
                .AddTransient<ICacheManager,CacheManager>()
                .AddTransient<ITokenManager,TokenManager>()
                .AddTransient<IIntegralOrderService, IntegralOrderService>()
                .AddTransient<IIntegralRecodeService, IntegralRecodeService>()
                .AddTransient<IRepayService,RepayService>()
                .AddTransient<ISettingService,SettingService>()
                .AddTransient<ITeamService,TeamService>()
                .AddTransient<ICreditLevelService, CreditLevelService>();
        }
    }
}
