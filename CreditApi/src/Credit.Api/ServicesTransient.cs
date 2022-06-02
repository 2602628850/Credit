using Credit.UserServices;

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
            services.AddTransient<IUserService, UserService>();
        }
    }
}
