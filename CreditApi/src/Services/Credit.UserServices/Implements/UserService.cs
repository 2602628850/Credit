using Credit.UserModels;
using Credit.UserServices.Dtos;
using Data.Commons.Helpers;

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
        public async Task CreateUser(UserInput input)
        {
            var user = new Users
            {
                Id = IdHelper.GetId(),
                Nickname = input.Nickname,
                Username = input.Username,
                Password = input.Password
            };
            var sql = _freeSql.Insert(user).ToSql();
            await _freeSql.Insert(user).ExecuteInsertedAsync();
        }
    }
}