using Credit.UserModels;
using Credit.UserServices.Dtos;

namespace Credit.UserServices
{
    public class UserService : IUserService
    {
        private readonly IFreeSql _freeSql;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="freeSql"></param>
        public UserService(IFreeSql freeSql)
        {
            _freeSql = freeSql;
        }

        /// <summary>
        ///  新建用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public void CreateUser(UserInput input)
        {
            _freeSql.Insert(new Users { 
                Id = input.Id,
                Nickname = input.Nickname,
                Username = input.Username,
                Password = input.Password
            });
        }
    }
}