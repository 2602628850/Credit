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
            //邀请码是否正确
            var Team = await _freeSql.Select<Users>()
               .Where(s => s.InvCode == input.InvCode)
               .ToOneAsync();
            if (Team == null)
                throw new MyException("is incorrect");
            var user = new Users
            {
                Id = IdHelper.GetId(),
                Username = input.Username.ToLower(),
                Password = input.Password,
                Nickname = input.Nickname,
                CountryName = input.CountryName,
                Code = input.Code,
                InvCode = input.InvCode,
                ParentId = Team.Id,
                TeamLevel = 0,
                CreditValue = 0,
                Level = 0,

            };
            await _freeSql.Insert(user).ExecuteAffrowsAsync();
            //邀请码注册
            if (input.InvCode != null)
            {
                //邀请码邀请人数
                var Directnum = 0;
                //增加邀请人积分
                await AddUserJF(Team.Id, 100);
                //查询邀请码邀请人数
                var teams = await GetTeamCountById(Team.Id);
                if (teams != null)
                {
                    //邀请人数达到一定数量时
                    if (teams.Direct == Directnum)
                    {
                        //增加 邀请人团队等级
                        await AddUserTeam(Team.Id);
                    }
                }
            }
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
            var token = await _tokenManager.GenerateToken(userToken, 24 * 608 * 60);
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
            var userToken = new AdminLoginDto
            {
                UserId = user.Id,
                Username = user.Username,
                Nickname = user.Nickname,
                HeadImage = user.HeadImage,
                IsAdmin = 1
            };
            var token = await _tokenManager.GenerateToken(userToken, 24 * 608 * 60);
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
        ///  获取用户团队人数
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserTeamDto> GetTeamCountById(long userId)
        {
            var DirectCount = await _freeSql.Select<Users>()
                    .Where(s => s.ParentId == userId)
                    .ToListAsync();
            var output = new UserTeamDto
            {
                Direct = DirectCount.Count,
                TeamUser = DirectCount.Count
            };
            return output;
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
        /// <summary>
        ///  用户积分转余额
        /// </summary>
        /// <param name="input"></param>
        public void ExchangeIntegral(UserDto input)
        {
            //修改用户余额信息
            _freeSql.Update<Users>(input.Id)
                .SetDto(new { Balance = input.Balance, Integral = input.Integral }).ExecuteAffrows();
        }
        /// <summary>
        /// 增加用户积分
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="Integral"></param>
        /// <returns></returns>
        public async Task AddUserJF(long userId, int Integral)
        {
            var user = await _freeSql.Select<Users>()
            .Where(s => s.Id == userId)
            .ToOneAsync();
            user.UpdateAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            user.Integral = user.Integral + Integral;
            await _freeSql.Update<Users>().SetSource(user).ExecuteAffrowsAsync();
        }
        /// <summary>
        /// 增加用户信用值
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="CreditValue"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task AddUserXYZ(long userId, int CreditValue)
        {
            var user = await _freeSql.Select<Users>()
           .Where(s => s.Id == userId)
           .ToOneAsync();
            user.UpdateAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            user.CreditValue = user.CreditValue + CreditValue;
            //获取配置的等级积分
            var xydj = 0;

            if (user.CreditValue >= xydj)
            {
                user.Level = 1;//相应信用等级 
            }
            await _freeSql.Update<Users>().SetSource(user).ExecuteAffrowsAsync();
        }

        public int SelectUserTeam(long userId)
        {
            return 0;
        }

        /// <summary>
        /// 增加用户团队等级
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task AddUserTeam(long userId)
        {
            var user = await _freeSql.Select<Users>()
            .Where(s => s.Id == userId)
            .ToOneAsync();
            user.UpdateAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            user.TeamLevel = user.TeamLevel + 1;// 邀请人数注册人数达到对应等级是团队等级自动+一级
            await _freeSql.Update<Users>().SetSource(user).ExecuteAffrowsAsync();
        }

        /// <summary>
        ///  获取团队所有成员
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private async Task<List<Users>> GetTeamUserAllMembers(long userId)
        {
            var output = new List<Users>();
            var user = await _freeSql.Select<Users>()
                .Where(s => s.IsDeleted == 0)
                .Where(s => s.Id == userId)
                .ToOneAsync();
            if (user == null)
                return output;
            output.Add(user);
            var rootParentId = user.RootParentId > 0 ? user.RootParentId : user.Id;
            var users = await _freeSql.Select<Users>()
                .Where(s => s.IsDeleted == 0 && s.IsTeamUser == 1 && s.Id != userId)
                .Where(s => s.RootParentId == rootParentId)
                .ToListAsync();
            output.AddRange(users);
            return output;
        }

        /// <summary>
        ///  获取用户团队父级成员
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="maxSort"></param>
        /// <returns></returns>
        public async Task<List<TeamUsersDto>> GetUserTeamParentMembers(long userId, int maxSort = 0)
        {
            var output = new List<TeamUsersDto>();
            output.Add(new TeamUsersDto
            {
                UserId = userId,
                LevelSort = 0
            });
            var teamUsers = await GetTeamUserAllMembers(userId);
            var parentId = teamUsers.FirstOrDefault(s => s.Id == userId)?.ParentId ?? 0;
            var parentMembers = await TeamParentMembers(parentId,teamUsers,maxSort,1);
            output.AddRange(parentMembers);
            return output;
        }

        /// <summary>
        /// 获取父级成员
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="teamUsers"></param>
        /// <param name="maxSort"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        private async Task<List<TeamUsersDto>> TeamParentMembers(long parentId,List<Users> teamUsers,int maxSort,int sort = 0)
        {
            var output = new List<TeamUsersDto>();
            var user = teamUsers.FirstOrDefault(s => s.Id == parentId);
            if (user == null)
                return output;
            output.Add(new TeamUsersDto
            {
                UserId = parentId,
                LevelSort = sort
            });
            if (user.ParentId == 0 || (maxSort > 0 && maxSort == sort))
                return output;
            var members = await TeamParentMembers(user.ParentId,teamUsers,maxSort,sort+1);
            output.AddRange(members);

            return output;
        }

        /// <summary>
        ///  获取用户团队子级成员
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="maxSort"></param>
        /// <returns></returns>
        public async Task<List<TeamUsersDto>> GetUserTeamChildMembers(long userId, int maxSort = 0)
        {
            var output = new List<TeamUsersDto>();
            output.Add(new TeamUsersDto
            {
                UserId = userId,
                LevelSort = 0
            });
            var teamUsers = await GetTeamUserAllMembers(userId);
            var parentId = teamUsers.FirstOrDefault(s => s.Id == userId)?.ParentId ?? 0;
            var parentMembers = await TeamChildMembers(parentId,teamUsers,maxSort,1);
            output.AddRange(parentMembers);
            return output;
        }
        
        /// <summary>
        /// 获取子级成员
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="teamUsers"></param>
        /// <param name="maxSort"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        private async Task<List<TeamUsersDto>> TeamChildMembers(long parentId,List<Users> teamUsers,int maxSort,int sort = 0)
        {
            var output = new List<TeamUsersDto>();
            var user = teamUsers.FirstOrDefault(s => s.ParentId == parentId);
            if (user == null)
                return output;
            output.Add(new TeamUsersDto
            {
                UserId = parentId,
                LevelSort = sort
            });
            if (maxSort == sort && maxSort > 0)
                return output;
            var members = await TeamChildMembers(user.Id,teamUsers,maxSort,sort+1);
            output.AddRange(members);

            return output;
        }
    }
}