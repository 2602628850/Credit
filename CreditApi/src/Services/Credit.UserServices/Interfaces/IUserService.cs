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
        Task<string> RegisterUser(RegisterUserInput input);

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
        ///  用户新增管理员
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateAdminUser(AdminUserDto input);

        /// <summary>
        ///  修改管理员资料
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<string> UpdateAdminUser(AdminUserDto input);

        /// <summary>
        ///  人员删除
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task UserDelete(long userId, long deleteUserId);
        /// <summary>
        ///  用户新增
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateUser(UserInput input);

        /// <summary>
        ///  修改个人资料
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<string> UpdateUser(UserInput input);

        /// <summary>
        ///  修改密码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<string> UpdateUserPwd(long userId, string oldPwd, string newPwd);


        /// <summary>
        ///  获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<UserDto> GetUserById(long userId);

        /// <summary>
        ///  获取用户信用等级
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<UserCreditDto> GetCreditLevleById(long userId);
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
        ///  获取用户团队信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<UserTeamInfoDto> GetUserTeamCountById(long userId);

        /// <summary>
        ///  获取用户收益信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<UserProfitDto> GetUserProfitById(long userId);

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
        /// 获取用户团队父级成员
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="maxSort"></param>
        /// <returns></returns>
        Task<List<TeamUsersDto>> GetUserTeamParentMembers(long userId, int maxSort = 0);

        /// <summary>
        ///  获取用户团队子级成员
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="maxSort"></param>
        /// <returns></returns>
        Task<List<TeamUsersDto>> GetUserTeamChildMembers(long userId, int maxSort = 0);

        /// <summary>
        ///  用户成为团队成员
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task UserBecomeTeamUser(long userId);

        /// <summary>
        ///  更新用户团队等级
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task UpdateTeamLevel(long userId);


        /// <summary>
        ///  更新用户信用等级
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task UpdateCreditLevel(long userId);

        /// <summary>
        ///  获取用户完成任务次数
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<UserTaskCompletedCountDto> GetUserTaskCompletedCount(long userId);

        /// <summary>
        ///  获取用户信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedOutput<AdminUserDto>> GetAdminUserPagedList(UserPagedInput input);
        /// <summary>
        ///  获取用户信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedOutput<UserDto>> GetUserPagedList(UserPagedInput input);
    }
}
