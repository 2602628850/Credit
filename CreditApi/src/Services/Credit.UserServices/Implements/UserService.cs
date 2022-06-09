using Credit.UserModels;
using Credit.UserServices.Dtos;
using Data.Commons.Dtos;
using Data.Commons.Extensions;
using Data.Commons.Helpers;
using Data.Commons.Runtime;

namespace Credit.UserServices
{
    /// <summary>
    ///  用户管理接口方法实现
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IFreeSql _freeSql;
        private readonly ITokenManager _tokenManager;

        /// <summary>
        /// 
        /// </summary>
        public UserService(IFreeSql freeSql,
            ITokenManager tokenManager)
        {
            _freeSql = freeSql;
            _tokenManager = tokenManager;
        }

        /// <summary>
        ///  注册用户
        /// </summary>
        /// <param name="input"></param>
        public async Task RegisterUser(RegisterUserInput input)
        {
            if (string.IsNullOrEmpty(input.Username))
                throw new MyException("Please enter your username");
            if (string.IsNullOrEmpty(input.Password))
                throw new MyException("Please enter your password");
            if (input.Password.Length < 6)
                throw new MyException("Password must be at least 6 characters long");
            if (string.IsNullOrEmpty(input.ConfirmPassword))
                throw new MyException("Please confirm your password");
            if (input.Password != input.ConfirmPassword)
                throw new MyException("Password does not match");
            //账号是否已存在
            var nameExist = await _freeSql.Select<Users>()
                    .Where(s => s.Username == input.Username)
                    .AnyAsync();
            var user = new Users
            {
                Id = IdHelper.GetId(),
                Username = input.Username.ToLower(),
                Password = input.Password,
                Nickname = input.Username,
            };
            await _freeSql.Insert(user).ExecuteAffrowsAsync();
        }
        
        /// <summary>
        ///  用户登录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<UserLoginOutput> UserLogin(UserLoginInput input)
        {
            if (string.IsNullOrEmpty(input.Username))
                throw new MyException("Please enter your username");
            if (string.IsNullOrEmpty(input.Password))
                throw new MyException("Please enter your password");
            var user = await _freeSql.Select<Users>()
                .Where(s => s.IsDeleted == 0)
                .Where(s => s.Username == input.Username.ToLower())
                .Where(s => s.IsAdmin == 0)
                .ToOneAsync();
            if (user == null)
                throw new MyException("Username does not exist");
            if (user.Password != input.Password)
                throw new MyException("Wrong password");
            var userToken = new UserLoginDto
            {
                UserId = user.Id,
                Username = user.Username,
                Nickname = user.Nickname,
                HeadImage = user.HeadImage
            };
            var token = await _tokenManager.GenerateToken(userToken,24*608*60);
            var output = new UserLoginOutput
            {
                User = userToken,
                Token = token
            };
            return output;
        }

        /// <summary>
        ///  管理员登录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="MyException"></exception>
        public async Task<UserLoginOutput> AdminUserLogin(UserLoginInput input)
        {
            if (string.IsNullOrEmpty(input.Username))
                throw new MyException("Please enter your username");
            if (string.IsNullOrEmpty(input.Password))
                throw new MyException("Please enter your password");
            var user = await _freeSql.Select<Users>()
                .Where(s => s.IsDeleted == 0)
                .Where(s => s.Username == input.Username.ToLower())
                .Where(s => s.IsAdmin == 1)
                .ToOneAsync();
            if (user == null)
                throw new MyException("Username does not exist");
            if (user.Password != input.Password)
                throw new MyException("Wrong password");
            var userToken = new UserLoginDto
            {
                UserId = user.Id,
                Username = user.Username,
                Nickname = user.Nickname,
                HeadImage = user.HeadImage
            };
            var token = await _tokenManager.GenerateToken(userToken,24*608*60);
            var output = new UserLoginOutput
            {
                User = userToken,
                Token = token
            };
            return output;
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
            await _freeSql.Insert(user).ExecuteAffrowsAsync();
        }

        /// <summary>
        ///  获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserDto> GetUserById(long userId)
        {
            var user = await _freeSql.Select<Users>()
                    .Where(s => s.Id == userId)
                    .ToOneAsync();
            return user.MapTo<UserDto>();
        }
        
        /// <summary>
        ///   获取用户列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<PagedOutput<UserDto>> GetUserPagedList(PagedInput input)
        {
            var list = await _freeSql.Select<Users>()
                .Where(s => s.IsDeleted == 0)
                .OrderByDescending(s => s.CreateAt)
                .Count(out long totalCount)
                .Page(input.PageIndex, input.PageSize)
                .ToListAsync();
            var output = new PagedOutput<UserDto>
            {
                
                TotalCount = totalCount,
                Items = list.MapToList<UserDto>()
            };

            return output;
        }
    }
}