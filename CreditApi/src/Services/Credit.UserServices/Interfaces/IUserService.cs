using Credit.UserServices.Dtos;
using Data.Commons.Dtos;

namespace Credit.UserServices
{
    /// <summary>
    ///  用户管理接口定义
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        ///  注册用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task RegisterUser(RegisterUserInput input);

        /// <summary>
        ///  用户登录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<UserLoginOutput> UserLogin(UserLoginInput input);

        /// <summary>
        ///  管理员用户登录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<UserLoginOutput> AdminUserLogin(UserLoginInput input);
        
        /// <summary>
        ///  用户新增
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateUser(UserInput input);

        /// <summary>
        ///  获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<UserDto> GetUserById(long userId);
        
        /// <summary>
        ///  获取用户列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedOutput<UserDto>> GetUserPagedList(PagedInput input);
        /// <summary>
        ///  用户积分转余额
        /// </summary>
        /// <param name="input"></param>
        void ExchangeIntegral(UserDto input);
    }
}
