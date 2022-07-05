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


        /// <summary>
        ///  用户团队人数统计
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<UserTeamDto> GetTeamCountById(long userId);
        /// <summary>
        /// 增加用户任务积分
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="Integral"></param>
        /// <returns></returns>
        Task AddUserJF(long userId, int Integral);
        /// <summary>
        /// 增加用户信用值
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="CreditValue"></param>
        /// <returns></returns>
        Task AddUserXYZ(long userId, int CreditValue);

        /// <summary>
        /// 增加用用户团队等级
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        int SelectUserTeam(long userId);
        /// <summary>
        /// 增加用用户团队等级
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task AddUserTeam(long userId);
    }
}
